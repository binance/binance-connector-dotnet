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

namespace Binance.Wallet.RestApi;

public sealed class FetchDepositAddressListWithNetworkResponseInner
{
    /// <summary>coin here means network address space, ETH for all EVM-like network</summary>
    [JsonPropertyName("coin")]
    public string? Coin { get; set; }

    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("tag")]
    public string? Tag { get; set; }

    /// <summary>'isDefault' is 1 means the address is default, same as shown in the app.</summary>
    [JsonPropertyName("isDefault")]
    public long? IsDefault { get; set; }
}
