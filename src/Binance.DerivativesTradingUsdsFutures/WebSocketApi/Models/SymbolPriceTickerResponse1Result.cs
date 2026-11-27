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

namespace Binance.DerivativesTradingUsdsFutures.WebSocketApi;

public sealed class SymbolPriceTickerResponse1Result
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("price")]
    public string? Price { get; set; }

    /// <summary>Transaction time</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }
}
