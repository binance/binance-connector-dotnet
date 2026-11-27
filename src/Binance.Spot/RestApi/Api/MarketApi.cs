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

namespace Binance.Spot.RestApi;

public sealed class AggTradesRequest
{
    public required string Symbol { get; init; }

    /// <summary>ID to get aggregate trades from INCLUSIVE.</summary>
    public long? FromId { get; init; }

    /// <summary>Timestamp in ms to get aggregate trades from INCLUSIVE.</summary>
    public long? StartTime { get; init; }

    /// <summary>Timestamp in ms to get aggregate trades until INCLUSIVE.</summary>
    public long? EndTime { get; init; }

    public long? Limit { get; init; }
}

public sealed class AvgPriceRequest
{
    public required string Symbol { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<DepthSymbolStatus>))]
public readonly struct DepthSymbolStatus : IExtensibleValue<DepthSymbolStatus>, IEquatable<DepthSymbolStatus>
{
    private readonly string? _value;

    public DepthSymbolStatus(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static DepthSymbolStatus Trading { get; } = new("TRADING");

    public static DepthSymbolStatus Halt { get; } = new("HALT");

    public static DepthSymbolStatus Break { get; } = new("BREAK");

    public static DepthSymbolStatus CancelOnly { get; } = new("CANCEL_ONLY");

    static DepthSymbolStatus IExtensibleValue<DepthSymbolStatus>.Create(string value) => new(value);

    public static bool operator ==(DepthSymbolStatus left, DepthSymbolStatus right) => left.Equals(right);

    public static bool operator !=(DepthSymbolStatus left, DepthSymbolStatus right) => !left.Equals(right);

    public static implicit operator DepthSymbolStatus(string value) => new(value);

    public static DepthSymbolStatus FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is DepthSymbolStatus other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(DepthSymbolStatus other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class DepthRequest
{
    public required string Symbol { get; init; }

    /// <summary>If limit &gt; 7500, only 7500 entries will be returned.</summary>
    public long? Limit { get; init; }

    /// <summary>
    /// Filters for symbols that have this tradingStatus. A status mismatch returns error -1220
    /// SYMBOL_DOES_NOT_MATCH_STATUS.
    /// </summary>
    public DepthSymbolStatus? SymbolStatus { get; init; }
}

public sealed class GetTradesRequest
{
    public required string Symbol { get; init; }

    public long? Limit { get; init; }
}

public sealed class HistoricalBlockTradesRequest
{
    public required string Symbol { get; init; }

    /// <summary>Block trade ID to fetch from</summary>
    public required long FromId { get; init; }

    /// <summary>Default: 500; Maximum: 1000</summary>
    public long? Limit { get; init; }
}

public sealed class HistoricalTradesRequest
{
    public required string Symbol { get; init; }

    public long? Limit { get; init; }

    /// <summary>TradeId to fetch from. Default gets most recent trades.</summary>
    public long? FromId { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<KlinesInterval>))]
public readonly struct KlinesInterval : IExtensibleValue<KlinesInterval>, IEquatable<KlinesInterval>
{
    private readonly string? _value;

    public KlinesInterval(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static KlinesInterval Interval1s { get; } = new("1s");

    public static KlinesInterval Interval1m { get; } = new("1m");

    public static KlinesInterval Interval3m { get; } = new("3m");

    public static KlinesInterval Interval5m { get; } = new("5m");

    public static KlinesInterval Interval15m { get; } = new("15m");

    public static KlinesInterval Interval30m { get; } = new("30m");

    public static KlinesInterval Interval1h { get; } = new("1h");

    public static KlinesInterval Interval2h { get; } = new("2h");

    public static KlinesInterval Interval4h { get; } = new("4h");

    public static KlinesInterval Interval6h { get; } = new("6h");

    public static KlinesInterval Interval8h { get; } = new("8h");

    public static KlinesInterval Interval12h { get; } = new("12h");

    public static KlinesInterval Interval1d { get; } = new("1d");

    public static KlinesInterval Interval3d { get; } = new("3d");

    public static KlinesInterval Interval1w { get; } = new("1w");

    public static KlinesInterval Interval1Month { get; } = new("1M");

    static KlinesInterval IExtensibleValue<KlinesInterval>.Create(string value) => new(value);

    public static bool operator ==(KlinesInterval left, KlinesInterval right) => left.Equals(right);

    public static bool operator !=(KlinesInterval left, KlinesInterval right) => !left.Equals(right);

    public static implicit operator KlinesInterval(string value) => new(value);

    public static KlinesInterval FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is KlinesInterval other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(KlinesInterval other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class KlinesRequest
{
    public required string Symbol { get; init; }

    public required KlinesInterval Interval { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Default: 0 (UTC)</summary>
    public string? TimeZone { get; init; }

    public long? Limit { get; init; }
}

public sealed class ReferencePriceRequest
{
    public required string Symbol { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<ReferencePriceCalculationSymbolStatus>))]
public readonly struct ReferencePriceCalculationSymbolStatus : IExtensibleValue<ReferencePriceCalculationSymbolStatus>, IEquatable<ReferencePriceCalculationSymbolStatus>
{
    private readonly string? _value;

    public ReferencePriceCalculationSymbolStatus(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static ReferencePriceCalculationSymbolStatus Trading { get; } = new("TRADING");

    public static ReferencePriceCalculationSymbolStatus Halt { get; } = new("HALT");

    public static ReferencePriceCalculationSymbolStatus Break { get; } = new("BREAK");

    public static ReferencePriceCalculationSymbolStatus CancelOnly { get; } = new("CANCEL_ONLY");

    static ReferencePriceCalculationSymbolStatus IExtensibleValue<ReferencePriceCalculationSymbolStatus>.Create(string value) => new(value);

    public static bool operator ==(ReferencePriceCalculationSymbolStatus left, ReferencePriceCalculationSymbolStatus right) => left.Equals(right);

    public static bool operator !=(ReferencePriceCalculationSymbolStatus left, ReferencePriceCalculationSymbolStatus right) => !left.Equals(right);

    public static implicit operator ReferencePriceCalculationSymbolStatus(string value) => new(value);

    public static ReferencePriceCalculationSymbolStatus FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ReferencePriceCalculationSymbolStatus other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ReferencePriceCalculationSymbolStatus other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class ReferencePriceCalculationRequest
{
    public required string Symbol { get; init; }

    /// <summary>Supported values: TRADING, HALT, BREAK, CANCEL_ONLY</summary>
    public ReferencePriceCalculationSymbolStatus? SymbolStatus { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<TickerWindowSize>))]
public readonly struct TickerWindowSize : IExtensibleValue<TickerWindowSize>, IEquatable<TickerWindowSize>
{
    private readonly string? _value;

    public TickerWindowSize(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static TickerWindowSize WindowSize1m { get; } = new("1m");

    public static TickerWindowSize WindowSize2m { get; } = new("2m");

    public static TickerWindowSize WindowSize3m { get; } = new("3m");

    public static TickerWindowSize WindowSize4m { get; } = new("4m");

    public static TickerWindowSize WindowSize5m { get; } = new("5m");

    public static TickerWindowSize WindowSize6m { get; } = new("6m");

    public static TickerWindowSize WindowSize7m { get; } = new("7m");

    public static TickerWindowSize WindowSize8m { get; } = new("8m");

    public static TickerWindowSize WindowSize9m { get; } = new("9m");

    public static TickerWindowSize WindowSize10m { get; } = new("10m");

    public static TickerWindowSize WindowSize11m { get; } = new("11m");

    public static TickerWindowSize WindowSize12m { get; } = new("12m");

    public static TickerWindowSize WindowSize13m { get; } = new("13m");

    public static TickerWindowSize WindowSize14m { get; } = new("14m");

    public static TickerWindowSize WindowSize15m { get; } = new("15m");

    public static TickerWindowSize WindowSize16m { get; } = new("16m");

    public static TickerWindowSize WindowSize17m { get; } = new("17m");

    public static TickerWindowSize WindowSize18m { get; } = new("18m");

    public static TickerWindowSize WindowSize19m { get; } = new("19m");

    public static TickerWindowSize WindowSize20m { get; } = new("20m");

    public static TickerWindowSize WindowSize21m { get; } = new("21m");

    public static TickerWindowSize WindowSize22m { get; } = new("22m");

    public static TickerWindowSize WindowSize23m { get; } = new("23m");

    public static TickerWindowSize WindowSize24m { get; } = new("24m");

    public static TickerWindowSize WindowSize25m { get; } = new("25m");

    public static TickerWindowSize WindowSize26m { get; } = new("26m");

    public static TickerWindowSize WindowSize27m { get; } = new("27m");

    public static TickerWindowSize WindowSize28m { get; } = new("28m");

    public static TickerWindowSize WindowSize29m { get; } = new("29m");

    public static TickerWindowSize WindowSize30m { get; } = new("30m");

    public static TickerWindowSize WindowSize31m { get; } = new("31m");

    public static TickerWindowSize WindowSize32m { get; } = new("32m");

    public static TickerWindowSize WindowSize33m { get; } = new("33m");

    public static TickerWindowSize WindowSize34m { get; } = new("34m");

    public static TickerWindowSize WindowSize35m { get; } = new("35m");

    public static TickerWindowSize WindowSize36m { get; } = new("36m");

    public static TickerWindowSize WindowSize37m { get; } = new("37m");

    public static TickerWindowSize WindowSize38m { get; } = new("38m");

    public static TickerWindowSize WindowSize39m { get; } = new("39m");

    public static TickerWindowSize WindowSize40m { get; } = new("40m");

    public static TickerWindowSize WindowSize41m { get; } = new("41m");

    public static TickerWindowSize WindowSize42m { get; } = new("42m");

    public static TickerWindowSize WindowSize43m { get; } = new("43m");

    public static TickerWindowSize WindowSize44m { get; } = new("44m");

    public static TickerWindowSize WindowSize45m { get; } = new("45m");

    public static TickerWindowSize WindowSize46m { get; } = new("46m");

    public static TickerWindowSize WindowSize47m { get; } = new("47m");

    public static TickerWindowSize WindowSize48m { get; } = new("48m");

    public static TickerWindowSize WindowSize49m { get; } = new("49m");

    public static TickerWindowSize WindowSize50m { get; } = new("50m");

    public static TickerWindowSize WindowSize51m { get; } = new("51m");

    public static TickerWindowSize WindowSize52m { get; } = new("52m");

    public static TickerWindowSize WindowSize53m { get; } = new("53m");

    public static TickerWindowSize WindowSize54m { get; } = new("54m");

    public static TickerWindowSize WindowSize55m { get; } = new("55m");

    public static TickerWindowSize WindowSize56m { get; } = new("56m");

    public static TickerWindowSize WindowSize57m { get; } = new("57m");

    public static TickerWindowSize WindowSize58m { get; } = new("58m");

    public static TickerWindowSize WindowSize59m { get; } = new("59m");

    public static TickerWindowSize WindowSize1h { get; } = new("1h");

    public static TickerWindowSize WindowSize2h { get; } = new("2h");

    public static TickerWindowSize WindowSize3h { get; } = new("3h");

    public static TickerWindowSize WindowSize4h { get; } = new("4h");

    public static TickerWindowSize WindowSize5h { get; } = new("5h");

    public static TickerWindowSize WindowSize6h { get; } = new("6h");

    public static TickerWindowSize WindowSize7h { get; } = new("7h");

    public static TickerWindowSize WindowSize8h { get; } = new("8h");

    public static TickerWindowSize WindowSize9h { get; } = new("9h");

    public static TickerWindowSize WindowSize10h { get; } = new("10h");

    public static TickerWindowSize WindowSize11h { get; } = new("11h");

    public static TickerWindowSize WindowSize12h { get; } = new("12h");

    public static TickerWindowSize WindowSize13h { get; } = new("13h");

    public static TickerWindowSize WindowSize14h { get; } = new("14h");

    public static TickerWindowSize WindowSize15h { get; } = new("15h");

    public static TickerWindowSize WindowSize16h { get; } = new("16h");

    public static TickerWindowSize WindowSize17h { get; } = new("17h");

    public static TickerWindowSize WindowSize18h { get; } = new("18h");

    public static TickerWindowSize WindowSize19h { get; } = new("19h");

    public static TickerWindowSize WindowSize20h { get; } = new("20h");

    public static TickerWindowSize WindowSize21h { get; } = new("21h");

    public static TickerWindowSize WindowSize22h { get; } = new("22h");

    public static TickerWindowSize WindowSize23h { get; } = new("23h");

    public static TickerWindowSize WindowSize1d { get; } = new("1d");

    public static TickerWindowSize WindowSize2d { get; } = new("2d");

    public static TickerWindowSize WindowSize3d { get; } = new("3d");

    public static TickerWindowSize WindowSize4d { get; } = new("4d");

    public static TickerWindowSize WindowSize5d { get; } = new("5d");

    public static TickerWindowSize WindowSize6d { get; } = new("6d");

    public static TickerWindowSize WindowSize7d { get; } = new("7d");

    static TickerWindowSize IExtensibleValue<TickerWindowSize>.Create(string value) => new(value);

    public static bool operator ==(TickerWindowSize left, TickerWindowSize right) => left.Equals(right);

    public static bool operator !=(TickerWindowSize left, TickerWindowSize right) => !left.Equals(right);

    public static implicit operator TickerWindowSize(string value) => new(value);

    public static TickerWindowSize FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TickerWindowSize other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(TickerWindowSize other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<TickerType>))]
public readonly struct TickerType : IExtensibleValue<TickerType>, IEquatable<TickerType>
{
    private readonly string? _value;

    public TickerType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static TickerType Full { get; } = new("FULL");

    public static TickerType Mini { get; } = new("MINI");

    static TickerType IExtensibleValue<TickerType>.Create(string value) => new(value);

    public static bool operator ==(TickerType left, TickerType right) => left.Equals(right);

    public static bool operator !=(TickerType left, TickerType right) => !left.Equals(right);

    public static implicit operator TickerType(string value) => new(value);

    public static TickerType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TickerType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(TickerType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<TickerSymbolStatus>))]
public readonly struct TickerSymbolStatus : IExtensibleValue<TickerSymbolStatus>, IEquatable<TickerSymbolStatus>
{
    private readonly string? _value;

    public TickerSymbolStatus(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static TickerSymbolStatus Trading { get; } = new("TRADING");

    public static TickerSymbolStatus Halt { get; } = new("HALT");

    public static TickerSymbolStatus Break { get; } = new("BREAK");

    public static TickerSymbolStatus CancelOnly { get; } = new("CANCEL_ONLY");

    static TickerSymbolStatus IExtensibleValue<TickerSymbolStatus>.Create(string value) => new(value);

    public static bool operator ==(TickerSymbolStatus left, TickerSymbolStatus right) => left.Equals(right);

    public static bool operator !=(TickerSymbolStatus left, TickerSymbolStatus right) => !left.Equals(right);

    public static implicit operator TickerSymbolStatus(string value) => new(value);

    public static TickerSymbolStatus FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TickerSymbolStatus other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(TickerSymbolStatus other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class TickerRequest
{
    /// <summary>Either symbol or symbols must be provided</summary>
    public string? Symbol { get; init; }

    /// <summary>
    /// Either symbol or symbols must be provided Examples of accepted format for the symbols parameter:
    /// ["BTCUSDT","BNBUSDT"] or %5B%22BTCUSDT%22,%22BNBUSDT%22%5D The maximum number of symbols allowed in
    /// a request is 100.
    /// </summary>
    public List<string>? Symbols { get; init; }

    /// <summary>Units cannot be combined (e.g. 1d2h is not allowed).</summary>
    public TickerWindowSize? WindowSize { get; init; }

    public TickerType? Type { get; init; }

    public TickerSymbolStatus? SymbolStatus { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<Ticker24hrType>))]
public readonly struct Ticker24hrType : IExtensibleValue<Ticker24hrType>, IEquatable<Ticker24hrType>
{
    private readonly string? _value;

    public Ticker24hrType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static Ticker24hrType Full { get; } = new("FULL");

    public static Ticker24hrType Mini { get; } = new("MINI");

    static Ticker24hrType IExtensibleValue<Ticker24hrType>.Create(string value) => new(value);

    public static bool operator ==(Ticker24hrType left, Ticker24hrType right) => left.Equals(right);

    public static bool operator !=(Ticker24hrType left, Ticker24hrType right) => !left.Equals(right);

    public static implicit operator Ticker24hrType(string value) => new(value);

    public static Ticker24hrType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is Ticker24hrType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(Ticker24hrType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<Ticker24hrSymbolStatus>))]
public readonly struct Ticker24hrSymbolStatus : IExtensibleValue<Ticker24hrSymbolStatus>, IEquatable<Ticker24hrSymbolStatus>
{
    private readonly string? _value;

    public Ticker24hrSymbolStatus(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static Ticker24hrSymbolStatus Trading { get; } = new("TRADING");

    public static Ticker24hrSymbolStatus Halt { get; } = new("HALT");

    public static Ticker24hrSymbolStatus Break { get; } = new("BREAK");

    public static Ticker24hrSymbolStatus CancelOnly { get; } = new("CANCEL_ONLY");

    static Ticker24hrSymbolStatus IExtensibleValue<Ticker24hrSymbolStatus>.Create(string value) => new(value);

    public static bool operator ==(Ticker24hrSymbolStatus left, Ticker24hrSymbolStatus right) => left.Equals(right);

    public static bool operator !=(Ticker24hrSymbolStatus left, Ticker24hrSymbolStatus right) => !left.Equals(right);

    public static implicit operator Ticker24hrSymbolStatus(string value) => new(value);

    public static Ticker24hrSymbolStatus FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is Ticker24hrSymbolStatus other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(Ticker24hrSymbolStatus other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class Ticker24hrRequest
{
    /// <summary>Either symbol or symbols must be provided</summary>
    public string? Symbol { get; init; }

    /// <summary>
    /// Either symbol or symbols must be provided Examples of accepted format for the symbols parameter:
    /// ["BTCUSDT","BNBUSDT"] or %5B%22BTCUSDT%22,%22BNBUSDT%22%5D The maximum number of symbols allowed in
    /// a request is 100.
    /// </summary>
    public List<string>? Symbols { get; init; }

    public Ticker24hrType? Type { get; init; }

    public Ticker24hrSymbolStatus? SymbolStatus { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<TickerBookTickerSymbolStatus>))]
public readonly struct TickerBookTickerSymbolStatus : IExtensibleValue<TickerBookTickerSymbolStatus>, IEquatable<TickerBookTickerSymbolStatus>
{
    private readonly string? _value;

    public TickerBookTickerSymbolStatus(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static TickerBookTickerSymbolStatus Trading { get; } = new("TRADING");

    public static TickerBookTickerSymbolStatus Halt { get; } = new("HALT");

    public static TickerBookTickerSymbolStatus Break { get; } = new("BREAK");

    public static TickerBookTickerSymbolStatus CancelOnly { get; } = new("CANCEL_ONLY");

    static TickerBookTickerSymbolStatus IExtensibleValue<TickerBookTickerSymbolStatus>.Create(string value) => new(value);

    public static bool operator ==(TickerBookTickerSymbolStatus left, TickerBookTickerSymbolStatus right) => left.Equals(right);

    public static bool operator !=(TickerBookTickerSymbolStatus left, TickerBookTickerSymbolStatus right) => !left.Equals(right);

    public static implicit operator TickerBookTickerSymbolStatus(string value) => new(value);

    public static TickerBookTickerSymbolStatus FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TickerBookTickerSymbolStatus other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(TickerBookTickerSymbolStatus other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class TickerBookTickerRequest
{
    /// <summary>
    /// Parameter symbol and symbols cannot be used in combination. If neither parameter is sent,
    /// bookTickers for all symbols will be returned in an array.
    /// </summary>
    public string? Symbol { get; init; }

    /// <summary>
    /// Parameter symbol and symbols cannot be used in combination. If neither parameter is sent,
    /// bookTickers for all symbols will be returned in an array. Examples of accepted format for the
    /// symbols parameter: ["BTCUSDT","BNBUSDT"] or %5B%22BTCUSDT%22,%22BNBUSDT%22%5D
    /// </summary>
    public List<string>? Symbols { get; init; }

    /// <summary>
    /// Filters for symbols that have this tradingStatus. For a single symbol, a status mismatch returns
    /// error -1220 SYMBOL_DOES_NOT_MATCH_STATUS. For multiple or all symbols, non-matching ones are simply
    /// excluded from the response.
    /// </summary>
    public TickerBookTickerSymbolStatus? SymbolStatus { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<TickerPriceSymbolStatus>))]
public readonly struct TickerPriceSymbolStatus : IExtensibleValue<TickerPriceSymbolStatus>, IEquatable<TickerPriceSymbolStatus>
{
    private readonly string? _value;

    public TickerPriceSymbolStatus(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static TickerPriceSymbolStatus Trading { get; } = new("TRADING");

    public static TickerPriceSymbolStatus Halt { get; } = new("HALT");

    public static TickerPriceSymbolStatus Break { get; } = new("BREAK");

    public static TickerPriceSymbolStatus CancelOnly { get; } = new("CANCEL_ONLY");

    static TickerPriceSymbolStatus IExtensibleValue<TickerPriceSymbolStatus>.Create(string value) => new(value);

    public static bool operator ==(TickerPriceSymbolStatus left, TickerPriceSymbolStatus right) => left.Equals(right);

    public static bool operator !=(TickerPriceSymbolStatus left, TickerPriceSymbolStatus right) => !left.Equals(right);

    public static implicit operator TickerPriceSymbolStatus(string value) => new(value);

    public static TickerPriceSymbolStatus FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TickerPriceSymbolStatus other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(TickerPriceSymbolStatus other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class TickerPriceRequest
{
    /// <summary>
    /// Parameter symbol and symbols cannot be used in combination. If neither parameter is sent, prices for
    /// all symbols will be returned in an array.
    /// </summary>
    public string? Symbol { get; init; }

    /// <summary>
    /// Parameter symbol and symbols cannot be used in combination. If neither parameter is sent, prices for
    /// all symbols will be returned in an array. Examples of accepted format for the symbols parameter:
    /// ["BTCUSDT","BNBUSDT"] or %5B%22BTCUSDT%22,%22BNBUSDT%22%5D
    /// </summary>
    public List<string>? Symbols { get; init; }

    /// <summary>
    /// Filters for symbols that have this tradingStatus. For a single symbol, a status mismatch returns
    /// error -1220 SYMBOL_DOES_NOT_MATCH_STATUS. For multiple or all symbols, non-matching ones are simply
    /// excluded from the response.
    /// </summary>
    public TickerPriceSymbolStatus? SymbolStatus { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<TickerTradingDayType>))]
public readonly struct TickerTradingDayType : IExtensibleValue<TickerTradingDayType>, IEquatable<TickerTradingDayType>
{
    private readonly string? _value;

    public TickerTradingDayType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static TickerTradingDayType Full { get; } = new("FULL");

    public static TickerTradingDayType Mini { get; } = new("MINI");

    static TickerTradingDayType IExtensibleValue<TickerTradingDayType>.Create(string value) => new(value);

    public static bool operator ==(TickerTradingDayType left, TickerTradingDayType right) => left.Equals(right);

    public static bool operator !=(TickerTradingDayType left, TickerTradingDayType right) => !left.Equals(right);

    public static implicit operator TickerTradingDayType(string value) => new(value);

    public static TickerTradingDayType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TickerTradingDayType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(TickerTradingDayType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<TickerTradingDaySymbolStatus>))]
public readonly struct TickerTradingDaySymbolStatus : IExtensibleValue<TickerTradingDaySymbolStatus>, IEquatable<TickerTradingDaySymbolStatus>
{
    private readonly string? _value;

    public TickerTradingDaySymbolStatus(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static TickerTradingDaySymbolStatus Trading { get; } = new("TRADING");

    public static TickerTradingDaySymbolStatus Halt { get; } = new("HALT");

    public static TickerTradingDaySymbolStatus Break { get; } = new("BREAK");

    public static TickerTradingDaySymbolStatus CancelOnly { get; } = new("CANCEL_ONLY");

    static TickerTradingDaySymbolStatus IExtensibleValue<TickerTradingDaySymbolStatus>.Create(string value) => new(value);

    public static bool operator ==(TickerTradingDaySymbolStatus left, TickerTradingDaySymbolStatus right) => left.Equals(right);

    public static bool operator !=(TickerTradingDaySymbolStatus left, TickerTradingDaySymbolStatus right) => !left.Equals(right);

    public static implicit operator TickerTradingDaySymbolStatus(string value) => new(value);

    public static TickerTradingDaySymbolStatus FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TickerTradingDaySymbolStatus other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(TickerTradingDaySymbolStatus other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class TickerTradingDayRequest
{
    /// <summary>Either symbol or symbols must be provided.</summary>
    public string? Symbol { get; init; }

    /// <summary>
    /// Either symbol or symbols must be provided. Examples of accepted format for the symbols parameter:
    /// ["BTCUSDT","BNBUSDT"] or %5B%22BTCUSDT%22,%22BNBUSDT%22%5D. The maximum number of symbols allowed in
    /// a request is 100.
    /// </summary>
    public List<string>? Symbols { get; init; }

    /// <summary>Default: 0 (UTC)</summary>
    public string? TimeZone { get; init; }

    public TickerTradingDayType? Type { get; init; }

    /// <summary>
    /// Filters for symbols that have this tradingStatus. For a single symbol, a status mismatch returns
    /// error -1220 SYMBOL_DOES_NOT_MATCH_STATUS. For multiple symbols, non-matching ones are simply
    /// excluded from the response.
    /// </summary>
    public TickerTradingDaySymbolStatus? SymbolStatus { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<UiKlinesInterval>))]
public readonly struct UiKlinesInterval : IExtensibleValue<UiKlinesInterval>, IEquatable<UiKlinesInterval>
{
    private readonly string? _value;

    public UiKlinesInterval(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static UiKlinesInterval Interval1s { get; } = new("1s");

    public static UiKlinesInterval Interval1m { get; } = new("1m");

    public static UiKlinesInterval Interval3m { get; } = new("3m");

    public static UiKlinesInterval Interval5m { get; } = new("5m");

    public static UiKlinesInterval Interval15m { get; } = new("15m");

    public static UiKlinesInterval Interval30m { get; } = new("30m");

    public static UiKlinesInterval Interval1h { get; } = new("1h");

    public static UiKlinesInterval Interval2h { get; } = new("2h");

    public static UiKlinesInterval Interval4h { get; } = new("4h");

    public static UiKlinesInterval Interval6h { get; } = new("6h");

    public static UiKlinesInterval Interval8h { get; } = new("8h");

    public static UiKlinesInterval Interval12h { get; } = new("12h");

    public static UiKlinesInterval Interval1d { get; } = new("1d");

    public static UiKlinesInterval Interval3d { get; } = new("3d");

    public static UiKlinesInterval Interval1w { get; } = new("1w");

    public static UiKlinesInterval Interval1Month { get; } = new("1M");

    static UiKlinesInterval IExtensibleValue<UiKlinesInterval>.Create(string value) => new(value);

    public static bool operator ==(UiKlinesInterval left, UiKlinesInterval right) => left.Equals(right);

    public static bool operator !=(UiKlinesInterval left, UiKlinesInterval right) => !left.Equals(right);

    public static implicit operator UiKlinesInterval(string value) => new(value);

    public static UiKlinesInterval FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is UiKlinesInterval other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(UiKlinesInterval other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class UiKlinesRequest
{
    public required string Symbol { get; init; }

    public required UiKlinesInterval Interval { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Default: 0 (UTC)</summary>
    public string? TimeZone { get; init; }

    public long? Limit { get; init; }
}

public sealed partial class SpotRestApi
{

    /// <summary>Compressed/Aggregate trades list</summary>
    /// <remarks>
    /// <para>
    /// Get compressed, aggregate trades. Trades that fill at the time, from the same taker order, with the
    /// same price will have the quantity aggregated.
    /// </para>
    /// <para>Weight(IP): 4</para>
    /// <para>Security Type: NONE</para>
    /// <para>Notes: Data Source: Database</para>
    /// <para>- If fromId, startTime, and endTime are not sent, the most recent aggregate trades will be returned.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<AggTradesResponseInner>>> AggTradesAsync(AggTradesRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/aggTrades", signed: false, hasTimeUnit: true);
        if (request is null) return Task.FromException<RestApiResponse<List<AggTradesResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("fromId", request.FromId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        return _client.SendAsync(r, SpotRestApiJson.Default.ListAggTradesResponseInner, cancellationToken);
    }

    /// <summary>Current average price</summary>
    /// <remarks>
    /// <para>Current average price for a symbol.</para>
    /// <para>Weight(IP): 2</para>
    /// <para>Security Type: NONE</para>
    /// <para>Notes: Data Source: Memory</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<AvgPriceResponse>> AvgPriceAsync(AvgPriceRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/avgPrice", signed: false, hasTimeUnit: true);
        if (request is null) return Task.FromException<RestApiResponse<AvgPriceResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        return _client.SendAsync(r, SpotRestApiJson.Default.AvgPriceResponse, cancellationToken);
    }

    /// <summary>Order book</summary>
    /// <remarks>
    /// <para>Weight: Adjusted based on the limit:</para>
    /// <para>|Limit|Request Weight</para>
    /// <para>1-100| 5 101-500| 25 501-1000| 50 1001-5000| 250 5001-7500| 500</para>
    /// <para>Security Type: NONE</para>
    /// <para>Notes: Data Source: Memory</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<DepthResponse>> DepthAsync(DepthRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/depth", signed: false, hasTimeUnit: true);
        if (request is null) return Task.FromException<RestApiResponse<DepthResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("limit", request.Limit);
        r.Query("symbolStatus", request.SymbolStatus);
        return _client.SendAsync(r, SpotRestApiJson.Default.DepthResponse, cancellationToken);
    }

    /// <summary>Recent trades list</summary>
    /// <remarks>
    /// <para>Get recent trades.</para>
    /// <para>Weight(IP): 25</para>
    /// <para>Security Type: NONE</para>
    /// <para>Notes: Data Source: Memory</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<GetTradesResponseInner>>> GetTradesAsync(GetTradesRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/trades", signed: false, hasTimeUnit: true);
        if (request is null) return Task.FromException<RestApiResponse<List<GetTradesResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("limit", request.Limit);
        return _client.SendAsync(r, SpotRestApiJson.Default.ListGetTradesResponseInner, cancellationToken);
    }

    /// <summary>Historical Block Trades (MARKET_DATA)</summary>
    /// <remarks>
    /// <para>Get block trades.</para>
    /// <para>Weight(IP): 25</para>
    /// <para>Security Type: MARKET_DATA</para>
    /// <para>Notes: Data Source: Database</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<HistoricalBlockTradesResponseInner>>> HistoricalBlockTradesAsync(HistoricalBlockTradesRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/historicalBlockTrades", signed: false, hasTimeUnit: true);
        if (request is null) return Task.FromException<RestApiResponse<List<HistoricalBlockTradesResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("fromId", request.FromId);
        r.Query("limit", request.Limit);
        return _client.SendAsync(r, SpotRestApiJson.Default.ListHistoricalBlockTradesResponseInner, cancellationToken);
    }

    /// <summary>Old trade lookup</summary>
    /// <remarks>
    /// <para>Get older trades.</para>
    /// <para>Weight(IP): 25</para>
    /// <para>Security Type: NONE</para>
    /// <para>Notes: Data Source: Database</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<GetTradesResponseInner>>> HistoricalTradesAsync(HistoricalTradesRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/historicalTrades", signed: false, hasTimeUnit: true);
        if (request is null) return Task.FromException<RestApiResponse<List<GetTradesResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("limit", request.Limit);
        r.Query("fromId", request.FromId);
        return _client.SendAsync(r, SpotRestApiJson.Default.ListGetTradesResponseInner, cancellationToken);
    }

    /// <summary>Kline/Candlestick data</summary>
    /// <remarks>
    /// <para>Kline/candlestick bars for a symbol. Klines are uniquely identified by their open time.</para>
    /// <para>Weight(IP): 2</para>
    /// <para>Security Type: NONE</para>
    /// <para>Notes: Data Source: Database</para>
    /// <para>Supported kline intervals (case-sensitive):</para>
    /// <para>Interval | interval value</para>
    /// <para>seconds | 1s</para>
    /// <para>minutes | 1m, 3m, 5m, 15m, 30m</para>
    /// <para>hours | 1h, 2h, 4h, 6h, 8h, 12h</para>
    /// <para>days | 1d, 3d</para>
    /// <para>weeks | 1w</para>
    /// <para>months | 1M</para>
    /// <para>Notes:</para>
    /// <para>- If startTime and endTime are not sent, the most recent klines are returned.</para>
    /// <para>- Supported values for timeZone:</para>
    /// <para>- Hours and minutes (e.g. -1:00, 05:45)</para>
    /// <para>- Only hours (e.g. 0, 8, 4)</para>
    /// <para>- Accepted range is strictly [-12:00 to +14:00] inclusive</para>
    /// <para>- If timeZone provided, kline intervals are interpreted in that timezone instead of UTC.</para>
    /// <para>- Note that startTime and endTime are always interpreted in UTC, regardless of timeZone.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<List<KlinesItemInner>>>> KlinesAsync(KlinesRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/klines", signed: false, hasTimeUnit: true);
        if (request is null) return Task.FromException<RestApiResponse<List<List<KlinesItemInner>>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("interval", request.Interval);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("timeZone", request.TimeZone);
        r.Query("limit", request.Limit);
        return _client.SendAsync(r, SpotRestApiJson.Default.ListListKlinesItemInner, cancellationToken);
    }

    /// <summary>Query Reference Price</summary>
    /// <remarks>
    /// <para>Query the reference price for a symbol.</para>
    /// <para>Weight(IP): 2</para>
    /// <para>Security Type: NONE</para>
    /// <para>Notes: Data Source: Memory</para>
    /// <para>If the symbol has never had a reference price set, the request is rejected with:</para>
    /// <para>{ "code": -2043, "msg": "This symbol doesn't have a reference price." }</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ReferencePriceResponse>> ReferencePriceAsync(ReferencePriceRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/referencePrice", signed: false, hasTimeUnit: true);
        if (request is null) return Task.FromException<RestApiResponse<ReferencePriceResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        return _client.SendAsync(r, SpotRestApiJson.Default.ReferencePriceResponse, cancellationToken);
    }

    /// <summary>Query Reference Price Calculation</summary>
    /// <remarks>
    /// <para>Describes how reference price is calculated for a given symbol.</para>
    /// <para>Weight(IP): 2</para>
    /// <para>Security Type: NONE</para>
    /// <para>Notes: Data Source: Memory</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ReferencePriceCalculationResponse>> ReferencePriceCalculationAsync(ReferencePriceCalculationRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/referencePrice/calculation", signed: false, hasTimeUnit: true);
        if (request is null) return Task.FromException<RestApiResponse<ReferencePriceCalculationResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("symbolStatus", request.SymbolStatus);
        return _client.SendAsync(r, SpotRestApiJson.Default.ReferencePriceCalculationResponse, cancellationToken);
    }

    /// <summary>Rolling window price change statistics</summary>
    /// <remarks>
    /// <para>Note: This endpoint differs from GET /api/v3/ticker/24hr.</para>
    /// <para>
    /// The statistical time range of this endpoint can be up to 59999ms longer than the requested
    /// windowSize.
    /// </para>
    /// <para>
    /// openTime starts at the beginning of a minute, while the end time is the current time. Therefore, the
    /// actual interval can be up to 59999ms longer than the requested window.
    /// </para>
    /// <para>
    /// For example, if closeTime is 1641287867099 (January 04, 2022 09:17:47:099 UTC) and windowSize is 1d,
    /// then openTime is 1641201420000 (January 3, 2022, 09:17:00 UTC).
    /// </para>
    /// <para>Weight: 4 for each requested symbol regardless of windowSize.</para>
    /// <para>
    /// The weight for this request will cap at 200 once the number of symbols in the request is more than
    /// 50.
    /// </para>
    /// <para>Security Type: NONE</para>
    /// <para>Notes: Data Source: Database</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<TickerResponse>> TickerAsync(TickerRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/ticker", signed: false, hasTimeUnit: true);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("symbols", request.Symbols);
        r.Query("windowSize", request.WindowSize);
        r.Query("type", request.Type);
        r.Query("symbolStatus", request.SymbolStatus);
        return _client.SendAsync(r, SpotRestApiJson.Default.TickerResponse, cancellationToken);
    }

    /// <summary>24hr ticker price change statistics</summary>
    /// <remarks>
    /// <para>24 hour rolling window price change statistics. Careful when accessing this with no symbol.</para>
    /// <para>Weight:</para>
    /// <para>- Parameter | Symbols Provided | Weight</para>
    /// <para>- symbol | 1 | 2</para>
    /// <para>- symbol parameter is omitted | 80</para>
    /// <para>- symbols | 1-20 | 2</para>
    /// <para>- 21-100 | 40</para>
    /// <para>- 101 or more | 80</para>
    /// <para>- symbols parameter is omitted | 80</para>
    /// <para>Security Type: NONE</para>
    /// <para>Notes: Data Source: Memory</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<Ticker24hrResponse>> Ticker24hrAsync(Ticker24hrRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/ticker/24hr", signed: false, hasTimeUnit: true);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("symbols", request.Symbols);
        r.Query("type", request.Type);
        r.Query("symbolStatus", request.SymbolStatus);
        return _client.SendAsync(r, SpotRestApiJson.Default.Ticker24hrResponse, cancellationToken);
    }

    /// <summary>Symbol order book ticker</summary>
    /// <remarks>
    /// <para>Best price/qty on the order book for a symbol or symbols.</para>
    /// <para>Weight: |Parameter|Symbols Provided|Weight|</para>
    /// <para>|symbol| 1 |2| | |omitted| 4| |symbols| Any |4|</para>
    /// <para>Security Type: NONE</para>
    /// <para>Notes: Data Source: Memory</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<TickerBookTickerResponse>> TickerBookTickerAsync(TickerBookTickerRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/ticker/bookTicker", signed: false, hasTimeUnit: true);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("symbols", request.Symbols);
        r.Query("symbolStatus", request.SymbolStatus);
        return _client.SendAsync(r, SpotRestApiJson.Default.TickerBookTickerResponse, cancellationToken);
    }

    /// <summary>Symbol price ticker</summary>
    /// <remarks>
    /// <para>Latest price for a symbol or symbols.</para>
    /// <para>Weight: |Parameter|Symbols Provided|Weight|</para>
    /// <para>|symbol| 1 |2| | |omitted| 4| |symbols| Any |4|</para>
    /// <para>Security Type: NONE</para>
    /// <para>Notes: Data Source: Memory</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<TickerPriceResponse>> TickerPriceAsync(TickerPriceRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/ticker/price", signed: false, hasTimeUnit: true);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("symbols", request.Symbols);
        r.Query("symbolStatus", request.SymbolStatus);
        return _client.SendAsync(r, SpotRestApiJson.Default.TickerPriceResponse, cancellationToken);
    }

    /// <summary>Trading Day Ticker</summary>
    /// <remarks>
    /// <para>Price change statistics for a trading day.</para>
    /// <para>
    /// Weight: 4 for each requested symbol. The weight for this request will cap at 200 once the number of
    /// symbols in the request is more than 50.
    /// </para>
    /// <para>Security Type: NONE</para>
    /// <para>Notes: Data Source: Database</para>
    /// <para>Notes::</para>
    /// <para>- Supported values for timeZone:</para>
    /// <para>- Hours and minutes (e.g. -1:00, 05:45)</para>
    /// <para>- Only hours (e.g. 0, 8, 4)</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<TickerTradingDayResponse>> TickerTradingDayAsync(TickerTradingDayRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/ticker/tradingDay", signed: false, hasTimeUnit: true);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("symbols", request.Symbols);
        r.Query("timeZone", request.TimeZone);
        r.Query("type", request.Type);
        r.Query("symbolStatus", request.SymbolStatus);
        return _client.SendAsync(r, SpotRestApiJson.Default.TickerTradingDayResponse, cancellationToken);
    }

    /// <summary>UIKlines</summary>
    /// <remarks>
    /// <para>The request is similar to klines having the same parameters and response.</para>
    /// <para>uiKlines return modified kline data, optimized for presentation of candlestick charts.</para>
    /// <para>Weight(IP): 2</para>
    /// <para>Security Type: NONE</para>
    /// <para>Notes: Data Source: Database</para>
    /// <para>- If startTime and endTime are not sent, the most recent klines are returned.</para>
    /// <para>- Supported values for timeZone:</para>
    /// <para>- Hours and minutes (e.g. -1:00, 05:45)</para>
    /// <para>- Only hours (e.g. 0, 8, 4)</para>
    /// <para>- Accepted range is strictly [-12:00 to +14:00] inclusive</para>
    /// <para>- If timeZone provided, kline intervals are interpreted in that timezone instead of UTC.</para>
    /// <para>- Note that startTime and endTime are always interpreted in UTC, regardless of timeZone.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<List<KlinesItemInner>>>> UiKlinesAsync(UiKlinesRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/uiKlines", signed: false, hasTimeUnit: true);
        if (request is null) return Task.FromException<RestApiResponse<List<List<KlinesItemInner>>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("interval", request.Interval);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("timeZone", request.TimeZone);
        r.Query("limit", request.Limit);
        return _client.SendAsync(r, SpotRestApiJson.Default.ListListKlinesItemInner, cancellationToken);
    }
}
