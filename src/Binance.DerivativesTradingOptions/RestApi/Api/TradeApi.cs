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

namespace Binance.DerivativesTradingOptions.RestApi;

public sealed class AccountTradeListRequest
{
    /// <summary>Option trading pair.</summary>
    public required string Symbol { get; init; }

    /// <summary>Trade id to fetch from. Default gets most recent trades, e.g 4611875134427365376</summary>
    public long? FromId { get; init; }

    /// <summary>Start Time, e.g 1593511200000</summary>
    public long? StartTime { get; init; }

    /// <summary>End Time, e.g 1593512200000</summary>
    public long? EndTime { get; init; }

    /// <summary>Number of result sets returned.</summary>
    public long? Limit { get; init; }

    /// <summary>Recv Window.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class CancelAllOptionOrdersByUnderlyingRequest
{
    /// <summary>Underlying asset.</summary>
    public required string Underlying { get; init; }

    /// <summary>Recv Window.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class CancelAllOptionOrdersOnSpecificSymbolRequest
{
    /// <summary>Option trading pair.</summary>
    public required string Symbol { get; init; }

    /// <summary>Recv Window.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class CancelMultipleOptionOrdersRequest
{
    /// <summary>Option trading pair.</summary>
    public required string Symbol { get; init; }

    /// <summary>Order ID list.</summary>
    public List<long>? OrderIds { get; init; }

    /// <summary>Client order ID list.</summary>
    public List<string>? ClientOrderIds { get; init; }

    /// <summary>Recv Window.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class CancelOptionOrderRequest
{
    /// <summary>Option trading pair.</summary>
    public required string Symbol { get; init; }

    /// <summary>Order ID.</summary>
    public long? OrderId { get; init; }

    /// <summary>clientOrderId</summary>
    public string? ClientOrderId { get; init; }

    /// <summary>Recv Window.</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<NewOrderSide>))]
public readonly struct NewOrderSide : IExtensibleValue<NewOrderSide>, IEquatable<NewOrderSide>
{
    private readonly string? _value;

    public NewOrderSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewOrderSide Buy { get; } = new("BUY");

    public static NewOrderSide Sell { get; } = new("SELL");

    static NewOrderSide IExtensibleValue<NewOrderSide>.Create(string value) => new(value);

    public static bool operator ==(NewOrderSide left, NewOrderSide right) => left.Equals(right);

    public static bool operator !=(NewOrderSide left, NewOrderSide right) => !left.Equals(right);

    public static implicit operator NewOrderSide(string value) => new(value);

    public static NewOrderSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewOrderSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewOrderSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewOrderType>))]
public readonly struct NewOrderType : IExtensibleValue<NewOrderType>, IEquatable<NewOrderType>
{
    private readonly string? _value;

    public NewOrderType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewOrderType Limit { get; } = new("LIMIT");

    static NewOrderType IExtensibleValue<NewOrderType>.Create(string value) => new(value);

    public static bool operator ==(NewOrderType left, NewOrderType right) => left.Equals(right);

    public static bool operator !=(NewOrderType left, NewOrderType right) => !left.Equals(right);

    public static implicit operator NewOrderType(string value) => new(value);

    public static NewOrderType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewOrderType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewOrderType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewOrderTimeInForce>))]
public readonly struct NewOrderTimeInForce : IExtensibleValue<NewOrderTimeInForce>, IEquatable<NewOrderTimeInForce>
{
    private readonly string? _value;

    public NewOrderTimeInForce(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewOrderTimeInForce Gtc { get; } = new("GTC");

    public static NewOrderTimeInForce Ioc { get; } = new("IOC");

    public static NewOrderTimeInForce Fok { get; } = new("FOK");

    public static NewOrderTimeInForce Gtx { get; } = new("GTX");

    static NewOrderTimeInForce IExtensibleValue<NewOrderTimeInForce>.Create(string value) => new(value);

    public static bool operator ==(NewOrderTimeInForce left, NewOrderTimeInForce right) => left.Equals(right);

    public static bool operator !=(NewOrderTimeInForce left, NewOrderTimeInForce right) => !left.Equals(right);

    public static implicit operator NewOrderTimeInForce(string value) => new(value);

    public static NewOrderTimeInForce FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewOrderTimeInForce other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewOrderTimeInForce other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewOrderNewOrderRespType>))]
public readonly struct NewOrderNewOrderRespType : IExtensibleValue<NewOrderNewOrderRespType>, IEquatable<NewOrderNewOrderRespType>
{
    private readonly string? _value;

    public NewOrderNewOrderRespType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewOrderNewOrderRespType Ack { get; } = new("ACK");

    public static NewOrderNewOrderRespType Result { get; } = new("RESULT");

    static NewOrderNewOrderRespType IExtensibleValue<NewOrderNewOrderRespType>.Create(string value) => new(value);

    public static bool operator ==(NewOrderNewOrderRespType left, NewOrderNewOrderRespType right) => left.Equals(right);

    public static bool operator !=(NewOrderNewOrderRespType left, NewOrderNewOrderRespType right) => !left.Equals(right);

    public static implicit operator NewOrderNewOrderRespType(string value) => new(value);

    public static NewOrderNewOrderRespType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewOrderNewOrderRespType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewOrderNewOrderRespType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewOrderSelfTradePreventionMode>))]
public readonly struct NewOrderSelfTradePreventionMode : IExtensibleValue<NewOrderSelfTradePreventionMode>, IEquatable<NewOrderSelfTradePreventionMode>
{
    private readonly string? _value;

    public NewOrderSelfTradePreventionMode(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewOrderSelfTradePreventionMode None { get; } = new("NONE");

    public static NewOrderSelfTradePreventionMode ExpireTaker { get; } = new("EXPIRE_TAKER");

    public static NewOrderSelfTradePreventionMode ExpireMaker { get; } = new("EXPIRE_MAKER");

    public static NewOrderSelfTradePreventionMode ExpireBoth { get; } = new("EXPIRE_BOTH");

    static NewOrderSelfTradePreventionMode IExtensibleValue<NewOrderSelfTradePreventionMode>.Create(string value) => new(value);

    public static bool operator ==(NewOrderSelfTradePreventionMode left, NewOrderSelfTradePreventionMode right) => left.Equals(right);

    public static bool operator !=(NewOrderSelfTradePreventionMode left, NewOrderSelfTradePreventionMode right) => !left.Equals(right);

    public static implicit operator NewOrderSelfTradePreventionMode(string value) => new(value);

    public static NewOrderSelfTradePreventionMode FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewOrderSelfTradePreventionMode other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewOrderSelfTradePreventionMode other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class NewOrderRequest
{
    public required string Symbol { get; init; }

    public required NewOrderSide Side { get; init; }

    public required NewOrderType Type { get; init; }

    /// <summary>Order Quantity</summary>
    public required decimal Quantity { get; init; }

    /// <summary>Order Price</summary>
    public decimal? Price { get; init; }

    public NewOrderTimeInForce? TimeInForce { get; init; }

    public bool? ReduceOnly { get; init; }

    public bool? PostOnly { get; init; }

    public NewOrderNewOrderRespType? NewOrderRespType { get; init; }

    /// <summary>User-defined order ID cannot be repeated in pending orders</summary>
    public string? ClientOrderId { get; init; }

    /// <summary>is market maker protection order</summary>
    public bool? IsMmp { get; init; }

    /// <summary>Self-trade prevention mode</summary>
    public NewOrderSelfTradePreventionMode? SelfTradePreventionMode { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class OptionPositionInformationRequest
{
    /// <summary>Option trading pair.</summary>
    public string? Symbol { get; init; }

    /// <summary>Recv Window.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class PlaceMultipleOrdersRequest
{
    /// <summary>order list. Max 10 orders</summary>
    public required List<PlaceMultipleOrdersOrdersParameterInner> Orders { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryCurrentOpenOptionOrdersRequest
{
    /// <summary>Option trading pair.</summary>
    public string? Symbol { get; init; }

    /// <summary>Order ID.</summary>
    public long? OrderId { get; init; }

    /// <summary>Start Time, e.g 1593511200000</summary>
    public long? StartTime { get; init; }

    /// <summary>End Time, e.g 1593512200000</summary>
    public long? EndTime { get; init; }

    /// <summary>Recv Window.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class QueryOptionOrderHistoryRequest
{
    /// <summary>Option trading pair.</summary>
    public required string Symbol { get; init; }

    /// <summary>Order ID.</summary>
    public long? OrderId { get; init; }

    /// <summary>Start Time, e.g 1593511200000</summary>
    public long? StartTime { get; init; }

    /// <summary>End Time, e.g 1593512200000</summary>
    public long? EndTime { get; init; }

    /// <summary>Number of result sets returned</summary>
    public long? Limit { get; init; }

    /// <summary>Recv Window.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class QuerySingleOrderRequest
{
    /// <summary>Option trading pair.</summary>
    public required string Symbol { get; init; }

    /// <summary>Order ID.</summary>
    public long? OrderId { get; init; }

    /// <summary>User-defined order ID; cannot be duplicated among open orders.</summary>
    public string? ClientOrderId { get; init; }

    /// <summary>Recv Window.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class TradfiOptionsContractRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class UserCommissionRequest
{
    /// <summary>Recv Window.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class UserExerciseRecordRequest
{
    /// <summary>Option trading pair.</summary>
    public string? Symbol { get; init; }

    /// <summary>Start Time, e.g 1593511200000</summary>
    public long? StartTime { get; init; }

    /// <summary>End Time, e.g 1593512200000</summary>
    public long? EndTime { get; init; }

    /// <summary>Number of result sets returned.</summary>
    public long? Limit { get; init; }

    /// <summary>Recv Window.</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class DerivativesTradingOptionsRestApi
{

    /// <summary>Account Trade List (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Get trades for a specific account and symbol. Only supports querying trades in the past 3 months; a
    /// startTime/endTime outside that window returns -6073 SEARCH_WINDOW_RESTRICTED.
    /// </para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<AccountTradeListResponseInner>>> AccountTradeListAsync(AccountTradeListRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/eapi/v1/userTrades", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<AccountTradeListResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("fromId", request.FromId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.ListAccountTradeListResponseInner, cancellationToken);
    }

    /// <summary>Cancel All Option Orders By Underlying (TRADE)</summary>
    /// <remarks>
    /// <para>Cancel all active orders on specified underlying.</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CancelAllOptionOrdersByUnderlyingResponse>> CancelAllOptionOrdersByUnderlyingAsync(CancelAllOptionOrdersByUnderlyingRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/eapi/v1/allOpenOrdersByUnderlying", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CancelAllOptionOrdersByUnderlyingResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("underlying", request.Underlying);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.CancelAllOptionOrdersByUnderlyingResponse, cancellationToken);
    }

    /// <summary>Cancel all Option orders on specific symbol (TRADE)</summary>
    /// <remarks>
    /// <para>Cancel all active order on a symbol.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CancelAllOptionOrdersOnSpecificSymbolResponse>> CancelAllOptionOrdersOnSpecificSymbolAsync(CancelAllOptionOrdersOnSpecificSymbolRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/eapi/v1/allOpenOrders", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CancelAllOptionOrdersOnSpecificSymbolResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.CancelAllOptionOrdersOnSpecificSymbolResponse, cancellationToken);
    }

    /// <summary>Cancel Multiple Option Orders (TRADE)</summary>
    /// <remarks>
    /// <para>Cancel multiple orders.</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- At least one instance of orderId and clientOrderId must be sent.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<CancelMultipleOptionOrdersResponseInner>>> CancelMultipleOptionOrdersAsync(CancelMultipleOptionOrdersRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/eapi/v1/batchOrders", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<CancelMultipleOptionOrdersResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderIds", request.OrderIds);
        r.Query("clientOrderIds", request.ClientOrderIds);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.ListCancelMultipleOptionOrdersResponseInner, cancellationToken);
    }

    /// <summary>Cancel Option Order (TRADE)</summary>
    /// <remarks>
    /// <para>Cancel an active order.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- At least one instance of orderId and clientOrderId must be sent.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CancelOptionOrderResponse>> CancelOptionOrderAsync(CancelOptionOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/eapi/v1/order", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CancelOptionOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderId", request.OrderId);
        r.Query("clientOrderId", request.ClientOrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.CancelOptionOrderResponse, cancellationToken);
    }

    /// <summary>New Order (TRADE)</summary>
    /// <remarks>
    /// <para>Send a new order.</para>
    /// <para>Weight(IP): 0</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes: Some parameters are mandatory depending on the order type as follows:</para>
    /// <para>Type | Mandatory parameters</para>
    /// <para>LIMIT | timeInForce, quantity, price</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<NewOrderResponse>> NewOrderAsync(NewOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/eapi/v1/order", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<NewOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("side", request.Side);
        r.Query("type", request.Type);
        r.Query("quantity", request.Quantity);
        r.Query("price", request.Price);
        r.Query("timeInForce", request.TimeInForce);
        r.Query("reduceOnly", request.ReduceOnly);
        r.Query("postOnly", request.PostOnly);
        r.Query("newOrderRespType", request.NewOrderRespType);
        r.Query("clientOrderId", request.ClientOrderId);
        r.Query("isMmp", request.IsMmp);
        r.Query("selfTradePreventionMode", request.SelfTradePreventionMode);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.NewOrderResponse, cancellationToken);
    }

    /// <summary>Option Position Information (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get current position information.</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<OptionPositionInformationResponseInner>>> OptionPositionInformationAsync(OptionPositionInformationRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/eapi/v1/position", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.ListOptionPositionInformationResponseInner, cancellationToken);
    }

    /// <summary>Place Multiple Orders (TRADE)</summary>
    /// <remarks>
    /// <para>Send multiple option orders.</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes: Some parameters are mandatory depending on the order type as follows:</para>
    /// <para>Type | Mandatory parameters</para>
    /// <para>LIMIT | timeInForce, quantity, price</para>
    /// <para>- Parameter rules are same with New Order</para>
    /// <para>- Batch orders are processed concurrently, and the order of matching is not guaranteed.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<PlaceMultipleOrdersResponseInner>>> PlaceMultipleOrdersAsync(PlaceMultipleOrdersRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/eapi/v1/batchOrders", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<PlaceMultipleOrdersResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("orders", Wire.Json(request.Orders, DerivativesTradingOptionsRestApiJson.Default.ListPlaceMultipleOrdersOrdersParameterInner));
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.ListPlaceMultipleOrdersResponseInner, cancellationToken);
    }

    /// <summary>Query Current Open Option Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query current all open orders, status: ACCEPTED PARTIALLY_FILLED</para>
    /// <para>Weight: 1 for a single symbol; 40 when the symbol parameter is omitted</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryCurrentOpenOptionOrdersResponseInner>>> QueryCurrentOpenOptionOrdersAsync(QueryCurrentOpenOptionOrdersRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/eapi/v1/openOrders", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("orderId", request.OrderId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.ListQueryCurrentOpenOptionOrdersResponseInner, cancellationToken);
    }

    /// <summary>Query Option Order History (TRADE)</summary>
    /// <remarks>
    /// <para>Query all finished orders within 5 days, finished status: CANCELLED FILLED REJECTED.</para>
    /// <para>Weight(IP): 3</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryOptionOrderHistoryResponseInner>>> QueryOptionOrderHistoryAsync(QueryOptionOrderHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/eapi/v1/historyOrders", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<QueryOptionOrderHistoryResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderId", request.OrderId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.ListQueryOptionOrderHistoryResponseInner, cancellationToken);
    }

    /// <summary>Query Single Order (TRADE)</summary>
    /// <remarks>
    /// <para>Check an order status.</para>
    /// <para>- These orders will not be found:</para>
    /// <para>- order status is CANCELED or REJECTED, AND</para>
    /// <para>- order has NO filled trade, AND</para>
    /// <para>- created time + 3 days &lt; current time</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Either orderId or clientOrderId must be sent.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QuerySingleOrderResponse>> QuerySingleOrderAsync(QuerySingleOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/eapi/v1/order", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QuerySingleOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderId", request.OrderId);
        r.Query("clientOrderId", request.ClientOrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.QuerySingleOrderResponse, cancellationToken);
    }

    /// <summary>TradFi Options Contract (USER_DATA)</summary>
    /// <remarks>
    /// <para>Sign TradFi Options agreement contract</para>
    /// <para>Weight(IP): 50</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<TradfiOptionsContractResponse>> TradfiOptionsContractAsync(TradfiOptionsContractRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/eapi/v1/stock/contract", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.TradfiOptionsContractResponse, cancellationToken);
    }

    /// <summary>User Commission (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get account commission.</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<UserCommissionResponse>> UserCommissionAsync(UserCommissionRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/eapi/v1/commission", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.UserCommissionResponse, cancellationToken);
    }

    /// <summary>User Exercise Record (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get account exercise records.</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<UserExerciseRecordResponseInner>>> UserExerciseRecordAsync(UserExerciseRecordRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/eapi/v1/exerciseRecord", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.ListUserExerciseRecordResponseInner, cancellationToken);
    }
}
