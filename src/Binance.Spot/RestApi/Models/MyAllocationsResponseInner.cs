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

namespace Binance.Spot.RestApi;

public sealed class MyAllocationsResponseInner
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("allocationId")]
    public long? AllocationId { get; set; }

    [JsonPropertyName("allocationType")]
    public string? AllocationType { get; set; }

    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    [JsonPropertyName("orderListId")]
    public long? OrderListId { get; set; }

    [JsonPropertyName("price")]
    public string? Price { get; set; }

    [JsonPropertyName("qty")]
    public string? Qty { get; set; }

    [JsonPropertyName("quoteQty")]
    public string? QuoteQty { get; set; }

    [JsonPropertyName("commission")]
    public string? Commission { get; set; }

    [JsonPropertyName("commissionAsset")]
    public string? CommissionAsset { get; set; }

    [JsonPropertyName("time")]
    public long? Time { get; set; }

    [JsonPropertyName("isBuyer")]
    public bool? IsBuyer { get; set; }

    [JsonPropertyName("isMaker")]
    public bool? IsMaker { get; set; }

    [JsonPropertyName("isAllocator")]
    public bool? IsAllocator { get; set; }
}
