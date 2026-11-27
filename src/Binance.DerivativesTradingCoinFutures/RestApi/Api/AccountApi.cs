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

namespace Binance.DerivativesTradingCoinFutures.RestApi;

public sealed class AccountInformationRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class FuturesAccountBalanceRequest
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

    public static GetIncomeHistoryIncomeType FundingFee { get; } = new("FUNDING_FEE");

    public static GetIncomeHistoryIncomeType RealizedPnl { get; } = new("REALIZED_PNL");

    public static GetIncomeHistoryIncomeType Commission { get; } = new("COMMISSION");

    public static GetIncomeHistoryIncomeType InsuranceClear { get; } = new("INSURANCE_CLEAR");

    public static GetIncomeHistoryIncomeType DeliveredSettelment { get; } = new("DELIVERED_SETTELMENT");

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
    /// <summary>Symbol</summary>
    public string? Symbol { get; init; }

    /// <summary>Income type.</summary>
    public GetIncomeHistoryIncomeType? IncomeType { get; init; }

    /// <summary>Timestamp in ms to get funding from INCLUSIVE.</summary>
    public long? StartTime { get; init; }

    /// <summary>Timestamp in ms to get funding until INCLUSIVE.</summary>
    public long? EndTime { get; init; }

    /// <summary>Maximum number of records to return.</summary>
    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class NotionalBracketForPairRequest
{
    public string? Pair { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class NotionalBracketForSymbolRequest
{
    public string? Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class UserCommissionRateRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed partial class DerivativesTradingCoinFuturesRestApi
{

    /// <summary>Account Information (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get current account information.</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- for One-way Mode user, the "positions" will only show the "BOTH" positions</para>
    /// <para>- for Hedge Mode user, the "positions" will show "BOTH", "LONG", and "SHORT" positions.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<AccountInformationResponse>> AccountInformationAsync(AccountInformationRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/account", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.AccountInformationResponse, cancellationToken);
    }

    /// <summary>Futures Account Balance (USER_DATA)</summary>
    /// <remarks>
    /// <para>Check futures account balance</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<FuturesAccountBalanceResponseInner>>> FuturesAccountBalanceAsync(FuturesAccountBalanceRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/balance", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListFuturesAccountBalanceResponseInner, cancellationToken);
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
        var r = new RestRequest("GET", "/dapi/v1/positionSide/dual", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.GetCurrentPositionModeResponse, cancellationToken);
    }

    /// <summary>Get Download Id For Futures Order History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Download Id For Futures Order History</para>
    /// <para>Weight(IP): 1000</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Request Limitation is 8 times per month, shared by front end download page and rest api</para>
    /// <para>
    /// - This endpoint uses the IP rate limit bucket and costs 1000 weight per call. The maximum is 2 calls
    /// per minute; the 3rd call within the same minute will trigger a ban.
    /// </para>
    /// <para>- The time between startTime and endTime can not be longer than 1 year</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetDownloadIdForFuturesOrderHistoryResponse>> GetDownloadIdForFuturesOrderHistoryAsync(GetDownloadIdForFuturesOrderHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/order/asyn", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetDownloadIdForFuturesOrderHistoryResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.GetDownloadIdForFuturesOrderHistoryResponse, cancellationToken);
    }

    /// <summary>Get Download Id For Futures Trade History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get download id for futures trade history</para>
    /// <para>Weight(IP): 1000</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Request Limitation is 8 times per month, shared by front end download page and rest api</para>
    /// <para>
    /// - This endpoint uses the IP rate limit bucket and costs 1000 weight per call. The maximum is 2 calls
    /// per minute; the 3rd call within the same minute will trigger a ban.
    /// </para>
    /// <para>- The time between startTime and endTime can not be longer than 1 year</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetDownloadIdForFuturesTradeHistoryResponse>> GetDownloadIdForFuturesTradeHistoryAsync(GetDownloadIdForFuturesTradeHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/trade/asyn", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetDownloadIdForFuturesTradeHistoryResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.GetDownloadIdForFuturesTradeHistoryResponse, cancellationToken);
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
    /// <para>
    /// - This endpoint uses the IP rate limit bucket and costs 1000 weight per call. The maximum is 2 calls
    /// per minute; the 3rd call within the same minute will trigger a ban.
    /// </para>
    /// <para>- The time between startTime and endTime can not be longer than 1 year</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetDownloadIdForFuturesTransactionHistoryResponse>> GetDownloadIdForFuturesTransactionHistoryAsync(GetDownloadIdForFuturesTransactionHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/income/asyn", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetDownloadIdForFuturesTransactionHistoryResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.GetDownloadIdForFuturesTransactionHistoryResponse, cancellationToken);
    }

    /// <summary>Get Futures Order History Download Link by Id (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get futures order history download link by Id</para>
    /// <para>Weight(IP): 5</para>
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
        var r = new RestRequest("GET", "/dapi/v1/order/asyn/id", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetFuturesOrderHistoryDownloadLinkByIdResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("downloadId", request.DownloadId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.GetFuturesOrderHistoryDownloadLinkByIdResponse, cancellationToken);
    }

    /// <summary>Get Futures Trade Download Link by Id (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get futures trade download link by Id</para>
    /// <para>Weight(IP): 5</para>
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
        var r = new RestRequest("GET", "/dapi/v1/trade/asyn/id", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetFuturesTradeDownloadLinkByIdResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("downloadId", request.DownloadId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.GetFuturesTradeDownloadLinkByIdResponse, cancellationToken);
    }

    /// <summary>Get Futures Transaction History Download Link by Id (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get futures transaction history download link by Id</para>
    /// <para>Weight(IP): 5</para>
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
        var r = new RestRequest("GET", "/dapi/v1/income/asyn/id", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetFuturesTransactionHistoryDownloadLinkByIdResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("downloadId", request.DownloadId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.GetFuturesTransactionHistoryDownloadLinkByIdResponse, cancellationToken);
    }

    /// <summary>Get Income History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get income history</para>
    /// <para>Weight(IP): 20</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If incomeType is not sent, all kinds of flow will be returned</para>
    /// <para>- "trandId" is unique in the same "incomeType" for a user</para>
    /// <para>- The time between startTime and endTime can not be longer than 1 year</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<GetIncomeHistoryResponseInner>>> GetIncomeHistoryAsync(GetIncomeHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/income", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("incomeType", request.IncomeType);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListGetIncomeHistoryResponseInner, cancellationToken);
    }

    /// <summary>Notional Bracket for Pair (USER_DATA)</summary>
    /// <remarks>
    /// <para>Not recommended to continue using this v1 endpoint</para>
    /// <para>
    /// Get the pair's default notional bracket list, may return ambiguous values when there have been
    /// multiple different symbol brackets under the pair, suggest using the following GET
    /// /dapi/v2/leverageBracket query instead to get the specific symbol notional bracket list.
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<NotionalBracketForPairResponseInner>>> NotionalBracketForPairAsync(NotionalBracketForPairRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/leverageBracket", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("pair", request.Pair);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListNotionalBracketForPairResponseInner, cancellationToken);
    }

    /// <summary>Notional Bracket for Symbol (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get the symbol's notional bracket list.</para>
    /// <para>Weight: 1 (after CM migration: 1 with symbol / 2 without symbol)</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<NotionalBracketForSymbolResponseInner>>> NotionalBracketForSymbolAsync(NotionalBracketForSymbolRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v2/leverageBracket", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListNotionalBracketForSymbolResponseInner, cancellationToken);
    }

    /// <summary>User Commission Rate (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query user commission rate</para>
    /// <para>Weight(IP): 20</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<UserCommissionRateResponse>> UserCommissionRateAsync(UserCommissionRateRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/commissionRate", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<UserCommissionRateResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.UserCommissionRateResponse, cancellationToken);
    }
}
