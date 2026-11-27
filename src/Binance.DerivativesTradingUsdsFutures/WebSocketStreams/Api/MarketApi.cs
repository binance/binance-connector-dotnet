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

namespace Binance.DerivativesTradingUsdsFutures.WebSocketStreams;

public sealed class AggregateTradeStreamsRequest
{
    /// <summary>The symbol parameter</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed class AllMarketLiquidationOrderStreamsRequest
{
    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed class AllMarketMiniTickersStreamRequest
{
    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed class AllMarketTickersStreamsRequest
{
    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed class AssetIndexRequest
{
    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed class CompositeIndexSymbolInformationStreamsRequest
{
    /// <summary>The symbol parameter</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<ContinuousContractKlineCandlestickStreamsContractType>))]
public readonly struct ContinuousContractKlineCandlestickStreamsContractType : IExtensibleValue<ContinuousContractKlineCandlestickStreamsContractType>, IEquatable<ContinuousContractKlineCandlestickStreamsContractType>
{
    private readonly string? _value;

    public ContinuousContractKlineCandlestickStreamsContractType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static ContinuousContractKlineCandlestickStreamsContractType Perpetual { get; } = new("perpetual");

    public static ContinuousContractKlineCandlestickStreamsContractType CurrentQuarter { get; } = new("current_quarter");

    public static ContinuousContractKlineCandlestickStreamsContractType NextQuarter { get; } = new("next_quarter");

    public static ContinuousContractKlineCandlestickStreamsContractType TradifiPerpetual { get; } = new("tradifi_perpetual");

    static ContinuousContractKlineCandlestickStreamsContractType IExtensibleValue<ContinuousContractKlineCandlestickStreamsContractType>.Create(string value) => new(value);

    public static bool operator ==(ContinuousContractKlineCandlestickStreamsContractType left, ContinuousContractKlineCandlestickStreamsContractType right) => left.Equals(right);

    public static bool operator !=(ContinuousContractKlineCandlestickStreamsContractType left, ContinuousContractKlineCandlestickStreamsContractType right) => !left.Equals(right);

    public static implicit operator ContinuousContractKlineCandlestickStreamsContractType(string value) => new(value);

    public static ContinuousContractKlineCandlestickStreamsContractType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ContinuousContractKlineCandlestickStreamsContractType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ContinuousContractKlineCandlestickStreamsContractType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<ContinuousContractKlineCandlestickStreamsInterval>))]
public readonly struct ContinuousContractKlineCandlestickStreamsInterval : IExtensibleValue<ContinuousContractKlineCandlestickStreamsInterval>, IEquatable<ContinuousContractKlineCandlestickStreamsInterval>
{
    private readonly string? _value;

    public ContinuousContractKlineCandlestickStreamsInterval(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static ContinuousContractKlineCandlestickStreamsInterval Interval1s { get; } = new("1s");

    public static ContinuousContractKlineCandlestickStreamsInterval Interval1m { get; } = new("1m");

    public static ContinuousContractKlineCandlestickStreamsInterval Interval3m { get; } = new("3m");

    public static ContinuousContractKlineCandlestickStreamsInterval Interval5m { get; } = new("5m");

    public static ContinuousContractKlineCandlestickStreamsInterval Interval15m { get; } = new("15m");

    public static ContinuousContractKlineCandlestickStreamsInterval Interval30m { get; } = new("30m");

    public static ContinuousContractKlineCandlestickStreamsInterval Interval1h { get; } = new("1h");

    public static ContinuousContractKlineCandlestickStreamsInterval Interval2h { get; } = new("2h");

    public static ContinuousContractKlineCandlestickStreamsInterval Interval4h { get; } = new("4h");

    public static ContinuousContractKlineCandlestickStreamsInterval Interval6h { get; } = new("6h");

    public static ContinuousContractKlineCandlestickStreamsInterval Interval8h { get; } = new("8h");

    public static ContinuousContractKlineCandlestickStreamsInterval Interval12h { get; } = new("12h");

    public static ContinuousContractKlineCandlestickStreamsInterval Interval1d { get; } = new("1d");

    public static ContinuousContractKlineCandlestickStreamsInterval Interval3d { get; } = new("3d");

    public static ContinuousContractKlineCandlestickStreamsInterval Interval1w { get; } = new("1w");

    public static ContinuousContractKlineCandlestickStreamsInterval Interval1Month { get; } = new("1M");

    static ContinuousContractKlineCandlestickStreamsInterval IExtensibleValue<ContinuousContractKlineCandlestickStreamsInterval>.Create(string value) => new(value);

    public static bool operator ==(ContinuousContractKlineCandlestickStreamsInterval left, ContinuousContractKlineCandlestickStreamsInterval right) => left.Equals(right);

    public static bool operator !=(ContinuousContractKlineCandlestickStreamsInterval left, ContinuousContractKlineCandlestickStreamsInterval right) => !left.Equals(right);

    public static implicit operator ContinuousContractKlineCandlestickStreamsInterval(string value) => new(value);

    public static ContinuousContractKlineCandlestickStreamsInterval FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ContinuousContractKlineCandlestickStreamsInterval other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ContinuousContractKlineCandlestickStreamsInterval other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class ContinuousContractKlineCandlestickStreamsRequest
{
    public required string Pair { get; init; }

    public required ContinuousContractKlineCandlestickStreamsContractType ContractType { get; init; }

    public required ContinuousContractKlineCandlestickStreamsInterval Interval { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed class ContractInfoStreamRequest
{
    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed class IndividualSymbolMiniTickerStreamRequest
{
    /// <summary>The symbol parameter</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed class IndividualSymbolTickerStreamsRequest
{
    /// <summary>The symbol parameter</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<KlineCandlestickStreamsInterval>))]
public readonly struct KlineCandlestickStreamsInterval : IExtensibleValue<KlineCandlestickStreamsInterval>, IEquatable<KlineCandlestickStreamsInterval>
{
    private readonly string? _value;

    public KlineCandlestickStreamsInterval(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static KlineCandlestickStreamsInterval Interval1m { get; } = new("1m");

    public static KlineCandlestickStreamsInterval Interval3m { get; } = new("3m");

    public static KlineCandlestickStreamsInterval Interval5m { get; } = new("5m");

    public static KlineCandlestickStreamsInterval Interval15m { get; } = new("15m");

    public static KlineCandlestickStreamsInterval Interval30m { get; } = new("30m");

    public static KlineCandlestickStreamsInterval Interval1h { get; } = new("1h");

    public static KlineCandlestickStreamsInterval Interval2h { get; } = new("2h");

    public static KlineCandlestickStreamsInterval Interval4h { get; } = new("4h");

    public static KlineCandlestickStreamsInterval Interval6h { get; } = new("6h");

    public static KlineCandlestickStreamsInterval Interval8h { get; } = new("8h");

    public static KlineCandlestickStreamsInterval Interval12h { get; } = new("12h");

    public static KlineCandlestickStreamsInterval Interval1d { get; } = new("1d");

    public static KlineCandlestickStreamsInterval Interval3d { get; } = new("3d");

    public static KlineCandlestickStreamsInterval Interval1w { get; } = new("1w");

    public static KlineCandlestickStreamsInterval Interval1Month { get; } = new("1M");

    static KlineCandlestickStreamsInterval IExtensibleValue<KlineCandlestickStreamsInterval>.Create(string value) => new(value);

    public static bool operator ==(KlineCandlestickStreamsInterval left, KlineCandlestickStreamsInterval right) => left.Equals(right);

    public static bool operator !=(KlineCandlestickStreamsInterval left, KlineCandlestickStreamsInterval right) => !left.Equals(right);

    public static implicit operator KlineCandlestickStreamsInterval(string value) => new(value);

    public static KlineCandlestickStreamsInterval FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is KlineCandlestickStreamsInterval other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(KlineCandlestickStreamsInterval other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class KlineCandlestickStreamsRequest
{
    /// <summary>The symbol parameter</summary>
    public required string Symbol { get; init; }

    /// <summary>The interval parameter</summary>
    public required KlineCandlestickStreamsInterval Interval { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed class LiquidationOrderStreamsRequest
{
    /// <summary>The symbol parameter</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<MarkPriceStreamUpdateSpeed>))]
public readonly struct MarkPriceStreamUpdateSpeed : IExtensibleValue<MarkPriceStreamUpdateSpeed>, IEquatable<MarkPriceStreamUpdateSpeed>
{
    private readonly string? _value;

    public MarkPriceStreamUpdateSpeed(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarkPriceStreamUpdateSpeed UpdateSpeed1s { get; } = new("1s");

    static MarkPriceStreamUpdateSpeed IExtensibleValue<MarkPriceStreamUpdateSpeed>.Create(string value) => new(value);

    public static bool operator ==(MarkPriceStreamUpdateSpeed left, MarkPriceStreamUpdateSpeed right) => left.Equals(right);

    public static bool operator !=(MarkPriceStreamUpdateSpeed left, MarkPriceStreamUpdateSpeed right) => !left.Equals(right);

    public static implicit operator MarkPriceStreamUpdateSpeed(string value) => new(value);

    public static MarkPriceStreamUpdateSpeed FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarkPriceStreamUpdateSpeed other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarkPriceStreamUpdateSpeed other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class MarkPriceStreamRequest
{
    /// <summary>The symbol parameter</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }

    /// <summary>WebSocket stream update speed</summary>
    public MarkPriceStreamUpdateSpeed? UpdateSpeed { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<MarkPriceStreamForAllMarketUpdateSpeed>))]
public readonly struct MarkPriceStreamForAllMarketUpdateSpeed : IExtensibleValue<MarkPriceStreamForAllMarketUpdateSpeed>, IEquatable<MarkPriceStreamForAllMarketUpdateSpeed>
{
    private readonly string? _value;

    public MarkPriceStreamForAllMarketUpdateSpeed(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarkPriceStreamForAllMarketUpdateSpeed UpdateSpeed1s { get; } = new("1s");

    static MarkPriceStreamForAllMarketUpdateSpeed IExtensibleValue<MarkPriceStreamForAllMarketUpdateSpeed>.Create(string value) => new(value);

    public static bool operator ==(MarkPriceStreamForAllMarketUpdateSpeed left, MarkPriceStreamForAllMarketUpdateSpeed right) => left.Equals(right);

    public static bool operator !=(MarkPriceStreamForAllMarketUpdateSpeed left, MarkPriceStreamForAllMarketUpdateSpeed right) => !left.Equals(right);

    public static implicit operator MarkPriceStreamForAllMarketUpdateSpeed(string value) => new(value);

    public static MarkPriceStreamForAllMarketUpdateSpeed FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarkPriceStreamForAllMarketUpdateSpeed other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarkPriceStreamForAllMarketUpdateSpeed other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class MarkPriceStreamForAllMarketRequest
{
    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }

    /// <summary>WebSocket stream update speed</summary>
    public MarkPriceStreamForAllMarketUpdateSpeed? UpdateSpeed { get; init; }
}

public sealed class TradingSessionStreamRequest
{
    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed partial class DerivativesTradingUsdsFuturesWebSocketStreamsConnection
{

    /// <summary>Aggregate Trade Streams</summary>
    /// <remarks>
    /// <para>
    /// The Aggregate Trade Streams push market trade information that is aggregated for fills with same
    /// price and taking side every 100 milliseconds. Only market trades will be aggregated, which means the
    /// insurance fund trades and ADL trades won't be aggregated.
    /// </para>
    /// <para>&gt; After CM migration, the payload is appended with a new st field (1 = UM, 2 = CM).</para>
    /// <para>Update Speed: 100ms</para>
    /// <para>Response Notes:</para>
    /// <para>
    /// - Retail Price Improvement(RPI) orders are aggregated into field q and without special tags to be
    /// distinguished.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<AggregateTradeStreamsResponse> AggregateTradeStreams(AggregateTradeStreamsRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@aggTrade", ("symbol", request.Symbol), ("id", request.Id)), DerivativesTradingUsdsFuturesWebSocketStreamsJson.Default.AggregateTradeStreamsResponse, "market", id: request.Id);
    }

    /// <summary>All Market Liquidation Order Streams</summary>
    /// <remarks>
    /// <para>
    /// The All Liquidation Order Snapshot Streams push force liquidation order information for all symbols
    /// in the market. For each symbol，only the largest one liquidation order within 1000ms will be pushed
    /// as the snapshot. If no liquidation happens in the interval of 1000ms, no stream will be pushed.
    /// </para>
    /// <para>
    /// &gt; After CM migration, this stream pushes the merged UM + CM universe (subscribable on both
    /// fstream and dstream); each payload is appended with a new st field (1 = UM, 2 = CM) and a new ps
    /// field (pair symbol).
    /// </para>
    /// <para>Update Speed: 1000ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<AllMarketLiquidationOrderStreamsResponse> AllMarketLiquidationOrderStreams(AllMarketLiquidationOrderStreamsRequest? request = null)
    {
        request ??= new();
        return _client.Subscribe(StreamName.Build("/!forceOrder@arr", ("id", request.Id)), DerivativesTradingUsdsFuturesWebSocketStreamsJson.Default.AllMarketLiquidationOrderStreamsResponse, "market", id: request.Id);
    }

    /// <summary>All Market Mini Tickers Stream</summary>
    /// <remarks>
    /// <para>
    /// 24hr rolling window mini-ticker statistics for all symbols. These are NOT the statistics of the UTC
    /// day, but a 24hr rolling window from requestTime to 24hrs before. Note that only tickers that have
    /// changed will be present in the array.
    /// </para>
    /// <para>
    /// &gt; After CM migration, this stream pushes the merged UM + CM universe (subscribable on both
    /// fstream and dstream); each payload is appended with a new st field (1 = UM, 2 = CM) and a new ps
    /// field (pair symbol).
    /// </para>
    /// <para>Update Speed: 1000ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<List<AllMarketMiniTickersStreamResponseInner>> AllMarketMiniTickersStream(AllMarketMiniTickersStreamRequest? request = null)
    {
        request ??= new();
        return _client.Subscribe(StreamName.Build("/!miniTicker@arr", ("id", request.Id)), DerivativesTradingUsdsFuturesWebSocketStreamsJson.Default.ListAllMarketMiniTickersStreamResponseInner, "market", id: request.Id);
    }

    /// <summary>All Market Tickers Streams</summary>
    /// <remarks>
    /// <para>
    /// 24hr rolling window ticker statistics for all symbols. These are NOT the statistics of the UTC day,
    /// but a 24hr rolling window from requestTime to 24hrs before. Note that only tickers that have changed
    /// will be present in the array.
    /// </para>
    /// <para>
    /// &gt; After CM migration, this stream pushes the merged UM + CM universe (subscribable on both
    /// fstream and dstream); each payload is appended with a new st field (1 = UM, 2 = CM) and a new ps
    /// field (pair symbol).
    /// </para>
    /// <para>Update Speed: 1000ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<List<AllMarketTickersStreamsResponseInner>> AllMarketTickersStreams(AllMarketTickersStreamsRequest? request = null)
    {
        request ??= new();
        return _client.Subscribe(StreamName.Build("/!ticker@arr", ("id", request.Id)), DerivativesTradingUsdsFuturesWebSocketStreamsJson.Default.ListAllMarketTickersStreamsResponseInner, "market", id: request.Id);
    }

    /// <summary>Multi-Assets Mode Asset Index</summary>
    /// <remarks>
    /// <para>
    /// Asset index price. Subscribe with !assetIndex@arr for all assets, or &lt;assetSymbol&gt;@assetIndex
    /// for a specific asset.
    /// </para>
    /// <para>
    /// &gt; CM-UM Integration (Effective 2026-06-30): Renamed from Multi-Assets Mode Asset Index. The
    /// stream !assetIndex@arr now additionally pushes COIN-M settlement-asset price index entries (e.g.,
    /// BTCUSD, ETHUSD, BNBUSD). The on-the-wire stream key is unchanged; existing subscriptions continue to
    /// work.
    /// </para>
    /// <para>Update Speed: 1s</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<List<AssetIndexResponseInner>> AssetIndex(AssetIndexRequest? request = null)
    {
        request ??= new();
        return _client.Subscribe(StreamName.Build("/!assetIndex@arr", ("id", request.Id)), DerivativesTradingUsdsFuturesWebSocketStreamsJson.Default.ListAssetIndexResponseInner, "market", id: request.Id);
    }

    /// <summary>Composite Index Symbol Information Streams</summary>
    /// <remarks>
    /// <para>Composite index information for index symbols pushed every second.</para>
    /// <para>Update Speed: 1000ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<CompositeIndexSymbolInformationStreamsResponse> CompositeIndexSymbolInformationStreams(CompositeIndexSymbolInformationStreamsRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@compositeIndex", ("symbol", request.Symbol), ("id", request.Id)), DerivativesTradingUsdsFuturesWebSocketStreamsJson.Default.CompositeIndexSymbolInformationStreamsResponse, "market", id: request.Id);
    }

    /// <summary>Continuous Contract Kline/Candlestick Streams</summary>
    /// <remarks>
    /// <para>
    /// &gt; After CM migration, both fstream and dstream may subscribe to either UM or CM symbols on this
    /// stream.
    /// </para>
    /// <para>Update Speed: 250ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<ContinuousContractKlineCandlestickStreamsResponse> ContinuousContractKlineCandlestickStreams(ContinuousContractKlineCandlestickStreamsRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<pair>_<contractType>@continuousKline_<interval>", ("pair", request.Pair), ("contractType", request.ContractType), ("interval", request.Interval), ("id", request.Id)), DerivativesTradingUsdsFuturesWebSocketStreamsJson.Default.ContinuousContractKlineCandlestickStreamsResponse, "market", id: request.Id);
    }

    /// <summary>Contract Info Stream</summary>
    /// <remarks>
    /// <para>
    /// ContractInfo stream pushes when contract info updates(listing/settlement/contract bracket update).
    /// bks field only shows up when bracket gets updated.
    /// </para>
    /// <para>
    /// &gt; After CM migration, this stream pushes the merged UM + CM universe (subscribable on both
    /// fstream and dstream); each payload is appended with a new st field (1 = UM, 2 = CM).
    /// </para>
    /// <para>Update Speed: Real-time</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<ContractInfoStreamResponse> ContractInfoStream(ContractInfoStreamRequest? request = null)
    {
        request ??= new();
        return _client.Subscribe(StreamName.Build("/!contractInfo", ("id", request.Id)), DerivativesTradingUsdsFuturesWebSocketStreamsJson.Default.ContractInfoStreamResponse, "market", id: request.Id);
    }

    /// <summary>Individual Symbol Mini Ticker Stream</summary>
    /// <remarks>
    /// <para>
    /// 24hr rolling window mini-ticker statistics for a single symbol. These are NOT the statistics of the
    /// UTC day, but a 24hr rolling window from requestTime to 24hrs before.
    /// </para>
    /// <para>
    /// &gt; After CM migration, the payload is appended with a new st field (1 = UM, 2 = CM) and a new ps
    /// field (pair symbol).
    /// </para>
    /// <para>Update Speed: 2s</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<IndividualSymbolMiniTickerStreamResponse> IndividualSymbolMiniTickerStream(IndividualSymbolMiniTickerStreamRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@miniTicker", ("symbol", request.Symbol), ("id", request.Id)), DerivativesTradingUsdsFuturesWebSocketStreamsJson.Default.IndividualSymbolMiniTickerStreamResponse, "market", id: request.Id);
    }

    /// <summary>Individual Symbol Ticker Streams</summary>
    /// <remarks>
    /// <para>
    /// 24hr rolling window ticker statistics for a single symbol. These are NOT the statistics of the UTC
    /// day, but a 24hr rolling window from requestTime to 24hrs before.
    /// </para>
    /// <para>
    /// &gt; After CM migration, the payload is appended with a new st field (1 = UM, 2 = CM) and a new ps
    /// field (pair symbol).
    /// </para>
    /// <para>Update Speed: 2000ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<IndividualSymbolTickerStreamsResponse> IndividualSymbolTickerStreams(IndividualSymbolTickerStreamsRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@ticker", ("symbol", request.Symbol), ("id", request.Id)), DerivativesTradingUsdsFuturesWebSocketStreamsJson.Default.IndividualSymbolTickerStreamsResponse, "market", id: request.Id);
    }

    /// <summary>Kline/Candlestick Streams</summary>
    /// <remarks>
    /// <para>
    /// The Kline/Candlestick Stream push updates to the current klines/candlestick every 250 milliseconds
    /// (if existing).
    /// </para>
    /// <para>
    /// &gt; After CM migration, both fstream and dstream may subscribe to either UM or CM symbols on this
    /// stream.
    /// </para>
    /// <para>Update Speed: 250ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<KlineCandlestickStreamsResponse> KlineCandlestickStreams(KlineCandlestickStreamsRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@kline_<interval>", ("symbol", request.Symbol), ("interval", request.Interval), ("id", request.Id)), DerivativesTradingUsdsFuturesWebSocketStreamsJson.Default.KlineCandlestickStreamsResponse, "market", id: request.Id);
    }

    /// <summary>Liquidation Order Streams</summary>
    /// <remarks>
    /// <para>
    /// The Liquidation Order Snapshot Streams push force liquidation order information for specific symbol.
    /// For each symbol，only the largest one liquidation order within 1000ms will be pushed as the snapshot.
    /// If no liquidation happens in the interval of 1000ms, no stream will be pushed.
    /// </para>
    /// <para>Update Speed: 1000ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<LiquidationOrderStreamsResponse> LiquidationOrderStreams(LiquidationOrderStreamsRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@forceOrder", ("symbol", request.Symbol), ("id", request.Id)), DerivativesTradingUsdsFuturesWebSocketStreamsJson.Default.LiquidationOrderStreamsResponse, "market", id: request.Id);
    }

    /// <summary>Mark Price Stream</summary>
    /// <remarks>
    /// <para>Mark price and funding rate for a single symbol pushed every 3 seconds or every second.</para>
    /// <para>
    /// &gt; After CM migration, the payload is appended with a new st field (1 = UM, 2 = CM); both fstream
    /// and dstream may subscribe to either UM or CM symbols on this stream.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<MarkPriceStreamResponse> MarkPriceStream(MarkPriceStreamRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@markPrice@<updateSpeed>", ("symbol", request.Symbol), ("id", request.Id), ("updateSpeed", request.UpdateSpeed)), DerivativesTradingUsdsFuturesWebSocketStreamsJson.Default.MarkPriceStreamResponse, "market", id: request.Id);
    }

    /// <summary>Mark Price Stream for All market</summary>
    /// <remarks>
    /// <para>Mark price and funding rate for all symbols pushed every 3 seconds or every second.</para>
    /// <para>Note:</para>
    /// <para>- TradFi symbols will be pushed through a seperate message.</para>
    /// <para>
    /// &gt; After CM migration, the payload is appended with a new st field (1 = UM, 2 = CM); both fstream
    /// and dstream may subscribe to either UM or CM symbols on this stream.
    /// </para>
    /// <para>Update Speed: 3s or 1s</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<List<MarkPriceStreamForAllMarketResponseInner>> MarkPriceStreamForAllMarket(MarkPriceStreamForAllMarketRequest? request = null)
    {
        request ??= new();
        return _client.Subscribe(StreamName.Build("/!markPrice@arr@<updateSpeed>", ("id", request.Id), ("updateSpeed", request.UpdateSpeed)), DerivativesTradingUsdsFuturesWebSocketStreamsJson.Default.ListMarkPriceStreamForAllMarketResponseInner, "market", id: request.Id);
    }

    /// <summary>Trading Session Stream</summary>
    /// <remarks>
    /// <para>
    /// Trading session information for the underlying assets of TradFi Perpetual contracts, covering the
    /// U.S. equity market, Korean equity market, Hong Kong equity market, China equity market, the
    /// commodity market, and the FX market, is updated every second. Trading session information for
    /// different underlying markets is pushed in separate messages.
    /// </para>
    /// <para>Event type:</para>
    /// <para>
    /// - EquityUpdate: Session types for the U.S. equity market include "PRE_MARKET", "REGULAR",
    /// "AFTER_MARKET", "OVERNIGHT", and "NO_TRADING".
    /// </para>
    /// <para>- CommodityUpdate: Session types for the commodity market include "REGULAR" and "NO_TRADING".</para>
    /// <para>- KR_EquityUpdate: Session types for the Korean equity market include "REGULAR" and "NO_TRADING".</para>
    /// <para>- HK_EquityUpdate: Session types for the Hong Kong equity market include "REGULAR" and "NO_TRADING".</para>
    /// <para>- CN_EquityUpdate: Session types for the China equity market include "REGULAR" and "NO_TRADING".</para>
    /// <para>- FXUpdate: Session types for the FX market include "REGULAR" and "NO_TRADING".</para>
    /// <para>Update Speed: 1s</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<TradingSessionStreamResponse> TradingSessionStream(TradingSessionStreamRequest? request = null)
    {
        request ??= new();
        return _client.Subscribe(StreamName.Build("/tradingSession", ("id", request.Id)), DerivativesTradingUsdsFuturesWebSocketStreamsJson.Default.TradingSessionStreamResponse, "market", id: request.Id);
    }
}
