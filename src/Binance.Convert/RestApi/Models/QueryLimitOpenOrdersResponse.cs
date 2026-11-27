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

namespace Binance.Convert.RestApi;

public sealed class QueryLimitOpenOrdersResponse
{
    [JsonPropertyName("list")]
    public List<QueryLimitOpenOrdersResponseListInner>? List { get; set; }
}
