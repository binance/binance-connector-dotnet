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

public sealed class GetSoftStakingProductListResponseRowsInner
{
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    [JsonPropertyName("minAmount")]
    public string? MinAmount { get; set; }

    [JsonPropertyName("maxCap")]
    public string? MaxCap { get; set; }

    [JsonPropertyName("apr")]
    public string? Apr { get; set; }

    [JsonPropertyName("stakedAmount")]
    public string? StakedAmount { get; set; }

    [JsonPropertyName("totalProfit")]
    public string? TotalProfit { get; set; }
}
