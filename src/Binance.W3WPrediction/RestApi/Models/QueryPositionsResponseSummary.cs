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

namespace Binance.W3WPrediction.RestApi;

public sealed class QueryPositionsResponseSummary
{
    [JsonPropertyName("totalValue")]
    public string? TotalValue { get; set; }

    [JsonPropertyName("positionValue")]
    public string? PositionValue { get; set; }

    [JsonPropertyName("walletBalance")]
    public string? WalletBalance { get; set; }

    [JsonPropertyName("totalClaimableAmount")]
    public string? TotalClaimableAmount { get; set; }

    [JsonPropertyName("todayRealizedPnl")]
    public string? TodayRealizedPnl { get; set; }

    [JsonPropertyName("todayRealizedPnlPercent")]
    public string? TodayRealizedPnlPercent { get; set; }

    [JsonPropertyName("todayTotalCost")]
    public string? TodayTotalCost { get; set; }
}
