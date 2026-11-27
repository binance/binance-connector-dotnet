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

namespace Binance.DerivativesTradingUsdsFutures.WebSocketStreams;

public sealed class AccountUpdateABInner
{
    /// <summary>Asset</summary>
    [JsonPropertyName("a")]
    public string? A { get; set; }

    /// <summary>Wallet Balance</summary>
    [JsonPropertyName("wb")]
    public string? Wb { get; set; }

    /// <summary>Cross Wallet Balance</summary>
    [JsonPropertyName("cw")]
    public string? Cw { get; set; }

    /// <summary>Balance Change except PnL and Commission</summary>
    [JsonPropertyName("bc")]
    public string? Bc { get; set; }
}
