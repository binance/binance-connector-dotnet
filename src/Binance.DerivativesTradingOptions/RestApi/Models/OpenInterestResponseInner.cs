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

namespace Binance.DerivativesTradingOptions.RestApi;

public sealed class OpenInterestResponseInner
{
    /// <summary>symbol</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>sum Open Interest</summary>
    [JsonPropertyName("sumOpenInterest")]
    public string? SumOpenInterest { get; set; }

    /// <summary>sum Open Interest Usd</summary>
    [JsonPropertyName("sumOpenInterestUsd")]
    public string? SumOpenInterestUsd { get; set; }

    /// <summary>timestamp</summary>
    [JsonPropertyName("timestamp")]
    public string? Timestamp { get; set; }
}
