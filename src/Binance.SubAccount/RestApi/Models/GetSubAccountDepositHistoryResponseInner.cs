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

namespace Binance.SubAccount.RestApi;

public sealed class GetSubAccountDepositHistoryResponseInner
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    [JsonPropertyName("coin")]
    public string? Coin { get; set; }

    [JsonPropertyName("network")]
    public string? Network { get; set; }

    /// <summary>
    /// Deposit status: 0=pending, 6=credited but cannot withdraw, 7=wrong deposit, 8=waiting user
    /// confirmation, 1=success.
    /// </summary>
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

    [JsonPropertyName("transferType")]
    public long? TransferType { get; set; }

    [JsonPropertyName("confirmTimes")]
    public string? ConfirmTimes { get; set; }

    [JsonPropertyName("unlockConfirm")]
    public long? UnlockConfirm { get; set; }

    [JsonPropertyName("walletType")]
    public long? WalletType { get; set; }
}
