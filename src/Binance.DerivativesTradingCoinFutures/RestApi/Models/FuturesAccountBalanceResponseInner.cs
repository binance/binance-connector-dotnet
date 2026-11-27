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

namespace Binance.DerivativesTradingCoinFutures.RestApi;

public sealed class FuturesAccountBalanceResponseInner
{
    /// <summary>unique account code</summary>
    [JsonPropertyName("accountAlias")]
    public string? AccountAlias { get; set; }

    /// <summary>asset name</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>Account balance.</summary>
    [JsonPropertyName("balance")]
    public string? Balance { get; set; }

    /// <summary>Available amount for withdrawal.</summary>
    [JsonPropertyName("withdrawAvailable")]
    public string? WithdrawAvailable { get; set; }

    /// <summary>wallet balance for crossed margin</summary>
    [JsonPropertyName("crossWalletBalance")]
    public string? CrossWalletBalance { get; set; }

    /// <summary>total unrealized profit or loss of crossed positions</summary>
    [JsonPropertyName("crossUnPnl")]
    public string? CrossUnPnl { get; set; }

    /// <summary>available margin balance</summary>
    [JsonPropertyName("availableBalance")]
    public string? AvailableBalance { get; set; }

    /// <summary>update time</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }
}
