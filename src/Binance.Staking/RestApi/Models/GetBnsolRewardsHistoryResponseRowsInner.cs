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

public sealed class GetBnsolRewardsHistoryResponseRowsInner
{
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    /// <summary>reward amount</summary>
    [JsonPropertyName("amountInSOL")]
    public string? AmountInSOL { get; set; }

    /// <summary>BNSOL holding balance</summary>
    [JsonPropertyName("holding")]
    public string? Holding { get; set; }

    [JsonPropertyName("holdingInSOL")]
    public string? HoldingInSOL { get; set; }

    /// <summary>0.5 means 50% here</summary>
    [JsonPropertyName("annualPercentageRate")]
    public string? AnnualPercentageRate { get; set; }
}
