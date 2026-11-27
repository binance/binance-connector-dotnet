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

namespace Binance.DerivativesTradingPortfolioMarginPro.RestApi;

public sealed class GetPortfolioMarginProAccountInfoResponse
{
    /// <summary>Classic Portfolio margin account maintenance margin rate</summary>
    [JsonPropertyName("uniMMR")]
    public string? UniMMR { get; set; }

    /// <summary>Account equity, unit：USD</summary>
    [JsonPropertyName("accountEquity")]
    public string? AccountEquity { get; set; }

    /// <summary>Actual equity, unit：USD</summary>
    [JsonPropertyName("actualEquity")]
    public string? ActualEquity { get; set; }

    /// <summary>Classic Portfolio margin account maintenance margin, unit：USD</summary>
    [JsonPropertyName("accountMaintMargin")]
    public string? AccountMaintMargin { get; set; }

    /// <summary>Ignored for PM PRO and PM PRO SPAN</summary>
    [JsonPropertyName("accountInitialMargin")]
    public string? AccountInitialMargin { get; set; }

    /// <summary>Ignored for PM PRO and PM PRO SPAN</summary>
    [JsonPropertyName("totalAvailableBalance")]
    public string? TotalAvailableBalance { get; set; }

    /// <summary>
    /// Classic Portfolio margin account status:"NORMAL", "MARGIN_CALL", "SUPPLY_MARGIN", "REDUCE_ONLY",
    /// "ACTIVE_LIQUIDATION", "FORCE_LIQUIDATION", "BANKRUPTED"
    /// </summary>
    [JsonPropertyName("accountStatus")]
    public string? AccountStatus { get; set; }

    /// <summary>PM_1 for PM PRO, PM_2 for PM, PM_3 for PM PRO SPAN</summary>
    [JsonPropertyName("accountType")]
    public string? AccountType { get; set; }
}
