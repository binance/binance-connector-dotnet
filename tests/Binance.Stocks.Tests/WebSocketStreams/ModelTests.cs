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
using Binance.Stocks.WebSocketStreams;

namespace Binance.Stocks.Tests.WebSocketStreams;

/// <summary>Decodes an instance of every model, built from its schema, with the serializer context of the module.</summary>
public class ModelTests
{
    private static readonly JsonSerializerOptions Reflection = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };

    public static TheoryData<string, string> Cases => new()
    {
        { "CalendarStreamResponse", "{\"e\":\"calendar\",\"from\":\"PRE_MARKET\",\"to\":\"MARKET_OPEN\",\"ts\":1710334200000}" },
        { "KlineStreamResponse", "{\"e\":\"kline\",\"E\":1710320400000,\"s\":\"AAPL\",\"k\":{\"t\":1710316800000,\"ct\":1710317099999,\"s\":\"AAPL\",\"i\":\"5m\",\"o\":\"182.50\",\"c\":\"183.20\",\"h\":\"183.50\",\"l\":\"182.30\",\"v\":\"15000\",\"n\":120,\"x\":false,\"vw\":\"182.95\"}}" },
        { "KlineStreamResponseK", "{\"t\":1710316800000,\"ct\":1710317099999,\"s\":\"AAPL\",\"i\":\"5m\",\"o\":\"182.50\",\"c\":\"183.20\",\"h\":\"183.50\",\"l\":\"182.30\",\"v\":\"15000\",\"n\":120,\"x\":false,\"vw\":\"182.95\"}" },
        { "OrderReportStreamResponse", "{\"e\":\"orderReport\",\"E\":1710000000000,\"x\":\"ORDER_UPDATE\",\"i\":\"b0b6dd9d-8b9b-48a9-ba46-b9d54906e415\",\"ai\":\"4ce9353c-66d1-46c2-898f-fce867ab0247\",\"b\":\"EQ_AAPL\",\"q\":\"USD\",\"S\":\"buy\",\"o\":\"limit\",\"p\":185.5,\"Q\":10,\"N\":1,\"fq\":5,\"FN\":927.5,\"tc\":1856.2,\"Z\":50,\"n\":\"Regular\",\"s\":\"partially_filled\",\"T\":1710000000000,\"U\":1710000060000}" },
        { "PriceStreamResponse", "{\"e\":\"price\",\"rates\":[{\"s\":\"AAPL\",\"ac\":\"EQ_AAPL\",\"p\":\"182.5\",\"t\":1710320400000,\"pc\":\"181.2000\",\"tc\":\"182.0000\",\"lrc\":\"182.0000\",\"prc\":\"181.2000\",\"mp\":\"O\"}]}" },
        { "PriceStreamResponseRatesInner", "{\"s\":\"AAPL\",\"ac\":\"EQ_AAPL\",\"p\":\"182.5\",\"t\":1710320400000,\"pc\":\"181.2000\",\"tc\":\"182.0000\",\"lrc\":\"182.0000\",\"prc\":\"181.2000\",\"mp\":\"O\"}" },
        { "QuoteStreamResponse", "{\"e\":\"quote\",\"E\":1710320400000,\"s\":\"AAPL\",\"bp\":\"182.50\",\"ap\":\"182.55\",\"bs\":100,\"as\":200,\"T\":1710320399500}" },
        { "TradabilityStreamResponse", "{\"e\":\"tradability\",\"symbol\":\"AAPL\",\"assetCode\":\"EQ_AAPL\",\"tradability\":\"BUY_SELL\",\"t\":1712345678000}" },
        { "TradingStatusStreamResponse", "{\"e\":\"tradingStatus\",\"symbol\":\"AAPL\",\"assetCode\":\"EQ_AAPL\",\"status\":\"TRADING_HALTED\",\"msg\":\"MATERIAL_NEWS\",\"time\":1614021300000,\"z\":\"C\",\"tradability\":\"NONE\"}" },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void DecodesAndRoundTrips(string name, string json)
    {
        var assembly = typeof(StocksWebSocketStreams).Assembly;
        var type = assembly.GetType($"Binance.Stocks.WebSocketStreams.{name.Split('/')[0]}", throwOnError: true)!;
        var context = (JsonSerializerContext)assembly.GetType("Binance.Stocks.WebSocketStreams.StocksWebSocketStreamsJson")!.GetProperty("Default")!.GetValue(null)!;
        // A model that no operation returns is not in the serializer context, so it is decoded by reflection.
        var info = context.GetTypeInfo(type);
        var model = info is null ? JsonSerializer.Deserialize(json, type, Reflection) : JsonSerializer.Deserialize(json, info);
        ExampleAssert.Matches(json, model);
    }
}
