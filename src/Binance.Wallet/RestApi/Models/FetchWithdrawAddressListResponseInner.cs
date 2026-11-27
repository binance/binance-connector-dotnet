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

public sealed class FetchWithdrawAddressListResponseInner
{
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("addressTag")]
    public string? AddressTag { get; set; }

    [JsonPropertyName("coin")]
    public string? Coin { get; set; }

    /// <summary>is a user-defined name</summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("network")]
    public string? Network { get; set; }

    /// <summary>
    /// if originType != 'others', this value is blank, otherwise the origin is manually filled in by the
    /// user
    /// </summary>
    [JsonPropertyName("origin")]
    public string? Origin { get; set; }

    /// <summary>
    /// Address source type, including but not limited to: type Exchange Address: Binance, CoinBase, HTX,
    /// Bitfinex, OKX, Bithumb, Kraken, Kucoin, Gemini, Bitget, Bybit, Upbit, Gate.io; type Wallet Address:
    /// Binance Web3 Wallet, Trust Wallet, MetaMask, Rabby Wallet, Phantom, OKX Web 3 Wallet, Coinbase
    /// Wallet, Bitget Wallet; type Others: others(multilanguage support)
    /// </summary>
    [JsonPropertyName("originType")]
    public string? OriginType { get; set; }

    /// <summary>Is it whitelisted</summary>
    [JsonPropertyName("whiteStatus")]
    public bool? WhiteStatus { get; set; }
}
