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
using Binance.Spot.WebSocketStreams;

namespace Binance.Spot.Tests.WebSocketStreams;

/// <summary>Decodes an instance of every model, built from its schema, with the serializer context of the module.</summary>
public class ModelTests
{
    private static readonly JsonSerializerOptions Reflection = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };

    public static TheoryData<string, string> Cases => new()
    {
        { "AggTradeResponse", "{\"e\":\"aggTrade\",\"E\":1672515782136,\"s\":\"BNBBTC\",\"a\":12345,\"p\":\"0.001\",\"q\":\"100\",\"f\":100,\"l\":105,\"T\":1672515782136,\"m\":true,\"M\":true}" },
        { "AllMarketRollingWindowTickerResponseInner", "{\"e\":\"1hTicker\",\"E\":1672515782136,\"s\":\"BNBBTC\",\"p\":\"0.0015\",\"P\":\"250.00\",\"o\":\"0.0010\",\"h\":\"0.0025\",\"l\":\"0.0010\",\"c\":\"0.0025\",\"w\":\"0.0018\",\"v\":\"10000\",\"q\":\"18\",\"O\":0,\"C\":1675216573749,\"F\":0,\"L\":18150,\"n\":18151}" },
        { "AllMiniTickerResponseInner", "{\"e\":\"24hrMiniTicker\",\"E\":1672515782136,\"s\":\"BNBBTC\",\"c\":\"0.0025\",\"o\":\"0.0010\",\"h\":\"0.0025\",\"l\":\"0.0010\",\"v\":\"10000\",\"q\":\"18\"}" },
        { "AvgPriceResponse", "{\"e\":\"avgPrice\",\"E\":1693907033000,\"s\":\"BTCUSDT\",\"i\":\"5m\",\"w\":\"25776.86000000\",\"T\":1693907032213}" },
        { "BalanceUpdate", "{\"E\":1573200697110,\"a\":\"BTC\",\"d\":\"100.00000000\",\"T\":1573200697068}" },
        { "BlockTradeResponse", "{\"e\":\"blockTrade\",\"E\":1772506983582,\"s\":\"BNBBTC\",\"t\":582,\"p\":\"0.052\",\"q\":\"5838\",\"T\":1772506983321,\"m\":true}" },
        { "BookTickerResponse", "{\"u\":400900217,\"s\":\"BNBUSDT\",\"b\":\"25.35190000\",\"B\":\"31.21000000\",\"a\":\"25.36520000\",\"A\":\"40.66000000\"}" },
        { "DiffBookDepthResponse", "{\"e\":\"depthUpdate\",\"E\":1672515782136,\"s\":\"BNBBTC\",\"U\":157,\"u\":160,\"b\":[[\"x\"]],\"a\":[[\"x\"]]}" },
        { "EventStreamTerminated", "{\"E\":1728973001334}" },
        { "ExecutionReport", "{\"E\":1499405658658,\"s\":\"ETHBTC\",\"c\":\"mUvoqJxFIILMdfAW5iGSOW\",\"S\":\"BUY\",\"o\":\"LIMIT\",\"f\":\"GTC\",\"q\":\"1.00000000\",\"p\":\"0.10264410\",\"P\":\"0.00000000\",\"F\":\"0.00000000\",\"g\":-1,\"C\":\"x\",\"x\":\"NEW\",\"X\":\"NEW\",\"r\":\"NONE\",\"i\":4293153,\"l\":\"0.00000000\",\"z\":\"0.00000000\",\"L\":\"0.00000000\",\"n\":\"0\",\"N\":\"N\",\"T\":1499405658657,\"t\":-1,\"v\":3,\"I\":8641984,\"w\":true,\"m\":false,\"M\":false,\"O\":1499405658657,\"Z\":\"0.00000000\",\"Y\":\"0.00000000\",\"Q\":\"0.00000000\",\"W\":1499405658657,\"V\":\"NONE\",\"d\":4,\"D\":1668680518494,\"j\":1,\"J\":1000000,\"A\":\"3.000000\",\"B\":\"3.000000\",\"u\":1,\"U\":37,\"Cs\":\"BTCUSDT\",\"pl\":\"2.123456\",\"pL\":\"0.10000001\",\"pY\":\"0.21234562\",\"Qq\":\"90.00000000\",\"eV\":\"DECREMENT\",\"b\":\"ONE_PARTY_TRADE_REPORT\",\"a\":1234,\"k\":\"SOR\",\"uS\":true,\"gP\":\"PRIMARY_PEG\",\"gOT\":\"PRICE_LEVEL\",\"gOV\":5,\"gp\":\"1.00000000\",\"eR\":\"INSUFFICIENT_LIQUIDITY\"}" },
        { "ExternalLockUpdate", "{\"E\":1581557507324,\"a\":\"NEO\",\"d\":\"10.00000000\",\"T\":1581557507268}" },
        { "KlineOffsetResponse", "{\"e\":\"kline\",\"E\":1672515782136,\"s\":\"BNBBTC\",\"k\":{\"t\":1672515780000,\"T\":1672515839999,\"s\":\"BNBBTC\",\"i\":\"1m\",\"f\":100,\"L\":200,\"o\":\"0.0010\",\"c\":\"0.0020\",\"h\":\"0.0025\",\"l\":\"0.0015\",\"v\":\"1000\",\"n\":100,\"x\":false,\"q\":\"1.0000\",\"V\":\"500\",\"Q\":\"0.500\",\"B\":\"123456\"}}" },
        { "KlineResponse", "{\"e\":\"kline\",\"E\":1672515782136,\"s\":\"BNBBTC\",\"k\":{\"t\":1672515780000,\"T\":1672515839999,\"s\":\"BNBBTC\",\"i\":\"1m\",\"f\":100,\"L\":200,\"o\":\"0.0010\",\"c\":\"0.0020\",\"h\":\"0.0025\",\"l\":\"0.0015\",\"v\":\"1000\",\"n\":100,\"x\":false,\"q\":\"1.0000\",\"V\":\"500\",\"Q\":\"0.500\",\"B\":\"123456\"}}" },
        { "KlineResponseK", "{\"t\":1672515780000,\"T\":1672515839999,\"s\":\"BNBBTC\",\"i\":\"1m\",\"f\":100,\"L\":200,\"o\":\"0.0010\",\"c\":\"0.0020\",\"h\":\"0.0025\",\"l\":\"0.0015\",\"v\":\"1000\",\"n\":100,\"x\":false,\"q\":\"1.0000\",\"V\":\"500\",\"Q\":\"0.500\",\"B\":\"123456\"}" },
        { "ListStatus", "{\"E\":1564035303637,\"s\":\"ETHBTC\",\"g\":2,\"c\":\"OCO\",\"l\":\"EXEC_STARTED\",\"L\":\"EXECUTING\",\"r\":\"NONE\",\"C\":\"F4QN4G8DlFATFlIUQ0cjdD\",\"T\":1564035303625,\"O\":[{\"s\":\"ETHBTC\",\"i\":17,\"c\":\"AJYsMjErWJesZvqlJCTUgL\"}]}" },
        { "ListStatusOInner", "{\"s\":\"ETHBTC\",\"i\":17,\"c\":\"AJYsMjErWJesZvqlJCTUgL\"}" },
        { "MiniTickerResponse", "{\"e\":\"24hrMiniTicker\",\"E\":1672515782136,\"s\":\"BNBBTC\",\"c\":\"0.0025\",\"o\":\"0.0010\",\"h\":\"0.0025\",\"l\":\"0.0010\",\"v\":\"10000\",\"q\":\"18\"}" },
        { "OutboundAccountPosition", "{\"E\":1564034571105,\"u\":1564034571073,\"B\":[{\"a\":\"ETH\",\"f\":\"10000.000000\",\"l\":\"0.000000\"}]}" },
        { "OutboundAccountPositionBInner", "{\"a\":\"ETH\",\"f\":\"10000.000000\",\"l\":\"0.000000\"}" },
        { "PartialBookDepthResponse", "{\"lastUpdateId\":160,\"bids\":[[\"x\"]],\"asks\":[[\"x\"]]}" },
        { "ReferencePriceResponse", "{\"e\":\"referencePrice\",\"s\":\"BAZUSD\",\"r\":\"1.00\",\"t\":1770313263917}" },
        { "RollingWindowTickerResponse", "{\"e\":\"1hTicker\",\"E\":1672515782136,\"s\":\"BNBBTC\",\"p\":\"0.0015\",\"P\":\"250.00\",\"o\":\"0.0010\",\"h\":\"0.0025\",\"l\":\"0.0010\",\"c\":\"0.0025\",\"w\":\"0.0018\",\"v\":\"10000\",\"q\":\"18\",\"O\":0,\"C\":1675216573749,\"F\":0,\"L\":18150,\"n\":18151}" },
        { "TickerResponse", "{\"e\":\"24hrTicker\",\"E\":1672515782136,\"s\":\"BNBBTC\",\"p\":\"0.0015\",\"P\":\"250.00\",\"w\":\"0.0018\",\"x\":\"0.0009\",\"c\":\"0.0025\",\"Q\":\"10\",\"b\":\"0.0024\",\"B\":\"10\",\"a\":\"0.0026\",\"A\":\"100\",\"o\":\"0.0010\",\"h\":\"0.0025\",\"l\":\"0.0010\",\"v\":\"10000\",\"q\":\"18\",\"O\":0,\"C\":1675216573749,\"F\":0,\"L\":18150,\"n\":18151}" },
        { "TradeResponse", "{\"e\":\"trade\",\"E\":1672515782136,\"s\":\"BNBBTC\",\"t\":12345,\"p\":\"0.001\",\"q\":\"100\",\"T\":1672515782136,\"m\":true,\"M\":true}" },
        { "UserDataStreamEventsResponse/BalanceUpdate", "{\"E\":1573200697110,\"a\":\"BTC\",\"d\":\"100.00000000\",\"T\":1573200697068}" },
        { "UserDataStreamEventsResponse/EventStreamTerminated", "{\"E\":1728973001334}" },
        { "UserDataStreamEventsResponse/ExecutionReport", "{\"E\":1499405658658,\"s\":\"ETHBTC\",\"c\":\"mUvoqJxFIILMdfAW5iGSOW\",\"S\":\"BUY\",\"o\":\"LIMIT\",\"f\":\"GTC\",\"q\":\"1.00000000\",\"p\":\"0.10264410\",\"P\":\"0.00000000\",\"F\":\"0.00000000\",\"g\":-1,\"C\":\"x\",\"x\":\"NEW\",\"X\":\"NEW\",\"r\":\"NONE\",\"i\":4293153,\"l\":\"0.00000000\",\"z\":\"0.00000000\",\"L\":\"0.00000000\",\"n\":\"0\",\"N\":\"N\",\"T\":1499405658657,\"t\":-1,\"v\":3,\"I\":8641984,\"w\":true,\"m\":false,\"M\":false,\"O\":1499405658657,\"Z\":\"0.00000000\",\"Y\":\"0.00000000\",\"Q\":\"0.00000000\",\"W\":1499405658657,\"V\":\"NONE\",\"d\":4,\"D\":1668680518494,\"j\":1,\"J\":1000000,\"A\":\"3.000000\",\"B\":\"3.000000\",\"u\":1,\"U\":37,\"Cs\":\"BTCUSDT\",\"pl\":\"2.123456\",\"pL\":\"0.10000001\",\"pY\":\"0.21234562\",\"Qq\":\"90.00000000\",\"eV\":\"DECREMENT\",\"b\":\"ONE_PARTY_TRADE_REPORT\",\"a\":1234,\"k\":\"SOR\",\"uS\":true,\"gP\":\"PRIMARY_PEG\",\"gOT\":\"PRICE_LEVEL\",\"gOV\":5,\"gp\":\"1.00000000\",\"eR\":\"INSUFFICIENT_LIQUIDITY\"}" },
        { "UserDataStreamEventsResponse/ExternalLockUpdate", "{\"E\":1581557507324,\"a\":\"NEO\",\"d\":\"10.00000000\",\"T\":1581557507268}" },
        { "UserDataStreamEventsResponse/ListStatus", "{\"E\":1564035303637,\"s\":\"ETHBTC\",\"g\":2,\"c\":\"OCO\",\"l\":\"EXEC_STARTED\",\"L\":\"EXECUTING\",\"r\":\"NONE\",\"C\":\"F4QN4G8DlFATFlIUQ0cjdD\",\"T\":1564035303625,\"O\":[{\"s\":\"ETHBTC\",\"i\":17,\"c\":\"AJYsMjErWJesZvqlJCTUgL\"}]}" },
        { "UserDataStreamEventsResponse/OutboundAccountPosition", "{\"E\":1564034571105,\"u\":1564034571073,\"B\":[{\"a\":\"ETH\",\"f\":\"10000.000000\",\"l\":\"0.000000\"}]}" },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void DecodesAndRoundTrips(string name, string json)
    {
        var assembly = typeof(SpotWebSocketStreams).Assembly;
        var type = assembly.GetType($"Binance.Spot.WebSocketStreams.{name.Split('/')[0]}", throwOnError: true)!;
        var context = (JsonSerializerContext)assembly.GetType("Binance.Spot.WebSocketStreams.SpotWebSocketStreamsJson")!.GetProperty("Default")!.GetValue(null)!;
        // A model that no operation returns is not in the serializer context, so it is decoded by reflection.
        var info = context.GetTypeInfo(type);
        var model = info is null ? JsonSerializer.Deserialize(json, type, Reflection) : JsonSerializer.Deserialize(json, info);
        ExampleAssert.Matches(json, model);
    }
}
