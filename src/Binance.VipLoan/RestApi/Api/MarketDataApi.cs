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

public sealed class GetBorrowInterestRateRequest
{
    /// <summary>Max 10 assets, Multiple split by ","</summary>
    public required string LoanCoin { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetCollateralAssetDataRequest
{
    public string? CollateralCoin { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetLoanableAssetsDataRequest
{
    public string? LoanCoin { get; init; }

    /// <summary>Defaults to the user's VIP level.</summary>
    public long? VipLevel { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetVIPLoanInterestRateHistoryRequest
{
    public required string Coin { get; init; }

    public required long RecvWindow { get; init; }

    /// <summary>If both startTime and endTime are omitted, the most recent 90 days are returned.</summary>
    public long? StartTime { get; init; }

    /// <summary>
    /// Maximum interval between startTime and endTime is 180 days. Time is based on UTC+0.
    /// </summary>
    public long? EndTime { get; init; }

    /// <summary>Current page number, starting from 1.</summary>
    public long? Current { get; init; }

    /// <summary>Number of records per page.</summary>
    public long? Limit { get; init; }
}

public sealed class QueryVIPLoanFixedRateMarketRequest
{
    /// <summary>Loan coin</summary>
    public required string LoanCoin { get; init; }

    /// <summary>Duration in days, minimum 1</summary>
    public long? Duration { get; init; }

    /// <summary>Page number, default 1, minimum 1</summary>
    public long? Current { get; init; }

    /// <summary>Page size, default 10, range [1, 100]</summary>
    public long? Size { get; init; }

    /// <summary>The value cannot be greater than 60000</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class VipLoanRestApi
{

    /// <summary>Get Borrow Interest Rate (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Borrow Interest Rate</para>
    /// <para>Weight(IP): 400</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Rate limit: 1 request per second per account.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<GetBorrowInterestRateResponseInner>>> GetBorrowInterestRateAsync(GetBorrowInterestRateRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/loan/vip/request/interestRate", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<GetBorrowInterestRateResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("loanCoin", request.LoanCoin);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, VipLoanRestApiJson.Default.ListGetBorrowInterestRateResponseInner, cancellationToken);
    }

    /// <summary>Get Collateral Asset Data (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Collateral Asset Data</para>
    /// <para>Weight(IP): 400</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Rate limit: 1 request per second per account.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetCollateralAssetDataResponse>> GetCollateralAssetDataAsync(GetCollateralAssetDataRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/loan/vip/collateral/data", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("collateralCoin", request.CollateralCoin);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, VipLoanRestApiJson.Default.GetCollateralAssetDataResponse, cancellationToken);
    }

    /// <summary>Get Loanable Assets Data (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get interest rate and borrow limit of loanable assets. The borrow limit is shown in USD value.</para>
    /// <para>Weight(IP): 400</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Rate limit: 1 request per second per account.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetLoanableAssetsDataResponse>> GetLoanableAssetsDataAsync(GetLoanableAssetsDataRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/loan/vip/loanable/data", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("loanCoin", request.LoanCoin);
        r.Query("vipLevel", request.VipLevel);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, VipLoanRestApiJson.Default.GetLoanableAssetsDataResponse, cancellationToken);
    }

    /// <summary>Get VIP Loan Interest Rate History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Check VIP Loan flexible interest rate history</para>
    /// <para>Weight(IP): 400</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If startTime and endTime are not sent, recent 90-day data is returned.</para>
    /// <para>- The maximum interval between startTime and endTime is 180 days.</para>
    /// <para>- Time is based on UTC+0.</para>
    /// <para>- Rate limit: 1 request per second per account.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetVIPLoanInterestRateHistoryResponse>> GetVIPLoanInterestRateHistoryAsync(GetVIPLoanInterestRateHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/loan/vip/interestRateHistory", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetVIPLoanInterestRateHistoryResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("coin", request.Coin);
        r.Query("recvWindow", request.RecvWindow);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("limit", request.Limit);
        return _client.SendAsync(r, VipLoanRestApiJson.Default.GetVIPLoanInterestRateHistoryResponse, cancellationToken);
    }

    /// <summary>Query VIP Loan Fixed Rate Market (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query the VIP Loan fixed rate market. Returns a paginated list of fixed-rate supply orders.</para>
    /// <para>Weight(IP): 6000</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryVIPLoanFixedRateMarketResponse>> QueryVIPLoanFixedRateMarketAsync(QueryVIPLoanFixedRateMarketRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/loan/vip/fixed/market", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryVIPLoanFixedRateMarketResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("loanCoin", request.LoanCoin);
        r.Query("duration", request.Duration);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, VipLoanRestApiJson.Default.QueryVIPLoanFixedRateMarketResponse, cancellationToken);
    }
}
