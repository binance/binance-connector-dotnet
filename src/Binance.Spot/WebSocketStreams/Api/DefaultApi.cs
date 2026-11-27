//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;
using Binance.Common;

namespace Binance.Spot.WebSocketStreams;

public sealed class AggTradeRequest
{
    /// <summary>Symbol to query</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<AllMarketRollingWindowTickerWindowSize>))]
public readonly struct AllMarketRollingWindowTickerWindowSize : IExtensibleValue<AllMarketRollingWindowTickerWindowSize>, IEquatable<AllMarketRollingWindowTickerWindowSize>
{
    private readonly string? _value;

    public AllMarketRollingWindowTickerWindowSize(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static AllMarketRollingWindowTickerWindowSize WindowSize1h { get; } = new("1h");

    public static AllMarketRollingWindowTickerWindowSize WindowSize4h { get; } = new("4h");

    public static AllMarketRollingWindowTickerWindowSize WindowSize1d { get; } = new("1d");

    static AllMarketRollingWindowTickerWindowSize IExtensibleValue<AllMarketRollingWindowTickerWindowSize>.Create(string value) => new(value);

    public static bool operator ==(AllMarketRollingWindowTickerWindowSize left, AllMarketRollingWindowTickerWindowSize right) => left.Equals(right);

    public static bool operator !=(AllMarketRollingWindowTickerWindowSize left, AllMarketRollingWindowTickerWindowSize right) => !left.Equals(right);

    public static implicit operator AllMarketRollingWindowTickerWindowSize(string value) => new(value);

    public static AllMarketRollingWindowTickerWindowSize FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is AllMarketRollingWindowTickerWindowSize other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(AllMarketRollingWindowTickerWindowSize other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class AllMarketRollingWindowTickerRequest
{
    public required AllMarketRollingWindowTickerWindowSize WindowSize { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed class AllMiniTickerRequest
{
    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed class AvgPriceRequest
{
    /// <summary>Symbol to query</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed class BlockTradeRequest
{
    /// <summary>Symbol to query</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed class BookTickerRequest
{
    /// <summary>Symbol to query</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<DiffBookDepthUpdateSpeed>))]
public readonly struct DiffBookDepthUpdateSpeed : IExtensibleValue<DiffBookDepthUpdateSpeed>, IEquatable<DiffBookDepthUpdateSpeed>
{
    private readonly string? _value;

    public DiffBookDepthUpdateSpeed(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static DiffBookDepthUpdateSpeed UpdateSpeed100ms { get; } = new("100ms");

    static DiffBookDepthUpdateSpeed IExtensibleValue<DiffBookDepthUpdateSpeed>.Create(string value) => new(value);

    public static bool operator ==(DiffBookDepthUpdateSpeed left, DiffBookDepthUpdateSpeed right) => left.Equals(right);

    public static bool operator !=(DiffBookDepthUpdateSpeed left, DiffBookDepthUpdateSpeed right) => !left.Equals(right);

    public static implicit operator DiffBookDepthUpdateSpeed(string value) => new(value);

    public static DiffBookDepthUpdateSpeed FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is DiffBookDepthUpdateSpeed other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(DiffBookDepthUpdateSpeed other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class DiffBookDepthRequest
{
    /// <summary>Symbol to query</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }

    /// <summary>Optional stream update speed suffix</summary>
    public DiffBookDepthUpdateSpeed? UpdateSpeed { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<KlineInterval>))]
public readonly struct KlineInterval : IExtensibleValue<KlineInterval>, IEquatable<KlineInterval>
{
    private readonly string? _value;

    public KlineInterval(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static KlineInterval Interval1s { get; } = new("1s");

    public static KlineInterval Interval1m { get; } = new("1m");

    public static KlineInterval Interval3m { get; } = new("3m");

    public static KlineInterval Interval5m { get; } = new("5m");

    public static KlineInterval Interval15m { get; } = new("15m");

    public static KlineInterval Interval30m { get; } = new("30m");

    public static KlineInterval Interval1h { get; } = new("1h");

    public static KlineInterval Interval2h { get; } = new("2h");

    public static KlineInterval Interval4h { get; } = new("4h");

    public static KlineInterval Interval6h { get; } = new("6h");

    public static KlineInterval Interval8h { get; } = new("8h");

    public static KlineInterval Interval12h { get; } = new("12h");

    public static KlineInterval Interval1d { get; } = new("1d");

    public static KlineInterval Interval3d { get; } = new("3d");

    public static KlineInterval Interval1w { get; } = new("1w");

    public static KlineInterval Interval1Month { get; } = new("1M");

    static KlineInterval IExtensibleValue<KlineInterval>.Create(string value) => new(value);

    public static bool operator ==(KlineInterval left, KlineInterval right) => left.Equals(right);

    public static bool operator !=(KlineInterval left, KlineInterval right) => !left.Equals(right);

    public static implicit operator KlineInterval(string value) => new(value);

    public static KlineInterval FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is KlineInterval other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(KlineInterval other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class KlineRequest
{
    /// <summary>Symbol to query</summary>
    public required string Symbol { get; init; }

    public required KlineInterval Interval { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<KlineOffsetInterval>))]
public readonly struct KlineOffsetInterval : IExtensibleValue<KlineOffsetInterval>, IEquatable<KlineOffsetInterval>
{
    private readonly string? _value;

    public KlineOffsetInterval(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static KlineOffsetInterval Interval1s { get; } = new("1s");

    public static KlineOffsetInterval Interval1m { get; } = new("1m");

    public static KlineOffsetInterval Interval3m { get; } = new("3m");

    public static KlineOffsetInterval Interval5m { get; } = new("5m");

    public static KlineOffsetInterval Interval15m { get; } = new("15m");

    public static KlineOffsetInterval Interval30m { get; } = new("30m");

    public static KlineOffsetInterval Interval1h { get; } = new("1h");

    public static KlineOffsetInterval Interval2h { get; } = new("2h");

    public static KlineOffsetInterval Interval4h { get; } = new("4h");

    public static KlineOffsetInterval Interval6h { get; } = new("6h");

    public static KlineOffsetInterval Interval8h { get; } = new("8h");

    public static KlineOffsetInterval Interval12h { get; } = new("12h");

    public static KlineOffsetInterval Interval1d { get; } = new("1d");

    public static KlineOffsetInterval Interval3d { get; } = new("3d");

    public static KlineOffsetInterval Interval1w { get; } = new("1w");

    public static KlineOffsetInterval Interval1Month { get; } = new("1M");

    static KlineOffsetInterval IExtensibleValue<KlineOffsetInterval>.Create(string value) => new(value);

    public static bool operator ==(KlineOffsetInterval left, KlineOffsetInterval right) => left.Equals(right);

    public static bool operator !=(KlineOffsetInterval left, KlineOffsetInterval right) => !left.Equals(right);

    public static implicit operator KlineOffsetInterval(string value) => new(value);

    public static KlineOffsetInterval FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is KlineOffsetInterval other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(KlineOffsetInterval other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class KlineOffsetRequest
{
    /// <summary>Symbol to query</summary>
    public required string Symbol { get; init; }

    public required KlineOffsetInterval Interval { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed class MiniTickerRequest
{
    /// <summary>Symbol to query</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<PartialBookDepthLevels>))]
public readonly struct PartialBookDepthLevels : IExtensibleValue<PartialBookDepthLevels>, IEquatable<PartialBookDepthLevels>
{
    private readonly string? _value;

    public PartialBookDepthLevels(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PartialBookDepthLevels Levels5 { get; } = new("5");

    public static PartialBookDepthLevels Levels10 { get; } = new("10");

    public static PartialBookDepthLevels Levels20 { get; } = new("20");

    static PartialBookDepthLevels IExtensibleValue<PartialBookDepthLevels>.Create(string value) => new(value);

    public static bool operator ==(PartialBookDepthLevels left, PartialBookDepthLevels right) => left.Equals(right);

    public static bool operator !=(PartialBookDepthLevels left, PartialBookDepthLevels right) => !left.Equals(right);

    public static implicit operator PartialBookDepthLevels(string value) => new(value);

    public static PartialBookDepthLevels FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PartialBookDepthLevels other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PartialBookDepthLevels other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<PartialBookDepthUpdateSpeed>))]
public readonly struct PartialBookDepthUpdateSpeed : IExtensibleValue<PartialBookDepthUpdateSpeed>, IEquatable<PartialBookDepthUpdateSpeed>
{
    private readonly string? _value;

    public PartialBookDepthUpdateSpeed(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PartialBookDepthUpdateSpeed UpdateSpeed100ms { get; } = new("100ms");

    static PartialBookDepthUpdateSpeed IExtensibleValue<PartialBookDepthUpdateSpeed>.Create(string value) => new(value);

    public static bool operator ==(PartialBookDepthUpdateSpeed left, PartialBookDepthUpdateSpeed right) => left.Equals(right);

    public static bool operator !=(PartialBookDepthUpdateSpeed left, PartialBookDepthUpdateSpeed right) => !left.Equals(right);

    public static implicit operator PartialBookDepthUpdateSpeed(string value) => new(value);

    public static PartialBookDepthUpdateSpeed FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PartialBookDepthUpdateSpeed other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PartialBookDepthUpdateSpeed other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class PartialBookDepthRequest
{
    /// <summary>Symbol to query</summary>
    public required string Symbol { get; init; }

    public required PartialBookDepthLevels Levels { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }

    /// <summary>Optional stream update speed suffix</summary>
    public PartialBookDepthUpdateSpeed? UpdateSpeed { get; init; }
}

public sealed class ReferencePriceRequest
{
    /// <summary>Symbol to query</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<RollingWindowTickerWindowSize>))]
public readonly struct RollingWindowTickerWindowSize : IExtensibleValue<RollingWindowTickerWindowSize>, IEquatable<RollingWindowTickerWindowSize>
{
    private readonly string? _value;

    public RollingWindowTickerWindowSize(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static RollingWindowTickerWindowSize WindowSize1h { get; } = new("1h");

    public static RollingWindowTickerWindowSize WindowSize4h { get; } = new("4h");

    public static RollingWindowTickerWindowSize WindowSize1d { get; } = new("1d");

    static RollingWindowTickerWindowSize IExtensibleValue<RollingWindowTickerWindowSize>.Create(string value) => new(value);

    public static bool operator ==(RollingWindowTickerWindowSize left, RollingWindowTickerWindowSize right) => left.Equals(right);

    public static bool operator !=(RollingWindowTickerWindowSize left, RollingWindowTickerWindowSize right) => !left.Equals(right);

    public static implicit operator RollingWindowTickerWindowSize(string value) => new(value);

    public static RollingWindowTickerWindowSize FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is RollingWindowTickerWindowSize other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(RollingWindowTickerWindowSize other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class RollingWindowTickerRequest
{
    /// <summary>Symbol to query</summary>
    public required string Symbol { get; init; }

    public required RollingWindowTickerWindowSize WindowSize { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed class TickerRequest
{
    /// <summary>Symbol to query</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed class TradeRequest
{
    /// <summary>Symbol to query</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed partial class SpotWebSocketStreamsConnection
{

    /// <summary>Aggregate Trade Streams</summary>
    /// <remarks>
    /// <para>The Aggregate Trade Streams push trade information that is aggregated for a single taker order.</para>
    /// <para>Update Speed: Real-time</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<AggTradeResponse> AggTrade(AggTradeRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@aggTrade", ("symbol", request.Symbol), ("id", request.Id)), SpotWebSocketStreamsJson.Default.AggTradeResponse, null, id: request.Id);
    }

    /// <summary>All Market Rolling Window Statistics Streams</summary>
    /// <remarks>
    /// <para>Rolling window ticker statistics for all market symbols, computed over multiple windows.</para>
    /// <para>Note that only tickers that have changed will be present in the array.</para>
    /// <para>Update Speed: 1000ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<List<AllMarketRollingWindowTickerResponseInner>> AllMarketRollingWindowTicker(AllMarketRollingWindowTickerRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/!ticker_<windowSize>@arr", ("windowSize", request.WindowSize), ("id", request.Id)), SpotWebSocketStreamsJson.Default.ListAllMarketRollingWindowTickerResponseInner, null, id: request.Id);
    }

    /// <summary>All Market Mini Tickers Stream</summary>
    /// <remarks>
    /// <para>
    /// 24hr rolling window mini-ticker statistics for all symbols that changed in an array. These are NOT
    /// the statistics of the UTC day, but a 24hr rolling window for the previous 24hrs. Note that only
    /// tickers that have changed will be present in the array.
    /// </para>
    /// <para>Update Speed: 1000ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<List<AllMiniTickerResponseInner>> AllMiniTicker(AllMiniTickerRequest? request = null)
    {
        request ??= new();
        return _client.Subscribe(StreamName.Build("/!miniTicker@arr", ("id", request.Id)), SpotWebSocketStreamsJson.Default.ListAllMiniTickerResponseInner, null, id: request.Id);
    }

    /// <summary>Average Price</summary>
    /// <remarks>
    /// <para>Average price streams push changes in the average price over a fixed time interval.</para>
    /// <para>Update Speed: 1000ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<AvgPriceResponse> AvgPrice(AvgPriceRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@avgPrice", ("symbol", request.Symbol), ("id", request.Id)), SpotWebSocketStreamsJson.Default.AvgPriceResponse, null, id: request.Id);
    }

    /// <summary>Block Trade Streams</summary>
    /// <remarks>
    /// <para>Block Trade Streams push block trade information in real-time.</para>
    /// <para>Update Speed: Real-time</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<BlockTradeResponse> BlockTrade(BlockTradeRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@blockTrade", ("symbol", request.Symbol), ("id", request.Id)), SpotWebSocketStreamsJson.Default.BlockTradeResponse, null, id: request.Id);
    }

    /// <summary>Individual Symbol Book Ticker Streams</summary>
    /// <remarks>
    /// <para>Pushes any update to the best bid or ask's price or quantity in real-time for a specified symbol.</para>
    /// <para>Multiple &lt;symbol&gt;@bookTicker streams can be subscribed to over one connection.</para>
    /// <para>Update Speed: Real-time</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<BookTickerResponse> BookTicker(BookTickerRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@bookTicker", ("symbol", request.Symbol), ("id", request.Id)), SpotWebSocketStreamsJson.Default.BookTickerResponse, null, id: request.Id);
    }

    /// <summary>Diff. Depth Stream</summary>
    /// <remarks>
    /// <para>Order book price and quantity depth updates used to locally manage an order book.</para>
    /// <para>Update Speed: 1000ms or 100ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<DiffBookDepthResponse> DiffBookDepth(DiffBookDepthRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@depth@<updateSpeed>", ("symbol", request.Symbol), ("id", request.Id), ("updateSpeed", request.UpdateSpeed)), SpotWebSocketStreamsJson.Default.DiffBookDepthResponse, null, id: request.Id);
    }

    /// <summary>Kline/Candlestick Streams for UTC</summary>
    /// <remarks>
    /// <para>
    /// The Kline/Candlestick Stream push updates to the current klines/candlestick every second in UTC+0
    /// timezone
    /// </para>
    /// <para>Update Speed: 1000ms for 1s, 2000ms for the other intervals</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<KlineResponse> Kline(KlineRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@kline_<interval>", ("symbol", request.Symbol), ("interval", request.Interval), ("id", request.Id)), SpotWebSocketStreamsJson.Default.KlineResponse, null, id: request.Id);
    }

    /// <summary>Kline/Candlestick Streams with timezone offset</summary>
    /// <remarks>
    /// <para>
    /// The Kline/Candlestick Stream push updates to the current klines/candlestick every second in UTC+8
    /// timezone
    /// </para>
    /// <para>Kline/Candlestick chart intervals:</para>
    /// <para>Supported intervals: See Kline/Candlestick chart intervals</para>
    /// <para>UTC+8 timezone offset:</para>
    /// <para>
    /// - Kline intervals open and close in the UTC+8 timezone. For example the 1d klines will open at the
    /// beginning of the UTC+8 day, and close at the end of the UTC+8 day.
    /// </para>
    /// <para>
    /// - Note that E (event time), t (start time) and T (close time) in the payload are Unix timestamps,
    /// which are always interpreted in UTC.
    /// </para>
    /// <para>Update Speed: 1000ms for 1s, 2000ms for the other intervals</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<KlineOffsetResponse> KlineOffset(KlineOffsetRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@kline_<interval>@+08:00", ("symbol", request.Symbol), ("interval", request.Interval), ("id", request.Id)), SpotWebSocketStreamsJson.Default.KlineOffsetResponse, null, id: request.Id);
    }

    /// <summary>Individual Symbol Mini Ticker Stream</summary>
    /// <remarks>
    /// <para>
    /// 24hr rolling window mini-ticker statistics. These are NOT the statistics of the UTC day, but a 24hr
    /// rolling window for the previous 24hrs.
    /// </para>
    /// <para>Update Speed: 1000ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<MiniTickerResponse> MiniTicker(MiniTickerRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@miniTicker", ("symbol", request.Symbol), ("id", request.Id)), SpotWebSocketStreamsJson.Default.MiniTickerResponse, null, id: request.Id);
    }

    /// <summary>Partial Book Depth Streams</summary>
    /// <remarks>
    /// <para>Top &lt;levels&gt; bids and asks, pushed every second. Valid &lt;levels&gt; are 5, 10, or 20.</para>
    /// <para>Update Speed: 1000ms or 100ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<PartialBookDepthResponse> PartialBookDepth(PartialBookDepthRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@depth<levels>@<updateSpeed>", ("symbol", request.Symbol), ("levels", request.Levels), ("id", request.Id), ("updateSpeed", request.UpdateSpeed)), SpotWebSocketStreamsJson.Default.PartialBookDepthResponse, null, id: request.Id);
    }

    /// <summary>Reference Price Streams</summary>
    /// <remarks>
    /// <para>Reference price stream for a symbol.</para>
    /// <para>Update Speed: 1000ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<ReferencePriceResponse> ReferencePrice(ReferencePriceRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@referencePrice", ("symbol", request.Symbol), ("id", request.Id)), SpotWebSocketStreamsJson.Default.ReferencePriceResponse, null, id: request.Id);
    }

    /// <summary>Individual Symbol Rolling Window Statistics Streams</summary>
    /// <remarks>
    /// <para>Rolling window ticker statistics for a single symbol, computed over multiple windows.</para>
    /// <para>
    /// Note: This stream is different from the &lt;symbol&gt;@ticker stream. The open time "O" always
    /// starts on a minute, while the closing time "C" is the current time of the update. As such, the
    /// effective window might be up to 59999ms wider than &lt;windowSize&gt;.
    /// </para>
    /// <para>Update Speed: 1000ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<RollingWindowTickerResponse> RollingWindowTicker(RollingWindowTickerRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@ticker_<windowSize>", ("symbol", request.Symbol), ("windowSize", request.WindowSize), ("id", request.Id)), SpotWebSocketStreamsJson.Default.RollingWindowTickerResponse, null, id: request.Id);
    }

    /// <summary>Individual Symbol Ticker Streams</summary>
    /// <remarks>
    /// <para>
    /// 24hr rolling window ticker statistics for a single symbol. These are NOT the statistics of the UTC
    /// day, but a 24hr rolling window for the previous 24hrs.
    /// </para>
    /// <para>Update Speed: 1000ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<TickerResponse> Ticker(TickerRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@ticker", ("symbol", request.Symbol), ("id", request.Id)), SpotWebSocketStreamsJson.Default.TickerResponse, null, id: request.Id);
    }

    /// <summary>Trade Streams</summary>
    /// <remarks>
    /// <para>The Trade Streams push raw trade information; each trade has a unique buyer and seller.</para>
    /// <para>Update Speed: Real-time</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<TradeResponse> Trade(TradeRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@trade", ("symbol", request.Symbol), ("id", request.Id)), SpotWebSocketStreamsJson.Default.TradeResponse, null, id: request.Id);
    }
}
