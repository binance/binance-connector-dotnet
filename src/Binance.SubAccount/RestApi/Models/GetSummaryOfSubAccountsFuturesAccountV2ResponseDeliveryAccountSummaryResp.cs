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

public sealed class GetSummaryOfSubAccountsFuturesAccountV2ResponseDeliveryAccountSummaryResp
{
    [JsonPropertyName("totalMarginBalanceOfBTC")]
    public string? TotalMarginBalanceOfBTC { get; set; }

    [JsonPropertyName("totalUnrealizedProfitOfBTC")]
    public string? TotalUnrealizedProfitOfBTC { get; set; }

    [JsonPropertyName("totalWalletBalanceOfBTC")]
    public string? TotalWalletBalanceOfBTC { get; set; }

    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    [JsonPropertyName("subAccountList")]
    public List<GetSummaryOfSubAccountsFuturesAccountV2ResponseDeliveryAccountSummaryRespSubAccountListInner>? SubAccountList { get; set; }
}
