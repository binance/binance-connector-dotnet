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

namespace Binance.MarginTrading.WebSocketStreams;

public sealed class ListStatusOInner
{
    /// <summary>Symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>orderId</summary>
    [JsonPropertyName("i")]
    public long? I { get; set; }

    /// <summary>ClientOrderId</summary>
    [JsonPropertyName("c")]
    public string? C { get; set; }
}
