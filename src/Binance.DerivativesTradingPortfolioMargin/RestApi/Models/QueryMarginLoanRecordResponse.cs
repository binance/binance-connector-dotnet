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

public sealed class QueryMarginLoanRecordResponse
{
    /// <summary>Rows.</summary>
    [JsonPropertyName("rows")]
    public List<QueryMarginLoanRecordResponseRowsInner>? Rows { get; set; }

    /// <summary>Total.</summary>
    [JsonPropertyName("total")]
    public long? Total { get; set; }
}
