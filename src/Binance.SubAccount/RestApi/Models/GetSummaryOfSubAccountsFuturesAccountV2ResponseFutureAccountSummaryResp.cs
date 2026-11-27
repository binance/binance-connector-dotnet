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

namespace Binance.SubAccount.RestApi;

public sealed class GetSummaryOfSubAccountsFuturesAccountV2ResponseFutureAccountSummaryResp
{
    [JsonPropertyName("totalInitialMargin")]
    public string? TotalInitialMargin { get; set; }

    [JsonPropertyName("totalMaintenanceMargin")]
    public string? TotalMaintenanceMargin { get; set; }

    [JsonPropertyName("totalMarginBalance")]
    public string? TotalMarginBalance { get; set; }

    [JsonPropertyName("totalOpenOrderInitialMargin")]
    public string? TotalOpenOrderInitialMargin { get; set; }

    [JsonPropertyName("totalPositionInitialMargin")]
    public string? TotalPositionInitialMargin { get; set; }

    [JsonPropertyName("totalUnrealizedProfit")]
    public string? TotalUnrealizedProfit { get; set; }

    [JsonPropertyName("totalWalletBalance")]
    public string? TotalWalletBalance { get; set; }

    /// <summary>The sum of BUSD and USDT</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    [JsonPropertyName("subAccountList")]
    public List<GetSummaryOfSubAccountsFuturesAccountResponseSubAccountListInner>? SubAccountList { get; set; }
}
