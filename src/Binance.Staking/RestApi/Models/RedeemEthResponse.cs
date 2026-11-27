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

namespace Binance.Staking.RestApi;

public sealed class RedeemEthResponse
{
    [JsonPropertyName("success")]
    public bool? Success { get; set; }

    [JsonPropertyName("ethAmount")]
    public string? EthAmount { get; set; }

    [JsonPropertyName("redeemId")]
    public long? RedeemId { get; set; }

    [JsonPropertyName("conversionRatio")]
    public string? ConversionRatio { get; set; }

    [JsonPropertyName("arrivalTime")]
    public long? ArrivalTime { get; set; }
}
