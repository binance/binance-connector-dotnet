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

namespace Binance.MarginTrading.RestApi;

public sealed class QueryLiabilityCoinLeverageBracketInCrossMarginProModeResponseInnerBracketsInner
{
    /// <summary>leverage.</summary>
    [JsonPropertyName("leverage")]
    public long? Leverage { get; set; }

    /// <summary>max Debt.</summary>
    [JsonPropertyName("maxDebt")]
    public decimal? MaxDebt { get; set; }

    /// <summary>maintenance Margin Rate.</summary>
    [JsonPropertyName("maintenanceMarginRate")]
    public decimal? MaintenanceMarginRate { get; set; }

    /// <summary>initial Margin Rate.</summary>
    [JsonPropertyName("initialMarginRate")]
    public decimal? InitialMarginRate { get; set; }

    /// <summary>fast Num.</summary>
    [JsonPropertyName("fastNum")]
    public decimal? FastNum { get; set; }
}
