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

public sealed class GetFlexibleRewardsHistoryResponseRowsInner
{
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    [JsonPropertyName("rewards")]
    public string? Rewards { get; set; }

    [JsonPropertyName("projectId")]
    public string? ProjectId { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("time")]
    public long? Time { get; set; }
}
