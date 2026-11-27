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

namespace Binance.CryptoLoan.RestApi;

public sealed class CheckCollateralRepayRateRequest
{
    public required string LoanCoin { get; init; }

    public required string CollateralCoin { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<FlexibleLoanAdjustLtvDirection>))]
public readonly struct FlexibleLoanAdjustLtvDirection : IExtensibleValue<FlexibleLoanAdjustLtvDirection>, IEquatable<FlexibleLoanAdjustLtvDirection>
{
    private readonly string? _value;

    public FlexibleLoanAdjustLtvDirection(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static FlexibleLoanAdjustLtvDirection Additional { get; } = new("ADDITIONAL");

    public static FlexibleLoanAdjustLtvDirection Reduced { get; } = new("REDUCED");

    static FlexibleLoanAdjustLtvDirection IExtensibleValue<FlexibleLoanAdjustLtvDirection>.Create(string value) => new(value);

    public static bool operator ==(FlexibleLoanAdjustLtvDirection left, FlexibleLoanAdjustLtvDirection right) => left.Equals(right);

    public static bool operator !=(FlexibleLoanAdjustLtvDirection left, FlexibleLoanAdjustLtvDirection right) => !left.Equals(right);

    public static implicit operator FlexibleLoanAdjustLtvDirection(string value) => new(value);

    public static FlexibleLoanAdjustLtvDirection FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is FlexibleLoanAdjustLtvDirection other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(FlexibleLoanAdjustLtvDirection other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class FlexibleLoanAdjustLtvRequest
{
    public required string LoanCoin { get; init; }

    public required string CollateralCoin { get; init; }

    public required decimal AdjustmentAmount { get; init; }

    public required FlexibleLoanAdjustLtvDirection Direction { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed class FlexibleLoanBorrowRequest
{
    public required string LoanCoin { get; init; }

    public required string CollateralCoin { get; init; }

    /// <summary>Mandatory when collateralAmount is empty</summary>
    public decimal? LoanAmount { get; init; }

    /// <summary>Mandatory when loanAmount is empty</summary>
    public decimal? CollateralAmount { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<FlexibleLoanRepayRepaymentType>))]
public readonly struct FlexibleLoanRepayRepaymentType : IExtensibleValue<FlexibleLoanRepayRepaymentType>, IEquatable<FlexibleLoanRepayRepaymentType>
{
    private readonly string? _value;

    public FlexibleLoanRepayRepaymentType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static FlexibleLoanRepayRepaymentType RepaymentType1 { get; } = new("1");

    public static FlexibleLoanRepayRepaymentType RepaymentType2 { get; } = new("2");

    static FlexibleLoanRepayRepaymentType IExtensibleValue<FlexibleLoanRepayRepaymentType>.Create(string value) => new(value);

    public static bool operator ==(FlexibleLoanRepayRepaymentType left, FlexibleLoanRepayRepaymentType right) => left.Equals(right);

    public static bool operator !=(FlexibleLoanRepayRepaymentType left, FlexibleLoanRepayRepaymentType right) => !left.Equals(right);

    public static implicit operator FlexibleLoanRepayRepaymentType(string value) => new(value);

    public static FlexibleLoanRepayRepaymentType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is FlexibleLoanRepayRepaymentType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(FlexibleLoanRepayRepaymentType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class FlexibleLoanRepayRequest
{
    public required string LoanCoin { get; init; }

    public required string CollateralCoin { get; init; }

    public required decimal RepayAmount { get; init; }

    /// <summary>
    /// TRUE: Return extra collateral to spot account; FALSE: Keep extra collateral in the order and lower
    /// LTV.
    /// </summary>
    public bool? CollateralReturn { get; init; }

    /// <summary>TRUE: Full repayment; FALSE: Partial repayment based on loan amount</summary>
    public bool? FullRepayment { get; init; }

    /// <summary>1: Repayment with loan asset; 2: Repayment with collateral</summary>
    public FlexibleLoanRepayRepaymentType? RepaymentType { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetFlexibleLoanAssetsDataRequest
{
    public string? LoanCoin { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetFlexibleLoanBorrowHistoryRequest
{
    public string? LoanCoin { get; init; }

    public string? CollateralCoin { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Current querying page</summary>
    public long? Current { get; init; }

    /// <summary>Number of records to return</summary>
    public long? Limit { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetFlexibleLoanCollateralAssetsDataRequest
{
    public string? CollateralCoin { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetFlexibleLoanInterestRateHistoryRequest
{
    public required string Coin { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public required long RecvWindow { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Current querying page</summary>
    public long? Current { get; init; }

    /// <summary>Number of records to return</summary>
    public long? Limit { get; init; }
}

public sealed class GetFlexibleLoanLiquidationHistoryRequest
{
    public string? LoanCoin { get; init; }

    public string? CollateralCoin { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Current querying page</summary>
    public long? Current { get; init; }

    /// <summary>Number of records to return</summary>
    public long? Limit { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetFlexibleLoanLtvAdjustmentHistoryRequest
{
    public string? LoanCoin { get; init; }

    public string? CollateralCoin { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Current querying page</summary>
    public long? Current { get; init; }

    /// <summary>Number of records to return</summary>
    public long? Limit { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetFlexibleLoanOngoingOrdersRequest
{
    public string? LoanCoin { get; init; }

    public string? CollateralCoin { get; init; }

    /// <summary>Current querying page</summary>
    public long? Current { get; init; }

    /// <summary>Number of records to return</summary>
    public long? Limit { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetFlexibleLoanRepaymentHistoryRequest
{
    public string? LoanCoin { get; init; }

    public string? CollateralCoin { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Current querying page</summary>
    public long? Current { get; init; }

    /// <summary>Number of records to return</summary>
    public long? Limit { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class CryptoLoanRestApi
{

    /// <summary>Check Collateral Flexible Repay Rate (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get the latest rate of collateral coin/loan coin when using collateral repay.</para>
    /// <para>Weight(IP): 6000</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Rate limit: 1 request per second per account.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CheckCollateralRepayRateResponse>> CheckCollateralRepayRateAsync(CheckCollateralRepayRateRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v2/loan/flexible/repay/rate", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CheckCollateralRepayRateResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("loanCoin", request.LoanCoin);
        r.Query("collateralCoin", request.CollateralCoin);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, CryptoLoanRestApiJson.Default.CheckCollateralRepayRateResponse, cancellationToken);
    }

    /// <summary>Flexible Loan Adjust LTV (TRADE)</summary>
    /// <remarks>
    /// <para>Flexible Loan Adjust LTV</para>
    /// <para>Weight(UID): 6000</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- API key needs Spot &amp; Margin Trading permission for this endpoint.</para>
    /// <para>
    /// - Rate limit: 1 request per second per loan position (account + loan coin + collateral coin
    /// combination).
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<FlexibleLoanAdjustLtvResponse>> FlexibleLoanAdjustLtvAsync(FlexibleLoanAdjustLtvRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v2/loan/flexible/adjust/ltv", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<FlexibleLoanAdjustLtvResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("loanCoin", request.LoanCoin);
        r.Query("collateralCoin", request.CollateralCoin);
        r.Query("adjustmentAmount", request.AdjustmentAmount);
        r.Query("direction", request.Direction);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, CryptoLoanRestApiJson.Default.FlexibleLoanAdjustLtvResponse, cancellationToken);
    }

    /// <summary>Flexible Loan Borrow (TRADE)</summary>
    /// <remarks>
    /// <para>Borrow Flexible Loan</para>
    /// <para>Weight(IP): 6000</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- This endpoint is available for both master and sub-accounts.</para>
    /// <para>- You can customize LTV by entering loanAmount and collateralAmount.</para>
    /// <para>- Rate limit: 1 request per second per account.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<FlexibleLoanBorrowResponse>> FlexibleLoanBorrowAsync(FlexibleLoanBorrowRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v2/loan/flexible/borrow", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<FlexibleLoanBorrowResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("loanCoin", request.LoanCoin);
        r.Query("collateralCoin", request.CollateralCoin);
        r.Query("loanAmount", request.LoanAmount);
        r.Query("collateralAmount", request.CollateralAmount);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, CryptoLoanRestApiJson.Default.FlexibleLoanBorrowResponse, cancellationToken);
    }

    /// <summary>Flexible Loan Repay (TRADE)</summary>
    /// <remarks>
    /// <para>Flexible Loan Repay</para>
    /// <para>Weight(IP): 6000</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- repayAmount is mandatory even when fullRepayment = FALSE.</para>
    /// <para>
    /// - Rate limit: 1 request per second per loan position (account + loan coin + collateral coin
    /// combination).
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<FlexibleLoanRepayResponse>> FlexibleLoanRepayAsync(FlexibleLoanRepayRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v2/loan/flexible/repay", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<FlexibleLoanRepayResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("loanCoin", request.LoanCoin);
        r.Query("collateralCoin", request.CollateralCoin);
        r.Query("repayAmount", request.RepayAmount);
        r.Query("collateralReturn", request.CollateralReturn);
        r.Query("fullRepayment", request.FullRepayment);
        r.Query("repaymentType", request.RepaymentType);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, CryptoLoanRestApiJson.Default.FlexibleLoanRepayResponse, cancellationToken);
    }

    /// <summary>Get Flexible Loan Assets Data (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Get interest rate and borrow limit of flexible loanable assets. The borrow limit is shown in USD
    /// value.
    /// </para>
    /// <para>Weight(IP): 400</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Rate limit: 1 request per second per account.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetFlexibleLoanAssetsDataResponse>> GetFlexibleLoanAssetsDataAsync(GetFlexibleLoanAssetsDataRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v2/loan/flexible/loanable/data", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("loanCoin", request.LoanCoin);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, CryptoLoanRestApiJson.Default.GetFlexibleLoanAssetsDataResponse, cancellationToken);
    }

    /// <summary>Get Flexible Loan Borrow History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Flexible Loan Borrow History.</para>
    /// <para>Weight(IP): 400</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If startTime and endTime are not sent, the recent 90-day data is returned.</para>
    /// <para>- The max interval between startTime and endTime is 180 days.</para>
    /// <para>- Rate limit: 5 requests per second per account.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetFlexibleLoanBorrowHistoryResponse>> GetFlexibleLoanBorrowHistoryAsync(GetFlexibleLoanBorrowHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v2/loan/flexible/borrow/history", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("loanCoin", request.LoanCoin);
        r.Query("collateralCoin", request.CollateralCoin);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, CryptoLoanRestApiJson.Default.GetFlexibleLoanBorrowHistoryResponse, cancellationToken);
    }

    /// <summary>Get Flexible Loan Collateral Assets Data (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Get LTV information and collateral limit of flexible loan's collateral assets. The collateral limit
    /// is shown in USD value.
    /// </para>
    /// <para>Weight(IP): 400</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Rate limit: 1 request per second per account.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetFlexibleLoanCollateralAssetsDataResponse>> GetFlexibleLoanCollateralAssetsDataAsync(GetFlexibleLoanCollateralAssetsDataRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v2/loan/flexible/collateral/data", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("collateralCoin", request.CollateralCoin);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, CryptoLoanRestApiJson.Default.GetFlexibleLoanCollateralAssetsDataResponse, cancellationToken);
    }

    /// <summary>Get Flexible Loan Interest Rate History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Check Flexible Loan interest rate history</para>
    /// <para>Weight(IP): 400</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If startTime and endTime are not sent, the recent 90-day data is returned.</para>
    /// <para>- The max interval between startTime and endTime is 90 days.</para>
    /// <para>- Time is based on UTC+0.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetFlexibleLoanInterestRateHistoryResponse>> GetFlexibleLoanInterestRateHistoryAsync(GetFlexibleLoanInterestRateHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v2/loan/interestRateHistory", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetFlexibleLoanInterestRateHistoryResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("coin", request.Coin);
        r.Query("recvWindow", request.RecvWindow);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("limit", request.Limit);
        return _client.SendAsync(r, CryptoLoanRestApiJson.Default.GetFlexibleLoanInterestRateHistoryResponse, cancellationToken);
    }

    /// <summary>Get Flexible Loan Liquidation History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Flexible Loan Liquidation History</para>
    /// <para>Weight(IP): 400</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Rate limit: 1 request per second per account.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetFlexibleLoanLiquidationHistoryResponse>> GetFlexibleLoanLiquidationHistoryAsync(GetFlexibleLoanLiquidationHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v2/loan/flexible/liquidation/history", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("loanCoin", request.LoanCoin);
        r.Query("collateralCoin", request.CollateralCoin);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, CryptoLoanRestApiJson.Default.GetFlexibleLoanLiquidationHistoryResponse, cancellationToken);
    }

    /// <summary>Get Flexible Loan LTV Adjustment History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Flexible Loan LTV Adjustment History.</para>
    /// <para>Weight(UID): 400</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If startTime and endTime are not sent, the recent 90-day data is returned.</para>
    /// <para>- The max interval between startTime and endTime is 180 days.</para>
    /// <para>- Rate limit: 5 requests per second per account.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetFlexibleLoanLtvAdjustmentHistoryResponse>> GetFlexibleLoanLtvAdjustmentHistoryAsync(GetFlexibleLoanLtvAdjustmentHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v2/loan/flexible/ltv/adjustment/history", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("loanCoin", request.LoanCoin);
        r.Query("collateralCoin", request.CollateralCoin);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, CryptoLoanRestApiJson.Default.GetFlexibleLoanLtvAdjustmentHistoryResponse, cancellationToken);
    }

    /// <summary>Get Flexible Loan Ongoing Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Flexible Loan Ongoing Orders</para>
    /// <para>Weight(IP): 300</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Rate limit: 10 requests per second per account.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetFlexibleLoanOngoingOrdersResponse>> GetFlexibleLoanOngoingOrdersAsync(GetFlexibleLoanOngoingOrdersRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v2/loan/flexible/ongoing/orders", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("loanCoin", request.LoanCoin);
        r.Query("collateralCoin", request.CollateralCoin);
        r.Query("current", request.Current);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, CryptoLoanRestApiJson.Default.GetFlexibleLoanOngoingOrdersResponse, cancellationToken);
    }

    /// <summary>Get Flexible Loan Repayment History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Flexible Loan Repayment History.</para>
    /// <para>Weight(IP): 400</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If startTime and endTime are not sent, the recent 90-day data is returned.</para>
    /// <para>- The max interval between startTime and endTime is 180 days.</para>
    /// <para>- Rate limit: 5 requests per second per account.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetFlexibleLoanRepaymentHistoryResponse>> GetFlexibleLoanRepaymentHistoryAsync(GetFlexibleLoanRepaymentHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v2/loan/flexible/repay/history", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("loanCoin", request.LoanCoin);
        r.Query("collateralCoin", request.CollateralCoin);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, CryptoLoanRestApiJson.Default.GetFlexibleLoanRepaymentHistoryResponse, cancellationToken);
    }
}
