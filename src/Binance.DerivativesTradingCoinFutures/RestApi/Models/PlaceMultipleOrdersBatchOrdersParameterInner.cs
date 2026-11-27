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

public sealed class PlaceMultipleOrdersBatchOrdersParameterInner
{
    /// <summary>Symbol</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("side")]
    public PlaceMultipleOrdersBatchOrdersParameterInnerSide? Side { get; set; }

    /// <summary>
    /// After CM migration, stop-type values (STOP, STOP_MARKET, TAKE_PROFIT, TAKE_PROFIT_MARKET,
    /// TRAILING_STOP_MARKET) are no longer accepted on a per-element basis and will return element-level
    /// -4120. Use the new /dapi/v1/algoOrder endpoint instead.
    /// </summary>
    [JsonPropertyName("type")]
    public PlaceMultipleOrdersBatchOrdersParameterInnerType? Type { get; set; }

    /// <summary>quantity measured by contract number</summary>
    [JsonPropertyName("quantity")]
    public decimal? Quantity { get; set; }

    /// <summary>
    /// Default BOTH for One-way Mode ; LONG or SHORT for Hedge Mode. It must be sent with Hedge Mode.
    /// </summary>
    [JsonPropertyName("positionSide")]
    public PlaceMultipleOrdersBatchOrdersParameterInnerPositionSide? PositionSide { get; set; }

    [JsonPropertyName("timeInForce")]
    public PlaceMultipleOrdersBatchOrdersParameterInnerTimeInForce? TimeInForce { get; set; }

    [JsonPropertyName("reduceOnly")]
    public PlaceMultipleOrdersBatchOrdersParameterInnerReduceOnly? ReduceOnly { get; set; }

    /// <summary>Order price</summary>
    [JsonPropertyName("price")]
    public decimal? Price { get; set; }

    /// <summary>
    /// A unique id among open orders. Automatically generated if not sent. Can only be string following the
    /// rule: ^[.A-Z\:/a-z0-9_-]{1,36}$
    /// </summary>
    [JsonPropertyName("newClientOrderId")]
    public string? NewClientOrderId { get; set; }

    /// <summary>Used with STOP/STOP_MARKET or TAKE_PROFIT/TAKE_PROFIT_MARKET orders.</summary>
    [JsonPropertyName("stopPrice")]
    public decimal? StopPrice { get; set; }

    /// <summary>
    /// Used with TRAILING_STOP_MARKET orders, default as the latest price(supporting different workingType)
    /// </summary>
    [JsonPropertyName("activationPrice")]
    public decimal? ActivationPrice { get; set; }

    /// <summary>Used with TRAILING_STOP_MARKET orders, min 0.1, max 4 where 1 for 1%</summary>
    [JsonPropertyName("callbackRate")]
    public decimal? CallbackRate { get; set; }

    [JsonPropertyName("workingType")]
    public PlaceMultipleOrdersBatchOrdersParameterInnerWorkingType? WorkingType { get; set; }

    /// <summary>Used with STOP/STOP_MARKET or TAKE_PROFIT/TAKE_PROFIT_MARKET orders.</summary>
    [JsonPropertyName("priceProtect")]
    public PlaceMultipleOrdersBatchOrdersParameterInnerPriceProtect? PriceProtect { get; set; }

    [JsonPropertyName("newOrderRespType")]
    public PlaceMultipleOrdersBatchOrdersParameterInnerNewOrderRespType? NewOrderRespType { get; set; }

    /// <summary>
    /// only avaliable for LIMIT/STOP/TAKE_PROFIT order; can't be passed together with price
    /// </summary>
    [JsonPropertyName("priceMatch")]
    public PlaceMultipleOrdersBatchOrdersParameterInnerPriceMatch? PriceMatch { get; set; }

    /// <summary>
    /// EXPIRE_TAKER: expire taker order when STP triggers/ EXPIRE_MAKER: expire taker order when STP
    /// triggers/ EXPIRE_BOTH: expire both orders when STP triggers
    /// </summary>
    [JsonPropertyName("selfTradePreventionMode")]
    public PlaceMultipleOrdersBatchOrdersParameterInnerSelfTradePreventionMode? SelfTradePreventionMode { get; set; }
}

[JsonConverter(typeof(ExtensibleValueConverter<PlaceMultipleOrdersBatchOrdersParameterInnerSide>))]
public readonly struct PlaceMultipleOrdersBatchOrdersParameterInnerSide : IExtensibleValue<PlaceMultipleOrdersBatchOrdersParameterInnerSide>, IEquatable<PlaceMultipleOrdersBatchOrdersParameterInnerSide>
{
    private readonly string? _value;

    public PlaceMultipleOrdersBatchOrdersParameterInnerSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PlaceMultipleOrdersBatchOrdersParameterInnerSide Buy { get; } = new("BUY");

    public static PlaceMultipleOrdersBatchOrdersParameterInnerSide Sell { get; } = new("SELL");

    static PlaceMultipleOrdersBatchOrdersParameterInnerSide IExtensibleValue<PlaceMultipleOrdersBatchOrdersParameterInnerSide>.Create(string value) => new(value);

    public static bool operator ==(PlaceMultipleOrdersBatchOrdersParameterInnerSide left, PlaceMultipleOrdersBatchOrdersParameterInnerSide right) => left.Equals(right);

    public static bool operator !=(PlaceMultipleOrdersBatchOrdersParameterInnerSide left, PlaceMultipleOrdersBatchOrdersParameterInnerSide right) => !left.Equals(right);

    public static implicit operator PlaceMultipleOrdersBatchOrdersParameterInnerSide(string value) => new(value);

    public static PlaceMultipleOrdersBatchOrdersParameterInnerSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PlaceMultipleOrdersBatchOrdersParameterInnerSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PlaceMultipleOrdersBatchOrdersParameterInnerSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<PlaceMultipleOrdersBatchOrdersParameterInnerType>))]
public readonly struct PlaceMultipleOrdersBatchOrdersParameterInnerType : IExtensibleValue<PlaceMultipleOrdersBatchOrdersParameterInnerType>, IEquatable<PlaceMultipleOrdersBatchOrdersParameterInnerType>
{
    private readonly string? _value;

    public PlaceMultipleOrdersBatchOrdersParameterInnerType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PlaceMultipleOrdersBatchOrdersParameterInnerType Limit { get; } = new("LIMIT");

    public static PlaceMultipleOrdersBatchOrdersParameterInnerType Market { get; } = new("MARKET");

    public static PlaceMultipleOrdersBatchOrdersParameterInnerType Stop { get; } = new("STOP");

    public static PlaceMultipleOrdersBatchOrdersParameterInnerType StopMarket { get; } = new("STOP_MARKET");

    public static PlaceMultipleOrdersBatchOrdersParameterInnerType TakeProfit { get; } = new("TAKE_PROFIT");

    public static PlaceMultipleOrdersBatchOrdersParameterInnerType TakeProfitMarket { get; } = new("TAKE_PROFIT_MARKET");

    public static PlaceMultipleOrdersBatchOrdersParameterInnerType TrailingStopMarket { get; } = new("TRAILING_STOP_MARKET");

    static PlaceMultipleOrdersBatchOrdersParameterInnerType IExtensibleValue<PlaceMultipleOrdersBatchOrdersParameterInnerType>.Create(string value) => new(value);

    public static bool operator ==(PlaceMultipleOrdersBatchOrdersParameterInnerType left, PlaceMultipleOrdersBatchOrdersParameterInnerType right) => left.Equals(right);

    public static bool operator !=(PlaceMultipleOrdersBatchOrdersParameterInnerType left, PlaceMultipleOrdersBatchOrdersParameterInnerType right) => !left.Equals(right);

    public static implicit operator PlaceMultipleOrdersBatchOrdersParameterInnerType(string value) => new(value);

    public static PlaceMultipleOrdersBatchOrdersParameterInnerType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PlaceMultipleOrdersBatchOrdersParameterInnerType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PlaceMultipleOrdersBatchOrdersParameterInnerType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<PlaceMultipleOrdersBatchOrdersParameterInnerPositionSide>))]
public readonly struct PlaceMultipleOrdersBatchOrdersParameterInnerPositionSide : IExtensibleValue<PlaceMultipleOrdersBatchOrdersParameterInnerPositionSide>, IEquatable<PlaceMultipleOrdersBatchOrdersParameterInnerPositionSide>
{
    private readonly string? _value;

    public PlaceMultipleOrdersBatchOrdersParameterInnerPositionSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PlaceMultipleOrdersBatchOrdersParameterInnerPositionSide Both { get; } = new("BOTH");

    public static PlaceMultipleOrdersBatchOrdersParameterInnerPositionSide Long { get; } = new("LONG");

    public static PlaceMultipleOrdersBatchOrdersParameterInnerPositionSide Short { get; } = new("SHORT");

    static PlaceMultipleOrdersBatchOrdersParameterInnerPositionSide IExtensibleValue<PlaceMultipleOrdersBatchOrdersParameterInnerPositionSide>.Create(string value) => new(value);

    public static bool operator ==(PlaceMultipleOrdersBatchOrdersParameterInnerPositionSide left, PlaceMultipleOrdersBatchOrdersParameterInnerPositionSide right) => left.Equals(right);

    public static bool operator !=(PlaceMultipleOrdersBatchOrdersParameterInnerPositionSide left, PlaceMultipleOrdersBatchOrdersParameterInnerPositionSide right) => !left.Equals(right);

    public static implicit operator PlaceMultipleOrdersBatchOrdersParameterInnerPositionSide(string value) => new(value);

    public static PlaceMultipleOrdersBatchOrdersParameterInnerPositionSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PlaceMultipleOrdersBatchOrdersParameterInnerPositionSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PlaceMultipleOrdersBatchOrdersParameterInnerPositionSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<PlaceMultipleOrdersBatchOrdersParameterInnerTimeInForce>))]
public readonly struct PlaceMultipleOrdersBatchOrdersParameterInnerTimeInForce : IExtensibleValue<PlaceMultipleOrdersBatchOrdersParameterInnerTimeInForce>, IEquatable<PlaceMultipleOrdersBatchOrdersParameterInnerTimeInForce>
{
    private readonly string? _value;

    public PlaceMultipleOrdersBatchOrdersParameterInnerTimeInForce(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PlaceMultipleOrdersBatchOrdersParameterInnerTimeInForce Gtc { get; } = new("GTC");

    public static PlaceMultipleOrdersBatchOrdersParameterInnerTimeInForce Ioc { get; } = new("IOC");

    public static PlaceMultipleOrdersBatchOrdersParameterInnerTimeInForce Fok { get; } = new("FOK");

    public static PlaceMultipleOrdersBatchOrdersParameterInnerTimeInForce Gtx { get; } = new("GTX");

    static PlaceMultipleOrdersBatchOrdersParameterInnerTimeInForce IExtensibleValue<PlaceMultipleOrdersBatchOrdersParameterInnerTimeInForce>.Create(string value) => new(value);

    public static bool operator ==(PlaceMultipleOrdersBatchOrdersParameterInnerTimeInForce left, PlaceMultipleOrdersBatchOrdersParameterInnerTimeInForce right) => left.Equals(right);

    public static bool operator !=(PlaceMultipleOrdersBatchOrdersParameterInnerTimeInForce left, PlaceMultipleOrdersBatchOrdersParameterInnerTimeInForce right) => !left.Equals(right);

    public static implicit operator PlaceMultipleOrdersBatchOrdersParameterInnerTimeInForce(string value) => new(value);

    public static PlaceMultipleOrdersBatchOrdersParameterInnerTimeInForce FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PlaceMultipleOrdersBatchOrdersParameterInnerTimeInForce other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PlaceMultipleOrdersBatchOrdersParameterInnerTimeInForce other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<PlaceMultipleOrdersBatchOrdersParameterInnerReduceOnly>))]
public readonly struct PlaceMultipleOrdersBatchOrdersParameterInnerReduceOnly : IExtensibleValue<PlaceMultipleOrdersBatchOrdersParameterInnerReduceOnly>, IEquatable<PlaceMultipleOrdersBatchOrdersParameterInnerReduceOnly>
{
    private readonly string? _value;

    public PlaceMultipleOrdersBatchOrdersParameterInnerReduceOnly(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PlaceMultipleOrdersBatchOrdersParameterInnerReduceOnly True { get; } = new("true");

    public static PlaceMultipleOrdersBatchOrdersParameterInnerReduceOnly False { get; } = new("false");

    static PlaceMultipleOrdersBatchOrdersParameterInnerReduceOnly IExtensibleValue<PlaceMultipleOrdersBatchOrdersParameterInnerReduceOnly>.Create(string value) => new(value);

    public static bool operator ==(PlaceMultipleOrdersBatchOrdersParameterInnerReduceOnly left, PlaceMultipleOrdersBatchOrdersParameterInnerReduceOnly right) => left.Equals(right);

    public static bool operator !=(PlaceMultipleOrdersBatchOrdersParameterInnerReduceOnly left, PlaceMultipleOrdersBatchOrdersParameterInnerReduceOnly right) => !left.Equals(right);

    public static implicit operator PlaceMultipleOrdersBatchOrdersParameterInnerReduceOnly(string value) => new(value);

    public static PlaceMultipleOrdersBatchOrdersParameterInnerReduceOnly FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PlaceMultipleOrdersBatchOrdersParameterInnerReduceOnly other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PlaceMultipleOrdersBatchOrdersParameterInnerReduceOnly other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<PlaceMultipleOrdersBatchOrdersParameterInnerWorkingType>))]
public readonly struct PlaceMultipleOrdersBatchOrdersParameterInnerWorkingType : IExtensibleValue<PlaceMultipleOrdersBatchOrdersParameterInnerWorkingType>, IEquatable<PlaceMultipleOrdersBatchOrdersParameterInnerWorkingType>
{
    private readonly string? _value;

    public PlaceMultipleOrdersBatchOrdersParameterInnerWorkingType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PlaceMultipleOrdersBatchOrdersParameterInnerWorkingType MarkPrice { get; } = new("MARK_PRICE");

    public static PlaceMultipleOrdersBatchOrdersParameterInnerWorkingType ContractPrice { get; } = new("CONTRACT_PRICE");

    static PlaceMultipleOrdersBatchOrdersParameterInnerWorkingType IExtensibleValue<PlaceMultipleOrdersBatchOrdersParameterInnerWorkingType>.Create(string value) => new(value);

    public static bool operator ==(PlaceMultipleOrdersBatchOrdersParameterInnerWorkingType left, PlaceMultipleOrdersBatchOrdersParameterInnerWorkingType right) => left.Equals(right);

    public static bool operator !=(PlaceMultipleOrdersBatchOrdersParameterInnerWorkingType left, PlaceMultipleOrdersBatchOrdersParameterInnerWorkingType right) => !left.Equals(right);

    public static implicit operator PlaceMultipleOrdersBatchOrdersParameterInnerWorkingType(string value) => new(value);

    public static PlaceMultipleOrdersBatchOrdersParameterInnerWorkingType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PlaceMultipleOrdersBatchOrdersParameterInnerWorkingType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PlaceMultipleOrdersBatchOrdersParameterInnerWorkingType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<PlaceMultipleOrdersBatchOrdersParameterInnerPriceProtect>))]
public readonly struct PlaceMultipleOrdersBatchOrdersParameterInnerPriceProtect : IExtensibleValue<PlaceMultipleOrdersBatchOrdersParameterInnerPriceProtect>, IEquatable<PlaceMultipleOrdersBatchOrdersParameterInnerPriceProtect>
{
    private readonly string? _value;

    public PlaceMultipleOrdersBatchOrdersParameterInnerPriceProtect(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PlaceMultipleOrdersBatchOrdersParameterInnerPriceProtect True { get; } = new("true");

    public static PlaceMultipleOrdersBatchOrdersParameterInnerPriceProtect False { get; } = new("false");

    static PlaceMultipleOrdersBatchOrdersParameterInnerPriceProtect IExtensibleValue<PlaceMultipleOrdersBatchOrdersParameterInnerPriceProtect>.Create(string value) => new(value);

    public static bool operator ==(PlaceMultipleOrdersBatchOrdersParameterInnerPriceProtect left, PlaceMultipleOrdersBatchOrdersParameterInnerPriceProtect right) => left.Equals(right);

    public static bool operator !=(PlaceMultipleOrdersBatchOrdersParameterInnerPriceProtect left, PlaceMultipleOrdersBatchOrdersParameterInnerPriceProtect right) => !left.Equals(right);

    public static implicit operator PlaceMultipleOrdersBatchOrdersParameterInnerPriceProtect(string value) => new(value);

    public static PlaceMultipleOrdersBatchOrdersParameterInnerPriceProtect FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PlaceMultipleOrdersBatchOrdersParameterInnerPriceProtect other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PlaceMultipleOrdersBatchOrdersParameterInnerPriceProtect other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<PlaceMultipleOrdersBatchOrdersParameterInnerNewOrderRespType>))]
public readonly struct PlaceMultipleOrdersBatchOrdersParameterInnerNewOrderRespType : IExtensibleValue<PlaceMultipleOrdersBatchOrdersParameterInnerNewOrderRespType>, IEquatable<PlaceMultipleOrdersBatchOrdersParameterInnerNewOrderRespType>
{
    private readonly string? _value;

    public PlaceMultipleOrdersBatchOrdersParameterInnerNewOrderRespType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PlaceMultipleOrdersBatchOrdersParameterInnerNewOrderRespType Ack { get; } = new("ACK");

    public static PlaceMultipleOrdersBatchOrdersParameterInnerNewOrderRespType Result { get; } = new("RESULT");

    static PlaceMultipleOrdersBatchOrdersParameterInnerNewOrderRespType IExtensibleValue<PlaceMultipleOrdersBatchOrdersParameterInnerNewOrderRespType>.Create(string value) => new(value);

    public static bool operator ==(PlaceMultipleOrdersBatchOrdersParameterInnerNewOrderRespType left, PlaceMultipleOrdersBatchOrdersParameterInnerNewOrderRespType right) => left.Equals(right);

    public static bool operator !=(PlaceMultipleOrdersBatchOrdersParameterInnerNewOrderRespType left, PlaceMultipleOrdersBatchOrdersParameterInnerNewOrderRespType right) => !left.Equals(right);

    public static implicit operator PlaceMultipleOrdersBatchOrdersParameterInnerNewOrderRespType(string value) => new(value);

    public static PlaceMultipleOrdersBatchOrdersParameterInnerNewOrderRespType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PlaceMultipleOrdersBatchOrdersParameterInnerNewOrderRespType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PlaceMultipleOrdersBatchOrdersParameterInnerNewOrderRespType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<PlaceMultipleOrdersBatchOrdersParameterInnerPriceMatch>))]
public readonly struct PlaceMultipleOrdersBatchOrdersParameterInnerPriceMatch : IExtensibleValue<PlaceMultipleOrdersBatchOrdersParameterInnerPriceMatch>, IEquatable<PlaceMultipleOrdersBatchOrdersParameterInnerPriceMatch>
{
    private readonly string? _value;

    public PlaceMultipleOrdersBatchOrdersParameterInnerPriceMatch(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PlaceMultipleOrdersBatchOrdersParameterInnerPriceMatch Opponent { get; } = new("OPPONENT");

    public static PlaceMultipleOrdersBatchOrdersParameterInnerPriceMatch Opponent5 { get; } = new("OPPONENT_5");

    public static PlaceMultipleOrdersBatchOrdersParameterInnerPriceMatch Opponent10 { get; } = new("OPPONENT_10");

    public static PlaceMultipleOrdersBatchOrdersParameterInnerPriceMatch Opponent20 { get; } = new("OPPONENT_20");

    public static PlaceMultipleOrdersBatchOrdersParameterInnerPriceMatch Queue { get; } = new("QUEUE");

    public static PlaceMultipleOrdersBatchOrdersParameterInnerPriceMatch Queue5 { get; } = new("QUEUE_5");

    public static PlaceMultipleOrdersBatchOrdersParameterInnerPriceMatch Queue10 { get; } = new("QUEUE_10");

    public static PlaceMultipleOrdersBatchOrdersParameterInnerPriceMatch Queue20 { get; } = new("QUEUE_20");

    static PlaceMultipleOrdersBatchOrdersParameterInnerPriceMatch IExtensibleValue<PlaceMultipleOrdersBatchOrdersParameterInnerPriceMatch>.Create(string value) => new(value);

    public static bool operator ==(PlaceMultipleOrdersBatchOrdersParameterInnerPriceMatch left, PlaceMultipleOrdersBatchOrdersParameterInnerPriceMatch right) => left.Equals(right);

    public static bool operator !=(PlaceMultipleOrdersBatchOrdersParameterInnerPriceMatch left, PlaceMultipleOrdersBatchOrdersParameterInnerPriceMatch right) => !left.Equals(right);

    public static implicit operator PlaceMultipleOrdersBatchOrdersParameterInnerPriceMatch(string value) => new(value);

    public static PlaceMultipleOrdersBatchOrdersParameterInnerPriceMatch FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PlaceMultipleOrdersBatchOrdersParameterInnerPriceMatch other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PlaceMultipleOrdersBatchOrdersParameterInnerPriceMatch other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<PlaceMultipleOrdersBatchOrdersParameterInnerSelfTradePreventionMode>))]
public readonly struct PlaceMultipleOrdersBatchOrdersParameterInnerSelfTradePreventionMode : IExtensibleValue<PlaceMultipleOrdersBatchOrdersParameterInnerSelfTradePreventionMode>, IEquatable<PlaceMultipleOrdersBatchOrdersParameterInnerSelfTradePreventionMode>
{
    private readonly string? _value;

    public PlaceMultipleOrdersBatchOrdersParameterInnerSelfTradePreventionMode(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PlaceMultipleOrdersBatchOrdersParameterInnerSelfTradePreventionMode ExpireTaker { get; } = new("EXPIRE_TAKER");

    public static PlaceMultipleOrdersBatchOrdersParameterInnerSelfTradePreventionMode ExpireMaker { get; } = new("EXPIRE_MAKER");

    public static PlaceMultipleOrdersBatchOrdersParameterInnerSelfTradePreventionMode ExpireBoth { get; } = new("EXPIRE_BOTH");

    static PlaceMultipleOrdersBatchOrdersParameterInnerSelfTradePreventionMode IExtensibleValue<PlaceMultipleOrdersBatchOrdersParameterInnerSelfTradePreventionMode>.Create(string value) => new(value);

    public static bool operator ==(PlaceMultipleOrdersBatchOrdersParameterInnerSelfTradePreventionMode left, PlaceMultipleOrdersBatchOrdersParameterInnerSelfTradePreventionMode right) => left.Equals(right);

    public static bool operator !=(PlaceMultipleOrdersBatchOrdersParameterInnerSelfTradePreventionMode left, PlaceMultipleOrdersBatchOrdersParameterInnerSelfTradePreventionMode right) => !left.Equals(right);

    public static implicit operator PlaceMultipleOrdersBatchOrdersParameterInnerSelfTradePreventionMode(string value) => new(value);

    public static PlaceMultipleOrdersBatchOrdersParameterInnerSelfTradePreventionMode FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PlaceMultipleOrdersBatchOrdersParameterInnerSelfTradePreventionMode other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PlaceMultipleOrdersBatchOrdersParameterInnerSelfTradePreventionMode other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}
