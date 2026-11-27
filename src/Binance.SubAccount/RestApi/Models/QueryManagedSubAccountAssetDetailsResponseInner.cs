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

namespace Binance.SubAccount.RestApi;

public sealed class QueryManagedSubAccountAssetDetailsResponseInner
{
    [JsonPropertyName("coin")]
    public string? Coin { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("totalBalance")]
    public string? TotalBalance { get; set; }

    [JsonPropertyName("availableBalance")]
    public string? AvailableBalance { get; set; }

    [JsonPropertyName("inOrder")]
    public string? InOrder { get; set; }

    [JsonPropertyName("btcValue")]
    public string? BtcValue { get; set; }
}
