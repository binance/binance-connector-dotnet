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

namespace Binance.MarginTrading.RestApi;

public sealed class QueryMarginPriceindexResponse
{
    /// <summary>calc Time.</summary>
    [JsonPropertyName("calcTime")]
    public long? CalcTime { get; set; }

    /// <summary>price.</summary>
    [JsonPropertyName("price")]
    public string? Price { get; set; }

    /// <summary>symbol.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }
}
