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

namespace Binance.Spot.WebSocketApi;

public sealed class ReferencePriceCalculationResponseResult
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("calculationType")]
    public string? CalculationType { get; set; }

    /// <summary>
    /// If the reference price is being calculated by the matching engine as an arithmetic mean
    /// </summary>
    [JsonPropertyName("bucketCount")]
    public long? BucketCount { get; set; }

    /// <summary>
    /// If the reference price is being calculated by the matching engine as an arithmetic mean
    /// </summary>
    [JsonPropertyName("bucketWidthMs")]
    public long? BucketWidthMs { get; set; }

    /// <summary>If the reference price is being calculated outside the matching engine</summary>
    [JsonPropertyName("externalCalculationId")]
    public long? ExternalCalculationId { get; set; }
}
