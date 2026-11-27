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

namespace Binance.SimpleEarn.RestApi;

public sealed class GetBfusdRewardsHistoryResponseRowsInner
{
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    [JsonPropertyName("rewardAsset")]
    public string? RewardAsset { get; set; }

    [JsonPropertyName("rewardsAmount")]
    public string? RewardsAmount { get; set; }

    [JsonPropertyName("BFUSDPosition")]
    public string? BFUSDPosition { get; set; }

    [JsonPropertyName("annualPercentageRate")]
    public string? AnnualPercentageRate { get; set; }
}
