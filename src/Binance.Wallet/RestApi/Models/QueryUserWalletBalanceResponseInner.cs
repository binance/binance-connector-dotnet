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

public sealed class QueryUserWalletBalanceResponseInner
{
    [JsonPropertyName("activate")]
    public bool? Activate { get; set; }

    [JsonPropertyName("balance")]
    public string? Balance { get; set; }

    [JsonPropertyName("walletName")]
    public string? WalletName { get; set; }

    /// <summary>
    /// Per-asset balance detail for this wallet. Only present when needBalanceDetail=true is passed;
    /// omitted entirely otherwise.
    /// </summary>
    [JsonPropertyName("assetBalances")]
    public List<QueryUserWalletBalanceResponseInnerAssetBalancesInner>? AssetBalances { get; set; }
}
