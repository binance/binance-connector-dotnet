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

namespace Binance.VipLoan.RestApi;

public sealed class CheckVIPLoanCollateralAccountRequest
{
    public long? OrderId { get; init; }

    public long? CollateralAccountId { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetVIPLoanAccruedInterestRequest
{
    public long? OrderId { get; init; }

    public string? LoanCoin { get; init; }

    /// <summary>If both startTime and endTime are omitted, the most recent 90 days are returned.</summary>
    public long? StartTime { get; init; }

    /// <summary>Maximum interval between startTime and endTime is 90 days.</summary>
    public long? EndTime { get; init; }

    /// <summary>Current page number, starting from 1.</summary>
    public long? Current { get; init; }

    /// <summary>Number of records per page.</summary>
    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetVIPLoanOngoingOrdersRequest
{
    public long? OrderId { get; init; }

    public long? CollateralAccountId { get; init; }

    public string? LoanCoin { get; init; }

    public string? CollateralCoin { get; init; }

    public long? Current { get; init; }

    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetVIPLoanRepaymentHistoryRequest
{
    public long? OrderId { get; init; }

    public string? LoanCoin { get; init; }

    /// <summary>If both startTime and endTime are omitted, the most recent 90 days are returned.</summary>
    public long? StartTime { get; init; }

    /// <summary>Maximum interval between startTime and endTime is 180 days.</summary>
    public long? EndTime { get; init; }

    /// <summary>Current page number, starting from 1.</summary>
    public long? Current { get; init; }

    /// <summary>Number of records per page.</summary>
    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryApplicationStatusRequest
{
    /// <summary>Current page number, starting from 1.</summary>
    public long? Current { get; init; }

    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed partial class VipLoanRestApi
{

    /// <summary>Check VIP Loan Collateral Account (USER_DATA)</summary>
    /// <remarks>
    /// <para>VIP loan is available for VIP users only</para>
    /// <para>Weight(IP): 6000</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>
    /// - If the logged-in account is a borrowing account, all collateral accounts bound to that borrowing
    /// account can be queried.
    /// </para>
    /// <para>
    /// - If the logged-in account is a collateral account, only collateral assets under that account can be
    /// queried.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CheckVIPLoanCollateralAccountResponse>> CheckVIPLoanCollateralAccountAsync(CheckVIPLoanCollateralAccountRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/loan/vip/collateral/account", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("orderId", request.OrderId);
        r.Query("collateralAccountId", request.CollateralAccountId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, VipLoanRestApiJson.Default.CheckVIPLoanCollateralAccountResponse, cancellationToken);
    }

    /// <summary>Get VIP Loan Accrued Interest (USER_DATA)</summary>
    /// <remarks>
    /// <para>Check VIP Loan interest record</para>
    /// <para>Weight(IP): 400</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If startTime and endTime are not sent, recent 90-day data is returned.</para>
    /// <para>- The maximum interval between startTime and endTime is 90 days.</para>
    /// <para>- Rate limit: 1 request per second per account.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetVIPLoanAccruedInterestResponse>> GetVIPLoanAccruedInterestAsync(GetVIPLoanAccruedInterestRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/loan/vip/accruedInterest", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("orderId", request.OrderId);
        r.Query("loanCoin", request.LoanCoin);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, VipLoanRestApiJson.Default.GetVIPLoanAccruedInterestResponse, cancellationToken);
    }

    /// <summary>Get VIP Loan Ongoing Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>VIP loan is available for VIP users only.</para>
    /// <para>Weight(IP): 400</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Rate limit: 1 request per second per account.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetVIPLoanOngoingOrdersResponse>> GetVIPLoanOngoingOrdersAsync(GetVIPLoanOngoingOrdersRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/loan/vip/ongoing/orders", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("orderId", request.OrderId);
        r.Query("collateralAccountId", request.CollateralAccountId);
        r.Query("loanCoin", request.LoanCoin);
        r.Query("collateralCoin", request.CollateralCoin);
        r.Query("current", request.Current);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, VipLoanRestApiJson.Default.GetVIPLoanOngoingOrdersResponse, cancellationToken);
    }

    /// <summary>Get VIP Loan Repayment History (USER_DATA)</summary>
    /// <remarks>
    /// <para>VIP Loans are available only to VIP users.</para>
    /// <para>Weight(IP): 400</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If startTime and endTime are not sent, recent 90-day data is returned.</para>
    /// <para>- The maximum interval between startTime and endTime is 180 days.</para>
    /// <para>
    /// - Rate limit: 1 request per second per account, shared with repayment history queries on the Binance
    /// website.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetVIPLoanRepaymentHistoryResponse>> GetVIPLoanRepaymentHistoryAsync(GetVIPLoanRepaymentHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/loan/vip/repay/history", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("orderId", request.OrderId);
        r.Query("loanCoin", request.LoanCoin);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, VipLoanRestApiJson.Default.GetVIPLoanRepaymentHistoryResponse, cancellationToken);
    }

    /// <summary>Query Application Status (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Application Status</para>
    /// <para>Weight(UID): 400</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Rate limit: 1 request per second per account.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryApplicationStatusResponse>> QueryApplicationStatusAsync(QueryApplicationStatusRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/loan/vip/request/data", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("current", request.Current);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, VipLoanRestApiJson.Default.QueryApplicationStatusResponse, cancellationToken);
    }
}
