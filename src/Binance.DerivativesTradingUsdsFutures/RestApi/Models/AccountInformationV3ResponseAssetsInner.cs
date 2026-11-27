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

/// <summary>For assets that are quote assets, USDT/USDC/BTC</summary>
public sealed class AccountInformationV3ResponseAssetsInner
{
    /// <summary>Asset name.</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>Wallet balance.</summary>
    [JsonPropertyName("walletBalance")]
    public string? WalletBalance { get; set; }

    /// <summary>Unrealized profit.</summary>
    [JsonPropertyName("unrealizedProfit")]
    public string? UnrealizedProfit { get; set; }

    /// <summary>Margin balance.</summary>
    [JsonPropertyName("marginBalance")]
    public string? MarginBalance { get; set; }

    /// <summary>Maintenance margin requirement.</summary>
    [JsonPropertyName("maintMargin")]
    public string? MaintMargin { get; set; }

    /// <summary>Total initial margin requirement.</summary>
    [JsonPropertyName("initialMargin")]
    public string? InitialMargin { get; set; }

    /// <summary>Initial margin required for positions.</summary>
    [JsonPropertyName("positionInitialMargin")]
    public string? PositionInitialMargin { get; set; }

    /// <summary>Initial margin required for open orders.</summary>
    [JsonPropertyName("openOrderInitialMargin")]
    public string? OpenOrderInitialMargin { get; set; }

    /// <summary>Cross wallet balance.</summary>
    [JsonPropertyName("crossWalletBalance")]
    public string? CrossWalletBalance { get; set; }

    /// <summary>Unrealized PnL for cross positions.</summary>
    [JsonPropertyName("crossUnPnl")]
    public string? CrossUnPnl { get; set; }

    /// <summary>Available balance.</summary>
    [JsonPropertyName("availableBalance")]
    public string? AvailableBalance { get; set; }

    /// <summary>Maximum transferable/withdrawable amount.</summary>
    [JsonPropertyName("maxWithdrawAmount")]
    public string? MaxWithdrawAmount { get; set; }

    /// <summary>Last update time in milliseconds.</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }
}
