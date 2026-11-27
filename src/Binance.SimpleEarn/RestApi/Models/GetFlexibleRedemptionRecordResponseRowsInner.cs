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

public sealed class GetFlexibleRedemptionRecordResponseRowsInner
{
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    [JsonPropertyName("time")]
    public long? Time { get; set; }

    [JsonPropertyName("projectId")]
    public string? ProjectId { get; set; }

    [JsonPropertyName("redeemId")]
    public long? RedeemId { get; set; }

    /// <summary>SPOT, FUNDING</summary>
    [JsonPropertyName("destAccount")]
    public string? DestAccount { get; set; }

    /// <summary>CREATED,PAID,FAILED</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
