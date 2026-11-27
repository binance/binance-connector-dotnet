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

public sealed class GetOnChainYieldsLockedProductListResponseRowsInnerDetail
{
    /// <summary>Lock up asset</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>Earn Asset</summary>
    [JsonPropertyName("rewardAsset")]
    public string? RewardAsset { get; set; }

    /// <summary>Lock period(days)</summary>
    [JsonPropertyName("duration")]
    public long? Duration { get; set; }

    /// <summary>Project supports renewal (auto-subscribe when maturity)</summary>
    [JsonPropertyName("renewable")]
    public bool? Renewable { get; set; }

    [JsonPropertyName("isSoldOut")]
    public bool? IsSoldOut { get; set; }

    /// <summary>0.039 stands for 3.9%</summary>
    [JsonPropertyName("apr")]
    public string? Apr { get; set; }

    /// <summary>PREHEATING,PURCHASING</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("subscriptionStartTime")]
    public long? SubscriptionStartTime { get; set; }

    /// <summary>Whether redemption to simple earn flexible is supported.</summary>
    [JsonPropertyName("canRedeemToFlex")]
    public bool? CanRedeemToFlex { get; set; }
}
