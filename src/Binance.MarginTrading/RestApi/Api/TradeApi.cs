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

namespace Binance.MarginTrading.RestApi;

[JsonConverter(typeof(ExtensibleValueConverter<CreateSpecialKeyPermissionMode>))]
public readonly struct CreateSpecialKeyPermissionMode : IExtensibleValue<CreateSpecialKeyPermissionMode>, IEquatable<CreateSpecialKeyPermissionMode>
{
    private readonly string? _value;

    public CreateSpecialKeyPermissionMode(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static CreateSpecialKeyPermissionMode Trade { get; } = new("TRADE");

    public static CreateSpecialKeyPermissionMode Read { get; } = new("READ");

    static CreateSpecialKeyPermissionMode IExtensibleValue<CreateSpecialKeyPermissionMode>.Create(string value) => new(value);

    public static bool operator ==(CreateSpecialKeyPermissionMode left, CreateSpecialKeyPermissionMode right) => left.Equals(right);

    public static bool operator !=(CreateSpecialKeyPermissionMode left, CreateSpecialKeyPermissionMode right) => !left.Equals(right);

    public static implicit operator CreateSpecialKeyPermissionMode(string value) => new(value);

    public static CreateSpecialKeyPermissionMode FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is CreateSpecialKeyPermissionMode other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(CreateSpecialKeyPermissionMode other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class CreateSpecialKeyRequest
{
    public required string ApiName { get; init; }

    public string? Symbol { get; init; }

    /// <summary>Can be added in batches, separated by commas. Max 30 for an API key</summary>
    public string? Ip { get; init; }

    /// <summary>
    /// - If publicKey is inputted it will create an RSA or Ed25519 key. 2. Need to be encoded to
    /// URL-encoded format
    /// </summary>
    public string? PublicKey { get; init; }

    /// <summary>
    /// This parameter is only for the Ed25519 API key, and does not effact for other encryption methods.
    /// The value can be TRADE (TRADE for all permissions) or READ (READ for USER_DATA, FIX_API_READ_ONLY).
    /// The default value is TRADE.
    /// </summary>
    public CreateSpecialKeyPermissionMode? PermissionMode { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class DeleteSpecialKeyRequest
{
    public string? ApiName { get; init; }

    public string? Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class EditIpForSpecialKeyRequest
{
    /// <summary>Can be added in batches, separated by commas. Max 30 for an API key</summary>
    public required string Ip { get; init; }

    /// <summary>isolated margin pair</summary>
    public string? Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class ExitSpecialKeyModeRequest
{
    /// <summary>The value cannot be greater than 60000</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetForceLiquidationRecordRequest
{
    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    public string? IsolatedSymbol { get; init; }

    public long? Current { get; init; }

    public long? Size { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetSmallLiabilityExchangeCoinListRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class GetSmallLiabilityExchangeHistoryRequest
{
    public required long Current { get; init; }

    public required long Size { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class LiquidationLoanRepayRequest
{
    /// <summary>The asset to repay (e.g. USDT, USDC)</summary>
    public required string Asset { get; init; }

    /// <summary>Repayment amount, must be greater than 0</summary>
    public required decimal Amount { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountCancelAllOpenOrdersOnASymbolIsIsolated>))]
public readonly struct MarginAccountCancelAllOpenOrdersOnASymbolIsIsolated : IExtensibleValue<MarginAccountCancelAllOpenOrdersOnASymbolIsIsolated>, IEquatable<MarginAccountCancelAllOpenOrdersOnASymbolIsIsolated>
{
    private readonly string? _value;

    public MarginAccountCancelAllOpenOrdersOnASymbolIsIsolated(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountCancelAllOpenOrdersOnASymbolIsIsolated True { get; } = new("TRUE");

    public static MarginAccountCancelAllOpenOrdersOnASymbolIsIsolated False { get; } = new("FALSE");

    static MarginAccountCancelAllOpenOrdersOnASymbolIsIsolated IExtensibleValue<MarginAccountCancelAllOpenOrdersOnASymbolIsIsolated>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountCancelAllOpenOrdersOnASymbolIsIsolated left, MarginAccountCancelAllOpenOrdersOnASymbolIsIsolated right) => left.Equals(right);

    public static bool operator !=(MarginAccountCancelAllOpenOrdersOnASymbolIsIsolated left, MarginAccountCancelAllOpenOrdersOnASymbolIsIsolated right) => !left.Equals(right);

    public static implicit operator MarginAccountCancelAllOpenOrdersOnASymbolIsIsolated(string value) => new(value);

    public static MarginAccountCancelAllOpenOrdersOnASymbolIsIsolated FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountCancelAllOpenOrdersOnASymbolIsIsolated other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountCancelAllOpenOrdersOnASymbolIsIsolated other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class MarginAccountCancelAllOpenOrdersOnASymbolRequest
{
    public required string Symbol { get; init; }

    public MarginAccountCancelAllOpenOrdersOnASymbolIsIsolated? IsIsolated { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountCancelOcoIsIsolated>))]
public readonly struct MarginAccountCancelOcoIsIsolated : IExtensibleValue<MarginAccountCancelOcoIsIsolated>, IEquatable<MarginAccountCancelOcoIsIsolated>
{
    private readonly string? _value;

    public MarginAccountCancelOcoIsIsolated(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountCancelOcoIsIsolated True { get; } = new("TRUE");

    public static MarginAccountCancelOcoIsIsolated False { get; } = new("FALSE");

    static MarginAccountCancelOcoIsIsolated IExtensibleValue<MarginAccountCancelOcoIsIsolated>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountCancelOcoIsIsolated left, MarginAccountCancelOcoIsIsolated right) => left.Equals(right);

    public static bool operator !=(MarginAccountCancelOcoIsIsolated left, MarginAccountCancelOcoIsIsolated right) => !left.Equals(right);

    public static implicit operator MarginAccountCancelOcoIsIsolated(string value) => new(value);

    public static MarginAccountCancelOcoIsIsolated FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountCancelOcoIsIsolated other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountCancelOcoIsIsolated other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class MarginAccountCancelOcoRequest
{
    public required string Symbol { get; init; }

    public MarginAccountCancelOcoIsIsolated? IsIsolated { get; init; }

    public long? OrderListId { get; init; }

    public string? ListClientOrderId { get; init; }

    public string? NewClientOrderId { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountCancelOrderIsIsolated>))]
public readonly struct MarginAccountCancelOrderIsIsolated : IExtensibleValue<MarginAccountCancelOrderIsIsolated>, IEquatable<MarginAccountCancelOrderIsIsolated>
{
    private readonly string? _value;

    public MarginAccountCancelOrderIsIsolated(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountCancelOrderIsIsolated True { get; } = new("TRUE");

    public static MarginAccountCancelOrderIsIsolated False { get; } = new("FALSE");

    static MarginAccountCancelOrderIsIsolated IExtensibleValue<MarginAccountCancelOrderIsIsolated>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountCancelOrderIsIsolated left, MarginAccountCancelOrderIsIsolated right) => left.Equals(right);

    public static bool operator !=(MarginAccountCancelOrderIsIsolated left, MarginAccountCancelOrderIsIsolated right) => !left.Equals(right);

    public static implicit operator MarginAccountCancelOrderIsIsolated(string value) => new(value);

    public static MarginAccountCancelOrderIsIsolated FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountCancelOrderIsIsolated other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountCancelOrderIsIsolated other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class MarginAccountCancelOrderRequest
{
    public required string Symbol { get; init; }

    public MarginAccountCancelOrderIsIsolated? IsIsolated { get; init; }

    public long? OrderId { get; init; }

    public string? OrigClientOrderId { get; init; }

    public string? NewClientOrderId { get; init; }

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

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOcoIsIsolated>))]
public readonly struct MarginAccountNewOcoIsIsolated : IExtensibleValue<MarginAccountNewOcoIsIsolated>, IEquatable<MarginAccountNewOcoIsIsolated>
{
    private readonly string? _value;

    public MarginAccountNewOcoIsIsolated(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOcoIsIsolated True { get; } = new("TRUE");

    public static MarginAccountNewOcoIsIsolated False { get; } = new("FALSE");

    static MarginAccountNewOcoIsIsolated IExtensibleValue<MarginAccountNewOcoIsIsolated>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOcoIsIsolated left, MarginAccountNewOcoIsIsolated right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOcoIsIsolated left, MarginAccountNewOcoIsIsolated right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOcoIsIsolated(string value) => new(value);

    public static MarginAccountNewOcoIsIsolated FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOcoIsIsolated other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOcoIsIsolated other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

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

    public static MarginAccountNewOcoStopLimitTimeInForce Fok { get; } = new("FOK");

    public static MarginAccountNewOcoStopLimitTimeInForce Ioc { get; } = new("IOC");

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

    public static MarginAccountNewOcoNewOrderRespType Full { get; } = new("FULL");

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

    public static MarginAccountNewOcoSideEffectType AutoBorrowRepay { get; } = new("AUTO_BORROW_REPAY");

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

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOcoSelfTradePreventionMode>))]
public readonly struct MarginAccountNewOcoSelfTradePreventionMode : IExtensibleValue<MarginAccountNewOcoSelfTradePreventionMode>, IEquatable<MarginAccountNewOcoSelfTradePreventionMode>
{
    private readonly string? _value;

    public MarginAccountNewOcoSelfTradePreventionMode(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOcoSelfTradePreventionMode ExpireTaker { get; } = new("EXPIRE_TAKER");

    public static MarginAccountNewOcoSelfTradePreventionMode ExpireMaker { get; } = new("EXPIRE_MAKER");

    public static MarginAccountNewOcoSelfTradePreventionMode ExpireBoth { get; } = new("EXPIRE_BOTH");

    public static MarginAccountNewOcoSelfTradePreventionMode None { get; } = new("NONE");

    static MarginAccountNewOcoSelfTradePreventionMode IExtensibleValue<MarginAccountNewOcoSelfTradePreventionMode>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOcoSelfTradePreventionMode left, MarginAccountNewOcoSelfTradePreventionMode right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOcoSelfTradePreventionMode left, MarginAccountNewOcoSelfTradePreventionMode right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOcoSelfTradePreventionMode(string value) => new(value);

    public static MarginAccountNewOcoSelfTradePreventionMode FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOcoSelfTradePreventionMode other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOcoSelfTradePreventionMode other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class MarginAccountNewOcoRequest
{
    public required string Symbol { get; init; }

    public required MarginAccountNewOcoSide Side { get; init; }

    public required decimal Quantity { get; init; }

    public required decimal Price { get; init; }

    public required decimal StopPrice { get; init; }

    public MarginAccountNewOcoIsIsolated? IsIsolated { get; init; }

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

    public MarginAccountNewOcoStopLimitTimeInForce? StopLimitTimeInForce { get; init; }

    public MarginAccountNewOcoNewOrderRespType? NewOrderRespType { get; init; }

    public MarginAccountNewOcoSideEffectType? SideEffectType { get; init; }

    public MarginAccountNewOcoSelfTradePreventionMode? SelfTradePreventionMode { get; init; }

    /// <summary>
    /// Only when MARGIN_BUY or AUTO_BORROW_REPAY order takes effect, true means that the debt generated by
    /// the order needs to be repay after the order is cancelled.
    /// </summary>
    public bool? AutoRepayAtCancel { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOrderSide>))]
public readonly struct MarginAccountNewOrderSide : IExtensibleValue<MarginAccountNewOrderSide>, IEquatable<MarginAccountNewOrderSide>
{
    private readonly string? _value;

    public MarginAccountNewOrderSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOrderSide Buy { get; } = new("BUY");

    public static MarginAccountNewOrderSide Sell { get; } = new("SELL");

    static MarginAccountNewOrderSide IExtensibleValue<MarginAccountNewOrderSide>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOrderSide left, MarginAccountNewOrderSide right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOrderSide left, MarginAccountNewOrderSide right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOrderSide(string value) => new(value);

    public static MarginAccountNewOrderSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOrderSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOrderSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOrderType>))]
public readonly struct MarginAccountNewOrderType : IExtensibleValue<MarginAccountNewOrderType>, IEquatable<MarginAccountNewOrderType>
{
    private readonly string? _value;

    public MarginAccountNewOrderType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOrderType Limit { get; } = new("LIMIT");

    public static MarginAccountNewOrderType Market { get; } = new("MARKET");

    public static MarginAccountNewOrderType StopLoss { get; } = new("STOP_LOSS");

    public static MarginAccountNewOrderType StopLossLimit { get; } = new("STOP_LOSS_LIMIT");

    public static MarginAccountNewOrderType TakeProfit { get; } = new("TAKE_PROFIT");

    public static MarginAccountNewOrderType TakeProfitLimit { get; } = new("TAKE_PROFIT_LIMIT");

    public static MarginAccountNewOrderType LimitMaker { get; } = new("LIMIT_MAKER");

    static MarginAccountNewOrderType IExtensibleValue<MarginAccountNewOrderType>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOrderType left, MarginAccountNewOrderType right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOrderType left, MarginAccountNewOrderType right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOrderType(string value) => new(value);

    public static MarginAccountNewOrderType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOrderType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOrderType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOrderIsIsolated>))]
public readonly struct MarginAccountNewOrderIsIsolated : IExtensibleValue<MarginAccountNewOrderIsIsolated>, IEquatable<MarginAccountNewOrderIsIsolated>
{
    private readonly string? _value;

    public MarginAccountNewOrderIsIsolated(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOrderIsIsolated True { get; } = new("TRUE");

    public static MarginAccountNewOrderIsIsolated False { get; } = new("FALSE");

    static MarginAccountNewOrderIsIsolated IExtensibleValue<MarginAccountNewOrderIsIsolated>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOrderIsIsolated left, MarginAccountNewOrderIsIsolated right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOrderIsIsolated left, MarginAccountNewOrderIsIsolated right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOrderIsIsolated(string value) => new(value);

    public static MarginAccountNewOrderIsIsolated FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOrderIsIsolated other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOrderIsIsolated other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOrderNewOrderRespType>))]
public readonly struct MarginAccountNewOrderNewOrderRespType : IExtensibleValue<MarginAccountNewOrderNewOrderRespType>, IEquatable<MarginAccountNewOrderNewOrderRespType>
{
    private readonly string? _value;

    public MarginAccountNewOrderNewOrderRespType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOrderNewOrderRespType Ack { get; } = new("ACK");

    public static MarginAccountNewOrderNewOrderRespType Result { get; } = new("RESULT");

    public static MarginAccountNewOrderNewOrderRespType Full { get; } = new("FULL");

    static MarginAccountNewOrderNewOrderRespType IExtensibleValue<MarginAccountNewOrderNewOrderRespType>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOrderNewOrderRespType left, MarginAccountNewOrderNewOrderRespType right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOrderNewOrderRespType left, MarginAccountNewOrderNewOrderRespType right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOrderNewOrderRespType(string value) => new(value);

    public static MarginAccountNewOrderNewOrderRespType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOrderNewOrderRespType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOrderNewOrderRespType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOrderSideEffectType>))]
public readonly struct MarginAccountNewOrderSideEffectType : IExtensibleValue<MarginAccountNewOrderSideEffectType>, IEquatable<MarginAccountNewOrderSideEffectType>
{
    private readonly string? _value;

    public MarginAccountNewOrderSideEffectType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOrderSideEffectType NoSideEffect { get; } = new("NO_SIDE_EFFECT");

    public static MarginAccountNewOrderSideEffectType MarginBuy { get; } = new("MARGIN_BUY");

    public static MarginAccountNewOrderSideEffectType AutoRepay { get; } = new("AUTO_REPAY");

    public static MarginAccountNewOrderSideEffectType AutoBorrowRepay { get; } = new("AUTO_BORROW_REPAY");

    static MarginAccountNewOrderSideEffectType IExtensibleValue<MarginAccountNewOrderSideEffectType>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOrderSideEffectType left, MarginAccountNewOrderSideEffectType right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOrderSideEffectType left, MarginAccountNewOrderSideEffectType right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOrderSideEffectType(string value) => new(value);

    public static MarginAccountNewOrderSideEffectType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOrderSideEffectType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOrderSideEffectType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOrderTimeInForce>))]
public readonly struct MarginAccountNewOrderTimeInForce : IExtensibleValue<MarginAccountNewOrderTimeInForce>, IEquatable<MarginAccountNewOrderTimeInForce>
{
    private readonly string? _value;

    public MarginAccountNewOrderTimeInForce(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOrderTimeInForce Gtc { get; } = new("GTC");

    public static MarginAccountNewOrderTimeInForce Ioc { get; } = new("IOC");

    public static MarginAccountNewOrderTimeInForce Fok { get; } = new("FOK");

    static MarginAccountNewOrderTimeInForce IExtensibleValue<MarginAccountNewOrderTimeInForce>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOrderTimeInForce left, MarginAccountNewOrderTimeInForce right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOrderTimeInForce left, MarginAccountNewOrderTimeInForce right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOrderTimeInForce(string value) => new(value);

    public static MarginAccountNewOrderTimeInForce FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOrderTimeInForce other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOrderTimeInForce other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOrderSelfTradePreventionMode>))]
public readonly struct MarginAccountNewOrderSelfTradePreventionMode : IExtensibleValue<MarginAccountNewOrderSelfTradePreventionMode>, IEquatable<MarginAccountNewOrderSelfTradePreventionMode>
{
    private readonly string? _value;

    public MarginAccountNewOrderSelfTradePreventionMode(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOrderSelfTradePreventionMode ExpireTaker { get; } = new("EXPIRE_TAKER");

    public static MarginAccountNewOrderSelfTradePreventionMode ExpireMaker { get; } = new("EXPIRE_MAKER");

    public static MarginAccountNewOrderSelfTradePreventionMode ExpireBoth { get; } = new("EXPIRE_BOTH");

    public static MarginAccountNewOrderSelfTradePreventionMode None { get; } = new("NONE");

    static MarginAccountNewOrderSelfTradePreventionMode IExtensibleValue<MarginAccountNewOrderSelfTradePreventionMode>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOrderSelfTradePreventionMode left, MarginAccountNewOrderSelfTradePreventionMode right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOrderSelfTradePreventionMode left, MarginAccountNewOrderSelfTradePreventionMode right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOrderSelfTradePreventionMode(string value) => new(value);

    public static MarginAccountNewOrderSelfTradePreventionMode FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOrderSelfTradePreventionMode other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOrderSelfTradePreventionMode other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class MarginAccountNewOrderRequest
{
    public required string Symbol { get; init; }

    public required MarginAccountNewOrderSide Side { get; init; }

    public required MarginAccountNewOrderType Type { get; init; }

    public MarginAccountNewOrderIsIsolated? IsIsolated { get; init; }

    public decimal? Quantity { get; init; }

    public decimal? QuoteOrderQty { get; init; }

    public decimal? Price { get; init; }

    /// <summary>Used with STOP_LOSS, STOP_LOSS_LIMIT, TAKE_PROFIT, and TAKE_PROFIT_LIMIT orders.</summary>
    public decimal? StopPrice { get; init; }

    /// <summary>A unique id among open orders. Automatically generated if not sent.</summary>
    public string? NewClientOrderId { get; init; }

    /// <summary>
    /// Used with LIMIT, STOP_LOSS_LIMIT, and TAKE_PROFIT_LIMIT to create an iceberg order.
    /// </summary>
    public decimal? IcebergQty { get; init; }

    /// <summary>MARKET and LIMIT order types default to FULL, all other orders default to ACK.</summary>
    public MarginAccountNewOrderNewOrderRespType? NewOrderRespType { get; init; }

    public MarginAccountNewOrderSideEffectType? SideEffectType { get; init; }

    public MarginAccountNewOrderTimeInForce? TimeInForce { get; init; }

    public MarginAccountNewOrderSelfTradePreventionMode? SelfTradePreventionMode { get; init; }

    /// <summary>Used with STOP_LOSS, STOP_LOSS_LIMIT, TAKE_PROFIT, and TAKE_PROFIT_LIMIT orders.</summary>
    public long? TrailingDelta { get; init; }

    /// <summary>
    /// Only when MARGIN_BUY or AUTO_BORROW_REPAY order takes effect, true means that the debt generated by
    /// the order needs to be repaid after the order is cancelled.
    /// </summary>
    public bool? AutoRepayAtCancel { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOtoWorkingType>))]
public readonly struct MarginAccountNewOtoWorkingType : IExtensibleValue<MarginAccountNewOtoWorkingType>, IEquatable<MarginAccountNewOtoWorkingType>
{
    private readonly string? _value;

    public MarginAccountNewOtoWorkingType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOtoWorkingType Limit { get; } = new("LIMIT");

    public static MarginAccountNewOtoWorkingType LimitMaker { get; } = new("LIMIT_MAKER");

    static MarginAccountNewOtoWorkingType IExtensibleValue<MarginAccountNewOtoWorkingType>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOtoWorkingType left, MarginAccountNewOtoWorkingType right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOtoWorkingType left, MarginAccountNewOtoWorkingType right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOtoWorkingType(string value) => new(value);

    public static MarginAccountNewOtoWorkingType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOtoWorkingType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOtoWorkingType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOtoWorkingSide>))]
public readonly struct MarginAccountNewOtoWorkingSide : IExtensibleValue<MarginAccountNewOtoWorkingSide>, IEquatable<MarginAccountNewOtoWorkingSide>
{
    private readonly string? _value;

    public MarginAccountNewOtoWorkingSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOtoWorkingSide Buy { get; } = new("BUY");

    public static MarginAccountNewOtoWorkingSide Sell { get; } = new("SELL");

    static MarginAccountNewOtoWorkingSide IExtensibleValue<MarginAccountNewOtoWorkingSide>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOtoWorkingSide left, MarginAccountNewOtoWorkingSide right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOtoWorkingSide left, MarginAccountNewOtoWorkingSide right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOtoWorkingSide(string value) => new(value);

    public static MarginAccountNewOtoWorkingSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOtoWorkingSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOtoWorkingSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOtoPendingType>))]
public readonly struct MarginAccountNewOtoPendingType : IExtensibleValue<MarginAccountNewOtoPendingType>, IEquatable<MarginAccountNewOtoPendingType>
{
    private readonly string? _value;

    public MarginAccountNewOtoPendingType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOtoPendingType Limit { get; } = new("LIMIT");

    public static MarginAccountNewOtoPendingType Market { get; } = new("MARKET");

    public static MarginAccountNewOtoPendingType StopLoss { get; } = new("STOP_LOSS");

    public static MarginAccountNewOtoPendingType StopLossLimit { get; } = new("STOP_LOSS_LIMIT");

    public static MarginAccountNewOtoPendingType TakeProfit { get; } = new("TAKE_PROFIT");

    public static MarginAccountNewOtoPendingType TakeProfitLimit { get; } = new("TAKE_PROFIT_LIMIT");

    public static MarginAccountNewOtoPendingType LimitMaker { get; } = new("LIMIT_MAKER");

    static MarginAccountNewOtoPendingType IExtensibleValue<MarginAccountNewOtoPendingType>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOtoPendingType left, MarginAccountNewOtoPendingType right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOtoPendingType left, MarginAccountNewOtoPendingType right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOtoPendingType(string value) => new(value);

    public static MarginAccountNewOtoPendingType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOtoPendingType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOtoPendingType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOtoPendingSide>))]
public readonly struct MarginAccountNewOtoPendingSide : IExtensibleValue<MarginAccountNewOtoPendingSide>, IEquatable<MarginAccountNewOtoPendingSide>
{
    private readonly string? _value;

    public MarginAccountNewOtoPendingSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOtoPendingSide Buy { get; } = new("BUY");

    public static MarginAccountNewOtoPendingSide Sell { get; } = new("SELL");

    static MarginAccountNewOtoPendingSide IExtensibleValue<MarginAccountNewOtoPendingSide>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOtoPendingSide left, MarginAccountNewOtoPendingSide right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOtoPendingSide left, MarginAccountNewOtoPendingSide right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOtoPendingSide(string value) => new(value);

    public static MarginAccountNewOtoPendingSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOtoPendingSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOtoPendingSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOtoIsIsolated>))]
public readonly struct MarginAccountNewOtoIsIsolated : IExtensibleValue<MarginAccountNewOtoIsIsolated>, IEquatable<MarginAccountNewOtoIsIsolated>
{
    private readonly string? _value;

    public MarginAccountNewOtoIsIsolated(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOtoIsIsolated True { get; } = new("TRUE");

    public static MarginAccountNewOtoIsIsolated False { get; } = new("FALSE");

    static MarginAccountNewOtoIsIsolated IExtensibleValue<MarginAccountNewOtoIsIsolated>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOtoIsIsolated left, MarginAccountNewOtoIsIsolated right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOtoIsIsolated left, MarginAccountNewOtoIsIsolated right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOtoIsIsolated(string value) => new(value);

    public static MarginAccountNewOtoIsIsolated FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOtoIsIsolated other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOtoIsIsolated other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOtoNewOrderRespType>))]
public readonly struct MarginAccountNewOtoNewOrderRespType : IExtensibleValue<MarginAccountNewOtoNewOrderRespType>, IEquatable<MarginAccountNewOtoNewOrderRespType>
{
    private readonly string? _value;

    public MarginAccountNewOtoNewOrderRespType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOtoNewOrderRespType Ack { get; } = new("ACK");

    public static MarginAccountNewOtoNewOrderRespType Result { get; } = new("RESULT");

    public static MarginAccountNewOtoNewOrderRespType Full { get; } = new("FULL");

    static MarginAccountNewOtoNewOrderRespType IExtensibleValue<MarginAccountNewOtoNewOrderRespType>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOtoNewOrderRespType left, MarginAccountNewOtoNewOrderRespType right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOtoNewOrderRespType left, MarginAccountNewOtoNewOrderRespType right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOtoNewOrderRespType(string value) => new(value);

    public static MarginAccountNewOtoNewOrderRespType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOtoNewOrderRespType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOtoNewOrderRespType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOtoSideEffectType>))]
public readonly struct MarginAccountNewOtoSideEffectType : IExtensibleValue<MarginAccountNewOtoSideEffectType>, IEquatable<MarginAccountNewOtoSideEffectType>
{
    private readonly string? _value;

    public MarginAccountNewOtoSideEffectType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOtoSideEffectType NoSideEffect { get; } = new("NO_SIDE_EFFECT");

    public static MarginAccountNewOtoSideEffectType MarginBuy { get; } = new("MARGIN_BUY");

    public static MarginAccountNewOtoSideEffectType AutoBorrowRepay { get; } = new("AUTO_BORROW_REPAY");

    static MarginAccountNewOtoSideEffectType IExtensibleValue<MarginAccountNewOtoSideEffectType>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOtoSideEffectType left, MarginAccountNewOtoSideEffectType right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOtoSideEffectType left, MarginAccountNewOtoSideEffectType right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOtoSideEffectType(string value) => new(value);

    public static MarginAccountNewOtoSideEffectType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOtoSideEffectType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOtoSideEffectType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOtoSelfTradePreventionMode>))]
public readonly struct MarginAccountNewOtoSelfTradePreventionMode : IExtensibleValue<MarginAccountNewOtoSelfTradePreventionMode>, IEquatable<MarginAccountNewOtoSelfTradePreventionMode>
{
    private readonly string? _value;

    public MarginAccountNewOtoSelfTradePreventionMode(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOtoSelfTradePreventionMode ExpireTaker { get; } = new("EXPIRE_TAKER");

    public static MarginAccountNewOtoSelfTradePreventionMode ExpireMaker { get; } = new("EXPIRE_MAKER");

    public static MarginAccountNewOtoSelfTradePreventionMode ExpireBoth { get; } = new("EXPIRE_BOTH");

    public static MarginAccountNewOtoSelfTradePreventionMode None { get; } = new("NONE");

    static MarginAccountNewOtoSelfTradePreventionMode IExtensibleValue<MarginAccountNewOtoSelfTradePreventionMode>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOtoSelfTradePreventionMode left, MarginAccountNewOtoSelfTradePreventionMode right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOtoSelfTradePreventionMode left, MarginAccountNewOtoSelfTradePreventionMode right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOtoSelfTradePreventionMode(string value) => new(value);

    public static MarginAccountNewOtoSelfTradePreventionMode FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOtoSelfTradePreventionMode other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOtoSelfTradePreventionMode other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOtoWorkingTimeInForce>))]
public readonly struct MarginAccountNewOtoWorkingTimeInForce : IExtensibleValue<MarginAccountNewOtoWorkingTimeInForce>, IEquatable<MarginAccountNewOtoWorkingTimeInForce>
{
    private readonly string? _value;

    public MarginAccountNewOtoWorkingTimeInForce(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOtoWorkingTimeInForce Gtc { get; } = new("GTC");

    public static MarginAccountNewOtoWorkingTimeInForce Ioc { get; } = new("IOC");

    public static MarginAccountNewOtoWorkingTimeInForce Fok { get; } = new("FOK");

    static MarginAccountNewOtoWorkingTimeInForce IExtensibleValue<MarginAccountNewOtoWorkingTimeInForce>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOtoWorkingTimeInForce left, MarginAccountNewOtoWorkingTimeInForce right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOtoWorkingTimeInForce left, MarginAccountNewOtoWorkingTimeInForce right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOtoWorkingTimeInForce(string value) => new(value);

    public static MarginAccountNewOtoWorkingTimeInForce FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOtoWorkingTimeInForce other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOtoWorkingTimeInForce other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOtoPendingTimeInForce>))]
public readonly struct MarginAccountNewOtoPendingTimeInForce : IExtensibleValue<MarginAccountNewOtoPendingTimeInForce>, IEquatable<MarginAccountNewOtoPendingTimeInForce>
{
    private readonly string? _value;

    public MarginAccountNewOtoPendingTimeInForce(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOtoPendingTimeInForce Gtc { get; } = new("GTC");

    public static MarginAccountNewOtoPendingTimeInForce Ioc { get; } = new("IOC");

    public static MarginAccountNewOtoPendingTimeInForce Fok { get; } = new("FOK");

    static MarginAccountNewOtoPendingTimeInForce IExtensibleValue<MarginAccountNewOtoPendingTimeInForce>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOtoPendingTimeInForce left, MarginAccountNewOtoPendingTimeInForce right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOtoPendingTimeInForce left, MarginAccountNewOtoPendingTimeInForce right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOtoPendingTimeInForce(string value) => new(value);

    public static MarginAccountNewOtoPendingTimeInForce FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOtoPendingTimeInForce other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOtoPendingTimeInForce other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class MarginAccountNewOtoRequest
{
    public required string Symbol { get; init; }

    public required MarginAccountNewOtoWorkingType WorkingType { get; init; }

    public required MarginAccountNewOtoWorkingSide WorkingSide { get; init; }

    public required decimal WorkingPrice { get; init; }

    /// <summary>Sets the quantity for the working order.</summary>
    public required decimal WorkingQuantity { get; init; }

    /// <summary>This can only be used if workingTimeInForce is GTC.</summary>
    public required decimal WorkingIcebergQty { get; init; }

    public required MarginAccountNewOtoPendingType PendingType { get; init; }

    public required MarginAccountNewOtoPendingSide PendingSide { get; init; }

    /// <summary>Sets the quantity for the pending order.</summary>
    public required decimal PendingQuantity { get; init; }

    public MarginAccountNewOtoIsIsolated? IsIsolated { get; init; }

    /// <summary>
    /// Arbitrary unique ID among open order lists. Automatically generated if not sent. A new order list
    /// with the same listClientOrderId is accepted only when the previous one is filled or completely
    /// expired. listClientOrderId is distinct from the workingClientOrderId and the pendingClientOrderId.
    /// </summary>
    public string? ListClientOrderId { get; init; }

    /// <summary>MARKET and LIMIT order types default to FULL, all other orders default to ACK.</summary>
    public MarginAccountNewOtoNewOrderRespType? NewOrderRespType { get; init; }

    public MarginAccountNewOtoSideEffectType? SideEffectType { get; init; }

    public MarginAccountNewOtoSelfTradePreventionMode? SelfTradePreventionMode { get; init; }

    /// <summary>
    /// Only when MARGIN_BUY order takes effect, true means that the debt generated by the order needs to be
    /// repaid after the order is cancelled.
    /// </summary>
    public bool? AutoRepayAtCancel { get; init; }

    /// <summary>
    /// Arbitrary unique ID among open orders for the working order. Automatically generated if not sent.
    /// </summary>
    public string? WorkingClientOrderId { get; init; }

    public MarginAccountNewOtoWorkingTimeInForce? WorkingTimeInForce { get; init; }

    /// <summary>
    /// Arbitrary unique ID among open orders for the pending order. Automatically generated if not sent.
    /// </summary>
    public string? PendingClientOrderId { get; init; }

    public decimal? PendingPrice { get; init; }

    public decimal? PendingStopPrice { get; init; }

    public decimal? PendingTrailingDelta { get; init; }

    /// <summary>This can only be used if pendingTimeInForce is GTC.</summary>
    public decimal? PendingIcebergQty { get; init; }

    public MarginAccountNewOtoPendingTimeInForce? PendingTimeInForce { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOtocoWorkingType>))]
public readonly struct MarginAccountNewOtocoWorkingType : IExtensibleValue<MarginAccountNewOtocoWorkingType>, IEquatable<MarginAccountNewOtocoWorkingType>
{
    private readonly string? _value;

    public MarginAccountNewOtocoWorkingType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOtocoWorkingType Limit { get; } = new("LIMIT");

    public static MarginAccountNewOtocoWorkingType LimitMaker { get; } = new("LIMIT_MAKER");

    static MarginAccountNewOtocoWorkingType IExtensibleValue<MarginAccountNewOtocoWorkingType>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOtocoWorkingType left, MarginAccountNewOtocoWorkingType right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOtocoWorkingType left, MarginAccountNewOtocoWorkingType right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOtocoWorkingType(string value) => new(value);

    public static MarginAccountNewOtocoWorkingType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOtocoWorkingType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOtocoWorkingType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOtocoWorkingSide>))]
public readonly struct MarginAccountNewOtocoWorkingSide : IExtensibleValue<MarginAccountNewOtocoWorkingSide>, IEquatable<MarginAccountNewOtocoWorkingSide>
{
    private readonly string? _value;

    public MarginAccountNewOtocoWorkingSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOtocoWorkingSide Buy { get; } = new("BUY");

    public static MarginAccountNewOtocoWorkingSide Sell { get; } = new("SELL");

    static MarginAccountNewOtocoWorkingSide IExtensibleValue<MarginAccountNewOtocoWorkingSide>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOtocoWorkingSide left, MarginAccountNewOtocoWorkingSide right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOtocoWorkingSide left, MarginAccountNewOtocoWorkingSide right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOtocoWorkingSide(string value) => new(value);

    public static MarginAccountNewOtocoWorkingSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOtocoWorkingSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOtocoWorkingSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOtocoPendingSide>))]
public readonly struct MarginAccountNewOtocoPendingSide : IExtensibleValue<MarginAccountNewOtocoPendingSide>, IEquatable<MarginAccountNewOtocoPendingSide>
{
    private readonly string? _value;

    public MarginAccountNewOtocoPendingSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOtocoPendingSide Buy { get; } = new("BUY");

    public static MarginAccountNewOtocoPendingSide Sell { get; } = new("SELL");

    static MarginAccountNewOtocoPendingSide IExtensibleValue<MarginAccountNewOtocoPendingSide>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOtocoPendingSide left, MarginAccountNewOtocoPendingSide right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOtocoPendingSide left, MarginAccountNewOtocoPendingSide right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOtocoPendingSide(string value) => new(value);

    public static MarginAccountNewOtocoPendingSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOtocoPendingSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOtocoPendingSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOtocoPendingAboveType>))]
public readonly struct MarginAccountNewOtocoPendingAboveType : IExtensibleValue<MarginAccountNewOtocoPendingAboveType>, IEquatable<MarginAccountNewOtocoPendingAboveType>
{
    private readonly string? _value;

    public MarginAccountNewOtocoPendingAboveType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOtocoPendingAboveType LimitMaker { get; } = new("LIMIT_MAKER");

    public static MarginAccountNewOtocoPendingAboveType StopLoss { get; } = new("STOP_LOSS");

    public static MarginAccountNewOtocoPendingAboveType StopLossLimit { get; } = new("STOP_LOSS_LIMIT");

    static MarginAccountNewOtocoPendingAboveType IExtensibleValue<MarginAccountNewOtocoPendingAboveType>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOtocoPendingAboveType left, MarginAccountNewOtocoPendingAboveType right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOtocoPendingAboveType left, MarginAccountNewOtocoPendingAboveType right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOtocoPendingAboveType(string value) => new(value);

    public static MarginAccountNewOtocoPendingAboveType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOtocoPendingAboveType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOtocoPendingAboveType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOtocoIsIsolated>))]
public readonly struct MarginAccountNewOtocoIsIsolated : IExtensibleValue<MarginAccountNewOtocoIsIsolated>, IEquatable<MarginAccountNewOtocoIsIsolated>
{
    private readonly string? _value;

    public MarginAccountNewOtocoIsIsolated(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOtocoIsIsolated True { get; } = new("TRUE");

    public static MarginAccountNewOtocoIsIsolated False { get; } = new("FALSE");

    static MarginAccountNewOtocoIsIsolated IExtensibleValue<MarginAccountNewOtocoIsIsolated>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOtocoIsIsolated left, MarginAccountNewOtocoIsIsolated right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOtocoIsIsolated left, MarginAccountNewOtocoIsIsolated right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOtocoIsIsolated(string value) => new(value);

    public static MarginAccountNewOtocoIsIsolated FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOtocoIsIsolated other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOtocoIsIsolated other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOtocoSideEffectType>))]
public readonly struct MarginAccountNewOtocoSideEffectType : IExtensibleValue<MarginAccountNewOtocoSideEffectType>, IEquatable<MarginAccountNewOtocoSideEffectType>
{
    private readonly string? _value;

    public MarginAccountNewOtocoSideEffectType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOtocoSideEffectType NoSideEffect { get; } = new("NO_SIDE_EFFECT");

    public static MarginAccountNewOtocoSideEffectType MarginBuy { get; } = new("MARGIN_BUY");

    public static MarginAccountNewOtocoSideEffectType AutoBorrowRepay { get; } = new("AUTO_BORROW_REPAY");

    static MarginAccountNewOtocoSideEffectType IExtensibleValue<MarginAccountNewOtocoSideEffectType>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOtocoSideEffectType left, MarginAccountNewOtocoSideEffectType right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOtocoSideEffectType left, MarginAccountNewOtocoSideEffectType right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOtocoSideEffectType(string value) => new(value);

    public static MarginAccountNewOtocoSideEffectType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOtocoSideEffectType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOtocoSideEffectType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOtocoNewOrderRespType>))]
public readonly struct MarginAccountNewOtocoNewOrderRespType : IExtensibleValue<MarginAccountNewOtocoNewOrderRespType>, IEquatable<MarginAccountNewOtocoNewOrderRespType>
{
    private readonly string? _value;

    public MarginAccountNewOtocoNewOrderRespType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOtocoNewOrderRespType Ack { get; } = new("ACK");

    public static MarginAccountNewOtocoNewOrderRespType Result { get; } = new("RESULT");

    public static MarginAccountNewOtocoNewOrderRespType Full { get; } = new("FULL");

    static MarginAccountNewOtocoNewOrderRespType IExtensibleValue<MarginAccountNewOtocoNewOrderRespType>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOtocoNewOrderRespType left, MarginAccountNewOtocoNewOrderRespType right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOtocoNewOrderRespType left, MarginAccountNewOtocoNewOrderRespType right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOtocoNewOrderRespType(string value) => new(value);

    public static MarginAccountNewOtocoNewOrderRespType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOtocoNewOrderRespType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOtocoNewOrderRespType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOtocoSelfTradePreventionMode>))]
public readonly struct MarginAccountNewOtocoSelfTradePreventionMode : IExtensibleValue<MarginAccountNewOtocoSelfTradePreventionMode>, IEquatable<MarginAccountNewOtocoSelfTradePreventionMode>
{
    private readonly string? _value;

    public MarginAccountNewOtocoSelfTradePreventionMode(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOtocoSelfTradePreventionMode ExpireTaker { get; } = new("EXPIRE_TAKER");

    public static MarginAccountNewOtocoSelfTradePreventionMode ExpireMaker { get; } = new("EXPIRE_MAKER");

    public static MarginAccountNewOtocoSelfTradePreventionMode ExpireBoth { get; } = new("EXPIRE_BOTH");

    public static MarginAccountNewOtocoSelfTradePreventionMode None { get; } = new("NONE");

    static MarginAccountNewOtocoSelfTradePreventionMode IExtensibleValue<MarginAccountNewOtocoSelfTradePreventionMode>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOtocoSelfTradePreventionMode left, MarginAccountNewOtocoSelfTradePreventionMode right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOtocoSelfTradePreventionMode left, MarginAccountNewOtocoSelfTradePreventionMode right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOtocoSelfTradePreventionMode(string value) => new(value);

    public static MarginAccountNewOtocoSelfTradePreventionMode FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOtocoSelfTradePreventionMode other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOtocoSelfTradePreventionMode other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOtocoWorkingTimeInForce>))]
public readonly struct MarginAccountNewOtocoWorkingTimeInForce : IExtensibleValue<MarginAccountNewOtocoWorkingTimeInForce>, IEquatable<MarginAccountNewOtocoWorkingTimeInForce>
{
    private readonly string? _value;

    public MarginAccountNewOtocoWorkingTimeInForce(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOtocoWorkingTimeInForce Gtc { get; } = new("GTC");

    public static MarginAccountNewOtocoWorkingTimeInForce Ioc { get; } = new("IOC");

    public static MarginAccountNewOtocoWorkingTimeInForce Fok { get; } = new("FOK");

    static MarginAccountNewOtocoWorkingTimeInForce IExtensibleValue<MarginAccountNewOtocoWorkingTimeInForce>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOtocoWorkingTimeInForce left, MarginAccountNewOtocoWorkingTimeInForce right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOtocoWorkingTimeInForce left, MarginAccountNewOtocoWorkingTimeInForce right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOtocoWorkingTimeInForce(string value) => new(value);

    public static MarginAccountNewOtocoWorkingTimeInForce FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOtocoWorkingTimeInForce other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOtocoWorkingTimeInForce other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOtocoPendingAboveTimeInForce>))]
public readonly struct MarginAccountNewOtocoPendingAboveTimeInForce : IExtensibleValue<MarginAccountNewOtocoPendingAboveTimeInForce>, IEquatable<MarginAccountNewOtocoPendingAboveTimeInForce>
{
    private readonly string? _value;

    public MarginAccountNewOtocoPendingAboveTimeInForce(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOtocoPendingAboveTimeInForce Gtc { get; } = new("GTC");

    public static MarginAccountNewOtocoPendingAboveTimeInForce Ioc { get; } = new("IOC");

    public static MarginAccountNewOtocoPendingAboveTimeInForce Fok { get; } = new("FOK");

    static MarginAccountNewOtocoPendingAboveTimeInForce IExtensibleValue<MarginAccountNewOtocoPendingAboveTimeInForce>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOtocoPendingAboveTimeInForce left, MarginAccountNewOtocoPendingAboveTimeInForce right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOtocoPendingAboveTimeInForce left, MarginAccountNewOtocoPendingAboveTimeInForce right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOtocoPendingAboveTimeInForce(string value) => new(value);

    public static MarginAccountNewOtocoPendingAboveTimeInForce FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOtocoPendingAboveTimeInForce other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOtocoPendingAboveTimeInForce other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOtocoPendingBelowType>))]
public readonly struct MarginAccountNewOtocoPendingBelowType : IExtensibleValue<MarginAccountNewOtocoPendingBelowType>, IEquatable<MarginAccountNewOtocoPendingBelowType>
{
    private readonly string? _value;

    public MarginAccountNewOtocoPendingBelowType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOtocoPendingBelowType LimitMaker { get; } = new("LIMIT_MAKER");

    public static MarginAccountNewOtocoPendingBelowType StopLoss { get; } = new("STOP_LOSS");

    public static MarginAccountNewOtocoPendingBelowType StopLossLimit { get; } = new("STOP_LOSS_LIMIT");

    static MarginAccountNewOtocoPendingBelowType IExtensibleValue<MarginAccountNewOtocoPendingBelowType>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOtocoPendingBelowType left, MarginAccountNewOtocoPendingBelowType right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOtocoPendingBelowType left, MarginAccountNewOtocoPendingBelowType right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOtocoPendingBelowType(string value) => new(value);

    public static MarginAccountNewOtocoPendingBelowType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOtocoPendingBelowType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOtocoPendingBelowType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginAccountNewOtocoPendingBelowTimeInForce>))]
public readonly struct MarginAccountNewOtocoPendingBelowTimeInForce : IExtensibleValue<MarginAccountNewOtocoPendingBelowTimeInForce>, IEquatable<MarginAccountNewOtocoPendingBelowTimeInForce>
{
    private readonly string? _value;

    public MarginAccountNewOtocoPendingBelowTimeInForce(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginAccountNewOtocoPendingBelowTimeInForce Gtc { get; } = new("GTC");

    public static MarginAccountNewOtocoPendingBelowTimeInForce Ioc { get; } = new("IOC");

    public static MarginAccountNewOtocoPendingBelowTimeInForce Fok { get; } = new("FOK");

    static MarginAccountNewOtocoPendingBelowTimeInForce IExtensibleValue<MarginAccountNewOtocoPendingBelowTimeInForce>.Create(string value) => new(value);

    public static bool operator ==(MarginAccountNewOtocoPendingBelowTimeInForce left, MarginAccountNewOtocoPendingBelowTimeInForce right) => left.Equals(right);

    public static bool operator !=(MarginAccountNewOtocoPendingBelowTimeInForce left, MarginAccountNewOtocoPendingBelowTimeInForce right) => !left.Equals(right);

    public static implicit operator MarginAccountNewOtocoPendingBelowTimeInForce(string value) => new(value);

    public static MarginAccountNewOtocoPendingBelowTimeInForce FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginAccountNewOtocoPendingBelowTimeInForce other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginAccountNewOtocoPendingBelowTimeInForce other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class MarginAccountNewOtocoRequest
{
    public required string Symbol { get; init; }

    public required MarginAccountNewOtocoWorkingType WorkingType { get; init; }

    public required MarginAccountNewOtocoWorkingSide WorkingSide { get; init; }

    public required decimal WorkingPrice { get; init; }

    public required decimal WorkingQuantity { get; init; }

    public required MarginAccountNewOtocoPendingSide PendingSide { get; init; }

    public required decimal PendingQuantity { get; init; }

    public required MarginAccountNewOtocoPendingAboveType PendingAboveType { get; init; }

    public MarginAccountNewOtocoIsIsolated? IsIsolated { get; init; }

    public MarginAccountNewOtocoSideEffectType? SideEffectType { get; init; }

    /// <summary>
    /// Only when MARGIN_BUY order takes effect, true means that the debt generated by the order needs to be
    /// repaid after the order is cancelled.
    /// </summary>
    public bool? AutoRepayAtCancel { get; init; }

    /// <summary>
    /// Arbitrary unique ID among open order lists. Automatically generated if not sent. A new order list
    /// with the same listClientOrderId is accepted only when the previous one is filled or completely
    /// expired. listClientOrderId is distinct from the workingClientOrderId, pendingAboveClientOrderId, and
    /// the pendingBelowClientOrderId.
    /// </summary>
    public string? ListClientOrderId { get; init; }

    public MarginAccountNewOtocoNewOrderRespType? NewOrderRespType { get; init; }

    public MarginAccountNewOtocoSelfTradePreventionMode? SelfTradePreventionMode { get; init; }

    /// <summary>
    /// Arbitrary unique ID among open orders for the working order. Automatically generated if not sent.
    /// </summary>
    public string? WorkingClientOrderId { get; init; }

    /// <summary>This can only be used if workingTimeInForce is GTC.</summary>
    public decimal? WorkingIcebergQty { get; init; }

    public MarginAccountNewOtocoWorkingTimeInForce? WorkingTimeInForce { get; init; }

    /// <summary>
    /// Arbitrary unique ID among open orders for the pending above order. Automatically generated if not
    /// sent.
    /// </summary>
    public string? PendingAboveClientOrderId { get; init; }

    public decimal? PendingAbovePrice { get; init; }

    public decimal? PendingAboveStopPrice { get; init; }

    public decimal? PendingAboveTrailingDelta { get; init; }

    /// <summary>This can only be used if pendingAboveTimeInForce is GTC.</summary>
    public decimal? PendingAboveIcebergQty { get; init; }

    public MarginAccountNewOtocoPendingAboveTimeInForce? PendingAboveTimeInForce { get; init; }

    public MarginAccountNewOtocoPendingBelowType? PendingBelowType { get; init; }

    /// <summary>
    /// Arbitrary unique ID among open orders for the pending below order. Automatically generated if not
    /// sent.
    /// </summary>
    public string? PendingBelowClientOrderId { get; init; }

    public decimal? PendingBelowPrice { get; init; }

    public decimal? PendingBelowStopPrice { get; init; }

    public decimal? PendingBelowTrailingDelta { get; init; }

    /// <summary>This can only be used if pendingBelowTimeInForce is GTC.</summary>
    public decimal? PendingBelowIcebergQty { get; init; }

    public MarginAccountNewOtocoPendingBelowTimeInForce? PendingBelowTimeInForce { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<MarginManualLiquidationType>))]
public readonly struct MarginManualLiquidationType : IExtensibleValue<MarginManualLiquidationType>, IEquatable<MarginManualLiquidationType>
{
    private readonly string? _value;

    public MarginManualLiquidationType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static MarginManualLiquidationType Margin { get; } = new("MARGIN");

    public static MarginManualLiquidationType Isolated { get; } = new("ISOLATED");

    static MarginManualLiquidationType IExtensibleValue<MarginManualLiquidationType>.Create(string value) => new(value);

    public static bool operator ==(MarginManualLiquidationType left, MarginManualLiquidationType right) => left.Equals(right);

    public static bool operator !=(MarginManualLiquidationType left, MarginManualLiquidationType right) => !left.Equals(right);

    public static implicit operator MarginManualLiquidationType(string value) => new(value);

    public static MarginManualLiquidationType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is MarginManualLiquidationType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(MarginManualLiquidationType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class MarginManualLiquidationRequest
{
    public required MarginManualLiquidationType Type { get; init; }

    /// <summary>When type selects ISOLATED, symbol must be filled in</summary>
    public string? Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<QueryCurrentMarginOrderCountUsageIsIsolated>))]
public readonly struct QueryCurrentMarginOrderCountUsageIsIsolated : IExtensibleValue<QueryCurrentMarginOrderCountUsageIsIsolated>, IEquatable<QueryCurrentMarginOrderCountUsageIsIsolated>
{
    private readonly string? _value;

    public QueryCurrentMarginOrderCountUsageIsIsolated(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static QueryCurrentMarginOrderCountUsageIsIsolated True { get; } = new("TRUE");

    public static QueryCurrentMarginOrderCountUsageIsIsolated False { get; } = new("FALSE");

    static QueryCurrentMarginOrderCountUsageIsIsolated IExtensibleValue<QueryCurrentMarginOrderCountUsageIsIsolated>.Create(string value) => new(value);

    public static bool operator ==(QueryCurrentMarginOrderCountUsageIsIsolated left, QueryCurrentMarginOrderCountUsageIsIsolated right) => left.Equals(right);

    public static bool operator !=(QueryCurrentMarginOrderCountUsageIsIsolated left, QueryCurrentMarginOrderCountUsageIsIsolated right) => !left.Equals(right);

    public static implicit operator QueryCurrentMarginOrderCountUsageIsIsolated(string value) => new(value);

    public static QueryCurrentMarginOrderCountUsageIsIsolated FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is QueryCurrentMarginOrderCountUsageIsIsolated other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(QueryCurrentMarginOrderCountUsageIsIsolated other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class QueryCurrentMarginOrderCountUsageRequest
{
    public QueryCurrentMarginOrderCountUsageIsIsolated? IsIsolated { get; init; }

    public string? Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryLiquidationLoanRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class QueryLiquidationLoanRepayHistoryRequest
{
    /// <summary>
    /// Start time in Unix timestamp (milliseconds). Defaults to 7 days ago if not specified
    /// </summary>
    public long? StartTime { get; init; }

    /// <summary>End time in Unix timestamp (milliseconds). Defaults to now if not specified</summary>
    public long? EndTime { get; init; }

    /// <summary>Current page number, default 1</summary>
    public long? Current { get; init; }

    /// <summary>Page size, default 50</summary>
    public long? Size { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<QueryMarginAccountsAllOcoIsIsolated>))]
public readonly struct QueryMarginAccountsAllOcoIsIsolated : IExtensibleValue<QueryMarginAccountsAllOcoIsIsolated>, IEquatable<QueryMarginAccountsAllOcoIsIsolated>
{
    private readonly string? _value;

    public QueryMarginAccountsAllOcoIsIsolated(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static QueryMarginAccountsAllOcoIsIsolated True { get; } = new("TRUE");

    public static QueryMarginAccountsAllOcoIsIsolated False { get; } = new("FALSE");

    static QueryMarginAccountsAllOcoIsIsolated IExtensibleValue<QueryMarginAccountsAllOcoIsIsolated>.Create(string value) => new(value);

    public static bool operator ==(QueryMarginAccountsAllOcoIsIsolated left, QueryMarginAccountsAllOcoIsIsolated right) => left.Equals(right);

    public static bool operator !=(QueryMarginAccountsAllOcoIsIsolated left, QueryMarginAccountsAllOcoIsIsolated right) => !left.Equals(right);

    public static implicit operator QueryMarginAccountsAllOcoIsIsolated(string value) => new(value);

    public static QueryMarginAccountsAllOcoIsIsolated FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is QueryMarginAccountsAllOcoIsIsolated other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(QueryMarginAccountsAllOcoIsIsolated other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class QueryMarginAccountsAllOcoRequest
{
    public QueryMarginAccountsAllOcoIsIsolated? IsIsolated { get; init; }

    public string? Symbol { get; init; }

    public long? FromId { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<QueryMarginAccountsAllOrdersIsIsolated>))]
public readonly struct QueryMarginAccountsAllOrdersIsIsolated : IExtensibleValue<QueryMarginAccountsAllOrdersIsIsolated>, IEquatable<QueryMarginAccountsAllOrdersIsIsolated>
{
    private readonly string? _value;

    public QueryMarginAccountsAllOrdersIsIsolated(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static QueryMarginAccountsAllOrdersIsIsolated True { get; } = new("TRUE");

    public static QueryMarginAccountsAllOrdersIsIsolated False { get; } = new("FALSE");

    static QueryMarginAccountsAllOrdersIsIsolated IExtensibleValue<QueryMarginAccountsAllOrdersIsIsolated>.Create(string value) => new(value);

    public static bool operator ==(QueryMarginAccountsAllOrdersIsIsolated left, QueryMarginAccountsAllOrdersIsIsolated right) => left.Equals(right);

    public static bool operator !=(QueryMarginAccountsAllOrdersIsIsolated left, QueryMarginAccountsAllOrdersIsIsolated right) => !left.Equals(right);

    public static implicit operator QueryMarginAccountsAllOrdersIsIsolated(string value) => new(value);

    public static QueryMarginAccountsAllOrdersIsIsolated FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is QueryMarginAccountsAllOrdersIsIsolated other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(QueryMarginAccountsAllOrdersIsIsolated other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class QueryMarginAccountsAllOrdersRequest
{
    public required string Symbol { get; init; }

    public QueryMarginAccountsAllOrdersIsIsolated? IsIsolated { get; init; }

    public long? OrderId { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<QueryMarginAccountsOcoIsIsolated>))]
public readonly struct QueryMarginAccountsOcoIsIsolated : IExtensibleValue<QueryMarginAccountsOcoIsIsolated>, IEquatable<QueryMarginAccountsOcoIsIsolated>
{
    private readonly string? _value;

    public QueryMarginAccountsOcoIsIsolated(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static QueryMarginAccountsOcoIsIsolated True { get; } = new("TRUE");

    public static QueryMarginAccountsOcoIsIsolated False { get; } = new("FALSE");

    static QueryMarginAccountsOcoIsIsolated IExtensibleValue<QueryMarginAccountsOcoIsIsolated>.Create(string value) => new(value);

    public static bool operator ==(QueryMarginAccountsOcoIsIsolated left, QueryMarginAccountsOcoIsIsolated right) => left.Equals(right);

    public static bool operator !=(QueryMarginAccountsOcoIsIsolated left, QueryMarginAccountsOcoIsIsolated right) => !left.Equals(right);

    public static implicit operator QueryMarginAccountsOcoIsIsolated(string value) => new(value);

    public static QueryMarginAccountsOcoIsIsolated FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is QueryMarginAccountsOcoIsIsolated other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(QueryMarginAccountsOcoIsIsolated other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class QueryMarginAccountsOcoRequest
{
    public QueryMarginAccountsOcoIsIsolated? IsIsolated { get; init; }

    public string? Symbol { get; init; }

    public long? OrderListId { get; init; }

    public string? OrigClientOrderId { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<QueryMarginAccountsOpenOcoIsIsolated>))]
public readonly struct QueryMarginAccountsOpenOcoIsIsolated : IExtensibleValue<QueryMarginAccountsOpenOcoIsIsolated>, IEquatable<QueryMarginAccountsOpenOcoIsIsolated>
{
    private readonly string? _value;

    public QueryMarginAccountsOpenOcoIsIsolated(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static QueryMarginAccountsOpenOcoIsIsolated True { get; } = new("TRUE");

    public static QueryMarginAccountsOpenOcoIsIsolated False { get; } = new("FALSE");

    static QueryMarginAccountsOpenOcoIsIsolated IExtensibleValue<QueryMarginAccountsOpenOcoIsIsolated>.Create(string value) => new(value);

    public static bool operator ==(QueryMarginAccountsOpenOcoIsIsolated left, QueryMarginAccountsOpenOcoIsIsolated right) => left.Equals(right);

    public static bool operator !=(QueryMarginAccountsOpenOcoIsIsolated left, QueryMarginAccountsOpenOcoIsIsolated right) => !left.Equals(right);

    public static implicit operator QueryMarginAccountsOpenOcoIsIsolated(string value) => new(value);

    public static QueryMarginAccountsOpenOcoIsIsolated FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is QueryMarginAccountsOpenOcoIsIsolated other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(QueryMarginAccountsOpenOcoIsIsolated other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class QueryMarginAccountsOpenOcoRequest
{
    public QueryMarginAccountsOpenOcoIsIsolated? IsIsolated { get; init; }

    public string? Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<QueryMarginAccountsOpenOrdersIsIsolated>))]
public readonly struct QueryMarginAccountsOpenOrdersIsIsolated : IExtensibleValue<QueryMarginAccountsOpenOrdersIsIsolated>, IEquatable<QueryMarginAccountsOpenOrdersIsIsolated>
{
    private readonly string? _value;

    public QueryMarginAccountsOpenOrdersIsIsolated(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static QueryMarginAccountsOpenOrdersIsIsolated True { get; } = new("TRUE");

    public static QueryMarginAccountsOpenOrdersIsIsolated False { get; } = new("FALSE");

    static QueryMarginAccountsOpenOrdersIsIsolated IExtensibleValue<QueryMarginAccountsOpenOrdersIsIsolated>.Create(string value) => new(value);

    public static bool operator ==(QueryMarginAccountsOpenOrdersIsIsolated left, QueryMarginAccountsOpenOrdersIsIsolated right) => left.Equals(right);

    public static bool operator !=(QueryMarginAccountsOpenOrdersIsIsolated left, QueryMarginAccountsOpenOrdersIsIsolated right) => !left.Equals(right);

    public static implicit operator QueryMarginAccountsOpenOrdersIsIsolated(string value) => new(value);

    public static QueryMarginAccountsOpenOrdersIsIsolated FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is QueryMarginAccountsOpenOrdersIsIsolated other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(QueryMarginAccountsOpenOrdersIsIsolated other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class QueryMarginAccountsOpenOrdersRequest
{
    /// <summary>isolated margin pair</summary>
    public string? Symbol { get; init; }

    public QueryMarginAccountsOpenOrdersIsIsolated? IsIsolated { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryMarginAccountsOpenOtootocoOrderListsRequest
{
    public string? Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<QueryMarginAccountsOrderIsIsolated>))]
public readonly struct QueryMarginAccountsOrderIsIsolated : IExtensibleValue<QueryMarginAccountsOrderIsIsolated>, IEquatable<QueryMarginAccountsOrderIsIsolated>
{
    private readonly string? _value;

    public QueryMarginAccountsOrderIsIsolated(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static QueryMarginAccountsOrderIsIsolated True { get; } = new("TRUE");

    public static QueryMarginAccountsOrderIsIsolated False { get; } = new("FALSE");

    static QueryMarginAccountsOrderIsIsolated IExtensibleValue<QueryMarginAccountsOrderIsIsolated>.Create(string value) => new(value);

    public static bool operator ==(QueryMarginAccountsOrderIsIsolated left, QueryMarginAccountsOrderIsIsolated right) => left.Equals(right);

    public static bool operator !=(QueryMarginAccountsOrderIsIsolated left, QueryMarginAccountsOrderIsIsolated right) => !left.Equals(right);

    public static implicit operator QueryMarginAccountsOrderIsIsolated(string value) => new(value);

    public static QueryMarginAccountsOrderIsIsolated FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is QueryMarginAccountsOrderIsIsolated other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(QueryMarginAccountsOrderIsIsolated other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class QueryMarginAccountsOrderRequest
{
    public required string Symbol { get; init; }

    public QueryMarginAccountsOrderIsIsolated? IsIsolated { get; init; }

    public long? OrderId { get; init; }

    public string? OrigClientOrderId { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<QueryMarginAccountsTradeListIsIsolated>))]
public readonly struct QueryMarginAccountsTradeListIsIsolated : IExtensibleValue<QueryMarginAccountsTradeListIsIsolated>, IEquatable<QueryMarginAccountsTradeListIsIsolated>
{
    private readonly string? _value;

    public QueryMarginAccountsTradeListIsIsolated(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static QueryMarginAccountsTradeListIsIsolated True { get; } = new("TRUE");

    public static QueryMarginAccountsTradeListIsIsolated False { get; } = new("FALSE");

    static QueryMarginAccountsTradeListIsIsolated IExtensibleValue<QueryMarginAccountsTradeListIsIsolated>.Create(string value) => new(value);

    public static bool operator ==(QueryMarginAccountsTradeListIsIsolated left, QueryMarginAccountsTradeListIsIsolated right) => left.Equals(right);

    public static bool operator !=(QueryMarginAccountsTradeListIsIsolated left, QueryMarginAccountsTradeListIsIsolated right) => !left.Equals(right);

    public static implicit operator QueryMarginAccountsTradeListIsIsolated(string value) => new(value);

    public static QueryMarginAccountsTradeListIsIsolated FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is QueryMarginAccountsTradeListIsIsolated other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(QueryMarginAccountsTradeListIsIsolated other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class QueryMarginAccountsTradeListRequest
{
    public required string Symbol { get; init; }

    public QueryMarginAccountsTradeListIsIsolated? IsIsolated { get; init; }

    public long? OrderId { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    public long? FromId { get; init; }

    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<QueryPreventedMatchesIsIsolated>))]
public readonly struct QueryPreventedMatchesIsIsolated : IExtensibleValue<QueryPreventedMatchesIsIsolated>, IEquatable<QueryPreventedMatchesIsIsolated>
{
    private readonly string? _value;

    public QueryPreventedMatchesIsIsolated(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static QueryPreventedMatchesIsIsolated True { get; } = new("TRUE");

    public static QueryPreventedMatchesIsIsolated False { get; } = new("FALSE");

    static QueryPreventedMatchesIsIsolated IExtensibleValue<QueryPreventedMatchesIsIsolated>.Create(string value) => new(value);

    public static bool operator ==(QueryPreventedMatchesIsIsolated left, QueryPreventedMatchesIsIsolated right) => left.Equals(right);

    public static bool operator !=(QueryPreventedMatchesIsIsolated left, QueryPreventedMatchesIsIsolated right) => !left.Equals(right);

    public static implicit operator QueryPreventedMatchesIsIsolated(string value) => new(value);

    public static QueryPreventedMatchesIsIsolated FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is QueryPreventedMatchesIsIsolated other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(QueryPreventedMatchesIsIsolated other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class QueryPreventedMatchesRequest
{
    public required string Symbol { get; init; }

    public long? PreventedMatchId { get; init; }

    public long? OrderId { get; init; }

    public long? FromPreventedMatchId { get; init; }

    public QueryPreventedMatchesIsIsolated? IsIsolated { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QuerySpecialKeyRequest
{
    public string? Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QuerySpecialKeyListRequest
{
    public string? Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class SmallLiabilityExchangeRequest
{
    /// <summary>The assets list of small liability exchange</summary>
    public required string AssetNames { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed partial class MarginTradingRestApi
{

    /// <summary>Create Special Key(Low-Latency Trading) (TRADE)</summary>
    /// <remarks>
    /// <para>Eligibility</para>
    /// <para>
    /// - Binance Margin offers low-latency trading through a special key, available exclusively to users
    /// with VIP level 7 or higher.
    /// </para>
    /// <para>- If you are VIP level 6 or below, please contact your VIP manager for eligibility criterias.</para>
    /// <para>
    /// - All new Margin Special Key users are required to read, understand, and agree to the Margin Special
    /// Key Supplemental Product Terms at the master account level before creating a Margin Special Key.
    /// </para>
    /// <para>
    /// - Once signed at the master account level, the agreement applies to all sub-accounts. The master
    /// account and all sub-accounts (Cross Margin Classic and Portfolio Margin Pro) are authorized to
    /// create a Margin Special Key and are subject to the LiquidationLoan policy.
    /// </para>
    /// <para>For more information, please refer to FAQ.</para>
    /// <para>Supported Products:</para>
    /// <para>- Cross Margin</para>
    /// <para>- Isolated Margin</para>
    /// <para>- Portfolio Margin Pro</para>
    /// <para>Unsupported Products:</para>
    /// <para>- Portfolio Margin</para>
    /// <para>We support several types of API keys:</para>
    /// <para>- Ed25519 (recommended)</para>
    /// <para>- HMAC</para>
    /// <para>- RSA</para>
    /// <para>
    /// We recommend to use Ed25519 API keys as it should provide the best performance and security out of
    /// all supported key types. We accept PKCS#8 (BEGIN PUBLIC KEY). For how to generate an RSA key pair to
    /// send API requests on Binance. Please refer to the document below FAQ .
    /// </para>
    /// <para>How to use the Margin Special Key</para>
    /// <para>- Use the below sapi endpoint to create your margin special API Key.</para>
    /// <para>- For accessing the Cross Margin account, do not send the symbol parameter.</para>
    /// <para>
    /// - For accessing the Isolated Margin account(s), pass the relevant symbol parameter in the API Key
    /// creation request.
    /// </para>
    /// <para>
    /// - Use the generated API Key (and Secret key, if applicable) to perform margin trading and listenKey
    /// generation via Spot REST API (https://api.binance.com/api/v3/*) endpoints.
    /// </para>
    /// <para>Read REST API or WebSocket API documentation to learn how to use different API keys</para>
    /// <para>
    /// You need to enable Permits “Enable Spot &amp; Margin Trading” option for the API Key which requests
    /// this endpoint.
    /// </para>
    /// <para>Weight(UID): 1</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Response Notes:</para>
    /// <para>- Error Code Description</para>
    /// <para>- UNSUPPORTED_OPERATION : Portfolio Margin is an unsupported</para>
    /// <para>product, please change the account type to a supported margin product.</para>
    /// <para>- Forbidden: Cross Margin Pro accounts require additional</para>
    /// <para>agreements, please contact your relationship manager.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CreateSpecialKeyResponse>> CreateSpecialKeyAsync(CreateSpecialKeyRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/margin/apiKey", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CreateSpecialKeyResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("apiName", request.ApiName);
        r.Query("symbol", request.Symbol);
        r.Query("ip", request.Ip);
        r.Query("publicKey", request.PublicKey);
        r.Query("permissionMode", request.PermissionMode);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.CreateSpecialKeyResponse, cancellationToken);
    }

    /// <summary>Delete Special Key(Low-Latency Trading) (TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Deleting your Margin Special Key alone does not exit you from the Margin Special Key framework or
    /// discharge your obligations under the Margin Special Key Supplemental Product Terms. To fully exit,
    /// you must:
    /// </para>
    /// <para>- Delete your Margin Special Key.</para>
    /// <para>- Ensure there are no outstanding liabilities on the account.</para>
    /// <para>- Call the Exit Margin Special Key API endpoint.</para>
    /// <para>- Confirm the exit status via the API response.</para>
    /// <para>
    /// Only after step 4 is completed and the exit status is confirmed by Binance will your account revert
    /// to standard liquidation logic and no longer be subject to the Margin Special Key Supplemental
    /// Product Terms.
    /// </para>
    /// <para>
    /// If apiKey is given, apiName will be ignored. If apiName is given with no apiKey, all apikeys with
    /// given apiName will be deleted.
    /// </para>
    /// <para>
    /// You need to enable Permits “Enable Spot &amp; Margin” option for the API Key which requests this
    /// endpoint.
    /// </para>
    /// <para>Weight(UID): 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<JsonElement>> DeleteSpecialKeyAsync(DeleteSpecialKeyRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/sapi/v1/margin/apiKey", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("apiName", request.ApiName);
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.JsonElement, cancellationToken);
    }

    /// <summary>Edit ip for Special Key(Low-Latency Trading) (TRADE)</summary>
    /// <remarks>
    /// <para>Edit ip restriction. This only applies to Special Key for Low Latency Trading.</para>
    /// <para>
    /// You need to enable Permits “Enable Spot &amp; Margin” option for the API Key which requests this
    /// endpoint.
    /// </para>
    /// <para>Weight(UID): 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<JsonElement>> EditIpForSpecialKeyAsync(EditIpForSpecialKeyRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("PUT", "/sapi/v1/margin/apiKey/ip", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<JsonElement>>(new ArgumentNullException(nameof(request)));
        r.Query("ip", request.Ip);
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.JsonElement, cancellationToken);
    }

    /// <summary>Exit Special Key Mode (TRADE)</summary>
    /// <remarks>
    /// <para>Exit the Margin Special Key mode for Cross Margin Classic accounts.</para>
    /// <para>
    /// All outstanding liabilities under the Cross Margin Classic account must be fully repaid before
    /// calling this endpoint. Deleting the Margin Special Key alone does not constitute a valid exit.
    /// </para>
    /// <para>
    /// When a user creates a Margin Special API Key, the account enters "Special Key Mode". Upon a
    /// successful request, the following actions will be performed atomically:
    /// </para>
    /// <para>- All existing Margin Special API Keys under the Cross Margin Classic mode account will be deleted.</para>
    /// <para>
    /// - All pre-execution margin checks (including Open-order-loss calculation) will revert to standard
    /// mode.
    /// </para>
    /// <para>
    /// - A cooldown period (default: 24 hours) will be enforced, during which the account will not be
    /// permitted to create new Margin Special API Keys.
    /// </para>
    /// <para>For more information, please refer to FAQ.</para>
    /// <para>Preconditions:</para>
    /// <para>The following conditions must be met; otherwise the request will be rejected:</para>
    /// <para>- Account type must be Cross Margin Classic.</para>
    /// <para>- Account must currently be in Special Key Mode. If not, the request silently succeeds.</para>
    /// <para>- Account must not be in liquidation.</para>
    /// <para>- Account must have no liability.</para>
    /// <para>
    /// You need to enable "Permits Enable Spot &amp; Margin Trading" option for the API Key which requests
    /// this endpoint.
    /// </para>
    /// <para>Weight(UID): 10</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<JsonElement>> ExitSpecialKeyModeAsync(ExitSpecialKeyModeRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/margin/exit-special-key-mode", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.JsonElement, cancellationToken);
    }

    /// <summary>Get Force Liquidation Record (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Force Liquidation Record</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Response in descending order</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetForceLiquidationRecordResponse>> GetForceLiquidationRecordAsync(GetForceLiquidationRecordRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/forceLiquidationRec", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("isolatedSymbol", request.IsolatedSymbol);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.GetForceLiquidationRecordResponse, cancellationToken);
    }

    /// <summary>Get Small Liability Exchange Coin List (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query the coins which can be small liability exchange</para>
    /// <para>Weight(IP): 100</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<GetSmallLiabilityExchangeCoinListResponseInner>>> GetSmallLiabilityExchangeCoinListAsync(GetSmallLiabilityExchangeCoinListRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/exchange-small-liability", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.ListGetSmallLiabilityExchangeCoinListResponseInner, cancellationToken);
    }

    /// <summary>Get Small Liability Exchange History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Small liability Exchange History</para>
    /// <para>Weight(UID): 100</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetSmallLiabilityExchangeHistoryResponse>> GetSmallLiabilityExchangeHistoryAsync(GetSmallLiabilityExchangeHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/exchange-small-liability-history", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetSmallLiabilityExchangeHistoryResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.GetSmallLiabilityExchangeHistoryResponse, cancellationToken);
    }

    /// <summary>Liquidation Loan Repay (MARGIN)</summary>
    /// <remarks>
    /// <para>
    /// Repays the outstanding cross-margin liquidation loan from the user's spot wallet. A liquidation loan
    /// represents the account deficit incurred when account equity turns negative during liquidation
    /// (bankruptcy). The repayment amount must be greater than 0 and cannot exceed the remaining loan
    /// balance. If the Spot Account has insufficient USDC balance, the repayment will fail.
    /// </para>
    /// <para>Weight(UID): 100</para>
    /// <para>Security Type: MARGIN</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<LiquidationLoanRepayResponse>> LiquidationLoanRepayAsync(LiquidationLoanRepayRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/margin/liquidation-loan/repay", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<LiquidationLoanRepayResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("asset", request.Asset);
        r.Query("amount", request.Amount);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.LiquidationLoanRepayResponse, cancellationToken);
    }

    /// <summary>Margin Account Cancel all Open Orders on a Symbol (TRADE)</summary>
    /// <remarks>
    /// <para>Cancels all active orders on a symbol for margin account.</para>
    /// <para>This includes OCO orders.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<MarginAccountCancelAllOpenOrdersOnASymbolResponseInner>>> MarginAccountCancelAllOpenOrdersOnASymbolAsync(MarginAccountCancelAllOpenOrdersOnASymbolRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/sapi/v1/margin/openOrders", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<MarginAccountCancelAllOpenOrdersOnASymbolResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("isIsolated", request.IsIsolated);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.ListMarginAccountCancelAllOpenOrdersOnASymbolResponseInner, cancellationToken);
    }

    /// <summary>Margin Account Cancel OCO (TRADE)</summary>
    /// <remarks>
    /// <para>Cancel an entire Order List for a margin account.</para>
    /// <para>Weight(UID): 1</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Canceling an individual leg will cancel the entire OCO</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<MarginAccountCancelOcoResponse>> MarginAccountCancelOcoAsync(MarginAccountCancelOcoRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/sapi/v1/margin/orderList", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<MarginAccountCancelOcoResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("isIsolated", request.IsIsolated);
        r.Query("orderListId", request.OrderListId);
        r.Query("listClientOrderId", request.ListClientOrderId);
        r.Query("newClientOrderId", request.NewClientOrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.MarginAccountCancelOcoResponse, cancellationToken);
    }

    /// <summary>Margin Account Cancel Order (TRADE)</summary>
    /// <remarks>
    /// <para>Cancel an active order for margin account.</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Either orderId or origClientOrderId must be sent.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<MarginAccountCancelOrderResponse>> MarginAccountCancelOrderAsync(MarginAccountCancelOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/sapi/v1/margin/order", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<MarginAccountCancelOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("isIsolated", request.IsIsolated);
        r.Query("orderId", request.OrderId);
        r.Query("origClientOrderId", request.OrigClientOrderId);
        r.Query("newClientOrderId", request.NewClientOrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.MarginAccountCancelOrderResponse, cancellationToken);
    }

    /// <summary>Margin Account New OCO (TRADE)</summary>
    /// <remarks>
    /// <para>Send in a new OCO for a margin account</para>
    /// <para>Weight: 6(UID) or 1500(UID) when sideEffectType is MARGIN_BUY or AUTO_BORROW_REPAY</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>
    /// - autoRepayAtCancel is suggested to set as “FALSE” to keep liability unrepaid under high frequent
    /// new order/cancel order execution
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<MarginAccountNewOcoResponse>> MarginAccountNewOcoAsync(MarginAccountNewOcoRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/margin/order/oco", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<MarginAccountNewOcoResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("side", request.Side);
        r.Query("quantity", request.Quantity);
        r.Query("price", request.Price);
        r.Query("stopPrice", request.StopPrice);
        r.Query("isIsolated", request.IsIsolated);
        r.Query("listClientOrderId", request.ListClientOrderId);
        r.Query("limitClientOrderId", request.LimitClientOrderId);
        r.Query("limitIcebergQty", request.LimitIcebergQty);
        r.Query("stopClientOrderId", request.StopClientOrderId);
        r.Query("stopLimitPrice", request.StopLimitPrice);
        r.Query("stopIcebergQty", request.StopIcebergQty);
        r.Query("stopLimitTimeInForce", request.StopLimitTimeInForce);
        r.Query("newOrderRespType", request.NewOrderRespType);
        r.Query("sideEffectType", request.SideEffectType);
        r.Query("selfTradePreventionMode", request.SelfTradePreventionMode);
        r.Query("autoRepayAtCancel", request.AutoRepayAtCancel);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.MarginAccountNewOcoResponse, cancellationToken);
    }

    /// <summary>Margin Account New Order (TRADE)</summary>
    /// <remarks>
    /// <para>Post a new order for margin account.</para>
    /// <para>Weight: 6(UID) or 1500(UID) when sideEffectType is MARGIN_BUY or AUTO_BORROW_REPAY</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>
    /// - autoRepayAtCancel is suggested to set as “FALSE” to keep liability unrepaid under high frequent
    /// new order/cancel order execution
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<MarginAccountNewOrderResponse>> MarginAccountNewOrderAsync(MarginAccountNewOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/margin/order", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<MarginAccountNewOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("side", request.Side);
        r.Query("type", request.Type);
        r.Query("isIsolated", request.IsIsolated);
        r.Query("quantity", request.Quantity);
        r.Query("quoteOrderQty", request.QuoteOrderQty);
        r.Query("price", request.Price);
        r.Query("stopPrice", request.StopPrice);
        r.Query("newClientOrderId", request.NewClientOrderId);
        r.Query("icebergQty", request.IcebergQty);
        r.Query("newOrderRespType", request.NewOrderRespType);
        r.Query("sideEffectType", request.SideEffectType);
        r.Query("timeInForce", request.TimeInForce);
        r.Query("selfTradePreventionMode", request.SelfTradePreventionMode);
        r.Query("trailingDelta", request.TrailingDelta);
        r.Query("autoRepayAtCancel", request.AutoRepayAtCancel);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.MarginAccountNewOrderResponse, cancellationToken);
    }

    /// <summary>Margin Account New OTO (TRADE)</summary>
    /// <remarks>
    /// <para>Post a new OTO order for margin account:</para>
    /// <para>- An OTO (One-Triggers-the-Other) is an order list comprised of 2</para>
    /// <para>orders.</para>
    /// <para>- The first order is called the working order and must be LIMIT or</para>
    /// <para>LIMIT_MAKER. Initially, only the working order goes on the order book.</para>
    /// <para>- The second order is called the pending order. It can be any order</para>
    /// <para>
    /// type except for MARKET orders using parameter quoteOrderQty. The pending order is only placed on the
    /// order book when the working order gets fully filled.
    /// </para>
    /// <para>- If either the working order or the pending order is cancelled</para>
    /// <para>individually, the other order in the order list will also be canceled or expired.</para>
    /// <para>- When the order list is placed, if the working order gets **immediately</para>
    /// <para>
    /// fully filled**, the placement response will show the working order as FILLED but the pending order
    /// will still appear as PENDING_NEW. You need to query the status of the pending order again to see its
    /// updated status.
    /// </para>
    /// <para>- OTOs add 2 orders to the unfilled order count,</para>
    /// <para>EXCHANGE_MAX_NUM_ORDERS filter and MAX_NUM_ORDERS filter.</para>
    /// <para>Weight: 6(UID) or 1500(UID) when sideEffectType is MARGIN_BUY or AUTO_BORROW_REPAY</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>
    /// - autoRepayAtCancel is suggested to set as “FALSE” to keep liability unrepaid under high frequent
    /// new order/cancel order execution
    /// </para>
    /// <para>- Depending on the pendingType or workingType, some optional parameters will become mandatory:</para>
    /// <para>| Type | Additional mandatory parameters | Additional information |</para>
    /// <para>| workingType = LIMIT | workingTimeInForce | |</para>
    /// <para>| pendingType = LIMIT | pendingPrice, pendingTimeInForce | |</para>
    /// <para>| pendingType = STOP_LOSS or TAKE_PROFIT | pendingStopPrice and/or pendingTrailingDelta | |</para>
    /// <para>
    /// | pendingType = STOP_LOSS_LIMIT or TAKE_PROFIT_LIMIT | pendingPrice, pendingStopPrice and/or
    /// pendingTrailingDelta, pendingTimeInForce | |
    /// </para>
    /// <para>| pendingTrailingDelta is provided | pendingPrice | |</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<MarginAccountNewOtoResponse>> MarginAccountNewOtoAsync(MarginAccountNewOtoRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/margin/order/oto", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<MarginAccountNewOtoResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("workingType", request.WorkingType);
        r.Query("workingSide", request.WorkingSide);
        r.Query("workingPrice", request.WorkingPrice);
        r.Query("workingQuantity", request.WorkingQuantity);
        r.Query("workingIcebergQty", request.WorkingIcebergQty);
        r.Query("pendingType", request.PendingType);
        r.Query("pendingSide", request.PendingSide);
        r.Query("pendingQuantity", request.PendingQuantity);
        r.Query("isIsolated", request.IsIsolated);
        r.Query("listClientOrderId", request.ListClientOrderId);
        r.Query("newOrderRespType", request.NewOrderRespType);
        r.Query("sideEffectType", request.SideEffectType);
        r.Query("selfTradePreventionMode", request.SelfTradePreventionMode);
        r.Query("autoRepayAtCancel", request.AutoRepayAtCancel);
        r.Query("workingClientOrderId", request.WorkingClientOrderId);
        r.Query("workingTimeInForce", request.WorkingTimeInForce);
        r.Query("pendingClientOrderId", request.PendingClientOrderId);
        r.Query("pendingPrice", request.PendingPrice);
        r.Query("pendingStopPrice", request.PendingStopPrice);
        r.Query("pendingTrailingDelta", request.PendingTrailingDelta);
        r.Query("pendingIcebergQty", request.PendingIcebergQty);
        r.Query("pendingTimeInForce", request.PendingTimeInForce);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.MarginAccountNewOtoResponse, cancellationToken);
    }

    /// <summary>Margin Account New OTOCO (TRADE)</summary>
    /// <remarks>
    /// <para>Post a new OTOCO order for margin account：</para>
    /// <para>- An OTOCO (One-Triggers-One-Cancels-the-Other) is an order list</para>
    /// <para>comprised of 3 orders.</para>
    /// <para>- The first order is called the working order and must be LIMIT or</para>
    /// <para>LIMIT_MAKER. Initially, only the working order goes on the order book.</para>
    /// <para>- The behavior of the working order is the same as the OTO.</para>
    /// <para>- OTOCO has 2 pending orders (pending above and pending below), forming</para>
    /// <para>
    /// an OCO pair. The pending orders are only placed on the order book when the working order gets fully
    /// filled.
    /// </para>
    /// <para>- The rules of the pending above and pending below follow the same rules as the Order List OCO.</para>
    /// <para>- OTOCOs add 3 orders against the unfilled order count,</para>
    /// <para>EXCHANGE_MAX_NUM_ORDERS filter, and MAX_NUM_ORDERS filter.</para>
    /// <para>Weight: 6(UID) or 1500(UID) when sideEffectType is MARGIN_BUY or AUTO_BORROW_REPAY</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>
    /// - autoRepayAtCancel is suggested to set as “FALSE” to keep liability unrepaid under high frequent
    /// new order/cancel order execution
    /// </para>
    /// <para>
    /// - Depending on the pendingAboveType/pendingBelowType or workingType, some optional parameters will
    /// become mandatory: | Type | Additional mandatory parameters | Additional information | |
    /// ------------------------------------ | ------------------------------------------------------------
    /// | ---------------------- | | workingType = LIMIT | workingTimeInForce | | | pendingAboveType=
    /// LIMIT_MAKER | pendingAbovePrice | | | pendingAboveType= STOP_LOSS | pendingAboveStopPrice and/or
    /// pendingAboveTrailingDelta | | | pendingAboveType=STOP_LOSS_LIMIT | pendingAbovePrice,
    /// pendingAboveStopPrice and/or pendingAboveTrailingDelta, pendingAboveTimeInForce | | |
    /// pendingBelowType= LIMIT_MAKER | pendingBelowPrice | | | pendingBelowType= STOP_LOSS |
    /// pendingBelowStopPrice and/or pendingBelowTrailingDelta | | | pendingBelowType=STOP_LOSS_LIMIT |
    /// pendingBelowPrice, pendingBelowStopPrice and/or pendingBelowTrailingDelta, pendingBelowTimeInForce |
    /// | | pendingAboveTrailingDelta is provided | pendingAbovePrice | | | pendingBelowTrailingDelta is
    /// provided | pendingBelowPrice | |
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<MarginAccountNewOtocoResponse>> MarginAccountNewOtocoAsync(MarginAccountNewOtocoRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/margin/order/otoco", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<MarginAccountNewOtocoResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("workingType", request.WorkingType);
        r.Query("workingSide", request.WorkingSide);
        r.Query("workingPrice", request.WorkingPrice);
        r.Query("workingQuantity", request.WorkingQuantity);
        r.Query("pendingSide", request.PendingSide);
        r.Query("pendingQuantity", request.PendingQuantity);
        r.Query("pendingAboveType", request.PendingAboveType);
        r.Query("isIsolated", request.IsIsolated);
        r.Query("sideEffectType", request.SideEffectType);
        r.Query("autoRepayAtCancel", request.AutoRepayAtCancel);
        r.Query("listClientOrderId", request.ListClientOrderId);
        r.Query("newOrderRespType", request.NewOrderRespType);
        r.Query("selfTradePreventionMode", request.SelfTradePreventionMode);
        r.Query("workingClientOrderId", request.WorkingClientOrderId);
        r.Query("workingIcebergQty", request.WorkingIcebergQty);
        r.Query("workingTimeInForce", request.WorkingTimeInForce);
        r.Query("pendingAboveClientOrderId", request.PendingAboveClientOrderId);
        r.Query("pendingAbovePrice", request.PendingAbovePrice);
        r.Query("pendingAboveStopPrice", request.PendingAboveStopPrice);
        r.Query("pendingAboveTrailingDelta", request.PendingAboveTrailingDelta);
        r.Query("pendingAboveIcebergQty", request.PendingAboveIcebergQty);
        r.Query("pendingAboveTimeInForce", request.PendingAboveTimeInForce);
        r.Query("pendingBelowType", request.PendingBelowType);
        r.Query("pendingBelowClientOrderId", request.PendingBelowClientOrderId);
        r.Query("pendingBelowPrice", request.PendingBelowPrice);
        r.Query("pendingBelowStopPrice", request.PendingBelowStopPrice);
        r.Query("pendingBelowTrailingDelta", request.PendingBelowTrailingDelta);
        r.Query("pendingBelowIcebergQty", request.PendingBelowIcebergQty);
        r.Query("pendingBelowTimeInForce", request.PendingBelowTimeInForce);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.MarginAccountNewOtocoResponse, cancellationToken);
    }

    /// <summary>Margin Manual Liquidation (TRADE)</summary>
    /// <remarks>
    /// <para>Margin Manual Liquidation</para>
    /// <para>Weight(UID): 3000</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- This endpoint supports Cross Margin Classic Mode and Pro Mode.</para>
    /// <para>- Isolated Margin is only supported in restricted regions.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<MarginManualLiquidationResponse>> MarginManualLiquidationAsync(MarginManualLiquidationRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/margin/manual-liquidation", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<MarginManualLiquidationResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("type", request.Type);
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.MarginManualLiquidationResponse, cancellationToken);
    }

    /// <summary>Query Current Margin Order Count Usage (TRADE)</summary>
    /// <remarks>
    /// <para>Displays the user's current margin order count usage for all intervals.</para>
    /// <para>Weight(IP): 20</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryCurrentMarginOrderCountUsageResponseInner>>> QueryCurrentMarginOrderCountUsageAsync(QueryCurrentMarginOrderCountUsageRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/rateLimit/order", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("isIsolated", request.IsIsolated);
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.ListQueryCurrentMarginOrderCountUsageResponseInner, cancellationToken);
    }

    /// <summary>Query Liquidation Loan (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Query the current user's cross-margin liquidation loan information, including the original loan
    /// amount, repaid amount, and remaining amount. When a cross-margin account is liquidated and the
    /// account equity turns negative (bankruptcy), the system generates a liquidation loan record
    /// representing the deficit. This represents the shortfall amount denominated in USDC.
    /// </para>
    /// <para>Weight(UID): 100</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryLiquidationLoanResponse>> QueryLiquidationLoanAsync(QueryLiquidationLoanRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/liquidation-loan", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.QueryLiquidationLoanResponse, cancellationToken);
    }

    /// <summary>Query Liquidation Loan Repay History (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Query the repayment history of cross-margin liquidation loans (deficit caused by bankruptcy during
    /// liquidation). Supports time-range filtering and pagination.
    /// </para>
    /// <para>Weight(UID): 100</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>
    /// - The maximum query range is 90 days. If startTime is earlier than 90 days ago, it will be clamped
    /// to 90 days ago.
    /// </para>
    /// <para>- Only records with status SUCCESS or PENDING are returned. Failed repayment records are excluded.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryLiquidationLoanRepayHistoryResponse>> QueryLiquidationLoanRepayHistoryAsync(QueryLiquidationLoanRepayHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/liquidation-loan/repay-history", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.QueryLiquidationLoanRepayHistoryResponse, cancellationToken);
    }

    /// <summary>Query Margin Account's all OCO (USER_DATA)</summary>
    /// <remarks>
    /// <para>Retrieves all OCO for a specific margin account based on provided optional parameters</para>
    /// <para>Weight(IP): 200</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryMarginAccountsAllOcoResponseInner>>> QueryMarginAccountsAllOcoAsync(QueryMarginAccountsAllOcoRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/allOrderList", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("isIsolated", request.IsIsolated);
        r.Query("symbol", request.Symbol);
        r.Query("fromId", request.FromId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.ListQueryMarginAccountsAllOcoResponseInner, cancellationToken);
    }

    /// <summary>Query Margin Account's All Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Margin Account's All Orders</para>
    /// <para>Weight(IP): 200</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If orderId is set, it will get orders &gt;= that orderId. Otherwise the</para>
    /// <para>orders within 24 hours are returned.</para>
    /// <para>- For some historical orders cummulativeQuoteQty will be &lt; 0, meaning</para>
    /// <para>the data is not available at this time.</para>
    /// <para>- Less than 24 hours between startTime and endTime.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryMarginAccountsAllOrdersResponseInner>>> QueryMarginAccountsAllOrdersAsync(QueryMarginAccountsAllOrdersRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/allOrders", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<QueryMarginAccountsAllOrdersResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("isIsolated", request.IsIsolated);
        r.Query("orderId", request.OrderId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.ListQueryMarginAccountsAllOrdersResponseInner, cancellationToken);
    }

    /// <summary>Query Margin Account's OCO (USER_DATA)</summary>
    /// <remarks>
    /// <para>Retrieves a specific OCO based on provided optional parameters</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryMarginAccountsOcoResponse>> QueryMarginAccountsOcoAsync(QueryMarginAccountsOcoRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/orderList", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("isIsolated", request.IsIsolated);
        r.Query("symbol", request.Symbol);
        r.Query("orderListId", request.OrderListId);
        r.Query("origClientOrderId", request.OrigClientOrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.QueryMarginAccountsOcoResponse, cancellationToken);
    }

    /// <summary>Query Margin Account's Open OCO (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Margin Account's Open OCO</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryMarginAccountsOpenOcoResponseInner>>> QueryMarginAccountsOpenOcoAsync(QueryMarginAccountsOpenOcoRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/openOrderList", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("isIsolated", request.IsIsolated);
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.ListQueryMarginAccountsOpenOcoResponseInner, cancellationToken);
    }

    /// <summary>Query Margin Account's Open Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Margin Account's Open Orders</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If the symbol is not sent, orders for all symbols will be returned in</para>
    /// <para>an array.</para>
    /// <para>- When all symbols are returned, the number of requests counted against</para>
    /// <para>the rate limiter is equal to the number of symbols currently trading on the exchange.</para>
    /// <para>- If isIsolated ="TRUE", symbol must be sent.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryMarginAccountsOpenOrdersResponseInner>>> QueryMarginAccountsOpenOrdersAsync(QueryMarginAccountsOpenOrdersRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/openOrders", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("isIsolated", request.IsIsolated);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.ListQueryMarginAccountsOpenOrdersResponseInner, cancellationToken);
    }

    /// <summary>Query Margin Account's Open OTO/OTOCO Order Lists (USER_DATA)</summary>
    /// <remarks>
    /// <para>Retrieves all open OTO / OTOCO order lists of the margin account.</para>
    /// <para>Notes:</para>
    /// <para>
    /// - The returned list contains order lists whose listOrderStatus is EXECUTING, i.e. at least one order
    /// of the list is still open (NEW / PARTIALLY_FILLED).
    /// </para>
    /// <para>- For OTO, the orders array contains 2 orders: the working order and the pending order.</para>
    /// <para>
    /// - For OTOCO, the orders array contains 3 orders: the working order and the two pending orders
    /// (pending above / pending below).
    /// </para>
    /// <para>Weight(UID): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryMarginAccountsOpenOtootocoOrderListsResponseInner>>> QueryMarginAccountsOpenOtootocoOrderListsAsync(QueryMarginAccountsOpenOtootocoOrderListsRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/oto/openOrderList", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.ListQueryMarginAccountsOpenOtootocoOrderListsResponseInner, cancellationToken);
    }

    /// <summary>Query Margin Account's Order (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Margin Account's Order</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Either orderId or origClientOrderId must be sent.</para>
    /// <para>- For some historical orders cummulativeQuoteQty will be &lt; 0, meaning</para>
    /// <para>the data is not available at this time.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryMarginAccountsOrderResponse>> QueryMarginAccountsOrderAsync(QueryMarginAccountsOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/order", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryMarginAccountsOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("isIsolated", request.IsIsolated);
        r.Query("orderId", request.OrderId);
        r.Query("origClientOrderId", request.OrigClientOrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.QueryMarginAccountsOrderResponse, cancellationToken);
    }

    /// <summary>Query Margin Account's Trade List (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Margin Account's Trade List</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If fromId is set, it will get trades &gt;= that fromId. Otherwise the</para>
    /// <para>trades within 24 hours are returned.</para>
    /// <para>- Less than 24 hours between startTime and endTime.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryMarginAccountsTradeListResponseInner>>> QueryMarginAccountsTradeListAsync(QueryMarginAccountsTradeListRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/myTrades", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<QueryMarginAccountsTradeListResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("isIsolated", request.IsIsolated);
        r.Query("orderId", request.OrderId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("fromId", request.FromId);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.ListQueryMarginAccountsTradeListResponseInner, cancellationToken);
    }

    /// <summary>Query Prevented Matches (USER_DATA)</summary>
    /// <remarks>
    /// <para>Displays the list of orders that were expired due to STP. (Self-Trade Prevention).</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Supported parameter combinations:</para>
    /// <para>- symbol + preventedMatchId</para>
    /// <para>- symbol + orderId</para>
    /// <para>- symbol + orderId + fromPreventedMatchId</para>
    /// <para>- If orderId is provided, all prevented matches for that order will be</para>
    /// <para>returned.</para>
    /// <para>- If preventedMatchId is provided, the specific prevented match will</para>
    /// <para>be returned.</para>
    /// <para>- A single request returns a maximum of 500 records. If there are more</para>
    /// <para>than 500 records, use symbol + orderId + fromPreventedMatchId combination for pagination.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryPreventedMatchesResponseInner>>> QueryPreventedMatchesAsync(QueryPreventedMatchesRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/myPreventedMatches", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<QueryPreventedMatchesResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("preventedMatchId", request.PreventedMatchId);
        r.Query("orderId", request.OrderId);
        r.Query("fromPreventedMatchId", request.FromPreventedMatchId);
        r.Query("isIsolated", request.IsIsolated);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.ListQueryPreventedMatchesResponseInner, cancellationToken);
    }

    /// <summary>Query Special key(Low Latency Trading) (TRADE)</summary>
    /// <remarks>
    /// <para>Query Special Key Information.</para>
    /// <para>This only applies to Special Key for Low Latency Trading.</para>
    /// <para>Weight(UID): 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QuerySpecialKeyResponse>> QuerySpecialKeyAsync(QuerySpecialKeyRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/apiKey", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.QuerySpecialKeyResponse, cancellationToken);
    }

    /// <summary>Query Special key List(Low Latency Trading) (TRADE)</summary>
    /// <remarks>
    /// <para>This only applies to Special Key for Low Latency Trading.</para>
    /// <para>Weight(UID): 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QuerySpecialKeyListResponseInner>>> QuerySpecialKeyListAsync(QuerySpecialKeyListRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/api-key-list", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.ListQuerySpecialKeyListResponseInner, cancellationToken);
    }

    /// <summary>Small Liability Exchange (MARGIN)</summary>
    /// <remarks>
    /// <para>Small Liability Exchange</para>
    /// <para>Weight(UID): 3000</para>
    /// <para>Security Type: MARGIN</para>
    /// <para>Notes:</para>
    /// <para>- Only convert once within 6 hours</para>
    /// <para>- Only liability valuation less than 10 USDT are supported</para>
    /// <para>- The maximum number of coin is 10</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<JsonElement>> SmallLiabilityExchangeAsync(SmallLiabilityExchangeRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/margin/exchange-small-liability", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<JsonElement>>(new ArgumentNullException(nameof(request)));
        r.Query("assetNames", request.AssetNames);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.JsonElement, cancellationToken);
    }
}
