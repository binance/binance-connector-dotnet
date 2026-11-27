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

public sealed class MarginAccountNewOrderResponseFillsInner
{
    /// <summary>price.</summary>
    [JsonPropertyName("price")]
    public string? Price { get; set; }

    /// <summary>qty.</summary>
    [JsonPropertyName("qty")]
    public string? Qty { get; set; }

    /// <summary>commission.</summary>
    [JsonPropertyName("commission")]
    public string? Commission { get; set; }

    /// <summary>commission Asset.</summary>
    [JsonPropertyName("commissionAsset")]
    public string? CommissionAsset { get; set; }

    /// <summary>trade Id.</summary>
    [JsonPropertyName("tradeId")]
    public long? TradeId { get; set; }
}
