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

namespace Binance.Stocks.RestApi;

public sealed class ExchangeInfoResponse
{
    /// <summary>Always UTC.</summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    /// <summary>List of tradable symbols with trading rules.</summary>
    [JsonPropertyName("symbols")]
    public List<ExchangeInfoResponseSymbolsInner>? Symbols { get; set; }
}
