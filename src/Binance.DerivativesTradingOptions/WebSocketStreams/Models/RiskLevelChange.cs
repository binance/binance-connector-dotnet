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

namespace Binance.DerivativesTradingOptions.WebSocketStreams;

public sealed class RiskLevelChange
{
    /// <summary>Event Time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>
    /// Risk level. This feature only applies to VIP and Market Maker accounts. Risk level is re-evaluated
    /// on: funds transfer, trade fill, option expiry.
    /// </summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>Margin balance</summary>
    [JsonPropertyName("mb")]
    public string? Mb { get; set; }

    /// <summary>Maintenance margin</summary>
    [JsonPropertyName("mm")]
    public string? Mm { get; set; }
}
