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

public sealed class NewBlockTradeOrderLegsParameterInner
{
    /// <summary>Option trading pair</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Buy/sell direction</summary>
    [JsonPropertyName("side")]
    public NewBlockTradeOrderLegsParameterInnerSide? Side { get; set; }

    /// <summary>Order type</summary>
    [JsonPropertyName("type")]
    public NewBlockTradeOrderLegsParameterInnerType? Type { get; set; }

    /// <summary>Order quantity</summary>
    [JsonPropertyName("quantity")]
    public string? Quantity { get; set; }

    /// <summary>Order price</summary>
    [JsonPropertyName("price")]
    public string? Price { get; set; }
}

[JsonConverter(typeof(ExtensibleValueConverter<NewBlockTradeOrderLegsParameterInnerSide>))]
public readonly struct NewBlockTradeOrderLegsParameterInnerSide : IExtensibleValue<NewBlockTradeOrderLegsParameterInnerSide>, IEquatable<NewBlockTradeOrderLegsParameterInnerSide>
{
    private readonly string? _value;

    public NewBlockTradeOrderLegsParameterInnerSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewBlockTradeOrderLegsParameterInnerSide Buy { get; } = new("BUY");

    public static NewBlockTradeOrderLegsParameterInnerSide Sell { get; } = new("SELL");

    static NewBlockTradeOrderLegsParameterInnerSide IExtensibleValue<NewBlockTradeOrderLegsParameterInnerSide>.Create(string value) => new(value);

    public static bool operator ==(NewBlockTradeOrderLegsParameterInnerSide left, NewBlockTradeOrderLegsParameterInnerSide right) => left.Equals(right);

    public static bool operator !=(NewBlockTradeOrderLegsParameterInnerSide left, NewBlockTradeOrderLegsParameterInnerSide right) => !left.Equals(right);

    public static implicit operator NewBlockTradeOrderLegsParameterInnerSide(string value) => new(value);

    public static NewBlockTradeOrderLegsParameterInnerSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewBlockTradeOrderLegsParameterInnerSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewBlockTradeOrderLegsParameterInnerSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<NewBlockTradeOrderLegsParameterInnerType>))]
public readonly struct NewBlockTradeOrderLegsParameterInnerType : IExtensibleValue<NewBlockTradeOrderLegsParameterInnerType>, IEquatable<NewBlockTradeOrderLegsParameterInnerType>
{
    private readonly string? _value;

    public NewBlockTradeOrderLegsParameterInnerType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewBlockTradeOrderLegsParameterInnerType Limit { get; } = new("LIMIT");

    static NewBlockTradeOrderLegsParameterInnerType IExtensibleValue<NewBlockTradeOrderLegsParameterInnerType>.Create(string value) => new(value);

    public static bool operator ==(NewBlockTradeOrderLegsParameterInnerType left, NewBlockTradeOrderLegsParameterInnerType right) => left.Equals(right);

    public static bool operator !=(NewBlockTradeOrderLegsParameterInnerType left, NewBlockTradeOrderLegsParameterInnerType right) => !left.Equals(right);

    public static implicit operator NewBlockTradeOrderLegsParameterInnerType(string value) => new(value);

    public static NewBlockTradeOrderLegsParameterInnerType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewBlockTradeOrderLegsParameterInnerType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewBlockTradeOrderLegsParameterInnerType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}
