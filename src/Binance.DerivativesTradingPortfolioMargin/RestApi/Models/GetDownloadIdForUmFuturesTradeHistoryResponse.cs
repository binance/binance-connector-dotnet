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

public sealed class GetDownloadIdForUmFuturesTradeHistoryResponse
{
    /// <summary>Average time taken for data download in the past 30 days</summary>
    [JsonPropertyName("avgCostTimestampOfLast30d")]
    public long? AvgCostTimestampOfLast30d { get; set; }

    /// <summary>Download ID.</summary>
    [JsonPropertyName("downloadId")]
    public string? DownloadId { get; set; }
}
