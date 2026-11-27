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

namespace Binance.DerivativesTradingCoinFutures.WebSocketApi;

public sealed class CancelAlgoOrderRequest
{
    /// <summary>Id.</summary>
    public string? Id { get; init; }

    /// <summary>Algo Id.</summary>
    public long? AlgoId { get; init; }

    /// <summary>Client Algo Id.</summary>
    public string? ClientAlgoId { get; init; }

    /// <summary>Recv Window.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class CancelOrderRequest
{
    public required string Symbol { get; init; }

    public string? Id { get; init; }

    public long? OrderId { get; init; }

    public string? OrigClientOrderId { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<ModifyOrderSide>))]
public readonly struct ModifyOrderSide : IExtensibleValue<ModifyOrderSide>, IEquatable<ModifyOrderSide>
{
    private readonly string? _value;

    public ModifyOrderSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static ModifyOrderSide Buy { get; } = new("BUY");

    public static ModifyOrderSide Sell { get; } = new("SELL");

    static ModifyOrderSide IExtensibleValue<ModifyOrderSide>.Create(string value) => new(value);

    public static bool operator ==(ModifyOrderSide left, ModifyOrderSide right) => left.Equals(right);

    public static bool operator !=(ModifyOrderSide left, ModifyOrderSide right) => !left.Equals(right);

    public static implicit operator ModifyOrderSide(string value) => new(value);

    public static ModifyOrderSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ModifyOrderSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ModifyOrderSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<ModifyOrderPriceMatch>))]
public readonly struct ModifyOrderPriceMatch : IExtensibleValue<ModifyOrderPriceMatch>, IEquatable<ModifyOrderPriceMatch>
{
    private readonly string? _value;

    public ModifyOrderPriceMatch(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static ModifyOrderPriceMatch Opponent { get; } = new("OPPONENT");

    public static ModifyOrderPriceMatch Opponent5 { get; } = new("OPPONENT_5");

    public static ModifyOrderPriceMatch Opponent10 { get; } = new("OPPONENT_10");

    public static ModifyOrderPriceMatch Opponent20 { get; } = new("OPPONENT_20");

    public static ModifyOrderPriceMatch Queue { get; } = new("QUEUE");

    public static ModifyOrderPriceMatch Queue5 { get; } = new("QUEUE_5");

    public static ModifyOrderPriceMatch Queue10 { get; } = new("QUEUE_10");

    public static ModifyOrderPriceMatch Queue20 { get; } = new("QUEUE_20");

    static ModifyOrderPriceMatch IExtensibleValue<ModifyOrderPriceMatch>.Create(string value) => new(value);

    public static bool operator ==(ModifyOrderPriceMatch left, ModifyOrderPriceMatch right) => left.Equals(right);

    public static bool operator !=(ModifyOrderPriceMatch left, ModifyOrderPriceMatch right) => !left.Equals(right);

    public static implicit operator ModifyOrderPriceMatch(string value) => new(value);

    public static ModifyOrderPriceMatch FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ModifyOrderPriceMatch other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ModifyOrderPriceMatch other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class ModifyOrderRequest
{
    public required string Symbol { get; init; }

    public required ModifyOrderSide Side { get; init; }

    /// <summary>Order quantity, cannot be sent with closePosition=true</summary>
    public required decimal Quantity { get; init; }

    public required decimal Price { get; init; }

    public string? Id { get; init; }

    public long? OrderId { get; init; }

    public string? OrigClientOrderId { get; init; }

    /// <summary>
    /// only avaliable for LIMIT/STOP/TAKE_PROFIT order; Can't be passed together with price
    /// </summary>
    public ModifyOrderPriceMatch? PriceMatch { get; init; }

    /// <summary>
    /// User-defined modification identifier, returned as-is in the response. Optional; not validated for
    /// uniqueness.
    /// </summary>
    public long? ModifyId { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<NewAlgoOrderAlgoType>))]
public readonly struct NewAlgoOrderAlgoType : IExtensibleValue<NewAlgoOrderAlgoType>, IEquatable<NewAlgoOrderAlgoType>
{
    private readonly string? _value;

    public NewAlgoOrderAlgoType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewAlgoOrderAlgoType Conditional { get; } = new("CONDITIONAL");

    static NewAlgoOrderAlgoType IExtensibleValue<NewAlgoOrderAlgoType>.Create(string value) => new(value);

    public static bool operator ==(NewAlgoOrderAlgoType left, NewAlgoOrderAlgoType right) => left.Equals(right);

    public static bool operator !=(NewAlgoOrderAlgoType left, NewAlgoOrderAlgoType right) => !left.Equals(right);

    public static implicit operator NewAlgoOrderAlgoType(string value) => new(value);

    public static NewAlgoOrderAlgoType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewAlgoOrderAlgoType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewAlgoOrderAlgoType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewAlgoOrderSide>))]
public readonly struct NewAlgoOrderSide : IExtensibleValue<NewAlgoOrderSide>, IEquatable<NewAlgoOrderSide>
{
    private readonly string? _value;

    public NewAlgoOrderSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewAlgoOrderSide Buy { get; } = new("BUY");

    public static NewAlgoOrderSide Sell { get; } = new("SELL");

    static NewAlgoOrderSide IExtensibleValue<NewAlgoOrderSide>.Create(string value) => new(value);

    public static bool operator ==(NewAlgoOrderSide left, NewAlgoOrderSide right) => left.Equals(right);

    public static bool operator !=(NewAlgoOrderSide left, NewAlgoOrderSide right) => !left.Equals(right);

    public static implicit operator NewAlgoOrderSide(string value) => new(value);

    public static NewAlgoOrderSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewAlgoOrderSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewAlgoOrderSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewAlgoOrderType>))]
public readonly struct NewAlgoOrderType : IExtensibleValue<NewAlgoOrderType>, IEquatable<NewAlgoOrderType>
{
    private readonly string? _value;

    public NewAlgoOrderType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewAlgoOrderType StopMarket { get; } = new("STOP_MARKET");

    public static NewAlgoOrderType TakeProfitMarket { get; } = new("TAKE_PROFIT_MARKET");

    public static NewAlgoOrderType Stop { get; } = new("STOP");

    public static NewAlgoOrderType TakeProfit { get; } = new("TAKE_PROFIT");

    public static NewAlgoOrderType TrailingStopMarket { get; } = new("TRAILING_STOP_MARKET");

    static NewAlgoOrderType IExtensibleValue<NewAlgoOrderType>.Create(string value) => new(value);

    public static bool operator ==(NewAlgoOrderType left, NewAlgoOrderType right) => left.Equals(right);

    public static bool operator !=(NewAlgoOrderType left, NewAlgoOrderType right) => !left.Equals(right);

    public static implicit operator NewAlgoOrderType(string value) => new(value);

    public static NewAlgoOrderType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewAlgoOrderType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewAlgoOrderType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewAlgoOrderPositionSide>))]
public readonly struct NewAlgoOrderPositionSide : IExtensibleValue<NewAlgoOrderPositionSide>, IEquatable<NewAlgoOrderPositionSide>
{
    private readonly string? _value;

    public NewAlgoOrderPositionSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewAlgoOrderPositionSide Both { get; } = new("BOTH");

    public static NewAlgoOrderPositionSide Long { get; } = new("LONG");

    public static NewAlgoOrderPositionSide Short { get; } = new("SHORT");

    static NewAlgoOrderPositionSide IExtensibleValue<NewAlgoOrderPositionSide>.Create(string value) => new(value);

    public static bool operator ==(NewAlgoOrderPositionSide left, NewAlgoOrderPositionSide right) => left.Equals(right);

    public static bool operator !=(NewAlgoOrderPositionSide left, NewAlgoOrderPositionSide right) => !left.Equals(right);

    public static implicit operator NewAlgoOrderPositionSide(string value) => new(value);

    public static NewAlgoOrderPositionSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewAlgoOrderPositionSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewAlgoOrderPositionSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewAlgoOrderTimeInForce>))]
public readonly struct NewAlgoOrderTimeInForce : IExtensibleValue<NewAlgoOrderTimeInForce>, IEquatable<NewAlgoOrderTimeInForce>
{
    private readonly string? _value;

    public NewAlgoOrderTimeInForce(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewAlgoOrderTimeInForce Ioc { get; } = new("IOC");

    public static NewAlgoOrderTimeInForce Gtc { get; } = new("GTC");

    public static NewAlgoOrderTimeInForce Fok { get; } = new("FOK");

    public static NewAlgoOrderTimeInForce Gtx { get; } = new("GTX");

    static NewAlgoOrderTimeInForce IExtensibleValue<NewAlgoOrderTimeInForce>.Create(string value) => new(value);

    public static bool operator ==(NewAlgoOrderTimeInForce left, NewAlgoOrderTimeInForce right) => left.Equals(right);

    public static bool operator !=(NewAlgoOrderTimeInForce left, NewAlgoOrderTimeInForce right) => !left.Equals(right);

    public static implicit operator NewAlgoOrderTimeInForce(string value) => new(value);

    public static NewAlgoOrderTimeInForce FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewAlgoOrderTimeInForce other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewAlgoOrderTimeInForce other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewAlgoOrderWorkingType>))]
public readonly struct NewAlgoOrderWorkingType : IExtensibleValue<NewAlgoOrderWorkingType>, IEquatable<NewAlgoOrderWorkingType>
{
    private readonly string? _value;

    public NewAlgoOrderWorkingType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewAlgoOrderWorkingType MarkPrice { get; } = new("MARK_PRICE");

    public static NewAlgoOrderWorkingType ContractPrice { get; } = new("CONTRACT_PRICE");

    static NewAlgoOrderWorkingType IExtensibleValue<NewAlgoOrderWorkingType>.Create(string value) => new(value);

    public static bool operator ==(NewAlgoOrderWorkingType left, NewAlgoOrderWorkingType right) => left.Equals(right);

    public static bool operator !=(NewAlgoOrderWorkingType left, NewAlgoOrderWorkingType right) => !left.Equals(right);

    public static implicit operator NewAlgoOrderWorkingType(string value) => new(value);

    public static NewAlgoOrderWorkingType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewAlgoOrderWorkingType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewAlgoOrderWorkingType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewAlgoOrderPriceMatch>))]
public readonly struct NewAlgoOrderPriceMatch : IExtensibleValue<NewAlgoOrderPriceMatch>, IEquatable<NewAlgoOrderPriceMatch>
{
    private readonly string? _value;

    public NewAlgoOrderPriceMatch(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewAlgoOrderPriceMatch Opponent { get; } = new("OPPONENT");

    public static NewAlgoOrderPriceMatch Opponent5 { get; } = new("OPPONENT_5");

    public static NewAlgoOrderPriceMatch Opponent10 { get; } = new("OPPONENT_10");

    public static NewAlgoOrderPriceMatch Opponent20 { get; } = new("OPPONENT_20");

    public static NewAlgoOrderPriceMatch Queue { get; } = new("QUEUE");

    public static NewAlgoOrderPriceMatch Queue5 { get; } = new("QUEUE_5");

    public static NewAlgoOrderPriceMatch Queue10 { get; } = new("QUEUE_10");

    public static NewAlgoOrderPriceMatch Queue20 { get; } = new("QUEUE_20");

    static NewAlgoOrderPriceMatch IExtensibleValue<NewAlgoOrderPriceMatch>.Create(string value) => new(value);

    public static bool operator ==(NewAlgoOrderPriceMatch left, NewAlgoOrderPriceMatch right) => left.Equals(right);

    public static bool operator !=(NewAlgoOrderPriceMatch left, NewAlgoOrderPriceMatch right) => !left.Equals(right);

    public static implicit operator NewAlgoOrderPriceMatch(string value) => new(value);

    public static NewAlgoOrderPriceMatch FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewAlgoOrderPriceMatch other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewAlgoOrderPriceMatch other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewAlgoOrderClosePosition>))]
public readonly struct NewAlgoOrderClosePosition : IExtensibleValue<NewAlgoOrderClosePosition>, IEquatable<NewAlgoOrderClosePosition>
{
    private readonly string? _value;

    public NewAlgoOrderClosePosition(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewAlgoOrderClosePosition True { get; } = new("true");

    public static NewAlgoOrderClosePosition False { get; } = new("false");

    static NewAlgoOrderClosePosition IExtensibleValue<NewAlgoOrderClosePosition>.Create(string value) => new(value);

    public static bool operator ==(NewAlgoOrderClosePosition left, NewAlgoOrderClosePosition right) => left.Equals(right);

    public static bool operator !=(NewAlgoOrderClosePosition left, NewAlgoOrderClosePosition right) => !left.Equals(right);

    public static implicit operator NewAlgoOrderClosePosition(string value) => new(value);

    public static NewAlgoOrderClosePosition FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewAlgoOrderClosePosition other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewAlgoOrderClosePosition other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewAlgoOrderPriceProtect>))]
public readonly struct NewAlgoOrderPriceProtect : IExtensibleValue<NewAlgoOrderPriceProtect>, IEquatable<NewAlgoOrderPriceProtect>
{
    private readonly string? _value;

    public NewAlgoOrderPriceProtect(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewAlgoOrderPriceProtect True { get; } = new("true");

    public static NewAlgoOrderPriceProtect False { get; } = new("false");

    static NewAlgoOrderPriceProtect IExtensibleValue<NewAlgoOrderPriceProtect>.Create(string value) => new(value);

    public static bool operator ==(NewAlgoOrderPriceProtect left, NewAlgoOrderPriceProtect right) => left.Equals(right);

    public static bool operator !=(NewAlgoOrderPriceProtect left, NewAlgoOrderPriceProtect right) => !left.Equals(right);

    public static implicit operator NewAlgoOrderPriceProtect(string value) => new(value);

    public static NewAlgoOrderPriceProtect FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewAlgoOrderPriceProtect other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewAlgoOrderPriceProtect other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewAlgoOrderReduceOnly>))]
public readonly struct NewAlgoOrderReduceOnly : IExtensibleValue<NewAlgoOrderReduceOnly>, IEquatable<NewAlgoOrderReduceOnly>
{
    private readonly string? _value;

    public NewAlgoOrderReduceOnly(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewAlgoOrderReduceOnly True { get; } = new("true");

    public static NewAlgoOrderReduceOnly False { get; } = new("false");

    static NewAlgoOrderReduceOnly IExtensibleValue<NewAlgoOrderReduceOnly>.Create(string value) => new(value);

    public static bool operator ==(NewAlgoOrderReduceOnly left, NewAlgoOrderReduceOnly right) => left.Equals(right);

    public static bool operator !=(NewAlgoOrderReduceOnly left, NewAlgoOrderReduceOnly right) => !left.Equals(right);

    public static implicit operator NewAlgoOrderReduceOnly(string value) => new(value);

    public static NewAlgoOrderReduceOnly FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewAlgoOrderReduceOnly other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewAlgoOrderReduceOnly other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewAlgoOrderNewOrderRespType>))]
public readonly struct NewAlgoOrderNewOrderRespType : IExtensibleValue<NewAlgoOrderNewOrderRespType>, IEquatable<NewAlgoOrderNewOrderRespType>
{
    private readonly string? _value;

    public NewAlgoOrderNewOrderRespType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewAlgoOrderNewOrderRespType Ack { get; } = new("ACK");

    public static NewAlgoOrderNewOrderRespType Result { get; } = new("RESULT");

    static NewAlgoOrderNewOrderRespType IExtensibleValue<NewAlgoOrderNewOrderRespType>.Create(string value) => new(value);

    public static bool operator ==(NewAlgoOrderNewOrderRespType left, NewAlgoOrderNewOrderRespType right) => left.Equals(right);

    public static bool operator !=(NewAlgoOrderNewOrderRespType left, NewAlgoOrderNewOrderRespType right) => !left.Equals(right);

    public static implicit operator NewAlgoOrderNewOrderRespType(string value) => new(value);

    public static NewAlgoOrderNewOrderRespType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewAlgoOrderNewOrderRespType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewAlgoOrderNewOrderRespType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewAlgoOrderSelfTradePreventionMode>))]
public readonly struct NewAlgoOrderSelfTradePreventionMode : IExtensibleValue<NewAlgoOrderSelfTradePreventionMode>, IEquatable<NewAlgoOrderSelfTradePreventionMode>
{
    private readonly string? _value;

    public NewAlgoOrderSelfTradePreventionMode(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewAlgoOrderSelfTradePreventionMode None { get; } = new("NONE");

    public static NewAlgoOrderSelfTradePreventionMode ExpireTaker { get; } = new("EXPIRE_TAKER");

    public static NewAlgoOrderSelfTradePreventionMode ExpireBoth { get; } = new("EXPIRE_BOTH");

    public static NewAlgoOrderSelfTradePreventionMode ExpireMaker { get; } = new("EXPIRE_MAKER");

    static NewAlgoOrderSelfTradePreventionMode IExtensibleValue<NewAlgoOrderSelfTradePreventionMode>.Create(string value) => new(value);

    public static bool operator ==(NewAlgoOrderSelfTradePreventionMode left, NewAlgoOrderSelfTradePreventionMode right) => left.Equals(right);

    public static bool operator !=(NewAlgoOrderSelfTradePreventionMode left, NewAlgoOrderSelfTradePreventionMode right) => !left.Equals(right);

    public static implicit operator NewAlgoOrderSelfTradePreventionMode(string value) => new(value);

    public static NewAlgoOrderSelfTradePreventionMode FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewAlgoOrderSelfTradePreventionMode other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewAlgoOrderSelfTradePreventionMode other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class NewAlgoOrderRequest
{
    /// <summary>Only support CONDITIONAL</summary>
    public required NewAlgoOrderAlgoType AlgoType { get; init; }

    /// <summary>Symbol.</summary>
    public required string Symbol { get; init; }

    /// <summary>Side.</summary>
    public required NewAlgoOrderSide Side { get; init; }

    /// <summary>
    /// For CONDITIONAL algoType, STOP_MARKET/TAKE_PROFIT_MARKET/STOP/TAKE_PROFIT/TRAILING_STOP_MARKET as
    /// order type
    /// </summary>
    public required NewAlgoOrderType Type { get; init; }

    /// <summary>Id.</summary>
    public string? Id { get; init; }

    /// <summary>
    /// Default BOTH for One-way Mode ; LONG or SHORT for Hedge Mode. It must be sent in Hedge Mode.
    /// </summary>
    public NewAlgoOrderPositionSide? PositionSide { get; init; }

    /// <summary>IOC or GTC or FOK or GTX, default GTC</summary>
    public NewAlgoOrderTimeInForce? TimeInForce { get; init; }

    /// <summary>
    /// quantity measured by contract number, Cannot be sent with closePosition=true(Close-All)
    /// </summary>
    public decimal? Quantity { get; init; }

    /// <summary>Price.</summary>
    public decimal? Price { get; init; }

    /// <summary>Trigger Price.</summary>
    public decimal? TriggerPrice { get; init; }

    /// <summary>triggerPrice triggered by: MARK_PRICE, CONTRACT_PRICE. Default CONTRACT_PRICE</summary>
    public NewAlgoOrderWorkingType? WorkingType { get; init; }

    /// <summary>
    /// only available for LIMIT/STOP/TAKE_PROFIT order; Can't be passed together with price
    /// </summary>
    public NewAlgoOrderPriceMatch? PriceMatch { get; init; }

    /// <summary>Close-All，used with STOP_MARKET or TAKE_PROFIT_MARKET.</summary>
    public NewAlgoOrderClosePosition? ClosePosition { get; init; }

    /// <summary>
    /// Used with STOP_MARKET or TAKE_PROFIT_MARKET order. when price reaches the triggerPrice ，the
    /// difference rate between "MARK_PRICE" and "CONTRACT_PRICE" cannot be larger than the Price Protection
    /// Threshold of the symbol.
    /// </summary>
    public NewAlgoOrderPriceProtect? PriceProtect { get; init; }

    /// <summary>Cannot be sent in Hedge Mode; cannot be sent with closePosition=true</summary>
    public NewAlgoOrderReduceOnly? ReduceOnly { get; init; }

    /// <summary>
    /// Used with TRAILING_STOP_MARKET orders, default as the latest price(supporting different workingType)
    /// </summary>
    public decimal? ActivatePrice { get; init; }

    /// <summary>Used with TRAILING_STOP_MARKET orders</summary>
    public decimal? CallbackRate { get; init; }

    /// <summary>
    /// A unique id among open orders. Automatically generated if not sent. Can only be string following the
    /// rule: ^[.A-Z\:/a-z0-9_-]{1,36}$
    /// </summary>
    public string? ClientAlgoId { get; init; }

    /// <summary>"ACK", "RESULT", default "ACK"</summary>
    public NewAlgoOrderNewOrderRespType? NewOrderRespType { get; init; }

    /// <summary>
    /// EXPIRE_TAKER: expire taker order when STP triggers/ EXPIRE_MAKER: expire maker order when STP
    /// triggers/ EXPIRE_BOTH: expire both orders when STP triggers; default NONE
    /// </summary>
    public NewAlgoOrderSelfTradePreventionMode? SelfTradePreventionMode { get; init; }

    /// <summary>Recv Window.</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<NewOrderSide>))]
public readonly struct NewOrderSide : IExtensibleValue<NewOrderSide>, IEquatable<NewOrderSide>
{
    private readonly string? _value;

    public NewOrderSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewOrderSide Buy { get; } = new("BUY");

    public static NewOrderSide Sell { get; } = new("SELL");

    static NewOrderSide IExtensibleValue<NewOrderSide>.Create(string value) => new(value);

    public static bool operator ==(NewOrderSide left, NewOrderSide right) => left.Equals(right);

    public static bool operator !=(NewOrderSide left, NewOrderSide right) => !left.Equals(right);

    public static implicit operator NewOrderSide(string value) => new(value);

    public static NewOrderSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewOrderSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewOrderSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewOrderType>))]
public readonly struct NewOrderType : IExtensibleValue<NewOrderType>, IEquatable<NewOrderType>
{
    private readonly string? _value;

    public NewOrderType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewOrderType Limit { get; } = new("LIMIT");

    public static NewOrderType Market { get; } = new("MARKET");

    public static NewOrderType Stop { get; } = new("STOP");

    public static NewOrderType StopMarket { get; } = new("STOP_MARKET");

    public static NewOrderType TakeProfit { get; } = new("TAKE_PROFIT");

    public static NewOrderType TakeProfitMarket { get; } = new("TAKE_PROFIT_MARKET");

    public static NewOrderType TrailingStopMarket { get; } = new("TRAILING_STOP_MARKET");

    static NewOrderType IExtensibleValue<NewOrderType>.Create(string value) => new(value);

    public static bool operator ==(NewOrderType left, NewOrderType right) => left.Equals(right);

    public static bool operator !=(NewOrderType left, NewOrderType right) => !left.Equals(right);

    public static implicit operator NewOrderType(string value) => new(value);

    public static NewOrderType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewOrderType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewOrderType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewOrderPositionSide>))]
public readonly struct NewOrderPositionSide : IExtensibleValue<NewOrderPositionSide>, IEquatable<NewOrderPositionSide>
{
    private readonly string? _value;

    public NewOrderPositionSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewOrderPositionSide Both { get; } = new("BOTH");

    public static NewOrderPositionSide Long { get; } = new("LONG");

    public static NewOrderPositionSide Short { get; } = new("SHORT");

    static NewOrderPositionSide IExtensibleValue<NewOrderPositionSide>.Create(string value) => new(value);

    public static bool operator ==(NewOrderPositionSide left, NewOrderPositionSide right) => left.Equals(right);

    public static bool operator !=(NewOrderPositionSide left, NewOrderPositionSide right) => !left.Equals(right);

    public static implicit operator NewOrderPositionSide(string value) => new(value);

    public static NewOrderPositionSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewOrderPositionSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewOrderPositionSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewOrderTimeInForce>))]
public readonly struct NewOrderTimeInForce : IExtensibleValue<NewOrderTimeInForce>, IEquatable<NewOrderTimeInForce>
{
    private readonly string? _value;

    public NewOrderTimeInForce(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewOrderTimeInForce Gtc { get; } = new("GTC");

    public static NewOrderTimeInForce Ioc { get; } = new("IOC");

    public static NewOrderTimeInForce Fok { get; } = new("FOK");

    public static NewOrderTimeInForce Gtx { get; } = new("GTX");

    static NewOrderTimeInForce IExtensibleValue<NewOrderTimeInForce>.Create(string value) => new(value);

    public static bool operator ==(NewOrderTimeInForce left, NewOrderTimeInForce right) => left.Equals(right);

    public static bool operator !=(NewOrderTimeInForce left, NewOrderTimeInForce right) => !left.Equals(right);

    public static implicit operator NewOrderTimeInForce(string value) => new(value);

    public static NewOrderTimeInForce FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewOrderTimeInForce other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewOrderTimeInForce other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewOrderReduceOnly>))]
public readonly struct NewOrderReduceOnly : IExtensibleValue<NewOrderReduceOnly>, IEquatable<NewOrderReduceOnly>
{
    private readonly string? _value;

    public NewOrderReduceOnly(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewOrderReduceOnly True { get; } = new("true");

    public static NewOrderReduceOnly False { get; } = new("false");

    static NewOrderReduceOnly IExtensibleValue<NewOrderReduceOnly>.Create(string value) => new(value);

    public static bool operator ==(NewOrderReduceOnly left, NewOrderReduceOnly right) => left.Equals(right);

    public static bool operator !=(NewOrderReduceOnly left, NewOrderReduceOnly right) => !left.Equals(right);

    public static implicit operator NewOrderReduceOnly(string value) => new(value);

    public static NewOrderReduceOnly FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewOrderReduceOnly other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewOrderReduceOnly other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewOrderClosePosition>))]
public readonly struct NewOrderClosePosition : IExtensibleValue<NewOrderClosePosition>, IEquatable<NewOrderClosePosition>
{
    private readonly string? _value;

    public NewOrderClosePosition(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewOrderClosePosition True { get; } = new("true");

    public static NewOrderClosePosition False { get; } = new("false");

    static NewOrderClosePosition IExtensibleValue<NewOrderClosePosition>.Create(string value) => new(value);

    public static bool operator ==(NewOrderClosePosition left, NewOrderClosePosition right) => left.Equals(right);

    public static bool operator !=(NewOrderClosePosition left, NewOrderClosePosition right) => !left.Equals(right);

    public static implicit operator NewOrderClosePosition(string value) => new(value);

    public static NewOrderClosePosition FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewOrderClosePosition other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewOrderClosePosition other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewOrderWorkingType>))]
public readonly struct NewOrderWorkingType : IExtensibleValue<NewOrderWorkingType>, IEquatable<NewOrderWorkingType>
{
    private readonly string? _value;

    public NewOrderWorkingType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewOrderWorkingType MarkPrice { get; } = new("MARK_PRICE");

    public static NewOrderWorkingType ContractPrice { get; } = new("CONTRACT_PRICE");

    static NewOrderWorkingType IExtensibleValue<NewOrderWorkingType>.Create(string value) => new(value);

    public static bool operator ==(NewOrderWorkingType left, NewOrderWorkingType right) => left.Equals(right);

    public static bool operator !=(NewOrderWorkingType left, NewOrderWorkingType right) => !left.Equals(right);

    public static implicit operator NewOrderWorkingType(string value) => new(value);

    public static NewOrderWorkingType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewOrderWorkingType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewOrderWorkingType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewOrderPriceProtect>))]
public readonly struct NewOrderPriceProtect : IExtensibleValue<NewOrderPriceProtect>, IEquatable<NewOrderPriceProtect>
{
    private readonly string? _value;

    public NewOrderPriceProtect(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewOrderPriceProtect True { get; } = new("true");

    public static NewOrderPriceProtect False { get; } = new("false");

    static NewOrderPriceProtect IExtensibleValue<NewOrderPriceProtect>.Create(string value) => new(value);

    public static bool operator ==(NewOrderPriceProtect left, NewOrderPriceProtect right) => left.Equals(right);

    public static bool operator !=(NewOrderPriceProtect left, NewOrderPriceProtect right) => !left.Equals(right);

    public static implicit operator NewOrderPriceProtect(string value) => new(value);

    public static NewOrderPriceProtect FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewOrderPriceProtect other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewOrderPriceProtect other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewOrderNewOrderRespType>))]
public readonly struct NewOrderNewOrderRespType : IExtensibleValue<NewOrderNewOrderRespType>, IEquatable<NewOrderNewOrderRespType>
{
    private readonly string? _value;

    public NewOrderNewOrderRespType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewOrderNewOrderRespType Ack { get; } = new("ACK");

    public static NewOrderNewOrderRespType Result { get; } = new("RESULT");

    static NewOrderNewOrderRespType IExtensibleValue<NewOrderNewOrderRespType>.Create(string value) => new(value);

    public static bool operator ==(NewOrderNewOrderRespType left, NewOrderNewOrderRespType right) => left.Equals(right);

    public static bool operator !=(NewOrderNewOrderRespType left, NewOrderNewOrderRespType right) => !left.Equals(right);

    public static implicit operator NewOrderNewOrderRespType(string value) => new(value);

    public static NewOrderNewOrderRespType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewOrderNewOrderRespType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewOrderNewOrderRespType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewOrderPriceMatch>))]
public readonly struct NewOrderPriceMatch : IExtensibleValue<NewOrderPriceMatch>, IEquatable<NewOrderPriceMatch>
{
    private readonly string? _value;

    public NewOrderPriceMatch(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewOrderPriceMatch Opponent { get; } = new("OPPONENT");

    public static NewOrderPriceMatch Opponent5 { get; } = new("OPPONENT_5");

    public static NewOrderPriceMatch Opponent10 { get; } = new("OPPONENT_10");

    public static NewOrderPriceMatch Opponent20 { get; } = new("OPPONENT_20");

    public static NewOrderPriceMatch Queue { get; } = new("QUEUE");

    public static NewOrderPriceMatch Queue5 { get; } = new("QUEUE_5");

    public static NewOrderPriceMatch Queue10 { get; } = new("QUEUE_10");

    public static NewOrderPriceMatch Queue20 { get; } = new("QUEUE_20");

    static NewOrderPriceMatch IExtensibleValue<NewOrderPriceMatch>.Create(string value) => new(value);

    public static bool operator ==(NewOrderPriceMatch left, NewOrderPriceMatch right) => left.Equals(right);

    public static bool operator !=(NewOrderPriceMatch left, NewOrderPriceMatch right) => !left.Equals(right);

    public static implicit operator NewOrderPriceMatch(string value) => new(value);

    public static NewOrderPriceMatch FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewOrderPriceMatch other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewOrderPriceMatch other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewOrderSelfTradePreventionMode>))]
public readonly struct NewOrderSelfTradePreventionMode : IExtensibleValue<NewOrderSelfTradePreventionMode>, IEquatable<NewOrderSelfTradePreventionMode>
{
    private readonly string? _value;

    public NewOrderSelfTradePreventionMode(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewOrderSelfTradePreventionMode None { get; } = new("NONE");

    public static NewOrderSelfTradePreventionMode ExpireTaker { get; } = new("EXPIRE_TAKER");

    public static NewOrderSelfTradePreventionMode ExpireBoth { get; } = new("EXPIRE_BOTH");

    public static NewOrderSelfTradePreventionMode ExpireMaker { get; } = new("EXPIRE_MAKER");

    static NewOrderSelfTradePreventionMode IExtensibleValue<NewOrderSelfTradePreventionMode>.Create(string value) => new(value);

    public static bool operator ==(NewOrderSelfTradePreventionMode left, NewOrderSelfTradePreventionMode right) => left.Equals(right);

    public static bool operator !=(NewOrderSelfTradePreventionMode left, NewOrderSelfTradePreventionMode right) => !left.Equals(right);

    public static implicit operator NewOrderSelfTradePreventionMode(string value) => new(value);

    public static NewOrderSelfTradePreventionMode FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewOrderSelfTradePreventionMode other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewOrderSelfTradePreventionMode other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class NewOrderRequest
{
    public required string Symbol { get; init; }

    public required NewOrderSide Side { get; init; }

    /// <summary>
    /// After CM migration, stop-type values (STOP, STOP_MARKET, TAKE_PROFIT, TAKE_PROFIT_MARKET,
    /// TRAILING_STOP_MARKET) are no longer accepted and will return -4120. Use the REST /dapi/v1/algoOrder
    /// endpoint instead.
    /// </summary>
    public required NewOrderType Type { get; init; }

    public string? Id { get; init; }

    /// <summary>
    /// Default BOTH for One-way Mode; LONG or SHORT for Hedge Mode. It must be sent in Hedge Mode.
    /// </summary>
    public NewOrderPositionSide? PositionSide { get; init; }

    public NewOrderTimeInForce? TimeInForce { get; init; }

    /// <summary>Quantity measured by contract number, Cannot be sent with closePosition=true</summary>
    public decimal? Quantity { get; init; }

    /// <summary>Cannot be sent in Hedge Mode; cannot be sent with closePosition=true (Close-All)"</summary>
    public NewOrderReduceOnly? ReduceOnly { get; init; }

    public decimal? Price { get; init; }

    /// <summary>
    /// A unique id among open orders. Automatically generated if not sent. Can only be string following the
    /// rule: ^[.A-Z\:/a-z0-9_-]{1,36}$
    /// </summary>
    public string? NewClientOrderId { get; init; }

    /// <summary>Used with STOP/STOP_MARKET or TAKE_PROFIT/TAKE_PROFIT_MARKET orders.</summary>
    public decimal? StopPrice { get; init; }

    /// <summary>true, false；Close-All，used with STOP_MARKET or TAKE_PROFIT_MARKET.</summary>
    public NewOrderClosePosition? ClosePosition { get; init; }

    /// <summary>
    /// Used with TRAILING_STOP_MARKET orders, default as the latest price(supporting different workingType)
    /// </summary>
    public decimal? ActivationPrice { get; init; }

    /// <summary>Used with TRAILING_STOP_MARKET orders, min 0.1, max 10 where 1 for 1%</summary>
    public decimal? CallbackRate { get; init; }

    /// <summary>stopPrice triggered by: "MARK_PRICE", "CONTRACT_PRICE". Default "CONTRACT_PRICE"</summary>
    public NewOrderWorkingType? WorkingType { get; init; }

    /// <summary>Used with STOP/STOP_MARKET or TAKE_PROFIT/TAKE_PROFIT_MARKET orders.'</summary>
    public NewOrderPriceProtect? PriceProtect { get; init; }

    public NewOrderNewOrderRespType? NewOrderRespType { get; init; }

    /// <summary>
    /// only available for LIMIT/STOP/TAKE_PROFIT order; Can't be passed together with price
    /// </summary>
    public NewOrderPriceMatch? PriceMatch { get; init; }

    /// <summary>
    /// NONE: No STP / EXPIRE_TAKER: expire taker order when STP triggers/ EXPIRE_MAKER: expire taker order
    /// when STP triggers/ EXPIRE_BOTH: expire both orders when STP triggers
    /// </summary>
    public NewOrderSelfTradePreventionMode? SelfTradePreventionMode { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class PositionInformationRequest
{
    public string? Id { get; init; }

    public string? MarginAsset { get; init; }

    public string? Pair { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryOrderRequest
{
    public required string Symbol { get; init; }

    public string? Id { get; init; }

    public long? OrderId { get; init; }

    public string? OrigClientOrderId { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed partial class DerivativesTradingCoinFuturesWebSocketApiConnection
{

    /// <summary>Cancel Algo Order (TRADE)</summary>
    /// <remarks>
    /// <para>Cancel an active algo order.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Either algoId or clientAlgoId must be sent.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<CancelAlgoOrderResponseResult>> CancelAlgoOrderAsync(CancelAlgoOrderRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("algoOrder.cancel", WebSocketAuth.Signed);
        request ??= new();
        r.Param("id", request.Id);
        r.Param("algoId", request.AlgoId);
        r.Param("clientAlgoId", request.ClientAlgoId);
        r.Param("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesWebSocketApiJson.Default.CancelAlgoOrderResponseResult, cancellationToken);
    }

    /// <summary>Cancel Order (TRADE)</summary>
    /// <remarks>
    /// <para>Cancel an active order.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Either orderId or origClientOrderId must be sent.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<CancelOrderResponseResult>> CancelOrderAsync(CancelOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("order.cancel", WebSocketAuth.Signed);
        if (request is null) return Task.FromException<WebSocketApiResponse<CancelOrderResponseResult>>(new ArgumentNullException(nameof(request)));
        r.Param("symbol", request.Symbol);
        r.Param("id", request.Id);
        r.Param("orderId", request.OrderId);
        r.Param("origClientOrderId", request.OrigClientOrderId);
        r.Param("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesWebSocketApiJson.Default.CancelOrderResponseResult, cancellationToken);
    }

    /// <summary>Modify Order (TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Order modify function, currently only LIMIT order modification is supported, modified orders will be
    /// reordered in the match queue
    /// </para>
    /// <para>
    /// Weight: 1 on 10s order rate limit(X-MBX-ORDER-COUNT-10S); 1 on 1min order rate
    /// limit(X-MBX-ORDER-COUNT-1M); 0 on IP rate limit(x-mbx-used-weight-1m)
    /// </para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Either orderId or origClientOrderId must be sent, and the orderId will prevail if both are sent.</para>
    /// <para>- Both quantity and price must be sent.</para>
    /// <para>
    /// - When the new quantity or price doesn't satisfy PRICE_FILTER / PERCENT_FILTER / LOT_SIZE, amendment
    /// will be rejected and the order will stay as it is.
    /// </para>
    /// <para>- However the order will be cancelled by the amendment in the following situations:</para>
    /// <para>- when the order is in partially filled status and the new quantity &lt;= executedQty</para>
    /// <para>- When the order is GTX and the new price will cause it to be executed immediately</para>
    /// <para>- One order can only be modified for less than 10000 times.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<ModifyOrderResponseResult>> ModifyOrderAsync(ModifyOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("order.modify", WebSocketAuth.Signed);
        if (request is null) return Task.FromException<WebSocketApiResponse<ModifyOrderResponseResult>>(new ArgumentNullException(nameof(request)));
        r.Param("symbol", request.Symbol);
        r.Param("side", request.Side);
        r.Param("quantity", request.Quantity);
        r.Param("price", request.Price);
        r.Param("id", request.Id);
        r.Param("orderId", request.OrderId);
        r.Param("origClientOrderId", request.OrigClientOrderId);
        r.Param("priceMatch", request.PriceMatch);
        r.Param("modifyId", request.ModifyId);
        r.Param("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesWebSocketApiJson.Default.ModifyOrderResponseResult, cancellationToken);
    }

    /// <summary>New Algo Order (TRADE)</summary>
    /// <remarks>
    /// <para>Send in a new algo order.</para>
    /// <para>Weight(IP): 0</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Condition orders will be triggered when:</para>
    /// <para>- If parameterpriceProtectis sent as true:</para>
    /// <para>- when price reaches the triggerPrice ，the difference rate between</para>
    /// <para>"MARK_PRICE" and "CONTRACT_PRICE" cannot be larger than the "triggerProtect" of the symbol</para>
    /// <para>- "triggerProtect" of a symbol can be got from GET</para>
    /// <para>/dapi/v1/exchangeInfo</para>
    /// <para>- STOP, STOP_MARKET:</para>
    /// <para>- BUY: latest price ("MARK_PRICE" or "CONTRACT_PRICE") &gt;= triggerPrice</para>
    /// <para>- SELL: latest price ("MARK_PRICE" or "CONTRACT_PRICE") &lt;=</para>
    /// <para>triggerPrice</para>
    /// <para>- TAKE_PROFIT, TAKE_PROFIT_MARKET:</para>
    /// <para>- BUY: latest price ("MARK_PRICE" or "CONTRACT_PRICE") &lt;= triggerPrice</para>
    /// <para>- SELL: latest price ("MARK_PRICE" or "CONTRACT_PRICE") &gt;=</para>
    /// <para>triggerPrice</para>
    /// <para>- TRAILING_STOP_MARKET:</para>
    /// <para>- BUY: the lowest price after order placed &lt;= activatePrice, and the</para>
    /// <para>latest price &gt;= the lowest price * (1 + callbackRate)</para>
    /// <para>- SELL: the highest price after order placed &gt;= activatePrice, and the</para>
    /// <para>latest price &lt;= the highest price * (1 - callbackRate)</para>
    /// <para>- For TRAILING_STOP_MARKET, if you got such error code.</para>
    /// <para>&gt; {"code": -2021, "msg": "Order would immediately trigger."}</para>
    /// <para>&gt; means that the parameters you send do not meet the following requirements:</para>
    /// <para>- BUY: activatePrice should be smaller than latest price.</para>
    /// <para>- SELL: activatePrice should be larger than latest price.</para>
    /// <para>- STOP_MARKET, TAKE_PROFIT_MARKET with closePosition=true:</para>
    /// <para>- Follow the same rules for condition orders.</para>
    /// <para>- If triggered，close all current long position( if SELL) or</para>
    /// <para>current short position( if BUY).</para>
    /// <para>- Cannot be used with quantity parameter</para>
    /// <para>- Cannot be used with reduceOnly parameter</para>
    /// <para>- In Hedge Mode,cannot be used with BUY orders in LONG position</para>
    /// <para>side. and cannot be used with SELL orders in SHORT position side</para>
    /// <para>- selfTradePreventionMode is only effective when timeInForce set to</para>
    /// <para>IOC or GTC.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<NewAlgoOrderResponseResult>> NewAlgoOrderAsync(NewAlgoOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("algoOrder.place", WebSocketAuth.Signed);
        if (request is null) return Task.FromException<WebSocketApiResponse<NewAlgoOrderResponseResult>>(new ArgumentNullException(nameof(request)));
        r.Param("algoType", request.AlgoType);
        r.Param("symbol", request.Symbol);
        r.Param("side", request.Side);
        r.Param("type", request.Type);
        r.Param("id", request.Id);
        r.Param("positionSide", request.PositionSide);
        r.Param("timeInForce", request.TimeInForce);
        r.Param("quantity", request.Quantity);
        r.Param("price", request.Price);
        r.Param("triggerPrice", request.TriggerPrice);
        r.Param("workingType", request.WorkingType);
        r.Param("priceMatch", request.PriceMatch);
        r.Param("closePosition", request.ClosePosition);
        r.Param("priceProtect", request.PriceProtect);
        r.Param("reduceOnly", request.ReduceOnly);
        r.Param("activatePrice", request.ActivatePrice);
        r.Param("callbackRate", request.CallbackRate);
        r.Param("clientAlgoId", request.ClientAlgoId);
        r.Param("newOrderRespType", request.NewOrderRespType);
        r.Param("selfTradePreventionMode", request.SelfTradePreventionMode);
        r.Param("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesWebSocketApiJson.Default.NewAlgoOrderResponseResult, cancellationToken);
    }

    /// <summary>New Order (TRADE)</summary>
    /// <remarks>
    /// <para>Send in a new order.</para>
    /// <para>Weight(IP): 0</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Additional mandatory parameters based on type:</para>
    /// <para>
    /// | Type | Additional mandatory parameters | | :---: | --- | | LIMIT | timeInForce, quantity, price |
    /// | MARKET | quantity | | STOP/TAKE_PROFIT | quantity, price, stopPrice | |
    /// STOP_MARKET/TAKE_PROFIT_MARKET | stopPrice | | TRAILING_STOP_MARKET | callbackRate |
    /// </para>
    /// <para>
    /// - Order with type STOP, parameter timeInForce can be sent ( default GTC). * Order with type
    /// TAKE_PROFIT, parameter timeInForce can be sent ( default GTC). * Condition orders will be triggered
    /// when:
    /// </para>
    /// <para>- If parameter priceProtect is sent as true:</para>
    /// <para>
    /// - when price reaches the stopPrice，the difference rate between "MARK_PRICE" and "CONTRACT_PRICE"
    /// cannot be larger than the "triggerProtect" of the symbol
    /// </para>
    /// <para>- "triggerProtect" of a symbol can be got from GET /dapi/v1/exchangeInfo</para>
    /// <para>- STOP, STOP_MARKET:</para>
    /// <para>- BUY: latest price ("MARK_PRICE" or "CONTRACT_PRICE") &gt;= stopPrice</para>
    /// <para>- SELL: latest price ("MARK_PRICE" or "CONTRACT_PRICE") &lt;= stopPrice</para>
    /// <para>- TAKE_PROFIT, TAKE_PROFIT_MARKET:</para>
    /// <para>- BUY: latest price ("MARK_PRICE" or "CONTRACT_PRICE") &lt;= stopPrice</para>
    /// <para>- SELL: latest price ("MARK_PRICE" or "CONTRACT_PRICE") &gt;= stopPrice</para>
    /// <para>- TRAILING_STOP_MARKET:</para>
    /// <para>
    /// - BUY: the lowest price after order placed &lt;= activationPrice, and the latest price &gt;= the
    /// lowest price * (1 + callbackRate)
    /// </para>
    /// <para>
    /// - SELL: the highest price after order placed &gt;= activationPrice, and the latest price &lt;= the
    /// highest price * (1 - callbackRate)
    /// </para>
    /// <para>- For TRAILING_STOP_MARKET, if you got such error code.</para>
    /// <para>- BUY: activationPrice should be smaller than latest price.</para>
    /// <para>- SELL: activationPrice should be larger than latest price.</para>
    /// <para>- If newOrderRespType is sent as RESULT:</para>
    /// <para>- MARKET order: the final FILLED result of the order will be return directly.</para>
    /// <para>
    /// - LIMIT order with special timeInForce: the final status result of the order(FILLED or EXPIRED) will
    /// be returned directly.
    /// </para>
    /// <para>- STOP_MARKET, TAKE_PROFIT_MARKET with closePosition=true:</para>
    /// <para>- Follow the same rules for condition orders.</para>
    /// <para>- If triggered，close all current long position(if SELL) or current short position(if BUY).</para>
    /// <para>- Cannot be used with quantity parameter</para>
    /// <para>- Cannot be used with reduceOnly parameter</para>
    /// <para>
    /// - In Hedge Mode, cannot be used with BUY orders in LONG position side. and cannot be used with SELL
    /// orders in SHORT position side
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<NewOrderResponseResult>> NewOrderAsync(NewOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("order.place", WebSocketAuth.Signed);
        if (request is null) return Task.FromException<WebSocketApiResponse<NewOrderResponseResult>>(new ArgumentNullException(nameof(request)));
        r.Param("symbol", request.Symbol);
        r.Param("side", request.Side);
        r.Param("type", request.Type);
        r.Param("id", request.Id);
        r.Param("positionSide", request.PositionSide);
        r.Param("timeInForce", request.TimeInForce);
        r.Param("quantity", request.Quantity);
        r.Param("reduceOnly", request.ReduceOnly);
        r.Param("price", request.Price);
        r.Param("newClientOrderId", request.NewClientOrderId);
        r.Param("stopPrice", request.StopPrice);
        r.Param("closePosition", request.ClosePosition);
        r.Param("activationPrice", request.ActivationPrice);
        r.Param("callbackRate", request.CallbackRate);
        r.Param("workingType", request.WorkingType);
        r.Param("priceProtect", request.PriceProtect);
        r.Param("newOrderRespType", request.NewOrderRespType);
        r.Param("priceMatch", request.PriceMatch);
        r.Param("selfTradePreventionMode", request.SelfTradePreventionMode);
        r.Param("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesWebSocketApiJson.Default.NewOrderResponseResult, cancellationToken);
    }

    /// <summary>Position Information (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get current position information.</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Please use with user data stream ACCOUNT_UPDATE to meet your timeliness and accuracy needs.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<List<PositionInformationResponseResultInner>>> PositionInformationAsync(PositionInformationRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("account.position", WebSocketAuth.Signed);
        request ??= new();
        r.Param("id", request.Id);
        r.Param("marginAsset", request.MarginAsset);
        r.Param("pair", request.Pair);
        r.Param("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesWebSocketApiJson.Default.ListPositionInformationResponseResultInner, cancellationToken);
    }

    /// <summary>Query Order (USER_DATA)</summary>
    /// <remarks>
    /// <para>Check an order's status.</para>
    /// <para>- These orders will not be found:</para>
    /// <para>
    /// - order status is CANCELED or EXPIRED AND order has NO filled trade AND created time + 3 days &lt;
    /// current time
    /// </para>
    /// <para>- order create time + 90 days &lt; current time</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Either orderId or origClientOrderId must be sent.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<QueryOrderResponseResult>> QueryOrderAsync(QueryOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("order.status", WebSocketAuth.Signed);
        if (request is null) return Task.FromException<WebSocketApiResponse<QueryOrderResponseResult>>(new ArgumentNullException(nameof(request)));
        r.Param("symbol", request.Symbol);
        r.Param("id", request.Id);
        r.Param("orderId", request.OrderId);
        r.Param("origClientOrderId", request.OrigClientOrderId);
        r.Param("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesWebSocketApiJson.Default.QueryOrderResponseResult, cancellationToken);
    }
}
