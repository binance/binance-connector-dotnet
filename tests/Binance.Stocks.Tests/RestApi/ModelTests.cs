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
using Binance.Stocks.RestApi;

namespace Binance.Stocks.Tests.RestApi;

/// <summary>Decodes an instance of every model, built from its schema, with the serializer context of the module.</summary>
public class ModelTests
{
    private static readonly JsonSerializerOptions Reflection = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };

    public static TheoryData<string, string> Cases => new()
    {
        { "BstocksCorporateActionRecordsResponse", "{\"items\":[{\"id\":123456,\"userId\":100001,\"assetCode\":\"EQ_AAPL\",\"eventType\":\"FORWARD_SPLIT\",\"amount\":\"10.50000000\",\"dbModifyTime\":1795593600000}],\"nextTime\":1795593600000,\"nextId\":123456}" },
        { "CancelAllEquityOrdersResponse", "{\"success\":true}" },
        { "CancelEquityOrderResponse", "{\"orderId\":\"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71\",\"status\":\"S\"}" },
        { "CorporateActionRecordsResponse", "{\"items\":[{\"id\":123456,\"userId\":100001,\"assetCode\":\"EQ_AAPL\",\"eventType\":\"FORWARD_SPLIT\",\"amount\":\"10.50000000\",\"dbModifyTime\":1795593600000}],\"nextTime\":1795593600000,\"nextId\":123456}" },
        { "CorporateActionRecordsResponseItemsInner", "{\"id\":123456,\"userId\":100001,\"assetCode\":\"EQ_AAPL\",\"eventType\":\"FORWARD_SPLIT\",\"amount\":\"10.50000000\",\"dbModifyTime\":1795593600000}" },
        { "CreateRenewListenKeyResponse", "{\"listenKey\":\"pqia91ma19a5s61cv6a81va65sdf19v8a65s1cv1zuz3ee1c5xz2ef6ad7\"}" },
        { "CurrentOpenOrdersResponseInner", "{\"orderId\":\"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71\",\"symbol\":\"AAPL\",\"quote\":\"USDC\",\"side\":\"BUY\",\"orderType\":\"LIMIT\",\"limitPrice\":\"180.50\",\"avgFilledPrice\":\"avgFilledPrice\",\"qty\":\"1\",\"notional\":\"notional\",\"filledQty\":\"0\",\"filledTotal\":\"filledTotal\",\"fee\":\"0\",\"session\":\"RTH\",\"status\":\"NEW\",\"createdAt\":1735900000000,\"updatedAt\":1735900000000}" },
        { "EquityOrderDetailResponse", "{\"orderId\":\"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71\",\"clientOrderId\":\"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a\",\"symbol\":\"AAPL\",\"quote\":\"USDC\",\"side\":\"BUY\",\"orderType\":\"LIMIT\",\"limitPrice\":\"180.50\",\"avgFilledPrice\":\"180.48\",\"qty\":\"1\",\"notional\":\"notional\",\"filledQty\":\"1\",\"filledTotal\":\"filledTotal\",\"fee\":\"0.10\",\"session\":\"RTH\",\"status\":\"FILLED\",\"createdAt\":1735900000000,\"updatedAt\":1735900120000,\"trades\":[{\"executionId\":\"exec-20260504-0001\",\"executionAt\":1735900115000,\"price\":\"180.48\",\"qty\":\"1\"}]}" },
        { "EquityOrderDetailResponseTradesInner", "{\"executionId\":\"exec-20260504-0001\",\"executionAt\":1735900115000,\"price\":\"180.48\",\"qty\":\"1\"}" },
        { "EquityOrderHistoryResponse", "{\"total\":2,\"page\":1,\"size\":20,\"rows\":[{\"orderId\":\"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71\",\"symbol\":\"AAPL\",\"quote\":\"USDC\",\"side\":\"BUY\",\"orderType\":\"LIMIT\",\"limitPrice\":\"180.50\",\"avgFilledPrice\":\"180.48\",\"qty\":\"1\",\"notional\":\"notional\",\"filledQty\":\"1\",\"filledTotal\":\"filledTotal\",\"fee\":\"0.10\",\"session\":\"RTH\",\"status\":\"FILLED\",\"createdAt\":1735900000000,\"updatedAt\":1735900120000}]}" },
        { "EquityOrderHistoryResponseRowsInner", "{\"orderId\":\"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71\",\"symbol\":\"AAPL\",\"quote\":\"USDC\",\"side\":\"BUY\",\"orderType\":\"LIMIT\",\"limitPrice\":\"180.50\",\"avgFilledPrice\":\"180.48\",\"qty\":\"1\",\"notional\":\"notional\",\"filledQty\":\"1\",\"filledTotal\":\"filledTotal\",\"fee\":\"0.10\",\"session\":\"RTH\",\"status\":\"FILLED\",\"createdAt\":1735900000000,\"updatedAt\":1735900120000}" },
        { "EquityTradeHistoryResponse", "{\"total\":1,\"page\":1,\"size\":20,\"rows\":[{\"executionId\":\"exec-20260504-0001\",\"orderId\":\"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71\",\"symbol\":\"AAPL\",\"quote\":\"USDC\",\"side\":\"BUY\",\"orderType\":\"LIMIT\",\"price\":\"180.50\",\"qty\":\"1\",\"total\":\"180.50\",\"executionAt\":1735900115000,\"updatedAt\":1735900115200}]}" },
        { "EquityTradeHistoryResponseRowsInner", "{\"executionId\":\"exec-20260504-0001\",\"orderId\":\"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71\",\"symbol\":\"AAPL\",\"quote\":\"USDC\",\"side\":\"BUY\",\"orderType\":\"LIMIT\",\"price\":\"180.50\",\"qty\":\"1\",\"total\":\"180.50\",\"executionAt\":1735900115000,\"updatedAt\":1735900115200}" },
        { "ExchangeInfoResponse", "{\"timezone\":\"UTC\",\"symbols\":[{\"symbol\":\"AAPL\",\"tradability\":\"BUY_SELL\",\"tradabilityUpdateTime\":1735900000000,\"overnightSupported\":true,\"fractionable\":true,\"fractionableEh\":false,\"extendedSession\":true,\"maxNumOrders\":200,\"stepSize\":\"0.000000001\",\"multiplierUp\":\"1.10\",\"multiplierDown\":\"0.90\",\"minQty\":\"0.000000001\",\"maxQty\":\"100000.00000000\",\"minNotional\":\"1.00\",\"maxNotional\":\"1000000.00\",\"listingTime\":1700000000000,\"delistingTime\":1}]}" },
        { "ExchangeInfoResponseSymbolsInner", "{\"symbol\":\"AAPL\",\"tradability\":\"BUY_SELL\",\"tradabilityUpdateTime\":1735900000000,\"overnightSupported\":true,\"fractionable\":true,\"fractionableEh\":false,\"extendedSession\":true,\"maxNumOrders\":200,\"stepSize\":\"0.000000001\",\"multiplierUp\":\"1.10\",\"multiplierDown\":\"0.90\",\"minQty\":\"0.000000001\",\"maxQty\":\"100000.00000000\",\"minNotional\":\"1.00\",\"maxNotional\":\"1000000.00\",\"listingTime\":1700000000000,\"delistingTime\":1}" },
        { "LatestQuoteResponse", "{\"symbol\":\"AAPL\",\"bidPrice\":\"180.50\",\"askPrice\":\"180.52\",\"bidSize\":100,\"askSize\":200}" },
        { "PlaceEquityOrderResponse", "{\"status\":\"S\",\"orderId\":\"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71\",\"clientOrderId\":\"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a\"}" },
        { "SignUsEquityDisclaimerResponse", "{\"success\":true}" },
        { "TokenizedAssetsResponseInner", "{\"assetCode\":\"AAPLB\",\"assetName\":\"Apple Inc. Tokenized Stock\",\"underlyingEquitySymbol\":\"AAPL\",\"multiplier\":\"1\",\"multiplierValid\":true}" },
        { "TokenizedConvertHistoryResponse", "{\"rows\":[{\"underlyingAsset\":\"AAPL\",\"underlyingAssetAmount\":\"1.000000000\",\"tokenizedAsset\":\"AAPLB\",\"tokenizedAssetAmount\":\"1.000000000\",\"issuerRequestId\":\"mint-20260505-8f3b9e1a2d3c4b5a\",\"convertType\":\"MINT\",\"status\":\"S\",\"createdAt\":1735900000000,\"updatedAt\":1735900060000,\"tokenizedAssetSettleWalletType\":\"CARD\"}],\"hasMore\":true,\"nextLastId\":10020}" },
        { "TokenizedConvertHistoryResponseRowsInner", "{\"underlyingAsset\":\"AAPL\",\"underlyingAssetAmount\":\"1.000000000\",\"tokenizedAsset\":\"AAPLB\",\"tokenizedAssetAmount\":\"1.000000000\",\"issuerRequestId\":\"mint-20260505-8f3b9e1a2d3c4b5a\",\"convertType\":\"MINT\",\"status\":\"S\",\"createdAt\":1735900000000,\"updatedAt\":1735900060000,\"tokenizedAssetSettleWalletType\":\"CARD\"}" },
        { "TokenizedConvertStatusResponse", "{\"underlyingAsset\":\"AAPL\",\"underlyingAssetAmount\":\"1.000000000\",\"tokenizedAsset\":\"AAPLB\",\"tokenizedAssetAmount\":\"1.000000000\",\"issuerRequestId\":\"mint-20260505-8f3b9e1a2d3c4b5a\",\"convertType\":\"MINT\",\"status\":\"S\",\"createdAt\":1735900000000,\"updatedAt\":1735900060000,\"tokenizedAssetSettleWalletType\":\"CARD\"}" },
        { "TokenizedMintResponse", "{\"issuerRequestId\":\"mint-20260505-8f3b9e1a2d3c4b5a\",\"status\":\"P\",\"tokenizedAssetSettleWalletType\":\"CARD\"}" },
        { "TokenizedRedeemResponse", "{\"issuerRequestId\":\"redeem-20260505-a1b2c3d4e5f6\",\"status\":\"P\",\"tokenizedAssetSettleWalletType\":\"CARD\"}" },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void DecodesAndRoundTrips(string name, string json)
    {
        var assembly = typeof(StocksRestApi).Assembly;
        var type = assembly.GetType($"Binance.Stocks.RestApi.{name.Split('/')[0]}", throwOnError: true)!;
        var context = (JsonSerializerContext)assembly.GetType("Binance.Stocks.RestApi.StocksRestApiJson")!.GetProperty("Default")!.GetValue(null)!;
        // A model that no operation returns is not in the serializer context, so it is decoded by reflection.
        var info = context.GetTypeInfo(type);
        var model = info is null ? JsonSerializer.Deserialize(json, type, Reflection) : JsonSerializer.Deserialize(json, info);
        ExampleAssert.Matches(json, model);
    }
}
