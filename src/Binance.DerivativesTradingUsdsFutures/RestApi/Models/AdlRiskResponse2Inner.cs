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

public sealed class AdlRiskResponse2Inner
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>ADL Risk rating</summary>
    [JsonPropertyName("adlRisk")]
    public string? AdlRisk { get; set; }

    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }
}
