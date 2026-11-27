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

namespace Binance.Spot.WebSocketStreams;

public sealed class AllMarketRollingWindowTickerResponseInner
{
    /// <summary>Event type</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>Event time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>Price change</summary>
    [JsonPropertyName("p")]
    public string? P { get; set; }

    /// <summary>Price change percent</summary>
    [JsonPropertyName("P")]
    public string? PUppercase { get; set; }

    /// <summary>Open price</summary>
    [JsonPropertyName("o")]
    public string? O { get; set; }

    /// <summary>High price</summary>
    [JsonPropertyName("h")]
    public string? H { get; set; }

    /// <summary>Low price</summary>
    [JsonPropertyName("l")]
    public string? L { get; set; }

    /// <summary>Last price</summary>
    [JsonPropertyName("c")]
    public string? C { get; set; }

    /// <summary>Weighted average price</summary>
    [JsonPropertyName("w")]
    public string? W { get; set; }

    /// <summary>Total traded base asset volume</summary>
    [JsonPropertyName("v")]
    public string? V { get; set; }

    /// <summary>Total traded quote asset volume</summary>
    [JsonPropertyName("q")]
    public string? Q { get; set; }

    /// <summary>Statistics open time</summary>
    [JsonPropertyName("O")]
    public long? OUppercase { get; set; }

    /// <summary>Statistics close time</summary>
    [JsonPropertyName("C")]
    public long? CUppercase { get; set; }

    /// <summary>First trade ID</summary>
    [JsonPropertyName("F")]
    public long? FUppercase { get; set; }

    /// <summary>Last trade Id</summary>
    [JsonPropertyName("L")]
    public long? LUppercase { get; set; }

    /// <summary>Total number of trades</summary>
    [JsonPropertyName("n")]
    public long? N { get; set; }
}
