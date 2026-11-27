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

public sealed class HistoricalExerciseRecordsResponseInner
{
    /// <summary>symbol</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>strike price</summary>
    [JsonPropertyName("strikePrice")]
    public string? StrikePrice { get; set; }

    /// <summary>real strike price</summary>
    [JsonPropertyName("realStrikePrice")]
    public string? RealStrikePrice { get; set; }

    /// <summary>Exercise time</summary>
    [JsonPropertyName("expiryDate")]
    public long? ExpiryDate { get; set; }

    /// <summary>strike result</summary>
    [JsonPropertyName("strikeResult")]
    public string? StrikeResult { get; set; }
}
