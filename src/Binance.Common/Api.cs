//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Channels;

namespace Binance.Common;

/// <summary>A REST response: its status, headers and rate limits, and the body, decoded by <see cref="Data"/>.</summary>
/// <typeparam name="T">The type of the body.</typeparam>
public sealed class RestApiResponse<T>
{
    private readonly Decoded<T> _data;

    internal RestApiResponse(Func<T?> decode, int status, IReadOnlyList<RestApiRateLimit> rateLimits, IReadOnlyDictionary<string, string> headers)
    {
        _data = new Decoded<T>(decode);
        Status = status;
        RateLimits = rateLimits;
        Headers = headers;
    }

    /// <summary>Decodes the body (once; later calls return the same value). Null when the body is empty.</summary>
    /// <exception cref="BinanceClientException">The body does not decode into <typeparamref name="T"/>.</exception>
    public T? Data() => _data.Value;

    /// <summary>HTTP status.</summary>
    public int Status { get; }

    /// <summary>Rate limit counters of the response.</summary>
    public IReadOnlyList<RestApiRateLimit> RateLimits { get; }

    /// <summary>Response headers, with lower-case names.</summary>
    public IReadOnlyDictionary<string, string> Headers { get; }
}

/// <summary>A WebSocket API response: its rate limits, and the result, decoded by <see cref="Data"/>.</summary>
/// <typeparam name="T">The type of the result.</typeparam>
public sealed class WebSocketApiResponse<T>
{
    private readonly Decoded<T> _data;

    internal WebSocketApiResponse(Func<T?> decode, IReadOnlyList<WebSocketApiRateLimit> rateLimits)
    {
        _data = new Decoded<T>(decode);
        RateLimits = rateLimits;
    }

    /// <summary>Decodes the result (once; later calls return the same value).</summary>
    /// <exception cref="BinanceClientException">The result does not decode into <typeparamref name="T"/>.</exception>
    public T? Data() => _data.Value;

    /// <summary>Rate limit counters of the response.</summary>
    public IReadOnlyList<WebSocketApiRateLimit> RateLimits { get; }
}

// Decodes once, on first use, and keeps the value or the error (Lazy<T> carries a trimming annotation that T would need too).
internal sealed class Decoded<T>(Func<T?> decode)
{
    private readonly object _lock = new();
    private Func<T?>? _decode = decode;
    private T? _value;
    private System.Runtime.ExceptionServices.ExceptionDispatchInfo? _error;

    public T? Value
    {
        get
        {
            lock (_lock)
            {
                if (Interlocked.Exchange(ref _decode, null) is { } d)
                {
                    try { _value = d(); }
                    catch (Exception e) { _error = System.Runtime.ExceptionServices.ExceptionDispatchInfo.Capture(e); }
                }
                _error?.Throw();
                return _value;
            }
        }
    }
}

// Removes a callback.
internal sealed class CallbackRegistration(Action remove) : IDisposable
{
    private Action? _remove = remove;

    public void Dispose() => Interlocked.Exchange(ref _remove, null)?.Invoke();
}

// Delivers the items of a single-reader channel either to one reader or to any number of callbacks, which a task calls one item
// at a time, in order. A callback that throws is logged; the others still get the item.
internal sealed class Dispatcher<T>(ChannelReader<T> reader, string name)
{
    private const int Unclaimed = 0, ByReader = 1, ByCallbacks = 2;
    private readonly List<Func<T, ValueTask>> _callbacks = [];
    private int _mode;
    private Task? _pump;

    public ChannelReader<T> Reader
    {
        get
        {
            Claim(ByReader);
            return reader;
        }
    }

    public IDisposable Add(Func<T, ValueTask> callback)
    {
        ArgumentNullException.ThrowIfNull(callback);
        Claim(ByCallbacks);
        lock (_callbacks)
        {
            _callbacks.Add(callback);
            _pump ??= Task.Run(PumpAsync);
        }
        return new CallbackRegistration(() => { lock (_callbacks) _callbacks.Remove(callback); });
    }

    public IDisposable Add(Action<T> callback)
    {
        ArgumentNullException.ThrowIfNull(callback);
        return Add(item => { callback(item); return ValueTask.CompletedTask; });
    }

    private void Claim(int mode)
    {
        var previous = Interlocked.CompareExchange(ref _mode, mode, Unclaimed);
        if (previous != Unclaimed && previous != mode)
            throw new InvalidOperationException(mode == ByReader
                ? $"{name} are delivered to callbacks: the reader is not available once a callback is added."
                : $"{name} are read from the reader: add callbacks before reading it, not both.");
    }

    private async Task PumpAsync()
    {
        try
        {
            await foreach (var item in reader.ReadAllAsync().ConfigureAwait(false))
            {
                Func<T, ValueTask>[] callbacks;
                lock (_callbacks) callbacks = [.. _callbacks];
                foreach (var callback in callbacks)
                {
                    try { await callback(item).ConfigureAwait(false); }
                    catch (Exception e) { BinanceLogging.Warn($"{name}: a callback threw {e.GetType().Name}: {e.Message}"); }
                }
            }
        }
        catch (Exception)
        {
            // The channel faulted (a rejected subscription): Completion tells it.
        }
    }
}

// Typed view of the raw event channel. A message that does not decode is skipped, logged and counted: the stream goes on.
// Streams that send one message with an array of events (or the other way round) are tolerated: an array message is delivered
// as one event for each element when the event type is not a list, and a single object is wrapped when the event type is a list.
internal sealed class EventReader<T>(ChannelReader<string> inner, JsonTypeInfo<T> info, string name) : ChannelReader<T>
{
    private readonly Queue<T> _pending = new();
    private long _failures;

    public long Failures => Interlocked.Read(ref _failures);

    public override Task Completion => inner.Completion;

    public override bool TryRead(out T item)
    {
        lock (_pending)
        {
            while (true)
            {
                if (_pending.TryDequeue(out item!)) return true;
                if (!inner.TryRead(out var json)) return false;
                Decode(json);
            }
        }
    }

    public override ValueTask<bool> WaitToReadAsync(CancellationToken cancellationToken = default)
    {
        lock (_pending)
        {
            if (_pending.Count > 0) return new ValueTask<bool>(true);
        }
        return inner.WaitToReadAsync(cancellationToken);
    }

    private void Decode(string json)
    {
        try
        {
            if (JsonSerializer.Deserialize(json, info) is { } value) _pending.Enqueue(value);
            return;
        }
        catch (JsonException e)
        {
            if (!TryOtherShape(json)) Fail(json, e);
        }
    }

    // The other shape of the same events: an array of events for an event type, or an object for a list type.
    private bool TryOtherShape(string json)
    {
        var trimmed = json.AsSpan().TrimStart();
        var first = trimmed.Length > 0 ? trimmed[0] : '\0';
        try
        {
            if (first == '[')
            {
                using var doc = JsonDocument.Parse(json);
                var elements = new List<T>();
                foreach (var element in doc.RootElement.EnumerateArray())
                    if (element.Deserialize(info) is { } value) elements.Add(value);
                foreach (var value in elements) _pending.Enqueue(value);
                return true;
            }
            if (first == '{' && JsonSerializer.Deserialize("[" + json + "]", info) is { } list)
            {
                _pending.Enqueue(list);
                return true;
            }
        }
        catch (JsonException)
        {
        }
        return false;
    }

    private void Fail(string json, JsonException e)
    {
        Interlocked.Increment(ref _failures);
        BinanceLogging.Warn($"Stream {name}: skipped a message that does not decode as {typeof(T).Name}: {e.Message} Payload: {(json.Length > 512 ? json[..512] + "..." : json)}");
    }
}

/// <summary>
/// Typed events of a subscription. They are delivered either to <see cref="Events"/>, a reader, or to the callbacks of
/// <see cref="OnMessage(Action{TEvent})"/>, not both. The subscription completes when it ends (the connection is disconnected or
/// disposed, or the subscription is unsubscribed) and faults when the server rejects the SUBSCRIBE; a lost connection that is
/// restored does not end it. A user-data subscription of the WebSocket API completes only when it is unsubscribed. Disposing
/// unsubscribes.
/// </summary>
/// <remarks>
/// The buffer is unbounded unless the configuration sets <c>EventBufferCapacity</c>, in which case the oldest event is
/// dropped when a slow reader lets it fill up: counted in <see cref="DroppedEventCount"/> and logged as a warning. Check it
/// when the events build state (an order book from depth updates): a drop means the state must be rebuilt. Read with <c>await foreach (var e in subscription.Events.ReadAllAsync(ct))</c>
/// or <see cref="RunAsync"/>. A message that does not decode into <typeparamref name="TEvent"/> is skipped, logged as a warning and
/// counted in <see cref="DecodeFailureCount"/>; it does not end the stream.
/// </remarks>
/// <typeparam name="TEvent">The type of an event.</typeparam>
public class EventSubscription<TEvent> : IDisposable
{
    private readonly StreamSubscription _sub;
    private readonly EventReader<TEvent> _reader;
    private readonly Dispatcher<TEvent> _dispatcher;
    private readonly Func<CancellationToken, Task>? _waitSubscribed;

    internal EventSubscription(StreamSubscription sub, JsonTypeInfo<TEvent> info, string name, Func<CancellationToken, Task>? waitSubscribed = null)
    {
        _sub = sub;
        _reader = new EventReader<TEvent>(sub.Reader, info, name);
        _dispatcher = new Dispatcher<TEvent>(_reader, $"The events of {name}");
        _waitSubscribed = waitSubscribed;
    }

    /// <summary>The events. The reader completes when the subscription ends and faults with a <see cref="BinanceException"/> when the server rejects it.</summary>
    /// <exception cref="InvalidOperationException">The events go to callbacks (<see cref="OnMessage(Action{TEvent})"/>).</exception>
    public ChannelReader<TEvent> Events => _dispatcher.Reader;

    /// <summary>
    /// Adds a callback for the events, like <c>stream.on('message', callback)</c> of the other connectors. Every callback gets every
    /// event, in order, one event at a time, on a thread-pool thread; one that throws is logged and the others still run. Disposing
    /// the result removes the callback. Once a callback is added, <see cref="Events"/> is not available.
    /// </summary>
    /// <param name="callback">Called for each event.</param>
    /// <exception cref="InvalidOperationException"><see cref="Events"/> was read.</exception>
    public IDisposable OnMessage(Action<TEvent> callback) => _dispatcher.Add(callback);

    /// <summary>As <see cref="OnMessage(Action{TEvent})"/>, with an asynchronous callback: the next event waits for it.</summary>
    /// <param name="callback">Called for each event.</param>
    /// <exception cref="InvalidOperationException"><see cref="Events"/> was read.</exception>
    public IDisposable OnMessage(Func<TEvent, ValueTask> callback) => _dispatcher.Add(callback);

    /// <summary>Completes when the subscription ends: normally when the client is disconnected or disposed, and with a <see cref="BinanceException"/> when the server rejects it.</summary>
    /// <remarks>It does not end when a connection is lost and the client reconnects. A user-data subscription of the WebSocket API ends only when it, or the client, is disposed.</remarks>
    public Task Completion => _sub.Completion;

    /// <summary>Whether the stream is still subscribed.</summary>
    public bool IsActive => _sub.IsActive;

    /// <summary>How many messages did not decode into <typeparamref name="TEvent"/> and were skipped.</summary>
    public long DecodeFailureCount => _reader.Failures;

    /// <summary>How many messages were dropped because the buffer (<c>EventBufferCapacity</c>) was full; always 0 when it is unbounded.</summary>
    public long DroppedEventCount => _sub.DroppedCount;

    /// <summary>
    /// Completes once the server has acknowledged the subscription (at once if it already has, and at once for a user-data
    /// subscription); while the connection opens or reconnects, it waits. A stream the server rejects faults it with
    /// <see cref="BinanceWebSocketResponseException"/>; one that ends first (unsubscribed, disconnected) with
    /// <see cref="BinanceCancelledException"/>.
    /// </summary>
    /// <param name="cancellationToken">Abandons the wait (the task ends as cancelled); the subscription stays.</param>
    public Task WaitSubscribedAsync(CancellationToken cancellationToken = default) =>
        _waitSubscribed?.Invoke(cancellationToken) ?? (cancellationToken.IsCancellationRequested ? Task.FromCanceled(cancellationToken) : Task.CompletedTask);

    /// <summary>Calls <paramref name="handler"/> for each event until the token is cancelled or the subscription completes.</summary>
    public async Task RunAsync(Func<TEvent, ValueTask> handler, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(handler);
        await foreach (var e in Events.ReadAllAsync(cancellationToken).ConfigureAwait(false))
            await handler(e).ConfigureAwait(false);
    }

    /// <summary>Unsubscribes: the events stop and <see cref="Completion"/> completes. The same as <see cref="Dispose"/>.</summary>
    /// <remarks>A user-data subscription of the WebSocket API is ended on the server (userDataStream.unsubscribe with its current subscriptionId, on the connection that holds it), and is no longer sent again after reconnects.</remarks>
    public void Unsubscribe() => Dispose();

    /// <summary>Unsubscribes.</summary>
    public void Dispose()
    {
        _sub.Dispose();
        GC.SuppressFinalize(this);
    }
}

/// <summary>The response to a request that opened a user-data subscription, and the events that follow.</summary>
/// <typeparam name="T">The type of the response.</typeparam>
/// <typeparam name="TEvent">The type of an event.</typeparam>
public sealed class WebSocketApiSubscription<T, TEvent> : EventSubscription<TEvent>
{
    internal WebSocketApiSubscription(WebSocketApiResponse<T> response, StreamSubscription sub, JsonTypeInfo<TEvent> info, string name) : base(sub, info, name) => Response = response;

    /// <summary>The response to the request.</summary>
    public WebSocketApiResponse<T> Response { get; }
}

/// <summary>The REST client behind the product clients (for example <c>SpotRestApi</c>); use a product client rather than this class.</summary>
public sealed class RestApiClient : IDisposable
{
    private readonly RestClient _client;
    private readonly TimeUnit? _timeUnit;

    /// <summary>Creates the client; the configuration is validated and copied.</summary>
    /// <param name="config">The configuration.</param>
    /// <param name="product">The product, for the default user agent.</param>
    /// <param name="assembly">The assembly of the product package, for the default user agent.</param>
    /// <exception cref="BinanceConfigException">The configuration is invalid.</exception>
    public RestApiClient(RestApiConfig config, string? product = null, System.Reflection.Assembly? assembly = null)
    {
        ArgumentNullException.ThrowIfNull(config);
        config = BinanceUserAgent.WithDefault(config, product, assembly);
        _timeUnit = config.TimeUnit;
        _client = new RestClient(config.ToJson(), config.ServerCertificateValidator, config.TimestampProvider);
    }

    /// <summary>Sends a request and decodes the body. Cancelling the token cancels the request in flight; the task then ends as cancelled.</summary>
    /// <typeparam name="T">The type of the body.</typeparam>
    /// <param name="request">The request.</param>
    /// <param name="info">Type info used to decode the body.</param>
    /// <param name="cancellationToken">Cancels the request.</param>
    /// <exception cref="BinanceException">The request failed (the task faults with the exception).</exception>
    public async Task<RestApiResponse<T>> SendAsync<T>(RestRequest request, JsonTypeInfo<T> info, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        ArgumentNullException.ThrowIfNull(info);
        var r = await _client.SendAsync(request.ToJson(_timeUnit), cancellationToken).ConfigureAwait(false);
        var body = r.Body;
        return new(() => Wire.Decode(body, info), r.Status, Wire.RestLimits(r.RateLimitsJson), Wire.Headers(r.HeadersJson));
    }

    /// <summary>
    /// Sends a request to any endpoint, for one that has no method yet, like <c>sendRequest</c> of the other connectors. Parameters
    /// are encoded (and the request signed) as for the methods of the product; the time unit of the configuration applies.
    /// </summary>
    /// <typeparam name="T">The type of the body.</typeparam>
    /// <param name="endpoint">The endpoint path, e.g. <c>/api/v3/time</c>.</param>
    /// <param name="method">The HTTP method: GET, POST, PUT, DELETE or PATCH.</param>
    /// <param name="info">Type info used to decode the body.</param>
    /// <param name="query">Query parameters: strings, numbers (<see cref="decimal"/> for prices and quantities), booleans, enums of the product, lists of them. Null values are skipped.</param>
    /// <param name="body">Body parameters, as <paramref name="query"/>.</param>
    /// <param name="signed">Whether the request is signed: the timestamp and the signature are added.</param>
    /// <param name="cancellationToken">Cancels the request.</param>
    /// <returns>The response.</returns>
    /// <exception cref="BinanceException">The request failed (the task faults with the exception).</exception>
    public Task<RestApiResponse<T>> SendRequestAsync<T>(string endpoint, HttpMethod method, JsonTypeInfo<T> info, IEnumerable<KeyValuePair<string, object?>>? query = null,
        IEnumerable<KeyValuePair<string, object?>>? body = null, bool signed = false, CancellationToken cancellationToken = default)
    {
        RestRequest request;
        try
        {
            ArgumentException.ThrowIfNullOrEmpty(endpoint);
            ArgumentNullException.ThrowIfNull(method);
            ArgumentNullException.ThrowIfNull(info);
            request = new RestRequest(method.Method.ToUpperInvariant(), endpoint, signed, hasTimeUnit: true);
            foreach (var (name, value) in query ?? []) request.Query(name, value);
            foreach (var (name, value) in body ?? []) request.Body(name, value);
        }
        catch (Exception e)
        {
            return Task.FromException<RestApiResponse<T>>(e);
        }
        return SendAsync(request, info, cancellationToken);
    }

    /// <summary>As <see cref="SendRequestAsync{T}"/>, with the body as raw JSON (<see cref="JsonValueKind.Undefined"/> when it is empty).</summary>
    /// <param name="endpoint">The endpoint path, e.g. <c>/api/v3/time</c>.</param>
    /// <param name="method">The HTTP method: GET, POST, PUT, DELETE or PATCH.</param>
    /// <param name="query">Query parameters, as for <see cref="SendRequestAsync{T}"/>.</param>
    /// <param name="body">Body parameters, as <paramref name="query"/>.</param>
    /// <param name="signed">Whether the request is signed: the timestamp and the signature are added.</param>
    /// <param name="cancellationToken">Cancels the request.</param>
    /// <exception cref="BinanceException">The request failed (the task faults with the exception).</exception>
    public Task<RestApiResponse<JsonElement>> SendRequestAsync(string endpoint, HttpMethod method, IEnumerable<KeyValuePair<string, object?>>? query = null,
        IEnumerable<KeyValuePair<string, object?>>? body = null, bool signed = false, CancellationToken cancellationToken = default) =>
        SendRequestAsync(endpoint, method, NativeJson.Default.JsonElement, query, body, signed, cancellationToken);

    /// <summary>Frees the client; requests in flight end with <see cref="BinanceCancelledException"/>.</summary>
    public void Dispose() => _client.Dispose();
}

/// <summary>The WebSocket API client behind the product connections (for example <c>SpotWebSocketApiConnection</c>); use a product client rather than this class.</summary>
public sealed class WebSocketApiClient : IAsyncDisposable, IDisposable
{
    private readonly WebSocketApi _api;
    private readonly int? _capacity;
    private readonly Dispatcher<ConnectionEvent> _events;
    private readonly object _messagesLock = new();
    private Dispatcher<ConnectionMessage>? _messages;

    /// <summary>Creates the client; the configuration is validated and copied.</summary>
    /// <param name="config">The configuration.</param>
    /// <param name="product">The product, for the user agent.</param>
    /// <param name="assembly">The assembly of the product package, for the user agent.</param>
    /// <exception cref="BinanceConfigException">The configuration is invalid.</exception>
    public WebSocketApiClient(WebSocketApiConfig config, string? product = null, System.Reflection.Assembly? assembly = null)
    {
        ArgumentNullException.ThrowIfNull(config);
        config = BinanceUserAgent.WithDefault(config, product, assembly);
        _capacity = config.EventBufferCapacity;
        _api = new WebSocketApi(config.ToJson(), config.ServerCertificateValidator, config.TimestampProvider);
        _events = new Dispatcher<ConnectionEvent>(_api.Events, "Connection events");
    }

    /// <summary>
    /// Lifecycle events (open, close, error, ping, pong). Completes when the client is disposed. It holds the latest
    /// 1024 events: older ones are dropped (<see cref="DroppedEventCount"/>), so a client that never reads it does not grow. It has
    /// one reader, and is not available once <see cref="OnEvent(Action{ConnectionEvent})"/> has added a callback.
    /// </summary>
    /// <exception cref="InvalidOperationException">The events go to callbacks.</exception>
    public ChannelReader<ConnectionEvent> Events => _events.Reader;

    /// <summary>
    /// Adds a callback for the lifecycle events, like <c>on('open' | 'close' | 'error' | 'ping' | 'pong', ...)</c> of the other
    /// connectors. Every callback gets every event, in order, on a thread-pool thread; disposing the result removes it. Once a
    /// callback is added, <see cref="Events"/> is not available.
    /// </summary>
    /// <param name="callback">Called for each event.</param>
    /// <exception cref="InvalidOperationException"><see cref="Events"/> was read.</exception>
    public IDisposable OnEvent(Action<ConnectionEvent> callback) => _events.Add(callback);

    /// <summary>How many lifecycle events were dropped because <see cref="Events"/> was not read in time.</summary>
    public long DroppedEventCount => _api.DroppedEventCount;

    /// <summary>Whether a connection is open.</summary>
    public bool IsConnected => _api.IsConnected;

    /// <summary>
    /// Turns on the delivery of every message of every connection, as the server sent it (responses and events alike, in addition to
    /// what the requests and subscriptions receive), and returns their reader; later calls return the same reader. Until it (or
    /// <see cref="OnMessage"/>) is called, the library does not even build them. Unbounded unless the configuration sets
    /// <c>EventBufferCapacity</c>. It has one reader and completes when the client is disposed.
    /// </summary>
    /// <exception cref="ObjectDisposedException">The client is disposed.</exception>
    /// <exception cref="InvalidOperationException">The messages go to callbacks.</exception>
    public ChannelReader<ConnectionMessage> EnableMessages() => Messages().Reader;

    /// <summary>
    /// Adds a callback for every message of every connection, like <c>on('message', ...)</c> of the other connectors; see
    /// <see cref="EnableMessages"/>. Disposing the result removes it. Once a callback is added, <see cref="EnableMessages"/> is not available.
    /// </summary>
    /// <param name="callback">Called for each message.</param>
    /// <exception cref="ObjectDisposedException">The client is disposed.</exception>
    /// <exception cref="InvalidOperationException">The messages are read from the reader of <see cref="EnableMessages"/>.</exception>
    public IDisposable OnMessage(Action<ConnectionMessage> callback) => Messages().Add(callback);

    private Dispatcher<ConnectionMessage> Messages()
    {
        lock (_messagesLock) return _messages ??= new Dispatcher<ConnectionMessage>(_api.EnableMessages(_capacity), "Messages");
    }

    /// <summary>Sends a WebSocket ping frame on every open connection (fire and forget).</summary>
    public void PingServer() => _api.PingServer();

    /// <summary>Opens the connections.</summary>
    public Task ConnectAsync(CancellationToken cancellationToken = default) => _api.ConnectAsync(cancellationToken);

    /// <summary>Closes the connections gracefully.</summary>
    public Task DisconnectAsync(CancellationToken cancellationToken = default) => _api.DisconnectAsync(cancellationToken);

    /// <summary>One response per answering connection (one, except for <c>session.logon</c> and <c>session.logout</c>).</summary>
    public async Task<IReadOnlyList<WebSocketApiResponse<T>>> SendAllAsync<T>(WebSocketApiRequest request, JsonTypeInfo<T> info, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        ArgumentNullException.ThrowIfNull(info);
        using var doc = JsonDocument.Parse(await _api.SendAsync(request.ToJson(), cancellationToken).ConfigureAwait(false));
        if (doc.RootElement.ValueKind != JsonValueKind.Array || doc.RootElement.GetArrayLength() == 0)
            throw new BinanceClientException("The library answered the WebSocket API request without a response (expected a non-empty JSON array).");
        return doc.RootElement.EnumerateArray().Select(e => Response(e, info)).ToList();
    }

    /// <summary>Sends a request; the result is decoded by <see cref="WebSocketApiResponse{T}.Data"/>. Cancelling the token ends the task as cancelled.</summary>
    /// <typeparam name="T">The type of the result.</typeparam>
    /// <param name="request">The request.</param>
    /// <param name="info">Type info used to decode the result.</param>
    /// <param name="cancellationToken">Cancels the wait for the response.</param>
    /// <exception cref="BinanceException">The request failed (the task faults with the exception).</exception>
    public async Task<WebSocketApiResponse<T>> SendAsync<T>(WebSocketApiRequest request, JsonTypeInfo<T> info, CancellationToken cancellationToken = default) =>
        (await SendAllAsync(request, info, cancellationToken).ConfigureAwait(false))[0];

    /// <summary>
    /// Sends a request with any method, for one that has no method yet, like <c>sendMessage</c> of the other connectors. Parameters
    /// are encoded as for the methods of the product.
    /// </summary>
    /// <typeparam name="T">The type of the result.</typeparam>
    /// <param name="method">The method, e.g. <c>time</c> or <c>account.status</c>.</param>
    /// <param name="info">Type info used to decode the result.</param>
    /// <param name="parameters">The parameters: strings, numbers (<see cref="decimal"/> for prices and quantities), booleans, enums of the product, lists of them. Null values are skipped.</param>
    /// <param name="auth">How it is authenticated: <see cref="WebSocketAuth.Signed"/> adds the API key, the timestamp and the signature.</param>
    /// <param name="cancellationToken">Cancels the wait for the response.</param>
    /// <returns>The response.</returns>
    /// <exception cref="BinanceException">The request failed (the task faults with the exception).</exception>
    public Task<WebSocketApiResponse<T>> SendMessageAsync<T>(string method, JsonTypeInfo<T> info, IEnumerable<KeyValuePair<string, object?>>? parameters = null,
        WebSocketAuth auth = WebSocketAuth.None, CancellationToken cancellationToken = default)
    {
        WebSocketApiRequest request;
        try
        {
            ArgumentException.ThrowIfNullOrEmpty(method);
            ArgumentNullException.ThrowIfNull(info);
            request = new WebSocketApiRequest(method, auth);
            foreach (var (name, value) in parameters ?? []) request.Param(name, value);
        }
        catch (Exception e)
        {
            return Task.FromException<WebSocketApiResponse<T>>(e);
        }
        return SendAsync(request, info, cancellationToken);
    }

    /// <summary>As <see cref="SendMessageAsync{T}"/>, with the result as raw JSON.</summary>
    /// <param name="method">The method, e.g. <c>time</c> or <c>account.status</c>.</param>
    /// <param name="parameters">The parameters, as for <see cref="SendMessageAsync{T}"/>.</param>
    /// <param name="auth">How it is authenticated.</param>
    /// <param name="cancellationToken">Cancels the wait for the response.</param>
    /// <exception cref="BinanceException">The request failed (the task faults with the exception).</exception>
    public Task<WebSocketApiResponse<JsonElement>> SendMessageAsync(string method, IEnumerable<KeyValuePair<string, object?>>? parameters = null,
        WebSocketAuth auth = WebSocketAuth.None, CancellationToken cancellationToken = default) =>
        SendMessageAsync(method, NativeJson.Default.JsonElement, parameters, auth, cancellationToken);

    /// <summary>Sends a request that opens a user-data subscription. Cancelling the token ends the task as cancelled, but the request is not withdrawn: the subscription may still be opened on the server, and the client then ends it there. Disposing the subscription ends it on the server, on the connection that holds it.</summary>
    /// <typeparam name="T">The type of the response.</typeparam>
    /// <typeparam name="TEvent">The type of an event.</typeparam>
    /// <param name="request">The request.</param>
    /// <param name="info">Type info used to decode the response.</param>
    /// <param name="eventInfo">Type info used to decode the events.</param>
    /// <param name="cancellationToken">Cancels the wait for the response.</param>
    /// <exception cref="BinanceException">The request failed (the task faults with the exception).</exception>
    public async Task<WebSocketApiSubscription<T, TEvent>> SubscribeAsync<T, TEvent>(WebSocketApiRequest request, JsonTypeInfo<T> info, JsonTypeInfo<TEvent> eventInfo, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        var s = await _api.SubscribeAsync(request.ToJson(), _capacity, cancellationToken).ConfigureAwait(false);
        try
        {
            using var doc = JsonDocument.Parse(s.ResponseJson);
            return new(Response(doc.RootElement, info), s.Events, eventInfo, "userDataStream");
        }
        catch
        {
            // Without this, the subscription would stay registered, and the library would open it again after every reconnect.
            s.Events.Dispose();
            throw;
        }
    }

    // The result is decoded on demand, from a copy that outlives the document.
    private static WebSocketApiResponse<T> Response<T>(JsonElement e, JsonTypeInfo<T> info)
    {
        var result = e.TryGetProperty("result", out var r) ? r.Clone() : default;
        return new(() => Wire.Decode(result, info), e.TryGetProperty("rateLimits", out var limits) ? Wire.WebSocketLimits(limits) : []);
    }

    /// <summary>Disconnects gracefully (waiting at most 5 seconds), then frees the client.</summary>
    public ValueTask DisposeAsync() => _api.DisposeAsync();

    /// <summary>Frees the client at once; requests in flight end with <see cref="BinanceCancelledException"/>.</summary>
    public void Dispose() => _api.Dispose();
}

/// <summary>The WebSocket Streams client behind the product connections (for example <c>SpotWebSocketStreamsConnection</c>); use a product client rather than this class.</summary>
public sealed class WebSocketStreamsClient : IAsyncDisposable, IDisposable
{
    private readonly WebSocketStreams _streams;
    private readonly int? _capacity;
    private readonly bool _strictId;
    private readonly Dispatcher<ConnectionEvent> _events;
    private readonly object _messagesLock = new();
    private Dispatcher<ConnectionMessage>? _messages;

    /// <summary>Creates the client; the configuration is validated and copied.</summary>
    /// <param name="config">The configuration.</param>
    /// <param name="urlPaths">URL paths of the product (streams are grouped by them).</param>
    /// <param name="product">The product, for the user agent.</param>
    /// <param name="assembly">The assembly of the product package, for the user agent.</param>
    /// <param name="signedStreams">The streams of the product are signed: the connection is authenticated with the credentials of the configuration.</param>
    /// <param name="streamIdIsStrictlyNumber">The product takes only numbers as subscription ids: a string id is replaced by a number.</param>
    /// <exception cref="BinanceConfigException">The configuration is invalid.</exception>
    public WebSocketStreamsClient(WebSocketStreamsConfig config, IEnumerable<string>? urlPaths = null, string? product = null, System.Reflection.Assembly? assembly = null,
        bool signedStreams = false, bool streamIdIsStrictlyNumber = false)
    {
        ArgumentNullException.ThrowIfNull(config);
        config = BinanceUserAgent.WithDefault(config, product, assembly) with { SignedStreams = signedStreams, StreamIdIsStrictlyNumber = streamIdIsStrictlyNumber };
        _capacity = config.EventBufferCapacity;
        _strictId = streamIdIsStrictlyNumber;
        var paths = urlPaths?.ToArray();
        _streams = new WebSocketStreams(config.ToJson(), paths is { Length: > 0 } ? JsonSerializer.Serialize(paths, NativeJson.Default.StringArray) : null, config.ServerCertificateValidator, config.TimestampProvider);
        _events = new Dispatcher<ConnectionEvent>(_streams.Events, "Connection events");
    }

    /// <summary>
    /// Lifecycle events (open, close, error, ping, pong). Completes when the client is disposed. It holds the latest
    /// 1024 events: older ones are dropped (<see cref="DroppedEventCount"/>), so a client that never reads it does not grow. It has
    /// one reader, and is not available once <see cref="OnEvent(Action{ConnectionEvent})"/> has added a callback.
    /// </summary>
    /// <exception cref="InvalidOperationException">The events go to callbacks.</exception>
    public ChannelReader<ConnectionEvent> Events => _events.Reader;

    /// <summary>
    /// Adds a callback for the lifecycle events, like <c>on('open' | 'close' | 'error' | 'ping' | 'pong', ...)</c> of the other
    /// connectors. Every callback gets every event, in order, on a thread-pool thread; disposing the result removes it. Once a
    /// callback is added, <see cref="Events"/> is not available.
    /// </summary>
    /// <param name="callback">Called for each event.</param>
    /// <exception cref="InvalidOperationException"><see cref="Events"/> was read.</exception>
    public IDisposable OnEvent(Action<ConnectionEvent> callback) => _events.Add(callback);

    /// <summary>How many lifecycle events were dropped because <see cref="Events"/> was not read in time.</summary>
    public long DroppedEventCount => _streams.DroppedEventCount;

    /// <summary>Whether a connection is open.</summary>
    public bool IsConnected => _streams.IsConnected;

    /// <summary>Whether <paramref name="stream"/> is subscribed (or queued until its connection opens), on any URL path.</summary>
    /// <param name="stream">The stream name, e.g. <c>btcusdt@trade</c>.</param>
    public bool IsSubscribed(string stream) => _streams.IsSubscribed(stream);

    /// <summary>
    /// Turns on the delivery of every message of every connection, as the server sent it (for combined streams,
    /// <c>{"stream": ..., "data": ...}</c>; in addition to what the subscriptions receive), and returns their reader; later calls return
    /// the same reader. Until it (or <see cref="OnMessage"/>) is called, the library does not even build them. Unbounded unless the
    /// configuration sets <c>EventBufferCapacity</c>. It has one reader and completes when the client is disposed.
    /// </summary>
    /// <exception cref="ObjectDisposedException">The client is disposed.</exception>
    /// <exception cref="InvalidOperationException">The messages go to callbacks.</exception>
    public ChannelReader<ConnectionMessage> EnableMessages() => Messages().Reader;

    /// <summary>
    /// Adds a callback for every message of every connection, like <c>on('message', ...)</c> of the other connectors; see
    /// <see cref="EnableMessages"/>. Disposing the result removes it. Once a callback is added, <see cref="EnableMessages"/> is not available.
    /// </summary>
    /// <param name="callback">Called for each message.</param>
    /// <exception cref="ObjectDisposedException">The client is disposed.</exception>
    /// <exception cref="InvalidOperationException">The messages are read from the reader of <see cref="EnableMessages"/>.</exception>
    public IDisposable OnMessage(Action<ConnectionMessage> callback) => Messages().Add(callback);

    private Dispatcher<ConnectionMessage> Messages()
    {
        lock (_messagesLock) return _messages ??= new Dispatcher<ConnectionMessage>(_streams.EnableMessages(_capacity), "Messages");
    }

    /// <summary>Sends a WebSocket ping frame on every open connection (fire and forget).</summary>
    public void PingServer() => _streams.PingServer();

    /// <summary>Opens the connections.</summary>
    public Task ConnectAsync(CancellationToken cancellationToken = default) => _streams.ConnectAsync(null, cancellationToken);

    /// <summary>
    /// Opens the connections with <paramref name="streams"/> subscribed through the connection URL. They stay subscribed across
    /// reconnects, until <c>DisconnectAsync</c>; their messages reach <see cref="EnableMessages"/>, and the subscriptions made for them.
    /// </summary>
    /// <param name="streams">Stream names, e.g. <c>btcusdt@trade</c>.</param>
    /// <param name="cancellationToken">Abandons the wait; the connection attempt itself continues.</param>
    public Task ConnectAsync(IEnumerable<string> streams, CancellationToken cancellationToken = default)
    {
        string? json;
        try
        {
            json = StreamsJson(streams, allowEmpty: true);
        }
        catch (Exception e)
        {
            return Task.FromException(e);
        }
        return _streams.ConnectAsync(json, cancellationToken);
    }

    /// <summary>Closes the connections gracefully.</summary>
    public Task DisconnectAsync(CancellationToken cancellationToken = default) => _streams.DisconnectAsync(cancellationToken);

    /// <summary>
    /// Completes once the server has acknowledged the subscription of <paramref name="stream"/> (at once if it already has); see
    /// <see cref="EventSubscription{TEvent}.WaitSubscribedAsync"/>.
    /// </summary>
    /// <param name="stream">The stream name.</param>
    /// <param name="urlPath">URL path of the stream, if the product has them.</param>
    /// <param name="cancellationToken">Abandons the wait; the subscription stays.</param>
    public Task WaitSubscribedAsync(string stream, string? urlPath = null, CancellationToken cancellationToken = default) =>
        _streams.WaitSubscribedAsync(stream, urlPath, cancellationToken);

    /// <summary>
    /// Subscribes to a stream name and returns the subscription, with its events decoded as <typeparamref name="TEvent"/>. It may be
    /// called before <c>ConnectAsync</c>: the subscription is sent once a connection opens. <see cref="EventSubscription{TEvent}.WaitSubscribedAsync"/>
    /// tells when the server has acknowledged it.
    /// </summary>
    /// <param name="stream">The stream name.</param>
    /// <param name="info">Type info of an event.</param>
    /// <param name="urlPath">URL path of the stream, if the product has them.</param>
    /// <param name="id">Subscription id (a string or a number); generated when null.</param>
    public EventSubscription<TEvent> Subscribe<TEvent>(string stream, JsonTypeInfo<TEvent> info, string? urlPath = null, object? id = null) =>
        new(_streams.Subscribe(stream, urlPath, _capacity, IdJson(id)), info, stream, ct => _streams.WaitSubscribedAsync(stream, urlPath, ct));

    /// <summary>Subscribes to a stream name, with the events as raw JSON; see <see cref="Subscribe{TEvent}"/>.</summary>
    /// <param name="stream">The stream name.</param>
    /// <param name="urlPath">URL path of the stream, if the product has them.</param>
    /// <param name="id">Subscription id (a string or a number); generated when null.</param>
    public EventSubscription<JsonElement> Subscribe(string stream, string? urlPath = null, object? id = null) =>
        Subscribe(stream, NativeJson.Default.JsonElement, urlPath, id);

    /// <summary>
    /// Subscribes to stream names without a subscription object, like <c>subscribe(streams)</c> of the other connectors: their messages
    /// reach <see cref="EnableMessages"/> and <see cref="OnMessage"/>, and the subscriptions of the same streams. Sent once a connection
    /// opens, and kept across reconnects.
    /// </summary>
    /// <param name="streams">Stream names, e.g. <c>btcusdt@trade</c>.</param>
    /// <param name="urlPath">URL path of the streams, if the product has them.</param>
    /// <param name="id">The SUBSCRIBE request id (a string or a number); generated when null.</param>
    public void Subscribe(IEnumerable<string> streams, string? urlPath = null, object? id = null) =>
        _streams.SubscribeNames(StreamsJson(streams)!, urlPath, IdJson(id));

    /// <summary>
    /// Unsubscribes from stream names, whatever subscribed them: the subscriptions of those streams receive nothing more (dispose
    /// them as well).
    /// </summary>
    /// <param name="streams">Stream names, e.g. <c>btcusdt@trade</c>.</param>
    /// <param name="urlPath">URL path of the streams, if the product has them.</param>
    /// <param name="id">The UNSUBSCRIBE request id (a string or a number); generated when null.</param>
    public void Unsubscribe(IEnumerable<string> streams, string? urlPath = null, object? id = null) =>
        _streams.UnsubscribeNames(StreamsJson(streams)!, urlPath, IdJson(id));

    private static string? StreamsJson(IEnumerable<string> streams, bool allowEmpty = false)
    {
        ArgumentNullException.ThrowIfNull(streams);
        var names = streams.ToArray();
        if (names.Length == 0)
            return allowEmpty ? null : throw new ArgumentException("At least one stream is needed.", nameof(streams));
        if (names.Any(string.IsNullOrEmpty)) throw new ArgumentException("A stream name is empty.", nameof(streams));
        return JsonSerializer.Serialize(names, NativeJson.Default.StringArray);
    }

    // A numeric id of a strictly numeric product is sent as a number; the library replaces any other string by one.
    private string? IdJson(object? id) => id switch
    {
        null => null,
        string s when _strictId && long.TryParse(s, System.Globalization.NumberStyles.None, System.Globalization.CultureInfo.InvariantCulture, out _) => s,
        _ => Wire.Node(id)!.ToJsonString(),
    };

    /// <summary>Disconnects gracefully (waiting at most 5 seconds), then frees the client.</summary>
    public ValueTask DisposeAsync() => _streams.DisposeAsync();

    /// <summary>Frees the client at once: subscriptions end and their readers complete.</summary>
    public void Dispose() => _streams.Dispose();
}
