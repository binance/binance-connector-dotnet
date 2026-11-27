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

public sealed class AssetDetailRequest
{
    public string? Asset { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class AssetDividendRecordRequest
{
    public string? Asset { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class DustConvertRequest
{
    public required string Asset { get; init; }

    /// <summary>SPOT or MARGIN, default SPOT</summary>
    public string? AccountType { get; init; }

    /// <summary>A unique id for the request</summary>
    public string? ClientId { get; init; }

    public string? TargetAsset { get; init; }

    public string? ThirdPartyClientId { get; init; }

    public decimal? DustQuotaAssetToTargetAssetPrice { get; init; }
}

public sealed class DustConvertibleAssetsRequest
{
    public required string TargetAsset { get; init; }

    /// <summary>SPOT or MARGIN, default SPOT</summary>
    public string? AccountType { get; init; }

    public decimal? DustQuotaAssetToTargetAssetPrice { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<DustTransferAccountType>))]
public readonly struct DustTransferAccountType : IExtensibleValue<DustTransferAccountType>, IEquatable<DustTransferAccountType>
{
    private readonly string? _value;

    public DustTransferAccountType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static DustTransferAccountType Spot { get; } = new("SPOT");

    public static DustTransferAccountType Margin { get; } = new("MARGIN");

    static DustTransferAccountType IExtensibleValue<DustTransferAccountType>.Create(string value) => new(value);

    public static bool operator ==(DustTransferAccountType left, DustTransferAccountType right) => left.Equals(right);

    public static bool operator !=(DustTransferAccountType left, DustTransferAccountType right) => !left.Equals(right);

    public static implicit operator DustTransferAccountType(string value) => new(value);

    public static DustTransferAccountType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is DustTransferAccountType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(DustTransferAccountType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class DustTransferRequest
{
    /// <summary>The asset being converted. For example: asset=BTC,USDT</summary>
    public required string Asset { get; init; }

    public DustTransferAccountType? AccountType { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<DustlogAccountType>))]
public readonly struct DustlogAccountType : IExtensibleValue<DustlogAccountType>, IEquatable<DustlogAccountType>
{
    private readonly string? _value;

    public DustlogAccountType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static DustlogAccountType Spot { get; } = new("SPOT");

    public static DustlogAccountType Margin { get; } = new("MARGIN");

    static DustlogAccountType IExtensibleValue<DustlogAccountType>.Create(string value) => new(value);

    public static bool operator ==(DustlogAccountType left, DustlogAccountType right) => left.Equals(right);

    public static bool operator !=(DustlogAccountType left, DustlogAccountType right) => !left.Equals(right);

    public static implicit operator DustlogAccountType(string value) => new(value);

    public static DustlogAccountType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is DustlogAccountType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(DustlogAccountType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class DustlogRequest
{
    public DustlogAccountType? AccountType { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class FundingWalletRequest
{
    public string? Asset { get; init; }

    public bool? NeedBtcValuation { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<GetAssetsThatCanBeConvertedIntoBnbAccountType>))]
public readonly struct GetAssetsThatCanBeConvertedIntoBnbAccountType : IExtensibleValue<GetAssetsThatCanBeConvertedIntoBnbAccountType>, IEquatable<GetAssetsThatCanBeConvertedIntoBnbAccountType>
{
    private readonly string? _value;

    public GetAssetsThatCanBeConvertedIntoBnbAccountType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static GetAssetsThatCanBeConvertedIntoBnbAccountType Spot { get; } = new("SPOT");

    public static GetAssetsThatCanBeConvertedIntoBnbAccountType Margin { get; } = new("MARGIN");

    static GetAssetsThatCanBeConvertedIntoBnbAccountType IExtensibleValue<GetAssetsThatCanBeConvertedIntoBnbAccountType>.Create(string value) => new(value);

    public static bool operator ==(GetAssetsThatCanBeConvertedIntoBnbAccountType left, GetAssetsThatCanBeConvertedIntoBnbAccountType right) => left.Equals(right);

    public static bool operator !=(GetAssetsThatCanBeConvertedIntoBnbAccountType left, GetAssetsThatCanBeConvertedIntoBnbAccountType right) => !left.Equals(right);

    public static implicit operator GetAssetsThatCanBeConvertedIntoBnbAccountType(string value) => new(value);

    public static GetAssetsThatCanBeConvertedIntoBnbAccountType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is GetAssetsThatCanBeConvertedIntoBnbAccountType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(GetAssetsThatCanBeConvertedIntoBnbAccountType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class GetAssetsThatCanBeConvertedIntoBnbRequest
{
    public GetAssetsThatCanBeConvertedIntoBnbAccountType? AccountType { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetCloudMiningPaymentAndRefundHistoryRequest
{
    /// <summary>inclusive, unit: ms</summary>
    public required long StartTime { get; init; }

    /// <summary>exclusive, unit: ms</summary>
    public required long EndTime { get; init; }

    /// <summary>The transaction id</summary>
    public long? TranId { get; init; }

    /// <summary>The unique flag</summary>
    public string? ClientTranId { get; init; }

    /// <summary>If it is blank, we will query all assets</summary>
    public string? Asset { get; init; }

    public long? Current { get; init; }

    public long? Size { get; init; }
}

public sealed class GetSpotAssetTagsRequest
{
    /// <summary>
    /// Tag filter. Supports multiple comma-separated tags with OR semantics (an asset is returned if it
    /// matches any one tag); leading/trailing whitespace around each tag is ignored. Returns all eligible
    /// assets when omitted.
    /// </summary>
    public string? Tag { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<QueryUserDelegationHistoryType>))]
public readonly struct QueryUserDelegationHistoryType : IExtensibleValue<QueryUserDelegationHistoryType>, IEquatable<QueryUserDelegationHistoryType>
{
    private readonly string? _value;

    public QueryUserDelegationHistoryType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static QueryUserDelegationHistoryType Delegate { get; } = new("DELEGATE");

    public static QueryUserDelegationHistoryType Undelegate { get; } = new("UNDELEGATE");

    static QueryUserDelegationHistoryType IExtensibleValue<QueryUserDelegationHistoryType>.Create(string value) => new(value);

    public static bool operator ==(QueryUserDelegationHistoryType left, QueryUserDelegationHistoryType right) => left.Equals(right);

    public static bool operator !=(QueryUserDelegationHistoryType left, QueryUserDelegationHistoryType right) => !left.Equals(right);

    public static implicit operator QueryUserDelegationHistoryType(string value) => new(value);

    public static QueryUserDelegationHistoryType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is QueryUserDelegationHistoryType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(QueryUserDelegationHistoryType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class QueryUserDelegationHistoryRequest
{
    public required string Email { get; init; }

    public required long StartTime { get; init; }

    public required long EndTime { get; init; }

    public QueryUserDelegationHistoryType? Type { get; init; }

    public string? Asset { get; init; }

    public long? Current { get; init; }

    public long? Size { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<QueryUserUniversalTransferHistoryFromSymbol>))]
public readonly struct QueryUserUniversalTransferHistoryFromSymbol : IExtensibleValue<QueryUserUniversalTransferHistoryFromSymbol>, IEquatable<QueryUserUniversalTransferHistoryFromSymbol>
{
    private readonly string? _value;

    public QueryUserUniversalTransferHistoryFromSymbol(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static QueryUserUniversalTransferHistoryFromSymbol IsolatedmarginMargin { get; } = new("ISOLATEDMARGIN_MARGIN");

    public static QueryUserUniversalTransferHistoryFromSymbol IsolatedmarginIsolatedmargin { get; } = new("ISOLATEDMARGIN_ISOLATEDMARGIN");

    static QueryUserUniversalTransferHistoryFromSymbol IExtensibleValue<QueryUserUniversalTransferHistoryFromSymbol>.Create(string value) => new(value);

    public static bool operator ==(QueryUserUniversalTransferHistoryFromSymbol left, QueryUserUniversalTransferHistoryFromSymbol right) => left.Equals(right);

    public static bool operator !=(QueryUserUniversalTransferHistoryFromSymbol left, QueryUserUniversalTransferHistoryFromSymbol right) => !left.Equals(right);

    public static implicit operator QueryUserUniversalTransferHistoryFromSymbol(string value) => new(value);

    public static QueryUserUniversalTransferHistoryFromSymbol FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is QueryUserUniversalTransferHistoryFromSymbol other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(QueryUserUniversalTransferHistoryFromSymbol other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<QueryUserUniversalTransferHistoryToSymbol>))]
public readonly struct QueryUserUniversalTransferHistoryToSymbol : IExtensibleValue<QueryUserUniversalTransferHistoryToSymbol>, IEquatable<QueryUserUniversalTransferHistoryToSymbol>
{
    private readonly string? _value;

    public QueryUserUniversalTransferHistoryToSymbol(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static QueryUserUniversalTransferHistoryToSymbol MarginIsolatedmargin { get; } = new("MARGIN_ISOLATEDMARGIN");

    public static QueryUserUniversalTransferHistoryToSymbol IsolatedmarginIsolatedmargin { get; } = new("ISOLATEDMARGIN_ISOLATEDMARGIN");

    static QueryUserUniversalTransferHistoryToSymbol IExtensibleValue<QueryUserUniversalTransferHistoryToSymbol>.Create(string value) => new(value);

    public static bool operator ==(QueryUserUniversalTransferHistoryToSymbol left, QueryUserUniversalTransferHistoryToSymbol right) => left.Equals(right);

    public static bool operator !=(QueryUserUniversalTransferHistoryToSymbol left, QueryUserUniversalTransferHistoryToSymbol right) => !left.Equals(right);

    public static implicit operator QueryUserUniversalTransferHistoryToSymbol(string value) => new(value);

    public static QueryUserUniversalTransferHistoryToSymbol FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is QueryUserUniversalTransferHistoryToSymbol other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(QueryUserUniversalTransferHistoryToSymbol other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class QueryUserUniversalTransferHistoryRequest
{
    public required string Type { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    public long? Current { get; init; }

    public long? Size { get; init; }

    public QueryUserUniversalTransferHistoryFromSymbol? FromSymbol { get; init; }

    public QueryUserUniversalTransferHistoryToSymbol? ToSymbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryUserWalletBalanceRequest
{
    public string? QuoteAsset { get; init; }

    /// <summary>
    /// Whether to return the per-asset balance detail for each wallet. When false or omitted, the response
    /// is unchanged from current behavior.
    /// </summary>
    public bool? NeedBalanceDetail { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class ToggleBnbBurnOnSpotTradeAndMarginInterestRequest
{
    /// <summary>Determines whether to use BNB to pay for trading fees on SPOT</summary>
    public string? SpotBNBBurn { get; init; }

    /// <summary>Determines whether to use BNB to pay for margin loan's interest</summary>
    public string? InterestBNBBurn { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class TradeFeeRequest
{
    public string? Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class UserAssetRequest
{
    /// <summary>If asset is blank, then query all positive assets user have.</summary>
    public string? Asset { get; init; }

    /// <summary>Whether need btc valuation or not.</summary>
    public bool? NeedBtcValuation { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<UserUniversalTransferType>))]
public readonly struct UserUniversalTransferType : IExtensibleValue<UserUniversalTransferType>, IEquatable<UserUniversalTransferType>
{
    private readonly string? _value;

    public UserUniversalTransferType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static UserUniversalTransferType MainUmfuture { get; } = new("MAIN_UMFUTURE");

    public static UserUniversalTransferType MainCmfuture { get; } = new("MAIN_CMFUTURE");

    public static UserUniversalTransferType MainMargin { get; } = new("MAIN_MARGIN");

    public static UserUniversalTransferType UmfutureMain { get; } = new("UMFUTURE_MAIN");

    public static UserUniversalTransferType UmfutureMargin { get; } = new("UMFUTURE_MARGIN");

    public static UserUniversalTransferType CmfutureMain { get; } = new("CMFUTURE_MAIN");

    public static UserUniversalTransferType CmfutureMargin { get; } = new("CMFUTURE_MARGIN");

    public static UserUniversalTransferType MarginMain { get; } = new("MARGIN_MAIN");

    public static UserUniversalTransferType MarginUmfuture { get; } = new("MARGIN_UMFUTURE");

    public static UserUniversalTransferType MarginCmfuture { get; } = new("MARGIN_CMFUTURE");

    public static UserUniversalTransferType IsolatedmarginMargin { get; } = new("ISOLATEDMARGIN_MARGIN");

    public static UserUniversalTransferType MarginIsolatedmargin { get; } = new("MARGIN_ISOLATEDMARGIN");

    public static UserUniversalTransferType IsolatedmarginIsolatedmargin { get; } = new("ISOLATEDMARGIN_ISOLATEDMARGIN");

    public static UserUniversalTransferType MainFunding { get; } = new("MAIN_FUNDING");

    public static UserUniversalTransferType FundingMain { get; } = new("FUNDING_MAIN");

    public static UserUniversalTransferType FundingUmfuture { get; } = new("FUNDING_UMFUTURE");

    public static UserUniversalTransferType UmfutureFunding { get; } = new("UMFUTURE_FUNDING");

    public static UserUniversalTransferType MarginFunding { get; } = new("MARGIN_FUNDING");

    public static UserUniversalTransferType FundingMargin { get; } = new("FUNDING_MARGIN");

    public static UserUniversalTransferType FundingCmfuture { get; } = new("FUNDING_CMFUTURE");

    public static UserUniversalTransferType CmfutureFunding { get; } = new("CMFUTURE_FUNDING");

    public static UserUniversalTransferType MainOption { get; } = new("MAIN_OPTION");

    public static UserUniversalTransferType OptionMain { get; } = new("OPTION_MAIN");

    public static UserUniversalTransferType UmfutureOption { get; } = new("UMFUTURE_OPTION");

    public static UserUniversalTransferType OptionUmfuture { get; } = new("OPTION_UMFUTURE");

    public static UserUniversalTransferType MarginOption { get; } = new("MARGIN_OPTION");

    public static UserUniversalTransferType OptionMargin { get; } = new("OPTION_MARGIN");

    public static UserUniversalTransferType FundingOption { get; } = new("FUNDING_OPTION");

    public static UserUniversalTransferType OptionFunding { get; } = new("OPTION_FUNDING");

    public static UserUniversalTransferType MainPortfolioMargin { get; } = new("MAIN_PORTFOLIO_MARGIN");

    public static UserUniversalTransferType PortfolioMarginMain { get; } = new("PORTFOLIO_MARGIN_MAIN");

    static UserUniversalTransferType IExtensibleValue<UserUniversalTransferType>.Create(string value) => new(value);

    public static bool operator ==(UserUniversalTransferType left, UserUniversalTransferType right) => left.Equals(right);

    public static bool operator !=(UserUniversalTransferType left, UserUniversalTransferType right) => !left.Equals(right);

    public static implicit operator UserUniversalTransferType(string value) => new(value);

    public static UserUniversalTransferType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is UserUniversalTransferType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(UserUniversalTransferType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<UserUniversalTransferFromSymbol>))]
public readonly struct UserUniversalTransferFromSymbol : IExtensibleValue<UserUniversalTransferFromSymbol>, IEquatable<UserUniversalTransferFromSymbol>
{
    private readonly string? _value;

    public UserUniversalTransferFromSymbol(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static UserUniversalTransferFromSymbol IsolatedmarginMargin { get; } = new("ISOLATEDMARGIN_MARGIN");

    public static UserUniversalTransferFromSymbol IsolatedmarginIsolatedmargin { get; } = new("ISOLATEDMARGIN_ISOLATEDMARGIN");

    static UserUniversalTransferFromSymbol IExtensibleValue<UserUniversalTransferFromSymbol>.Create(string value) => new(value);

    public static bool operator ==(UserUniversalTransferFromSymbol left, UserUniversalTransferFromSymbol right) => left.Equals(right);

    public static bool operator !=(UserUniversalTransferFromSymbol left, UserUniversalTransferFromSymbol right) => !left.Equals(right);

    public static implicit operator UserUniversalTransferFromSymbol(string value) => new(value);

    public static UserUniversalTransferFromSymbol FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is UserUniversalTransferFromSymbol other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(UserUniversalTransferFromSymbol other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<UserUniversalTransferToSymbol>))]
public readonly struct UserUniversalTransferToSymbol : IExtensibleValue<UserUniversalTransferToSymbol>, IEquatable<UserUniversalTransferToSymbol>
{
    private readonly string? _value;

    public UserUniversalTransferToSymbol(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static UserUniversalTransferToSymbol MarginIsolatedmargin { get; } = new("MARGIN_ISOLATEDMARGIN");

    public static UserUniversalTransferToSymbol IsolatedmarginIsolatedmargin { get; } = new("ISOLATEDMARGIN_ISOLATEDMARGIN");

    static UserUniversalTransferToSymbol IExtensibleValue<UserUniversalTransferToSymbol>.Create(string value) => new(value);

    public static bool operator ==(UserUniversalTransferToSymbol left, UserUniversalTransferToSymbol right) => left.Equals(right);

    public static bool operator !=(UserUniversalTransferToSymbol left, UserUniversalTransferToSymbol right) => !left.Equals(right);

    public static implicit operator UserUniversalTransferToSymbol(string value) => new(value);

    public static UserUniversalTransferToSymbol FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is UserUniversalTransferToSymbol other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(UserUniversalTransferToSymbol other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class UserUniversalTransferRequest
{
    public required UserUniversalTransferType Type { get; init; }

    public required string Asset { get; init; }

    public required decimal Amount { get; init; }

    public UserUniversalTransferFromSymbol? FromSymbol { get; init; }

    public UserUniversalTransferToSymbol? ToSymbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed partial class WalletRestApi
{

    /// <summary>Asset Detail (USER_DATA)</summary>
    /// <remarks>
    /// <para>Fetch details of assets supported on Binance.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Please get network and other deposit or withdraw details from GET /sapi/v1/capital/config/getall.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<AssetDetailResponse>> AssetDetailAsync(AssetDetailRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/asset/assetDetail", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("asset", request.Asset);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.AssetDetailResponse, cancellationToken);
    }

    /// <summary>Asset Dividend Record (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query asset dividend record.</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- There cannot be more than 180 days between parameter startTime and endTime.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<AssetDividendRecordResponse>> AssetDividendRecordAsync(AssetDividendRecordRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/asset/assetDividend", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("asset", request.Asset);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.AssetDividendRecordResponse, cancellationToken);
    }

    /// <summary>Dust Convert (USER_DATA)</summary>
    /// <remarks>
    /// <para>Convert dust assets</para>
    /// <para>Weight(UID): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<DustConvertResponse>> DustConvertAsync(DustConvertRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/asset/dust-convert/convert", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<DustConvertResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("asset", request.Asset);
        r.Query("accountType", request.AccountType);
        r.Query("clientId", request.ClientId);
        r.Query("targetAsset", request.TargetAsset);
        r.Query("thirdPartyClientId", request.ThirdPartyClientId);
        r.Query("dustQuotaAssetToTargetAssetPrice", request.DustQuotaAssetToTargetAssetPrice);
        return _client.SendAsync(r, WalletRestApiJson.Default.DustConvertResponse, cancellationToken);
    }

    /// <summary>Dust Convertible Assets (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query dust convertible assets</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<DustConvertibleAssetsResponse>> DustConvertibleAssetsAsync(DustConvertibleAssetsRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/asset/dust-convert/query-convertible-assets", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<DustConvertibleAssetsResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("targetAsset", request.TargetAsset);
        r.Query("accountType", request.AccountType);
        r.Query("dustQuotaAssetToTargetAssetPrice", request.DustQuotaAssetToTargetAssetPrice);
        return _client.SendAsync(r, WalletRestApiJson.Default.DustConvertibleAssetsResponse, cancellationToken);
    }

    /// <summary>Dust Transfer (USER_DATA)</summary>
    /// <remarks>
    /// <para>Convert dust assets to BNB.</para>
    /// <para>Weight(UID): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>
    /// - You need to openEnable Spot &amp; Margin Trading permission for the API Key which requests this
    /// endpoint.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<DustTransferResponse>> DustTransferAsync(DustTransferRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/asset/dust", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<DustTransferResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("asset", request.Asset);
        r.Query("accountType", request.AccountType);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.DustTransferResponse, cancellationToken);
    }

    /// <summary>DustLog (USER_DATA)</summary>
    /// <remarks>
    /// <para>Dustlog</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Only return last 100 records</para>
    /// <para>- Only return records after 2020/12/01</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<DustlogResponse>> DustlogAsync(DustlogRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/asset/dribblet", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("accountType", request.AccountType);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.DustlogResponse, cancellationToken);
    }

    /// <summary>Funding Wallet (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Funding Wallet</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>
    /// - Currently supports querying the following business assets：Binance Pay, Binance Card, Binance Gift
    /// Card, Stock Token
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<FundingWalletResponseInner>>> FundingWalletAsync(FundingWalletRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/asset/get-funding-asset", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("asset", request.Asset);
        r.Query("needBtcValuation", request.NeedBtcValuation);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.ListFundingWalletResponseInner, cancellationToken);
    }

    /// <summary>Get Assets That Can Be Converted Into BNB (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Assets That Can Be Converted Into BNB</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetAssetsThatCanBeConvertedIntoBnbResponse>> GetAssetsThatCanBeConvertedIntoBnbAsync(GetAssetsThatCanBeConvertedIntoBnbRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/asset/dust-btc", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("accountType", request.AccountType);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.GetAssetsThatCanBeConvertedIntoBnbResponse, cancellationToken);
    }

    /// <summary>Get Cloud-Mining payment and refund history (USER_DATA)</summary>
    /// <remarks>
    /// <para>The query of Cloud-Mining payment and refund history</para>
    /// <para>Weight(UID): 600</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Just return the SUCCESS records of payment and refund.</para>
    /// <para>- For response, type = 248 means payment, type = 249 means refund, status =S means SUCCESS.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetCloudMiningPaymentAndRefundHistoryResponse>> GetCloudMiningPaymentAndRefundHistoryAsync(GetCloudMiningPaymentAndRefundHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/asset/ledger-transfer/cloud-mining/queryByPage", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetCloudMiningPaymentAndRefundHistoryResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("tranId", request.TranId);
        r.Query("clientTranId", request.ClientTranId);
        r.Query("asset", request.Asset);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        return _client.SendAsync(r, WalletRestApiJson.Default.GetCloudMiningPaymentAndRefundHistoryResponse, cancellationToken);
    }

    /// <summary>Get Open Symbol List (MARKET_DATA)</summary>
    /// <remarks>
    /// <para>Get the list of symbols that are scheduled to be opened for trading in the market.</para>
    /// <para>Weight(IP): 100</para>
    /// <para>Security Type: MARKET_DATA</para>
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<GetOpenSymbolListResponseInner>>> GetOpenSymbolListAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/spot/open-symbol-list", signed: false, hasTimeUnit: false);
        return _client.SendAsync(r, WalletRestApiJson.Default.ListGetOpenSymbolListResponseInner, cancellationToken);
    }

    /// <summary>Get Spot Asset Tags (MARKET_DATA)</summary>
    /// <remarks>
    /// <para>Get the tags configured for spot-tradable assets.</para>
    /// <para>Weight(IP): 100</para>
    /// <para>Security Type: MARKET_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<GetSpotAssetTagsResponseInner>>> GetSpotAssetTagsAsync(GetSpotAssetTagsRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/spot/asset/tags", signed: false, hasTimeUnit: false);
        request ??= new();
        r.Query("tag", request.Tag);
        return _client.SendAsync(r, WalletRestApiJson.Default.ListGetSpotAssetTagsResponseInner, cancellationToken);
    }

    /// <summary>Query User Delegation History(For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query User Delegation History</para>
    /// <para>Weight(IP): 60</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryUserDelegationHistoryResponse>> QueryUserDelegationHistoryAsync(QueryUserDelegationHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/asset/custody/transfer-history", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryUserDelegationHistoryResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("email", request.Email);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("type", request.Type);
        r.Query("asset", request.Asset);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.QueryUserDelegationHistoryResponse, cancellationToken);
    }

    /// <summary>Query User Universal Transfer History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query User Universal Transfer History</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- fromSymbol must be sent when type are ISOLATEDMARGIN_MARGIN and ISOLATEDMARGIN_ISOLATEDMARGIN</para>
    /// <para>- toSymbol must be sent when type are MARGIN_ISOLATEDMARGIN and ISOLATEDMARGIN_ISOLATEDMARGIN</para>
    /// <para>- Support query within the last 6 months only</para>
    /// <para>- If startTimeand endTime not sent, return records of the last 7 days by default</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryUserUniversalTransferHistoryResponse>> QueryUserUniversalTransferHistoryAsync(QueryUserUniversalTransferHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/asset/transfer", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryUserUniversalTransferHistoryResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("type", request.Type);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("fromSymbol", request.FromSymbol);
        r.Query("toSymbol", request.ToSymbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.QueryUserUniversalTransferHistoryResponse, cancellationToken);
    }

    /// <summary>Query User Wallet Balance (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query User Wallet Balance</para>
    /// <para>Weight(IP): 60</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryUserWalletBalanceResponseInner>>> QueryUserWalletBalanceAsync(QueryUserWalletBalanceRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/asset/wallet/balance", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("quoteAsset", request.QuoteAsset);
        r.Query("needBalanceDetail", request.NeedBalanceDetail);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.ListQueryUserWalletBalanceResponseInner, cancellationToken);
    }

    /// <summary>Toggle BNB Burn On Spot Trade And Margin Interest (USER_DATA)</summary>
    /// <remarks>
    /// <para>Toggle BNB Burn On Spot Trade And Margin Interest</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- "spotBNBBurn" and "interestBNBBurn" should be sent at least one.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ToggleBnbBurnOnSpotTradeAndMarginInterestResponse>> ToggleBnbBurnOnSpotTradeAndMarginInterestAsync(ToggleBnbBurnOnSpotTradeAndMarginInterestRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/bnbBurn", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("spotBNBBurn", request.SpotBNBBurn);
        r.Query("interestBNBBurn", request.InterestBNBBurn);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.ToggleBnbBurnOnSpotTradeAndMarginInterestResponse, cancellationToken);
    }

    /// <summary>Trade Fee (USER_DATA)</summary>
    /// <remarks>
    /// <para>Fetch trade fee</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<TradeFeeResponseInner>>> TradeFeeAsync(TradeFeeRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/asset/tradeFee", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.ListTradeFeeResponseInner, cancellationToken);
    }

    /// <summary>User Asset (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get user assets, just for positive data.</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If asset is set, then return this asset, otherwise return all assets positive.</para>
    /// <para>- If needBtcValuation is set, then return btcValudation.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<UserAssetResponseInner>>> UserAssetAsync(UserAssetRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v3/asset/getUserAsset", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("asset", request.Asset);
        r.Query("needBtcValuation", request.NeedBtcValuation);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.ListUserAssetResponseInner, cancellationToken);
    }

    /// <summary>User Universal Transfer (USER_DATA)</summary>
    /// <remarks>
    /// <para>User universal transfer</para>
    /// <para>Weight(UID): 300</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- You need to enable Permits Universal Transfer option for the API Key that requests this endpoint.</para>
    /// <para>- fromSymbol must be sent when type is ISOLATEDMARGIN_MARGIN or ISOLATEDMARGIN_ISOLATEDMARGIN.</para>
    /// <para>- toSymbol must be sent when type is MARGIN_ISOLATEDMARGIN or ISOLATEDMARGIN_ISOLATEDMARGIN.</para>
    /// <para>- ENUM of transfer types:</para>
    /// <para>- MAIN_UMFUTURE: Spot → USDⓈ-M Futures</para>
    /// <para>- MAIN_CMFUTURE: Spot → COIN-M Futures</para>
    /// <para>- MAIN_MARGIN: Spot → Margin (cross)</para>
    /// <para>- UMFUTURE_MAIN: USDⓈ-M Futures → Spot</para>
    /// <para>- UMFUTURE_MARGIN: USDⓈ-M Futures → Margin (cross)</para>
    /// <para>- CMFUTURE_MAIN: COIN-M Futures → Spot</para>
    /// <para>- CMFUTURE_MARGIN: COIN-M Futures → Margin (cross)</para>
    /// <para>- MARGIN_MAIN: Margin (cross) → Spot</para>
    /// <para>- MARGIN_UMFUTURE: Margin (cross) → USDⓈ-M Futures</para>
    /// <para>- MARGIN_CMFUTURE: Margin (cross) → COIN-M Futures</para>
    /// <para>- ISOLATEDMARGIN_MARGIN: Isolated margin → Margin (cross)</para>
    /// <para>- MARGIN_ISOLATEDMARGIN: Margin (cross) → Isolated margin</para>
    /// <para>- ISOLATEDMARGIN_ISOLATEDMARGIN: Isolated margin → Isolated margin</para>
    /// <para>- MAIN_FUNDING: Spot → Funding</para>
    /// <para>- FUNDING_MAIN: Funding → Spot</para>
    /// <para>- FUNDING_UMFUTURE: Funding → USDⓈ-M Futures</para>
    /// <para>- UMFUTURE_FUNDING: USDⓈ-M Futures → Funding</para>
    /// <para>- MARGIN_FUNDING: Margin (cross) → Funding</para>
    /// <para>- FUNDING_MARGIN: Funding → Margin (cross)</para>
    /// <para>- FUNDING_CMFUTURE: Funding → COIN-M Futures</para>
    /// <para>- CMFUTURE_FUNDING: COIN-M Futures → Funding</para>
    /// <para>- MAIN_OPTION: Spot → Options</para>
    /// <para>- OPTION_MAIN: Options → Spot</para>
    /// <para>- UMFUTURE_OPTION: USDⓈ-M Futures → Options</para>
    /// <para>- OPTION_UMFUTURE: Options → USDⓈ-M Futures</para>
    /// <para>- MARGIN_OPTION: Margin (cross) → Options</para>
    /// <para>- OPTION_MARGIN: Options → Margin (cross)</para>
    /// <para>- FUNDING_OPTION: Funding → Options</para>
    /// <para>- OPTION_FUNDING: Options → Funding</para>
    /// <para>- MAIN_PORTFOLIO_MARGIN: Spot → Portfolio Margin</para>
    /// <para>- PORTFOLIO_MARGIN_MAIN: Portfolio Margin → Spot</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<UserUniversalTransferResponse>> UserUniversalTransferAsync(UserUniversalTransferRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/asset/transfer", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<UserUniversalTransferResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("type", request.Type);
        r.Query("asset", request.Asset);
        r.Query("amount", request.Amount);
        r.Query("fromSymbol", request.FromSymbol);
        r.Query("toSymbol", request.ToSymbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.UserUniversalTransferResponse, cancellationToken);
    }
}
