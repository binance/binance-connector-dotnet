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

namespace Binance.Spot.WebSocketApi;

public sealed class AccountCommissionRequest
{
    public required string Symbol { get; init; }

    /// <summary>Client-generated request identifier.</summary>
    public string? Id { get; init; }
}

public sealed class AccountRateLimitsOrdersRequest
{
    /// <summary>Client-generated request identifier.</summary>
    public string? Id { get; init; }

    /// <summary>
    /// Supports up to three decimal places of precision (e.g., 6000.346) so that microseconds may be
    /// specified.
    /// </summary>
    public decimal? RecvWindow { get; init; }
}

public sealed class AccountStatusRequest
{
    /// <summary>Client-generated request identifier.</summary>
    public string? Id { get; init; }

    /// <summary>
    /// When set to true, emits only the non-zero balances of an account. Default value: false.
    /// </summary>
    public bool? OmitZeroBalances { get; init; }

    /// <summary>
    /// Supports up to three decimal places of precision (e.g., 6000.346) so that microseconds may be
    /// specified.
    /// </summary>
    public decimal? RecvWindow { get; init; }
}

public sealed class AllOrderListsRequest
{
    /// <summary>Client-generated request identifier.</summary>
    public string? Id { get; init; }

    /// <summary>Order list ID to begin at</summary>
    public long? FromId { get; init; }

    /// <summary>Timestamp in ms</summary>
    public long? StartTime { get; init; }

    /// <summary>Timestamp in ms</summary>
    public long? EndTime { get; init; }

    /// <summary>Default: 500; Maximum: 1000</summary>
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

    /// <summary>Client-generated request identifier.</summary>
    public string? Id { get; init; }

    /// <summary>Order ID to begin at</summary>
    public long? OrderId { get; init; }

    /// <summary>Timestamp in ms</summary>
    public long? StartTime { get; init; }

    /// <summary>Timestamp in ms</summary>
    public long? EndTime { get; init; }

    /// <summary>Default: 500; Maximum: 1000</summary>
    public long? Limit { get; init; }

    /// <summary>
    /// Supports up to three decimal places of precision (e.g., 6000.346) so that microseconds may be
    /// specified.
    /// </summary>
    public decimal? RecvWindow { get; init; }
}

public sealed class MyAllocationsRequest
{
    public required string Symbol { get; init; }

    /// <summary>Client-generated request identifier.</summary>
    public string? Id { get; init; }

    /// <summary>Timestamp in ms</summary>
    public long? StartTime { get; init; }

    /// <summary>Timestamp in ms</summary>
    public long? EndTime { get; init; }

    /// <summary>Allocation ID to begin at</summary>
    public long? FromAllocationId { get; init; }

    /// <summary>Default: 500; Maximum: 1000</summary>
    public long? Limit { get; init; }

    /// <summary>Order ID</summary>
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

    /// <summary>Client-generated request identifier.</summary>
    public string? Id { get; init; }

    /// <summary>
    /// Supports up to three decimal places of precision (e.g., 6000.346) so that microseconds may be
    /// specified.
    /// </summary>
    public decimal? RecvWindow { get; init; }
}

public sealed class MyPreventedMatchesRequest
{
    public required string Symbol { get; init; }

    /// <summary>Client-generated request identifier.</summary>
    public string? Id { get; init; }

    /// <summary>Prevented match ID</summary>
    public long? PreventedMatchId { get; init; }

    /// <summary>Order ID</summary>
    public long? OrderId { get; init; }

    /// <summary>Prevented match ID to begin at</summary>
    public long? FromPreventedMatchId { get; init; }

    /// <summary>Default: 500; Maximum: 1000</summary>
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

    /// <summary>Client-generated request identifier.</summary>
    public string? Id { get; init; }

    /// <summary>This can only be used in combination with symbol.</summary>
    public long? OrderId { get; init; }

    /// <summary>Timestamp in ms</summary>
    public long? StartTime { get; init; }

    /// <summary>Timestamp in ms</summary>
    public long? EndTime { get; init; }

    /// <summary>First trade ID to query</summary>
    public long? FromId { get; init; }

    /// <summary>Default: 500; Maximum: 1000</summary>
    public long? Limit { get; init; }

    /// <summary>
    /// Supports up to three decimal places of precision (e.g., 6000.346) so that microseconds may be
    /// specified.
    /// </summary>
    public decimal? RecvWindow { get; init; }
}

public sealed class OpenOrderListsStatusRequest
{
    /// <summary>Client-generated request identifier.</summary>
    public string? Id { get; init; }

    /// <summary>
    /// Supports up to three decimal places of precision (e.g., 6000.346) so that microseconds may be
    /// specified.
    /// </summary>
    public decimal? RecvWindow { get; init; }
}

public sealed class OpenOrdersStatusRequest
{
    /// <summary>Client-generated request identifier.</summary>
    public string? Id { get; init; }

    /// <summary>If omitted, open orders for all symbols are returned</summary>
    public string? Symbol { get; init; }

    /// <summary>
    /// Supports up to three decimal places of precision (e.g., 6000.346) so that microseconds may be
    /// specified.
    /// </summary>
    public decimal? RecvWindow { get; init; }
}

public sealed class OrderAmendmentsRequest
{
    public required string Symbol { get; init; }

    /// <summary>Order ID</summary>
    public required long OrderId { get; init; }

    /// <summary>Client-generated request identifier.</summary>
    public string? Id { get; init; }

    /// <summary>Execution ID to begin at</summary>
    public long? FromExecutionId { get; init; }

    /// <summary>Default: 500; Maximum: 1000</summary>
    public long? Limit { get; init; }

    /// <summary>
    /// Supports up to three decimal places of precision (e.g., 6000.346) so that microseconds may be
    /// specified.
    /// </summary>
    public decimal? RecvWindow { get; init; }
}

public sealed class OrderListStatusRequest
{
    /// <summary>Client-generated request identifier.</summary>
    public string? Id { get; init; }

    /// <summary>
    /// Query order list by listClientOrderId. orderListId or origClientOrderId must be provided.
    /// </summary>
    public string? OrigClientOrderId { get; init; }

    /// <summary>
    /// Query order list by orderListId. orderListId or origClientOrderId must be provided.
    /// </summary>
    public long? OrderListId { get; init; }

    /// <summary>
    /// Supports up to three decimal places of precision (e.g., 6000.346) so that microseconds may be
    /// specified.
    /// </summary>
    public decimal? RecvWindow { get; init; }
}

public sealed class OrderStatusRequest
{
    public required string Symbol { get; init; }

    /// <summary>Client-generated request identifier.</summary>
    public string? Id { get; init; }

    /// <summary>Lookup order by orderId</summary>
    public long? OrderId { get; init; }

    /// <summary>Lookup order by clientOrderId</summary>
    public string? OrigClientOrderId { get; init; }

    /// <summary>
    /// Supports up to three decimal places of precision (e.g., 6000.346) so that microseconds may be
    /// specified.
    /// </summary>
    public decimal? RecvWindow { get; init; }
}

public sealed partial class SpotWebSocketApiConnection
{

    /// <summary>Account Commission Rates (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get current account commission rates.</para>
    /// <para>Weight(IP): 20</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes: Data Source: Database</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<AccountCommissionResponseResult>> AccountCommissionAsync(AccountCommissionRequest request, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("account.commission", WebSocketAuth.Signed);
        if (request is null) return Task.FromException<WebSocketApiResponse<AccountCommissionResponseResult>>(new ArgumentNullException(nameof(request)));
        r.Param("symbol", request.Symbol);
        r.Param("id", request.Id);
        return _client.SendAsync(r, SpotWebSocketApiJson.Default.AccountCommissionResponseResult, cancellationToken);
    }

    /// <summary>Unfilled Order Count (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query your current unfilled order count for all intervals.</para>
    /// <para>Weight(IP): 40</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes: Data Source: Memory</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<List<AccountRateLimitsOrdersResponseResultInner>>> AccountRateLimitsOrdersAsync(AccountRateLimitsOrdersRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("account.rateLimits.orders", WebSocketAuth.Signed);
        request ??= new();
        r.Param("id", request.Id);
        r.Param("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SpotWebSocketApiJson.Default.ListAccountRateLimitsOrdersResponseResultInner, cancellationToken);
    }

    /// <summary>Account information (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query information about your account.</para>
    /// <para>Weight(IP): 20</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes: Data Source: Memory =&gt; Database</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<AccountStatusResponseResult>> AccountStatusAsync(AccountStatusRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("account.status", WebSocketAuth.Signed);
        request ??= new();
        r.Param("id", request.Id);
        r.Param("omitZeroBalances", request.OmitZeroBalances);
        r.Param("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SpotWebSocketApiJson.Default.AccountStatusResponseResult, cancellationToken);
    }

    /// <summary>Account order list history (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query information about all your order lists, filtered by time range.</para>
    /// <para>Weight(IP): 20</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes: Data Source: Database</para>
    /// <para>Notes:</para>
    /// <para>- If startTime and/or endTime are specified, fromId is ignored.</para>
    /// <para>Order lists are filtered by transactionTime of the last order list execution status update.</para>
    /// <para>- If fromId is specified, return order lists with order list ID &gt;= fromId.</para>
    /// <para>- If no condition is specified, the most recent order lists are returned.</para>
    /// <para>- The time between startTime and endTime can't be longer than 24 hours.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<List<AllOrderListsResponseResultInner>>> AllOrderListsAsync(AllOrderListsRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("allOrderLists", WebSocketAuth.Signed);
        request ??= new();
        r.Param("id", request.Id);
        r.Param("fromId", request.FromId);
        r.Param("startTime", request.StartTime);
        r.Param("endTime", request.EndTime);
        r.Param("limit", request.Limit);
        r.Param("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SpotWebSocketApiJson.Default.ListAllOrderListsResponseResultInner, cancellationToken);
    }

    /// <summary>Account order history (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query information about all your orders – active, canceled, filled – filtered by time range.</para>
    /// <para>Weight(IP): 20</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes: Data Source: Database</para>
    /// <para>Notes:</para>
    /// <para>- If startTime and/or endTime are specified, orderId is ignored.</para>
    /// <para>Orders are filtered by time of the last execution status update.</para>
    /// <para>- If orderId is specified, return orders with order ID &gt;= orderId.</para>
    /// <para>- If no condition is specified, the most recent orders are returned.</para>
    /// <para>- For some historical orders the cummulativeQuoteQty response field may be negative,</para>
    /// <para>meaning the data is not available at this time.</para>
    /// <para>- The time between startTime and endTime can't be longer than 24 hours.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<List<AllOrdersResponseResultInner>>> AllOrdersAsync(AllOrdersRequest request, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("allOrders", WebSocketAuth.Signed);
        if (request is null) return Task.FromException<WebSocketApiResponse<List<AllOrdersResponseResultInner>>>(new ArgumentNullException(nameof(request)));
        r.Param("symbol", request.Symbol);
        r.Param("id", request.Id);
        r.Param("orderId", request.OrderId);
        r.Param("startTime", request.StartTime);
        r.Param("endTime", request.EndTime);
        r.Param("limit", request.Limit);
        r.Param("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SpotWebSocketApiJson.Default.ListAllOrdersResponseResultInner, cancellationToken);
    }

    /// <summary>Account allocations (USER_DATA)</summary>
    /// <remarks>
    /// <para>Retrieves allocations resulting from SOR order placement.</para>
    /// <para>Weight(IP): 20</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes: Data Source: Database</para>
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
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<List<MyAllocationsResponseResultInner>>> MyAllocationsAsync(MyAllocationsRequest request, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("myAllocations", WebSocketAuth.Signed);
        if (request is null) return Task.FromException<WebSocketApiResponse<List<MyAllocationsResponseResultInner>>>(new ArgumentNullException(nameof(request)));
        r.Param("symbol", request.Symbol);
        r.Param("id", request.Id);
        r.Param("startTime", request.StartTime);
        r.Param("endTime", request.EndTime);
        r.Param("fromAllocationId", request.FromAllocationId);
        r.Param("limit", request.Limit);
        r.Param("orderId", request.OrderId);
        r.Param("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SpotWebSocketApiJson.Default.ListMyAllocationsResponseResultInner, cancellationToken);
    }

    /// <summary>Query Relevant Filters (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Retrieves the list of filters relevant to an account on a given symbol. This is the only method that
    /// shows if an account has MAX_ASSET filters applied to it.
    /// </para>
    /// <para>Weight(IP): 40</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes: Data Source: Memory</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<MyFiltersResponse>> MyFiltersAsync(MyFiltersRequest request, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("myFilters", WebSocketAuth.Signed);
        if (request is null) return Task.FromException<WebSocketApiResponse<MyFiltersResponse>>(new ArgumentNullException(nameof(request)));
        r.Param("symbol", request.Symbol);
        r.Param("id", request.Id);
        r.Param("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SpotWebSocketApiJson.Default.MyFiltersResponse, cancellationToken);
    }

    /// <summary>Account prevented matches (USER_DATA)</summary>
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
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<List<MyPreventedMatchesResponseResultInner>>> MyPreventedMatchesAsync(MyPreventedMatchesRequest request, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("myPreventedMatches", WebSocketAuth.Signed);
        if (request is null) return Task.FromException<WebSocketApiResponse<List<MyPreventedMatchesResponseResultInner>>>(new ArgumentNullException(nameof(request)));
        r.Param("symbol", request.Symbol);
        r.Param("id", request.Id);
        r.Param("preventedMatchId", request.PreventedMatchId);
        r.Param("orderId", request.OrderId);
        r.Param("fromPreventedMatchId", request.FromPreventedMatchId);
        r.Param("limit", request.Limit);
        r.Param("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SpotWebSocketApiJson.Default.ListMyPreventedMatchesResponseResultInner, cancellationToken);
    }

    /// <summary>Account trade history (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query information about all your trades, filtered by time range.</para>
    /// <para>Weight: Condition| Weight|</para>
    /// <para>|Without orderId|20| |With orderId|5|</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes: Data Source: Memory =&gt; Database</para>
    /// <para>Notes:</para>
    /// <para>- If fromId is specified, return trades with trade ID &gt;= fromId.</para>
    /// <para>- If startTime and/or endTime are specified, trades are filtered by execution time (time).</para>
    /// <para>- fromId cannot be used together with startTime and endTime.</para>
    /// <para>- If orderId is specified, only trades related to that order are returned.</para>
    /// <para>- startTime and endTime cannot be used together with orderId.</para>
    /// <para>- If no condition is specified, the most recent trades are returned.</para>
    /// <para>- The time between startTime and endTime can't be longer than 24 hours.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<List<MyTradesResponseResultInner>>> MyTradesAsync(MyTradesRequest request, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("myTrades", WebSocketAuth.Signed);
        if (request is null) return Task.FromException<WebSocketApiResponse<List<MyTradesResponseResultInner>>>(new ArgumentNullException(nameof(request)));
        r.Param("symbol", request.Symbol);
        r.Param("id", request.Id);
        r.Param("orderId", request.OrderId);
        r.Param("startTime", request.StartTime);
        r.Param("endTime", request.EndTime);
        r.Param("fromId", request.FromId);
        r.Param("limit", request.Limit);
        r.Param("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SpotWebSocketApiJson.Default.ListMyTradesResponseResultInner, cancellationToken);
    }

    /// <summary>Current open Order lists (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query execution status of all open order lists.</para>
    /// <para>If you need to continuously monitor order status updates, please consider using WebSocket Streams:</para>
    /// <para>- userDataStream.subscribe if on an authenticated session</para>
    /// <para>- userDataStream.subscribe.signature if subscribing through signature subscription</para>
    /// <para>Weight(IP): 6</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes: Data Source: Memory -&gt; Database</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<List<OpenOrderListsStatusResponseResultInner>>> OpenOrderListsStatusAsync(OpenOrderListsStatusRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("openOrderLists.status", WebSocketAuth.Signed);
        request ??= new();
        r.Param("id", request.Id);
        r.Param("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SpotWebSocketApiJson.Default.ListOpenOrderListsStatusResponseResultInner, cancellationToken);
    }

    /// <summary>Current open orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query execution status of all open orders.</para>
    /// <para>If you need to continuously monitor order status updates, please consider using WebSocket Streams:</para>
    /// <para>- userDataStream.subscribe if on an authenticated session</para>
    /// <para>- userDataStream.subscribe.signature if subscribing through signature subscription</para>
    /// <para>Weight: | Parameter | Weight |</para>
    /// <para>| symbol | 6 |</para>
    /// <para>| none | 80 |</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes: Data Source: Memory =&gt; Database</para>
    /// <para>Not every field appears in every response. See Conditional fields in Order Responses.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<List<OpenOrdersStatusResponseResultInner>>> OpenOrdersStatusAsync(OpenOrdersStatusRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("openOrders.status", WebSocketAuth.Signed);
        request ??= new();
        r.Param("id", request.Id);
        r.Param("symbol", request.Symbol);
        r.Param("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SpotWebSocketApiJson.Default.ListOpenOrdersStatusResponseResultInner, cancellationToken);
    }

    /// <summary>Query Order Amendments (USER_DATA)</summary>
    /// <remarks>
    /// <para>Queries all amendments of a single order.</para>
    /// <para>Weight(IP): 4</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes: Data Source: Database</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<List<OrderAmendmentsResponseResultInner>>> OrderAmendmentsAsync(OrderAmendmentsRequest request, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("order.amendments", WebSocketAuth.Signed);
        if (request is null) return Task.FromException<WebSocketApiResponse<List<OrderAmendmentsResponseResultInner>>>(new ArgumentNullException(nameof(request)));
        r.Param("symbol", request.Symbol);
        r.Param("orderId", request.OrderId);
        r.Param("id", request.Id);
        r.Param("fromExecutionId", request.FromExecutionId);
        r.Param("limit", request.Limit);
        r.Param("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SpotWebSocketApiJson.Default.ListOrderAmendmentsResponseResultInner, cancellationToken);
    }

    /// <summary>Query Order list (USER_DATA)</summary>
    /// <remarks>
    /// <para>Check execution status of an Order list.</para>
    /// <para>For execution status of individual orders, use order.status.</para>
    /// <para>Weight(IP): 4</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes: Data Source: Database</para>
    /// <para>Notes:</para>
    /// <para>- origClientOrderId refers to listClientOrderId of the order list itself.</para>
    /// <para>- If both origClientOrderId and orderListId parameters are specified,</para>
    /// <para>only origClientOrderId is used and orderListId is ignored.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<OrderListStatusResponseResult>> OrderListStatusAsync(OrderListStatusRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("orderList.status", WebSocketAuth.Signed);
        request ??= new();
        r.Param("id", request.Id);
        r.Param("origClientOrderId", request.OrigClientOrderId);
        r.Param("orderListId", request.OrderListId);
        r.Param("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SpotWebSocketApiJson.Default.OrderListStatusResponseResult, cancellationToken);
    }

    /// <summary>Query order (USER_DATA)</summary>
    /// <remarks>
    /// <para>Check execution status of an order.</para>
    /// <para>Weight(IP): 4</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes: Data Source: Memory =&gt; Database</para>
    /// <para>Notes:</para>
    /// <para>
    /// - If both orderId and origClientOrderId are provided, the orderId is searched first, then the
    /// origClientOrderId from that result is checked against that order. If both conditions are not met the
    /// request will be rejected.
    /// </para>
    /// <para>- For some historical orders the cummulativeQuoteQty response field may be negative,</para>
    /// <para>meaning the data is not available at this time.</para>
    /// <para>Not every field appears in every response. See Conditional fields in Order Responses.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<OrderStatusResponseResult>> OrderStatusAsync(OrderStatusRequest request, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("order.status", WebSocketAuth.Signed);
        if (request is null) return Task.FromException<WebSocketApiResponse<OrderStatusResponseResult>>(new ArgumentNullException(nameof(request)));
        r.Param("symbol", request.Symbol);
        r.Param("id", request.Id);
        r.Param("orderId", request.OrderId);
        r.Param("origClientOrderId", request.OrigClientOrderId);
        r.Param("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SpotWebSocketApiJson.Default.OrderStatusResponseResult, cancellationToken);
    }
}
