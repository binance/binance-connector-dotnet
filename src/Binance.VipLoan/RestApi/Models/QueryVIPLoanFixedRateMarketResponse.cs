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

namespace Binance.VipLoan.RestApi;

public sealed class QueryVIPLoanFixedRateMarketResponse
{
    /// <summary>Total number of records</summary>
    [JsonPropertyName("total")]
    public long? Total { get; set; }

    /// <summary>Current page data</summary>
    [JsonPropertyName("rows")]
    public List<QueryVIPLoanFixedRateMarketResponseRowsInner>? Rows { get; set; }
}
