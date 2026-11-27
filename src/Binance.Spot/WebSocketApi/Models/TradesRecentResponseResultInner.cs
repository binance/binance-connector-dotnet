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

public sealed class TradesRecentResponseResultInner
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("price")]
    public string? Price { get; set; }

    [JsonPropertyName("qty")]
    public string? Qty { get; set; }

    [JsonPropertyName("quoteQty")]
    public string? QuoteQty { get; set; }

    [JsonPropertyName("time")]
    public long? Time { get; set; }

    [JsonPropertyName("isBuyerMaker")]
    public bool? IsBuyerMaker { get; set; }

    [JsonPropertyName("isBestMatch")]
    public bool? IsBestMatch { get; set; }
}
