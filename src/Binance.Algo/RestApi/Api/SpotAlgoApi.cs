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

namespace Binance.Algo.RestApi;

public sealed class CancelAlgoOrderSpotAlgoRequest
{
    public long? AlgoId { get; init; }

    public string? ClientAlgoId { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed class QueryCurrentAlgoOpenOrdersSpotAlgoRequest
{
    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<QueryHistoricalAlgoOrdersSpotAlgoSide>))]
public readonly struct QueryHistoricalAlgoOrdersSpotAlgoSide : IExtensibleValue<QueryHistoricalAlgoOrdersSpotAlgoSide>, IEquatable<QueryHistoricalAlgoOrdersSpotAlgoSide>
{
    private readonly string? _value;

    public QueryHistoricalAlgoOrdersSpotAlgoSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static QueryHistoricalAlgoOrdersSpotAlgoSide Buy { get; } = new("BUY");

    public static QueryHistoricalAlgoOrdersSpotAlgoSide Sell { get; } = new("SELL");

    static QueryHistoricalAlgoOrdersSpotAlgoSide IExtensibleValue<QueryHistoricalAlgoOrdersSpotAlgoSide>.Create(string value) => new(value);

    public static bool operator ==(QueryHistoricalAlgoOrdersSpotAlgoSide left, QueryHistoricalAlgoOrdersSpotAlgoSide right) => left.Equals(right);

    public static bool operator !=(QueryHistoricalAlgoOrdersSpotAlgoSide left, QueryHistoricalAlgoOrdersSpotAlgoSide right) => !left.Equals(right);

    public static implicit operator QueryHistoricalAlgoOrdersSpotAlgoSide(string value) => new(value);

    public static QueryHistoricalAlgoOrdersSpotAlgoSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is QueryHistoricalAlgoOrdersSpotAlgoSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(QueryHistoricalAlgoOrdersSpotAlgoSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class QueryHistoricalAlgoOrdersSpotAlgoRequest
{
    /// <summary>Trading symbol</summary>
    public string? Symbol { get; init; }

    public QueryHistoricalAlgoOrdersSpotAlgoSide? Side { get; init; }

    /// <summary>in milliseconds eg.1641522717552</summary>
    public long? StartTime { get; init; }

    /// <summary>in milliseconds eg.1641522526562</summary>
    public long? EndTime { get; init; }

    /// <summary>Page number</summary>
    public long? Page { get; init; }

    /// <summary>Records per page</summary>
    public long? PageSize { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed class QuerySubOrdersSpotAlgoRequest
{
    /// <summary>eg. 14511</summary>
    public required long AlgoId { get; init; }

    /// <summary>Page number</summary>
    public long? Page { get; init; }

    /// <summary>Records per page</summary>
    public long? PageSize { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<TimeWeightedAveragePriceSpotAlgoSide>))]
public readonly struct TimeWeightedAveragePriceSpotAlgoSide : IExtensibleValue<TimeWeightedAveragePriceSpotAlgoSide>, IEquatable<TimeWeightedAveragePriceSpotAlgoSide>
{
    private readonly string? _value;

    public TimeWeightedAveragePriceSpotAlgoSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static TimeWeightedAveragePriceSpotAlgoSide Buy { get; } = new("BUY");

    public static TimeWeightedAveragePriceSpotAlgoSide Sell { get; } = new("SELL");

    static TimeWeightedAveragePriceSpotAlgoSide IExtensibleValue<TimeWeightedAveragePriceSpotAlgoSide>.Create(string value) => new(value);

    public static bool operator ==(TimeWeightedAveragePriceSpotAlgoSide left, TimeWeightedAveragePriceSpotAlgoSide right) => left.Equals(right);

    public static bool operator !=(TimeWeightedAveragePriceSpotAlgoSide left, TimeWeightedAveragePriceSpotAlgoSide right) => !left.Equals(right);

    public static implicit operator TimeWeightedAveragePriceSpotAlgoSide(string value) => new(value);

    public static TimeWeightedAveragePriceSpotAlgoSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TimeWeightedAveragePriceSpotAlgoSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(TimeWeightedAveragePriceSpotAlgoSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class TimeWeightedAveragePriceSpotAlgoRequest
{
    /// <summary>Trading symbol eg. BTCUSDT</summary>
    public required string Symbol { get; init; }

    /// <summary>Trading side ( BUY or SELL )</summary>
    public required TimeWeightedAveragePriceSpotAlgoSide Side { get; init; }

    /// <summary>
    /// Quantity of base asset; Maximum notional per order is 200k, 2mm or 10mm, depending on symbol. Please
    /// reduce your size if you order is above the maximum notional per order.
    /// </summary>
    public required decimal Quantity { get; init; }

    /// <summary>Duration for TWAP orders in seconds</summary>
    public required long Duration { get; init; }

    /// <summary>
    /// A unique id among Algo orders (length should be 32 characters)， If it is not sent, we will give
    /// default value
    /// </summary>
    public string? ClientAlgoId { get; init; }

    /// <summary>
    /// Limit price of the order; If it is not sent, will place order by market price by default
    /// </summary>
    public decimal? LimitPrice { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<VolumeParticipationSide>))]
public readonly struct VolumeParticipationSide : IExtensibleValue<VolumeParticipationSide>, IEquatable<VolumeParticipationSide>
{
    private readonly string? _value;

    public VolumeParticipationSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static VolumeParticipationSide Buy { get; } = new("BUY");

    public static VolumeParticipationSide Sell { get; } = new("SELL");

    static VolumeParticipationSide IExtensibleValue<VolumeParticipationSide>.Create(string value) => new(value);

    public static bool operator ==(VolumeParticipationSide left, VolumeParticipationSide right) => left.Equals(right);

    public static bool operator !=(VolumeParticipationSide left, VolumeParticipationSide right) => !left.Equals(right);

    public static implicit operator VolumeParticipationSide(string value) => new(value);

    public static VolumeParticipationSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is VolumeParticipationSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(VolumeParticipationSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<VolumeParticipationUrgency>))]
public readonly struct VolumeParticipationUrgency : IExtensibleValue<VolumeParticipationUrgency>, IEquatable<VolumeParticipationUrgency>
{
    private readonly string? _value;

    public VolumeParticipationUrgency(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static VolumeParticipationUrgency Low { get; } = new("LOW");

    public static VolumeParticipationUrgency Medium { get; } = new("MEDIUM");

    public static VolumeParticipationUrgency High { get; } = new("HIGH");

    static VolumeParticipationUrgency IExtensibleValue<VolumeParticipationUrgency>.Create(string value) => new(value);

    public static bool operator ==(VolumeParticipationUrgency left, VolumeParticipationUrgency right) => left.Equals(right);

    public static bool operator !=(VolumeParticipationUrgency left, VolumeParticipationUrgency right) => !left.Equals(right);

    public static implicit operator VolumeParticipationUrgency(string value) => new(value);

    public static VolumeParticipationUrgency FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is VolumeParticipationUrgency other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(VolumeParticipationUrgency other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class VolumeParticipationRequest
{
    /// <summary>Trading symbol eg. BTCUSDT</summary>
    public required string Symbol { get; init; }

    /// <summary>Trading side ( BUY or SELL )</summary>
    public required VolumeParticipationSide Side { get; init; }

    /// <summary>
    /// Total order quantity in base asset; The notional must be at least the equivalent of 1,000 USDT, and
    /// the maximum notional per order is 200k, 2mm or 10mm, depending on symbol. Please reduce your size if
    /// your order is above the maximum notional per order.
    /// </summary>
    public required decimal Quantity { get; init; }

    /// <summary>Represent the relative speed of the current execution; ENUM: LOW, MEDIUM, HIGH</summary>
    public required VolumeParticipationUrgency Urgency { get; init; }

    /// <summary>
    /// A unique id among Algo orders (length should be 32 characters). If it is not sent, we will give
    /// default value. Must be unique across all open Algo orders.
    /// </summary>
    public string? ClientAlgoId { get; init; }

    /// <summary>
    /// Max allowed duration in seconds (minimum 300, maximum 86400). If it is not sent, 86400 is used and
    /// the order runs until fully filled or cancelled.
    /// </summary>
    public long? VpTimeLimit { get; init; }

    /// <summary>Cannot be greater than 60000</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class AlgoRestApi
{

    /// <summary>Cancel Spot Algo Order (TRADE)</summary>
    /// <remarks>
    /// <para>Cancel an open TWAP or VP algo order</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Either algoId or clientAlgoId must be sent.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CancelAlgoOrderSpotAlgoResponse>> CancelAlgoOrderSpotAlgoAsync(CancelAlgoOrderSpotAlgoRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/sapi/v1/algo/spot/order", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("algoId", request.AlgoId);
        r.Query("clientAlgoId", request.ClientAlgoId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, AlgoRestApiJson.Default.CancelAlgoOrderSpotAlgoResponse, cancellationToken);
    }

    /// <summary>Query Current Spot Algo Open Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get all open Spot TWAP and VP algo orders</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryCurrentAlgoOpenOrdersSpotAlgoResponse>> QueryCurrentAlgoOpenOrdersSpotAlgoAsync(QueryCurrentAlgoOpenOrdersSpotAlgoRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/algo/spot/openOrders", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, AlgoRestApiJson.Default.QueryCurrentAlgoOpenOrdersSpotAlgoResponse, cancellationToken);
    }

    /// <summary>Query Historical Spot Algo Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get all historical Spot TWAP and VP algo orders</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryHistoricalAlgoOrdersSpotAlgoResponse>> QueryHistoricalAlgoOrdersSpotAlgoAsync(QueryHistoricalAlgoOrdersSpotAlgoRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/algo/spot/historicalOrders", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("side", request.Side);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("page", request.Page);
        r.Query("pageSize", request.PageSize);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, AlgoRestApiJson.Default.QueryHistoricalAlgoOrdersSpotAlgoResponse, cancellationToken);
    }

    /// <summary>Query Spot Sub Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get respective sub orders for a specified algoId</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QuerySubOrdersSpotAlgoResponse>> QuerySubOrdersSpotAlgoAsync(QuerySubOrdersSpotAlgoRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/algo/spot/subOrders", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QuerySubOrdersSpotAlgoResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("algoId", request.AlgoId);
        r.Query("page", request.Page);
        r.Query("pageSize", request.PageSize);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, AlgoRestApiJson.Default.QuerySubOrdersSpotAlgoResponse, cancellationToken);
    }

    /// <summary>Time-Weighted Spot Average Price(Twap) New Order (TRADE)</summary>
    /// <remarks>
    /// <para>Place a new spot TWAP order with Algo service.</para>
    /// <para>Weight(UID): 3000</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Total Algo open orders max allowed: 20 orders.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<TimeWeightedAveragePriceSpotAlgoResponse>> TimeWeightedAveragePriceSpotAlgoAsync(TimeWeightedAveragePriceSpotAlgoRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/algo/spot/newOrderTwap", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<TimeWeightedAveragePriceSpotAlgoResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("side", request.Side);
        r.Query("quantity", request.Quantity);
        r.Query("duration", request.Duration);
        r.Query("clientAlgoId", request.ClientAlgoId);
        r.Query("limitPrice", request.LimitPrice);
        return _client.SendAsync(r, AlgoRestApiJson.Default.TimeWeightedAveragePriceSpotAlgoResponse, cancellationToken);
    }

    /// <summary>Volume Participation (VP) New Order (TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Place a new spot VP (Volume Participation) order with Algo service. A VP order automatically slices
    /// the total quantity over time, targeting a percentage of the market volume.
    /// </para>
    /// <para>Weight(UID): 3000</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>
    /// - VP orders do not accept price or timeInForce; pricing is determined algorithmically based on
    /// market volume.
    /// </para>
    /// <para>- urgency controls the participation rate: LOW = passive, MEDIUM = neutral, HIGH = aggressive.</para>
    /// <para>
    /// - Receiving "success": true does not guarantee execution; use the query order endpoints (GET
    /// /sapi/v1/algo/spot/openOrders or GET /sapi/v1/algo/spot/historicalOrders) to check the final status.
    /// </para>
    /// <para>- You need to enable the Spot Trading permission for the API key requesting this endpoint.</para>
    /// <para>- Base URL: https://api.binance.com</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<VolumeParticipationResponse>> VolumeParticipationAsync(VolumeParticipationRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/algo/spot/newOrderVp", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<VolumeParticipationResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("side", request.Side);
        r.Query("quantity", request.Quantity);
        r.Query("urgency", request.Urgency);
        r.Query("clientAlgoId", request.ClientAlgoId);
        r.Query("vpTimeLimit", request.VpTimeLimit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, AlgoRestApiJson.Default.VolumeParticipationResponse, cancellationToken);
    }
}
