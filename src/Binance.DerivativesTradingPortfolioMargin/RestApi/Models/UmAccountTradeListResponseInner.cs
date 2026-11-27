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

public sealed class UmAccountTradeListResponseInner
{
    /// <summary>Trade symbol, if existing.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>ID.</summary>
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    /// <summary>
    /// Normal orderID after trigger if appliable, only have when the strategy is triggered
    /// </summary>
    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    /// <summary>Side.</summary>
    [JsonPropertyName("side")]
    public string? Side { get; set; }

    /// <summary>Price.</summary>
    [JsonPropertyName("price")]
    public string? Price { get; set; }

    /// <summary>Qty.</summary>
    [JsonPropertyName("qty")]
    public string? Qty { get; set; }

    /// <summary>Realized Pnl.</summary>
    [JsonPropertyName("realizedPnl")]
    public string? RealizedPnl { get; set; }

    /// <summary>Quote Qty.</summary>
    [JsonPropertyName("quoteQty")]
    public string? QuoteQty { get; set; }

    /// <summary>Commission.</summary>
    [JsonPropertyName("commission")]
    public string? Commission { get; set; }

    /// <summary>Commission Asset.</summary>
    [JsonPropertyName("commissionAsset")]
    public string? CommissionAsset { get; set; }

    /// <summary>Event time.</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    /// <summary>Buyer.</summary>
    [JsonPropertyName("buyer")]
    public bool? Buyer { get; set; }

    /// <summary>Maker.</summary>
    [JsonPropertyName("maker")]
    public bool? Maker { get; set; }

    /// <summary>BOTH means that it is the position of One-way Mode</summary>
    [JsonPropertyName("positionSide")]
    public string? PositionSide { get; set; }
}
