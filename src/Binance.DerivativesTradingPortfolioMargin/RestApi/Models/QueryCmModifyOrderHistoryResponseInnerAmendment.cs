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

namespace Binance.DerivativesTradingPortfolioMargin.RestApi;

/// <summary>Amendment.</summary>
public sealed class QueryCmModifyOrderHistoryResponseInnerAmendment
{
    [JsonPropertyName("price")]
    public QueryCmModifyOrderHistoryResponseInnerAmendmentPrice? Price { get; set; }

    [JsonPropertyName("origQty")]
    public QueryCmModifyOrderHistoryResponseInnerAmendmentOrigQty? OrigQty { get; set; }

    /// <summary>
    /// Order modification count, representing the number of times the order has been modified
    /// </summary>
    [JsonPropertyName("count")]
    public long? Count { get; set; }

    /// <summary>user-defined modification identifier, only returned if provided in the request</summary>
    [JsonPropertyName("modifyId")]
    public long? ModifyId { get; set; }
}
