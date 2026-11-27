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

public sealed class ExchangeInfoResponseSorsInner
{
    [JsonPropertyName("baseAsset")]
    public string? BaseAsset { get; set; }

    [JsonPropertyName("symbols")]
    public List<string>? Symbols { get; set; }
}
