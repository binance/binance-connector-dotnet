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

namespace Binance.SubAccount.RestApi;

public sealed class FuturesTransferForSubAccountRequest
{
    public required string Email { get; init; }

    /// <summary>The asset being transferred</summary>
    public required string Asset { get; init; }

    /// <summary>The amount to be transferred</summary>
    public required decimal Amount { get; init; }

    /// <summary>
    /// 1: transfer from subaccount's spot account to its USDT-margined futures account 2: transfer from
    /// subaccount's USDT-margined futures account to its spot account 3: transfer from subaccount's spot
    /// account to its COIN-margined futures account 4: transfer from subaccount's COIN-margined futures
    /// account to its spot account
    /// </summary>
    public required long Type { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetDetailOnSubAccountsFuturesAccountRequest
{
    public required string Email { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetDetailOnSubAccountsFuturesAccountV2Request
{
    public required string Email { get; init; }

    /// <summary>1: USDT-margined Futures，2: Coin-margined Futures</summary>
    public required long FuturesType { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetDetailOnSubAccountsMarginAccountRequest
{
    public required string Email { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<GetMovePositionHistoryForSubAccountProductType>))]
public readonly struct GetMovePositionHistoryForSubAccountProductType : IExtensibleValue<GetMovePositionHistoryForSubAccountProductType>, IEquatable<GetMovePositionHistoryForSubAccountProductType>
{
    private readonly string? _value;

    public GetMovePositionHistoryForSubAccountProductType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static GetMovePositionHistoryForSubAccountProductType Um { get; } = new("UM");

    public static GetMovePositionHistoryForSubAccountProductType Option { get; } = new("OPTION");

    static GetMovePositionHistoryForSubAccountProductType IExtensibleValue<GetMovePositionHistoryForSubAccountProductType>.Create(string value) => new(value);

    public static bool operator ==(GetMovePositionHistoryForSubAccountProductType left, GetMovePositionHistoryForSubAccountProductType right) => left.Equals(right);

    public static bool operator !=(GetMovePositionHistoryForSubAccountProductType left, GetMovePositionHistoryForSubAccountProductType right) => !left.Equals(right);

    public static implicit operator GetMovePositionHistoryForSubAccountProductType(string value) => new(value);

    public static GetMovePositionHistoryForSubAccountProductType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is GetMovePositionHistoryForSubAccountProductType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(GetMovePositionHistoryForSubAccountProductType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class GetMovePositionHistoryForSubAccountRequest
{
    public required string Symbol { get; init; }

    public required long Page { get; init; }

    /// <summary>Max 100.</summary>
    public required long Rows { get; init; }

    /// <summary>Default UM.</summary>
    public GetMovePositionHistoryForSubAccountProductType? ProductType { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetSubAccountDepositAddressRequest
{
    public required string Email { get; init; }

    public required string Coin { get; init; }

    /// <summary>networks can be found in GET /sapi/v1/capital/deposit/address</summary>
    public string? Network { get; init; }

    public decimal? Amount { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetSubAccountDepositHistoryRequest
{
    public required string Email { get; init; }

    /// <summary>Default false, return sourceAddress field when set to true</summary>
    public bool? IncludeSource { get; init; }

    public string? Coin { get; init; }

    /// <summary>
    /// Deposit status: 0=pending, 6=credited but cannot withdraw, 7=wrong deposit, 8=waiting user
    /// confirmation, 1=success.
    /// </summary>
    public long? Status { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    public long? Limit { get; init; }

    public long? Offset { get; init; }

    public long? RecvWindow { get; init; }

    public string? TxId { get; init; }
}

public sealed class GetSummaryOfSubAccountsFuturesAccountRequest
{
    public required long Page { get; init; }

    public required long Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetSummaryOfSubAccountsFuturesAccountV2Request
{
    /// <summary>1: USDT-margined Futures，2: Coin-margined Futures</summary>
    public required long FuturesType { get; init; }

    public long? Page { get; init; }

    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetSummaryOfSubAccountsMarginAccountRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class MarginTransferForSubAccountRequest
{
    public required string Email { get; init; }

    /// <summary>The asset being transferred</summary>
    public required string Asset { get; init; }

    /// <summary>The amount to be transferred</summary>
    public required decimal Amount { get; init; }

    /// <summary>
    /// 1: transfer from subaccount's spot account to margin account 2: transfer from subaccount's margin
    /// account to its spot account
    /// </summary>
    public required long Type { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<MovePositionForSubAccountProductType>))]
public readonly struct MovePositionForSubAccountProductType : IExtensibleValue<MovePositionForSubAccountProductType>, IEquatable<MovePositionForSubAccountProductType>
{
    private readonly string? _value;

    public MovePositionForSubAccountProductType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MovePositionForSubAccountProductType Um { get; } = new("UM");

    public static MovePositionForSubAccountProductType Option { get; } = new("OPTION");

    static MovePositionForSubAccountProductType IExtensibleValue<MovePositionForSubAccountProductType>.Create(string value) => new(value);

    public static bool operator ==(MovePositionForSubAccountProductType left, MovePositionForSubAccountProductType right) => left.Equals(right);

    public static bool operator !=(MovePositionForSubAccountProductType left, MovePositionForSubAccountProductType right) => !left.Equals(right);

    public static implicit operator MovePositionForSubAccountProductType(string value) => new(value);

    public static MovePositionForSubAccountProductType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MovePositionForSubAccountProductType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MovePositionForSubAccountProductType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class MovePositionForSubAccountRequest
{
    public required string FromUserEmail { get; init; }

    public required string ToUserEmail { get; init; }

    /// <summary>A single request cannot mix UM and OPTION positions.</summary>
    public required MovePositionForSubAccountProductType ProductType { get; init; }

    /// <summary>
    /// Max 10 positions supported. When input request parameter,orderArgs.symbol should be STRING,
    /// orderArgs.quantity should be BIGDECIMAL, and orderArgs.positionSide should be STRING, positionSide
    /// support BOTH,LONG and SHORT. Each entry should be like
    /// orderArgs[0].symbol=BTCUSDT,orderArgs[0].quantity=0.001,orderArgs[0].positionSide=BOTH. Example of
    /// the request parameter array: orderArgs[0].symbol=BTCUSDT orderArgs[0].quantity=0.001
    /// orderArgs[0].positionSide=BOTH orderArgs[1].symbol=ETHUSDT orderArgs[1].quantity=0.01
    /// orderArgs[1].positionSide=BOTH
    /// </summary>
    public required List<MovePositionForSubAccountOrderArgsParameterInner> OrderArgs { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QuerySubAccountAssetsRequest
{
    public required string Email { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QuerySubAccountAssetsAssetManagementRequest
{
    public required string Email { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QuerySubAccountFuturesAssetTransferHistoryRequest
{
    public required string Email { get; init; }

    /// <summary>1: USDT-margined Futures，2: Coin-margined Futures</summary>
    public required long FuturesType { get; init; }

    /// <summary>Cannot be earlier than 1 month ago</summary>
    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    public long? Page { get; init; }

    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QuerySubAccountSpotAssetTransferHistoryRequest
{
    public string? FromEmail { get; init; }

    public string? ToEmail { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    public long? Page { get; init; }

    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QuerySubAccountSpotAssetsSummaryRequest
{
    /// <summary>Managed sub-account email</summary>
    public string? Email { get; init; }

    public long? Page { get; init; }

    public long? Size { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryUniversalTransferHistoryRequest
{
    public string? FromEmail { get; init; }

    public string? ToEmail { get; init; }

    public string? ClientTranId { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    public long? Page { get; init; }

    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class SubAccountFuturesAssetTransferRequest
{
    /// <summary>Sender email</summary>
    public required string FromEmail { get; init; }

    /// <summary>Recipient email</summary>
    public required string ToEmail { get; init; }

    /// <summary>1: USDT-margined Futures，2: Coin-margined Futures</summary>
    public required long FuturesType { get; init; }

    public required string Asset { get; init; }

    public required decimal Amount { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class SubAccountTransferHistoryRequest
{
    /// <summary>If not sent, result of all assets will be returned</summary>
    public string? Asset { get; init; }

    /// <summary>1: transfer in, 2: transfer out</summary>
    public long? Type { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    public long? Limit { get; init; }

    /// <summary>
    /// Default False, return PROCESS and SUCCESS status history; If True,return PROCESS and SUCCESS and
    /// FAILURE status history
    /// </summary>
    public bool? ReturnFailHistory { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class TransferToMasterRequest
{
    public required string Asset { get; init; }

    public required decimal Amount { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class TransferToSubAccountOfSameMasterRequest
{
    public required string ToEmail { get; init; }

    public required string Asset { get; init; }

    public required decimal Amount { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<UniversalTransferFromAccountType>))]
public readonly struct UniversalTransferFromAccountType : IExtensibleValue<UniversalTransferFromAccountType>, IEquatable<UniversalTransferFromAccountType>
{
    private readonly string? _value;

    public UniversalTransferFromAccountType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static UniversalTransferFromAccountType Spot { get; } = new("SPOT");

    public static UniversalTransferFromAccountType UsdtFuture { get; } = new("USDT_FUTURE");

    public static UniversalTransferFromAccountType CoinFuture { get; } = new("COIN_FUTURE");

    public static UniversalTransferFromAccountType Margin { get; } = new("MARGIN");

    public static UniversalTransferFromAccountType IsolatedMargin { get; } = new("ISOLATED_MARGIN");

    static UniversalTransferFromAccountType IExtensibleValue<UniversalTransferFromAccountType>.Create(string value) => new(value);

    public static bool operator ==(UniversalTransferFromAccountType left, UniversalTransferFromAccountType right) => left.Equals(right);

    public static bool operator !=(UniversalTransferFromAccountType left, UniversalTransferFromAccountType right) => !left.Equals(right);

    public static implicit operator UniversalTransferFromAccountType(string value) => new(value);

    public static UniversalTransferFromAccountType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is UniversalTransferFromAccountType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(UniversalTransferFromAccountType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<UniversalTransferToAccountType>))]
public readonly struct UniversalTransferToAccountType : IExtensibleValue<UniversalTransferToAccountType>, IEquatable<UniversalTransferToAccountType>
{
    private readonly string? _value;

    public UniversalTransferToAccountType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static UniversalTransferToAccountType Spot { get; } = new("SPOT");

    public static UniversalTransferToAccountType UsdtFuture { get; } = new("USDT_FUTURE");

    public static UniversalTransferToAccountType CoinFuture { get; } = new("COIN_FUTURE");

    public static UniversalTransferToAccountType Margin { get; } = new("MARGIN");

    public static UniversalTransferToAccountType IsolatedMargin { get; } = new("ISOLATED_MARGIN");

    static UniversalTransferToAccountType IExtensibleValue<UniversalTransferToAccountType>.Create(string value) => new(value);

    public static bool operator ==(UniversalTransferToAccountType left, UniversalTransferToAccountType right) => left.Equals(right);

    public static bool operator !=(UniversalTransferToAccountType left, UniversalTransferToAccountType right) => !left.Equals(right);

    public static implicit operator UniversalTransferToAccountType(string value) => new(value);

    public static UniversalTransferToAccountType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is UniversalTransferToAccountType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(UniversalTransferToAccountType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class UniversalTransferRequest
{
    public required UniversalTransferFromAccountType FromAccountType { get; init; }

    public required UniversalTransferToAccountType ToAccountType { get; init; }

    public required string Asset { get; init; }

    public required decimal Amount { get; init; }

    public string? FromEmail { get; init; }

    public string? ToEmail { get; init; }

    /// <summary>Must be unique</summary>
    public string? ClientTranId { get; init; }

    /// <summary>Only supported under ISOLATED_MARGIN type</summary>
    public string? Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed partial class SubAccountRestApi
{

    /// <summary>Futures Transfer for Sub-account (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Futures Transfer for Sub-account</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>
    /// - You need to open Enable Spot &amp; Margin Trading permission for the API Key which requests this
    /// endpoint.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<FuturesTransferForSubAccountResponse>> FuturesTransferForSubAccountAsync(FuturesTransferForSubAccountRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/sub-account/futures/transfer", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<FuturesTransferForSubAccountResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("email", request.Email);
        r.Query("asset", request.Asset);
        r.Query("amount", request.Amount);
        r.Query("type", request.Type);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.FuturesTransferForSubAccountResponse, cancellationToken);
    }

    /// <summary>Get Detail on Sub-account's Futures Account (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Detail on Sub-account's Futures Account</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetDetailOnSubAccountsFuturesAccountResponse>> GetDetailOnSubAccountsFuturesAccountAsync(GetDetailOnSubAccountsFuturesAccountRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/sub-account/futures/account", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetDetailOnSubAccountsFuturesAccountResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("email", request.Email);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.GetDetailOnSubAccountsFuturesAccountResponse, cancellationToken);
    }

    /// <summary>Get Detail on Sub-account's Futures Account V2 (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Detail on Sub-account's Futures Account</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetDetailOnSubAccountsFuturesAccountV2Response>> GetDetailOnSubAccountsFuturesAccountV2Async(GetDetailOnSubAccountsFuturesAccountV2Request request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v2/sub-account/futures/account", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetDetailOnSubAccountsFuturesAccountV2Response>>(new ArgumentNullException(nameof(request)));
        r.Query("email", request.Email);
        r.Query("futuresType", request.FuturesType);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.GetDetailOnSubAccountsFuturesAccountV2Response, cancellationToken);
    }

    /// <summary>Get Detail on Sub-account's Margin Account (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Detail on Sub-account's Margin Account</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetDetailOnSubAccountsMarginAccountResponse>> GetDetailOnSubAccountsMarginAccountAsync(GetDetailOnSubAccountsMarginAccountRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/sub-account/margin/account", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetDetailOnSubAccountsMarginAccountResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("email", request.Email);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.GetDetailOnSubAccountsMarginAccountResponse, cancellationToken);
    }

    /// <summary>Get Move Position History for Sub-account (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query move position history</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>
    /// - If startTime and endTime are both omitted, records from the last 90 days are returned by default
    /// (up to 100 records).
    /// </para>
    /// <para>
    /// - If startTime is sent and endTime is omitted, records in [max(startTime, now-90d), now] are
    /// returned.
    /// </para>
    /// <para>
    /// - If startTime is omitted and endTime is sent, records in [max(now, endTime-90d), endTime] are
    /// returned.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetMovePositionHistoryForSubAccountResponse>> GetMovePositionHistoryForSubAccountAsync(GetMovePositionHistoryForSubAccountRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/sub-account/futures/move-position", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetMovePositionHistoryForSubAccountResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("page", request.Page);
        r.Query("rows", request.Rows);
        r.Query("productType", request.ProductType);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.GetMovePositionHistoryForSubAccountResponse, cancellationToken);
    }

    /// <summary>Get Sub-account Deposit Address (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Fetch sub-account deposit address</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- amount needs to be sent if using LIGHTNING network</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetSubAccountDepositAddressResponse>> GetSubAccountDepositAddressAsync(GetSubAccountDepositAddressRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/capital/deposit/subAddress", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetSubAccountDepositAddressResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("email", request.Email);
        r.Query("coin", request.Coin);
        r.Query("network", request.Network);
        r.Query("amount", request.Amount);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.GetSubAccountDepositAddressResponse, cancellationToken);
    }

    /// <summary>Get Sub-account Deposit History (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Fetch sub-account deposit history</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<GetSubAccountDepositHistoryResponseInner>>> GetSubAccountDepositHistoryAsync(GetSubAccountDepositHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/capital/deposit/subHisrec", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<GetSubAccountDepositHistoryResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("email", request.Email);
        r.Query("includeSource", request.IncludeSource);
        r.Query("coin", request.Coin);
        r.Query("status", request.Status);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("offset", request.Offset);
        r.Query("recvWindow", request.RecvWindow);
        r.Query("txId", request.TxId);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.ListGetSubAccountDepositHistoryResponseInner, cancellationToken);
    }

    /// <summary>Get Summary of Sub-account's Futures Account (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Summary of Sub-account's Futures Account</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetSummaryOfSubAccountsFuturesAccountResponse>> GetSummaryOfSubAccountsFuturesAccountAsync(GetSummaryOfSubAccountsFuturesAccountRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/sub-account/futures/accountSummary", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetSummaryOfSubAccountsFuturesAccountResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("page", request.Page);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.GetSummaryOfSubAccountsFuturesAccountResponse, cancellationToken);
    }

    /// <summary>Get Summary of Sub-account's Futures Account V2 (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Summary of Sub-account's Futures Account</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetSummaryOfSubAccountsFuturesAccountV2Response>> GetSummaryOfSubAccountsFuturesAccountV2Async(GetSummaryOfSubAccountsFuturesAccountV2Request request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v2/sub-account/futures/accountSummary", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetSummaryOfSubAccountsFuturesAccountV2Response>>(new ArgumentNullException(nameof(request)));
        r.Query("futuresType", request.FuturesType);
        r.Query("page", request.Page);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.GetSummaryOfSubAccountsFuturesAccountV2Response, cancellationToken);
    }

    /// <summary>Get Summary of Sub-account's Margin Account (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Summary of Sub-account's Margin Account</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetSummaryOfSubAccountsMarginAccountResponse>> GetSummaryOfSubAccountsMarginAccountAsync(GetSummaryOfSubAccountsMarginAccountRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/sub-account/margin/accountSummary", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.GetSummaryOfSubAccountsMarginAccountResponse, cancellationToken);
    }

    /// <summary>Margin Transfer for Sub-account (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Margin Transfer for Sub-account</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>
    /// - You need to open Enable Spot &amp; Margin Trading permission for the API Key which requests this
    /// endpoint.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<MarginTransferForSubAccountResponse>> MarginTransferForSubAccountAsync(MarginTransferForSubAccountRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/sub-account/margin/transfer", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<MarginTransferForSubAccountResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("email", request.Email);
        r.Query("asset", request.Asset);
        r.Query("amount", request.Amount);
        r.Query("type", request.Type);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.MarginTransferForSubAccountResponse, cancellationToken);
    }

    /// <summary>Move Position for Sub-account (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Move position between sub-master, master-sub, or sub-sub accounts when necessary</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- You need to enable the Trading permission for the API key used to call this endpoint.</para>
    /// <para>- This function is only available for VIP levels 7-9.</para>
    /// <para>- Only master accounts can call this endpoint.</para>
    /// <para>- quantity must be a positive number.</para>
    /// <para>- Supported account types: normal account, PM PRO, PM PRO SPAN, and PM Retail.</para>
    /// <para>- The source account must have positions.</para>
    /// <para>
    /// - For orders in the same orderArgs request, if any symbol's total close position quantity exceeds
    /// current position quantity, all orders in that batch fail.
    /// </para>
    /// <para>- Only cross margin mode is supported.</para>
    /// <para>- The move position price supports MARK_PRICE only.</para>
    /// <para>- MSA is not supported.</para>
    /// <para>- Symbols configured with Reduce-Only are not supported.</para>
    /// <para>
    /// - Move Position charges a trading fee. The fee rate is based on the master account's VIP level: the
    /// source account (fromUserEmail) is the taker and pays the taker fee, and the destination account
    /// (toUserEmail) is the maker and pays the maker fee.
    /// </para>
    /// <para>- The clientOrderId of orders generated by Move Position now starts with otcCHGFE (previously otc-).</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<MovePositionForSubAccountResponse>> MovePositionForSubAccountAsync(MovePositionForSubAccountRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/sub-account/futures/move-position", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<MovePositionForSubAccountResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("fromUserEmail", request.FromUserEmail);
        r.Query("toUserEmail", request.ToUserEmail);
        r.Query("productType", request.ProductType);
        r.Query("orderArgs", Wire.Json(request.OrderArgs, SubAccountRestApiJson.Default.ListMovePositionForSubAccountOrderArgsParameterInner));
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.MovePositionForSubAccountResponse, cancellationToken);
    }

    /// <summary>Query Sub-account Assets (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Fetch sub-account assets</para>
    /// <para>Weight(UID): 60</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QuerySubAccountAssetsResponse>> QuerySubAccountAssetsAsync(QuerySubAccountAssetsRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v3/sub-account/assets", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QuerySubAccountAssetsResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("email", request.Email);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.QuerySubAccountAssetsResponse, cancellationToken);
    }

    /// <summary>Query Sub-account Assets V4 (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Fetch sub-account assets</para>
    /// <para>Weight(UID): 60</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QuerySubAccountAssetsAssetManagementResponse>> QuerySubAccountAssetsAssetManagementAsync(QuerySubAccountAssetsAssetManagementRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v4/sub-account/assets", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QuerySubAccountAssetsAssetManagementResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("email", request.Email);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.QuerySubAccountAssetsAssetManagementResponse, cancellationToken);
    }

    /// <summary>Query Sub-account Futures Asset Transfer History (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Sub-account Futures Asset Transfer History</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QuerySubAccountFuturesAssetTransferHistoryResponse>> QuerySubAccountFuturesAssetTransferHistoryAsync(QuerySubAccountFuturesAssetTransferHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/sub-account/futures/internalTransfer", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QuerySubAccountFuturesAssetTransferHistoryResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("email", request.Email);
        r.Query("futuresType", request.FuturesType);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("page", request.Page);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.QuerySubAccountFuturesAssetTransferHistoryResponse, cancellationToken);
    }

    /// <summary>Query Sub-account Spot Asset Transfer History (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Sub-account Spot Asset Transfer History</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- fromEmail and toEmail cannot be sent at the same time.</para>
    /// <para>
    /// - If both fromEmail and toEmail are omitted, records with fromEmail equal to the master account are
    /// returned by default.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QuerySubAccountSpotAssetTransferHistoryResponseInner>>> QuerySubAccountSpotAssetTransferHistoryAsync(QuerySubAccountSpotAssetTransferHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/sub-account/sub/transfer/history", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("fromEmail", request.FromEmail);
        r.Query("toEmail", request.ToEmail);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("page", request.Page);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.ListQuerySubAccountSpotAssetTransferHistoryResponseInner, cancellationToken);
    }

    /// <summary>Query Sub-account Spot Assets Summary (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get BTC valued asset summary of subaccounts.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QuerySubAccountSpotAssetsSummaryResponse>> QuerySubAccountSpotAssetsSummaryAsync(QuerySubAccountSpotAssetsSummaryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/sub-account/spotSummary", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("email", request.Email);
        r.Query("page", request.Page);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.QuerySubAccountSpotAssetsSummaryResponse, cancellationToken);
    }

    /// <summary>Query Universal Transfer History (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Universal Transfer History</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- fromEmail and toEmail cannot be sent at the same time.</para>
    /// <para>
    /// - If both fromEmail and toEmail are omitted, records with fromEmail equal to the master account are
    /// returned by default.
    /// </para>
    /// <para>- The query time range must be less than 7 days.</para>
    /// <para>- If startTime and endTime are omitted, records from the last 7 days are returned by default.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryUniversalTransferHistoryResponse>> QueryUniversalTransferHistoryAsync(QueryUniversalTransferHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/sub-account/universalTransfer", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("fromEmail", request.FromEmail);
        r.Query("toEmail", request.ToEmail);
        r.Query("clientTranId", request.ClientTranId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("page", request.Page);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.QueryUniversalTransferHistoryResponse, cancellationToken);
    }

    /// <summary>Sub-account Futures Asset Transfer (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Sub-account Futures Asset Transfer</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- A master account can transfer at most 2000 times per minute.</para>
    /// <para>- The futures wallet must have sufficient margin balance to execute the transfer.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<SubAccountFuturesAssetTransferResponse>> SubAccountFuturesAssetTransferAsync(SubAccountFuturesAssetTransferRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/sub-account/futures/internalTransfer", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<SubAccountFuturesAssetTransferResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("fromEmail", request.FromEmail);
        r.Query("toEmail", request.ToEmail);
        r.Query("futuresType", request.FuturesType);
        r.Query("asset", request.Asset);
        r.Query("amount", request.Amount);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.SubAccountFuturesAssetTransferResponse, cancellationToken);
    }

    /// <summary>Sub-account Transfer History (For Sub-account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Sub-account Transfer History</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If type is not sent, records of type 2 (transfer out) are returned by default.</para>
    /// <para>- If startTime and endTime are not sent, data from the most recent 30 days is returned.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<SubAccountTransferHistoryResponseInner>>> SubAccountTransferHistoryAsync(SubAccountTransferHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/sub-account/transfer/subUserHistory", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("asset", request.Asset);
        r.Query("type", request.Type);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("returnFailHistory", request.ReturnFailHistory);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.ListSubAccountTransferHistoryResponseInner, cancellationToken);
    }

    /// <summary>Transfer to Master (For Sub-account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Transfer to Master</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>
    /// - You need to open Enable Spot &amp; Margin Trading permission for the API Key which requests this
    /// endpoint.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<TransferToMasterResponse>> TransferToMasterAsync(TransferToMasterRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/sub-account/transfer/subToMaster", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<TransferToMasterResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("asset", request.Asset);
        r.Query("amount", request.Amount);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.TransferToMasterResponse, cancellationToken);
    }

    /// <summary>Transfer to Sub-account of Same Master (For Sub-account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Transfer to Sub-account of Same Master</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>
    /// - You need to open Enable Spot &amp; Margin Trading permission for the API Key which requests this
    /// endpoint.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<TransferToSubAccountOfSameMasterResponse>> TransferToSubAccountOfSameMasterAsync(TransferToSubAccountOfSameMasterRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/sub-account/transfer/subToSub", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<TransferToSubAccountOfSameMasterResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("toEmail", request.ToEmail);
        r.Query("asset", request.Asset);
        r.Query("amount", request.Amount);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.TransferToSubAccountOfSameMasterResponse, cancellationToken);
    }

    /// <summary>Universal Transfer (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Universal Transfer</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Weight(UID): 360</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- You need to enable the internal transfer option for the API key used to call this endpoint.</para>
    /// <para>- If fromEmail is not sent, transfer out from the master account by default.</para>
    /// <para>- If toEmail is not sent, transfer into the master account by default.</para>
    /// <para>
    /// - When fromAccountType and toAccountType are the same, at least one of fromEmail or toEmail must be
    /// sent.
    /// </para>
    /// <para>- Supported transfer scenarios:</para>
    /// <para>- SPOT -&gt; SPOT / USDT_FUTURE / COIN_FUTURE (master or sub-account).</para>
    /// <para>- SPOT / USDT_FUTURE / COIN_FUTURE -&gt; SPOT (master or sub-account).</para>
    /// <para>- Master account SPOT -&gt; sub-account MARGIN(Cross) / ISOLATED_MARGIN.</para>
    /// <para>- Sub-account MARGIN(Cross) / ISOLATED_MARGIN -&gt; master account SPOT.</para>
    /// <para>- Sub-account MARGIN(Cross) -&gt; sub-account MARGIN(Cross).</para>
    /// <para>- ALPHA -&gt; ALPHA (master or sub-account).</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<UniversalTransferResponse>> UniversalTransferAsync(UniversalTransferRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/sub-account/universalTransfer", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<UniversalTransferResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("fromAccountType", request.FromAccountType);
        r.Query("toAccountType", request.ToAccountType);
        r.Query("asset", request.Asset);
        r.Query("amount", request.Amount);
        r.Query("fromEmail", request.FromEmail);
        r.Query("toEmail", request.ToEmail);
        r.Query("clientTranId", request.ClientTranId);
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.UniversalTransferResponse, cancellationToken);
    }
}
