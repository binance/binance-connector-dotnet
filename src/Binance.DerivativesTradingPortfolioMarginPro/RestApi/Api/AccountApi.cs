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

namespace Binance.DerivativesTradingPortfolioMarginPro.RestApi;

[JsonConverter(typeof(ExtensibleValueConverter<BnbTransferTransferSide>))]
public readonly struct BnbTransferTransferSide : IExtensibleValue<BnbTransferTransferSide>, IEquatable<BnbTransferTransferSide>
{
    private readonly string? _value;

    public BnbTransferTransferSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static BnbTransferTransferSide ToUm { get; } = new("TO_UM");

    public static BnbTransferTransferSide FromUm { get; } = new("FROM_UM");

    static BnbTransferTransferSide IExtensibleValue<BnbTransferTransferSide>.Create(string value) => new(value);

    public static bool operator ==(BnbTransferTransferSide left, BnbTransferTransferSide right) => left.Equals(right);

    public static bool operator !=(BnbTransferTransferSide left, BnbTransferTransferSide right) => !left.Equals(right);

    public static implicit operator BnbTransferTransferSide(string value) => new(value);

    public static BnbTransferTransferSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is BnbTransferTransferSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(BnbTransferTransferSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class BnbTransferRequest
{
    public required decimal Amount { get; init; }

    public required BnbTransferTransferSide TransferSide { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<ChangeAutoRepayFuturesStatusAutoRepay>))]
public readonly struct ChangeAutoRepayFuturesStatusAutoRepay : IExtensibleValue<ChangeAutoRepayFuturesStatusAutoRepay>, IEquatable<ChangeAutoRepayFuturesStatusAutoRepay>
{
    private readonly string? _value;

    public ChangeAutoRepayFuturesStatusAutoRepay(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static ChangeAutoRepayFuturesStatusAutoRepay True { get; } = new("true");

    public static ChangeAutoRepayFuturesStatusAutoRepay False { get; } = new("false");

    static ChangeAutoRepayFuturesStatusAutoRepay IExtensibleValue<ChangeAutoRepayFuturesStatusAutoRepay>.Create(string value) => new(value);

    public static bool operator ==(ChangeAutoRepayFuturesStatusAutoRepay left, ChangeAutoRepayFuturesStatusAutoRepay right) => left.Equals(right);

    public static bool operator !=(ChangeAutoRepayFuturesStatusAutoRepay left, ChangeAutoRepayFuturesStatusAutoRepay right) => !left.Equals(right);

    public static implicit operator ChangeAutoRepayFuturesStatusAutoRepay(string value) => new(value);

    public static ChangeAutoRepayFuturesStatusAutoRepay FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ChangeAutoRepayFuturesStatusAutoRepay other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ChangeAutoRepayFuturesStatusAutoRepay other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class ChangeAutoRepayFuturesStatusRequest
{
    /// <summary>false for turn off the auto-repay futures negative balance function</summary>
    public required ChangeAutoRepayFuturesStatusAutoRepay AutoRepay { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class DeleteMarginCallLevelRequest
{
    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed class FundAutoCollectionRequest
{
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<FundCollectionByAssetFutureType>))]
public readonly struct FundCollectionByAssetFutureType : IExtensibleValue<FundCollectionByAssetFutureType>, IEquatable<FundCollectionByAssetFutureType>
{
    private readonly string? _value;

    public FundCollectionByAssetFutureType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static FundCollectionByAssetFutureType Um { get; } = new("UM");

    public static FundCollectionByAssetFutureType Cm { get; } = new("CM");

    public static FundCollectionByAssetFutureType Option { get; } = new("OPTION");

    static FundCollectionByAssetFutureType IExtensibleValue<FundCollectionByAssetFutureType>.Create(string value) => new(value);

    public static bool operator ==(FundCollectionByAssetFutureType left, FundCollectionByAssetFutureType right) => left.Equals(right);

    public static bool operator !=(FundCollectionByAssetFutureType left, FundCollectionByAssetFutureType right) => !left.Equals(right);

    public static implicit operator FundCollectionByAssetFutureType(string value) => new(value);

    public static FundCollectionByAssetFutureType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is FundCollectionByAssetFutureType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(FundCollectionByAssetFutureType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class FundCollectionByAssetRequest
{
    public required string Asset { get; init; }

    /// <summary>Amount to collect. When provided, futureType is required.</summary>
    public decimal? Amount { get; init; }

    /// <summary>
    /// Target wallet for the collection. OPTION is for SPAN only. Cannot be sent without amount. amount and
    /// futureType must be provided together. If neither is provided, existing behavior is unchanged (query
    /// all wallets + transfer).
    /// </summary>
    public FundCollectionByAssetFutureType? FutureType { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetAutoRepayFuturesStatusRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class GetDeltaModeStatusRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class GetMarginCallLevelRequest
{
    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetPortfolioMarginProAccountBalanceRequest
{
    public string? Asset { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetPortfolioMarginProAccountInfoRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class GetPortfolioMarginProSpanAccountInfoRequest
{
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<GetTransferableEarnAssetBalanceForPortfolioMarginTransferType>))]
public readonly struct GetTransferableEarnAssetBalanceForPortfolioMarginTransferType : IExtensibleValue<GetTransferableEarnAssetBalanceForPortfolioMarginTransferType>, IEquatable<GetTransferableEarnAssetBalanceForPortfolioMarginTransferType>
{
    private readonly string? _value;

    public GetTransferableEarnAssetBalanceForPortfolioMarginTransferType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static GetTransferableEarnAssetBalanceForPortfolioMarginTransferType EarnToFuture { get; } = new("EARN_TO_FUTURE");

    public static GetTransferableEarnAssetBalanceForPortfolioMarginTransferType FutureToEarn { get; } = new("FUTURE_TO_EARN");

    static GetTransferableEarnAssetBalanceForPortfolioMarginTransferType IExtensibleValue<GetTransferableEarnAssetBalanceForPortfolioMarginTransferType>.Create(string value) => new(value);

    public static bool operator ==(GetTransferableEarnAssetBalanceForPortfolioMarginTransferType left, GetTransferableEarnAssetBalanceForPortfolioMarginTransferType right) => left.Equals(right);

    public static bool operator !=(GetTransferableEarnAssetBalanceForPortfolioMarginTransferType left, GetTransferableEarnAssetBalanceForPortfolioMarginTransferType right) => !left.Equals(right);

    public static implicit operator GetTransferableEarnAssetBalanceForPortfolioMarginTransferType(string value) => new(value);

    public static GetTransferableEarnAssetBalanceForPortfolioMarginTransferType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is GetTransferableEarnAssetBalanceForPortfolioMarginTransferType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(GetTransferableEarnAssetBalanceForPortfolioMarginTransferType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class GetTransferableEarnAssetBalanceForPortfolioMarginRequest
{
    /// <summary>LDUSDT only</summary>
    public required string Asset { get; init; }

    public required GetTransferableEarnAssetBalanceForPortfolioMarginTransferType TransferType { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class PortfolioMarginProBankruptcyLoanRepayRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class QueryPortfolioMarginProBankruptcyLoanAmountRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class QueryPortfolioMarginProBankruptcyLoanRepayHistoryRequest
{
    /// <summary>Start time</summary>
    public long? StartTime { get; init; }

    /// <summary>End time</summary>
    public long? EndTime { get; init; }

    /// <summary>Number of results returned.</summary>
    public long? Size { get; init; }

    /// <summary>Currently querying page. Start from 1.</summary>
    public long? Current { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryPortfolioMarginProNegativeBalanceInterestHistoryRequest
{
    public string? Asset { get; init; }

    /// <summary>Start time</summary>
    public long? StartTime { get; init; }

    /// <summary>End time</summary>
    public long? EndTime { get; init; }

    /// <summary>Number of results returned.</summary>
    public long? Size { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class RepayFuturesNegativeBalanceRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class SetMarginCallLevelRequest
{
    /// <summary>The value must be within the range [1.1, 2.0].</summary>
    public required decimal MarginCallLevel { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<SwitchDeltaModeDeltaEnabled>))]
public readonly struct SwitchDeltaModeDeltaEnabled : IExtensibleValue<SwitchDeltaModeDeltaEnabled>, IEquatable<SwitchDeltaModeDeltaEnabled>
{
    private readonly string? _value;

    public SwitchDeltaModeDeltaEnabled(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static SwitchDeltaModeDeltaEnabled True { get; } = new("true");

    public static SwitchDeltaModeDeltaEnabled False { get; } = new("false");

    static SwitchDeltaModeDeltaEnabled IExtensibleValue<SwitchDeltaModeDeltaEnabled>.Create(string value) => new(value);

    public static bool operator ==(SwitchDeltaModeDeltaEnabled left, SwitchDeltaModeDeltaEnabled right) => left.Equals(right);

    public static bool operator !=(SwitchDeltaModeDeltaEnabled left, SwitchDeltaModeDeltaEnabled right) => !left.Equals(right);

    public static implicit operator SwitchDeltaModeDeltaEnabled(string value) => new(value);

    public static SwitchDeltaModeDeltaEnabled FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is SwitchDeltaModeDeltaEnabled other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(SwitchDeltaModeDeltaEnabled other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class SwitchDeltaModeRequest
{
    /// <summary>true to enable Delta mode; false to disable Delta mode</summary>
    public required SwitchDeltaModeDeltaEnabled DeltaEnabled { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<TransferLdusdtRwusdForPortfolioMarginAsset>))]
public readonly struct TransferLdusdtRwusdForPortfolioMarginAsset : IExtensibleValue<TransferLdusdtRwusdForPortfolioMarginAsset>, IEquatable<TransferLdusdtRwusdForPortfolioMarginAsset>
{
    private readonly string? _value;

    public TransferLdusdtRwusdForPortfolioMarginAsset(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static TransferLdusdtRwusdForPortfolioMarginAsset Ldusdt { get; } = new("LDUSDT");

    public static TransferLdusdtRwusdForPortfolioMarginAsset Rwusd { get; } = new("RWUSD");

    static TransferLdusdtRwusdForPortfolioMarginAsset IExtensibleValue<TransferLdusdtRwusdForPortfolioMarginAsset>.Create(string value) => new(value);

    public static bool operator ==(TransferLdusdtRwusdForPortfolioMarginAsset left, TransferLdusdtRwusdForPortfolioMarginAsset right) => left.Equals(right);

    public static bool operator !=(TransferLdusdtRwusdForPortfolioMarginAsset left, TransferLdusdtRwusdForPortfolioMarginAsset right) => !left.Equals(right);

    public static implicit operator TransferLdusdtRwusdForPortfolioMarginAsset(string value) => new(value);

    public static TransferLdusdtRwusdForPortfolioMarginAsset FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TransferLdusdtRwusdForPortfolioMarginAsset other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(TransferLdusdtRwusdForPortfolioMarginAsset other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<TransferLdusdtRwusdForPortfolioMarginTransferType>))]
public readonly struct TransferLdusdtRwusdForPortfolioMarginTransferType : IExtensibleValue<TransferLdusdtRwusdForPortfolioMarginTransferType>, IEquatable<TransferLdusdtRwusdForPortfolioMarginTransferType>
{
    private readonly string? _value;

    public TransferLdusdtRwusdForPortfolioMarginTransferType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static TransferLdusdtRwusdForPortfolioMarginTransferType EarnToFuture { get; } = new("EARN_TO_FUTURE");

    public static TransferLdusdtRwusdForPortfolioMarginTransferType FutureToEarn { get; } = new("FUTURE_TO_EARN");

    static TransferLdusdtRwusdForPortfolioMarginTransferType IExtensibleValue<TransferLdusdtRwusdForPortfolioMarginTransferType>.Create(string value) => new(value);

    public static bool operator ==(TransferLdusdtRwusdForPortfolioMarginTransferType left, TransferLdusdtRwusdForPortfolioMarginTransferType right) => left.Equals(right);

    public static bool operator !=(TransferLdusdtRwusdForPortfolioMarginTransferType left, TransferLdusdtRwusdForPortfolioMarginTransferType right) => !left.Equals(right);

    public static implicit operator TransferLdusdtRwusdForPortfolioMarginTransferType(string value) => new(value);

    public static TransferLdusdtRwusdForPortfolioMarginTransferType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TransferLdusdtRwusdForPortfolioMarginTransferType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(TransferLdusdtRwusdForPortfolioMarginTransferType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class TransferLdusdtRwusdForPortfolioMarginRequest
{
    public required TransferLdusdtRwusdForPortfolioMarginAsset Asset { get; init; }

    public required TransferLdusdtRwusdForPortfolioMarginTransferType TransferType { get; init; }

    public required decimal Amount { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed partial class DerivativesTradingPortfolioMarginProRestApi
{

    /// <summary>BNB transfer (USER_DATA)</summary>
    /// <remarks>
    /// <para>BNB transfer can be between Margin Account and USDM Account</para>
    /// <para>Weight(IP): 1500</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- You can only use this function 2 times per 10 minutes in a rolling manner</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<BnbTransferResponse>> BnbTransferAsync(BnbTransferRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/portfolio/bnb-transfer", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<BnbTransferResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("amount", request.Amount);
        r.Query("transferSide", request.TransferSide);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginProRestApiJson.Default.BnbTransferResponse, cancellationToken);
    }

    /// <summary>Change Auto-repay-futures Status (TRADE)</summary>
    /// <remarks>
    /// <para>Change Auto-repay-futures Status</para>
    /// <para>Weight(IP): 1500</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ChangeAutoRepayFuturesStatusResponse>> ChangeAutoRepayFuturesStatusAsync(ChangeAutoRepayFuturesStatusRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/portfolio/repay-futures-switch", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<ChangeAutoRepayFuturesStatusResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("autoRepay", request.AutoRepay);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginProRestApiJson.Default.ChangeAutoRepayFuturesStatusResponse, cancellationToken);
    }

    /// <summary>Delete Margin Call Level (USER_DATA)</summary>
    /// <remarks>
    /// <para>Delete the margin call level for a Portfolio Margin account.</para>
    /// <para>Weight(IP): 1500</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<DeleteMarginCallLevelResponse>> DeleteMarginCallLevelAsync(DeleteMarginCallLevelRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/sapi/v1/portfolio/margin-call-level", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginProRestApiJson.Default.DeleteMarginCallLevelResponse, cancellationToken);
    }

    /// <summary>Fund Auto-collection (USER_DATA)</summary>
    /// <remarks>
    /// <para>Transfers all assets from Futures Account to Margin account</para>
    /// <para>Weight(IP): 1500</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- The BNB would not be collected from UM-PM account to the Portfolio Margin account.</para>
    /// <para>- You can only use this function 500 times per hour in a rolling manner.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<FundAutoCollectionResponse>> FundAutoCollectionAsync(FundAutoCollectionRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/portfolio/auto-collection", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginProRestApiJson.Default.FundAutoCollectionResponse, cancellationToken);
    }

    /// <summary>Fund Collection by Asset (USER_DATA)</summary>
    /// <remarks>
    /// <para>Transfers specific asset from Futures Account to Margin account</para>
    /// <para>Weight(IP): 60</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- The BNB transfer is not be supported</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<FundCollectionByAssetResponse>> FundCollectionByAssetAsync(FundCollectionByAssetRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/portfolio/asset-collection", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<FundCollectionByAssetResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("asset", request.Asset);
        r.Query("amount", request.Amount);
        r.Query("futureType", request.FutureType);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginProRestApiJson.Default.FundCollectionByAssetResponse, cancellationToken);
    }

    /// <summary>Get Auto-repay-futures Status (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Auto-repay-futures Status</para>
    /// <para>Weight(IP): 30</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetAutoRepayFuturesStatusResponse>> GetAutoRepayFuturesStatusAsync(GetAutoRepayFuturesStatusRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/portfolio/repay-futures-switch", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginProRestApiJson.Default.GetAutoRepayFuturesStatusResponse, cancellationToken);
    }

    /// <summary>Get Delta Mode Status (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query the Delta mode status of current account.</para>
    /// <para>Weight(IP): 1500</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetDeltaModeStatusResponse>> GetDeltaModeStatusAsync(GetDeltaModeStatusRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/portfolio/delta-mode", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginProRestApiJson.Default.GetDeltaModeStatusResponse, cancellationToken);
    }

    /// <summary>Get Margin Call Level (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get the margin call level for a Portfolio Margin account.</para>
    /// <para>Weight(IP): 1500</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetMarginCallLevelResponse>> GetMarginCallLevelAsync(GetMarginCallLevelRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/portfolio/margin-call-level", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginProRestApiJson.Default.GetMarginCallLevelResponse, cancellationToken);
    }

    /// <summary>Get Portfolio Margin Pro Account Balance (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Portfolio Margin Pro account balance</para>
    /// <para>Weight(IP): 20</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<GetPortfolioMarginProAccountBalanceResponseInner>>> GetPortfolioMarginProAccountBalanceAsync(GetPortfolioMarginProAccountBalanceRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/portfolio/balance", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("asset", request.Asset);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginProRestApiJson.Default.ListGetPortfolioMarginProAccountBalanceResponseInner, cancellationToken);
    }

    /// <summary>Get Portfolio Margin Pro Account Info (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Portfolio Margin Pro Account Info</para>
    /// <para>Weight(UID): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetPortfolioMarginProAccountInfoResponse>> GetPortfolioMarginProAccountInfoAsync(GetPortfolioMarginProAccountInfoRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/portfolio/account", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginProRestApiJson.Default.GetPortfolioMarginProAccountInfoResponse, cancellationToken);
    }

    /// <summary>Get Portfolio Margin Pro SPAN Account Info (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Portfolio Margin Pro SPAN Account Info (For Portfolio Margin Pro SPAN users only)</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetPortfolioMarginProSpanAccountInfoResponse>> GetPortfolioMarginProSpanAccountInfoAsync(GetPortfolioMarginProSpanAccountInfoRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v2/portfolio/account", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginProRestApiJson.Default.GetPortfolioMarginProSpanAccountInfoResponse, cancellationToken);
    }

    /// <summary>Get Transferable Earn Asset Balance for Portfolio Margin (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get transferable earn asset balance for all types of Portfolio Margin account</para>
    /// <para>Weight(IP): 1500</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetTransferableEarnAssetBalanceForPortfolioMarginResponse>> GetTransferableEarnAssetBalanceForPortfolioMarginAsync(GetTransferableEarnAssetBalanceForPortfolioMarginRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/portfolio/earn-asset-balance", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetTransferableEarnAssetBalanceForPortfolioMarginResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("asset", request.Asset);
        r.Query("transferType", request.TransferType);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginProRestApiJson.Default.GetTransferableEarnAssetBalanceForPortfolioMarginResponse, cancellationToken);
    }

    /// <summary>Portfolio Margin Pro Bankruptcy Loan Repay (TRADE)</summary>
    /// <remarks>
    /// <para>Repay Portfolio Margin Pro Bankruptcy Loan</para>
    /// <para>Weight(UID): 3000</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>
    /// - Please note that the API Key has enabled Spot &amp; Margin Trading permissions to access this
    /// endpoint.
    /// </para>
    /// <para>- USDT is taken from the Spot account and transferred to the Cross Margin account to repay the loan.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<PortfolioMarginProBankruptcyLoanRepayResponse>> PortfolioMarginProBankruptcyLoanRepayAsync(PortfolioMarginProBankruptcyLoanRepayRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/portfolio/repay", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginProRestApiJson.Default.PortfolioMarginProBankruptcyLoanRepayResponse, cancellationToken);
    }

    /// <summary>Query Portfolio Margin Pro Bankruptcy Loan Amount (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Portfolio Margin Pro Bankruptcy Loan Amount</para>
    /// <para>Weight(UID): 500</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If there’s no classic portfolio margin bankruptcy loan, the amount would be 0</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryPortfolioMarginProBankruptcyLoanAmountResponse>> QueryPortfolioMarginProBankruptcyLoanAmountAsync(QueryPortfolioMarginProBankruptcyLoanAmountRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/portfolio/pmLoan", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginProRestApiJson.Default.QueryPortfolioMarginProBankruptcyLoanAmountResponse, cancellationToken);
    }

    /// <summary>Query Portfolio Margin Pro Bankruptcy Loan Repay History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query repay history of pmloan for portfolio margin pro.</para>
    /// <para>Weight(IP): 500</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- startTime and endTime cannot be longer than 360 days</para>
    /// <para>- If startTime and endTime not sent, return records of the last 30 days by default.</para>
    /// <para>- If startTimeis sent and endTime is not sent, return records of [startTime, startTime+30d].</para>
    /// <para>- If startTime is not sent and endTime is sent, return records of [endTime-30d, endTime].</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryPortfolioMarginProBankruptcyLoanRepayHistoryResponse>> QueryPortfolioMarginProBankruptcyLoanRepayHistoryAsync(QueryPortfolioMarginProBankruptcyLoanRepayHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/portfolio/pmloan-history", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("size", request.Size);
        r.Query("current", request.Current);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginProRestApiJson.Default.QueryPortfolioMarginProBankruptcyLoanRepayHistoryResponse, cancellationToken);
    }

    /// <summary>Query Portfolio Margin Pro Negative Balance Interest History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query interest history of negative balance for portfolio margin.</para>
    /// <para>Weight(IP): 50</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryPortfolioMarginProNegativeBalanceInterestHistoryResponseInner>>> QueryPortfolioMarginProNegativeBalanceInterestHistoryAsync(QueryPortfolioMarginProNegativeBalanceInterestHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/portfolio/interest-history", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("asset", request.Asset);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginProRestApiJson.Default.ListQueryPortfolioMarginProNegativeBalanceInterestHistoryResponseInner, cancellationToken);
    }

    /// <summary>Repay futures Negative Balance (USER_DATA)</summary>
    /// <remarks>
    /// <para>Repay futures Negative Balance</para>
    /// <para>Weight(IP): 1500</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- The negative balance is repaid from the Cross Margin account.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<RepayFuturesNegativeBalanceResponse>> RepayFuturesNegativeBalanceAsync(RepayFuturesNegativeBalanceRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/portfolio/repay-futures-negative-balance", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginProRestApiJson.Default.RepayFuturesNegativeBalanceResponse, cancellationToken);
    }

    /// <summary>Set Margin Call Level (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Set the margin call level for a Portfolio Margin account. When the account's uniMMR drops to the
    /// specified level, a notification will be sent via email and push/inbox.
    /// </para>
    /// <para>Weight(IP): 1500</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<SetMarginCallLevelResponse>> SetMarginCallLevelAsync(SetMarginCallLevelRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/portfolio/margin-call-level", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<SetMarginCallLevelResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("marginCallLevel", request.MarginCallLevel);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginProRestApiJson.Default.SetMarginCallLevelResponse, cancellationToken);
    }

    /// <summary>Switch Delta Mode (TRADE)</summary>
    /// <remarks>
    /// <para>Switch the Delta mode for existing PM PRO / PM RETAIL accounts.</para>
    /// <para>Weight(IP): 1500</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<SwitchDeltaModeResponse>> SwitchDeltaModeAsync(SwitchDeltaModeRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/portfolio/delta-mode", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<SwitchDeltaModeResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("deltaEnabled", request.DeltaEnabled);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginProRestApiJson.Default.SwitchDeltaModeResponse, cancellationToken);
    }

    /// <summary>Transfer LDUSDT/RWUSD for Portfolio Margin (TRADE)</summary>
    /// <remarks>
    /// <para>Transfer LDUSDT/RWUSD as collateral for all types of Portfolio Margin account</para>
    /// <para>Weight(UID): 1500</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<TransferLdusdtRwusdForPortfolioMarginResponse>> TransferLdusdtRwusdForPortfolioMarginAsync(TransferLdusdtRwusdForPortfolioMarginRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/portfolio/earn-asset-transfer", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<TransferLdusdtRwusdForPortfolioMarginResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("asset", request.Asset);
        r.Query("transferType", request.TransferType);
        r.Query("amount", request.Amount);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginProRestApiJson.Default.TransferLdusdtRwusdForPortfolioMarginResponse, cancellationToken);
    }
}
