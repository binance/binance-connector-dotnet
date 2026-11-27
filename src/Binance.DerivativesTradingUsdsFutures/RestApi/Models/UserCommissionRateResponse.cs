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

public sealed class UserCommissionRateResponse
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>0.02%</summary>
    [JsonPropertyName("makerCommissionRate")]
    public string? MakerCommissionRate { get; set; }

    /// <summary>0.04%</summary>
    [JsonPropertyName("takerCommissionRate")]
    public string? TakerCommissionRate { get; set; }

    /// <summary>0.005%</summary>
    [JsonPropertyName("rpiCommissionRate")]
    public string? RpiCommissionRate { get; set; }
}
