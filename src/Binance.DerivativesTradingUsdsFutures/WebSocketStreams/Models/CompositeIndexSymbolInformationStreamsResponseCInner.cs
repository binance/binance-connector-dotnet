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

namespace Binance.DerivativesTradingUsdsFutures.WebSocketStreams;

public sealed class CompositeIndexSymbolInformationStreamsResponseCInner
{
    /// <summary>Base asset</summary>
    [JsonPropertyName("b")]
    public string? B { get; set; }

    /// <summary>Quote asset</summary>
    [JsonPropertyName("q")]
    public string? Q { get; set; }

    /// <summary>Weight in quantity</summary>
    [JsonPropertyName("w")]
    public string? W { get; set; }

    /// <summary>Weight in percentage</summary>
    [JsonPropertyName("W")]
    public string? WUppercase { get; set; }

    /// <summary>Index price</summary>
    [JsonPropertyName("i")]
    public string? I { get; set; }
}
