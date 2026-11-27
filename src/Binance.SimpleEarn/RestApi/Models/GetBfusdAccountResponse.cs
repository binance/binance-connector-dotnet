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

public sealed class GetBfusdAccountResponse
{
    [JsonPropertyName("bfusdAmount")]
    public string? BfusdAmount { get; set; }

    [JsonPropertyName("usdtProfit")]
    public string? UsdtProfit { get; set; }

    [JsonPropertyName("bfusdProfit")]
    public string? BfusdProfit { get; set; }
}
