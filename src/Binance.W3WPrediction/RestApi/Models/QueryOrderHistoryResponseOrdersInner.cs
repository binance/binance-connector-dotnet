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

namespace Binance.W3WPrediction.RestApi;

public sealed class QueryOrderHistoryResponseOrdersInner
{
    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

    [JsonPropertyName("vendorOrderId")]
    public string? VendorOrderId { get; set; }

    [JsonPropertyName("vendor")]
    public string? Vendor { get; set; }

    [JsonPropertyName("marketTopicId")]
    public long? MarketTopicId { get; set; }

    [JsonPropertyName("slug")]
    public string? Slug { get; set; }

    [JsonPropertyName("marketTopicTitle")]
    public string? MarketTopicTitle { get; set; }

    [JsonPropertyName("marketId")]
    public long? MarketId { get; set; }

    [JsonPropertyName("marketTitle")]
    public string? MarketTitle { get; set; }

    [JsonPropertyName("outcome")]
    public string? Outcome { get; set; }

    [JsonPropertyName("outcomeIndex")]
    public long? OutcomeIndex { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("side")]
    public string? Side { get; set; }

    [JsonPropertyName("orderType")]
    public string? OrderType { get; set; }

    [JsonPropertyName("createTime")]
    public long? CreateTime { get; set; }

    [JsonPropertyName("modifyTime")]
    public long? ModifyTime { get; set; }

    [JsonPropertyName("terminalTime")]
    public long? TerminalTime { get; set; }

    [JsonPropertyName("makerUsdtAmount")]
    public string? MakerUsdtAmount { get; set; }

    [JsonPropertyName("makerShareQty")]
    public string? MakerShareQty { get; set; }

    [JsonPropertyName("filledUsdtAmount")]
    public string? FilledUsdtAmount { get; set; }

    [JsonPropertyName("filledShareQty")]
    public string? FilledShareQty { get; set; }

    [JsonPropertyName("fillPercentage")]
    public string? FillPercentage { get; set; }

    [JsonPropertyName("price")]
    public string? Price { get; set; }

    [JsonPropertyName("marketProviderFee")]
    public string? MarketProviderFee { get; set; }

    [JsonPropertyName("networkFee")]
    public string? NetworkFee { get; set; }
}
