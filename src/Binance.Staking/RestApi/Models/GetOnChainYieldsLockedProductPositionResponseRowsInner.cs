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

public sealed class GetOnChainYieldsLockedProductPositionResponseRowsInner
{
    /// <summary>Locked position ID</summary>
    [JsonPropertyName("positionId")]
    public string? PositionId { get; set; }

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
    public string? PurchaseTime { get; set; }

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

    /// <summary>Next estimated rewards payment</summary>
    [JsonPropertyName("nextPay")]
    public string? NextPay { get; set; }

    /// <summary>Next rewards payment date</summary>
    [JsonPropertyName("nextPayDate")]
    public string? NextPayDate { get; set; }

    /// <summary>Payment cycle</summary>
    [JsonPropertyName("payPeriod")]
    public string? PayPeriod { get; set; }

    /// <summary>Rewards payment date when maturity</summary>
    [JsonPropertyName("rewardsPayDate")]
    public string? RewardsPayDate { get; set; }

    /// <summary>Rewards accrual end date</summary>
    [JsonPropertyName("rewardsEndDate")]
    public string? RewardsEndDate { get; set; }

    /// <summary>
    /// Redemption arrival time(include early redemption or natural maturity; if auto-subscribe is on, not
    /// response this one)
    /// </summary>
    [JsonPropertyName("deliverDate")]
    public string? DeliverDate { get; set; }

    /// <summary>Response when auto-subscribe on</summary>
    [JsonPropertyName("nextSubscriptionDate")]
    public string? NextSubscriptionDate { get; set; }

    /// <summary>
    /// Amount under redemption when auto-subsceibe is on but left quota is less than stake amount
    /// </summary>
    [JsonPropertyName("redeemingAmt")]
    public string? RedeemingAmt { get; set; }

    /// <summary>Redeem to simple earn Flexible product or Spot wallet, "SPOT":spot wallet</summary>
    [JsonPropertyName("redeemTo")]
    public string? RedeemTo { get; set; }

    /// <summary>When it is true, early redemption can be operated</summary>
    [JsonPropertyName("canRedeemEarly")]
    public bool? CanRedeemEarly { get; set; }

    /// <summary>When it is true, auto subscribe can be operated</summary>
    [JsonPropertyName("autoSubscribe")]
    public bool? AutoSubscribe { get; set; }

    /// <summary>AUTO：auto-subscribe order； NORMAL：normal-subscribe order</summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// HOLDING,REDEEMING,RENEWING:auto subscribing,NEW_TRANSFERRING:Redeeming to Simple Earn flexible
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
