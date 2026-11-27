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

public sealed class GetEthRedemptionHistoryResponseRowsInner
{
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    [JsonPropertyName("arrivalTime")]
    public long? ArrivalTime { get; set; }

    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    [JsonPropertyName("distributeAsset")]
    public string? DistributeAsset { get; set; }

    [JsonPropertyName("distributeAmount")]
    public string? DistributeAmount { get; set; }

    [JsonPropertyName("conversionRatio")]
    public string? ConversionRatio { get; set; }

    /// <summary>PENDING,SUCCESS,FAILED</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
