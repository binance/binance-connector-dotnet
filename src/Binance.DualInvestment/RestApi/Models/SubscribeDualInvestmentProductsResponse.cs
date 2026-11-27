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

namespace Binance.DualInvestment.RestApi;

public sealed class SubscribeDualInvestmentProductsResponse
{
    [JsonPropertyName("positionId")]
    public long? PositionId { get; set; }

    [JsonPropertyName("investCoin")]
    public string? InvestCoin { get; set; }

    [JsonPropertyName("exercisedCoin")]
    public string? ExercisedCoin { get; set; }

    [JsonPropertyName("subscriptionAmount")]
    public string? SubscriptionAmount { get; set; }

    [JsonPropertyName("duration")]
    public long? Duration { get; set; }

    /// <summary>STANDARD, ADVANCED, this field won't display when autocompound is set to None</summary>
    [JsonPropertyName("autoCompoundPlan")]
    public string? AutoCompoundPlan { get; set; }

    [JsonPropertyName("strikePrice")]
    public string? StrikePrice { get; set; }

    [JsonPropertyName("settleDate")]
    public long? SettleDate { get; set; }

    [JsonPropertyName("purchaseStatus")]
    public string? PurchaseStatus { get; set; }

    [JsonPropertyName("apr")]
    public string? Apr { get; set; }

    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    [JsonPropertyName("purchaseTime")]
    public long? PurchaseTime { get; set; }

    [JsonPropertyName("optionType")]
    public string? OptionType { get; set; }
}
