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

namespace Binance.Alpha.RestApi;

public sealed class AggregatedTradesResponseDataInner
{
    /// <summary>Aggregate trade ID.</summary>
    [JsonPropertyName("a")]
    public long? A { get; set; }

    /// <summary>Trade price.</summary>
    [JsonPropertyName("p")]
    public string? P { get; set; }

    /// <summary>Trade quantity.</summary>
    [JsonPropertyName("q")]
    public string? Q { get; set; }

    /// <summary>First trade ID in the aggregation.</summary>
    [JsonPropertyName("f")]
    public long? F { get; set; }

    /// <summary>Last trade ID in the aggregation.</summary>
    [JsonPropertyName("l")]
    public long? L { get; set; }

    /// <summary>Trade timestamp in milliseconds.</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>Whether buyer is the market maker (deprecated).</summary>
    [JsonPropertyName("m")]
    public bool? M { get; set; }
}
