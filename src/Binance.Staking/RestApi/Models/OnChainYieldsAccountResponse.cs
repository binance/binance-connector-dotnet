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

public sealed class OnChainYieldsAccountResponse
{
    [JsonPropertyName("totalAmountInBTC")]
    public string? TotalAmountInBTC { get; set; }

    [JsonPropertyName("totalAmountInUSDT")]
    public string? TotalAmountInUSDT { get; set; }

    [JsonPropertyName("totalFlexibleAmountInBTC")]
    public string? TotalFlexibleAmountInBTC { get; set; }

    [JsonPropertyName("totalFlexibleAmountInUSDT")]
    public string? TotalFlexibleAmountInUSDT { get; set; }

    [JsonPropertyName("totalLockedInBTC")]
    public string? TotalLockedInBTC { get; set; }

    [JsonPropertyName("totalLockedInUSDT")]
    public string? TotalLockedInUSDT { get; set; }
}
