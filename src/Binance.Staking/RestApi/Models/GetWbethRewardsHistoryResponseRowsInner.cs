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

public sealed class GetWbethRewardsHistoryResponseRowsInner
{
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    /// <summary>Estimated rewards accrued within WBETH</summary>
    [JsonPropertyName("amountInETH")]
    public string? AmountInETH { get; set; }

    /// <summary>WBETH holding balance</summary>
    [JsonPropertyName("holding")]
    public string? Holding { get; set; }

    [JsonPropertyName("holdingInETH")]
    public string? HoldingInETH { get; set; }

    [JsonPropertyName("annualPercentageRate")]
    public string? AnnualPercentageRate { get; set; }
}
