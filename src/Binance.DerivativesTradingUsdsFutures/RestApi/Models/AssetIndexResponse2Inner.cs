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

public sealed class AssetIndexResponse2Inner
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("time")]
    public long? Time { get; set; }

    [JsonPropertyName("index")]
    public string? Index { get; set; }

    [JsonPropertyName("bidBuffer")]
    public string? BidBuffer { get; set; }

    [JsonPropertyName("askBuffer")]
    public string? AskBuffer { get; set; }

    [JsonPropertyName("bidRate")]
    public string? BidRate { get; set; }

    [JsonPropertyName("askRate")]
    public string? AskRate { get; set; }

    [JsonPropertyName("autoExchangeBidBuffer")]
    public string? AutoExchangeBidBuffer { get; set; }

    [JsonPropertyName("autoExchangeAskBuffer")]
    public string? AutoExchangeAskBuffer { get; set; }

    [JsonPropertyName("autoExchangeBidRate")]
    public string? AutoExchangeBidRate { get; set; }

    [JsonPropertyName("autoExchangeAskRate")]
    public string? AutoExchangeAskRate { get; set; }
}
