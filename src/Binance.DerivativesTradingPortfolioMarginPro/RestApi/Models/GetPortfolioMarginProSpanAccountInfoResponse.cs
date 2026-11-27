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

public sealed class GetPortfolioMarginProSpanAccountInfoResponse
{
    /// <summary>uni MMR.</summary>
    [JsonPropertyName("uniMMR")]
    public string? UniMMR { get; set; }

    /// <summary>Account equity, unit：USD</summary>
    [JsonPropertyName("accountEquity")]
    public string? AccountEquity { get; set; }

    /// <summary>Actual equity, unit：USD</summary>
    [JsonPropertyName("actualEquity")]
    public string? ActualEquity { get; set; }

    /// <summary>Account maintenance margin, unit：USD</summary>
    [JsonPropertyName("accountMaintMargin")]
    public string? AccountMaintMargin { get; set; }

    [JsonPropertyName("riskUnitMMList")]
    public List<GetPortfolioMarginProSpanAccountInfoResponseRiskUnitMMListInner>? RiskUnitMMList { get; set; }

    /// <summary>margin MM.</summary>
    [JsonPropertyName("marginMM")]
    public string? MarginMM { get; set; }

    /// <summary>other MM.</summary>
    [JsonPropertyName("otherMM")]
    public string? OtherMM { get; set; }

    /// <summary>
    /// Classic Portfolio margin account status:"NORMAL", "MARGIN_CALL", "SUPPLY_MARGIN", "REDUCE_ONLY",
    /// "ACTIVE_LIQUIDATION", "FORCE_LIQUIDATION", "BANKRUPTED"
    /// </summary>
    [JsonPropertyName("accountStatus")]
    public string? AccountStatus { get; set; }

    /// <summary>PM_1 for classic PM, PM_2 for PM, PM_3 for PM Pro(SPAN)</summary>
    [JsonPropertyName("accountType")]
    public string? AccountType { get; set; }
}
