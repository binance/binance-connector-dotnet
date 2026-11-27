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

public sealed class CancelAllCmOpenConditionalOrdersRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class CancelAllCmOpenOrdersRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class CancelAllUmAlgoOpenOrdersRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class CancelAllUmOpenOrdersRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class CancelCmConditionalOrderRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    public long? StrategyId { get; init; }

    public string? NewClientStrategyId { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class CancelCmOrderRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    public long? OrderId { get; init; }

    public string? OrigClientOrderId { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class CancelMarginAccountAllOpenOrdersOnASymbolRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class CancelMarginAccountOcoOrdersRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    /// <summary>Either orderListId or listClientOrderId must be provided</summary>
    public long? OrderListId { get; init; }

    /// <summary>Either orderListId or listClientOrderId must be provided</summary>
    public string? ListClientOrderId { get; init; }

    /// <summary>Used to uniquely identify this cancel request.</summary>
    public string? NewClientOrderId { get; init; }

    /// <summary>The value cannot be greater than 60000</summary>
    public long? RecvWindow { get; init; }
}

public sealed class CancelMarginAccountOrderRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    public long? OrderId { get; init; }

    public string? OrigClientOrderId { get; init; }

    /// <summary>Used to uniquely identify this cancel request.</summary>
    public string? NewClientOrderId { get; init; }

    /// <summary>The value cannot be greater than 60000</summary>
    public long? RecvWindow { get; init; }
}

public sealed class CancelUmAlgoOrderRequest
{
    /// <summary>Algo order ID</summary>
    public long? AlgoId { get; init; }

    /// <summary>Client algo order ID</summary>
    public string? ClientAlgoId { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class CancelUmOrderRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    public long? OrderId { get; init; }

    public string? OrigClientOrderId { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class CmAccountTradeListRequest
{
    public string? Symbol { get; init; }

    public string? Pair { get; init; }

    /// <summary>Timestamp in ms to get funding from INCLUSIVE.</summary>
    public long? StartTime { get; init; }

    /// <summary>Timestamp in ms to get funding until INCLUSIVE.</summary>
    public long? EndTime { get; init; }

    /// <summary>Trade ID to fetch from.</summary>
    public long? FromId { get; init; }

    /// <summary>Number of results returned.</summary>
    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class CmPositionAdlQuantileEstimationRequest
{
    public string? Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class FuturesTradfiPerpsContractRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class GetUmFuturesBnbBurnStatusRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class MarginAccountBorrowRequest
{
    public required string Asset { get; init; }

    public required decimal Amount { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOcoSide>))]
public readonly struct MarginAccountNewOcoSide : IExtensibleValue<MarginAccountNewOcoSide>, IEquatable<MarginAccountNewOcoSide>
{
    private readonly string? _value;

    public MarginAccountNewOcoSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOcoSide Buy { get; } = new("BUY");

    public static MarginAccountNewOcoSide Sell { get; } = new("SELL");

    static MarginAccountNewOcoSide IExtensibleValue<MarginAccountNewOcoSide>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOcoSide left, MarginAccountNewOcoSide right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOcoSide left, MarginAccountNewOcoSide right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOcoSide(string value) => new(value);

    public static MarginAccountNewOcoSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOcoSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOcoSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOcoStopLimitTimeInForce>))]
public readonly struct MarginAccountNewOcoStopLimitTimeInForce : IExtensibleValue<MarginAccountNewOcoStopLimitTimeInForce>, IEquatable<MarginAccountNewOcoStopLimitTimeInForce>
{
    private readonly string? _value;

    public MarginAccountNewOcoStopLimitTimeInForce(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOcoStopLimitTimeInForce Gtc { get; } = new("GTC");

    public static MarginAccountNewOcoStopLimitTimeInForce Ioc { get; } = new("IOC");

    public static MarginAccountNewOcoStopLimitTimeInForce Fok { get; } = new("FOK");

    static MarginAccountNewOcoStopLimitTimeInForce IExtensibleValue<MarginAccountNewOcoStopLimitTimeInForce>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOcoStopLimitTimeInForce left, MarginAccountNewOcoStopLimitTimeInForce right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOcoStopLimitTimeInForce left, MarginAccountNewOcoStopLimitTimeInForce right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOcoStopLimitTimeInForce(string value) => new(value);

    public static MarginAccountNewOcoStopLimitTimeInForce FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOcoStopLimitTimeInForce other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOcoStopLimitTimeInForce other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOcoNewOrderRespType>))]
public readonly struct MarginAccountNewOcoNewOrderRespType : IExtensibleValue<MarginAccountNewOcoNewOrderRespType>, IEquatable<MarginAccountNewOcoNewOrderRespType>
{
    private readonly string? _value;

    public MarginAccountNewOcoNewOrderRespType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOcoNewOrderRespType Ack { get; } = new("ACK");

    public static MarginAccountNewOcoNewOrderRespType Result { get; } = new("RESULT");

    static MarginAccountNewOcoNewOrderRespType IExtensibleValue<MarginAccountNewOcoNewOrderRespType>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOcoNewOrderRespType left, MarginAccountNewOcoNewOrderRespType right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOcoNewOrderRespType left, MarginAccountNewOcoNewOrderRespType right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOcoNewOrderRespType(string value) => new(value);

    public static MarginAccountNewOcoNewOrderRespType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOcoNewOrderRespType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOcoNewOrderRespType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOcoSideEffectType>))]
public readonly struct MarginAccountNewOcoSideEffectType : IExtensibleValue<MarginAccountNewOcoSideEffectType>, IEquatable<MarginAccountNewOcoSideEffectType>
{
    private readonly string? _value;

    public MarginAccountNewOcoSideEffectType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOcoSideEffectType NoSideEffect { get; } = new("NO_SIDE_EFFECT");

    public static MarginAccountNewOcoSideEffectType MarginBuy { get; } = new("MARGIN_BUY");

    public static MarginAccountNewOcoSideEffectType AutoRepay { get; } = new("AUTO_REPAY");

    static MarginAccountNewOcoSideEffectType IExtensibleValue<MarginAccountNewOcoSideEffectType>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOcoSideEffectType left, MarginAccountNewOcoSideEffectType right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOcoSideEffectType left, MarginAccountNewOcoSideEffectType right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOcoSideEffectType(string value) => new(value);

    public static MarginAccountNewOcoSideEffectType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOcoSideEffectType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOcoSideEffectType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class MarginAccountNewOcoRequest
{
    public required string Symbol { get; init; }

    /// <summary>See enum definitions: order side</summary>
    public required MarginAccountNewOcoSide Side { get; init; }

    public required decimal Quantity { get; init; }

    public required decimal Price { get; init; }

    public required decimal StopPrice { get; init; }

    /// <summary>A unique Id for the entire orderList</summary>
    public string? ListClientOrderId { get; init; }

    /// <summary>A unique Id for the limit order</summary>
    public string? LimitClientOrderId { get; init; }

    public decimal? LimitIcebergQty { get; init; }

    /// <summary>A unique Id for the stop loss/stop loss limit leg</summary>
    public string? StopClientOrderId { get; init; }

    /// <summary>If provided, stopLimitTimeInForce is required.</summary>
    public decimal? StopLimitPrice { get; init; }

    public decimal? StopIcebergQty { get; init; }

    /// <summary>Valid values are GTC/FOK/IOC</summary>
    public MarginAccountNewOcoStopLimitTimeInForce? StopLimitTimeInForce { get; init; }

    /// <summary>Set the response JSON.</summary>
    public MarginAccountNewOcoNewOrderRespType? NewOrderRespType { get; init; }

    /// <summary>NO_SIDE_EFFECT, MARGIN_BUY, AUTO_REPAY; default NO_SIDE_EFFECT.</summary>
    public MarginAccountNewOcoSideEffectType? SideEffectType { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class MarginAccountRepayRequest
{
    public required string Asset { get; init; }

    public required decimal Amount { get; init; }

    /// <summary>The value cannot be greater than 60000</summary>
    public long? RecvWindow { get; init; }
}

public sealed class MarginAccountRepayDebtRequest
{
    public required string Asset { get; init; }

    public string? Amount { get; init; }

    /// <summary>Specific asset list to repay debt; Can be added in batch, separated by commas</summary>
    public string? SpecifyRepayAssets { get; init; }

    /// <summary>The value cannot be greater than 60000</summary>
    public long? RecvWindow { get; init; }
}

public sealed class MarginAccountTradeListRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    public long? OrderId { get; init; }

    /// <summary>Timestamp in ms to get funding from INCLUSIVE.</summary>
    public long? StartTime { get; init; }

    /// <summary>Timestamp in ms to get funding until INCLUSIVE.</summary>
    public long? EndTime { get; init; }

    /// <summary>Trade ID to fetch from.</summary>
    public long? FromId { get; init; }

    /// <summary>Number of results returned.</summary>
    public long? Limit { get; init; }

    /// <summary>Value cannot be greater than 60000</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<ModifyCmOrderSide>))]
public readonly struct ModifyCmOrderSide : IExtensibleValue<ModifyCmOrderSide>, IEquatable<ModifyCmOrderSide>
{
    private readonly string? _value;

    public ModifyCmOrderSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static ModifyCmOrderSide Buy { get; } = new("BUY");

    public static ModifyCmOrderSide Sell { get; } = new("SELL");

    static ModifyCmOrderSide IExtensibleValue<ModifyCmOrderSide>.Create(string value) => new(value);

    public static bool operator ==(ModifyCmOrderSide left, ModifyCmOrderSide right) => left.Equals(right);

    public static bool operator !=(ModifyCmOrderSide left, ModifyCmOrderSide right) => !left.Equals(right);

    public static implicit operator ModifyCmOrderSide(string value) => new(value);

    public static ModifyCmOrderSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ModifyCmOrderSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ModifyCmOrderSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<ModifyCmOrderPriceMatch>))]
public readonly struct ModifyCmOrderPriceMatch : IExtensibleValue<ModifyCmOrderPriceMatch>, IEquatable<ModifyCmOrderPriceMatch>
{
    private readonly string? _value;

    public ModifyCmOrderPriceMatch(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static ModifyCmOrderPriceMatch Opponent { get; } = new("OPPONENT");

    public static ModifyCmOrderPriceMatch Opponent5 { get; } = new("OPPONENT_5");

    public static ModifyCmOrderPriceMatch Opponent10 { get; } = new("OPPONENT_10");

    public static ModifyCmOrderPriceMatch Opponent20 { get; } = new("OPPONENT_20");

    public static ModifyCmOrderPriceMatch Queue { get; } = new("QUEUE");

    public static ModifyCmOrderPriceMatch Queue5 { get; } = new("QUEUE_5");

    public static ModifyCmOrderPriceMatch Queue10 { get; } = new("QUEUE_10");

    public static ModifyCmOrderPriceMatch Queue20 { get; } = new("QUEUE_20");

    static ModifyCmOrderPriceMatch IExtensibleValue<ModifyCmOrderPriceMatch>.Create(string value) => new(value);

    public static bool operator ==(ModifyCmOrderPriceMatch left, ModifyCmOrderPriceMatch right) => left.Equals(right);

    public static bool operator !=(ModifyCmOrderPriceMatch left, ModifyCmOrderPriceMatch right) => !left.Equals(right);

    public static implicit operator ModifyCmOrderPriceMatch(string value) => new(value);

    public static ModifyCmOrderPriceMatch FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ModifyCmOrderPriceMatch other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ModifyCmOrderPriceMatch other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class ModifyCmOrderRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    public required ModifyCmOrderSide Side { get; init; }

    /// <summary>Order quantity</summary>
    public required decimal Quantity { get; init; }

    /// <summary>Order price</summary>
    public required decimal Price { get; init; }

    /// <summary>Order ID</summary>
    public long? OrderId { get; init; }

    /// <summary>Client order ID</summary>
    public string? OrigClientOrderId { get; init; }

    /// <summary>
    /// only avaliable for LIMIT/STOP/TAKE_PROFIT order; can be set to OPPONENT/ OPPONENT_5/ OPPONENT_10/
    /// OPPONENT_20: /QUEUE/ QUEUE_5/ QUEUE_10/ QUEUE_20; Can't be passed together with price
    /// </summary>
    public ModifyCmOrderPriceMatch? PriceMatch { get; init; }

    /// <summary>
    /// User-defined modification identifier, returned as-is in the response. Optional; not validated for
    /// uniqueness.
    /// </summary>
    public long? ModifyId { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<ModifyUmOrderSide>))]
public readonly struct ModifyUmOrderSide : IExtensibleValue<ModifyUmOrderSide>, IEquatable<ModifyUmOrderSide>
{
    private readonly string? _value;

    public ModifyUmOrderSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static ModifyUmOrderSide Buy { get; } = new("BUY");

    public static ModifyUmOrderSide Sell { get; } = new("SELL");

    static ModifyUmOrderSide IExtensibleValue<ModifyUmOrderSide>.Create(string value) => new(value);

    public static bool operator ==(ModifyUmOrderSide left, ModifyUmOrderSide right) => left.Equals(right);

    public static bool operator !=(ModifyUmOrderSide left, ModifyUmOrderSide right) => !left.Equals(right);

    public static implicit operator ModifyUmOrderSide(string value) => new(value);

    public static ModifyUmOrderSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ModifyUmOrderSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ModifyUmOrderSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<ModifyUmOrderPriceMatch>))]
public readonly struct ModifyUmOrderPriceMatch : IExtensibleValue<ModifyUmOrderPriceMatch>, IEquatable<ModifyUmOrderPriceMatch>
{
    private readonly string? _value;

    public ModifyUmOrderPriceMatch(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static ModifyUmOrderPriceMatch Opponent { get; } = new("OPPONENT");

    public static ModifyUmOrderPriceMatch Opponent5 { get; } = new("OPPONENT_5");

    public static ModifyUmOrderPriceMatch Opponent10 { get; } = new("OPPONENT_10");

    public static ModifyUmOrderPriceMatch Opponent20 { get; } = new("OPPONENT_20");

    public static ModifyUmOrderPriceMatch Queue { get; } = new("QUEUE");

    public static ModifyUmOrderPriceMatch Queue5 { get; } = new("QUEUE_5");

    public static ModifyUmOrderPriceMatch Queue10 { get; } = new("QUEUE_10");

    public static ModifyUmOrderPriceMatch Queue20 { get; } = new("QUEUE_20");

    static ModifyUmOrderPriceMatch IExtensibleValue<ModifyUmOrderPriceMatch>.Create(string value) => new(value);

    public static bool operator ==(ModifyUmOrderPriceMatch left, ModifyUmOrderPriceMatch right) => left.Equals(right);

    public static bool operator !=(ModifyUmOrderPriceMatch left, ModifyUmOrderPriceMatch right) => !left.Equals(right);

    public static implicit operator ModifyUmOrderPriceMatch(string value) => new(value);

    public static ModifyUmOrderPriceMatch FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ModifyUmOrderPriceMatch other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ModifyUmOrderPriceMatch other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class ModifyUmOrderRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    public required ModifyUmOrderSide Side { get; init; }

    /// <summary>Order quantity</summary>
    public required decimal Quantity { get; init; }

    /// <summary>Order price</summary>
    public required decimal Price { get; init; }

    /// <summary>Order ID</summary>
    public long? OrderId { get; init; }

    /// <summary>Client order ID</summary>
    public string? OrigClientOrderId { get; init; }

    /// <summary>
    /// only avaliable for LIMIT/STOP/TAKE_PROFIT order; can be set to OPPONENT/ OPPONENT_5/ OPPONENT_10/
    /// OPPONENT_20: /QUEUE/ QUEUE_5/ QUEUE_10/ QUEUE_20; Can't be passed together with price
    /// </summary>
    public ModifyUmOrderPriceMatch? PriceMatch { get; init; }

    /// <summary>
    /// User-defined modification identifier, returned as-is in the response. Optional; not validated for
    /// uniqueness.
    /// </summary>
    public long? ModifyId { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<NewCmConditionalOrderSide>))]
public readonly struct NewCmConditionalOrderSide : IExtensibleValue<NewCmConditionalOrderSide>, IEquatable<NewCmConditionalOrderSide>
{
    private readonly string? _value;

    public NewCmConditionalOrderSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewCmConditionalOrderSide Buy { get; } = new("BUY");

    public static NewCmConditionalOrderSide Sell { get; } = new("SELL");

    static NewCmConditionalOrderSide IExtensibleValue<NewCmConditionalOrderSide>.Create(string value) => new(value);

    public static bool operator ==(NewCmConditionalOrderSide left, NewCmConditionalOrderSide right) => left.Equals(right);

    public static bool operator !=(NewCmConditionalOrderSide left, NewCmConditionalOrderSide right) => !left.Equals(right);

    public static implicit operator NewCmConditionalOrderSide(string value) => new(value);

    public static NewCmConditionalOrderSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewCmConditionalOrderSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewCmConditionalOrderSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewCmConditionalOrderStrategyType>))]
public readonly struct NewCmConditionalOrderStrategyType : IExtensibleValue<NewCmConditionalOrderStrategyType>, IEquatable<NewCmConditionalOrderStrategyType>
{
    private readonly string? _value;

    public NewCmConditionalOrderStrategyType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewCmConditionalOrderStrategyType Stop { get; } = new("STOP");

    public static NewCmConditionalOrderStrategyType StopMarket { get; } = new("STOP_MARKET");

    public static NewCmConditionalOrderStrategyType TakeProfit { get; } = new("TAKE_PROFIT");

    public static NewCmConditionalOrderStrategyType TakeProfitMarket { get; } = new("TAKE_PROFIT_MARKET");

    public static NewCmConditionalOrderStrategyType TrailingStopMarket { get; } = new("TRAILING_STOP_MARKET");

    static NewCmConditionalOrderStrategyType IExtensibleValue<NewCmConditionalOrderStrategyType>.Create(string value) => new(value);

    public static bool operator ==(NewCmConditionalOrderStrategyType left, NewCmConditionalOrderStrategyType right) => left.Equals(right);

    public static bool operator !=(NewCmConditionalOrderStrategyType left, NewCmConditionalOrderStrategyType right) => !left.Equals(right);

    public static implicit operator NewCmConditionalOrderStrategyType(string value) => new(value);

    public static NewCmConditionalOrderStrategyType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewCmConditionalOrderStrategyType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewCmConditionalOrderStrategyType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewCmConditionalOrderPositionSide>))]
public readonly struct NewCmConditionalOrderPositionSide : IExtensibleValue<NewCmConditionalOrderPositionSide>, IEquatable<NewCmConditionalOrderPositionSide>
{
    private readonly string? _value;

    public NewCmConditionalOrderPositionSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewCmConditionalOrderPositionSide Both { get; } = new("BOTH");

    public static NewCmConditionalOrderPositionSide Long { get; } = new("LONG");

    public static NewCmConditionalOrderPositionSide Short { get; } = new("SHORT");

    static NewCmConditionalOrderPositionSide IExtensibleValue<NewCmConditionalOrderPositionSide>.Create(string value) => new(value);

    public static bool operator ==(NewCmConditionalOrderPositionSide left, NewCmConditionalOrderPositionSide right) => left.Equals(right);

    public static bool operator !=(NewCmConditionalOrderPositionSide left, NewCmConditionalOrderPositionSide right) => !left.Equals(right);

    public static implicit operator NewCmConditionalOrderPositionSide(string value) => new(value);

    public static NewCmConditionalOrderPositionSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewCmConditionalOrderPositionSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewCmConditionalOrderPositionSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewCmConditionalOrderTimeInForce>))]
public readonly struct NewCmConditionalOrderTimeInForce : IExtensibleValue<NewCmConditionalOrderTimeInForce>, IEquatable<NewCmConditionalOrderTimeInForce>
{
    private readonly string? _value;

    public NewCmConditionalOrderTimeInForce(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewCmConditionalOrderTimeInForce Gtc { get; } = new("GTC");

    public static NewCmConditionalOrderTimeInForce Ioc { get; } = new("IOC");

    public static NewCmConditionalOrderTimeInForce Fok { get; } = new("FOK");

    public static NewCmConditionalOrderTimeInForce Gtx { get; } = new("GTX");

    static NewCmConditionalOrderTimeInForce IExtensibleValue<NewCmConditionalOrderTimeInForce>.Create(string value) => new(value);

    public static bool operator ==(NewCmConditionalOrderTimeInForce left, NewCmConditionalOrderTimeInForce right) => left.Equals(right);

    public static bool operator !=(NewCmConditionalOrderTimeInForce left, NewCmConditionalOrderTimeInForce right) => !left.Equals(right);

    public static implicit operator NewCmConditionalOrderTimeInForce(string value) => new(value);

    public static NewCmConditionalOrderTimeInForce FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewCmConditionalOrderTimeInForce other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewCmConditionalOrderTimeInForce other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewCmConditionalOrderWorkingType>))]
public readonly struct NewCmConditionalOrderWorkingType : IExtensibleValue<NewCmConditionalOrderWorkingType>, IEquatable<NewCmConditionalOrderWorkingType>
{
    private readonly string? _value;

    public NewCmConditionalOrderWorkingType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewCmConditionalOrderWorkingType MarkPrice { get; } = new("MARK_PRICE");

    public static NewCmConditionalOrderWorkingType ContractPrice { get; } = new("CONTRACT_PRICE");

    static NewCmConditionalOrderWorkingType IExtensibleValue<NewCmConditionalOrderWorkingType>.Create(string value) => new(value);

    public static bool operator ==(NewCmConditionalOrderWorkingType left, NewCmConditionalOrderWorkingType right) => left.Equals(right);

    public static bool operator !=(NewCmConditionalOrderWorkingType left, NewCmConditionalOrderWorkingType right) => !left.Equals(right);

    public static implicit operator NewCmConditionalOrderWorkingType(string value) => new(value);

    public static NewCmConditionalOrderWorkingType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewCmConditionalOrderWorkingType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewCmConditionalOrderWorkingType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewCmConditionalOrderPriceProtect>))]
public readonly struct NewCmConditionalOrderPriceProtect : IExtensibleValue<NewCmConditionalOrderPriceProtect>, IEquatable<NewCmConditionalOrderPriceProtect>
{
    private readonly string? _value;

    public NewCmConditionalOrderPriceProtect(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewCmConditionalOrderPriceProtect True { get; } = new("true");

    public static NewCmConditionalOrderPriceProtect False { get; } = new("false");

    static NewCmConditionalOrderPriceProtect IExtensibleValue<NewCmConditionalOrderPriceProtect>.Create(string value) => new(value);

    public static bool operator ==(NewCmConditionalOrderPriceProtect left, NewCmConditionalOrderPriceProtect right) => left.Equals(right);

    public static bool operator !=(NewCmConditionalOrderPriceProtect left, NewCmConditionalOrderPriceProtect right) => !left.Equals(right);

    public static implicit operator NewCmConditionalOrderPriceProtect(string value) => new(value);

    public static NewCmConditionalOrderPriceProtect FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewCmConditionalOrderPriceProtect other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewCmConditionalOrderPriceProtect other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class NewCmConditionalOrderRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    /// <summary>Side</summary>
    public required NewCmConditionalOrderSide Side { get; init; }

    public required NewCmConditionalOrderStrategyType StrategyType { get; init; }

    /// <summary>
    /// Default BOTH for One-way Mode ; LONG or SHORT for Hedge Mode. It must be sent in Hedge Mode.
    /// </summary>
    public NewCmConditionalOrderPositionSide? PositionSide { get; init; }

    public NewCmConditionalOrderTimeInForce? TimeInForce { get; init; }

    public decimal? Quantity { get; init; }

    /// <summary>"true" or "false". default "false". Cannot be sent in Hedge Mode</summary>
    public string? ReduceOnly { get; init; }

    public decimal? Price { get; init; }

    /// <summary>stopPrice triggered by: "MARK_PRICE", "CONTRACT_PRICE". Default "CONTRACT_PRICE"</summary>
    public NewCmConditionalOrderWorkingType? WorkingType { get; init; }

    /// <summary>
    /// "true" or "false", default "false". Used with STOP/STOP_MARKET or TAKE_PROFIT/TAKE_PROFIT_MARKET
    /// orders
    /// </summary>
    public NewCmConditionalOrderPriceProtect? PriceProtect { get; init; }

    /// <summary>
    /// A unique id among open orders. Automatically generated if not sent. Can only be string following the
    /// rule: ^[.A-Z\:/a-z0-9_-]{1,36}$
    /// </summary>
    public string? NewClientStrategyId { get; init; }

    /// <summary>Used with STOP/STOP_MARKET or TAKE_PROFIT/TAKE_PROFIT_MARKET orders.</summary>
    public decimal? StopPrice { get; init; }

    /// <summary>Used with TRAILING_STOP_MARKET orders.</summary>
    public decimal? ActivationPrice { get; init; }

    /// <summary>Used with TRAILING_STOP_MARKET orders.</summary>
    public decimal? CallbackRate { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<NewCmOrderSide>))]
public readonly struct NewCmOrderSide : IExtensibleValue<NewCmOrderSide>, IEquatable<NewCmOrderSide>
{
    private readonly string? _value;

    public NewCmOrderSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewCmOrderSide Buy { get; } = new("BUY");

    public static NewCmOrderSide Sell { get; } = new("SELL");

    static NewCmOrderSide IExtensibleValue<NewCmOrderSide>.Create(string value) => new(value);

    public static bool operator ==(NewCmOrderSide left, NewCmOrderSide right) => left.Equals(right);

    public static bool operator !=(NewCmOrderSide left, NewCmOrderSide right) => !left.Equals(right);

    public static implicit operator NewCmOrderSide(string value) => new(value);

    public static NewCmOrderSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewCmOrderSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewCmOrderSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewCmOrderType>))]
public readonly struct NewCmOrderType : IExtensibleValue<NewCmOrderType>, IEquatable<NewCmOrderType>
{
    private readonly string? _value;

    public NewCmOrderType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewCmOrderType Limit { get; } = new("LIMIT");

    public static NewCmOrderType Market { get; } = new("MARKET");

    static NewCmOrderType IExtensibleValue<NewCmOrderType>.Create(string value) => new(value);

    public static bool operator ==(NewCmOrderType left, NewCmOrderType right) => left.Equals(right);

    public static bool operator !=(NewCmOrderType left, NewCmOrderType right) => !left.Equals(right);

    public static implicit operator NewCmOrderType(string value) => new(value);

    public static NewCmOrderType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewCmOrderType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewCmOrderType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewCmOrderPositionSide>))]
public readonly struct NewCmOrderPositionSide : IExtensibleValue<NewCmOrderPositionSide>, IEquatable<NewCmOrderPositionSide>
{
    private readonly string? _value;

    public NewCmOrderPositionSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewCmOrderPositionSide Both { get; } = new("BOTH");

    public static NewCmOrderPositionSide Long { get; } = new("LONG");

    public static NewCmOrderPositionSide Short { get; } = new("SHORT");

    static NewCmOrderPositionSide IExtensibleValue<NewCmOrderPositionSide>.Create(string value) => new(value);

    public static bool operator ==(NewCmOrderPositionSide left, NewCmOrderPositionSide right) => left.Equals(right);

    public static bool operator !=(NewCmOrderPositionSide left, NewCmOrderPositionSide right) => !left.Equals(right);

    public static implicit operator NewCmOrderPositionSide(string value) => new(value);

    public static NewCmOrderPositionSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewCmOrderPositionSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewCmOrderPositionSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewCmOrderTimeInForce>))]
public readonly struct NewCmOrderTimeInForce : IExtensibleValue<NewCmOrderTimeInForce>, IEquatable<NewCmOrderTimeInForce>
{
    private readonly string? _value;

    public NewCmOrderTimeInForce(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewCmOrderTimeInForce Gtc { get; } = new("GTC");

    public static NewCmOrderTimeInForce Ioc { get; } = new("IOC");

    public static NewCmOrderTimeInForce Fok { get; } = new("FOK");

    public static NewCmOrderTimeInForce Gtx { get; } = new("GTX");

    static NewCmOrderTimeInForce IExtensibleValue<NewCmOrderTimeInForce>.Create(string value) => new(value);

    public static bool operator ==(NewCmOrderTimeInForce left, NewCmOrderTimeInForce right) => left.Equals(right);

    public static bool operator !=(NewCmOrderTimeInForce left, NewCmOrderTimeInForce right) => !left.Equals(right);

    public static implicit operator NewCmOrderTimeInForce(string value) => new(value);

    public static NewCmOrderTimeInForce FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewCmOrderTimeInForce other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewCmOrderTimeInForce other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewCmOrderReduceOnly>))]
public readonly struct NewCmOrderReduceOnly : IExtensibleValue<NewCmOrderReduceOnly>, IEquatable<NewCmOrderReduceOnly>
{
    private readonly string? _value;

    public NewCmOrderReduceOnly(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewCmOrderReduceOnly True { get; } = new("true");

    public static NewCmOrderReduceOnly False { get; } = new("false");

    static NewCmOrderReduceOnly IExtensibleValue<NewCmOrderReduceOnly>.Create(string value) => new(value);

    public static bool operator ==(NewCmOrderReduceOnly left, NewCmOrderReduceOnly right) => left.Equals(right);

    public static bool operator !=(NewCmOrderReduceOnly left, NewCmOrderReduceOnly right) => !left.Equals(right);

    public static implicit operator NewCmOrderReduceOnly(string value) => new(value);

    public static NewCmOrderReduceOnly FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewCmOrderReduceOnly other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewCmOrderReduceOnly other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewCmOrderPriceMatch>))]
public readonly struct NewCmOrderPriceMatch : IExtensibleValue<NewCmOrderPriceMatch>, IEquatable<NewCmOrderPriceMatch>
{
    private readonly string? _value;

    public NewCmOrderPriceMatch(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewCmOrderPriceMatch Opponent { get; } = new("OPPONENT");

    public static NewCmOrderPriceMatch Opponent5 { get; } = new("OPPONENT_5");

    public static NewCmOrderPriceMatch Opponent10 { get; } = new("OPPONENT_10");

    public static NewCmOrderPriceMatch Opponent20 { get; } = new("OPPONENT_20");

    public static NewCmOrderPriceMatch Queue { get; } = new("QUEUE");

    public static NewCmOrderPriceMatch Queue5 { get; } = new("QUEUE_5");

    public static NewCmOrderPriceMatch Queue10 { get; } = new("QUEUE_10");

    public static NewCmOrderPriceMatch Queue20 { get; } = new("QUEUE_20");

    static NewCmOrderPriceMatch IExtensibleValue<NewCmOrderPriceMatch>.Create(string value) => new(value);

    public static bool operator ==(NewCmOrderPriceMatch left, NewCmOrderPriceMatch right) => left.Equals(right);

    public static bool operator !=(NewCmOrderPriceMatch left, NewCmOrderPriceMatch right) => !left.Equals(right);

    public static implicit operator NewCmOrderPriceMatch(string value) => new(value);

    public static NewCmOrderPriceMatch FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewCmOrderPriceMatch other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewCmOrderPriceMatch other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewCmOrderNewOrderRespType>))]
public readonly struct NewCmOrderNewOrderRespType : IExtensibleValue<NewCmOrderNewOrderRespType>, IEquatable<NewCmOrderNewOrderRespType>
{
    private readonly string? _value;

    public NewCmOrderNewOrderRespType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewCmOrderNewOrderRespType Ack { get; } = new("ACK");

    public static NewCmOrderNewOrderRespType Result { get; } = new("RESULT");

    static NewCmOrderNewOrderRespType IExtensibleValue<NewCmOrderNewOrderRespType>.Create(string value) => new(value);

    public static bool operator ==(NewCmOrderNewOrderRespType left, NewCmOrderNewOrderRespType right) => left.Equals(right);

    public static bool operator !=(NewCmOrderNewOrderRespType left, NewCmOrderNewOrderRespType right) => !left.Equals(right);

    public static implicit operator NewCmOrderNewOrderRespType(string value) => new(value);

    public static NewCmOrderNewOrderRespType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewCmOrderNewOrderRespType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewCmOrderNewOrderRespType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class NewCmOrderRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    /// <summary>Side</summary>
    public required NewCmOrderSide Side { get; init; }

    public required NewCmOrderType Type { get; init; }

    /// <summary>
    /// Default BOTH for One-way Mode ; LONG or SHORT for Hedge Mode. It must be sent in Hedge Mode.
    /// </summary>
    public NewCmOrderPositionSide? PositionSide { get; init; }

    public NewCmOrderTimeInForce? TimeInForce { get; init; }

    /// <summary>Place amount</summary>
    public decimal? Quantity { get; init; }

    /// <summary>"true" or "false". Cannot be sent in Hedge Mode.</summary>
    public NewCmOrderReduceOnly? ReduceOnly { get; init; }

    /// <summary>Order price</summary>
    public decimal? Price { get; init; }

    /// <summary>
    /// only avaliable for LIMIT/STOP/TAKE_PROFIT order; can be set to OPPONENT/ OPPONENT_5/ OPPONENT_10/
    /// OPPONENT_20: /QUEUE/ QUEUE_5/ QUEUE_10/ QUEUE_20; Can't be passed together with price
    /// </summary>
    public NewCmOrderPriceMatch? PriceMatch { get; init; }

    /// <summary>
    /// A unique id among open orders. Automatically generated if not sent. Can only be string following the
    /// rule: ^[.A-Z\:/a-z0-9_-]{1,32}$
    /// </summary>
    public string? NewClientOrderId { get; init; }

    /// <summary>"ACK", "RESULT", default "ACK"</summary>
    public NewCmOrderNewOrderRespType? NewOrderRespType { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<NewMarginOrderSide>))]
public readonly struct NewMarginOrderSide : IExtensibleValue<NewMarginOrderSide>, IEquatable<NewMarginOrderSide>
{
    private readonly string? _value;

    public NewMarginOrderSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewMarginOrderSide Buy { get; } = new("BUY");

    public static NewMarginOrderSide Sell { get; } = new("SELL");

    static NewMarginOrderSide IExtensibleValue<NewMarginOrderSide>.Create(string value) => new(value);

    public static bool operator ==(NewMarginOrderSide left, NewMarginOrderSide right) => left.Equals(right);

    public static bool operator !=(NewMarginOrderSide left, NewMarginOrderSide right) => !left.Equals(right);

    public static implicit operator NewMarginOrderSide(string value) => new(value);

    public static NewMarginOrderSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewMarginOrderSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewMarginOrderSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewMarginOrderType>))]
public readonly struct NewMarginOrderType : IExtensibleValue<NewMarginOrderType>, IEquatable<NewMarginOrderType>
{
    private readonly string? _value;

    public NewMarginOrderType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewMarginOrderType Limit { get; } = new("LIMIT");

    public static NewMarginOrderType Market { get; } = new("MARKET");

    public static NewMarginOrderType StopLoss { get; } = new("STOP_LOSS");

    public static NewMarginOrderType StopLossLimit { get; } = new("STOP_LOSS_LIMIT");

    public static NewMarginOrderType TakeProfit { get; } = new("TAKE_PROFIT");

    public static NewMarginOrderType TakeProfitLimit { get; } = new("TAKE_PROFIT_LIMIT");

    public static NewMarginOrderType LimitMaker { get; } = new("LIMIT_MAKER");

    static NewMarginOrderType IExtensibleValue<NewMarginOrderType>.Create(string value) => new(value);

    public static bool operator ==(NewMarginOrderType left, NewMarginOrderType right) => left.Equals(right);

    public static bool operator !=(NewMarginOrderType left, NewMarginOrderType right) => !left.Equals(right);

    public static implicit operator NewMarginOrderType(string value) => new(value);

    public static NewMarginOrderType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewMarginOrderType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewMarginOrderType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewMarginOrderNewOrderRespType>))]
public readonly struct NewMarginOrderNewOrderRespType : IExtensibleValue<NewMarginOrderNewOrderRespType>, IEquatable<NewMarginOrderNewOrderRespType>
{
    private readonly string? _value;

    public NewMarginOrderNewOrderRespType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewMarginOrderNewOrderRespType Ack { get; } = new("ACK");

    public static NewMarginOrderNewOrderRespType Result { get; } = new("RESULT");

    public static NewMarginOrderNewOrderRespType Full { get; } = new("FULL");

    static NewMarginOrderNewOrderRespType IExtensibleValue<NewMarginOrderNewOrderRespType>.Create(string value) => new(value);

    public static bool operator ==(NewMarginOrderNewOrderRespType left, NewMarginOrderNewOrderRespType right) => left.Equals(right);

    public static bool operator !=(NewMarginOrderNewOrderRespType left, NewMarginOrderNewOrderRespType right) => !left.Equals(right);

    public static implicit operator NewMarginOrderNewOrderRespType(string value) => new(value);

    public static NewMarginOrderNewOrderRespType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewMarginOrderNewOrderRespType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewMarginOrderNewOrderRespType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewMarginOrderSideEffectType>))]
public readonly struct NewMarginOrderSideEffectType : IExtensibleValue<NewMarginOrderSideEffectType>, IEquatable<NewMarginOrderSideEffectType>
{
    private readonly string? _value;

    public NewMarginOrderSideEffectType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewMarginOrderSideEffectType NoSideEffect { get; } = new("NO_SIDE_EFFECT");

    public static NewMarginOrderSideEffectType MarginBuy { get; } = new("MARGIN_BUY");

    public static NewMarginOrderSideEffectType AutoRepay { get; } = new("AUTO_REPAY");

    public static NewMarginOrderSideEffectType AutoBorrowRepay { get; } = new("AUTO_BORROW_REPAY");

    static NewMarginOrderSideEffectType IExtensibleValue<NewMarginOrderSideEffectType>.Create(string value) => new(value);

    public static bool operator ==(NewMarginOrderSideEffectType left, NewMarginOrderSideEffectType right) => left.Equals(right);

    public static bool operator !=(NewMarginOrderSideEffectType left, NewMarginOrderSideEffectType right) => !left.Equals(right);

    public static implicit operator NewMarginOrderSideEffectType(string value) => new(value);

    public static NewMarginOrderSideEffectType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewMarginOrderSideEffectType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewMarginOrderSideEffectType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewMarginOrderTimeInForce>))]
public readonly struct NewMarginOrderTimeInForce : IExtensibleValue<NewMarginOrderTimeInForce>, IEquatable<NewMarginOrderTimeInForce>
{
    private readonly string? _value;

    public NewMarginOrderTimeInForce(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewMarginOrderTimeInForce Gtc { get; } = new("GTC");

    public static NewMarginOrderTimeInForce Ioc { get; } = new("IOC");

    public static NewMarginOrderTimeInForce Fok { get; } = new("FOK");

    static NewMarginOrderTimeInForce IExtensibleValue<NewMarginOrderTimeInForce>.Create(string value) => new(value);

    public static bool operator ==(NewMarginOrderTimeInForce left, NewMarginOrderTimeInForce right) => left.Equals(right);

    public static bool operator !=(NewMarginOrderTimeInForce left, NewMarginOrderTimeInForce right) => !left.Equals(right);

    public static implicit operator NewMarginOrderTimeInForce(string value) => new(value);

    public static NewMarginOrderTimeInForce FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewMarginOrderTimeInForce other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewMarginOrderTimeInForce other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewMarginOrderSelfTradePreventionMode>))]
public readonly struct NewMarginOrderSelfTradePreventionMode : IExtensibleValue<NewMarginOrderSelfTradePreventionMode>, IEquatable<NewMarginOrderSelfTradePreventionMode>
{
    private readonly string? _value;

    public NewMarginOrderSelfTradePreventionMode(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewMarginOrderSelfTradePreventionMode None { get; } = new("NONE");

    public static NewMarginOrderSelfTradePreventionMode ExpireTaker { get; } = new("EXPIRE_TAKER");

    public static NewMarginOrderSelfTradePreventionMode ExpireBoth { get; } = new("EXPIRE_BOTH");

    public static NewMarginOrderSelfTradePreventionMode ExpireMaker { get; } = new("EXPIRE_MAKER");

    static NewMarginOrderSelfTradePreventionMode IExtensibleValue<NewMarginOrderSelfTradePreventionMode>.Create(string value) => new(value);

    public static bool operator ==(NewMarginOrderSelfTradePreventionMode left, NewMarginOrderSelfTradePreventionMode right) => left.Equals(right);

    public static bool operator !=(NewMarginOrderSelfTradePreventionMode left, NewMarginOrderSelfTradePreventionMode right) => !left.Equals(right);

    public static implicit operator NewMarginOrderSelfTradePreventionMode(string value) => new(value);

    public static NewMarginOrderSelfTradePreventionMode FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewMarginOrderSelfTradePreventionMode other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewMarginOrderSelfTradePreventionMode other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class NewMarginOrderRequest
{
    public required string Symbol { get; init; }

    public required NewMarginOrderSide Side { get; init; }

    public required NewMarginOrderType Type { get; init; }

    public decimal? Quantity { get; init; }

    public decimal? QuoteOrderQty { get; init; }

    public decimal? Price { get; init; }

    /// <summary>Used with STOP_LOSS, STOP_LOSS_LIMIT, TAKE_PROFIT, and TAKE_PROFIT_LIMIT orders.</summary>
    public decimal? StopPrice { get; init; }

    /// <summary>A unique id among open orders. Automatically generated if not sent.</summary>
    public string? NewClientOrderId { get; init; }

    /// <summary>Set the response JSON. ACK, RESULT, or FULL.</summary>
    public NewMarginOrderNewOrderRespType? NewOrderRespType { get; init; }

    /// <summary>Used with LIMIT, STOP_LOSS_LIMIT, and TAKE_PROFIT_LIMIT to create an iceberg order</summary>
    public decimal? IcebergQty { get; init; }

    public NewMarginOrderSideEffectType? SideEffectType { get; init; }

    public NewMarginOrderTimeInForce? TimeInForce { get; init; }

    /// <summary>
    /// NONE: No STP / EXPIRE_TAKER: expire taker order when STP triggers/ EXPIRE_MAKER: expire taker order
    /// when STP triggers/ EXPIRE_BOTH: expire both orders when STP triggers
    /// </summary>
    public NewMarginOrderSelfTradePreventionMode? SelfTradePreventionMode { get; init; }

    /// <summary>
    /// Only when MARGIN_BUY or AUTO_BORROW_REPAY order takes effect, true means that the debt generated by
    /// the order needs to be repaid after the order is cancelled.
    /// </summary>
    public bool? AutoRepayAtCancel { get; init; }

    /// <summary>The value cannot be greater than 60000</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<NewUmAlgoOrderAlgoType>))]
public readonly struct NewUmAlgoOrderAlgoType : IExtensibleValue<NewUmAlgoOrderAlgoType>, IEquatable<NewUmAlgoOrderAlgoType>
{
    private readonly string? _value;

    public NewUmAlgoOrderAlgoType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewUmAlgoOrderAlgoType Conditional { get; } = new("CONDITIONAL");

    static NewUmAlgoOrderAlgoType IExtensibleValue<NewUmAlgoOrderAlgoType>.Create(string value) => new(value);

    public static bool operator ==(NewUmAlgoOrderAlgoType left, NewUmAlgoOrderAlgoType right) => left.Equals(right);

    public static bool operator !=(NewUmAlgoOrderAlgoType left, NewUmAlgoOrderAlgoType right) => !left.Equals(right);

    public static implicit operator NewUmAlgoOrderAlgoType(string value) => new(value);

    public static NewUmAlgoOrderAlgoType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewUmAlgoOrderAlgoType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewUmAlgoOrderAlgoType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewUmAlgoOrderSide>))]
public readonly struct NewUmAlgoOrderSide : IExtensibleValue<NewUmAlgoOrderSide>, IEquatable<NewUmAlgoOrderSide>
{
    private readonly string? _value;

    public NewUmAlgoOrderSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewUmAlgoOrderSide Buy { get; } = new("BUY");

    public static NewUmAlgoOrderSide Sell { get; } = new("SELL");

    static NewUmAlgoOrderSide IExtensibleValue<NewUmAlgoOrderSide>.Create(string value) => new(value);

    public static bool operator ==(NewUmAlgoOrderSide left, NewUmAlgoOrderSide right) => left.Equals(right);

    public static bool operator !=(NewUmAlgoOrderSide left, NewUmAlgoOrderSide right) => !left.Equals(right);

    public static implicit operator NewUmAlgoOrderSide(string value) => new(value);

    public static NewUmAlgoOrderSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewUmAlgoOrderSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewUmAlgoOrderSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewUmAlgoOrderType>))]
public readonly struct NewUmAlgoOrderType : IExtensibleValue<NewUmAlgoOrderType>, IEquatable<NewUmAlgoOrderType>
{
    private readonly string? _value;

    public NewUmAlgoOrderType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewUmAlgoOrderType Stop { get; } = new("STOP");

    public static NewUmAlgoOrderType TakeProfit { get; } = new("TAKE_PROFIT");

    public static NewUmAlgoOrderType StopMarket { get; } = new("STOP_MARKET");

    public static NewUmAlgoOrderType TakeProfitMarket { get; } = new("TAKE_PROFIT_MARKET");

    public static NewUmAlgoOrderType TrailingStopMarket { get; } = new("TRAILING_STOP_MARKET");

    static NewUmAlgoOrderType IExtensibleValue<NewUmAlgoOrderType>.Create(string value) => new(value);

    public static bool operator ==(NewUmAlgoOrderType left, NewUmAlgoOrderType right) => left.Equals(right);

    public static bool operator !=(NewUmAlgoOrderType left, NewUmAlgoOrderType right) => !left.Equals(right);

    public static implicit operator NewUmAlgoOrderType(string value) => new(value);

    public static NewUmAlgoOrderType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewUmAlgoOrderType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewUmAlgoOrderType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewUmAlgoOrderPositionSide>))]
public readonly struct NewUmAlgoOrderPositionSide : IExtensibleValue<NewUmAlgoOrderPositionSide>, IEquatable<NewUmAlgoOrderPositionSide>
{
    private readonly string? _value;

    public NewUmAlgoOrderPositionSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewUmAlgoOrderPositionSide Both { get; } = new("BOTH");

    public static NewUmAlgoOrderPositionSide Long { get; } = new("LONG");

    public static NewUmAlgoOrderPositionSide Short { get; } = new("SHORT");

    static NewUmAlgoOrderPositionSide IExtensibleValue<NewUmAlgoOrderPositionSide>.Create(string value) => new(value);

    public static bool operator ==(NewUmAlgoOrderPositionSide left, NewUmAlgoOrderPositionSide right) => left.Equals(right);

    public static bool operator !=(NewUmAlgoOrderPositionSide left, NewUmAlgoOrderPositionSide right) => !left.Equals(right);

    public static implicit operator NewUmAlgoOrderPositionSide(string value) => new(value);

    public static NewUmAlgoOrderPositionSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewUmAlgoOrderPositionSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewUmAlgoOrderPositionSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewUmAlgoOrderTimeInForce>))]
public readonly struct NewUmAlgoOrderTimeInForce : IExtensibleValue<NewUmAlgoOrderTimeInForce>, IEquatable<NewUmAlgoOrderTimeInForce>
{
    private readonly string? _value;

    public NewUmAlgoOrderTimeInForce(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewUmAlgoOrderTimeInForce Ioc { get; } = new("IOC");

    public static NewUmAlgoOrderTimeInForce Gtc { get; } = new("GTC");

    public static NewUmAlgoOrderTimeInForce Fok { get; } = new("FOK");

    public static NewUmAlgoOrderTimeInForce Gtx { get; } = new("GTX");

    public static NewUmAlgoOrderTimeInForce Gtd { get; } = new("GTD");

    static NewUmAlgoOrderTimeInForce IExtensibleValue<NewUmAlgoOrderTimeInForce>.Create(string value) => new(value);

    public static bool operator ==(NewUmAlgoOrderTimeInForce left, NewUmAlgoOrderTimeInForce right) => left.Equals(right);

    public static bool operator !=(NewUmAlgoOrderTimeInForce left, NewUmAlgoOrderTimeInForce right) => !left.Equals(right);

    public static implicit operator NewUmAlgoOrderTimeInForce(string value) => new(value);

    public static NewUmAlgoOrderTimeInForce FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewUmAlgoOrderTimeInForce other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewUmAlgoOrderTimeInForce other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewUmAlgoOrderWorkingType>))]
public readonly struct NewUmAlgoOrderWorkingType : IExtensibleValue<NewUmAlgoOrderWorkingType>, IEquatable<NewUmAlgoOrderWorkingType>
{
    private readonly string? _value;

    public NewUmAlgoOrderWorkingType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewUmAlgoOrderWorkingType MarkPrice { get; } = new("MARK_PRICE");

    public static NewUmAlgoOrderWorkingType ContractPrice { get; } = new("CONTRACT_PRICE");

    static NewUmAlgoOrderWorkingType IExtensibleValue<NewUmAlgoOrderWorkingType>.Create(string value) => new(value);

    public static bool operator ==(NewUmAlgoOrderWorkingType left, NewUmAlgoOrderWorkingType right) => left.Equals(right);

    public static bool operator !=(NewUmAlgoOrderWorkingType left, NewUmAlgoOrderWorkingType right) => !left.Equals(right);

    public static implicit operator NewUmAlgoOrderWorkingType(string value) => new(value);

    public static NewUmAlgoOrderWorkingType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewUmAlgoOrderWorkingType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewUmAlgoOrderWorkingType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewUmAlgoOrderPriceMatch>))]
public readonly struct NewUmAlgoOrderPriceMatch : IExtensibleValue<NewUmAlgoOrderPriceMatch>, IEquatable<NewUmAlgoOrderPriceMatch>
{
    private readonly string? _value;

    public NewUmAlgoOrderPriceMatch(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewUmAlgoOrderPriceMatch Opponent { get; } = new("OPPONENT");

    public static NewUmAlgoOrderPriceMatch Opponent5 { get; } = new("OPPONENT_5");

    public static NewUmAlgoOrderPriceMatch Opponent10 { get; } = new("OPPONENT_10");

    public static NewUmAlgoOrderPriceMatch Opponent20 { get; } = new("OPPONENT_20");

    public static NewUmAlgoOrderPriceMatch Queue { get; } = new("QUEUE");

    public static NewUmAlgoOrderPriceMatch Queue5 { get; } = new("QUEUE_5");

    public static NewUmAlgoOrderPriceMatch Queue10 { get; } = new("QUEUE_10");

    public static NewUmAlgoOrderPriceMatch Queue20 { get; } = new("QUEUE_20");

    static NewUmAlgoOrderPriceMatch IExtensibleValue<NewUmAlgoOrderPriceMatch>.Create(string value) => new(value);

    public static bool operator ==(NewUmAlgoOrderPriceMatch left, NewUmAlgoOrderPriceMatch right) => left.Equals(right);

    public static bool operator !=(NewUmAlgoOrderPriceMatch left, NewUmAlgoOrderPriceMatch right) => !left.Equals(right);

    public static implicit operator NewUmAlgoOrderPriceMatch(string value) => new(value);

    public static NewUmAlgoOrderPriceMatch FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewUmAlgoOrderPriceMatch other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewUmAlgoOrderPriceMatch other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewUmAlgoOrderClosePosition>))]
public readonly struct NewUmAlgoOrderClosePosition : IExtensibleValue<NewUmAlgoOrderClosePosition>, IEquatable<NewUmAlgoOrderClosePosition>
{
    private readonly string? _value;

    public NewUmAlgoOrderClosePosition(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewUmAlgoOrderClosePosition True { get; } = new("true");

    public static NewUmAlgoOrderClosePosition False { get; } = new("false");

    static NewUmAlgoOrderClosePosition IExtensibleValue<NewUmAlgoOrderClosePosition>.Create(string value) => new(value);

    public static bool operator ==(NewUmAlgoOrderClosePosition left, NewUmAlgoOrderClosePosition right) => left.Equals(right);

    public static bool operator !=(NewUmAlgoOrderClosePosition left, NewUmAlgoOrderClosePosition right) => !left.Equals(right);

    public static implicit operator NewUmAlgoOrderClosePosition(string value) => new(value);

    public static NewUmAlgoOrderClosePosition FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewUmAlgoOrderClosePosition other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewUmAlgoOrderClosePosition other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewUmAlgoOrderPriceProtect>))]
public readonly struct NewUmAlgoOrderPriceProtect : IExtensibleValue<NewUmAlgoOrderPriceProtect>, IEquatable<NewUmAlgoOrderPriceProtect>
{
    private readonly string? _value;

    public NewUmAlgoOrderPriceProtect(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewUmAlgoOrderPriceProtect True { get; } = new("true");

    public static NewUmAlgoOrderPriceProtect False { get; } = new("false");

    static NewUmAlgoOrderPriceProtect IExtensibleValue<NewUmAlgoOrderPriceProtect>.Create(string value) => new(value);

    public static bool operator ==(NewUmAlgoOrderPriceProtect left, NewUmAlgoOrderPriceProtect right) => left.Equals(right);

    public static bool operator !=(NewUmAlgoOrderPriceProtect left, NewUmAlgoOrderPriceProtect right) => !left.Equals(right);

    public static implicit operator NewUmAlgoOrderPriceProtect(string value) => new(value);

    public static NewUmAlgoOrderPriceProtect FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewUmAlgoOrderPriceProtect other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewUmAlgoOrderPriceProtect other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewUmAlgoOrderReduceOnly>))]
public readonly struct NewUmAlgoOrderReduceOnly : IExtensibleValue<NewUmAlgoOrderReduceOnly>, IEquatable<NewUmAlgoOrderReduceOnly>
{
    private readonly string? _value;

    public NewUmAlgoOrderReduceOnly(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewUmAlgoOrderReduceOnly True { get; } = new("true");

    public static NewUmAlgoOrderReduceOnly False { get; } = new("false");

    static NewUmAlgoOrderReduceOnly IExtensibleValue<NewUmAlgoOrderReduceOnly>.Create(string value) => new(value);

    public static bool operator ==(NewUmAlgoOrderReduceOnly left, NewUmAlgoOrderReduceOnly right) => left.Equals(right);

    public static bool operator !=(NewUmAlgoOrderReduceOnly left, NewUmAlgoOrderReduceOnly right) => !left.Equals(right);

    public static implicit operator NewUmAlgoOrderReduceOnly(string value) => new(value);

    public static NewUmAlgoOrderReduceOnly FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewUmAlgoOrderReduceOnly other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewUmAlgoOrderReduceOnly other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewUmAlgoOrderNewOrderRespType>))]
public readonly struct NewUmAlgoOrderNewOrderRespType : IExtensibleValue<NewUmAlgoOrderNewOrderRespType>, IEquatable<NewUmAlgoOrderNewOrderRespType>
{
    private readonly string? _value;

    public NewUmAlgoOrderNewOrderRespType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewUmAlgoOrderNewOrderRespType Ack { get; } = new("ACK");

    public static NewUmAlgoOrderNewOrderRespType Result { get; } = new("RESULT");

    static NewUmAlgoOrderNewOrderRespType IExtensibleValue<NewUmAlgoOrderNewOrderRespType>.Create(string value) => new(value);

    public static bool operator ==(NewUmAlgoOrderNewOrderRespType left, NewUmAlgoOrderNewOrderRespType right) => left.Equals(right);

    public static bool operator !=(NewUmAlgoOrderNewOrderRespType left, NewUmAlgoOrderNewOrderRespType right) => !left.Equals(right);

    public static implicit operator NewUmAlgoOrderNewOrderRespType(string value) => new(value);

    public static NewUmAlgoOrderNewOrderRespType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewUmAlgoOrderNewOrderRespType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewUmAlgoOrderNewOrderRespType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewUmAlgoOrderSelfTradePreventionMode>))]
public readonly struct NewUmAlgoOrderSelfTradePreventionMode : IExtensibleValue<NewUmAlgoOrderSelfTradePreventionMode>, IEquatable<NewUmAlgoOrderSelfTradePreventionMode>
{
    private readonly string? _value;

    public NewUmAlgoOrderSelfTradePreventionMode(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewUmAlgoOrderSelfTradePreventionMode None { get; } = new("NONE");

    public static NewUmAlgoOrderSelfTradePreventionMode ExpireTaker { get; } = new("EXPIRE_TAKER");

    public static NewUmAlgoOrderSelfTradePreventionMode ExpireMaker { get; } = new("EXPIRE_MAKER");

    public static NewUmAlgoOrderSelfTradePreventionMode ExpireBoth { get; } = new("EXPIRE_BOTH");

    static NewUmAlgoOrderSelfTradePreventionMode IExtensibleValue<NewUmAlgoOrderSelfTradePreventionMode>.Create(string value) => new(value);

    public static bool operator ==(NewUmAlgoOrderSelfTradePreventionMode left, NewUmAlgoOrderSelfTradePreventionMode right) => left.Equals(right);

    public static bool operator !=(NewUmAlgoOrderSelfTradePreventionMode left, NewUmAlgoOrderSelfTradePreventionMode right) => !left.Equals(right);

    public static implicit operator NewUmAlgoOrderSelfTradePreventionMode(string value) => new(value);

    public static NewUmAlgoOrderSelfTradePreventionMode FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewUmAlgoOrderSelfTradePreventionMode other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewUmAlgoOrderSelfTradePreventionMode other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class NewUmAlgoOrderRequest
{
    /// <summary>Only support CONDITIONAL</summary>
    public required NewUmAlgoOrderAlgoType AlgoType { get; init; }

    public required string Symbol { get; init; }

    public required NewUmAlgoOrderSide Side { get; init; }

    /// <summary>Conditional order type</summary>
    public required NewUmAlgoOrderType Type { get; init; }

    /// <summary>Default BOTH for One-way Mode; LONG or SHORT for Hedge Mode</summary>
    public NewUmAlgoOrderPositionSide? PositionSide { get; init; }

    public NewUmAlgoOrderTimeInForce? TimeInForce { get; init; }

    /// <summary>Order quantity. Cannot be sent with closePosition=true(Close-All)</summary>
    public decimal? Quantity { get; init; }

    /// <summary>Order price</summary>
    public decimal? Price { get; init; }

    /// <summary>Trigger price</summary>
    public decimal? TriggerPrice { get; init; }

    /// <summary>Trigger price type. Default CONTRACT_PRICE</summary>
    public NewUmAlgoOrderWorkingType? WorkingType { get; init; }

    /// <summary>Can't be passed together with price</summary>
    public NewUmAlgoOrderPriceMatch? PriceMatch { get; init; }

    /// <summary>Close-All, used with STOP_MARKET or TAKE_PROFIT_MARKET.</summary>
    public NewUmAlgoOrderClosePosition? ClosePosition { get; init; }

    /// <summary>Price protection. Default false</summary>
    public NewUmAlgoOrderPriceProtect? PriceProtect { get; init; }

    /// <summary>Cannot be sent in Hedge Mode; cannot be sent with closePosition=true</summary>
    public NewUmAlgoOrderReduceOnly? ReduceOnly { get; init; }

    /// <summary>Used with TRAILING_STOP_MARKET, default as latest price</summary>
    public decimal? ActivatePrice { get; init; }

    /// <summary>Used with TRAILING_STOP_MARKET, min 0.1, max 20 (1 = 1%)</summary>
    public decimal? CallbackRate { get; init; }

    /// <summary>Unique id among open orders. Auto-generated if not sent</summary>
    public string? ClientAlgoId { get; init; }

    public NewUmAlgoOrderNewOrderRespType? NewOrderRespType { get; init; }

    public NewUmAlgoOrderSelfTradePreventionMode? SelfTradePreventionMode { get; init; }

    /// <summary>Order cancel time for GTD timeInForce, mandatory when timeInForce is GTD</summary>
    public long? GoodTillDate { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<NewUmOrderSide>))]
public readonly struct NewUmOrderSide : IExtensibleValue<NewUmOrderSide>, IEquatable<NewUmOrderSide>
{
    private readonly string? _value;

    public NewUmOrderSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewUmOrderSide Buy { get; } = new("BUY");

    public static NewUmOrderSide Sell { get; } = new("SELL");

    static NewUmOrderSide IExtensibleValue<NewUmOrderSide>.Create(string value) => new(value);

    public static bool operator ==(NewUmOrderSide left, NewUmOrderSide right) => left.Equals(right);

    public static bool operator !=(NewUmOrderSide left, NewUmOrderSide right) => !left.Equals(right);

    public static implicit operator NewUmOrderSide(string value) => new(value);

    public static NewUmOrderSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewUmOrderSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewUmOrderSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewUmOrderType>))]
public readonly struct NewUmOrderType : IExtensibleValue<NewUmOrderType>, IEquatable<NewUmOrderType>
{
    private readonly string? _value;

    public NewUmOrderType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewUmOrderType Limit { get; } = new("LIMIT");

    public static NewUmOrderType Market { get; } = new("MARKET");

    static NewUmOrderType IExtensibleValue<NewUmOrderType>.Create(string value) => new(value);

    public static bool operator ==(NewUmOrderType left, NewUmOrderType right) => left.Equals(right);

    public static bool operator !=(NewUmOrderType left, NewUmOrderType right) => !left.Equals(right);

    public static implicit operator NewUmOrderType(string value) => new(value);

    public static NewUmOrderType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewUmOrderType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewUmOrderType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewUmOrderPositionSide>))]
public readonly struct NewUmOrderPositionSide : IExtensibleValue<NewUmOrderPositionSide>, IEquatable<NewUmOrderPositionSide>
{
    private readonly string? _value;

    public NewUmOrderPositionSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewUmOrderPositionSide Both { get; } = new("BOTH");

    public static NewUmOrderPositionSide Long { get; } = new("LONG");

    public static NewUmOrderPositionSide Short { get; } = new("SHORT");

    static NewUmOrderPositionSide IExtensibleValue<NewUmOrderPositionSide>.Create(string value) => new(value);

    public static bool operator ==(NewUmOrderPositionSide left, NewUmOrderPositionSide right) => left.Equals(right);

    public static bool operator !=(NewUmOrderPositionSide left, NewUmOrderPositionSide right) => !left.Equals(right);

    public static implicit operator NewUmOrderPositionSide(string value) => new(value);

    public static NewUmOrderPositionSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewUmOrderPositionSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewUmOrderPositionSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewUmOrderTimeInForce>))]
public readonly struct NewUmOrderTimeInForce : IExtensibleValue<NewUmOrderTimeInForce>, IEquatable<NewUmOrderTimeInForce>
{
    private readonly string? _value;

    public NewUmOrderTimeInForce(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewUmOrderTimeInForce Gtc { get; } = new("GTC");

    public static NewUmOrderTimeInForce Ioc { get; } = new("IOC");

    public static NewUmOrderTimeInForce Fok { get; } = new("FOK");

    public static NewUmOrderTimeInForce Gtx { get; } = new("GTX");

    public static NewUmOrderTimeInForce Gtd { get; } = new("GTD");

    static NewUmOrderTimeInForce IExtensibleValue<NewUmOrderTimeInForce>.Create(string value) => new(value);

    public static bool operator ==(NewUmOrderTimeInForce left, NewUmOrderTimeInForce right) => left.Equals(right);

    public static bool operator !=(NewUmOrderTimeInForce left, NewUmOrderTimeInForce right) => !left.Equals(right);

    public static implicit operator NewUmOrderTimeInForce(string value) => new(value);

    public static NewUmOrderTimeInForce FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewUmOrderTimeInForce other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewUmOrderTimeInForce other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewUmOrderReduceOnly>))]
public readonly struct NewUmOrderReduceOnly : IExtensibleValue<NewUmOrderReduceOnly>, IEquatable<NewUmOrderReduceOnly>
{
    private readonly string? _value;

    public NewUmOrderReduceOnly(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewUmOrderReduceOnly True { get; } = new("true");

    public static NewUmOrderReduceOnly False { get; } = new("false");

    static NewUmOrderReduceOnly IExtensibleValue<NewUmOrderReduceOnly>.Create(string value) => new(value);

    public static bool operator ==(NewUmOrderReduceOnly left, NewUmOrderReduceOnly right) => left.Equals(right);

    public static bool operator !=(NewUmOrderReduceOnly left, NewUmOrderReduceOnly right) => !left.Equals(right);

    public static implicit operator NewUmOrderReduceOnly(string value) => new(value);

    public static NewUmOrderReduceOnly FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewUmOrderReduceOnly other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewUmOrderReduceOnly other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewUmOrderNewOrderRespType>))]
public readonly struct NewUmOrderNewOrderRespType : IExtensibleValue<NewUmOrderNewOrderRespType>, IEquatable<NewUmOrderNewOrderRespType>
{
    private readonly string? _value;

    public NewUmOrderNewOrderRespType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewUmOrderNewOrderRespType Ack { get; } = new("ACK");

    public static NewUmOrderNewOrderRespType Result { get; } = new("RESULT");

    static NewUmOrderNewOrderRespType IExtensibleValue<NewUmOrderNewOrderRespType>.Create(string value) => new(value);

    public static bool operator ==(NewUmOrderNewOrderRespType left, NewUmOrderNewOrderRespType right) => left.Equals(right);

    public static bool operator !=(NewUmOrderNewOrderRespType left, NewUmOrderNewOrderRespType right) => !left.Equals(right);

    public static implicit operator NewUmOrderNewOrderRespType(string value) => new(value);

    public static NewUmOrderNewOrderRespType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewUmOrderNewOrderRespType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewUmOrderNewOrderRespType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewUmOrderPriceMatch>))]
public readonly struct NewUmOrderPriceMatch : IExtensibleValue<NewUmOrderPriceMatch>, IEquatable<NewUmOrderPriceMatch>
{
    private readonly string? _value;

    public NewUmOrderPriceMatch(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewUmOrderPriceMatch Opponent { get; } = new("OPPONENT");

    public static NewUmOrderPriceMatch Opponent5 { get; } = new("OPPONENT_5");

    public static NewUmOrderPriceMatch Opponent10 { get; } = new("OPPONENT_10");

    public static NewUmOrderPriceMatch Opponent20 { get; } = new("OPPONENT_20");

    public static NewUmOrderPriceMatch Queue { get; } = new("QUEUE");

    public static NewUmOrderPriceMatch Queue5 { get; } = new("QUEUE_5");

    public static NewUmOrderPriceMatch Queue10 { get; } = new("QUEUE_10");

    public static NewUmOrderPriceMatch Queue20 { get; } = new("QUEUE_20");

    static NewUmOrderPriceMatch IExtensibleValue<NewUmOrderPriceMatch>.Create(string value) => new(value);

    public static bool operator ==(NewUmOrderPriceMatch left, NewUmOrderPriceMatch right) => left.Equals(right);

    public static bool operator !=(NewUmOrderPriceMatch left, NewUmOrderPriceMatch right) => !left.Equals(right);

    public static implicit operator NewUmOrderPriceMatch(string value) => new(value);

    public static NewUmOrderPriceMatch FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewUmOrderPriceMatch other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewUmOrderPriceMatch other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewUmOrderSelfTradePreventionMode>))]
public readonly struct NewUmOrderSelfTradePreventionMode : IExtensibleValue<NewUmOrderSelfTradePreventionMode>, IEquatable<NewUmOrderSelfTradePreventionMode>
{
    private readonly string? _value;

    public NewUmOrderSelfTradePreventionMode(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewUmOrderSelfTradePreventionMode ExpireTaker { get; } = new("EXPIRE_TAKER");

    public static NewUmOrderSelfTradePreventionMode ExpireBoth { get; } = new("EXPIRE_BOTH");

    public static NewUmOrderSelfTradePreventionMode ExpireMaker { get; } = new("EXPIRE_MAKER");

    static NewUmOrderSelfTradePreventionMode IExtensibleValue<NewUmOrderSelfTradePreventionMode>.Create(string value) => new(value);

    public static bool operator ==(NewUmOrderSelfTradePreventionMode left, NewUmOrderSelfTradePreventionMode right) => left.Equals(right);

    public static bool operator !=(NewUmOrderSelfTradePreventionMode left, NewUmOrderSelfTradePreventionMode right) => !left.Equals(right);

    public static implicit operator NewUmOrderSelfTradePreventionMode(string value) => new(value);

    public static NewUmOrderSelfTradePreventionMode FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewUmOrderSelfTradePreventionMode other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewUmOrderSelfTradePreventionMode other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class NewUmOrderRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    public required NewUmOrderSide Side { get; init; }

    public required NewUmOrderType Type { get; init; }

    /// <summary>
    /// Default BOTH for One-way Mode ; LONG or SHORT for Hedge Mode. It must be sent in Hedge Mode.
    /// </summary>
    public NewUmOrderPositionSide? PositionSide { get; init; }

    /// <summary>Valid values</summary>
    public NewUmOrderTimeInForce? TimeInForce { get; init; }

    /// <summary>Place amount</summary>
    public decimal? Quantity { get; init; }

    /// <summary>"true" or "false". default "false". Cannot be sent in Hedge Mode .</summary>
    public NewUmOrderReduceOnly? ReduceOnly { get; init; }

    /// <summary>Order price</summary>
    public decimal? Price { get; init; }

    /// <summary>
    /// A unique id among open orders. Automatically generated if not sent. Can only be string following the
    /// rule: ^[.A-Z\:/a-z0-9_-]{1,32}$
    /// </summary>
    public string? NewClientOrderId { get; init; }

    /// <summary>ACK, RESULT, default ACK</summary>
    public NewUmOrderNewOrderRespType? NewOrderRespType { get; init; }

    /// <summary>
    /// only avaliable for LIMIT/STOP/TAKE_PROFIT order; can be set to OPPONENT/ OPPONENT_5/ OPPONENT_10/
    /// OPPONENT_20: /QUEUE/ QUEUE_5/ QUEUE_10/ QUEUE_20; Can't be passed together with price
    /// </summary>
    public NewUmOrderPriceMatch? PriceMatch { get; init; }

    /// <summary>
    /// EXPIRE_TAKER: expire taker order when STP triggers/ EXPIRE_MAKER: expire taker order when STP
    /// triggers/ EXPIRE_BOTH: expire both orders when STP triggers
    /// </summary>
    public NewUmOrderSelfTradePreventionMode? SelfTradePreventionMode { get; init; }

    /// <summary>
    /// order cancel time for timeInForce GTD, mandatory when timeInforce set to GTD; order the timestamp
    /// only retains second-level precision, ms part will be ignored; The goodTillDate timestamp must be
    /// greater than the current time plus 600 seconds and smaller than 253402300799000Mode. It must be sent
    /// in Hedge Mode.
    /// </summary>
    public long? GoodTillDate { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryAllCmConditionalOrdersRequest
{
    public string? Symbol { get; init; }

    public long? StrategyId { get; init; }

    /// <summary>Timestamp in ms to get funding from INCLUSIVE.</summary>
    public long? StartTime { get; init; }

    /// <summary>Timestamp in ms to get funding until INCLUSIVE.</summary>
    public long? EndTime { get; init; }

    /// <summary>Number of results returned.</summary>
    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryAllCmOrdersRequest
{
    /// <summary>Symbol</summary>
    public string? Symbol { get; init; }

    public string? Pair { get; init; }

    public long? OrderId { get; init; }

    /// <summary>Timestamp in ms to get funding from INCLUSIVE.</summary>
    public long? StartTime { get; init; }

    /// <summary>Timestamp in ms to get funding until INCLUSIVE.</summary>
    public long? EndTime { get; init; }

    /// <summary>Number of results returned.</summary>
    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryAllCurrentCmOpenConditionalOrdersRequest
{
    public string? Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryAllCurrentCmOpenOrdersRequest
{
    public string? Symbol { get; init; }

    public string? Pair { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryAllCurrentUmOpenAlgoOrdersRequest
{
    public string? AlgoType { get; init; }

    public string? Symbol { get; init; }

    public long? AlgoId { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryAllCurrentUmOpenOrdersRequest
{
    public string? Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryAllMarginAccountOrdersRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    public long? OrderId { get; init; }

    /// <summary>Timestamp in ms to get funding from INCLUSIVE.</summary>
    public long? StartTime { get; init; }

    /// <summary>Timestamp in ms to get funding until INCLUSIVE.</summary>
    public long? EndTime { get; init; }

    /// <summary>Number of results returned.</summary>
    public long? Limit { get; init; }

    /// <summary>Value cannot be greater than 60000</summary>
    public long? RecvWindow { get; init; }
}

public sealed class QueryAllUmOrdersRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    public long? OrderId { get; init; }

    /// <summary>Timestamp in ms to get funding from INCLUSIVE.</summary>
    public long? StartTime { get; init; }

    /// <summary>Timestamp in ms to get funding until INCLUSIVE.</summary>
    public long? EndTime { get; init; }

    /// <summary>Number of results returned.</summary>
    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryCmConditionalOrderHistoryRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    public long? StrategyId { get; init; }

    public string? NewClientStrategyId { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryCmModifyOrderHistoryRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    /// <summary>Order ID</summary>
    public long? OrderId { get; init; }

    /// <summary>Client order ID</summary>
    public string? OrigClientOrderId { get; init; }

    /// <summary>Timestamp in ms to get funding from INCLUSIVE.</summary>
    public long? StartTime { get; init; }

    /// <summary>Timestamp in ms to get funding until INCLUSIVE.</summary>
    public long? EndTime { get; init; }

    /// <summary>Number of results returned.</summary>
    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryCmOrderRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    public long? OrderId { get; init; }

    public string? OrigClientOrderId { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryCurrentCmOpenConditionalOrderRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    public long? StrategyId { get; init; }

    public string? NewClientStrategyId { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryCurrentCmOpenOrderRequest
{
    /// <summary>Trading pair.</summary>
    public required string Symbol { get; init; }

    /// <summary>Order ID.</summary>
    public long? OrderId { get; init; }

    /// <summary>User-defined order ID.</summary>
    public string? OrigClientOrderId { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryCurrentMarginOpenOrderRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    /// <summary>Value cannot be greater than 60000</summary>
    public long? RecvWindow { get; init; }
}

public sealed class QueryCurrentUmOpenAlgoOrderRequest
{
    /// <summary>Algo order ID</summary>
    public long? AlgoId { get; init; }

    /// <summary>Client algo order ID</summary>
    public string? ClientAlgoId { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryCurrentUmOpenOrderRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    public long? OrderId { get; init; }

    public string? OrigClientOrderId { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryMarginAccountOrderRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    public long? OrderId { get; init; }

    public string? OrigClientOrderId { get; init; }

    /// <summary>Value cannot be greater than 60000</summary>
    public long? RecvWindow { get; init; }
}

public sealed class QueryMarginAccountsAllOcoRequest
{
    /// <summary>Trade ID to fetch from.</summary>
    public long? FromId { get; init; }

    /// <summary>Timestamp in ms to get funding from INCLUSIVE.</summary>
    public long? StartTime { get; init; }

    /// <summary>Timestamp in ms to get funding until INCLUSIVE.</summary>
    public long? EndTime { get; init; }

    /// <summary>Number of results returned.</summary>
    public long? Limit { get; init; }

    /// <summary>Value cannot be greater than 60000</summary>
    public long? RecvWindow { get; init; }
}

public sealed class QueryMarginAccountsOcoRequest
{
    /// <summary>Either orderListId or listClientOrderId must be provided</summary>
    public long? OrderListId { get; init; }

    /// <summary>orderListId or listClientOrderId must be provided.</summary>
    public string? OrigClientOrderId { get; init; }

    /// <summary>Value cannot be greater than 60000</summary>
    public long? RecvWindow { get; init; }
}

public sealed class QueryMarginAccountsOpenOcoRequest
{
    /// <summary>Value cannot be greater than 60000</summary>
    public long? RecvWindow { get; init; }
}

public sealed class QueryUmAlgoOrderHistoryRequest
{
    public required string Symbol { get; init; }

    /// <summary>Only return orders &gt;= this algoId</summary>
    public long? AlgoId { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Default 500; max 1000</summary>
    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryUmModifyOrderHistoryRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    /// <summary>Order ID</summary>
    public long? OrderId { get; init; }

    /// <summary>Client order ID</summary>
    public string? OrigClientOrderId { get; init; }

    /// <summary>Timestamp in ms to get funding from INCLUSIVE.</summary>
    public long? StartTime { get; init; }

    /// <summary>Timestamp in ms to get funding until INCLUSIVE.</summary>
    public long? EndTime { get; init; }

    /// <summary>Number of results returned.</summary>
    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryUmOrderRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    public long? OrderId { get; init; }

    public string? OrigClientOrderId { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<QueryUsersCmForceOrdersAutoCloseType>))]
public readonly struct QueryUsersCmForceOrdersAutoCloseType : IExtensibleValue<QueryUsersCmForceOrdersAutoCloseType>, IEquatable<QueryUsersCmForceOrdersAutoCloseType>
{
    private readonly string? _value;

    public QueryUsersCmForceOrdersAutoCloseType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static QueryUsersCmForceOrdersAutoCloseType Liquidation { get; } = new("LIQUIDATION");

    public static QueryUsersCmForceOrdersAutoCloseType Adl { get; } = new("ADL");

    static QueryUsersCmForceOrdersAutoCloseType IExtensibleValue<QueryUsersCmForceOrdersAutoCloseType>.Create(string value) => new(value);

    public static bool operator ==(QueryUsersCmForceOrdersAutoCloseType left, QueryUsersCmForceOrdersAutoCloseType right) => left.Equals(right);

    public static bool operator !=(QueryUsersCmForceOrdersAutoCloseType left, QueryUsersCmForceOrdersAutoCloseType right) => !left.Equals(right);

    public static implicit operator QueryUsersCmForceOrdersAutoCloseType(string value) => new(value);

    public static QueryUsersCmForceOrdersAutoCloseType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is QueryUsersCmForceOrdersAutoCloseType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(QueryUsersCmForceOrdersAutoCloseType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class QueryUsersCmForceOrdersRequest
{
    public string? Symbol { get; init; }

    /// <summary>LIQUIDATION for liquidation orders, ADL for ADL orders.</summary>
    public QueryUsersCmForceOrdersAutoCloseType? AutoCloseType { get; init; }

    /// <summary>Timestamp in ms to get funding from INCLUSIVE.</summary>
    public long? StartTime { get; init; }

    /// <summary>Timestamp in ms to get funding until INCLUSIVE.</summary>
    public long? EndTime { get; init; }

    /// <summary>Number of results returned.</summary>
    public long? Limit { get; init; }

    /// <summary>The value cannot be greater than 60000</summary>
    public long? RecvWindow { get; init; }
}

public sealed class QueryUsersMarginForceOrdersRequest
{
    /// <summary>Timestamp in ms to get funding from INCLUSIVE.</summary>
    public long? StartTime { get; init; }

    /// <summary>Timestamp in ms to get funding until INCLUSIVE.</summary>
    public long? EndTime { get; init; }

    /// <summary>Current page number.</summary>
    public long? Current { get; init; }

    /// <summary>Number of results returned.</summary>
    public long? Size { get; init; }

    /// <summary>The value cannot be greater than 60000</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<QueryUsersUmForceOrdersAutoCloseType>))]
public readonly struct QueryUsersUmForceOrdersAutoCloseType : IExtensibleValue<QueryUsersUmForceOrdersAutoCloseType>, IEquatable<QueryUsersUmForceOrdersAutoCloseType>
{
    private readonly string? _value;

    public QueryUsersUmForceOrdersAutoCloseType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static QueryUsersUmForceOrdersAutoCloseType Liquidation { get; } = new("LIQUIDATION");

    public static QueryUsersUmForceOrdersAutoCloseType Adl { get; } = new("ADL");

    static QueryUsersUmForceOrdersAutoCloseType IExtensibleValue<QueryUsersUmForceOrdersAutoCloseType>.Create(string value) => new(value);

    public static bool operator ==(QueryUsersUmForceOrdersAutoCloseType left, QueryUsersUmForceOrdersAutoCloseType right) => left.Equals(right);

    public static bool operator !=(QueryUsersUmForceOrdersAutoCloseType left, QueryUsersUmForceOrdersAutoCloseType right) => !left.Equals(right);

    public static implicit operator QueryUsersUmForceOrdersAutoCloseType(string value) => new(value);

    public static QueryUsersUmForceOrdersAutoCloseType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is QueryUsersUmForceOrdersAutoCloseType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(QueryUsersUmForceOrdersAutoCloseType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class QueryUsersUmForceOrdersRequest
{
    public string? Symbol { get; init; }

    /// <summary>LIQUIDATION for liquidation orders, ADL for ADL orders.</summary>
    public QueryUsersUmForceOrdersAutoCloseType? AutoCloseType { get; init; }

    /// <summary>Timestamp in ms to get funding from INCLUSIVE.</summary>
    public long? StartTime { get; init; }

    /// <summary>Timestamp in ms to get funding until INCLUSIVE.</summary>
    public long? EndTime { get; init; }

    /// <summary>Number of results returned.</summary>
    public long? Limit { get; init; }

    /// <summary>The value cannot be greater than 60000</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<ToggleBnbBurnOnUmFuturesTradeFeeBurn>))]
public readonly struct ToggleBnbBurnOnUmFuturesTradeFeeBurn : IExtensibleValue<ToggleBnbBurnOnUmFuturesTradeFeeBurn>, IEquatable<ToggleBnbBurnOnUmFuturesTradeFeeBurn>
{
    private readonly string? _value;

    public ToggleBnbBurnOnUmFuturesTradeFeeBurn(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static ToggleBnbBurnOnUmFuturesTradeFeeBurn True { get; } = new("true");

    public static ToggleBnbBurnOnUmFuturesTradeFeeBurn False { get; } = new("false");

    static ToggleBnbBurnOnUmFuturesTradeFeeBurn IExtensibleValue<ToggleBnbBurnOnUmFuturesTradeFeeBurn>.Create(string value) => new(value);

    public static bool operator ==(ToggleBnbBurnOnUmFuturesTradeFeeBurn left, ToggleBnbBurnOnUmFuturesTradeFeeBurn right) => left.Equals(right);

    public static bool operator !=(ToggleBnbBurnOnUmFuturesTradeFeeBurn left, ToggleBnbBurnOnUmFuturesTradeFeeBurn right) => !left.Equals(right);

    public static implicit operator ToggleBnbBurnOnUmFuturesTradeFeeBurn(string value) => new(value);

    public static ToggleBnbBurnOnUmFuturesTradeFeeBurn FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ToggleBnbBurnOnUmFuturesTradeFeeBurn other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ToggleBnbBurnOnUmFuturesTradeFeeBurn other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class ToggleBnbBurnOnUmFuturesTradeRequest
{
    /// <summary>"true": Fee Discount On; "false": Fee Discount Off</summary>
    public required ToggleBnbBurnOnUmFuturesTradeFeeBurn FeeBurn { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class UmAccountTradeListRequest
{
    /// <summary>Symbol</summary>
    public required string Symbol { get; init; }

    /// <summary>Timestamp in ms to get funding from INCLUSIVE.</summary>
    public long? StartTime { get; init; }

    /// <summary>Timestamp in ms to get funding until INCLUSIVE.</summary>
    public long? EndTime { get; init; }

    /// <summary>Trade ID to fetch from.</summary>
    public long? FromId { get; init; }

    /// <summary>Number of results returned.</summary>
    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class UmPositionAdlQuantileEstimationRequest
{
    public string? Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed partial class DerivativesTradingPortfolioMarginRestApi
{

    /// <summary>Cancel All CM Open Conditional Orders (TRADE)</summary>
    /// <remarks>
    /// <para>Cancel All CM Open Conditional Orders</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CancelAllCmOpenConditionalOrdersResponse>> CancelAllCmOpenConditionalOrdersAsync(CancelAllCmOpenConditionalOrdersRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/papi/v1/cm/conditional/allOpenOrders", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CancelAllCmOpenConditionalOrdersResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.CancelAllCmOpenConditionalOrdersResponse, cancellationToken);
    }

    /// <summary>Cancel All CM Open Orders (TRADE)</summary>
    /// <remarks>
    /// <para>Cancel all active LIMIT orders on specific symbol</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CancelAllCmOpenOrdersResponse>> CancelAllCmOpenOrdersAsync(CancelAllCmOpenOrdersRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/papi/v1/cm/allOpenOrders", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CancelAllCmOpenOrdersResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.CancelAllCmOpenOrdersResponse, cancellationToken);
    }

    /// <summary>Cancel All UM Algo Open Orders (TRADE)</summary>
    /// <remarks>
    /// <para>Cancel All UM Algo Open Orders</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CancelAllUmAlgoOpenOrdersResponse>> CancelAllUmAlgoOpenOrdersAsync(CancelAllUmAlgoOpenOrdersRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/papi/v1/um/algo/allOpenOrders", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CancelAllUmAlgoOpenOrdersResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.CancelAllUmAlgoOpenOrdersResponse, cancellationToken);
    }

    /// <summary>Cancel All UM Open Orders (TRADE)</summary>
    /// <remarks>
    /// <para>Cancel all active LIMIT orders on specific symbol</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CancelAllUmOpenOrdersResponse>> CancelAllUmOpenOrdersAsync(CancelAllUmOpenOrdersRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/papi/v1/um/allOpenOrders", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CancelAllUmOpenOrdersResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.CancelAllUmOpenOrdersResponse, cancellationToken);
    }

    /// <summary>Cancel CM Conditional Order (TRADE)</summary>
    /// <remarks>
    /// <para>Cancel CM Conditional Order</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Either strategyId or newClientStrategyId must be sent.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CancelCmConditionalOrderResponse>> CancelCmConditionalOrderAsync(CancelCmConditionalOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/papi/v1/cm/conditional/order", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CancelCmConditionalOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("strategyId", request.StrategyId);
        r.Query("newClientStrategyId", request.NewClientStrategyId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.CancelCmConditionalOrderResponse, cancellationToken);
    }

    /// <summary>Cancel CM Order (TRADE)</summary>
    /// <remarks>
    /// <para>Cancel an active LIMIT order</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Either orderId or origClientOrderId must be sent.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CancelCmOrderResponse>> CancelCmOrderAsync(CancelCmOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/papi/v1/cm/order", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CancelCmOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderId", request.OrderId);
        r.Query("origClientOrderId", request.OrigClientOrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.CancelCmOrderResponse, cancellationToken);
    }

    /// <summary>Cancel Margin Account All Open Orders on a Symbol (TRADE)</summary>
    /// <remarks>
    /// <para>Cancel Margin Account All Open Orders on a Symbol</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<CancelMarginAccountAllOpenOrdersOnASymbolResponseInner>>> CancelMarginAccountAllOpenOrdersOnASymbolAsync(CancelMarginAccountAllOpenOrdersOnASymbolRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/papi/v1/margin/allOpenOrders", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<CancelMarginAccountAllOpenOrdersOnASymbolResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ListCancelMarginAccountAllOpenOrdersOnASymbolResponseInner, cancellationToken);
    }

    /// <summary>Cancel Margin Account OCO Orders (TRADE)</summary>
    /// <remarks>
    /// <para>Cancel Margin Account OCO Orders</para>
    /// <para>Weight(IP): 2</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Additional notes: Canceling an individual leg will cancel the entire OCO</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CancelMarginAccountOcoOrdersResponse>> CancelMarginAccountOcoOrdersAsync(CancelMarginAccountOcoOrdersRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/papi/v1/margin/orderList", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CancelMarginAccountOcoOrdersResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderListId", request.OrderListId);
        r.Query("listClientOrderId", request.ListClientOrderId);
        r.Query("newClientOrderId", request.NewClientOrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.CancelMarginAccountOcoOrdersResponse, cancellationToken);
    }

    /// <summary>Cancel Margin Account Order (TRADE)</summary>
    /// <remarks>
    /// <para>Cancel Margin Account Order</para>
    /// <para>Weight(IP): 2</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Either orderId or origClientOrderId must be sent.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CancelMarginAccountOrderResponse>> CancelMarginAccountOrderAsync(CancelMarginAccountOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/papi/v1/margin/order", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CancelMarginAccountOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderId", request.OrderId);
        r.Query("origClientOrderId", request.OrigClientOrderId);
        r.Query("newClientOrderId", request.NewClientOrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.CancelMarginAccountOrderResponse, cancellationToken);
    }

    /// <summary>Cancel UM Algo Order (TRADE)</summary>
    /// <remarks>
    /// <para>Cancel an active UM algo order</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Either algoId or clientAlgoId must be sent.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CancelUmAlgoOrderResponse>> CancelUmAlgoOrderAsync(CancelUmAlgoOrderRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/papi/v1/um/algo/order", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("algoId", request.AlgoId);
        r.Query("clientAlgoId", request.ClientAlgoId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.CancelUmAlgoOrderResponse, cancellationToken);
    }

    /// <summary>Cancel UM Order (TRADE)</summary>
    /// <remarks>
    /// <para>Cancel an active UM LIMIT order</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Either orderId or origClientOrderId must be sent.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CancelUmOrderResponse>> CancelUmOrderAsync(CancelUmOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/papi/v1/um/order", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CancelUmOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderId", request.OrderId);
        r.Query("origClientOrderId", request.OrigClientOrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.CancelUmOrderResponse, cancellationToken);
    }

    /// <summary>CM Account Trade List (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get trades for a specific account and CM symbol.</para>
    /// <para>Weight: - 20 with symbol</para>
    /// <para>- 40 with pair</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Either symbol or pair must be sent</para>
    /// <para>- symbol and pair cannot be sent together</para>
    /// <para>- pair and fromId cannot be sent together</para>
    /// <para>- OrderId can only be sent together with symbol</para>
    /// <para>- If a pair is sent, tickers for all symbols of the pair will be returned</para>
    /// <para>- The parameter fromId cannot be sent with startTime or endTime</para>
    /// <para>- If startTime and endTime are both not sent, then the last '24 hours' data will be returned.</para>
    /// <para>- The time between startTime and endTime cannot be longer than 24 hours.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<CmAccountTradeListResponseInner>>> CmAccountTradeListAsync(CmAccountTradeListRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/cm/userTrades", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("pair", request.Pair);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("fromId", request.FromId);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ListCmAccountTradeListResponseInner, cancellationToken);
    }

    /// <summary>CM Position ADL Quantile Estimation (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query CM Position ADL Quantile Estimation</para>
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
    public Task<RestApiResponse<List<CmPositionAdlQuantileEstimationResponseInner>>> CmPositionAdlQuantileEstimationAsync(CmPositionAdlQuantileEstimationRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/cm/adlQuantile", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ListCmPositionAdlQuantileEstimationResponseInner, cancellationToken);
    }

    /// <summary>Futures TradFi Perps Contract (USER_DATA)</summary>
    /// <remarks>
    /// <para>Sign TradFi-Perps agreement contract</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<FuturesTradfiPerpsContractResponse>> FuturesTradfiPerpsContractAsync(FuturesTradfiPerpsContractRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/papi/v1/um/stock/contract", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.FuturesTradfiPerpsContractResponse, cancellationToken);
    }

    /// <summary>Get UM Futures BNB Burn Status (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get user's BNB Fee Discount for UM Futures (Fee Discount On or Fee Discount Off )</para>
    /// <para>Weight(IP): 30</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetUmFuturesBnbBurnStatusResponse>> GetUmFuturesBnbBurnStatusAsync(GetUmFuturesBnbBurnStatusRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/um/feeBurn", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.GetUmFuturesBnbBurnStatusResponse, cancellationToken);
    }

    /// <summary>Margin Account Borrow (MARGIN)</summary>
    /// <remarks>
    /// <para>Apply for a margin loan.</para>
    /// <para>Weight(IP): 100</para>
    /// <para>Security Type: MARGIN</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<MarginAccountBorrowResponse>> MarginAccountBorrowAsync(MarginAccountBorrowRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/papi/v1/marginLoan", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<MarginAccountBorrowResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("asset", request.Asset);
        r.Query("amount", request.Amount);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.MarginAccountBorrowResponse, cancellationToken);
    }

    /// <summary>Margin Account New OCO (TRADE)</summary>
    /// <remarks>
    /// <para>Send in a new OCO for a margin account</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Other Info:</para>
    /// <para>- Price Restrictions:</para>
    /// <para>- SELL: Limit Price &gt; Last Price &gt; Stop Price</para>
    /// <para>- BUY: Limit Price * Quantity Restrictions:</para>
    /// <para>- Both legs must have the same quantity</para>
    /// <para>- ICEBERG quantities however do not have to be the same.</para>
    /// <para>- Order Rate Limit</para>
    /// <para>- OCO counts as 2 orders against the order rate limit.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<MarginAccountNewOcoResponse>> MarginAccountNewOcoAsync(MarginAccountNewOcoRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/papi/v1/margin/order/oco", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<MarginAccountNewOcoResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("side", request.Side);
        r.Query("quantity", request.Quantity);
        r.Query("price", request.Price);
        r.Query("stopPrice", request.StopPrice);
        r.Query("listClientOrderId", request.ListClientOrderId);
        r.Query("limitClientOrderId", request.LimitClientOrderId);
        r.Query("limitIcebergQty", request.LimitIcebergQty);
        r.Query("stopClientOrderId", request.StopClientOrderId);
        r.Query("stopLimitPrice", request.StopLimitPrice);
        r.Query("stopIcebergQty", request.StopIcebergQty);
        r.Query("stopLimitTimeInForce", request.StopLimitTimeInForce);
        r.Query("newOrderRespType", request.NewOrderRespType);
        r.Query("sideEffectType", request.SideEffectType);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.MarginAccountNewOcoResponse, cancellationToken);
    }

    /// <summary>Margin Account Repay (MARGIN)</summary>
    /// <remarks>
    /// <para>Repay for a margin loan.</para>
    /// <para>Weight(IP): 100</para>
    /// <para>Security Type: MARGIN</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<MarginAccountRepayResponse>> MarginAccountRepayAsync(MarginAccountRepayRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/papi/v1/repayLoan", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<MarginAccountRepayResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("asset", request.Asset);
        r.Query("amount", request.Amount);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.MarginAccountRepayResponse, cancellationToken);
    }

    /// <summary>Margin Account Repay Debt (TRADE)</summary>
    /// <remarks>
    /// <para>Repay debt for a margin loan.</para>
    /// <para>Weight(IP): 3000</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- The repay asset amount cannot exceed 50000 USD equivalent value for a single request.</para>
    /// <para>- If amount is not sent, all the asset loan will be repaid if having enough specific repay assets.</para>
    /// <para>
    /// - If amount is sent, only the certain amount of the asset loan will be repaid if having enough
    /// specific repay assets.
    /// </para>
    /// <para>
    /// - The system will use the same asset to repay the loan first (if have) no matter whether put the
    /// asset in specifyRepayAssets
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<MarginAccountRepayDebtResponse>> MarginAccountRepayDebtAsync(MarginAccountRepayDebtRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/papi/v1/margin/repay-debt", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<MarginAccountRepayDebtResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("asset", request.Asset);
        r.Query("amount", request.Amount);
        r.Query("specifyRepayAssets", request.SpecifyRepayAssets);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.MarginAccountRepayDebtResponse, cancellationToken);
    }

    /// <summary>Margin Account Trade List (USER_DATA)</summary>
    /// <remarks>
    /// <para>Margin Account Trade List</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>
    /// - Note: * If fromId is set, returns orders with id &gt;= fromId; otherwise returns recent order
    /// history.
    /// </para>
    /// <para>- The interval between startTime and endTime must be less than 24 hours.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<MarginAccountTradeListResponseInner>>> MarginAccountTradeListAsync(MarginAccountTradeListRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/margin/myTrades", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<MarginAccountTradeListResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderId", request.OrderId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("fromId", request.FromId);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ListMarginAccountTradeListResponseInner, cancellationToken);
    }

    /// <summary>Modify CM Order (TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Order modify function, currently only LIMIT order modification is supported, modified orders will be
    /// reordered in the match queue
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Either orderId or origClientOrderId must be sent, and the orderId will prevail if both are sent.</para>
    /// <para>- Both quantity and price must be sent</para>
    /// <para>
    /// - When the new quantity or price doesn't satisfy PRICE_FILTER / PERCENT_FILTER / LOT_SIZE, amendment
    /// will be rejected and the order will stay as it is.
    /// </para>
    /// <para>- However the order will be cancelled by the amendment in the following situations:</para>
    /// <para>- when the order is in partially filled status and the new quantity &lt;= executedQty</para>
    /// <para>- When the order is GTX and the new price will cause it to be executed immediately</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ModifyCmOrderResponse>> ModifyCmOrderAsync(ModifyCmOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("PUT", "/papi/v1/cm/order", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<ModifyCmOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("side", request.Side);
        r.Query("quantity", request.Quantity);
        r.Query("price", request.Price);
        r.Query("orderId", request.OrderId);
        r.Query("origClientOrderId", request.OrigClientOrderId);
        r.Query("priceMatch", request.PriceMatch);
        r.Query("modifyId", request.ModifyId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ModifyCmOrderResponse, cancellationToken);
    }

    /// <summary>Modify UM Order (TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Order modify function, currently only LIMIT order modification is supported, modified orders will be
    /// reordered in the match queue
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Either orderId or origClientOrderId must be sent, and the orderId will prevail if both are sent.</para>
    /// <para>- Both quantity and price must be sent</para>
    /// <para>
    /// - When the new quantity or price doesn't satisfy PRICE_FILTER / PERCENT_FILTER / LOT_SIZE, amendment
    /// will be rejected and the order will stay as it is.
    /// </para>
    /// <para>- However the order will be cancelled by the amendment in the following situations:</para>
    /// <para>- when the order is in partially filled status and the new quantity &lt;= executedQty</para>
    /// <para>- When the order is GTX and the new price will cause it to be executed immediately</para>
    /// <para>- The amendment keeps the order's original selfTradePreventionMode.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ModifyUmOrderResponse>> ModifyUmOrderAsync(ModifyUmOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("PUT", "/papi/v1/um/order", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<ModifyUmOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("side", request.Side);
        r.Query("quantity", request.Quantity);
        r.Query("price", request.Price);
        r.Query("orderId", request.OrderId);
        r.Query("origClientOrderId", request.OrigClientOrderId);
        r.Query("priceMatch", request.PriceMatch);
        r.Query("modifyId", request.ModifyId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ModifyUmOrderResponse, cancellationToken);
    }

    /// <summary>New CM Conditional Order (TRADE)</summary>
    /// <remarks>
    /// <para>New CM Conditional Order</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Additional mandatory parameters based on type:</para>
    /// <para>- Order with type STOP/TAKE_PROFIT, parameter timeInForce can be sent ( default GTC).</para>
    /// <para>- Condition orders will be triggered when:</para>
    /// <para>- STOP, STOP_MARKET:</para>
    /// <para>- BUY: "MARK_PRICE" &gt;= stopPrice</para>
    /// <para>- SELL: "MARK_PRICE" &lt;= stopPrice</para>
    /// <para>- TAKE_PROFIT, TAKE_PROFIT_MARKET:</para>
    /// <para>- BUY: "MARK_PRICE" &lt;= stopPrice</para>
    /// <para>- SELL: "MARK_PRICE" &gt;= stopPrice</para>
    /// <para>- TRAILING_STOP_MARKET:</para>
    /// <para>
    /// - BUY: the lowest mark price after order placed &lt;= activationPrice, and the latest mark price
    /// &gt;= the lowest mark price * (1 + callbackRate)
    /// </para>
    /// <para>
    /// - SELL: the highest mark price after order placed &gt;= activationPrice, and the latest mark price
    /// &lt;= the highest mark price * (1 - callbackRate)
    /// </para>
    /// <para>
    /// - For TRAILING_STOP_MARKET, if you got such error code. {"code": -2021, "msg": "Order would
    /// immediately trigger."} means that the parameters you send do not meet the following requirements:
    /// </para>
    /// <para>- BUY: activationPrice should be smaller than latest mark price.</para>
    /// <para>- SELL: activationPrice should be larger than latest mark price.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<NewCmConditionalOrderResponse>> NewCmConditionalOrderAsync(NewCmConditionalOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/papi/v1/cm/conditional/order", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<NewCmConditionalOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("side", request.Side);
        r.Query("strategyType", request.StrategyType);
        r.Query("positionSide", request.PositionSide);
        r.Query("timeInForce", request.TimeInForce);
        r.Query("quantity", request.Quantity);
        r.Query("reduceOnly", request.ReduceOnly);
        r.Query("price", request.Price);
        r.Query("workingType", request.WorkingType);
        r.Query("priceProtect", request.PriceProtect);
        r.Query("newClientStrategyId", request.NewClientStrategyId);
        r.Query("stopPrice", request.StopPrice);
        r.Query("activationPrice", request.ActivationPrice);
        r.Query("callbackRate", request.CallbackRate);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.NewCmConditionalOrderResponse, cancellationToken);
    }

    /// <summary>New CM Order (TRADE)</summary>
    /// <remarks>
    /// <para>Place new CM order</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Additional mandatory parameters based on type:</para>
    /// <para>- If newOrderRespType is sent as RESULT :</para>
    /// <para>- MARKET order: the final FILLED result of the order will be return directly.</para>
    /// <para>
    /// - LIMIT order with special timeInForce: the final status result of the order(FILLED or EXPIRED) will
    /// be returned directly.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<NewCmOrderResponse>> NewCmOrderAsync(NewCmOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/papi/v1/cm/order", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<NewCmOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("side", request.Side);
        r.Query("type", request.Type);
        r.Query("positionSide", request.PositionSide);
        r.Query("timeInForce", request.TimeInForce);
        r.Query("quantity", request.Quantity);
        r.Query("reduceOnly", request.ReduceOnly);
        r.Query("price", request.Price);
        r.Query("priceMatch", request.PriceMatch);
        r.Query("newClientOrderId", request.NewClientOrderId);
        r.Query("newOrderRespType", request.NewOrderRespType);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.NewCmOrderResponse, cancellationToken);
    }

    /// <summary>New Margin Order (TRADE)</summary>
    /// <remarks>
    /// <para>New Margin Order</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<NewMarginOrderResponse>> NewMarginOrderAsync(NewMarginOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/papi/v1/margin/order", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<NewMarginOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("side", request.Side);
        r.Query("type", request.Type);
        r.Query("quantity", request.Quantity);
        r.Query("quoteOrderQty", request.QuoteOrderQty);
        r.Query("price", request.Price);
        r.Query("stopPrice", request.StopPrice);
        r.Query("newClientOrderId", request.NewClientOrderId);
        r.Query("newOrderRespType", request.NewOrderRespType);
        r.Query("icebergQty", request.IcebergQty);
        r.Query("sideEffectType", request.SideEffectType);
        r.Query("timeInForce", request.TimeInForce);
        r.Query("selfTradePreventionMode", request.SelfTradePreventionMode);
        r.Query("autoRepayAtCancel", request.AutoRepayAtCancel);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.NewMarginOrderResponse, cancellationToken);
    }

    /// <summary>New UM Algo Order (TRADE)</summary>
    /// <remarks>
    /// <para>Place new UM conditional order</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Algo order with type STOP, parameter timeInForce can be sent (default GTC).</para>
    /// <para>- Algo order with type TAKE_PROFIT, parameter timeInForce can be sent (default GTC).</para>
    /// <para>- Condition orders will be triggered when price reaches the triggerPrice.</para>
    /// <para>- STOP, STOP_MARKET: BUY: latest price &gt;= triggerPrice; SELL: latest price &lt;= triggerPrice.</para>
    /// <para>
    /// - TAKE_PROFIT, TAKE_PROFIT_MARKET: BUY: latest price &lt;= triggerPrice; SELL: latest price &gt;=
    /// triggerPrice.
    /// </para>
    /// <para>
    /// - TRAILING_STOP_MARKET: BUY: lowest price after order placed &lt;= activatePrice, and latest price
    /// &gt;= lowest price * (1 + callbackRate); SELL: highest price after order placed &gt;= activatePrice,
    /// and latest price &lt;= highest price * (1 - callbackRate).
    /// </para>
    /// <para>
    /// - STOP_MARKET, TAKE_PROFIT_MARKET with closePosition=true: follow the same rules for conditional
    /// orders; if triggered, close all current long position (if SELL) or current short position (if BUY);
    /// cannot be used with quantity parameter; cannot be used with reduceOnly parameter; in Hedge Mode,
    /// cannot be used with BUY orders in LONG position side, and cannot be used with SELL orders in SHORT
    /// position side.
    /// </para>
    /// <para>- selfTradePreventionMode is only effective when timeInForce set to IOC or GTC or GTD.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<NewUmAlgoOrderResponse>> NewUmAlgoOrderAsync(NewUmAlgoOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/papi/v1/um/algo/order", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<NewUmAlgoOrderResponse>>(new ArgumentNullException(nameof(request)));
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
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.NewUmAlgoOrderResponse, cancellationToken);
    }

    /// <summary>New UM Order (TRADE)</summary>
    /// <remarks>
    /// <para>Place new UM order</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Additional mandatory parameters based on type:</para>
    /// <para>- If newOrderRespType is sent as RESULT :</para>
    /// <para>- MARKET order: the final FILLED result of the order will be return directly.</para>
    /// <para>
    /// - LIMIT order with special timeInForce: the final status result of the order(FILLED or EXPIRED) will
    /// be returned directly.
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
    public Task<RestApiResponse<NewUmOrderResponse>> NewUmOrderAsync(NewUmOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/papi/v1/um/order", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<NewUmOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("side", request.Side);
        r.Query("type", request.Type);
        r.Query("positionSide", request.PositionSide);
        r.Query("timeInForce", request.TimeInForce);
        r.Query("quantity", request.Quantity);
        r.Query("reduceOnly", request.ReduceOnly);
        r.Query("price", request.Price);
        r.Query("newClientOrderId", request.NewClientOrderId);
        r.Query("newOrderRespType", request.NewOrderRespType);
        r.Query("priceMatch", request.PriceMatch);
        r.Query("selfTradePreventionMode", request.SelfTradePreventionMode);
        r.Query("goodTillDate", request.GoodTillDate);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.NewUmOrderResponse, cancellationToken);
    }

    /// <summary>Query All CM Conditional Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query All CM Conditional Orders</para>
    /// <para>Weight: - 1 for a single symbol</para>
    /// <para>- 40 when symbol is omitted</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- These orders will not be found:</para>
    /// <para>- order strategyStatus is CANCELED or EXPIRED, AND</para>
    /// <para>- order has NO filled trade, AND</para>
    /// <para>
    /// - created time + 7 days * The query time period must be less than 7 days( default as the recent 7
    /// days).
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryAllCmConditionalOrdersResponseInner>>> QueryAllCmConditionalOrdersAsync(QueryAllCmConditionalOrdersRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/cm/conditional/allOrders", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("strategyId", request.StrategyId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ListQueryAllCmConditionalOrdersResponseInner, cancellationToken);
    }

    /// <summary>Query All CM Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get all account CM orders; active, canceled, or filled.</para>
    /// <para>Weight: - 20 with symbol</para>
    /// <para>- 40 with pair</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Either symbol or pair must be sent.</para>
    /// <para>
    /// - If orderId is set, it will get orders &gt;= that orderId. Otherwise most recent orders are
    /// returned.
    /// </para>
    /// <para>- These orders will not be found:</para>
    /// <para>- order status is CANCELED or EXPIRED, AND</para>
    /// <para>- order has NO filled trade, AND</para>
    /// <para>- created time + 3 days &lt; current time</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryAllCmOrdersResponseInner>>> QueryAllCmOrdersAsync(QueryAllCmOrdersRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/cm/allOrders", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("pair", request.Pair);
        r.Query("orderId", request.OrderId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ListQueryAllCmOrdersResponseInner, cancellationToken);
    }

    /// <summary>Query All Current CM Open Conditional Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get all open conditional orders on a symbol. Careful when accessing this with no symbol.</para>
    /// <para>Weight: - 1 for a single symbol</para>
    /// <para>- 40 when symbol is omitted</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If the symbol is not sent, orders for all symbols will be returned in an array.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryAllCurrentCmOpenConditionalOrdersResponseInner>>> QueryAllCurrentCmOpenConditionalOrdersAsync(QueryAllCurrentCmOpenConditionalOrdersRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/cm/conditional/openOrders", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ListQueryAllCurrentCmOpenConditionalOrdersResponseInner, cancellationToken);
    }

    /// <summary>Query All Current CM Open Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get all open orders on a symbol.</para>
    /// <para>- If the symbol is not sent, orders for all symbols will be returned in an array.</para>
    /// <para>Weight: - 1 for a single symbol</para>
    /// <para>- 40 when symbol is omitted</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryAllCmOrdersResponseInner>>> QueryAllCurrentCmOpenOrdersAsync(QueryAllCurrentCmOpenOrdersRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/cm/openOrders", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("pair", request.Pair);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ListQueryAllCmOrdersResponseInner, cancellationToken);
    }

    /// <summary>Query All Current UM Open Algo Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Get all UM open algo orders on a symbol. If the symbol is not sent, orders for all symbols will be
    /// returned.
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Weight: 1 for a single symbol; 40 when the symbol parameter is omitted.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryAllCurrentUmOpenAlgoOrdersResponseInner>>> QueryAllCurrentUmOpenAlgoOrdersAsync(QueryAllCurrentUmOpenAlgoOrdersRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/um/algo/openAlgoOrders", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("algoType", request.AlgoType);
        r.Query("symbol", request.Symbol);
        r.Query("algoId", request.AlgoId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ListQueryAllCurrentUmOpenAlgoOrdersResponseInner, cancellationToken);
    }

    /// <summary>Query All Current UM Open Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get all open orders on a symbol.</para>
    /// <para>Weight: - 1 for a single symbol</para>
    /// <para>- 40 when symbol is omitted</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If the symbol is not sent, orders for all symbols will be returned in an array.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryAllCurrentUmOpenOrdersResponseInner>>> QueryAllCurrentUmOpenOrdersAsync(QueryAllCurrentUmOpenOrdersRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/um/openOrders", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ListQueryAllCurrentUmOpenOrdersResponseInner, cancellationToken);
    }

    /// <summary>Query All Margin Account Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query All Margin Account Orders</para>
    /// <para>Weight(IP): 100</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If orderId is set, returns orders with id &gt;= orderId; otherwise returns recent order history.</para>
    /// <para>- For some historical orders, cummulativeQuoteQty &lt; 0 means the data is unavailable at this time.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryAllMarginAccountOrdersResponseInner>>> QueryAllMarginAccountOrdersAsync(QueryAllMarginAccountOrdersRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/margin/allOrders", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<QueryAllMarginAccountOrdersResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderId", request.OrderId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ListQueryAllMarginAccountOrdersResponseInner, cancellationToken);
    }

    /// <summary>Query All UM Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get all account UM orders; active, canceled, or filled.</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>
    /// - If orderId is set, it will get orders &gt;= that orderId. Otherwise most recent orders are
    /// returned.
    /// </para>
    /// <para>- The query time period must be less then 7 days( default as the recent 7 days).</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryAllCurrentUmOpenOrdersResponseInner>>> QueryAllUmOrdersAsync(QueryAllUmOrdersRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/um/allOrders", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<QueryAllCurrentUmOpenOrdersResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderId", request.OrderId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ListQueryAllCurrentUmOpenOrdersResponseInner, cancellationToken);
    }

    /// <summary>Query CM Conditional Order History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query CM Conditional Order History</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Either strategyId or newClientStrategyId must be sent.</para>
    /// <para>- NEW orders will not be found.</para>
    /// <para>- These orders will not be found:</para>
    /// <para>- order status is CANCELED or EXPIRED, AND</para>
    /// <para>- order has NO filled trade, AND</para>
    /// <para>- created time + 7 days &lt; current time</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryCmConditionalOrderHistoryResponse>> QueryCmConditionalOrderHistoryAsync(QueryCmConditionalOrderHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/cm/conditional/orderHistory", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryCmConditionalOrderHistoryResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("strategyId", request.StrategyId);
        r.Query("newClientStrategyId", request.NewClientStrategyId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.QueryCmConditionalOrderHistoryResponse, cancellationToken);
    }

    /// <summary>Query CM Modify Order History (TRADE)</summary>
    /// <remarks>
    /// <para>Get order modification history</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Either orderId or origClientOrderId must be sent, and the orderId will prevail if both are sent.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryCmModifyOrderHistoryResponseInner>>> QueryCmModifyOrderHistoryAsync(QueryCmModifyOrderHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/cm/orderAmendment", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<QueryCmModifyOrderHistoryResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderId", request.OrderId);
        r.Query("origClientOrderId", request.OrigClientOrderId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ListQueryCmModifyOrderHistoryResponseInner, cancellationToken);
    }

    /// <summary>Query CM Order (USER_DATA)</summary>
    /// <remarks>
    /// <para>Check an CM order's status.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Either orderId or origClientOrderId must be sent.</para>
    /// <para>- These orders will not be found:</para>
    /// <para>- order status is CANCELED or EXPIRED, AND</para>
    /// <para>- order has NO filled trade, AND</para>
    /// <para>- created time + 3 days &lt; current time</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryCmOrderResponse>> QueryCmOrderAsync(QueryCmOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/cm/order", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryCmOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderId", request.OrderId);
        r.Query("origClientOrderId", request.OrigClientOrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.QueryCmOrderResponse, cancellationToken);
    }

    /// <summary>Query Current CM Open Conditional Order (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Current CM Open Conditional Order</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Either strategyId or newClientStrategyId must be sent.</para>
    /// <para>
    /// - If the queried order has been triggered, cancelled or expired, the error message "Order does not
    /// exist" will be returned.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryCurrentCmOpenConditionalOrderResponse>> QueryCurrentCmOpenConditionalOrderAsync(QueryCurrentCmOpenConditionalOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/cm/conditional/openOrder", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryCurrentCmOpenConditionalOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("strategyId", request.StrategyId);
        r.Query("newClientStrategyId", request.NewClientStrategyId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.QueryCurrentCmOpenConditionalOrderResponse, cancellationToken);
    }

    /// <summary>Query Current CM Open Order (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query current CM open order</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Either orderId or origClientOrderId must be sent.</para>
    /// <para>
    /// - If the queried order has been filled or cancelled, the error message "Order does not exist" will
    /// be returned.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryAllCmOrdersResponseInner>>> QueryCurrentCmOpenOrderAsync(QueryCurrentCmOpenOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/cm/openOrder", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<QueryAllCmOrdersResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderId", request.OrderId);
        r.Query("origClientOrderId", request.OrigClientOrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ListQueryAllCmOrdersResponseInner, cancellationToken);
    }

    /// <summary>Query Current Margin Open Order (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Current Margin Open Order</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If symbol is not sent, order records for all symbols are returned.</para>
    /// <para>
    /// - When returning all symbols, the request count charged to the rate limiter equals the number of
    /// symbols currently trading on the exchange.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryCurrentMarginOpenOrderResponseInner>>> QueryCurrentMarginOpenOrderAsync(QueryCurrentMarginOpenOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/margin/openOrders", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<QueryCurrentMarginOpenOrderResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ListQueryCurrentMarginOpenOrderResponseInner, cancellationToken);
    }

    /// <summary>Query Current UM Open Algo Order (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Check an UM algo order's status. Orders will not be found if: status is CANCELED/EXPIRED with no
    /// fills and created 3+ days ago; or created 90+ days ago.
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Either algoId or clientAlgoId must be sent. algoId is self-increment for each specific symbol.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryCurrentUmOpenAlgoOrderResponse>> QueryCurrentUmOpenAlgoOrderAsync(QueryCurrentUmOpenAlgoOrderRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/um/algo/algoOrder", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("algoId", request.AlgoId);
        r.Query("clientAlgoId", request.ClientAlgoId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.QueryCurrentUmOpenAlgoOrderResponse, cancellationToken);
    }

    /// <summary>Query Current UM Open Order (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query current UM open order</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Either orderId or origClientOrderId must be sent.</para>
    /// <para>
    /// - If the queried order has been filled or cancelled, the error message "Order does not exist" will
    /// be returned.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryCurrentUmOpenOrderResponse>> QueryCurrentUmOpenOrderAsync(QueryCurrentUmOpenOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/um/openOrder", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryCurrentUmOpenOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderId", request.OrderId);
        r.Query("origClientOrderId", request.OrigClientOrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.QueryCurrentUmOpenOrderResponse, cancellationToken);
    }

    /// <summary>Query Margin Account Order (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Margin Account Order</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Either orderId or origClientOrderId must be sent.</para>
    /// <para>- For some historical orders, cummulativeQuoteQty &lt; 0 means the data is unavailable at this time.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryMarginAccountOrderResponse>> QueryMarginAccountOrderAsync(QueryMarginAccountOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/margin/order", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryMarginAccountOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderId", request.OrderId);
        r.Query("origClientOrderId", request.OrigClientOrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.QueryMarginAccountOrderResponse, cancellationToken);
    }

    /// <summary>Query Margin Account's all OCO (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query all OCO for a specific margin account based on provided optional parameters</para>
    /// <para>Weight(IP): 100</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryMarginAccountsAllOcoResponseInner>>> QueryMarginAccountsAllOcoAsync(QueryMarginAccountsAllOcoRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/margin/allOrderList", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("fromId", request.FromId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ListQueryMarginAccountsAllOcoResponseInner, cancellationToken);
    }

    /// <summary>Query Margin Account's OCO (USER_DATA)</summary>
    /// <remarks>
    /// <para>Retrieves a specific OCO based on provided optional parameters</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryMarginAccountsOcoResponse>> QueryMarginAccountsOcoAsync(QueryMarginAccountsOcoRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/margin/orderList", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("orderListId", request.OrderListId);
        r.Query("origClientOrderId", request.OrigClientOrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.QueryMarginAccountsOcoResponse, cancellationToken);
    }

    /// <summary>Query Margin Account's Open OCO (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Margin Account's Open OCO</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryMarginAccountsOpenOcoResponseInner>>> QueryMarginAccountsOpenOcoAsync(QueryMarginAccountsOpenOcoRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/margin/openOrderList", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ListQueryMarginAccountsOpenOcoResponseInner, cancellationToken);
    }

    /// <summary>Query UM Algo Order History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get all algo orders: ACTIVE, CANCELED, TRIGGERED or FINISHED.</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If algoId is set, it will get orders &gt;= that algoId. Otherwise most recent orders are returned.</para>
    /// <para>- The query time period must be less than 7 days (default as the recent 7 days).</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryUmAlgoOrderHistoryResponseInner>>> QueryUmAlgoOrderHistoryAsync(QueryUmAlgoOrderHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/um/algo/allAlgoOrders", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<QueryUmAlgoOrderHistoryResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("algoId", request.AlgoId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ListQueryUmAlgoOrderHistoryResponseInner, cancellationToken);
    }

    /// <summary>Query UM Modify Order History (TRADE)</summary>
    /// <remarks>
    /// <para>Get order modification history</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Either orderId or origClientOrderId must be sent, and the orderId will prevail if both are sent.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryUmModifyOrderHistoryResponseInner>>> QueryUmModifyOrderHistoryAsync(QueryUmModifyOrderHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/um/orderAmendment", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<QueryUmModifyOrderHistoryResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderId", request.OrderId);
        r.Query("origClientOrderId", request.OrigClientOrderId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ListQueryUmModifyOrderHistoryResponseInner, cancellationToken);
    }

    /// <summary>Query UM Order (USER_DATA)</summary>
    /// <remarks>
    /// <para>Check an UM order's status.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- These orders will not be found:</para>
    /// <para>- Either orderId or origClientOrderId must be sent.</para>
    /// <para>- order status is CANCELED or EXPIRED, AND</para>
    /// <para>- order has NO filled trade, AND</para>
    /// <para>- created time + 3 days &lt; current time</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryUmOrderResponse>> QueryUmOrderAsync(QueryUmOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/um/order", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryUmOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("orderId", request.OrderId);
        r.Query("origClientOrderId", request.OrigClientOrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.QueryUmOrderResponse, cancellationToken);
    }

    /// <summary>Query User's CM Force Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query User's CM Force Orders</para>
    /// <para>Weight: - 20 with symbol</para>
    /// <para>- 50 without symbol</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If "autoCloseType" is not sent, orders with both of the types will be returned</para>
    /// <para>- If "startTime" is not sent, data within 7 days before "endTime" can be queried</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryUsersCmForceOrdersResponseInner>>> QueryUsersCmForceOrdersAsync(QueryUsersCmForceOrdersRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/cm/forceOrders", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("autoCloseType", request.AutoCloseType);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ListQueryUsersCmForceOrdersResponseInner, cancellationToken);
    }

    /// <summary>Query User's Margin Force Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query user's margin force orders</para>
    /// <para>
    /// &gt; Note: Portfolio Margin accounts liquidated through the Risk-Based Liquidation Adjustment flow
    /// will not have any order or trade records returned by this endpoint. Query the capital flow endpoint
    /// instead: Query Cross Isolated Margin Capital Flow.
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryUsersMarginForceOrdersResponse>> QueryUsersMarginForceOrdersAsync(QueryUsersMarginForceOrdersRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/margin/forceOrders", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.QueryUsersMarginForceOrdersResponse, cancellationToken);
    }

    /// <summary>Query User's UM Force Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query User's UM Force Orders</para>
    /// <para>Weight: - 20 with symbol</para>
    /// <para>- 50 without symbol</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If autoCloseType is not sent, orders with both of the types will be returned</para>
    /// <para>- If startTime is not sent, data within 7 days before endTime can be queried</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryUsersUmForceOrdersResponseInner>>> QueryUsersUmForceOrdersAsync(QueryUsersUmForceOrdersRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/um/forceOrders", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("autoCloseType", request.AutoCloseType);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ListQueryUsersUmForceOrdersResponseInner, cancellationToken);
    }

    /// <summary>Toggle BNB Burn On UM Futures Trade (TRADE)</summary>
    /// <remarks>
    /// <para>Change user's BNB Fee Discount for UM Futures (Fee Discount On or Fee Discount Off ) on EVERY symbol</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- The BNB would not be collected from UM-PM account to the Portfolio Margin account.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ToggleBnbBurnOnUmFuturesTradeResponse>> ToggleBnbBurnOnUmFuturesTradeAsync(ToggleBnbBurnOnUmFuturesTradeRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/papi/v1/um/feeBurn", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<ToggleBnbBurnOnUmFuturesTradeResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("feeBurn", request.FeeBurn);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ToggleBnbBurnOnUmFuturesTradeResponse, cancellationToken);
    }

    /// <summary>UM Account Trade List (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get trades for a specific account and UM symbol.</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If startTime and endTime are both not sent, then the last '7 days' data will be returned.</para>
    /// <para>- The time between startTime and endTime cannot be longer than 7 days.</para>
    /// <para>- The parameter fromId cannot be sent with startTime or endTime.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<UmAccountTradeListResponseInner>>> UmAccountTradeListAsync(UmAccountTradeListRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/um/userTrades", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<UmAccountTradeListResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("fromId", request.FromId);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ListUmAccountTradeListResponseInner, cancellationToken);
    }

    /// <summary>UM Position ADL Quantile Estimation (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query UM Position ADL Quantile Estimation</para>
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
    public Task<RestApiResponse<List<UmPositionAdlQuantileEstimationResponseInner>>> UmPositionAdlQuantileEstimationAsync(UmPositionAdlQuantileEstimationRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/um/adlQuantile", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.ListUmPositionAdlQuantileEstimationResponseInner, cancellationToken);
    }
}
