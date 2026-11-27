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

public sealed class GetDetailOnSubAccountsFuturesAccountV2ResponseFutureAccountResp
{
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("assets")]
    public List<GetDetailOnSubAccountsFuturesAccountResponseAssetsInner>? Assets { get; set; }

    [JsonPropertyName("canDeposit")]
    public bool? CanDeposit { get; set; }

    [JsonPropertyName("canTrade")]
    public bool? CanTrade { get; set; }

    [JsonPropertyName("canWithdraw")]
    public bool? CanWithdraw { get; set; }

    [JsonPropertyName("feeTier")]
    public long? FeeTier { get; set; }

    [JsonPropertyName("maxWithdrawAmount")]
    public string? MaxWithdrawAmount { get; set; }

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

    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }
}
