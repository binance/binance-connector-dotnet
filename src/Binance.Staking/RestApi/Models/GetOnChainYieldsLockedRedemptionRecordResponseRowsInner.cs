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

public sealed class GetOnChainYieldsLockedRedemptionRecordResponseRowsInner
{
    [JsonPropertyName("positionId")]
    public string? PositionId { get; set; }

    [JsonPropertyName("redeemId")]
    public long? RedeemId { get; set; }

    [JsonPropertyName("time")]
    public long? Time { get; set; }

    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    [JsonPropertyName("lockPeriod")]
    public string? LockPeriod { get; set; }

    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    [JsonPropertyName("originalAmount")]
    public string? OriginalAmount { get; set; }

    /// <summary>
    /// NORMAL for normal maturity redemption, EARLY for early redemption, CONVERT for redeem to simple earn
    /// flexible
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>Redemption date</summary>
    [JsonPropertyName("deliverDate")]
    public string? DeliverDate { get; set; }

    /// <summary>Loss of profit on early redemption</summary>
    [JsonPropertyName("lossAmount")]
    public string? LossAmount { get; set; }

    [JsonPropertyName("isComplete")]
    public bool? IsComplete { get; set; }

    [JsonPropertyName("rewardAsset")]
    public string? RewardAsset { get; set; }

    [JsonPropertyName("rewardAmt")]
    public string? RewardAmt { get; set; }

    /// <summary>CREATED/PAID</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
