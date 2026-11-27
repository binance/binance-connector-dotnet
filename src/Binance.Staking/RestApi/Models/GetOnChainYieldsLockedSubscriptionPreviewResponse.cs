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

public sealed class GetOnChainYieldsLockedSubscriptionPreviewResponse
{
    /// <summary>Earned asset</summary>
    [JsonPropertyName("rewardAsset")]
    public string? RewardAsset { get; set; }

    /// <summary>Earned amount total in locked period</summary>
    [JsonPropertyName("totalRewardAmt")]
    public string? TotalRewardAmt { get; set; }

    /// <summary>Next estimated rewards payment</summary>
    [JsonPropertyName("nextPay")]
    public string? NextPay { get; set; }

    /// <summary>Next rewards payment date</summary>
    [JsonPropertyName("nextPayDate")]
    public string? NextPayDate { get; set; }

    /// <summary>Rewards payment date</summary>
    [JsonPropertyName("rewardsPayDate")]
    public string? RewardsPayDate { get; set; }

    [JsonPropertyName("valueDate")]
    public string? ValueDate { get; set; }

    /// <summary>Rewards accrual end date</summary>
    [JsonPropertyName("rewardsEndDate")]
    public string? RewardsEndDate { get; set; }

    /// <summary>Redemption arrival time(if auto-subscribe is true, not response this one)</summary>
    [JsonPropertyName("deliverDate")]
    public string? DeliverDate { get; set; }

    /// <summary>Response if autoSubscribe is true</summary>
    [JsonPropertyName("nextSubscriptionDate")]
    public string? NextSubscriptionDate { get; set; }
}
