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
using Binance.DerivativesTradingOptions.RestApi;

namespace Binance.DerivativesTradingOptions.Tests.RestApi;

/// <summary>Decodes an instance of every model, built from its schema, with the serializer context of the module.</summary>
public class ModelTests
{
    private static readonly JsonSerializerOptions Reflection = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };

    public static TheoryData<string, string> Cases => new()
    {
        { "AcceptBlockTradeOrderResponse", "{\"blockTradeSettlementKey\":\"7d046e6e-a429-4335-ab9d-6a681febcde5\",\"expireTime\":1730172115801,\"liquidity\":\"MAKER\",\"status\":\"ACCEPTED\",\"createTime\":1730170315803,\"legs\":[{\"symbol\":\"BNB-241101-700-C\",\"side\":\"SELL\",\"quantity\":\"1.2\",\"price\":\"2.8\"}]}" },
        { "AcceptBlockTradeOrderResponseLegsInner", "{\"symbol\":\"BNB-241101-700-C\",\"side\":\"SELL\",\"quantity\":\"1.2\",\"price\":\"2.8\"}" },
        { "AccountBlockTradeListResponseInner", "{\"parentOrderId\":\"4675011431944499201\",\"crossType\":\"USER_BLOCK\",\"legs\":[{\"createTime\":1730170445600,\"updateTime\":1730170445600,\"symbol\":\"BNB-241101-700-C\",\"orderId\":\"4675011431944499203\",\"orderPrice\":2.8,\"orderQuantity\":1.2,\"orderStatus\":\"FILLED\",\"executedQty\":1.2,\"executedAmount\":3.36,\"fee\":0.336,\"orderType\":\"PREV_QUOTED\",\"orderSide\":\"BUY\",\"id\":\"1125899906900937837\",\"tradeId\":1,\"tradePrice\":2.8,\"tradeQty\":1.2,\"tradeTime\":1730170445600,\"liquidity\":\"TAKER\",\"commission\":0.336}],\"blockTradeSettlementKey\":\"7d085e6e-a229-2335-ab9d-6a581febcd25\"}" },
        { "AccountBlockTradeListResponseInnerLegsInner", "{\"createTime\":1730170445600,\"updateTime\":1730170445600,\"symbol\":\"BNB-241101-700-C\",\"orderId\":\"4675011431944499203\",\"orderPrice\":2.8,\"orderQuantity\":1.2,\"orderStatus\":\"FILLED\",\"executedQty\":1.2,\"executedAmount\":3.36,\"fee\":0.336,\"orderType\":\"PREV_QUOTED\",\"orderSide\":\"BUY\",\"id\":\"1125899906900937837\",\"tradeId\":1,\"tradePrice\":2.8,\"tradeQty\":1.2,\"tradeTime\":1730170445600,\"liquidity\":\"TAKER\",\"commission\":0.336}" },
        { "AccountFundingFlowResponseInner", "{\"id\":\"1125899906842624000\",\"asset\":\"USDT\",\"amount\":\"-0.552\",\"symbol\":\"BTC-200730-9000-C\",\"type\":\"FEE\",\"createDate\":1592449456000}" },
        { "AccountTradeListResponseInner", "{\"id\":\"4611875134427365000\",\"tradeId\":239,\"orderId\":\"4611875134427365000\",\"symbol\":\"BTC-200730-9000-C\",\"price\":\"100\",\"quantity\":\"1\",\"fee\":\"-1.04378629\",\"realizedProfit\":\"0.00000000\",\"side\":\"BUY\",\"type\":\"LIMIT\",\"liquidity\":\"TAKER\",\"time\":1592465880683,\"priceScale\":2,\"quantityScale\":2,\"optionSide\":\"CALL\",\"quoteAsset\":\"USDT\"}" },
        { "AutoCancelAllOpenOrdersResponse", "{\"underlyings\":[\"x\"]}" },
        { "CancelAllOptionOrdersByUnderlyingResponse", "{\"code\":0,\"msg\":\"success\"}" },
        { "CancelAllOptionOrdersOnSpecificSymbolResponse", "{\"code\":\"0\",\"msg\":\"success\"}" },
        { "CancelMultipleOptionOrdersResponseInner", "{\"orderId\":\"4611875134427365000\",\"symbol\":\"BTC-200730-9000-C\",\"price\":\"100\",\"quantity\":\"1\",\"executedQty\":\"0\",\"fee\":\"0\",\"side\":\"BUY\",\"type\":\"LIMIT\",\"timeInForce\":\"GTC\",\"reduceOnly\":false,\"createTime\":1592465880683,\"updateTime\":1566818724722,\"status\":\"ACCEPTED\",\"avgPrice\":\"0\",\"clientOrderId\":\"x\",\"priceScale\":3,\"quantityScale\":4,\"optionSide\":\"CALL\",\"quoteAsset\":\"USDT\",\"mmp\":false,\"source\":\"API\",\"selfTradePreventionMode\":\"EXPIRE_MAKER\"}" },
        { "CancelOptionOrderResponse", "{\"orderId\":\"4611875134427365000\",\"symbol\":\"BTC-200730-9000-C\",\"price\":\"100\",\"quantity\":\"1\",\"executedQty\":\"0\",\"side\":\"BUY\",\"type\":\"LIMIT\",\"timeInForce\":\"GTC\",\"reduceOnly\":false,\"createDate\":1592465880683,\"updateTime\":1566818724722,\"status\":\"ACCEPTED\",\"avgPrice\":\"0\",\"source\":\"API\",\"clientOrderId\":\"x\",\"priceScale\":4,\"quantityScale\":4,\"optionSide\":\"CALL\",\"quoteAsset\":\"USDT\",\"mmp\":false,\"selfTradePreventionMode\":\"EXPIRE_MAKER\"}" },
        { "CheckServerTimeResponse", "{\"serverTime\":1592387156596}" },
        { "ExchangeInformationResponse", "{\"timezone\":\"UTC\",\"serverTime\":1592387337630,\"optionContracts\":[{\"baseAsset\":\"BTC\",\"quoteAsset\":\"USDT\",\"underlying\":\"BTCUSDT\",\"settleAsset\":\"USDT\"}],\"optionAssets\":[{\"name\":\"USDT\"}],\"optionSymbols\":[{\"expiryDate\":1660521600000,\"filters\":[{\"filterType\":\"PRICE_FILTER\",\"minPrice\":\"0.02\",\"maxPrice\":\"80000.01\",\"tickSize\":\"0.01\",\"minQty\":\"0.01\",\"maxQty\":\"100\",\"stepSize\":\"0.01\"}],\"symbol\":\"BTC-220815-50000-C\",\"side\":\"CALL\",\"strikePrice\":\"50000\",\"underlying\":\"BTCUSDT\",\"unit\":1,\"liquidationFeeRate\":\"0.0019000\",\"minQty\":\"0.01\",\"maxQty\":\"100\",\"initialMargin\":\"0.15\",\"maintenanceMargin\":\"0.075\",\"minInitialMargin\":\"0.1\",\"minMaintenanceMargin\":\"0.05\",\"priceScale\":2,\"quantityScale\":2,\"quoteAsset\":\"USDT\",\"contractType\":\"CRYPTO_OPTIONS\",\"underlyingType\":\"CRYPTO\",\"nakedSell\":false,\"status\":\"TRADING\"}],\"rateLimits\":[{\"rateLimitType\":\"REQUEST_WEIGHT\",\"interval\":\"MINUTE\",\"intervalNum\":1,\"limit\":2400}]}" },
        { "ExchangeInformationResponseOptionAssetsInner", "{\"name\":\"USDT\"}" },
        { "ExchangeInformationResponseOptionContractsInner", "{\"baseAsset\":\"BTC\",\"quoteAsset\":\"USDT\",\"underlying\":\"BTCUSDT\",\"settleAsset\":\"USDT\"}" },
        { "ExchangeInformationResponseOptionSymbolsInner", "{\"expiryDate\":1660521600000,\"filters\":[{\"filterType\":\"PRICE_FILTER\",\"minPrice\":\"0.02\",\"maxPrice\":\"80000.01\",\"tickSize\":\"0.01\",\"minQty\":\"0.01\",\"maxQty\":\"100\",\"stepSize\":\"0.01\"}],\"symbol\":\"BTC-220815-50000-C\",\"side\":\"CALL\",\"strikePrice\":\"50000\",\"underlying\":\"BTCUSDT\",\"unit\":1,\"liquidationFeeRate\":\"0.0019000\",\"minQty\":\"0.01\",\"maxQty\":\"100\",\"initialMargin\":\"0.15\",\"maintenanceMargin\":\"0.075\",\"minInitialMargin\":\"0.1\",\"minMaintenanceMargin\":\"0.05\",\"priceScale\":2,\"quantityScale\":2,\"quoteAsset\":\"USDT\",\"contractType\":\"CRYPTO_OPTIONS\",\"underlyingType\":\"CRYPTO\",\"nakedSell\":false,\"status\":\"TRADING\"}" },
        { "ExchangeInformationResponseOptionSymbolsInnerFiltersInner", "{\"filterType\":\"PRICE_FILTER\",\"minPrice\":\"0.02\",\"maxPrice\":\"80000.01\",\"tickSize\":\"0.01\",\"minQty\":\"0.01\",\"maxQty\":\"100\",\"stepSize\":\"0.01\"}" },
        { "ExchangeInformationResponseRateLimitsInner", "{\"rateLimitType\":\"REQUEST_WEIGHT\",\"interval\":\"MINUTE\",\"intervalNum\":1,\"limit\":2400}" },
        { "ExtendBlockTradeOrderResponse", "{\"blockTradeSettlementKey\":\"3668822b8-1baa-6a2f-adb8-d3de6289b361\",\"expireTime\":1730172007000,\"liquidity\":\"TAKER\",\"status\":\"RECEIVED\",\"createTime\":1730170088111,\"legs\":[{\"symbol\":\"BNB-241101-700-C\",\"side\":\"BUY\",\"quantity\":\"1.2\",\"price\":\"2.8\"}]}" },
        { "ExtendBlockTradeOrderResponseLegsInner", "{\"symbol\":\"BNB-241101-700-C\",\"side\":\"BUY\",\"quantity\":\"1.2\",\"price\":\"2.8\"}" },
        { "GetAutoCancelAllOpenOrdersResponse", "{\"underlying\":\"ETHUSDT\",\"countdownTime\":100000}" },
        { "GetMarketMakerProtectionConfigResponse", "{\"underlyingId\":2,\"underlying\":\"BTCUSDT\",\"windowTimeInMilliseconds\":3000,\"frozenTimeInMilliseconds\":300000,\"qtyLimit\":\"2\",\"deltaLimit\":\"2.3\",\"lastTriggerTime\":0}" },
        { "HistoricalExerciseRecordsResponseInner", "{\"symbol\":\"BTC-220121-60000-P\",\"strikePrice\":\"60000\",\"realStrikePrice\":\"38844.69652571\",\"expiryDate\":1642752000000,\"strikeResult\":\"REALISTIC_VALUE_STRICKEN\"}" },
        { "IndexPriceResponse", "{\"time\":1656647305000,\"indexPrice\":\"105917.75\"}" },
        { "KlineCandlestickDataItemInner/long", "1" },
        { "KlineCandlestickDataItemInner/string", "\"x\"" },
        { "NewBlockTradeOrderLegsParameterInner", "{\"symbol\":\"BTC-210115-35000-C\",\"side\":\"BUY\",\"type\":\"LIMIT\",\"quantity\":\"0.0002\",\"price\":\"100\"}" },
        { "NewBlockTradeOrderResponse", "{\"blockTradeSettlementKey\":\"3668822b8-1baa-6a2f-adb8-d3de6289b361\",\"expireTime\":1730171888109,\"liquidity\":\"TAKER\",\"status\":\"RECEIVED\",\"legs\":[{\"symbol\":\"BNB-241101-700-C\",\"side\":\"BUY\",\"quantity\":\"1.2\",\"price\":\"2.8\"}]}" },
        { "NewOrderResponse", "{\"orderId\":\"4611875134427365000\",\"symbol\":\"BTC-200730-9000-C\",\"price\":\"100\",\"quantity\":\"1\",\"executedQty\":\"0\",\"fee\":0,\"side\":\"BUY\",\"type\":\"LIMIT\",\"timeInForce\":\"GTC\",\"reduceOnly\":false,\"postOnly\":false,\"createTime\":1592465880683,\"updateTime\":1566818724722,\"status\":\"NEW\",\"avgPrice\":\"0\",\"source\":\"API\",\"clientOrderId\":\"x\",\"priceScale\":2,\"quantityScale\":2,\"optionSide\":\"CALL\",\"quoteAsset\":\"USDT\",\"mmp\":false,\"selfTradePreventionMode\":\"EXPIRE_MAKER\"}" },
        { "OpenInterestResponseInner", "{\"symbol\":\"ETH-221119-1175-P\",\"sumOpenInterest\":\"4.01\",\"sumOpenInterestUsd\":\"4880.2985615624\",\"timestamp\":\"1668754020000\"}" },
        { "OptionMarginAccountInformationResponse", "{\"asset\":[{\"asset\":\"USDT\",\"marginBalance\":\"10099.448\",\"equity\":\"10094.44662\",\"available\":\"8725.92524\",\"initialMargin\":\"1084.52138\",\"maintMargin\":\"151.00138\",\"unrealizedPNL\":\"-5.00138\",\"adjustedEquity\":\"34.13282285\"}],\"greek\":[{\"underlying\":\"BTCUSDT\",\"delta\":\"-0.05\",\"gamma\":\"-0.002\",\"theta\":\"-0.05\",\"vega\":\"-0.002\"}],\"time\":1762843368098,\"canTrade\":true,\"canDeposit\":true,\"canWithdraw\":true,\"reduceOnly\":false,\"tradeGroupId\":-1}" },
        { "OptionMarginAccountInformationResponseAssetInner", "{\"asset\":\"USDT\",\"marginBalance\":\"10099.448\",\"equity\":\"10094.44662\",\"available\":\"8725.92524\",\"initialMargin\":\"1084.52138\",\"maintMargin\":\"151.00138\",\"unrealizedPNL\":\"-5.00138\",\"adjustedEquity\":\"34.13282285\"}" },
        { "OptionMarginAccountInformationResponseGreekInner", "{\"underlying\":\"BTCUSDT\",\"delta\":\"-0.05\",\"gamma\":\"-0.002\",\"theta\":\"-0.05\",\"vega\":\"-0.002\"}" },
        { "OptionMarkPriceResponseInner", "{\"symbol\":\"BTC-200730-9000-C\",\"markPrice\":\"1343.2883\",\"bidIV\":\"1.40000077\",\"askIV\":\"1.50000153\",\"markIV\":\"1.45000000\",\"delta\":\"0.55937056\",\"theta\":\"3739.82509871\",\"gamma\":\"0.00010969\",\"vega\":\"978.58874732\",\"highPriceLimit\":\"1618.241\",\"lowPriceLimit\":\"1068.3356\",\"riskFreeInterest\":\"0.1\"}" },
        { "OptionPositionInformationResponseInner", "{\"entryPrice\":\"1000\",\"symbol\":\"BTC-200730-9000-C\",\"side\":\"SHORT\",\"quantity\":\"-0.1\",\"markValue\":\"105.00138\",\"unrealizedPNL\":\"-5.00138\",\"markPrice\":\"1050.0138\",\"strikePrice\":\"9000\",\"expiryDate\":1593511200000,\"priceScale\":2,\"quantityScale\":2,\"optionSide\":\"CALL\",\"quoteAsset\":\"USDT\",\"time\":1762872654561,\"bidQuantity\":\"0.0000\",\"askQuantity\":\"0.0000\"}" },
        { "OrderBookResponse", "{\"bids\":[[\"x\"]],\"asks\":[[\"x\"]],\"T\":1762780909676,\"lastUpdateId\":361}" },
        { "PlaceMultipleOrdersOrdersParameterInner", "{\"symbol\":\"BTC-200730-9000-C\",\"side\":\"BUY\",\"type\":\"LIMIT\",\"quantity\":1,\"price\":1,\"timeInForce\":\"GTC\",\"reduceOnly\":false,\"postOnly\":false,\"newOrderRespType\":\"ACK\",\"clientOrderId\":\"1\",\"isMmp\":true,\"selfTradePreventionMode\":\"EXPIRE_TAKER\"}" },
        { "PlaceMultipleOrdersResponseInner", "{\"orderId\":\"4611875134427365000\",\"symbol\":\"BTC-200730-9000-C\",\"price\":\"100\",\"quantity\":\"1\",\"executedQty\":\"0\",\"fee\":0,\"side\":\"BUY\",\"type\":\"LIMIT\",\"timeInForce\":\"GTC\",\"reduceOnly\":false,\"postOnly\":false,\"createTime\":1592465880683,\"updateTime\":1566818724722,\"status\":\"NEW\",\"avgPrice\":\"0\",\"clientOrderId\":\"x\",\"priceScale\":2,\"quantityScale\":2,\"optionSide\":\"CALL\",\"quoteAsset\":\"USDT\",\"mmp\":false,\"selfTradePreventionMode\":\"EXPIRE_MAKER\",\"source\":\"API\"}" },
        { "QueryBlockTradeDetailsResponse", "{\"blockTradeSettlementKey\":\"12b96c28-ba05-8906-c89t-703215cfb2e6\",\"expireTime\":1730171860460,\"liquidity\":\"MAKER\",\"status\":\"RECEIVED\",\"createTime\":1730170060462,\"legs\":[{\"symbol\":\"BNB-241101-700-C\",\"side\":\"SELL\",\"quantity\":\"1.66\",\"price\":\"20\"}]}" },
        { "QueryBlockTradeDetailsResponseLegsInner", "{\"symbol\":\"BNB-241101-700-C\",\"side\":\"SELL\",\"quantity\":\"1.66\",\"price\":\"20\"}" },
        { "QueryBlockTradeOrderResponseInner", "{\"blockTradeSettlementKey\":\"7d046e6e-a429-4335-ab9d-6a681febcde5\",\"expireTime\":1730172115801,\"liquidity\":\"TAKER\",\"status\":\"RECEIVED\",\"createTime\":1730170315803,\"legs\":[{\"symbol\":\"BNB-241101-700-C\",\"side\":\"BUY\",\"quantity\":\"1.2\",\"price\":\"2.8\"}]}" },
        { "QueryCurrentOpenOptionOrdersResponseInner", "{\"orderId\":\"4611875134427365000\",\"symbol\":\"BTC-200730-9000-C\",\"price\":\"100\",\"quantity\":\"1\",\"executedQty\":\"0\",\"side\":\"BUY\",\"type\":\"LIMIT\",\"timeInForce\":\"GTC\",\"reduceOnly\":false,\"createTime\":1592465880683,\"updateTime\":1592465880683,\"status\":\"NEW\",\"avgPrice\":\"0\",\"clientOrderId\":\"x\",\"priceScale\":2,\"quantityScale\":2,\"optionSide\":\"CALL\",\"quoteAsset\":\"USDT\",\"mmp\":false,\"selfTradePreventionMode\":\"EXPIRE_MAKER\"}" },
        { "QueryOptionOrderHistoryResponseInner", "{\"orderId\":\"4611875134427365000\",\"symbol\":\"BTC-200730-9000-C\",\"price\":\"100\",\"quantity\":\"1\",\"executedQty\":\"0\",\"side\":\"BUY\",\"type\":\"LIMIT\",\"timeInForce\":\"GTC\",\"reduceOnly\":false,\"createTime\":1592465880683,\"updateTime\":1592465880683,\"status\":\"ACCEPTED\",\"avgPrice\":\"0\",\"clientOrderId\":\"x\",\"priceScale\":2,\"quantityScale\":2,\"optionSide\":\"CALL\",\"quoteAsset\":\"USDT\",\"mmp\":false}" },
        { "QuerySingleOrderResponse", "{\"orderId\":\"4611875134427365000\",\"symbol\":\"BTC-200730-9000-C\",\"price\":\"100\",\"quantity\":\"1\",\"executedQty\":\"0\",\"side\":\"BUY\",\"type\":\"LIMIT\",\"timeInForce\":\"GTC\",\"reduceOnly\":false,\"postOnly\":false,\"createTime\":1592465880683,\"updateTime\":1566818724722,\"status\":\"NEW\",\"avgPrice\":\"0\",\"clientOrderId\":\"x\",\"priceScale\":2,\"quantityScale\":2,\"optionSide\":\"CALL\",\"quoteAsset\":\"USDT\",\"mmp\":false,\"selfTradePreventionMode\":\"EXPIRE_MAKER\"}" },
        { "RecentBlockTradesListResponseInner", "{\"id\":\"1125899906901081100\",\"tradeId\":389,\"symbol\":\"ETH-250725-1200-P\",\"price\":\"342.40\",\"qty\":\"-2167.20\",\"quoteQty\":\"-4.90\",\"side\":-1,\"time\":1733950676483}" },
        { "RecentTradesListResponseInner", "{\"id\":\"2323857420768529000\",\"tradeId\":1,\"symbol\":\"BTC-251123-126000-C\",\"price\":\"1300\",\"qty\":\"0.1\",\"quoteQty\":\"130\",\"side\":-1,\"time\":1762780453623}" },
        { "ResetMarketMakerProtectionConfigResponse", "{\"underlyingId\":2,\"underlying\":\"BTCUSDT\",\"windowTimeInMilliseconds\":3000,\"frozenTimeInMilliseconds\":300000,\"qtyLimit\":\"2\",\"deltaLimit\":\"2.3\",\"lastTriggerTime\":0}" },
        { "SetAutoCancelAllOpenOrdersResponse", "{\"underlying\":\"ETHUSDT\",\"countdownTime\":100000}" },
        { "SetMarketMakerProtectionConfigResponse", "{\"underlyingId\":2,\"underlying\":\"BTCUSDT\",\"windowTimeInMilliseconds\":3000,\"frozenTimeInMilliseconds\":300000,\"qtyLimit\":\"2\",\"deltaLimit\":\"2.3\",\"lastTriggerTime\":0}" },
        { "StartUserDataStreamResponse", "{\"listenKey\":\"pqia91ma19a5s61cv6a81va65sdf19v8a65a1a5s61cv6a81va65sdf19v8a65a1\",\"expiration\":1762855900452}" },
        { "Ticker24hrPriceChangeStatisticsResponseInner", "{\"symbol\":\"BTC-200730-9000-C\",\"priceChange\":\"-16.2038\",\"priceChangePercent\":\"-0.0162\",\"lastPrice\":\"1000\",\"lastQty\":\"1000\",\"open\":\"1016.2038\",\"high\":\"1016.2038\",\"low\":\"0\",\"volume\":\"5\",\"amount\":\"1\",\"bidPrice\":\"999.34\",\"askPrice\":\"1000.23\",\"openTime\":1592317127349,\"closeTime\":1592380593516,\"firstTradeId\":1,\"tradeCount\":5,\"strikePrice\":\"9000\",\"exercisePrice\":\"3000.3356\"}" },
        { "TradfiOptionsContractResponse", "{\"code\":200,\"msg\":\"success\"}" },
        { "UserCommissionResponse", "{\"commissions\":[{\"underlying\":\"BTCUSDT\",\"makerFee\":\"0.000240\",\"takerFee\":\"0.000240\"}]}" },
        { "UserCommissionResponseCommissionsInner", "{\"underlying\":\"BTCUSDT\",\"makerFee\":\"0.000240\",\"takerFee\":\"0.000240\"}" },
        { "UserExerciseRecordResponseInner", "{\"id\":\"1125899906842624042\",\"currency\":\"USDT\",\"symbol\":\"BTC-220721-25000-C\",\"exercisePrice\":\"25000.00000000\",\"quantity\":\"1.00000000\",\"amount\":\"0.00000000\",\"fee\":\"0.00000000\",\"createDate\":1658361600000,\"priceScale\":2,\"quantityScale\":2,\"optionSide\":\"CALL\",\"positionSide\":\"LONG\",\"quoteAsset\":\"USDT\"}" },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void DecodesAndRoundTrips(string name, string json)
    {
        var assembly = typeof(DerivativesTradingOptionsRestApi).Assembly;
        var type = assembly.GetType($"Binance.DerivativesTradingOptions.RestApi.{name.Split('/')[0]}", throwOnError: true)!;
        var context = (JsonSerializerContext)assembly.GetType("Binance.DerivativesTradingOptions.RestApi.DerivativesTradingOptionsRestApiJson")!.GetProperty("Default")!.GetValue(null)!;
        // A model that no operation returns is not in the serializer context, so it is decoded by reflection.
        var info = context.GetTypeInfo(type);
        var model = info is null ? JsonSerializer.Deserialize(json, type, Reflection) : JsonSerializer.Deserialize(json, info);
        ExampleAssert.Matches(json, model);
    }
}
