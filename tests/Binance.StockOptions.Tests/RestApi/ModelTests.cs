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
using Binance.StockOptions.RestApi;

namespace Binance.StockOptions.Tests.RestApi;

/// <summary>Decodes an instance of every model, built from its schema, with the serializer context of the module.</summary>
public class ModelTests
{
    private static readonly JsonSerializerOptions Reflection = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };

    public static TheoryData<string, string> Cases => new()
    {
        { "CancelAllOptionOrdersResponse", "{\"success\":true}" },
        { "CancelOptionOrderResponse", "{\"orderId\":\"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71\",\"status\":\"S\"}" },
        { "CreateRenewListenKeyResponse", "{\"listenKey\":\"3f9a1c2e-7b4d-4e8a-9c61-0d2f5b7e8a13\"}" },
        { "CurrentOpenOptionOrdersResponseInner", "{\"orderId\":\"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71\",\"clientOrderId\":\"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a\",\"symbol\":\"NVDA260930C00100000\",\"underlyingSymbol\":\"NVDA\",\"rootSymbol\":\"NVDA\",\"contractType\":\"CALL\",\"strikePrice\":\"100\",\"expirationDate\":1790784000000,\"multiplier\":\"100\",\"positionIntent\":\"BUY_TO_OPEN\",\"quoteAsset\":\"USDC\",\"side\":\"BUY\",\"orderType\":\"LIMIT\",\"limitPrice\":\"1.5\",\"qty\":\"1\",\"filledQty\":\"0\",\"filledNotional\":\"0\",\"totalCost\":\"150.65\",\"filledPercent\":\"0\",\"status\":\"NEW\",\"createdAt\":1790173800000,\"updatedAt\":1790173800000}" },
        { "ExercisableOptionsResponseInner", "{\"symbol\":\"NVDA260930C00100000\",\"underlyingSymbol\":\"NVDA\",\"rootSymbol\":\"NVDA\",\"contractType\":\"CALL\",\"strikePrice\":\"100\",\"expirationDate\":1790784000000,\"multiplier\":\"100\",\"positionQty\":\"2\",\"availableQty\":\"2\",\"deliverables\":[{\"type\":\"EQUITY\",\"symbol\":\"NVDA\",\"amount\":\"100\"}]}" },
        { "OptionContractsResponseInner", "{\"symbol\":\"NVDA260930C00100000\",\"contractType\":\"CALL\",\"strikePrice\":\"100\",\"multiplier\":\"100\",\"contractSize\":100,\"expirationDate\":\"2026-09-30\",\"status\":\"OPEN_CLOSE\"}" },
        { "OptionExchangeInfoResponse", "{\"timezone\":\"UTC\",\"symbols\":[{\"symbol\":\"NVDA260930C00100000\",\"underlyingSymbol\":\"NVDA\",\"rootSymbol\":\"NVDA\",\"contractType\":\"CALL\",\"status\":\"OPEN_CLOSE\",\"strikePrice\":\"100\",\"expirationDate\":1790784000000,\"multiplier\":\"100\",\"contractSize\":100,\"tickSize\":\"0.01\",\"stepSize\":\"1\",\"minQty\":\"1\",\"maxQty\":\"100000\",\"minNotional\":\"1\",\"maxNotional\":\"500000\",\"optionsLateClose\":false,\"pennyProgram\":true,\"deliverables\":[{\"type\":\"EQUITY\",\"symbol\":\"NVDA\",\"amount\":\"100\"}]}]}" },
        { "OptionExchangeInfoResponseSymbolsInner", "{\"symbol\":\"NVDA260930C00100000\",\"underlyingSymbol\":\"NVDA\",\"rootSymbol\":\"NVDA\",\"contractType\":\"CALL\",\"status\":\"OPEN_CLOSE\",\"strikePrice\":\"100\",\"expirationDate\":1790784000000,\"multiplier\":\"100\",\"contractSize\":100,\"tickSize\":\"0.01\",\"stepSize\":\"1\",\"minQty\":\"1\",\"maxQty\":\"100000\",\"minNotional\":\"1\",\"maxNotional\":\"500000\",\"optionsLateClose\":false,\"pennyProgram\":true,\"deliverables\":[{\"type\":\"EQUITY\",\"symbol\":\"NVDA\",\"amount\":\"100\"}]}" },
        { "OptionExchangeInfoResponseSymbolsInnerDeliverablesInner", "{\"type\":\"EQUITY\",\"symbol\":\"NVDA\",\"amount\":\"100\"}" },
        { "OptionExerciseDetailResponse", "{\"tranId\":1234567890,\"clientOrderId\":\"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a\",\"symbol\":\"NVDA260930C00100000\",\"underlyingSymbol\":\"NVDA\",\"rootSymbol\":\"NVDA\",\"contractType\":\"CALL\",\"strikePrice\":\"100\",\"expirationDate\":1790784000000,\"requestedQty\":\"2\",\"status\":\"SUCCESS\",\"requestedTime\":1790704800000,\"updateTime\":1790766761000,\"optionEventId\":\"a7f3c2e1-4b5d-4e8f-9c0a-1b2c3d4e5f60\",\"underlyingEventId\":\"c9d8e7f6-a5b4-4c3d-8e2f-1a0b9c8d7e6f\",\"multiplier\":\"100\",\"errorCode\":\"497505\"}" },
        { "OptionExerciseHistoryResponse", "{\"total\":1,\"page\":1,\"size\":20,\"rows\":[{\"tranId\":1234567890,\"clientOrderId\":\"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a\",\"symbol\":\"NVDA260930C00100000\",\"underlyingSymbol\":\"NVDA\",\"rootSymbol\":\"NVDA\",\"contractType\":\"CALL\",\"strikePrice\":\"100\",\"expirationDate\":1790784000000,\"requestedQty\":\"2\",\"status\":\"SUCCESS\",\"requestedTime\":1790704800000}]}" },
        { "OptionExerciseHistoryResponseRowsInner", "{\"tranId\":1234567890,\"clientOrderId\":\"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a\",\"symbol\":\"NVDA260930C00100000\",\"underlyingSymbol\":\"NVDA\",\"rootSymbol\":\"NVDA\",\"contractType\":\"CALL\",\"strikePrice\":\"100\",\"expirationDate\":1790784000000,\"requestedQty\":\"2\",\"status\":\"SUCCESS\",\"requestedTime\":1790704800000}" },
        { "OptionExpirationsResponseInner", "{\"expirationDate\":\"2026-09-30\",\"rootSymbol\":\"NVDA\"}" },
        { "OptionOrderDetailResponse", "{\"orderId\":\"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71\",\"clientOrderId\":\"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a\",\"symbol\":\"NVDA260930C00100000\",\"underlyingSymbol\":\"NVDA\",\"rootSymbol\":\"NVDA\",\"contractType\":\"CALL\",\"strikePrice\":\"100\",\"expirationDate\":1790784000000,\"multiplier\":\"100\",\"positionIntent\":\"BUY_TO_OPEN\",\"autoLiquidation\":false,\"quote\":\"USDC\",\"side\":\"BUY\",\"orderType\":\"LIMIT\",\"limitPrice\":\"1.5\",\"avgFilledPrice\":\"1.48\",\"qty\":\"1\",\"filledQty\":\"1\",\"filledTotal\":\"148\",\"fee\":\"0.65\",\"status\":\"FILLED\",\"createdAt\":1790173800000,\"updatedAt\":1790173802000,\"timeInForce\":\"DAY\",\"commission\":\"0.6\",\"platformFee\":\"0\",\"sec\":\"0\",\"taf\":\"0\",\"cat\":\"0.01\",\"orf\":\"0.02\",\"occ\":\"0.02\",\"total\":\"148\",\"filledAt\":1790173802000,\"canceledAt\":1790173802000,\"expiredAt\":1790173802000,\"settlementDate\":1790272800000,\"trades\":[{\"executionId\":\"8f2d0c1e-5b7a-4e3c-9d61-2a4b6c8e0f13\",\"executionAt\":1790173802000,\"price\":\"1.48\",\"qty\":\"1\"}]}" },
        { "OptionOrderDetailResponseTradesInner", "{\"executionId\":\"8f2d0c1e-5b7a-4e3c-9d61-2a4b6c8e0f13\",\"executionAt\":1790173802000,\"price\":\"1.48\",\"qty\":\"1\"}" },
        { "OptionOrderHistoryResponse", "{\"total\":1,\"page\":1,\"size\":20,\"rows\":[{\"orderId\":\"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71\",\"clientOrderId\":\"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a\",\"symbol\":\"NVDA260930C00100000\",\"underlyingSymbol\":\"NVDA\",\"rootSymbol\":\"NVDA\",\"contractType\":\"CALL\",\"strikePrice\":\"100\",\"expirationDate\":1790784000000,\"multiplier\":\"100\",\"positionIntent\":\"BUY_TO_OPEN\",\"autoLiquidation\":false,\"quote\":\"USDC\",\"side\":\"BUY\",\"orderType\":\"LIMIT\",\"limitPrice\":\"1.5\",\"avgFilledPrice\":\"1.48\",\"qty\":\"1\",\"filledQty\":\"1\",\"filledTotal\":\"148\",\"fee\":\"0.65\",\"status\":\"FILLED\",\"createdAt\":1790173800000,\"updatedAt\":1790173802000}]}" },
        { "OptionOrderHistoryResponseRowsInner", "{\"orderId\":\"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71\",\"clientOrderId\":\"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a\",\"symbol\":\"NVDA260930C00100000\",\"underlyingSymbol\":\"NVDA\",\"rootSymbol\":\"NVDA\",\"contractType\":\"CALL\",\"strikePrice\":\"100\",\"expirationDate\":1790784000000,\"multiplier\":\"100\",\"positionIntent\":\"BUY_TO_OPEN\",\"autoLiquidation\":false,\"quote\":\"USDC\",\"side\":\"BUY\",\"orderType\":\"LIMIT\",\"limitPrice\":\"1.5\",\"avgFilledPrice\":\"1.48\",\"qty\":\"1\",\"filledQty\":\"1\",\"filledTotal\":\"148\",\"fee\":\"0.65\",\"status\":\"FILLED\",\"createdAt\":1790173800000,\"updatedAt\":1790173802000}" },
        { "OptionPositionsResponseInner", "{\"symbol\":\"NVDA260930C00100000\",\"underlyingSymbol\":\"NVDA\",\"contractType\":\"CALL\",\"side\":\"LONG\",\"free\":\"2\",\"locked\":\"1\",\"strikePrice\":\"100\",\"expirationDate\":1790784000000,\"multiplier\":\"100\"}" },
        { "OptionSettlementEventDetailResponse", "{\"eventId\":\"a7f3c2e1-4b5d-4e8f-9c0a-1b2c3d4e5f60\",\"eventType\":\"EXERCISE\",\"status\":\"Completed\",\"symbol\":\"NVDA260930C00100000\",\"underlyingSymbol\":\"NVDA\",\"contractType\":\"CALL\",\"contracts\":\"2\",\"expirationDate\":1790784000000,\"strikePrice\":\"100\",\"shareDelta\":\"200\",\"deliverables\":[{\"type\":\"OPEXC\",\"symbol\":\"USDC\",\"amount\":\"-20000\"}],\"eventTime\":1790766761000,\"settlementKind\":\"PHYSICAL\",\"underlyingPrice\":\"123.45\",\"cashDirection\":\"DEBIT\",\"amount\":\"20000\",\"collateralRelease\":[{\"symbol\":\"USDC\",\"amount\":\"9000\"}],\"updatedTime\":1790766761000}" },
        { "OptionSettlementEventDetailResponseCollateralReleaseInner", "{\"symbol\":\"USDC\",\"amount\":\"9000\"}" },
        { "OptionSettlementEventHistoryResponse", "{\"rows\":[{\"eventId\":\"a7f3c2e1-4b5d-4e8f-9c0a-1b2c3d4e5f60\",\"eventType\":\"EXERCISE\",\"status\":\"Completed\",\"symbol\":\"NVDA260930C00100000\",\"underlyingSymbol\":\"NVDA\",\"contractType\":\"CALL\",\"contracts\":\"2\",\"expirationDate\":1790784000000,\"strikePrice\":\"100\",\"shareDelta\":\"200\",\"deliverables\":[{\"type\":\"OPEXC\",\"symbol\":\"USDC\",\"amount\":\"-20000\"}],\"eventTime\":1790766760000}],\"hasMore\":false,\"nextLastId\":10086}" },
        { "OptionSettlementEventHistoryResponseRowsInner", "{\"eventId\":\"a7f3c2e1-4b5d-4e8f-9c0a-1b2c3d4e5f60\",\"eventType\":\"EXERCISE\",\"status\":\"Completed\",\"symbol\":\"NVDA260930C00100000\",\"underlyingSymbol\":\"NVDA\",\"contractType\":\"CALL\",\"contracts\":\"2\",\"expirationDate\":1790784000000,\"strikePrice\":\"100\",\"shareDelta\":\"200\",\"deliverables\":[{\"type\":\"OPEXC\",\"symbol\":\"USDC\",\"amount\":\"-20000\"}],\"eventTime\":1790766760000}" },
        { "OptionSettlementEventHistoryResponseRowsInnerDeliverablesInner", "{\"type\":\"OPEXC\",\"symbol\":\"USDC\",\"amount\":\"-20000\"}" },
        { "OptionTradeHistoryResponse", "{\"total\":1,\"page\":1,\"size\":20,\"rows\":[{\"executionId\":\"8f2d0c1e-5b7a-4e3c-9d61-2a4b6c8e0f13\",\"orderId\":\"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71\",\"clientOrderId\":\"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a\",\"symbol\":\"NVDA260930C00100000\",\"underlyingSymbol\":\"NVDA\",\"rootSymbol\":\"NVDA\",\"contractType\":\"CALL\",\"strikePrice\":\"100\",\"expirationDate\":1790784000000,\"multiplier\":\"100\",\"positionIntent\":\"BUY_TO_OPEN\",\"autoLiquidation\":false,\"quote\":\"USDC\",\"side\":\"BUY\",\"orderType\":\"LIMIT\",\"price\":\"1.48\",\"qty\":\"1\",\"total\":\"148\",\"executionAt\":1790173802000,\"updatedAt\":1790173802000,\"settlementDate\":1790272800000}]}" },
        { "OptionTradeHistoryResponseRowsInner", "{\"executionId\":\"8f2d0c1e-5b7a-4e3c-9d61-2a4b6c8e0f13\",\"orderId\":\"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71\",\"clientOrderId\":\"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a\",\"symbol\":\"NVDA260930C00100000\",\"underlyingSymbol\":\"NVDA\",\"rootSymbol\":\"NVDA\",\"contractType\":\"CALL\",\"strikePrice\":\"100\",\"expirationDate\":1790784000000,\"multiplier\":\"100\",\"positionIntent\":\"BUY_TO_OPEN\",\"autoLiquidation\":false,\"quote\":\"USDC\",\"side\":\"BUY\",\"orderType\":\"LIMIT\",\"price\":\"1.48\",\"qty\":\"1\",\"total\":\"148\",\"executionAt\":1790173802000,\"updatedAt\":1790173802000,\"settlementDate\":1790272800000}" },
        { "PlaceOptionOrderResponse", "{\"status\":\"S\",\"orderId\":\"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71\",\"clientOrderId\":\"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a\"}" },
        { "SubmitOptionExerciseResponse", "{\"tranId\":1234567890,\"clientOrderId\":\"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a\",\"status\":\"PROCESSING\"}" },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void DecodesAndRoundTrips(string name, string json)
    {
        var assembly = typeof(StockOptionsRestApi).Assembly;
        var type = assembly.GetType($"Binance.StockOptions.RestApi.{name.Split('/')[0]}", throwOnError: true)!;
        var context = (JsonSerializerContext)assembly.GetType("Binance.StockOptions.RestApi.StockOptionsRestApiJson")!.GetProperty("Default")!.GetValue(null)!;
        // A model that no operation returns is not in the serializer context, so it is decoded by reflection.
        var info = context.GetTypeInfo(type);
        var model = info is null ? JsonSerializer.Deserialize(json, type, Reflection) : JsonSerializer.Deserialize(json, info);
        ExampleAssert.Matches(json, model);
    }
}
