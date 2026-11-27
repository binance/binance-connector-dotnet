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

public sealed class GetSoftStakingProductListResponse
{
    [JsonPropertyName("status")]
    public bool? Status { get; set; }

    [JsonPropertyName("totalRewardsUsdt")]
    public string? TotalRewardsUsdt { get; set; }

    [JsonPropertyName("rows")]
    public List<GetSoftStakingProductListResponseRowsInner>? Rows { get; set; }

    [JsonPropertyName("total")]
    public long? Total { get; set; }
}
