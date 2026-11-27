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

public sealed class FundingWalletResponseInner
{
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>avalible balance</summary>
    [JsonPropertyName("free")]
    public string? Free { get; set; }

    /// <summary>locked asset</summary>
    [JsonPropertyName("locked")]
    public string? Locked { get; set; }

    /// <summary>freeze asset</summary>
    [JsonPropertyName("freeze")]
    public string? Freeze { get; set; }

    [JsonPropertyName("withdrawing")]
    public string? Withdrawing { get; set; }

    [JsonPropertyName("btcValuation")]
    public string? BtcValuation { get; set; }
}
