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

namespace Binance.Spot.RestApi;

public sealed class AccountCommissionRequest
{
    public required string Symbol { get; init; }
}

public sealed class AllOrderListRequest
{
    /// <summary>If supplied, neither startTime or endTime can be provided</summary>
    public long? FromId { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    public long? Limit { get; init; }

    /// <summary>
    /// Supports up to three decimal places of precision (e.g., 6000.346) so that microseconds may be
    /// specified.
    /// </summary>
    public decimal? RecvWindow { get; init; }
}

public sealed class AllOrdersRequest
{
    public required string Symbol { get; init; }

    public long? OrderId { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    public long? Limit { get; init; }

    /// <summary>
    /// The value cannot be greater than 60000. Supports up to three decimal places of precision (e.g.,
    /// 6000.346) so that microseconds may be specified.
    /// </summary>
    public decimal? RecvWindow { get; init; }
}

public sealed class GetAccountRequest
{
    /// <summary>When set to true, emits only the non-zero balances of an account.</summary>
    public bool? OmitZeroBalances { get; init; }

    /// <summary>
    /// Supports up to three decimal places of precision (e.g., 6000.346) so that microseconds may be
    /// specified.
    /// </summary>
    public decimal? RecvWindow { get; init; }
}

public sealed class GetOpenOrdersRequest
{
    public string? Symbol { get; init; }

    /// <summary>
    /// Supports up to three decimal places of precision (e.g., 6000.346) so that microseconds may be
    /// specified.
    /// </summary>
    public decimal? RecvWindow { get; init; }
}

public sealed class GetOrderRequest
{
    public required string Symbol { get; init; }

    public long? OrderId { get; init; }

    public string? OrigClientOrderId { get; init; }

    /// <summary>
    /// Supports up to three decimal places of precision (e.g., 6000.346) so that microseconds may be
    /// specified.
    /// </summary>
    public decimal? RecvWindow { get; init; }
}

public sealed class GetOrderListRequest
{
    /// <summary>
    /// Query order list by orderListId. orderListId or origClientOrderId must be provided.
    /// </summary>
    public long? OrderListId { get; init; }

    /// <summary>
    /// Query order list by listClientOrderId. orderListId or origClientOrderId must be provided.
    /// </summary>
    public string? OrigClientOrderId { get; init; }

    /// <summary>
    /// Supports up to three decimal places of precision (e.g., 6000.346) so that microseconds may be
    /// specified.
    /// </summary>
    public decimal? RecvWindow { get; init; }
}

public sealed class MyAllocationsRequest
{
    public required string Symbol { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    public long? FromAllocationId { get; init; }

    public long? Limit { get; init; }

    public long? OrderId { get; init; }

    /// <summary>
    /// Supports up to three decimal places of precision (e.g., 6000.346) so that microseconds may be
    /// specified.
    /// </summary>
    public decimal? RecvWindow { get; init; }
}

public sealed class MyFiltersRequest
{
    public required string Symbol { get; init; }

    /// <summary>
    /// Supports up to three decimal places of precision (e.g., 6000.346) so that microseconds may be
    /// specified.
    /// </summary>
    public decimal? RecvWindow { get; init; }
}

public sealed class MyPreventedMatchesRequest
{
    public required string Symbol { get; init; }

    public long? PreventedMatchId { get; init; }

    public long? OrderId { get; init; }

    public long? FromPreventedMatchId { get; init; }

    public long? Limit { get; init; }

    /// <summary>
    /// Supports up to three decimal places of precision (e.g., 6000.346) so that microseconds may be
    /// specified.
    /// </summary>
    public decimal? RecvWindow { get; init; }
}

public sealed class MyTradesRequest
{
    public required string Symbol { get; init; }

    /// <summary>This can only be used in combination with symbol.</summary>
    public long? OrderId { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>TradeId to fetch from. Default gets most recent trades.</summary>
    public long? FromId { get; init; }

    public long? Limit { get; init; }

    /// <summary>
    /// Supports up to three decimal places of precision (e.g., 6000.346) so that microseconds may be
    /// specified.
    /// </summary>
    public decimal? RecvWindow { get; init; }
}

public sealed class OpenOrderListRequest
{
    /// <summary>
    /// Supports up to three decimal places of precision (e.g., 6000.346) so that microseconds may be
    /// specified.
    /// </summary>
    public decimal? RecvWindow { get; init; }
}

public sealed class OrderAmendmentsRequest
{
    public required string Symbol { get; init; }

    public required long OrderId { get; init; }

    public long? FromExecutionId { get; init; }

    public long? Limit { get; init; }

    /// <summary>
    /// Supports up to three decimal places of precision (e.g., 6000.346) so that microseconds may be
    /// specified.
    /// </summary>
    public decimal? RecvWindow { get; init; }
}

public sealed class RateLimitOrderRequest
{
    /// <summary>
    /// Supports up to three decimal places of precision (e.g., 6000.346) so that microseconds may be
    /// specified.
    /// </summary>
    public decimal? RecvWindow { get; init; }
}

public sealed partial class SpotRestApi
{

    /// <summary>Query Commission Rates (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get current account commission rates.</para>
    /// <para>Weight(IP): 20</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes: Data Source: Database</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<AccountCommissionResponse>> AccountCommissionAsync(AccountCommissionRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/account/commission", signed: true, hasTimeUnit: true);
        if (request is null) return Task.FromException<RestApiResponse<AccountCommissionResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        return _client.SendAsync(r, SpotRestApiJson.Default.AccountCommissionResponse, cancellationToken);
    }

    /// <summary>Query all Order lists (USER_DATA)</summary>
    /// <remarks>
    /// <para>Retrieves all order lists based on provided optional parameters.</para>
    /// <para>Note that the time between startTime and endTime can't be longer than 24 hours.</para>
    /// <para>Weight(IP): 20</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes: Data Source: Database</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<AllOrderListResponseInner>>> AllOrderListAsync(AllOrderListRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/allOrderList", signed: true, hasTimeUnit: true);
        request ??= new();
        r.Query("fromId", request.FromId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SpotRestApiJson.Default.ListAllOrderListResponseInner, cancellationToken);
    }

    /// <summary>All orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get all account orders; active, canceled, or filled.</para>
    /// <para>Weight(IP): 20</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes: Data Source: Database</para>
    /// <para>
    /// - If orderId is set, it will get orders &gt;= that orderId. Otherwise most recent orders are
    /// returned.
    /// </para>
    /// <para>
    /// - For some historical orders cummulativeQuoteQty will be &lt; 0, meaning the data is not available
    /// at this time.
    /// </para>
    /// <para>- If startTime and/or endTime provided, orderId is not required.</para>
    /// <para>- The time between startTime and endTime can't be longer than 24 hours.</para>
    /// <para>Not every field appears in every response. See Conditional fields in Order Responses.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<AllOrdersResponseInner>>> AllOrdersAsync(AllOrdersRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/allOrders", signed: true, hasTimeUnit: true);
        if (request is null) return Task.FromException<RestApiResponse<List<AllOrdersResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderId", request.OrderId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SpotRestApiJson.Default.ListAllOrdersResponseInner, cancellationToken);
    }

    /// <summary>Account information (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get current account information.</para>
    /// <para>Weight(IP): 20</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes: Data Source: Memory =&gt; Database</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetAccountResponse>> GetAccountAsync(GetAccountRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/account", signed: true, hasTimeUnit: true);
        request ??= new();
        r.Query("omitZeroBalances", request.OmitZeroBalances);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SpotRestApiJson.Default.GetAccountResponse, cancellationToken);
    }

    /// <summary>Current open orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get all open orders on a symbol. Careful when accessing this with no symbol.</para>
    /// <para>Weight: 6 for a single symbol; 80 when the symbol parameter is omitted</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes: Data Source: Memory =&gt; Database</para>
    /// <para>- If the symbol is not sent, orders for all symbols will be returned in an array.</para>
    /// <para>Not every field appears in every response. See Conditional fields in Order Responses.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<GetOpenOrdersResponseInner>>> GetOpenOrdersAsync(GetOpenOrdersRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/openOrders", signed: true, hasTimeUnit: true);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SpotRestApiJson.Default.ListGetOpenOrdersResponseInner, cancellationToken);
    }

    /// <summary>Query order (USER_DATA)</summary>
    /// <remarks>
    /// <para>Check an order's status.</para>
    /// <para>Weight(IP): 4</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes: Data Source: Memory =&gt; Database</para>
    /// <para>- Either orderId or origClientOrderId must be sent.</para>
    /// <para>
    /// - If both orderId and origClientOrderId are provided, the orderId is searched first, then the
    /// origClientOrderId from that result is checked against that order. If both conditions are not met the
    /// request will be rejected.
    /// </para>
    /// <para>
    /// - For some historical orders cummulativeQuoteQty will be &lt; 0, meaning the data is not available
    /// at this time.
    /// </para>
    /// <para>Not every field appears in every response. See Conditional fields in Order Responses.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetOrderResponse>> GetOrderAsync(GetOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/order", signed: true, hasTimeUnit: true);
        if (request is null) return Task.FromException<RestApiResponse<GetOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderId", request.OrderId);
        r.Query("origClientOrderId", request.OrigClientOrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SpotRestApiJson.Default.GetOrderResponse, cancellationToken);
    }

    /// <summary>Query Order list (USER_DATA)</summary>
    /// <remarks>
    /// <para>Retrieves a specific order list based on provided optional parameters.</para>
    /// <para>Weight(IP): 4</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes: Data Source: Database</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetOrderListResponse>> GetOrderListAsync(GetOrderListRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/orderList", signed: true, hasTimeUnit: true);
        request ??= new();
        r.Query("orderListId", request.OrderListId);
        r.Query("origClientOrderId", request.OrigClientOrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SpotRestApiJson.Default.GetOrderListResponse, cancellationToken);
    }

    /// <summary>Query Allocations (USER_DATA)</summary>
    /// <remarks>
    /// <para>Retrieves allocations resulting from SOR order placement.</para>
    /// <para>Weight(IP): 20</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes: Data Source: Database"</para>
    /// <para>Supported parameter combinations:</para>
    /// <para>Parameters | Response |</para>
    /// <para>symbol | allocations from oldest to newest |</para>
    /// <para>symbol + startTime | oldest allocations since startTime |</para>
    /// <para>symbol + endTime | newest allocations until endTime |</para>
    /// <para>symbol + startTime + endTime | allocations within the time range |</para>
    /// <para>symbol + fromAllocationId | allocations by allocation ID |</para>
    /// <para>symbol + orderId | allocations related to an order starting with oldest |</para>
    /// <para>symbol + orderId + fromAllocationId | allocations related to an order by allocation ID |</para>
    /// <para>Note: The time between startTime and endTime can't be longer than 24 hours.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<MyAllocationsResponseInner>>> MyAllocationsAsync(MyAllocationsRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/myAllocations", signed: true, hasTimeUnit: true);
        if (request is null) return Task.FromException<RestApiResponse<List<MyAllocationsResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("fromAllocationId", request.FromAllocationId);
        r.Query("limit", request.Limit);
        r.Query("orderId", request.OrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SpotRestApiJson.Default.ListMyAllocationsResponseInner, cancellationToken);
    }

    /// <summary>Query relevant filters (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Retrieves the list of filters relevant to an account on a given symbol. This is the only endpoint
    /// that shows if an account has MAX_ASSET filters applied to it.
    /// </para>
    /// <para>Weight(IP): 40</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes: Data Source: Memory</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<MyFiltersResponse>> MyFiltersAsync(MyFiltersRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/myFilters", signed: true, hasTimeUnit: true);
        if (request is null) return Task.FromException<RestApiResponse<MyFiltersResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SpotRestApiJson.Default.MyFiltersResponse, cancellationToken);
    }

    /// <summary>Query Prevented Matches (USER_DATA)</summary>
    /// <remarks>
    /// <para>Displays the list of orders that were expired due to STP.</para>
    /// <para>These are the combinations supported:</para>
    /// <para>- symbol + preventedMatchId</para>
    /// <para>- symbol + orderId</para>
    /// <para>- symbol + orderId + fromPreventedMatchId (limit will default to 500)</para>
    /// <para>- symbol + orderId + fromPreventedMatchId + limit</para>
    /// <para>Weight: Case | Weight</para>
    /// <para>If symbol is invalid | 2</para>
    /// <para>Querying by preventedMatchId | 2</para>
    /// <para>Querying by orderId | 20</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes: Data Source: Database</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<MyPreventedMatchesResponseInner>>> MyPreventedMatchesAsync(MyPreventedMatchesRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/myPreventedMatches", signed: true, hasTimeUnit: true);
        if (request is null) return Task.FromException<RestApiResponse<List<MyPreventedMatchesResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("preventedMatchId", request.PreventedMatchId);
        r.Query("orderId", request.OrderId);
        r.Query("fromPreventedMatchId", request.FromPreventedMatchId);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SpotRestApiJson.Default.ListMyPreventedMatchesResponseInner, cancellationToken);
    }

    /// <summary>Account trade list (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get trades for a specific account and symbol.</para>
    /// <para>Weight: Condition| Weight|</para>
    /// <para>|Without orderId|20| |With orderId|5|</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes: Data Source: Memory =&gt; Database</para>
    /// <para>Notes::</para>
    /// <para>- If fromId is set, it will get trades &gt;= that fromId. Otherwise most recent trades are returned.</para>
    /// <para>- The time between startTime and endTime can't be longer than 24 hours.</para>
    /// <para>- These are the supported combinations of all parameters:</para>
    /// <para>- symbol</para>
    /// <para>- symbol + orderId</para>
    /// <para>- symbol + startTime</para>
    /// <para>- symbol + endTime</para>
    /// <para>- symbol + fromId</para>
    /// <para>- symbol + startTime + endTime</para>
    /// <para>- symbol+ orderId + fromId</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<MyTradesResponseInner>>> MyTradesAsync(MyTradesRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/myTrades", signed: true, hasTimeUnit: true);
        if (request is null) return Task.FromException<RestApiResponse<List<MyTradesResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderId", request.OrderId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("fromId", request.FromId);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SpotRestApiJson.Default.ListMyTradesResponseInner, cancellationToken);
    }

    /// <summary>Query Open Order lists (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Open Order lists</para>
    /// <para>Weight(IP): 6</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes: Data Source: Memory -&gt; Database</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<OpenOrderListResponseInner>>> OpenOrderListAsync(OpenOrderListRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/openOrderList", signed: true, hasTimeUnit: true);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SpotRestApiJson.Default.ListOpenOrderListResponseInner, cancellationToken);
    }

    /// <summary>Query Order Amendments (USER_DATA)</summary>
    /// <remarks>
    /// <para>Queries all amendments of a single order.</para>
    /// <para>Weight(IP): 4</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes: Data Source: Database</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<OrderAmendmentsResponseInner>>> OrderAmendmentsAsync(OrderAmendmentsRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/order/amendments", signed: true, hasTimeUnit: true);
        if (request is null) return Task.FromException<RestApiResponse<List<OrderAmendmentsResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderId", request.OrderId);
        r.Query("fromExecutionId", request.FromExecutionId);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SpotRestApiJson.Default.ListOrderAmendmentsResponseInner, cancellationToken);
    }

    /// <summary>Query Unfilled Order Count (USER_DATA)</summary>
    /// <remarks>
    /// <para>Displays the user's unfilled order count for all intervals.</para>
    /// <para>Weight(IP): 40</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes: Data Source: Memory</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<RateLimitOrderResponseInner>>> RateLimitOrderAsync(RateLimitOrderRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/rateLimit/order", signed: true, hasTimeUnit: true);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SpotRestApiJson.Default.ListRateLimitOrderResponseInner, cancellationToken);
    }
}
