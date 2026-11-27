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

public sealed class QueryMarginInterestRateHistoryResponseInner
{
    /// <summary>asset.</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>daily Interest Rate.</summary>
    [JsonPropertyName("dailyInterestRate")]
    public string? DailyInterestRate { get; set; }

    /// <summary>timestamp.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; set; }

    /// <summary>vip Level.</summary>
    [JsonPropertyName("vipLevel")]
    public long? VipLevel { get; set; }
}
