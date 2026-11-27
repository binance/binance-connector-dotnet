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

public sealed class GetSimpleEarnLockedProductListResponseRowsInnerDetail
{
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    [JsonPropertyName("rewardAsset")]
    public string? RewardAsset { get; set; }

    [JsonPropertyName("duration")]
    public long? Duration { get; set; }

    [JsonPropertyName("renewable")]
    public bool? Renewable { get; set; }

    [JsonPropertyName("isSoldOut")]
    public bool? IsSoldOut { get; set; }

    [JsonPropertyName("apr")]
    public string? Apr { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("subscriptionStartTime")]
    public long? SubscriptionStartTime { get; set; }

    [JsonPropertyName("extraRewardAsset")]
    public string? ExtraRewardAsset { get; set; }

    [JsonPropertyName("extraRewardAPR")]
    public string? ExtraRewardAPR { get; set; }

    [JsonPropertyName("boostRewardAsset")]
    public string? BoostRewardAsset { get; set; }

    [JsonPropertyName("boostApr")]
    public string? BoostApr { get; set; }

    [JsonPropertyName("boostEndTime")]
    public long? BoostEndTime { get; set; }
}
