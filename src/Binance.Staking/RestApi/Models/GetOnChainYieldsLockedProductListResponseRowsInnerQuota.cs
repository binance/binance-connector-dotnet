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

public sealed class GetOnChainYieldsLockedProductListResponseRowsInnerQuota
{
    /// <summary>Total Personal quota</summary>
    [JsonPropertyName("totalPersonalQuota")]
    public string? TotalPersonalQuota { get; set; }

    /// <summary>Minimum amount per order</summary>
    [JsonPropertyName("minimum")]
    public string? Minimum { get; set; }
}
