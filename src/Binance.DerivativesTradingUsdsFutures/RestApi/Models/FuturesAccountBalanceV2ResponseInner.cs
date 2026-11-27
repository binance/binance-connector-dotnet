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

namespace Binance.DerivativesTradingUsdsFutures.RestApi;

public sealed class FuturesAccountBalanceV2ResponseInner
{
    /// <summary>Unique account alias.</summary>
    [JsonPropertyName("accountAlias")]
    public string? AccountAlias { get; set; }

    /// <summary>Asset name.</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>Wallet balance.</summary>
    [JsonPropertyName("balance")]
    public string? Balance { get; set; }

    /// <summary>Cross wallet balance.</summary>
    [JsonPropertyName("crossWalletBalance")]
    public string? CrossWalletBalance { get; set; }

    /// <summary>Unrealized PnL of cross positions.</summary>
    [JsonPropertyName("crossUnPnl")]
    public string? CrossUnPnl { get; set; }

    /// <summary>Available balance.</summary>
    [JsonPropertyName("availableBalance")]
    public string? AvailableBalance { get; set; }

    /// <summary>Maximum transferable/withdrawable amount.</summary>
    [JsonPropertyName("maxWithdrawAmount")]
    public string? MaxWithdrawAmount { get; set; }

    /// <summary>Whether the asset can be used as margin in multi-assets mode.</summary>
    [JsonPropertyName("marginAvailable")]
    public bool? MarginAvailable { get; set; }

    /// <summary>Last update time in milliseconds.</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }
}
