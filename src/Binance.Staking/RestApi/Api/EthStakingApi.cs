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

namespace Binance.Staking.RestApi;

public sealed class EthStakingAccountRequest
{
    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetCurrentEthStakingQuotaRequest
{
    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetEthRedemptionHistoryRequest
{
    public long? RedeemId { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Currently querying page</summary>
    public long? Current { get; init; }

    public long? Size { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetEthStakingHistoryRequest
{
    public long? PurchaseId { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Currently querying page</summary>
    public long? Current { get; init; }

    public long? Size { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetWbethRateHistoryRequest
{
    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Currently querying page</summary>
    public long? Current { get; init; }

    public long? Size { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetWbethRewardsHistoryRequest
{
    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Currently querying page</summary>
    public long? Current { get; init; }

    public long? Size { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetWbethUnwrapHistoryRequest
{
    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Currently querying page</summary>
    public long? Current { get; init; }

    public long? Size { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetWbethWrapHistoryRequest
{
    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Currently querying page</summary>
    public long? Current { get; init; }

    public long? Size { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<RedeemEthAsset>))]
public readonly struct RedeemEthAsset : IExtensibleValue<RedeemEthAsset>, IEquatable<RedeemEthAsset>
{
    private readonly string? _value;

    public RedeemEthAsset(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static RedeemEthAsset Wbeth { get; } = new("WBETH");

    public static RedeemEthAsset Beth { get; } = new("BETH");

    static RedeemEthAsset IExtensibleValue<RedeemEthAsset>.Create(string value) => new(value);

    public static bool operator ==(RedeemEthAsset left, RedeemEthAsset right) => left.Equals(right);

    public static bool operator !=(RedeemEthAsset left, RedeemEthAsset right) => !left.Equals(right);

    public static implicit operator RedeemEthAsset(string value) => new(value);

    public static RedeemEthAsset FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is RedeemEthAsset other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(RedeemEthAsset other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class RedeemEthRequest
{
    /// <summary>Amount in BETH, limit 8 decimals</summary>
    public required decimal Amount { get; init; }

    public RedeemEthAsset? Asset { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class SubscribeEthStakingRequest
{
    /// <summary>Amount in ETH, limit 4 decimals</summary>
    public required decimal Amount { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class WrapBethRequest
{
    /// <summary>Amount in BETH, limit 4 decimals</summary>
    public required decimal Amount { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class StakingRestApi
{

    /// <summary>ETH Staking account (USER_DATA)</summary>
    /// <remarks>
    /// <para>ETH Staking account</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<EthStakingAccountResponse>> EthStakingAccountAsync(EthStakingAccountRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v2/eth-staking/account", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.EthStakingAccountResponse, cancellationToken);
    }

    /// <summary>Get current ETH staking quota (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get current ETH staking quota</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetCurrentEthStakingQuotaResponse>> GetCurrentEthStakingQuotaAsync(GetCurrentEthStakingQuotaRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/eth-staking/eth/quota", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.GetCurrentEthStakingQuotaResponse, cancellationToken);
    }

    /// <summary>Get ETH redemption history (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get ETH redemption history</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- The time between startTime and endTime cannot be longer than 3 months.</para>
    /// <para>- If startTime and endTime</para>
    /// <para>are both not sent, then the last 30 days' data will be returned.</para>
    /// <para>- If startTime is sent but endTime is not</para>
    /// <para>sent, the next 30 days' data beginning from startTime will be returned.</para>
    /// <para>- If endTime is sent but</para>
    /// <para>startTime is not sent, the 30 days' data before endTime will be returned.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetEthRedemptionHistoryResponse>> GetEthRedemptionHistoryAsync(GetEthRedemptionHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/eth-staking/eth/history/redemptionHistory", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("redeemId", request.RedeemId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.GetEthRedemptionHistoryResponse, cancellationToken);
    }

    /// <summary>Get ETH staking history (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get ETH staking history</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- The time between startTime and endTime cannot be longer than 3 months.</para>
    /// <para>- If startTime and endTime</para>
    /// <para>are both not sent, then the last 30 days' data will be returned.</para>
    /// <para>- If startTime is sent but endTime is not</para>
    /// <para>sent, the next 30 days' data beginning from startTime will be returned.</para>
    /// <para>- If endTime is sent but</para>
    /// <para>startTime is not sent, the 30 days' data before endTime will be returned.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetEthStakingHistoryResponse>> GetEthStakingHistoryAsync(GetEthStakingHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/eth-staking/eth/history/stakingHistory", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("purchaseId", request.PurchaseId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.GetEthStakingHistoryResponse, cancellationToken);
    }

    /// <summary>Get WBETH Rate History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get WBETH Rate History</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- The time between startTime and endTime cannot be longer than 3 months.</para>
    /// <para>- If startTime and endTime</para>
    /// <para>are both not sent, then the last 30 days' data will be returned.</para>
    /// <para>- If startTime is sent but endTime is not</para>
    /// <para>sent, the next 30 days' data beginning from startTime will be returned.</para>
    /// <para>- If endTime is sent but</para>
    /// <para>startTime is not sent, the 30 days' data before endTime will be returned.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetWbethRateHistoryResponse>> GetWbethRateHistoryAsync(GetWbethRateHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/eth-staking/eth/history/rateHistory", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.GetWbethRateHistoryResponse, cancellationToken);
    }

    /// <summary>Get WBETH rewards history (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get WBETH rewards history</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- The time between startTime and endTime cannot be longer than 3 months.</para>
    /// <para>- If startTime and endTime</para>
    /// <para>are both not sent, then the last 30 days' data will be returned.</para>
    /// <para>- If startTime is sent but endTime is not</para>
    /// <para>sent, the next 30 days' data beginning from startTime will be returned.</para>
    /// <para>- If endTime is sent but</para>
    /// <para>startTime is not sent, the 30 days' data before endTime will be returned.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetWbethRewardsHistoryResponse>> GetWbethRewardsHistoryAsync(GetWbethRewardsHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/eth-staking/eth/history/wbethRewardsHistory", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.GetWbethRewardsHistoryResponse, cancellationToken);
    }

    /// <summary>Get WBETH unwrap history (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get WBETH unwrap history</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- The time between startTime and endTime cannot be longer than 3 months.</para>
    /// <para>- If startTime and endTime</para>
    /// <para>are both not sent, then the last 30 days' data will be returned.</para>
    /// <para>- If startTime is sent but endTime is not</para>
    /// <para>sent, the next 30 days' data beginning from startTime will be returned.</para>
    /// <para>- If endTime is sent but</para>
    /// <para>startTime is not sent, the 30 days' data before endTime will be returned.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetWbethUnwrapHistoryResponse>> GetWbethUnwrapHistoryAsync(GetWbethUnwrapHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/eth-staking/wbeth/history/unwrapHistory", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.GetWbethUnwrapHistoryResponse, cancellationToken);
    }

    /// <summary>Get WBETH wrap history (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get WBETH wrap history</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- The time between startTime and endTime cannot be longer than 3 months.</para>
    /// <para>- If startTime and endTime</para>
    /// <para>are both not sent, then the last 30 days' data will be returned.</para>
    /// <para>- If startTime is sent but endTime is not</para>
    /// <para>sent, the next 30 days' data beginning from startTime will be returned.</para>
    /// <para>- If endTime is sent but</para>
    /// <para>startTime is not sent, the 30 days' data before endTime will be returned.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetWbethWrapHistoryResponse>> GetWbethWrapHistoryAsync(GetWbethWrapHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/eth-staking/wbeth/history/wrapHistory", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.GetWbethWrapHistoryResponse, cancellationToken);
    }

    /// <summary>Redeem ETH (TRADE)</summary>
    /// <remarks>
    /// <para>Redeem WBETH or BETH and get ETH</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: TRADE</para>
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
    public Task<RestApiResponse<RedeemEthResponse>> RedeemEthAsync(RedeemEthRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/eth-staking/eth/redeem", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<RedeemEthResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("amount", request.Amount);
        r.Query("asset", request.Asset);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.RedeemEthResponse, cancellationToken);
    }

    /// <summary>Subscribe ETH Staking (TRADE)</summary>
    /// <remarks>
    /// <para>Subscribe ETH Staking</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: TRADE</para>
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
    public Task<RestApiResponse<SubscribeEthStakingResponse>> SubscribeEthStakingAsync(SubscribeEthStakingRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v2/eth-staking/eth/stake", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<SubscribeEthStakingResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("amount", request.Amount);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.SubscribeEthStakingResponse, cancellationToken);
    }

    /// <summary>Wrap BETH (TRADE)</summary>
    /// <remarks>
    /// <para>Wrap BETH</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: TRADE</para>
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
    public Task<RestApiResponse<WrapBethResponse>> WrapBethAsync(WrapBethRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/eth-staking/wbeth/wrap", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<WrapBethResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("amount", request.Amount);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.WrapBethResponse, cancellationToken);
    }
}
