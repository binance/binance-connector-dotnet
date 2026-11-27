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

public sealed class GetFundingRateHistoryOfPerpetualFuturesResponseInner
{
    /// <summary>Trading symbol</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Funding time.</summary>
    [JsonPropertyName("fundingTime")]
    public long? FundingTime { get; set; }

    /// <summary>Funding rate.</summary>
    [JsonPropertyName("fundingRate")]
    public string? FundingRate { get; set; }
}
