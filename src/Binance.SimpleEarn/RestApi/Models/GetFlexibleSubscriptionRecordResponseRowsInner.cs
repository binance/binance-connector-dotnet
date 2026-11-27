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

namespace Binance.SimpleEarn.RestApi;

public sealed class GetFlexibleSubscriptionRecordResponseRowsInner
{
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    [JsonPropertyName("time")]
    public long? Time { get; set; }

    [JsonPropertyName("purchaseId")]
    public long? PurchaseId { get; set; }

    [JsonPropertyName("productId")]
    public string? ProductId { get; set; }

    /// <summary>
    /// AUTO for auto subscribe, NORMAL for normal subscription, CONVERT for Locked to Flexible, LOAN for
    /// flexible loan collateral, AI for Auto Invest subscribe, TRANSFER for Locked Savings to Flexible
    /// </summary>
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
