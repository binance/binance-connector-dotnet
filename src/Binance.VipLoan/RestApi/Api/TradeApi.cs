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

public sealed class VipLoanBorrowRequest
{
    public required long LoanAccountId { get; init; }

    public required string LoanCoin { get; init; }

    public required decimal LoanAmount { get; init; }

    /// <summary>Collateral account ID(s). Multiple split by ,</summary>
    public required string CollateralAccountId { get; init; }

    /// <summary>
    /// Collateral coin(s), multiple separated by ,. Use &lt;ASSET&gt;-Earn for a Simple Earn Flexible
    /// position; it must be sent together with its Spot asset, e.g. USDT,USDT-Earn.
    /// </summary>
    public required string CollateralCoin { get; init; }

    /// <summary>TRUE: flexible rate; FALSE: fixed rate</summary>
    public required bool IsFlexibleRate { get; init; }

    /// <summary>Mandatory for fixed rate. Optional for flexible rate. e.g. 30/60 days</summary>
    public long? LoanTerm { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class VipLoanFixedRateBorrowRequest
{
    /// <summary>
    /// Supply request string, positional encoding (no key). Multiple entries separated by ;, fields
    /// separated by :, order: &lt;requestId&gt;:&lt;interestRate&gt;:&lt;amount&gt;. Example:
    /// 1212:0.12:100;3434:0.13:50
    /// </summary>
    public required string SupplyRequest { get; init; }

    /// <summary>Borrow coin</summary>
    public required string BorrowCoin { get; init; }

    /// <summary>Loan term in days</summary>
    public required long LoanTerm { get; init; }

    /// <summary>Borrow receiving account UID</summary>
    public required long BorrowUid { get; init; }

    /// <summary>
    /// Collateral coin(s), multiple separated by ,. Only coin names, no amount (VIP loan collateral amount
    /// = entire Spot balance of the coin; for &lt;ASSET&gt;-Earn, the Simple Earn Flexible position of the
    /// asset). &lt;ASSET&gt;-Earn must be sent together with its Spot asset, e.g. BNB,BNB-Earn.
    /// </summary>
    public required string CollateralCoin { get; init; }

    /// <summary>Collateral account ID(s), multiple separated by ,</summary>
    public required string CollateralAccountId { get; init; }

    /// <summary>
    /// Default: true. true: auto repay at expiration; false: auto-convert to flexible (floating rate) at
    /// expiration
    /// </summary>
    public bool? AutoRepay { get; init; }

    /// <summary>The value cannot be greater than 60000</summary>
    public long? RecvWindow { get; init; }
}

public sealed class VipLoanRenewRequest
{
    public required long OrderId { get; init; }

    /// <summary>30/60 days</summary>
    public required long LoanTerm { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class VipLoanRepayRequest
{
    public required long OrderId { get; init; }

    public required decimal Amount { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed partial class VipLoanRestApi
{

    /// <summary>VIP Loan Borrow (TRADE)</summary>
    /// <remarks>
    /// <para>VIP loan is available for VIP users only.</para>
    /// <para>Weight(UID): 6000</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- loanAccountId refers to the loan receiving account.</para>
    /// <para>- Only master account applications are supported.</para>
    /// <para>- loanAccountId and collateralAccountId must be under the same master account.</para>
    /// <para>- loanTerm is mandatory if the user chooses a fixed rate (isFlexibleRate = FALSE).</para>
    /// <para>- Every coin in collateralCoin is pledged from every account in collateralAccountId.</para>
    /// <para>
    /// - To pledge a Simple Earn Flexible position, add &lt;ASSET&gt;-Earn (e.g. USDT-Earn) to
    /// collateralCoin together with its Spot asset (e.g. USDT,USDT-Earn). Sending &lt;ASSET&gt;-Earn
    /// without its Spot asset returns -10213.
    /// </para>
    /// <para>- Rate limit: 1 request per second per account.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<VipLoanBorrowResponse>> VipLoanBorrowAsync(VipLoanBorrowRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/loan/vip/borrow", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<VipLoanBorrowResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("loanAccountId", request.LoanAccountId);
        r.Query("loanCoin", request.LoanCoin);
        r.Query("loanAmount", request.LoanAmount);
        r.Query("collateralAccountId", request.CollateralAccountId);
        r.Query("collateralCoin", request.CollateralCoin);
        r.Query("isFlexibleRate", request.IsFlexibleRate);
        r.Query("loanTerm", request.LoanTerm);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, VipLoanRestApiJson.Default.VipLoanBorrowResponse, cancellationToken);
    }

    /// <summary>VIP Loan Fixed Rate Borrow (TRADE)</summary>
    /// <remarks>
    /// <para>Submit a fixed rate borrow request by matching market supply orders.</para>
    /// <para>Weight(UID): 6000</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Rate limit: 2 requests per second per account.</para>
    /// <para>
    /// - When multiple supplyRequest entries are provided, all requestId values must correspond to the same
    /// borrowCoin and loanTerm (validated by collateral facade).
    /// </para>
    /// <para>- Every coin in collateralCoin is pledged from every account in collateralAccountId.</para>
    /// <para>
    /// - To pledge a Simple Earn Flexible position, add &lt;ASSET&gt;-Earn (e.g. BNB-Earn) to
    /// collateralCoin together with its Spot asset (e.g. BNB,BNB-Earn). Sending &lt;ASSET&gt;-Earn without
    /// its Spot asset returns -10213.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<VipLoanFixedRateBorrowResponse>> VipLoanFixedRateBorrowAsync(VipLoanFixedRateBorrowRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/loan/vip/fixed/borrow", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<VipLoanFixedRateBorrowResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("supplyRequest", request.SupplyRequest);
        r.Query("borrowCoin", request.BorrowCoin);
        r.Query("loanTerm", request.LoanTerm);
        r.Query("borrowUid", request.BorrowUid);
        r.Query("collateralCoin", request.CollateralCoin);
        r.Query("collateralAccountId", request.CollateralAccountId);
        r.Query("autoRepay", request.AutoRepay);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, VipLoanRestApiJson.Default.VipLoanFixedRateBorrowResponse, cancellationToken);
    }

    /// <summary>VIP Loan Renew (TRADE)</summary>
    /// <remarks>
    /// <para>VIP loan is available for VIP users only.</para>
    /// <para>Weight(UID): 6000</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Rate limit: 1 request per second per account.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<VipLoanRenewResponse>> VipLoanRenewAsync(VipLoanRenewRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/loan/vip/renew", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<VipLoanRenewResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("orderId", request.OrderId);
        r.Query("loanTerm", request.LoanTerm);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, VipLoanRestApiJson.Default.VipLoanRenewResponse, cancellationToken);
    }

    /// <summary>VIP Loan Repay (TRADE)</summary>
    /// <remarks>
    /// <para>VIP loan is available for VIP users only.</para>
    /// <para>Weight(UID): 6000</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Rate limit: 1 request per second per account.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<VipLoanRepayResponse>> VipLoanRepayAsync(VipLoanRepayRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/loan/vip/repay", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<VipLoanRepayResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("orderId", request.OrderId);
        r.Query("amount", request.Amount);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, VipLoanRestApiJson.Default.VipLoanRepayResponse, cancellationToken);
    }
}
