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

public sealed class TokenizedConvertHistoryResponse
{
    /// <summary>Convert history rows on this page. Empty array if nothing matches.</summary>
    [JsonPropertyName("rows")]
    public List<TokenizedConvertHistoryResponseRowsInner>? Rows { get; set; }

    /// <summary>true when more pages exist — pass nextLastId as lastId on the next request.</summary>
    [JsonPropertyName("hasMore")]
    public bool? HasMore { get; set; }

    /// <summary>Pass this value as lastId on the next request to get the following page.</summary>
    [JsonPropertyName("nextLastId")]
    public long? NextLastId { get; set; }
}
