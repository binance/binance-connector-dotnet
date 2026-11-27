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

public sealed class AccountInformationResponseResult
{
    /// <summary>account commission tier</summary>
    [JsonPropertyName("feeTier")]
    public long? FeeTier { get; set; }

    /// <summary>if can trade</summary>
    [JsonPropertyName("canTrade")]
    public bool? CanTrade { get; set; }

    /// <summary>if can transfer in asset</summary>
    [JsonPropertyName("canDeposit")]
    public bool? CanDeposit { get; set; }

    /// <summary>if can transfer out asset</summary>
    [JsonPropertyName("canWithdraw")]
    public bool? CanWithdraw { get; set; }

    /// <summary>reserved property, please ignore</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }

    [JsonPropertyName("multiAssetsMargin")]
    public bool? MultiAssetsMargin { get; set; }

    [JsonPropertyName("tradeGroupId")]
    public long? TradeGroupId { get; set; }

    /// <summary>
    /// total initial margin required with current mark price (useless with isolated positions), only for
    /// USDT asset
    /// </summary>
    [JsonPropertyName("totalInitialMargin")]
    public string? TotalInitialMargin { get; set; }

    /// <summary>the sum of USD value of all cross positions maintenance margin</summary>
    [JsonPropertyName("totalMaintMargin")]
    public string? TotalMaintMargin { get; set; }

    /// <summary>total wallet balance, only for USDT asset</summary>
    [JsonPropertyName("totalWalletBalance")]
    public string? TotalWalletBalance { get; set; }

    /// <summary>total unrealized profit, only for USDT asset</summary>
    [JsonPropertyName("totalUnrealizedProfit")]
    public string? TotalUnrealizedProfit { get; set; }

    /// <summary>total margin balance, only for USDT asset</summary>
    [JsonPropertyName("totalMarginBalance")]
    public string? TotalMarginBalance { get; set; }

    /// <summary>initial margin required for positions with current mark price, only for USDT asset</summary>
    [JsonPropertyName("totalPositionInitialMargin")]
    public string? TotalPositionInitialMargin { get; set; }

    /// <summary>
    /// initial margin required for open orders with current mark price, only for USDT asset
    /// </summary>
    [JsonPropertyName("totalOpenOrderInitialMargin")]
    public string? TotalOpenOrderInitialMargin { get; set; }

    /// <summary>crossed wallet balance, only for USDT asset</summary>
    [JsonPropertyName("totalCrossWalletBalance")]
    public string? TotalCrossWalletBalance { get; set; }

    /// <summary>unrealized profit of crossed positions, only for USDT asset</summary>
    [JsonPropertyName("totalCrossUnPnl")]
    public string? TotalCrossUnPnl { get; set; }

    /// <summary>available balance, only for USDT asset</summary>
    [JsonPropertyName("availableBalance")]
    public string? AvailableBalance { get; set; }

    /// <summary>maximum amount for transfer out, only for USDT asset</summary>
    [JsonPropertyName("maxWithdrawAmount")]
    public string? MaxWithdrawAmount { get; set; }

    [JsonPropertyName("assets")]
    public List<AccountInformationResponseResultAssetsInner>? Assets { get; set; }

    /// <summary>positions of all symbols in the market are returned</summary>
    [JsonPropertyName("positions")]
    public List<AccountInformationResponseResultPositionsInner>? Positions { get; set; }
}
