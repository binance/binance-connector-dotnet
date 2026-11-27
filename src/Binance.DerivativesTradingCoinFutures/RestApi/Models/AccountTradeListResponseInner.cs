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

public sealed class AccountTradeListResponseInner
{
    /// <summary>Trading symbol</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>positionId</summary>
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    /// <summary>Sub-order ID</summary>
    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    /// <summary>Pair</summary>
    [JsonPropertyName("pair")]
    public string? Pair { get; set; }

    /// <summary>Trading side</summary>
    [JsonPropertyName("side")]
    public string? Side { get; set; }

    /// <summary>Latest token price.</summary>
    [JsonPropertyName("price")]
    public string? Price { get; set; }

    /// <summary>Quantity.</summary>
    [JsonPropertyName("qty")]
    public string? Qty { get; set; }

    /// <summary>Realized PnL.</summary>
    [JsonPropertyName("realizedPnl")]
    public string? RealizedPnl { get; set; }

    /// <summary>Margin asset.</summary>
    [JsonPropertyName("marginAsset")]
    public string? MarginAsset { get; set; }

    /// <summary>Base asset quantity. Populated for COIN-M symbols; returns "0" for USDⓈ-M symbols.</summary>
    [JsonPropertyName("baseQty")]
    public string? BaseQty { get; set; }

    /// <summary>
    /// Quote asset quantity. Populated for USDⓈ-M symbols; returns "0" for COIN-M symbols.
    /// </summary>
    [JsonPropertyName("quoteQty")]
    public string? QuoteQty { get; set; }

    /// <summary>Transaction Fee (in Crypto)</summary>
    [JsonPropertyName("commission")]
    public string? Commission { get; set; }

    /// <summary>Commission asset.</summary>
    [JsonPropertyName("commissionAsset")]
    public string? CommissionAsset { get; set; }

    /// <summary>Time</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    /// <summary>Position side</summary>
    [JsonPropertyName("positionSide")]
    public string? PositionSide { get; set; }

    /// <summary>Whether the trade is a buy side for the account.</summary>
    [JsonPropertyName("buyer")]
    public bool? Buyer { get; set; }

    /// <summary>Whether the account is maker in this trade.</summary>
    [JsonPropertyName("maker")]
    public bool? Maker { get; set; }
}
