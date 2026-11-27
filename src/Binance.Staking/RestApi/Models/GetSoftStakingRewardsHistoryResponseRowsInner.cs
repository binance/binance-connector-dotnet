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

public sealed class GetSoftStakingRewardsHistoryResponseRowsInner
{
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    [JsonPropertyName("rewards")]
    public string? Rewards { get; set; }

    [JsonPropertyName("rewardAsset")]
    public string? RewardAsset { get; set; }

    [JsonPropertyName("avgAmount")]
    public string? AvgAmount { get; set; }

    [JsonPropertyName("time")]
    public long? Time { get; set; }
}
