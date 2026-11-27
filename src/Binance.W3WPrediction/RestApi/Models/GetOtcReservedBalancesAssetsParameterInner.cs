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

namespace Binance.W3WPrediction.RestApi;

public sealed class GetOtcReservedBalancesAssetsParameterInner
{
    [JsonPropertyName("type")]
    public GetOtcReservedBalancesAssetsParameterInnerType? Type { get; set; }

    [JsonPropertyName("tokenId")]
    public string? TokenId { get; set; }
}

[JsonConverter(typeof(ExtensibleValueConverter<GetOtcReservedBalancesAssetsParameterInnerType>))]
public readonly struct GetOtcReservedBalancesAssetsParameterInnerType : IExtensibleValue<GetOtcReservedBalancesAssetsParameterInnerType>, IEquatable<GetOtcReservedBalancesAssetsParameterInnerType>
{
    private readonly string? _value;

    public GetOtcReservedBalancesAssetsParameterInnerType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static GetOtcReservedBalancesAssetsParameterInnerType Usdt { get; } = new("USDT");

    public static GetOtcReservedBalancesAssetsParameterInnerType Share { get; } = new("SHARE");

    static GetOtcReservedBalancesAssetsParameterInnerType IExtensibleValue<GetOtcReservedBalancesAssetsParameterInnerType>.Create(string value) => new(value);

    public static bool operator ==(GetOtcReservedBalancesAssetsParameterInnerType left, GetOtcReservedBalancesAssetsParameterInnerType right) => left.Equals(right);

    public static bool operator !=(GetOtcReservedBalancesAssetsParameterInnerType left, GetOtcReservedBalancesAssetsParameterInnerType right) => !left.Equals(right);

    public static implicit operator GetOtcReservedBalancesAssetsParameterInnerType(string value) => new(value);

    public static GetOtcReservedBalancesAssetsParameterInnerType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is GetOtcReservedBalancesAssetsParameterInnerType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(GetOtcReservedBalancesAssetsParameterInnerType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}
