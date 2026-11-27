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

public sealed class GetDualInvestmentProductListResponseListInner
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("investCoin")]
    public string? InvestCoin { get; set; }

    [JsonPropertyName("exercisedCoin")]
    public string? ExercisedCoin { get; set; }

    [JsonPropertyName("strikePrice")]
    public string? StrikePrice { get; set; }

    [JsonPropertyName("duration")]
    public long? Duration { get; set; }

    [JsonPropertyName("settleDate")]
    public long? SettleDate { get; set; }

    [JsonPropertyName("purchaseDecimal")]
    public long? PurchaseDecimal { get; set; }

    [JsonPropertyName("purchaseEndTime")]
    public long? PurchaseEndTime { get; set; }

    /// <summary>Whether the product can be subscribed to currently</summary>
    [JsonPropertyName("canPurchase")]
    public bool? CanPurchase { get; set; }

    [JsonPropertyName("apr")]
    public string? Apr { get; set; }

    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    [JsonPropertyName("minAmount")]
    public string? MinAmount { get; set; }

    [JsonPropertyName("maxAmount")]
    public string? MaxAmount { get; set; }

    [JsonPropertyName("createTimestamp")]
    public long? CreateTimestamp { get; set; }

    [JsonPropertyName("optionType")]
    public string? OptionType { get; set; }

    /// <summary>Whether auto-compound is enabled for this product</summary>
    [JsonPropertyName("isAutoCompoundEnable")]
    public bool? IsAutoCompoundEnable { get; set; }

    /// <summary>Available auto-compound plans for this product</summary>
    [JsonPropertyName("autoCompoundPlanList")]
    public List<string>? AutoCompoundPlanList { get; set; }
}
