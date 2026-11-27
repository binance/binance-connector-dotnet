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

/// <summary>
/// indicator: quantitative rules indicators, value: user's indicators value, triggerValue: trigger
/// indicator value threshold of quantitative rules.
/// </summary>
public sealed class FuturesTradingQuantitativeRulesIndicatorsResponseIndicators
{
    [JsonPropertyName("BTCUSDT")]
    public List<FuturesTradingQuantitativeRulesIndicatorsResponseIndicatorsBTCUSDTInner>? BTCUSDT { get; set; }

    [JsonPropertyName("ETHUSDT")]
    public List<FuturesTradingQuantitativeRulesIndicatorsResponseIndicatorsBTCUSDTInner>? ETHUSDT { get; set; }

    [JsonPropertyName("ACCOUNT")]
    public List<FuturesTradingQuantitativeRulesIndicatorsResponseIndicatorsACCOUNTInner>? ACCOUNT { get; set; }
}
