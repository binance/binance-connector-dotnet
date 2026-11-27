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
using Binance.DerivativesTradingOptions.WebSocketStreams;

namespace Binance.DerivativesTradingOptions.Tests.WebSocketStreams;

/// <summary>Decodes an instance of every model, built from its schema, with the serializer context of the module.</summary>
public class ModelTests
{
    private static readonly JsonSerializerOptions Reflection = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };

    public static TheoryData<string, string> Cases => new()
    {
        { "AccountUpdate", "{\"E\":1762914568643,\"T\":1762914568619,\"eq\":\"10000371.61462086\",\"aeq\":\"10000475.51032086\",\"b\":\"10000475.51032086\",\"m\":\"-103.89570000\",\"u\":\"16.10430000\",\"i\":\"32354.38562539\",\"M\":\"6089.28766956\"}" },
        { "BalancePositionUpdate", "{\"E\":1762917544216,\"T\":1762917544206,\"m\":\"ORDER\",\"B\":[{\"a\":\"USDT\",\"b\":\"10000471.37940900\",\"bc\":\"0\"}],\"P\":[{\"s\":\"BTC-251123-126000-C\",\"c\":\"-0.1000\",\"p\":\"-120.00000000\",\"a\":\"1200.00000000\"}]}" },
        { "BalancePositionUpdateBInner", "{\"a\":\"USDT\",\"b\":\"10000471.37940900\",\"bc\":\"0\"}" },
        { "BalancePositionUpdatePInner", "{\"s\":\"BTC-251123-126000-C\",\"c\":\"-0.1000\",\"p\":\"-120.00000000\",\"a\":\"1200.00000000\"}" },
        { "DiffBookDepthStreamsResponse", "{\"e\":\"depthUpdate\",\"E\":1762866729459,\"T\":1762866729358,\"s\":\"BTC-251123-126000-C\",\"U\":465,\"u\":465,\"pu\":464,\"b\":[[\"x\"]],\"a\":[[\"x\"]]}" },
        { "GreekUpdate", "{\"E\":1762917544216,\"T\":1762917544216,\"G\":[{\"u\":\"BTCUSDT\",\"d\":\"-0.01304097\",\"g\":\"-0.00000124\",\"t\":\"16.11648100\",\"v\":\"-3.83444011\"}]}" },
        { "GreekUpdateGInner", "{\"u\":\"BTCUSDT\",\"d\":\"-0.01304097\",\"g\":\"-0.00000124\",\"t\":\"16.11648100\",\"v\":\"-3.83444011\"}" },
        { "Hour24TickerResponse", "{\"e\":\"24hrTicker\",\"E\":1764080707933,\"s\":\"ETH-251226-3000-C\",\"p\":\"0.0000\",\"P\":\"0.00\",\"w\":\"200.0000\",\"c\":\"200.0000\",\"Q\":\"1.0000\",\"o\":\"200.0000\",\"h\":\"200.0000\",\"l\":\"200.0000\",\"v\":\"9.0000\",\"q\":\"1800.0000\",\"O\":1764051060000,\"C\":1764080707933,\"F\":1,\"L\":22,\"n\":9}" },
        { "IndexPriceStreamsResponseInner", "{\"e\":\"indexPrice\",\"E\":1763092572229,\"s\":\"ETHUSDT\",\"p\":\"3224.51976744\"}" },
        { "IndividualSymbolBookTickerStreamsResponse", "{\"e\":\"bookTicker\",\"u\":2472,\"s\":\"BTC-251226-110000-C\",\"b\":\"5000.000\",\"B\":\"0.2000\",\"a\":\"5100.000\",\"A\":\"0.1000\",\"T\":1763041762942,\"E\":1763041762942}" },
        { "KlineCandlestickStreamsResponse", "{\"e\":\"kline\",\"E\":1638747660000,\"s\":\"BTC-200630-9000-P\",\"k\":{\"t\":1638747660000,\"T\":1638747719999,\"s\":\"BTC-200630-9000-P\",\"i\":\"1m\",\"f\":0,\"L\":0,\"o\":\"1000\",\"c\":\"1000\",\"h\":\"1000\",\"l\":\"1000\",\"v\":\"0\",\"n\":0,\"x\":false,\"q\":\"0\",\"V\":\"0\",\"Q\":\"0\"}}" },
        { "KlineCandlestickStreamsResponseK", "{\"t\":1638747660000,\"T\":1638747719999,\"s\":\"BTC-200630-9000-P\",\"i\":\"1m\",\"f\":0,\"L\":0,\"o\":\"1000\",\"c\":\"1000\",\"h\":\"1000\",\"l\":\"1000\",\"v\":\"0\",\"n\":0,\"x\":false,\"q\":\"0\",\"V\":\"0\",\"Q\":\"0\"}" },
        { "ListenKeyExpired", "{\"E\":\"1736996475556\",\"listenKey\":\"WsCMN0a4KHUPTQuX6IUnqEZfB1inxmv1qR4kbf1LuEjur5VdbzqvyxqG9TSjVVxv\"}" },
        { "NewSymbolInfoResponse", "{\"e\":\"optionSymbol\",\"E\":1669356423908,\"s\":\"BTC-250926-140000-C\",\"ps\":\"BTCUSDT\",\"qa\":\"USDT\",\"d\":\"CALL\",\"sp\":\"21000\",\"dt\":4133404800000,\"u\":1,\"ot\":1569398400000,\"cs\":\"TRADING\"}" },
        { "OpenInterestResponseInner", "{\"e\":\"openInterest\",\"E\":1668759300045,\"s\":\"ETH-221125-2700-C\",\"o\":\"1580.87\",\"h\":\"1912992.178168204\"}" },
        { "OptionMarkPriceResponseInner", "{\"s\":\"BTC-251120-126000-C\",\"mp\":\"770.543\",\"E\":1762867543321,\"e\":\"markPrice\",\"i\":\"104334.60217391\",\"P\":\"0.000\",\"bo\":\"0.000\",\"ao\":\"900.000\",\"bq\":\"0.0000\",\"aq\":\"0.2000\",\"b\":\"-1.0\",\"a\":\"0.98161161\",\"hl\":\"924.652\",\"ll\":\"616.435\",\"vo\":\"0.9408058\",\"rf\":\"0.0\",\"d\":\"0.11111964\",\"t\":\"-164.26702615\",\"g\":\"0.00001245\",\"v\":\"30.63855919\"}" },
        { "OrderTradeUpdate", "{\"E\":1568879465651,\"T\":1568879465650,\"o\":{\"s\":\"BTCUSDT\",\"c\":\"TEST\",\"S\":\"SELL\",\"o\":\"TRAILING_STOP_MARKET\",\"f\":\"GTC\",\"q\":\"0.001\",\"p\":\"0\",\"ap\":\"0\",\"x\":\"NEW\",\"X\":\"NEW\",\"i\":8886774,\"l\":\"0\",\"z\":\"0\",\"L\":\"0\",\"N\":\"USDT\",\"n\":\"0\",\"T\":1568879465650,\"t\":0,\"b\":\"0\",\"a\":\"9.91\",\"m\":false,\"R\":false,\"ot\":\"TRAILING_STOP_MARKET\",\"rp\":\"0\",\"V\":\"EXPIRE_TAKER\"}}" },
        { "OrderTradeUpdateO", "{\"s\":\"BTCUSDT\",\"c\":\"TEST\",\"S\":\"SELL\",\"o\":\"TRAILING_STOP_MARKET\",\"f\":\"GTC\",\"q\":\"0.001\",\"p\":\"0\",\"ap\":\"0\",\"x\":\"NEW\",\"X\":\"NEW\",\"i\":8886774,\"l\":\"0\",\"z\":\"0\",\"L\":\"0\",\"N\":\"USDT\",\"n\":\"0\",\"T\":1568879465650,\"t\":0,\"b\":\"0\",\"a\":\"9.91\",\"m\":false,\"R\":false,\"ot\":\"TRAILING_STOP_MARKET\",\"rp\":\"0\",\"V\":\"EXPIRE_TAKER\"}" },
        { "PartialBookDepthStreamsResponse", "{\"e\":\"depthUpdate\",\"E\":1762866729459,\"T\":1762866729358,\"s\":\"BTC-251123-126000-C\",\"U\":465,\"u\":465,\"pu\":464,\"b\":[[\"x\"]],\"a\":[[\"x\"]]}" },
        { "RiskLevelChange", "{\"E\":1587727187525,\"s\":\"REDUCE_ONLY\",\"mb\":\"1534.11708371\",\"mm\":\"254789.11708371\"}" },
        { "TradeStreamsResponse", "{\"e\":\"trade\",\"E\":1762856064204,\"T\":1762856064203,\"s\":\"BTC-251123-126000-C\",\"t\":4,\"p\":\"1300.000\",\"q\":\"0.1000\",\"X\":\"MARKET\",\"S\":\"BUY\",\"m\":false}" },
        { "UserDataStreamEventsResponse/AccountUpdate", "{\"E\":1762914568643,\"T\":1762914568619,\"eq\":\"10000371.61462086\",\"aeq\":\"10000475.51032086\",\"b\":\"10000475.51032086\",\"m\":\"-103.89570000\",\"u\":\"16.10430000\",\"i\":\"32354.38562539\",\"M\":\"6089.28766956\"}" },
        { "UserDataStreamEventsResponse/BalancePositionUpdate", "{\"E\":1762917544216,\"T\":1762917544206,\"m\":\"ORDER\",\"B\":[{\"a\":\"USDT\",\"b\":\"10000471.37940900\",\"bc\":\"0\"}],\"P\":[{\"s\":\"BTC-251123-126000-C\",\"c\":\"-0.1000\",\"p\":\"-120.00000000\",\"a\":\"1200.00000000\"}]}" },
        { "UserDataStreamEventsResponse/GreekUpdate", "{\"E\":1762917544216,\"T\":1762917544216,\"G\":[{\"u\":\"BTCUSDT\",\"d\":\"-0.01304097\",\"g\":\"-0.00000124\",\"t\":\"16.11648100\",\"v\":\"-3.83444011\"}]}" },
        { "UserDataStreamEventsResponse/ListenKeyExpired", "{\"E\":\"1736996475556\",\"listenKey\":\"WsCMN0a4KHUPTQuX6IUnqEZfB1inxmv1qR4kbf1LuEjur5VdbzqvyxqG9TSjVVxv\"}" },
        { "UserDataStreamEventsResponse/OrderTradeUpdate", "{\"E\":1568879465651,\"T\":1568879465650,\"o\":{\"s\":\"BTCUSDT\",\"c\":\"TEST\",\"S\":\"SELL\",\"o\":\"TRAILING_STOP_MARKET\",\"f\":\"GTC\",\"q\":\"0.001\",\"p\":\"0\",\"ap\":\"0\",\"x\":\"NEW\",\"X\":\"NEW\",\"i\":8886774,\"l\":\"0\",\"z\":\"0\",\"L\":\"0\",\"N\":\"USDT\",\"n\":\"0\",\"T\":1568879465650,\"t\":0,\"b\":\"0\",\"a\":\"9.91\",\"m\":false,\"R\":false,\"ot\":\"TRAILING_STOP_MARKET\",\"rp\":\"0\",\"V\":\"EXPIRE_TAKER\"}}" },
        { "UserDataStreamEventsResponse/RiskLevelChange", "{\"E\":1587727187525,\"s\":\"REDUCE_ONLY\",\"mb\":\"1534.11708371\",\"mm\":\"254789.11708371\"}" },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void DecodesAndRoundTrips(string name, string json)
    {
        var assembly = typeof(DerivativesTradingOptionsWebSocketStreams).Assembly;
        var type = assembly.GetType($"Binance.DerivativesTradingOptions.WebSocketStreams.{name.Split('/')[0]}", throwOnError: true)!;
        var context = (JsonSerializerContext)assembly.GetType("Binance.DerivativesTradingOptions.WebSocketStreams.DerivativesTradingOptionsWebSocketStreamsJson")!.GetProperty("Default")!.GetValue(null)!;
        // A model that no operation returns is not in the serializer context, so it is decoded by reflection.
        var info = context.GetTypeInfo(type);
        var model = info is null ? JsonSerializer.Deserialize(json, type, Reflection) : JsonSerializer.Deserialize(json, info);
        ExampleAssert.Matches(json, model);
    }
}
