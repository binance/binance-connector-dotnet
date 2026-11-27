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

namespace Binance.DerivativesTradingUsdsFutures.WebSocketApi;

public sealed class SymbolOrderBookTickerResponse1Result
{
    [JsonPropertyName("lastUpdateId")]
    public long? LastUpdateId { get; set; }

    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("bidPrice")]
    public string? BidPrice { get; set; }

    [JsonPropertyName("bidQty")]
    public string? BidQty { get; set; }

    [JsonPropertyName("askPrice")]
    public string? AskPrice { get; set; }

    [JsonPropertyName("askQty")]
    public string? AskQty { get; set; }

    /// <summary>Transaction time</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }
}
