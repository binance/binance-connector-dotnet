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
using Binance.DerivativesTradingUsdsFutures.WebSocketStreams;

namespace Binance.DerivativesTradingUsdsFutures.Tests.WebSocketStreams;

/// <summary>Decodes an instance of every model, built from its schema, with the serializer context of the module.</summary>
public class ModelTests
{
    private static readonly JsonSerializerOptions Reflection = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };

    public static TheoryData<string, string> Cases => new()
    {
        { "AccountConfigUpdate", "{\"E\":1611646737479,\"T\":1611646737476,\"ac\":{\"s\":\"BTCUSDT\",\"l\":25},\"ai\":{\"j\":true}}" },
        { "AccountConfigUpdateAc", "{\"s\":\"BTCUSDT\",\"l\":25}" },
        { "AccountConfigUpdateAi", "{\"j\":true}" },
        { "AccountUpdate", "{\"E\":1564745798939,\"T\":1564745798938,\"a\":{\"m\":\"ORDER\",\"B\":[{\"a\":\"USDT\",\"wb\":\"122624.12345678\",\"cw\":\"100.12345678\",\"bc\":\"50.12345678\"}],\"P\":[{\"s\":\"BTCUSDT\",\"pa\":\"0\",\"ep\":\"0.00000\",\"bep\":\"0\",\"cr\":\"200\",\"up\":\"0\",\"mt\":\"isolated\",\"iw\":\"0.00000000\",\"ps\":\"BOTH\"}],\"S\":\"BTCUSDT\"}}" },
        { "AccountUpdateA", "{\"m\":\"ORDER\",\"B\":[{\"a\":\"USDT\",\"wb\":\"122624.12345678\",\"cw\":\"100.12345678\",\"bc\":\"50.12345678\"}],\"P\":[{\"s\":\"BTCUSDT\",\"pa\":\"0\",\"ep\":\"0.00000\",\"bep\":\"0\",\"cr\":\"200\",\"up\":\"0\",\"mt\":\"isolated\",\"iw\":\"0.00000000\",\"ps\":\"BOTH\"}],\"S\":\"BTCUSDT\"}" },
        { "AccountUpdateABInner", "{\"a\":\"USDT\",\"wb\":\"122624.12345678\",\"cw\":\"100.12345678\",\"bc\":\"50.12345678\"}" },
        { "AccountUpdateAPInner", "{\"s\":\"BTCUSDT\",\"pa\":\"0\",\"ep\":\"0.00000\",\"bep\":\"0\",\"cr\":\"200\",\"up\":\"0\",\"mt\":\"isolated\",\"iw\":\"0.00000000\",\"ps\":\"BOTH\"}" },
        { "AggregateTradeStreamsResponse", "{\"e\":\"aggTrade\",\"E\":123456789,\"s\":\"BNBUSDT\",\"a\":5933014,\"p\":\"0.001\",\"q\":\"100\",\"nq\":\"100\",\"f\":100,\"l\":105,\"T\":123456785,\"m\":true,\"st\":1}" },
        { "AlgoUpdate", "{\"T\":1750515742297,\"E\":1750515742303,\"o\":{\"caid\":\"Q5xaq5EGKgXXa0fD7fs0Ip\",\"aid\":2148719,\"at\":\"CONDITIONAL\",\"o\":\"TAKE_PROFIT\",\"s\":\"BNBUSDT\",\"S\":\"SELL\",\"ps\":\"BOTH\",\"f\":\"GTC\",\"q\":\"0.01\",\"X\":\"CANCELED\",\"ai\":\"x\",\"ap\":\"0.00000\",\"aq\":\"0.00000\",\"act\":\"0\",\"tp\":\"750\",\"p\":\"750\",\"V\":\"EXPIRE_MAKER\",\"wt\":\"CONTRACT_PRICE\",\"pm\":\"NONE\",\"cp\":false,\"pP\":false,\"R\":false,\"tt\":0,\"gtd\":0,\"rm\":\"Reduce Only reject\",\"ia\":false,\"spt\":\"ChaseRatio\",\"spv\":\"0.01\",\"splv\":\"0.01\"}}" },
        { "AlgoUpdateO", "{\"caid\":\"Q5xaq5EGKgXXa0fD7fs0Ip\",\"aid\":2148719,\"at\":\"CONDITIONAL\",\"o\":\"TAKE_PROFIT\",\"s\":\"BNBUSDT\",\"S\":\"SELL\",\"ps\":\"BOTH\",\"f\":\"GTC\",\"q\":\"0.01\",\"X\":\"CANCELED\",\"ai\":\"x\",\"ap\":\"0.00000\",\"aq\":\"0.00000\",\"act\":\"0\",\"tp\":\"750\",\"p\":\"750\",\"V\":\"EXPIRE_MAKER\",\"wt\":\"CONTRACT_PRICE\",\"pm\":\"NONE\",\"cp\":false,\"pP\":false,\"R\":false,\"tt\":0,\"gtd\":0,\"rm\":\"Reduce Only reject\",\"ia\":false,\"spt\":\"ChaseRatio\",\"spv\":\"0.01\",\"splv\":\"0.01\"}" },
        { "AllBookTickersStreamResponse", "{\"e\":\"bookTicker\",\"u\":400900217,\"E\":1568014460893,\"T\":1568014460891,\"s\":\"BNBUSDT\",\"b\":\"25.35190000\",\"B\":\"31.21000000\",\"a\":\"25.36520000\",\"A\":\"40.66000000\",\"ps\":\"BTCUSDT\",\"st\":1}" },
        { "AllMarketLiquidationOrderStreamsResponse", "{\"e\":\"forceOrder\",\"E\":1568014460893,\"o\":{\"s\":\"BTCUSDT\",\"S\":\"SELL\",\"o\":\"LIMIT\",\"f\":\"IOC\",\"q\":\"0.014\",\"p\":\"9910\",\"ap\":\"9910\",\"X\":\"FILLED\",\"l\":\"0.014\",\"z\":\"0.014\",\"T\":1568014460893},\"ps\":\"BTCUSDT\",\"st\":1}" },
        { "AllMarketLiquidationOrderStreamsResponseO", "{\"s\":\"BTCUSDT\",\"S\":\"SELL\",\"o\":\"LIMIT\",\"f\":\"IOC\",\"q\":\"0.014\",\"p\":\"9910\",\"ap\":\"9910\",\"X\":\"FILLED\",\"l\":\"0.014\",\"z\":\"0.014\",\"T\":1568014460893}" },
        { "AllMarketMiniTickersStreamResponseInner", "{\"e\":\"24hrMiniTicker\",\"E\":123456789,\"s\":\"BNBUSDT\",\"c\":\"0.0025\",\"o\":\"0.0010\",\"h\":\"0.0025\",\"l\":\"0.0010\",\"v\":\"10000\",\"q\":\"18\",\"ps\":\"BTCUSDT\",\"st\":1}" },
        { "AllMarketTickersStreamsResponseInner", "{\"e\":\"24hrTicker\",\"E\":123456789,\"s\":\"BNBUSDT\",\"p\":\"0.0015\",\"P\":\"250.00\",\"w\":\"0.0018\",\"c\":\"0.0025\",\"Q\":\"10\",\"o\":\"0.0010\",\"h\":\"0.0025\",\"l\":\"0.0010\",\"v\":\"10000\",\"q\":\"18\",\"O\":0,\"C\":86400000,\"F\":0,\"L\":18150,\"n\":18151,\"ps\":\"BTCUSDT\",\"st\":1}" },
        { "AssetIndexResponseInner", "{\"e\":\"assetIndexUpdate\",\"E\":1686749230000,\"s\":\"ADAUSD\",\"i\":\"0.27462452\",\"b\":\"0.10000000\",\"a\":\"0.10000000\",\"B\":\"0.24716207\",\"A\":\"0.30208698\",\"q\":\"0.05000000\",\"g\":\"0.05000000\",\"Q\":\"0.26089330\",\"G\":\"0.28835575\"}" },
        { "CompositeIndexSymbolInformationStreamsResponse", "{\"e\":\"compositeIndex\",\"E\":1602310596000,\"s\":\"DEFIUSDT\",\"p\":\"554.41604065\",\"C\":\"baseAsset\",\"c\":[{\"b\":\"BAL\",\"q\":\"USDT\",\"w\":\"1.04884844\",\"W\":\"0.01457800\",\"i\":\"24.33521021\"}]}" },
        { "CompositeIndexSymbolInformationStreamsResponseCInner", "{\"b\":\"BAL\",\"q\":\"USDT\",\"w\":\"1.04884844\",\"W\":\"0.01457800\",\"i\":\"24.33521021\"}" },
        { "ConditionalOrderTriggerReject", "{\"E\":1685517224945,\"T\":1685517224955,\"or\":{\"s\":\"ETHUSDT\",\"i\":155618472834,\"r\":\"Due to the order could not be filled immediately, the FOK order has been rejected. The order will not be recorded in the order history\"}}" },
        { "ConditionalOrderTriggerRejectOr", "{\"s\":\"ETHUSDT\",\"i\":155618472834,\"r\":\"Due to the order could not be filled immediately, the FOK order has been rejected. The order will not be recorded in the order history\"}" },
        { "ContinuousContractKlineCandlestickStreamsResponse", "{\"e\":\"continuous_kline\",\"E\":1607443058651,\"ps\":\"BTCUSDT\",\"ct\":\"PERPETUAL\",\"k\":{\"t\":1607443020000,\"T\":1607443079999,\"i\":\"1m\",\"f\":116467658886,\"L\":116468012423,\"o\":\"18787.00\",\"c\":\"18804.04\",\"h\":\"18804.04\",\"l\":\"18786.54\",\"v\":\"197.664\",\"n\":543,\"x\":false,\"q\":\"3715253.19494\",\"V\":\"184.769\",\"Q\":\"3472925.84746\",\"B\":\"0\"}}" },
        { "ContinuousContractKlineCandlestickStreamsResponseK", "{\"t\":1607443020000,\"T\":1607443079999,\"i\":\"1m\",\"f\":116467658886,\"L\":116468012423,\"o\":\"18787.00\",\"c\":\"18804.04\",\"h\":\"18804.04\",\"l\":\"18786.54\",\"v\":\"197.664\",\"n\":543,\"x\":false,\"q\":\"3715253.19494\",\"V\":\"184.769\",\"Q\":\"3472925.84746\",\"B\":\"0\"}" },
        { "ContractInfoStreamResponse", "{\"e\":\"contractInfo\",\"E\":1669356423908,\"s\":\"IOTAUSDT\",\"ct\":\"PERPETUAL\",\"dt\":4133404800000,\"ot\":1569398400000,\"cs\":\"TRADING\",\"bks\":[{\"bs\":1,\"bnf\":0,\"bnc\":5000,\"mmr\":0.01,\"cf\":0,\"mi\":21,\"ma\":50}],\"st\":1}" },
        { "ContractInfoStreamResponseBksInner", "{\"bs\":1,\"bnf\":0,\"bnc\":5000,\"mmr\":0.01,\"cf\":0,\"mi\":21,\"ma\":50}" },
        { "DiffBookDepthStreamsResponse", "{\"e\":\"depthUpdate\",\"E\":123456789,\"T\":123456788,\"s\":\"BNBUSDT\",\"U\":157,\"u\":160,\"pu\":149,\"b\":[[\"x\"]],\"a\":[[\"x\"]],\"ps\":\"BTCUSDT\",\"st\":1}" },
        { "GridUpdate", "{\"T\":1669262908216,\"E\":1669262908218,\"gu\":{\"si\":176057039,\"st\":\"GRID\",\"ss\":\"WORKING\",\"s\":\"BTCUSDT\",\"r\":\"-0.00300716\",\"up\":\"16720\",\"uq\":\"-0.001\",\"uf\":\"-0.00300716\",\"mp\":\"0.0\",\"ut\":1669262908197}}" },
        { "GridUpdateGu", "{\"si\":176057039,\"st\":\"GRID\",\"ss\":\"WORKING\",\"s\":\"BTCUSDT\",\"r\":\"-0.00300716\",\"up\":\"16720\",\"uq\":\"-0.001\",\"uf\":\"-0.00300716\",\"mp\":\"0.0\",\"ut\":1669262908197}" },
        { "IndividualSymbolBookTickerStreamsResponse", "{\"e\":\"bookTicker\",\"u\":400900217,\"E\":1568014460893,\"T\":1568014460891,\"s\":\"BNBUSDT\",\"ps\":\"BNBUSDT\",\"b\":\"25.35190000\",\"B\":\"31.21000000\",\"a\":\"25.36520000\",\"A\":\"40.66000000\",\"st\":1}" },
        { "IndividualSymbolMiniTickerStreamResponse", "{\"e\":\"24hrMiniTicker\",\"E\":123456789,\"s\":\"BNBUSDT\",\"c\":\"0.0025\",\"o\":\"0.0010\",\"h\":\"0.0025\",\"l\":\"0.0010\",\"v\":\"10000\",\"q\":\"18\",\"ps\":\"BTCUSDT\",\"st\":1}" },
        { "IndividualSymbolTickerStreamsResponse", "{\"e\":\"24hrTicker\",\"E\":123456789,\"s\":\"BNBUSDT\",\"p\":\"0.0015\",\"P\":\"250.00\",\"w\":\"0.0018\",\"c\":\"0.0025\",\"Q\":\"10\",\"o\":\"0.0010\",\"h\":\"0.0025\",\"l\":\"0.0010\",\"v\":\"10000\",\"q\":\"18\",\"O\":0,\"C\":86400000,\"F\":0,\"L\":18150,\"n\":18151,\"ps\":\"BTCUSDT\",\"st\":1}" },
        { "KlineCandlestickStreamsResponse", "{\"e\":\"kline\",\"E\":1638747660000,\"s\":\"BTCUSDT\",\"k\":{\"t\":1638747660000,\"T\":1638747719999,\"s\":\"BTCUSDT\",\"i\":\"1m\",\"f\":100,\"L\":200,\"o\":\"0.0010\",\"c\":\"0.0020\",\"h\":\"0.0025\",\"l\":\"0.0015\",\"v\":\"1000\",\"n\":100,\"x\":false,\"q\":\"1.0000\",\"V\":\"500\",\"Q\":\"0.500\",\"B\":\"123456\"}}" },
        { "KlineCandlestickStreamsResponseK", "{\"t\":1638747660000,\"T\":1638747719999,\"s\":\"BTCUSDT\",\"i\":\"1m\",\"f\":100,\"L\":200,\"o\":\"0.0010\",\"c\":\"0.0020\",\"h\":\"0.0025\",\"l\":\"0.0015\",\"v\":\"1000\",\"n\":100,\"x\":false,\"q\":\"1.0000\",\"V\":\"500\",\"Q\":\"0.500\",\"B\":\"123456\"}" },
        { "LiquidationOrderStreamsResponse", "{\"e\":\"forceOrder\",\"E\":1568014460893,\"o\":{\"s\":\"BTCUSDT\",\"S\":\"SELL\",\"o\":\"LIMIT\",\"f\":\"IOC\",\"q\":\"0.014\",\"p\":\"9910\",\"ap\":\"9910\",\"X\":\"FILLED\",\"l\":\"0.014\",\"z\":\"0.014\",\"T\":1568014460893}}" },
        { "ListenKeyExpired", "{\"E\":1736996475556,\"listenKey\":\"WsCMN0a4KHUPTQuX6IUnqEZfB1inxmv1qR4kbf1LuEjur5VdbzqvyxqG9TSjVVxv\"}" },
        { "MarginCall", "{\"E\":1587727187525,\"cw\":\"3.16812045\",\"p\":[{\"s\":\"ETHUSDT\",\"ps\":\"LONG\",\"pa\":\"1.327\",\"mt\":\"CROSSED\",\"iw\":\"0\",\"mp\":\"187.17127\",\"up\":\"-1.166074\",\"mm\":\"1.614445\"}]}" },
        { "MarginCallPInner", "{\"s\":\"ETHUSDT\",\"ps\":\"LONG\",\"pa\":\"1.327\",\"mt\":\"CROSSED\",\"iw\":\"0\",\"mp\":\"187.17127\",\"up\":\"-1.166074\",\"mm\":\"1.614445\"}" },
        { "MarkPriceStreamForAllMarketResponseInner", "{\"e\":\"markPriceUpdate\",\"E\":1562305380000,\"s\":\"BTCUSDT\",\"p\":\"11185.87786614\",\"i\":\"11784.62659091\",\"P\":\"11784.25641265\",\"r\":\"0.00030000\",\"ap\":\"11185.87786614\",\"T\":1562306400000,\"st\":1}" },
        { "MarkPriceStreamResponse", "{\"e\":\"markPriceUpdate\",\"E\":1562305380000,\"s\":\"BTCUSDT\",\"p\":\"11794.15000000\",\"i\":\"11784.62659091\",\"P\":\"11784.25641265\",\"r\":\"0.00038167\",\"ap\":\"11794.15000000\",\"T\":1562306400000,\"st\":1}" },
        { "OrderTradeUpdate", "{\"E\":1568879465651,\"T\":1568879465650,\"o\":{\"s\":\"BTCUSDT\",\"c\":\"TEST\",\"S\":\"SELL\",\"o\":\"TRAILING_STOP_MARKET\",\"f\":\"GTC\",\"q\":\"0.001\",\"p\":\"0\",\"ap\":\"0\",\"sp\":\"7103.04\",\"x\":\"NEW\",\"X\":\"NEW\",\"i\":8886774,\"M\":\"44444\",\"l\":\"0\",\"z\":\"0\",\"L\":\"0\",\"N\":\"USDT\",\"n\":\"0\",\"T\":1568879465650,\"t\":0,\"b\":\"0\",\"a\":\"9.91\",\"m\":false,\"R\":false,\"wt\":\"CONTRACT_PRICE\",\"ot\":\"TRAILING_STOP_MARKET\",\"ps\":\"LONG\",\"cp\":false,\"AP\":\"7476.89\",\"cr\":\"5.0\",\"pP\":false,\"si\":0,\"ss\":0,\"rp\":\"0\",\"V\":\"EXPIRE_TAKER\",\"pm\":\"OPPONENT\",\"gtd\":0,\"er\":\"0\"}}" },
        { "OrderTradeUpdateO", "{\"s\":\"BTCUSDT\",\"c\":\"TEST\",\"S\":\"SELL\",\"o\":\"TRAILING_STOP_MARKET\",\"f\":\"GTC\",\"q\":\"0.001\",\"p\":\"0\",\"ap\":\"0\",\"sp\":\"7103.04\",\"x\":\"NEW\",\"X\":\"NEW\",\"i\":8886774,\"M\":\"44444\",\"l\":\"0\",\"z\":\"0\",\"L\":\"0\",\"N\":\"USDT\",\"n\":\"0\",\"T\":1568879465650,\"t\":0,\"b\":\"0\",\"a\":\"9.91\",\"m\":false,\"R\":false,\"wt\":\"CONTRACT_PRICE\",\"ot\":\"TRAILING_STOP_MARKET\",\"ps\":\"LONG\",\"cp\":false,\"AP\":\"7476.89\",\"cr\":\"5.0\",\"pP\":false,\"si\":0,\"ss\":0,\"rp\":\"0\",\"V\":\"EXPIRE_TAKER\",\"pm\":\"OPPONENT\",\"gtd\":0,\"er\":\"0\"}" },
        { "PartialBookDepthStreamsResponse", "{\"e\":\"depthUpdate\",\"E\":1571889248277,\"T\":1571889248276,\"s\":\"BTCUSDT\",\"U\":390497796,\"u\":390497878,\"pu\":390497794,\"b\":[[\"x\"]],\"a\":[[\"x\"]],\"ps\":\"BTCUSDT\",\"st\":1}" },
        { "RpiDiffBookDepthStreamsResponse", "{\"e\":\"depthUpdate\",\"E\":123456789,\"T\":123456788,\"s\":\"BNBUSDT\",\"U\":157,\"u\":160,\"pu\":149,\"b\":[[\"x\"]],\"a\":[[\"x\"]],\"ps\":\"BTCUSDT\",\"st\":1}" },
        { "StrategyUpdate", "{\"T\":1669261797627,\"E\":1669261797628,\"su\":{\"si\":176054594,\"st\":\"GRID\",\"ss\":\"NEW\",\"s\":\"BTCUSDT\",\"ut\":1669261797627,\"c\":8007}}" },
        { "StrategyUpdateSu", "{\"si\":176054594,\"st\":\"GRID\",\"ss\":\"NEW\",\"s\":\"BTCUSDT\",\"ut\":1669261797627,\"c\":8007}" },
        { "TradeLite", "{\"E\":1721895408092,\"T\":1721895408214,\"s\":\"BTCUSDT\",\"q\":\"0.001\",\"p\":\"0\",\"m\":false,\"c\":\"z8hcUoOsqEdKMeKPSABslD\",\"S\":\"BUY\",\"L\":\"64089.20\",\"l\":\"0.040\",\"t\":109100866,\"i\":8886774}" },
        { "TradingSessionStreamResponse", "{\"e\":\"EquityUpdate\",\"E\":1765244143062,\"t\":1765242000000,\"T\":1765270800000,\"S\":\"OVERNIGHT\"}" },
        { "UserDataStreamEventsResponse/AccountConfigUpdate", "{\"E\":1611646737479,\"T\":1611646737476,\"ac\":{\"s\":\"BTCUSDT\",\"l\":25},\"ai\":{\"j\":true}}" },
        { "UserDataStreamEventsResponse/AccountUpdate", "{\"E\":1564745798939,\"T\":1564745798938,\"a\":{\"m\":\"ORDER\",\"B\":[{\"a\":\"USDT\",\"wb\":\"122624.12345678\",\"cw\":\"100.12345678\",\"bc\":\"50.12345678\"}],\"P\":[{\"s\":\"BTCUSDT\",\"pa\":\"0\",\"ep\":\"0.00000\",\"bep\":\"0\",\"cr\":\"200\",\"up\":\"0\",\"mt\":\"isolated\",\"iw\":\"0.00000000\",\"ps\":\"BOTH\"}],\"S\":\"BTCUSDT\"}}" },
        { "UserDataStreamEventsResponse/AlgoUpdate", "{\"T\":1750515742297,\"E\":1750515742303,\"o\":{\"caid\":\"Q5xaq5EGKgXXa0fD7fs0Ip\",\"aid\":2148719,\"at\":\"CONDITIONAL\",\"o\":\"TAKE_PROFIT\",\"s\":\"BNBUSDT\",\"S\":\"SELL\",\"ps\":\"BOTH\",\"f\":\"GTC\",\"q\":\"0.01\",\"X\":\"CANCELED\",\"ai\":\"x\",\"ap\":\"0.00000\",\"aq\":\"0.00000\",\"act\":\"0\",\"tp\":\"750\",\"p\":\"750\",\"V\":\"EXPIRE_MAKER\",\"wt\":\"CONTRACT_PRICE\",\"pm\":\"NONE\",\"cp\":false,\"pP\":false,\"R\":false,\"tt\":0,\"gtd\":0,\"rm\":\"Reduce Only reject\",\"ia\":false,\"spt\":\"ChaseRatio\",\"spv\":\"0.01\",\"splv\":\"0.01\"}}" },
        { "UserDataStreamEventsResponse/ConditionalOrderTriggerReject", "{\"E\":1685517224945,\"T\":1685517224955,\"or\":{\"s\":\"ETHUSDT\",\"i\":155618472834,\"r\":\"Due to the order could not be filled immediately, the FOK order has been rejected. The order will not be recorded in the order history\"}}" },
        { "UserDataStreamEventsResponse/GridUpdate", "{\"T\":1669262908216,\"E\":1669262908218,\"gu\":{\"si\":176057039,\"st\":\"GRID\",\"ss\":\"WORKING\",\"s\":\"BTCUSDT\",\"r\":\"-0.00300716\",\"up\":\"16720\",\"uq\":\"-0.001\",\"uf\":\"-0.00300716\",\"mp\":\"0.0\",\"ut\":1669262908197}}" },
        { "UserDataStreamEventsResponse/ListenKeyExpired", "{\"E\":1736996475556,\"listenKey\":\"WsCMN0a4KHUPTQuX6IUnqEZfB1inxmv1qR4kbf1LuEjur5VdbzqvyxqG9TSjVVxv\"}" },
        { "UserDataStreamEventsResponse/MarginCall", "{\"E\":1587727187525,\"cw\":\"3.16812045\",\"p\":[{\"s\":\"ETHUSDT\",\"ps\":\"LONG\",\"pa\":\"1.327\",\"mt\":\"CROSSED\",\"iw\":\"0\",\"mp\":\"187.17127\",\"up\":\"-1.166074\",\"mm\":\"1.614445\"}]}" },
        { "UserDataStreamEventsResponse/OrderTradeUpdate", "{\"E\":1568879465651,\"T\":1568879465650,\"o\":{\"s\":\"BTCUSDT\",\"c\":\"TEST\",\"S\":\"SELL\",\"o\":\"TRAILING_STOP_MARKET\",\"f\":\"GTC\",\"q\":\"0.001\",\"p\":\"0\",\"ap\":\"0\",\"sp\":\"7103.04\",\"x\":\"NEW\",\"X\":\"NEW\",\"i\":8886774,\"M\":\"44444\",\"l\":\"0\",\"z\":\"0\",\"L\":\"0\",\"N\":\"USDT\",\"n\":\"0\",\"T\":1568879465650,\"t\":0,\"b\":\"0\",\"a\":\"9.91\",\"m\":false,\"R\":false,\"wt\":\"CONTRACT_PRICE\",\"ot\":\"TRAILING_STOP_MARKET\",\"ps\":\"LONG\",\"cp\":false,\"AP\":\"7476.89\",\"cr\":\"5.0\",\"pP\":false,\"si\":0,\"ss\":0,\"rp\":\"0\",\"V\":\"EXPIRE_TAKER\",\"pm\":\"OPPONENT\",\"gtd\":0,\"er\":\"0\"}}" },
        { "UserDataStreamEventsResponse/StrategyUpdate", "{\"T\":1669261797627,\"E\":1669261797628,\"su\":{\"si\":176054594,\"st\":\"GRID\",\"ss\":\"NEW\",\"s\":\"BTCUSDT\",\"ut\":1669261797627,\"c\":8007}}" },
        { "UserDataStreamEventsResponse/TradeLite", "{\"E\":1721895408092,\"T\":1721895408214,\"s\":\"BTCUSDT\",\"q\":\"0.001\",\"p\":\"0\",\"m\":false,\"c\":\"z8hcUoOsqEdKMeKPSABslD\",\"S\":\"BUY\",\"L\":\"64089.20\",\"l\":\"0.040\",\"t\":109100866,\"i\":8886774}" },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void DecodesAndRoundTrips(string name, string json)
    {
        var assembly = typeof(DerivativesTradingUsdsFuturesWebSocketStreams).Assembly;
        var type = assembly.GetType($"Binance.DerivativesTradingUsdsFutures.WebSocketStreams.{name.Split('/')[0]}", throwOnError: true)!;
        var context = (JsonSerializerContext)assembly.GetType("Binance.DerivativesTradingUsdsFutures.WebSocketStreams.DerivativesTradingUsdsFuturesWebSocketStreamsJson")!.GetProperty("Default")!.GetValue(null)!;
        // A model that no operation returns is not in the serializer context, so it is decoded by reflection.
        var info = context.GetTypeInfo(type);
        var model = info is null ? JsonSerializer.Deserialize(json, type, Reflection) : JsonSerializer.Deserialize(json, info);
        ExampleAssert.Matches(json, model);
    }
}
