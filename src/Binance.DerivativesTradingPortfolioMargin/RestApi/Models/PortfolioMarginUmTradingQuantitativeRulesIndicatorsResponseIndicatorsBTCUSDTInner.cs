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

public sealed class PortfolioMarginUmTradingQuantitativeRulesIndicatorsResponseIndicatorsBTCUSDTInner
{
    /// <summary>Is Locked.</summary>
    [JsonPropertyName("isLocked")]
    public bool? IsLocked { get; set; }

    /// <summary>Planned Recover Time.</summary>
    [JsonPropertyName("plannedRecoverTime")]
    public long? PlannedRecoverTime { get; set; }

    /// <summary>Indicator.</summary>
    [JsonPropertyName("indicator")]
    public string? Indicator { get; set; }

    /// <summary>Value.</summary>
    [JsonPropertyName("value")]
    public decimal? Value { get; set; }

    /// <summary>Trigger Value.</summary>
    [JsonPropertyName("triggerValue")]
    public decimal? TriggerValue { get; set; }
}
