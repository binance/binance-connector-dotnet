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

namespace Binance.Spot.RestApi;

public sealed class ReferencePriceCalculationResponse
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Either ARITHMETIC_MEAN or EXTERNAL.</summary>
    [JsonPropertyName("calculationType")]
    public string? CalculationType { get; set; }

    /// <summary>Present when calculationType is ARITHMETIC_MEAN.</summary>
    [JsonPropertyName("bucketCount")]
    public long? BucketCount { get; set; }

    /// <summary>Present when calculationType is ARITHMETIC_MEAN.</summary>
    [JsonPropertyName("bucketWidthMs")]
    public long? BucketWidthMs { get; set; }

    /// <summary>Present when calculationType is EXTERNAL.</summary>
    [JsonPropertyName("externalCalculationId")]
    public long? ExternalCalculationId { get; set; }
}
