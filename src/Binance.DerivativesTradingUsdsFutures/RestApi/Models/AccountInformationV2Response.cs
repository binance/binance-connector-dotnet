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

public sealed class AccountInformationV2Response
{
    /// <summary>Account commission tier.</summary>
    [JsonPropertyName("feeTier")]
    public long? FeeTier { get; set; }

    /// <summary>Whether fee discount is enabled.</summary>
    [JsonPropertyName("feeBurn")]
    public bool? FeeBurn { get; set; }

    /// <summary>Whether trading is enabled.</summary>
    [JsonPropertyName("canTrade")]
    public bool? CanTrade { get; set; }

    /// <summary>Whether transfer-in is enabled.</summary>
    [JsonPropertyName("canDeposit")]
    public bool? CanDeposit { get; set; }

    /// <summary>Whether transfer-out is enabled.</summary>
    [JsonPropertyName("canWithdraw")]
    public bool? CanWithdraw { get; set; }

    /// <summary>Reserved field, ignore.</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }

    /// <summary>Whether multi-assets mode is enabled.</summary>
    [JsonPropertyName("multiAssetsMargin")]
    public bool? MultiAssetsMargin { get; set; }

    /// <summary>Trade group identifier.</summary>
    [JsonPropertyName("tradeGroupId")]
    public long? TradeGroupId { get; set; }

    /// <summary>
    /// Total initial margin requirement. USDT only in single-asset mode; the sum of USD value of all cross
    /// positions/open order initial margin in multi-assets mode.
    /// </summary>
    [JsonPropertyName("totalInitialMargin")]
    public string? TotalInitialMargin { get; set; }

    /// <summary>
    /// Total maintenance margin requirement. USDT only in single-asset mode; the sum of USD value of all
    /// cross positions maintenance margin in multi-assets mode.
    /// </summary>
    [JsonPropertyName("totalMaintMargin")]
    public string? TotalMaintMargin { get; set; }

    /// <summary>
    /// Total wallet balance. USDT only in single-asset mode; USD-denominated in multi-assets mode.
    /// </summary>
    [JsonPropertyName("totalWalletBalance")]
    public string? TotalWalletBalance { get; set; }

    /// <summary>
    /// Total unrealized profit. USDT only in single-asset mode; USD-denominated in multi-assets mode.
    /// </summary>
    [JsonPropertyName("totalUnrealizedProfit")]
    public string? TotalUnrealizedProfit { get; set; }

    /// <summary>
    /// Total margin balance. USDT only in single-asset mode; USD-denominated in multi-assets mode.
    /// </summary>
    [JsonPropertyName("totalMarginBalance")]
    public string? TotalMarginBalance { get; set; }

    /// <summary>
    /// Initial margin required for positions. USDT only in single-asset mode; the sum of USD value of all
    /// cross positions initial margin in multi-assets mode.
    /// </summary>
    [JsonPropertyName("totalPositionInitialMargin")]
    public string? TotalPositionInitialMargin { get; set; }

    /// <summary>
    /// Initial margin required for open orders. USDT only in single-asset mode; USD-denominated in
    /// multi-assets mode.
    /// </summary>
    [JsonPropertyName("totalOpenOrderInitialMargin")]
    public string? TotalOpenOrderInitialMargin { get; set; }

    /// <summary>
    /// Cross wallet balance. USDT only in single-asset mode; USD-denominated in multi-assets mode.
    /// </summary>
    [JsonPropertyName("totalCrossWalletBalance")]
    public string? TotalCrossWalletBalance { get; set; }

    /// <summary>
    /// Unrealized PnL for cross positions. USDT only in single-asset mode; USD-denominated in multi-assets
    /// mode.
    /// </summary>
    [JsonPropertyName("totalCrossUnPnl")]
    public string? TotalCrossUnPnl { get; set; }

    /// <summary>
    /// Available balance. USDT only in single-asset mode; USD-denominated in multi-assets mode.
    /// </summary>
    [JsonPropertyName("availableBalance")]
    public string? AvailableBalance { get; set; }

    /// <summary>
    /// Maximum transferable/withdrawable amount. USDT only in single-asset mode; a maximum virtual USD
    /// amount in multi-assets mode.
    /// </summary>
    [JsonPropertyName("maxWithdrawAmount")]
    public string? MaxWithdrawAmount { get; set; }

    /// <summary>Asset-level account details.</summary>
    [JsonPropertyName("assets")]
    public List<AccountInformationV2ResponseAssetsInner>? Assets { get; set; }

    /// <summary>
    /// Position details for symbols. One-way mode returns BOTH; hedge mode returns LONG/SHORT.
    /// </summary>
    [JsonPropertyName("positions")]
    public List<AccountInformationV2ResponsePositionsInner>? Positions { get; set; }
}
