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

/// <summary>symbols.</summary>
public sealed class ExchangeInformationResponseSymbolsInner
{
    /// <summary>Symbol.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Pair.</summary>
    [JsonPropertyName("pair")]
    public string? Pair { get; set; }

    /// <summary>Contract Type.</summary>
    [JsonPropertyName("contractType")]
    public string? ContractType { get; set; }

    /// <summary>Delivery Date.</summary>
    [JsonPropertyName("deliveryDate")]
    public long? DeliveryDate { get; set; }

    /// <summary>Onboard Date.</summary>
    [JsonPropertyName("onboardDate")]
    public long? OnboardDate { get; set; }

    /// <summary>Status.</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>ignore</summary>
    [JsonPropertyName("maintMarginPercent")]
    public string? MaintMarginPercent { get; set; }

    /// <summary>ignore</summary>
    [JsonPropertyName("requiredMarginPercent")]
    public string? RequiredMarginPercent { get; set; }

    /// <summary>Base Asset.</summary>
    [JsonPropertyName("baseAsset")]
    public string? BaseAsset { get; set; }

    /// <summary>Quote Asset.</summary>
    [JsonPropertyName("quoteAsset")]
    public string? QuoteAsset { get; set; }

    /// <summary>Margin Asset.</summary>
    [JsonPropertyName("marginAsset")]
    public string? MarginAsset { get; set; }

    /// <summary>please do not use it as tickSize</summary>
    [JsonPropertyName("pricePrecision")]
    public long? PricePrecision { get; set; }

    /// <summary>please do not use it as stepSize</summary>
    [JsonPropertyName("quantityPrecision")]
    public long? QuantityPrecision { get; set; }

    /// <summary>Base Asset Precision.</summary>
    [JsonPropertyName("baseAssetPrecision")]
    public long? BaseAssetPrecision { get; set; }

    /// <summary>Quote Precision.</summary>
    [JsonPropertyName("quotePrecision")]
    public long? QuotePrecision { get; set; }

    [JsonPropertyName("underlyingType")]
    public string? UnderlyingType { get; set; }

    [JsonPropertyName("underlyingSubType")]
    public List<string>? UnderlyingSubType { get; set; }

    [JsonPropertyName("settlePlan")]
    public long? SettlePlan { get; set; }

    /// <summary>threshold for algo order with "priceProtect"</summary>
    [JsonPropertyName("triggerProtect")]
    public string? TriggerProtect { get; set; }

    [JsonPropertyName("filters")]
    public List<ExchangeInformationResponseSymbolsInnerFiltersInner>? Filters { get; set; }

    [JsonPropertyName("orderTypes")]
    public List<string>? OrderTypes { get; set; }

    /// <summary>Time In Force.</summary>
    [JsonPropertyName("timeInForce")]
    public List<string>? TimeInForce { get; set; }

    /// <summary>liquidation fee rate</summary>
    [JsonPropertyName("liquidationFee")]
    public string? LiquidationFee { get; set; }

    /// <summary>the max price difference rate( from mark price) a market order can make</summary>
    [JsonPropertyName("marketTakeBound")]
    public string? MarketTakeBound { get; set; }
}
