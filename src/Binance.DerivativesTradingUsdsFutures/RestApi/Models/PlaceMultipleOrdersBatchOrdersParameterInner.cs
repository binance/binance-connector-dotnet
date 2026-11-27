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

namespace Binance.DerivativesTradingUsdsFutures.RestApi;

public sealed class PlaceMultipleOrdersBatchOrdersParameterInner
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("side")]
    public PlaceMultipleOrdersBatchOrdersParameterInnerSide? Side { get; set; }

    /// <summary>Default BOTH for One-way Mode; LONG or SHORT for Hedge Mode.</summary>
    [JsonPropertyName("positionSide")]
    public PlaceMultipleOrdersBatchOrdersParameterInnerPositionSide? PositionSide { get; set; }

    [JsonPropertyName("type")]
    public PlaceMultipleOrdersBatchOrdersParameterInnerType? Type { get; set; }

    [JsonPropertyName("timeInForce")]
    public PlaceMultipleOrdersBatchOrdersParameterInnerTimeInForce? TimeInForce { get; set; }

    [JsonPropertyName("quantity")]
    public decimal? Quantity { get; set; }

    [JsonPropertyName("reduceOnly")]
    public PlaceMultipleOrdersBatchOrdersParameterInnerReduceOnly? ReduceOnly { get; set; }

    [JsonPropertyName("price")]
    public decimal? Price { get; set; }

    [JsonPropertyName("newClientOrderId")]
    public string? NewClientOrderId { get; set; }

    [JsonPropertyName("newOrderRespType")]
    public PlaceMultipleOrdersBatchOrdersParameterInnerNewOrderRespType? NewOrderRespType { get; set; }

    /// <summary>
    /// only avaliable for LIMIT/STOP/TAKE_PROFIT order; Can't be passed together with price
    /// </summary>
    [JsonPropertyName("priceMatch")]
    public PlaceMultipleOrdersBatchOrdersParameterInnerPriceMatch? PriceMatch { get; set; }

    /// <summary>
    /// EXPIRE_TAKER: expire taker order when STP triggers/ EXPIRE_MAKER: expire taker order when STP
    /// triggers/ EXPIRE_BOTH: expire both orders when STP triggers; default NONE
    /// </summary>
    [JsonPropertyName("selfTradePreventionMode")]
    public PlaceMultipleOrdersBatchOrdersParameterInnerSelfTradePreventionMode? SelfTradePreventionMode { get; set; }

    /// <summary>Auto-cancel time for GTD orders.</summary>
    [JsonPropertyName("goodTillDate")]
    public long? GoodTillDate { get; set; }
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

    public static PlaceMultipleOrdersBatchOrdersParameterInnerTimeInForce Gtd { get; } = new("GTD");

    public static PlaceMultipleOrdersBatchOrdersParameterInnerTimeInForce Rpi { get; } = new("RPI");

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

    public static PlaceMultipleOrdersBatchOrdersParameterInnerSelfTradePreventionMode None { get; } = new("NONE");

    public static PlaceMultipleOrdersBatchOrdersParameterInnerSelfTradePreventionMode ExpireTaker { get; } = new("EXPIRE_TAKER");

    public static PlaceMultipleOrdersBatchOrdersParameterInnerSelfTradePreventionMode ExpireBoth { get; } = new("EXPIRE_BOTH");

    public static PlaceMultipleOrdersBatchOrdersParameterInnerSelfTradePreventionMode ExpireMaker { get; } = new("EXPIRE_MAKER");

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
