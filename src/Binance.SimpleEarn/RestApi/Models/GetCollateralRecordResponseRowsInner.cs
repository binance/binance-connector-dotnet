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

namespace Binance.SimpleEarn.RestApi;

public sealed class GetCollateralRecordResponseRowsInner
{
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    [JsonPropertyName("productId")]
    public string? ProductId { get; set; }

    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    [JsonPropertyName("createTime")]
    public long? CreateTime { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("productName")]
    public string? ProductName { get; set; }

    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }
}
