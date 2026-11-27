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

namespace Binance.Algo.RestApi;

public sealed class CancelAlgoOrderFutureAlgoResponse
{
    [JsonPropertyName("algoId")]
    public long? AlgoId { get; set; }

    [JsonPropertyName("success")]
    public bool? Success { get; set; }

    [JsonPropertyName("code")]
    public long? Code { get; set; }

    [JsonPropertyName("msg")]
    public string? Msg { get; set; }
}
