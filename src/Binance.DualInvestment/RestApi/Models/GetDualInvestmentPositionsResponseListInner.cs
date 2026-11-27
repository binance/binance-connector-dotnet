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

public sealed class GetDualInvestmentPositionsResponseListInner
{
    /// <summary>positionId</summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("investCoin")]
    public string? InvestCoin { get; set; }

    [JsonPropertyName("exercisedCoin")]
    public string? ExercisedCoin { get; set; }

    [JsonPropertyName("subscriptionAmount")]
    public string? SubscriptionAmount { get; set; }

    [JsonPropertyName("strikePrice")]
    public string? StrikePrice { get; set; }

    [JsonPropertyName("duration")]
    public long? Duration { get; set; }

    [JsonPropertyName("settleDate")]
    public long? SettleDate { get; set; }

    /// <summary>
    /// Purchase status. Possible values include PENDING, PURCHASE_SUCCESS, SETTLED, PURCHASE_FAIL,
    /// REFUNDING, REFUND_SUCCESS, and SETTLING.
    /// </summary>
    [JsonPropertyName("purchaseStatus")]
    public string? PurchaseStatus { get; set; }

    [JsonPropertyName("apr")]
    public string? Apr { get; set; }

    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    [JsonPropertyName("purchaseEndTime")]
    public long? PurchaseEndTime { get; set; }

    [JsonPropertyName("optionType")]
    public string? OptionType { get; set; }

    /// <summary>NULL, STANDARD, ADVANCED</summary>
    [JsonPropertyName("autoCompoundPlan")]
    public string? AutoCompoundPlan { get; set; }

    [JsonPropertyName("subscriptionTime")]
    public long? SubscriptionTime { get; set; }
}
