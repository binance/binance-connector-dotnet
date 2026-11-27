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

public sealed class WithdrawHistoryResponseInner
{
    /// <summary>Withdrawal id in Binance</summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>withdrawal amount</summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>transaction fee</summary>
    [JsonPropertyName("transactionFee")]
    public string? TransactionFee { get; set; }

    [JsonPropertyName("coin")]
    public string? Coin { get; set; }

    [JsonPropertyName("status")]
    public long? Status { get; set; }

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

    /// <summary>1 for internal transfer, 0 for external transfer</summary>
    [JsonPropertyName("transferType")]
    public long? TransferType { get; set; }

    /// <summary>will not be returned if there's no withdrawOrderId for this withdraw.</summary>
    [JsonPropertyName("withdrawOrderId")]
    public string? WithdrawOrderId { get; set; }

    /// <summary>reason for withdrawal failure</summary>
    [JsonPropertyName("info")]
    public string? Info { get; set; }

    /// <summary>confirm times for withdraw</summary>
    [JsonPropertyName("confirmNo")]
    public long? ConfirmNo { get; set; }

    /// <summary>1: Funding Wallet 0:Spot Wallet</summary>
    [JsonPropertyName("walletType")]
    public long? WalletType { get; set; }

    [JsonPropertyName("txKey")]
    public string? TxKey { get; set; }

    /// <summary>
    /// complete UTC time when user's asset is deduct from withdrawing, only if status = 6(success)
    /// </summary>
    [JsonPropertyName("completeTime")]
    public string? CompleteTime { get; set; }
}
