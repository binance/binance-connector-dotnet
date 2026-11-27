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

public sealed class ModifyMultipleOrdersBatchOrdersParameterInner
{
    /// <summary>Trading symbol</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Trading side</summary>
    [JsonPropertyName("side")]
    public ModifyMultipleOrdersBatchOrdersParameterInnerSide? Side { get; set; }

    /// <summary>
    /// Unix timestamp in milliseconds used to sign the request. The value must reflect the current client
    /// time and is validated by the server for signed endpoints.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; set; }

    /// <summary>Sub-order ID, required when clientOrderId is not sent.</summary>
    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    /// <summary>
    /// Client order ID, required when orderId is not sent. Only support letters, numbers and underscores,
    /// and must be unique within 24 hours.
    /// </summary>
    [JsonPropertyName("origClientOrderId")]
    public string? OrigClientOrderId { get; set; }

    /// <summary>
    /// Order quantity, cannot be sent with closePosition=true. After CM migration, this parameter becomes
    /// mandatory (each batch element must send both price and quantity).
    /// </summary>
    [JsonPropertyName("quantity")]
    public decimal? Quantity { get; set; }

    /// <summary>
    /// Latest token price. After CM migration, this parameter becomes mandatory (each batch element must
    /// send both price and quantity).
    /// </summary>
    [JsonPropertyName("price")]
    public decimal? Price { get; set; }

    /// <summary>
    /// User-defined modification identifier, returned as-is in the response. Optional; not validated for
    /// uniqueness.
    /// </summary>
    [JsonPropertyName("modifyId")]
    public long? ModifyId { get; set; }

    [JsonPropertyName("recvWindow")]
    public long? RecvWindow { get; set; }
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
