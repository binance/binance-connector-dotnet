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

public sealed class QueryIsolatedMarginAccountInfoResponseAssetsInner
{
    [JsonPropertyName("baseAsset")]
    public QueryIsolatedMarginAccountInfoResponseAssetsInnerBaseAsset? BaseAsset { get; set; }

    [JsonPropertyName("quoteAsset")]
    public QueryIsolatedMarginAccountInfoResponseAssetsInnerQuoteAsset? QuoteAsset { get; set; }

    /// <summary>symbol.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>isolated Created.</summary>
    [JsonPropertyName("isolatedCreated")]
    public bool? IsolatedCreated { get; set; }

    /// <summary>true-enabled, false-disabled</summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>margin Level.</summary>
    [JsonPropertyName("marginLevel")]
    public string? MarginLevel { get; set; }

    /// <summary>"EXCESSIVE", "NORMAL", "MARGIN_CALL", "PRE_LIQUIDATION", "FORCE_LIQUIDATION"</summary>
    [JsonPropertyName("marginLevelStatus")]
    public string? MarginLevelStatus { get; set; }

    /// <summary>margin Ratio.</summary>
    [JsonPropertyName("marginRatio")]
    public string? MarginRatio { get; set; }

    /// <summary>index Price.</summary>
    [JsonPropertyName("indexPrice")]
    public string? IndexPrice { get; set; }

    /// <summary>liquidate Price.</summary>
    [JsonPropertyName("liquidatePrice")]
    public string? LiquidatePrice { get; set; }

    /// <summary>liquidate Rate.</summary>
    [JsonPropertyName("liquidateRate")]
    public string? LiquidateRate { get; set; }

    /// <summary>trade Enabled.</summary>
    [JsonPropertyName("tradeEnabled")]
    public bool? TradeEnabled { get; set; }
}
