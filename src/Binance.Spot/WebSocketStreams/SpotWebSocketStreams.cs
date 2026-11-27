//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Threading.Channels;
using Binance.Common;

namespace Binance.Spot.WebSocketStreams;

/// <summary>
/// The Spot WebSocket Streams client. It holds the configuration, and <see cref="ConnectAsync"/> opens a connection with it,
/// like the <c>connect()</c> of the other Binance connectors: every call returns an independent, open
/// <see cref="SpotWebSocketStreamsConnection"/>.
/// </summary>
public sealed class SpotWebSocketStreams
{
    /// <summary>The production endpoint.</summary>
    public static readonly string ProductionUrl = BinanceUrls.SpotWebSocketStreamsProdUrl;

    /// <summary>The testnet endpoint.</summary>
    public static readonly string TestnetUrl = BinanceUrls.SpotWebSocketStreamsTestnetUrl;

    /// <summary>The demo endpoint.</summary>
    public static readonly string DemoUrl = BinanceUrls.SpotWebSocketStreamsDemoUrl;

    private readonly WebSocketStreamsConfig _config;

    /// <summary>Creates a client; <see cref="WebSocketStreamsConfig.Url"/> is required.</summary>
    /// <param name="config">The configuration, which is copied. It is validated when a connection is opened.</param>
    public SpotWebSocketStreams(WebSocketStreamsConfig config)
    {
        ArgumentNullException.ThrowIfNull(config);
        _config = config with { };
    }

    /// <summary>Creates a client of the production environment.</summary>
    /// <param name="config">Credentials and options; the endpoint is set.</param>
    public static SpotWebSocketStreams Production(WebSocketStreamsConfig? config = null) =>
        new((config ?? new()) with { Url = ProductionUrl });

    /// <summary>Creates a client of the testnet environment.</summary>
    /// <param name="config">Credentials and options; the endpoint is set.</param>
    public static SpotWebSocketStreams Testnet(WebSocketStreamsConfig? config = null) =>
        new((config ?? new()) with { Url = TestnetUrl });

    /// <summary>Creates a client of the demo environment.</summary>
    /// <param name="config">Credentials and options; the endpoint is set.</param>
    public static SpotWebSocketStreams Demo(WebSocketStreamsConfig? config = null) =>
        new((config ?? new()) with { Url = DemoUrl });

    /// <summary>Creates a client for the endpoint of the configuration (<c>Url</c>), or of production when it is empty.</summary>
    /// <param name="config">The configuration.</param>
    public static SpotWebSocketStreams FromConfig(WebSocketStreamsConfig config)
    {
        ArgumentNullException.ThrowIfNull(config);
        return new(string.IsNullOrEmpty(config.Url) ? config with { Url = ProductionUrl } : config);
    }

    /// <summary>
    /// Opens a connection (or a pool of them with <c>WebSocketMode.Pool(n)</c>, overriding <see cref="WebSocketStreamsConfig.Mode"/>),
    /// subscribed to <paramref name="streams"/> through the connection URL, and returns it once it is open. Dispose the connection when
    /// done.
    /// </summary>
    /// <param name="streams">Stream names to subscribe to on open, e.g. <c>btcusdt@trade</c>, or null for none.</param>
    /// <param name="mode">The mode, or null for the configured one.</param>
    /// <param name="cancellationToken">Abandons the wait; the connection is then disposed.</param>
    /// <returns>The open connection.</returns>
    /// <exception cref="BinanceConfigException">The configuration is invalid.</exception>
    /// <exception cref="BinanceException">A connection failed to open.</exception>
    public async Task<SpotWebSocketStreamsConnection> ConnectAsync(IEnumerable<string>? streams = null, WebSocketMode? mode = null,
        CancellationToken cancellationToken = default)
    {
        var connection = new SpotWebSocketStreamsConnection(mode is null ? _config : _config with { Mode = mode });
        try
        {
            await connection.OpenAsync(streams, cancellationToken).ConfigureAwait(false);
            return connection;
        }
        catch
        {
            await connection.DisposeAsync().ConfigureAwait(false);
            throw;
        }
    }
}

/// <summary>
/// A connection to the Spot WebSocket Streams, returned open by <see cref="SpotWebSocketStreams.ConnectAsync"/>:
/// one method for each stream, returning a subscription with a reader of typed events. It reconnects, renews its connections and
/// resubscribes until <see cref="DisconnectAsync"/>. Dispose it when done; DisposeAsync disconnects gracefully.
/// </summary>
public sealed partial class SpotWebSocketStreamsConnection : IAsyncDisposable, IDisposable
{
    private readonly WebSocketStreamsClient _client;

    internal SpotWebSocketStreamsConnection(WebSocketStreamsConfig config) =>
        _client = new WebSocketStreamsClient(config, [], "spot", typeof(SpotWebSocketStreams).Assembly);

    /// <summary>Events of the stream of listenKey.</summary>
    /// <param name="listenKey">The listen key.</param>
    /// <param name="id">The subscription id (a string or a number); generated when null.</param>
    public EventSubscription<UserDataStreamEventsResponse> UserData(string listenKey, object? id = null) =>
        _client.Subscribe(listenKey, SpotWebSocketStreamsJson.Default.UserDataStreamEventsResponse, null, id);

    /// <summary>
    /// Lifecycle events (open, close, error, ping, pong) of the connections. Completes on dispose. It keeps the latest 1024
    /// events (older ones are dropped and counted in <see cref="DroppedEventCount"/>) and has a single reader; it is not available
    /// once <see cref="OnEvent"/> has added a callback.
    /// </summary>
    public ChannelReader<ConnectionEvent> Events => _client.Events;

    /// <summary>
    /// Adds a callback for the lifecycle events, like <c>on('open' | 'close' | 'error' | 'ping' | 'pong', ...)</c> of the other
    /// connectors; disposing the result removes it. Once a callback is added, <see cref="Events"/> is not available.
    /// </summary>
    /// <param name="callback">Called for each event, on a thread-pool thread.</param>
    public IDisposable OnEvent(Action<ConnectionEvent> callback) => _client.OnEvent(callback);

    /// <summary>How many lifecycle events were dropped because <see cref="Events"/> was not read in time.</summary>
    public long DroppedEventCount => _client.DroppedEventCount;

    /// <summary>Whether a connection is open.</summary>
    public bool IsConnected => _client.IsConnected;

    /// <summary>Whether <paramref name="stream"/> is subscribed (or queued until its connection opens).</summary>
    /// <param name="stream">The stream name, e.g. <c>btcusdt@trade</c>.</param>
    public bool IsSubscribed(string stream) => _client.IsSubscribed(stream);

    /// <summary>
    /// Turns on the delivery of every message of every connection as the server sent it, and returns their reader; later calls return
    /// the same reader. Unbounded unless <c>EventBufferCapacity</c> is set; it has a single reader and completes on dispose.
    /// </summary>
    /// <exception cref="ObjectDisposedException">The client is disposed.</exception>
    public ChannelReader<ConnectionMessage> EnableMessages() => _client.EnableMessages();

    /// <summary>
    /// Adds a callback for every message of every connection, like <c>on('message', ...)</c> of the other connectors; disposing the
    /// result removes it. Once a callback is added, <see cref="EnableMessages"/> is not available.
    /// </summary>
    /// <param name="callback">Called for each message, on a thread-pool thread.</param>
    /// <exception cref="ObjectDisposedException">The client is disposed.</exception>
    public IDisposable OnMessage(Action<ConnectionMessage> callback) => _client.OnMessage(callback);

    /// <summary>
    /// Subscribes to any stream by name, with the events as raw JSON. <c>WaitSubscribedAsync()</c> of the subscription completes once
    /// the server has acknowledged it.
    /// </summary>
    /// <param name="stream">The stream name, e.g. <c>btcusdt@trade</c>.</param>
    /// <param name="urlPath">The URL path of the stream, for a product that has them.</param>
    /// <param name="id">The subscription id (a string or a number); generated when null.</param>
    public EventSubscription<JsonElement> Subscribe(string stream, string? urlPath = null, object? id = null) =>
        _client.Subscribe(stream, urlPath, id);

    /// <summary>
    /// Subscribes to stream names without a subscription object, like <c>subscribe(streams)</c> of the other connectors: their messages
    /// reach <see cref="EnableMessages"/> and <see cref="OnMessage"/>.
    /// </summary>
    /// <param name="streams">Stream names, e.g. <c>btcusdt@trade</c>.</param>
    /// <param name="urlPath">The URL path of the streams, for a product that has them.</param>
    /// <param name="id">The SUBSCRIBE request id (a string or a number); generated when null.</param>
    public void Subscribe(IEnumerable<string> streams, string? urlPath = null, object? id = null) =>
        _client.Subscribe(streams, urlPath, id);

    /// <summary>Unsubscribes from stream names, whatever subscribed them, like <c>unsubscribe(streams)</c> of the other connectors.</summary>
    /// <param name="streams">Stream names, e.g. <c>btcusdt@trade</c>.</param>
    /// <param name="urlPath">The URL path of the streams, for a product that has them.</param>
    /// <param name="id">The UNSUBSCRIBE request id (a string or a number); generated when null.</param>
    public void Unsubscribe(IEnumerable<string> streams, string? urlPath = null, object? id = null) =>
        _client.Unsubscribe(streams, urlPath, id);

    /// <summary>Sends a WebSocket ping frame on every open connection (fire and forget).</summary>
    public void PingServer() => _client.PingServer();

    // The streams of the connection URL stay subscribed across reconnects, until DisconnectAsync; their messages reach
    // EnableMessages, and the subscriptions made for them.
    internal Task OpenAsync(IEnumerable<string>? streams, CancellationToken cancellationToken) =>
        streams is null ? _client.ConnectAsync(cancellationToken) : _client.ConnectAsync(streams, cancellationToken);

    /// <summary>Closes the connections gracefully.</summary>
    /// <param name="cancellationToken">Abandons the wait.</param>
    public Task DisconnectAsync(CancellationToken cancellationToken = default) => _client.DisconnectAsync(cancellationToken);

    /// <summary>Disconnects gracefully (the wait is bounded), then frees the client.</summary>
    public ValueTask DisposeAsync() => _client.DisposeAsync();

    /// <summary>Frees the client at once: subscriptions end and their readers complete.</summary>
    public void Dispose() => _client.Dispose();
}
