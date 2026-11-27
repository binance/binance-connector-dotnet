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

public sealed class AcceptTheOfferedQuoteResponse
{
    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

    [JsonPropertyName("createTime")]
    public long? CreateTime { get; set; }

    /// <summary>PROCESS/ACCEPT_SUCCESS/SUCCESS/FAIL</summary>
    [JsonPropertyName("orderStatus")]
    public string? OrderStatus { get; set; }
}
