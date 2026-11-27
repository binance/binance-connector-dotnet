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

public sealed class AccountInformationResponseAssetsInner
{
    /// <summary>asset name</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>total wallet balance</summary>
    [JsonPropertyName("walletBalance")]
    public string? WalletBalance { get; set; }

    /// <summary>unrealized profit or loss</summary>
    [JsonPropertyName("unrealizedProfit")]
    public string? UnrealizedProfit { get; set; }

    /// <summary>margin balance</summary>
    [JsonPropertyName("marginBalance")]
    public string? MarginBalance { get; set; }

    /// <summary>maintenance margin</summary>
    [JsonPropertyName("maintMargin")]
    public string? MaintMargin { get; set; }

    /// <summary>total intial margin required with the latest mark price</summary>
    [JsonPropertyName("initialMargin")]
    public string? InitialMargin { get; set; }

    /// <summary>positions margin required with the latest mark price</summary>
    [JsonPropertyName("positionInitialMargin")]
    public string? PositionInitialMargin { get; set; }

    /// <summary>open orders intial margin required with the latest mark price</summary>
    [JsonPropertyName("openOrderInitialMargin")]
    public string? OpenOrderInitialMargin { get; set; }

    /// <summary>maximum amount for transfer out</summary>
    [JsonPropertyName("maxWithdrawAmount")]
    public string? MaxWithdrawAmount { get; set; }

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
