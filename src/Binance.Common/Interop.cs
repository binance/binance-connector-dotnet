//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Binance.Common;

// The user data of every native callback is an id into this table, never a pointer: a callback that arrives
// after its client was disposed finds no entry and does nothing.
internal static class Registry
{
    private static long _next;
    // Keyed by the pointer-sized id itself: a 64-bit key would never match again once a 32-bit id had been truncated.
    private static readonly ConcurrentDictionary<nint, object> Entries = new();

    public static nint Add(object value)
    {
        // On 32-bit platforms the id wraps around after 2^32 registrations; 0 (no id) and ids still in use are skipped.
        while (true)
        {
            var id = unchecked((nint)Interlocked.Increment(ref _next));
            if (id != 0 && Entries.TryAdd(id, value)) return id;
        }
    }

    public static T? Get<T>(nint id) where T : class => Entries.TryGetValue(id, out var v) ? v as T : null;

    public static T? Take<T>(nint id) where T : class => Entries.TryRemove(id, out var v) ? v as T : null;

    public static void Remove(nint id) => Entries.TryRemove(id, out _);
}

internal static class Interop
{
    private static readonly object Gate = new();
    private static bool _checked;

    /// <summary>Loads the platform library once and checks that its interface version is the one this assembly requires.</summary>
    public static void Check()
    {
        if (_checked) return;
        lock (Gate)
        {
            if (_checked) return;
            uint found;
            try
            {
                found = Native.bnc_abi_version();
            }
            catch (Exception e) when (e is DllNotFoundException or EntryPointNotFoundException or BadImageFormatException)
            {
                throw new BinanceLibraryException(
                    $"The platform library (libbinance_c) could not be loaded ({e.GetType().Name}). Binance.Common ships it for {string.Join(", ", Native.SupportedRuntimes)} " +
                    $"in runtimes/<rid>/native/; this process is {RuntimeInformation.RuntimeIdentifier}. Reinstall the package or see the Binance.Common README.", e);
            }
            if (found != Native.AbiVersion)
                throw new BinanceLibraryException($"The platform library has ABI version {found}, but this package requires version {Native.AbiVersion}. Use the library shipped with this package version.");
            // Functions added without an ABI change: an older library of the same ABI lacks them.
            var library = Native.LibraryHandle();
            foreach (var export in Native.AddedExports)
            {
                if (library == IntPtr.Zero || !NativeLibrary.TryGetExport(library, export, out _))
                    throw new BinanceLibraryException($"The platform library is older than this package (it has no {export}). Use the library shipped with this package version.");
            }
            // Warnings and errors only, unless LOG_LEVEL is set; BinanceLogging.SetLevel changes it later.
            if (Environment.GetEnvironmentVariable("LOG_LEVEL") is null) Native.bnc_set_log_level(2);
            _checked = true;
        }
    }

    /// <summary>Ends the task as cancelled when <paramref name="ct"/> cancels the request, and releases the handle.</summary>
    public static async Task<T> Cancellable<T>(Task<T> task, RequestHandle? request, CancellationToken ct)
    {
        if (request is null) return await task.ConfigureAwait(false);
        try
        {
            using var registration = ct.Register(static r =>
            {
                try { Native.bnc_request_cancel((RequestHandle)r!); }
                catch (ObjectDisposedException) { }
            }, request);
            try
            {
                return await task.ConfigureAwait(false);
            }
            catch (BinanceCancelledException) when (ct.IsCancellationRequested)
            {
                throw new OperationCanceledException(ct);
            }
        }
        finally
        {
            request.Dispose();
        }
    }

    // A callback that cannot deliver: logged, never rethrown into native code.
    public static void CallbackFailed(string callback, Exception e)
    {
        try { BinanceLogging.Warn($"The native callback {callback} failed with {e.GetType().Name}: {e.Message}"); }
        catch (Exception) { }
    }

    public static unsafe string Utf8(byte* p, nuint len) => Encoding.UTF8.GetString(p, checked((int)len));

    public static unsafe BinanceException Fail(BncError* e) => BinanceException.Create(e);

    /// <summary>As <see cref="Cancellable{T}"/>, for an operation without a result.</summary>
    public static async Task Cancellable(Task task, RequestHandle? request, CancellationToken ct)
    {
        static async Task<bool> Completed(Task t) { await t.ConfigureAwait(false); return true; }
        await Cancellable(Completed(task), request, ct).ConfigureAwait(false);
    }
}

/// <summary>
/// The certificate check of a client, called with each certificate of the chain being verified. <paramref name="preverified"/> is
/// whether the built-in checks (trusted chain, validity, host name) found no problem with this certificate so far. Return true to
/// accept the certificate and false to reject it (the handshake then fails). Returning true when <paramref name="preverified"/> is false
/// accepts the certificate anyway, which switches the verification off for the connection. It runs on background threads, possibly several at
/// a time, and must return quickly; an exception it throws rejects the certificate and is logged.
/// </summary>
/// <param name="certificate">The certificate; <paramref name="depth"/> 0 is the server certificate, higher depths its issuers. The caller disposes it.</param>
/// <param name="depth">Position in the chain.</param>
/// <param name="preverified">Whether the built-in checks passed so far.</param>
public delegate bool ServerCertificateValidator(X509Certificate2 certificate, int depth, bool preverified);

// The callbacks of a client (its certificate validator and timestamp provider), reached from native code through an id of the
// Registry. Disposing them (with the client) ends the callbacks.
internal sealed unsafe class TlsHook : IDisposable
{
    private readonly ServerCertificateValidator? _validator;
    private readonly Func<DateTimeOffset>? _timestamp;

    private TlsHook(ServerCertificateValidator? validator, Func<DateTimeOffset>? timestamp)
    {
        _validator = validator;
        _timestamp = timestamp;
        Id = Registry.Add(this);
    }

    public nint Id { get; }

    public static TlsHook? Create(ServerCertificateValidator? validator, Func<DateTimeOffset>? timestamp = null) =>
        validator is null && timestamp is null ? null : new TlsHook(validator, timestamp);

    public BncClientOptions Options() => new()
    {
        StructSize = (uint)sizeof(BncClientOptions),
        TlsVerify = _validator is null ? null : &OnVerify,
        TlsVerifyData = _validator is null ? 0 : Id,
        Timestamp = _timestamp is null ? null : &OnTimestamp,
        TimestampData = _timestamp is null ? 0 : Id,
    };

    [UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static int OnVerify(nint user, byte* der, nuint len, int depth, int preverified)
    {
        // A client that was disposed has no entry: the connection is going away, so reject.
        if (Registry.Get<TlsHook>(user) is not { _validator: { } validator }) return 0;
        try
        {
            var bytes = new ReadOnlySpan<byte>(der, checked((int)len));
#if NET9_0_OR_GREATER
            using var certificate = X509CertificateLoader.LoadCertificate(bytes);
#else
            using var certificate = new X509Certificate2(bytes.ToArray());
#endif
            return validator(certificate, depth, preverified != 0) ? 1 : 0;
        }
        catch (Exception e)
        {
            try { BinanceLogging.Warn($"The ServerCertificateValidator threw {e.GetType().Name}: {e.Message} The certificate was rejected."); }
            catch (Exception) { }
            return 0;
        }
    }

    // A provider that throws, or a client that was disposed, falls back to the host clock: the request is still sent.
    [UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static long OnTimestamp(nint user)
    {
        try
        {
            if (Registry.Get<TlsHook>(user) is { _timestamp: { } timestamp }) return timestamp().ToUnixTimeMilliseconds();
        }
        catch (Exception e)
        {
            try { BinanceLogging.Warn($"The TimestampProvider threw {e.GetType().Name}: {e.Message} The host clock was used."); }
            catch (Exception) { }
        }
        return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }

    public void Dispose() => Registry.Remove(Id);
}
