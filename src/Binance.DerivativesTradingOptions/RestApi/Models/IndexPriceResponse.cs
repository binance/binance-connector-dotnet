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

namespace Binance.DerivativesTradingOptions.RestApi;

public sealed class IndexPriceResponse
{
    /// <summary>time</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    /// <summary>index Price</summary>
    [JsonPropertyName("indexPrice")]
    public string? IndexPrice { get; set; }
}
