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

public sealed class OpenInterestStatisticsResponseInner
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>total open interest</summary>
    [JsonPropertyName("sumOpenInterest")]
    public string? SumOpenInterest { get; set; }

    /// <summary>total open interest value</summary>
    [JsonPropertyName("sumOpenInterestValue")]
    public string? SumOpenInterestValue { get; set; }

    /// <summary>circulating supply provided by CMC</summary>
    [JsonPropertyName("CMCCirculatingSupply")]
    public string? CMCCirculatingSupply { get; set; }

    /// <summary>End time of the period, in milliseconds.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; set; }
}
