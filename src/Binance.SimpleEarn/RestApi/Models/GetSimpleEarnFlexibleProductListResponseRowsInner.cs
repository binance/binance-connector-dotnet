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

public sealed class GetSimpleEarnFlexibleProductListResponseRowsInner
{
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    [JsonPropertyName("latestAnnualPercentageRate")]
    public string? LatestAnnualPercentageRate { get; set; }

    [JsonPropertyName("tierAnnualPercentageRate")]
    public GetFlexibleProductPositionResponseRowsInnerTierAnnualPercentageRate? TierAnnualPercentageRate { get; set; }

    [JsonPropertyName("airDropPercentageRate")]
    public string? AirDropPercentageRate { get; set; }

    [JsonPropertyName("canPurchase")]
    public bool? CanPurchase { get; set; }

    [JsonPropertyName("canRedeem")]
    public bool? CanRedeem { get; set; }

    [JsonPropertyName("isSoldOut")]
    public bool? IsSoldOut { get; set; }

    [JsonPropertyName("hot")]
    public bool? Hot { get; set; }

    [JsonPropertyName("minPurchaseAmount")]
    public string? MinPurchaseAmount { get; set; }

    [JsonPropertyName("productId")]
    public string? ProductId { get; set; }

    [JsonPropertyName("subscriptionStartTime")]
    public long? SubscriptionStartTime { get; set; }

    /// <summary>PREHEATING,PURCHASING,END</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
