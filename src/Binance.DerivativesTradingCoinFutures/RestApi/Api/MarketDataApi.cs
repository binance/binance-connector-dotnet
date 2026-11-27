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

namespace Binance.DerivativesTradingCoinFutures.RestApi;

[JsonConverter(typeof(ExtensibleValueConverter<BasisContractType>))]
public readonly struct BasisContractType : IExtensibleValue<BasisContractType>, IEquatable<BasisContractType>
{
    private readonly string? _value;

    public BasisContractType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static BasisContractType Perpetual { get; } = new("PERPETUAL");

    public static BasisContractType CurrentQuarter { get; } = new("CURRENT_QUARTER");

    public static BasisContractType NextQuarter { get; } = new("NEXT_QUARTER");

    static BasisContractType IExtensibleValue<BasisContractType>.Create(string value) => new(value);

    public static bool operator ==(BasisContractType left, BasisContractType right) => left.Equals(right);

    public static bool operator !=(BasisContractType left, BasisContractType right) => !left.Equals(right);

    public static implicit operator BasisContractType(string value) => new(value);

    public static BasisContractType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is BasisContractType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(BasisContractType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<BasisPeriod>))]
public readonly struct BasisPeriod : IExtensibleValue<BasisPeriod>, IEquatable<BasisPeriod>
{
    private readonly string? _value;

    public BasisPeriod(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static BasisPeriod Period5m { get; } = new("5m");

    public static BasisPeriod Period15m { get; } = new("15m");

    public static BasisPeriod Period30m { get; } = new("30m");

    public static BasisPeriod Period1h { get; } = new("1h");

    public static BasisPeriod Period2h { get; } = new("2h");

    public static BasisPeriod Period4h { get; } = new("4h");

    public static BasisPeriod Period6h { get; } = new("6h");

    public static BasisPeriod Period12h { get; } = new("12h");

    public static BasisPeriod Period1d { get; } = new("1d");

    static BasisPeriod IExtensibleValue<BasisPeriod>.Create(string value) => new(value);

    public static bool operator ==(BasisPeriod left, BasisPeriod right) => left.Equals(right);

    public static bool operator !=(BasisPeriod left, BasisPeriod right) => !left.Equals(right);

    public static implicit operator BasisPeriod(string value) => new(value);

    public static BasisPeriod FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is BasisPeriod other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(BasisPeriod other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class BasisRequest
{
    /// <summary>Pair.</summary>
    public required string Pair { get; init; }

    /// <summary>Contract type.</summary>
    public required BasisContractType ContractType { get; init; }

    /// <summary>Period interval.</summary>
    public required BasisPeriod Period { get; init; }

    /// <summary>Maximum number of records to return.</summary>
    public long? Limit { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }
}

public sealed class CompressedAggregateTradesListRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    /// <summary>ID to get aggregate trades from INCLUSIVE.</summary>
    public long? FromId { get; init; }

    /// <summary>Timestamp in ms to get aggregate trades from INCLUSIVE.</summary>
    public long? StartTime { get; init; }

    /// <summary>Timestamp in ms to get aggregate trades until INCLUSIVE.</summary>
    public long? EndTime { get; init; }

    /// <summary>Maximum number of records to return.</summary>
    public long? Limit { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<ContinuousContractKlineCandlestickDataContractType>))]
public readonly struct ContinuousContractKlineCandlestickDataContractType : IExtensibleValue<ContinuousContractKlineCandlestickDataContractType>, IEquatable<ContinuousContractKlineCandlestickDataContractType>
{
    private readonly string? _value;

    public ContinuousContractKlineCandlestickDataContractType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static ContinuousContractKlineCandlestickDataContractType Perpetual { get; } = new("PERPETUAL");

    public static ContinuousContractKlineCandlestickDataContractType CurrentQuarter { get; } = new("CURRENT_QUARTER");

    public static ContinuousContractKlineCandlestickDataContractType NextQuarter { get; } = new("NEXT_QUARTER");

    static ContinuousContractKlineCandlestickDataContractType IExtensibleValue<ContinuousContractKlineCandlestickDataContractType>.Create(string value) => new(value);

    public static bool operator ==(ContinuousContractKlineCandlestickDataContractType left, ContinuousContractKlineCandlestickDataContractType right) => left.Equals(right);

    public static bool operator !=(ContinuousContractKlineCandlestickDataContractType left, ContinuousContractKlineCandlestickDataContractType right) => !left.Equals(right);

    public static implicit operator ContinuousContractKlineCandlestickDataContractType(string value) => new(value);

    public static ContinuousContractKlineCandlestickDataContractType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ContinuousContractKlineCandlestickDataContractType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ContinuousContractKlineCandlestickDataContractType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<ContinuousContractKlineCandlestickDataInterval>))]
public readonly struct ContinuousContractKlineCandlestickDataInterval : IExtensibleValue<ContinuousContractKlineCandlestickDataInterval>, IEquatable<ContinuousContractKlineCandlestickDataInterval>
{
    private readonly string? _value;

    public ContinuousContractKlineCandlestickDataInterval(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static ContinuousContractKlineCandlestickDataInterval Interval1m { get; } = new("1m");

    public static ContinuousContractKlineCandlestickDataInterval Interval3m { get; } = new("3m");

    public static ContinuousContractKlineCandlestickDataInterval Interval5m { get; } = new("5m");

    public static ContinuousContractKlineCandlestickDataInterval Interval15m { get; } = new("15m");

    public static ContinuousContractKlineCandlestickDataInterval Interval30m { get; } = new("30m");

    public static ContinuousContractKlineCandlestickDataInterval Interval1h { get; } = new("1h");

    public static ContinuousContractKlineCandlestickDataInterval Interval2h { get; } = new("2h");

    public static ContinuousContractKlineCandlestickDataInterval Interval4h { get; } = new("4h");

    public static ContinuousContractKlineCandlestickDataInterval Interval6h { get; } = new("6h");

    public static ContinuousContractKlineCandlestickDataInterval Interval8h { get; } = new("8h");

    public static ContinuousContractKlineCandlestickDataInterval Interval12h { get; } = new("12h");

    public static ContinuousContractKlineCandlestickDataInterval Interval1d { get; } = new("1d");

    public static ContinuousContractKlineCandlestickDataInterval Interval3d { get; } = new("3d");

    public static ContinuousContractKlineCandlestickDataInterval Interval1w { get; } = new("1w");

    public static ContinuousContractKlineCandlestickDataInterval Interval1Month { get; } = new("1M");

    static ContinuousContractKlineCandlestickDataInterval IExtensibleValue<ContinuousContractKlineCandlestickDataInterval>.Create(string value) => new(value);

    public static bool operator ==(ContinuousContractKlineCandlestickDataInterval left, ContinuousContractKlineCandlestickDataInterval right) => left.Equals(right);

    public static bool operator !=(ContinuousContractKlineCandlestickDataInterval left, ContinuousContractKlineCandlestickDataInterval right) => !left.Equals(right);

    public static implicit operator ContinuousContractKlineCandlestickDataInterval(string value) => new(value);

    public static ContinuousContractKlineCandlestickDataInterval FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ContinuousContractKlineCandlestickDataInterval other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ContinuousContractKlineCandlestickDataInterval other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class ContinuousContractKlineCandlestickDataRequest
{
    /// <summary>After CM migration, accepts both CM and UM pair values.</summary>
    public required string Pair { get; init; }

    public required ContinuousContractKlineCandlestickDataContractType ContractType { get; init; }

    /// <summary>Interval</summary>
    public required ContinuousContractKlineCandlestickDataInterval Interval { get; init; }

    /// <summary>Start time</summary>
    public long? StartTime { get; init; }

    /// <summary>End time</summary>
    public long? EndTime { get; init; }

    /// <summary>Maximum number of records to return.</summary>
    public long? Limit { get; init; }
}

public sealed class GetFundingRateHistoryOfPerpetualFuturesRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    /// <summary>Timestamp in ms to get funding rate from INCLUSIVE.</summary>
    public long? StartTime { get; init; }

    /// <summary>Timestamp in ms to get funding rate until INCLUSIVE.</summary>
    public long? EndTime { get; init; }

    /// <summary>Maximum number of records to return.</summary>
    public long? Limit { get; init; }
}

public sealed class IndexPriceAndMarkPriceRequest
{
    public string? Symbol { get; init; }

    public string? Pair { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<IndexPriceKlineCandlestickDataInterval>))]
public readonly struct IndexPriceKlineCandlestickDataInterval : IExtensibleValue<IndexPriceKlineCandlestickDataInterval>, IEquatable<IndexPriceKlineCandlestickDataInterval>
{
    private readonly string? _value;

    public IndexPriceKlineCandlestickDataInterval(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static IndexPriceKlineCandlestickDataInterval Interval1m { get; } = new("1m");

    public static IndexPriceKlineCandlestickDataInterval Interval3m { get; } = new("3m");

    public static IndexPriceKlineCandlestickDataInterval Interval5m { get; } = new("5m");

    public static IndexPriceKlineCandlestickDataInterval Interval15m { get; } = new("15m");

    public static IndexPriceKlineCandlestickDataInterval Interval30m { get; } = new("30m");

    public static IndexPriceKlineCandlestickDataInterval Interval1h { get; } = new("1h");

    public static IndexPriceKlineCandlestickDataInterval Interval2h { get; } = new("2h");

    public static IndexPriceKlineCandlestickDataInterval Interval4h { get; } = new("4h");

    public static IndexPriceKlineCandlestickDataInterval Interval6h { get; } = new("6h");

    public static IndexPriceKlineCandlestickDataInterval Interval8h { get; } = new("8h");

    public static IndexPriceKlineCandlestickDataInterval Interval12h { get; } = new("12h");

    public static IndexPriceKlineCandlestickDataInterval Interval1d { get; } = new("1d");

    public static IndexPriceKlineCandlestickDataInterval Interval3d { get; } = new("3d");

    public static IndexPriceKlineCandlestickDataInterval Interval1w { get; } = new("1w");

    public static IndexPriceKlineCandlestickDataInterval Interval1Month { get; } = new("1M");

    static IndexPriceKlineCandlestickDataInterval IExtensibleValue<IndexPriceKlineCandlestickDataInterval>.Create(string value) => new(value);

    public static bool operator ==(IndexPriceKlineCandlestickDataInterval left, IndexPriceKlineCandlestickDataInterval right) => left.Equals(right);

    public static bool operator !=(IndexPriceKlineCandlestickDataInterval left, IndexPriceKlineCandlestickDataInterval right) => !left.Equals(right);

    public static implicit operator IndexPriceKlineCandlestickDataInterval(string value) => new(value);

    public static IndexPriceKlineCandlestickDataInterval FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is IndexPriceKlineCandlestickDataInterval other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(IndexPriceKlineCandlestickDataInterval other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class IndexPriceKlineCandlestickDataRequest
{
    /// <summary>After CM migration, accepts both CM and UM pair values.</summary>
    public required string Pair { get; init; }

    /// <summary>Interval</summary>
    public required IndexPriceKlineCandlestickDataInterval Interval { get; init; }

    /// <summary>Start time</summary>
    public long? StartTime { get; init; }

    /// <summary>End time</summary>
    public long? EndTime { get; init; }

    /// <summary>Maximum number of records to return.</summary>
    public long? Limit { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<KlineCandlestickDataInterval>))]
public readonly struct KlineCandlestickDataInterval : IExtensibleValue<KlineCandlestickDataInterval>, IEquatable<KlineCandlestickDataInterval>
{
    private readonly string? _value;

    public KlineCandlestickDataInterval(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static KlineCandlestickDataInterval Interval1m { get; } = new("1m");

    public static KlineCandlestickDataInterval Interval3m { get; } = new("3m");

    public static KlineCandlestickDataInterval Interval5m { get; } = new("5m");

    public static KlineCandlestickDataInterval Interval15m { get; } = new("15m");

    public static KlineCandlestickDataInterval Interval30m { get; } = new("30m");

    public static KlineCandlestickDataInterval Interval1h { get; } = new("1h");

    public static KlineCandlestickDataInterval Interval2h { get; } = new("2h");

    public static KlineCandlestickDataInterval Interval4h { get; } = new("4h");

    public static KlineCandlestickDataInterval Interval6h { get; } = new("6h");

    public static KlineCandlestickDataInterval Interval8h { get; } = new("8h");

    public static KlineCandlestickDataInterval Interval12h { get; } = new("12h");

    public static KlineCandlestickDataInterval Interval1d { get; } = new("1d");

    public static KlineCandlestickDataInterval Interval3d { get; } = new("3d");

    public static KlineCandlestickDataInterval Interval1w { get; } = new("1w");

    public static KlineCandlestickDataInterval Interval1Month { get; } = new("1M");

    static KlineCandlestickDataInterval IExtensibleValue<KlineCandlestickDataInterval>.Create(string value) => new(value);

    public static bool operator ==(KlineCandlestickDataInterval left, KlineCandlestickDataInterval right) => left.Equals(right);

    public static bool operator !=(KlineCandlestickDataInterval left, KlineCandlestickDataInterval right) => !left.Equals(right);

    public static implicit operator KlineCandlestickDataInterval(string value) => new(value);

    public static KlineCandlestickDataInterval FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is KlineCandlestickDataInterval other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(KlineCandlestickDataInterval other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class KlineCandlestickDataRequest
{
    /// <summary>After CM migration, accepts both CM and UM symbols.</summary>
    public required string Symbol { get; init; }

    /// <summary>Interval</summary>
    public required KlineCandlestickDataInterval Interval { get; init; }

    /// <summary>Start time</summary>
    public long? StartTime { get; init; }

    /// <summary>End time</summary>
    public long? EndTime { get; init; }

    /// <summary>Maximum number of records to return.</summary>
    public long? Limit { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<LongShortRatioPeriod>))]
public readonly struct LongShortRatioPeriod : IExtensibleValue<LongShortRatioPeriod>, IEquatable<LongShortRatioPeriod>
{
    private readonly string? _value;

    public LongShortRatioPeriod(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static LongShortRatioPeriod Period5m { get; } = new("5m");

    public static LongShortRatioPeriod Period15m { get; } = new("15m");

    public static LongShortRatioPeriod Period30m { get; } = new("30m");

    public static LongShortRatioPeriod Period1h { get; } = new("1h");

    public static LongShortRatioPeriod Period2h { get; } = new("2h");

    public static LongShortRatioPeriod Period4h { get; } = new("4h");

    public static LongShortRatioPeriod Period6h { get; } = new("6h");

    public static LongShortRatioPeriod Period12h { get; } = new("12h");

    public static LongShortRatioPeriod Period1d { get; } = new("1d");

    static LongShortRatioPeriod IExtensibleValue<LongShortRatioPeriod>.Create(string value) => new(value);

    public static bool operator ==(LongShortRatioPeriod left, LongShortRatioPeriod right) => left.Equals(right);

    public static bool operator !=(LongShortRatioPeriod left, LongShortRatioPeriod right) => !left.Equals(right);

    public static implicit operator LongShortRatioPeriod(string value) => new(value);

    public static LongShortRatioPeriod FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is LongShortRatioPeriod other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(LongShortRatioPeriod other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<LongShortRatioContractType>))]
public readonly struct LongShortRatioContractType : IExtensibleValue<LongShortRatioContractType>, IEquatable<LongShortRatioContractType>
{
    private readonly string? _value;

    public LongShortRatioContractType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static LongShortRatioContractType Perpetual { get; } = new("PERPETUAL");

    public static LongShortRatioContractType CurrentQuarter { get; } = new("CURRENT_QUARTER");

    public static LongShortRatioContractType NextQuarter { get; } = new("NEXT_QUARTER");

    static LongShortRatioContractType IExtensibleValue<LongShortRatioContractType>.Create(string value) => new(value);

    public static bool operator ==(LongShortRatioContractType left, LongShortRatioContractType right) => left.Equals(right);

    public static bool operator !=(LongShortRatioContractType left, LongShortRatioContractType right) => !left.Equals(right);

    public static implicit operator LongShortRatioContractType(string value) => new(value);

    public static LongShortRatioContractType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is LongShortRatioContractType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(LongShortRatioContractType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class LongShortRatioRequest
{
    /// <summary>BTCUSD</summary>
    public required string Pair { get; init; }

    public required LongShortRatioPeriod Period { get; init; }

    /// <summary>
    /// Contract type filter. If omitted, returns aggregated data across all contract types.
    /// </summary>
    public LongShortRatioContractType? ContractType { get; init; }

    /// <summary>Maximum number of records to return.</summary>
    public long? Limit { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<MarkPriceKlineCandlestickDataInterval>))]
public readonly struct MarkPriceKlineCandlestickDataInterval : IExtensibleValue<MarkPriceKlineCandlestickDataInterval>, IEquatable<MarkPriceKlineCandlestickDataInterval>
{
    private readonly string? _value;

    public MarkPriceKlineCandlestickDataInterval(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarkPriceKlineCandlestickDataInterval Interval1m { get; } = new("1m");

    public static MarkPriceKlineCandlestickDataInterval Interval3m { get; } = new("3m");

    public static MarkPriceKlineCandlestickDataInterval Interval5m { get; } = new("5m");

    public static MarkPriceKlineCandlestickDataInterval Interval15m { get; } = new("15m");

    public static MarkPriceKlineCandlestickDataInterval Interval30m { get; } = new("30m");

    public static MarkPriceKlineCandlestickDataInterval Interval1h { get; } = new("1h");

    public static MarkPriceKlineCandlestickDataInterval Interval2h { get; } = new("2h");

    public static MarkPriceKlineCandlestickDataInterval Interval4h { get; } = new("4h");

    public static MarkPriceKlineCandlestickDataInterval Interval6h { get; } = new("6h");

    public static MarkPriceKlineCandlestickDataInterval Interval8h { get; } = new("8h");

    public static MarkPriceKlineCandlestickDataInterval Interval12h { get; } = new("12h");

    public static MarkPriceKlineCandlestickDataInterval Interval1d { get; } = new("1d");

    public static MarkPriceKlineCandlestickDataInterval Interval3d { get; } = new("3d");

    public static MarkPriceKlineCandlestickDataInterval Interval1w { get; } = new("1w");

    public static MarkPriceKlineCandlestickDataInterval Interval1Month { get; } = new("1M");

    static MarkPriceKlineCandlestickDataInterval IExtensibleValue<MarkPriceKlineCandlestickDataInterval>.Create(string value) => new(value);

    public static bool operator ==(MarkPriceKlineCandlestickDataInterval left, MarkPriceKlineCandlestickDataInterval right) => left.Equals(right);

    public static bool operator !=(MarkPriceKlineCandlestickDataInterval left, MarkPriceKlineCandlestickDataInterval right) => !left.Equals(right);

    public static implicit operator MarkPriceKlineCandlestickDataInterval(string value) => new(value);

    public static MarkPriceKlineCandlestickDataInterval FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarkPriceKlineCandlestickDataInterval other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarkPriceKlineCandlestickDataInterval other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class MarkPriceKlineCandlestickDataRequest
{
    /// <summary>After CM migration, accepts both CM and UM symbols.</summary>
    public required string Symbol { get; init; }

    /// <summary>Interval</summary>
    public required MarkPriceKlineCandlestickDataInterval Interval { get; init; }

    /// <summary>Start time</summary>
    public long? StartTime { get; init; }

    /// <summary>End time</summary>
    public long? EndTime { get; init; }

    /// <summary>Maximum number of records to return.</summary>
    public long? Limit { get; init; }
}

public sealed class OldTradesLookupRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    /// <summary>Maximum number of records to return.</summary>
    public long? Limit { get; init; }

    /// <summary>TradeId to fetch from. Default gets most recent trades.</summary>
    public long? FromId { get; init; }
}

public sealed class OpenInterestRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<OpenInterestStatisticsPeriod>))]
public readonly struct OpenInterestStatisticsPeriod : IExtensibleValue<OpenInterestStatisticsPeriod>, IEquatable<OpenInterestStatisticsPeriod>
{
    private readonly string? _value;

    public OpenInterestStatisticsPeriod(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static OpenInterestStatisticsPeriod Period5m { get; } = new("5m");

    public static OpenInterestStatisticsPeriod Period15m { get; } = new("15m");

    public static OpenInterestStatisticsPeriod Period30m { get; } = new("30m");

    public static OpenInterestStatisticsPeriod Period1h { get; } = new("1h");

    public static OpenInterestStatisticsPeriod Period2h { get; } = new("2h");

    public static OpenInterestStatisticsPeriod Period4h { get; } = new("4h");

    public static OpenInterestStatisticsPeriod Period6h { get; } = new("6h");

    public static OpenInterestStatisticsPeriod Period12h { get; } = new("12h");

    public static OpenInterestStatisticsPeriod Period1d { get; } = new("1d");

    static OpenInterestStatisticsPeriod IExtensibleValue<OpenInterestStatisticsPeriod>.Create(string value) => new(value);

    public static bool operator ==(OpenInterestStatisticsPeriod left, OpenInterestStatisticsPeriod right) => left.Equals(right);

    public static bool operator !=(OpenInterestStatisticsPeriod left, OpenInterestStatisticsPeriod right) => !left.Equals(right);

    public static implicit operator OpenInterestStatisticsPeriod(string value) => new(value);

    public static OpenInterestStatisticsPeriod FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is OpenInterestStatisticsPeriod other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(OpenInterestStatisticsPeriod other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<OpenInterestStatisticsContractType>))]
public readonly struct OpenInterestStatisticsContractType : IExtensibleValue<OpenInterestStatisticsContractType>, IEquatable<OpenInterestStatisticsContractType>
{
    private readonly string? _value;

    public OpenInterestStatisticsContractType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static OpenInterestStatisticsContractType Perpetual { get; } = new("PERPETUAL");

    public static OpenInterestStatisticsContractType CurrentQuarter { get; } = new("CURRENT_QUARTER");

    public static OpenInterestStatisticsContractType NextQuarter { get; } = new("NEXT_QUARTER");

    static OpenInterestStatisticsContractType IExtensibleValue<OpenInterestStatisticsContractType>.Create(string value) => new(value);

    public static bool operator ==(OpenInterestStatisticsContractType left, OpenInterestStatisticsContractType right) => left.Equals(right);

    public static bool operator !=(OpenInterestStatisticsContractType left, OpenInterestStatisticsContractType right) => !left.Equals(right);

    public static implicit operator OpenInterestStatisticsContractType(string value) => new(value);

    public static OpenInterestStatisticsContractType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is OpenInterestStatisticsContractType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(OpenInterestStatisticsContractType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class OpenInterestStatisticsRequest
{
    public required string Pair { get; init; }

    public required OpenInterestStatisticsPeriod Period { get; init; }

    /// <summary>
    /// Contract type filter. If omitted, returns aggregated data across all contract types.
    /// </summary>
    public OpenInterestStatisticsContractType? ContractType { get; init; }

    /// <summary>Maximum number of records to return.</summary>
    public long? Limit { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }
}

public sealed class OrderBookRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    /// <summary>Valid limits:[5, 10, 20, 50, 100, 500, 1000].</summary>
    public long? Limit { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<PremiumIndexKlineDataInterval>))]
public readonly struct PremiumIndexKlineDataInterval : IExtensibleValue<PremiumIndexKlineDataInterval>, IEquatable<PremiumIndexKlineDataInterval>
{
    private readonly string? _value;

    public PremiumIndexKlineDataInterval(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PremiumIndexKlineDataInterval Interval1m { get; } = new("1m");

    public static PremiumIndexKlineDataInterval Interval3m { get; } = new("3m");

    public static PremiumIndexKlineDataInterval Interval5m { get; } = new("5m");

    public static PremiumIndexKlineDataInterval Interval15m { get; } = new("15m");

    public static PremiumIndexKlineDataInterval Interval30m { get; } = new("30m");

    public static PremiumIndexKlineDataInterval Interval1h { get; } = new("1h");

    public static PremiumIndexKlineDataInterval Interval2h { get; } = new("2h");

    public static PremiumIndexKlineDataInterval Interval4h { get; } = new("4h");

    public static PremiumIndexKlineDataInterval Interval6h { get; } = new("6h");

    public static PremiumIndexKlineDataInterval Interval8h { get; } = new("8h");

    public static PremiumIndexKlineDataInterval Interval12h { get; } = new("12h");

    public static PremiumIndexKlineDataInterval Interval1d { get; } = new("1d");

    public static PremiumIndexKlineDataInterval Interval3d { get; } = new("3d");

    public static PremiumIndexKlineDataInterval Interval1w { get; } = new("1w");

    public static PremiumIndexKlineDataInterval Interval1Month { get; } = new("1M");

    static PremiumIndexKlineDataInterval IExtensibleValue<PremiumIndexKlineDataInterval>.Create(string value) => new(value);

    public static bool operator ==(PremiumIndexKlineDataInterval left, PremiumIndexKlineDataInterval right) => left.Equals(right);

    public static bool operator !=(PremiumIndexKlineDataInterval left, PremiumIndexKlineDataInterval right) => !left.Equals(right);

    public static implicit operator PremiumIndexKlineDataInterval(string value) => new(value);

    public static PremiumIndexKlineDataInterval FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PremiumIndexKlineDataInterval other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PremiumIndexKlineDataInterval other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class PremiumIndexKlineDataRequest
{
    /// <summary>After CM migration, accepts both CM and UM symbols.</summary>
    public required string Symbol { get; init; }

    /// <summary>Interval</summary>
    public required PremiumIndexKlineDataInterval Interval { get; init; }

    /// <summary>Start time</summary>
    public long? StartTime { get; init; }

    /// <summary>End time</summary>
    public long? EndTime { get; init; }

    /// <summary>Maximum number of records to return.</summary>
    public long? Limit { get; init; }
}

public sealed class QueryIndexPriceConstituentsRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }
}

public sealed class RecentTradesListRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    /// <summary>Maximum number of records to return.</summary>
    public long? Limit { get; init; }
}

public sealed class SymbolOrderBookTickerRequest
{
    /// <summary>Symbol</summary>
    public string? Symbol { get; init; }

    /// <summary>Symbol</summary>
    public string? Pair { get; init; }
}

public sealed class SymbolPriceTickerRequest
{
    /// <summary>Symbol</summary>
    public string? Symbol { get; init; }

    /// <summary>Pair</summary>
    public string? Pair { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<TakerBuySellVolumeContractType>))]
public readonly struct TakerBuySellVolumeContractType : IExtensibleValue<TakerBuySellVolumeContractType>, IEquatable<TakerBuySellVolumeContractType>
{
    private readonly string? _value;

    public TakerBuySellVolumeContractType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static TakerBuySellVolumeContractType All { get; } = new("ALL");

    public static TakerBuySellVolumeContractType Perpetual { get; } = new("PERPETUAL");

    public static TakerBuySellVolumeContractType CurrentQuarter { get; } = new("CURRENT_QUARTER");

    public static TakerBuySellVolumeContractType NextQuarter { get; } = new("NEXT_QUARTER");

    static TakerBuySellVolumeContractType IExtensibleValue<TakerBuySellVolumeContractType>.Create(string value) => new(value);

    public static bool operator ==(TakerBuySellVolumeContractType left, TakerBuySellVolumeContractType right) => left.Equals(right);

    public static bool operator !=(TakerBuySellVolumeContractType left, TakerBuySellVolumeContractType right) => !left.Equals(right);

    public static implicit operator TakerBuySellVolumeContractType(string value) => new(value);

    public static TakerBuySellVolumeContractType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TakerBuySellVolumeContractType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(TakerBuySellVolumeContractType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<TakerBuySellVolumePeriod>))]
public readonly struct TakerBuySellVolumePeriod : IExtensibleValue<TakerBuySellVolumePeriod>, IEquatable<TakerBuySellVolumePeriod>
{
    private readonly string? _value;

    public TakerBuySellVolumePeriod(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static TakerBuySellVolumePeriod Period5m { get; } = new("5m");

    public static TakerBuySellVolumePeriod Period15m { get; } = new("15m");

    public static TakerBuySellVolumePeriod Period30m { get; } = new("30m");

    public static TakerBuySellVolumePeriod Period1h { get; } = new("1h");

    public static TakerBuySellVolumePeriod Period2h { get; } = new("2h");

    public static TakerBuySellVolumePeriod Period4h { get; } = new("4h");

    public static TakerBuySellVolumePeriod Period6h { get; } = new("6h");

    public static TakerBuySellVolumePeriod Period12h { get; } = new("12h");

    public static TakerBuySellVolumePeriod Period1d { get; } = new("1d");

    static TakerBuySellVolumePeriod IExtensibleValue<TakerBuySellVolumePeriod>.Create(string value) => new(value);

    public static bool operator ==(TakerBuySellVolumePeriod left, TakerBuySellVolumePeriod right) => left.Equals(right);

    public static bool operator !=(TakerBuySellVolumePeriod left, TakerBuySellVolumePeriod right) => !left.Equals(right);

    public static implicit operator TakerBuySellVolumePeriod(string value) => new(value);

    public static TakerBuySellVolumePeriod FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TakerBuySellVolumePeriod other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(TakerBuySellVolumePeriod other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class TakerBuySellVolumeRequest
{
    public required string Pair { get; init; }

    public required TakerBuySellVolumeContractType ContractType { get; init; }

    public required TakerBuySellVolumePeriod Period { get; init; }

    /// <summary>Maximum number of records to return.</summary>
    public long? Limit { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }
}

public sealed class Ticker24hrPriceChangeStatisticsRequest
{
    /// <summary>Symbol</summary>
    public string? Symbol { get; init; }

    /// <summary>Pair</summary>
    public string? Pair { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<TopTraderLongShortRatioAccountsPeriod>))]
public readonly struct TopTraderLongShortRatioAccountsPeriod : IExtensibleValue<TopTraderLongShortRatioAccountsPeriod>, IEquatable<TopTraderLongShortRatioAccountsPeriod>
{
    private readonly string? _value;

    public TopTraderLongShortRatioAccountsPeriod(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static TopTraderLongShortRatioAccountsPeriod Period5m { get; } = new("5m");

    public static TopTraderLongShortRatioAccountsPeriod Period15m { get; } = new("15m");

    public static TopTraderLongShortRatioAccountsPeriod Period30m { get; } = new("30m");

    public static TopTraderLongShortRatioAccountsPeriod Period1h { get; } = new("1h");

    public static TopTraderLongShortRatioAccountsPeriod Period2h { get; } = new("2h");

    public static TopTraderLongShortRatioAccountsPeriod Period4h { get; } = new("4h");

    public static TopTraderLongShortRatioAccountsPeriod Period6h { get; } = new("6h");

    public static TopTraderLongShortRatioAccountsPeriod Period12h { get; } = new("12h");

    public static TopTraderLongShortRatioAccountsPeriod Period1d { get; } = new("1d");

    static TopTraderLongShortRatioAccountsPeriod IExtensibleValue<TopTraderLongShortRatioAccountsPeriod>.Create(string value) => new(value);

    public static bool operator ==(TopTraderLongShortRatioAccountsPeriod left, TopTraderLongShortRatioAccountsPeriod right) => left.Equals(right);

    public static bool operator !=(TopTraderLongShortRatioAccountsPeriod left, TopTraderLongShortRatioAccountsPeriod right) => !left.Equals(right);

    public static implicit operator TopTraderLongShortRatioAccountsPeriod(string value) => new(value);

    public static TopTraderLongShortRatioAccountsPeriod FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TopTraderLongShortRatioAccountsPeriod other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(TopTraderLongShortRatioAccountsPeriod other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<TopTraderLongShortRatioAccountsContractType>))]
public readonly struct TopTraderLongShortRatioAccountsContractType : IExtensibleValue<TopTraderLongShortRatioAccountsContractType>, IEquatable<TopTraderLongShortRatioAccountsContractType>
{
    private readonly string? _value;

    public TopTraderLongShortRatioAccountsContractType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static TopTraderLongShortRatioAccountsContractType Perpetual { get; } = new("PERPETUAL");

    public static TopTraderLongShortRatioAccountsContractType CurrentQuarter { get; } = new("CURRENT_QUARTER");

    public static TopTraderLongShortRatioAccountsContractType NextQuarter { get; } = new("NEXT_QUARTER");

    static TopTraderLongShortRatioAccountsContractType IExtensibleValue<TopTraderLongShortRatioAccountsContractType>.Create(string value) => new(value);

    public static bool operator ==(TopTraderLongShortRatioAccountsContractType left, TopTraderLongShortRatioAccountsContractType right) => left.Equals(right);

    public static bool operator !=(TopTraderLongShortRatioAccountsContractType left, TopTraderLongShortRatioAccountsContractType right) => !left.Equals(right);

    public static implicit operator TopTraderLongShortRatioAccountsContractType(string value) => new(value);

    public static TopTraderLongShortRatioAccountsContractType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TopTraderLongShortRatioAccountsContractType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(TopTraderLongShortRatioAccountsContractType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class TopTraderLongShortRatioAccountsRequest
{
    /// <summary>Pair</summary>
    public required string Pair { get; init; }

    public required TopTraderLongShortRatioAccountsPeriod Period { get; init; }

    /// <summary>
    /// Contract type filter. If omitted, returns aggregated data across all contract types.
    /// </summary>
    public TopTraderLongShortRatioAccountsContractType? ContractType { get; init; }

    /// <summary>Maximum number of records to return.</summary>
    public long? Limit { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<TopTraderLongShortRatioPositionsPeriod>))]
public readonly struct TopTraderLongShortRatioPositionsPeriod : IExtensibleValue<TopTraderLongShortRatioPositionsPeriod>, IEquatable<TopTraderLongShortRatioPositionsPeriod>
{
    private readonly string? _value;

    public TopTraderLongShortRatioPositionsPeriod(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static TopTraderLongShortRatioPositionsPeriod Period5m { get; } = new("5m");

    public static TopTraderLongShortRatioPositionsPeriod Period15m { get; } = new("15m");

    public static TopTraderLongShortRatioPositionsPeriod Period30m { get; } = new("30m");

    public static TopTraderLongShortRatioPositionsPeriod Period1h { get; } = new("1h");

    public static TopTraderLongShortRatioPositionsPeriod Period2h { get; } = new("2h");

    public static TopTraderLongShortRatioPositionsPeriod Period4h { get; } = new("4h");

    public static TopTraderLongShortRatioPositionsPeriod Period6h { get; } = new("6h");

    public static TopTraderLongShortRatioPositionsPeriod Period12h { get; } = new("12h");

    public static TopTraderLongShortRatioPositionsPeriod Period1d { get; } = new("1d");

    static TopTraderLongShortRatioPositionsPeriod IExtensibleValue<TopTraderLongShortRatioPositionsPeriod>.Create(string value) => new(value);

    public static bool operator ==(TopTraderLongShortRatioPositionsPeriod left, TopTraderLongShortRatioPositionsPeriod right) => left.Equals(right);

    public static bool operator !=(TopTraderLongShortRatioPositionsPeriod left, TopTraderLongShortRatioPositionsPeriod right) => !left.Equals(right);

    public static implicit operator TopTraderLongShortRatioPositionsPeriod(string value) => new(value);

    public static TopTraderLongShortRatioPositionsPeriod FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TopTraderLongShortRatioPositionsPeriod other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(TopTraderLongShortRatioPositionsPeriod other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<TopTraderLongShortRatioPositionsContractType>))]
public readonly struct TopTraderLongShortRatioPositionsContractType : IExtensibleValue<TopTraderLongShortRatioPositionsContractType>, IEquatable<TopTraderLongShortRatioPositionsContractType>
{
    private readonly string? _value;

    public TopTraderLongShortRatioPositionsContractType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static TopTraderLongShortRatioPositionsContractType Perpetual { get; } = new("PERPETUAL");

    public static TopTraderLongShortRatioPositionsContractType CurrentQuarter { get; } = new("CURRENT_QUARTER");

    public static TopTraderLongShortRatioPositionsContractType NextQuarter { get; } = new("NEXT_QUARTER");

    static TopTraderLongShortRatioPositionsContractType IExtensibleValue<TopTraderLongShortRatioPositionsContractType>.Create(string value) => new(value);

    public static bool operator ==(TopTraderLongShortRatioPositionsContractType left, TopTraderLongShortRatioPositionsContractType right) => left.Equals(right);

    public static bool operator !=(TopTraderLongShortRatioPositionsContractType left, TopTraderLongShortRatioPositionsContractType right) => !left.Equals(right);

    public static implicit operator TopTraderLongShortRatioPositionsContractType(string value) => new(value);

    public static TopTraderLongShortRatioPositionsContractType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TopTraderLongShortRatioPositionsContractType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(TopTraderLongShortRatioPositionsContractType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class TopTraderLongShortRatioPositionsRequest
{
    public required string Pair { get; init; }

    public required TopTraderLongShortRatioPositionsPeriod Period { get; init; }

    /// <summary>
    /// Contract type filter. If omitted, returns aggregated data across all contract types.
    /// </summary>
    public TopTraderLongShortRatioPositionsContractType? ContractType { get; init; }

    /// <summary>Maximum number of records to return.</summary>
    public long? Limit { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }
}

public sealed partial class DerivativesTradingCoinFuturesRestApi
{

    /// <summary>Basis</summary>
    /// <remarks>
    /// <para>Query basis</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Notes:</para>
    /// <para>- If startTime and endTime are not sent, the most recent data is returned.</para>
    /// <para>- Only the data of the latest 30 days is available.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<BasisResponseInner>>> BasisAsync(BasisRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/futures/data/basis", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<BasisResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("pair", request.Pair);
        r.Query("contractType", request.ContractType);
        r.Query("period", request.Period);
        r.Query("limit", request.Limit);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListBasisResponseInner, cancellationToken);
    }

    /// <summary>Check Server time</summary>
    /// <remarks>
    /// <para>Test connectivity to the Rest API and get the current server time.</para>
    /// <para>Weight(IP): 1</para>
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CheckServerTimeResponse>> CheckServerTimeAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/time", signed: false, hasTimeUnit: false);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.CheckServerTimeResponse, cancellationToken);
    }

    /// <summary>Compressed/Aggregate Trades List</summary>
    /// <remarks>
    /// <para>
    /// Get compressed, aggregate trades. Market trades that fill in 100ms with the same price and the same
    /// taking side will have the quantity aggregated.
    /// </para>
    /// <para>Weight(IP): 20</para>
    /// <para>Notes:</para>
    /// <para>- only trade histories within the past 48 hours (counted from now) can be queried</para>
    /// <para>
    /// - If both startTime and endTime are sent, time between startTime and endTime must be less than 1
    /// hour.
    /// </para>
    /// <para>- If fromId, startTime, and endTime are not sent, the most recent aggregate trades will be returned.</para>
    /// <para>
    /// - Only market trades will be aggregated and returned, which means the insurance fund trades and ADL
    /// trades won't be aggregated.
    /// </para>
    /// <para>
    /// - Sending both startTime/endTime and fromId might cause response timeout, please send either fromId
    /// or startTime/endTime
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<CompressedAggregateTradesListResponseInner>>> CompressedAggregateTradesListAsync(CompressedAggregateTradesListRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/aggTrades", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<CompressedAggregateTradesListResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("fromId", request.FromId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListCompressedAggregateTradesListResponseInner, cancellationToken);
    }

    /// <summary>Continuous Contract Kline/Candlestick Data</summary>
    /// <remarks>
    /// <para>
    /// Kline/candlestick bars for a specific contract type. Klines are uniquely identified by their open
    /// time.
    /// </para>
    /// <para>Weight: based on parameter LIMIT</para>
    /// <para>| LIMIT | weight |</para>
    /// <para>| [1,100) | 1 |</para>
    /// <para>| [100, 500) | 2 |</para>
    /// <para>| [500, 1000] | 5 |</para>
    /// <para>| &gt; 1000 | 10 |</para>
    /// <para>Notes:</para>
    /// <para>- The difference between startTime and endTime can only be up to 200 days</para>
    /// <para>- Between startTime and endTime, the most recent limit data from endTime will be returned:</para>
    /// <para>
    /// - If startTime and endTime are not sent, current timestamp will be set as endTime, and the most
    /// recent data will be returned.
    /// </para>
    /// <para>
    /// - If startTime is sent only, the timestamp of 200 days after startTime will be set as endTime(up to
    /// the current time)
    /// </para>
    /// <para>- If endTime is sent only, the timestamp of 200 days before endTime will be set as startTime</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<List<ContinuousContractKlineCandlestickDataItemInner>>>> ContinuousContractKlineCandlestickDataAsync(ContinuousContractKlineCandlestickDataRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/continuousKlines", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<List<ContinuousContractKlineCandlestickDataItemInner>>>>(new ArgumentNullException(nameof(request)));
        r.Query("pair", request.Pair);
        r.Query("contractType", request.ContractType);
        r.Query("interval", request.Interval);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListListContinuousContractKlineCandlestickDataItemInner, cancellationToken);
    }

    /// <summary>Exchange Information</summary>
    /// <remarks>
    /// <para>Current exchange trading rules and symbol information</para>
    /// <para>Weight(IP): 1</para>
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ExchangeInformationResponse>> ExchangeInformationAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/exchangeInfo", signed: false, hasTimeUnit: false);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ExchangeInformationResponse, cancellationToken);
    }

    /// <summary>Get Funding Rate History of Perpetual Futures</summary>
    /// <remarks>
    /// <para>Weight(IP): 1</para>
    /// <para>Notes:</para>
    /// <para>- empty array will be returned for delivery symbols.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<GetFundingRateHistoryOfPerpetualFuturesResponseInner>>> GetFundingRateHistoryOfPerpetualFuturesAsync(GetFundingRateHistoryOfPerpetualFuturesRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/fundingRate", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<GetFundingRateHistoryOfPerpetualFuturesResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListGetFundingRateHistoryOfPerpetualFuturesResponseInner, cancellationToken);
    }

    /// <summary>Get Funding Rate Info</summary>
    /// <remarks>
    /// Query funding rate info for symbols that had FundingRateCap/FundingRateFloor/fundingIntervalHours
    /// adjustment
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<GetFundingRateInfoResponseInner>>> GetFundingRateInfoAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/fundingInfo", signed: false, hasTimeUnit: false);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListGetFundingRateInfoResponseInner, cancellationToken);
    }

    /// <summary>Index Price and Mark Price</summary>
    /// <remarks>
    /// <para>Query index price and mark price</para>
    /// <para>Weight(IP): 10</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<IndexPriceAndMarkPriceResponseInner>>> IndexPriceAndMarkPriceAsync(IndexPriceAndMarkPriceRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/premiumIndex", signed: false, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("pair", request.Pair);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListIndexPriceAndMarkPriceResponseInner, cancellationToken);
    }

    /// <summary>Index Price Kline/Candlestick Data</summary>
    /// <remarks>
    /// <para>
    /// Kline/candlestick bars for the index price of a pair. Klines are uniquely identified by their open
    /// time.
    /// </para>
    /// <para>Weight: Based on parameter LIMIT</para>
    /// <para>| LIMIT | weight |</para>
    /// <para>| [1,100) | 1 |</para>
    /// <para>| [100, 500) | 2 |</para>
    /// <para>| [500, 1000] | 5 |</para>
    /// <para>| &gt; 1000 | 10 |</para>
    /// <para>Notes:</para>
    /// <para>- The difference between startTime and endTime can only be up to 200 days</para>
    /// <para>- Between startTime and endTime, the most recent limit data from endTime will be returned:</para>
    /// <para>
    /// - If startTime and endTime are not sent, current timestamp will be set as endTime, and the most
    /// recent data will be returned.
    /// </para>
    /// <para>
    /// - If startTime is sent only, the timestamp of 200 days after startTime will be set as endTime(up to
    /// the current time)
    /// </para>
    /// <para>- If endTime is sent only, the timestamp of 200 days before endTime will be set as startTime</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<List<IndexPriceKlineCandlestickDataItemInner>>>> IndexPriceKlineCandlestickDataAsync(IndexPriceKlineCandlestickDataRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/indexPriceKlines", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<List<IndexPriceKlineCandlestickDataItemInner>>>>(new ArgumentNullException(nameof(request)));
        r.Query("pair", request.Pair);
        r.Query("interval", request.Interval);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListListIndexPriceKlineCandlestickDataItemInner, cancellationToken);
    }

    /// <summary>Kline/Candlestick Data</summary>
    /// <remarks>
    /// <para>Kline/candlestick bars for a symbol. Klines are uniquely identified by their open time.</para>
    /// <para>Weight: Based on parameter LIMIT</para>
    /// <para>| LIMIT | weight |</para>
    /// <para>| [1,100) | 1 |</para>
    /// <para>| [100, 500) | 2 |</para>
    /// <para>| [500, 1000] | 5 |</para>
    /// <para>| &gt; 1000 | 10 |</para>
    /// <para>Notes:</para>
    /// <para>- The difference between startTime and endTime can only be up to 200 days</para>
    /// <para>- Between startTime and endTime, the most recent limit data from endTime will be returned:</para>
    /// <para>
    /// - If startTime and endTime are not sent, current timestamp will be set as endTime, and the most
    /// recent data will be returned.
    /// </para>
    /// <para>
    /// - If startTime is sent only, the timestamp of 200 days after startTime will be set as endTime(up to
    /// the current time)
    /// </para>
    /// <para>- If endTime is sent only, the timestamp of 200 days before endTime will be set as startTime</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<List<ContinuousContractKlineCandlestickDataItemInner>>>> KlineCandlestickDataAsync(KlineCandlestickDataRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/klines", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<List<ContinuousContractKlineCandlestickDataItemInner>>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("interval", request.Interval);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListListContinuousContractKlineCandlestickDataItemInner, cancellationToken);
    }

    /// <summary>Long/Short Ratio</summary>
    /// <remarks>
    /// <para>Query symbol Long/Short Ratio</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Notes:</para>
    /// <para>- If startTime and endTime are not sent, the most recent data is returned.</para>
    /// <para>- Only the data of the latest 30 days is available.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<LongShortRatioResponseInner>>> LongShortRatioAsync(LongShortRatioRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/futures/data/globalLongShortAccountRatio", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<LongShortRatioResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("pair", request.Pair);
        r.Query("period", request.Period);
        r.Query("contractType", request.ContractType);
        r.Query("limit", request.Limit);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListLongShortRatioResponseInner, cancellationToken);
    }

    /// <summary>Mark Price Kline/Candlestick Data</summary>
    /// <remarks>
    /// <para>
    /// Kline/candlestick bars for the mark price of a symbol. Klines are uniquely identified by their open
    /// time.
    /// </para>
    /// <para>Weight: Based on parameter LIMIT</para>
    /// <para>| LIMIT | weight |</para>
    /// <para>| [1,100) | 1 |</para>
    /// <para>| [100, 500) | 2 |</para>
    /// <para>| [500, 1000] | 5 |</para>
    /// <para>| &gt; 1000 | 10 |</para>
    /// <para>Notes:</para>
    /// <para>- The difference between startTime and endTime can only be up to 200 days</para>
    /// <para>- Between startTime and endTime, the most recent limit data from endTime will be returned:</para>
    /// <para>
    /// - If startTime and endTime are not sent, current timestamp will be set as endTime, and the most
    /// recent data will be returned.
    /// </para>
    /// <para>
    /// - If startTime is sent only, the timestamp of 200 days after startTime will be set as endTime(up to
    /// the current time)
    /// </para>
    /// <para>- If endTime is sent only, the timestamp of 200 days before endTime will be set as startTime</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<List<IndexPriceKlineCandlestickDataItemInner>>>> MarkPriceKlineCandlestickDataAsync(MarkPriceKlineCandlestickDataRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/markPriceKlines", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<List<IndexPriceKlineCandlestickDataItemInner>>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("interval", request.Interval);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListListIndexPriceKlineCandlestickDataItemInner, cancellationToken);
    }

    /// <summary>Old Trades Lookup (MARKET_DATA)</summary>
    /// <remarks>
    /// <para>Get older market historical trades.</para>
    /// <para>Weight(IP): 200</para>
    /// <para>Security Type: MARKET_DATA</para>
    /// <para>Notes:</para>
    /// <para>
    /// - Market trades means trades filled in the order book. Only market trades will be returned, which
    /// means the insurance fund trades and ADL trades won't be returned.
    /// </para>
    /// <para>- Only supports data from within the last one month</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<OldTradesLookupResponseInner>>> OldTradesLookupAsync(OldTradesLookupRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/historicalTrades", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<OldTradesLookupResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("limit", request.Limit);
        r.Query("fromId", request.FromId);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListOldTradesLookupResponseInner, cancellationToken);
    }

    /// <summary>Open Interest</summary>
    /// <remarks>
    /// <para>Get present open interest of a specific symbol.</para>
    /// <para>Weight(IP): 1</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<OpenInterestResponse>> OpenInterestAsync(OpenInterestRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/openInterest", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<OpenInterestResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.OpenInterestResponse, cancellationToken);
    }

    /// <summary>Open Interest Statistics</summary>
    /// <remarks>
    /// <para>Query open interest stats</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Notes:</para>
    /// <para>- If startTime and endTime are not sent, the most recent data is returned.</para>
    /// <para>- Only the data of the latest 30 days is available.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<OpenInterestStatisticsResponseInner>>> OpenInterestStatisticsAsync(OpenInterestStatisticsRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/futures/data/openInterestHist", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<OpenInterestStatisticsResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("pair", request.Pair);
        r.Query("period", request.Period);
        r.Query("contractType", request.ContractType);
        r.Query("limit", request.Limit);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListOpenInterestStatisticsResponseInner, cancellationToken);
    }

    /// <summary>Order Book</summary>
    /// <remarks>
    /// <para>Query orderbook on specific symbol</para>
    /// <para>Weight: Adjusted based on the limit:</para>
    /// <para>| Limit | Weight |</para>
    /// <para>| 5, 10, 20, 50 | 2 |</para>
    /// <para>| 100 | 5 |</para>
    /// <para>| 500 | 10 |</para>
    /// <para>| 1000 | 20 |</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<OrderBookResponse>> OrderBookAsync(OrderBookRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/depth", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<OrderBookResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("limit", request.Limit);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.OrderBookResponse, cancellationToken);
    }

    /// <summary>Premium index Kline Data</summary>
    /// <remarks>
    /// <para>Premium index kline bars of a symbol. Klines are uniquely identified by their open time.</para>
    /// <para>Weight: Based on parameter LIMIT</para>
    /// <para>| LIMIT | weight |</para>
    /// <para>| [1,100) | 1 |</para>
    /// <para>| [100, 500) | 2 |</para>
    /// <para>| [500, 1000] | 5 |</para>
    /// <para>| &gt; 1000 | 10 |</para>
    /// <para>Notes:</para>
    /// <para>- If startTime and endTime are not sent, the most recent klines are returned.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<List<PremiumIndexKlineDataItemInner>>>> PremiumIndexKlineDataAsync(PremiumIndexKlineDataRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/premiumIndexKlines", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<List<PremiumIndexKlineDataItemInner>>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("interval", request.Interval);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListListPremiumIndexKlineDataItemInner, cancellationToken);
    }

    /// <summary>Query Index Price Constituents</summary>
    /// <remarks>
    /// <para>Query index price constituents</para>
    /// <para>Weight(IP): 1</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryIndexPriceConstituentsResponse>> QueryIndexPriceConstituentsAsync(QueryIndexPriceConstituentsRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/constituents", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryIndexPriceConstituentsResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.QueryIndexPriceConstituentsResponse, cancellationToken);
    }

    /// <summary>Recent Trades List</summary>
    /// <remarks>
    /// <para>Get recent market trades</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Notes:</para>
    /// <para>
    /// - Market trades means trades filled in the order book. Only market trades will be returned, which
    /// means the insurance fund trades and ADL trades won't be returned.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<RecentTradesListResponseInner>>> RecentTradesListAsync(RecentTradesListRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/trades", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<RecentTradesListResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("limit", request.Limit);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListRecentTradesListResponseInner, cancellationToken);
    }

    /// <summary>Symbol Order Book Ticker</summary>
    /// <remarks>
    /// <para>Best price/qty on the order book for a symbol or symbols.</para>
    /// <para>Weight: 2 for a single symbol, 5 when the symbol parameter is omitted</para>
    /// <para>Notes:</para>
    /// <para>- Symbol and pair cannot be sent together</para>
    /// <para>- If a pair is sent,tickers for all symbols of the pair will be returned</para>
    /// <para>- If either a pair or symbol is sent, tickers for all symbols of all pairs will be returned</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<SymbolOrderBookTickerResponseInner>>> SymbolOrderBookTickerAsync(SymbolOrderBookTickerRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/ticker/bookTicker", signed: false, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("pair", request.Pair);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListSymbolOrderBookTickerResponseInner, cancellationToken);
    }

    /// <summary>Symbol Price Ticker</summary>
    /// <remarks>
    /// <para>Latest price for a symbol or symbols.</para>
    /// <para>Weight: 1 for a single symbol, 2 when the symbol parameter is omitted</para>
    /// <para>Notes:</para>
    /// <para>- Symbol and pair cannot be sent together</para>
    /// <para>- If a pair is sent,tickers for all symbols of the pair will be returned</para>
    /// <para>- If either a pair or symbol is sent, tickers for all symbols of all pairs will be returned</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<SymbolPriceTickerResponseInner>>> SymbolPriceTickerAsync(SymbolPriceTickerRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/ticker/price", signed: false, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("pair", request.Pair);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListSymbolPriceTickerResponseInner, cancellationToken);
    }

    /// <summary>Taker Buy/Sell Volume</summary>
    /// <remarks>
    /// <para>Taker Buy Volume: the total volume of buy orders filled by takers within the period.</para>
    /// <para>Taker Sell Volume: the total volume of sell orders filled by takers within the period.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Notes:</para>
    /// <para>- If startTime and endTime are not sent, the most recent data is returned.</para>
    /// <para>- Only the data of the latest 30 days is available.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<TakerBuySellVolumeResponseInner>>> TakerBuySellVolumeAsync(TakerBuySellVolumeRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/futures/data/takerBuySellVol", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<TakerBuySellVolumeResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("pair", request.Pair);
        r.Query("contractType", request.ContractType);
        r.Query("period", request.Period);
        r.Query("limit", request.Limit);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListTakerBuySellVolumeResponseInner, cancellationToken);
    }

    /// <summary>Test Connectivity</summary>
    /// <remarks>
    /// <para>Test connectivity to the Rest API.</para>
    /// <para>Weight(IP): 1</para>
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<JsonElement>> TestConnectivityAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/ping", signed: false, hasTimeUnit: false);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.JsonElement, cancellationToken);
    }

    /// <summary>24hr Ticker Price Change Statistics</summary>
    /// <remarks>
    /// <para>24 hour rolling window price change statistics.</para>
    /// <para>
    /// Weight: 1 for a single symbol, 40 when the symbol parameter is omitted Careful when accessing this
    /// with no symbol.
    /// </para>
    /// <para>Notes:</para>
    /// <para>- Symbol and pair cannot be sent together</para>
    /// <para>- If a pair is sent,tickers for all symbols of the pair will be returned</para>
    /// <para>- If either a pair or symbol is sent, tickers for all symbols of all pairs will be returned</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<Ticker24hrPriceChangeStatisticsResponseInner>>> Ticker24hrPriceChangeStatisticsAsync(Ticker24hrPriceChangeStatisticsRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/ticker/24hr", signed: false, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("pair", request.Pair);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListTicker24hrPriceChangeStatisticsResponseInner, cancellationToken);
    }

    /// <summary>Top Trader Long/Short Account Ratio</summary>
    /// <remarks>
    /// <para>
    /// The proportion of net long and net short accounts to total accounts of the top 20% users with the
    /// highest margin balance. Each account is counted once only.
    /// </para>
    /// <para>
    /// Long Account % = Accounts of top traders with net long positions / Total accounts of top traders
    /// with open positions
    /// </para>
    /// <para>
    /// Short Account % = Accounts of top traders with net short positions / Total accounts of top traders
    /// with open positions
    /// </para>
    /// <para>Long/Short Ratio (Accounts) = Long Account % / Short Account %</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: Accounts</para>
    /// <para>Notes:</para>
    /// <para>- If startTime and endTime are not sent, the most recent data is returned.</para>
    /// <para>- Only the data of the latest 30 days is available.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<TopTraderLongShortRatioAccountsResponseInner>>> TopTraderLongShortRatioAccountsAsync(TopTraderLongShortRatioAccountsRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/futures/data/topLongShortAccountRatio", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<TopTraderLongShortRatioAccountsResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("pair", request.Pair);
        r.Query("period", request.Period);
        r.Query("contractType", request.ContractType);
        r.Query("limit", request.Limit);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListTopTraderLongShortRatioAccountsResponseInner, cancellationToken);
    }

    /// <summary>Top Trader Long/Short Position Ratio</summary>
    /// <remarks>
    /// <para>
    /// The proportion of net long and net short positions to total open positions of the top 20% users with
    /// the highest margin balance.
    /// </para>
    /// <para>Long Position % = Long positions of top traders / Total open positions of top traders</para>
    /// <para>Short Position % = Short positions of top traders / Total open positions of top traders</para>
    /// <para>Long/Short Ratio (Positions) = Long Position % / Short Position %</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: Positions</para>
    /// <para>Notes:</para>
    /// <para>- If startTime and endTime are not sent, the most recent data is returned.</para>
    /// <para>- Only the data of the latest 30 days is available.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<TopTraderLongShortRatioPositionsResponseInner>>> TopTraderLongShortRatioPositionsAsync(TopTraderLongShortRatioPositionsRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/futures/data/topLongShortPositionRatio", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<TopTraderLongShortRatioPositionsResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("pair", request.Pair);
        r.Query("period", request.Period);
        r.Query("contractType", request.ContractType);
        r.Query("limit", request.Limit);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListTopTraderLongShortRatioPositionsResponseInner, cancellationToken);
    }
}
