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

/// <summary>Special commission rates from the order.</summary>
public sealed class AccountCommissionResponseSpecialCommission
{
    [JsonPropertyName("maker")]
    public string? Maker { get; set; }

    [JsonPropertyName("taker")]
    public string? Taker { get; set; }

    [JsonPropertyName("buyer")]
    public string? Buyer { get; set; }

    [JsonPropertyName("seller")]
    public string? Seller { get; set; }
}
