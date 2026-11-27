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
using Binance.Algo.RestApi;

namespace Binance.Algo.Tests.RestApi;

/// <summary>Decodes an instance of every model, built from its schema, with the serializer context of the module.</summary>
public class ModelTests
{
    private static readonly JsonSerializerOptions Reflection = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };

    public static TheoryData<string, string> Cases => new()
    {
        { "CancelAlgoOrderFutureAlgoResponse", "{\"algoId\":14511,\"success\":true,\"code\":0,\"msg\":\"OK\"}" },
        { "CancelAlgoOrderSpotAlgoResponse", "{\"algoId\":14511,\"success\":true,\"code\":0,\"msg\":\"OK\"}" },
        { "QueryCurrentAlgoOpenOrdersFutureAlgoResponse", "{\"total\":1,\"orders\":[{\"algoId\":14517,\"symbol\":\"ETHUSDT\",\"side\":\"SELL\",\"positionSide\":\"SHORT\",\"totalQty\":\"5.000\",\"executedQty\":\"0.000\",\"executedAmt\":\"0.00000000\",\"avgPrice\":\"0.00\",\"clientAlgoId\":\"d7096549481642f8a0bb69e9e2e31f2e\",\"bookTime\":1649756817004,\"endTime\":0,\"algoStatus\":\"WORKING\",\"algoType\":\"VP\",\"urgency\":\"LOW\"}]}" },
        { "QueryCurrentAlgoOpenOrdersFutureAlgoResponseOrdersInner", "{\"algoId\":14517,\"symbol\":\"ETHUSDT\",\"side\":\"SELL\",\"positionSide\":\"SHORT\",\"totalQty\":\"5.000\",\"executedQty\":\"0.000\",\"executedAmt\":\"0.00000000\",\"avgPrice\":\"0.00\",\"clientAlgoId\":\"d7096549481642f8a0bb69e9e2e31f2e\",\"bookTime\":1649756817004,\"endTime\":0,\"algoStatus\":\"WORKING\",\"algoType\":\"VP\",\"urgency\":\"LOW\"}" },
        { "QueryCurrentAlgoOpenOrdersSpotAlgoResponse", "{\"total\":1,\"orders\":[{\"algoId\":14517,\"symbol\":\"ETHUSDT\",\"side\":\"SELL\",\"totalQty\":\"5.000\",\"executedQty\":\"0.000\",\"executedAmt\":\"0.00000000\",\"avgPrice\":\"0.00\",\"clientAlgoId\":\"d7096549481642f8a0bb69e9e2e31f2e\",\"bookTime\":1649756817004,\"endTime\":0,\"algoStatus\":\"WORKING\",\"algoType\":\"TWAP\",\"urgency\":\"LOW\",\"duration\":86400}]}" },
        { "QueryCurrentAlgoOpenOrdersSpotAlgoResponseOrdersInner", "{\"algoId\":14517,\"symbol\":\"ETHUSDT\",\"side\":\"SELL\",\"totalQty\":\"5.000\",\"executedQty\":\"0.000\",\"executedAmt\":\"0.00000000\",\"avgPrice\":\"0.00\",\"clientAlgoId\":\"d7096549481642f8a0bb69e9e2e31f2e\",\"bookTime\":1649756817004,\"endTime\":0,\"algoStatus\":\"WORKING\",\"algoType\":\"TWAP\",\"urgency\":\"LOW\",\"duration\":86400}" },
        { "QueryHistoricalAlgoOrdersFutureAlgoResponse", "{\"total\":1,\"orders\":[{\"algoId\":14518,\"symbol\":\"BNBUSDT\",\"side\":\"BUY\",\"positionSide\":\"BOTH\",\"totalQty\":\"100.00\",\"executedQty\":\"0.00\",\"executedAmt\":\"0.00000000\",\"avgPrice\":\"0.000\",\"clientAlgoId\":\"acacab56b3c44bef9f6a8f8ebd2a8408\",\"bookTime\":1649757019503,\"endTime\":1649757088101,\"algoStatus\":\"CANCELLED\",\"algoType\":\"VP\",\"urgency\":\"LOW\"}]}" },
        { "QueryHistoricalAlgoOrdersFutureAlgoResponseOrdersInner", "{\"algoId\":14518,\"symbol\":\"BNBUSDT\",\"side\":\"BUY\",\"positionSide\":\"BOTH\",\"totalQty\":\"100.00\",\"executedQty\":\"0.00\",\"executedAmt\":\"0.00000000\",\"avgPrice\":\"0.000\",\"clientAlgoId\":\"acacab56b3c44bef9f6a8f8ebd2a8408\",\"bookTime\":1649757019503,\"endTime\":1649757088101,\"algoStatus\":\"CANCELLED\",\"algoType\":\"VP\",\"urgency\":\"LOW\"}" },
        { "QueryHistoricalAlgoOrdersSpotAlgoResponse", "{\"total\":1,\"orders\":[{\"algoId\":14518,\"symbol\":\"BNBUSDT\",\"side\":\"BUY\",\"totalQty\":\"100.00\",\"executedQty\":\"0.00\",\"executedAmt\":\"0.00000000\",\"avgPrice\":\"0.000\",\"clientAlgoId\":\"acacab56b3c44bef9f6a8f8ebd2a8408\",\"bookTime\":1649757019503,\"endTime\":1649757088101,\"algoStatus\":\"CANCELLED\",\"algoType\":\"TWAP\",\"urgency\":\"LOW\",\"duration\":86400}]}" },
        { "QueryHistoricalAlgoOrdersSpotAlgoResponseOrdersInner", "{\"algoId\":14518,\"symbol\":\"BNBUSDT\",\"side\":\"BUY\",\"totalQty\":\"100.00\",\"executedQty\":\"0.00\",\"executedAmt\":\"0.00000000\",\"avgPrice\":\"0.000\",\"clientAlgoId\":\"acacab56b3c44bef9f6a8f8ebd2a8408\",\"bookTime\":1649757019503,\"endTime\":1649757088101,\"algoStatus\":\"CANCELLED\",\"algoType\":\"TWAP\",\"urgency\":\"LOW\",\"duration\":86400}" },
        { "QuerySubOrdersFutureAlgoResponse", "{\"total\":1,\"executedQty\":\"1.000\",\"executedAmt\":\"3229.44000000\",\"subOrders\":[{\"algoId\":13723,\"orderId\":\"8389765519993909000\",\"orderStatus\":\"FILLED\",\"executedQty\":\"1.000\",\"executedAmt\":\"3229.44000000\",\"feeAmt\":\"-1.61471999\",\"feeAsset\":\"USDT\",\"bookTime\":1649319001964,\"avgPrice\":\"3229.44\",\"side\":\"SELL\",\"symbol\":\"ETHUSDT\",\"subId\":1,\"timeInForce\":\"IMMEDIATE_OR_CANCEL\",\"origQty\":\"1.000\"}]}" },
        { "QuerySubOrdersFutureAlgoResponseSubOrdersInner", "{\"algoId\":13723,\"orderId\":\"8389765519993909000\",\"orderStatus\":\"FILLED\",\"executedQty\":\"1.000\",\"executedAmt\":\"3229.44000000\",\"feeAmt\":\"-1.61471999\",\"feeAsset\":\"USDT\",\"bookTime\":1649319001964,\"avgPrice\":\"3229.44\",\"side\":\"SELL\",\"symbol\":\"ETHUSDT\",\"subId\":1,\"timeInForce\":\"IMMEDIATE_OR_CANCEL\",\"origQty\":\"1.000\"}" },
        { "QuerySubOrdersSpotAlgoResponse", "{\"total\":1,\"executedQty\":\"1.000\",\"executedAmt\":\"3229.44000000\",\"subOrders\":[{\"algoId\":13723,\"orderId\":\"8389765519993909000\",\"orderStatus\":\"FILLED\",\"executedQty\":\"1.000\",\"executedAmt\":\"3229.44000000\",\"feeAmt\":\"-1.61471999\",\"feeAsset\":\"USDT\",\"bookTime\":1649319001964,\"avgPrice\":\"3229.44\",\"side\":\"SELL\",\"symbol\":\"ETHUSDT\",\"subId\":1,\"timeInForce\":\"IMMEDIATE_OR_CANCEL\",\"origQty\":\"1.000\"}]}" },
        { "TimeWeightedAveragePriceFutureAlgoResponse", "{\"clientAlgoId\":\"65ce1630101a480b85915d7e11fd5078\",\"success\":true,\"code\":0,\"msg\":\"OK\"}" },
        { "TimeWeightedAveragePriceSpotAlgoResponse", "{\"clientAlgoId\":\"65ce1630101a480b85915d7e11fd5078\",\"success\":true,\"code\":0,\"msg\":\"OK\"}" },
        { "VolumeParticipationFutureAlgoResponse", "{\"clientAlgoId\":\"00358ce6a268403398bd34eaa36dffe7\",\"success\":true,\"code\":0,\"msg\":\"OK\"}" },
        { "VolumeParticipationResponse", "{\"clientAlgoId\":\"65ce1630101a480b85915d7e11fd5078\",\"success\":true,\"code\":0,\"msg\":\"OK\"}" },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void DecodesAndRoundTrips(string name, string json)
    {
        var assembly = typeof(AlgoRestApi).Assembly;
        var type = assembly.GetType($"Binance.Algo.RestApi.{name.Split('/')[0]}", throwOnError: true)!;
        var context = (JsonSerializerContext)assembly.GetType("Binance.Algo.RestApi.AlgoRestApiJson")!.GetProperty("Default")!.GetValue(null)!;
        // A model that no operation returns is not in the serializer context, so it is decoded by reflection.
        var info = context.GetTypeInfo(type);
        var model = info is null ? JsonSerializer.Deserialize(json, type, Reflection) : JsonSerializer.Deserialize(json, info);
        ExampleAssert.Matches(json, model);
    }
}
