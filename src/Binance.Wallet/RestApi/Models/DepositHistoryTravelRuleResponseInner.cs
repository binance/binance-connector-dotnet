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

public sealed class DepositHistoryTravelRuleResponseInner
{
    [JsonPropertyName("trId")]
    public long? TrId { get; set; }

    [JsonPropertyName("tranId")]
    public long? TranId { get; set; }

    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    [JsonPropertyName("coin")]
    public string? Coin { get; set; }

    [JsonPropertyName("network")]
    public string? Network { get; set; }

    [JsonPropertyName("depositStatus")]
    public long? DepositStatus { get; set; }

    [JsonPropertyName("travelRuleStatus")]
    public long? TravelRuleStatus { get; set; }

    /// <summary>
    /// Overall travel rule verification status (GTR + sanctions screening combined). "PASSED": verification
    /// complete, deposit released. "PENDING": verification in progress, deposit frozen. "REJECTED":
    /// verification failed.
    /// </summary>
    [JsonPropertyName("travelRuleStatusV2")]
    public string? TravelRuleStatusV2 { get; set; }

    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("addressTag")]
    public string? AddressTag { get; set; }

    [JsonPropertyName("txId")]
    public string? TxId { get; set; }

    [JsonPropertyName("insertTime")]
    public long? InsertTime { get; set; }

    /// <summary>Timestamp when the deposit was fully completed/credited (epoch ms).</summary>
    [JsonPropertyName("completeTime")]
    public long? CompleteTime { get; set; }

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
    public string? Questionnaire { get; set; }
}
