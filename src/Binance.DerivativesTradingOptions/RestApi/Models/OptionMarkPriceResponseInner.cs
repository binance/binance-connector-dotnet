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

namespace Binance.DerivativesTradingOptions.RestApi;

public sealed class OptionMarkPriceResponseInner
{
    /// <summary>symbol</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Mark price</summary>
    [JsonPropertyName("markPrice")]
    public string? MarkPrice { get; set; }

    /// <summary>Implied volatility Buy</summary>
    [JsonPropertyName("bidIV")]
    public string? BidIV { get; set; }

    /// <summary>Implied volatility Sell</summary>
    [JsonPropertyName("askIV")]
    public string? AskIV { get; set; }

    /// <summary>Implied volatility mark</summary>
    [JsonPropertyName("markIV")]
    public string? MarkIV { get; set; }

    /// <summary>delta</summary>
    [JsonPropertyName("delta")]
    public string? Delta { get; set; }

    /// <summary>theta</summary>
    [JsonPropertyName("theta")]
    public string? Theta { get; set; }

    /// <summary>gamma</summary>
    [JsonPropertyName("gamma")]
    public string? Gamma { get; set; }

    /// <summary>vega</summary>
    [JsonPropertyName("vega")]
    public string? Vega { get; set; }

    /// <summary>Current highest buy price</summary>
    [JsonPropertyName("highPriceLimit")]
    public string? HighPriceLimit { get; set; }

    /// <summary>Current lowest sell price</summary>
    [JsonPropertyName("lowPriceLimit")]
    public string? LowPriceLimit { get; set; }

    /// <summary>risk free rate</summary>
    [JsonPropertyName("riskFreeInterest")]
    public string? RiskFreeInterest { get; set; }
}
