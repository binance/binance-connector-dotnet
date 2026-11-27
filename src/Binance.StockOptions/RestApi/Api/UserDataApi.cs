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

namespace Binance.StockOptions.RestApi;

public sealed class CurrentOpenOptionOrdersRequest
{
    /// <summary>The value cannot be greater than 60000.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class ExercisableOptionsRequest
{
    /// <summary>The value cannot be greater than 60000.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class OptionExerciseDetailRequest
{
    /// <summary>Exercise transaction ID returned by Submit Option Exercise.</summary>
    public long? TranId { get; init; }

    /// <summary>Client ID used at submission.</summary>
    public string? ClientOrderId { get; init; }

    /// <summary>The value cannot be greater than 60000.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class OptionExerciseHistoryRequest
{
    /// <summary>Comma-separated status filter: PROCESSING / SUCCESS / FAILED.</summary>
    public string? Status { get; init; }

    /// <summary>Start time (ms).</summary>
    public long? StartTime { get; init; }

    /// <summary>End time (ms).</summary>
    public long? EndTime { get; init; }

    /// <summary>Page number. Default 1.</summary>
    public long? Current { get; init; }

    /// <summary>Page size. Default 20, max 100.</summary>
    public long? Size { get; init; }

    /// <summary>The value cannot be greater than 60000.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class OptionOrderDetailRequest
{
    /// <summary>Option order ID. Provide at least one of orderId and clientOrderId.</summary>
    public string? OrderId { get; init; }

    /// <summary>Client order ID. Provide at least one of orderId and clientOrderId.</summary>
    public string? ClientOrderId { get; init; }

    /// <summary>The value cannot be greater than 60000.</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<OptionOrderHistorySide>))]
public readonly struct OptionOrderHistorySide : IExtensibleValue<OptionOrderHistorySide>, IEquatable<OptionOrderHistorySide>
{
    private readonly string? _value;

    public OptionOrderHistorySide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static OptionOrderHistorySide Buy { get; } = new("BUY");

    public static OptionOrderHistorySide Sell { get; } = new("SELL");

    static OptionOrderHistorySide IExtensibleValue<OptionOrderHistorySide>.Create(string value) => new(value);

    public static bool operator ==(OptionOrderHistorySide left, OptionOrderHistorySide right) => left.Equals(right);

    public static bool operator !=(OptionOrderHistorySide left, OptionOrderHistorySide right) => !left.Equals(right);

    public static implicit operator OptionOrderHistorySide(string value) => new(value);

    public static OptionOrderHistorySide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is OptionOrderHistorySide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(OptionOrderHistorySide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class OptionOrderHistoryRequest
{
    /// <summary>
    /// Start of the order creation time (createdAt) filter (ms). If the span to endTime exceeds 180 days,
    /// it is truncated to 180 days before endTime.
    /// </summary>
    public required long StartTime { get; init; }

    /// <summary>End of the order creation time (createdAt) filter (ms).</summary>
    public required long EndTime { get; init; }

    /// <summary>
    /// Underlying US-equity ticker filter, e.g. NVDA, case-insensitive. Matches orders on all contracts of
    /// that underlying, not a single OCC contract. An unlisted or delisted ticker returns -26004.
    /// </summary>
    public string? UnderlyingSymbol { get; init; }

    /// <summary>BUY / SELL.</summary>
    public OptionOrderHistorySide? Side { get; init; }

    /// <summary>
    /// Comma-separated status filter, without spaces: FILLED / PARTIALLY_FILLED / CANCELED / EXPIRED /
    /// REJECTED. If omitted, all statuses are returned except open orders with no fills (NEW / ACCEPTED,
    /// etc.).
    /// </summary>
    public string? OrderStatus { get; init; }

    /// <summary>Page number. Default 1.</summary>
    public long? Current { get; init; }

    /// <summary>Page size. Default 20, max 100.</summary>
    public long? Size { get; init; }

    /// <summary>The value cannot be greater than 60000.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class OptionPositionsRequest
{
    /// <summary>The value cannot be greater than 60000.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class OptionSettlementEventDetailRequest
{
    /// <summary>Event ID from Option Settlement Event History.</summary>
    public required string EventId { get; init; }

    /// <summary>The value cannot be greater than 60000.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class OptionSettlementEventHistoryRequest
{
    /// <summary>Underlying US-equity ticker filter.</summary>
    public string? UnderlyingSymbol { get; init; }

    /// <summary>
    /// OCC contract symbol filter. If both symbol and underlyingSymbol are sent, symbol takes precedence.
    /// </summary>
    public string? Symbol { get; init; }

    /// <summary>
    /// Comma-separated event type filter: EXERCISE / ASSIGNMENT / EXPIRY, case-insensitive.
    /// </summary>
    public string? EventType { get; init; }

    /// <summary>Start of the event time (eventTime) filter (ms).</summary>
    public long? StartTime { get; init; }

    /// <summary>End of the event time (eventTime) filter (ms).</summary>
    public long? EndTime { get; init; }

    /// <summary>Cursor returned by the previous page. Omit on the first page.</summary>
    public long? LastId { get; init; }

    /// <summary>Page size. Default 20, max 100.</summary>
    public long? Size { get; init; }

    /// <summary>The value cannot be greater than 60000.</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<OptionTradeHistorySide>))]
public readonly struct OptionTradeHistorySide : IExtensibleValue<OptionTradeHistorySide>, IEquatable<OptionTradeHistorySide>
{
    private readonly string? _value;

    public OptionTradeHistorySide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static OptionTradeHistorySide Buy { get; } = new("BUY");

    public static OptionTradeHistorySide Sell { get; } = new("SELL");

    static OptionTradeHistorySide IExtensibleValue<OptionTradeHistorySide>.Create(string value) => new(value);

    public static bool operator ==(OptionTradeHistorySide left, OptionTradeHistorySide right) => left.Equals(right);

    public static bool operator !=(OptionTradeHistorySide left, OptionTradeHistorySide right) => !left.Equals(right);

    public static implicit operator OptionTradeHistorySide(string value) => new(value);

    public static OptionTradeHistorySide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is OptionTradeHistorySide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(OptionTradeHistorySide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class OptionTradeHistoryRequest
{
    /// <summary>Start of the execution time (executionAt) filter (ms).</summary>
    public required long StartTime { get; init; }

    /// <summary>End of the execution time (executionAt) filter (ms).</summary>
    public required long EndTime { get; init; }

    /// <summary>
    /// Underlying US-equity ticker filter, e.g. NVDA, case-insensitive. Matches fills on all contracts of
    /// that underlying, not a single OCC contract. An unlisted or delisted ticker returns -26004.
    /// </summary>
    public string? UnderlyingSymbol { get; init; }

    /// <summary>BUY / SELL.</summary>
    public OptionTradeHistorySide? Side { get; init; }

    /// <summary>Return fills of this order only.</summary>
    public string? OrderId { get; init; }

    /// <summary>Page number. Default 1.</summary>
    public long? Current { get; init; }

    /// <summary>Page size. Default 20, max 100.</summary>
    public long? Size { get; init; }

    /// <summary>The value cannot be greater than 60000.</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class StockOptionsRestApi
{

    /// <summary>Current Open Option Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Query all of the caller's open option orders, including the remaining quantity of partially filled
    /// orders. Stock orders are not included.
    /// </para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<CurrentOpenOptionOrdersResponseInner>>> CurrentOpenOptionOrdersAsync(CurrentOpenOptionOrdersRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/equity/option/order/open-orders", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StockOptionsRestApiJson.Default.ListCurrentOpenOptionOrdersResponseInner, cancellationToken);
    }

    /// <summary>Exercisable Options (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Returns the contracts that can currently be exercised. Only long positions are exercisable; the
    /// short side is the assigned party and has no exercise right.
    /// </para>
    /// <para>availableQty is the maximum quantity for Submit Option Exercise.</para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<ExercisableOptionsResponseInner>>> ExercisableOptionsAsync(ExercisableOptionsRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/equity/option/exercise/exercisable", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StockOptionsRestApiJson.Default.ListExercisableOptionsResponseInner, cancellationToken);
    }

    /// <summary>Option Exercise Detail (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Query the result of a single exercise request. Provide at least one of tranId and clientOrderId;
    /// omitting both returns -1102. If both are provided, the lookup uses clientOrderId and tranId is
    /// ignored (the opposite of Option Order Detail).
    /// </para>
    /// <para>Returns 497402 Order not found. if no record is found or the record does not belong to the caller.</para>
    /// <para>errorCode is returned only when status is FAILED.</para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<OptionExerciseDetailResponse>> OptionExerciseDetailAsync(OptionExerciseDetailRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/equity/option/exercise/detail", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("tranId", request.TranId);
        r.Query("clientOrderId", request.ClientOrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StockOptionsRestApiJson.Default.OptionExerciseDetailResponse, cancellationToken);
    }

    /// <summary>Option Exercise History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Paged exercise history.</para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<OptionExerciseHistoryResponse>> OptionExerciseHistoryAsync(OptionExerciseHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/equity/option/exercise/history", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("status", request.Status);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StockOptionsRestApiJson.Default.OptionExerciseHistoryResponse, cancellationToken);
    }

    /// <summary>Option Order Detail (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query a single option order with its fills and an itemized fee breakdown.</para>
    /// <para>
    /// Provide at least one of orderId and clientOrderId; omitting both returns -1102. If both are
    /// provided, the order is looked up by orderId, and clientOrderId must belong to the same order,
    /// otherwise 486218 Order not found is returned.
    /// </para>
    /// <para>
    /// Only option orders are accepted: the orderId / clientOrderId of a stock order returns -2013 Order
    /// does not exist.; an unknown order ID returns 486218 Order not found.
    /// </para>
    /// <para>
    /// Example: a fully filled buy-to-open order — filledTotal = total = 1.48 × 1 × 100 = 148 (excluding
    /// fees); total fees fee = 0.65 (commission + cat + orf + occ). sec / taf are 0 for buy orders. For an
    /// order still in progress with no fills, fee and the itemized fees are not returned (platformFee is
    /// always "0"); for an order canceled or expired without any fill, each fee item is "0". canceledAt /
    /// expiredAt are returned only in the corresponding status; settlementDate is not returned for buy
    /// orders.
    /// </para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<OptionOrderDetailResponse>> OptionOrderDetailAsync(OptionOrderDetailRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/equity/option/order/detail", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("orderId", request.OrderId);
        r.Query("clientOrderId", request.ClientOrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StockOptionsRestApiJson.Default.OptionOrderDetailResponse, cancellationToken);
    }

    /// <summary>Option Order History (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Paged option order history, sorted by creation time in descending order. Only option orders are
    /// returned; stock orders are not included.
    /// </para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<OptionOrderHistoryResponse>> OptionOrderHistoryAsync(OptionOrderHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/equity/option/order/history", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<OptionOrderHistoryResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("underlyingSymbol", request.UnderlyingSymbol);
        r.Query("side", request.Side);
        r.Query("orderStatus", request.OrderStatus);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StockOptionsRestApiJson.Default.OptionOrderHistoryResponse, cancellationToken);
    }

    /// <summary>Option Positions (USER_DATA)</summary>
    /// <remarks>
    /// <para>Returns all current option positions.</para>
    /// <para>One record per contract; see side for the direction.</para>
    /// <para>
    /// free / locked are signed: negative for short positions. For example, with 3 short contracts of which
    /// 1 is reserved by an open order, free = "-2" and locked = "-1". When closing (SELL_TO_CLOSE /
    /// BUY_TO_CLOSE), the quantity you can order is the absolute value of free.
    /// </para>
    /// <para>Positions past the last trading time and awaiting settlement are not returned.</para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<OptionPositionsResponseInner>>> OptionPositionsAsync(OptionPositionsRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/equity/option/position", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StockOptionsRestApiJson.Default.ListOptionPositionsResponseInner, cancellationToken);
    }

    /// <summary>Option Settlement Event Detail (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Full detail of a single settlement event, including the settlement basis and collateral release.
    /// Returns -1102 if eventId does not exist or does not belong to the caller.
    /// </para>
    /// <para>
    /// All fields of the history endpoint are included, with two differences: contracts is an absolute
    /// value, and eventTime is the time the settlement record was created.
    /// </para>
    /// <para>
    /// For an EXPIRY event, settlementKind, cashDirection, amount and shareDelta are not returned. For an
    /// EXPIRY event on a short position (covered call / cash-secured put), collateralRelease lists the
    /// collateral released.
    /// </para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<OptionSettlementEventDetailResponse>> OptionSettlementEventDetailAsync(OptionSettlementEventDetailRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/equity/option/event/detail", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<OptionSettlementEventDetailResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("eventId", request.EventId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StockOptionsRestApiJson.Default.OptionSettlementEventDetailResponse, cancellationToken);
    }

    /// <summary>Option Settlement Event History (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Query option settlement events — the settlement outcome of a contract: exercise, assignment or
    /// expiry (expired worthless), along with the shares / cash delivered and the collateral released.
    /// Sorted by event time in descending order.
    /// </para>
    /// <para>These records are on a settlement basis, separate from orders and trades.</para>
    /// <para>
    /// Cursor pagination. Omit lastId on the first page, then pass the nextLastId from the previous page
    /// until hasMore is false.
    /// </para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<OptionSettlementEventHistoryResponse>> OptionSettlementEventHistoryAsync(OptionSettlementEventHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/equity/option/event/history", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("underlyingSymbol", request.UnderlyingSymbol);
        r.Query("symbol", request.Symbol);
        r.Query("eventType", request.EventType);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("lastId", request.LastId);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StockOptionsRestApiJson.Default.OptionSettlementEventHistoryResponse, cancellationToken);
    }

    /// <summary>Option Trade History (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Paged per-fill option trade history. Only option fills are returned. Option fees are charged per
    /// order, so individual fills carry no fee; see fee in Option Order History / Option Order Detail.
    /// </para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<OptionTradeHistoryResponse>> OptionTradeHistoryAsync(OptionTradeHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/equity/option/trade/history", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<OptionTradeHistoryResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("underlyingSymbol", request.UnderlyingSymbol);
        r.Query("side", request.Side);
        r.Query("orderId", request.OrderId);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StockOptionsRestApiJson.Default.OptionTradeHistoryResponse, cancellationToken);
    }
}
