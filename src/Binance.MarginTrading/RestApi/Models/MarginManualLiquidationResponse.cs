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

public sealed class MarginManualLiquidationResponse
{
    /// <summary>asset.</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>interest.</summary>
    [JsonPropertyName("interest")]
    public string? Interest { get; set; }

    /// <summary>principal.</summary>
    [JsonPropertyName("principal")]
    public string? Principal { get; set; }

    /// <summary>liability Asset.</summary>
    [JsonPropertyName("liabilityAsset")]
    public string? LiabilityAsset { get; set; }

    /// <summary>liability Qty.</summary>
    [JsonPropertyName("liabilityQty")]
    public decimal? LiabilityQty { get; set; }
}
