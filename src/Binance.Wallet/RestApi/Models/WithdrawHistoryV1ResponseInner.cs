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

public sealed class WithdrawHistoryV1ResponseInner
{
    /// <summary>Withdrawal id in Binance</summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>Travel rule record id</summary>
    [JsonPropertyName("trId")]
    public long? TrId { get; set; }

    /// <summary>withdrawal amount</summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>only available for sAPI requests</summary>
    [JsonPropertyName("transactionFee")]
    public string? TransactionFee { get; set; }

    [JsonPropertyName("coin")]
    public string? Coin { get; set; }

    /// <summary>Capital withdrawal status, only available for sAPI requests</summary>
    [JsonPropertyName("withdrawalStatus")]
    public long? WithdrawalStatus { get; set; }

    /// <summary>Travel rule status.</summary>
    [JsonPropertyName("travelRuleStatus")]
    public long? TravelRuleStatus { get; set; }

    [JsonPropertyName("address")]
    public string? Address { get; set; }

    /// <summary>withdrawal transaction id</summary>
    [JsonPropertyName("txId")]
    public string? TxId { get; set; }

    /// <summary>UTC time</summary>
    [JsonPropertyName("applyTime")]
    public string? ApplyTime { get; set; }

    [JsonPropertyName("network")]
    public string? Network { get; set; }

    /// <summary>1 for internal transfer, 0 for external transfer, only available for sAPI requests</summary>
    [JsonPropertyName("transferType")]
    public long? TransferType { get; set; }

    /// <summary>
    /// will not be returned if there's no withdrawOrderId for this withdraw, only available for sAPI
    /// requests
    /// </summary>
    [JsonPropertyName("withdrawOrderId")]
    public string? WithdrawOrderId { get; set; }

    /// <summary>reason for withdrawal failure, only available for sAPI requests</summary>
    [JsonPropertyName("info")]
    public string? Info { get; set; }

    /// <summary>confirm times for withdraw, only available for sAPI requests</summary>
    [JsonPropertyName("confirmNo")]
    public long? ConfirmNo { get; set; }

    /// <summary>1: Funding Wallet 0:Spot Wallet, only available for sAPI requests</summary>
    [JsonPropertyName("walletType")]
    public long? WalletType { get; set; }

    /// <summary>only available for sAPI requests</summary>
    [JsonPropertyName("txKey")]
    public string? TxKey { get; set; }

    /// <summary>The answers of the questionnaire</summary>
    [JsonPropertyName("questionnaire")]
    public string? Questionnaire { get; set; }

    /// <summary>
    /// complete UTC time when user's asset is deduct from withdrawing, only if status = 6(success)
    /// </summary>
    [JsonPropertyName("completeTime")]
    public string? CompleteTime { get; set; }
}
