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

namespace Binance.StockOptions.RestApi;

public sealed class OptionExchangeInfoResponse
{
    /// <summary>Always UTC.</summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    /// <summary>Matched contract.</summary>
    [JsonPropertyName("symbols")]
    public List<OptionExchangeInfoResponseSymbolsInner>? Symbols { get; set; }
}
