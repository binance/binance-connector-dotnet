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

namespace Binance.Alpha.WebSocketStreams;

/// <summary>Kline payload</summary>
public sealed class ContractKlineStreamResponseK
{
    /// <summary>Open price</summary>
    [JsonPropertyName("o")]
    public string? O { get; set; }

    /// <summary>Close price</summary>
    [JsonPropertyName("c")]
    public string? C { get; set; }

    /// <summary>High price</summary>
    [JsonPropertyName("h")]
    public string? H { get; set; }

    /// <summary>Low price</summary>
    [JsonPropertyName("l")]
    public string? L { get; set; }

    /// <summary>Volume</summary>
    [JsonPropertyName("v")]
    public string? V { get; set; }

    /// <summary>Kline open time</summary>
    [JsonPropertyName("ot")]
    public long? Ot { get; set; }

    /// <summary>Kline close time</summary>
    [JsonPropertyName("ct")]
    public long? Ct { get; set; }

    /// <summary>Interval</summary>
    [JsonPropertyName("i")]
    public string? I { get; set; }
}
