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

public sealed class AccountTradeListResponseInner
{
    /// <summary>Buyer.</summary>
    [JsonPropertyName("buyer")]
    public bool? Buyer { get; set; }

    /// <summary>Commission.</summary>
    [JsonPropertyName("commission")]
    public string? Commission { get; set; }

    /// <summary>Commission Asset.</summary>
    [JsonPropertyName("commissionAsset")]
    public string? CommissionAsset { get; set; }

    /// <summary>Id.</summary>
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    /// <summary>Maker.</summary>
    [JsonPropertyName("maker")]
    public bool? Maker { get; set; }

    /// <summary>Order Id.</summary>
    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    /// <summary>Price.</summary>
    [JsonPropertyName("price")]
    public string? Price { get; set; }

    /// <summary>Qty.</summary>
    [JsonPropertyName("qty")]
    public string? Qty { get; set; }

    /// <summary>
    /// Quote asset quantity. Populated for USDⓈ-M symbols; returns "0" for COIN-M symbols.
    /// </summary>
    [JsonPropertyName("quoteQty")]
    public string? QuoteQty { get; set; }

    /// <summary>Base asset quantity. Populated for COIN-M symbols; returns "0" for USDⓈ-M symbols.</summary>
    [JsonPropertyName("baseQty")]
    public string? BaseQty { get; set; }

    /// <summary>Margin Asset.</summary>
    [JsonPropertyName("marginAsset")]
    public string? MarginAsset { get; set; }

    /// <summary>Realized Pnl.</summary>
    [JsonPropertyName("realizedPnl")]
    public string? RealizedPnl { get; set; }

    /// <summary>Side.</summary>
    [JsonPropertyName("side")]
    public string? Side { get; set; }

    /// <summary>Position Side.</summary>
    [JsonPropertyName("positionSide")]
    public string? PositionSide { get; set; }

    /// <summary>Symbol.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Pair.</summary>
    [JsonPropertyName("pair")]
    public string? Pair { get; set; }

    /// <summary>Time.</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }
}
