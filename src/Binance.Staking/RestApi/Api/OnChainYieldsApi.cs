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

public sealed class GetOnChainYieldsLockedPersonalLeftQuotaRequest
{
    public required string ProjectId { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetOnChainYieldsLockedProductListRequest
{
    public string? Asset { get; init; }

    /// <summary>Currently querying page</summary>
    public long? Current { get; init; }

    /// <summary>Number of results per page.</summary>
    public long? Size { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetOnChainYieldsLockedProductPositionRequest
{
    public string? Asset { get; init; }

    public string? PositionId { get; init; }

    public string? ProjectId { get; init; }

    /// <summary>Currently querying page</summary>
    public long? Current { get; init; }

    /// <summary>Number of results per page.</summary>
    public long? Size { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetOnChainYieldsLockedRedemptionRecordRequest
{
    public string? PositionId { get; init; }

    public string? RedeemId { get; init; }

    public string? Asset { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Currently querying page</summary>
    public long? Current { get; init; }

    public long? Size { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetOnChainYieldsLockedRewardsHistoryRequest
{
    public string? PositionId { get; init; }

    public string? Asset { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Currently querying page</summary>
    public long? Current { get; init; }

    public long? Size { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetOnChainYieldsLockedSubscriptionPreviewRequest
{
    public required string ProjectId { get; init; }

    public required decimal Amount { get; init; }

    public bool? AutoSubscribe { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetOnChainYieldsLockedSubscriptionRecordRequest
{
    public string? PurchaseId { get; init; }

    public string? ClientId { get; init; }

    public string? Asset { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Currently querying page</summary>
    public long? Current { get; init; }

    public long? Size { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class OnChainYieldsAccountRequest
{
    /// <summary>The value cannot be greater than 60000</summary>
    public long? RecvWindow { get; init; }
}

public sealed class RedeemOnChainYieldsLockedProductRequest
{
    /// <summary>Locked product position ID</summary>
    public required string PositionId { get; init; }

    public string? ChannelId { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class SetOnChainYieldsLockedAutoSubscribeRequest
{
    public required string PositionId { get; init; }

    public required bool AutoSubscribe { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<SetOnChainYieldsLockedProductRedeemOptionRedeemTo>))]
public readonly struct SetOnChainYieldsLockedProductRedeemOptionRedeemTo : IExtensibleValue<SetOnChainYieldsLockedProductRedeemOptionRedeemTo>, IEquatable<SetOnChainYieldsLockedProductRedeemOptionRedeemTo>
{
    private readonly string? _value;

    public SetOnChainYieldsLockedProductRedeemOptionRedeemTo(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static SetOnChainYieldsLockedProductRedeemOptionRedeemTo Spot { get; } = new("SPOT");

    public static SetOnChainYieldsLockedProductRedeemOptionRedeemTo Flexible { get; } = new("FLEXIBLE");

    static SetOnChainYieldsLockedProductRedeemOptionRedeemTo IExtensibleValue<SetOnChainYieldsLockedProductRedeemOptionRedeemTo>.Create(string value) => new(value);

    public static bool operator ==(SetOnChainYieldsLockedProductRedeemOptionRedeemTo left, SetOnChainYieldsLockedProductRedeemOptionRedeemTo right) => left.Equals(right);

    public static bool operator !=(SetOnChainYieldsLockedProductRedeemOptionRedeemTo left, SetOnChainYieldsLockedProductRedeemOptionRedeemTo right) => !left.Equals(right);

    public static implicit operator SetOnChainYieldsLockedProductRedeemOptionRedeemTo(string value) => new(value);

    public static SetOnChainYieldsLockedProductRedeemOptionRedeemTo FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is SetOnChainYieldsLockedProductRedeemOptionRedeemTo other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(SetOnChainYieldsLockedProductRedeemOptionRedeemTo other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class SetOnChainYieldsLockedProductRedeemOptionRequest
{
    public required string PositionId { get; init; }

    public required SetOnChainYieldsLockedProductRedeemOptionRedeemTo RedeemTo { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<SubscribeOnChainYieldsLockedProductSourceAccount>))]
public readonly struct SubscribeOnChainYieldsLockedProductSourceAccount : IExtensibleValue<SubscribeOnChainYieldsLockedProductSourceAccount>, IEquatable<SubscribeOnChainYieldsLockedProductSourceAccount>
{
    private readonly string? _value;

    public SubscribeOnChainYieldsLockedProductSourceAccount(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static SubscribeOnChainYieldsLockedProductSourceAccount Spot { get; } = new("SPOT");

    public static SubscribeOnChainYieldsLockedProductSourceAccount Fund { get; } = new("FUND");

    public static SubscribeOnChainYieldsLockedProductSourceAccount All { get; } = new("ALL");

    static SubscribeOnChainYieldsLockedProductSourceAccount IExtensibleValue<SubscribeOnChainYieldsLockedProductSourceAccount>.Create(string value) => new(value);

    public static bool operator ==(SubscribeOnChainYieldsLockedProductSourceAccount left, SubscribeOnChainYieldsLockedProductSourceAccount right) => left.Equals(right);

    public static bool operator !=(SubscribeOnChainYieldsLockedProductSourceAccount left, SubscribeOnChainYieldsLockedProductSourceAccount right) => !left.Equals(right);

    public static implicit operator SubscribeOnChainYieldsLockedProductSourceAccount(string value) => new(value);

    public static SubscribeOnChainYieldsLockedProductSourceAccount FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is SubscribeOnChainYieldsLockedProductSourceAccount other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(SubscribeOnChainYieldsLockedProductSourceAccount other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<SubscribeOnChainYieldsLockedProductRedeemTo>))]
public readonly struct SubscribeOnChainYieldsLockedProductRedeemTo : IExtensibleValue<SubscribeOnChainYieldsLockedProductRedeemTo>, IEquatable<SubscribeOnChainYieldsLockedProductRedeemTo>
{
    private readonly string? _value;

    public SubscribeOnChainYieldsLockedProductRedeemTo(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static SubscribeOnChainYieldsLockedProductRedeemTo Spot { get; } = new("SPOT");

    public static SubscribeOnChainYieldsLockedProductRedeemTo Flexible { get; } = new("FLEXIBLE");

    static SubscribeOnChainYieldsLockedProductRedeemTo IExtensibleValue<SubscribeOnChainYieldsLockedProductRedeemTo>.Create(string value) => new(value);

    public static bool operator ==(SubscribeOnChainYieldsLockedProductRedeemTo left, SubscribeOnChainYieldsLockedProductRedeemTo right) => left.Equals(right);

    public static bool operator !=(SubscribeOnChainYieldsLockedProductRedeemTo left, SubscribeOnChainYieldsLockedProductRedeemTo right) => !left.Equals(right);

    public static implicit operator SubscribeOnChainYieldsLockedProductRedeemTo(string value) => new(value);

    public static SubscribeOnChainYieldsLockedProductRedeemTo FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is SubscribeOnChainYieldsLockedProductRedeemTo other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(SubscribeOnChainYieldsLockedProductRedeemTo other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class SubscribeOnChainYieldsLockedProductRequest
{
    public required string ProjectId { get; init; }

    public required decimal Amount { get; init; }

    public bool? AutoSubscribe { get; init; }

    public SubscribeOnChainYieldsLockedProductSourceAccount? SourceAccount { get; init; }

    /// <summary>Takes effect when Auto Subscribe is false</summary>
    public SubscribeOnChainYieldsLockedProductRedeemTo? RedeemTo { get; init; }

    public string? ChannelId { get; init; }

    public string? ClientId { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class StakingRestApi
{

    /// <summary>Get On-chain Yields Locked Personal Left Quota (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get On-chain Yields Locked Personal Left Quota</para>
    /// <para>Weight(IP): 50</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetOnChainYieldsLockedPersonalLeftQuotaResponse>> GetOnChainYieldsLockedPersonalLeftQuotaAsync(GetOnChainYieldsLockedPersonalLeftQuotaRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/onchain-yields/locked/personalLeftQuota", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetOnChainYieldsLockedPersonalLeftQuotaResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("projectId", request.ProjectId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.GetOnChainYieldsLockedPersonalLeftQuotaResponse, cancellationToken);
    }

    /// <summary>Get On-chain Yields Locked Product List (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get available On-chain Yields Locked product list</para>
    /// <para>Weight(IP): 50</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Get available On-chain Yields Locked product list</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetOnChainYieldsLockedProductListResponse>> GetOnChainYieldsLockedProductListAsync(GetOnChainYieldsLockedProductListRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/onchain-yields/locked/list", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("asset", request.Asset);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.GetOnChainYieldsLockedProductListResponse, cancellationToken);
    }

    /// <summary>Get On-chain Yields Locked Product Position (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get On-chain Yields Locked Product Position</para>
    /// <para>Weight(IP): 50</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetOnChainYieldsLockedProductPositionResponse>> GetOnChainYieldsLockedProductPositionAsync(GetOnChainYieldsLockedProductPositionRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/onchain-yields/locked/position", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("asset", request.Asset);
        r.Query("positionId", request.PositionId);
        r.Query("projectId", request.ProjectId);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.GetOnChainYieldsLockedProductPositionResponse, cancellationToken);
    }

    /// <summary>Get On-chain Yields Locked Redemption Record (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get On-chain Yields Locked Redemption Record</para>
    /// <para>Weight(IP): 50</para>
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
    public Task<RestApiResponse<GetOnChainYieldsLockedRedemptionRecordResponse>> GetOnChainYieldsLockedRedemptionRecordAsync(GetOnChainYieldsLockedRedemptionRecordRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/onchain-yields/locked/history/redemptionRecord", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("positionId", request.PositionId);
        r.Query("redeemId", request.RedeemId);
        r.Query("asset", request.Asset);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.GetOnChainYieldsLockedRedemptionRecordResponse, cancellationToken);
    }

    /// <summary>Get On-chain Yields Locked Rewards History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get On-chain Yields Locked Rewards History</para>
    /// <para>Weight(IP): 50</para>
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
    public Task<RestApiResponse<GetOnChainYieldsLockedRewardsHistoryResponse>> GetOnChainYieldsLockedRewardsHistoryAsync(GetOnChainYieldsLockedRewardsHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/onchain-yields/locked/history/rewardsRecord", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("positionId", request.PositionId);
        r.Query("asset", request.Asset);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.GetOnChainYieldsLockedRewardsHistoryResponse, cancellationToken);
    }

    /// <summary>Get On-chain Yields Locked Subscription Preview (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get On-chain Yields Locked Subscription Preview</para>
    /// <para>Weight(IP): 50</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetOnChainYieldsLockedSubscriptionPreviewResponse>> GetOnChainYieldsLockedSubscriptionPreviewAsync(GetOnChainYieldsLockedSubscriptionPreviewRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/onchain-yields/locked/subscriptionPreview", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetOnChainYieldsLockedSubscriptionPreviewResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("projectId", request.ProjectId);
        r.Query("amount", request.Amount);
        r.Query("autoSubscribe", request.AutoSubscribe);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.GetOnChainYieldsLockedSubscriptionPreviewResponse, cancellationToken);
    }

    /// <summary>Get On-chain Yields Locked Subscription Record (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get On-chain Yields Locked Subscription Record</para>
    /// <para>Weight(IP): 50</para>
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
    public Task<RestApiResponse<GetOnChainYieldsLockedSubscriptionRecordResponse>> GetOnChainYieldsLockedSubscriptionRecordAsync(GetOnChainYieldsLockedSubscriptionRecordRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/onchain-yields/locked/history/subscriptionRecord", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("purchaseId", request.PurchaseId);
        r.Query("clientId", request.ClientId);
        r.Query("asset", request.Asset);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.GetOnChainYieldsLockedSubscriptionRecordResponse, cancellationToken);
    }

    /// <summary>On-chain Yields Account (USER_DATA)</summary>
    /// <remarks>
    /// <para>On-chain Yields Account query</para>
    /// <para>Weight(IP): 50</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<OnChainYieldsAccountResponse>> OnChainYieldsAccountAsync(OnChainYieldsAccountRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/onchain-yields/account", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.OnChainYieldsAccountResponse, cancellationToken);
    }

    /// <summary>Redeem On-chain Yields Locked Product (TRADE)</summary>
    /// <remarks>
    /// <para>Redeem On-chain Yields Locked Product</para>
    /// <para>Weight(IP): 200</para>
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
    public Task<RestApiResponse<RedeemOnChainYieldsLockedProductResponse>> RedeemOnChainYieldsLockedProductAsync(RedeemOnChainYieldsLockedProductRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/onchain-yields/locked/redeem", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<RedeemOnChainYieldsLockedProductResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("positionId", request.PositionId);
        r.Query("channelId", request.ChannelId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.RedeemOnChainYieldsLockedProductResponse, cancellationToken);
    }

    /// <summary>Set On-chain Yields Locked Auto Subscribe (USER_DATA)</summary>
    /// <remarks>
    /// <para>Set On-chain Yield locked auto subscribe</para>
    /// <para>Weight(IP): 50</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<SetOnChainYieldsLockedAutoSubscribeResponse>> SetOnChainYieldsLockedAutoSubscribeAsync(SetOnChainYieldsLockedAutoSubscribeRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/onchain-yields/locked/setAutoSubscribe", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<SetOnChainYieldsLockedAutoSubscribeResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("positionId", request.PositionId);
        r.Query("autoSubscribe", request.AutoSubscribe);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.SetOnChainYieldsLockedAutoSubscribeResponse, cancellationToken);
    }

    /// <summary>Set On-chain Yields Locked Product Redeem Option (USER_DATA)</summary>
    /// <remarks>
    /// <para>Set On-chain Yields redeem option for Locked product</para>
    /// <para>Weight(IP): 50</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<SetOnChainYieldsLockedProductRedeemOptionResponse>> SetOnChainYieldsLockedProductRedeemOptionAsync(SetOnChainYieldsLockedProductRedeemOptionRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/onchain-yields/locked/setRedeemOption", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<SetOnChainYieldsLockedProductRedeemOptionResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("positionId", request.PositionId);
        r.Query("redeemTo", request.RedeemTo);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.SetOnChainYieldsLockedProductRedeemOptionResponse, cancellationToken);
    }

    /// <summary>Subscribe On-chain Yields Locked Product (TRADE)</summary>
    /// <remarks>
    /// <para>Subscribe On-chain Yields Locked Product</para>
    /// <para>Weight(IP): 200</para>
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
    public Task<RestApiResponse<SubscribeOnChainYieldsLockedProductResponse>> SubscribeOnChainYieldsLockedProductAsync(SubscribeOnChainYieldsLockedProductRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/onchain-yields/locked/subscribe", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<SubscribeOnChainYieldsLockedProductResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("projectId", request.ProjectId);
        r.Query("amount", request.Amount);
        r.Query("autoSubscribe", request.AutoSubscribe);
        r.Query("sourceAccount", request.SourceAccount);
        r.Query("redeemTo", request.RedeemTo);
        r.Query("channelId", request.ChannelId);
        r.Query("clientId", request.ClientId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.SubscribeOnChainYieldsLockedProductResponse, cancellationToken);
    }
}
