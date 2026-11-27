//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json.Serialization;

namespace Binance.Common.Tests;

public sealed class TimeDto
{
    [JsonPropertyName("serverTime")]
    public long? ServerTime { get; set; }

    [JsonPropertyName("price")]
    public decimal? Price { get; set; }

    [JsonPropertyName("side")]
    public Side? Side { get; set; }
}

// An extensible enum like those of the product clients.
[JsonConverter(typeof(ExtensibleValueConverter<Side>))]
public readonly struct Side : IExtensibleValue<Side>, IEquatable<Side>
{
    private readonly string? _value;

    public Side(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    static Side IExtensibleValue<Side>.Create(string value) => new(value);

    public static Side Buy { get; } = new("BUY");

    public static bool operator ==(Side left, Side right) => left.Equals(right);

    public static bool operator !=(Side left, Side right) => !left.Equals(right);

    public static implicit operator Side(string value) => new(value);

    public override bool Equals(object? obj) => obj is Side other && Equals(other);

    public bool Equals(Side other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    public override string ToString() => Value;
}

/// <summary>A oneOf of <see cref="Circle"/> and a list of numbers.</summary>
[JsonConverter(typeof(OneOfConverter<Shape>))]
public sealed class Shape : OneOf
{
    protected override JsonSerializerContext Context => TestJson.Default;
}

public sealed class Circle
{
    [JsonPropertyName("radius")]
    public decimal? Radius { get; set; }
}

[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString)]
[JsonSerializable(typeof(TimeDto))]
[JsonSerializable(typeof(List<TimeDto>))]
[JsonSerializable(typeof(Shape))]
[JsonSerializable(typeof(Circle))]
[JsonSerializable(typeof(List<long>))]
[JsonSerializable(typeof(long))]
public sealed partial class TestJson : JsonSerializerContext;
