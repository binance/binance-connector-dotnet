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

namespace Binance.SimpleEarn.RestApi;

public sealed class GetFlexibleProductPositionResponseRowsInner
{
    [JsonPropertyName("totalAmount")]
    public string? TotalAmount { get; set; }

    [JsonPropertyName("tierAnnualPercentageRate")]
    public GetFlexibleProductPositionResponseRowsInnerTierAnnualPercentageRate? TierAnnualPercentageRate { get; set; }

    [JsonPropertyName("latestAnnualPercentageRate")]
    public string? LatestAnnualPercentageRate { get; set; }

    [JsonPropertyName("yesterdayAirdropPercentageRate")]
    public string? YesterdayAirdropPercentageRate { get; set; }

    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    [JsonPropertyName("airDropAsset")]
    public string? AirDropAsset { get; set; }

    [JsonPropertyName("canRedeem")]
    public bool? CanRedeem { get; set; }

    [JsonPropertyName("collateralAmount")]
    public string? CollateralAmount { get; set; }

    [JsonPropertyName("productId")]
    public string? ProductId { get; set; }

    [JsonPropertyName("yesterdayRealTimeRewards")]
    public string? YesterdayRealTimeRewards { get; set; }

    [JsonPropertyName("cumulativeBonusRewards")]
    public string? CumulativeBonusRewards { get; set; }

    [JsonPropertyName("cumulativeRealTimeRewards")]
    public string? CumulativeRealTimeRewards { get; set; }

    [JsonPropertyName("cumulativeTotalRewards")]
    public string? CumulativeTotalRewards { get; set; }

    [JsonPropertyName("autoSubscribe")]
    public bool? AutoSubscribe { get; set; }
}
