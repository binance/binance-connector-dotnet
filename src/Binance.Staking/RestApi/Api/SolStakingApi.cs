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

public sealed class ClaimBoostRewardsRequest
{
    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetBnsolRateHistoryRequest
{
    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Currently querying page</summary>
    public long? Current { get; init; }

    public long? Size { get; init; }

    /// <summary>The value cannot be greater than 60000</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetBnsolRewardsHistoryRequest
{
    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Currently querying page</summary>
    public long? Current { get; init; }

    public long? Size { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<GetBoostRewardsHistoryType>))]
public readonly struct GetBoostRewardsHistoryType : IExtensibleValue<GetBoostRewardsHistoryType>, IEquatable<GetBoostRewardsHistoryType>
{
    private readonly string? _value;

    public GetBoostRewardsHistoryType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static GetBoostRewardsHistoryType Claim { get; } = new("CLAIM");

    public static GetBoostRewardsHistoryType Distribute { get; } = new("DISTRIBUTE");

    static GetBoostRewardsHistoryType IExtensibleValue<GetBoostRewardsHistoryType>.Create(string value) => new(value);

    public static bool operator ==(GetBoostRewardsHistoryType left, GetBoostRewardsHistoryType right) => left.Equals(right);

    public static bool operator !=(GetBoostRewardsHistoryType left, GetBoostRewardsHistoryType right) => !left.Equals(right);

    public static implicit operator GetBoostRewardsHistoryType(string value) => new(value);

    public static GetBoostRewardsHistoryType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is GetBoostRewardsHistoryType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(GetBoostRewardsHistoryType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class GetBoostRewardsHistoryRequest
{
    public required GetBoostRewardsHistoryType Type { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Currently querying page</summary>
    public long? Current { get; init; }

    public long? Size { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetSolRedemptionHistoryRequest
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

public sealed class GetSolStakingHistoryRequest
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

public sealed class GetSolStakingQuotaDetailsRequest
{
    /// <summary>The value cannot be greater than 60000</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetUnclaimedRewardsRequest
{
    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class RedeemSolRequest
{
    /// <summary>Amount in BNSOL, limit 8 decimals</summary>
    public required decimal Amount { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class SolStakingAccountRequest
{
    /// <summary>The value cannot be greater than 60000</summary>
    public long? RecvWindow { get; init; }
}

public sealed class SubscribeSolStakingRequest
{
    /// <summary>Amount in SOL.</summary>
    public required decimal Amount { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class StakingRestApi
{

    /// <summary>Claim Boost Rewards (TRADE)</summary>
    /// <remarks>
    /// <para>Claim Boost APR Airdrop Rewards</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>
    /// - You need to open Enable Spot &amp; Margin Trading permission for the API Key which requests this
    /// endpoint.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ClaimBoostRewardsResponse>> ClaimBoostRewardsAsync(ClaimBoostRewardsRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/sol-staking/sol/claim", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.ClaimBoostRewardsResponse, cancellationToken);
    }

    /// <summary>Get BNSOL Rate History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get BNSOL Rate History</para>
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
    public Task<RestApiResponse<GetBnsolRateHistoryResponse>> GetBnsolRateHistoryAsync(GetBnsolRateHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/sol-staking/sol/history/rateHistory", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.GetBnsolRateHistoryResponse, cancellationToken);
    }

    /// <summary>Get BNSOL rewards history (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get BNSOL rewards history</para>
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
    public Task<RestApiResponse<GetBnsolRewardsHistoryResponse>> GetBnsolRewardsHistoryAsync(GetBnsolRewardsHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/sol-staking/sol/history/bnsolRewardsHistory", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.GetBnsolRewardsHistoryResponse, cancellationToken);
    }

    /// <summary>Get Boost Rewards History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Boost rewards history</para>
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
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetBoostRewardsHistoryResponse>> GetBoostRewardsHistoryAsync(GetBoostRewardsHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/sol-staking/sol/history/boostRewardsHistory", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetBoostRewardsHistoryResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("type", request.Type);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.GetBoostRewardsHistoryResponse, cancellationToken);
    }

    /// <summary>Get SOL redemption history (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get SOL redemption history</para>
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
    public Task<RestApiResponse<GetSolRedemptionHistoryResponse>> GetSolRedemptionHistoryAsync(GetSolRedemptionHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/sol-staking/sol/history/redemptionHistory", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("redeemId", request.RedeemId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.GetSolRedemptionHistoryResponse, cancellationToken);
    }

    /// <summary>Get SOL staking history (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get SOL staking history</para>
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
    public Task<RestApiResponse<GetSolStakingHistoryResponse>> GetSolStakingHistoryAsync(GetSolStakingHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/sol-staking/sol/history/stakingHistory", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("purchaseId", request.PurchaseId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.GetSolStakingHistoryResponse, cancellationToken);
    }

    /// <summary>Get SOL staking quota details (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get SOL staking quota</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetSolStakingQuotaDetailsResponse>> GetSolStakingQuotaDetailsAsync(GetSolStakingQuotaDetailsRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/sol-staking/sol/quota", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.GetSolStakingQuotaDetailsResponse, cancellationToken);
    }

    /// <summary>Get Unclaimed Rewards (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Unclaimed rewards</para>
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
    public Task<RestApiResponse<List<GetUnclaimedRewardsResponseInner>>> GetUnclaimedRewardsAsync(GetUnclaimedRewardsRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/sol-staking/sol/history/unclaimedRewards", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.ListGetUnclaimedRewardsResponseInner, cancellationToken);
    }

    /// <summary>Redeem SOL (TRADE)</summary>
    /// <remarks>
    /// <para>Redeem BNSOL get SOL</para>
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
    public Task<RestApiResponse<RedeemSolResponse>> RedeemSolAsync(RedeemSolRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/sol-staking/sol/redeem", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<RedeemSolResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("amount", request.Amount);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.RedeemSolResponse, cancellationToken);
    }

    /// <summary>SOL Staking account (USER_DATA)</summary>
    /// <remarks>
    /// <para>SOL Staking account</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<SolStakingAccountResponse>> SolStakingAccountAsync(SolStakingAccountRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/sol-staking/account", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.SolStakingAccountResponse, cancellationToken);
    }

    /// <summary>Subscribe SOL Staking (TRADE)</summary>
    /// <remarks>
    /// <para>Subscribe SOL Staking</para>
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
    public Task<RestApiResponse<SubscribeSolStakingResponse>> SubscribeSolStakingAsync(SubscribeSolStakingRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/sol-staking/sol/stake", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<SubscribeSolStakingResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("amount", request.Amount);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.SubscribeSolStakingResponse, cancellationToken);
    }
}
