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

public sealed class DepositHistoryV2ResponseInner
{
    [JsonPropertyName("depositId")]
    public string? DepositId { get; set; }

    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    [JsonPropertyName("network")]
    public string? Network { get; set; }

    [JsonPropertyName("coin")]
    public string? Coin { get; set; }

    [JsonPropertyName("depositStatus")]
    public long? DepositStatus { get; set; }

    /// <summary>0:PASS,2:REJECTED,3:PENDING,-1:FAILED</summary>
    [JsonPropertyName("travelRuleReqStatus")]
    public long? TravelRuleReqStatus { get; set; }

    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("addressTag")]
    public string? AddressTag { get; set; }

    [JsonPropertyName("txId")]
    public string? TxId { get; set; }

    [JsonPropertyName("transferType")]
    public long? TransferType { get; set; }

    [JsonPropertyName("confirmTimes")]
    public string? ConfirmTimes { get; set; }

    /// <summary>
    /// true: This deposit require user to answer questionnaire to get it credited, false: This deposit
    /// doesn't require user to answer questionnaire as it's already completed or information has been
    /// verified
    /// </summary>
    [JsonPropertyName("requireQuestionnaire")]
    public bool? RequireQuestionnaire { get; set; }

    [JsonPropertyName("questionnaire")]
    public DepositHistoryV2ResponseInnerQuestionnaire? Questionnaire { get; set; }

    [JsonPropertyName("insertTime")]
    public long? InsertTime { get; set; }
}
