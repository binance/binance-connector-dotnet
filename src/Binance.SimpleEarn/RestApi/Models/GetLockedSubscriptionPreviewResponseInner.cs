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

public sealed class GetLockedSubscriptionPreviewResponseInner
{
    [JsonPropertyName("rewardAsset")]
    public string? RewardAsset { get; set; }

    [JsonPropertyName("totalRewardAmt")]
    public string? TotalRewardAmt { get; set; }

    [JsonPropertyName("extraRewardAsset")]
    public string? ExtraRewardAsset { get; set; }

    [JsonPropertyName("estTotalExtraRewardAmt")]
    public string? EstTotalExtraRewardAmt { get; set; }

    [JsonPropertyName("boostRewardAsset")]
    public string? BoostRewardAsset { get; set; }

    [JsonPropertyName("estDailyRewardAmt")]
    public string? EstDailyRewardAmt { get; set; }

    [JsonPropertyName("nextPay")]
    public string? NextPay { get; set; }

    [JsonPropertyName("nextPayDate")]
    public long? NextPayDate { get; set; }

    [JsonPropertyName("valueDate")]
    public long? ValueDate { get; set; }

    [JsonPropertyName("rewardsEndDate")]
    public long? RewardsEndDate { get; set; }

    [JsonPropertyName("deliverDate")]
    public long? DeliverDate { get; set; }

    [JsonPropertyName("nextSubscriptionDate")]
    public long? NextSubscriptionDate { get; set; }
}
