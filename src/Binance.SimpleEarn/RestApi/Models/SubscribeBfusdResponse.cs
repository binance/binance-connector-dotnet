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

public sealed class SubscribeBfusdResponse
{
    [JsonPropertyName("success")]
    public bool? Success { get; set; }

    [JsonPropertyName("bfusdAmount")]
    public string? BfusdAmount { get; set; }
}
