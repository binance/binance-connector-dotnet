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

namespace Binance.Convert.RestApi;

public sealed class GetConvertTradeHistoryResponseListInner
{
    [JsonPropertyName("quoteId")]
    public string? QuoteId { get; set; }

    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    /// <summary>Order status</summary>
    [JsonPropertyName("orderStatus")]
    public string? OrderStatus { get; set; }

    /// <summary>Source asset</summary>
    [JsonPropertyName("fromAsset")]
    public string? FromAsset { get; set; }

    /// <summary>Source amount</summary>
    [JsonPropertyName("fromAmount")]
    public string? FromAmount { get; set; }

    /// <summary>Destination asset</summary>
    [JsonPropertyName("toAsset")]
    public string? ToAsset { get; set; }

    /// <summary>Destination amount</summary>
    [JsonPropertyName("toAmount")]
    public string? ToAmount { get; set; }

    /// <summary>Price ratio</summary>
    [JsonPropertyName("ratio")]
    public string? Ratio { get; set; }

    /// <summary>Inverse price ratio</summary>
    [JsonPropertyName("inverseRatio")]
    public string? InverseRatio { get; set; }

    [JsonPropertyName("createTime")]
    public long? CreateTime { get; set; }
}
