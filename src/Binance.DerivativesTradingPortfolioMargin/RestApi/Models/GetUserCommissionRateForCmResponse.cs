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

namespace Binance.DerivativesTradingPortfolioMargin.RestApi;

public sealed class GetUserCommissionRateForCmResponse
{
    /// <summary>Trade symbol, if existing.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>0.015%</summary>
    [JsonPropertyName("makerCommissionRate")]
    public string? MakerCommissionRate { get; set; }

    /// <summary>0.040%</summary>
    [JsonPropertyName("takerCommissionRate")]
    public string? TakerCommissionRate { get; set; }
}
