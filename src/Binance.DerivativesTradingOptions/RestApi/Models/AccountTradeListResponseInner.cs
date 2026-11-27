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

public sealed class AccountTradeListResponseInner
{
    /// <summary>unique id</summary>
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    /// <summary>trade id</summary>
    [JsonPropertyName("tradeId")]
    public long? TradeId { get; set; }

    /// <summary>order id</summary>
    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    /// <summary>option symbol</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>trade price</summary>
    [JsonPropertyName("price")]
    public string? Price { get; set; }

    /// <summary>trade quantity</summary>
    [JsonPropertyName("quantity")]
    public string? Quantity { get; set; }

    /// <summary>fee(negative is fee deduction)</summary>
    [JsonPropertyName("fee")]
    public string? Fee { get; set; }

    /// <summary>realized profit/loss</summary>
    [JsonPropertyName("realizedProfit")]
    public string? RealizedProfit { get; set; }

    /// <summary>order side</summary>
    [JsonPropertyName("side")]
    public string? Side { get; set; }

    /// <summary>order type</summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>TAKER or MAKER</summary>
    [JsonPropertyName("liquidity")]
    public string? Liquidity { get; set; }

    /// <summary>trade time</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    /// <summary>price Scale</summary>
    [JsonPropertyName("priceScale")]
    public long? PriceScale { get; set; }

    /// <summary>quantity Scale</summary>
    [JsonPropertyName("quantityScale")]
    public long? QuantityScale { get; set; }

    /// <summary>option Side</summary>
    [JsonPropertyName("optionSide")]
    public string? OptionSide { get; set; }

    /// <summary>quote Asset</summary>
    [JsonPropertyName("quoteAsset")]
    public string? QuoteAsset { get; set; }
}
