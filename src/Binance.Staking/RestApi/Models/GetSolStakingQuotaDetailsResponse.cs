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

public sealed class GetSolStakingQuotaDetailsResponse
{
    [JsonPropertyName("leftStakingPersonalQuota")]
    public string? LeftStakingPersonalQuota { get; set; }

    [JsonPropertyName("leftRedemptionPersonalQuota")]
    public string? LeftRedemptionPersonalQuota { get; set; }

    [JsonPropertyName("minStakeAmount")]
    public string? MinStakeAmount { get; set; }

    [JsonPropertyName("minRedeemAmount")]
    public string? MinRedeemAmount { get; set; }

    [JsonPropertyName("redeemPeriod")]
    public long? RedeemPeriod { get; set; }

    [JsonPropertyName("stakeable")]
    public bool? Stakeable { get; set; }

    [JsonPropertyName("redeemable")]
    public bool? Redeemable { get; set; }

    [JsonPropertyName("soldOut")]
    public bool? SoldOut { get; set; }

    [JsonPropertyName("commissionFee")]
    public string? CommissionFee { get; set; }

    [JsonPropertyName("nextEpochTime")]
    public long? NextEpochTime { get; set; }

    [JsonPropertyName("calculating")]
    public bool? Calculating { get; set; }
}
