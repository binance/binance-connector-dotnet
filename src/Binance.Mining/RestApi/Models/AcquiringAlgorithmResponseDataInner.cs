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

namespace Binance.Mining.RestApi;

public sealed class AcquiringAlgorithmResponseDataInner
{
    /// <summary>Algorithm name</summary>
    [JsonPropertyName("algoName")]
    public string? AlgoName { get; set; }

    /// <summary>Algorithm ID</summary>
    [JsonPropertyName("algoId")]
    public long? AlgoId { get; set; }

    /// <summary>Sequence</summary>
    [JsonPropertyName("poolIndex")]
    public long? PoolIndex { get; set; }

    /// <summary>Unit</summary>
    [JsonPropertyName("unit")]
    public string? Unit { get; set; }
}
