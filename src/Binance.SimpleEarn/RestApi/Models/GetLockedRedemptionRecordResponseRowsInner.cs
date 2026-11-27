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

public sealed class GetLockedRedemptionRecordResponseRowsInner
{
    [JsonPropertyName("positionId")]
    public long? PositionId { get; set; }

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
    /// MATURE for redeem to Spot Wallet, NEW_TRANSFERRED for redeem to Flexible product, AHEAD for early
    /// redemption
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("deliverDate")]
    public long? DeliverDate { get; set; }

    /// <summary>Loss of profit on early redemption</summary>
    [JsonPropertyName("lossAmount")]
    public string? LossAmount { get; set; }

    [JsonPropertyName("isComplete")]
    public bool? IsComplete { get; set; }

    [JsonPropertyName("rewardAsset")]
    public string? RewardAsset { get; set; }

    [JsonPropertyName("rewardAmt")]
    public string? RewardAmt { get; set; }

    [JsonPropertyName("extraRewardAsset")]
    public string? ExtraRewardAsset { get; set; }

    [JsonPropertyName("estExtraRewardAmt")]
    public string? EstExtraRewardAmt { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
