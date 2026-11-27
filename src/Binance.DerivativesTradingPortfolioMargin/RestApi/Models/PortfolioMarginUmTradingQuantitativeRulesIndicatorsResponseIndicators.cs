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

/// <summary>Indicators.</summary>
public sealed class PortfolioMarginUmTradingQuantitativeRulesIndicatorsResponseIndicators
{
    /// <summary>BTCUSDT.</summary>
    [JsonPropertyName("BTCUSDT")]
    public List<PortfolioMarginUmTradingQuantitativeRulesIndicatorsResponseIndicatorsBTCUSDTInner>? BTCUSDT { get; set; }

    /// <summary>ACCOUNT.</summary>
    [JsonPropertyName("ACCOUNT")]
    public List<PortfolioMarginUmTradingQuantitativeRulesIndicatorsResponseIndicatorsACCOUNTInner>? ACCOUNT { get; set; }
}
