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

namespace Binance.DerivativesTradingUsdsFutures.RestApi;

public sealed class AccountInformationV2Request
{
    public long? RecvWindow { get; init; }
}

public sealed class AccountInformationV3Request
{
    public long? RecvWindow { get; init; }
}

public sealed class FuturesAccountBalanceV2Request
{
    public long? RecvWindow { get; init; }
}

public sealed class FuturesAccountBalanceV3Request
{
    public long? RecvWindow { get; init; }
}

public sealed class FuturesAccountConfigurationRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class FuturesTradingQuantitativeRulesIndicatorsRequest
{
    public string? Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetBnbBurnStatusRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class GetCurrentMultiAssetsModeRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class GetCurrentPositionModeRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class GetDownloadIdForFuturesOrderHistoryRequest
{
    /// <summary>Timestamp in ms</summary>
    public required long StartTime { get; init; }

    /// <summary>Timestamp in ms</summary>
    public required long EndTime { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetDownloadIdForFuturesTradeHistoryRequest
{
    /// <summary>Timestamp in ms</summary>
    public required long StartTime { get; init; }

    /// <summary>Timestamp in ms</summary>
    public required long EndTime { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetDownloadIdForFuturesTransactionHistoryRequest
{
    /// <summary>Timestamp in ms</summary>
    public required long StartTime { get; init; }

    /// <summary>Timestamp in ms</summary>
    public required long EndTime { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetFuturesOrderHistoryDownloadLinkByIdRequest
{
    /// <summary>get by download id api</summary>
    public required string DownloadId { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetFuturesTradeDownloadLinkByIdRequest
{
    /// <summary>get by download id api</summary>
    public required string DownloadId { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetFuturesTransactionHistoryDownloadLinkByIdRequest
{
    /// <summary>get by download id api</summary>
    public required string DownloadId { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<GetIncomeHistoryIncomeType>))]
public readonly struct GetIncomeHistoryIncomeType : IExtensibleValue<GetIncomeHistoryIncomeType>, IEquatable<GetIncomeHistoryIncomeType>
{
    private readonly string? _value;

    public GetIncomeHistoryIncomeType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static GetIncomeHistoryIncomeType Transfer { get; } = new("TRANSFER");

    public static GetIncomeHistoryIncomeType WelcomeBonus { get; } = new("WELCOME_BONUS");

    public static GetIncomeHistoryIncomeType RealizedPnl { get; } = new("REALIZED_PNL");

    public static GetIncomeHistoryIncomeType FundingFee { get; } = new("FUNDING_FEE");

    public static GetIncomeHistoryIncomeType Commission { get; } = new("COMMISSION");

    public static GetIncomeHistoryIncomeType InsuranceClear { get; } = new("INSURANCE_CLEAR");

    public static GetIncomeHistoryIncomeType ReferralKickback { get; } = new("REFERRAL_KICKBACK");

    public static GetIncomeHistoryIncomeType CommissionRebate { get; } = new("COMMISSION_REBATE");

    public static GetIncomeHistoryIncomeType ApiRebate { get; } = new("API_REBATE");

    public static GetIncomeHistoryIncomeType ContestReward { get; } = new("CONTEST_REWARD");

    public static GetIncomeHistoryIncomeType CrossCollateralTransfer { get; } = new("CROSS_COLLATERAL_TRANSFER");

    public static GetIncomeHistoryIncomeType OptionsPremiumFee { get; } = new("OPTIONS_PREMIUM_FEE");

    public static GetIncomeHistoryIncomeType OptionsSettleProfit { get; } = new("OPTIONS_SETTLE_PROFIT");

    public static GetIncomeHistoryIncomeType InternalTransfer { get; } = new("INTERNAL_TRANSFER");

    public static GetIncomeHistoryIncomeType AutoExchange { get; } = new("AUTO_EXCHANGE");

    public static GetIncomeHistoryIncomeType DeliveredSettelment { get; } = new("DELIVERED_SETTELMENT");

    public static GetIncomeHistoryIncomeType CoinSwapDeposit { get; } = new("COIN_SWAP_DEPOSIT");

    public static GetIncomeHistoryIncomeType CoinSwapWithdraw { get; } = new("COIN_SWAP_WITHDRAW");

    public static GetIncomeHistoryIncomeType PositionLimitIncreaseFee { get; } = new("POSITION_LIMIT_INCREASE_FEE");

    public static GetIncomeHistoryIncomeType StrategyUmfuturesTransfer { get; } = new("STRATEGY_UMFUTURES_TRANSFER");

    public static GetIncomeHistoryIncomeType FeeReturn { get; } = new("FEE_RETURN");

    public static GetIncomeHistoryIncomeType BfusdReward { get; } = new("BFUSD_REWARD");

    public static GetIncomeHistoryIncomeType SpecialFundingFee { get; } = new("SPECIAL_FUNDING_FEE");

    static GetIncomeHistoryIncomeType IExtensibleValue<GetIncomeHistoryIncomeType>.Create(string value) => new(value);

    public static bool operator ==(GetIncomeHistoryIncomeType left, GetIncomeHistoryIncomeType right) => left.Equals(right);

    public static bool operator !=(GetIncomeHistoryIncomeType left, GetIncomeHistoryIncomeType right) => !left.Equals(right);

    public static implicit operator GetIncomeHistoryIncomeType(string value) => new(value);

    public static GetIncomeHistoryIncomeType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is GetIncomeHistoryIncomeType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(GetIncomeHistoryIncomeType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class GetIncomeHistoryRequest
{
    /// <summary>Trading symbol.</summary>
    public string? Symbol { get; init; }

    /// <summary>Income type.</summary>
    public GetIncomeHistoryIncomeType? IncomeType { get; init; }

    /// <summary>Timestamp in milliseconds (inclusive start).</summary>
    public long? StartTime { get; init; }

    /// <summary>Timestamp in milliseconds (inclusive end).</summary>
    public long? EndTime { get; init; }

    /// <summary>Maximum number of records to return.</summary>
    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class NotionalAndLeverageBracketsRequest
{
    public string? Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryUserRateLimitRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class SymbolConfigurationRequest
{
    /// <summary>Symbol</summary>
    public string? Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class ToggleBnbBurnOnFuturesTradeRequest
{
    /// <summary>"true": Fee Discount On; "false": Fee Discount Off</summary>
    public required string FeeBurn { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class UserCommissionRateRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed partial class DerivativesTradingUsdsFuturesRestApi
{

    /// <summary>Account Information V2 (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Get current account information. User in single-asset/ multi-assets mode will see different value,
    /// see comments in response section for detail.
    /// </para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<AccountInformationV2Response>> AccountInformationV2Async(AccountInformationV2Request? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v2/account", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.AccountInformationV2Response, cancellationToken);
    }

    /// <summary>Account Information V3 (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Get current account information. User in single-asset/ multi-assets mode will see different value,
    /// see comments in response section for detail.
    /// </para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<AccountInformationV3Response>> AccountInformationV3Async(AccountInformationV3Request? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v3/account", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.AccountInformationV3Response, cancellationToken);
    }

    /// <summary>Futures Account Balance V2 (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query account balance information.</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<FuturesAccountBalanceV2ResponseInner>>> FuturesAccountBalanceV2Async(FuturesAccountBalanceV2Request? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v2/balance", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.ListFuturesAccountBalanceV2ResponseInner, cancellationToken);
    }

    /// <summary>Futures Account Balance V3 (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query account balance information.</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<FuturesAccountBalanceV2ResponseInner>>> FuturesAccountBalanceV3Async(FuturesAccountBalanceV3Request? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v3/balance", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.ListFuturesAccountBalanceV2ResponseInner, cancellationToken);
    }

    /// <summary>Futures Account Configuration (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query account configuration</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<FuturesAccountConfigurationResponse>> FuturesAccountConfigurationAsync(FuturesAccountConfigurationRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v1/accountConfig", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.FuturesAccountConfigurationResponse, cancellationToken);
    }

    /// <summary>Futures Trading Quantitative Rules Indicators (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Futures trading quantitative rules indicators, for more information on this, please refer to the
    /// Futures Trading Quantitative Rules
    /// </para>
    /// <para>Weight: - 1 for a single symbol</para>
    /// <para>- 10 when the symbol parameter is omitted</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<FuturesTradingQuantitativeRulesIndicatorsResponse>> FuturesTradingQuantitativeRulesIndicatorsAsync(FuturesTradingQuantitativeRulesIndicatorsRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v1/apiTradingStatus", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.FuturesTradingQuantitativeRulesIndicatorsResponse, cancellationToken);
    }

    /// <summary>Get BNB Burn Status (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get user's BNB Fee Discount (Fee Discount On or Fee Discount Off )</para>
    /// <para>Weight(IP): 30</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetBnbBurnStatusResponse>> GetBnbBurnStatusAsync(GetBnbBurnStatusRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v1/feeBurn", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.GetBnbBurnStatusResponse, cancellationToken);
    }

    /// <summary>Get Current Multi-Assets Mode (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get user's Multi-Assets mode (Multi-Assets Mode or Single-Asset Mode) on Every symbol</para>
    /// <para>Weight(IP): 30</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetCurrentMultiAssetsModeResponse>> GetCurrentMultiAssetsModeAsync(GetCurrentMultiAssetsModeRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v1/multiAssetsMargin", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.GetCurrentMultiAssetsModeResponse, cancellationToken);
    }

    /// <summary>Get Current Position Mode (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get user's position mode (Hedge Mode or One-way Mode ) on EVERY symbol</para>
    /// <para>Weight(IP): 30</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetCurrentPositionModeResponse>> GetCurrentPositionModeAsync(GetCurrentPositionModeRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v1/positionSide/dual", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.GetCurrentPositionModeResponse, cancellationToken);
    }

    /// <summary>Get Download Id For Futures Order History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Download Id For Futures Order History</para>
    /// <para>Weight(IP): 1000</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Request Limitation is 10 times per month, shared by front end download page and rest api</para>
    /// <para>- The time between startTime and endTime can not be longer than 1 year</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetDownloadIdForFuturesOrderHistoryResponse>> GetDownloadIdForFuturesOrderHistoryAsync(GetDownloadIdForFuturesOrderHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v1/order/asyn", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetDownloadIdForFuturesOrderHistoryResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.GetDownloadIdForFuturesOrderHistoryResponse, cancellationToken);
    }

    /// <summary>Get Download Id For Futures Trade History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get download id for futures trade history</para>
    /// <para>Weight(IP): 1000</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Request Limitation is 5 times per month, shared by front end download page and rest api</para>
    /// <para>- The time between startTime and endTime can not be longer than 1 year</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetDownloadIdForFuturesTradeHistoryResponse>> GetDownloadIdForFuturesTradeHistoryAsync(GetDownloadIdForFuturesTradeHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v1/trade/asyn", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetDownloadIdForFuturesTradeHistoryResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.GetDownloadIdForFuturesTradeHistoryResponse, cancellationToken);
    }

    /// <summary>Get Download Id For Futures Transaction History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get download id for futures transaction history</para>
    /// <para>Weight(IP): 1000</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>
    /// - The request limit is 100 times per month, shared across the front end download page and rest api,
    /// as well as between USDⓈ-M and COIN-M contracts.
    /// </para>
    /// <para>- The time between startTime and endTime can not be longer than 1 year</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetDownloadIdForFuturesTransactionHistoryResponse>> GetDownloadIdForFuturesTransactionHistoryAsync(GetDownloadIdForFuturesTransactionHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v1/income/asyn", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetDownloadIdForFuturesTransactionHistoryResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.GetDownloadIdForFuturesTransactionHistoryResponse, cancellationToken);
    }

    /// <summary>Get Futures Order History Download Link by Id (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get futures order history download link by Id</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Download link expiration: 7 days</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetFuturesOrderHistoryDownloadLinkByIdResponse>> GetFuturesOrderHistoryDownloadLinkByIdAsync(GetFuturesOrderHistoryDownloadLinkByIdRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v1/order/asyn/id", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetFuturesOrderHistoryDownloadLinkByIdResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("downloadId", request.DownloadId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.GetFuturesOrderHistoryDownloadLinkByIdResponse, cancellationToken);
    }

    /// <summary>Get Futures Trade Download Link by Id (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get futures trade download link by Id</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Download link expiration: 7 days</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetFuturesTradeDownloadLinkByIdResponse>> GetFuturesTradeDownloadLinkByIdAsync(GetFuturesTradeDownloadLinkByIdRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v1/trade/asyn/id", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetFuturesTradeDownloadLinkByIdResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("downloadId", request.DownloadId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.GetFuturesTradeDownloadLinkByIdResponse, cancellationToken);
    }

    /// <summary>Get Futures Transaction History Download Link by Id (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get futures transaction history download link by Id</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Download link expiration: 7 days</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetFuturesTransactionHistoryDownloadLinkByIdResponse>> GetFuturesTransactionHistoryDownloadLinkByIdAsync(GetFuturesTransactionHistoryDownloadLinkByIdRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v1/income/asyn/id", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetFuturesTransactionHistoryDownloadLinkByIdResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("downloadId", request.DownloadId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.GetFuturesTransactionHistoryDownloadLinkByIdResponse, cancellationToken);
    }

    /// <summary>Get Income History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query income history</para>
    /// <para>Weight(IP): 30</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If incomeType is not sent, all kinds of flow will be returned</para>
    /// <para>- If startTime and endTime are not sent, the recent 7-day data will be returned.</para>
    /// <para>- trandId is unique in the same incomeType for a user.</para>
    /// <para>- Income history only contains data for the last three months.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<GetIncomeHistoryResponseInner>>> GetIncomeHistoryAsync(GetIncomeHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v1/income", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("incomeType", request.IncomeType);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.ListGetIncomeHistoryResponseInner, cancellationToken);
    }

    /// <summary>Notional and Leverage Brackets (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query user notional and leverage bracket on speicfic symbol</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<NotionalAndLeverageBracketsResponse>> NotionalAndLeverageBracketsAsync(NotionalAndLeverageBracketsRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v1/leverageBracket", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.NotionalAndLeverageBracketsResponse, cancellationToken);
    }

    /// <summary>Query User Rate Limit (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query User Rate Limit</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryUserRateLimitResponseInner>>> QueryUserRateLimitAsync(QueryUserRateLimitRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v1/rateLimit/order", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.ListQueryUserRateLimitResponseInner, cancellationToken);
    }

    /// <summary>Symbol Configuration (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get current account symbol configuration.</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<SymbolConfigurationResponseInner>>> SymbolConfigurationAsync(SymbolConfigurationRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v1/symbolConfig", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.ListSymbolConfigurationResponseInner, cancellationToken);
    }

    /// <summary>Toggle BNB Burn On Futures Trade (TRADE)</summary>
    /// <remarks>
    /// <para>Change user's BNB Fee Discount (Fee Discount On or Fee Discount Off ) on EVERY symbol</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ToggleBnbBurnOnFuturesTradeResponse>> ToggleBnbBurnOnFuturesTradeAsync(ToggleBnbBurnOnFuturesTradeRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/fapi/v1/feeBurn", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<ToggleBnbBurnOnFuturesTradeResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("feeBurn", request.FeeBurn);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.ToggleBnbBurnOnFuturesTradeResponse, cancellationToken);
    }

    /// <summary>User Commission Rate (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get User Commission Rate</para>
    /// <para>Weight(IP): 20</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<UserCommissionRateResponse>> UserCommissionRateAsync(UserCommissionRateRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v1/commissionRate", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<UserCommissionRateResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.UserCommissionRateResponse, cancellationToken);
    }
}
