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

public sealed class MarkPriceResponse2Inner
{
    /// <summary>Symbol.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>mark price</summary>
    [JsonPropertyName("markPrice")]
    public string? MarkPrice { get; set; }

    /// <summary>index price</summary>
    [JsonPropertyName("indexPrice")]
    public string? IndexPrice { get; set; }

    /// <summary>Estimated Settle Price, only useful in the last hour before the settlement starts.</summary>
    [JsonPropertyName("estimatedSettlePrice")]
    public string? EstimatedSettlePrice { get; set; }

    /// <summary>This is the Latest funding rate</summary>
    [JsonPropertyName("lastFundingRate")]
    public string? LastFundingRate { get; set; }

    /// <summary>Interest Rate.</summary>
    [JsonPropertyName("interestRate")]
    public string? InterestRate { get; set; }

    /// <summary>Next Funding Time.</summary>
    [JsonPropertyName("nextFundingTime")]
    public long? NextFundingTime { get; set; }

    /// <summary>Time.</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }
}
