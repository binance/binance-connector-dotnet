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

namespace Binance.SimpleEarn.RestApi;

public sealed class GetCollateralRecordRequest
{
    public string? ProductId { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Currently querying page.</summary>
    public long? Current { get; init; }

    /// <summary>Number of results per page.</summary>
    public long? Size { get; init; }

    /// <summary>The value cannot be greater than 60000 (ms)</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetFlexiblePersonalLeftQuotaRequest
{
    public required string ProductId { get; init; }

    /// <summary>The value cannot be greater than 60000 (ms)</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetFlexibleProductPositionRequest
{
    public string? Asset { get; init; }

    public string? ProductId { get; init; }

    /// <summary>Currently querying page. Starts from 1.</summary>
    public long? Current { get; init; }

    /// <summary>Number of results per page.</summary>
    public long? Size { get; init; }

    /// <summary>The value cannot be greater than 60000 (ms)</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetFlexibleRedemptionRecordRequest
{
    public string? ProductId { get; init; }

    public string? RedeemId { get; init; }

    public string? Asset { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Currently querying page. Starts from 1.</summary>
    public long? Current { get; init; }

    /// <summary>Number of results per page.</summary>
    public long? Size { get; init; }

    /// <summary>The value cannot be greater than 60000 (ms)</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<GetFlexibleRewardsHistoryType>))]
public readonly struct GetFlexibleRewardsHistoryType : IExtensibleValue<GetFlexibleRewardsHistoryType>, IEquatable<GetFlexibleRewardsHistoryType>
{
    private readonly string? _value;

    public GetFlexibleRewardsHistoryType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static GetFlexibleRewardsHistoryType Bonus { get; } = new("BONUS");

    public static GetFlexibleRewardsHistoryType Realtime { get; } = new("REALTIME");

    public static GetFlexibleRewardsHistoryType Rewards { get; } = new("REWARDS");

    public static GetFlexibleRewardsHistoryType All { get; } = new("ALL");

    static GetFlexibleRewardsHistoryType IExtensibleValue<GetFlexibleRewardsHistoryType>.Create(string value) => new(value);

    public static bool operator ==(GetFlexibleRewardsHistoryType left, GetFlexibleRewardsHistoryType right) => left.Equals(right);

    public static bool operator !=(GetFlexibleRewardsHistoryType left, GetFlexibleRewardsHistoryType right) => !left.Equals(right);

    public static implicit operator GetFlexibleRewardsHistoryType(string value) => new(value);

    public static GetFlexibleRewardsHistoryType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is GetFlexibleRewardsHistoryType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(GetFlexibleRewardsHistoryType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class GetFlexibleRewardsHistoryRequest
{
    public string? ProductId { get; init; }

    public string? Asset { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>
    /// BONUS - Bonus tiered APR, REALTIME - Real-time APR, REWARDS - Historical rewards, ALL - All types.
    /// Default: ALL
    /// </summary>
    public GetFlexibleRewardsHistoryType? Type { get; init; }

    /// <summary>Currently querying page. Starts from 1.</summary>
    public long? Current { get; init; }

    /// <summary>Number of results per page.</summary>
    public long? Size { get; init; }

    /// <summary>The value cannot be greater than 60000 (ms)</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetFlexibleSubscriptionPreviewRequest
{
    public required string ProductId { get; init; }

    public required decimal Amount { get; init; }

    /// <summary>The value cannot be greater than 60000 (ms)</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetFlexibleSubscriptionRecordRequest
{
    public string? ProductId { get; init; }

    public string? PurchaseId { get; init; }

    public string? Asset { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Currently querying page. Starts from 1.</summary>
    public long? Current { get; init; }

    /// <summary>Number of results per page.</summary>
    public long? Size { get; init; }

    /// <summary>The value cannot be greater than 60000 (ms)</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetLockedPersonalLeftQuotaRequest
{
    public required string ProjectId { get; init; }

    /// <summary>The value cannot be greater than 60000 (ms)</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetLockedProductPositionRequest
{
    public string? Asset { get; init; }

    public string? PositionId { get; init; }

    public string? ProjectId { get; init; }

    /// <summary>Currently querying page. Starts from 1.</summary>
    public long? Current { get; init; }

    /// <summary>Number of results per page.</summary>
    public long? Size { get; init; }

    /// <summary>The value cannot be greater than 60000 (ms)</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetLockedRedemptionRecordRequest
{
    public string? PositionId { get; init; }

    public string? RedeemId { get; init; }

    public string? Asset { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Currently querying page. Starts from 1.</summary>
    public long? Current { get; init; }

    /// <summary>Number of results per page.</summary>
    public long? Size { get; init; }

    /// <summary>The value cannot be greater than 60000 (ms)</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetLockedRewardsHistoryRequest
{
    public string? PositionId { get; init; }

    public string? Asset { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Currently querying page. Starts from 1.</summary>
    public long? Current { get; init; }

    /// <summary>Number of results per page.</summary>
    public long? Size { get; init; }

    /// <summary>The value cannot be greater than 60000 (ms)</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetLockedSubscriptionPreviewRequest
{
    public required string ProjectId { get; init; }

    public required decimal Amount { get; init; }

    /// <summary>default true.</summary>
    public bool? AutoSubscribe { get; init; }

    /// <summary>The value cannot be greater than 60000 (ms)</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetLockedSubscriptionRecordRequest
{
    public string? PurchaseId { get; init; }

    public string? Asset { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Currently querying page. Starts from 1.</summary>
    public long? Current { get; init; }

    /// <summary>Number of results per page.</summary>
    public long? Size { get; init; }

    /// <summary>The value cannot be greater than 60000 (ms)</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<GetRateHistoryAprPeriod>))]
public readonly struct GetRateHistoryAprPeriod : IExtensibleValue<GetRateHistoryAprPeriod>, IEquatable<GetRateHistoryAprPeriod>
{
    private readonly string? _value;

    public GetRateHistoryAprPeriod(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static GetRateHistoryAprPeriod Day { get; } = new("DAY");

    public static GetRateHistoryAprPeriod Year { get; } = new("YEAR");

    static GetRateHistoryAprPeriod IExtensibleValue<GetRateHistoryAprPeriod>.Create(string value) => new(value);

    public static bool operator ==(GetRateHistoryAprPeriod left, GetRateHistoryAprPeriod right) => left.Equals(right);

    public static bool operator !=(GetRateHistoryAprPeriod left, GetRateHistoryAprPeriod right) => !left.Equals(right);

    public static implicit operator GetRateHistoryAprPeriod(string value) => new(value);

    public static GetRateHistoryAprPeriod FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is GetRateHistoryAprPeriod other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(GetRateHistoryAprPeriod other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class GetRateHistoryRequest
{
    public required string ProductId { get; init; }

    public GetRateHistoryAprPeriod? AprPeriod { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Currently querying page</summary>
    public long? Current { get; init; }

    /// <summary>Number of results per page</summary>
    public long? Size { get; init; }

    /// <summary>The value cannot be greater than 60000 (ms)</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetSimpleEarnFlexibleProductListRequest
{
    public string? Asset { get; init; }

    /// <summary>Currently querying page. Starts from 1.</summary>
    public long? Current { get; init; }

    /// <summary>Number of results per page.</summary>
    public long? Size { get; init; }

    /// <summary>The value cannot be greater than 60000 (ms)</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetSimpleEarnLockedProductListRequest
{
    public string? Asset { get; init; }

    /// <summary>Currently querying page. Starts from 1.</summary>
    public long? Current { get; init; }

    /// <summary>Number of results per page.</summary>
    public long? Size { get; init; }

    /// <summary>The value cannot be greater than 60000 (ms)</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<RedeemFlexibleProductDestAccount>))]
public readonly struct RedeemFlexibleProductDestAccount : IExtensibleValue<RedeemFlexibleProductDestAccount>, IEquatable<RedeemFlexibleProductDestAccount>
{
    private readonly string? _value;

    public RedeemFlexibleProductDestAccount(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static RedeemFlexibleProductDestAccount Spot { get; } = new("SPOT");

    public static RedeemFlexibleProductDestAccount Fund { get; } = new("FUND");

    static RedeemFlexibleProductDestAccount IExtensibleValue<RedeemFlexibleProductDestAccount>.Create(string value) => new(value);

    public static bool operator ==(RedeemFlexibleProductDestAccount left, RedeemFlexibleProductDestAccount right) => left.Equals(right);

    public static bool operator !=(RedeemFlexibleProductDestAccount left, RedeemFlexibleProductDestAccount right) => !left.Equals(right);

    public static implicit operator RedeemFlexibleProductDestAccount(string value) => new(value);

    public static RedeemFlexibleProductDestAccount FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is RedeemFlexibleProductDestAccount other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(RedeemFlexibleProductDestAccount other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class RedeemFlexibleProductRequest
{
    public required string ProductId { get; init; }

    public bool? RedeemAll { get; init; }

    /// <summary>if redeemAll is false, amount is mandatory</summary>
    public decimal? Amount { get; init; }

    public RedeemFlexibleProductDestAccount? DestAccount { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class RedeemLockedProductRequest
{
    /// <summary>Locked product position ID</summary>
    public required string PositionId { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class SetFlexibleAutoSubscribeRequest
{
    public required string ProductId { get; init; }

    public required bool AutoSubscribe { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class SetLockedAutoSubscribeRequest
{
    public required string PositionId { get; init; }

    public required bool AutoSubscribe { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<SetLockedProductRedeemOptionRedeemTo>))]
public readonly struct SetLockedProductRedeemOptionRedeemTo : IExtensibleValue<SetLockedProductRedeemOptionRedeemTo>, IEquatable<SetLockedProductRedeemOptionRedeemTo>
{
    private readonly string? _value;

    public SetLockedProductRedeemOptionRedeemTo(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static SetLockedProductRedeemOptionRedeemTo Spot { get; } = new("SPOT");

    public static SetLockedProductRedeemOptionRedeemTo Flexible { get; } = new("FLEXIBLE");

    static SetLockedProductRedeemOptionRedeemTo IExtensibleValue<SetLockedProductRedeemOptionRedeemTo>.Create(string value) => new(value);

    public static bool operator ==(SetLockedProductRedeemOptionRedeemTo left, SetLockedProductRedeemOptionRedeemTo right) => left.Equals(right);

    public static bool operator !=(SetLockedProductRedeemOptionRedeemTo left, SetLockedProductRedeemOptionRedeemTo right) => !left.Equals(right);

    public static implicit operator SetLockedProductRedeemOptionRedeemTo(string value) => new(value);

    public static SetLockedProductRedeemOptionRedeemTo FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is SetLockedProductRedeemOptionRedeemTo other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(SetLockedProductRedeemOptionRedeemTo other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class SetLockedProductRedeemOptionRequest
{
    public required string PositionId { get; init; }

    public required SetLockedProductRedeemOptionRedeemTo RedeemTo { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class SimpleAccountRequest
{
    /// <summary>The value cannot be greater than 60000 (ms)</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<SubscribeFlexibleProductSourceAccount>))]
public readonly struct SubscribeFlexibleProductSourceAccount : IExtensibleValue<SubscribeFlexibleProductSourceAccount>, IEquatable<SubscribeFlexibleProductSourceAccount>
{
    private readonly string? _value;

    public SubscribeFlexibleProductSourceAccount(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static SubscribeFlexibleProductSourceAccount Spot { get; } = new("SPOT");

    public static SubscribeFlexibleProductSourceAccount Fund { get; } = new("FUND");

    public static SubscribeFlexibleProductSourceAccount All { get; } = new("ALL");

    static SubscribeFlexibleProductSourceAccount IExtensibleValue<SubscribeFlexibleProductSourceAccount>.Create(string value) => new(value);

    public static bool operator ==(SubscribeFlexibleProductSourceAccount left, SubscribeFlexibleProductSourceAccount right) => left.Equals(right);

    public static bool operator !=(SubscribeFlexibleProductSourceAccount left, SubscribeFlexibleProductSourceAccount right) => !left.Equals(right);

    public static implicit operator SubscribeFlexibleProductSourceAccount(string value) => new(value);

    public static SubscribeFlexibleProductSourceAccount FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is SubscribeFlexibleProductSourceAccount other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(SubscribeFlexibleProductSourceAccount other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class SubscribeFlexibleProductRequest
{
    public required string ProductId { get; init; }

    public required decimal Amount { get; init; }

    public bool? AutoSubscribe { get; init; }

    public SubscribeFlexibleProductSourceAccount? SourceAccount { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<SubscribeLockedProductSourceAccount>))]
public readonly struct SubscribeLockedProductSourceAccount : IExtensibleValue<SubscribeLockedProductSourceAccount>, IEquatable<SubscribeLockedProductSourceAccount>
{
    private readonly string? _value;

    public SubscribeLockedProductSourceAccount(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static SubscribeLockedProductSourceAccount Spot { get; } = new("SPOT");

    public static SubscribeLockedProductSourceAccount Fund { get; } = new("FUND");

    public static SubscribeLockedProductSourceAccount All { get; } = new("ALL");

    static SubscribeLockedProductSourceAccount IExtensibleValue<SubscribeLockedProductSourceAccount>.Create(string value) => new(value);

    public static bool operator ==(SubscribeLockedProductSourceAccount left, SubscribeLockedProductSourceAccount right) => left.Equals(right);

    public static bool operator !=(SubscribeLockedProductSourceAccount left, SubscribeLockedProductSourceAccount right) => !left.Equals(right);

    public static implicit operator SubscribeLockedProductSourceAccount(string value) => new(value);

    public static SubscribeLockedProductSourceAccount FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is SubscribeLockedProductSourceAccount other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(SubscribeLockedProductSourceAccount other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<SubscribeLockedProductRedeemTo>))]
public readonly struct SubscribeLockedProductRedeemTo : IExtensibleValue<SubscribeLockedProductRedeemTo>, IEquatable<SubscribeLockedProductRedeemTo>
{
    private readonly string? _value;

    public SubscribeLockedProductRedeemTo(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static SubscribeLockedProductRedeemTo Spot { get; } = new("SPOT");

    public static SubscribeLockedProductRedeemTo Flexible { get; } = new("FLEXIBLE");

    static SubscribeLockedProductRedeemTo IExtensibleValue<SubscribeLockedProductRedeemTo>.Create(string value) => new(value);

    public static bool operator ==(SubscribeLockedProductRedeemTo left, SubscribeLockedProductRedeemTo right) => left.Equals(right);

    public static bool operator !=(SubscribeLockedProductRedeemTo left, SubscribeLockedProductRedeemTo right) => !left.Equals(right);

    public static implicit operator SubscribeLockedProductRedeemTo(string value) => new(value);

    public static SubscribeLockedProductRedeemTo FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is SubscribeLockedProductRedeemTo other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(SubscribeLockedProductRedeemTo other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class SubscribeLockedProductRequest
{
    public required string ProjectId { get; init; }

    public required decimal Amount { get; init; }

    public bool? AutoSubscribe { get; init; }

    public SubscribeLockedProductSourceAccount? SourceAccount { get; init; }

    public SubscribeLockedProductRedeemTo? RedeemTo { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class SimpleEarnRestApi
{

    /// <summary>Get Collateral Record (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Collateral Record</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- The time between startTime and endTime cannot be longer than 30 days.</para>
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
    public Task<RestApiResponse<GetCollateralRecordResponse>> GetCollateralRecordAsync(GetCollateralRecordRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/simple-earn/flexible/history/collateralRecord", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("productId", request.ProductId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.GetCollateralRecordResponse, cancellationToken);
    }

    /// <summary>Get Flexible Personal Left Quota (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Flexible Personal Left Quota</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetFlexiblePersonalLeftQuotaResponse>> GetFlexiblePersonalLeftQuotaAsync(GetFlexiblePersonalLeftQuotaRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/simple-earn/flexible/personalLeftQuota", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetFlexiblePersonalLeftQuotaResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("productId", request.ProductId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.GetFlexiblePersonalLeftQuotaResponse, cancellationToken);
    }

    /// <summary>Get Flexible Product Position (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Flexible Product Position</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetFlexibleProductPositionResponse>> GetFlexibleProductPositionAsync(GetFlexibleProductPositionRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/simple-earn/flexible/position", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("asset", request.Asset);
        r.Query("productId", request.ProductId);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.GetFlexibleProductPositionResponse, cancellationToken);
    }

    /// <summary>Get Flexible Redemption Record (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Flexible Redemption Record</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- The time between startTime and endTime cannot be longer than 30 days.</para>
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
    public Task<RestApiResponse<GetFlexibleRedemptionRecordResponse>> GetFlexibleRedemptionRecordAsync(GetFlexibleRedemptionRecordRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/simple-earn/flexible/history/redemptionRecord", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("productId", request.ProductId);
        r.Query("redeemId", request.RedeemId);
        r.Query("asset", request.Asset);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.GetFlexibleRedemptionRecordResponse, cancellationToken);
    }

    /// <summary>Get Flexible Rewards History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Flexible Rewards History</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- The time between startTime and endTime cannot be longer than 30 days.</para>
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
    public Task<RestApiResponse<GetFlexibleRewardsHistoryResponse>> GetFlexibleRewardsHistoryAsync(GetFlexibleRewardsHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/simple-earn/flexible/history/rewardsRecord", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("productId", request.ProductId);
        r.Query("asset", request.Asset);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("type", request.Type);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.GetFlexibleRewardsHistoryResponse, cancellationToken);
    }

    /// <summary>Get Flexible Subscription Preview (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Flexible Subscription Preview</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetFlexibleSubscriptionPreviewResponse>> GetFlexibleSubscriptionPreviewAsync(GetFlexibleSubscriptionPreviewRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/simple-earn/flexible/subscriptionPreview", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetFlexibleSubscriptionPreviewResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("productId", request.ProductId);
        r.Query("amount", request.Amount);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.GetFlexibleSubscriptionPreviewResponse, cancellationToken);
    }

    /// <summary>Get Flexible Subscription Record (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Flexible Subscription Record</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- The time between startTime and endTime cannot be longer than 30 days.</para>
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
    public Task<RestApiResponse<GetFlexibleSubscriptionRecordResponse>> GetFlexibleSubscriptionRecordAsync(GetFlexibleSubscriptionRecordRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/simple-earn/flexible/history/subscriptionRecord", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("productId", request.ProductId);
        r.Query("purchaseId", request.PurchaseId);
        r.Query("asset", request.Asset);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.GetFlexibleSubscriptionRecordResponse, cancellationToken);
    }

    /// <summary>Get Locked Personal Left Quota (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Locked Personal Left Quota</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetLockedPersonalLeftQuotaResponse>> GetLockedPersonalLeftQuotaAsync(GetLockedPersonalLeftQuotaRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/simple-earn/locked/personalLeftQuota", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetLockedPersonalLeftQuotaResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("projectId", request.ProjectId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.GetLockedPersonalLeftQuotaResponse, cancellationToken);
    }

    /// <summary>Get Locked Product Position (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Locked Product Position</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetLockedProductPositionResponse>> GetLockedProductPositionAsync(GetLockedProductPositionRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/simple-earn/locked/position", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("asset", request.Asset);
        r.Query("positionId", request.PositionId);
        r.Query("projectId", request.ProjectId);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.GetLockedProductPositionResponse, cancellationToken);
    }

    /// <summary>Get Locked Redemption Record (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Locked Redemption Record</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- The time between startTime and endTime cannot be longer than 30 days.</para>
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
    public Task<RestApiResponse<GetLockedRedemptionRecordResponse>> GetLockedRedemptionRecordAsync(GetLockedRedemptionRecordRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/simple-earn/locked/history/redemptionRecord", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("positionId", request.PositionId);
        r.Query("redeemId", request.RedeemId);
        r.Query("asset", request.Asset);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.GetLockedRedemptionRecordResponse, cancellationToken);
    }

    /// <summary>Get Locked Rewards History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Locked Rewards History</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- The time between startTime and endTime cannot be longer than 30 days.</para>
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
    public Task<RestApiResponse<GetLockedRewardsHistoryResponse>> GetLockedRewardsHistoryAsync(GetLockedRewardsHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/simple-earn/locked/history/rewardsRecord", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("positionId", request.PositionId);
        r.Query("asset", request.Asset);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.GetLockedRewardsHistoryResponse, cancellationToken);
    }

    /// <summary>Get Locked Subscription Preview (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Locked Subscription Preview</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<GetLockedSubscriptionPreviewResponseInner>>> GetLockedSubscriptionPreviewAsync(GetLockedSubscriptionPreviewRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/simple-earn/locked/subscriptionPreview", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<GetLockedSubscriptionPreviewResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("projectId", request.ProjectId);
        r.Query("amount", request.Amount);
        r.Query("autoSubscribe", request.AutoSubscribe);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.ListGetLockedSubscriptionPreviewResponseInner, cancellationToken);
    }

    /// <summary>Get Locked Subscription Record (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Locked Subscription Record</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- The time between startTime and endTime cannot be longer than 30 days.</para>
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
    public Task<RestApiResponse<GetLockedSubscriptionRecordResponse>> GetLockedSubscriptionRecordAsync(GetLockedSubscriptionRecordRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/simple-earn/locked/history/subscriptionRecord", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("purchaseId", request.PurchaseId);
        r.Query("asset", request.Asset);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.GetLockedSubscriptionRecordResponse, cancellationToken);
    }

    /// <summary>Get Rate History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Rate History</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- The time between startTime and endTime cannot be longer than 1 year.</para>
    /// <para>- If startTime and endTime are</para>
    /// <para>both not sent, then the last 30 days' data will be returned.</para>
    /// <para>- If startTime is sent but endTime is not</para>
    /// <para>sent, the next 30 days' data beginning from startTime will be returned.</para>
    /// <para>- If endTime is sent but</para>
    /// <para>startTime is not sent, the 30 days' data before endTime will be returned.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetRateHistoryResponse>> GetRateHistoryAsync(GetRateHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/simple-earn/flexible/history/rateHistory", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetRateHistoryResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("productId", request.ProductId);
        r.Query("aprPeriod", request.AprPeriod);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.GetRateHistoryResponse, cancellationToken);
    }

    /// <summary>Get Simple Earn Flexible Product List (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get available Simple Earn flexible product list</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetSimpleEarnFlexibleProductListResponse>> GetSimpleEarnFlexibleProductListAsync(GetSimpleEarnFlexibleProductListRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/simple-earn/flexible/list", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("asset", request.Asset);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.GetSimpleEarnFlexibleProductListResponse, cancellationToken);
    }

    /// <summary>Get Simple Earn Locked Product List (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Simple Earn Locked Product List</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Get available Simple Earn locked product list</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetSimpleEarnLockedProductListResponse>> GetSimpleEarnLockedProductListAsync(GetSimpleEarnLockedProductListRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/simple-earn/locked/list", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("asset", request.Asset);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.GetSimpleEarnLockedProductListResponse, cancellationToken);
    }

    /// <summary>Redeem Flexible Product (TRADE)</summary>
    /// <remarks>
    /// <para>Redeem Flexible Product</para>
    /// <para>Weight(IP): 1</para>
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
    public Task<RestApiResponse<RedeemFlexibleProductResponse>> RedeemFlexibleProductAsync(RedeemFlexibleProductRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/simple-earn/flexible/redeem", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<RedeemFlexibleProductResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("productId", request.ProductId);
        r.Query("redeemAll", request.RedeemAll);
        r.Query("amount", request.Amount);
        r.Query("destAccount", request.DestAccount);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.RedeemFlexibleProductResponse, cancellationToken);
    }

    /// <summary>Redeem Locked Product (TRADE)</summary>
    /// <remarks>
    /// <para>Redeem Locked Product</para>
    /// <para>Weight(IP): 1</para>
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
    public Task<RestApiResponse<RedeemLockedProductResponse>> RedeemLockedProductAsync(RedeemLockedProductRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/simple-earn/locked/redeem", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<RedeemLockedProductResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("positionId", request.PositionId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.RedeemLockedProductResponse, cancellationToken);
    }

    /// <summary>Set Flexible Auto Subscribe (USER_DATA)</summary>
    /// <remarks>
    /// <para>Set Flexible Auto Subscribe</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<SetFlexibleAutoSubscribeResponse>> SetFlexibleAutoSubscribeAsync(SetFlexibleAutoSubscribeRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/simple-earn/flexible/setAutoSubscribe", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<SetFlexibleAutoSubscribeResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("productId", request.ProductId);
        r.Query("autoSubscribe", request.AutoSubscribe);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.SetFlexibleAutoSubscribeResponse, cancellationToken);
    }

    /// <summary>Set Locked Auto Subscribe (USER_DATA)</summary>
    /// <remarks>
    /// <para>Set locked auto subscribe</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<SetLockedAutoSubscribeResponse>> SetLockedAutoSubscribeAsync(SetLockedAutoSubscribeRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/simple-earn/locked/setAutoSubscribe", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<SetLockedAutoSubscribeResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("positionId", request.PositionId);
        r.Query("autoSubscribe", request.AutoSubscribe);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.SetLockedAutoSubscribeResponse, cancellationToken);
    }

    /// <summary>Set Locked Product Redeem Option (USER_DATA)</summary>
    /// <remarks>
    /// <para>Set redeem option for Locked product</para>
    /// <para>Weight(IP): 50</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<SetLockedProductRedeemOptionResponse>> SetLockedProductRedeemOptionAsync(SetLockedProductRedeemOptionRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/simple-earn/locked/setRedeemOption", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<SetLockedProductRedeemOptionResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("positionId", request.PositionId);
        r.Query("redeemTo", request.RedeemTo);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.SetLockedProductRedeemOptionResponse, cancellationToken);
    }

    /// <summary>Simple Account (USER_DATA)</summary>
    /// <remarks>
    /// <para>Simple Account query</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<SimpleAccountResponse>> SimpleAccountAsync(SimpleAccountRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/simple-earn/account", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.SimpleAccountResponse, cancellationToken);
    }

    /// <summary>Subscribe Flexible Product (TRADE)</summary>
    /// <remarks>
    /// <para>Subscribe Flexible Product</para>
    /// <para>Weight(IP): 1</para>
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
    public Task<RestApiResponse<SubscribeFlexibleProductResponse>> SubscribeFlexibleProductAsync(SubscribeFlexibleProductRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/simple-earn/flexible/subscribe", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<SubscribeFlexibleProductResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("productId", request.ProductId);
        r.Query("amount", request.Amount);
        r.Query("autoSubscribe", request.AutoSubscribe);
        r.Query("sourceAccount", request.SourceAccount);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.SubscribeFlexibleProductResponse, cancellationToken);
    }

    /// <summary>Subscribe Locked Product (TRADE)</summary>
    /// <remarks>
    /// <para>Subscribe Locked Product</para>
    /// <para>Weight(IP): 1</para>
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
    public Task<RestApiResponse<SubscribeLockedProductResponse>> SubscribeLockedProductAsync(SubscribeLockedProductRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/simple-earn/locked/subscribe", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<SubscribeLockedProductResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("projectId", request.ProjectId);
        r.Query("amount", request.Amount);
        r.Query("autoSubscribe", request.AutoSubscribe);
        r.Query("sourceAccount", request.SourceAccount);
        r.Query("redeemTo", request.RedeemTo);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.SubscribeLockedProductResponse, cancellationToken);
    }
}
