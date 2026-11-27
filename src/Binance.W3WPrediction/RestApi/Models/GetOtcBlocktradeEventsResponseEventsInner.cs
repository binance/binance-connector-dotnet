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

public sealed class GetOtcBlocktradeEventsResponseEventsInner
{
    [JsonPropertyName("event")]
    public string? Event { get; set; }

    [JsonPropertyName("blocktradeId")]
    public string? BlocktradeId { get; set; }

    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

    [JsonPropertyName("marketId")]
    public long? MarketId { get; set; }

    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    [JsonPropertyName("fee")]
    public string? Fee { get; set; }

    [JsonPropertyName("effectiveFee")]
    public string? EffectiveFee { get; set; }

    [JsonPropertyName("price")]
    public string? Price { get; set; }

    [JsonPropertyName("transactionHash")]
    public string? TransactionHash { get; set; }

    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    [JsonPropertyName("isMaker")]
    public bool? IsMaker { get; set; }

    [JsonPropertyName("timestamp")]
    public string? Timestamp { get; set; }
}
