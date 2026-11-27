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

namespace Binance.DerivativesTradingOptions.WebSocketStreams;

public sealed class IndexPriceStreamsRequest
{
    /// <summary>Unique WebSocket request ID.</summary>
    public long? Id { get; init; }
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

    public static KlineCandlestickStreamsInterval Interval12h { get; } = new("12h");

    public static KlineCandlestickStreamsInterval Interval1d { get; } = new("1d");

    public static KlineCandlestickStreamsInterval Interval3d { get; } = new("3d");

    public static KlineCandlestickStreamsInterval Interval1w { get; } = new("1w");

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
    public long? Id { get; init; }
}

public sealed class NewSymbolInfoRequest
{
    /// <summary>Unique WebSocket request ID.</summary>
    public long? Id { get; init; }
}

public sealed class OpenInterestRequest
{
    /// <summary>The underlying parameter</summary>
    public required string Underlying { get; init; }

    /// <summary>The expirationDate parameter</summary>
    public required string ExpirationDate { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public long? Id { get; init; }
}

public sealed class OptionMarkPriceRequest
{
    /// <summary>The underlying parameter</summary>
    public required string Underlying { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public long? Id { get; init; }
}

public sealed partial class DerivativesTradingOptionsWebSocketStreamsConnection
{

    /// <summary>Index Price Streams</summary>
    /// <remarks>
    /// <para>Underlying(e.g ETHUSDT) index stream.</para>
    /// <para>Update Speed: 1000ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<List<IndexPriceStreamsResponseInner>> IndexPriceStreams(IndexPriceStreamsRequest? request = null)
    {
        request ??= new();
        return _client.Subscribe(StreamName.Build("/!index@arr", ("id", request.Id)), DerivativesTradingOptionsWebSocketStreamsJson.Default.ListIndexPriceStreamsResponseInner, "market", id: request.Id);
    }

    /// <summary>Kline/Candlestick Streams</summary>
    /// <remarks>
    /// <para>
    /// The Kline/Candlestick Stream push updates to the current klines/candlestick every 1000 milliseconds
    /// (if existing).
    /// </para>
    /// <para>Update Speed: 1000ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<KlineCandlestickStreamsResponse> KlineCandlestickStreams(KlineCandlestickStreamsRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@kline_<interval>", ("symbol", request.Symbol), ("interval", request.Interval), ("id", request.Id)), DerivativesTradingOptionsWebSocketStreamsJson.Default.KlineCandlestickStreamsResponse, "market", id: request.Id);
    }

    /// <summary>New Symbol Info</summary>
    /// <remarks>
    /// <para>New symbol listing stream.</para>
    /// <para>Update Speed: 50ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<NewSymbolInfoResponse> NewSymbolInfo(NewSymbolInfoRequest? request = null)
    {
        request ??= new();
        return _client.Subscribe(StreamName.Build("/!optionSymbol", ("id", request.Id)), DerivativesTradingOptionsWebSocketStreamsJson.Default.NewSymbolInfoResponse, "market", id: request.Id);
    }

    /// <summary>Open Interest</summary>
    /// <remarks>
    /// <para>
    /// Option open interest for specific underlying asset on specific expiration date.
    /// E.g.ethusdt@optionOpenInterest@221125
    /// </para>
    /// <para>Update Speed: 60s</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<List<OpenInterestResponseInner>> OpenInterest(OpenInterestRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<underlying>@optionOpenInterest@<expirationDate>", ("underlying", request.Underlying), ("expirationDate", request.ExpirationDate), ("id", request.Id)), DerivativesTradingOptionsWebSocketStreamsJson.Default.ListOpenInterestResponseInner, "market", id: request.Id);
    }

    /// <summary>Option Mark Price</summary>
    /// <remarks>
    /// <para>The mark price for all option symbols on specific underlying asset. E.g.btcusdt@optionMarkPrice</para>
    /// <para>Update Speed: 1000ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<List<OptionMarkPriceResponseInner>> OptionMarkPrice(OptionMarkPriceRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<underlying>@optionMarkPrice", ("underlying", request.Underlying), ("id", request.Id)), DerivativesTradingOptionsWebSocketStreamsJson.Default.ListOptionMarkPriceResponseInner, "market", id: request.Id);
    }
}
