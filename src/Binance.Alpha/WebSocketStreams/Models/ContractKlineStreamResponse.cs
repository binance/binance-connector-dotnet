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

namespace Binance.Alpha.WebSocketStreams;

public sealed class ContractKlineStreamResponse
{
    /// <summary>Contract address@Chain ID</summary>
    [JsonPropertyName("ca")]
    public string? Ca { get; set; }

    /// <summary>Event type</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    [JsonPropertyName("k")]
    public ContractKlineStreamResponseK? K { get; set; }
}
