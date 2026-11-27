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

namespace Binance.DerivativesTradingPortfolioMargin.RestApi;

public sealed class AccountBalanceRequest
{
    public string? Asset { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class AccountInformationRequest
{
    public long? RecvWindow { get; init; }
}

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

public sealed class ChangeCmInitialLeverageRequest
{
    public required string Symbol { get; init; }

    /// <summary>target initial leverage</summary>
    public required long Leverage { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<ChangeCmPositionModeDualSidePosition>))]
public readonly struct ChangeCmPositionModeDualSidePosition : IExtensibleValue<ChangeCmPositionModeDualSidePosition>, IEquatable<ChangeCmPositionModeDualSidePosition>
{
    private readonly string? _value;

    public ChangeCmPositionModeDualSidePosition(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static ChangeCmPositionModeDualSidePosition True { get; } = new("true");

    public static ChangeCmPositionModeDualSidePosition False { get; } = new("false");

    static ChangeCmPositionModeDualSidePosition IExtensibleValue<ChangeCmPositionModeDualSidePosition>.Create(string value) => new(value);

    public static bool operator ==(ChangeCmPositionModeDualSidePosition left, ChangeCmPositionModeDualSidePosition right) => left.Equals(right);

    public static bool operator !=(ChangeCmPositionModeDualSidePosition left, ChangeCmPositionModeDualSidePosition right) => !left.Equals(right);

    public static implicit operator ChangeCmPositionModeDualSidePosition(string value) => new(value);

    public static ChangeCmPositionModeDualSidePosition FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ChangeCmPositionModeDualSidePosition other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ChangeCmPositionModeDualSidePosition other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class ChangeCmPositionModeRequest
{
    /// <summary>"true": Hedge Mode; "false": One-way Mode</summary>
    public required ChangeCmPositionModeDualSidePosition DualSidePosition { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class ChangeUmInitialLeverageRequest
{
    public required string Symbol { get; init; }

    /// <summary>
    /// Target initial leverage. The maximum is symbol-specific: use initialLeverage of bracket 1 from GET
    /// /papi/v1/um/leverageBracket.
    /// </summary>
    public required long Leverage { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<ChangeUmPositionModeDualSidePosition>))]
public readonly struct ChangeUmPositionModeDualSidePosition : IExtensibleValue<ChangeUmPositionModeDualSidePosition>, IEquatable<ChangeUmPositionModeDualSidePosition>
{
    private readonly string? _value;

    public ChangeUmPositionModeDualSidePosition(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static ChangeUmPositionModeDualSidePosition True { get; } = new("true");

    public static ChangeUmPositionModeDualSidePosition False { get; } = new("false");

    static ChangeUmPositionModeDualSidePosition IExtensibleValue<ChangeUmPositionModeDualSidePosition>.Create(string value) => new(value);

    public static bool operator ==(ChangeUmPositionModeDualSidePosition left, ChangeUmPositionModeDualSidePosition right) => left.Equals(right);

    public static bool operator !=(ChangeUmPositionModeDualSidePosition left, ChangeUmPositionModeDualSidePosition right) => !left.Equals(right);

    public static implicit operator ChangeUmPositionModeDualSidePosition(string value) => new(value);

    public static ChangeUmPositionModeDualSidePosition FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ChangeUmPositionModeDualSidePosition other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ChangeUmPositionModeDualSidePosition other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class ChangeUmPositionModeRequest
{
    /// <summary>"true": Hedge Mode; "false": One-way Mode</summary>
    public required ChangeUmPositionModeDualSidePosition DualSidePosition { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class CmNotionalAndLeverageBracketsRequest
{
    public string? Symbol { get; init; }

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

public sealed class GetCmAccountDetailRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class GetCmCurrentPositionModeRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class GetCmFuturesOrderDownloadLinkByIdRequest
{
    /// <summary>get by download id api</summary>
    public required string DownloadId { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetCmFuturesTradeDownloadLinkByIdRequest
{
    /// <summary>get by download id api</summary>
    public required string DownloadId { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetCmFuturesTransactionDownloadLinkByIdRequest
{
    /// <summary>get by download id api</summary>
    public required string DownloadId { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<GetCmIncomeHistoryIncomeType>))]
public readonly struct GetCmIncomeHistoryIncomeType : IExtensibleValue<GetCmIncomeHistoryIncomeType>, IEquatable<GetCmIncomeHistoryIncomeType>
{
    private readonly string? _value;

    public GetCmIncomeHistoryIncomeType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static GetCmIncomeHistoryIncomeType Transfer { get; } = new("TRANSFER");

    public static GetCmIncomeHistoryIncomeType WelcomeBonus { get; } = new("WELCOME_BONUS");

    public static GetCmIncomeHistoryIncomeType FundingFee { get; } = new("FUNDING_FEE");

    public static GetCmIncomeHistoryIncomeType RealizedPnl { get; } = new("REALIZED_PNL");

    public static GetCmIncomeHistoryIncomeType Commission { get; } = new("COMMISSION");

    public static GetCmIncomeHistoryIncomeType InsuranceClear { get; } = new("INSURANCE_CLEAR");

    public static GetCmIncomeHistoryIncomeType DeliveredSettelment { get; } = new("DELIVERED_SETTELMENT");

    static GetCmIncomeHistoryIncomeType IExtensibleValue<GetCmIncomeHistoryIncomeType>.Create(string value) => new(value);

    public static bool operator ==(GetCmIncomeHistoryIncomeType left, GetCmIncomeHistoryIncomeType right) => left.Equals(right);

    public static bool operator !=(GetCmIncomeHistoryIncomeType left, GetCmIncomeHistoryIncomeType right) => !left.Equals(right);

    public static implicit operator GetCmIncomeHistoryIncomeType(string value) => new(value);

    public static GetCmIncomeHistoryIncomeType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is GetCmIncomeHistoryIncomeType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(GetCmIncomeHistoryIncomeType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class GetCmIncomeHistoryRequest
{
    public string? Symbol { get; init; }

    public GetCmIncomeHistoryIncomeType? IncomeType { get; init; }

    /// <summary>Timestamp in ms to get funding from INCLUSIVE.</summary>
    public long? StartTime { get; init; }

    /// <summary>Timestamp in ms to get funding until INCLUSIVE.</summary>
    public long? EndTime { get; init; }

    /// <summary>Number of results returned.</summary>
    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetDownloadIdForCmFuturesOrderHistoryRequest
{
    /// <summary>Timestamp in ms</summary>
    public required long StartTime { get; init; }

    /// <summary>Timestamp in ms</summary>
    public required long EndTime { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetDownloadIdForCmFuturesTradeHistoryRequest
{
    /// <summary>Timestamp in ms</summary>
    public required long StartTime { get; init; }

    /// <summary>Timestamp in ms</summary>
    public required long EndTime { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetDownloadIdForCmFuturesTransactionHistoryRequest
{
    /// <summary>Timestamp in ms</summary>
    public required long StartTime { get; init; }

    /// <summary>Timestamp in ms</summary>
    public required long EndTime { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetDownloadIdForUmFuturesOrderHistoryRequest
{
    /// <summary>Timestamp in ms</summary>
    public required long StartTime { get; init; }

    /// <summary>Timestamp in ms</summary>
    public required long EndTime { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetDownloadIdForUmFuturesTradeHistoryRequest
{
    /// <summary>Timestamp in ms</summary>
    public required long StartTime { get; init; }

    /// <summary>Timestamp in ms</summary>
    public required long EndTime { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetDownloadIdForUmFuturesTransactionHistoryRequest
{
    /// <summary>Timestamp in ms</summary>
    public required long StartTime { get; init; }

    /// <summary>Timestamp in ms</summary>
    public required long EndTime { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<GetMarginBorrowLoanInterestHistoryArchived>))]
public readonly struct GetMarginBorrowLoanInterestHistoryArchived : IExtensibleValue<GetMarginBorrowLoanInterestHistoryArchived>, IEquatable<GetMarginBorrowLoanInterestHistoryArchived>
{
    private readonly string? _value;

    public GetMarginBorrowLoanInterestHistoryArchived(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static GetMarginBorrowLoanInterestHistoryArchived True { get; } = new("true");

    public static GetMarginBorrowLoanInterestHistoryArchived False { get; } = new("false");

    static GetMarginBorrowLoanInterestHistoryArchived IExtensibleValue<GetMarginBorrowLoanInterestHistoryArchived>.Create(string value) => new(value);

    public static bool operator ==(GetMarginBorrowLoanInterestHistoryArchived left, GetMarginBorrowLoanInterestHistoryArchived right) => left.Equals(right);

    public static bool operator !=(GetMarginBorrowLoanInterestHistoryArchived left, GetMarginBorrowLoanInterestHistoryArchived right) => !left.Equals(right);

    public static implicit operator GetMarginBorrowLoanInterestHistoryArchived(string value) => new(value);

    public static GetMarginBorrowLoanInterestHistoryArchived FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is GetMarginBorrowLoanInterestHistoryArchived other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(GetMarginBorrowLoanInterestHistoryArchived other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class GetMarginBorrowLoanInterestHistoryRequest
{
    public string? Asset { get; init; }

    /// <summary>Timestamp in ms to get funding from INCLUSIVE.</summary>
    public long? StartTime { get; init; }

    /// <summary>Timestamp in ms to get funding until INCLUSIVE.</summary>
    public long? EndTime { get; init; }

    /// <summary>Current page number.</summary>
    public long? Current { get; init; }

    /// <summary>Number of results returned.</summary>
    public long? Size { get; init; }

    /// <summary>Set to true to query archived data from 6 months ago.</summary>
    public GetMarginBorrowLoanInterestHistoryArchived? Archived { get; init; }

    /// <summary>The value cannot be greater than 60000</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetUmAccountDetailRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class GetUmAccountDetailV2Request
{
    public long? RecvWindow { get; init; }
}

public sealed class GetUmCurrentPositionModeRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class GetUmFuturesOrderDownloadLinkByIdRequest
{
    /// <summary>get by download id api</summary>
    public required string DownloadId { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetUmFuturesTradeDownloadLinkByIdRequest
{
    /// <summary>get by download id api</summary>
    public required string DownloadId { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetUmFuturesTransactionDownloadLinkByIdRequest
{
    /// <summary>get by download id api</summary>
    public required string DownloadId { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<GetUmIncomeHistoryIncomeType>))]
public readonly struct GetUmIncomeHistoryIncomeType : IExtensibleValue<GetUmIncomeHistoryIncomeType>, IEquatable<GetUmIncomeHistoryIncomeType>
{
    private readonly string? _value;

    public GetUmIncomeHistoryIncomeType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static GetUmIncomeHistoryIncomeType Transfer { get; } = new("TRANSFER");

    public static GetUmIncomeHistoryIncomeType WelcomeBonus { get; } = new("WELCOME_BONUS");

    public static GetUmIncomeHistoryIncomeType RealizedPnl { get; } = new("REALIZED_PNL");

    public static GetUmIncomeHistoryIncomeType FundingFee { get; } = new("FUNDING_FEE");

    public static GetUmIncomeHistoryIncomeType Commission { get; } = new("COMMISSION");

    public static GetUmIncomeHistoryIncomeType InsuranceClear { get; } = new("INSURANCE_CLEAR");

    public static GetUmIncomeHistoryIncomeType ReferralKickback { get; } = new("REFERRAL_KICKBACK");

    public static GetUmIncomeHistoryIncomeType CommissionRebate { get; } = new("COMMISSION_REBATE");

    public static GetUmIncomeHistoryIncomeType ApiRebate { get; } = new("API_REBATE");

    public static GetUmIncomeHistoryIncomeType ContestReward { get; } = new("CONTEST_REWARD");

    public static GetUmIncomeHistoryIncomeType CrossCollateralTransfer { get; } = new("CROSS_COLLATERAL_TRANSFER");

    public static GetUmIncomeHistoryIncomeType OptionsPremiumFee { get; } = new("OPTIONS_PREMIUM_FEE");

    public static GetUmIncomeHistoryIncomeType OptionsSettleProfit { get; } = new("OPTIONS_SETTLE_PROFIT");

    public static GetUmIncomeHistoryIncomeType InternalTransfer { get; } = new("INTERNAL_TRANSFER");

    public static GetUmIncomeHistoryIncomeType DeliveredSettelment { get; } = new("DELIVERED_SETTELMENT");

    public static GetUmIncomeHistoryIncomeType CoinSwapDeposit { get; } = new("COIN_SWAP_DEPOSIT");

    public static GetUmIncomeHistoryIncomeType CoinSwapWithdraw { get; } = new("COIN_SWAP_WITHDRAW");

    public static GetUmIncomeHistoryIncomeType PositionLimitIncreaseFee { get; } = new("POSITION_LIMIT_INCREASE_FEE");

    static GetUmIncomeHistoryIncomeType IExtensibleValue<GetUmIncomeHistoryIncomeType>.Create(string value) => new(value);

    public static bool operator ==(GetUmIncomeHistoryIncomeType left, GetUmIncomeHistoryIncomeType right) => left.Equals(right);

    public static bool operator !=(GetUmIncomeHistoryIncomeType left, GetUmIncomeHistoryIncomeType right) => !left.Equals(right);

    public static implicit operator GetUmIncomeHistoryIncomeType(string value) => new(value);

    public static GetUmIncomeHistoryIncomeType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is GetUmIncomeHistoryIncomeType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(GetUmIncomeHistoryIncomeType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class GetUmIncomeHistoryRequest
{
    public string? Symbol { get; init; }

    /// <summary>Income type.</summary>
    public GetUmIncomeHistoryIncomeType? IncomeType { get; init; }

    /// <summary>Timestamp in ms to get funding from INCLUSIVE.</summary>
    public long? StartTime { get; init; }

    /// <summary>Timestamp in ms to get funding until INCLUSIVE.</summary>
    public long? EndTime { get; init; }

    /// <summary>Number of results returned.</summary>
    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetUserCommissionRateForCmRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetUserCommissionRateForUmRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class MarginMaxBorrowRequest
{
    public required string Asset { get; init; }

    /// <summary>The value cannot be greater than 60000</summary>
    public long? RecvWindow { get; init; }
}

public sealed class PortfolioMarginUmTradingQuantitativeRulesIndicatorsRequest
{
    public string? Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryCmPositionInformationRequest
{
    public string? MarginAsset { get; init; }

    public string? Pair { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<QueryMarginLoanRecordArchived>))]
public readonly struct QueryMarginLoanRecordArchived : IExtensibleValue<QueryMarginLoanRecordArchived>, IEquatable<QueryMarginLoanRecordArchived>
{
    private readonly string? _value;

    public QueryMarginLoanRecordArchived(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static QueryMarginLoanRecordArchived True { get; } = new("true");

    public static QueryMarginLoanRecordArchived False { get; } = new("false");

    static QueryMarginLoanRecordArchived IExtensibleValue<QueryMarginLoanRecordArchived>.Create(string value) => new(value);

    public static bool operator ==(QueryMarginLoanRecordArchived left, QueryMarginLoanRecordArchived right) => left.Equals(right);

    public static bool operator !=(QueryMarginLoanRecordArchived left, QueryMarginLoanRecordArchived right) => !left.Equals(right);

    public static implicit operator QueryMarginLoanRecordArchived(string value) => new(value);

    public static QueryMarginLoanRecordArchived FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is QueryMarginLoanRecordArchived other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(QueryMarginLoanRecordArchived other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class QueryMarginLoanRecordRequest
{
    public required string Asset { get; init; }

    /// <summary>the tranId in POST/papi/v1/marginLoan</summary>
    public long? TxId { get; init; }

    /// <summary>Timestamp in ms to get funding from INCLUSIVE.</summary>
    public long? StartTime { get; init; }

    /// <summary>Timestamp in ms to get funding until INCLUSIVE.</summary>
    public long? EndTime { get; init; }

    /// <summary>Current page number.</summary>
    public long? Current { get; init; }

    /// <summary>Number of results returned.</summary>
    public long? Size { get; init; }

    /// <summary>Set to true to query archived data from 6 months ago.</summary>
    public QueryMarginLoanRecordArchived? Archived { get; init; }

    /// <summary>The value cannot be greater than 60000</summary>
    public long? RecvWindow { get; init; }
}

public sealed class QueryMarginMaxWithdrawRequest
{
    public required string Asset { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<QueryMarginRepayRecordArchived>))]
public readonly struct QueryMarginRepayRecordArchived : IExtensibleValue<QueryMarginRepayRecordArchived>, IEquatable<QueryMarginRepayRecordArchived>
{
    private readonly string? _value;

    public QueryMarginRepayRecordArchived(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static QueryMarginRepayRecordArchived True { get; } = new("true");

    public static QueryMarginRepayRecordArchived False { get; } = new("false");

    static QueryMarginRepayRecordArchived IExtensibleValue<QueryMarginRepayRecordArchived>.Create(string value) => new(value);

    public static bool operator ==(QueryMarginRepayRecordArchived left, QueryMarginRepayRecordArchived right) => left.Equals(right);

    public static bool operator !=(QueryMarginRepayRecordArchived left, QueryMarginRepayRecordArchived right) => !left.Equals(right);

    public static implicit operator QueryMarginRepayRecordArchived(string value) => new(value);

    public static QueryMarginRepayRecordArchived FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is QueryMarginRepayRecordArchived other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(QueryMarginRepayRecordArchived other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class QueryMarginRepayRecordRequest
{
    public required string Asset { get; init; }

    /// <summary>the tranId in POST /papi/v1/repayLoan</summary>
    public long? TxId { get; init; }

    /// <summary>Timestamp in ms to get funding from INCLUSIVE.</summary>
    public long? StartTime { get; init; }

    /// <summary>Timestamp in ms to get funding until INCLUSIVE.</summary>
    public long? EndTime { get; init; }

    /// <summary>Current page number.</summary>
    public long? Current { get; init; }

    /// <summary>Number of results returned.</summary>
    public long? Size { get; init; }

    /// <summary>Set to true to query archived data from 6 months ago.</summary>
    public QueryMarginRepayRecordArchived? Archived { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryPortfolioMarginNegativeBalanceInterestHistoryRequest
{
    public string? Asset { get; init; }

    /// <summary>Timestamp in ms to get funding from INCLUSIVE.</summary>
    public long? StartTime { get; init; }

    /// <summary>Timestamp in ms to get funding until INCLUSIVE.</summary>
    public long? EndTime { get; init; }

    /// <summary>Number of results returned.</summary>
    public long? Size { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryUmPositionInformationRequest
{
    public string? Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryUserNegativeBalanceAutoExchangeRecordRequest
{
    public required long StartTime { get; init; }

    public required long EndTime { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryUserRateLimitRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class RepayFuturesNegativeBalanceRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class UmFuturesAccountConfigurationRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class UmFuturesSymbolConfigurationRequest
{
    /// <summary>Symbol</summary>
    public string? Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class UmNotionalAndLeverageBracketsRequest
{
    public string? Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed partial class DerivativesTradingPortfolioMarginRestApi
{

    /// <summary>Account Balance (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query account balance</para>
    /// <para>Weight(IP): 20</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<AccountBalanceResponse>> AccountBalanceAsync(AccountBalanceRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/balance", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("asset", request.Asset);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.AccountBalanceResponse, cancellationToken);
    }

    /// <summary>Account Information (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query account information</para>
    /// <para>Weight(IP): 20</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<AccountInformationResponse>> AccountInformationAsync(AccountInformationRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/account", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.AccountInformationResponse, cancellationToken);
    }

    /// <summary>BNB transfer (TRADE)</summary>
    /// <remarks>
    /// <para>Transfer BNB in and out of UM</para>
    /// <para>Weight(IP): 750</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- The endpoint can only be called 10 times per 10 minutes in a rolling manner</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<BnbTransferResponse>> BnbTransferAsync(BnbTransferRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/papi/v1/bnb-transfer", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<BnbTransferResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("amount", request.Amount);
        r.Query("transferSide", request.TransferSide);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.BnbTransferResponse, cancellationToken);
    }

    /// <summary>Change Auto-repay-futures Status (TRADE)</summary>
    /// <remarks>
    /// <para>Change Auto-repay-futures Status</para>
    /// <para>Weight(IP): 750</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ChangeAutoRepayFuturesStatusResponse>> ChangeAutoRepayFuturesStatusAsync(ChangeAutoRepayFuturesStatusRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/papi/v1/repay-futures-switch", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<ChangeAutoRepayFuturesStatusResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("autoRepay", request.AutoRepay);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ChangeAutoRepayFuturesStatusResponse, cancellationToken);
    }

    /// <summary>Change CM Initial Leverage (TRADE)</summary>
    /// <remarks>
    /// <para>Change user's initial leverage of specific symbol in CM.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ChangeCmInitialLeverageResponse>> ChangeCmInitialLeverageAsync(ChangeCmInitialLeverageRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/papi/v1/cm/leverage", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<ChangeCmInitialLeverageResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("leverage", request.Leverage);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ChangeCmInitialLeverageResponse, cancellationToken);
    }

    /// <summary>Change CM Position Mode (TRADE)</summary>
    /// <remarks>
    /// <para>Change user's position mode (Hedge Mode or One-way Mode ) on EVERY symbol in CM</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ChangeCmPositionModeResponse>> ChangeCmPositionModeAsync(ChangeCmPositionModeRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/papi/v1/cm/positionSide/dual", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<ChangeCmPositionModeResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("dualSidePosition", request.DualSidePosition);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ChangeCmPositionModeResponse, cancellationToken);
    }

    /// <summary>Change UM Initial Leverage (TRADE)</summary>
    /// <remarks>
    /// <para>Change user's initial leverage of specific symbol in UM.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ChangeUmInitialLeverageResponse>> ChangeUmInitialLeverageAsync(ChangeUmInitialLeverageRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/papi/v1/um/leverage", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<ChangeUmInitialLeverageResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("leverage", request.Leverage);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ChangeUmInitialLeverageResponse, cancellationToken);
    }

    /// <summary>Change UM Position Mode (TRADE)</summary>
    /// <remarks>
    /// <para>Change user's position mode (Hedge Mode or One-way Mode ) on EVERY symbol in UM</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ChangeUmPositionModeResponse>> ChangeUmPositionModeAsync(ChangeUmPositionModeRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/papi/v1/um/positionSide/dual", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<ChangeUmPositionModeResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("dualSidePosition", request.DualSidePosition);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ChangeUmPositionModeResponse, cancellationToken);
    }

    /// <summary>CM Notional and Leverage Brackets (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query CM notional and leverage brackets</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<CmNotionalAndLeverageBracketsResponseInner>>> CmNotionalAndLeverageBracketsAsync(CmNotionalAndLeverageBracketsRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/cm/leverageBracket", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ListCmNotionalAndLeverageBracketsResponseInner, cancellationToken);
    }

    /// <summary>Fund Auto-collection (TRADE)</summary>
    /// <remarks>
    /// <para>Fund collection for Portfolio Margin</para>
    /// <para>Weight(IP): 750</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- BNB assets will not be auto-collected.</para>
    /// <para>- Rolling window endpoint can be called at most 500 times per hour.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<FundAutoCollectionResponse>> FundAutoCollectionAsync(FundAutoCollectionRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/papi/v1/auto-collection", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.FundAutoCollectionResponse, cancellationToken);
    }

    /// <summary>Fund Collection by Asset (TRADE)</summary>
    /// <remarks>
    /// <para>Transfers specific asset from Futures Account to Margin account</para>
    /// <para>Weight(IP): 30</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- The BNB transfer is not be supported</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<FundCollectionByAssetResponse>> FundCollectionByAssetAsync(FundCollectionByAssetRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/papi/v1/asset-collection", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<FundCollectionByAssetResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("asset", request.Asset);
        r.Query("amount", request.Amount);
        r.Query("futureType", request.FutureType);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.FundCollectionByAssetResponse, cancellationToken);
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
        var r = new RestRequest("GET", "/papi/v1/repay-futures-switch", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.GetAutoRepayFuturesStatusResponse, cancellationToken);
    }

    /// <summary>Get CM Account Detail (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get current CM account asset and position information.</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetCmAccountDetailResponse>> GetCmAccountDetailAsync(GetCmAccountDetailRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/cm/account", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.GetCmAccountDetailResponse, cancellationToken);
    }

    /// <summary>Get CM Current Position Mode (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get user's position mode (Hedge Mode or One-way Mode ) on EVERY symbol in CM</para>
    /// <para>Weight(IP): 30</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetCmCurrentPositionModeResponse>> GetCmCurrentPositionModeAsync(GetCmCurrentPositionModeRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/cm/positionSide/dual", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.GetCmCurrentPositionModeResponse, cancellationToken);
    }

    /// <summary>Get CM Futures Order Download Link by Id (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get CM futures order download link by Id</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Download link expiration: 7 days</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetCmFuturesOrderDownloadLinkByIdResponse>> GetCmFuturesOrderDownloadLinkByIdAsync(GetCmFuturesOrderDownloadLinkByIdRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/cm/order/asyn/id", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetCmFuturesOrderDownloadLinkByIdResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("downloadId", request.DownloadId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.GetCmFuturesOrderDownloadLinkByIdResponse, cancellationToken);
    }

    /// <summary>Get CM Futures Trade Download Link by Id (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get CM futures trade download link by Id</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Download link expiration: 7 days</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetCmFuturesTradeDownloadLinkByIdResponse>> GetCmFuturesTradeDownloadLinkByIdAsync(GetCmFuturesTradeDownloadLinkByIdRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/cm/trade/asyn/id", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetCmFuturesTradeDownloadLinkByIdResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("downloadId", request.DownloadId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.GetCmFuturesTradeDownloadLinkByIdResponse, cancellationToken);
    }

    /// <summary>Get CM Futures Transaction Download Link by Id (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get CM futures Transaction download link by Id</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Download link expiration: 7 days</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetCmFuturesTransactionDownloadLinkByIdResponse>> GetCmFuturesTransactionDownloadLinkByIdAsync(GetCmFuturesTransactionDownloadLinkByIdRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/cm/income/asyn/id", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetCmFuturesTransactionDownloadLinkByIdResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("downloadId", request.DownloadId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.GetCmFuturesTransactionDownloadLinkByIdResponse, cancellationToken);
    }

    /// <summary>Get CM Income History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get CM Income History.</para>
    /// <para>Weight(IP): 30</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If incomeType is not sent, all kinds of flow will be returned</para>
    /// <para>- "trandId" is unique in the same "incomeType" for a user</para>
    /// <para>- The interval between startTime and endTime can not exceed 200 days:</para>
    /// <para>- If startTime and endTime are not sent, the last 200 days will be returned</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<GetCmIncomeHistoryResponseInner>>> GetCmIncomeHistoryAsync(GetCmIncomeHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/cm/income", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("incomeType", request.IncomeType);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ListGetCmIncomeHistoryResponseInner, cancellationToken);
    }

    /// <summary>Get Download Id For CM Futures Order History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get download id for CM futures order history</para>
    /// <para>Weight(IP): 1500</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Request Limitation is 10 times per month, shared by front end download page and rest api</para>
    /// <para>- The time between startTime and endTime can not be longer than 1 year</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetDownloadIdForCmFuturesOrderHistoryResponse>> GetDownloadIdForCmFuturesOrderHistoryAsync(GetDownloadIdForCmFuturesOrderHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/cm/order/asyn", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetDownloadIdForCmFuturesOrderHistoryResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.GetDownloadIdForCmFuturesOrderHistoryResponse, cancellationToken);
    }

    /// <summary>Get Download Id For CM Futures Trade History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get download id for CM futures trade history</para>
    /// <para>Weight(IP): 1500</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Request Limitation is 5 times per month, shared by front end download page and rest api</para>
    /// <para>- The time between startTime and endTime can not be longer than 1 year</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetDownloadIdForCmFuturesTradeHistoryResponse>> GetDownloadIdForCmFuturesTradeHistoryAsync(GetDownloadIdForCmFuturesTradeHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/cm/trade/asyn", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetDownloadIdForCmFuturesTradeHistoryResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.GetDownloadIdForCmFuturesTradeHistoryResponse, cancellationToken);
    }

    /// <summary>Get Download Id For CM Futures Transaction History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get download id for CM futures transaction history</para>
    /// <para>Weight(IP): 1500</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Request Limitation is 5 times per month, shared by front end download page and rest api</para>
    /// <para>- The time between startTime and endTime can not be longer than 1 year</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetDownloadIdForCmFuturesTransactionHistoryResponse>> GetDownloadIdForCmFuturesTransactionHistoryAsync(GetDownloadIdForCmFuturesTransactionHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/cm/income/asyn", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetDownloadIdForCmFuturesTransactionHistoryResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.GetDownloadIdForCmFuturesTransactionHistoryResponse, cancellationToken);
    }

    /// <summary>Get Download Id For UM Futures Order History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get download id for UM futures order history</para>
    /// <para>Weight(IP): 1500</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Request Limitation is 10 times per month, shared by front end download page and rest api</para>
    /// <para>- The time between startTime and endTime can not be longer than 1 year</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetDownloadIdForUmFuturesOrderHistoryResponse>> GetDownloadIdForUmFuturesOrderHistoryAsync(GetDownloadIdForUmFuturesOrderHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/um/order/asyn", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetDownloadIdForUmFuturesOrderHistoryResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.GetDownloadIdForUmFuturesOrderHistoryResponse, cancellationToken);
    }

    /// <summary>Get Download Id For UM Futures Trade History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get download id for UM futures trade history</para>
    /// <para>Weight(IP): 1500</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Request Limitation is 5 times per month, shared by front end download page and rest api</para>
    /// <para>- The time between startTime and endTime can not be longer than 1 year</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetDownloadIdForUmFuturesTradeHistoryResponse>> GetDownloadIdForUmFuturesTradeHistoryAsync(GetDownloadIdForUmFuturesTradeHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/um/trade/asyn", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetDownloadIdForUmFuturesTradeHistoryResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.GetDownloadIdForUmFuturesTradeHistoryResponse, cancellationToken);
    }

    /// <summary>Get Download Id For UM Futures Transaction History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get download id for UM futures transaction history</para>
    /// <para>Weight(IP): 1500</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Request Limitation is 5 times per month, shared by front end download page and rest api</para>
    /// <para>- The time between startTime and endTime can not be longer than 1 year</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetDownloadIdForUmFuturesTransactionHistoryResponse>> GetDownloadIdForUmFuturesTransactionHistoryAsync(GetDownloadIdForUmFuturesTransactionHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/um/income/asyn", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetDownloadIdForUmFuturesTransactionHistoryResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.GetDownloadIdForUmFuturesTransactionHistoryResponse, cancellationToken);
    }

    /// <summary>Get Margin Borrow/Loan Interest History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Margin Borrow/Loan Interest History</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Response in descending order</para>
    /// <para>
    /// - The max interval between startTime and endTime is 30 days. It is a MUST to ensure data
    /// correctness.
    /// </para>
    /// <para>- If startTime and endTime not sent, return records of the last 7 days by default</para>
    /// <para>
    /// - If startTime is sent and endTime is not sent, the records from startTime to the present will be
    /// returned; if startTime is more than 30 days ago, the records of the past 30 days will be returned.
    /// </para>
    /// <para>
    /// - If startTime is not sent and endTime is sent, the records of the 7 days before endTime is
    /// returned.
    /// </para>
    /// <para>- Type in response has 5 enums:</para>
    /// <para>- PERIODIC interest charged per hour</para>
    /// <para>- ON_BORROW first interest charged on borrow</para>
    /// <para>- PERIODIC_CONVERTED interest charged per hour converted into BNB</para>
    /// <para>- ON_BORROW_CONVERTED first interest charged on borrow converted into BNB</para>
    /// <para>- PORTFOLIO Portfolio Margin negative balance daily interest</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetMarginBorrowLoanInterestHistoryResponse>> GetMarginBorrowLoanInterestHistoryAsync(GetMarginBorrowLoanInterestHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/margin/marginInterestHistory", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("asset", request.Asset);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("archived", request.Archived);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.GetMarginBorrowLoanInterestHistoryResponse, cancellationToken);
    }

    /// <summary>Get UM Account Detail (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get current UM account asset and position information.</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetUmAccountDetailResponse>> GetUmAccountDetailAsync(GetUmAccountDetailRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/um/account", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.GetUmAccountDetailResponse, cancellationToken);
    }

    /// <summary>Get UM Account Detail V2 (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get current UM account asset and position information.</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetUmAccountDetailV2Response>> GetUmAccountDetailV2Async(GetUmAccountDetailV2Request? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v2/um/account", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.GetUmAccountDetailV2Response, cancellationToken);
    }

    /// <summary>Get UM Current Position Mode (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get user's position mode (Hedge Mode or One-way Mode ) on EVERY symbol in UM</para>
    /// <para>Weight(IP): 30</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetUmCurrentPositionModeResponse>> GetUmCurrentPositionModeAsync(GetUmCurrentPositionModeRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/um/positionSide/dual", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.GetUmCurrentPositionModeResponse, cancellationToken);
    }

    /// <summary>Get UM Futures Order Download Link by Id (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get UM futures order download link by Id</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Download link expiration: 7 days</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetUmFuturesOrderDownloadLinkByIdResponse>> GetUmFuturesOrderDownloadLinkByIdAsync(GetUmFuturesOrderDownloadLinkByIdRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/um/order/asyn/id", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetUmFuturesOrderDownloadLinkByIdResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("downloadId", request.DownloadId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.GetUmFuturesOrderDownloadLinkByIdResponse, cancellationToken);
    }

    /// <summary>Get UM Futures Trade Download Link by Id (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get UM futures trade download link by Id</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Download link expiration: 7 days</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetUmFuturesTradeDownloadLinkByIdResponse>> GetUmFuturesTradeDownloadLinkByIdAsync(GetUmFuturesTradeDownloadLinkByIdRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/um/trade/asyn/id", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetUmFuturesTradeDownloadLinkByIdResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("downloadId", request.DownloadId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.GetUmFuturesTradeDownloadLinkByIdResponse, cancellationToken);
    }

    /// <summary>Get UM Futures Transaction Download Link by Id (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get UM futures Transaction download link by Id</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Download link expiration: 7 days</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetUmFuturesTransactionDownloadLinkByIdResponse>> GetUmFuturesTransactionDownloadLinkByIdAsync(GetUmFuturesTransactionDownloadLinkByIdRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/um/income/asyn/id", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetUmFuturesTransactionDownloadLinkByIdResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("downloadId", request.DownloadId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.GetUmFuturesTransactionDownloadLinkByIdResponse, cancellationToken);
    }

    /// <summary>Get UM Income History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get UM Income History.</para>
    /// <para>Weight(IP): 30</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If neither startTime nor endTime is sent, the recent 7-day data will be returned.</para>
    /// <para>- If incomeType is not sent, all kinds of flow will be returned</para>
    /// <para>- "trandId" is unique in the same incomeType for a user</para>
    /// <para>- Income history only contains data for the last three months</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<GetUmIncomeHistoryResponseInner>>> GetUmIncomeHistoryAsync(GetUmIncomeHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/um/income", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("incomeType", request.IncomeType);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ListGetUmIncomeHistoryResponseInner, cancellationToken);
    }

    /// <summary>Get User Commission Rate for CM (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get User Commission Rate for CM</para>
    /// <para>Weight(IP): 20</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetUserCommissionRateForCmResponse>> GetUserCommissionRateForCmAsync(GetUserCommissionRateForCmRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/cm/commissionRate", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetUserCommissionRateForCmResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.GetUserCommissionRateForCmResponse, cancellationToken);
    }

    /// <summary>Get User Commission Rate for UM (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get User Commission Rate for UM</para>
    /// <para>Weight(IP): 20</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetUserCommissionRateForUmResponse>> GetUserCommissionRateForUmAsync(GetUserCommissionRateForUmRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/um/commissionRate", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetUserCommissionRateForUmResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.GetUserCommissionRateForUmResponse, cancellationToken);
    }

    /// <summary>Margin Max Borrow (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query margin max borrow</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<MarginMaxBorrowResponse>> MarginMaxBorrowAsync(MarginMaxBorrowRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/margin/maxBorrowable", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<MarginMaxBorrowResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("asset", request.Asset);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.MarginMaxBorrowResponse, cancellationToken);
    }

    /// <summary>Portfolio Margin UM Trading Quantitative Rules Indicators (USER_DATA)</summary>
    /// <remarks>
    /// <para>Portfolio Margin UM Trading Quantitative Rules Indicators</para>
    /// <para>Weight: - 1 for a single symbol</para>
    /// <para>- 10 when symbol is omitted</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<PortfolioMarginUmTradingQuantitativeRulesIndicatorsResponse>> PortfolioMarginUmTradingQuantitativeRulesIndicatorsAsync(PortfolioMarginUmTradingQuantitativeRulesIndicatorsRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/um/apiTradingStatus", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.PortfolioMarginUmTradingQuantitativeRulesIndicatorsResponse, cancellationToken);
    }

    /// <summary>Query CM Position Information (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get current CM position information.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>
    /// - If neither marginAsset nor pair is sent, positions of all symbols with TRADING status will be
    /// returned.
    /// </para>
    /// <para>- for One-way Mode user, the response will only show the "BOTH" positions</para>
    /// <para>- for Hedge Mode user, the response will show "LONG", and "SHORT" positions. Note</para>
    /// <para>- Please use with user data stream ACCOUNT_UPDATE to meet your timeliness and accuracy needs.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryCmPositionInformationResponseInner>>> QueryCmPositionInformationAsync(QueryCmPositionInformationRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/cm/positionRisk", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("marginAsset", request.MarginAsset);
        r.Query("pair", request.Pair);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ListQueryCmPositionInformationResponseInner, cancellationToken);
    }

    /// <summary>Query Margin Loan Record (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query margin loan record</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- txId or startTime must be sent. txId takes precedence.</para>
    /// <para>- Response in descending order</para>
    /// <para>- The max interval between startTime and endTime is 30 days.</para>
    /// <para>- If startTime and endTime not sent, return records of the last 7 days by default</para>
    /// <para>- Set archived to true to query data from 6 months ago</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryMarginLoanRecordResponse>> QueryMarginLoanRecordAsync(QueryMarginLoanRecordRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/margin/marginLoan", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryMarginLoanRecordResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("asset", request.Asset);
        r.Query("txId", request.TxId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("archived", request.Archived);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.QueryMarginLoanRecordResponse, cancellationToken);
    }

    /// <summary>Query Margin Max Withdraw (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Margin Max Withdraw</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryMarginMaxWithdrawResponse>> QueryMarginMaxWithdrawAsync(QueryMarginMaxWithdrawRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/margin/maxWithdraw", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryMarginMaxWithdrawResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("asset", request.Asset);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.QueryMarginMaxWithdrawResponse, cancellationToken);
    }

    /// <summary>Query Margin repay Record (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query margin repay record.</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- txId or startTime must be sent. txId takes precedence.</para>
    /// <para>- Response in descending order</para>
    /// <para>- The max interval between startTime and endTime is 30 days.</para>
    /// <para>- If startTime and endTime not sent, return records of the last 7 days by default</para>
    /// <para>- Set archived to true to query data from 6 months ago</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryMarginRepayRecordResponse>> QueryMarginRepayRecordAsync(QueryMarginRepayRecordRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/margin/repayLoan", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryMarginRepayRecordResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("asset", request.Asset);
        r.Query("txId", request.TxId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("archived", request.Archived);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.QueryMarginRepayRecordResponse, cancellationToken);
    }

    /// <summary>Query Portfolio Margin Negative Balance Interest History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query interest history of negative balance for portfolio margin.</para>
    /// <para>Weight(IP): 50</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Results are returned in descending order.</para>
    /// <para>- The query range cannot exceed 30 days to ensure data correctness.</para>
    /// <para>- If both startTime and endTime are omitted, the most recent 7 days are returned by default.</para>
    /// <para>
    /// - If startTime is provided but endTime is omitted, records from startTime to now are returned; if
    /// that exceeds 30 days, only the most recent 30 days are returned.
    /// </para>
    /// <para>
    /// - If endTime is provided but startTime is omitted, records from the 7 days before endTime are
    /// returned.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryPortfolioMarginNegativeBalanceInterestHistoryResponseInner>>> QueryPortfolioMarginNegativeBalanceInterestHistoryAsync(QueryPortfolioMarginNegativeBalanceInterestHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/portfolio/interest-history", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("asset", request.Asset);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ListQueryPortfolioMarginNegativeBalanceInterestHistoryResponseInner, cancellationToken);
    }

    /// <summary>Query UM Position Information (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get current UM position information.</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Please use with account push event ACCOUNT_UPDATE for timeliness and accuracy.</para>
    /// <para>- In One-way Mode, only positions with side BOTH are shown.</para>
    /// <para>- In Hedge Mode, positions with sides BOTH, LONG, and SHORT are shown.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryUmPositionInformationResponseInner>>> QueryUmPositionInformationAsync(QueryUmPositionInformationRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/um/positionRisk", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ListQueryUmPositionInformationResponseInner, cancellationToken);
    }

    /// <summary>Query User Negative Balance Auto Exchange Record (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query user negative balance auto exchange record</para>
    /// <para>Weight(IP): 100</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Response in descending order</para>
    /// <para>- The max interval between startTime and endTime is 3 months.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryUserNegativeBalanceAutoExchangeRecordResponse>> QueryUserNegativeBalanceAutoExchangeRecordAsync(QueryUserNegativeBalanceAutoExchangeRecordRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/portfolio/negative-balance-exchange-record", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryUserNegativeBalanceAutoExchangeRecordResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.QueryUserNegativeBalanceAutoExchangeRecordResponse, cancellationToken);
    }

    /// <summary>Query User Rate Limit (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query User Rate Limit</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryUserRateLimitResponseInner>>> QueryUserRateLimitAsync(QueryUserRateLimitRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/rateLimit/order", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ListQueryUserRateLimitResponseInner, cancellationToken);
    }

    /// <summary>Repay futures Negative Balance (USER_DATA)</summary>
    /// <remarks>
    /// <para>Repay futures Negative Balance</para>
    /// <para>Weight(IP): 750</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<RepayFuturesNegativeBalanceResponse>> RepayFuturesNegativeBalanceAsync(RepayFuturesNegativeBalanceRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/papi/v1/repay-futures-negative-balance", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.RepayFuturesNegativeBalanceResponse, cancellationToken);
    }

    /// <summary>UM Futures Account Configuration (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query UM Futures account configuration</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<UmFuturesAccountConfigurationResponse>> UmFuturesAccountConfigurationAsync(UmFuturesAccountConfigurationRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/um/accountConfig", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.UmFuturesAccountConfigurationResponse, cancellationToken);
    }

    /// <summary>UM Futures Symbol Configuration (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get current UM account symbol configuration.</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<UmFuturesSymbolConfigurationResponseInner>>> UmFuturesSymbolConfigurationAsync(UmFuturesSymbolConfigurationRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/um/symbolConfig", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ListUmFuturesSymbolConfigurationResponseInner, cancellationToken);
    }

    /// <summary>UM Notional and Leverage Brackets (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query UM notional and leverage brackets</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<UmNotionalAndLeverageBracketsResponseInner>>> UmNotionalAndLeverageBracketsAsync(UmNotionalAndLeverageBracketsRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/um/leverageBracket", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ListUmNotionalAndLeverageBracketsResponseInner, cancellationToken);
    }
}
