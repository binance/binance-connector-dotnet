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

namespace Binance.DerivativesTradingOptions.WebSocketStreams;

public sealed class GreekUpdateGInner
{
    /// <summary>Underlying</summary>
    [JsonPropertyName("u")]
    public string? U { get; set; }

    /// <summary>Delta</summary>
    [JsonPropertyName("d")]
    public string? D { get; set; }

    /// <summary>Gamma</summary>
    [JsonPropertyName("g")]
    public string? G { get; set; }

    /// <summary>Theta</summary>
    [JsonPropertyName("t")]
    public string? T { get; set; }

    /// <summary>Vega</summary>
    [JsonPropertyName("v")]
    public string? V { get; set; }
}
