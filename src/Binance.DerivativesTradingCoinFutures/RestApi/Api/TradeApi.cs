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

public sealed class AccountTradeListRequest
{
    /// <summary>Symbol</summary>
    public string? Symbol { get; init; }

    /// <summary>pair</summary>
    public string? Pair { get; init; }

    /// <summary>Order ID</summary>
    public string? OrderId { get; init; }

    /// <summary>Start time</summary>
    public long? StartTime { get; init; }

    /// <summary>End time</summary>
    public long? EndTime { get; init; }

    /// <summary>Trade id to fetch from. Default gets most recent trades.</summary>
    public long? FromId { get; init; }

    /// <summary>Maximum number of records to return.</summary>
    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class AllOrdersRequest
{
    /// <summary>Symbol</summary>
    public string? Symbol { get; init; }

    /// <summary>Pair</summary>
    public string? Pair { get; init; }

    public long? OrderId { get; init; }

    /// <summary>Start time</summary>
    public long? StartTime { get; init; }

    /// <summary>End time</summary>
    public long? EndTime { get; init; }

    /// <summary>Maximum number of records to return.</summary>
    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class AutoCancelAllOpenOrdersRequest
{
    public required string Symbol { get; init; }

    /// <summary>countdown time, 1000 for 1 second. 0 to cancel the timer</summary>
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
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class CancelMultipleOrdersRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    /// <summary>Order IDs to cancel.</summary>
    public List<long>? OrderIdList { get; init; }

    /// <summary>Original client order IDs to cancel.</summary>
    public List<string>? OrigClientOrderIdList { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class CancelOrderRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    /// <summary>Order ID</summary>
    public long? OrderId { get; init; }

    /// <summary>Client order ID</summary>
    public string? OrigClientOrderId { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class ChangeInitialLeverageRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    /// <summary>target initial leverage: int from 1 to 125</summary>
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
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    public required ChangeMarginTypeMarginType MarginType { get; init; }

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
    /// <summary>
    /// Symbol. After CM migration, an invalid symbol returns -1121 (previously a silent 200).
    /// </summary>
    public string? Symbol { get; init; }

    /// <summary>Pair</summary>
    public string? Pair { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetOrderModifyHistoryRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    /// <summary>Order ID</summary>
    public long? OrderId { get; init; }

    /// <summary>Client order ID</summary>
    public string? OrigClientOrderId { get; init; }

    /// <summary>Timestamp in ms to get modification history from INCLUSIVE</summary>
    public long? StartTime { get; init; }

    /// <summary>Timestamp in ms to get modification history until INCLUSIVE</summary>
    public long? EndTime { get; init; }

    /// <summary>Maximum number of records to return.</summary>
    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetPositionMarginChangeHistoryRequest
{
    public required string Symbol { get; init; }

    /// <summary>1: Add position margin,2: Reduce position margin</summary>
    public long? Type { get; init; }

    /// <summary>Start time</summary>
    public long? StartTime { get; init; }

    /// <summary>End time</summary>
    public long? EndTime { get; init; }

    /// <summary>Maximum number of records to return.</summary>
    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<ModifyIsolatedPositionMarginPositionSide>))]
public readonly struct ModifyIsolatedPositionMarginPositionSide : IExtensibleValue<ModifyIsolatedPositionMarginPositionSide>, IEquatable<ModifyIsolatedPositionMarginPositionSide>
{
    private readonly string? _value;

    public ModifyIsolatedPositionMarginPositionSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static ModifyIsolatedPositionMarginPositionSide Both { get; } = new("BOTH");

    public static ModifyIsolatedPositionMarginPositionSide Long { get; } = new("LONG");

    public static ModifyIsolatedPositionMarginPositionSide Short { get; } = new("SHORT");

    static ModifyIsolatedPositionMarginPositionSide IExtensibleValue<ModifyIsolatedPositionMarginPositionSide>.Create(string value) => new(value);

    public static bool operator ==(ModifyIsolatedPositionMarginPositionSide left, ModifyIsolatedPositionMarginPositionSide right) => left.Equals(right);

    public static bool operator !=(ModifyIsolatedPositionMarginPositionSide left, ModifyIsolatedPositionMarginPositionSide right) => !left.Equals(right);

    public static implicit operator ModifyIsolatedPositionMarginPositionSide(string value) => new(value);

    public static ModifyIsolatedPositionMarginPositionSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ModifyIsolatedPositionMarginPositionSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ModifyIsolatedPositionMarginPositionSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class ModifyIsolatedPositionMarginRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    /// <summary>Margin asset</summary>
    public required decimal Amount { get; init; }

    /// <summary>1: Add position margin,2: Reduce position margin</summary>
    public required long Type { get; init; }

    /// <summary>
    /// Default BOTH for One-way Mode ; LONG or SHORT for Hedge Mode. It must be sent with Hedge Mode.
    /// </summary>
    public ModifyIsolatedPositionMarginPositionSide? PositionSide { get; init; }

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

public sealed class ModifyOrderRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    public required ModifyOrderSide Side { get; init; }

    /// <summary>Order ID</summary>
    public long? OrderId { get; init; }

    /// <summary>Client order ID</summary>
    public string? OrigClientOrderId { get; init; }

    /// <summary>
    /// Order quantity, cannot be sent with closePosition=true. After CM migration, this parameter becomes
    /// mandatory (must be sent together with price).
    /// </summary>
    public decimal? Quantity { get; init; }

    /// <summary>
    /// Order price. After CM migration, this parameter becomes mandatory (must be sent together with
    /// quantity).
    /// </summary>
    public decimal? Price { get; init; }

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

    /// <summary>
    /// quantity measured by contract number, Cannot be sent with closePosition=true(Close-All)
    /// </summary>
    public decimal? Quantity { get; init; }

    public decimal? Price { get; init; }

    /// <summary>Trigger price</summary>
    public decimal? TriggerPrice { get; init; }

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

    public NewAlgoOrderNewOrderRespType? NewOrderRespType { get; init; }

    /// <summary>
    /// EXPIRE_TAKER: expire taker order when STP triggers / EXPIRE_MAKER: expire maker order when STP
    /// triggers/ EXPIRE_BOTH: expire both orders when STP triggers; default NONE
    /// </summary>
    public NewAlgoOrderSelfTradePreventionMode? SelfTradePreventionMode { get; init; }

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
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    public required NewOrderSide Side { get; init; }

    /// <summary>
    /// After CM migration, stop-type values (STOP, STOP_MARKET, TAKE_PROFIT, TAKE_PROFIT_MARKET,
    /// TRAILING_STOP_MARKET) are no longer accepted by this endpoint and will return -4120. Use the new
    /// /dapi/v1/algoOrder endpoint instead.
    /// </summary>
    public required NewOrderType Type { get; init; }

    /// <summary>
    /// Default BOTH for One-way Mode ; LONG or SHORT for Hedge Mode. It must be sent in Hedge Mode.
    /// </summary>
    public NewOrderPositionSide? PositionSide { get; init; }

    /// <summary>
    /// "true" or "false". Cannot be sent in Hedge Mode; cannot be sent with closePosition=true(Close-All)
    /// </summary>
    public NewOrderReduceOnly? ReduceOnly { get; init; }

    /// <summary>quantity measured by contract number, Cannot be sent with closePosition=true</summary>
    public decimal? Quantity { get; init; }

    /// <summary>Order price</summary>
    public decimal? Price { get; init; }

    /// <summary>
    /// A unique id among open orders. Automatically generated if not sent. Can only be string following the
    /// rule: ^[.A-Z\:/a-z0-9_-]{1,36}$
    /// </summary>
    public string? NewClientOrderId { get; init; }

    /// <summary>Used with STOP/STOP_MARKET or TAKE_PROFIT/TAKE_PROFIT_MARKET orders.</summary>
    public decimal? StopPrice { get; init; }

    /// <summary>true, false；Close-All,used with STOP_MARKET or TAKE_PROFIT_MARKET.</summary>
    public string? ClosePosition { get; init; }

    /// <summary>
    /// Used with TRAILING_STOP_MARKET orders, default as the latest price(supporting different workingType)
    /// </summary>
    public decimal? ActivationPrice { get; init; }

    /// <summary>Used with TRAILING_STOP_MARKET orders, min 0.1, max 10 where 1 for 1%</summary>
    public decimal? CallbackRate { get; init; }

    public NewOrderTimeInForce? TimeInForce { get; init; }

    /// <summary>'stopPrice triggered by: "MARK_PRICE", "CONTRACT_PRICE".</summary>
    public NewOrderWorkingType? WorkingType { get; init; }

    /// <summary>
    /// "true" or "false". Used with STOP/STOP_MARKET or TAKE_PROFIT/TAKE_PROFIT_MARKET orders.
    /// </summary>
    public NewOrderPriceProtect? PriceProtect { get; init; }

    public NewOrderNewOrderRespType? NewOrderRespType { get; init; }

    /// <summary>
    /// only avaliable for LIMIT/STOP/TAKE_PROFIT order; Can't be passed together with price
    /// </summary>
    public NewOrderPriceMatch? PriceMatch { get; init; }

    /// <summary>
    /// EXPIRE_TAKER: expire taker order when STP triggers/ EXPIRE_MAKER: expire taker order when STP
    /// triggers/ EXPIRE_BOTH: expire both orders when STP triggers
    /// </summary>
    public NewOrderSelfTradePreventionMode? SelfTradePreventionMode { get; init; }

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

public sealed class PositionInformationRequest
{
    public string? MarginAsset { get; init; }

    public string? Pair { get; init; }

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
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    /// <summary>Order ID</summary>
    public long? OrderId { get; init; }

    /// <summary>Client order ID</summary>
    public string? OrigClientOrderId { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryOrderRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    /// <summary>Order ID</summary>
    public long? OrderId { get; init; }

    /// <summary>Client order ID</summary>
    public string? OrigClientOrderId { get; init; }

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

    public UsersForceOrdersAutoCloseType? AutoCloseType { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Maximum number of records to return.</summary>
    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed partial class DerivativesTradingCoinFuturesRestApi
{

    /// <summary>Account Trade List (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get trades for a specific account and symbol.</para>
    /// <para>Weight: 20 with symbol，40 with pair (after CM migration: 5 flat)</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Either symbol or pair must be sent</para>
    /// <para>- Symbol and pair cannot be sent together</para>
    /// <para>- Pair and fromId cannot be sent together</para>
    /// <para>- OrderId can only be sent together with symbol</para>
    /// <para>- If a pair is sent,tickers for all symbols of the pair will be returned</para>
    /// <para>- The parameter fromId cannot be sent with startTime or endTime</para>
    /// <para>- If startTime and endTime are both not sent, then the last 7 days' data will be returned.</para>
    /// <para>- The time between startTime and endTime cannot be longer than 7 days.</para>
    /// <para>- Only support querying trade in the past 3 months</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<AccountTradeListResponseInner>>> AccountTradeListAsync(AccountTradeListRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/userTrades", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("pair", request.Pair);
        r.Query("orderId", request.OrderId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("fromId", request.FromId);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListAccountTradeListResponseInner, cancellationToken);
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
    /// <para>Weight: 20 with symbol, 40 with pair (after CM migration: 5 flat)</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Either symbol or pair must be sent.</para>
    /// <para>- pair can't be sent with orderId</para>
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
        var r = new RestRequest("GET", "/dapi/v1/allOrders", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("pair", request.Pair);
        r.Query("orderId", request.OrderId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListAllOrdersResponseInner, cancellationToken);
    }

    /// <summary>Auto-Cancel All Open Orders (TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Cancel all open orders of the specified symbol at the end of the specified countdown. This rest
    /// endpoint means to ensure your open orders are canceled in case of an outage. The endpoint should be
    /// called repeatedly as heartbeats so that the existing countdown time can be canceled and repalced by
    /// a new one. The system will check all countdowns approximately every 10 milliseconds, so please note
    /// that sufficient redundancy should be considered when using this function. We do not recommend
    /// setting the countdown time to be too precise or too small.
    /// </para>
    /// <para>- Example usage:</para>
    /// <para>Call this endpoint at 30s intervals with an countdownTime of 120000 (120s).</para>
    /// <para>
    /// If this endpoint is not called within 120 seconds, all your orders of the specified symbol will be
    /// automatically canceled.
    /// </para>
    /// <para>If this endpoint is called with an countdownTime of 0, the countdown timer will be stopped.</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<AutoCancelAllOpenOrdersResponse>> AutoCancelAllOpenOrdersAsync(AutoCancelAllOpenOrdersRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/dapi/v1/countdownCancelAll", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<AutoCancelAllOpenOrdersResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("countdownTime", request.CountdownTime);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.AutoCancelAllOpenOrdersResponse, cancellationToken);
    }

    /// <summary>Cancel Algo Order (TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Cancel an active algo (conditional) order, including TP/SL (Take Profit / Stop Loss) and trailing
    /// stop orders on COIN-M Futures.
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
        var r = new RestRequest("DELETE", "/dapi/v1/algoOrder", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("algoId", request.AlgoId);
        r.Query("clientAlgoId", request.ClientAlgoId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.CancelAlgoOrderResponse, cancellationToken);
    }

    /// <summary>Cancel All Algo Open Orders (TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Cancel all open algo (conditional) orders on a symbol, including TP/SL (Take Profit / Stop Loss) and
    /// trailing stop orders on COIN-M Futures.
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
        var r = new RestRequest("DELETE", "/dapi/v1/algoOpenOrders", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CancelAllAlgoOpenOrdersResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.CancelAllAlgoOpenOrdersResponse, cancellationToken);
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
        var r = new RestRequest("DELETE", "/dapi/v1/allOpenOrders", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CancelAllOpenOrdersResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.CancelAllOpenOrdersResponse, cancellationToken);
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
        var r = new RestRequest("DELETE", "/dapi/v1/batchOrders", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<CancelMultipleOrdersResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderIdList", request.OrderIdList);
        r.Query("origClientOrderIdList", request.OrigClientOrderIdList);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListCancelMultipleOrdersResponseInner, cancellationToken);
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
        var r = new RestRequest("DELETE", "/dapi/v1/order", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CancelOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderId", request.OrderId);
        r.Query("origClientOrderId", request.OrigClientOrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.CancelOrderResponse, cancellationToken);
    }

    /// <summary>Change Initial Leverage (TRADE)</summary>
    /// <remarks>
    /// <para>Change user's initial leverage in the specific symbol market.</para>
    /// <para>
    /// For Hedge Mode, LONG and SHORT positions of one symbol use the same initial leverage and share a
    /// total notional value.
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ChangeInitialLeverageResponse>> ChangeInitialLeverageAsync(ChangeInitialLeverageRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/dapi/v1/leverage", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<ChangeInitialLeverageResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("leverage", request.Leverage);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ChangeInitialLeverageResponse, cancellationToken);
    }

    /// <summary>Change Margin Type (TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Change user's margin type in the specific symbol market.For Hedge Mode, LONG and SHORT positions of
    /// one symbol use the same margin type.
    /// </para>
    /// <para>With ISOLATED margin type, margins of the LONG and SHORT positions are isolated from each other.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ChangeMarginTypeResponse>> ChangeMarginTypeAsync(ChangeMarginTypeRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/dapi/v1/marginType", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<ChangeMarginTypeResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("marginType", request.MarginType);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ChangeMarginTypeResponse, cancellationToken);
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
        var r = new RestRequest("POST", "/dapi/v1/positionSide/dual", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<ChangePositionModeResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("dualSidePosition", request.DualSidePosition);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ChangePositionModeResponse, cancellationToken);
    }

    /// <summary>Current All Algo Open Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Get all open algo (conditional) orders on a symbol, including TP/SL (Take Profit / Stop Loss) and
    /// trailing stop orders on COIN-M Futures.
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
        var r = new RestRequest("GET", "/dapi/v1/openAlgoOrders", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("algoType", request.AlgoType);
        r.Query("symbol", request.Symbol);
        r.Query("algoId", request.AlgoId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListCurrentAllAlgoOpenOrdersResponseInner, cancellationToken);
    }

    /// <summary>Current All Open Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get all open orders on a symbol. Careful when accessing this with no symbol.</para>
    /// <para>Weight(IP): null</para>
    /// <para>Weight: 1 for a single symbol, 40 for mutltiple symbols</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<CurrentAllOpenOrdersResponseInner>>> CurrentAllOpenOrdersAsync(CurrentAllOpenOrdersRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/openOrders", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("pair", request.Pair);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListCurrentAllOpenOrdersResponseInner, cancellationToken);
    }

    /// <summary>Get Order Modify History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get order modification history</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Either orderId or origClientOrderId must be sent, and the orderId will prevail if both are sent.</para>
    /// <para>- Order modify history longer than 3 month is not avaliable</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<GetOrderModifyHistoryResponseInner>>> GetOrderModifyHistoryAsync(GetOrderModifyHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/orderAmendment", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<GetOrderModifyHistoryResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderId", request.OrderId);
        r.Query("origClientOrderId", request.OrigClientOrderId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListGetOrderModifyHistoryResponseInner, cancellationToken);
    }

    /// <summary>Get Position Margin Change History (TRADE)</summary>
    /// <remarks>
    /// <para>Get position margin change history</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<GetPositionMarginChangeHistoryResponseInner>>> GetPositionMarginChangeHistoryAsync(GetPositionMarginChangeHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/positionMargin/history", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<GetPositionMarginChangeHistoryResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("type", request.Type);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListGetPositionMarginChangeHistoryResponseInner, cancellationToken);
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
        var r = new RestRequest("POST", "/dapi/v1/positionMargin", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<ModifyIsolatedPositionMarginResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("amount", request.Amount);
        r.Query("type", request.Type);
        r.Query("positionSide", request.PositionSide);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ModifyIsolatedPositionMarginResponse, cancellationToken);
    }

    /// <summary>Modify Multiple Orders (TRADE)</summary>
    /// <remarks>
    /// <para>Modify Multiple Orders</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Parameter rules are same with Modify Order</para>
    /// <para>- Batch modify orders are processed concurrently, and the order of matching is not guaranteed.</para>
    /// <para>- The order of returned contents for batch modify orders is the same as the order of the order list.</para>
    /// <para>- One order can only be modfied for less than 10000 times</para>
    /// <para>
    /// - modifyId is an optional user-defined identifier passed through as-is; the server does not validate
    /// its uniqueness. If omitted, it is not included in the response.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<ModifyMultipleOrdersResponseInner>>> ModifyMultipleOrdersAsync(ModifyMultipleOrdersRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("PUT", "/dapi/v1/batchOrders", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<ModifyMultipleOrdersResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("batchOrders", Wire.Json(request.BatchOrders, DerivativesTradingCoinFuturesRestApiJson.Default.ListModifyMultipleOrdersBatchOrdersParameterInner));
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListModifyMultipleOrdersResponseInner, cancellationToken);
    }

    /// <summary>Modify Order (TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Order modify function, currently only LIMIT order modification is supported, modified orders will be
    /// reordered in the match queue
    /// </para>
    /// <para>Weight(IP): 0</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Either orderId or origClientOrderId must be sent, and the orderId will prevail if both are sent.</para>
    /// <para>- Either quantity or price must be sent. (After CM migration, both quantity and price are required.)</para>
    /// <para>
    /// - When the new quantity or price doesn't satisfy PRICE_FILTER / PERCENT_FILTER / LOT_SIZE, amendment
    /// will be rejected and the order will stay as it is.
    /// </para>
    /// <para>- However the order will be cancelled by the amendment in the following situations:</para>
    /// <para>- when the order is in partially filled status and the new quantity &lt;= executedQty</para>
    /// <para>- When the order is GTX and the new price will cause it to be executed immediately</para>
    /// <para>- One order can only be modfied for less than 10000 times</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ModifyOrderResponse>> ModifyOrderAsync(ModifyOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("PUT", "/dapi/v1/order", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<ModifyOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("side", request.Side);
        r.Query("orderId", request.OrderId);
        r.Query("origClientOrderId", request.OrigClientOrderId);
        r.Query("quantity", request.Quantity);
        r.Query("price", request.Price);
        r.Query("priceMatch", request.PriceMatch);
        r.Query("modifyId", request.ModifyId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ModifyOrderResponse, cancellationToken);
    }

    /// <summary>New Algo Order (TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Send in a new algo (conditional) order. Use this endpoint to place TP/SL (Take Profit / Stop Loss)
    /// and trailing stop orders on COIN-M Futures. Supported order types under algoType=CONDITIONAL are
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
    /// <para>- "triggerProtect" of a symbol can be got from GET /dapi/v1/exchangeInfo</para>
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
    /// <para>- Cannot be used with quantity parameter</para>
    /// <para>- Cannot be used with reduceOnly parameter</para>
    /// <para>
    /// - In Hedge Mode,cannot be used with BUY orders in LONG position side. and cannot be used with SELL
    /// orders in SHORT position side
    /// </para>
    /// <para>- selfTradePreventionMode is only effective when timeInForce set to IOC or GTC.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<NewAlgoOrderResponse>> NewAlgoOrderAsync(NewAlgoOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/dapi/v1/algoOrder", signed: true, hasTimeUnit: false);
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
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.NewAlgoOrderResponse, cancellationToken);
    }

    /// <summary>New Order (TRADE)</summary>
    /// <remarks>
    /// <para>Send in a new order.</para>
    /// <para>Weight: 1 on 1min order rate limit(X-MBX-ORDER-COUNT-1M) 0 on IP rate limit(x-mbx-used-weight-1m)</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Additional mandatory parameters based on type:</para>
    /// <para>- Order with type STOP, parameter timeInForce can be sent ( default GTC).</para>
    /// <para>- Order with type TAKE_PROFIT, parameter timeInForce can be sent ( default GTC).</para>
    /// <para>- Condition orders will be triggered when:</para>
    /// <para>- If parameterpriceProtectis sent as true:</para>
    /// <para>
    /// - when price reaches the stopPrice ，the difference rate between "MARK_PRICE" and "CONTRACT_PRICE"
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
    /// <para>- If triggered,close all current long position( if SELL) or current short position( if BUY).</para>
    /// <para>- Cannot be used with quantity parameter</para>
    /// <para>- Cannot be used with reduceOnly parameter</para>
    /// <para>
    /// - In Hedge Mode,cannot be used with BUY orders in LONG position side. and cannot be used with SELL
    /// orders in SHORT position side
    /// </para>
    /// <para>- selfTradePreventionMode is only effective when timeInForce set to IOC or GTC.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<NewOrderResponse>> NewOrderAsync(NewOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/dapi/v1/order", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<NewOrderResponse>>(new ArgumentNullException(nameof(request)));
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
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.NewOrderResponse, cancellationToken);
    }

    /// <summary>Place Multiple Orders (TRADE)</summary>
    /// <remarks>
    /// <para>Place multiple orders</para>
    /// <para>- Parameter rules are same with New Order</para>
    /// <para>- Batch orders are processed concurrently, and the order of matching is not guaranteed.</para>
    /// <para>- The order of returned contents for batch orders is the same as the order of the order list.</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- batchOrders must be a JSON array of order parameter objects.</para>
    /// <para>- Example:</para>
    /// <para>/dapi/v1/batchOrders?batchOrders=[{"type":"LIMIT","timeInForce":"GTC","symbol":"BTCUSD_PERP","side":"BUY","price":"10001","quantity":"1"}]</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<PlaceMultipleOrdersResponseInner>>> PlaceMultipleOrdersAsync(PlaceMultipleOrdersRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/dapi/v1/batchOrders", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<PlaceMultipleOrdersResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("batchOrders", Wire.Json(request.BatchOrders, DerivativesTradingCoinFuturesRestApiJson.Default.ListPlaceMultipleOrdersBatchOrdersParameterInner));
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListPlaceMultipleOrdersResponseInner, cancellationToken);
    }

    /// <summary>Position ADL Quantile Estimation (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query position ADL quantile estimation</para>
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
        var r = new RestRequest("GET", "/dapi/v1/adlQuantile", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListPositionAdlQuantileEstimationResponseInner, cancellationToken);
    }

    /// <summary>Position Information (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get current account information.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>
    /// - If neither marginAsset nor pair is sent, positions of all symbols with TRADING status will be
    /// returned.
    /// </para>
    /// <para>- for One-way Mode user, the response will only show the "BOTH" positions</para>
    /// <para>
    /// - for Hedge Mode user, the response will show "BOTH", "LONG", and "SHORT" positions. Note &gt;
    /// Please use with user data stream ACCOUNT_UPDATE to meet your timeliness and accuracy needs.
    /// </para>
    /// <para>- Please use with user data stream ACCOUNT_UPDATE to meet your timeliness and accuracy needs.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<PositionInformationResponseInner>>> PositionInformationAsync(PositionInformationRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/positionRisk", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("marginAsset", request.MarginAsset);
        r.Query("pair", request.Pair);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListPositionInformationResponseInner, cancellationToken);
    }

    /// <summary>Query Algo Order (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Check the status of an algo (conditional) order, such as TP/SL (Take Profit / Stop Loss) or trailing
    /// stop orders on COIN-M Futures.
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
        var r = new RestRequest("GET", "/dapi/v1/algoOrder", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("algoId", request.AlgoId);
        r.Query("clientAlgoId", request.ClientAlgoId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.QueryAlgoOrderResponse, cancellationToken);
    }

    /// <summary>Query All Algo Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Get all algo (conditional) orders — active, CANCELED, TRIGGERED, or FINISHED — including TP/SL (Take
    /// Profit / Stop Loss) and trailing stop orders on COIN-M Futures.
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
    /// <para>- The query time period must be less than 7 days( default as the recent 7 days).</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryAllAlgoOrdersResponseInner>>> QueryAllAlgoOrdersAsync(QueryAllAlgoOrdersRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/allAlgoOrders", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<QueryAllAlgoOrdersResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("algoId", request.AlgoId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListQueryAllAlgoOrdersResponseInner, cancellationToken);
    }

    /// <summary>Query Current Open Order (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Current Open Order</para>
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
        var r = new RestRequest("GET", "/dapi/v1/openOrder", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryCurrentOpenOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderId", request.OrderId);
        r.Query("origClientOrderId", request.OrigClientOrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.QueryCurrentOpenOrderResponse, cancellationToken);
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
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryOrderResponse>> QueryOrderAsync(QueryOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/order", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderId", request.OrderId);
        r.Query("origClientOrderId", request.OrigClientOrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.QueryOrderResponse, cancellationToken);
    }

    /// <summary>User's Force Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>User's Force Orders</para>
    /// <para>Weight: 20 (after CM migration: 20 with symbol / 50 without symbol)</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If "autoCloseType" is not sent, orders with both of the types will be returned</para>
    /// <para>- Only support querying data in the past 90 days</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<UsersForceOrdersResponseInner>>> UsersForceOrdersAsync(UsersForceOrdersRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/dapi/v1/forceOrders", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("autoCloseType", request.AutoCloseType);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.ListUsersForceOrdersResponseInner, cancellationToken);
    }
}
