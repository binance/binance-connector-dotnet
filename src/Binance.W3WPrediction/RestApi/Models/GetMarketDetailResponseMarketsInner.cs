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

namespace Binance.W3WPrediction.RestApi;

public sealed class GetMarketDetailResponseMarketsInner
{
    [JsonPropertyName("marketId")]
    public long? MarketId { get; set; }

    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("question")]
    public string? Question { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("conditionId")]
    public string? ConditionId { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("tradingStatus")]
    public string? TradingStatus { get; set; }

    [JsonPropertyName("tradeVolume")]
    public string? TradeVolume { get; set; }

    [JsonPropertyName("liquidity")]
    public string? Liquidity { get; set; }

    /// <summary>
    /// Price precision of the market, in decimal places. The price tick is 10 to the power of minus
    /// decimalPrecision, for example 2 means a tick of 0.01. A limit price that is not on the tick is
    /// truncated down
    /// </summary>
    [JsonPropertyName("decimalPrecision")]
    public long? DecimalPrecision { get; set; }

    [JsonPropertyName("outcomes")]
    public List<GetMarketDetailResponseMarketsInnerOutcomesInner>? Outcomes { get; set; }
}
