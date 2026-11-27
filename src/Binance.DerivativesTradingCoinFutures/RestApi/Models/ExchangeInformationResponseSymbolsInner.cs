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

namespace Binance.DerivativesTradingCoinFutures.RestApi;

public sealed class ExchangeInformationResponseSymbolsInner
{
    /// <summary>Trading filters and constraints.</summary>
    [JsonPropertyName("filters")]
    public List<ExchangeInformationResponseSymbolsInnerFiltersInner>? Filters { get; set; }

    /// <summary>Supported order types.</summary>
    [JsonPropertyName("orderTypes")]
    public List<string>? OrderTypes { get; set; }

    /// <summary>Time in force</summary>
    [JsonPropertyName("timeInForce")]
    public List<string>? TimeInForce { get; set; }

    /// <summary>liquidation fee rate</summary>
    [JsonPropertyName("liquidationFee")]
    public string? LiquidationFee { get; set; }

    /// <summary>the max price difference rate( from mark price) a market order can make</summary>
    [JsonPropertyName("marketTakeBound")]
    public string? MarketTakeBound { get; set; }

    /// <summary>Trading symbol</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Pair</summary>
    [JsonPropertyName("pair")]
    public string? Pair { get; set; }

    /// <summary>Contract type.</summary>
    [JsonPropertyName("contractType")]
    public string? ContractType { get; set; }

    /// <summary>Delivery timestamp.</summary>
    [JsonPropertyName("deliveryDate")]
    public long? DeliveryDate { get; set; }

    /// <summary>Onboard timestamp.</summary>
    [JsonPropertyName("onboardDate")]
    public long? OnboardDate { get; set; }

    /// <summary>Contract status.</summary>
    [JsonPropertyName("contractStatus")]
    public string? ContractStatus { get; set; }

    /// <summary>Contract size.</summary>
    [JsonPropertyName("contractSize")]
    public long? ContractSize { get; set; }

    /// <summary>Quote asset symbol.</summary>
    [JsonPropertyName("quoteAsset")]
    public string? QuoteAsset { get; set; }

    /// <summary>Base asset symbol.</summary>
    [JsonPropertyName("baseAsset")]
    public string? BaseAsset { get; set; }

    /// <summary>Margin asset.</summary>
    [JsonPropertyName("marginAsset")]
    public string? MarginAsset { get; set; }

    /// <summary>please do not use it as tickSize</summary>
    [JsonPropertyName("pricePrecision")]
    public long? PricePrecision { get; set; }

    /// <summary>please do not use it as stepSize</summary>
    [JsonPropertyName("quantityPrecision")]
    public long? QuantityPrecision { get; set; }

    /// <summary>Base asset precision.</summary>
    [JsonPropertyName("baseAssetPrecision")]
    public long? BaseAssetPrecision { get; set; }

    /// <summary>Quote asset precision.</summary>
    [JsonPropertyName("quotePrecision")]
    public long? QuotePrecision { get; set; }

    /// <summary>ignore</summary>
    [JsonPropertyName("equalQtyPrecision")]
    public long? EqualQtyPrecision { get; set; }

    /// <summary>threshold for algo order with "priceProtect"</summary>
    [JsonPropertyName("triggerProtect")]
    public string? TriggerProtect { get; set; }

    /// <summary>ignore</summary>
    [JsonPropertyName("maintMarginPercent")]
    public string? MaintMarginPercent { get; set; }

    /// <summary>ignore</summary>
    [JsonPropertyName("requiredMarginPercent")]
    public string? RequiredMarginPercent { get; set; }

    /// <summary>Underlying asset type.</summary>
    [JsonPropertyName("underlyingType")]
    public string? UnderlyingType { get; set; }

    /// <summary>Underlying asset sub-type.</summary>
    [JsonPropertyName("underlyingSubType")]
    public List<string>? UnderlyingSubType { get; set; }
}
