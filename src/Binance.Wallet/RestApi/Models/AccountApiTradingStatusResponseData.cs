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

namespace Binance.Wallet.RestApi;

public sealed class AccountApiTradingStatusResponseData
{
    /// <summary>API trading function is locked or not</summary>
    [JsonPropertyName("isLocked")]
    public bool? IsLocked { get; set; }

    /// <summary>If API trading function is locked, this is the planned recover time</summary>
    [JsonPropertyName("plannedRecoverTime")]
    public long? PlannedRecoverTime { get; set; }

    [JsonPropertyName("triggerCondition")]
    public AccountApiTradingStatusResponseDataTriggerCondition? TriggerCondition { get; set; }

    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }
}
