//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;
using Binance.Common.Tests;
using Binance.DualInvestment.RestApi;

namespace Binance.DualInvestment.Tests.RestApi;

/// <summary>Decodes an instance of every model, built from its schema, with the serializer context of the module.</summary>
public class ModelTests
{
    private static readonly JsonSerializerOptions Reflection = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };

    public static TheoryData<string, string> Cases => new()
    {
        { "CheckDualInvestmentAccountsResponse", "{\"totalAmountInBTC\":\"0.01067982\",\"totalAmountInUSDT\":\"77.13289230\"}" },
        { "GetDualInvestmentPositionsResponse", "{\"total\":1,\"list\":[{\"id\":\"10160533\",\"investCoin\":\"USDT\",\"exercisedCoin\":\"BNB\",\"subscriptionAmount\":\"0.5\",\"strikePrice\":\"330\",\"duration\":4,\"settleDate\":1708416000000,\"purchaseStatus\":\"PURCHASE_SUCCESS\",\"apr\":\"0.0365\",\"orderId\":7973677530,\"purchaseEndTime\":1708329600000,\"optionType\":\"PUT\",\"autoCompoundPlan\":\"STANDARD\",\"subscriptionTime\":1708243200000}]}" },
        { "GetDualInvestmentPositionsResponseListInner", "{\"id\":\"10160533\",\"investCoin\":\"USDT\",\"exercisedCoin\":\"BNB\",\"subscriptionAmount\":\"0.5\",\"strikePrice\":\"330\",\"duration\":4,\"settleDate\":1708416000000,\"purchaseStatus\":\"PURCHASE_SUCCESS\",\"apr\":\"0.0365\",\"orderId\":7973677530,\"purchaseEndTime\":1708329600000,\"optionType\":\"PUT\",\"autoCompoundPlan\":\"STANDARD\",\"subscriptionTime\":1708243200000}" },
        { "GetDualInvestmentProductListResponse", "{\"total\":1,\"list\":[{\"id\":\"741590\",\"investCoin\":\"USDT\",\"exercisedCoin\":\"BNB\",\"strikePrice\":\"380\",\"duration\":4,\"settleDate\":1709020800000,\"purchaseDecimal\":8,\"purchaseEndTime\":1708934400000,\"canPurchase\":true,\"apr\":\"0.6076\",\"orderId\":8257205859,\"minAmount\":\"0.1\",\"maxAmount\":\"25265.7\",\"createTimestamp\":1708560084000,\"optionType\":\"PUT\",\"isAutoCompoundEnable\":true,\"autoCompoundPlanList\":[\"x\"]}]}" },
        { "GetDualInvestmentProductListResponseListInner", "{\"id\":\"741590\",\"investCoin\":\"USDT\",\"exercisedCoin\":\"BNB\",\"strikePrice\":\"380\",\"duration\":4,\"settleDate\":1709020800000,\"purchaseDecimal\":8,\"purchaseEndTime\":1708934400000,\"canPurchase\":true,\"apr\":\"0.6076\",\"orderId\":8257205859,\"minAmount\":\"0.1\",\"maxAmount\":\"25265.7\",\"createTimestamp\":1708560084000,\"optionType\":\"PUT\",\"isAutoCompoundEnable\":true,\"autoCompoundPlanList\":[\"x\"]}" },
        { "SubscribeDualInvestmentProductsResponse", "{\"positionId\":10208824,\"investCoin\":\"BNB\",\"exercisedCoin\":\"USDT\",\"subscriptionAmount\":\"0.002\",\"duration\":4,\"autoCompoundPlan\":\"STANDARD\",\"strikePrice\":\"380\",\"settleDate\":1709020800000,\"purchaseStatus\":\"PURCHASE_SUCCESS\",\"apr\":\"0.7397\",\"orderId\":8259117597,\"purchaseTime\":1708677583874,\"optionType\":\"CALL\"}" },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void DecodesAndRoundTrips(string name, string json)
    {
        var assembly = typeof(DualInvestmentRestApi).Assembly;
        var type = assembly.GetType($"Binance.DualInvestment.RestApi.{name.Split('/')[0]}", throwOnError: true)!;
        var context = (JsonSerializerContext)assembly.GetType("Binance.DualInvestment.RestApi.DualInvestmentRestApiJson")!.GetProperty("Default")!.GetValue(null)!;
        // A model that no operation returns is not in the serializer context, so it is decoded by reflection.
        var info = context.GetTypeInfo(type);
        var model = info is null ? JsonSerializer.Deserialize(json, type, Reflection) : JsonSerializer.Deserialize(json, info);
        ExampleAssert.Matches(json, model);
    }
}
