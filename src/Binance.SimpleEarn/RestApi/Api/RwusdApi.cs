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

public sealed class GetRwusdAccountRequest
{
    /// <summary>The value cannot be greater than 60000 (ms)</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetRwusdQuotaDetailsRequest
{
    /// <summary>The value cannot be greater than 60000 (ms)</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetRwusdRateHistoryRequest
{
    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Currently querying page</summary>
    public long? Current { get; init; }

    /// <summary>Number of results per page</summary>
    public long? Size { get; init; }

    /// <summary>The value cannot be greater than 60000 (ms)</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetRwusdRedemptionHistoryRequest
{
    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Currently querying page</summary>
    public long? Current { get; init; }

    /// <summary>Number of results per page</summary>
    public long? Size { get; init; }

    /// <summary>The value cannot be greater than 60000 (ms)</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetRwusdRewardsHistoryRequest
{
    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Currently querying page</summary>
    public long? Current { get; init; }

    /// <summary>Number of results per page</summary>
    public long? Size { get; init; }

    /// <summary>The value cannot be greater than 60000 (ms)</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<GetRwusdSubscriptionHistoryAsset>))]
public readonly struct GetRwusdSubscriptionHistoryAsset : IExtensibleValue<GetRwusdSubscriptionHistoryAsset>, IEquatable<GetRwusdSubscriptionHistoryAsset>
{
    private readonly string? _value;

    public GetRwusdSubscriptionHistoryAsset(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static GetRwusdSubscriptionHistoryAsset Usdc { get; } = new("USDC");

    public static GetRwusdSubscriptionHistoryAsset Usdt { get; } = new("USDT");

    static GetRwusdSubscriptionHistoryAsset IExtensibleValue<GetRwusdSubscriptionHistoryAsset>.Create(string value) => new(value);

    public static bool operator ==(GetRwusdSubscriptionHistoryAsset left, GetRwusdSubscriptionHistoryAsset right) => left.Equals(right);

    public static bool operator !=(GetRwusdSubscriptionHistoryAsset left, GetRwusdSubscriptionHistoryAsset right) => !left.Equals(right);

    public static implicit operator GetRwusdSubscriptionHistoryAsset(string value) => new(value);

    public static GetRwusdSubscriptionHistoryAsset FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is GetRwusdSubscriptionHistoryAsset other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(GetRwusdSubscriptionHistoryAsset other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class GetRwusdSubscriptionHistoryRequest
{
    public GetRwusdSubscriptionHistoryAsset? Asset { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Currently querying page</summary>
    public long? Current { get; init; }

    /// <summary>Number of results per page</summary>
    public long? Size { get; init; }

    /// <summary>The value cannot be greater than 60000 (ms)</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<RedeemRwusdType>))]
public readonly struct RedeemRwusdType : IExtensibleValue<RedeemRwusdType>, IEquatable<RedeemRwusdType>
{
    private readonly string? _value;

    public RedeemRwusdType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static RedeemRwusdType Fast { get; } = new("FAST");

    public static RedeemRwusdType Standard { get; } = new("STANDARD");

    static RedeemRwusdType IExtensibleValue<RedeemRwusdType>.Create(string value) => new(value);

    public static bool operator ==(RedeemRwusdType left, RedeemRwusdType right) => left.Equals(right);

    public static bool operator !=(RedeemRwusdType left, RedeemRwusdType right) => !left.Equals(right);

    public static implicit operator RedeemRwusdType(string value) => new(value);

    public static RedeemRwusdType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is RedeemRwusdType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(RedeemRwusdType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class RedeemRwusdRequest
{
    /// <summary>Amount in RWUSD</summary>
    public required decimal Amount { get; init; }

    public required RedeemRwusdType Type { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<SubscribeRwusdAsset>))]
public readonly struct SubscribeRwusdAsset : IExtensibleValue<SubscribeRwusdAsset>, IEquatable<SubscribeRwusdAsset>
{
    private readonly string? _value;

    public SubscribeRwusdAsset(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static SubscribeRwusdAsset Usdt { get; } = new("USDT");

    public static SubscribeRwusdAsset Usdc { get; } = new("USDC");

    static SubscribeRwusdAsset IExtensibleValue<SubscribeRwusdAsset>.Create(string value) => new(value);

    public static bool operator ==(SubscribeRwusdAsset left, SubscribeRwusdAsset right) => left.Equals(right);

    public static bool operator !=(SubscribeRwusdAsset left, SubscribeRwusdAsset right) => !left.Equals(right);

    public static implicit operator SubscribeRwusdAsset(string value) => new(value);

    public static SubscribeRwusdAsset FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is SubscribeRwusdAsset other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(SubscribeRwusdAsset other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class SubscribeRwusdRequest
{
    public required SubscribeRwusdAsset Asset { get; init; }

    /// <summary>Amount</summary>
    public required decimal Amount { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class SimpleEarnRestApi
{

    /// <summary>Get RWUSD Account (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get RWUSD account information.</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetRwusdAccountResponse>> GetRwusdAccountAsync(GetRwusdAccountRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/rwusd/account", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.GetRwusdAccountResponse, cancellationToken);
    }

    /// <summary>Get RWUSD Quota Details (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Get RWUSD quota details including subscription quota, fast redemption quota, and standard redemption
    /// quota.
    /// </para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetRwusdQuotaDetailsResponse>> GetRwusdQuotaDetailsAsync(GetRwusdQuotaDetailsRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/rwusd/quota", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.GetRwusdQuotaDetailsResponse, cancellationToken);
    }

    /// <summary>Get RWUSD Rate History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get RWUSD rate history sorted by descending order.</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- The time between startTime and endTime cannot be longer than 6 months.</para>
    /// <para>- If startTime and endTime</para>
    /// <para>are both not sent, then the last 30 days' data will be returned.</para>
    /// <para>- If startTime is sent but endTime is not</para>
    /// <para>sent, endTime will default to current time, and results from startTime onward will be returned.</para>
    /// <para>- If</para>
    /// <para>
    /// endTime is sent but startTime is not sent, startTime defaults to the current time minus one month,
    /// and data between startTime and endTime will be returned.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetRwusdRateHistoryResponse>> GetRwusdRateHistoryAsync(GetRwusdRateHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/rwusd/history/rateHistory", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.GetRwusdRateHistoryResponse, cancellationToken);
    }

    /// <summary>Get RWUSD Redemption History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get RWUSD redemption history.</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- The time between startTime and endTime cannot be longer than 6 months.</para>
    /// <para>- If startTime and endTime</para>
    /// <para>are both not sent, then the last 30 days' data will be returned.</para>
    /// <para>- If startTime is sent but endTime is not</para>
    /// <para>sent, endTime will default to current time, and results from startTime onward will be returned.</para>
    /// <para>- If</para>
    /// <para>
    /// endTime is sent but startTime is not sent, startTime defaults to the current time minus one month,
    /// and data between startTime and endTime will be returned.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetRwusdRedemptionHistoryResponse>> GetRwusdRedemptionHistoryAsync(GetRwusdRedemptionHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/rwusd/history/redemptionHistory", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.GetRwusdRedemptionHistoryResponse, cancellationToken);
    }

    /// <summary>Get RWUSD Rewards History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get RWUSD rewards history.</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- The time between startTime and endTime cannot be longer than 6 months.</para>
    /// <para>- If startTime and endTime</para>
    /// <para>are both not sent, then the last 30 days' data will be returned.</para>
    /// <para>- If startTime is sent but endTime is not</para>
    /// <para>sent, endTime will default to current time, and results from startTime onward will be returned.</para>
    /// <para>- If</para>
    /// <para>
    /// endTime is sent but startTime is not sent, startTime defaults to the current time minus one month,
    /// and data between startTime and endTime will be returned.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetRwusdRewardsHistoryResponse>> GetRwusdRewardsHistoryAsync(GetRwusdRewardsHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/rwusd/history/rewardsHistory", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.GetRwusdRewardsHistoryResponse, cancellationToken);
    }

    /// <summary>Get RWUSD subscription history (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get RWUSD subscription history</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- The time between startTime and endTime cannot be longer than 6 months.</para>
    /// <para>- If startTime and endTime</para>
    /// <para>are both not sent, then the last 30 days' data will be returned.</para>
    /// <para>- If startTime is sent but endTime is not</para>
    /// <para>sent, endTime will default to current time, and results from startTime onward will be returned.</para>
    /// <para>- If</para>
    /// <para>
    /// endTime is sent but startTime is not sent, startTime defaults to the current time advanced by one
    /// month, and data between startTime and endTime will be returned.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetRwusdSubscriptionHistoryResponse>> GetRwusdSubscriptionHistoryAsync(GetRwusdSubscriptionHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/rwusd/history/subscriptionHistory", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("asset", request.Asset);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.GetRwusdSubscriptionHistoryResponse, cancellationToken);
    }

    /// <summary>Redeem RWUSD (TRADE)</summary>
    /// <remarks>
    /// <para>Redeem RWUSD to USDC</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>
    /// - You need to open Enable Spot &amp; Margin Trading permission for the API Key which requests this
    /// endpoint.
    /// </para>
    /// <para>
    /// - This API only supports RWUSD redemption to the Spot Account. Redemptions to the Funding Account or
    /// any other account type are not supported.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<RedeemRwusdResponse>> RedeemRwusdAsync(RedeemRwusdRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/rwusd/redeem", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<RedeemRwusdResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("amount", request.Amount);
        r.Query("type", request.Type);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.RedeemRwusdResponse, cancellationToken);
    }

    /// <summary>Subscribe RWUSD (TRADE)</summary>
    /// <remarks>
    /// <para>Subscribe RWUSD</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>
    /// - You need to open Enable Spot &amp; Margin Trading permission for the API Key which requests this
    /// endpoint.
    /// </para>
    /// <para>
    /// - This API only supports RWUSD subscription using assets held in the Spot Account. Subscriptions
    /// initiated from the Funding Account or any other account type are not supported.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<SubscribeRwusdResponse>> SubscribeRwusdAsync(SubscribeRwusdRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/rwusd/subscribe", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<SubscribeRwusdResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("asset", request.Asset);
        r.Query("amount", request.Amount);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.SubscribeRwusdResponse, cancellationToken);
    }
}
