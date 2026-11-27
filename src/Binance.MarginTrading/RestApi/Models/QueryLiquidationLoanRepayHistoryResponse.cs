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

public sealed class QueryLiquidationLoanRepayHistoryResponse
{
    /// <summary>Total number of repayment records</summary>
    [JsonPropertyName("total")]
    public long? Total { get; set; }

    [JsonPropertyName("rows")]
    public List<QueryLiquidationLoanRepayHistoryResponseRowsInner>? Rows { get; set; }
}
