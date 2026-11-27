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

public sealed class GetFundingRateInfoResponseInner
{
    /// <summary>Trading symbol</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Adjusted funding rate cap.</summary>
    [JsonPropertyName("adjustedFundingRateCap")]
    public string? AdjustedFundingRateCap { get; set; }

    /// <summary>Adjusted funding rate floor.</summary>
    [JsonPropertyName("adjustedFundingRateFloor")]
    public string? AdjustedFundingRateFloor { get; set; }

    /// <summary>Funding interval in hours.</summary>
    [JsonPropertyName("fundingIntervalHours")]
    public long? FundingIntervalHours { get; set; }

    /// <summary>Disclaimer text.</summary>
    [JsonPropertyName("disclaimer")]
    public bool? Disclaimer { get; set; }
}
