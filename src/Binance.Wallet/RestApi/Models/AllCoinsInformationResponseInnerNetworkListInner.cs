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

namespace Binance.Wallet.RestApi;

public sealed class AllCoinsInformationResponseInnerNetworkListInner
{
    [JsonPropertyName("network")]
    public string? Network { get; set; }

    [JsonPropertyName("coin")]
    public string? Coin { get; set; }

    [JsonPropertyName("withdrawIntegerMultiple")]
    public string? WithdrawIntegerMultiple { get; set; }

    [JsonPropertyName("isDefault")]
    public bool? IsDefault { get; set; }

    [JsonPropertyName("depositEnable")]
    public bool? DepositEnable { get; set; }

    [JsonPropertyName("withdrawEnable")]
    public bool? WithdrawEnable { get; set; }

    /// <summary>shown only when "depositEnable" is false.</summary>
    [JsonPropertyName("depositDesc")]
    public string? DepositDesc { get; set; }

    /// <summary>shown only when "withdrawEnable" is false.</summary>
    [JsonPropertyName("withdrawDesc")]
    public string? WithdrawDesc { get; set; }

    [JsonPropertyName("specialTips")]
    public string? SpecialTips { get; set; }

    [JsonPropertyName("specialWithdrawTips")]
    public string? SpecialWithdrawTips { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("resetAddressStatus")]
    public bool? ResetAddressStatus { get; set; }

    [JsonPropertyName("addressRegex")]
    public string? AddressRegex { get; set; }

    [JsonPropertyName("memoRegex")]
    public string? MemoRegex { get; set; }

    [JsonPropertyName("withdrawFee")]
    public string? WithdrawFee { get; set; }

    [JsonPropertyName("withdrawMin")]
    public string? WithdrawMin { get; set; }

    [JsonPropertyName("withdrawMax")]
    public string? WithdrawMax { get; set; }

    /// <summary>Minimum internal transfer amount</summary>
    [JsonPropertyName("withdrawInternalMin")]
    public string? WithdrawInternalMin { get; set; }

    [JsonPropertyName("depositDust")]
    public string? DepositDust { get; set; }

    /// <summary>min number for balance confirmation</summary>
    [JsonPropertyName("minConfirm")]
    public long? MinConfirm { get; set; }

    /// <summary>confirmation number for balance unlock</summary>
    [JsonPropertyName("unLockConfirm")]
    public long? UnLockConfirm { get; set; }

    /// <summary>Obsoleted, recomment to use withdrawTag</summary>
    [JsonPropertyName("sameAddress")]
    public bool? SameAddress { get; set; }

    /// <summary>If the coin needs to provide memo to withdraw</summary>
    [JsonPropertyName("withdrawTag")]
    public bool? WithdrawTag { get; set; }

    [JsonPropertyName("estimatedArrivalTime")]
    public long? EstimatedArrivalTime { get; set; }

    [JsonPropertyName("busy")]
    public bool? Busy { get; set; }

    [JsonPropertyName("contractAddressUrl")]
    public string? ContractAddressUrl { get; set; }

    [JsonPropertyName("contractAddress")]
    public string? ContractAddress { get; set; }

    /// <summary>1 1MBABYDOGE = 1000000 BABYDOGE</summary>
    [JsonPropertyName("denomination")]
    public long? Denomination { get; set; }
}
