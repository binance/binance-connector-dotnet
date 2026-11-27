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

public sealed class QueryMarginAvailableInventoryResponse
{
    /// <summary>
    /// Available inventory per asset. Keys are asset symbols, values are available amounts.
    /// </summary>
    [JsonPropertyName("assets")]
    public Dictionary<string, string>? Assets { get; set; }

    /// <summary>update Time.</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }
}
