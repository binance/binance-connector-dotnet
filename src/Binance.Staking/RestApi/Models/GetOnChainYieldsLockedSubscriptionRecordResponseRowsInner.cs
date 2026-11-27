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

public sealed class GetOnChainYieldsLockedSubscriptionRecordResponseRowsInner
{
    [JsonPropertyName("positionId")]
    public string? PositionId { get; set; }

    [JsonPropertyName("purchaseId")]
    public string? PurchaseId { get; set; }

    [JsonPropertyName("projectId")]
    public string? ProjectId { get; set; }

    [JsonPropertyName("clientId")]
    public string? ClientId { get; set; }

    [JsonPropertyName("time")]
    public long? Time { get; set; }

    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    [JsonPropertyName("lockPeriod")]
    public string? LockPeriod { get; set; }

    /// <summary>NORMAL for normal staking, AUTO for auto-subscription order</summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>SPOT, FUNDING, SPOTANDFUNDING</summary>
    [JsonPropertyName("sourceAccount")]
    public string? SourceAccount { get; set; }

    /// <summary>Display if sourceAccount is SPOTANDFUNDING</summary>
    [JsonPropertyName("amtFromSpot")]
    public string? AmtFromSpot { get; set; }

    /// <summary>Display if sourceAccount is SPOTANDFUNDING</summary>
    [JsonPropertyName("amtFromFunding")]
    public string? AmtFromFunding { get; set; }

    /// <summary>PURCHASING/SUCCESS/FAILED</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
