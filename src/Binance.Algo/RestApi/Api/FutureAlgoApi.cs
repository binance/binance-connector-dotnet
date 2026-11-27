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

public sealed class CancelAlgoOrderFutureAlgoRequest
{
    /// <summary>eg. 14511</summary>
    public long? AlgoId { get; init; }

    /// <summary>eg. "65ce1630101a480b85915d7e11fd5078"</summary>
    public string? ClientAlgoId { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed class QueryCurrentAlgoOpenOrdersFutureAlgoRequest
{
    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<QueryHistoricalAlgoOrdersFutureAlgoSide>))]
public readonly struct QueryHistoricalAlgoOrdersFutureAlgoSide : IExtensibleValue<QueryHistoricalAlgoOrdersFutureAlgoSide>, IEquatable<QueryHistoricalAlgoOrdersFutureAlgoSide>
{
    private readonly string? _value;

    public QueryHistoricalAlgoOrdersFutureAlgoSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static QueryHistoricalAlgoOrdersFutureAlgoSide Buy { get; } = new("BUY");

    public static QueryHistoricalAlgoOrdersFutureAlgoSide Sell { get; } = new("SELL");

    static QueryHistoricalAlgoOrdersFutureAlgoSide IExtensibleValue<QueryHistoricalAlgoOrdersFutureAlgoSide>.Create(string value) => new(value);

    public static bool operator ==(QueryHistoricalAlgoOrdersFutureAlgoSide left, QueryHistoricalAlgoOrdersFutureAlgoSide right) => left.Equals(right);

    public static bool operator !=(QueryHistoricalAlgoOrdersFutureAlgoSide left, QueryHistoricalAlgoOrdersFutureAlgoSide right) => !left.Equals(right);

    public static implicit operator QueryHistoricalAlgoOrdersFutureAlgoSide(string value) => new(value);

    public static QueryHistoricalAlgoOrdersFutureAlgoSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is QueryHistoricalAlgoOrdersFutureAlgoSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(QueryHistoricalAlgoOrdersFutureAlgoSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class QueryHistoricalAlgoOrdersFutureAlgoRequest
{
    /// <summary>Trading symbol eg. BTCUSDT</summary>
    public string? Symbol { get; init; }

    /// <summary>BUY or SELL</summary>
    public QueryHistoricalAlgoOrdersFutureAlgoSide? Side { get; init; }

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

public sealed class QuerySubOrdersFutureAlgoRequest
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

[JsonConverter(typeof(ExtensibleValueConverter<TimeWeightedAveragePriceFutureAlgoSide>))]
public readonly struct TimeWeightedAveragePriceFutureAlgoSide : IExtensibleValue<TimeWeightedAveragePriceFutureAlgoSide>, IEquatable<TimeWeightedAveragePriceFutureAlgoSide>
{
    private readonly string? _value;

    public TimeWeightedAveragePriceFutureAlgoSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static TimeWeightedAveragePriceFutureAlgoSide Buy { get; } = new("BUY");

    public static TimeWeightedAveragePriceFutureAlgoSide Sell { get; } = new("SELL");

    static TimeWeightedAveragePriceFutureAlgoSide IExtensibleValue<TimeWeightedAveragePriceFutureAlgoSide>.Create(string value) => new(value);

    public static bool operator ==(TimeWeightedAveragePriceFutureAlgoSide left, TimeWeightedAveragePriceFutureAlgoSide right) => left.Equals(right);

    public static bool operator !=(TimeWeightedAveragePriceFutureAlgoSide left, TimeWeightedAveragePriceFutureAlgoSide right) => !left.Equals(right);

    public static implicit operator TimeWeightedAveragePriceFutureAlgoSide(string value) => new(value);

    public static TimeWeightedAveragePriceFutureAlgoSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TimeWeightedAveragePriceFutureAlgoSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(TimeWeightedAveragePriceFutureAlgoSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<TimeWeightedAveragePriceFutureAlgoPositionSide>))]
public readonly struct TimeWeightedAveragePriceFutureAlgoPositionSide : IExtensibleValue<TimeWeightedAveragePriceFutureAlgoPositionSide>, IEquatable<TimeWeightedAveragePriceFutureAlgoPositionSide>
{
    private readonly string? _value;

    public TimeWeightedAveragePriceFutureAlgoPositionSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static TimeWeightedAveragePriceFutureAlgoPositionSide Both { get; } = new("BOTH");

    public static TimeWeightedAveragePriceFutureAlgoPositionSide Long { get; } = new("LONG");

    public static TimeWeightedAveragePriceFutureAlgoPositionSide Short { get; } = new("SHORT");

    static TimeWeightedAveragePriceFutureAlgoPositionSide IExtensibleValue<TimeWeightedAveragePriceFutureAlgoPositionSide>.Create(string value) => new(value);

    public static bool operator ==(TimeWeightedAveragePriceFutureAlgoPositionSide left, TimeWeightedAveragePriceFutureAlgoPositionSide right) => left.Equals(right);

    public static bool operator !=(TimeWeightedAveragePriceFutureAlgoPositionSide left, TimeWeightedAveragePriceFutureAlgoPositionSide right) => !left.Equals(right);

    public static implicit operator TimeWeightedAveragePriceFutureAlgoPositionSide(string value) => new(value);

    public static TimeWeightedAveragePriceFutureAlgoPositionSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TimeWeightedAveragePriceFutureAlgoPositionSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(TimeWeightedAveragePriceFutureAlgoPositionSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class TimeWeightedAveragePriceFutureAlgoRequest
{
    /// <summary>Trading symbol eg. BTCUSDT</summary>
    public required string Symbol { get; init; }

    /// <summary>Trading side ( BUY or SELL )</summary>
    public required TimeWeightedAveragePriceFutureAlgoSide Side { get; init; }

    /// <summary>
    /// Quantity of base asset; The notional (quantity * mark price(base asset)) must be more than the
    /// equivalent of 1,000 USDT, and the maximum notional varies by symbol: up to 50,000,000 USDT for
    /// BTCUSDT perpetual, up to 25,000,000 USDT for ETHUSDT perpetual, and up to 5,000,000 USDT for other
    /// symbols
    /// </summary>
    public required decimal Quantity { get; init; }

    /// <summary>Duration for TWAP orders in seconds</summary>
    public required long Duration { get; init; }

    /// <summary>
    /// Default BOTH for One-way Mode ; LONG or SHORT for Hedge Mode. It must be sent in Hedge Mode.
    /// </summary>
    public TimeWeightedAveragePriceFutureAlgoPositionSide? PositionSide { get; init; }

    /// <summary>
    /// A unique id among Algo orders (length should be 32 characters)， If it is not sent, we will give
    /// default value
    /// </summary>
    public string? ClientAlgoId { get; init; }

    /// <summary>
    /// "true" or "false". Default "false"; Cannot be sent in Hedge Mode; Cannot be sent when you open a
    /// position
    /// </summary>
    public bool? ReduceOnly { get; init; }

    /// <summary>
    /// Limit price of the order; If it is not sent, will place order by market price by default
    /// </summary>
    public decimal? LimitPrice { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<VolumeParticipationFutureAlgoSide>))]
public readonly struct VolumeParticipationFutureAlgoSide : IExtensibleValue<VolumeParticipationFutureAlgoSide>, IEquatable<VolumeParticipationFutureAlgoSide>
{
    private readonly string? _value;

    public VolumeParticipationFutureAlgoSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static VolumeParticipationFutureAlgoSide Buy { get; } = new("BUY");

    public static VolumeParticipationFutureAlgoSide Sell { get; } = new("SELL");

    static VolumeParticipationFutureAlgoSide IExtensibleValue<VolumeParticipationFutureAlgoSide>.Create(string value) => new(value);

    public static bool operator ==(VolumeParticipationFutureAlgoSide left, VolumeParticipationFutureAlgoSide right) => left.Equals(right);

    public static bool operator !=(VolumeParticipationFutureAlgoSide left, VolumeParticipationFutureAlgoSide right) => !left.Equals(right);

    public static implicit operator VolumeParticipationFutureAlgoSide(string value) => new(value);

    public static VolumeParticipationFutureAlgoSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is VolumeParticipationFutureAlgoSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(VolumeParticipationFutureAlgoSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<VolumeParticipationFutureAlgoUrgency>))]
public readonly struct VolumeParticipationFutureAlgoUrgency : IExtensibleValue<VolumeParticipationFutureAlgoUrgency>, IEquatable<VolumeParticipationFutureAlgoUrgency>
{
    private readonly string? _value;

    public VolumeParticipationFutureAlgoUrgency(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static VolumeParticipationFutureAlgoUrgency Low { get; } = new("LOW");

    public static VolumeParticipationFutureAlgoUrgency Medium { get; } = new("MEDIUM");

    public static VolumeParticipationFutureAlgoUrgency High { get; } = new("HIGH");

    static VolumeParticipationFutureAlgoUrgency IExtensibleValue<VolumeParticipationFutureAlgoUrgency>.Create(string value) => new(value);

    public static bool operator ==(VolumeParticipationFutureAlgoUrgency left, VolumeParticipationFutureAlgoUrgency right) => left.Equals(right);

    public static bool operator !=(VolumeParticipationFutureAlgoUrgency left, VolumeParticipationFutureAlgoUrgency right) => !left.Equals(right);

    public static implicit operator VolumeParticipationFutureAlgoUrgency(string value) => new(value);

    public static VolumeParticipationFutureAlgoUrgency FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is VolumeParticipationFutureAlgoUrgency other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(VolumeParticipationFutureAlgoUrgency other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<VolumeParticipationFutureAlgoPositionSide>))]
public readonly struct VolumeParticipationFutureAlgoPositionSide : IExtensibleValue<VolumeParticipationFutureAlgoPositionSide>, IEquatable<VolumeParticipationFutureAlgoPositionSide>
{
    private readonly string? _value;

    public VolumeParticipationFutureAlgoPositionSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static VolumeParticipationFutureAlgoPositionSide Both { get; } = new("BOTH");

    public static VolumeParticipationFutureAlgoPositionSide Long { get; } = new("LONG");

    public static VolumeParticipationFutureAlgoPositionSide Short { get; } = new("SHORT");

    static VolumeParticipationFutureAlgoPositionSide IExtensibleValue<VolumeParticipationFutureAlgoPositionSide>.Create(string value) => new(value);

    public static bool operator ==(VolumeParticipationFutureAlgoPositionSide left, VolumeParticipationFutureAlgoPositionSide right) => left.Equals(right);

    public static bool operator !=(VolumeParticipationFutureAlgoPositionSide left, VolumeParticipationFutureAlgoPositionSide right) => !left.Equals(right);

    public static implicit operator VolumeParticipationFutureAlgoPositionSide(string value) => new(value);

    public static VolumeParticipationFutureAlgoPositionSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is VolumeParticipationFutureAlgoPositionSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(VolumeParticipationFutureAlgoPositionSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class VolumeParticipationFutureAlgoRequest
{
    /// <summary>Trading symbol eg. BTCUSDT</summary>
    public required string Symbol { get; init; }

    /// <summary>Trading side ( BUY or SELL )</summary>
    public required VolumeParticipationFutureAlgoSide Side { get; init; }

    /// <summary>
    /// Quantity of base asset; The notional (quantity * mark price(base asset)) must be more than the
    /// equivalent of 10,000 USDT, and the maximum notional varies by symbol: up to 50,000,000 USDT for
    /// BTCUSDT perpetual, up to 25,000,000 USDT for ETHUSDT perpetual, and up to 5,000,000 USDT for other
    /// symbols
    /// </summary>
    public required decimal Quantity { get; init; }

    /// <summary>Represent the relative speed of the current execution; ENUM: LOW, MEDIUM, HIGH</summary>
    public required VolumeParticipationFutureAlgoUrgency Urgency { get; init; }

    /// <summary>
    /// Default BOTH for One-way Mode ; LONG or SHORT for Hedge Mode. It must be sent in Hedge Mode.
    /// </summary>
    public VolumeParticipationFutureAlgoPositionSide? PositionSide { get; init; }

    /// <summary>
    /// A unique id among Algo orders (length should be 32 characters)， If it is not sent, we will give
    /// default value
    /// </summary>
    public string? ClientAlgoId { get; init; }

    /// <summary>
    /// "true" or "false". Default "false"; Cannot be sent in Hedge Mode; Cannot be sent when you open a
    /// position
    /// </summary>
    public bool? ReduceOnly { get; init; }

    /// <summary>
    /// Limit price of the order; If it is not sent, will place order by market price by default
    /// </summary>
    public decimal? LimitPrice { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class AlgoRestApi
{

    /// <summary>Cancel Futures Algo Order (TRADE)</summary>
    /// <remarks>
    /// <para>Cancel an active order.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Either algoId or clientAlgoId must be sent.</para>
    /// <para>- You need to enable Futures Trading Permission for the API key that requests this endpoint.</para>
    /// <para>- Base URL: https://api.binance.com</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CancelAlgoOrderFutureAlgoResponse>> CancelAlgoOrderFutureAlgoAsync(CancelAlgoOrderFutureAlgoRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/sapi/v1/algo/futures/order", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("algoId", request.AlgoId);
        r.Query("clientAlgoId", request.ClientAlgoId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, AlgoRestApiJson.Default.CancelAlgoOrderFutureAlgoResponse, cancellationToken);
    }

    /// <summary>Query Current Futures Algo Open Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Current Algo Open Orders</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- You need to enable Futures Trading Permission for the API key that requests this endpoint.</para>
    /// <para>- Base URL: https://api.binance.com</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryCurrentAlgoOpenOrdersFutureAlgoResponse>> QueryCurrentAlgoOpenOrdersFutureAlgoAsync(QueryCurrentAlgoOpenOrdersFutureAlgoRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/algo/futures/openOrders", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, AlgoRestApiJson.Default.QueryCurrentAlgoOpenOrdersFutureAlgoResponse, cancellationToken);
    }

    /// <summary>Query Historical Futures Algo Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Historical Algo Order</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- You need to enable Futures Trading Permission for the API key that requests this endpoint.</para>
    /// <para>- Base URL: https://api.binance.com</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryHistoricalAlgoOrdersFutureAlgoResponse>> QueryHistoricalAlgoOrdersFutureAlgoAsync(QueryHistoricalAlgoOrdersFutureAlgoRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/algo/futures/historicalOrders", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("side", request.Side);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("page", request.Page);
        r.Query("pageSize", request.PageSize);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, AlgoRestApiJson.Default.QueryHistoricalAlgoOrdersFutureAlgoResponse, cancellationToken);
    }

    /// <summary>Query Futures Sub Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get respective sub orders for a specified algoId</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- You need to enable Futures Trading Permission for the API key that requests this endpoint.</para>
    /// <para>- Base URL: https://api.binance.com</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QuerySubOrdersFutureAlgoResponse>> QuerySubOrdersFutureAlgoAsync(QuerySubOrdersFutureAlgoRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/algo/futures/subOrders", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QuerySubOrdersFutureAlgoResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("algoId", request.AlgoId);
        r.Query("page", request.Page);
        r.Query("pageSize", request.PageSize);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, AlgoRestApiJson.Default.QuerySubOrdersFutureAlgoResponse, cancellationToken);
    }

    /// <summary>Time-Weighted Futures Average Price (Twap) New Order (TRADE)</summary>
    /// <remarks>
    /// <para>Send in a Twap new order. Only support on USDⓈ-M Contracts.</para>
    /// <para>Weight(UID): 3000</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Other info:</para>
    /// <para>- Total Algo open orders max allowed: 30 orders.</para>
    /// <para>- Leverage and position mode follow your futures account settings.</para>
    /// <para>- Receiving "success": true does not guarantee execution; query order endpoints for final status.</para>
    /// <para>
    /// - If balance/position constraints fail, response may still return success but order status becomes
    /// expired.
    /// </para>
    /// <para>- quantity * 60 / duration must be greater than minQty.</para>
    /// <para>- duration cannot be less than 5 minutes or greater than 24 hours.</para>
    /// <para>- For delivery contracts, TWAP end time should be one hour earlier than symbol delivery time.</para>
    /// <para>- You need to enable the corresponding permission for the API key requesting this endpoint:</para>
    /// <para>- Futures Trading Permission — for Classic Trading Account mode</para>
    /// <para>- Portfolio Margin Trading Permission — for Portfolio Margin Account mode</para>
    /// <para>- Base URL: https://api.binance.com</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<TimeWeightedAveragePriceFutureAlgoResponse>> TimeWeightedAveragePriceFutureAlgoAsync(TimeWeightedAveragePriceFutureAlgoRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/algo/futures/newOrderTwap", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<TimeWeightedAveragePriceFutureAlgoResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("side", request.Side);
        r.Query("quantity", request.Quantity);
        r.Query("duration", request.Duration);
        r.Query("positionSide", request.PositionSide);
        r.Query("clientAlgoId", request.ClientAlgoId);
        r.Query("reduceOnly", request.ReduceOnly);
        r.Query("limitPrice", request.LimitPrice);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, AlgoRestApiJson.Default.TimeWeightedAveragePriceFutureAlgoResponse, cancellationToken);
    }

    /// <summary>Volume Participation (VP) New Order (TRADE)</summary>
    /// <remarks>
    /// <para>Send in a VP new order. Only support on USDⓈ-M Contracts.</para>
    /// <para>Weight(UID): 300</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Other info:</para>
    /// <para>- Total Algo open orders max allowed: 10 orders.</para>
    /// <para>- Leverage and position mode follow your futures account settings.</para>
    /// <para>- Receiving "success": true does not guarantee execution; query order endpoints for final status.</para>
    /// <para>
    /// - If balance/position constraints fail, response may still return success but order status becomes
    /// expired.
    /// </para>
    /// <para>- You need to enable the corresponding permission for the API key requesting this endpoint:</para>
    /// <para>- Futures Trading Permission — for Classic Trading Account mode</para>
    /// <para>- Portfolio Margin Trading Permission — for Portfolio Margin Account mode</para>
    /// <para>- Base URL: https://api.binance.com</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<VolumeParticipationFutureAlgoResponse>> VolumeParticipationFutureAlgoAsync(VolumeParticipationFutureAlgoRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/algo/futures/newOrderVp", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<VolumeParticipationFutureAlgoResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("side", request.Side);
        r.Query("quantity", request.Quantity);
        r.Query("urgency", request.Urgency);
        r.Query("positionSide", request.PositionSide);
        r.Query("clientAlgoId", request.ClientAlgoId);
        r.Query("reduceOnly", request.ReduceOnly);
        r.Query("limitPrice", request.LimitPrice);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, AlgoRestApiJson.Default.VolumeParticipationFutureAlgoResponse, cancellationToken);
    }
}
