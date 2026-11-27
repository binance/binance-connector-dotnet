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

namespace Binance.DerivativesTradingPortfolioMargin.WebSocketStreams;

public sealed class AccountUpdate
{
    /// <summary>Event business unit. 'UM' for USDS-M futures and 'CM' for COIN-M futures</summary>
    [JsonPropertyName("fs")]
    public string? Fs { get; set; }

    /// <summary>Event Time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Transaction</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>Account Alias, ignore for UM</summary>
    [JsonPropertyName("i")]
    public string? I { get; set; }

    [JsonPropertyName("a")]
    public AccountUpdateA? A { get; set; }
}
