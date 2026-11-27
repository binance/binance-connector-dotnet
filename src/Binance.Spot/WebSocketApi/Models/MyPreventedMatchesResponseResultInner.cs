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

namespace Binance.Spot.WebSocketApi;

public sealed class MyPreventedMatchesResponseResultInner
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("preventedMatchId")]
    public long? PreventedMatchId { get; set; }

    [JsonPropertyName("takerOrderId")]
    public long? TakerOrderId { get; set; }

    [JsonPropertyName("makerSymbol")]
    public string? MakerSymbol { get; set; }

    [JsonPropertyName("makerOrderId")]
    public long? MakerOrderId { get; set; }

    [JsonPropertyName("tradeGroupId")]
    public long? TradeGroupId { get; set; }

    [JsonPropertyName("selfTradePreventionMode")]
    public string? SelfTradePreventionMode { get; set; }

    [JsonPropertyName("price")]
    public string? Price { get; set; }

    [JsonPropertyName("makerPreventedQuantity")]
    public string? MakerPreventedQuantity { get; set; }

    [JsonPropertyName("transactTime")]
    public long? TransactTime { get; set; }
}
