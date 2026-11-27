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

public sealed class OptionPositionInformationResponseInner
{
    /// <summary>Average entry price</summary>
    [JsonPropertyName("entryPrice")]
    public string? EntryPrice { get; set; }

    /// <summary>Option trading pair</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Position direction</summary>
    [JsonPropertyName("side")]
    public string? Side { get; set; }

    /// <summary>
    /// Number of positions (positive numbers represent long positions, negative number represent short
    /// positions)
    /// </summary>
    [JsonPropertyName("quantity")]
    public string? Quantity { get; set; }

    /// <summary>Current market value</summary>
    [JsonPropertyName("markValue")]
    public string? MarkValue { get; set; }

    /// <summary>Unrealized profit/loss</summary>
    [JsonPropertyName("unrealizedPNL")]
    public string? UnrealizedPNL { get; set; }

    /// <summary>Mark price</summary>
    [JsonPropertyName("markPrice")]
    public string? MarkPrice { get; set; }

    /// <summary>Strike price</summary>
    [JsonPropertyName("strikePrice")]
    public string? StrikePrice { get; set; }

    /// <summary>Exercise time</summary>
    [JsonPropertyName("expiryDate")]
    public long? ExpiryDate { get; set; }

    /// <summary>price Scale</summary>
    [JsonPropertyName("priceScale")]
    public long? PriceScale { get; set; }

    /// <summary>quantity Scale</summary>
    [JsonPropertyName("quantityScale")]
    public long? QuantityScale { get; set; }

    /// <summary>option type</summary>
    [JsonPropertyName("optionSide")]
    public string? OptionSide { get; set; }

    /// <summary>quote asset</summary>
    [JsonPropertyName("quoteAsset")]
    public string? QuoteAsset { get; set; }

    /// <summary>last update time</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    /// <summary>buy order qty</summary>
    [JsonPropertyName("bidQuantity")]
    public string? BidQuantity { get; set; }

    /// <summary>sell order qty</summary>
    [JsonPropertyName("askQuantity")]
    public string? AskQuantity { get; set; }
}
