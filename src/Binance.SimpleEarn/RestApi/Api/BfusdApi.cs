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

public sealed class GetBfusdAccountRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class GetBfusdQuotaDetailsRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class GetBfusdRateHistoryRequest
{
    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Currently querying page. Starts from 1.</summary>
    public long? Current { get; init; }

    /// <summary>Number of results per page.</summary>
    public long? Size { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetBfusdRedemptionHistoryRequest
{
    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Currently querying page.</summary>
    public long? Current { get; init; }

    /// <summary>Number of results per page.</summary>
    public long? Size { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetBfusdRewardsHistoryRequest
{
    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Currently querying page.</summary>
    public long? Current { get; init; }

    /// <summary>Number of results per page.</summary>
    public long? Size { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<GetBfusdSubscriptionHistoryAsset>))]
public readonly struct GetBfusdSubscriptionHistoryAsset : IExtensibleValue<GetBfusdSubscriptionHistoryAsset>, IEquatable<GetBfusdSubscriptionHistoryAsset>
{
    private readonly string? _value;

    public GetBfusdSubscriptionHistoryAsset(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static GetBfusdSubscriptionHistoryAsset Usdc { get; } = new("USDC");

    public static GetBfusdSubscriptionHistoryAsset Usdt { get; } = new("USDT");

    static GetBfusdSubscriptionHistoryAsset IExtensibleValue<GetBfusdSubscriptionHistoryAsset>.Create(string value) => new(value);

    public static bool operator ==(GetBfusdSubscriptionHistoryAsset left, GetBfusdSubscriptionHistoryAsset right) => left.Equals(right);

    public static bool operator !=(GetBfusdSubscriptionHistoryAsset left, GetBfusdSubscriptionHistoryAsset right) => !left.Equals(right);

    public static implicit operator GetBfusdSubscriptionHistoryAsset(string value) => new(value);

    public static GetBfusdSubscriptionHistoryAsset FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is GetBfusdSubscriptionHistoryAsset other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(GetBfusdSubscriptionHistoryAsset other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class GetBfusdSubscriptionHistoryRequest
{
    public GetBfusdSubscriptionHistoryAsset? Asset { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Currently querying page.</summary>
    public long? Current { get; init; }

    /// <summary>Number of results per page.</summary>
    public long? Size { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<RedeemBfusdType>))]
public readonly struct RedeemBfusdType : IExtensibleValue<RedeemBfusdType>, IEquatable<RedeemBfusdType>
{
    private readonly string? _value;

    public RedeemBfusdType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static RedeemBfusdType Fast { get; } = new("FAST");

    public static RedeemBfusdType Standard { get; } = new("STANDARD");

    static RedeemBfusdType IExtensibleValue<RedeemBfusdType>.Create(string value) => new(value);

    public static bool operator ==(RedeemBfusdType left, RedeemBfusdType right) => left.Equals(right);

    public static bool operator !=(RedeemBfusdType left, RedeemBfusdType right) => !left.Equals(right);

    public static implicit operator RedeemBfusdType(string value) => new(value);

    public static RedeemBfusdType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is RedeemBfusdType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(RedeemBfusdType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class RedeemBfusdRequest
{
    /// <summary>Amount in BFUSD</summary>
    public required decimal Amount { get; init; }

    /// <summary>defaults to STANDARD</summary>
    public required RedeemBfusdType Type { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class SubscribeBfusdRequest
{
    public required string Asset { get; init; }

    /// <summary>Amount</summary>
    public required decimal Amount { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class SimpleEarnRestApi
{

    /// <summary>Get BFUSD Account (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get BFUSD account information.</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetBfusdAccountResponse>> GetBfusdAccountAsync(GetBfusdAccountRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/bfusd/account", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.GetBfusdAccountResponse, cancellationToken);
    }

    /// <summary>Get BFUSD Quota Details (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Get BFUSD quota details including subscription quota, fast redemption quota, and standard redemption
    /// quota.
    /// </para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetBfusdQuotaDetailsResponse>> GetBfusdQuotaDetailsAsync(GetBfusdQuotaDetailsRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/bfusd/quota", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.GetBfusdQuotaDetailsResponse, cancellationToken);
    }

    /// <summary>Get BFUSD Rate History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get BFUSD rate history sorted by descending order.</para>
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
    public Task<RestApiResponse<GetBfusdRateHistoryResponse>> GetBfusdRateHistoryAsync(GetBfusdRateHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/bfusd/history/rateHistory", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.GetBfusdRateHistoryResponse, cancellationToken);
    }

    /// <summary>Get BFUSD Redemption History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get BFUSD redemption history</para>
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
    public Task<RestApiResponse<GetBfusdRedemptionHistoryResponse>> GetBfusdRedemptionHistoryAsync(GetBfusdRedemptionHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/bfusd/history/redemptionHistory", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.GetBfusdRedemptionHistoryResponse, cancellationToken);
    }

    /// <summary>Get BFUSD Rewards History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get BFUSD rewards history</para>
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
    public Task<RestApiResponse<GetBfusdRewardsHistoryResponse>> GetBfusdRewardsHistoryAsync(GetBfusdRewardsHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/bfusd/history/rewardsHistory", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.GetBfusdRewardsHistoryResponse, cancellationToken);
    }

    /// <summary>Get BFUSD subscription history (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get BFUSD subscription history</para>
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
    public Task<RestApiResponse<GetBfusdSubscriptionHistoryResponse>> GetBfusdSubscriptionHistoryAsync(GetBfusdSubscriptionHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/bfusd/history/subscriptionHistory", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("asset", request.Asset);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.GetBfusdSubscriptionHistoryResponse, cancellationToken);
    }

    /// <summary>Redeem BFUSD (TRADE)</summary>
    /// <remarks>
    /// <para>Redeem BFUSD to USDT</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>
    /// - You need to open Enable Spot &amp; Margin Trading permission for the API Key which requests this
    /// endpoint.
    /// </para>
    /// <para>
    /// - This API only supports BFUSD redemption to the Spot Account. Redemptions to the Funding Account or
    /// any other account type are not supported.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<RedeemBfusdResponse>> RedeemBfusdAsync(RedeemBfusdRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/bfusd/redeem", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<RedeemBfusdResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("amount", request.Amount);
        r.Query("type", request.Type);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.RedeemBfusdResponse, cancellationToken);
    }

    /// <summary>Subscribe BFUSD (TRADE)</summary>
    /// <remarks>
    /// <para>Subscribe BFUSD</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>
    /// - You need to open Enable Spot &amp; Margin Trading permission for the API Key which requests this
    /// endpoint.
    /// </para>
    /// <para>
    /// - This API only supports BFUSD subscription using assets held in the Spot Account. Subscriptions
    /// initiated from the Funding Account or any other account type are not supported.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<SubscribeBfusdResponse>> SubscribeBfusdAsync(SubscribeBfusdRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/bfusd/subscribe", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<SubscribeBfusdResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("asset", request.Asset);
        r.Query("amount", request.Amount);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.SubscribeBfusdResponse, cancellationToken);
    }
}
