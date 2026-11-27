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

public sealed class DepositAssetsIntoTheManagedSubAccountRequest
{
    public required string ToEmail { get; init; }

    public required string Asset { get; init; }

    public required decimal Amount { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetManagedSubAccountDepositAddressRequest
{
    public required string Email { get; init; }

    public required string Coin { get; init; }

    /// <summary>networks can be found in GET /sapi/v1/capital/deposit/address</summary>
    public string? Network { get; init; }

    public decimal? Amount { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryManagedSubAccountAssetDetailsRequest
{
    public required string Email { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryManagedSubAccountFuturesAssetDetailsRequest
{
    public required string Email { get; init; }

    /// <summary>
    /// No input or input "USDT_FUTURE" to get UM Futures account details. Input "COIN_FUTURE" to get CM
    /// Futures account details.
    /// </summary>
    public string? AccountType { get; init; }
}

public sealed class QueryManagedSubAccountListRequest
{
    public string? Email { get; init; }

    public long? Page { get; init; }

    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryManagedSubAccountMarginAssetDetailsRequest
{
    public required string Email { get; init; }

    /// <summary>
    /// No input or input "MARGIN" to get Cross Margin account details. Input "ISOLATED_MARGIN" to get
    /// Isolated Margin account details.
    /// </summary>
    public string? AccountType { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<QueryManagedSubAccountSnapshotType>))]
public readonly struct QueryManagedSubAccountSnapshotType : IExtensibleValue<QueryManagedSubAccountSnapshotType>, IEquatable<QueryManagedSubAccountSnapshotType>
{
    private readonly string? _value;

    public QueryManagedSubAccountSnapshotType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static QueryManagedSubAccountSnapshotType Spot { get; } = new("SPOT");

    public static QueryManagedSubAccountSnapshotType Margin { get; } = new("MARGIN");

    public static QueryManagedSubAccountSnapshotType Futures { get; } = new("FUTURES");

    static QueryManagedSubAccountSnapshotType IExtensibleValue<QueryManagedSubAccountSnapshotType>.Create(string value) => new(value);

    public static bool operator ==(QueryManagedSubAccountSnapshotType left, QueryManagedSubAccountSnapshotType right) => left.Equals(right);

    public static bool operator !=(QueryManagedSubAccountSnapshotType left, QueryManagedSubAccountSnapshotType right) => !left.Equals(right);

    public static implicit operator QueryManagedSubAccountSnapshotType(string value) => new(value);

    public static QueryManagedSubAccountSnapshotType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is QueryManagedSubAccountSnapshotType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(QueryManagedSubAccountSnapshotType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class QueryManagedSubAccountSnapshotRequest
{
    public required string Email { get; init; }

    public required QueryManagedSubAccountSnapshotType Type { get; init; }

    /// <summary>
    /// Query time range must be within 30 days and only supports data within the last month.
    /// </summary>
    public long? StartTime { get; init; }

    /// <summary>
    /// If both startTime and endTime are omitted, records from the last 7 days are returned by default.
    /// </summary>
    public long? EndTime { get; init; }

    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<QueryManagedSubAccountTransferLogMasterAccountInvestorTransferFunctionAccountType>))]
public readonly struct QueryManagedSubAccountTransferLogMasterAccountInvestorTransferFunctionAccountType : IExtensibleValue<QueryManagedSubAccountTransferLogMasterAccountInvestorTransferFunctionAccountType>, IEquatable<QueryManagedSubAccountTransferLogMasterAccountInvestorTransferFunctionAccountType>
{
    private readonly string? _value;

    public QueryManagedSubAccountTransferLogMasterAccountInvestorTransferFunctionAccountType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static QueryManagedSubAccountTransferLogMasterAccountInvestorTransferFunctionAccountType Spot { get; } = new("SPOT");

    public static QueryManagedSubAccountTransferLogMasterAccountInvestorTransferFunctionAccountType Margin { get; } = new("MARGIN");

    public static QueryManagedSubAccountTransferLogMasterAccountInvestorTransferFunctionAccountType IsolatedMargin { get; } = new("ISOLATED_MARGIN");

    public static QueryManagedSubAccountTransferLogMasterAccountInvestorTransferFunctionAccountType UsdtFuture { get; } = new("USDT_FUTURE");

    public static QueryManagedSubAccountTransferLogMasterAccountInvestorTransferFunctionAccountType CoinFuture { get; } = new("COIN_FUTURE");

    static QueryManagedSubAccountTransferLogMasterAccountInvestorTransferFunctionAccountType IExtensibleValue<QueryManagedSubAccountTransferLogMasterAccountInvestorTransferFunctionAccountType>.Create(string value) => new(value);

    public static bool operator ==(QueryManagedSubAccountTransferLogMasterAccountInvestorTransferFunctionAccountType left, QueryManagedSubAccountTransferLogMasterAccountInvestorTransferFunctionAccountType right) => left.Equals(right);

    public static bool operator !=(QueryManagedSubAccountTransferLogMasterAccountInvestorTransferFunctionAccountType left, QueryManagedSubAccountTransferLogMasterAccountInvestorTransferFunctionAccountType right) => !left.Equals(right);

    public static implicit operator QueryManagedSubAccountTransferLogMasterAccountInvestorTransferFunctionAccountType(string value) => new(value);

    public static QueryManagedSubAccountTransferLogMasterAccountInvestorTransferFunctionAccountType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is QueryManagedSubAccountTransferLogMasterAccountInvestorTransferFunctionAccountType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(QueryManagedSubAccountTransferLogMasterAccountInvestorTransferFunctionAccountType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class QueryManagedSubAccountTransferLogMasterAccountInvestorRequest
{
    public required string Email { get; init; }

    /// <summary>Start Time</summary>
    public required long StartTime { get; init; }

    /// <summary>End Time (The start time and end time interval cannot exceed half a year)</summary>
    public required long EndTime { get; init; }

    /// <summary>Page</summary>
    public required long Page { get; init; }

    public required long Limit { get; init; }

    /// <summary>Transfer Direction (FROM/TO)</summary>
    public string? Transfers { get; init; }

    public QueryManagedSubAccountTransferLogMasterAccountInvestorTransferFunctionAccountType? TransferFunctionAccountType { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<QueryManagedSubAccountTransferLogMasterAccountTradingTransferFunctionAccountType>))]
public readonly struct QueryManagedSubAccountTransferLogMasterAccountTradingTransferFunctionAccountType : IExtensibleValue<QueryManagedSubAccountTransferLogMasterAccountTradingTransferFunctionAccountType>, IEquatable<QueryManagedSubAccountTransferLogMasterAccountTradingTransferFunctionAccountType>
{
    private readonly string? _value;

    public QueryManagedSubAccountTransferLogMasterAccountTradingTransferFunctionAccountType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static QueryManagedSubAccountTransferLogMasterAccountTradingTransferFunctionAccountType Spot { get; } = new("SPOT");

    public static QueryManagedSubAccountTransferLogMasterAccountTradingTransferFunctionAccountType Margin { get; } = new("MARGIN");

    public static QueryManagedSubAccountTransferLogMasterAccountTradingTransferFunctionAccountType IsolatedMargin { get; } = new("ISOLATED_MARGIN");

    public static QueryManagedSubAccountTransferLogMasterAccountTradingTransferFunctionAccountType UsdtFuture { get; } = new("USDT_FUTURE");

    public static QueryManagedSubAccountTransferLogMasterAccountTradingTransferFunctionAccountType CoinFuture { get; } = new("COIN_FUTURE");

    static QueryManagedSubAccountTransferLogMasterAccountTradingTransferFunctionAccountType IExtensibleValue<QueryManagedSubAccountTransferLogMasterAccountTradingTransferFunctionAccountType>.Create(string value) => new(value);

    public static bool operator ==(QueryManagedSubAccountTransferLogMasterAccountTradingTransferFunctionAccountType left, QueryManagedSubAccountTransferLogMasterAccountTradingTransferFunctionAccountType right) => left.Equals(right);

    public static bool operator !=(QueryManagedSubAccountTransferLogMasterAccountTradingTransferFunctionAccountType left, QueryManagedSubAccountTransferLogMasterAccountTradingTransferFunctionAccountType right) => !left.Equals(right);

    public static implicit operator QueryManagedSubAccountTransferLogMasterAccountTradingTransferFunctionAccountType(string value) => new(value);

    public static QueryManagedSubAccountTransferLogMasterAccountTradingTransferFunctionAccountType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is QueryManagedSubAccountTransferLogMasterAccountTradingTransferFunctionAccountType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(QueryManagedSubAccountTransferLogMasterAccountTradingTransferFunctionAccountType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class QueryManagedSubAccountTransferLogMasterAccountTradingRequest
{
    public required string Email { get; init; }

    /// <summary>Start Time</summary>
    public required long StartTime { get; init; }

    /// <summary>End Time (The start time and end time interval cannot exceed half a year)</summary>
    public required long EndTime { get; init; }

    public required long Page { get; init; }

    public required long Limit { get; init; }

    /// <summary>Transfer Direction (FROM/TO)</summary>
    public string? Transfers { get; init; }

    public QueryManagedSubAccountTransferLogMasterAccountTradingTransferFunctionAccountType? TransferFunctionAccountType { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<QueryManagedSubAccountTransferLogSubAccountTradingTransferFunctionAccountType>))]
public readonly struct QueryManagedSubAccountTransferLogSubAccountTradingTransferFunctionAccountType : IExtensibleValue<QueryManagedSubAccountTransferLogSubAccountTradingTransferFunctionAccountType>, IEquatable<QueryManagedSubAccountTransferLogSubAccountTradingTransferFunctionAccountType>
{
    private readonly string? _value;

    public QueryManagedSubAccountTransferLogSubAccountTradingTransferFunctionAccountType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static QueryManagedSubAccountTransferLogSubAccountTradingTransferFunctionAccountType Spot { get; } = new("SPOT");

    public static QueryManagedSubAccountTransferLogSubAccountTradingTransferFunctionAccountType Margin { get; } = new("MARGIN");

    public static QueryManagedSubAccountTransferLogSubAccountTradingTransferFunctionAccountType IsolatedMargin { get; } = new("ISOLATED_MARGIN");

    public static QueryManagedSubAccountTransferLogSubAccountTradingTransferFunctionAccountType UsdtFuture { get; } = new("USDT_FUTURE");

    public static QueryManagedSubAccountTransferLogSubAccountTradingTransferFunctionAccountType CoinFuture { get; } = new("COIN_FUTURE");

    static QueryManagedSubAccountTransferLogSubAccountTradingTransferFunctionAccountType IExtensibleValue<QueryManagedSubAccountTransferLogSubAccountTradingTransferFunctionAccountType>.Create(string value) => new(value);

    public static bool operator ==(QueryManagedSubAccountTransferLogSubAccountTradingTransferFunctionAccountType left, QueryManagedSubAccountTransferLogSubAccountTradingTransferFunctionAccountType right) => left.Equals(right);

    public static bool operator !=(QueryManagedSubAccountTransferLogSubAccountTradingTransferFunctionAccountType left, QueryManagedSubAccountTransferLogSubAccountTradingTransferFunctionAccountType right) => !left.Equals(right);

    public static implicit operator QueryManagedSubAccountTransferLogSubAccountTradingTransferFunctionAccountType(string value) => new(value);

    public static QueryManagedSubAccountTransferLogSubAccountTradingTransferFunctionAccountType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is QueryManagedSubAccountTransferLogSubAccountTradingTransferFunctionAccountType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(QueryManagedSubAccountTransferLogSubAccountTradingTransferFunctionAccountType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class QueryManagedSubAccountTransferLogSubAccountTradingRequest
{
    /// <summary>Start Time</summary>
    public required long StartTime { get; init; }

    /// <summary>End Time (The start time and end time interval cannot exceed half a year)</summary>
    public required long EndTime { get; init; }

    public required long Page { get; init; }

    public required long Limit { get; init; }

    /// <summary>Transfer Direction (from/to)</summary>
    public string? Transfers { get; init; }

    public QueryManagedSubAccountTransferLogSubAccountTradingTransferFunctionAccountType? TransferFunctionAccountType { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class WithdrawlAssetsFromTheManagedSubAccountRequest
{
    public required string FromEmail { get; init; }

    public required string Asset { get; init; }

    public required decimal Amount { get; init; }

    /// <summary>
    /// Withdrawal will happen automatically on the selected date (UTC 0). If no date is selected,
    /// withdrawal takes effect immediately.
    /// </summary>
    public long? TransferDate { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed partial class SubAccountRestApi
{

    /// <summary>
    /// Deposit Assets Into The Managed Sub-account (For Investor Master Account) (USER_DATA)
    /// </summary>
    /// <remarks>
    /// <para>Deposit Assets Into The Managed Sub-account</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>
    /// - You need to enable Enable Spot &amp; Margin Trading option for the api key which requests this
    /// endpoint
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<DepositAssetsIntoTheManagedSubAccountResponse>> DepositAssetsIntoTheManagedSubAccountAsync(DepositAssetsIntoTheManagedSubAccountRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/managed-subaccount/deposit", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<DepositAssetsIntoTheManagedSubAccountResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("toEmail", request.ToEmail);
        r.Query("asset", request.Asset);
        r.Query("amount", request.Amount);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.DepositAssetsIntoTheManagedSubAccountResponse, cancellationToken);
    }

    /// <summary>Get Managed Sub-account Deposit Address (For Investor Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get investor's managed sub-account deposit address.</para>
    /// <para>Weight(UID): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If network is not sent, the default network for the coin is returned.</para>
    /// <para>- When using LIGHTNING, amount must be provided.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetManagedSubAccountDepositAddressResponse>> GetManagedSubAccountDepositAddressAsync(GetManagedSubAccountDepositAddressRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/managed-subaccount/deposit/address", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetManagedSubAccountDepositAddressResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("email", request.Email);
        r.Query("coin", request.Coin);
        r.Query("network", request.Network);
        r.Query("amount", request.Amount);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.GetManagedSubAccountDepositAddressResponse, cancellationToken);
    }

    /// <summary>Query Managed Sub-account Asset Details (For Investor Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Managed Sub-account Asset Details</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryManagedSubAccountAssetDetailsResponseInner>>> QueryManagedSubAccountAssetDetailsAsync(QueryManagedSubAccountAssetDetailsRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/managed-subaccount/asset", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<QueryManagedSubAccountAssetDetailsResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("email", request.Email);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.ListQueryManagedSubAccountAssetDetailsResponseInner, cancellationToken);
    }

    /// <summary>
    /// Query Managed Sub-account Futures Asset Details (For Investor Master Account) (USER_DATA)
    /// </summary>
    /// <remarks>
    /// <para>Investor can use this api to query managed sub account futures asset details</para>
    /// <para>Weight(UID): 60</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryManagedSubAccountFuturesAssetDetailsResponse>> QueryManagedSubAccountFuturesAssetDetailsAsync(QueryManagedSubAccountFuturesAssetDetailsRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/managed-subaccount/fetch-future-asset", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryManagedSubAccountFuturesAssetDetailsResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("email", request.Email);
        r.Query("accountType", request.AccountType);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.QueryManagedSubAccountFuturesAssetDetailsResponse, cancellationToken);
    }

    /// <summary>Query Managed Sub-account List (For Investor) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get investor's managed sub-account list.</para>
    /// <para>Weight(UID): 60</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryManagedSubAccountListResponse>> QueryManagedSubAccountListAsync(QueryManagedSubAccountListRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/managed-subaccount/info", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("email", request.Email);
        r.Query("page", request.Page);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.QueryManagedSubAccountListResponse, cancellationToken);
    }

    /// <summary>
    /// Query Managed Sub-account Margin Asset Details (For Investor Master Account) (USER_DATA)
    /// </summary>
    /// <remarks>
    /// <para>Investor can use this api to query managed sub account margin asset details</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryManagedSubAccountMarginAssetDetailsResponse>> QueryManagedSubAccountMarginAssetDetailsAsync(QueryManagedSubAccountMarginAssetDetailsRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/managed-subaccount/marginAsset", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryManagedSubAccountMarginAssetDetailsResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("email", request.Email);
        r.Query("accountType", request.AccountType);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.QueryManagedSubAccountMarginAssetDetailsResponse, cancellationToken);
    }

    /// <summary>Query Managed Sub-account Snapshot (For Investor Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Managed Sub-account Snapshot</para>
    /// <para>Weight(IP): 2400</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- The query time range must be less than 30 days.</para>
    /// <para>- Only data from the most recent month is supported.</para>
    /// <para>- If startTime and endTime are omitted, records from the last 7 days are returned by default.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryManagedSubAccountSnapshotResponse>> QueryManagedSubAccountSnapshotAsync(QueryManagedSubAccountSnapshotRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/managed-subaccount/accountSnapshot", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryManagedSubAccountSnapshotResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("email", request.Email);
        r.Query("type", request.Type);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.QueryManagedSubAccountSnapshotResponse, cancellationToken);
    }

    /// <summary>Query Managed Sub Account Transfer Log For Investor Master Account (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Managed Sub Account Transfer Log For Investor Master Account</para>
    /// <para>
    /// Investor can use this api to query managed sub account transfer log. This endpoint is available for
    /// investor of Managed Sub-Account. A Managed Sub-Account is an account type for investors who value
    /// flexibility in asset allocation and account application, while delegating trades to a professional
    /// trading team.
    /// </para>
    /// <para>Please refer to link</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryManagedSubAccountTransferLogMasterAccountInvestorResponse>> QueryManagedSubAccountTransferLogMasterAccountInvestorAsync(QueryManagedSubAccountTransferLogMasterAccountInvestorRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/managed-subaccount/queryTransLogForInvestor", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryManagedSubAccountTransferLogMasterAccountInvestorResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("email", request.Email);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("page", request.Page);
        r.Query("limit", request.Limit);
        r.Query("transfers", request.Transfers);
        r.Query("transferFunctionAccountType", request.TransferFunctionAccountType);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.QueryManagedSubAccountTransferLogMasterAccountInvestorResponse, cancellationToken);
    }

    /// <summary>Query Managed Sub Account Transfer Log For Trading Team Master Account (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Managed Sub Account Transfer Log For Trading Team Master Account</para>
    /// <para>
    /// Trading team can use this api to query managed sub account transfer log. This endpoint is available
    /// for trading team of Managed Sub-Account. A Managed Sub-Account is an account type for investors who
    /// value flexibility in asset allocation and account application, while delegating trades to a
    /// professional trading team.
    /// </para>
    /// <para>Please refer to link</para>
    /// <para>Weight(UID): 60</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryManagedSubAccountTransferLogMasterAccountTradingResponse>> QueryManagedSubAccountTransferLogMasterAccountTradingAsync(QueryManagedSubAccountTransferLogMasterAccountTradingRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/managed-subaccount/queryTransLogForTradeParent", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryManagedSubAccountTransferLogMasterAccountTradingResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("email", request.Email);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("page", request.Page);
        r.Query("limit", request.Limit);
        r.Query("transfers", request.Transfers);
        r.Query("transferFunctionAccountType", request.TransferFunctionAccountType);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.QueryManagedSubAccountTransferLogMasterAccountTradingResponse, cancellationToken);
    }

    /// <summary>Query Managed Sub Account Transfer Log (For Trading Team Sub Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Managed Sub Account Transfer Log (For Trading Team Sub Account)</para>
    /// <para>Weight(UID): 60</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryManagedSubAccountTransferLogSubAccountTradingResponse>> QueryManagedSubAccountTransferLogSubAccountTradingAsync(QueryManagedSubAccountTransferLogSubAccountTradingRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/managed-subaccount/query-trans-log", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryManagedSubAccountTransferLogSubAccountTradingResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("page", request.Page);
        r.Query("limit", request.Limit);
        r.Query("transfers", request.Transfers);
        r.Query("transferFunctionAccountType", request.TransferFunctionAccountType);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.QueryManagedSubAccountTransferLogSubAccountTradingResponse, cancellationToken);
    }

    /// <summary>
    /// Withdrawl Assets From The Managed Sub-account (For Investor Master Account) (USER_DATA)
    /// </summary>
    /// <remarks>
    /// <para>Withdrawl Assets From The Managed Sub-account</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Your API key must have the permission Enable Spot &amp; Margin Trading.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<WithdrawlAssetsFromTheManagedSubAccountResponse>> WithdrawlAssetsFromTheManagedSubAccountAsync(WithdrawlAssetsFromTheManagedSubAccountRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/managed-subaccount/withdraw", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<WithdrawlAssetsFromTheManagedSubAccountResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("fromEmail", request.FromEmail);
        r.Query("asset", request.Asset);
        r.Query("amount", request.Amount);
        r.Query("transferDate", request.TransferDate);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.WithdrawlAssetsFromTheManagedSubAccountResponse, cancellationToken);
    }
}
