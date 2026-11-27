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

public sealed class AccountTradeListRequest
{
    public required string Symbol { get; init; }

    /// <summary>Must be used together with parameter symbol.</summary>
    public long? OrderId { get; init; }

    /// <summary>Start time</summary>
    public long? StartTime { get; init; }

    /// <summary>End time</summary>
    public long? EndTime { get; init; }

    /// <summary>Trade id to fetch from. Default gets most recent trades.</summary>
    public long? FromId { get; init; }

    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class AllOrdersRequest
{
    public string? Symbol { get; init; }

    public long? OrderId { get; init; }

    /// <summary>Start time</summary>
    public long? StartTime { get; init; }

    /// <summary>End time</summary>
    public long? EndTime { get; init; }

    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class AutoCancelAllOpenOrdersRequest
{
    public required string Symbol { get; init; }

    /// <summary>Countdown in milliseconds. 1000 means 1 second; 0 disables countdown cancel-all.</summary>
    public required long CountdownTime { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class CancelAlgoOrderRequest
{
    public long? AlgoId { get; init; }

    public string? ClientAlgoId { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class CancelAllAlgoOpenOrdersRequest
{
    public required string Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class CancelAllOpenOrdersRequest
{
    public required string Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class CancelMultipleOrdersRequest
{
    public required string Symbol { get; init; }

    public List<long>? OrderIdList { get; init; }

    public List<string>? OrigClientOrderIdList { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class CancelOrderRequest
{
    public required string Symbol { get; init; }

    public long? OrderId { get; init; }

    public string? OrigClientOrderId { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class ChangeInitialLeverageRequest
{
    public required string Symbol { get; init; }

    /// <summary>
    /// Target initial leverage. The maximum is symbol-specific: use initialLeverage of bracket 1 from GET
    /// /fapi/v1/leverageBracket.
    /// </summary>
    public required long Leverage { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<ChangeMarginTypeMarginType>))]
public readonly struct ChangeMarginTypeMarginType : IExtensibleValue<ChangeMarginTypeMarginType>, IEquatable<ChangeMarginTypeMarginType>
{
    private readonly string? _value;

    public ChangeMarginTypeMarginType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static ChangeMarginTypeMarginType Isolated { get; } = new("ISOLATED");

    public static ChangeMarginTypeMarginType Crossed { get; } = new("CROSSED");

    static ChangeMarginTypeMarginType IExtensibleValue<ChangeMarginTypeMarginType>.Create(string value) => new(value);

    public static bool operator ==(ChangeMarginTypeMarginType left, ChangeMarginTypeMarginType right) => left.Equals(right);

    public static bool operator !=(ChangeMarginTypeMarginType left, ChangeMarginTypeMarginType right) => !left.Equals(right);

    public static implicit operator ChangeMarginTypeMarginType(string value) => new(value);

    public static ChangeMarginTypeMarginType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ChangeMarginTypeMarginType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ChangeMarginTypeMarginType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class ChangeMarginTypeRequest
{
    public required string Symbol { get; init; }

    public required ChangeMarginTypeMarginType MarginType { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class ChangeMultiAssetsModeRequest
{
    /// <summary>"true": Multi-Assets Mode; "false": Single-Asset Mode</summary>
    public required string MultiAssetsMargin { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class ChangePositionModeRequest
{
    /// <summary>"true": Hedge Mode; "false": One-way Mode</summary>
    public required string DualSidePosition { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class CurrentAllAlgoOpenOrdersRequest
{
    public string? AlgoType { get; init; }

    public string? Symbol { get; init; }

    public long? AlgoId { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class CurrentAllOpenOrdersRequest
{
    public string? Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class FuturesTradfiPerpsContractRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class GetOrderModifyHistoryRequest
{
    public required string Symbol { get; init; }

    public long? OrderId { get; init; }

    public string? OrigClientOrderId { get; init; }

    /// <summary>Timestamp in ms to get modification history from INCLUSIVE</summary>
    public long? StartTime { get; init; }

    /// <summary>Timestamp in ms to get modification history until INCLUSIVE</summary>
    public long? EndTime { get; init; }

    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetPositionMarginChangeHistoryRequest
{
    public required string Symbol { get; init; }

    /// <summary>1: Add position margin，2: Reduce position margin</summary>
    public string? Type { get; init; }

    /// <summary>Start time</summary>
    public long? StartTime { get; init; }

    /// <summary>time if not pass</summary>
    public long? EndTime { get; init; }

    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class ModifyIsolatedPositionMarginRequest
{
    public required string Symbol { get; init; }

    /// <summary>Margin asset</summary>
    public required decimal Amount { get; init; }

    /// <summary>1: Add position margin，2: Reduce position margin</summary>
    public required long Type { get; init; }

    /// <summary>
    /// Default BOTH for One-way Mode ; LONG or SHORT for Hedge Mode. It must be sent with Hedge Mode.
    /// </summary>
    public string? PositionSide { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class ModifyMultipleOrdersRequest
{
    /// <summary>order list. Max 5 orders</summary>
    public required List<ModifyMultipleOrdersBatchOrdersParameterInner> BatchOrders { get; init; }

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

[JsonConverter(typeof(ExtensibleValueConverter<ModifyOrderReduceOnly>))]
public readonly struct ModifyOrderReduceOnly : IExtensibleValue<ModifyOrderReduceOnly>, IEquatable<ModifyOrderReduceOnly>
{
    private readonly string? _value;

    public ModifyOrderReduceOnly(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static ModifyOrderReduceOnly True { get; } = new("true");

    public static ModifyOrderReduceOnly False { get; } = new("false");

    static ModifyOrderReduceOnly IExtensibleValue<ModifyOrderReduceOnly>.Create(string value) => new(value);

    public static bool operator ==(ModifyOrderReduceOnly left, ModifyOrderReduceOnly right) => left.Equals(right);

    public static bool operator !=(ModifyOrderReduceOnly left, ModifyOrderReduceOnly right) => !left.Equals(right);

    public static implicit operator ModifyOrderReduceOnly(string value) => new(value);

    public static ModifyOrderReduceOnly FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ModifyOrderReduceOnly other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ModifyOrderReduceOnly other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

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

    /// <summary>See notes below for behavior.</summary>
    public ModifyOrderReduceOnly? ReduceOnly { get; init; }

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

    public static NewAlgoOrderType Limit { get; } = new("LIMIT");

    public static NewAlgoOrderType Market { get; } = new("MARKET");

    public static NewAlgoOrderType Stop { get; } = new("STOP");

    public static NewAlgoOrderType StopMarket { get; } = new("STOP_MARKET");

    public static NewAlgoOrderType TakeProfit { get; } = new("TAKE_PROFIT");

    public static NewAlgoOrderType TakeProfitMarket { get; } = new("TAKE_PROFIT_MARKET");

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

    public static NewAlgoOrderTimeInForce Gtc { get; } = new("GTC");

    public static NewAlgoOrderTimeInForce Ioc { get; } = new("IOC");

    public static NewAlgoOrderTimeInForce Fok { get; } = new("FOK");

    public static NewAlgoOrderTimeInForce Gtx { get; } = new("GTX");

    public static NewAlgoOrderTimeInForce Gtd { get; } = new("GTD");

    public static NewAlgoOrderTimeInForce Rpi { get; } = new("RPI");

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
    public required NewAlgoOrderAlgoType AlgoType { get; init; }

    public required string Symbol { get; init; }

    public required NewAlgoOrderSide Side { get; init; }

    public required NewAlgoOrderType Type { get; init; }

    /// <summary>
    /// Default BOTH for One-way Mode ; LONG or SHORT for Hedge Mode. It must be sent in Hedge Mode.
    /// </summary>
    public string? PositionSide { get; init; }

    public NewAlgoOrderTimeInForce? TimeInForce { get; init; }

    /// <summary>Cannot be sent with closePosition=true(Close-All)</summary>
    public decimal? Quantity { get; init; }

    public decimal? Price { get; init; }

    /// <summary>Trigger price</summary>
    public decimal? TriggerPrice { get; init; }

    public NewAlgoOrderWorkingType? WorkingType { get; init; }

    /// <summary>
    /// only avaliable for LIMIT/STOP/TAKE_PROFIT order; Can't be passed together with price
    /// </summary>
    public NewAlgoOrderPriceMatch? PriceMatch { get; init; }

    /// <summary>Close-All，used with STOP_MARKET or TAKE_PROFIT_MARKET.</summary>
    public NewAlgoOrderClosePosition? ClosePosition { get; init; }

    /// <summary>
    /// Used with STOP_MARKET or TAKE_PROFIT_MARKET order. when price reaches the triggerPrice ，the
    /// difference rate between "MARK_PRICE" and "CONTRACT_PRICE" cannot be larger than the Price Protection
    /// Threshold of the symbol.'
    /// </summary>
    public NewAlgoOrderPriceProtect? PriceProtect { get; init; }

    /// <summary>Cannot be sent in Hedge Mode; cannot be sent with closePosition=true'</summary>
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

    public NewAlgoOrderNewOrderRespType? NewOrderRespType { get; init; }

    /// <summary>
    /// EXPIRE_TAKER: expire taker order when STP triggers / EXPIRE_MAKER: expire taker order when STP
    /// triggers/ EXPIRE_BOTH: expire both orders when STP triggers; default NONE
    /// </summary>
    public NewAlgoOrderSelfTradePreventionMode? SelfTradePreventionMode { get; init; }

    /// <summary>
    /// order cancel time for timeInForce GTD, mandatory when timeInforce set to GTD; order the timestamp
    /// only retains second-level precision, ms part will be ignored; The goodTillDate timestamp must be
    /// greater than the current time plus 600 seconds and smaller than 253402300799000
    /// </summary>
    public long? GoodTillDate { get; init; }

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

    public static NewOrderTimeInForce Gtd { get; } = new("GTD");

    public static NewOrderTimeInForce Rpi { get; } = new("RPI");

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

    /// <summary>Order type</summary>
    public required NewOrderType Type { get; init; }

    /// <summary>
    /// Default BOTH for One-way Mode ; LONG or SHORT for Hedge Mode. It must be sent in Hedge Mode.
    /// </summary>
    public string? PositionSide { get; init; }

    public NewOrderTimeInForce? TimeInForce { get; init; }

    /// <summary>Cannot be sent in Hedge Mode</summary>
    public NewOrderReduceOnly? ReduceOnly { get; init; }

    public decimal? Quantity { get; init; }

    public decimal? Price { get; init; }

    /// <summary>
    /// A unique id among open orders. Automatically generated if not sent. Can only be string following the
    /// rule: ^[.A-Z\:/a-z0-9_-]{1,36}$
    /// </summary>
    public string? NewClientOrderId { get; init; }

    public NewOrderNewOrderRespType? NewOrderRespType { get; init; }

    /// <summary>
    /// only avaliable for LIMIT/STOP/TAKE_PROFIT order; Can't be passed together with price
    /// </summary>
    public NewOrderPriceMatch? PriceMatch { get; init; }

    /// <summary>
    /// EXPIRE_TAKER: expire taker order when STP triggers/ EXPIRE_MAKER: expire taker order when STP
    /// triggers/ EXPIRE_BOTH: expire both orders when STP triggers; default EXPIRE_MAKER
    /// </summary>
    public NewOrderSelfTradePreventionMode? SelfTradePreventionMode { get; init; }

    /// <summary>
    /// order cancel time for timeInForce GTD, mandatory when timeInforce set to GTD; order the timestamp
    /// only retains second-level precision, ms part will be ignored; The goodTillDate timestamp must be
    /// greater than the current time plus 600 seconds and smaller than 253402300799000
    /// </summary>
    public long? GoodTillDate { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class PlaceMultipleOrdersRequest
{
    /// <summary>order list. Max 5 orders</summary>
    public required List<PlaceMultipleOrdersBatchOrdersParameterInner> BatchOrders { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class PositionAdlQuantileEstimationRequest
{
    public string? Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class PositionInformationV2Request
{
    public string? Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class PositionInformationV3Request
{
    public string? Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryAlgoOrderRequest
{
    /// <summary>Order ID</summary>
    public long? AlgoId { get; init; }

    /// <summary>Client order ID</summary>
    public string? ClientAlgoId { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryAllAlgoOrdersRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    public long? AlgoId { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryCurrentOpenOrderRequest
{
    public required string Symbol { get; init; }

    public long? OrderId { get; init; }

    public string? OrigClientOrderId { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryOrderRequest
{
    public required string Symbol { get; init; }

    public long? OrderId { get; init; }

    public string? OrigClientOrderId { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<TestOrderSide>))]
public readonly struct TestOrderSide : IExtensibleValue<TestOrderSide>, IEquatable<TestOrderSide>
{
    private readonly string? _value;

    public TestOrderSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static TestOrderSide Buy { get; } = new("BUY");

    public static TestOrderSide Sell { get; } = new("SELL");

    static TestOrderSide IExtensibleValue<TestOrderSide>.Create(string value) => new(value);

    public static bool operator ==(TestOrderSide left, TestOrderSide right) => left.Equals(right);

    public static bool operator !=(TestOrderSide left, TestOrderSide right) => !left.Equals(right);

    public static implicit operator TestOrderSide(string value) => new(value);

    public static TestOrderSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TestOrderSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(TestOrderSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<TestOrderType>))]
public readonly struct TestOrderType : IExtensibleValue<TestOrderType>, IEquatable<TestOrderType>
{
    private readonly string? _value;

    public TestOrderType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static TestOrderType Limit { get; } = new("LIMIT");

    public static TestOrderType Market { get; } = new("MARKET");

    public static TestOrderType Stop { get; } = new("STOP");

    public static TestOrderType StopMarket { get; } = new("STOP_MARKET");

    public static TestOrderType TakeProfit { get; } = new("TAKE_PROFIT");

    public static TestOrderType TakeProfitMarket { get; } = new("TAKE_PROFIT_MARKET");

    public static TestOrderType TrailingStopMarket { get; } = new("TRAILING_STOP_MARKET");

    static TestOrderType IExtensibleValue<TestOrderType>.Create(string value) => new(value);

    public static bool operator ==(TestOrderType left, TestOrderType right) => left.Equals(right);

    public static bool operator !=(TestOrderType left, TestOrderType right) => !left.Equals(right);

    public static implicit operator TestOrderType(string value) => new(value);

    public static TestOrderType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TestOrderType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(TestOrderType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<TestOrderPositionSide>))]
public readonly struct TestOrderPositionSide : IExtensibleValue<TestOrderPositionSide>, IEquatable<TestOrderPositionSide>
{
    private readonly string? _value;

    public TestOrderPositionSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static TestOrderPositionSide Both { get; } = new("BOTH");

    public static TestOrderPositionSide Long { get; } = new("LONG");

    public static TestOrderPositionSide Short { get; } = new("SHORT");

    static TestOrderPositionSide IExtensibleValue<TestOrderPositionSide>.Create(string value) => new(value);

    public static bool operator ==(TestOrderPositionSide left, TestOrderPositionSide right) => left.Equals(right);

    public static bool operator !=(TestOrderPositionSide left, TestOrderPositionSide right) => !left.Equals(right);

    public static implicit operator TestOrderPositionSide(string value) => new(value);

    public static TestOrderPositionSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TestOrderPositionSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(TestOrderPositionSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<TestOrderReduceOnly>))]
public readonly struct TestOrderReduceOnly : IExtensibleValue<TestOrderReduceOnly>, IEquatable<TestOrderReduceOnly>
{
    private readonly string? _value;

    public TestOrderReduceOnly(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static TestOrderReduceOnly True { get; } = new("true");

    public static TestOrderReduceOnly False { get; } = new("false");

    static TestOrderReduceOnly IExtensibleValue<TestOrderReduceOnly>.Create(string value) => new(value);

    public static bool operator ==(TestOrderReduceOnly left, TestOrderReduceOnly right) => left.Equals(right);

    public static bool operator !=(TestOrderReduceOnly left, TestOrderReduceOnly right) => !left.Equals(right);

    public static implicit operator TestOrderReduceOnly(string value) => new(value);

    public static TestOrderReduceOnly FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TestOrderReduceOnly other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(TestOrderReduceOnly other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<TestOrderClosePosition>))]
public readonly struct TestOrderClosePosition : IExtensibleValue<TestOrderClosePosition>, IEquatable<TestOrderClosePosition>
{
    private readonly string? _value;

    public TestOrderClosePosition(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static TestOrderClosePosition True { get; } = new("true");

    public static TestOrderClosePosition False { get; } = new("false");

    static TestOrderClosePosition IExtensibleValue<TestOrderClosePosition>.Create(string value) => new(value);

    public static bool operator ==(TestOrderClosePosition left, TestOrderClosePosition right) => left.Equals(right);

    public static bool operator !=(TestOrderClosePosition left, TestOrderClosePosition right) => !left.Equals(right);

    public static implicit operator TestOrderClosePosition(string value) => new(value);

    public static TestOrderClosePosition FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TestOrderClosePosition other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(TestOrderClosePosition other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<TestOrderTimeInForce>))]
public readonly struct TestOrderTimeInForce : IExtensibleValue<TestOrderTimeInForce>, IEquatable<TestOrderTimeInForce>
{
    private readonly string? _value;

    public TestOrderTimeInForce(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static TestOrderTimeInForce Gtc { get; } = new("GTC");

    public static TestOrderTimeInForce Ioc { get; } = new("IOC");

    public static TestOrderTimeInForce Fok { get; } = new("FOK");

    public static TestOrderTimeInForce Gtx { get; } = new("GTX");

    public static TestOrderTimeInForce Gtd { get; } = new("GTD");

    public static TestOrderTimeInForce Rpi { get; } = new("RPI");

    static TestOrderTimeInForce IExtensibleValue<TestOrderTimeInForce>.Create(string value) => new(value);

    public static bool operator ==(TestOrderTimeInForce left, TestOrderTimeInForce right) => left.Equals(right);

    public static bool operator !=(TestOrderTimeInForce left, TestOrderTimeInForce right) => !left.Equals(right);

    public static implicit operator TestOrderTimeInForce(string value) => new(value);

    public static TestOrderTimeInForce FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TestOrderTimeInForce other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(TestOrderTimeInForce other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<TestOrderWorkingType>))]
public readonly struct TestOrderWorkingType : IExtensibleValue<TestOrderWorkingType>, IEquatable<TestOrderWorkingType>
{
    private readonly string? _value;

    public TestOrderWorkingType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static TestOrderWorkingType MarkPrice { get; } = new("MARK_PRICE");

    public static TestOrderWorkingType ContractPrice { get; } = new("CONTRACT_PRICE");

    static TestOrderWorkingType IExtensibleValue<TestOrderWorkingType>.Create(string value) => new(value);

    public static bool operator ==(TestOrderWorkingType left, TestOrderWorkingType right) => left.Equals(right);

    public static bool operator !=(TestOrderWorkingType left, TestOrderWorkingType right) => !left.Equals(right);

    public static implicit operator TestOrderWorkingType(string value) => new(value);

    public static TestOrderWorkingType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TestOrderWorkingType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(TestOrderWorkingType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<TestOrderPriceProtect>))]
public readonly struct TestOrderPriceProtect : IExtensibleValue<TestOrderPriceProtect>, IEquatable<TestOrderPriceProtect>
{
    private readonly string? _value;

    public TestOrderPriceProtect(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static TestOrderPriceProtect True { get; } = new("true");

    public static TestOrderPriceProtect False { get; } = new("false");

    static TestOrderPriceProtect IExtensibleValue<TestOrderPriceProtect>.Create(string value) => new(value);

    public static bool operator ==(TestOrderPriceProtect left, TestOrderPriceProtect right) => left.Equals(right);

    public static bool operator !=(TestOrderPriceProtect left, TestOrderPriceProtect right) => !left.Equals(right);

    public static implicit operator TestOrderPriceProtect(string value) => new(value);

    public static TestOrderPriceProtect FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TestOrderPriceProtect other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(TestOrderPriceProtect other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<TestOrderNewOrderRespType>))]
public readonly struct TestOrderNewOrderRespType : IExtensibleValue<TestOrderNewOrderRespType>, IEquatable<TestOrderNewOrderRespType>
{
    private readonly string? _value;

    public TestOrderNewOrderRespType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static TestOrderNewOrderRespType Ack { get; } = new("ACK");

    public static TestOrderNewOrderRespType Result { get; } = new("RESULT");

    static TestOrderNewOrderRespType IExtensibleValue<TestOrderNewOrderRespType>.Create(string value) => new(value);

    public static bool operator ==(TestOrderNewOrderRespType left, TestOrderNewOrderRespType right) => left.Equals(right);

    public static bool operator !=(TestOrderNewOrderRespType left, TestOrderNewOrderRespType right) => !left.Equals(right);

    public static implicit operator TestOrderNewOrderRespType(string value) => new(value);

    public static TestOrderNewOrderRespType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TestOrderNewOrderRespType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(TestOrderNewOrderRespType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<TestOrderPriceMatch>))]
public readonly struct TestOrderPriceMatch : IExtensibleValue<TestOrderPriceMatch>, IEquatable<TestOrderPriceMatch>
{
    private readonly string? _value;

    public TestOrderPriceMatch(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static TestOrderPriceMatch Opponent { get; } = new("OPPONENT");

    public static TestOrderPriceMatch Opponent5 { get; } = new("OPPONENT_5");

    public static TestOrderPriceMatch Opponent10 { get; } = new("OPPONENT_10");

    public static TestOrderPriceMatch Opponent20 { get; } = new("OPPONENT_20");

    public static TestOrderPriceMatch Queue { get; } = new("QUEUE");

    public static TestOrderPriceMatch Queue5 { get; } = new("QUEUE_5");

    public static TestOrderPriceMatch Queue10 { get; } = new("QUEUE_10");

    public static TestOrderPriceMatch Queue20 { get; } = new("QUEUE_20");

    static TestOrderPriceMatch IExtensibleValue<TestOrderPriceMatch>.Create(string value) => new(value);

    public static bool operator ==(TestOrderPriceMatch left, TestOrderPriceMatch right) => left.Equals(right);

    public static bool operator !=(TestOrderPriceMatch left, TestOrderPriceMatch right) => !left.Equals(right);

    public static implicit operator TestOrderPriceMatch(string value) => new(value);

    public static TestOrderPriceMatch FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TestOrderPriceMatch other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(TestOrderPriceMatch other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<TestOrderSelfTradePreventionMode>))]
public readonly struct TestOrderSelfTradePreventionMode : IExtensibleValue<TestOrderSelfTradePreventionMode>, IEquatable<TestOrderSelfTradePreventionMode>
{
    private readonly string? _value;

    public TestOrderSelfTradePreventionMode(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static TestOrderSelfTradePreventionMode None { get; } = new("NONE");

    public static TestOrderSelfTradePreventionMode ExpireTaker { get; } = new("EXPIRE_TAKER");

    public static TestOrderSelfTradePreventionMode ExpireBoth { get; } = new("EXPIRE_BOTH");

    public static TestOrderSelfTradePreventionMode ExpireMaker { get; } = new("EXPIRE_MAKER");

    static TestOrderSelfTradePreventionMode IExtensibleValue<TestOrderSelfTradePreventionMode>.Create(string value) => new(value);

    public static bool operator ==(TestOrderSelfTradePreventionMode left, TestOrderSelfTradePreventionMode right) => left.Equals(right);

    public static bool operator !=(TestOrderSelfTradePreventionMode left, TestOrderSelfTradePreventionMode right) => !left.Equals(right);

    public static implicit operator TestOrderSelfTradePreventionMode(string value) => new(value);

    public static TestOrderSelfTradePreventionMode FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TestOrderSelfTradePreventionMode other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(TestOrderSelfTradePreventionMode other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class TestOrderRequest
{
    public required string Symbol { get; init; }

    public required TestOrderSide Side { get; init; }

    public required TestOrderType Type { get; init; }

    /// <summary>
    /// Default BOTH for One-way Mode ; LONG or SHORT for Hedge Mode. It must be sent in Hedge Mode.
    /// </summary>
    public TestOrderPositionSide? PositionSide { get; init; }

    /// <summary>Cannot be sent in Hedge Mode; cannot be sent with closePosition=true</summary>
    public TestOrderReduceOnly? ReduceOnly { get; init; }

    /// <summary>Cannot be sent with closePosition=true(Close-All)</summary>
    public decimal? Quantity { get; init; }

    public decimal? Price { get; init; }

    /// <summary>
    /// A unique id among open orders. Automatically generated if not sent. Can only be string following the
    /// rule: ^[.A-Z\:/a-z0-9_-]{1,36}$
    /// </summary>
    public string? NewClientOrderId { get; init; }

    /// <summary>Used with STOP/STOP_MARKET or TAKE_PROFIT/TAKE_PROFIT_MARKET orders.</summary>
    public decimal? StopPrice { get; init; }

    /// <summary>Close-All，used with STOP_MARKET or TAKE_PROFIT_MARKET."</summary>
    public TestOrderClosePosition? ClosePosition { get; init; }

    /// <summary>
    /// Used with TRAILING_STOP_MARKET orders, default as the latest price(supporting different workingType)
    /// </summary>
    public decimal? ActivationPrice { get; init; }

    /// <summary>Used with TRAILING_STOP_MARKET orders</summary>
    public decimal? CallbackRate { get; init; }

    public TestOrderTimeInForce? TimeInForce { get; init; }

    public TestOrderWorkingType? WorkingType { get; init; }

    public TestOrderPriceProtect? PriceProtect { get; init; }

    public TestOrderNewOrderRespType? NewOrderRespType { get; init; }

    /// <summary>
    /// only avaliable for LIMIT/STOP/TAKE_PROFIT order; Can't be passed together with price
    /// </summary>
    public TestOrderPriceMatch? PriceMatch { get; init; }

    /// <summary>
    /// NONE: No STP / EXPIRE_TAKER: expire taker order when STP triggers/ EXPIRE_MAKER: expire taker order
    /// when STP triggers/ EXPIRE_BOTH: expire both orders when STP triggers; default NONE
    /// </summary>
    public TestOrderSelfTradePreventionMode? SelfTradePreventionMode { get; init; }

    /// <summary>
    /// order cancel time for timeInForce GTD, mandatory when timeInforce set to GTD; order the timestamp
    /// only retains second-level precision, ms part will be ignored; The goodTillDate timestamp must be
    /// greater than the current time plus 600 seconds and smaller than 253402300799000
    /// </summary>
    public long? GoodTillDate { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<UsersForceOrdersAutoCloseType>))]
public readonly struct UsersForceOrdersAutoCloseType : IExtensibleValue<UsersForceOrdersAutoCloseType>, IEquatable<UsersForceOrdersAutoCloseType>
{
    private readonly string? _value;

    public UsersForceOrdersAutoCloseType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static UsersForceOrdersAutoCloseType Liquidation { get; } = new("LIQUIDATION");

    public static UsersForceOrdersAutoCloseType Adl { get; } = new("ADL");

    static UsersForceOrdersAutoCloseType IExtensibleValue<UsersForceOrdersAutoCloseType>.Create(string value) => new(value);

    public static bool operator ==(UsersForceOrdersAutoCloseType left, UsersForceOrdersAutoCloseType right) => left.Equals(right);

    public static bool operator !=(UsersForceOrdersAutoCloseType left, UsersForceOrdersAutoCloseType right) => !left.Equals(right);

    public static implicit operator UsersForceOrdersAutoCloseType(string value) => new(value);

    public static UsersForceOrdersAutoCloseType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is UsersForceOrdersAutoCloseType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(UsersForceOrdersAutoCloseType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class UsersForceOrdersRequest
{
    public string? Symbol { get; init; }

    /// <summary>"LIQUIDATION" for liquidation orders, "ADL" for ADL orders.</summary>
    public UsersForceOrdersAutoCloseType? AutoCloseType { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed partial class DerivativesTradingUsdsFuturesRestApi
{

    /// <summary>Account Trade List (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get trades for a specific account and symbol.</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If startTime and endTime are both not sent, then the last 7 days' data will be returned.</para>
    /// <para>- The time between startTime and endTime cannot be longer than 7 days.</para>
    /// <para>- The parameter fromId cannot be sent with startTime or endTime.</para>
    /// <para>- Only support querying trade in the past 3 months</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<AccountTradeListResponseInner>>> AccountTradeListAsync(AccountTradeListRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v1/userTrades", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<AccountTradeListResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderId", request.OrderId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("fromId", request.FromId);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.ListAccountTradeListResponseInner, cancellationToken);
    }

    /// <summary>All Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get all account orders; active, canceled, or filled.</para>
    /// <para>- These orders will not be found:</para>
    /// <para>
    /// - order status is CANCELED or EXPIRED AND order has NO filled trade AND created time + 3 days &lt;
    /// current time
    /// </para>
    /// <para>- order create time + 90 days &lt; current time</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>
    /// - If orderId is set, it will get orders &gt;= that orderId. Otherwise most recent orders are
    /// returned.
    /// </para>
    /// <para>- The query time period must be less then 7 days( default as the recent 7 days).</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<AllOrdersResponseInner>>> AllOrdersAsync(AllOrdersRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v1/allOrders", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("orderId", request.OrderId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.ListAllOrdersResponseInner, cancellationToken);
    }

    /// <summary>Auto-Cancel All Open Orders (TRADE)</summary>
    /// <remarks>
    /// <para>Cancel all open orders of the specified symbol at the end of the specified countdown.</para>
    /// <para>
    /// The endpoint should be called repeatedly as heartbeats so that the existing countdown time can be
    /// canceled and replaced by a new one.
    /// </para>
    /// <para>Example usage:</para>
    /// <para>
    /// Call this endpoint at 30s intervals with an countdownTime of 120000 (120s). If this endpoint is not
    /// called within 120 seconds, all your orders of the specified symbol will be automatically canceled.
    /// If this endpoint is called with an countdownTime of 0, the countdown timer will be stopped.
    /// </para>
    /// <para>
    /// The system will check all countdowns approximately every 10 milliseconds, so please note that
    /// sufficient redundancy should be considered when using this function. We do not recommend setting the
    /// countdown time to be too precise or too small.
    /// </para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<AutoCancelAllOpenOrdersResponse>> AutoCancelAllOpenOrdersAsync(AutoCancelAllOpenOrdersRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/fapi/v1/countdownCancelAll", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<AutoCancelAllOpenOrdersResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("countdownTime", request.CountdownTime);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.AutoCancelAllOpenOrdersResponse, cancellationToken);
    }

    /// <summary>Cancel Algo Order (TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Cancel an active algo (conditional) order, including TP/SL (Take Profit / Stop Loss) and trailing
    /// stop orders on USD-M Futures.
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Either algoId or clientAlgoId must be sent.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CancelAlgoOrderResponse>> CancelAlgoOrderAsync(CancelAlgoOrderRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/fapi/v1/algoOrder", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("algoId", request.AlgoId);
        r.Query("clientAlgoId", request.ClientAlgoId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.CancelAlgoOrderResponse, cancellationToken);
    }

    /// <summary>Cancel All Algo Open Orders (TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Cancel all open algo (conditional) orders on a symbol, including TP/SL (Take Profit / Stop Loss) and
    /// trailing stop orders on USD-M Futures.
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CancelAllAlgoOpenOrdersResponse>> CancelAllAlgoOpenOrdersAsync(CancelAllAlgoOpenOrdersRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/fapi/v1/algoOpenOrders", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CancelAllAlgoOpenOrdersResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.CancelAllAlgoOpenOrdersResponse, cancellationToken);
    }

    /// <summary>Cancel All Open Orders (TRADE)</summary>
    /// <remarks>
    /// <para>Cancel All Open Orders</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CancelAllOpenOrdersResponse>> CancelAllOpenOrdersAsync(CancelAllOpenOrdersRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/fapi/v1/allOpenOrders", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CancelAllOpenOrdersResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.CancelAllOpenOrdersResponse, cancellationToken);
    }

    /// <summary>Cancel Multiple Orders (TRADE)</summary>
    /// <remarks>
    /// <para>Cancel Multiple Orders</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Either orderIdList or origClientOrderIdList must be sent.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<CancelMultipleOrdersResponseInner>>> CancelMultipleOrdersAsync(CancelMultipleOrdersRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/fapi/v1/batchOrders", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<CancelMultipleOrdersResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderIdList", request.OrderIdList);
        r.Query("origClientOrderIdList", request.OrigClientOrderIdList);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.ListCancelMultipleOrdersResponseInner, cancellationToken);
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
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CancelOrderResponse>> CancelOrderAsync(CancelOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/fapi/v1/order", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CancelOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderId", request.OrderId);
        r.Query("origClientOrderId", request.OrigClientOrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.CancelOrderResponse, cancellationToken);
    }

    /// <summary>Change Initial Leverage (TRADE)</summary>
    /// <remarks>
    /// <para>Change user's initial leverage of specific symbol market.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ChangeInitialLeverageResponse>> ChangeInitialLeverageAsync(ChangeInitialLeverageRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/fapi/v1/leverage", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<ChangeInitialLeverageResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("leverage", request.Leverage);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.ChangeInitialLeverageResponse, cancellationToken);
    }

    /// <summary>Change Margin Type (TRADE)</summary>
    /// <remarks>
    /// <para>Change symbol level margin type</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ChangeMarginTypeResponse>> ChangeMarginTypeAsync(ChangeMarginTypeRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/fapi/v1/marginType", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<ChangeMarginTypeResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("marginType", request.MarginType);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.ChangeMarginTypeResponse, cancellationToken);
    }

    /// <summary>Change Multi-Assets Mode (TRADE)</summary>
    /// <remarks>
    /// <para>Change user's Multi-Assets mode (Multi-Assets Mode or Single-Asset Mode) on Every symbol</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ChangeMultiAssetsModeResponse>> ChangeMultiAssetsModeAsync(ChangeMultiAssetsModeRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/fapi/v1/multiAssetsMargin", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<ChangeMultiAssetsModeResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("multiAssetsMargin", request.MultiAssetsMargin);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.ChangeMultiAssetsModeResponse, cancellationToken);
    }

    /// <summary>Change Position Mode (TRADE)</summary>
    /// <remarks>
    /// <para>Change user's position mode (Hedge Mode or One-way Mode ) on EVERY symbol.</para>
    /// <para>
    /// After CM migration, UM and CM share the same dualSidePosition setting. Calling this endpoint flips
    /// both UM and CM at once. If either side has any open order or open position, the change is rejected:
    /// </para>
    /// <para>- -4067 (open orders exist)</para>
    /// <para>- -4068 (open position exists)</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ChangePositionModeResponse>> ChangePositionModeAsync(ChangePositionModeRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/fapi/v1/positionSide/dual", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<ChangePositionModeResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("dualSidePosition", request.DualSidePosition);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.ChangePositionModeResponse, cancellationToken);
    }

    /// <summary>Current All Algo Open Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Get all open algo (conditional) orders on a symbol, including TP/SL (Take Profit / Stop Loss) and
    /// trailing stop orders on USD-M Futures.
    /// </para>
    /// <para>Weight: 1 for a single symbol; 40 when the symbol parameter is omitted</para>
    /// <para>Careful when accessing this with no symbol.</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If the symbol is not sent, orders for all symbols will be returned in an array.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<CurrentAllAlgoOpenOrdersResponseInner>>> CurrentAllAlgoOpenOrdersAsync(CurrentAllAlgoOpenOrdersRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v1/openAlgoOrders", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("algoType", request.AlgoType);
        r.Query("symbol", request.Symbol);
        r.Query("algoId", request.AlgoId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.ListCurrentAllAlgoOpenOrdersResponseInner, cancellationToken);
    }

    /// <summary>Current All Open Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get all open orders on a symbol.</para>
    /// <para>Weight: 1 for a single symbol; 40 when the symbol parameter is omitted</para>
    /// <para>Careful when accessing this with no symbol.</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If the symbol is not sent, orders for all symbols will be returned in an array.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<CurrentAllOpenOrdersResponseInner>>> CurrentAllOpenOrdersAsync(CurrentAllOpenOrdersRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v1/openOrders", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.ListCurrentAllOpenOrdersResponseInner, cancellationToken);
    }

    /// <summary>Futures TradFi Perps Contract (USER_DATA)</summary>
    /// <remarks>
    /// <para>Sign TradFi-Perps agreement contract</para>
    /// <para>Weight(IP): 50</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<FuturesTradfiPerpsContractResponse>> FuturesTradfiPerpsContractAsync(FuturesTradfiPerpsContractRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/fapi/v1/stock/contract", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.FuturesTradfiPerpsContractResponse, cancellationToken);
    }

    /// <summary>Get Order Modify History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get order modification history</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Either orderId or origClientOrderId must be sent, and the</para>
    /// <para>orderId will prevail if both are sent.</para>
    /// <para>- Order modify history longer than 3 month is not avaliable</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<GetOrderModifyHistoryResponseInner>>> GetOrderModifyHistoryAsync(GetOrderModifyHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v1/orderAmendment", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<GetOrderModifyHistoryResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderId", request.OrderId);
        r.Query("origClientOrderId", request.OrigClientOrderId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.ListGetOrderModifyHistoryResponseInner, cancellationToken);
    }

    /// <summary>Get Position Margin Change History (TRADE)</summary>
    /// <remarks>
    /// <para>Get Position Margin Change History</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Support querying future histories that are not older than 30 days</para>
    /// <para>- The time between startTime and endTimecan't be more than 30 days</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<GetPositionMarginChangeHistoryResponseInner>>> GetPositionMarginChangeHistoryAsync(GetPositionMarginChangeHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v1/positionMargin/history", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<GetPositionMarginChangeHistoryResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("type", request.Type);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.ListGetPositionMarginChangeHistoryResponseInner, cancellationToken);
    }

    /// <summary>Modify Isolated Position Margin (TRADE)</summary>
    /// <remarks>
    /// <para>Modify Isolated Position Margin</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Only for isolated symbol</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ModifyIsolatedPositionMarginResponse>> ModifyIsolatedPositionMarginAsync(ModifyIsolatedPositionMarginRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/fapi/v1/positionMargin", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<ModifyIsolatedPositionMarginResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("amount", request.Amount);
        r.Query("type", request.Type);
        r.Query("positionSide", request.PositionSide);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.ModifyIsolatedPositionMarginResponse, cancellationToken);
    }

    /// <summary>Modify Multiple Orders (TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Weight: 5 on 10s order rate limit(X-MBX-ORDER-COUNT-10S); 1 on 1min order rate
    /// limit(X-MBX-ORDER-COUNT-1M); 5 on IP rate limit(x-mbx-used-weight-1m);
    /// </para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Parameter rules are same with Modify Order</para>
    /// <para>- Batch modify orders are processed concurrently, and the order of matching is not guaranteed.</para>
    /// <para>- The order of returned contents for batch modify orders is the same as the order of the order list.</para>
    /// <para>- One order can only be modfied for less than 10000 times</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<ModifyMultipleOrdersResponseInner>>> ModifyMultipleOrdersAsync(ModifyMultipleOrdersRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("PUT", "/fapi/v1/batchOrders", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<ModifyMultipleOrdersResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("batchOrders", Wire.Json(request.BatchOrders, DerivativesTradingUsdsFuturesRestApiJson.Default.ListModifyMultipleOrdersBatchOrdersParameterInner));
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.ListModifyMultipleOrdersResponseInner, cancellationToken);
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
    /// <para>- Both quantity and price must be sent, which is different from dapi modify order endpoint.</para>
    /// <para>
    /// - When the new quantity or price doesn't satisfy PRICE_FILTER / PERCENT_FILTER / LOT_SIZE, amendment
    /// will be rejected and the order will stay as it is.
    /// </para>
    /// <para>- However the order will be cancelled by the amendment in the following situations:</para>
    /// <para>- when the order is in partially filled status and the new quantity &lt;= executedQty</para>
    /// <para>- When the order is GTX and the new price will cause it to be executed immediately</para>
    /// <para>- One order can only be modfied for less than 10000 times</para>
    /// <para>- reduceOnly behavior:</para>
    /// <para>- false or omitted: behave as today — min_notional is enforced on the modified order.</para>
    /// <para>
    /// - true and the original order's reduceOnly attribute is also true (consistent): the min_notional
    /// check is skipped on the modified order, matching placement semantics.
    /// </para>
    /// <para>
    /// - true but the original order's reduceOnly attribute is false (inconsistent): the modify request is
    /// rejected with error code -5047, "The original order is not a reduce-only order".
    /// </para>
    /// <para>
    /// - reduceOnly is used purely for validation — passing true does not change the original order's
    /// reduceOnly attribute; that flag remains whatever it was set to at placement time.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ModifyOrderResponse>> ModifyOrderAsync(ModifyOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("PUT", "/fapi/v1/order", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<ModifyOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("side", request.Side);
        r.Query("quantity", request.Quantity);
        r.Query("price", request.Price);
        r.Query("orderId", request.OrderId);
        r.Query("origClientOrderId", request.OrigClientOrderId);
        r.Query("priceMatch", request.PriceMatch);
        r.Query("modifyId", request.ModifyId);
        r.Query("reduceOnly", request.ReduceOnly);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.ModifyOrderResponse, cancellationToken);
    }

    /// <summary>New Algo Order (TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Send in a new algo (conditional) order. Use this endpoint to place TP/SL (Take Profit / Stop Loss)
    /// and trailing stop orders on USD-M Futures. Supported order types under algoType=CONDITIONAL are
    /// STOP_MARKET, TAKE_PROFIT_MARKET, STOP, TAKE_PROFIT, and TRAILING_STOP_MARKET.
    /// </para>
    /// <para>
    /// Weight: 1 on 10s order rate limit(X-MBX-ORDER-COUNT-10S); 1 on 1min order rate
    /// limit(X-MBX-ORDER-COUNT-1M); 0 on IP rate limit(x-mbx-used-weight-1m)
    /// </para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Algo order with type STOP, parameter timeInForce can be sent (default GTC).</para>
    /// <para>- Algo order with type TAKE_PROFIT, parameter timeInForce can be sent ( default GTC).</para>
    /// <para>- Condition orders will be triggered when:</para>
    /// <para>- If parameterpriceProtectis sent as true:</para>
    /// <para>
    /// - when price reaches the triggerPrice ，the difference rate between "MARK_PRICE" and "CONTRACT_PRICE"
    /// cannot be larger than the "triggerProtect" of the symbol
    /// </para>
    /// <para>- "triggerProtect" of a symbol can be got from GET /fapi/v1/exchangeInfo</para>
    /// <para>- STOP, STOP_MARKET:</para>
    /// <para>- BUY: latest price ("MARK_PRICE" or "CONTRACT_PRICE") &gt;= triggerPrice</para>
    /// <para>- SELL: latest price ("MARK_PRICE" or "CONTRACT_PRICE") &lt;= triggerPrice</para>
    /// <para>- TAKE_PROFIT, TAKE_PROFIT_MARKET:</para>
    /// <para>- BUY: latest price ("MARK_PRICE" or "CONTRACT_PRICE") &lt;= triggerPrice</para>
    /// <para>- SELL: latest price ("MARK_PRICE" or "CONTRACT_PRICE") &gt;= triggerPrice</para>
    /// <para>- TRAILING_STOP_MARKET:</para>
    /// <para>
    /// - BUY: the lowest price after order placed &lt;= activatePrice, and the latest price &gt;= the
    /// lowest price * (1 + callbackRate)
    /// </para>
    /// <para>
    /// - SELL: the highest price after order placed &gt;= activatePrice, and the latest price &lt;= the
    /// highest price * (1 - callbackRate)
    /// </para>
    /// <para>
    /// - For TRAILING_STOP_MARKET, if you got such error code. &gt; {"code": -2021, "msg": "Order would
    /// immediately trigger."} &gt; means that the parameters you send do not meet the following
    /// requirements:
    /// </para>
    /// <para>- BUY: activatePrice should be smaller than latest price.</para>
    /// <para>- SELL: activatePrice should be larger than latest price.</para>
    /// <para>- STOP_MARKET, TAKE_PROFIT_MARKET with closePosition=true:</para>
    /// <para>- Follow the same rules for condition orders.</para>
    /// <para>- If triggered，close all current long position( if SELL) or current short position( if BUY).</para>
    /// <para>- Cannot be used with quantity paremeter</para>
    /// <para>- Cannot be used with reduceOnly parameter</para>
    /// <para>
    /// - In Hedge Mode,cannot be used with BUY orders in LONG position side. and cannot be used with SELL
    /// orders in SHORT position side
    /// </para>
    /// <para>- selfTradePreventionMode is only effective when timeInForce set to IOC or GTC or GTD.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<NewAlgoOrderResponse>> NewAlgoOrderAsync(NewAlgoOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/fapi/v1/algoOrder", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<NewAlgoOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("algoType", request.AlgoType);
        r.Query("symbol", request.Symbol);
        r.Query("side", request.Side);
        r.Query("type", request.Type);
        r.Query("positionSide", request.PositionSide);
        r.Query("timeInForce", request.TimeInForce);
        r.Query("quantity", request.Quantity);
        r.Query("price", request.Price);
        r.Query("triggerPrice", request.TriggerPrice);
        r.Query("workingType", request.WorkingType);
        r.Query("priceMatch", request.PriceMatch);
        r.Query("closePosition", request.ClosePosition);
        r.Query("priceProtect", request.PriceProtect);
        r.Query("reduceOnly", request.ReduceOnly);
        r.Query("activatePrice", request.ActivatePrice);
        r.Query("callbackRate", request.CallbackRate);
        r.Query("clientAlgoId", request.ClientAlgoId);
        r.Query("newOrderRespType", request.NewOrderRespType);
        r.Query("selfTradePreventionMode", request.SelfTradePreventionMode);
        r.Query("goodTillDate", request.GoodTillDate);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.NewAlgoOrderResponse, cancellationToken);
    }

    /// <summary>New Order (TRADE)</summary>
    /// <remarks>
    /// <para>Send in a new order.</para>
    /// <para>
    /// Weight: 1 on 10s order rate limit(X-MBX-ORDER-COUNT-10S); 1 on 1min order rate
    /// limit(X-MBX-ORDER-COUNT-1M); 0 on IP rate limit(x-mbx-used-weight-1m)
    /// </para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes: Additional mandatory parameters based on type:</para>
    /// <para>| Type | Additional mandatory parameters |</para>
    /// <para>| LIMIT | timeInForce, quantity, price |</para>
    /// <para>| MARKET | quantity |</para>
    /// <para>- If newOrderRespType is sent as RESULT:</para>
    /// <para>- MARKET order: the final FILLED result of the order will be returned directly.</para>
    /// <para>
    /// - LIMIT order with special timeInForce: the final status result of the order (FILLED or EXPIRED)
    /// will be returned directly.
    /// </para>
    /// <para>- selfTradePreventionMode is only effective when timeInForce is set to IOC, GTC, or GTD.</para>
    /// <para>
    /// - In extreme market conditions, timeInForce GTD order auto-cancel time might be delayed compared to
    /// goodTillDate.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<NewOrderResponse>> NewOrderAsync(NewOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/fapi/v1/order", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<NewOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("side", request.Side);
        r.Query("type", request.Type);
        r.Query("positionSide", request.PositionSide);
        r.Query("timeInForce", request.TimeInForce);
        r.Query("reduceOnly", request.ReduceOnly);
        r.Query("quantity", request.Quantity);
        r.Query("price", request.Price);
        r.Query("newClientOrderId", request.NewClientOrderId);
        r.Query("newOrderRespType", request.NewOrderRespType);
        r.Query("priceMatch", request.PriceMatch);
        r.Query("selfTradePreventionMode", request.SelfTradePreventionMode);
        r.Query("goodTillDate", request.GoodTillDate);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.NewOrderResponse, cancellationToken);
    }

    /// <summary>Place Multiple Orders (TRADE)</summary>
    /// <remarks>
    /// <para>Place Multiple Orders</para>
    /// <para>
    /// Weight: 5 on 10s order rate limit(X-MBX-ORDER-COUNT-10S); 1 on 1min order rate
    /// limit(X-MBX-ORDER-COUNT-1M); 5 on IP rate limit(x-mbx-used-weight-1m);
    /// </para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Paremeter rules are same with New Order</para>
    /// <para>- Batch orders are processed concurrently, and the order of matching is not guaranteed.</para>
    /// <para>- The order of returned contents for batch orders is the same as the order of the order list.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<PlaceMultipleOrdersResponseInner>>> PlaceMultipleOrdersAsync(PlaceMultipleOrdersRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/fapi/v1/batchOrders", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<PlaceMultipleOrdersResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("batchOrders", Wire.Json(request.BatchOrders, DerivativesTradingUsdsFuturesRestApiJson.Default.ListPlaceMultipleOrdersBatchOrdersParameterInner));
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.ListPlaceMultipleOrdersResponseInner, cancellationToken);
    }

    /// <summary>Position ADL Quantile Estimation (USER_DATA)</summary>
    /// <remarks>
    /// <para>Position ADL Quantile Estimation</para>
    /// <para>- Values update every 30s.</para>
    /// <para>- Values 0, 1, 2, 3, 4 shows the queue position and possibility of ADL from low to high.</para>
    /// <para>
    /// - For positions of the symbol are in One-way Mode or isolated margined in Hedge Mode, "LONG",
    /// "SHORT", and "BOTH" will be returned to show the positions' adl quantiles of different position
    /// sides.
    /// </para>
    /// <para>- If the positions of the symbol are crossed margined in Hedge Mode:</para>
    /// <para>- "HEDGE" as a sign will be returned instead of "BOTH";</para>
    /// <para>
    /// - A same value caculated on unrealized pnls on long and short sides' positions will be shown for
    /// "LONG" and "SHORT" when there are positions in both of long and short sides.
    /// </para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<PositionAdlQuantileEstimationResponseInner>>> PositionAdlQuantileEstimationAsync(PositionAdlQuantileEstimationRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v1/adlQuantile", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.ListPositionAdlQuantileEstimationResponseInner, cancellationToken);
    }

    /// <summary>Position Information V2 (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get current position information.</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Please use with user data stream ACCOUNT_UPDATE to meet your timeliness and accuracy needs.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<PositionInformationV2ResponseInner>>> PositionInformationV2Async(PositionInformationV2Request? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v2/positionRisk", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.ListPositionInformationV2ResponseInner, cancellationToken);
    }

    /// <summary>Position Information V3 (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get current position information(only symbol that has position or open orders will be returned).</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Please use with user data stream ACCOUNT_UPDATE to meet your timeliness and accuracy needs.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<PositionInformationV3ResponseInner>>> PositionInformationV3Async(PositionInformationV3Request? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v3/positionRisk", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.ListPositionInformationV3ResponseInner, cancellationToken);
    }

    /// <summary>Query Algo Order (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Check the status of an algo (conditional) order, such as TP/SL (Take Profit / Stop Loss) or trailing
    /// stop orders on USD-M Futures.
    /// </para>
    /// <para>- These orders will not be found:</para>
    /// <para>
    /// - order status is CANCELED or EXPIRED AND order has NO filled trade AND created time + 3 days &lt;
    /// current time
    /// </para>
    /// <para>- order create time + 90 days &lt; current time</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Either algoId or clientAlgoId must be sent.</para>
    /// <para>- algoId is self-increment for each specific symbol</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryAlgoOrderResponse>> QueryAlgoOrderAsync(QueryAlgoOrderRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v1/algoOrder", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("algoId", request.AlgoId);
        r.Query("clientAlgoId", request.ClientAlgoId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.QueryAlgoOrderResponse, cancellationToken);
    }

    /// <summary>Query All Algo Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Get all algo (conditional) orders — active, CANCELED, TRIGGERED, or FINISHED — including TP/SL (Take
    /// Profit / Stop Loss) and trailing stop orders on USD-M Futures.
    /// </para>
    /// <para>- These orders will not be found:</para>
    /// <para>
    /// - order status is CANCELED or EXPIRED AND order has NO filled trade AND created time + 3 days &lt;
    /// current time
    /// </para>
    /// <para>- order create time + 90 days &lt; current time</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If algoId is set, it will get orders &gt;= that algoId. Otherwise most recent orders are returned.</para>
    /// <para>- The query time period must be less then 7 days( default as the recent 7 days).</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryAllAlgoOrdersResponseInner>>> QueryAllAlgoOrdersAsync(QueryAllAlgoOrdersRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v1/allAlgoOrders", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<QueryAllAlgoOrdersResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("algoId", request.AlgoId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.ListQueryAllAlgoOrdersResponseInner, cancellationToken);
    }

    /// <summary>Query Current Open Order (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query open order</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- EitherorderId or origClientOrderId must be sent</para>
    /// <para>
    /// - If the queried order has been filled or cancelled, the error message "Order does not exist" will
    /// be returned.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryCurrentOpenOrderResponse>> QueryCurrentOpenOrderAsync(QueryCurrentOpenOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v1/openOrder", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryCurrentOpenOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderId", request.OrderId);
        r.Query("origClientOrderId", request.OrigClientOrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.QueryCurrentOpenOrderResponse, cancellationToken);
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
    /// <para>- orderId is self-increment for each specific symbol</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryOrderResponse>> QueryOrderAsync(QueryOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v1/order", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderId", request.OrderId);
        r.Query("origClientOrderId", request.OrigClientOrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.QueryOrderResponse, cancellationToken);
    }

    /// <summary>Test Order (TRADE)</summary>
    /// <remarks>
    /// <para>Testing order request, this order will not be submitted to matching engine</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes: Additional mandatory parameters based on type:</para>
    /// <para>| Type | Additional mandatory parameters |</para>
    /// <para>| LIMIT | timeInForce, quantity, price |</para>
    /// <para>| MARKET | quantity |</para>
    /// <para>| STOP/TAKE_PROFIT | quantity, price, stopPrice |</para>
    /// <para>| STOP_MARKET/TAKE_PROFIT_MARKET | stopPrice |</para>
    /// <para>| TRAILING_STOP_MARKET | callbackRate |</para>
    /// <para>- Order with type STOP, parameter timeInForce can be sent ( default GTC).</para>
    /// <para>- Order with type TAKE_PROFIT, parameter timeInForce can be sent (default GTC).</para>
    /// <para>- Condition orders will be triggered when:</para>
    /// <para>- If parameterpriceProtectis sent as true:</para>
    /// <para>
    /// - when price reaches the stopPrice ，the difference rate between "MARK_PRICE" and "CONTRACT_PRICE"
    /// cannot be larger than the "triggerProtect" of the symbol
    /// </para>
    /// <para>- "triggerProtect" of a symbol can be got from GET /fapi/v1/exchangeInfo</para>
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
    /// <para>
    /// - For TRAILING_STOP_MARKET, if you got such error code. &gt; {"code": -2021, "msg": "Order would
    /// immediately trigger."} &gt; means that the parameters you send do not meet the following
    /// requirements:
    /// </para>
    /// <para>- BUY: activationPrice should be smaller than latest price.</para>
    /// <para>- SELL: activationPrice should be larger than latest price.</para>
    /// <para>- If newOrderRespType is sent as RESULT :</para>
    /// <para>- MARKET order: the final FILLED result of the order will be return directly.</para>
    /// <para>
    /// - LIMIT order with special timeInForce: the final status result of the order(FILLED or EXPIRED) will
    /// be returned directly.
    /// </para>
    /// <para>- STOP_MARKET, TAKE_PROFIT_MARKET with closePosition=true:</para>
    /// <para>- Follow the same rules for condition orders.</para>
    /// <para>- If triggered，close all current long position( if SELL) or current short position( if BUY).</para>
    /// <para>- Cannot be used with quantity paremeter</para>
    /// <para>- Cannot be used with reduceOnly parameter</para>
    /// <para>
    /// - In Hedge Mode,cannot be used with BUY orders in LONG position side. and cannot be used with SELL
    /// orders in SHORT position side
    /// </para>
    /// <para>- selfTradePreventionMode is only effective when timeInForce set to IOC or GTC or GTD.</para>
    /// <para>
    /// - In extreme market conditions, timeInForce GTD order auto cancel time might be delayed comparing to
    /// goodTillDate
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<TestOrderResponse>> TestOrderAsync(TestOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/fapi/v1/order/test", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<TestOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("side", request.Side);
        r.Query("type", request.Type);
        r.Query("positionSide", request.PositionSide);
        r.Query("reduceOnly", request.ReduceOnly);
        r.Query("quantity", request.Quantity);
        r.Query("price", request.Price);
        r.Query("newClientOrderId", request.NewClientOrderId);
        r.Query("stopPrice", request.StopPrice);
        r.Query("closePosition", request.ClosePosition);
        r.Query("activationPrice", request.ActivationPrice);
        r.Query("callbackRate", request.CallbackRate);
        r.Query("timeInForce", request.TimeInForce);
        r.Query("workingType", request.WorkingType);
        r.Query("priceProtect", request.PriceProtect);
        r.Query("newOrderRespType", request.NewOrderRespType);
        r.Query("priceMatch", request.PriceMatch);
        r.Query("selfTradePreventionMode", request.SelfTradePreventionMode);
        r.Query("goodTillDate", request.GoodTillDate);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.TestOrderResponse, cancellationToken);
    }

    /// <summary>User's Force Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query user's Force Orders</para>
    /// <para>Weight: 20 with symbol, 50 without symbol</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If "autoCloseType" is not sent, orders with both of the types will be returned</para>
    /// <para>- If "startTime" is not sent, data within 7 days before "endTime" can be queried</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<UsersForceOrdersResponseInner>>> UsersForceOrdersAsync(UsersForceOrdersRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v1/forceOrders", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("autoCloseType", request.AutoCloseType);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.ListUsersForceOrdersResponseInner, cancellationToken);
    }
}
