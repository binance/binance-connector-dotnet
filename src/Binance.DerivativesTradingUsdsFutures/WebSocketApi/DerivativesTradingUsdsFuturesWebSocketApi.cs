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

namespace Binance.DerivativesTradingUsdsFutures.WebSocketApi;

/// <summary>
/// The Futures (USDⓈ-M) WebSocket API client. It holds the configuration, and <see cref="ConnectAsync"/> opens a connection with it,
/// like the <c>connect()</c> of the other Binance connectors: every call returns an independent, open
/// <see cref="DerivativesTradingUsdsFuturesWebSocketApiConnection"/>.
/// </summary>
public sealed class DerivativesTradingUsdsFuturesWebSocketApi
{
    /// <summary>The production endpoint.</summary>
    public static readonly string ProductionUrl = BinanceUrls.DerivativesTradingUsdsFuturesWebSocketApiProdUrl;

    /// <summary>The testnet endpoint.</summary>
    public static readonly string TestnetUrl = BinanceUrls.DerivativesTradingUsdsFuturesWebSocketApiTestnetUrl;

    private readonly WebSocketApiConfig _config;

    /// <summary>Creates a client; <see cref="WebSocketApiConfig.Url"/> is required.</summary>
    /// <param name="config">The configuration, which is copied. It is validated when a connection is opened.</param>
    public DerivativesTradingUsdsFuturesWebSocketApi(WebSocketApiConfig config)
    {
        ArgumentNullException.ThrowIfNull(config);
        _config = config with { };
    }

    /// <summary>Creates a client of the production environment.</summary>
    /// <param name="config">Credentials and options; the endpoint is set.</param>
    public static DerivativesTradingUsdsFuturesWebSocketApi Production(WebSocketApiConfig? config = null) =>
        new((config ?? new()) with { Url = ProductionUrl });

    /// <summary>Creates a client of the testnet environment.</summary>
    /// <param name="config">Credentials and options; the endpoint is set.</param>
    public static DerivativesTradingUsdsFuturesWebSocketApi Testnet(WebSocketApiConfig? config = null) =>
        new((config ?? new()) with { Url = TestnetUrl });

    /// <summary>Creates a client for the endpoint of the configuration (<c>Url</c>), or of production when it is empty.</summary>
    /// <param name="config">The configuration.</param>
    public static DerivativesTradingUsdsFuturesWebSocketApi FromConfig(WebSocketApiConfig config)
    {
        ArgumentNullException.ThrowIfNull(config);
        return new(string.IsNullOrEmpty(config.Url) ? config with { Url = ProductionUrl } : config);
    }

    /// <summary>
    /// Opens a connection (or a pool of them with <c>WebSocketMode.Pool(n)</c>, overriding <see cref="WebSocketApiConfig.Mode"/>) and
    /// returns it once it is open. Dispose the connection when done.
    /// </summary>
    /// <param name="mode">The mode, or null for the configured one.</param>
    /// <param name="cancellationToken">Abandons the wait; the connection is then disposed.</param>
    /// <returns>The open connection.</returns>
    /// <exception cref="BinanceConfigException">The configuration is invalid.</exception>
    /// <exception cref="BinanceException">A connection failed to open.</exception>
    public async Task<DerivativesTradingUsdsFuturesWebSocketApiConnection> ConnectAsync(WebSocketMode? mode = null, CancellationToken cancellationToken = default)
    {
        var connection = new DerivativesTradingUsdsFuturesWebSocketApiConnection(mode is null ? _config : _config with { Mode = mode });
        try
        {
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
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
/// A connection to the Futures (USDⓈ-M) WebSocket API, returned open by <see cref="DerivativesTradingUsdsFuturesWebSocketApi.ConnectAsync"/>, with one
/// method for each request. It reconnects and renews its connections until <see cref="DisconnectAsync"/>. Dispose it when done;
/// DisposeAsync disconnects gracefully.
/// </summary>
public sealed partial class DerivativesTradingUsdsFuturesWebSocketApiConnection : IAsyncDisposable, IDisposable
{
    private readonly WebSocketApiClient _client;

    internal DerivativesTradingUsdsFuturesWebSocketApiConnection(WebSocketApiConfig config) =>
        _client = new WebSocketApiClient(config with { TimeUnit = null }, "derivatives-trading-usds-futures", typeof(DerivativesTradingUsdsFuturesWebSocketApi).Assembly);

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

    /// <summary>
    /// Turns on the delivery of every message of every connection as the server sent it (responses and events), and returns their
    /// reader; later calls return the same reader. Unbounded unless <c>EventBufferCapacity</c> is set; it has a single reader and
    /// completes on dispose.
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

    /// <summary>Sends a request with any method, for one that has no method yet. Parameters are encoded as for the other methods.</summary>
    /// <param name="method">The method, e.g. <c>time</c>.</param>
    /// <param name="parameters">The parameters (null values are skipped).</param>
    /// <param name="withApiKey">Whether the API key is sent (as <c>apiKey</c>).</param>
    /// <param name="cancellationToken">Cancels the wait for the response.</param>
    /// <returns>The response, with the result as raw JSON.</returns>
    /// <exception cref="BinanceException">The request failed (the task faults with the exception).</exception>
    public Task<WebSocketApiResponse<JsonElement>> SendMessageAsync(string method, IEnumerable<KeyValuePair<string, object?>>? parameters = null,
        bool withApiKey = false, CancellationToken cancellationToken = default) =>
        _client.SendMessageAsync(method, parameters, withApiKey ? WebSocketAuth.ApiKey : WebSocketAuth.None, cancellationToken);

    /// <summary>As <c>SendMessageAsync</c>, with the result decoded by <paramref name="info"/>.</summary>
    /// <typeparam name="T">The type of the result.</typeparam>
    /// <param name="method">The method, e.g. <c>time</c>.</param>
    /// <param name="info">Type info of the result, e.g. from the serializer context of the product.</param>
    /// <param name="parameters">The parameters (null values are skipped).</param>
    /// <param name="withApiKey">Whether the API key is sent (as <c>apiKey</c>).</param>
    /// <param name="cancellationToken">Cancels the wait for the response.</param>
    /// <exception cref="BinanceException">The request failed (the task faults with the exception).</exception>
    public Task<WebSocketApiResponse<T>> SendMessageAsync<T>(string method, System.Text.Json.Serialization.Metadata.JsonTypeInfo<T> info,
        IEnumerable<KeyValuePair<string, object?>>? parameters = null, bool withApiKey = false, CancellationToken cancellationToken = default) =>
        _client.SendMessageAsync(method, info, parameters, withApiKey ? WebSocketAuth.ApiKey : WebSocketAuth.None, cancellationToken);

    /// <summary>As <c>SendMessageAsync</c>, but signed: the API key, the timestamp and the signature are added.</summary>
    /// <param name="method">The method, e.g. <c>account.status</c>.</param>
    /// <param name="parameters">The parameters (null values are skipped).</param>
    /// <param name="cancellationToken">Cancels the wait for the response.</param>
    /// <returns>The response, with the result as raw JSON.</returns>
    /// <exception cref="BinanceException">The request failed (the task faults with the exception).</exception>
    public Task<WebSocketApiResponse<JsonElement>> SendSignedMessageAsync(string method, IEnumerable<KeyValuePair<string, object?>>? parameters = null,
        CancellationToken cancellationToken = default) =>
        _client.SendMessageAsync(method, parameters, WebSocketAuth.Signed, cancellationToken);

    /// <summary>As <c>SendSignedMessageAsync</c>, with the result decoded by <paramref name="info"/>.</summary>
    /// <typeparam name="T">The type of the result.</typeparam>
    /// <param name="method">The method, e.g. <c>account.status</c>.</param>
    /// <param name="info">Type info of the result, e.g. from the serializer context of the product.</param>
    /// <param name="parameters">The parameters (null values are skipped).</param>
    /// <param name="cancellationToken">Cancels the wait for the response.</param>
    /// <exception cref="BinanceException">The request failed (the task faults with the exception).</exception>
    public Task<WebSocketApiResponse<T>> SendSignedMessageAsync<T>(string method, System.Text.Json.Serialization.Metadata.JsonTypeInfo<T> info,
        IEnumerable<KeyValuePair<string, object?>>? parameters = null, CancellationToken cancellationToken = default) =>
        _client.SendMessageAsync(method, info, parameters, WebSocketAuth.Signed, cancellationToken);

    /// <summary>Sends a WebSocket ping frame on every open connection (fire and forget).</summary>
    public void PingServer() => _client.PingServer();

    internal Task OpenAsync(CancellationToken cancellationToken) => _client.ConnectAsync(cancellationToken);

    /// <summary>Closes the connections gracefully.</summary>
    /// <param name="cancellationToken">Abandons the wait.</param>
    public Task DisconnectAsync(CancellationToken cancellationToken = default) => _client.DisconnectAsync(cancellationToken);

    /// <summary>Disconnects gracefully (the wait is bounded), then frees the client.</summary>
    public ValueTask DisposeAsync() => _client.DisposeAsync();

    /// <summary>Frees the client at once; requests in flight end with <see cref="BinanceCancelledException"/>.</summary>
    public void Dispose() => _client.Dispose();
}
