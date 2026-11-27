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

namespace Binance.Spot.RestApi;

public sealed class PercentPriceBySideFilter
{
    [JsonPropertyName("filterType")]
    public string? FilterType { get; set; }

    [JsonPropertyName("multiplierExponent")]
    public long? MultiplierExponent { get; set; }

    [JsonPropertyName("bidMultiplierUp")]
    public string? BidMultiplierUp { get; set; }

    [JsonPropertyName("bidMultiplierDown")]
    public string? BidMultiplierDown { get; set; }

    [JsonPropertyName("askMultiplierUp")]
    public string? AskMultiplierUp { get; set; }

    [JsonPropertyName("askMultiplierDown")]
    public string? AskMultiplierDown { get; set; }

    [JsonPropertyName("avgPriceMins")]
    public long? AvgPriceMins { get; set; }
}
