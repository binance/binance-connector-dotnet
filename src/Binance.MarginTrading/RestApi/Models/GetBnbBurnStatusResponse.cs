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

namespace Binance.MarginTrading.RestApi;

public sealed class GetBnbBurnStatusResponse
{
    /// <summary>spot BNBBurn.</summary>
    [JsonPropertyName("spotBNBBurn")]
    public bool? SpotBNBBurn { get; set; }

    /// <summary>interest BNBBurn.</summary>
    [JsonPropertyName("interestBNBBurn")]
    public bool? InterestBNBBurn { get; set; }
}
