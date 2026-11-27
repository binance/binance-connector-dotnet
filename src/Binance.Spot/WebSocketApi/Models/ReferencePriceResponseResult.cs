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

public sealed class ReferencePriceResponseResult
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("referencePrice")]
    public string? ReferencePrice { get; set; }

    /// <summary>Timestamp when the reference price was valid</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; set; }

    [JsonPropertyName("code")]
    public long? Code { get; set; }

    [JsonPropertyName("msg")]
    public string? Msg { get; set; }
}
