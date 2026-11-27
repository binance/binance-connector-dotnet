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

public sealed class AllBookTickersStreamRequest
{
    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

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
    /// <summary>Trading pair symbol.</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }

    /// <summary>WebSocket stream update speed</summary>
    public DiffBookDepthStreamsUpdateSpeed? UpdateSpeed { get; init; }
}

public sealed class IndividualSymbolBookTickerStreamsRequest
{
    /// <summary>The symbol parameter</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<PartialBookDepthStreamsLevels>))]
public readonly struct PartialBookDepthStreamsLevels : IExtensibleValue<PartialBookDepthStreamsLevels>, IEquatable<PartialBookDepthStreamsLevels>
{
    private readonly string? _value;

    public PartialBookDepthStreamsLevels(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PartialBookDepthStreamsLevels Levels5 { get; } = new("5");

    public static PartialBookDepthStreamsLevels Levels10 { get; } = new("10");

    public static PartialBookDepthStreamsLevels Levels20 { get; } = new("20");

    static PartialBookDepthStreamsLevels IExtensibleValue<PartialBookDepthStreamsLevels>.Create(string value) => new(value);

    public static bool operator ==(PartialBookDepthStreamsLevels left, PartialBookDepthStreamsLevels right) => left.Equals(right);

    public static bool operator !=(PartialBookDepthStreamsLevels left, PartialBookDepthStreamsLevels right) => !left.Equals(right);

    public static implicit operator PartialBookDepthStreamsLevels(string value) => new(value);

    public static PartialBookDepthStreamsLevels FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PartialBookDepthStreamsLevels other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PartialBookDepthStreamsLevels other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

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

    /// <summary>The levels parameter</summary>
    public required PartialBookDepthStreamsLevels Levels { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }

    /// <summary>WebSocket stream update speed</summary>
    public PartialBookDepthStreamsUpdateSpeed? UpdateSpeed { get; init; }
}

public sealed class RpiDiffBookDepthStreamsRequest
{
    /// <summary>The symbol parameter</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed partial class DerivativesTradingUsdsFuturesWebSocketStreamsConnection
{

    /// <summary>All Book Tickers Stream</summary>
    /// <remarks>
    /// <para>Pushes any update to the best bid or ask's price or quantity in real-time for all symbols.</para>
    /// <para>
    /// &gt; After CM migration, this stream pushes the merged UM + CM universe (subscribable on both
    /// fstream and dstream); each payload is appended with a new st field (1 = UM, 2 = CM) and a new ps
    /// field (pair symbol).
    /// </para>
    /// <para>Update Speed: 5s</para>
    /// <para>Response Notes:</para>
    /// <para>- Retail Price Improvement(RPI) orders are not visible and excluded in the response message.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<AllBookTickersStreamResponse> AllBookTickersStream(AllBookTickersStreamRequest? request = null)
    {
        request ??= new();
        return _client.Subscribe(StreamName.Build("/!bookTicker", ("id", request.Id)), DerivativesTradingUsdsFuturesWebSocketStreamsJson.Default.AllBookTickersStreamResponse, "public", id: request.Id);
    }

    /// <summary>Diff. Book Depth Streams</summary>
    /// <remarks>
    /// <para>Bids and asks, pushed every 250 milliseconds, 500 milliseconds, 100 milliseconds (if existing).</para>
    /// <para>
    /// &gt; After CM migration, the payload is appended with a new st field (1 = UM, 2 = CM) and a new ps
    /// field (pair symbol).
    /// </para>
    /// <para>Update Speed: 250ms, 500ms, 100ms</para>
    /// <para>Response Notes:</para>
    /// <para>- Retail Price Improvement(RPI) orders are not visible and excluded in the response message.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<DiffBookDepthStreamsResponse> DiffBookDepthStreams(DiffBookDepthStreamsRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@depth@<updateSpeed>", ("symbol", request.Symbol), ("id", request.Id), ("updateSpeed", request.UpdateSpeed)), DerivativesTradingUsdsFuturesWebSocketStreamsJson.Default.DiffBookDepthStreamsResponse, "public", id: request.Id);
    }

    /// <summary>Individual Symbol Book Ticker Streams</summary>
    /// <remarks>
    /// <para>Pushes any update to the best bid or ask's price or quantity in real-time for a specified symbol.</para>
    /// <para>&gt; After CM migration, the payload is appended with a new st field (1 = UM, 2 = CM).</para>
    /// <para>Update Speed: Real-time</para>
    /// <para>
    /// Response Notes: Retail Price Improvement (RPI) orders are not visible and excluded in the response
    /// message.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<IndividualSymbolBookTickerStreamsResponse> IndividualSymbolBookTickerStreams(IndividualSymbolBookTickerStreamsRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@bookTicker", ("symbol", request.Symbol), ("id", request.Id)), DerivativesTradingUsdsFuturesWebSocketStreamsJson.Default.IndividualSymbolBookTickerStreamsResponse, "public", id: request.Id);
    }

    /// <summary>Partial Book Depth Streams</summary>
    /// <remarks>
    /// <para>Top &lt;levels&gt; bids and asks</para>
    /// <para>
    /// &gt; After CM migration, the payload is appended with a new st field (1 = UM, 2 = CM) and a new ps
    /// field (pair symbol).
    /// </para>
    /// <para>Update Speed: 250ms or 500ms or 100ms</para>
    /// <para>
    /// Response Notes: Retail Price Improvement (RPI) orders are not visible and excluded in the response
    /// message.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<PartialBookDepthStreamsResponse> PartialBookDepthStreams(PartialBookDepthStreamsRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@depth<levels>@<updateSpeed>", ("symbol", request.Symbol), ("levels", request.Levels), ("id", request.Id), ("updateSpeed", request.UpdateSpeed)), DerivativesTradingUsdsFuturesWebSocketStreamsJson.Default.PartialBookDepthStreamsResponse, "public", id: request.Id);
    }

    /// <summary>RPI Diff. Book Depth Streams</summary>
    /// <remarks>
    /// <para>Bids and asks including RPI orders, pushed every 500 milliseconds</para>
    /// <para>
    /// &gt; After CM migration, the payload is appended with a new st field (1 = UM, 2 = CM) and a new ps
    /// field (pair symbol).
    /// </para>
    /// <para>Update Speed: 500ms</para>
    /// <para>Response Notes:</para>
    /// <para>
    /// - RPI(Retail Price Improvement) orders are included and aggreated in the response message. When the
    /// quantity of a price level to be updated is equal to 0, it means either all quotations for this price
    /// have been filled/canceled, or the quantity of crossed RPI orders for this price are hidden
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<RpiDiffBookDepthStreamsResponse> RpiDiffBookDepthStreams(RpiDiffBookDepthStreamsRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@rpiDepth@500ms", ("symbol", request.Symbol), ("id", request.Id)), DerivativesTradingUsdsFuturesWebSocketStreamsJson.Default.RpiDiffBookDepthStreamsResponse, "public", id: request.Id);
    }
}
