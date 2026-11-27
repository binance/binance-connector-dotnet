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
using Binance.DerivativesTradingCoinFutures.WebSocketStreams;

namespace Binance.DerivativesTradingCoinFutures.Tests.WebSocketStreams;

/// <summary>Decodes an instance of every model, built from its schema, with the serializer context of the module.</summary>
public class ModelTests
{
    private static readonly JsonSerializerOptions Reflection = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };

    public static TheoryData<string, string> Cases => new()
    {
        { "AccountConfigUpdate", "{\"E\":1611646737479,\"T\":1611646737476,\"ac\":{\"s\":\"BTCUSD_PERP\",\"l\":25}}" },
        { "AccountConfigUpdateAc", "{\"s\":\"BTCUSD_PERP\",\"l\":25}" },
        { "AccountUpdate", "{\"E\":1564745798939,\"T\":1564745798938,\"i\":\"SfsR\",\"a\":{\"m\":\"ORDER\",\"B\":[{\"a\":\"BTC\",\"wb\":\"122624.12345678\",\"cw\":\"100.12345678\",\"bc\":\"50.12345678\"}],\"P\":[{\"s\":\"BTCUSD_200925\",\"pa\":\"0\",\"ep\":\"0.0\",\"bep\":\"0.0\",\"cr\":\"200\",\"up\":\"0\",\"mt\":\"isolated\",\"iw\":\"0.00000000\",\"ps\":\"BOTH\"}],\"S\":\"BTCUSD_200925\"}}" },
        { "AccountUpdateA", "{\"m\":\"ORDER\",\"B\":[{\"a\":\"BTC\",\"wb\":\"122624.12345678\",\"cw\":\"100.12345678\",\"bc\":\"50.12345678\"}],\"P\":[{\"s\":\"BTCUSD_200925\",\"pa\":\"0\",\"ep\":\"0.0\",\"bep\":\"0.0\",\"cr\":\"200\",\"up\":\"0\",\"mt\":\"isolated\",\"iw\":\"0.00000000\",\"ps\":\"BOTH\"}],\"S\":\"BTCUSD_200925\"}" },
        { "AccountUpdateABInner", "{\"a\":\"BTC\",\"wb\":\"122624.12345678\",\"cw\":\"100.12345678\",\"bc\":\"50.12345678\"}" },
        { "AccountUpdateAPInner", "{\"s\":\"BTCUSD_200925\",\"pa\":\"0\",\"ep\":\"0.0\",\"bep\":\"0.0\",\"cr\":\"200\",\"up\":\"0\",\"mt\":\"isolated\",\"iw\":\"0.00000000\",\"ps\":\"BOTH\"}" },
        { "AggregateTradeStreamsResponse", "{\"e\":\"aggTrade\",\"E\":1591261134288,\"a\":424951,\"s\":\"BTCUSD_200626\",\"p\":\"9643.5\",\"q\":\"2\",\"f\":606073,\"l\":606073,\"T\":1591261134199,\"m\":false,\"st\":1}" },
        { "AlgoUpdate", "{\"T\":1750515742297,\"E\":1750515742303,\"o\":{\"caid\":\"Q5xaq5EGKgXXa0fD7fs0Ip\",\"aid\":2148719,\"at\":\"CONDITIONAL\",\"o\":\"TAKE_PROFIT\",\"s\":\"BTCUSD_PERP\",\"S\":\"SELL\",\"ps\":\"BOTH\",\"f\":\"GTC\",\"q\":\"0.01\",\"X\":\"CANCELED\",\"ai\":\"x\",\"ap\":\"0.00000\",\"aq\":\"0.00000\",\"act\":\"0\",\"tp\":\"750\",\"p\":\"750\",\"V\":\"EXPIRE_MAKER\",\"wt\":\"CONTRACT_PRICE\",\"pm\":\"NONE\",\"cp\":false,\"pP\":false,\"R\":false,\"tt\":0,\"gtd\":0,\"rm\":\"Reduce Only reject\",\"ia\":false,\"spt\":\"ChaseRatio\",\"spv\":\"0.01\",\"splv\":\"0.01\"}}" },
        { "AlgoUpdateO", "{\"caid\":\"Q5xaq5EGKgXXa0fD7fs0Ip\",\"aid\":2148719,\"at\":\"CONDITIONAL\",\"o\":\"TAKE_PROFIT\",\"s\":\"BTCUSD_PERP\",\"S\":\"SELL\",\"ps\":\"BOTH\",\"f\":\"GTC\",\"q\":\"0.01\",\"X\":\"CANCELED\",\"ai\":\"x\",\"ap\":\"0.00000\",\"aq\":\"0.00000\",\"act\":\"0\",\"tp\":\"750\",\"p\":\"750\",\"V\":\"EXPIRE_MAKER\",\"wt\":\"CONTRACT_PRICE\",\"pm\":\"NONE\",\"cp\":false,\"pP\":false,\"R\":false,\"tt\":0,\"gtd\":0,\"rm\":\"Reduce Only reject\",\"ia\":false,\"spt\":\"ChaseRatio\",\"spv\":\"0.01\",\"splv\":\"0.01\"}" },
        { "AllBookTickersStreamResponse", "{\"e\":\"bookTicker\",\"u\":17242169,\"s\":\"BTCUSD_200626\",\"b\":\"9548.1\",\"B\":\"52\",\"a\":\"9548.5\",\"A\":\"11\",\"T\":1591268628155,\"E\":1591268628166,\"ps\":\"BTCUSD\",\"st\":1}" },
        { "AllMarketLiquidationOrderStreamsResponse", "{\"e\":\"forceOrder\",\"E\":1591154240950,\"o\":{\"s\":\"BTCUSD_200925\",\"ps\":\"BTCUSD\",\"S\":\"SELL\",\"o\":\"LIMIT\",\"f\":\"IOC\",\"q\":\"1\",\"p\":\"9425.5\",\"ap\":\"9496.5\",\"X\":\"FILLED\",\"l\":\"1\",\"z\":\"1\",\"T\":1591154240949},\"st\":1}" },
        { "AllMarketLiquidationOrderStreamsResponseO", "{\"s\":\"BTCUSD_200925\",\"ps\":\"BTCUSD\",\"S\":\"SELL\",\"o\":\"LIMIT\",\"f\":\"IOC\",\"q\":\"1\",\"p\":\"9425.5\",\"ap\":\"9496.5\",\"X\":\"FILLED\",\"l\":\"1\",\"z\":\"1\",\"T\":1591154240949}" },
        { "AllMarketMiniTickersStreamResponseInner", "{\"e\":\"24hrMiniTicker\",\"E\":1591267704450,\"s\":\"BTCUSD_200626\",\"ps\":\"BTCUSD\",\"c\":\"9561.7\",\"o\":\"9580.9\",\"h\":\"10000.0\",\"l\":\"7000.0\",\"v\":\"487476\",\"q\":\"33264343847.22378500\",\"st\":1}" },
        { "AllMarketTickersStreamsResponseInner", "{\"e\":\"24hrTicker\",\"E\":1591268262453,\"s\":\"BTCUSD_200626\",\"p\":\"-43.4\",\"P\":\"-0.452\",\"w\":\"0.00147974\",\"c\":\"9548.5\",\"Q\":\"2\",\"o\":\"9591.9\",\"h\":\"10000.0\",\"l\":\"7000.0\",\"v\":\"487850\",\"q\":\"32968676323.46222700\",\"O\":1591181820000,\"C\":1591268262442,\"F\":512014,\"L\":615289,\"n\":103272,\"ps\":\"BTCUSD\",\"st\":1}" },
        { "ConditionalOrderTriggerReject", "{\"E\":1685517224945,\"T\":1685517224955,\"or\":{\"s\":\"BTCUSD_PERP\",\"i\":155618472834,\"r\":\"Due to the order could not be filled immediately, the FOK order has been rejected. The order will not be recorded in the order history\"}}" },
        { "ConditionalOrderTriggerRejectOr", "{\"s\":\"BTCUSD_PERP\",\"i\":155618472834,\"r\":\"Due to the order could not be filled immediately, the FOK order has been rejected. The order will not be recorded in the order history\"}" },
        { "ContinuousContractKlineCandlestickStreamsResponse", "{\"e\":\"continuous_kline\",\"E\":1591261542539,\"ps\":\"BTCUSD\",\"ct\":\"NEXT_QUARTER\",\"k\":{\"t\":1591261500000,\"T\":1591261559999,\"i\":\"1m\",\"f\":606400,\"L\":606430,\"o\":\"9638.9\",\"c\":\"9639.8\",\"h\":\"9639.8\",\"l\":\"9638.6\",\"v\":\"156\",\"n\":31,\"x\":false,\"q\":\"1.61836886\",\"V\":\"73\",\"Q\":\"0.75731156\",\"B\":\"0\"}}" },
        { "ContinuousContractKlineCandlestickStreamsResponseK", "{\"t\":1591261500000,\"T\":1591261559999,\"i\":\"1m\",\"f\":606400,\"L\":606430,\"o\":\"9638.9\",\"c\":\"9639.8\",\"h\":\"9639.8\",\"l\":\"9638.6\",\"v\":\"156\",\"n\":31,\"x\":false,\"q\":\"1.61836886\",\"V\":\"73\",\"Q\":\"0.75731156\",\"B\":\"0\"}" },
        { "ContractInfoStreamResponse", "{\"e\":\"contractInfo\",\"E\":1669647330375,\"s\":\"APTUSD_PERP\",\"ps\":\"APTUSD\",\"ct\":\"PERPETUAL\",\"dt\":4133404800000,\"ot\":1666594800000,\"cs\":\"TRADING\",\"bks\":[{\"bs\":1,\"bnf\":0,\"bnc\":500000,\"mmr\":0.0065,\"cf\":75,\"mi\":51,\"ma\":75}],\"st\":1}" },
        { "ContractInfoStreamResponseBksInner", "{\"bs\":1,\"bnf\":0,\"bnc\":500000,\"mmr\":0.0065,\"cf\":75,\"mi\":51,\"ma\":75}" },
        { "DiffBookDepthStreamsResponse", "{\"e\":\"depthUpdate\",\"E\":1591270260907,\"T\":1591270260891,\"s\":\"BTCUSD_200626\",\"ps\":\"BTCUSD\",\"U\":17285681,\"u\":17285702,\"pu\":17285675,\"b\":[[\"x\"]],\"a\":[[\"x\"]],\"st\":1}" },
        { "GridUpdate", "{\"T\":1669262908216,\"E\":1669262908218,\"gu\":{\"si\":176057039,\"st\":\"GRID\",\"ss\":\"WORKING\",\"s\":\"BTCUSDT\",\"r\":\"-0.00300716\",\"up\":\"16720\",\"uq\":\"-0.001\",\"uf\":\"-0.00300716\",\"mp\":\"0.0\",\"ut\":1669262908197}}" },
        { "GridUpdateGu", "{\"si\":176057039,\"st\":\"GRID\",\"ss\":\"WORKING\",\"s\":\"BTCUSDT\",\"r\":\"-0.00300716\",\"up\":\"16720\",\"uq\":\"-0.001\",\"uf\":\"-0.00300716\",\"mp\":\"0.0\",\"ut\":1669262908197}" },
        { "IndexKlineCandlestickStreamsResponse", "{\"e\":\"indexPrice_kline\",\"E\":1591267070033,\"ps\":\"BTCUSD\",\"k\":{\"t\":1591267020000,\"T\":1591267079999,\"s\":\"0\",\"i\":\"1m\",\"f\":1591267020000,\"L\":1591267070000,\"o\":\"9542.21900000\",\"c\":\"9542.50440000\",\"h\":\"9542.71640000\",\"l\":\"9542.21040000\",\"v\":\"0\",\"n\":51,\"x\":false,\"q\":\"0\",\"V\":\"0\",\"Q\":\"0\",\"B\":\"0\"}}" },
        { "IndexKlineCandlestickStreamsResponseK", "{\"t\":1591267020000,\"T\":1591267079999,\"s\":\"0\",\"i\":\"1m\",\"f\":1591267020000,\"L\":1591267070000,\"o\":\"9542.21900000\",\"c\":\"9542.50440000\",\"h\":\"9542.71640000\",\"l\":\"9542.21040000\",\"v\":\"0\",\"n\":51,\"x\":false,\"q\":\"0\",\"V\":\"0\",\"Q\":\"0\",\"B\":\"0\"}" },
        { "IndexPriceStreamResponse", "{\"e\":\"indexPriceUpdate\",\"E\":1591261236000,\"i\":\"BTCUSD\",\"p\":\"9636.57860000\"}" },
        { "IndividualSymbolBookTickerStreamsResponse", "{\"e\":\"bookTicker\",\"u\":17242169,\"s\":\"BTCUSD_200626\",\"b\":\"9548.1\",\"B\":\"52\",\"a\":\"9548.5\",\"A\":\"11\",\"T\":1591268628155,\"E\":1591268628166,\"ps\":\"BTCUSD\",\"st\":2}" },
        { "IndividualSymbolMiniTickerStreamResponse", "{\"e\":\"24hrMiniTicker\",\"E\":1591267704450,\"s\":\"BTCUSD_200626\",\"ps\":\"BTCUSD\",\"c\":\"9561.7\",\"o\":\"9580.9\",\"h\":\"10000.0\",\"l\":\"7000.0\",\"v\":\"487476\",\"q\":\"33264343847.22378500\",\"st\":1}" },
        { "IndividualSymbolTickerStreamsResponse", "{\"e\":\"24hrTicker\",\"E\":1591268262453,\"s\":\"BTCUSD_200626\",\"p\":\"-43.4\",\"P\":\"-0.452\",\"w\":\"0.00147974\",\"c\":\"9548.5\",\"Q\":\"2\",\"o\":\"9591.9\",\"h\":\"10000.0\",\"l\":\"7000.0\",\"v\":\"487850\",\"q\":\"32968676323.46222700\",\"O\":1591181820000,\"C\":1591268262442,\"F\":512014,\"L\":615289,\"n\":103272,\"ps\":\"BTCUSD\",\"st\":1}" },
        { "KlineCandlestickStreamsResponse", "{\"e\":\"kline\",\"E\":1591261542539,\"s\":\"BTCUSD_200626\",\"k\":{\"t\":1591261500000,\"T\":1591261559999,\"s\":\"BTCUSD_200626\",\"i\":\"1m\",\"f\":606400,\"L\":606430,\"o\":\"9638.9\",\"c\":\"9639.8\",\"h\":\"9639.8\",\"l\":\"9638.6\",\"v\":\"156\",\"n\":31,\"x\":false,\"q\":\"1.61836886\",\"V\":\"73\",\"Q\":\"0.75731156\",\"B\":\"0\"}}" },
        { "KlineCandlestickStreamsResponseK", "{\"t\":1591261500000,\"T\":1591261559999,\"s\":\"BTCUSD_200626\",\"i\":\"1m\",\"f\":606400,\"L\":606430,\"o\":\"9638.9\",\"c\":\"9639.8\",\"h\":\"9639.8\",\"l\":\"9638.6\",\"v\":\"156\",\"n\":31,\"x\":false,\"q\":\"1.61836886\",\"V\":\"73\",\"Q\":\"0.75731156\",\"B\":\"0\"}" },
        { "ListenKeyExpired", "{\"E\":1576653824250,\"listenKey\":\"WsCMN0a4KHUPTQuX6IUnqEZfB1inxmv1qR4kbf1LuEjur5VdbzqvyxqG9TSjVVxv\"}" },
        { "MarginCall", "{\"E\":1587727187525,\"i\":\"SfsR\",\"cw\":\"3.16812045\",\"p\":[{\"s\":\"BTCUSD_200925\",\"ps\":\"LONG\",\"pa\":\"132\",\"mt\":\"CROSSED\",\"iw\":\"0\",\"mp\":\"9187.17127000\",\"up\":\"-1.166074\",\"mm\":\"1.614445\"}]}" },
        { "MarginCallPInner", "{\"s\":\"BTCUSD_200925\",\"ps\":\"LONG\",\"pa\":\"132\",\"mt\":\"CROSSED\",\"iw\":\"0\",\"mp\":\"9187.17127000\",\"up\":\"-1.166074\",\"mm\":\"1.614445\"}" },
        { "MarkPriceKlineCandlestickStreamsResponse", "{\"e\":\"markPrice_kline\",\"E\":1591267398004,\"ps\":\"BTCUSD\",\"k\":{\"t\":1591267380000,\"T\":1591267439999,\"s\":\"BTCUSD_200626\",\"i\":\"1m\",\"f\":1591267380000,\"L\":1591267398000,\"o\":\"9539.67161333\",\"c\":\"9540.82761333\",\"h\":\"9540.82761333\",\"l\":\"9539.66961333\",\"v\":\"0\",\"n\":19,\"x\":false,\"q\":\"0\",\"V\":\"0\",\"Q\":\"0\",\"B\":\"0\"}}" },
        { "MarkPriceKlineCandlestickStreamsResponseK", "{\"t\":1591267380000,\"T\":1591267439999,\"s\":\"BTCUSD_200626\",\"i\":\"1m\",\"f\":1591267380000,\"L\":1591267398000,\"o\":\"9539.67161333\",\"c\":\"9540.82761333\",\"h\":\"9540.82761333\",\"l\":\"9539.66961333\",\"v\":\"0\",\"n\":19,\"x\":false,\"q\":\"0\",\"V\":\"0\",\"Q\":\"0\",\"B\":\"0\"}" },
        { "MarkPriceOfAllSymbolsOfAPairResponseInner", "{\"e\":\"markPriceUpdate\",\"E\":1596095725000,\"s\":\"BTCUSD_201225\",\"p\":\"10934.62615417\",\"P\":\"10962.17178236\",\"i\":\"10933.62615417\",\"r\":\"x\",\"T\":0,\"st\":1}" },
        { "MarkPriceStreamResponse", "{\"e\":\"markPriceUpdate\",\"E\":1596095725000,\"s\":\"BTCUSD_201225\",\"p\":\"10934.62615417\",\"P\":\"10962.17178236\",\"i\":\"10933.62615417\",\"r\":\"x\",\"T\":0,\"st\":1}" },
        { "MarketLiquidationOrderStreamsResponse", "{\"e\":\"forceOrder\",\"E\":1591154240950,\"o\":{\"s\":\"BTCUSD_200925\",\"ps\":\"BTCUSD\",\"S\":\"SELL\",\"o\":\"LIMIT\",\"f\":\"IOC\",\"q\":\"1\",\"p\":\"9425.5\",\"ap\":\"9496.5\",\"X\":\"FILLED\",\"l\":\"1\",\"z\":\"1\",\"T\":1591154240949}}" },
        { "OrderTradeUpdate", "{\"E\":1591274595442,\"T\":1591274595442,\"i\":\"SfsR\",\"o\":{\"s\":\"BTCUSD_200925\",\"c\":\"TEST\",\"S\":\"SELL\",\"o\":\"TRAILING_STOP_MARKET\",\"f\":\"GTC\",\"q\":\"2\",\"p\":\"0\",\"ap\":\"0\",\"sp\":\"9103.1\",\"x\":\"NEW\",\"X\":\"NEW\",\"i\":8888888,\"M\":\"44444\",\"l\":\"0\",\"z\":\"0\",\"L\":\"0\",\"ma\":\"BTC\",\"N\":\"BTC\",\"n\":\"0\",\"T\":1591274595442,\"t\":0,\"rp\":\"0\",\"b\":\"0\",\"a\":\"0\",\"m\":false,\"R\":false,\"wt\":\"CONTRACT_PRICE\",\"ot\":\"TRAILING_STOP_MARKET\",\"ps\":\"LONG\",\"cp\":false,\"AP\":\"9476.8\",\"cr\":\"5.0\",\"pP\":false,\"V\":\"EXPIRE_TAKER\",\"pm\":\"OPPONENT\",\"er\":\"0\"}}" },
        { "OrderTradeUpdateO", "{\"s\":\"BTCUSD_200925\",\"c\":\"TEST\",\"S\":\"SELL\",\"o\":\"TRAILING_STOP_MARKET\",\"f\":\"GTC\",\"q\":\"2\",\"p\":\"0\",\"ap\":\"0\",\"sp\":\"9103.1\",\"x\":\"NEW\",\"X\":\"NEW\",\"i\":8888888,\"M\":\"44444\",\"l\":\"0\",\"z\":\"0\",\"L\":\"0\",\"ma\":\"BTC\",\"N\":\"BTC\",\"n\":\"0\",\"T\":1591274595442,\"t\":0,\"rp\":\"0\",\"b\":\"0\",\"a\":\"0\",\"m\":false,\"R\":false,\"wt\":\"CONTRACT_PRICE\",\"ot\":\"TRAILING_STOP_MARKET\",\"ps\":\"LONG\",\"cp\":false,\"AP\":\"9476.8\",\"cr\":\"5.0\",\"pP\":false,\"V\":\"EXPIRE_TAKER\",\"pm\":\"OPPONENT\",\"er\":\"0\"}" },
        { "PartialBookDepthStreamsResponse", "{\"e\":\"depthUpdate\",\"E\":1591269996801,\"T\":1591269996646,\"s\":\"BTCUSD_200626\",\"ps\":\"BTCUSD\",\"U\":17276694,\"u\":17276701,\"pu\":17276678,\"b\":[[\"x\"]],\"a\":[[\"x\"]],\"st\":1}" },
        { "StrategyUpdate", "{\"T\":1669261797627,\"E\":1669261797628,\"su\":{\"si\":176054594,\"st\":\"GRID\",\"ss\":\"NEW\",\"s\":\"BTCUSDT\",\"ut\":1669261797627,\"c\":8007}}" },
        { "StrategyUpdateSu", "{\"si\":176054594,\"st\":\"GRID\",\"ss\":\"NEW\",\"s\":\"BTCUSDT\",\"ut\":1669261797627,\"c\":8007}" },
        { "UserDataStreamEventsResponse/AccountConfigUpdate", "{\"E\":1611646737479,\"T\":1611646737476,\"ac\":{\"s\":\"BTCUSD_PERP\",\"l\":25}}" },
        { "UserDataStreamEventsResponse/AccountUpdate", "{\"E\":1564745798939,\"T\":1564745798938,\"i\":\"SfsR\",\"a\":{\"m\":\"ORDER\",\"B\":[{\"a\":\"BTC\",\"wb\":\"122624.12345678\",\"cw\":\"100.12345678\",\"bc\":\"50.12345678\"}],\"P\":[{\"s\":\"BTCUSD_200925\",\"pa\":\"0\",\"ep\":\"0.0\",\"bep\":\"0.0\",\"cr\":\"200\",\"up\":\"0\",\"mt\":\"isolated\",\"iw\":\"0.00000000\",\"ps\":\"BOTH\"}],\"S\":\"BTCUSD_200925\"}}" },
        { "UserDataStreamEventsResponse/AlgoUpdate", "{\"T\":1750515742297,\"E\":1750515742303,\"o\":{\"caid\":\"Q5xaq5EGKgXXa0fD7fs0Ip\",\"aid\":2148719,\"at\":\"CONDITIONAL\",\"o\":\"TAKE_PROFIT\",\"s\":\"BTCUSD_PERP\",\"S\":\"SELL\",\"ps\":\"BOTH\",\"f\":\"GTC\",\"q\":\"0.01\",\"X\":\"CANCELED\",\"ai\":\"x\",\"ap\":\"0.00000\",\"aq\":\"0.00000\",\"act\":\"0\",\"tp\":\"750\",\"p\":\"750\",\"V\":\"EXPIRE_MAKER\",\"wt\":\"CONTRACT_PRICE\",\"pm\":\"NONE\",\"cp\":false,\"pP\":false,\"R\":false,\"tt\":0,\"gtd\":0,\"rm\":\"Reduce Only reject\",\"ia\":false,\"spt\":\"ChaseRatio\",\"spv\":\"0.01\",\"splv\":\"0.01\"}}" },
        { "UserDataStreamEventsResponse/ConditionalOrderTriggerReject", "{\"E\":1685517224945,\"T\":1685517224955,\"or\":{\"s\":\"BTCUSD_PERP\",\"i\":155618472834,\"r\":\"Due to the order could not be filled immediately, the FOK order has been rejected. The order will not be recorded in the order history\"}}" },
        { "UserDataStreamEventsResponse/GridUpdate", "{\"T\":1669262908216,\"E\":1669262908218,\"gu\":{\"si\":176057039,\"st\":\"GRID\",\"ss\":\"WORKING\",\"s\":\"BTCUSDT\",\"r\":\"-0.00300716\",\"up\":\"16720\",\"uq\":\"-0.001\",\"uf\":\"-0.00300716\",\"mp\":\"0.0\",\"ut\":1669262908197}}" },
        { "UserDataStreamEventsResponse/ListenKeyExpired", "{\"E\":1576653824250,\"listenKey\":\"WsCMN0a4KHUPTQuX6IUnqEZfB1inxmv1qR4kbf1LuEjur5VdbzqvyxqG9TSjVVxv\"}" },
        { "UserDataStreamEventsResponse/MarginCall", "{\"E\":1587727187525,\"i\":\"SfsR\",\"cw\":\"3.16812045\",\"p\":[{\"s\":\"BTCUSD_200925\",\"ps\":\"LONG\",\"pa\":\"132\",\"mt\":\"CROSSED\",\"iw\":\"0\",\"mp\":\"9187.17127000\",\"up\":\"-1.166074\",\"mm\":\"1.614445\"}]}" },
        { "UserDataStreamEventsResponse/OrderTradeUpdate", "{\"E\":1591274595442,\"T\":1591274595442,\"i\":\"SfsR\",\"o\":{\"s\":\"BTCUSD_200925\",\"c\":\"TEST\",\"S\":\"SELL\",\"o\":\"TRAILING_STOP_MARKET\",\"f\":\"GTC\",\"q\":\"2\",\"p\":\"0\",\"ap\":\"0\",\"sp\":\"9103.1\",\"x\":\"NEW\",\"X\":\"NEW\",\"i\":8888888,\"M\":\"44444\",\"l\":\"0\",\"z\":\"0\",\"L\":\"0\",\"ma\":\"BTC\",\"N\":\"BTC\",\"n\":\"0\",\"T\":1591274595442,\"t\":0,\"rp\":\"0\",\"b\":\"0\",\"a\":\"0\",\"m\":false,\"R\":false,\"wt\":\"CONTRACT_PRICE\",\"ot\":\"TRAILING_STOP_MARKET\",\"ps\":\"LONG\",\"cp\":false,\"AP\":\"9476.8\",\"cr\":\"5.0\",\"pP\":false,\"V\":\"EXPIRE_TAKER\",\"pm\":\"OPPONENT\",\"er\":\"0\"}}" },
        { "UserDataStreamEventsResponse/StrategyUpdate", "{\"T\":1669261797627,\"E\":1669261797628,\"su\":{\"si\":176054594,\"st\":\"GRID\",\"ss\":\"NEW\",\"s\":\"BTCUSDT\",\"ut\":1669261797627,\"c\":8007}}" },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void DecodesAndRoundTrips(string name, string json)
    {
        var assembly = typeof(DerivativesTradingCoinFuturesWebSocketStreams).Assembly;
        var type = assembly.GetType($"Binance.DerivativesTradingCoinFutures.WebSocketStreams.{name.Split('/')[0]}", throwOnError: true)!;
        var context = (JsonSerializerContext)assembly.GetType("Binance.DerivativesTradingCoinFutures.WebSocketStreams.DerivativesTradingCoinFuturesWebSocketStreamsJson")!.GetProperty("Default")!.GetValue(null)!;
        // A model that no operation returns is not in the serializer context, so it is decoded by reflection.
        var info = context.GetTypeInfo(type);
        var model = info is null ? JsonSerializer.Deserialize(json, type, Reflection) : JsonSerializer.Deserialize(json, info);
        ExampleAssert.Matches(json, model);
    }
}
