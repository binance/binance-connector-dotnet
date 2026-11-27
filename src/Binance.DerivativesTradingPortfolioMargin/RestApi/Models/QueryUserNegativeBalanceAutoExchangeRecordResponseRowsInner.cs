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

public sealed class QueryUserNegativeBalanceAutoExchangeRecordResponseRowsInner
{
    /// <summary>Start Time.</summary>
    [JsonPropertyName("startTime")]
    public long? StartTime { get; set; }

    /// <summary>End Time.</summary>
    [JsonPropertyName("endTime")]
    public long? EndTime { get; set; }

    /// <summary>Details.</summary>
    [JsonPropertyName("details")]
    public List<QueryUserNegativeBalanceAutoExchangeRecordResponseRowsInnerDetailsInner>? Details { get; set; }
}
