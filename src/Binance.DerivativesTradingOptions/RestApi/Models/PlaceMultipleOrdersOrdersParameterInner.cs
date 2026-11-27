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

namespace Binance.DerivativesTradingOptions.RestApi;

public sealed class PlaceMultipleOrdersOrdersParameterInner
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("side")]
    public PlaceMultipleOrdersOrdersParameterInnerSide? Side { get; set; }

    [JsonPropertyName("type")]
    public PlaceMultipleOrdersOrdersParameterInnerType? Type { get; set; }

    /// <summary>Order Quantity</summary>
    [JsonPropertyName("quantity")]
    public decimal? Quantity { get; set; }

    /// <summary>Order Price</summary>
    [JsonPropertyName("price")]
    public decimal? Price { get; set; }

    [JsonPropertyName("timeInForce")]
    public PlaceMultipleOrdersOrdersParameterInnerTimeInForce? TimeInForce { get; set; }

    [JsonPropertyName("reduceOnly")]
    public bool? ReduceOnly { get; set; }

    [JsonPropertyName("postOnly")]
    public bool? PostOnly { get; set; }

    [JsonPropertyName("newOrderRespType")]
    public PlaceMultipleOrdersOrdersParameterInnerNewOrderRespType? NewOrderRespType { get; set; }

    /// <summary>User-defined order ID cannot be repeated in pending orders</summary>
    [JsonPropertyName("clientOrderId")]
    public string? ClientOrderId { get; set; }

    /// <summary>is market maker protection order</summary>
    [JsonPropertyName("isMmp")]
    public bool? IsMmp { get; set; }

    /// <summary>
    /// EXPIRE_TAKER: expire taker order when STP triggers/ EXPIRE_MAKER: expire maker order when STP
    /// triggers/ EXPIRE_BOTH: expire both orders when STP triggers; Default EXPIRE_MAKER
    /// </summary>
    [JsonPropertyName("selfTradePreventionMode")]
    public PlaceMultipleOrdersOrdersParameterInnerSelfTradePreventionMode? SelfTradePreventionMode { get; set; }
}

[JsonConverter(typeof(ExtensibleValueConverter<PlaceMultipleOrdersOrdersParameterInnerSide>))]
public readonly struct PlaceMultipleOrdersOrdersParameterInnerSide : IExtensibleValue<PlaceMultipleOrdersOrdersParameterInnerSide>, IEquatable<PlaceMultipleOrdersOrdersParameterInnerSide>
{
    private readonly string? _value;

    public PlaceMultipleOrdersOrdersParameterInnerSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PlaceMultipleOrdersOrdersParameterInnerSide Buy { get; } = new("BUY");

    public static PlaceMultipleOrdersOrdersParameterInnerSide Sell { get; } = new("SELL");

    static PlaceMultipleOrdersOrdersParameterInnerSide IExtensibleValue<PlaceMultipleOrdersOrdersParameterInnerSide>.Create(string value) => new(value);

    public static bool operator ==(PlaceMultipleOrdersOrdersParameterInnerSide left, PlaceMultipleOrdersOrdersParameterInnerSide right) => left.Equals(right);

    public static bool operator !=(PlaceMultipleOrdersOrdersParameterInnerSide left, PlaceMultipleOrdersOrdersParameterInnerSide right) => !left.Equals(right);

    public static implicit operator PlaceMultipleOrdersOrdersParameterInnerSide(string value) => new(value);

    public static PlaceMultipleOrdersOrdersParameterInnerSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PlaceMultipleOrdersOrdersParameterInnerSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PlaceMultipleOrdersOrdersParameterInnerSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<PlaceMultipleOrdersOrdersParameterInnerType>))]
public readonly struct PlaceMultipleOrdersOrdersParameterInnerType : IExtensibleValue<PlaceMultipleOrdersOrdersParameterInnerType>, IEquatable<PlaceMultipleOrdersOrdersParameterInnerType>
{
    private readonly string? _value;

    public PlaceMultipleOrdersOrdersParameterInnerType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PlaceMultipleOrdersOrdersParameterInnerType Limit { get; } = new("LIMIT");

    static PlaceMultipleOrdersOrdersParameterInnerType IExtensibleValue<PlaceMultipleOrdersOrdersParameterInnerType>.Create(string value) => new(value);

    public static bool operator ==(PlaceMultipleOrdersOrdersParameterInnerType left, PlaceMultipleOrdersOrdersParameterInnerType right) => left.Equals(right);

    public static bool operator !=(PlaceMultipleOrdersOrdersParameterInnerType left, PlaceMultipleOrdersOrdersParameterInnerType right) => !left.Equals(right);

    public static implicit operator PlaceMultipleOrdersOrdersParameterInnerType(string value) => new(value);

    public static PlaceMultipleOrdersOrdersParameterInnerType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PlaceMultipleOrdersOrdersParameterInnerType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PlaceMultipleOrdersOrdersParameterInnerType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<PlaceMultipleOrdersOrdersParameterInnerTimeInForce>))]
public readonly struct PlaceMultipleOrdersOrdersParameterInnerTimeInForce : IExtensibleValue<PlaceMultipleOrdersOrdersParameterInnerTimeInForce>, IEquatable<PlaceMultipleOrdersOrdersParameterInnerTimeInForce>
{
    private readonly string? _value;

    public PlaceMultipleOrdersOrdersParameterInnerTimeInForce(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PlaceMultipleOrdersOrdersParameterInnerTimeInForce Gtc { get; } = new("GTC");

    public static PlaceMultipleOrdersOrdersParameterInnerTimeInForce Ioc { get; } = new("IOC");

    public static PlaceMultipleOrdersOrdersParameterInnerTimeInForce Fok { get; } = new("FOK");

    public static PlaceMultipleOrdersOrdersParameterInnerTimeInForce Gtx { get; } = new("GTX");

    static PlaceMultipleOrdersOrdersParameterInnerTimeInForce IExtensibleValue<PlaceMultipleOrdersOrdersParameterInnerTimeInForce>.Create(string value) => new(value);

    public static bool operator ==(PlaceMultipleOrdersOrdersParameterInnerTimeInForce left, PlaceMultipleOrdersOrdersParameterInnerTimeInForce right) => left.Equals(right);

    public static bool operator !=(PlaceMultipleOrdersOrdersParameterInnerTimeInForce left, PlaceMultipleOrdersOrdersParameterInnerTimeInForce right) => !left.Equals(right);

    public static implicit operator PlaceMultipleOrdersOrdersParameterInnerTimeInForce(string value) => new(value);

    public static PlaceMultipleOrdersOrdersParameterInnerTimeInForce FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PlaceMultipleOrdersOrdersParameterInnerTimeInForce other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PlaceMultipleOrdersOrdersParameterInnerTimeInForce other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<PlaceMultipleOrdersOrdersParameterInnerNewOrderRespType>))]
public readonly struct PlaceMultipleOrdersOrdersParameterInnerNewOrderRespType : IExtensibleValue<PlaceMultipleOrdersOrdersParameterInnerNewOrderRespType>, IEquatable<PlaceMultipleOrdersOrdersParameterInnerNewOrderRespType>
{
    private readonly string? _value;

    public PlaceMultipleOrdersOrdersParameterInnerNewOrderRespType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PlaceMultipleOrdersOrdersParameterInnerNewOrderRespType Ack { get; } = new("ACK");

    public static PlaceMultipleOrdersOrdersParameterInnerNewOrderRespType Result { get; } = new("RESULT");

    static PlaceMultipleOrdersOrdersParameterInnerNewOrderRespType IExtensibleValue<PlaceMultipleOrdersOrdersParameterInnerNewOrderRespType>.Create(string value) => new(value);

    public static bool operator ==(PlaceMultipleOrdersOrdersParameterInnerNewOrderRespType left, PlaceMultipleOrdersOrdersParameterInnerNewOrderRespType right) => left.Equals(right);

    public static bool operator !=(PlaceMultipleOrdersOrdersParameterInnerNewOrderRespType left, PlaceMultipleOrdersOrdersParameterInnerNewOrderRespType right) => !left.Equals(right);

    public static implicit operator PlaceMultipleOrdersOrdersParameterInnerNewOrderRespType(string value) => new(value);

    public static PlaceMultipleOrdersOrdersParameterInnerNewOrderRespType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PlaceMultipleOrdersOrdersParameterInnerNewOrderRespType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PlaceMultipleOrdersOrdersParameterInnerNewOrderRespType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<PlaceMultipleOrdersOrdersParameterInnerSelfTradePreventionMode>))]
public readonly struct PlaceMultipleOrdersOrdersParameterInnerSelfTradePreventionMode : IExtensibleValue<PlaceMultipleOrdersOrdersParameterInnerSelfTradePreventionMode>, IEquatable<PlaceMultipleOrdersOrdersParameterInnerSelfTradePreventionMode>
{
    private readonly string? _value;

    public PlaceMultipleOrdersOrdersParameterInnerSelfTradePreventionMode(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PlaceMultipleOrdersOrdersParameterInnerSelfTradePreventionMode ExpireTaker { get; } = new("EXPIRE_TAKER");

    public static PlaceMultipleOrdersOrdersParameterInnerSelfTradePreventionMode ExpireMaker { get; } = new("EXPIRE_MAKER");

    public static PlaceMultipleOrdersOrdersParameterInnerSelfTradePreventionMode ExpireBoth { get; } = new("EXPIRE_BOTH");

    static PlaceMultipleOrdersOrdersParameterInnerSelfTradePreventionMode IExtensibleValue<PlaceMultipleOrdersOrdersParameterInnerSelfTradePreventionMode>.Create(string value) => new(value);

    public static bool operator ==(PlaceMultipleOrdersOrdersParameterInnerSelfTradePreventionMode left, PlaceMultipleOrdersOrdersParameterInnerSelfTradePreventionMode right) => left.Equals(right);

    public static bool operator !=(PlaceMultipleOrdersOrdersParameterInnerSelfTradePreventionMode left, PlaceMultipleOrdersOrdersParameterInnerSelfTradePreventionMode right) => !left.Equals(right);

    public static implicit operator PlaceMultipleOrdersOrdersParameterInnerSelfTradePreventionMode(string value) => new(value);

    public static PlaceMultipleOrdersOrdersParameterInnerSelfTradePreventionMode FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PlaceMultipleOrdersOrdersParameterInnerSelfTradePreventionMode other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PlaceMultipleOrdersOrdersParameterInnerSelfTradePreventionMode other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}
