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

public sealed class GetFundingRateInfoResponseInner
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("adjustedFundingRateCap")]
    public string? AdjustedFundingRateCap { get; set; }

    [JsonPropertyName("adjustedFundingRateFloor")]
    public string? AdjustedFundingRateFloor { get; set; }

    [JsonPropertyName("fundingIntervalHours")]
    public long? FundingIntervalHours { get; set; }

    /// <summary>ingore</summary>
    [JsonPropertyName("disclaimer")]
    public bool? Disclaimer { get; set; }
}
