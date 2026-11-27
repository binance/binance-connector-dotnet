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

namespace Binance.SimpleEarn.RestApi;

public sealed class GetRwusdQuotaDetailsResponseFastRedemptionQuota
{
    [JsonPropertyName("leftQuota")]
    public string? LeftQuota { get; set; }

    [JsonPropertyName("minimum")]
    public string? Minimum { get; set; }

    [JsonPropertyName("fee")]
    public string? Fee { get; set; }

    [JsonPropertyName("freeQuota")]
    public string? FreeQuota { get; set; }
}
