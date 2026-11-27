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

public sealed class GetLockedProductPositionResponseRowsInner
{
    /// <summary>Locked position ID</summary>
    [JsonPropertyName("positionId")]
    public long? PositionId { get; set; }

    /// <summary>Parent position ID</summary>
    [JsonPropertyName("parentPositionId")]
    public long? ParentPositionId { get; set; }

    /// <summary>Locked project ID</summary>
    [JsonPropertyName("projectId")]
    public string? ProjectId { get; set; }

    /// <summary>Locked asset</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>Locked Amount</summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>Subscription time</summary>
    [JsonPropertyName("purchaseTime")]
    public long? PurchaseTime { get; set; }

    /// <summary>Lock period(days)</summary>
    [JsonPropertyName("duration")]
    public string? Duration { get; set; }

    /// <summary>Accrue days</summary>
    [JsonPropertyName("accrualDays")]
    public string? AccrualDays { get; set; }

    /// <summary>Earned asset</summary>
    [JsonPropertyName("rewardAsset")]
    public string? RewardAsset { get; set; }

    [JsonPropertyName("APY")]
    public string? APY { get; set; }

    /// <summary>Earned amount</summary>
    [JsonPropertyName("rewardAmt")]
    public string? RewardAmt { get; set; }

    /// <summary>Rewards assets of extra staking type</summary>
    [JsonPropertyName("extraRewardAsset")]
    public string? ExtraRewardAsset { get; set; }

    /// <summary>APR of extra staking type</summary>
    [JsonPropertyName("extraRewardAPR")]
    public string? ExtraRewardAPR { get; set; }

    /// <summary>Rewards of extra staking type, distribute when order expires</summary>
    [JsonPropertyName("estExtraRewardAmt")]
    public string? EstExtraRewardAmt { get; set; }

    [JsonPropertyName("boostRewardAsset")]
    public string? BoostRewardAsset { get; set; }

    [JsonPropertyName("boostApr")]
    public string? BoostApr { get; set; }

    [JsonPropertyName("totalBoostRewardAmt")]
    public string? TotalBoostRewardAmt { get; set; }

    /// <summary>Next estimated rewards payment</summary>
    [JsonPropertyName("nextPay")]
    public string? NextPay { get; set; }

    /// <summary>Next rewards payment date</summary>
    [JsonPropertyName("nextPayDate")]
    public long? NextPayDate { get; set; }

    /// <summary>Payment cycle</summary>
    [JsonPropertyName("payPeriod")]
    public string? PayPeriod { get; set; }

    /// <summary>Early redemption amount</summary>
    [JsonPropertyName("redeemAmountEarly")]
    public string? RedeemAmountEarly { get; set; }

    /// <summary>Rewards accrual end date</summary>
    [JsonPropertyName("rewardsEndDate")]
    public long? RewardsEndDate { get; set; }

    /// <summary>Redemption arrival time</summary>
    [JsonPropertyName("deliverDate")]
    public long? DeliverDate { get; set; }

    /// <summary>Redemption interval</summary>
    [JsonPropertyName("redeemPeriod")]
    public string? RedeemPeriod { get; set; }

    /// <summary>Amount under redemption</summary>
    [JsonPropertyName("redeemingAmt")]
    public string? RedeemingAmt { get; set; }

    /// <summary>Redeem to Flexible product or Spot wallet</summary>
    [JsonPropertyName("redeemTo")]
    public string? RedeemTo { get; set; }

    /// <summary>Arrival time of partial redemption amount of order</summary>
    [JsonPropertyName("partialAmtDeliverDate")]
    public long? PartialAmtDeliverDate { get; set; }

    /// <summary>When it is true, early redemption can be operated</summary>
    [JsonPropertyName("canRedeemEarly")]
    public bool? CanRedeemEarly { get; set; }

    /// <summary>When it is true, fast redemption can be operated</summary>
    [JsonPropertyName("canFastRedemption")]
    public bool? CanFastRedemption { get; set; }

    /// <summary>When it is true, auto staking can be operated</summary>
    [JsonPropertyName("autoSubscribe")]
    public bool? AutoSubscribe { get; set; }

    /// <summary>Order type is auto subscribe or normal</summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("canReStake")]
    public bool? CanReStake { get; set; }
}
