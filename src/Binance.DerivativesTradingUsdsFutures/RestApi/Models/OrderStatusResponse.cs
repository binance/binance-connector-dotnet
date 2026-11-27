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

public sealed class OrderStatusResponse
{
    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    [JsonPropertyName("orderStatus")]
    public string? OrderStatus { get; set; }

    [JsonPropertyName("fromAsset")]
    public string? FromAsset { get; set; }

    [JsonPropertyName("fromAmount")]
    public string? FromAmount { get; set; }

    [JsonPropertyName("toAsset")]
    public string? ToAsset { get; set; }

    [JsonPropertyName("toAmount")]
    public string? ToAmount { get; set; }

    [JsonPropertyName("ratio")]
    public string? Ratio { get; set; }

    [JsonPropertyName("inverseRatio")]
    public string? InverseRatio { get; set; }

    [JsonPropertyName("createTime")]
    public long? CreateTime { get; set; }
}
