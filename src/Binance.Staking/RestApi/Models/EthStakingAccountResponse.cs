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

namespace Binance.Staking.RestApi;

public sealed class EthStakingAccountResponse
{
    [JsonPropertyName("holdingInETH")]
    public string? HoldingInETH { get; set; }

    [JsonPropertyName("holdings")]
    public EthStakingAccountResponseHoldings? Holdings { get; set; }

    [JsonPropertyName("thirtyDaysProfitInETH")]
    public string? ThirtyDaysProfitInETH { get; set; }

    [JsonPropertyName("profit")]
    public EthStakingAccountResponseProfit? Profit { get; set; }
}
