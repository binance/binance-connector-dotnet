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

[JsonConverter(typeof(ExtensibleValueConverter<DiffBookDepthStreamsUpdateSpeed>))]
public readonly struct DiffBookDepthStreamsUpdateSpeed : IExtensibleValue<DiffBookDepthStreamsUpdateSpeed>, IEquatable<DiffBookDepthStreamsUpdateSpeed>
{
    private readonly string? _value;

    public DiffBookDepthStreamsUpdateSpeed(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static DiffBookDepthStreamsUpdateSpeed UpdateSpeed100ms { get; } = new("100ms");

    public static DiffBookDepthStreamsUpdateSpeed UpdateSpeed500ms { get; } = new("500ms");

    static DiffBookDepthStreamsUpdateSpeed IExtensibleValue<DiffBookDepthStreamsUpdateSpeed>.Create(string value) => new(value);

    public static bool operator ==(DiffBookDepthStreamsUpdateSpeed left, DiffBookDepthStreamsUpdateSpeed right) => left.Equals(right);

    public static bool operator !=(DiffBookDepthStreamsUpdateSpeed left, DiffBookDepthStreamsUpdateSpeed right) => !left.Equals(right);

    public static implicit operator DiffBookDepthStreamsUpdateSpeed(string value) => new(value);

    public static DiffBookDepthStreamsUpdateSpeed FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is DiffBookDepthStreamsUpdateSpeed other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(DiffBookDepthStreamsUpdateSpeed other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class DiffBookDepthStreamsRequest
{
    /// <summary>The symbol parameter</summary>
    public required string Symbol { get; init; }

    /// <summary>WebSocket stream update speed</summary>
    public required DiffBookDepthStreamsUpdateSpeed UpdateSpeed { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public long? Id { get; init; }
}

public sealed class Hour24TickerRequest
{
    /// <summary>The symbol parameter</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public long? Id { get; init; }

    /// <summary>The expiration date parameter</summary>
    public string? ExpirationDate { get; init; }
}

public sealed class IndividualSymbolBookTickerStreamsRequest
{
    /// <summary>The symbol parameter</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public long? Id { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<PartialBookDepthStreamsLevel>))]
public readonly struct PartialBookDepthStreamsLevel : IExtensibleValue<PartialBookDepthStreamsLevel>, IEquatable<PartialBookDepthStreamsLevel>
{
    private readonly string? _value;

    public PartialBookDepthStreamsLevel(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PartialBookDepthStreamsLevel Level5 { get; } = new("5");

    public static PartialBookDepthStreamsLevel Level10 { get; } = new("10");

    public static PartialBookDepthStreamsLevel Level20 { get; } = new("20");

    static PartialBookDepthStreamsLevel IExtensibleValue<PartialBookDepthStreamsLevel>.Create(string value) => new(value);

    public static bool operator ==(PartialBookDepthStreamsLevel left, PartialBookDepthStreamsLevel right) => left.Equals(right);

    public static bool operator !=(PartialBookDepthStreamsLevel left, PartialBookDepthStreamsLevel right) => !left.Equals(right);

    public static implicit operator PartialBookDepthStreamsLevel(string value) => new(value);

    public static PartialBookDepthStreamsLevel FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PartialBookDepthStreamsLevel other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PartialBookDepthStreamsLevel other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<PartialBookDepthStreamsUpdateSpeed>))]
public readonly struct PartialBookDepthStreamsUpdateSpeed : IExtensibleValue<PartialBookDepthStreamsUpdateSpeed>, IEquatable<PartialBookDepthStreamsUpdateSpeed>
{
    private readonly string? _value;

    public PartialBookDepthStreamsUpdateSpeed(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PartialBookDepthStreamsUpdateSpeed UpdateSpeed100ms { get; } = new("100ms");

    public static PartialBookDepthStreamsUpdateSpeed UpdateSpeed500ms { get; } = new("500ms");

    static PartialBookDepthStreamsUpdateSpeed IExtensibleValue<PartialBookDepthStreamsUpdateSpeed>.Create(string value) => new(value);

    public static bool operator ==(PartialBookDepthStreamsUpdateSpeed left, PartialBookDepthStreamsUpdateSpeed right) => left.Equals(right);

    public static bool operator !=(PartialBookDepthStreamsUpdateSpeed left, PartialBookDepthStreamsUpdateSpeed right) => !left.Equals(right);

    public static implicit operator PartialBookDepthStreamsUpdateSpeed(string value) => new(value);

    public static PartialBookDepthStreamsUpdateSpeed FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PartialBookDepthStreamsUpdateSpeed other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PartialBookDepthStreamsUpdateSpeed other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class PartialBookDepthStreamsRequest
{
    /// <summary>The symbol parameter</summary>
    public required string Symbol { get; init; }

    /// <summary>The level parameter</summary>
    public required PartialBookDepthStreamsLevel Level { get; init; }

    /// <summary>WebSocket stream update speed</summary>
    public required PartialBookDepthStreamsUpdateSpeed UpdateSpeed { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public long? Id { get; init; }
}

public sealed class TradeStreamsRequest
{
    /// <summary>The symbol parameter</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public long? Id { get; init; }
}

public sealed partial class DerivativesTradingOptionsWebSocketStreamsConnection
{

    /// <summary>Diff Book Depth Streams</summary>
    /// <remarks>
    /// <para>Bids and asks, pushed every 500 milliseconds, 100 milliseconds (if existing)</para>
    /// <para>Update Speed: 100ms or 500ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<DiffBookDepthStreamsResponse> DiffBookDepthStreams(DiffBookDepthStreamsRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@depth@<updateSpeed>", ("symbol", request.Symbol), ("updateSpeed", request.UpdateSpeed), ("id", request.Id)), DerivativesTradingOptionsWebSocketStreamsJson.Default.DiffBookDepthStreamsResponse, "public", id: request.Id);
    }

    /// <summary>24-hour TICKER</summary>
    /// <remarks>
    /// <para>24hr ticker info for all symbols. Only symbols whose ticker info changed will be sent.</para>
    /// <para>Update Speed: 1000ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<Hour24TickerResponse> Hour24Ticker(Hour24TickerRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@optionTicker<expirationDate>", ("symbol", request.Symbol), ("id", request.Id), ("expirationDate", request.ExpirationDate)), DerivativesTradingOptionsWebSocketStreamsJson.Default.Hour24TickerResponse, "public", id: request.Id);
    }

    /// <summary>Individual Symbol Book Ticker Streams</summary>
    /// <remarks>
    /// <para>Pushes any update to the best bid or ask's price or quantity in real-time for a specified symbol.</para>
    /// <para>Update Speed: Real-Time</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<IndividualSymbolBookTickerStreamsResponse> IndividualSymbolBookTickerStreams(IndividualSymbolBookTickerStreamsRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@bookTicker", ("symbol", request.Symbol), ("id", request.Id)), DerivativesTradingOptionsWebSocketStreamsJson.Default.IndividualSymbolBookTickerStreamsResponse, "public", id: request.Id);
    }

    /// <summary>Partial Book Depth Streams</summary>
    /// <remarks>
    /// <para>Top &lt;levels&gt; bids and asks. Valid &lt;levels&gt; are 5, 10, 20.</para>
    /// <para>Update Speed: 100ms or 500ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<PartialBookDepthStreamsResponse> PartialBookDepthStreams(PartialBookDepthStreamsRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@depth<level>@<updateSpeed>", ("symbol", request.Symbol), ("level", request.Level), ("updateSpeed", request.UpdateSpeed), ("id", request.Id)), DerivativesTradingOptionsWebSocketStreamsJson.Default.PartialBookDepthStreamsResponse, "public", id: request.Id);
    }

    /// <summary>Trade Streams</summary>
    /// <remarks>
    /// <para>
    /// The Trade Streams push raw trade information for specific symbol or underlying asset.
    /// E.g.btcusdt@optionTrade
    /// </para>
    /// <para>Update Speed: 50ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<TradeStreamsResponse> TradeStreams(TradeStreamsRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@optionTrade", ("symbol", request.Symbol), ("id", request.Id)), DerivativesTradingOptionsWebSocketStreamsJson.Default.TradeStreamsResponse, "public", id: request.Id);
    }
}
