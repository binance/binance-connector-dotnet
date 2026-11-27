//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading.Channels;

namespace Binance.Common;

/// <summary>Process-wide settings.</summary>
public static unsafe class Library
{
    /// <summary>The version of the platform library that is loaded, e.g. <c>1.0.0</c>.</summary>
    /// <exception cref="BinanceLibraryException">The platform library cannot be loaded.</exception>
    public static string Version
    {
        get
        {
            Interop.Check();
            return Marshal.PtrToStringUTF8((nint)Native.bnc_version())!;
        }
    }

    /// <summary>Sets the number of threads of the I/O pool that every client shares (default 2). It takes effect only if it is called before the first client is created.</summary>
    /// <param name="threads">The number of threads.</param>
    public static void SetThreadCount(uint threads)
    {
        Interop.Check();
        Native.bnc_set_thread_count(threads);
    }
}

/// <summary>A raw REST response.</summary>
/// <param name="Status">HTTP status.</param>
/// <param name="Body">The response body.</param>
/// <param name="HeadersJson">The response headers, as a JSON object.</param>
/// <param name="RateLimitsJson">The rate limit counters of the response, as a JSON array.</param>
internal sealed record RestResponse(int Status, string Body, string HeadersJson, string RateLimitsJson);

/// <summary>The low-level REST client: JSON in, JSON out.</summary>
internal sealed unsafe class RestClient : IDisposable
{
    private readonly RestClientHandle _client;
    private readonly TlsHook? _tls;

    /// <summary>Creates a client from a JSON configuration.</summary>
    /// <param name="configJson">The configuration.</param>
    /// <param name="validator">Checks the certificates of the TLS handshakes; see <see cref="ServerCertificateValidator"/>.</param>
    /// <param name="timestamp">The timestamp of signed requests, or null for the host clock (plus <c>time_offset_ms</c>).</param>
    public RestClient(string configJson, ServerCertificateValidator? validator = null, Func<DateTimeOffset>? timestamp = null)
    {
        Interop.Check();
        _tls = TlsHook.Create(validator, timestamp);
        BncError e = default;
        var options = _tls?.Options() ?? default;
        var raw = Native.bnc_rest_new_ex(configJson, _tls is null ? null : &options, &e);
        if (raw == 0) { _tls?.Dispose(); throw Interop.Fail(&e); }
        _client = NativeHandle.Wrap<RestClientHandle>(raw);
    }

    /// <summary>Sends a request. Cancelling the token cancels the request in flight; the task then ends as cancelled.</summary>
    /// <param name="requestJson">The request, as JSON.</param>
    /// <param name="cancellationToken">Cancels the request.</param>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception, also when the request cannot be started. This method does not throw.</exception>
    public Task<RestResponse> SendAsync(string requestJson, CancellationToken cancellationToken = default)
    {
        nint id = 0;
        try
        {
            if (cancellationToken.IsCancellationRequested) return Task.FromCanceled<RestResponse>(cancellationToken);
            var tcs = new TaskCompletionSource<RestResponse>(TaskCreationOptions.RunContinuationsAsynchronously);
            id = Registry.Add(tcs);
            BncError e = default;
            nint request = 0;
            if (Native.bnc_rest_send(_client, requestJson, &OnComplete, id, cancellationToken.CanBeCanceled ? &request : null, &e) != 0)
            {
                Registry.Remove(id);
                return Task.FromException<RestResponse>(Interop.Fail(&e));
            }
            return Interop.Cancellable(tcs.Task, request == 0 ? null : NativeHandle.Wrap<RequestHandle>(request), cancellationToken);
        }
        catch (Exception e)
        {
            if (id != 0) Registry.Remove(id);
            return Task.FromException<RestResponse>(e);
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static void OnComplete(nint user, BncError* error, BncRestResponse* r)
    {
        var tcs = Registry.Take<TaskCompletionSource<RestResponse>>(user);
        if (tcs is null) return;
        try
        {
            if (error != null)
            {
                var failure = Interop.Fail(error);
                // An HTTP error comes with the response that caused it.
                if (r != null)
                {
                    try
                    {
                        failure.SetResponse(Interop.Utf8(r->Body, r->BodyLen), Wire.Headers(Marshal.PtrToStringUTF8((nint)r->HeadersJson)!),
                            Wire.RestLimits(Marshal.PtrToStringUTF8((nint)r->RateLimitsJson)!));
                    }
                    catch (Exception e)
                    {
                        Interop.CallbackFailed(nameof(OnComplete), e); // the error goes on without its response
                    }
                }
                tcs.TrySetException(failure);
            }
            else tcs.TrySetResult(new RestResponse(r->Status, Interop.Utf8(r->Body, r->BodyLen),
                Marshal.PtrToStringUTF8((nint)r->HeadersJson)!, Marshal.PtrToStringUTF8((nint)r->RateLimitsJson)!));
        }
        catch (Exception e)
        {
            tcs.TrySetException(e);
        }
    }

    /// <summary>Frees the client; requests in flight end with <see cref="BinanceCancelledException"/>.</summary>
    public void Dispose()
    {
        _client.Dispose();
        _tls?.Dispose();
    }
}

/// <summary>
/// A subscribed stream: events arrive on <see cref="Reader"/>, which completes when the subscription ends. Disposing unsubscribes.
/// </summary>
/// <remarks>
/// For a stream of <see cref="WebSocketStreams"/> the subscription ends, with a normal completion, when the client is disconnected or
/// disposed, and, with a <see cref="BinanceException"/> that <c>await foreach</c> throws, when the server rejects the SUBSCRIBE. It does
/// not end when a connection is lost and the client reconnects. A user-data subscription of the WebSocket API is not tracked by the
/// client: its reader completes only when it (or the client) is disposed.
/// </remarks>
internal sealed unsafe class StreamSubscription : IDisposable
{
    private readonly Channel<string> _channel;
    private readonly TaskCompletionSource _completion = new(TaskCreationOptions.RunContinuationsAsynchronously);
    private readonly nint _id;
    private readonly nint _terminationId;
    private readonly Action<StreamSubscription>? _release;
    private readonly string _name;
    private StreamHandle? _handle;
    private long _dropped;

    /// <param name="name">The stream, for the warning about dropped messages.</param>
    /// <param name="capacity">Bounds the buffer: the oldest message is dropped (and counted) when it is full. Unbounded when null.</param>
    /// <param name="release">Called on dispose.</param>
    /// <param name="tracked">Whether the library tells the end of the subscription (streams of <see cref="WebSocketStreams"/>).</param>
    internal StreamSubscription(string name, int? capacity, Action<StreamSubscription>? release = null, bool tracked = false)
    {
        _name = name;
        _channel = capacity is { } n
            ? Channel.CreateBounded<string>(new BoundedChannelOptions(n) { SingleWriter = true, FullMode = BoundedChannelFullMode.DropOldest }, _ => OnDropped())
            : Channel.CreateUnbounded<string>(new UnboundedChannelOptions { SingleWriter = true });
        _release = release;
        _id = Registry.Add(_channel);
        if (tracked) _terminationId = Registry.Add(this);
        _ = _completion.Task.ContinueWith(static t => _ = t.Exception, TaskContinuationOptions.OnlyOnFaulted); // observed here so that an unawaited Completion never raises UnobservedTaskException
    }

    /// <summary>The raw JSON messages.</summary>
    public ChannelReader<string> Reader => _channel.Reader;

    /// <summary>Completes when the subscription ends normally and faults with the <see cref="BinanceException"/> when it is rejected.</summary>
    public Task Completion => _completion.Task;

    /// <summary>Whether the stream is subscribed (or queued until a connection opens).</summary>
    public bool IsActive
    {
        get
        {
            if (_completion.Task.IsCompleted || _handle is not { IsClosed: false } handle) return false;
            try { return Native.bnc_stream_is_active(handle) != 0; }
            catch (ObjectDisposedException) { return false; } // disposed meanwhile
        }
    }

    internal nint Id => _id;

    /// <summary>How many messages the bounded buffer dropped because the reader was too slow.</summary>
    public long DroppedCount => Interlocked.Read(ref _dropped);

    internal nint TerminationId => _terminationId;

    internal void Attach(StreamHandle handle) => _handle = handle;

    internal void Complete(BinanceException? error = null)
    {
        _channel.Writer.TryComplete(error);
        if (error is null) _completion.TrySetResult(); else _completion.TrySetException(error);
    }

    // On the library thread that delivers the message, so it only counts, and warns now and then.
    private void OnDropped()
    {
        var n = Interlocked.Increment(ref _dropped);
        if (n == 1 || n % 10_000 == 0)
            BinanceLogging.Warn($"Stream {_name}: the reader is too slow for the buffer (EventBufferCapacity), {n} message(s) dropped so far.");
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    internal static void OnMessage(nint user, byte* data, nuint len)
    {
        try
        {
            Registry.Get<Channel<string>>(user)?.Writer.TryWrite(Interop.Utf8(data, len));
        }
        catch (Exception e)
        {
            Interop.CallbackFailed(nameof(OnMessage), e); // the message is lost; the stream goes on
        }
    }

    // Called at most once per subscription, and not when a connection is lost and restored.
    [UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    internal static void OnTerminated(nint user, BncError* error)
    {
        var sub = Registry.Take<StreamSubscription>(user);
        if (sub is null) return;
        try
        {
            sub.Complete(error == null ? null : Interop.Fail(error));
        }
        catch (Exception e)
        {
            Interop.CallbackFailed(nameof(OnTerminated), e);
            try { sub.Complete(e as BinanceException ?? new BinanceClientException("The subscription ended and its error could not be read: " + e.Message, e)); }
            catch (Exception) { }
        }
    }

    /// <summary>Unsubscribes and completes the reader. Safe to call more than once.</summary>
    public void Dispose()
    {
        _handle?.Dispose(); // no callback starts after this
        Registry.Remove(_id);
        if (_terminationId != 0) Registry.Remove(_terminationId);
        Complete();
        _release?.Invoke(this);
    }
}

/// <summary>The type of a connection's lifecycle event.</summary>
public enum ConnectionEventType
{
    /// <summary>A connection opened.</summary>
    Open = 0,
    /// <summary>A message (never delivered as a lifecycle event).</summary>
    Message,
    /// <summary>A connection failed.</summary>
    Error,
    /// <summary>A connection closed.</summary>
    Close,
    /// <summary>A ping frame was received.</summary>
    Ping,
    /// <summary>A pong frame was received.</summary>
    Pong,
}

/// <summary>A lifecycle event of a connection. <paramref name="Data"/> is the error text or close reason; <paramref name="CloseCode"/> is set on <see cref="ConnectionEventType.Close"/>.</summary>
public sealed record ConnectionEvent(ConnectionEventType Type, string Data, int CloseCode, string ConnectionId);

/// <summary>A message as the server sent it (the JSON text), and the connection it came on.</summary>
/// <param name="Data">The message, as JSON text.</param>
/// <param name="ConnectionId">The connection.</param>
public sealed record ConnectionMessage(string Data, string ConnectionId);

// Delivers the lifecycle events (everything but messages) of the connections of a client. Bounded: the server pings every
// connection about every 20 seconds, so a client whose events nobody reads would otherwise grow without end. The oldest
// event is dropped when the buffer is full, and counted.
// Messages are delivered too once EnableMessages is called (the library then builds them for this client): unbounded unless
// a capacity is given, like the buffers of subscriptions.
internal sealed unsafe class EventSink : IDisposable
{
    internal const int Capacity = 1024;

    private readonly Channel<ConnectionEvent> _channel;
    private volatile Channel<ConnectionMessage>? _messages;
    private long _dropped;
    private long _droppedMessages;

    public EventSink()
    {
        _channel = Channel.CreateBounded<ConnectionEvent>(
            new BoundedChannelOptions(Capacity) { SingleWriter = true, FullMode = BoundedChannelFullMode.DropOldest },
            _ => Interlocked.Increment(ref _dropped));
        Id = Registry.Add(this);
    }

    public nint Id { get; }
    public ChannelReader<ConnectionEvent> Reader => _channel.Reader;
    internal ChannelWriter<ConnectionEvent> Writer => _channel.Writer;

    /// <summary>How many events were dropped because the buffer was full (nobody read them in time).</summary>
    public long DroppedCount => Interlocked.Read(ref _dropped);

    /// <summary>The reader of the messages, or null until <see cref="EnableMessages"/>.</summary>
    public ChannelReader<ConnectionMessage>? Messages => _messages?.Reader;

    /// <summary>Creates the message channel; returns false if it existed (the native callback is then already set).</summary>
    public bool EnableMessages(int? capacity)
    {
        lock (_channel)
        {
            if (_messages is not null) return false;
            var messages = capacity is { } n
                ? Channel.CreateBounded<ConnectionMessage>(new BoundedChannelOptions(n) { SingleWriter = true, FullMode = BoundedChannelFullMode.DropOldest }, _ => OnMessageDropped())
                : Channel.CreateUnbounded<ConnectionMessage>(new UnboundedChannelOptions { SingleWriter = true });
            if (_channel.Reader.Completion.IsCompleted) messages.Writer.TryComplete();
            _messages = messages;
            return true;
        }
    }

    private void OnMessageDropped()
    {
        var n = Interlocked.Increment(ref _droppedMessages);
        if (n == 1 || n % 10_000 == 0)
            BinanceLogging.Warn($"Messages: the reader is too slow for the buffer (EventBufferCapacity), {n} message(s) dropped so far.");
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static void OnEvent(nint user, int type, byte* data, nuint len, ushort closeCode, byte* connectionId)
    {
        try
        {
            var sink = Registry.Get<EventSink>(user);
            if (sink is null) return;
            var id = connectionId == null ? "" : Marshal.PtrToStringUTF8((nint)connectionId)!;
            if (type == (int)ConnectionEventType.Message)
            {
                sink._messages?.Writer.TryWrite(new(data == null ? "" : Interop.Utf8(data, len), id));
                return;
            }
            var text = data == null ? "" : Interop.Utf8(data, len);
            sink._channel.Writer.TryWrite(new((ConnectionEventType)type, text, closeCode, id));
        }
        catch (Exception e)
        {
            Interop.CallbackFailed(nameof(OnEvent), e);
        }
    }

    public void Dispose()
    {
        Registry.Remove(Id);
        lock (_channel)
        {
            _channel.Writer.TryComplete();
            _messages?.Writer.TryComplete();
        }
    }
}

internal static unsafe class Status
{
    [UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static void OnStatus(nint user, BncError* error)
    {
        var tcs = Registry.Take<TaskCompletionSource>(user);
        if (tcs is null) return;
        try
        {
            if (error != null) tcs.TrySetException(Interop.Fail(error)); else tcs.TrySetResult();
        }
        catch (Exception e)
        {
            tcs.TrySetException(e);
        }
    }
}

/// <summary>The low-level WebSocket Streams client.</summary>
internal sealed unsafe partial class WebSocketStreams : IDisposable
{
    private readonly StreamsHandle _streams;
    private readonly TlsHook? _tls;
    private readonly EventSink _events = new();
    private readonly HashSet<StreamSubscription> _subscriptions = [];

    /// <summary>Creates a client from a JSON configuration.</summary>
    /// <param name="configJson">The configuration.</param>
    /// <param name="urlPathsJson">A JSON array of URL paths, or null.</param>
    /// <param name="validator">Checks the certificates of the TLS handshakes; see <see cref="ServerCertificateValidator"/>.</param>
    /// <param name="timestamp">The timestamp of signed requests, or null for the host clock (plus <c>time_offset_ms</c>).</param>
    public WebSocketStreams(string configJson, string? urlPathsJson = null, ServerCertificateValidator? validator = null, Func<DateTimeOffset>? timestamp = null)
    {
        Interop.Check();
        _tls = TlsHook.Create(validator, timestamp);
        BncError e = default;
        var options = _tls?.Options() ?? default;
        var raw = Native.bnc_streams_new_ex(configJson, urlPathsJson, _tls is null ? null : &options, &e);
        if (raw == 0) { _events.Dispose(); _tls?.Dispose(); throw Interop.Fail(&e); }
        _streams = NativeHandle.Wrap<StreamsHandle>(raw);
        Native.bnc_streams_set_lifecycle_callback(_streams, &EventSink.OnEvent, _events.Id);
    }

    /// <summary>Lifecycle events (open, close, error, ping, pong) of every connection.</summary>
    public ChannelReader<ConnectionEvent> Events => _events.Reader;

    public long DroppedEventCount => _events.DroppedCount;

    /// <summary>Whether a connection is open.</summary>
    public bool IsConnected
    {
        get
        {
            if (_streams.IsClosed) return false;
            try { return Native.bnc_streams_is_connected(_streams) != 0; }
            catch (ObjectDisposedException) { return false; } // disposed meanwhile
        }
    }

    /// <summary>Whether <paramref name="stream"/> is subscribed (or queued until its connection opens), on any URL path.</summary>
    public bool IsSubscribed(string stream)
    {
        ArgumentNullException.ThrowIfNull(stream);
        if (_streams.IsClosed) return false;
        int result;
        try { result = Native.bnc_streams_is_subscribed(_streams, stream); }
        catch (ObjectDisposedException) { return false; }
        // -1: the library could not check (an error, not "not subscribed").
        return result switch
        {
            1 => true,
            0 => false,
            _ => throw new InvalidOperationException($"The platform library could not check whether {stream} is subscribed."),
        };
    }

    /// <summary>Every message of every connection, from now on; see <see cref="EventSink.EnableMessages"/>.</summary>
    /// <exception cref="ObjectDisposedException">The client is disposed.</exception>
    public ChannelReader<ConnectionMessage> EnableMessages(int? capacity)
    {
        ObjectDisposedException.ThrowIf(_streams.IsClosed, this);
        if (_events.EnableMessages(capacity))
            Native.bnc_streams_set_event_callback(_streams, &EventSink.OnEvent, _events.Id);
        return _events.Messages!;
    }

    /// <summary>Sends a WebSocket ping frame on every open connection (fire and forget).</summary>
    public void PingServer()
    {
        BncError e = default;
        if (Native.bnc_streams_ping(_streams, &e) != 0) throw Interop.Fail(&e);
    }

    /// <summary>Opens the connections, subscribing to <paramref name="streamsJson"/> (a JSON array of stream names) on open.</summary>
    /// <remarks>
    /// Cancelling the token abandons the wait: the task ends as cancelled, but the connect itself is not cancelled and may still open the connections.
    /// </remarks>
    public Task ConnectAsync(string? streamsJson = null, CancellationToken cancellationToken = default)
    {
        nint id = 0;
        try
        {
            if (cancellationToken.IsCancellationRequested) return Task.FromCanceled(cancellationToken);
            var tcs = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
            id = Registry.Add(tcs);
            BncError e = default;
            nint request = 0;
            if (Native.bnc_streams_connect(_streams, streamsJson, &Status.OnStatus, id, cancellationToken.CanBeCanceled ? &request : null, &e) != 0)
            {
                Registry.Remove(id);
                return Task.FromException(Interop.Fail(&e));
            }
            return Interop.Cancellable(tcs.Task, request == 0 ? null : NativeHandle.Wrap<RequestHandle>(request), cancellationToken);
        }
        catch (Exception e)
        {
            if (id != 0) Registry.Remove(id);
            return Task.FromException(e);
        }
    }

    /// <summary>Closes the connections gracefully.</summary>
    /// <remarks>
    /// Cancelling the token abandons the wait: the task ends as cancelled, but the disconnect itself is not cancelled and may still close the connections and end the subscriptions.
    /// </remarks>
    public Task DisconnectAsync(CancellationToken cancellationToken = default)
    {
        nint id = 0;
        try
        {
            if (cancellationToken.IsCancellationRequested) return Task.FromCanceled(cancellationToken);
            var tcs = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
            id = Registry.Add(tcs);
            BncError e = default;
            nint request = 0;
            if (Native.bnc_streams_disconnect(_streams, &Status.OnStatus, id, cancellationToken.CanBeCanceled ? &request : null, &e) != 0)
            {
                Registry.Remove(id);
                return Task.FromException(Interop.Fail(&e));
            }
            return Interop.Cancellable(tcs.Task, request == 0 ? null : NativeHandle.Wrap<RequestHandle>(request), cancellationToken);
        }
        catch (Exception e)
        {
            if (id != 0) Registry.Remove(id);
            return Task.FromException(e);
        }
    }

    /// <summary>
    /// Completes once the server has acknowledged the subscription of <paramref name="stream"/> (at once if it already has), and faults
    /// with the server's rejection, or with <see cref="BinanceCancelledException"/> if the stream is not subscribed or stops being before.
    /// </summary>
    /// <remarks>Cancelling the token abandons the wait: the task ends as cancelled, and the subscription stays.</remarks>
    public Task WaitSubscribedAsync(string stream, string? urlPath = null, CancellationToken cancellationToken = default)
    {
        nint id = 0;
        try
        {
            if (cancellationToken.IsCancellationRequested) return Task.FromCanceled(cancellationToken);
            var tcs = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
            id = Registry.Add(tcs);
            BncError e = default;
            nint request = 0;
            if (Native.bnc_streams_wait_subscribed(_streams, stream, urlPath, &Status.OnStatus, id, cancellationToken.CanBeCanceled ? &request : null, &e) != 0)
            {
                Registry.Remove(id);
                return Task.FromException(Interop.Fail(&e));
            }
            return Interop.Cancellable(tcs.Task, request == 0 ? null : NativeHandle.Wrap<RequestHandle>(request), cancellationToken);
        }
        catch (Exception e)
        {
            if (id != 0) Registry.Remove(id);
            return Task.FromException(e);
        }
    }

    /// <summary>
    /// Subscribes to a stream name; the subscription is sent once a connection opens. <paramref name="capacity"/> bounds
    /// the buffer (the oldest message is dropped when it is full); it is unbounded by default, so that a slow reader
    /// loses nothing. <paramref name="idJson"/> is the SUBSCRIBE id (a JSON number or string).
    /// </summary>
    public StreamSubscription Subscribe(string stream, string? urlPath = null, int? capacity = null, string? idJson = null)
    {
        var sub = new StreamSubscription(stream, capacity, s => { lock (_subscriptions) _subscriptions.Remove(s); }, tracked: true);
        lock (_subscriptions) _subscriptions.Add(sub);
        BncError e = default;
        nint raw;
        try { raw = Native.bnc_stream_new(_streams, stream, urlPath, idJson, &StreamSubscription.OnMessage, sub.Id, &StreamSubscription.OnTerminated, sub.TerminationId, &e); }
        catch { sub.Dispose(); throw; }
        if (raw == 0) { sub.Dispose(); throw Interop.Fail(&e); }
        sub.Attach(NativeHandle.Wrap<StreamHandle>(raw));
        return sub;
    }

    /// <summary>Subscribes to the stream names of <paramref name="streamsJson"/> (a JSON array) without a handle.</summary>
    public void SubscribeNames(string streamsJson, string? urlPath, string? idJson)
    {
        BncError e = default;
        if (Native.bnc_streams_subscribe(_streams, streamsJson, urlPath, idJson, &e) != 0) throw Interop.Fail(&e);
    }

    /// <summary>Unsubscribes from the stream names of <paramref name="streamsJson"/> (a JSON array).</summary>
    public void UnsubscribeNames(string streamsJson, string? urlPath, string? idJson)
    {
        BncError e = default;
        if (Native.bnc_streams_unsubscribe(_streams, streamsJson, urlPath, idJson, &e) != 0) throw Interop.Fail(&e);
    }

    /// <summary>Frees the client at once: subscriptions end and their readers complete.</summary>
    public void Dispose()
    {
        if (_streams.IsClosed) return;
        StreamSubscription[] open;
        lock (_subscriptions) open = [.. _subscriptions];
        foreach (var s in open) s.Dispose(); // streams must be released before their client
        try { Native.bnc_streams_set_lifecycle_callback(_streams, null, 0); }
        catch (ObjectDisposedException) { }
        _streams.Dispose();
        _events.Dispose();
        _tls?.Dispose();
    }
}

/// <summary>The response to a request that opened a subscription, and the subscription.</summary>
internal sealed record WebSocketApiSubscribed(string ResponseJson, StreamSubscription Events);

internal sealed record PendingSubscription(TaskCompletionSource<WebSocketApiSubscribed> Completion, StreamSubscription Subscription);

/// <summary>The low-level WebSocket API client.</summary>
internal sealed unsafe partial class WebSocketApi : IDisposable
{
    private readonly WsApiHandle _api;
    private readonly TlsHook? _tls;
    private readonly EventSink _events = new();
    private readonly HashSet<StreamSubscription> _subscriptions = [];

    /// <summary>Creates a client from a JSON configuration.</summary>
    /// <param name="configJson">The configuration.</param>
    /// <param name="validator">Checks the certificates of the TLS handshakes; see <see cref="ServerCertificateValidator"/>.</param>
    /// <param name="timestamp">The timestamp of signed requests, or null for the host clock (plus <c>time_offset_ms</c>).</param>
    public WebSocketApi(string configJson, ServerCertificateValidator? validator = null, Func<DateTimeOffset>? timestamp = null)
    {
        Interop.Check();
        _tls = TlsHook.Create(validator, timestamp);
        BncError e = default;
        var options = _tls?.Options() ?? default;
        var raw = Native.bnc_wsapi_new_ex(configJson, _tls is null ? null : &options, &e);
        if (raw == 0) { _events.Dispose(); _tls?.Dispose(); throw Interop.Fail(&e); }
        _api = NativeHandle.Wrap<WsApiHandle>(raw);
        Native.bnc_wsapi_set_lifecycle_callback(_api, &EventSink.OnEvent, _events.Id);
    }

    /// <summary>Lifecycle events (open, close, error, ping, pong) of every connection.</summary>
    public ChannelReader<ConnectionEvent> Events => _events.Reader;

    public long DroppedEventCount => _events.DroppedCount;

    /// <summary>Whether a connection is open.</summary>
    public bool IsConnected
    {
        get
        {
            if (_api.IsClosed) return false;
            try { return Native.bnc_wsapi_is_connected(_api) != 0; }
            catch (ObjectDisposedException) { return false; } // disposed meanwhile
        }
    }

    /// <summary>Every message of every connection, from now on; see <see cref="EventSink.EnableMessages"/>.</summary>
    /// <exception cref="ObjectDisposedException">The client is disposed.</exception>
    public ChannelReader<ConnectionMessage> EnableMessages(int? capacity)
    {
        ObjectDisposedException.ThrowIf(_api.IsClosed, this);
        if (_events.EnableMessages(capacity))
            Native.bnc_wsapi_set_event_callback(_api, &EventSink.OnEvent, _events.Id);
        return _events.Messages!;
    }

    /// <summary>Sends a WebSocket ping frame on every open connection (fire and forget).</summary>
    public void PingServer()
    {
        BncError e = default;
        if (Native.bnc_wsapi_ping(_api, &e) != 0) throw Interop.Fail(&e);
    }

    /// <summary>Opens the connections.</summary>
    /// <remarks>
    /// Cancelling the token abandons the wait: the task ends as cancelled, but the connect itself is not cancelled and may still open the connections.
    /// </remarks>
    public Task ConnectAsync(CancellationToken cancellationToken = default)
    {
        nint id = 0;
        try
        {
            if (cancellationToken.IsCancellationRequested) return Task.FromCanceled(cancellationToken);
            var tcs = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
            id = Registry.Add(tcs);
            BncError e = default;
            nint request = 0;
            if (Native.bnc_wsapi_connect(_api, &Status.OnStatus, id, cancellationToken.CanBeCanceled ? &request : null, &e) != 0)
            {
                Registry.Remove(id);
                return Task.FromException(Interop.Fail(&e));
            }
            return Interop.Cancellable(tcs.Task, request == 0 ? null : NativeHandle.Wrap<RequestHandle>(request), cancellationToken);
        }
        catch (Exception e)
        {
            if (id != 0) Registry.Remove(id);
            return Task.FromException(e);
        }
    }

    /// <summary>Closes the connections gracefully.</summary>
    /// <remarks>
    /// Cancelling the token abandons the wait: the task ends as cancelled, but the disconnect itself is not cancelled and may still close the connections.
    /// </remarks>
    public Task DisconnectAsync(CancellationToken cancellationToken = default)
    {
        nint id = 0;
        try
        {
            if (cancellationToken.IsCancellationRequested) return Task.FromCanceled(cancellationToken);
            var tcs = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
            id = Registry.Add(tcs);
            BncError e = default;
            nint request = 0;
            if (Native.bnc_wsapi_disconnect(_api, &Status.OnStatus, id, cancellationToken.CanBeCanceled ? &request : null, &e) != 0)
            {
                Registry.Remove(id);
                return Task.FromException(Interop.Fail(&e));
            }
            return Interop.Cancellable(tcs.Task, request == 0 ? null : NativeHandle.Wrap<RequestHandle>(request), cancellationToken);
        }
        catch (Exception e)
        {
            if (id != 0) Registry.Remove(id);
            return Task.FromException(e);
        }
    }

    /// <summary>Sends a request and returns the JSON array of responses (one per answering connection).</summary>
    public Task<string> SendAsync(string requestJson, CancellationToken cancellationToken = default)
    {
        nint id = 0;
        try
        {
            if (cancellationToken.IsCancellationRequested) return Task.FromCanceled<string>(cancellationToken);
            var tcs = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);
            id = Registry.Add(tcs);
            BncError e = default;
            nint request = 0;
            if (Native.bnc_wsapi_send(_api, requestJson, &OnSend, id, cancellationToken.CanBeCanceled ? &request : null, &e) != 0)
            {
                Registry.Remove(id);
                return Task.FromException<string>(Interop.Fail(&e));
            }
            return Interop.Cancellable(tcs.Task, request == 0 ? null : NativeHandle.Wrap<RequestHandle>(request), cancellationToken);
        }
        catch (Exception e)
        {
            if (id != 0) Registry.Remove(id);
            return Task.FromException<string>(e);
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static void OnSend(nint user, BncError* error, byte* json, nuint len)
    {
        var tcs = Registry.Take<TaskCompletionSource<string>>(user);
        if (tcs is null) return;
        try
        {
            if (error != null) tcs.TrySetException(WithErrorDetails(Interop.Fail(error), json, len)); else tcs.TrySetResult(Interop.Utf8(json, len));
        }
        catch (Exception e)
        {
            tcs.TrySetException(e);
        }
    }

    /// <summary>
    /// Sends a request that opens a user-data subscription; the request is repeated after every reconnect.
    /// <paramref name="capacity"/> bounds the buffer of the events (the oldest is dropped when it is full); unbounded by default.
    /// </summary>
    /// <remarks>
    /// Cancelling the token abandons the wait: the task ends as cancelled, but the request itself is not cancelled: the subscription may still be opened on the server, and the client then ends it there, as disposing the subscription does.
    /// </remarks>
    public Task<WebSocketApiSubscribed> SubscribeAsync(string requestJson, int? capacity = null, CancellationToken cancellationToken = default)
    {
        StreamSubscription? sub = null;
        nint id = 0;
        try
        {
            if (cancellationToken.IsCancellationRequested) return Task.FromCanceled<WebSocketApiSubscribed>(cancellationToken);
            sub = new StreamSubscription("userDataStream", capacity, s => { lock (_subscriptions) _subscriptions.Remove(s); });
            lock (_subscriptions) _subscriptions.Add(sub);
            var tcs = new TaskCompletionSource<WebSocketApiSubscribed>(TaskCreationOptions.RunContinuationsAsynchronously);
            id = Registry.Add(new PendingSubscription(tcs, sub));
            BncError e = default;
            nint request = 0;
            if (Native.bnc_wsapi_subscribe(_api, requestJson, &OnSubscribed, id, &StreamSubscription.OnMessage, sub.Id, cancellationToken.CanBeCanceled ? &request : null, &e) != 0)
            {
                Registry.Remove(id);
                sub.Dispose();
                return Task.FromException<WebSocketApiSubscribed>(Interop.Fail(&e));
            }
            return Interop.Cancellable(tcs.Task, request == 0 ? null : NativeHandle.Wrap<RequestHandle>(request), cancellationToken);
        }
        catch (Exception e)
        {
            if (id != 0) Registry.Remove(id);
            try { sub?.Dispose(); } catch (Exception) { }
            return Task.FromException<WebSocketApiSubscribed>(e);
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static void OnSubscribed(nint user, BncError* error, byte* json, nuint len, nint stream)
    {
        if (Registry.Take<PendingSubscription>(user) is not { } entry)
        {
            if (error == null && stream != 0) Native.bnc_stream_free(stream);
            return;
        }
        var (tcs, sub) = (entry.Completion, entry.Subscription);
        try
        {
            if (error != null) { sub.Dispose(); tcs.TrySetException(WithErrorDetails(Interop.Fail(error), json, len)); return; }
            sub.Attach(NativeHandle.Wrap<StreamHandle>(stream));
            tcs.TrySetResult(new WebSocketApiSubscribed(Interop.Utf8(json, len), sub));
        }
        catch (Exception e)
        {
            try { sub.Dispose(); } catch (Exception) { }
            tcs.TrySetException(e);
        }
    }

    // An error answered by the server comes with {"rateLimits": [...], "data": ...}: the rate limits of that answer, and its error.data.
    private static BinanceException WithErrorDetails(BinanceException failure, byte* json, nuint len)
    {
        if (json == null) return failure;
        try
        {
            using var doc = JsonDocument.Parse(Interop.Utf8(json, len));
            if (doc.RootElement.TryGetProperty("rateLimits", out var limits)) failure.SetWebSocketRateLimits(Wire.WebSocketLimits(limits));
            if (doc.RootElement.TryGetProperty("data", out var data)) failure.SetErrorData(data.Clone());
        }
        catch (Exception e)
        {
            Interop.CallbackFailed(nameof(WithErrorDetails), e); // the error goes on without its details
        }
        return failure;
    }

    /// <summary>Frees the client at once: requests in flight end with <see cref="BinanceCancelledException"/> and subscriptions complete.</summary>
    public void Dispose()
    {
        if (_api.IsClosed) return;
        StreamSubscription[] open;
        lock (_subscriptions) open = [.. _subscriptions];
        foreach (var s in open) s.Dispose();
        try { Native.bnc_wsapi_set_lifecycle_callback(_api, null, 0); }
        catch (ObjectDisposedException) { }
        _api.Dispose();
        _events.Dispose();
        _tls?.Dispose();
    }
}

internal sealed partial class WebSocketStreams : IAsyncDisposable
{
    /// <summary>Disconnects gracefully (waiting at most 5 seconds), then frees the client.</summary>
    public async ValueTask DisposeAsync()
    {
        if (!_streams.IsClosed && IsConnected)
        {
            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            try { await DisconnectAsync(timeout.Token).ConfigureAwait(false); }
            catch (Exception e) when (e is BinanceException or OperationCanceledException or ObjectDisposedException) { }
        }
        Dispose();
    }
}

internal sealed partial class WebSocketApi : IAsyncDisposable
{
    /// <summary>Disconnects gracefully (waiting at most 5 seconds), then frees the client.</summary>
    public async ValueTask DisposeAsync()
    {
        if (!_api.IsClosed && IsConnected)
        {
            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            try { await DisconnectAsync(timeout.Token).ConfigureAwait(false); }
            catch (Exception e) when (e is BinanceException or OperationCanceledException or ObjectDisposedException) { }
        }
        Dispose();
    }
}
