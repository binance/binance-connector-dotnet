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

namespace Binance.Wallet.RestApi;

public sealed class AllCoinsInformationRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class DepositAddressRequest
{
    /// <summary>coin refers to the parent network address format that the address is using</summary>
    public required string Coin { get; init; }

    public string? Network { get; init; }

    public decimal? Amount { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<DepositHistoryStatus>))]
public readonly struct DepositHistoryStatus : IExtensibleValue<DepositHistoryStatus>, IEquatable<DepositHistoryStatus>
{
    private readonly string? _value;

    public DepositHistoryStatus(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static DepositHistoryStatus Status0 { get; } = new("0");

    public static DepositHistoryStatus Status1 { get; } = new("1");

    public static DepositHistoryStatus Status2 { get; } = new("2");

    public static DepositHistoryStatus Status6 { get; } = new("6");

    public static DepositHistoryStatus Status7 { get; } = new("7");

    public static DepositHistoryStatus Status8 { get; } = new("8");

    static DepositHistoryStatus IExtensibleValue<DepositHistoryStatus>.Create(string value) => new(value);

    public static bool operator ==(DepositHistoryStatus left, DepositHistoryStatus right) => left.Equals(right);

    public static bool operator !=(DepositHistoryStatus left, DepositHistoryStatus right) => !left.Equals(right);

    public static implicit operator DepositHistoryStatus(string value) => new(value);

    public static DepositHistoryStatus FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is DepositHistoryStatus other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(DepositHistoryStatus other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class DepositHistoryRequest
{
    /// <summary>return sourceAddress field when set to true</summary>
    public bool? IncludeSource { get; init; }

    public string? Coin { get; init; }

    /// <summary>
    /// 0: pending, 1: success, 2: rejected, 6: credited but cannot withdraw, 7: Wrong Deposit, 8: Waiting
    /// User confirm
    /// </summary>
    public DepositHistoryStatus? Status { get; init; }

    /// <summary>Default: 90 days from current timestamp</summary>
    public long? StartTime { get; init; }

    /// <summary>Default: present timestamp</summary>
    public long? EndTime { get; init; }

    public long? Offset { get; init; }

    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }

    public string? TxId { get; init; }
}

public sealed class FetchDepositAddressListWithNetworkRequest
{
    /// <summary>Coin name</summary>
    public required string Coin { get; init; }

    /// <summary>
    /// If network is not send, return with default network of the coin. You can get network and isDefault
    /// in networkList in the response of Get /sapi/v1/capital/config/getall
    /// </summary>
    public string? Network { get; init; }
}

public sealed class OneClickArrivalDepositApplyRequest
{
    /// <summary>Deposit record Id, priority use</summary>
    public long? DepositId { get; init; }

    /// <summary>Deposit txId, used when depositId is not specified</summary>
    public string? TxId { get; init; }

    /// <summary>Sub-accountId of Cloud user</summary>
    public string? SubAccountId { get; init; }

    /// <summary>Sub-userId of parent user</summary>
    public long? SubUserId { get; init; }
}

public sealed class WithdrawRequest
{
    public required string Coin { get; init; }

    /// <summary>Withdrawal address</summary>
    public required string Address { get; init; }

    /// <summary>Amount</summary>
    public required decimal Amount { get; init; }

    /// <summary>
    /// client side id for withdrawal, if provide here, can be used in GET /sapi/v1/capital/withdraw/history
    /// for query.
    /// </summary>
    public string? WithdrawOrderId { get; init; }

    /// <summary>Withdrawal network</summary>
    public string? Network { get; init; }

    /// <summary>Secondary address identifier for coins like XRP,XMR etc.</summary>
    public string? AddressTag { get; init; }

    /// <summary>
    /// When making internal transfer, true for returning the fee to the destination account; false for
    /// returning the fee back to the departure account. Default false.
    /// </summary>
    public bool? TransactionFeeFlag { get; init; }

    public string? Name { get; init; }

    /// <summary>
    /// The wallet type for withdraw，0-spot wallet ，1-funding wallet. Default walletType is the current
    /// "selected wallet" under wallet-&gt;Fiat and Spot/Funding-&gt;Deposit
    /// </summary>
    public long? WalletType { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class WithdrawHistoryRequest
{
    public string? Coin { get; init; }

    /// <summary>
    /// client side id for withdrawal, if provided in POST /sapi/v1/capital/withdraw/apply, can be used here
    /// for query.
    /// </summary>
    public string? WithdrawOrderId { get; init; }

    /// <summary>0(0: Email Sent, 2: Awaiting Approval 3: Rejected 4: Processing 6: Completed)</summary>
    public long? Status { get; init; }

    /// <summary>Default: 0</summary>
    public long? Offset { get; init; }

    public long? Limit { get; init; }

    /// <summary>
    /// id list returned in the response of POST /sapi/v1/capital/withdraw/apply, separated by ,
    /// </summary>
    public string? IdList { get; init; }

    /// <summary>Default: 90 days from current timestamp</summary>
    public long? StartTime { get; init; }

    /// <summary>Default: present timestamp</summary>
    public long? EndTime { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed partial class WalletRestApi
{

    /// <summary>All Coins' Information (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get information of coins (available for deposit and withdraw) for user.</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<AllCoinsInformationResponseInner>>> AllCoinsInformationAsync(AllCoinsInformationRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/capital/config/getall", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.ListAllCoinsInformationResponseInner, cancellationToken);
    }

    /// <summary>Deposit Address(supporting network) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Fetch deposit address with network.</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If network is not send, return with default network of the coin.</para>
    /// <para>
    /// - You can get network and isDefault in networkList in the response of Get
    /// /sapi/v1/capital/config/getall (HMAC SHA256).
    /// </para>
    /// <para>- amount needs to be sent if using LIGHTNING network</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<DepositAddressResponse>> DepositAddressAsync(DepositAddressRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/capital/deposit/address", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<DepositAddressResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("coin", request.Coin);
        r.Query("network", request.Network);
        r.Query("amount", request.Amount);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.DepositAddressResponse, cancellationToken);
    }

    /// <summary>Deposit History (supporting network) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Fetch deposit history.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>
    /// - Please notice the default startTime and endTime to make sure that time interval is within 0-90
    /// days.
    /// </para>
    /// <para>
    /// - If both startTime and endTime are sent, time between startTime and endTime must be less than 90
    /// days.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<DepositHistoryResponseInner>>> DepositHistoryAsync(DepositHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/capital/deposit/hisrec", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("includeSource", request.IncludeSource);
        r.Query("coin", request.Coin);
        r.Query("status", request.Status);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("offset", request.Offset);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        r.Query("txId", request.TxId);
        return _client.SendAsync(r, WalletRestApiJson.Default.ListDepositHistoryResponseInner, cancellationToken);
    }

    /// <summary>Fetch deposit address list with network (USER_DATA)</summary>
    /// <remarks>
    /// <para>Fetch deposit address list with network.</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<FetchDepositAddressListWithNetworkResponseInner>>> FetchDepositAddressListWithNetworkAsync(FetchDepositAddressListWithNetworkRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/capital/deposit/address/list", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<FetchDepositAddressListWithNetworkResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("coin", request.Coin);
        r.Query("network", request.Network);
        return _client.SendAsync(r, WalletRestApiJson.Default.ListFetchDepositAddressListWithNetworkResponseInner, cancellationToken);
    }

    /// <summary>Fetch withdraw address list (USER_DATA)</summary>
    /// <remarks>
    /// <para>Fetch withdraw address list</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<FetchWithdrawAddressListResponseInner>>> FetchWithdrawAddressListAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/capital/withdraw/address/list", signed: true, hasTimeUnit: false);
        return _client.SendAsync(r, WalletRestApiJson.Default.ListFetchWithdrawAddressListResponseInner, cancellationToken);
    }

    /// <summary>Fetch withdraw quota (USER_DATA)</summary>
    /// <remarks>
    /// <para>Fetch withdraw quota</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<FetchWithdrawQuotaResponse>> FetchWithdrawQuotaAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/capital/withdraw/quota", signed: true, hasTimeUnit: false);
        return _client.SendAsync(r, WalletRestApiJson.Default.FetchWithdrawQuotaResponse, cancellationToken);
    }

    /// <summary>One click arrival deposit apply (for expired address deposit) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Apply deposit credit for expired address (One click arrival)</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<OneClickArrivalDepositApplyResponse>> OneClickArrivalDepositApplyAsync(OneClickArrivalDepositApplyRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/capital/deposit/credit-apply", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("depositId", request.DepositId);
        r.Query("txId", request.TxId);
        r.Query("subAccountId", request.SubAccountId);
        r.Query("subUserId", request.SubUserId);
        return _client.SendAsync(r, WalletRestApiJson.Default.OneClickArrivalDepositApplyResponse, cancellationToken);
    }

    /// <summary>Withdraw (USER_DATA)</summary>
    /// <remarks>
    /// <para>Submit a withdraw request</para>
    /// <para>Weight(UID): 900</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If network not send, return with default network of the coin.</para>
    /// <para>
    /// - You can get network and isDefault in networkList of a coin in the response of Get
    /// /sapi/v1/capital/config/getall (HMAC SHA256).
    /// </para>
    /// <para>
    /// - To check if travel rule is required, by using GET /sapi/v1/localentity/questionnaire-requirements
    /// and if it returns anything other than NIL you will need update SAPI to POST
    /// /sapi/v1/localentity/withdraw/apply else you can continue POST /sapi/v1/capital/withdraw/apply.
    /// Please note that if you are required to comply to travel rule please refer to the Travel Rule SAPI.
    /// </para>
    /// <para>
    /// - "For networks that do not support memo/tag, submitting a withdrawal request with a non-empty
    /// addressTag will return error -4106 TAG_NOT_SUPPORTED_FOR_NETWORK. Please omit the addressTag field
    /// for such networks. You can check whether a network requires a tag via GET
    /// /sapi/v1/capital/config/getall: If withdrawTag = true → memo/tag is required. If withdrawTag = false
    /// → memo/tag is not supported; omit addressTag."
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<WithdrawResponse>> WithdrawAsync(WithdrawRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/capital/withdraw/apply", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<WithdrawResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("coin", request.Coin);
        r.Query("address", request.Address);
        r.Query("amount", request.Amount);
        r.Query("withdrawOrderId", request.WithdrawOrderId);
        r.Query("network", request.Network);
        r.Query("addressTag", request.AddressTag);
        r.Query("transactionFeeFlag", request.TransactionFeeFlag);
        r.Query("name", request.Name);
        r.Query("walletType", request.WalletType);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.WithdrawResponse, cancellationToken);
    }

    /// <summary>Withdraw History (supporting network) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Fetch withdraw history</para>
    /// <para>Weight(UID): 18000 (10 requests per second)</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- network may not be in the response for old withdraw.</para>
    /// <para>
    /// - Please notice the default startTime and endTime to make sure that time interval is within 0-90
    /// days.
    /// </para>
    /// <para>- If both startTime and endTimeare sent, time between startTimeand endTimemust be less than 90 days.</para>
    /// <para>- If withdrawOrderId is sent, time between startTime and endTime must be less than 7 days.</para>
    /// <para>
    /// - If withdrawOrderId is sent, startTime and endTime are not sent, will return last 7 days records by
    /// default.
    /// </para>
    /// <para>- Maximum support idList number is 45.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<WithdrawHistoryResponseInner>>> WithdrawHistoryAsync(WithdrawHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/capital/withdraw/history", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("coin", request.Coin);
        r.Query("withdrawOrderId", request.WithdrawOrderId);
        r.Query("status", request.Status);
        r.Query("offset", request.Offset);
        r.Query("limit", request.Limit);
        r.Query("idList", request.IdList);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.ListWithdrawHistoryResponseInner, cancellationToken);
    }
}
