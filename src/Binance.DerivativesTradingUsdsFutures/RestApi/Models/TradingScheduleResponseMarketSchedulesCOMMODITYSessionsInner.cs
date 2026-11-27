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

public sealed class TradingScheduleResponseMarketSchedulesCOMMODITYSessionsInner
{
    [JsonPropertyName("startTime")]
    public long? StartTime { get; set; }

    [JsonPropertyName("endTime")]
    public long? EndTime { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}
