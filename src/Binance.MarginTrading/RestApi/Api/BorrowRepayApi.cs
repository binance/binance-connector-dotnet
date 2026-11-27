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

namespace Binance.MarginTrading.RestApi;

[JsonConverter(typeof(ExtensibleValueConverter<GetFutureHourlyInterestRateIsIsolated>))]
public readonly struct GetFutureHourlyInterestRateIsIsolated : IExtensibleValue<GetFutureHourlyInterestRateIsIsolated>, IEquatable<GetFutureHourlyInterestRateIsIsolated>
{
    private readonly string? _value;

    public GetFutureHourlyInterestRateIsIsolated(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static GetFutureHourlyInterestRateIsIsolated True { get; } = new("TRUE");

    public static GetFutureHourlyInterestRateIsIsolated False { get; } = new("FALSE");

    static GetFutureHourlyInterestRateIsIsolated IExtensibleValue<GetFutureHourlyInterestRateIsIsolated>.Create(string value) => new(value);

    public static bool operator ==(GetFutureHourlyInterestRateIsIsolated left, GetFutureHourlyInterestRateIsIsolated right) => left.Equals(right);

    public static bool operator !=(GetFutureHourlyInterestRateIsIsolated left, GetFutureHourlyInterestRateIsIsolated right) => !left.Equals(right);

    public static implicit operator GetFutureHourlyInterestRateIsIsolated(string value) => new(value);

    public static GetFutureHourlyInterestRateIsIsolated FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is GetFutureHourlyInterestRateIsIsolated other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(GetFutureHourlyInterestRateIsIsolated other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class GetFutureHourlyInterestRateRequest
{
    public required string Assets { get; init; }

    public required GetFutureHourlyInterestRateIsIsolated IsIsolated { get; init; }
}

public sealed class GetInterestHistoryRequest
{
    public string? Asset { get; init; }

    public string? IsolatedSymbol { get; init; }

    /// <summary>Only supports querying data from the past 90 days.</summary>
    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    public long? Current { get; init; }

    public long? Size { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountBorrowRepayIsIsolated>))]
public readonly struct MarginAccountBorrowRepayIsIsolated : IExtensibleValue<MarginAccountBorrowRepayIsIsolated>, IEquatable<MarginAccountBorrowRepayIsIsolated>
{
    private readonly string? _value;

    public MarginAccountBorrowRepayIsIsolated(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountBorrowRepayIsIsolated True { get; } = new("TRUE");

    public static MarginAccountBorrowRepayIsIsolated False { get; } = new("FALSE");

    static MarginAccountBorrowRepayIsIsolated IExtensibleValue<MarginAccountBorrowRepayIsIsolated>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountBorrowRepayIsIsolated left, MarginAccountBorrowRepayIsIsolated right) => left.Equals(right);

    public static bool operator !=(MarginAccountBorrowRepayIsIsolated left, MarginAccountBorrowRepayIsIsolated right) => !left.Equals(right);

    public static implicit operator MarginAccountBorrowRepayIsIsolated(string value) => new(value);

    public static MarginAccountBorrowRepayIsIsolated FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountBorrowRepayIsIsolated other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountBorrowRepayIsIsolated other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountBorrowRepayType>))]
public readonly struct MarginAccountBorrowRepayType : IExtensibleValue<MarginAccountBorrowRepayType>, IEquatable<MarginAccountBorrowRepayType>
{
    private readonly string? _value;

    public MarginAccountBorrowRepayType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountBorrowRepayType Borrow { get; } = new("BORROW");

    public static MarginAccountBorrowRepayType Repay { get; } = new("REPAY");

    static MarginAccountBorrowRepayType IExtensibleValue<MarginAccountBorrowRepayType>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountBorrowRepayType left, MarginAccountBorrowRepayType right) => left.Equals(right);

    public static bool operator !=(MarginAccountBorrowRepayType left, MarginAccountBorrowRepayType right) => !left.Equals(right);

    public static implicit operator MarginAccountBorrowRepayType(string value) => new(value);

    public static MarginAccountBorrowRepayType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountBorrowRepayType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountBorrowRepayType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class MarginAccountBorrowRepayRequest
{
    public required string Asset { get; init; }

    /// <summary>TRUE for Isolated Margin, FALSE for Cross Margin</summary>
    public required MarginAccountBorrowRepayIsIsolated IsIsolated { get; init; }

    public required string Amount { get; init; }

    public required MarginAccountBorrowRepayType Type { get; init; }

    /// <summary>Only for Isolated margin</summary>
    public string? Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<QueryBorrowRepayRecordsInMarginAccountType>))]
public readonly struct QueryBorrowRepayRecordsInMarginAccountType : IExtensibleValue<QueryBorrowRepayRecordsInMarginAccountType>, IEquatable<QueryBorrowRepayRecordsInMarginAccountType>
{
    private readonly string? _value;

    public QueryBorrowRepayRecordsInMarginAccountType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static QueryBorrowRepayRecordsInMarginAccountType Borrow { get; } = new("BORROW");

    public static QueryBorrowRepayRecordsInMarginAccountType Repay { get; } = new("REPAY");

    static QueryBorrowRepayRecordsInMarginAccountType IExtensibleValue<QueryBorrowRepayRecordsInMarginAccountType>.Create(string value) => new(value);

    public static bool operator ==(QueryBorrowRepayRecordsInMarginAccountType left, QueryBorrowRepayRecordsInMarginAccountType right) => left.Equals(right);

    public static bool operator !=(QueryBorrowRepayRecordsInMarginAccountType left, QueryBorrowRepayRecordsInMarginAccountType right) => !left.Equals(right);

    public static implicit operator QueryBorrowRepayRecordsInMarginAccountType(string value) => new(value);

    public static QueryBorrowRepayRecordsInMarginAccountType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is QueryBorrowRepayRecordsInMarginAccountType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(QueryBorrowRepayRecordsInMarginAccountType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class QueryBorrowRepayRecordsInMarginAccountRequest
{
    public required QueryBorrowRepayRecordsInMarginAccountType Type { get; init; }

    public string? Asset { get; init; }

    public string? IsolatedSymbol { get; init; }

    public long? TxId { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    public long? Current { get; init; }

    public long? Size { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryMarginInterestRateHistoryRequest
{
    public required string Asset { get; init; }

    public long? VipLevel { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryMaxBorrowRequest
{
    public required string Asset { get; init; }

    public string? IsolatedSymbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed partial class MarginTradingRestApi
{

    /// <summary>Get future hourly interest rate (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get future hourly interest rate</para>
    /// <para>Weight(IP): 100</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<GetFutureHourlyInterestRateResponseInner>>> GetFutureHourlyInterestRateAsync(GetFutureHourlyInterestRateRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/next-hourly-interest-rate", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<GetFutureHourlyInterestRateResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("assets", request.Assets);
        r.Query("isIsolated", request.IsIsolated);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.ListGetFutureHourlyInterestRateResponseInner, cancellationToken);
    }

    /// <summary>Get Interest History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Interest History</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Response in descending order</para>
    /// <para>- If isolatedSymbol is not sent, crossed margin data will be returned</para>
    /// <para>- The max interval between startTime and endTime is 30 days. It is a</para>
    /// <para>MUST to ensure data correctness.</para>
    /// <para>- If startTimeand endTime not sent, return records of the last 7</para>
    /// <para>days by default.</para>
    /// <para>- If startTime is sent and endTime is not sent, return records of</para>
    /// <para>[max(startTime, now-30d), now].</para>
    /// <para>- If startTime is not sent and endTime is sent, return records of</para>
    /// <para>[endTime-7, endTime]</para>
    /// <para>- type in response has 4 enums:</para>
    /// <para>- PERIODIC interest charged per hour</para>
    /// <para>- ON_BORROW first interest charged on borrow</para>
    /// <para>- PERIODIC_CONVERTED interest charged per hour converted into BNB</para>
    /// <para>- ON_BORROW_CONVERTED first interest charged on borrow converted into</para>
    /// <para>BNB</para>
    /// <para>- PORTFOLIO interest charged daily on the portfolio margin negative</para>
    /// <para>balance</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetInterestHistoryResponse>> GetInterestHistoryAsync(GetInterestHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/interestHistory", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("asset", request.Asset);
        r.Query("isolatedSymbol", request.IsolatedSymbol);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.GetInterestHistoryResponse, cancellationToken);
    }

    /// <summary>Margin account borrow/repay (USER_DATA)</summary>
    /// <remarks>
    /// <para>Margin account borrow/repay</para>
    /// <para>Weight(UID): 1500</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>
    /// - -3045 INSUFFICIENT_INVENTORY: returned when system borrowable inventory is below the requested
    /// amount, or when inventory is severely insufficient (all borrow requests rejected regardless of
    /// size). Monitor system asset availability and adjust borrow strategy accordingly.
    /// </para>
    /// <para>
    /// - -3006 EXCEED_MAX_BORROWABLE: borrow amount exceeds your current max borrowable limit. Query GET
    /// /sapi/v1/margin/maxBorrowable and adjust the request.
    /// </para>
    /// <para>
    /// - -3012 ASSET_ADMIN_BAN_BORROW: this asset does not currently support borrowing. Query GET
    /// /sapi/v1/margin/allAssets for asset borrow availability.
    /// </para>
    /// <para>
    /// - -3015 REPAY_EXCEED_LIABILITY: returned in two scenarios — (1) repay amount exceeds your
    /// outstanding liability, or (2) the remaining unpaid debt after this repayment would fall below
    /// Binance's minimum threshold. Adjust the repay amount accordingly.
    /// </para>
    /// <para>
    /// - -3007 HAS_PENDING_TRANSACTION: a borrow/repay transaction is already in progress on this account.
    /// Requests are processed in submission order across all assets, and an in-flight request briefly
    /// blocks subsequent ones. Typical processing time is ~100ms; space consecutive requests by at least
    /// 100ms. Auto-repay orders can also fail silently for this reason — verify outstanding liability after
    /// an auto-repay executes.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<MarginAccountBorrowRepayResponse>> MarginAccountBorrowRepayAsync(MarginAccountBorrowRepayRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/margin/borrow-repay", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<MarginAccountBorrowRepayResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("asset", request.Asset);
        r.Query("isIsolated", request.IsIsolated);
        r.Query("amount", request.Amount);
        r.Query("type", request.Type);
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.MarginAccountBorrowRepayResponse, cancellationToken);
    }

    /// <summary>Query borrow/repay records in Margin account (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query borrow/repay records in Margin account</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- txId or startTime must be sent. txId takes precedence.</para>
    /// <para>- Response in descending order</para>
    /// <para>
    /// - If an asset is sent, data within 30 days before endTime; If an asset is not sent, data within 7
    /// days before endTime
    /// </para>
    /// <para>- If neither startTime nor endTime is sent, the recent 7-day data will be returned.</para>
    /// <para>- startTime set as endTime - 7 days by default, endTime set as current time by default</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryBorrowRepayRecordsInMarginAccountResponse>> QueryBorrowRepayRecordsInMarginAccountAsync(QueryBorrowRepayRecordsInMarginAccountRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/borrow-repay", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryBorrowRepayRecordsInMarginAccountResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("type", request.Type);
        r.Query("asset", request.Asset);
        r.Query("isolatedSymbol", request.IsolatedSymbol);
        r.Query("txId", request.TxId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.QueryBorrowRepayRecordsInMarginAccountResponse, cancellationToken);
    }

    /// <summary>Query Margin Interest Rate History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Margin Interest Rate History</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryMarginInterestRateHistoryResponseInner>>> QueryMarginInterestRateHistoryAsync(QueryMarginInterestRateHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/interestRateHistory", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<QueryMarginInterestRateHistoryResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("asset", request.Asset);
        r.Query("vipLevel", request.VipLevel);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.ListQueryMarginInterestRateHistoryResponseInner, cancellationToken);
    }

    /// <summary>Query Max Borrow (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Max Borrow</para>
    /// <para>Weight(IP): 50</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If isolatedSymbol is not sent, crossed margin data will be sent.</para>
    /// <para>- borrowLimit is also available from https://www.binance.com/en/margin-fee</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryMaxBorrowResponse>> QueryMaxBorrowAsync(QueryMaxBorrowRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/maxBorrowable", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryMaxBorrowResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("asset", request.Asset);
        r.Query("isolatedSymbol", request.IsolatedSymbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.QueryMaxBorrowResponse, cancellationToken);
    }
}
