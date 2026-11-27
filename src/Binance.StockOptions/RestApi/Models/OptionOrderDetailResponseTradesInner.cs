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

namespace Binance.StockOptions.RestApi;

public sealed class OptionOrderDetailResponseTradesInner
{
    /// <summary>Execution ID.</summary>
    [JsonPropertyName("executionId")]
    public string? ExecutionId { get; set; }

    /// <summary>Execution time (ms).</summary>
    [JsonPropertyName("executionAt")]
    public long? ExecutionAt { get; set; }

    /// <summary>Fill price (premium per share).</summary>
    [JsonPropertyName("price")]
    public string? Price { get; set; }

    /// <summary>Fill quantity (contracts).</summary>
    [JsonPropertyName("qty")]
    public string? Qty { get; set; }
}
