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

public sealed class AccountApiTradingStatusRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class AccountInfoRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class AccountStatusRequest
{
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<DailyAccountSnapshotType>))]
public readonly struct DailyAccountSnapshotType : IExtensibleValue<DailyAccountSnapshotType>, IEquatable<DailyAccountSnapshotType>
{
    private readonly string? _value;

    public DailyAccountSnapshotType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static DailyAccountSnapshotType Spot { get; } = new("SPOT");

    public static DailyAccountSnapshotType Margin { get; } = new("MARGIN");

    public static DailyAccountSnapshotType Futures { get; } = new("FUTURES");

    static DailyAccountSnapshotType IExtensibleValue<DailyAccountSnapshotType>.Create(string value) => new(value);

    public static bool operator ==(DailyAccountSnapshotType left, DailyAccountSnapshotType right) => left.Equals(right);

    public static bool operator !=(DailyAccountSnapshotType left, DailyAccountSnapshotType right) => !left.Equals(right);

    public static implicit operator DailyAccountSnapshotType(string value) => new(value);

    public static DailyAccountSnapshotType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is DailyAccountSnapshotType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(DailyAccountSnapshotType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class DailyAccountSnapshotRequest
{
    public required DailyAccountSnapshotType Type { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class DisableFastWithdrawSwitchRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class EnableFastWithdrawSwitchRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class GetApiKeyPermissionRequest
{
    public long? RecvWindow { get; init; }
}

public sealed partial class WalletRestApi
{

    /// <summary>Account API Trading Status (USER_DATA)</summary>
    /// <remarks>
    /// <para>Fetch account api trading status detail.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<AccountApiTradingStatusResponse>> AccountApiTradingStatusAsync(AccountApiTradingStatusRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/account/apiTradingStatus", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.AccountApiTradingStatusResponse, cancellationToken);
    }

    /// <summary>Account info (USER_DATA)</summary>
    /// <remarks>
    /// <para>Fetch account info detail.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<AccountInfoResponse>> AccountInfoAsync(AccountInfoRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/account/info", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.AccountInfoResponse, cancellationToken);
    }

    /// <summary>Account Status (USER_DATA)</summary>
    /// <remarks>
    /// <para>Fetch account status detail.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<AccountStatusResponse>> AccountStatusAsync(AccountStatusRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/account/status", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.AccountStatusResponse, cancellationToken);
    }

    /// <summary>Daily Account Snapshot (USER_DATA)</summary>
    /// <remarks>
    /// <para>Daily account snapshot</para>
    /// <para>Weight(IP): 2400</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- The query time period must be less then 30 days</para>
    /// <para>- Support query within the last one month only</para>
    /// <para>- If startTimeand endTime not sent, return records of the last 7 days by default</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<DailyAccountSnapshotResponse>> DailyAccountSnapshotAsync(DailyAccountSnapshotRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/accountSnapshot", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<DailyAccountSnapshotResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("type", request.Type);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.DailyAccountSnapshotResponse, cancellationToken);
    }

    /// <summary>Disable Fast Withdraw Switch (USER_DATA)</summary>
    /// <remarks>
    /// <para>Disable Fast Withdraw Switch</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>
    /// - This request will disable fastwithdraw switch under your account. You need to enable "trade"
    /// option for the api key which requests this endpoint.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<JsonElement>> DisableFastWithdrawSwitchAsync(DisableFastWithdrawSwitchRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/account/disableFastWithdrawSwitch", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.JsonElement, cancellationToken);
    }

    /// <summary>Enable Fast Withdraw Switch (USER_DATA)</summary>
    /// <remarks>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>
    /// - This request will enable fastwithdraw switch under your account. You need to enable "trade" option
    /// for the api key which requests this endpoint.
    /// </para>
    /// <para>
    /// - When Fast Withdraw Switch is on, transferring funds to a Binance account will be done instantly.
    /// There is no on-chain transaction, no transaction ID and no withdrawal fee.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<JsonElement>> EnableFastWithdrawSwitchAsync(EnableFastWithdrawSwitchRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/account/enableFastWithdrawSwitch", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.JsonElement, cancellationToken);
    }

    /// <summary>Get API Key Permission (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get API Key Permission</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetApiKeyPermissionResponse>> GetApiKeyPermissionAsync(GetApiKeyPermissionRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/account/apiRestrictions", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.GetApiKeyPermissionResponse, cancellationToken);
    }
}
