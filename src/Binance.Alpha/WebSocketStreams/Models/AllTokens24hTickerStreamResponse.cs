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

public sealed class AllTokens24hTickerStreamResponse
{
    /// <summary>Event type</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>Per-token 24-hour ticker metrics</summary>
    [JsonPropertyName("d")]
    public List<AllTokens24hTickerStreamResponseDInner>? D { get; set; }
}
