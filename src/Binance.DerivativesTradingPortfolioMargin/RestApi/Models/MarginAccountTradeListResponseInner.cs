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

public sealed class MarginAccountTradeListResponseInner
{
    /// <summary>Commission.</summary>
    [JsonPropertyName("commission")]
    public string? Commission { get; set; }

    /// <summary>Commission Asset.</summary>
    [JsonPropertyName("commissionAsset")]
    public string? CommissionAsset { get; set; }

    /// <summary>ID.</summary>
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    /// <summary>Is Best Match.</summary>
    [JsonPropertyName("isBestMatch")]
    public bool? IsBestMatch { get; set; }

    /// <summary>Is Buyer.</summary>
    [JsonPropertyName("isBuyer")]
    public bool? IsBuyer { get; set; }

    /// <summary>Is Maker.</summary>
    [JsonPropertyName("isMaker")]
    public bool? IsMaker { get; set; }

    /// <summary>
    /// Normal orderID after trigger if appliable, only have when the strategy is triggered
    /// </summary>
    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    /// <summary>Price.</summary>
    [JsonPropertyName("price")]
    public string? Price { get; set; }

    /// <summary>Qty.</summary>
    [JsonPropertyName("qty")]
    public string? Qty { get; set; }

    /// <summary>Trade symbol, if existing.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Event time.</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }
}
