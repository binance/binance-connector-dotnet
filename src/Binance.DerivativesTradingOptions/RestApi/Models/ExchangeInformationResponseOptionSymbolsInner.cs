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

public sealed class ExchangeInformationResponseOptionSymbolsInner
{
    /// <summary>expiry time</summary>
    [JsonPropertyName("expiryDate")]
    public long? ExpiryDate { get; set; }

    /// <summary>filters</summary>
    [JsonPropertyName("filters")]
    public List<ExchangeInformationResponseOptionSymbolsInnerFiltersInner>? Filters { get; set; }

    /// <summary>Trading pair name</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Direction: CALL long, PUT short</summary>
    [JsonPropertyName("side")]
    public string? Side { get; set; }

    /// <summary>Strike price</summary>
    [JsonPropertyName("strikePrice")]
    public string? StrikePrice { get; set; }

    /// <summary>Name of the underlying asset of the option contract</summary>
    [JsonPropertyName("underlying")]
    public string? Underlying { get; set; }

    /// <summary>
    /// Contract unit, the quantity of the underlying asset represented by a single contract.
    /// </summary>
    [JsonPropertyName("unit")]
    public long? Unit { get; set; }

    /// <summary>liquidation fee rate</summary>
    [JsonPropertyName("liquidationFeeRate")]
    public string? LiquidationFeeRate { get; set; }

    /// <summary>Minimum order quantity</summary>
    [JsonPropertyName("minQty")]
    public string? MinQty { get; set; }

    /// <summary>Maximum order quantity</summary>
    [JsonPropertyName("maxQty")]
    public string? MaxQty { get; set; }

    /// <summary>Initial Magin Ratio</summary>
    [JsonPropertyName("initialMargin")]
    public string? InitialMargin { get; set; }

    /// <summary>Maintenance Margin Ratio</summary>
    [JsonPropertyName("maintenanceMargin")]
    public string? MaintenanceMargin { get; set; }

    /// <summary>Min Initial Margin Ratio</summary>
    [JsonPropertyName("minInitialMargin")]
    public string? MinInitialMargin { get; set; }

    /// <summary>Min Maintenance Margin Ratio</summary>
    [JsonPropertyName("minMaintenanceMargin")]
    public string? MinMaintenanceMargin { get; set; }

    /// <summary>price precision</summary>
    [JsonPropertyName("priceScale")]
    public long? PriceScale { get; set; }

    /// <summary>quantity precision</summary>
    [JsonPropertyName("quantityScale")]
    public long? QuantityScale { get; set; }

    /// <summary>Quotation asset</summary>
    [JsonPropertyName("quoteAsset")]
    public string? QuoteAsset { get; set; }

    /// <summary>Contract type</summary>
    [JsonPropertyName("contractType")]
    public string? ContractType { get; set; }

    /// <summary>Underlying type</summary>
    [JsonPropertyName("underlyingType")]
    public string? UnderlyingType { get; set; }

    /// <summary>Whether naked selling is allowed for this symbol</summary>
    [JsonPropertyName("nakedSell")]
    public bool? NakedSell { get; set; }

    /// <summary>Trading Status</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
