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

namespace Binance.DerivativesTradingCoinFutures.WebSocketStreams;

public sealed class AggregateTradeStreamsRequest
{
    /// <summary>The symbol parameter</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed class AllBookTickersStreamRequest
{
    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed class AllMarketLiquidationOrderStreamsRequest
{
    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed class AllMarketMiniTickersStreamRequest
{
    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed class AllMarketTickersStreamsRequest
{
    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<ContinuousContractKlineCandlestickStreamsContractType>))]
public readonly struct ContinuousContractKlineCandlestickStreamsContractType : IExtensibleValue<ContinuousContractKlineCandlestickStreamsContractType>, IEquatable<ContinuousContractKlineCandlestickStreamsContractType>
{
    private readonly string? _value;

    public ContinuousContractKlineCandlestickStreamsContractType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static ContinuousContractKlineCandlestickStreamsContractType Perpetual { get; } = new("perpetual");

    public static ContinuousContractKlineCandlestickStreamsContractType CurrentQuarter { get; } = new("current_quarter");

    public static ContinuousContractKlineCandlestickStreamsContractType NextQuarter { get; } = new("next_quarter");

    static ContinuousContractKlineCandlestickStreamsContractType IExtensibleValue<ContinuousContractKlineCandlestickStreamsContractType>.Create(string value) => new(value);

    public static bool operator ==(ContinuousContractKlineCandlestickStreamsContractType left, ContinuousContractKlineCandlestickStreamsContractType right) => left.Equals(right);

    public static bool operator !=(ContinuousContractKlineCandlestickStreamsContractType left, ContinuousContractKlineCandlestickStreamsContractType right) => !left.Equals(right);

    public static implicit operator ContinuousContractKlineCandlestickStreamsContractType(string value) => new(value);

    public static ContinuousContractKlineCandlestickStreamsContractType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ContinuousContractKlineCandlestickStreamsContractType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ContinuousContractKlineCandlestickStreamsContractType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<ContinuousContractKlineCandlestickStreamsInterval>))]
public readonly struct ContinuousContractKlineCandlestickStreamsInterval : IExtensibleValue<ContinuousContractKlineCandlestickStreamsInterval>, IEquatable<ContinuousContractKlineCandlestickStreamsInterval>
{
    private readonly string? _value;

    public ContinuousContractKlineCandlestickStreamsInterval(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static ContinuousContractKlineCandlestickStreamsInterval Interval1m { get; } = new("1m");

    public static ContinuousContractKlineCandlestickStreamsInterval Interval3m { get; } = new("3m");

    public static ContinuousContractKlineCandlestickStreamsInterval Interval5m { get; } = new("5m");

    public static ContinuousContractKlineCandlestickStreamsInterval Interval15m { get; } = new("15m");

    public static ContinuousContractKlineCandlestickStreamsInterval Interval30m { get; } = new("30m");

    public static ContinuousContractKlineCandlestickStreamsInterval Interval1h { get; } = new("1h");

    public static ContinuousContractKlineCandlestickStreamsInterval Interval2h { get; } = new("2h");

    public static ContinuousContractKlineCandlestickStreamsInterval Interval4h { get; } = new("4h");

    public static ContinuousContractKlineCandlestickStreamsInterval Interval6h { get; } = new("6h");

    public static ContinuousContractKlineCandlestickStreamsInterval Interval8h { get; } = new("8h");

    public static ContinuousContractKlineCandlestickStreamsInterval Interval12h { get; } = new("12h");

    public static ContinuousContractKlineCandlestickStreamsInterval Interval1d { get; } = new("1d");

    public static ContinuousContractKlineCandlestickStreamsInterval Interval3d { get; } = new("3d");

    public static ContinuousContractKlineCandlestickStreamsInterval Interval1w { get; } = new("1w");

    public static ContinuousContractKlineCandlestickStreamsInterval Interval1Month { get; } = new("1M");

    static ContinuousContractKlineCandlestickStreamsInterval IExtensibleValue<ContinuousContractKlineCandlestickStreamsInterval>.Create(string value) => new(value);

    public static bool operator ==(ContinuousContractKlineCandlestickStreamsInterval left, ContinuousContractKlineCandlestickStreamsInterval right) => left.Equals(right);

    public static bool operator !=(ContinuousContractKlineCandlestickStreamsInterval left, ContinuousContractKlineCandlestickStreamsInterval right) => !left.Equals(right);

    public static implicit operator ContinuousContractKlineCandlestickStreamsInterval(string value) => new(value);

    public static ContinuousContractKlineCandlestickStreamsInterval FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ContinuousContractKlineCandlestickStreamsInterval other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ContinuousContractKlineCandlestickStreamsInterval other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class ContinuousContractKlineCandlestickStreamsRequest
{
    /// <summary>The pair parameter</summary>
    public required string Pair { get; init; }

    /// <summary>The contractType parameter</summary>
    public required ContinuousContractKlineCandlestickStreamsContractType ContractType { get; init; }

    /// <summary>The interval parameter</summary>
    public required ContinuousContractKlineCandlestickStreamsInterval Interval { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed class ContractInfoStreamRequest
{
    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<DiffBookDepthStreamsUpdateSpeed>))]
public readonly struct DiffBookDepthStreamsUpdateSpeed : IExtensibleValue<DiffBookDepthStreamsUpdateSpeed>, IEquatable<DiffBookDepthStreamsUpdateSpeed>
{
    private readonly string? _value;

    public DiffBookDepthStreamsUpdateSpeed(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static DiffBookDepthStreamsUpdateSpeed UpdateSpeed100ms { get; } = new("100ms");

    public static DiffBookDepthStreamsUpdateSpeed UpdateSpeed500ms { get; } = new("500ms");

    static DiffBookDepthStreamsUpdateSpeed IExtensibleValue<DiffBookDepthStreamsUpdateSpeed>.Create(string value) => new(value);

    public static bool operator ==(DiffBookDepthStreamsUpdateSpeed left, DiffBookDepthStreamsUpdateSpeed right) => left.Equals(right);

    public static bool operator !=(DiffBookDepthStreamsUpdateSpeed left, DiffBookDepthStreamsUpdateSpeed right) => !left.Equals(right);

    public static implicit operator DiffBookDepthStreamsUpdateSpeed(string value) => new(value);

    public static DiffBookDepthStreamsUpdateSpeed FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is DiffBookDepthStreamsUpdateSpeed other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(DiffBookDepthStreamsUpdateSpeed other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class DiffBookDepthStreamsRequest
{
    /// <summary>The symbol parameter</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }

    /// <summary>WebSocket stream update speed</summary>
    public DiffBookDepthStreamsUpdateSpeed? UpdateSpeed { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<IndexKlineCandlestickStreamsInterval>))]
public readonly struct IndexKlineCandlestickStreamsInterval : IExtensibleValue<IndexKlineCandlestickStreamsInterval>, IEquatable<IndexKlineCandlestickStreamsInterval>
{
    private readonly string? _value;

    public IndexKlineCandlestickStreamsInterval(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static IndexKlineCandlestickStreamsInterval Interval1m { get; } = new("1m");

    public static IndexKlineCandlestickStreamsInterval Interval3m { get; } = new("3m");

    public static IndexKlineCandlestickStreamsInterval Interval5m { get; } = new("5m");

    public static IndexKlineCandlestickStreamsInterval Interval15m { get; } = new("15m");

    public static IndexKlineCandlestickStreamsInterval Interval30m { get; } = new("30m");

    public static IndexKlineCandlestickStreamsInterval Interval1h { get; } = new("1h");

    public static IndexKlineCandlestickStreamsInterval Interval2h { get; } = new("2h");

    public static IndexKlineCandlestickStreamsInterval Interval4h { get; } = new("4h");

    public static IndexKlineCandlestickStreamsInterval Interval6h { get; } = new("6h");

    public static IndexKlineCandlestickStreamsInterval Interval8h { get; } = new("8h");

    public static IndexKlineCandlestickStreamsInterval Interval12h { get; } = new("12h");

    public static IndexKlineCandlestickStreamsInterval Interval1d { get; } = new("1d");

    public static IndexKlineCandlestickStreamsInterval Interval3d { get; } = new("3d");

    public static IndexKlineCandlestickStreamsInterval Interval1w { get; } = new("1w");

    public static IndexKlineCandlestickStreamsInterval Interval1Month { get; } = new("1M");

    static IndexKlineCandlestickStreamsInterval IExtensibleValue<IndexKlineCandlestickStreamsInterval>.Create(string value) => new(value);

    public static bool operator ==(IndexKlineCandlestickStreamsInterval left, IndexKlineCandlestickStreamsInterval right) => left.Equals(right);

    public static bool operator !=(IndexKlineCandlestickStreamsInterval left, IndexKlineCandlestickStreamsInterval right) => !left.Equals(right);

    public static implicit operator IndexKlineCandlestickStreamsInterval(string value) => new(value);

    public static IndexKlineCandlestickStreamsInterval FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is IndexKlineCandlestickStreamsInterval other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(IndexKlineCandlestickStreamsInterval other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class IndexKlineCandlestickStreamsRequest
{
    /// <summary>The pair parameter</summary>
    public required string Pair { get; init; }

    /// <summary>The interval parameter</summary>
    public required IndexKlineCandlestickStreamsInterval Interval { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<IndexPriceStreamUpdateSpeed>))]
public readonly struct IndexPriceStreamUpdateSpeed : IExtensibleValue<IndexPriceStreamUpdateSpeed>, IEquatable<IndexPriceStreamUpdateSpeed>
{
    private readonly string? _value;

    public IndexPriceStreamUpdateSpeed(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static IndexPriceStreamUpdateSpeed UpdateSpeed1s { get; } = new("1s");

    static IndexPriceStreamUpdateSpeed IExtensibleValue<IndexPriceStreamUpdateSpeed>.Create(string value) => new(value);

    public static bool operator ==(IndexPriceStreamUpdateSpeed left, IndexPriceStreamUpdateSpeed right) => left.Equals(right);

    public static bool operator !=(IndexPriceStreamUpdateSpeed left, IndexPriceStreamUpdateSpeed right) => !left.Equals(right);

    public static implicit operator IndexPriceStreamUpdateSpeed(string value) => new(value);

    public static IndexPriceStreamUpdateSpeed FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is IndexPriceStreamUpdateSpeed other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(IndexPriceStreamUpdateSpeed other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class IndexPriceStreamRequest
{
    /// <summary>The pair parameter</summary>
    public required string Pair { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }

    /// <summary>WebSocket stream update speed</summary>
    public IndexPriceStreamUpdateSpeed? UpdateSpeed { get; init; }
}

public sealed class IndividualSymbolBookTickerStreamsRequest
{
    /// <summary>The symbol parameter</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed class IndividualSymbolMiniTickerStreamRequest
{
    /// <summary>The symbol parameter</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed class IndividualSymbolTickerStreamsRequest
{
    /// <summary>The symbol parameter</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<KlineCandlestickStreamsInterval>))]
public readonly struct KlineCandlestickStreamsInterval : IExtensibleValue<KlineCandlestickStreamsInterval>, IEquatable<KlineCandlestickStreamsInterval>
{
    private readonly string? _value;

    public KlineCandlestickStreamsInterval(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static KlineCandlestickStreamsInterval Interval1m { get; } = new("1m");

    public static KlineCandlestickStreamsInterval Interval3m { get; } = new("3m");

    public static KlineCandlestickStreamsInterval Interval5m { get; } = new("5m");

    public static KlineCandlestickStreamsInterval Interval15m { get; } = new("15m");

    public static KlineCandlestickStreamsInterval Interval30m { get; } = new("30m");

    public static KlineCandlestickStreamsInterval Interval1h { get; } = new("1h");

    public static KlineCandlestickStreamsInterval Interval2h { get; } = new("2h");

    public static KlineCandlestickStreamsInterval Interval4h { get; } = new("4h");

    public static KlineCandlestickStreamsInterval Interval6h { get; } = new("6h");

    public static KlineCandlestickStreamsInterval Interval8h { get; } = new("8h");

    public static KlineCandlestickStreamsInterval Interval12h { get; } = new("12h");

    public static KlineCandlestickStreamsInterval Interval1d { get; } = new("1d");

    public static KlineCandlestickStreamsInterval Interval3d { get; } = new("3d");

    public static KlineCandlestickStreamsInterval Interval1w { get; } = new("1w");

    public static KlineCandlestickStreamsInterval Interval1Month { get; } = new("1M");

    static KlineCandlestickStreamsInterval IExtensibleValue<KlineCandlestickStreamsInterval>.Create(string value) => new(value);

    public static bool operator ==(KlineCandlestickStreamsInterval left, KlineCandlestickStreamsInterval right) => left.Equals(right);

    public static bool operator !=(KlineCandlestickStreamsInterval left, KlineCandlestickStreamsInterval right) => !left.Equals(right);

    public static implicit operator KlineCandlestickStreamsInterval(string value) => new(value);

    public static KlineCandlestickStreamsInterval FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is KlineCandlestickStreamsInterval other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(KlineCandlestickStreamsInterval other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class KlineCandlestickStreamsRequest
{
    /// <summary>The symbol parameter</summary>
    public required string Symbol { get; init; }

    /// <summary>The interval parameter</summary>
    public required KlineCandlestickStreamsInterval Interval { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<MarkPriceKlineCandlestickStreamsInterval>))]
public readonly struct MarkPriceKlineCandlestickStreamsInterval : IExtensibleValue<MarkPriceKlineCandlestickStreamsInterval>, IEquatable<MarkPriceKlineCandlestickStreamsInterval>
{
    private readonly string? _value;

    public MarkPriceKlineCandlestickStreamsInterval(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarkPriceKlineCandlestickStreamsInterval Interval1m { get; } = new("1m");

    public static MarkPriceKlineCandlestickStreamsInterval Interval3m { get; } = new("3m");

    public static MarkPriceKlineCandlestickStreamsInterval Interval5m { get; } = new("5m");

    public static MarkPriceKlineCandlestickStreamsInterval Interval15m { get; } = new("15m");

    public static MarkPriceKlineCandlestickStreamsInterval Interval30m { get; } = new("30m");

    public static MarkPriceKlineCandlestickStreamsInterval Interval1h { get; } = new("1h");

    public static MarkPriceKlineCandlestickStreamsInterval Interval2h { get; } = new("2h");

    public static MarkPriceKlineCandlestickStreamsInterval Interval4h { get; } = new("4h");

    public static MarkPriceKlineCandlestickStreamsInterval Interval6h { get; } = new("6h");

    public static MarkPriceKlineCandlestickStreamsInterval Interval8h { get; } = new("8h");

    public static MarkPriceKlineCandlestickStreamsInterval Interval12h { get; } = new("12h");

    public static MarkPriceKlineCandlestickStreamsInterval Interval1d { get; } = new("1d");

    public static MarkPriceKlineCandlestickStreamsInterval Interval3d { get; } = new("3d");

    public static MarkPriceKlineCandlestickStreamsInterval Interval1w { get; } = new("1w");

    public static MarkPriceKlineCandlestickStreamsInterval Interval1Month { get; } = new("1M");

    static MarkPriceKlineCandlestickStreamsInterval IExtensibleValue<MarkPriceKlineCandlestickStreamsInterval>.Create(string value) => new(value);

    public static bool operator ==(MarkPriceKlineCandlestickStreamsInterval left, MarkPriceKlineCandlestickStreamsInterval right) => left.Equals(right);

    public static bool operator !=(MarkPriceKlineCandlestickStreamsInterval left, MarkPriceKlineCandlestickStreamsInterval right) => !left.Equals(right);

    public static implicit operator MarkPriceKlineCandlestickStreamsInterval(string value) => new(value);

    public static MarkPriceKlineCandlestickStreamsInterval FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarkPriceKlineCandlestickStreamsInterval other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarkPriceKlineCandlestickStreamsInterval other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class MarkPriceKlineCandlestickStreamsRequest
{
    /// <summary>The symbol parameter</summary>
    public required string Symbol { get; init; }

    /// <summary>The interval parameter</summary>
    public required MarkPriceKlineCandlestickStreamsInterval Interval { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<MarkPriceOfAllSymbolsOfAPairUpdateSpeed>))]
public readonly struct MarkPriceOfAllSymbolsOfAPairUpdateSpeed : IExtensibleValue<MarkPriceOfAllSymbolsOfAPairUpdateSpeed>, IEquatable<MarkPriceOfAllSymbolsOfAPairUpdateSpeed>
{
    private readonly string? _value;

    public MarkPriceOfAllSymbolsOfAPairUpdateSpeed(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarkPriceOfAllSymbolsOfAPairUpdateSpeed UpdateSpeed1s { get; } = new("1s");

    static MarkPriceOfAllSymbolsOfAPairUpdateSpeed IExtensibleValue<MarkPriceOfAllSymbolsOfAPairUpdateSpeed>.Create(string value) => new(value);

    public static bool operator ==(MarkPriceOfAllSymbolsOfAPairUpdateSpeed left, MarkPriceOfAllSymbolsOfAPairUpdateSpeed right) => left.Equals(right);

    public static bool operator !=(MarkPriceOfAllSymbolsOfAPairUpdateSpeed left, MarkPriceOfAllSymbolsOfAPairUpdateSpeed right) => !left.Equals(right);

    public static implicit operator MarkPriceOfAllSymbolsOfAPairUpdateSpeed(string value) => new(value);

    public static MarkPriceOfAllSymbolsOfAPairUpdateSpeed FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarkPriceOfAllSymbolsOfAPairUpdateSpeed other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarkPriceOfAllSymbolsOfAPairUpdateSpeed other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class MarkPriceOfAllSymbolsOfAPairRequest
{
    /// <summary>The pair parameter</summary>
    public required string Pair { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }

    /// <summary>WebSocket stream update speed</summary>
    public MarkPriceOfAllSymbolsOfAPairUpdateSpeed? UpdateSpeed { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<MarkPriceStreamUpdateSpeed>))]
public readonly struct MarkPriceStreamUpdateSpeed : IExtensibleValue<MarkPriceStreamUpdateSpeed>, IEquatable<MarkPriceStreamUpdateSpeed>
{
    private readonly string? _value;

    public MarkPriceStreamUpdateSpeed(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarkPriceStreamUpdateSpeed UpdateSpeed1s { get; } = new("1s");

    static MarkPriceStreamUpdateSpeed IExtensibleValue<MarkPriceStreamUpdateSpeed>.Create(string value) => new(value);

    public static bool operator ==(MarkPriceStreamUpdateSpeed left, MarkPriceStreamUpdateSpeed right) => left.Equals(right);

    public static bool operator !=(MarkPriceStreamUpdateSpeed left, MarkPriceStreamUpdateSpeed right) => !left.Equals(right);

    public static implicit operator MarkPriceStreamUpdateSpeed(string value) => new(value);

    public static MarkPriceStreamUpdateSpeed FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarkPriceStreamUpdateSpeed other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarkPriceStreamUpdateSpeed other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class MarkPriceStreamRequest
{
    /// <summary>The symbol parameter</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }

    /// <summary>WebSocket stream update speed</summary>
    public MarkPriceStreamUpdateSpeed? UpdateSpeed { get; init; }
}

public sealed class MarketLiquidationOrderStreamsRequest
{
    /// <summary>The symbol parameter</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<PartialBookDepthStreamsLevels>))]
public readonly struct PartialBookDepthStreamsLevels : IExtensibleValue<PartialBookDepthStreamsLevels>, IEquatable<PartialBookDepthStreamsLevels>
{
    private readonly string? _value;

    public PartialBookDepthStreamsLevels(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PartialBookDepthStreamsLevels Levels5 { get; } = new("5");

    public static PartialBookDepthStreamsLevels Levels10 { get; } = new("10");

    public static PartialBookDepthStreamsLevels Levels20 { get; } = new("20");

    static PartialBookDepthStreamsLevels IExtensibleValue<PartialBookDepthStreamsLevels>.Create(string value) => new(value);

    public static bool operator ==(PartialBookDepthStreamsLevels left, PartialBookDepthStreamsLevels right) => left.Equals(right);

    public static bool operator !=(PartialBookDepthStreamsLevels left, PartialBookDepthStreamsLevels right) => !left.Equals(right);

    public static implicit operator PartialBookDepthStreamsLevels(string value) => new(value);

    public static PartialBookDepthStreamsLevels FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PartialBookDepthStreamsLevels other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PartialBookDepthStreamsLevels other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<PartialBookDepthStreamsUpdateSpeed>))]
public readonly struct PartialBookDepthStreamsUpdateSpeed : IExtensibleValue<PartialBookDepthStreamsUpdateSpeed>, IEquatable<PartialBookDepthStreamsUpdateSpeed>
{
    private readonly string? _value;

    public PartialBookDepthStreamsUpdateSpeed(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PartialBookDepthStreamsUpdateSpeed UpdateSpeed100ms { get; } = new("100ms");

    public static PartialBookDepthStreamsUpdateSpeed UpdateSpeed500ms { get; } = new("500ms");

    static PartialBookDepthStreamsUpdateSpeed IExtensibleValue<PartialBookDepthStreamsUpdateSpeed>.Create(string value) => new(value);

    public static bool operator ==(PartialBookDepthStreamsUpdateSpeed left, PartialBookDepthStreamsUpdateSpeed right) => left.Equals(right);

    public static bool operator !=(PartialBookDepthStreamsUpdateSpeed left, PartialBookDepthStreamsUpdateSpeed right) => !left.Equals(right);

    public static implicit operator PartialBookDepthStreamsUpdateSpeed(string value) => new(value);

    public static PartialBookDepthStreamsUpdateSpeed FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PartialBookDepthStreamsUpdateSpeed other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PartialBookDepthStreamsUpdateSpeed other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class PartialBookDepthStreamsRequest
{
    /// <summary>The symbol parameter</summary>
    public required string Symbol { get; init; }

    /// <summary>The levels parameter</summary>
    public required PartialBookDepthStreamsLevels Levels { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }

    /// <summary>WebSocket stream update speed</summary>
    public PartialBookDepthStreamsUpdateSpeed? UpdateSpeed { get; init; }
}

public sealed partial class DerivativesTradingCoinFuturesWebSocketStreamsConnection
{

    /// <summary>Aggregate Trade Streams</summary>
    /// <remarks>
    /// <para>
    /// The Aggregate Trade Streams push market trade information that is aggregated for fills with same
    /// price and taking side every 100 milliseconds.
    /// </para>
    /// <para>&gt; After CM migration, the payload is appended with a new st field (1 = UM, 2 = CM).</para>
    /// <para>Update Speed: 100ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<AggregateTradeStreamsResponse> AggregateTradeStreams(AggregateTradeStreamsRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@aggTrade", ("symbol", request.Symbol), ("id", request.Id)), DerivativesTradingCoinFuturesWebSocketStreamsJson.Default.AggregateTradeStreamsResponse, null, id: request.Id);
    }

    /// <summary>All Book Tickers Stream</summary>
    /// <remarks>
    /// <para>Pushes any update to the best bid or ask's price or quantity in real-time for all symbols.</para>
    /// <para>
    /// &gt; After CM migration, this stream pushes the merged UM + CM universe (subscribable on both
    /// fstream and dstream); each payload is appended with a new st field (1 = UM, 2 = CM).
    /// </para>
    /// <para>Update Speed: Real-time</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<AllBookTickersStreamResponse> AllBookTickersStream(AllBookTickersStreamRequest? request = null)
    {
        request ??= new();
        return _client.Subscribe(StreamName.Build("/!bookTicker", ("id", request.Id)), DerivativesTradingCoinFuturesWebSocketStreamsJson.Default.AllBookTickersStreamResponse, null, id: request.Id);
    }

    /// <summary>All Market Liquidation Order Streams</summary>
    /// <remarks>
    /// <para>
    /// The All Liquidation Order Snapshot Streams push force liquidation order information for all symbols
    /// in the market. For each symbol，only the latest one liquidation order within 1000ms will be pushed as
    /// the snapshot. If no liquidation happens in the interval of 1000ms, no stream will be pushed.
    /// </para>
    /// <para>
    /// &gt; After CM migration, this stream pushes the merged UM + CM universe (subscribable on both
    /// fstream and dstream); each payload is appended with a new st field (1 = UM, 2 = CM).
    /// </para>
    /// <para>Update Speed: 1000ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<AllMarketLiquidationOrderStreamsResponse> AllMarketLiquidationOrderStreams(AllMarketLiquidationOrderStreamsRequest? request = null)
    {
        request ??= new();
        return _client.Subscribe(StreamName.Build("/!forceOrder@arr", ("id", request.Id)), DerivativesTradingCoinFuturesWebSocketStreamsJson.Default.AllMarketLiquidationOrderStreamsResponse, null, id: request.Id);
    }

    /// <summary>All Market Mini Tickers Stream</summary>
    /// <remarks>
    /// <para>
    /// 24hr rolling window mini-ticker statistics for all symbols. These are NOT the statistics of the UTC
    /// day, but a 24hr rolling window from requestTime to 24hrs before. Note that only tickers that have
    /// changed will be present in the array.
    /// </para>
    /// <para>
    /// &gt; After CM migration, this stream pushes the merged UM + CM universe (subscribable on both
    /// fstream and dstream); each payload is appended with a new st field (1 = UM, 2 = CM).
    /// </para>
    /// <para>Update Speed: 1000ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<List<AllMarketMiniTickersStreamResponseInner>> AllMarketMiniTickersStream(AllMarketMiniTickersStreamRequest? request = null)
    {
        request ??= new();
        return _client.Subscribe(StreamName.Build("/!miniTicker@arr", ("id", request.Id)), DerivativesTradingCoinFuturesWebSocketStreamsJson.Default.ListAllMarketMiniTickersStreamResponseInner, null, id: request.Id);
    }

    /// <summary>All Market Tickers Streams</summary>
    /// <remarks>
    /// <para>
    /// 24hr rolling window ticker statistics for all symbols. These are NOT the statistics of the UTC day,
    /// but a 24hr rolling window from requestTime to 24hrs before. Note that only tickers that have changed
    /// will be present in the array.
    /// </para>
    /// <para>
    /// &gt; After CM migration, this stream pushes the merged UM + CM universe (subscribable on both
    /// fstream and dstream); each payload is appended with a new st field (1 = UM, 2 = CM).
    /// </para>
    /// <para>Update Speed: 1000ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<List<AllMarketTickersStreamsResponseInner>> AllMarketTickersStreams(AllMarketTickersStreamsRequest? request = null)
    {
        request ??= new();
        return _client.Subscribe(StreamName.Build("/!ticker@arr", ("id", request.Id)), DerivativesTradingCoinFuturesWebSocketStreamsJson.Default.ListAllMarketTickersStreamsResponseInner, null, id: request.Id);
    }

    /// <summary>Continuous Contract Kline/Candlestick Streams</summary>
    /// <remarks>
    /// <para>Kline update every second</para>
    /// <para>
    /// &gt; After CM migration, both fstream and dstream may subscribe to either UM or CM symbols on this
    /// stream.
    /// </para>
    /// <para>Update Speed: 250ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<ContinuousContractKlineCandlestickStreamsResponse> ContinuousContractKlineCandlestickStreams(ContinuousContractKlineCandlestickStreamsRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<pair>_<contractType>@continuousKline_<interval>", ("pair", request.Pair), ("contractType", request.ContractType), ("interval", request.Interval), ("id", request.Id)), DerivativesTradingCoinFuturesWebSocketStreamsJson.Default.ContinuousContractKlineCandlestickStreamsResponse, null, id: request.Id);
    }

    /// <summary>Contract Info Stream</summary>
    /// <remarks>
    /// <para>
    /// ContractInfo stream pushes when contract info updates(listing/settlement/contract bracket update).
    /// bks field only shows up when bracket gets updated.
    /// </para>
    /// <para>
    /// &gt; After CM migration, this stream pushes the merged UM + CM universe (subscribable on both
    /// fstream and dstream); each payload is appended with a new st field (1 = UM, 2 = CM).
    /// </para>
    /// <para>Update Speed: Real-time</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<ContractInfoStreamResponse> ContractInfoStream(ContractInfoStreamRequest? request = null)
    {
        request ??= new();
        return _client.Subscribe(StreamName.Build("/!contractInfo", ("id", request.Id)), DerivativesTradingCoinFuturesWebSocketStreamsJson.Default.ContractInfoStreamResponse, null, id: request.Id);
    }

    /// <summary>Diff. Book Depth Streams</summary>
    /// <remarks>
    /// <para>Bids and asks, pushed every 250 milliseconds, 500 milliseconds, or 100 milliseconds</para>
    /// <para>&gt; After CM migration, the payload is appended with a new st field (1 = UM, 2 = CM).</para>
    /// <para>Update Speed: 250ms or 500ms or 100ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<DiffBookDepthStreamsResponse> DiffBookDepthStreams(DiffBookDepthStreamsRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@depth@<updateSpeed>", ("symbol", request.Symbol), ("id", request.Id), ("updateSpeed", request.UpdateSpeed)), DerivativesTradingCoinFuturesWebSocketStreamsJson.Default.DiffBookDepthStreamsResponse, null, id: request.Id);
    }

    /// <summary>Index Kline/Candlestick Streams</summary>
    /// <remarks>
    /// <para>&gt; After CM migration, both fstream and dstream may subscribe to CM symbols on this stream.</para>
    /// <para>Update Speed: 250ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<IndexKlineCandlestickStreamsResponse> IndexKlineCandlestickStreams(IndexKlineCandlestickStreamsRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<pair>@indexPriceKline_<interval>", ("pair", request.Pair), ("interval", request.Interval), ("id", request.Id)), DerivativesTradingCoinFuturesWebSocketStreamsJson.Default.IndexKlineCandlestickStreamsResponse, null, id: request.Id);
    }

    /// <summary>Index Price Stream</summary>
    /// <remarks>Update Speed: 3000ms OR 1000ms</remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<IndexPriceStreamResponse> IndexPriceStream(IndexPriceStreamRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<pair>@indexPrice@<updateSpeed>", ("pair", request.Pair), ("id", request.Id), ("updateSpeed", request.UpdateSpeed)), DerivativesTradingCoinFuturesWebSocketStreamsJson.Default.IndexPriceStreamResponse, null, id: request.Id);
    }

    /// <summary>Individual Symbol Book Ticker Streams</summary>
    /// <remarks>
    /// <para>Pushes any update to the best bid or ask's price or quantity in real-time for a specified symbol.</para>
    /// <para>&gt; After CM migration, the payload is appended with a new st field (1 = UM, 2 = CM).</para>
    /// <para>Update Speed: Real-time</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<IndividualSymbolBookTickerStreamsResponse> IndividualSymbolBookTickerStreams(IndividualSymbolBookTickerStreamsRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@bookTicker", ("symbol", request.Symbol), ("id", request.Id)), DerivativesTradingCoinFuturesWebSocketStreamsJson.Default.IndividualSymbolBookTickerStreamsResponse, null, id: request.Id);
    }

    /// <summary>Individual Symbol Mini Ticker Stream</summary>
    /// <remarks>
    /// <para>
    /// 24hr rolling window mini-ticker statistics for a single symbol. These are NOT the statistics of the
    /// UTC day, but a 24hr rolling window from requestTime to 24hrs before.
    /// </para>
    /// <para>&gt; After CM migration, the payload is appended with a new st field (1 = UM, 2 = CM).</para>
    /// <para>Update Speed: 500ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<IndividualSymbolMiniTickerStreamResponse> IndividualSymbolMiniTickerStream(IndividualSymbolMiniTickerStreamRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@miniTicker", ("symbol", request.Symbol), ("id", request.Id)), DerivativesTradingCoinFuturesWebSocketStreamsJson.Default.IndividualSymbolMiniTickerStreamResponse, null, id: request.Id);
    }

    /// <summary>Individual Symbol Ticker Streams</summary>
    /// <remarks>
    /// <para>
    /// 24hr rolling window ticker statistics for a single symbol. These are NOT the statistics of the UTC
    /// day, but a 24hr rolling window from requestTime to 24hrs before.
    /// </para>
    /// <para>&gt; After CM migration, the payload is appended with a new st field (1 = UM, 2 = CM).</para>
    /// <para>Update Speed: 500ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<IndividualSymbolTickerStreamsResponse> IndividualSymbolTickerStreams(IndividualSymbolTickerStreamsRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@ticker", ("symbol", request.Symbol), ("id", request.Id)), DerivativesTradingCoinFuturesWebSocketStreamsJson.Default.IndividualSymbolTickerStreamsResponse, null, id: request.Id);
    }

    /// <summary>Kline/Candlestick Streams</summary>
    /// <remarks>
    /// <para>
    /// The Kline/Candlestick Stream push updates to the current klines/candlestick every 250 milliseconds
    /// (if existing).
    /// </para>
    /// <para>
    /// &gt; After CM migration, both fstream and dstream may subscribe to either UM or CM symbols on this
    /// stream.
    /// </para>
    /// <para>Update Speed: 250ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<KlineCandlestickStreamsResponse> KlineCandlestickStreams(KlineCandlestickStreamsRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@kline_<interval>", ("symbol", request.Symbol), ("interval", request.Interval), ("id", request.Id)), DerivativesTradingCoinFuturesWebSocketStreamsJson.Default.KlineCandlestickStreamsResponse, null, id: request.Id);
    }

    /// <summary>Mark Price Kline/Candlestick Streams</summary>
    /// <remarks>
    /// <para>&gt; After CM migration, both fstream and dstream may subscribe to CM symbols on this stream.</para>
    /// <para>Update Speed: 250ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<MarkPriceKlineCandlestickStreamsResponse> MarkPriceKlineCandlestickStreams(MarkPriceKlineCandlestickStreamsRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@markPriceKline_<interval>", ("symbol", request.Symbol), ("interval", request.Interval), ("id", request.Id)), DerivativesTradingCoinFuturesWebSocketStreamsJson.Default.MarkPriceKlineCandlestickStreamsResponse, null, id: request.Id);
    }

    /// <summary>Mark Price of All Symbols of a Pair</summary>
    /// <remarks>
    /// <para>
    /// &gt; After CM migration, the payload is appended with a new st field (1 = UM, 2 = CM); both fstream
    /// and dstream may subscribe to either UM or CM symbols on this stream.
    /// </para>
    /// <para>Update Speed: 3000ms OR 1000ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<List<MarkPriceOfAllSymbolsOfAPairResponseInner>> MarkPriceOfAllSymbolsOfAPair(MarkPriceOfAllSymbolsOfAPairRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<pair>@markPrice@<updateSpeed>", ("pair", request.Pair), ("id", request.Id), ("updateSpeed", request.UpdateSpeed)), DerivativesTradingCoinFuturesWebSocketStreamsJson.Default.ListMarkPriceOfAllSymbolsOfAPairResponseInner, null, id: request.Id);
    }

    /// <summary>Mark Price Stream</summary>
    /// <remarks>
    /// <para>Mark price update stream</para>
    /// <para>
    /// &gt; After CM migration, the payload is appended with a new st field (1 = UM, 2 = CM); both fstream
    /// and dstream may subscribe to either UM or CM symbols on this stream.
    /// </para>
    /// <para>Update Speed: 3000ms OR 1000ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<MarkPriceStreamResponse> MarkPriceStream(MarkPriceStreamRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@markPrice@<updateSpeed>", ("symbol", request.Symbol), ("id", request.Id), ("updateSpeed", request.UpdateSpeed)), DerivativesTradingCoinFuturesWebSocketStreamsJson.Default.MarkPriceStreamResponse, null, id: request.Id);
    }

    /// <summary>Market Liquidation Order Streams</summary>
    /// <remarks>
    /// <para>
    /// The Liquidation Order Snapshot Streams push force liquidation order information for specific symbol.
    /// For each symbol，only the latest one liquidation order within 1000ms will be pushed as the snapshot.
    /// If no liquidation happens in the interval of 1000ms, no stream will be pushed.
    /// </para>
    /// <para>Update Speed: 1000ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<MarketLiquidationOrderStreamsResponse> MarketLiquidationOrderStreams(MarketLiquidationOrderStreamsRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@forceOrder", ("symbol", request.Symbol), ("id", request.Id)), DerivativesTradingCoinFuturesWebSocketStreamsJson.Default.MarketLiquidationOrderStreamsResponse, null, id: request.Id);
    }

    /// <summary>Partial Book Depth Streams</summary>
    /// <remarks>
    /// <para>Top levels bids and asks.</para>
    /// <para>&gt; After CM migration, the payload is appended with a new st field (1 = UM, 2 = CM).</para>
    /// <para>Update Speed: 250ms, 500ms or 100ms</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<PartialBookDepthStreamsResponse> PartialBookDepthStreams(PartialBookDepthStreamsRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<symbol>@depth<levels>@<updateSpeed>", ("symbol", request.Symbol), ("levels", request.Levels), ("id", request.Id), ("updateSpeed", request.UpdateSpeed)), DerivativesTradingCoinFuturesWebSocketStreamsJson.Default.PartialBookDepthStreamsResponse, null, id: request.Id);
    }
}
