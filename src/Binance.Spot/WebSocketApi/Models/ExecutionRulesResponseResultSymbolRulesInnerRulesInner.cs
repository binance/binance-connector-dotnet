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

namespace Binance.Spot.WebSocketApi;

public sealed class ExecutionRulesResponseResultSymbolRulesInnerRulesInner
{
    [JsonPropertyName("ruleType")]
    public string? RuleType { get; set; }

    [JsonPropertyName("bidLimitMultUp")]
    public string? BidLimitMultUp { get; set; }

    [JsonPropertyName("bidLimitMultDown")]
    public string? BidLimitMultDown { get; set; }

    [JsonPropertyName("askLimitMultUp")]
    public string? AskLimitMultUp { get; set; }

    [JsonPropertyName("askLimitMultDown")]
    public string? AskLimitMultDown { get; set; }
}
