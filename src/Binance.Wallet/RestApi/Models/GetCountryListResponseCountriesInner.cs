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

namespace Binance.Wallet.RestApi;

public sealed class GetCountryListResponseCountriesInner
{
    /// <summary>ISO 2-digit country code, lowercase.</summary>
    [JsonPropertyName("countryCode")]
    public string? CountryCode { get; set; }

    /// <summary>Country display name.</summary>
    [JsonPropertyName("countryName")]
    public string? CountryName { get; set; }

    /// <summary>supported, limited, or blocked.</summary>
    [JsonPropertyName("blockType")]
    public string? BlockType { get; set; }

    /// <summary>Whether deposit is allowed for this country.</summary>
    [JsonPropertyName("depositAllowed")]
    public bool? DepositAllowed { get; set; }

    /// <summary>Whether withdrawal is allowed for this country.</summary>
    [JsonPropertyName("withdrawalAllowed")]
    public bool? WithdrawalAllowed { get; set; }

    /// <summary>
    /// Whether this country has region-level restrictions. Always false for the BR entity, which does not
    /// collect region/city.
    /// </summary>
    [JsonPropertyName("hasRegionRestrictions")]
    public bool? HasRegionRestrictions { get; set; }
}
