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

public sealed class ModifyMultipleOrdersBatchOrdersParameterInner
{
    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    [JsonPropertyName("origClientOrderId")]
    public string? OrigClientOrderId { get; set; }

    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("side")]
    public ModifyMultipleOrdersBatchOrdersParameterInnerSide? Side { get; set; }

    /// <summary>Order quantity, cannot be sent with closePosition=true</summary>
    [JsonPropertyName("quantity")]
    public decimal? Quantity { get; set; }

    [JsonPropertyName("price")]
    public decimal? Price { get; set; }

    /// <summary>
    /// Only avaliable for LIMIT/STOP/TAKE_PROFIT order; Cannot be sent together with price.
    /// </summary>
    [JsonPropertyName("priceMatch")]
    public ModifyMultipleOrdersBatchOrdersParameterInnerPriceMatch? PriceMatch { get; set; }

    /// <summary>stop price, only STOP, STOP_MARKET, TAKE_PROFIT, TAKE_PROFIT_MARKET need</summary>
    [JsonPropertyName("stopPrice")]
    public decimal? StopPrice { get; set; }

    /// <summary>
    /// User-defined modification identifier, returned as-is in the response. Optional; not validated for
    /// uniqueness.
    /// </summary>
    [JsonPropertyName("modifyId")]
    public long? ModifyId { get; set; }

    /// <summary>Validity window in milliseconds.</summary>
    [JsonPropertyName("recvWindow")]
    public long? RecvWindow { get; set; }

    /// <summary>Unix timestamp in milliseconds.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; set; }
}

[JsonConverter(typeof(ExtensibleValueConverter<ModifyMultipleOrdersBatchOrdersParameterInnerSide>))]
public readonly struct ModifyMultipleOrdersBatchOrdersParameterInnerSide : IExtensibleValue<ModifyMultipleOrdersBatchOrdersParameterInnerSide>, IEquatable<ModifyMultipleOrdersBatchOrdersParameterInnerSide>
{
    private readonly string? _value;

    public ModifyMultipleOrdersBatchOrdersParameterInnerSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static ModifyMultipleOrdersBatchOrdersParameterInnerSide Buy { get; } = new("BUY");

    public static ModifyMultipleOrdersBatchOrdersParameterInnerSide Sell { get; } = new("SELL");

    static ModifyMultipleOrdersBatchOrdersParameterInnerSide IExtensibleValue<ModifyMultipleOrdersBatchOrdersParameterInnerSide>.Create(string value) => new(value);

    public static bool operator ==(ModifyMultipleOrdersBatchOrdersParameterInnerSide left, ModifyMultipleOrdersBatchOrdersParameterInnerSide right) => left.Equals(right);

    public static bool operator !=(ModifyMultipleOrdersBatchOrdersParameterInnerSide left, ModifyMultipleOrdersBatchOrdersParameterInnerSide right) => !left.Equals(right);

    public static implicit operator ModifyMultipleOrdersBatchOrdersParameterInnerSide(string value) => new(value);

    public static ModifyMultipleOrdersBatchOrdersParameterInnerSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ModifyMultipleOrdersBatchOrdersParameterInnerSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ModifyMultipleOrdersBatchOrdersParameterInnerSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<ModifyMultipleOrdersBatchOrdersParameterInnerPriceMatch>))]
public readonly struct ModifyMultipleOrdersBatchOrdersParameterInnerPriceMatch : IExtensibleValue<ModifyMultipleOrdersBatchOrdersParameterInnerPriceMatch>, IEquatable<ModifyMultipleOrdersBatchOrdersParameterInnerPriceMatch>
{
    private readonly string? _value;

    public ModifyMultipleOrdersBatchOrdersParameterInnerPriceMatch(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static ModifyMultipleOrdersBatchOrdersParameterInnerPriceMatch Opponent { get; } = new("OPPONENT");

    public static ModifyMultipleOrdersBatchOrdersParameterInnerPriceMatch Opponent5 { get; } = new("OPPONENT_5");

    public static ModifyMultipleOrdersBatchOrdersParameterInnerPriceMatch Opponent10 { get; } = new("OPPONENT_10");

    public static ModifyMultipleOrdersBatchOrdersParameterInnerPriceMatch Opponent20 { get; } = new("OPPONENT_20");

    public static ModifyMultipleOrdersBatchOrdersParameterInnerPriceMatch Queue { get; } = new("QUEUE");

    public static ModifyMultipleOrdersBatchOrdersParameterInnerPriceMatch Queue5 { get; } = new("QUEUE_5");

    public static ModifyMultipleOrdersBatchOrdersParameterInnerPriceMatch Queue10 { get; } = new("QUEUE_10");

    public static ModifyMultipleOrdersBatchOrdersParameterInnerPriceMatch Queue20 { get; } = new("QUEUE_20");

    static ModifyMultipleOrdersBatchOrdersParameterInnerPriceMatch IExtensibleValue<ModifyMultipleOrdersBatchOrdersParameterInnerPriceMatch>.Create(string value) => new(value);

    public static bool operator ==(ModifyMultipleOrdersBatchOrdersParameterInnerPriceMatch left, ModifyMultipleOrdersBatchOrdersParameterInnerPriceMatch right) => left.Equals(right);

    public static bool operator !=(ModifyMultipleOrdersBatchOrdersParameterInnerPriceMatch left, ModifyMultipleOrdersBatchOrdersParameterInnerPriceMatch right) => !left.Equals(right);

    public static implicit operator ModifyMultipleOrdersBatchOrdersParameterInnerPriceMatch(string value) => new(value);

    public static ModifyMultipleOrdersBatchOrdersParameterInnerPriceMatch FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ModifyMultipleOrdersBatchOrdersParameterInnerPriceMatch other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ModifyMultipleOrdersBatchOrdersParameterInnerPriceMatch other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}
