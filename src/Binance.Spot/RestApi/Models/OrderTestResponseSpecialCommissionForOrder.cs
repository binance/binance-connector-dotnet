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

namespace Binance.Spot.RestApi;

/// <summary>Special commission rates on trades from the order.</summary>
public sealed class OrderTestResponseSpecialCommissionForOrder
{
    [JsonPropertyName("maker")]
    public string? Maker { get; set; }

    [JsonPropertyName("taker")]
    public string? Taker { get; set; }
}
