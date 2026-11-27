//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace Binance.Common;

// Layout of the error record the platform library fills in.
[StructLayout(LayoutKind.Sequential)]
internal unsafe struct BncError
{
    public int Kind;
    public int HttpStatus;
    public int HasCode;
    public int Reserved0;
    public long Code;
    public long RetryAfterSeconds;
    public long RetryAtMs;
    public int TransportCode;
    public fixed byte TransportCategory[32];
    public int RequestSent;
    public fixed byte Message[512];
    public int WsKind;
    public int Reserved1;
}

// Layout of the client options passed to the platform library.
[StructLayout(LayoutKind.Sequential)]
internal unsafe struct BncClientOptions
{
    public uint StructSize;
    public delegate* unmanaged[Cdecl]<nint, byte*, nuint, int, int, int> TlsVerify;
    public nint TlsVerifyData;
    public delegate* unmanaged[Cdecl]<nint, long> Timestamp;
    public nint TimestampData;
}

[StructLayout(LayoutKind.Sequential)]
internal unsafe struct BncRestResponse
{
    public int Status;
    public byte* Body;
    public nuint BodyLen;
    public byte* HeadersJson;
    public byte* RateLimitsJson;
}

// Native objects are owned by SafeHandles, so each is freed exactly once and never while a call that uses it is running.
internal abstract class NativeHandle : SafeHandleZeroOrMinusOneIsInvalid
{
    protected NativeHandle() : base(true) { }

    public static T Wrap<T>(nint raw) where T : NativeHandle, new()
    {
        var handle = new T();
        handle.SetHandle(raw);
        return handle;
    }
}

internal sealed class RestClientHandle : NativeHandle
{
    protected override bool ReleaseHandle() { Native.bnc_rest_free(handle); return true; }
}

internal sealed class StreamsHandle : NativeHandle
{
    protected override bool ReleaseHandle() { Native.bnc_streams_free(handle); return true; }
}

internal sealed class WsApiHandle : NativeHandle
{
    protected override bool ReleaseHandle() { Native.bnc_wsapi_free(handle); return true; }
}

internal sealed class StreamHandle : NativeHandle
{
    protected override bool ReleaseHandle() { Native.bnc_stream_free(handle); return true; }
}

internal sealed class RequestHandle : NativeHandle
{
    protected override bool ReleaseHandle() { Native.bnc_request_release(handle); return true; }
}

internal static unsafe partial class Native
{
    /// <summary>The interface version of the platform library that this assembly requires.</summary>
    public const uint AbiVersion = 5;

    /// <summary>Functions added to the library since <see cref="AbiVersion"/> was set: a library of the same ABI may lack them.</summary>
    internal static readonly string[] AddedExports = [];
    private const string Lib = "binance_c";

    // Every function and callback of binance_c.h uses the C calling convention. It is spelled out because the default of
    // LibraryImport on 32-bit Windows is stdcall.

    /// <summary>The runtime identifiers the package ships a platform library for.</summary>
    public static readonly string[] SupportedRuntimes =
        ["win-x64", "win-x86", "win-arm64", "linux-x64", "linux-arm64", "linux-arm", "linux-musl-x64", "linux-musl-arm64", "osx-x64", "osx-arm64"];

    static Native()
    {
        NativeLibrary.SetDllImportResolver(typeof(Native).Assembly, Resolve);
    }

    /// <summary>The handle of the platform library, found as the imports find it; zero if it cannot be loaded.</summary>
    public static IntPtr LibraryHandle()
    {
        var handle = Resolve(Lib, typeof(Native).Assembly, null);
        if (handle != IntPtr.Zero) return handle;
        return NativeLibrary.TryLoad(Lib, typeof(Native).Assembly, null, out handle) ? handle : IntPtr.Zero;
    }

    // The BINANCE_C_LIB environment variable overrides the library file; otherwise the runtime probes next to the
    // application and in runtimes/<rid>/native/ (where the NuGet package puts it).
    private static IntPtr Resolve(string name, Assembly assembly, DllImportSearchPath? searchPath)
    {
        if (name != Lib) return IntPtr.Zero;
        var path = Environment.GetEnvironmentVariable("BINANCE_C_LIB");
        if (string.IsNullOrEmpty(path)) return IntPtr.Zero;
        if (NativeLibrary.TryLoad(path, out var handle)) return handle;
        throw new BinanceLibraryException($"BINANCE_C_LIB is set to '{path}', which cannot be loaded as the platform library.");
    }

    [LibraryImport(Lib), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])] public static partial uint bnc_abi_version();
    [LibraryImport(Lib), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])] public static partial byte* bnc_version();
    [LibraryImport(Lib), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])] public static partial void bnc_set_thread_count(uint threads);
    [LibraryImport(Lib), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])] public static partial void bnc_set_log_level(int level);
    [LibraryImport(Lib), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void bnc_set_log_callback(delegate* unmanaged[Cdecl]<nint, int, byte*, nuint, void> callback, nint userData);

    [LibraryImport(Lib, StringMarshalling = StringMarshalling.Utf8), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial nint bnc_rest_new_ex(string configJson, BncClientOptions* options, BncError* error);
    [LibraryImport(Lib), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])] public static partial void bnc_rest_free(nint client);
    [LibraryImport(Lib, StringMarshalling = StringMarshalling.Utf8), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int bnc_rest_send(RestClientHandle client, string requestJson,
        delegate* unmanaged[Cdecl]<nint, BncError*, BncRestResponse*, void> callback, nint userData, nint* outRequest, BncError* error);

    [LibraryImport(Lib), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])] public static partial void bnc_request_cancel(RequestHandle request);
    [LibraryImport(Lib), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])] public static partial void bnc_request_release(nint request);

    [LibraryImport(Lib, StringMarshalling = StringMarshalling.Utf8), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial nint bnc_streams_new_ex(string configJson, string? urlPathsJson, BncClientOptions* options, BncError* error);
    [LibraryImport(Lib), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])] public static partial void bnc_streams_free(nint streams);
    [LibraryImport(Lib, StringMarshalling = StringMarshalling.Utf8), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int bnc_streams_connect(StreamsHandle streams, string? streamsJson,
        delegate* unmanaged[Cdecl]<nint, BncError*, void> callback, nint userData, nint* outRequest, BncError* error);
    [LibraryImport(Lib), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int bnc_streams_disconnect(StreamsHandle streams,
        delegate* unmanaged[Cdecl]<nint, BncError*, void> callback, nint userData, nint* outRequest, BncError* error);
    [LibraryImport(Lib), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])] public static partial int bnc_streams_is_connected(StreamsHandle streams);
    [LibraryImport(Lib, StringMarshalling = StringMarshalling.Utf8), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int bnc_streams_is_subscribed(StreamsHandle streams, string stream);
    [LibraryImport(Lib, StringMarshalling = StringMarshalling.Utf8), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int bnc_streams_wait_subscribed(StreamsHandle streams, string stream, string? urlPath,
        delegate* unmanaged[Cdecl]<nint, BncError*, void> callback, nint userData, nint* outRequest, BncError* error);
    [LibraryImport(Lib, StringMarshalling = StringMarshalling.Utf8), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial nint bnc_stream_new(StreamsHandle streams, string stream, string? urlPath, string? idJson,
        delegate* unmanaged[Cdecl]<nint, byte*, nuint, void> callback, nint userData,
        delegate* unmanaged[Cdecl]<nint, BncError*, void> onTerminated, nint terminatedData, BncError* error);
    [LibraryImport(Lib, StringMarshalling = StringMarshalling.Utf8), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int bnc_streams_subscribe(StreamsHandle streams, string streamsJson, string? urlPath, string? idJson, BncError* error);
    [LibraryImport(Lib, StringMarshalling = StringMarshalling.Utf8), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int bnc_streams_unsubscribe(StreamsHandle streams, string streamsJson, string? urlPath, string? idJson, BncError* error);
    [LibraryImport(Lib), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])] public static partial int bnc_stream_is_active(StreamHandle stream);
    [LibraryImport(Lib), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])] public static partial void bnc_stream_free(nint stream);
    [LibraryImport(Lib), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])] public static partial int bnc_streams_ping(StreamsHandle streams, BncError* error);
    [LibraryImport(Lib), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void bnc_streams_set_lifecycle_callback(StreamsHandle streams,
        delegate* unmanaged[Cdecl]<nint, int, byte*, nuint, ushort, byte*, void> callback, nint userData);
    [LibraryImport(Lib), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void bnc_streams_set_event_callback(StreamsHandle streams,
        delegate* unmanaged[Cdecl]<nint, int, byte*, nuint, ushort, byte*, void> callback, nint userData);

    [LibraryImport(Lib, StringMarshalling = StringMarshalling.Utf8), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial nint bnc_wsapi_new_ex(string configJson, BncClientOptions* options, BncError* error);
    [LibraryImport(Lib), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])] public static partial void bnc_wsapi_free(nint api);
    [LibraryImport(Lib), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int bnc_wsapi_connect(WsApiHandle api,
        delegate* unmanaged[Cdecl]<nint, BncError*, void> callback, nint userData, nint* outRequest, BncError* error);
    [LibraryImport(Lib), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int bnc_wsapi_disconnect(WsApiHandle api,
        delegate* unmanaged[Cdecl]<nint, BncError*, void> callback, nint userData, nint* outRequest, BncError* error);
    [LibraryImport(Lib), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])] public static partial int bnc_wsapi_is_connected(WsApiHandle api);
    [LibraryImport(Lib), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])] public static partial int bnc_wsapi_ping(WsApiHandle api, BncError* error);
    [LibraryImport(Lib), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void bnc_wsapi_set_lifecycle_callback(WsApiHandle api,
        delegate* unmanaged[Cdecl]<nint, int, byte*, nuint, ushort, byte*, void> callback, nint userData);
    [LibraryImport(Lib), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void bnc_wsapi_set_event_callback(WsApiHandle api,
        delegate* unmanaged[Cdecl]<nint, int, byte*, nuint, ushort, byte*, void> callback, nint userData);
    [LibraryImport(Lib, StringMarshalling = StringMarshalling.Utf8), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int bnc_wsapi_send(WsApiHandle api, string requestJson,
        delegate* unmanaged[Cdecl]<nint, BncError*, byte*, nuint, void> callback, nint userData, nint* outRequest, BncError* error);
    [LibraryImport(Lib, StringMarshalling = StringMarshalling.Utf8), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int bnc_wsapi_subscribe(WsApiHandle api, string requestJson,
        delegate* unmanaged[Cdecl]<nint, BncError*, byte*, nuint, nint, void> callback, nint userData,
        delegate* unmanaged[Cdecl]<nint, byte*, nuint, void> messageCallback, nint messageData, nint* outRequest, BncError* error);
}
