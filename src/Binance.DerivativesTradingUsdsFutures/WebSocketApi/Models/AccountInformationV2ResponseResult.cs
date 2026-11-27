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

public sealed class AccountInformationV2ResponseResult
{
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

    /// <summary>For assets that are quote assets, USDT/USDC/BTC</summary>
    [JsonPropertyName("assets")]
    public List<AccountInformationV2ResponseResultAssetsInner>? Assets { get; set; }

    /// <summary>positions of all symbols user had position/ open orders are returned</summary>
    [JsonPropertyName("positions")]
    public List<AccountInformationV2ResponseResultPositionsInner>? Positions { get; set; }
}
