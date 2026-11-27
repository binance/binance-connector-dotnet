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
using Binance.Alpha.WebSocketStreams;

namespace Binance.Alpha.Tests.WebSocketStreams;

/// <summary>Decodes an instance of every model, built from its schema, with the serializer context of the module.</summary>
public class ModelTests
{
    private static readonly JsonSerializerOptions Reflection = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };

    public static TheoryData<string, string> Cases => new()
    {
        { "AggregateTradeStreamResponse", "{\"e\":\"aggTrade\",\"E\":1771828569861,\"T\":1771828569702,\"a\":2684294,\"f\":2684294,\"l\":2684294,\"m\":false,\"p\":\"0.08530000\",\"q\":\"879.24000000\",\"s\":\"ALPHA_474USDT\"}" },
        { "AllBookTickerStreamResponse", "{\"e\":\"bookTicker\",\"E\":1773108379067,\"T\":1773108379054,\"u\":6663207693,\"s\":\"ALPHA_116USDT\",\"b\":\"8.30000000\",\"B\":\"0.91076900\",\"a\":\"9.30000000\",\"A\":\"2.00353200\"}" },
        { "AllMiniTickerStreamResponse", "{\"e\":\"24hrMiniTicker\",\"E\":1773109449908,\"s\":\"ALPHA_116USDT\",\"c\":\"8.40000000\",\"o\":\"8.40000000\",\"h\":\"8.50000000\",\"l\":\"8.30000000\",\"v\":\"64739.03978900\",\"q\":\"543810.36005090\"}" },
        { "AllTickerStreamResponse", "{\"e\":\"24hrTicker\",\"E\":1773109631569,\"s\":\"ALPHA_116USDT\",\"p\":\"0.00000000\",\"P\":\"0.00\",\"w\":\"8.40003127\",\"c\":\"8.40000000\",\"Q\":\"0.49293200\",\"o\":\"8.40000000\",\"h\":\"8.50000000\",\"l\":\"8.30000000\",\"v\":\"64750.63418500\",\"q\":\"543907.35169250\",\"O\":1773023220000,\"C\":1773109631555,\"F\":19847634,\"L\":19911287,\"n\":217505}" },
        { "AllTokens24hTickerStreamResponse", "{\"e\":\"tickerList\",\"d\":[{\"ca\":\"0x8fce...@56\",\"cnt24\":10426,\"fdv\":\"72834145.18711072\",\"hc\":\"6822\",\"liq\":\"1442996.98151177662835\",\"mc\":\"13542034.24008014\",\"p\":\"0.072849536538593663\",\"pc24\":\"-2.32\",\"s\":\"1\",\"t\":1771825733000,\"vol24\":\"12930712.213702157742688594285\"}]}" },
        { "AllTokens24hTickerStreamResponseDInner", "{\"ca\":\"0x8fce...@56\",\"cnt24\":10426,\"fdv\":\"72834145.18711072\",\"hc\":\"6822\",\"liq\":\"1442996.98151177662835\",\"mc\":\"13542034.24008014\",\"p\":\"0.072849536538593663\",\"pc24\":\"-2.32\",\"s\":\"1\",\"t\":1771825733000,\"vol24\":\"12930712.213702157742688594285\"}" },
        { "BookTickerStreamResponse", "{\"e\":\"bookTicker\",\"E\":1773108379067,\"T\":1773108379054,\"u\":6663207693,\"s\":\"ALPHA_116USDT\",\"b\":\"8.30000000\",\"B\":\"0.91076900\",\"a\":\"9.30000000\",\"A\":\"2.00353200\"}" },
        { "ContractKlineStreamResponse", "{\"ca\":\"G7vQW...@CT_501\",\"e\":\"kline\",\"k\":{\"o\":\"0.15584372258086979622\",\"c\":\"0.15584957424118055058\",\"h\":\"0.15584957424118055058\",\"l\":\"0.15584372258086979622\",\"v\":\"2.8584092999332775480\",\"ot\":1771828655000,\"ct\":1771828656000,\"i\":\"1s\"}}" },
        { "ContractKlineStreamResponseK", "{\"o\":\"0.15584372258086979622\",\"c\":\"0.15584957424118055058\",\"h\":\"0.15584957424118055058\",\"l\":\"0.15584372258086979622\",\"v\":\"2.8584092999332775480\",\"ot\":1771828655000,\"ct\":1771828656000,\"i\":\"1s\"}" },
        { "FullDepthStreamResponse", "{\"e\":\"depthUpdate\",\"E\":1771828614381,\"T\":1771828614258,\"U\":42648947917,\"u\":42648948229,\"pu\":42648947321,\"s\":\"ALPHA_474USDT\",\"b\":[[\"x\"]],\"a\":[[\"x\"]]}" },
        { "KlineStreamResponse", "{\"e\":\"kline\",\"E\":1773111055144,\"s\":\"ALPHA_116USDT\",\"k\":{\"t\":1773111000000,\"T\":1773111059999,\"s\":\"ALPHA_116USDT\",\"i\":\"1m\",\"f\":19912696,\"L\":19912765,\"o\":\"8.40000000\",\"c\":\"8.40000000\",\"h\":\"8.40000000\",\"l\":\"8.40000000\",\"v\":\"63.64876300\",\"n\":218,\"x\":false,\"q\":\"534.64960920\",\"V\":\"63.64876300\",\"Q\":\"534.64960920\",\"B\":\"0\"}}" },
        { "KlineStreamResponseK", "{\"t\":1773111000000,\"T\":1773111059999,\"s\":\"ALPHA_116USDT\",\"i\":\"1m\",\"f\":19912696,\"L\":19912765,\"o\":\"8.40000000\",\"c\":\"8.40000000\",\"h\":\"8.40000000\",\"l\":\"8.40000000\",\"v\":\"63.64876300\",\"n\":218,\"x\":false,\"q\":\"534.64960920\",\"V\":\"63.64876300\",\"Q\":\"534.64960920\",\"B\":\"0\"}" },
        { "MiniTickerStreamResponse", "{\"e\":\"24hrMiniTicker\",\"E\":1773109449908,\"s\":\"ALPHA_116USDT\",\"c\":\"8.40000000\",\"o\":\"8.40000000\",\"h\":\"8.50000000\",\"l\":\"8.30000000\",\"v\":\"64739.03978900\",\"q\":\"543810.36005090\"}" },
        { "PartialDepthStreamResponse", "{\"e\":\"depthUpdate\",\"E\":1773110222878,\"T\":1773110222767,\"U\":6663367135,\"u\":6663367147,\"pu\":6663366971,\"s\":\"ALPHA_116USDT\",\"b\":[[\"x\"]],\"a\":[[\"x\"]]}" },
        { "TickerStreamResponse", "{\"e\":\"24hrTicker\",\"E\":1773109631569,\"s\":\"ALPHA_116USDT\",\"p\":\"0.00000000\",\"P\":\"0.00\",\"w\":\"8.40003127\",\"c\":\"8.40000000\",\"Q\":\"0.49293200\",\"o\":\"8.40000000\",\"h\":\"8.50000000\",\"l\":\"8.30000000\",\"v\":\"64750.63418500\",\"q\":\"543907.35169250\",\"O\":1773023220000,\"C\":1773109631555,\"F\":19847634,\"L\":19911287,\"n\":217505}" },
        { "TradeStreamResponse", "{\"e\":\"trade\",\"E\":1773110023891,\"T\":1773110023877,\"s\":\"ALPHA_116USDT\",\"t\":19911650,\"p\":\"8.40000000\",\"q\":\"0.97915700\",\"m\":false}" },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void DecodesAndRoundTrips(string name, string json)
    {
        var assembly = typeof(AlphaWebSocketStreams).Assembly;
        var type = assembly.GetType($"Binance.Alpha.WebSocketStreams.{name.Split('/')[0]}", throwOnError: true)!;
        var context = (JsonSerializerContext)assembly.GetType("Binance.Alpha.WebSocketStreams.AlphaWebSocketStreamsJson")!.GetProperty("Default")!.GetValue(null)!;
        // A model that no operation returns is not in the serializer context, so it is decoded by reflection.
        var info = context.GetTypeInfo(type);
        var model = info is null ? JsonSerializer.Deserialize(json, type, Reflection) : JsonSerializer.Deserialize(json, info);
        ExampleAssert.Matches(json, model);
    }
}
