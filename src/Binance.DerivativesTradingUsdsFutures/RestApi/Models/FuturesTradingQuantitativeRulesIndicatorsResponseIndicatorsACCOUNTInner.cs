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

public sealed class FuturesTradingQuantitativeRulesIndicatorsResponseIndicatorsACCOUNTInner
{
    /// <summary>Too many violations under multiple symbols trigger account violation</summary>
    [JsonPropertyName("indicator")]
    public string? Indicator { get; set; }

    /// <summary>Current value</summary>
    [JsonPropertyName("value")]
    public long? Value { get; set; }

    /// <summary>Trigger value</summary>
    [JsonPropertyName("triggerValue")]
    public long? TriggerValue { get; set; }

    /// <summary>Planned Recover Time.</summary>
    [JsonPropertyName("plannedRecoverTime")]
    public long? PlannedRecoverTime { get; set; }

    /// <summary>Is Locked.</summary>
    [JsonPropertyName("isLocked")]
    public bool? IsLocked { get; set; }
}
