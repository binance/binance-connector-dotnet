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

public sealed class DepositHistoryResponseInner
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    [JsonPropertyName("coin")]
    public string? Coin { get; set; }

    [JsonPropertyName("network")]
    public string? Network { get; set; }

    [JsonPropertyName("status")]
    public long? Status { get; set; }

    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("addressTag")]
    public string? AddressTag { get; set; }

    [JsonPropertyName("txId")]
    public string? TxId { get; set; }

    [JsonPropertyName("insertTime")]
    public long? InsertTime { get; set; }

    /// <summary>represents deposit completion datetime, available for deposits after 6-Mar-2025.</summary>
    [JsonPropertyName("completeTime")]
    public long? CompleteTime { get; set; }

    [JsonPropertyName("transferType")]
    public long? TransferType { get; set; }

    [JsonPropertyName("confirmTimes")]
    public string? ConfirmTimes { get; set; }

    [JsonPropertyName("unlockConfirm")]
    public long? UnlockConfirm { get; set; }

    [JsonPropertyName("walletType")]
    public long? WalletType { get; set; }

    /// <summary>
    /// 0: travel rule not required OR info already provided and funds ready to use, 1: travel rule required
    /// to provide deposit info
    /// </summary>
    [JsonPropertyName("travelRuleStatus")]
    public long? TravelRuleStatus { get; set; }
}
