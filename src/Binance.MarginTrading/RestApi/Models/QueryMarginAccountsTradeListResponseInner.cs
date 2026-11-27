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

public sealed class QueryMarginAccountsTradeListResponseInner
{
    /// <summary>commission.</summary>
    [JsonPropertyName("commission")]
    public string? Commission { get; set; }

    /// <summary>commission Asset.</summary>
    [JsonPropertyName("commissionAsset")]
    public string? CommissionAsset { get; set; }

    /// <summary>id.</summary>
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    /// <summary>is Best Match.</summary>
    [JsonPropertyName("isBestMatch")]
    public bool? IsBestMatch { get; set; }

    /// <summary>is Buyer.</summary>
    [JsonPropertyName("isBuyer")]
    public bool? IsBuyer { get; set; }

    /// <summary>is Maker.</summary>
    [JsonPropertyName("isMaker")]
    public bool? IsMaker { get; set; }

    /// <summary>order Id.</summary>
    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    /// <summary>price.</summary>
    [JsonPropertyName("price")]
    public string? Price { get; set; }

    /// <summary>qty.</summary>
    [JsonPropertyName("qty")]
    public string? Qty { get; set; }

    /// <summary>symbol.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>is Isolated.</summary>
    [JsonPropertyName("isIsolated")]
    public bool? IsIsolated { get; set; }

    /// <summary>time.</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }
}
