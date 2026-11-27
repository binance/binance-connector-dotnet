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

namespace Binance.DerivativesTradingCoinFutures.RestApi;

public sealed class OpenInterestStatisticsResponseInner
{
    /// <summary>Pair</summary>
    [JsonPropertyName("pair")]
    public string? Pair { get; set; }

    /// <summary>Contract type.</summary>
    [JsonPropertyName("contractType")]
    public string? ContractType { get; set; }

    /// <summary>unit: cont</summary>
    [JsonPropertyName("sumOpenInterest")]
    public string? SumOpenInterest { get; set; }

    /// <summary>unit: base asset</summary>
    [JsonPropertyName("sumOpenInterestValue")]
    public string? SumOpenInterestValue { get; set; }

    /// <summary>End time of the period, in milliseconds.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; set; }
}
