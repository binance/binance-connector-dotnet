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

public sealed class AcquiringCoinnameResponseDataInner
{
    /// <summary>Currency name</summary>
    [JsonPropertyName("coinName")]
    public string? CoinName { get; set; }

    /// <summary>ID</summary>
    [JsonPropertyName("coinId")]
    public long? CoinId { get; set; }

    /// <summary>Sort</summary>
    [JsonPropertyName("poolIndex")]
    public long? PoolIndex { get; set; }

    /// <summary>Algorithm</summary>
    [JsonPropertyName("algoId")]
    public long? AlgoId { get; set; }

    /// <summary>Name of algorithm</summary>
    [JsonPropertyName("algoName")]
    public string? AlgoName { get; set; }
}
