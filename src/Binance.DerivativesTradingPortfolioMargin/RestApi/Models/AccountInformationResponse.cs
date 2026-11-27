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

namespace Binance.DerivativesTradingPortfolioMargin.RestApi;

public sealed class AccountInformationResponse
{
    /// <summary>Portfolio margin account maintenance margin rate</summary>
    [JsonPropertyName("uniMMR")]
    public string? UniMMR { get; set; }

    /// <summary>Account equity, in USD value</summary>
    [JsonPropertyName("accountEquity")]
    public string? AccountEquity { get; set; }

    /// <summary>Account equity without collateral rate, in USD value</summary>
    [JsonPropertyName("actualEquity")]
    public string? ActualEquity { get; set; }

    /// <summary>Account Initial Margin.</summary>
    [JsonPropertyName("accountInitialMargin")]
    public string? AccountInitialMargin { get; set; }

    /// <summary>Portfolio margin account maintenance margin, unit：USD</summary>
    [JsonPropertyName("accountMaintMargin")]
    public string? AccountMaintMargin { get; set; }

    /// <summary>
    /// Portfolio margin account status:"NORMAL", "MARGIN_CALL", "SUPPLY_MARGIN", "REDUCE_ONLY",
    /// "ACTIVE_LIQUIDATION", "FORCE_LIQUIDATION", "BANKRUPTED"
    /// </summary>
    [JsonPropertyName("accountStatus")]
    public string? AccountStatus { get; set; }

    /// <summary>Portfolio margin maximum amount for transfer out in USD</summary>
    [JsonPropertyName("virtualMaxWithdrawAmount")]
    public string? VirtualMaxWithdrawAmount { get; set; }

    /// <summary>Total Available Balance.</summary>
    [JsonPropertyName("totalAvailableBalance")]
    public string? TotalAvailableBalance { get; set; }

    /// <summary>in USD margin open order</summary>
    [JsonPropertyName("totalMarginOpenLoss")]
    public string? TotalMarginOpenLoss { get; set; }

    /// <summary>last update time</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }
}
