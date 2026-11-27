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

namespace Binance.DerivativesTradingUsdsFutures.WebSocketApi;

public sealed class AccountInformationV2ResponseResultAssetsInner
{
    /// <summary>asset name</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>wallet balance</summary>
    [JsonPropertyName("walletBalance")]
    public string? WalletBalance { get; set; }

    /// <summary>unrealized profit</summary>
    [JsonPropertyName("unrealizedProfit")]
    public string? UnrealizedProfit { get; set; }

    /// <summary>margin balance</summary>
    [JsonPropertyName("marginBalance")]
    public string? MarginBalance { get; set; }

    /// <summary>maintenance margin required</summary>
    [JsonPropertyName("maintMargin")]
    public string? MaintMargin { get; set; }

    /// <summary>total initial margin required with current mark price</summary>
    [JsonPropertyName("initialMargin")]
    public string? InitialMargin { get; set; }

    /// <summary>initial margin required for positions with current mark price</summary>
    [JsonPropertyName("positionInitialMargin")]
    public string? PositionInitialMargin { get; set; }

    /// <summary>initial margin required for open orders with current mark price</summary>
    [JsonPropertyName("openOrderInitialMargin")]
    public string? OpenOrderInitialMargin { get; set; }

    /// <summary>crossed wallet balance</summary>
    [JsonPropertyName("crossWalletBalance")]
    public string? CrossWalletBalance { get; set; }

    /// <summary>unrealized profit of crossed positions</summary>
    [JsonPropertyName("crossUnPnl")]
    public string? CrossUnPnl { get; set; }

    /// <summary>available balance, only for USDT asset</summary>
    [JsonPropertyName("availableBalance")]
    public string? AvailableBalance { get; set; }

    /// <summary>maximum amount for transfer out, only for USDT asset</summary>
    [JsonPropertyName("maxWithdrawAmount")]
    public string? MaxWithdrawAmount { get; set; }

    /// <summary>whether the asset can be used as margin in Multi-Assets mode</summary>
    [JsonPropertyName("marginAvailable")]
    public bool? MarginAvailable { get; set; }

    /// <summary>last update time</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }
}
