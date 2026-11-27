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

namespace Binance.Alpha.WebSocketStreams;

public sealed class AggregateTradeStreamRequest
{
    /// <summary>Symbol to subscribe, in lowercase stream format.</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public long? Id { get; init; }
}

public sealed class AllBookTickerStreamRequest
{
    /// <summary>Unique WebSocket request ID.</summary>
    public long? Id { get; init; }
}

public sealed class AllMiniTickerStreamRequest
{
    /// <summary>Unique WebSocket request ID.</summary>
    public long? Id { get; init; }
}

public sealed class AllTickerStreamRequest
{
    /// <summary>Unique WebSocket request ID.</summary>
    public long? Id { get; init; }
}

public sealed class AllTokens24hTickerStreamRequest
{
    /// <summary>Unique WebSocket request ID.</summary>
    public long? Id { get; init; }
}

public sealed class BookTickerStreamRequest
{
    /// <summary>Symbol to subscribe, in lowercase stream format.</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public long? Id { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<ContractKlineStreamInterval>))]
public readonly struct ContractKlineStreamInterval : IExtensibleValue<ContractKlineStreamInterval>, IEquatable<ContractKlineStreamInterval>
{
    private readonly string? _value;

    public ContractKlineStreamInterval(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static ContractKlineStreamInterval Interval1s { get; } = new("1s");

    public static ContractKlineStreamInterval Interval1m { get; } = new("1m");

    public static ContractKlineStreamInterval Interval5m { get; } = new("5m");

    public static ContractKlineStreamInterval Interval15m { get; } = new("15m");

    public static ContractKlineStreamInterval Interval1h { get; } = new("1h");

    public static ContractKlineStreamInterval Interval4h { get; } = new("4h");

    public static ContractKlineStreamInterval Interval1d { get; } = new("1d");

    static ContractKlineStreamInterval IExtensibleValue<ContractKlineStreamInterval>.Create(string value) => new(value);

    public static bool operator ==(ContractKlineStreamInterval left, ContractKlineStreamInterval right) => left.Equals(right);

    public static bool operator !=(ContractKlineStreamInterval left, ContractKlineStreamInterval right) => !left.Equals(right);

    public static implicit operator ContractKlineStreamInterval(string value) => new(value);

    public static ContractKlineStreamInterval FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ContractKlineStreamInterval other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ContractKlineStreamInterval other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class ContractKlineStreamRequest
{
    /// <summary>Contract address.</summary>
    public required string ContractAddress { get; init; }

    /// <summary>Chain ID.</summary>
    public required string ChainId { get; init; }

    /// <summary>Kline interval.</summary>
    public required ContractKlineStreamInterval Interval { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public long? Id { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<FullDepthStreamInterval>))]
public readonly struct FullDepthStreamInterval : IExtensibleValue<FullDepthStreamInterval>, IEquatable<FullDepthStreamInterval>
{
    private readonly string? _value;

    public FullDepthStreamInterval(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static FullDepthStreamInterval Interval0ms { get; } = new("0ms");

    public static FullDepthStreamInterval Interval100ms { get; } = new("100ms");

    public static FullDepthStreamInterval Interval500ms { get; } = new("500ms");

    static FullDepthStreamInterval IExtensibleValue<FullDepthStreamInterval>.Create(string value) => new(value);

    public static bool operator ==(FullDepthStreamInterval left, FullDepthStreamInterval right) => left.Equals(right);

    public static bool operator !=(FullDepthStreamInterval left, FullDepthStreamInterval right) => !left.Equals(right);

    public static implicit operator FullDepthStreamInterval(string value) => new(value);

    public static FullDepthStreamInterval FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is FullDepthStreamInterval other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(FullDepthStreamInterval other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class FullDepthStreamRequest
{
    /// <summary>Symbol to subscribe, in lowercase stream format.</summary>
    public required string Symbol { get; init; }

    /// <summary>Update interval.</summary>
    public required FullDepthStreamInterval Interval { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public long? Id { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<KlineStreamInterval>))]
public readonly struct KlineStreamInterval : IExtensibleValue<KlineStreamInterval>, IEquatable<KlineStreamInterval>
{
    private readonly string? _value;

    public KlineStreamInterval(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static KlineStreamInterval Interval1m { get; } = new("1m");

    public static KlineStreamInterval Interval3m { get; } = new("3m");

    public static KlineStreamInterval Interval5m { get; } = new("5m");

    public static KlineStreamInterval Interval15m { get; } = new("15m");

    public static KlineStreamInterval Interval30m { get; } = new("30m");

    public static KlineStreamInterval Interval1h { get; } = new("1h");

    public static KlineStreamInterval Interval2h { get; } = new("2h");

    public static KlineStreamInterval Interval4h { get; } = new("4h");

    public static KlineStreamInterval Interval6h { get; } = new("6h");

    public static KlineStreamInterval Interval8h { get; } = new("8h");

    public static KlineStreamInterval Interval12h { get; } = new("12h");

    public static KlineStreamInterval Interval1d { get; } = new("1d");

    public static KlineStreamInterval Interval3d { get; } = new("3d");

    public static KlineStreamInterval Interval1w { get; } = new("1w");

    public static KlineStreamInterval Interval1Month { get; } = new("1M");

    static KlineStreamInterval IExtensibleValue<KlineStreamInterval>.Create(string value) => new(value);

    public static bool operator ==(KlineStreamInterval left, KlineStreamInterval right) => left.Equals(right);

    public static bool operator !=(KlineStreamInterval left, KlineStreamInterval right) => !left.Equals(right);

    public static implicit operator KlineStreamInterval(string value) => new(value);

    public static KlineStreamInterval FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is KlineStreamInterval other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(KlineStreamInterval other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class KlineStreamRequest
{
    /// <summary>Symbol to subscribe, in lowercase stream format.</summary>
    public required string Symbol { get; init; }

    /// <summary>Kline interval.</summary>
    public required KlineStreamInterval Interval { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public long? Id { get; init; }
}

public sealed class MiniTickerStreamRequest
{
    /// <summary>Symbol to subscribe, in lowercase stream format.</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public long? Id { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<PartialDepthStreamLevels>))]
public readonly struct PartialDepthStreamLevels : IExtensibleValue<PartialDepthStreamLevels>, IEquatable<PartialDepthStreamLevels>
{
    private readonly string? _value;

    public PartialDepthStreamLevels(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PartialDepthStreamLevels Levels5 { get; } = new("5");

    public static PartialDepthStreamLevels Levels10 { get; } = new("10");

    public static PartialDepthStreamLevels Levels20 { get; } = new("20");

    static PartialDepthStreamLevels IExtensibleValue<PartialDepthStreamLevels>.Create(string value) => new(value);

    public static bool operator ==(PartialDepthStreamLevels left, PartialDepthStreamLevels right) => left.Equals(right);

    public static bool operator !=(PartialDepthStreamLevels left, PartialDepthStreamLevels right) => !left.Equals(right);

    public static implicit operator PartialDepthStreamLevels(string value) => new(value);

    public static PartialDepthStreamLevels FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PartialDepthStreamLevels other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PartialDepthStreamLevels other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<PartialDepthStreamInterval>))]
public readonly struct PartialDepthStreamInterval : IExtensibleValue<PartialDepthStreamInterval>, IEquatable<PartialDepthStreamInterval>
{
    private readonly string? _value;

    public PartialDepthStreamInterval(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PartialDepthStreamInterval Interval0ms { get; } = new("0ms");

    public static PartialDepthStreamInterval Interval100ms { get; } = new("100ms");

    public static PartialDepthStreamInterval Interval500ms { get; } = new("500ms");

    static PartialDepthStreamInterval IExtensibleValue<PartialDepthStreamInterval>.Create(string value) => new(value);

    public static bool operator ==(PartialDepthStreamInterval left, PartialDepthStreamInterval right) => left.Equals(right);

    public static bool operator !=(PartialDepthStreamInterval left, PartialDepthStreamInterval right) => !left.Equals(right);

    public static implicit operator PartialDepthStreamInterval(string value) => new(value);

    public static PartialDepthStreamInterval FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PartialDepthStreamInterval other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PartialDepthStreamInterval other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class PartialDepthStreamRequest
{
    /// <summary>Symbol to subscribe, in lowercase stream format.</summary>
    public required string Symbol { get; init; }

    /// <summary>Depth levels.</summary>
    public required PartialDepthStreamLevels Levels { get; init; }

    /// <summary>Update interval.</summary>
    public required PartialDepthStreamInterval Interval { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public long? Id { get; init; }
}

public sealed class TickerStreamRequest
{
    /// <summary>Symbol to subscribe, in lowercase stream format.</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public long? Id { get; init; }
}

public sealed class TradeStreamRequest
{
    /// <summary>Symbol to subscribe, in lowercase stream format.</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public long? Id { get; init; }
}

public sealed partial class AlphaWebSocketStreamsConnection
{

    /// <summary>Aggregate Trade Stream</summary>
    /// <remarks>Pushes aggregate trade updates for a symbol.</remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<AggregateTradeStreamResponse> AggregateTradeStream(AggregateTradeStreamRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@aggTrade", ("symbol", request.Symbol), ("id", request.Id)), AlphaWebSocketStreamsJson.Default.AggregateTradeStreamResponse, null, id: request.Id);
    }

    /// <summary>All Book Ticker Stream</summary>
    /// <remarks>Pushes best bid/ask updates for all symbols.</remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<AllBookTickerStreamResponse> AllBookTickerStream(AllBookTickerStreamRequest? request = null)
    {
        request ??= new();
        return _client.Subscribe(StreamName.Build("/!bookTicker", ("id", request.Id)), AlphaWebSocketStreamsJson.Default.AllBookTickerStreamResponse, null, id: request.Id);
    }

    /// <summary>All Mini Ticker Stream</summary>
    /// <remarks>Pushes mini ticker statistics for all symbols.</remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<AllMiniTickerStreamResponse> AllMiniTickerStream(AllMiniTickerStreamRequest? request = null)
    {
        request ??= new();
        return _client.Subscribe(StreamName.Build("/!miniTicker@arr", ("id", request.Id)), AlphaWebSocketStreamsJson.Default.AllMiniTickerStreamResponse, null, id: request.Id);
    }

    /// <summary>All Ticker Stream</summary>
    /// <remarks>Pushes full ticker statistics for all symbols.</remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<AllTickerStreamResponse> AllTickerStream(AllTickerStreamRequest? request = null)
    {
        request ??= new();
        return _client.Subscribe(StreamName.Build("/!ticker@arr", ("id", request.Id)), AlphaWebSocketStreamsJson.Default.AllTickerStreamResponse, null, id: request.Id);
    }

    /// <summary>All Tokens 24h Ticker Stream</summary>
    /// <remarks>Pushes 24h ticker-like metrics for all tokens.</remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<AllTokens24hTickerStreamResponse> AllTokens24hTickerStream(AllTokens24hTickerStreamRequest? request = null)
    {
        request ??= new();
        return _client.Subscribe(StreamName.Build("/came@allTokens@ticker24", ("id", request.Id)), AlphaWebSocketStreamsJson.Default.AllTokens24hTickerStreamResponse, null, id: request.Id);
    }

    /// <summary>Book Ticker Stream</summary>
    /// <remarks>Pushes best bid/ask updates for a symbol.</remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<BookTickerStreamResponse> BookTickerStream(BookTickerStreamRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@bookTicker", ("symbol", request.Symbol), ("id", request.Id)), AlphaWebSocketStreamsJson.Default.BookTickerStreamResponse, null, id: request.Id);
    }

    /// <summary>Contract Kline Stream</summary>
    /// <remarks>Pushes kline updates by contractAddress@chainId.</remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<ContractKlineStreamResponse> ContractKlineStream(ContractKlineStreamRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/came@<contractAddress>@<chainId>@kline_<interval>", ("contractAddress", request.ContractAddress), ("chainId", request.ChainId), ("interval", request.Interval), ("id", request.Id)), AlphaWebSocketStreamsJson.Default.ContractKlineStreamResponse, null, id: request.Id);
    }

    /// <summary>Full Depth Stream</summary>
    /// <remarks>Returns all available depth, including UI and API orders.</remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<FullDepthStreamResponse> FullDepthStream(FullDepthStreamRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@fulldepth@<interval>", ("symbol", request.Symbol), ("interval", request.Interval), ("id", request.Id)), AlphaWebSocketStreamsJson.Default.FullDepthStreamResponse, null, id: request.Id);
    }

    /// <summary>Kline Stream</summary>
    /// <remarks>Pushes kline updates for a symbol.</remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<KlineStreamResponse> KlineStream(KlineStreamRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@kline_<interval>", ("symbol", request.Symbol), ("interval", request.Interval), ("id", request.Id)), AlphaWebSocketStreamsJson.Default.KlineStreamResponse, null, id: request.Id);
    }

    /// <summary>Mini Ticker Stream</summary>
    /// <remarks>Pushes 24h rolling mini ticker statistics.</remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<MiniTickerStreamResponse> MiniTickerStream(MiniTickerStreamRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@miniTicker", ("symbol", request.Symbol), ("id", request.Id)), AlphaWebSocketStreamsJson.Default.MiniTickerStreamResponse, null, id: request.Id);
    }

    /// <summary>Partial Depth Stream</summary>
    /// <remarks>Pushes partial depth updates (UI orders only).</remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<PartialDepthStreamResponse> PartialDepthStream(PartialDepthStreamRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@depth<levels>@<interval>", ("symbol", request.Symbol), ("levels", request.Levels), ("interval", request.Interval), ("id", request.Id)), AlphaWebSocketStreamsJson.Default.PartialDepthStreamResponse, null, id: request.Id);
    }

    /// <summary>Ticker Stream</summary>
    /// <remarks>Pushes full 24h rolling ticker statistics.</remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<TickerStreamResponse> TickerStream(TickerStreamRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@ticker", ("symbol", request.Symbol), ("id", request.Id)), AlphaWebSocketStreamsJson.Default.TickerStreamResponse, null, id: request.Id);
    }

    /// <summary>Trade Stream</summary>
    /// <remarks>Pushes raw trade updates for a symbol.</remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<TradeStreamResponse> TradeStream(TradeStreamRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@trade", ("symbol", request.Symbol), ("id", request.Id)), AlphaWebSocketStreamsJson.Default.TradeStreamResponse, null, id: request.Id);
    }
}
