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

namespace Binance.MarginTrading.RestApi;

public sealed class AdjustCrossMarginMaxLeverageRequest
{
    /// <summary>
    /// Can only adjust 3 , 5 or 10，Example: maxLeverage = 5 or 3 for Cross Margin Classic; maxLeverage=10
    /// for Cross Margin Pro 10x leverage or 20x if compliance allows.
    /// </summary>
    public required long MaxLeverage { get; init; }
}

public sealed class DisableIsolatedMarginAccountRequest
{
    public required string Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class EnableIsolatedMarginAccountRequest
{
    public required string Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetBnbBurnStatusRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class GetSummaryOfMarginAccountRequest
{
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<QueryCrossIsolatedMarginCapitalFlowType>))]
public readonly struct QueryCrossIsolatedMarginCapitalFlowType : IExtensibleValue<QueryCrossIsolatedMarginCapitalFlowType>, IEquatable<QueryCrossIsolatedMarginCapitalFlowType>
{
    private readonly string? _value;

    public QueryCrossIsolatedMarginCapitalFlowType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static QueryCrossIsolatedMarginCapitalFlowType Transfer { get; } = new("TRANSFER");

    public static QueryCrossIsolatedMarginCapitalFlowType Borrow { get; } = new("BORROW");

    public static QueryCrossIsolatedMarginCapitalFlowType Repay { get; } = new("REPAY");

    public static QueryCrossIsolatedMarginCapitalFlowType BuyIncome { get; } = new("BUY_INCOME");

    public static QueryCrossIsolatedMarginCapitalFlowType BuyExpense { get; } = new("BUY_EXPENSE");

    public static QueryCrossIsolatedMarginCapitalFlowType SellIncome { get; } = new("SELL_INCOME");

    public static QueryCrossIsolatedMarginCapitalFlowType SellExpense { get; } = new("SELL_EXPENSE");

    public static QueryCrossIsolatedMarginCapitalFlowType TradingCommission { get; } = new("TRADING_COMMISSION");

    public static QueryCrossIsolatedMarginCapitalFlowType BuyLiquidation { get; } = new("BUY_LIQUIDATION");

    public static QueryCrossIsolatedMarginCapitalFlowType SellLiquidation { get; } = new("SELL_LIQUIDATION");

    public static QueryCrossIsolatedMarginCapitalFlowType RepayLiquidation { get; } = new("REPAY_LIQUIDATION");

    public static QueryCrossIsolatedMarginCapitalFlowType OtherLiquidation { get; } = new("OTHER_LIQUIDATION");

    public static QueryCrossIsolatedMarginCapitalFlowType LiquidationFee { get; } = new("LIQUIDATION_FEE");

    public static QueryCrossIsolatedMarginCapitalFlowType SmallBalanceConvert { get; } = new("SMALL_BALANCE_CONVERT");

    public static QueryCrossIsolatedMarginCapitalFlowType CommissionReturn { get; } = new("COMMISSION_RETURN");

    public static QueryCrossIsolatedMarginCapitalFlowType SmallConvert { get; } = new("SMALL_CONVERT");

    static QueryCrossIsolatedMarginCapitalFlowType IExtensibleValue<QueryCrossIsolatedMarginCapitalFlowType>.Create(string value) => new(value);

    public static bool operator ==(QueryCrossIsolatedMarginCapitalFlowType left, QueryCrossIsolatedMarginCapitalFlowType right) => left.Equals(right);

    public static bool operator !=(QueryCrossIsolatedMarginCapitalFlowType left, QueryCrossIsolatedMarginCapitalFlowType right) => !left.Equals(right);

    public static implicit operator QueryCrossIsolatedMarginCapitalFlowType(string value) => new(value);

    public static QueryCrossIsolatedMarginCapitalFlowType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is QueryCrossIsolatedMarginCapitalFlowType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(QueryCrossIsolatedMarginCapitalFlowType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class QueryCrossIsolatedMarginCapitalFlowRequest
{
    public string? Asset { get; init; }

    /// <summary>Mandatory for Isolated data</summary>
    public string? Symbol { get; init; }

    public QueryCrossIsolatedMarginCapitalFlowType? Type { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    public long? FromId { get; init; }

    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryCrossMarginAccountDetailsRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class QueryCrossMarginFeeDataRequest
{
    /// <summary>User's current specific margin data will be returned if vipLevel is omitted</summary>
    public long? VipLevel { get; init; }

    public string? Coin { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryEnabledIsolatedMarginAccountLimitRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class QueryIsolatedMarginAccountInfoRequest
{
    public string? Symbols { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryIsolatedMarginFeeDataRequest
{
    public long? VipLevel { get; init; }

    public string? Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed partial class MarginTradingRestApi
{

    /// <summary>Adjust cross margin max leverage (USER_DATA)</summary>
    /// <remarks>
    /// <para>Adjust cross margin max leverage</para>
    /// <para>Weight(UID): 3000, 1 times/min per IP</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>
    /// - The margin level need higher than the initial risk ratio of adjusted leverage, the initial risk
    /// ratio of 3x is 1.5 , the initial risk ratio of 5x is 1.25; The detail conditions on how to switch
    /// between Cross Margin Classic and Cross Margin Pro can refer to the FAQ.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<AdjustCrossMarginMaxLeverageResponse>> AdjustCrossMarginMaxLeverageAsync(AdjustCrossMarginMaxLeverageRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/margin/max-leverage", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<AdjustCrossMarginMaxLeverageResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("maxLeverage", request.MaxLeverage);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.AdjustCrossMarginMaxLeverageResponse, cancellationToken);
    }

    /// <summary>Disable Isolated Margin Account (TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Disable isolated margin account for a specific symbol. Each trading pair can only be deactivated
    /// once every 24 hours.
    /// </para>
    /// <para>Weight(UID): 300</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<DisableIsolatedMarginAccountResponse>> DisableIsolatedMarginAccountAsync(DisableIsolatedMarginAccountRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/sapi/v1/margin/isolated/account", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<DisableIsolatedMarginAccountResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.DisableIsolatedMarginAccountResponse, cancellationToken);
    }

    /// <summary>Enable Isolated Margin Account (TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Enable isolated margin account for a specific symbol(Only supports activation of previously disabled
    /// accounts).
    /// </para>
    /// <para>Weight(UID): 300</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<EnableIsolatedMarginAccountResponse>> EnableIsolatedMarginAccountAsync(EnableIsolatedMarginAccountRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/margin/isolated/account", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<EnableIsolatedMarginAccountResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.EnableIsolatedMarginAccountResponse, cancellationToken);
    }

    /// <summary>Get BNB Burn Status (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get BNB Burn Status</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetBnbBurnStatusResponse>> GetBnbBurnStatusAsync(GetBnbBurnStatusRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/bnbBurn", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.GetBnbBurnStatusResponse, cancellationToken);
    }

    /// <summary>Get Summary of Margin account (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get personal margin level information</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetSummaryOfMarginAccountResponse>> GetSummaryOfMarginAccountAsync(GetSummaryOfMarginAccountRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/tradeCoeff", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.GetSummaryOfMarginAccountResponse, cancellationToken);
    }

    /// <summary>Query Cross Isolated Margin Capital Flow (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Cross Isolated Margin Capital Flow</para>
    /// <para>Weight(IP): 100</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Only supports querying the data of the last 90 days</para>
    /// <para>- The time between startTime and endTime cannot be longer than 7 days.</para>
    /// <para>- If both startTime and endTime are omitted, the most recent 7 days are</para>
    /// <para>queried (endTime defaults to the current time, and startTime to the current time minus 7 days).</para>
    /// <para>- If startTime is provided without endTime, endTime defaults to</para>
    /// <para>startTime plus 7 days.</para>
    /// <para>- If endTime is provided without startTime, startTime defaults to</para>
    /// <para>endTime minus 7 days.</para>
    /// <para>- If fromId is set, the data with id &gt; fromId within the queried time</para>
    /// <para>
    /// range will be returned. Otherwise the latest data within that range will be returned. fromId does
    /// not extend the time range; to retrieve older records, move startTime and endTime backwards in
    /// windows of up to 7 days.
    /// </para>
    /// <para>- To query isolated data, Symbol needs to be entered.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryCrossIsolatedMarginCapitalFlowResponseInner>>> QueryCrossIsolatedMarginCapitalFlowAsync(QueryCrossIsolatedMarginCapitalFlowRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/capital-flow", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("asset", request.Asset);
        r.Query("symbol", request.Symbol);
        r.Query("type", request.Type);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("fromId", request.FromId);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.ListQueryCrossIsolatedMarginCapitalFlowResponseInner, cancellationToken);
    }

    /// <summary>Query Cross Margin Account Details (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Cross Margin Account Details</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryCrossMarginAccountDetailsResponse>> QueryCrossMarginAccountDetailsAsync(QueryCrossMarginAccountDetailsRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/account", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.QueryCrossMarginAccountDetailsResponse, cancellationToken);
    }

    /// <summary>Query Cross Margin Fee Data (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Get cross margin fee data collection with any vip level or user's current specific data as
    /// https://www.binance.com/en/margin-fee
    /// </para>
    /// <para>Weight: 1 when coin is specified;(IP) 5 when the coin parameter is omitted(IP)</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryCrossMarginFeeDataResponseInner>>> QueryCrossMarginFeeDataAsync(QueryCrossMarginFeeDataRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/crossMarginData", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("vipLevel", request.VipLevel);
        r.Query("coin", request.Coin);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.ListQueryCrossMarginFeeDataResponseInner, cancellationToken);
    }

    /// <summary>Query Enabled Isolated Margin Account Limit (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query enabled isolated margin account limit.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryEnabledIsolatedMarginAccountLimitResponse>> QueryEnabledIsolatedMarginAccountLimitAsync(QueryEnabledIsolatedMarginAccountLimitRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/isolated/accountLimit", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.QueryEnabledIsolatedMarginAccountLimitResponse, cancellationToken);
    }

    /// <summary>Query Isolated Margin Account Info (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Isolated Margin Account Info</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If "symbols" is not sent, all isolated assets will be returned.</para>
    /// <para>- If "symbols" is sent, only the isolated assets of the sent symbols</para>
    /// <para>will be returned.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryIsolatedMarginAccountInfoResponse>> QueryIsolatedMarginAccountInfoAsync(QueryIsolatedMarginAccountInfoRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/isolated/account", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbols", request.Symbols);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.QueryIsolatedMarginAccountInfoResponse, cancellationToken);
    }

    /// <summary>Query Isolated Margin Fee Data (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Get isolated margin fee data collection with any vip level or user's current specific data as
    /// https://www.binance.com/en/margin-fee
    /// </para>
    /// <para>Weight: 1 when a single is specified;(IP) 10 when the symbol parameter is omitted(IP)</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryIsolatedMarginFeeDataResponseInner>>> QueryIsolatedMarginFeeDataAsync(QueryIsolatedMarginFeeDataRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/isolatedMarginData", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("vipLevel", request.VipLevel);
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.ListQueryIsolatedMarginFeeDataResponseInner, cancellationToken);
    }
}
