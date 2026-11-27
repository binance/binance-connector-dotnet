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

public sealed class GetRateHistoryResponseRowsInner
{
    [JsonPropertyName("productId")]
    public string? ProductId { get; set; }

    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    [JsonPropertyName("annualPercentageRate")]
    public string? AnnualPercentageRate { get; set; }

    [JsonPropertyName("time")]
    public long? Time { get; set; }
}
