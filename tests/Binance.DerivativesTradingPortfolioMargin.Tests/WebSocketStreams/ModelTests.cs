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
using Binance.DerivativesTradingPortfolioMargin.WebSocketStreams;

namespace Binance.DerivativesTradingPortfolioMargin.Tests.WebSocketStreams;

/// <summary>Decodes an instance of every model, built from its schema, with the serializer context of the module.</summary>
public class ModelTests
{
    private static readonly JsonSerializerOptions Reflection = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };

    public static TheoryData<string, string> Cases => new()
    {
        { "AccountConfigUpdate", "{\"fs\":\"UM\",\"E\":1611646737479,\"T\":1611646737476,\"ac\":{\"s\":\"BTCUSD_PERP\",\"l\":25}}" },
        { "AccountConfigUpdateAc", "{\"s\":\"BTCUSD_PERP\",\"l\":25}" },
        { "AccountUpdate", "{\"fs\":\"UM\",\"E\":1564745798939,\"T\":1564745798938,\"i\":\"x\",\"a\":{\"m\":\"ORDER\",\"B\":[{\"a\":\"USDT\",\"wb\":\"122624.12345678\",\"cw\":\"100.12345678\",\"bc\":\"50.12345678\"}],\"P\":[{\"s\":\"BTCUSDT\",\"pa\":\"0\",\"ep\":\"0.00000\",\"cr\":\"200\",\"up\":\"0\",\"ps\":\"BOTH\",\"bep\":\"0.00000\"}],\"S\":\"BTCUSDT\"}}" },
        { "AccountUpdateA", "{\"m\":\"ORDER\",\"B\":[{\"a\":\"USDT\",\"wb\":\"122624.12345678\",\"cw\":\"100.12345678\",\"bc\":\"50.12345678\"}],\"P\":[{\"s\":\"BTCUSDT\",\"pa\":\"0\",\"ep\":\"0.00000\",\"cr\":\"200\",\"up\":\"0\",\"ps\":\"BOTH\",\"bep\":\"0.00000\"}],\"S\":\"BTCUSDT\"}" },
        { "AccountUpdateABInner", "{\"a\":\"USDT\",\"wb\":\"122624.12345678\",\"cw\":\"100.12345678\",\"bc\":\"50.12345678\"}" },
        { "AccountUpdateAPInner", "{\"s\":\"BTCUSDT\",\"pa\":\"0\",\"ep\":\"0.00000\",\"cr\":\"200\",\"up\":\"0\",\"ps\":\"BOTH\",\"bep\":\"0.00000\"}" },
        { "AlgoOrderUpdate", "{\"T\":1750515742297,\"E\":1750515742303,\"fs\":\"UM\",\"ao\":{\"caid\":\"Q5xaq5EGKgXXa0fD7fs0Ip\",\"aid\":2148719,\"at\":\"CONDITIONAL\",\"o\":\"TAKE_PROFIT\",\"s\":\"BNBUSDT\",\"S\":\"SELL\",\"ps\":\"BOTH\",\"f\":\"GTC\",\"q\":\"0.01\",\"X\":\"CANCELED\",\"ai\":\"x\",\"ap\":\"0.00000\",\"aq\":\"0.00000\",\"act\":\"0\",\"tp\":\"750\",\"p\":\"750\",\"V\":\"EXPIRE_MAKER\",\"wt\":\"CONTRACT_PRICE\",\"pm\":\"NONE\",\"cp\":false,\"pP\":false,\"R\":false,\"tt\":0,\"gtd\":0,\"rm\":\"x\",\"ia\":false}}" },
        { "AlgoOrderUpdateAo", "{\"caid\":\"Q5xaq5EGKgXXa0fD7fs0Ip\",\"aid\":2148719,\"at\":\"CONDITIONAL\",\"o\":\"TAKE_PROFIT\",\"s\":\"BNBUSDT\",\"S\":\"SELL\",\"ps\":\"BOTH\",\"f\":\"GTC\",\"q\":\"0.01\",\"X\":\"CANCELED\",\"ai\":\"x\",\"ap\":\"0.00000\",\"aq\":\"0.00000\",\"act\":\"0\",\"tp\":\"750\",\"p\":\"750\",\"V\":\"EXPIRE_MAKER\",\"wt\":\"CONTRACT_PRICE\",\"pm\":\"NONE\",\"cp\":false,\"pP\":false,\"R\":false,\"tt\":0,\"gtd\":0,\"rm\":\"x\",\"ia\":false}" },
        { "BalanceUpdate", "{\"E\":1573200697110,\"a\":\"BTC\",\"d\":\"100.00000000\",\"U\":1027053479517,\"T\":1573200697068}" },
        { "ConditionalOrderTradeUpdate", "{\"T\":1669262908216,\"E\":1669262908218,\"fs\":\"UM\",\"so\":{\"s\":\"BTCUSDT\",\"c\":\"TEST\",\"si\":176057039,\"S\":\"SELL\",\"st\":\"TRAILING_STOP_MARKET\",\"f\":\"GTC\",\"q\":\"0.001\",\"p\":\"0\",\"sp\":\"7103.04\",\"os\":\"NEW\",\"T\":1568879465650,\"ut\":1669262908216,\"R\":false,\"wt\":\"MARK_PRICE\",\"ps\":\"LONG\",\"cp\":false,\"AP\":\"7476.89\",\"cr\":\"5.0\",\"i\":8886774,\"V\":\"EXPIRE_TAKER\",\"gtd\":0}}" },
        { "ConditionalOrderTradeUpdateSo", "{\"s\":\"BTCUSDT\",\"c\":\"TEST\",\"si\":176057039,\"S\":\"SELL\",\"st\":\"TRAILING_STOP_MARKET\",\"f\":\"GTC\",\"q\":\"0.001\",\"p\":\"0\",\"sp\":\"7103.04\",\"os\":\"NEW\",\"T\":1568879465650,\"ut\":1669262908216,\"R\":false,\"wt\":\"MARK_PRICE\",\"ps\":\"LONG\",\"cp\":false,\"AP\":\"7476.89\",\"cr\":\"5.0\",\"i\":8886774,\"V\":\"EXPIRE_TAKER\",\"gtd\":0}" },
        { "ExecutionReport", "{\"E\":1499405658658,\"s\":\"ETHBTC\",\"c\":\"mUvoqJxFIILMdfAW5iGSOW\",\"S\":\"BUY\",\"o\":\"LIMIT\",\"f\":\"GTC\",\"q\":\"1.00000000\",\"p\":\"0.10264410\",\"P\":\"0.00000000\",\"d\":4,\"F\":\"0.00000000\",\"g\":-1,\"C\":\"x\",\"x\":\"NEW\",\"X\":\"NEW\",\"r\":\"NONE\",\"i\":4293153,\"l\":\"0.00000000\",\"z\":\"0.00000000\",\"L\":\"0.00000000\",\"n\":\"0\",\"N\":\"null\",\"T\":1499405658657,\"t\":-1,\"v\":3,\"I\":8641984,\"w\":true,\"m\":false,\"O\":1499405658657,\"Z\":\"0.00000000\",\"Y\":\"0.00000000\",\"Q\":\"0.00000000\",\"D\":1668680518494,\"j\":1,\"J\":1000000,\"W\":1499405658657,\"V\":\"EXPIRE_MAKER\",\"u\":1,\"U\":37,\"A\":\"3.000000\",\"B\":\"3.000000\",\"Cs\":\"BTCUSDT\",\"pl\":\"2.123456\",\"pL\":\"0.10000001\",\"pY\":\"0.21234562\",\"eR\":\"INSUFFICIENT_LIQUIDITY\"}" },
        { "LiabilityChange", "{\"E\":1573200697110,\"a\":\"BTC\",\"t\":\"BORROW\",\"T\":\"1352286576452864800\",\"p\":\"1.03453430\",\"i\":\"0\",\"l\":\"1.03476851\"}" },
        { "ListenKeyExpired", "{\"E\":1576653824250}" },
        { "OpenOrderLoss", "{\"E\":1678710578788,\"o\":\"-310.00000000\"}" },
        { "OrderTradeUpdate", "{\"fs\":\"UM\",\"E\":1568879465651,\"T\":1568879465650,\"i\":\"x\",\"o\":{\"s\":\"BTCUSDT\",\"c\":\"TEST\",\"S\":\"SELL\",\"o\":\"MARKET\",\"f\":\"GTC\",\"q\":\"0.001\",\"p\":\"0\",\"ap\":\"0\",\"sp\":\"7103.04\",\"x\":\"NEW\",\"X\":\"NEW\",\"i\":8886774,\"M\":\"44444\",\"l\":\"0\",\"z\":\"0\",\"L\":\"0\",\"N\":\"USDT\",\"n\":\"0\",\"T\":1568879465650,\"t\":0,\"b\":\"0\",\"a\":\"9.91\",\"m\":false,\"R\":false,\"ps\":\"LONG\",\"rp\":\"0\",\"st\":\"C_TAKE_PROFIT\",\"si\":12893,\"V\":\"EXPIRE_TAKER\",\"gtd\":0}}" },
        { "OrderTradeUpdateO", "{\"s\":\"BTCUSDT\",\"c\":\"TEST\",\"S\":\"SELL\",\"o\":\"MARKET\",\"f\":\"GTC\",\"q\":\"0.001\",\"p\":\"0\",\"ap\":\"0\",\"sp\":\"7103.04\",\"x\":\"NEW\",\"X\":\"NEW\",\"i\":8886774,\"M\":\"44444\",\"l\":\"0\",\"z\":\"0\",\"L\":\"0\",\"N\":\"USDT\",\"n\":\"0\",\"T\":1568879465650,\"t\":0,\"b\":\"0\",\"a\":\"9.91\",\"m\":false,\"R\":false,\"ps\":\"LONG\",\"rp\":\"0\",\"st\":\"C_TAKE_PROFIT\",\"si\":12893,\"V\":\"EXPIRE_TAKER\",\"gtd\":0}" },
        { "OutboundAccountPosition", "{\"E\":1564034571105,\"u\":1564034571073,\"U\":1027053479517,\"B\":[{\"a\":\"ETH\",\"f\":\"10000.000000\",\"l\":\"0.000000\"}]}" },
        { "OutboundAccountPositionBInner", "{\"a\":\"ETH\",\"f\":\"10000.000000\",\"l\":\"0.000000\"}" },
        { "RiskLevelChange", "{\"E\":1587727187525,\"u\":\"1.99999999\",\"s\":\"MARGIN_CALL\",\"eq\":\"30.23416728\",\"ae\":\"30.23416728\",\"m\":\"15.11708371\"}" },
        { "UserDataStreamEventsResponse/AccountConfigUpdate", "{\"fs\":\"UM\",\"E\":1611646737479,\"T\":1611646737476,\"ac\":{\"s\":\"BTCUSD_PERP\",\"l\":25}}" },
        { "UserDataStreamEventsResponse/AccountUpdate", "{\"fs\":\"UM\",\"E\":1564745798939,\"T\":1564745798938,\"i\":\"x\",\"a\":{\"m\":\"ORDER\",\"B\":[{\"a\":\"USDT\",\"wb\":\"122624.12345678\",\"cw\":\"100.12345678\",\"bc\":\"50.12345678\"}],\"P\":[{\"s\":\"BTCUSDT\",\"pa\":\"0\",\"ep\":\"0.00000\",\"cr\":\"200\",\"up\":\"0\",\"ps\":\"BOTH\",\"bep\":\"0.00000\"}],\"S\":\"BTCUSDT\"}}" },
        { "UserDataStreamEventsResponse/AlgoOrderUpdate", "{\"T\":1750515742297,\"E\":1750515742303,\"fs\":\"UM\",\"ao\":{\"caid\":\"Q5xaq5EGKgXXa0fD7fs0Ip\",\"aid\":2148719,\"at\":\"CONDITIONAL\",\"o\":\"TAKE_PROFIT\",\"s\":\"BNBUSDT\",\"S\":\"SELL\",\"ps\":\"BOTH\",\"f\":\"GTC\",\"q\":\"0.01\",\"X\":\"CANCELED\",\"ai\":\"x\",\"ap\":\"0.00000\",\"aq\":\"0.00000\",\"act\":\"0\",\"tp\":\"750\",\"p\":\"750\",\"V\":\"EXPIRE_MAKER\",\"wt\":\"CONTRACT_PRICE\",\"pm\":\"NONE\",\"cp\":false,\"pP\":false,\"R\":false,\"tt\":0,\"gtd\":0,\"rm\":\"x\",\"ia\":false}}" },
        { "UserDataStreamEventsResponse/BalanceUpdate", "{\"E\":1573200697110,\"a\":\"BTC\",\"d\":\"100.00000000\",\"U\":1027053479517,\"T\":1573200697068}" },
        { "UserDataStreamEventsResponse/ConditionalOrderTradeUpdate", "{\"T\":1669262908216,\"E\":1669262908218,\"fs\":\"UM\",\"so\":{\"s\":\"BTCUSDT\",\"c\":\"TEST\",\"si\":176057039,\"S\":\"SELL\",\"st\":\"TRAILING_STOP_MARKET\",\"f\":\"GTC\",\"q\":\"0.001\",\"p\":\"0\",\"sp\":\"7103.04\",\"os\":\"NEW\",\"T\":1568879465650,\"ut\":1669262908216,\"R\":false,\"wt\":\"MARK_PRICE\",\"ps\":\"LONG\",\"cp\":false,\"AP\":\"7476.89\",\"cr\":\"5.0\",\"i\":8886774,\"V\":\"EXPIRE_TAKER\",\"gtd\":0}}" },
        { "UserDataStreamEventsResponse/ExecutionReport", "{\"E\":1499405658658,\"s\":\"ETHBTC\",\"c\":\"mUvoqJxFIILMdfAW5iGSOW\",\"S\":\"BUY\",\"o\":\"LIMIT\",\"f\":\"GTC\",\"q\":\"1.00000000\",\"p\":\"0.10264410\",\"P\":\"0.00000000\",\"d\":4,\"F\":\"0.00000000\",\"g\":-1,\"C\":\"x\",\"x\":\"NEW\",\"X\":\"NEW\",\"r\":\"NONE\",\"i\":4293153,\"l\":\"0.00000000\",\"z\":\"0.00000000\",\"L\":\"0.00000000\",\"n\":\"0\",\"N\":\"null\",\"T\":1499405658657,\"t\":-1,\"v\":3,\"I\":8641984,\"w\":true,\"m\":false,\"O\":1499405658657,\"Z\":\"0.00000000\",\"Y\":\"0.00000000\",\"Q\":\"0.00000000\",\"D\":1668680518494,\"j\":1,\"J\":1000000,\"W\":1499405658657,\"V\":\"EXPIRE_MAKER\",\"u\":1,\"U\":37,\"A\":\"3.000000\",\"B\":\"3.000000\",\"Cs\":\"BTCUSDT\",\"pl\":\"2.123456\",\"pL\":\"0.10000001\",\"pY\":\"0.21234562\",\"eR\":\"INSUFFICIENT_LIQUIDITY\"}" },
        { "UserDataStreamEventsResponse/LiabilityChange", "{\"E\":1573200697110,\"a\":\"BTC\",\"t\":\"BORROW\",\"T\":\"1352286576452864800\",\"p\":\"1.03453430\",\"i\":\"0\",\"l\":\"1.03476851\"}" },
        { "UserDataStreamEventsResponse/ListenKeyExpired", "{\"E\":1576653824250}" },
        { "UserDataStreamEventsResponse/OpenOrderLoss", "{\"E\":1678710578788,\"o\":\"-310.00000000\"}" },
        { "UserDataStreamEventsResponse/OrderTradeUpdate", "{\"fs\":\"UM\",\"E\":1568879465651,\"T\":1568879465650,\"i\":\"x\",\"o\":{\"s\":\"BTCUSDT\",\"c\":\"TEST\",\"S\":\"SELL\",\"o\":\"MARKET\",\"f\":\"GTC\",\"q\":\"0.001\",\"p\":\"0\",\"ap\":\"0\",\"sp\":\"7103.04\",\"x\":\"NEW\",\"X\":\"NEW\",\"i\":8886774,\"M\":\"44444\",\"l\":\"0\",\"z\":\"0\",\"L\":\"0\",\"N\":\"USDT\",\"n\":\"0\",\"T\":1568879465650,\"t\":0,\"b\":\"0\",\"a\":\"9.91\",\"m\":false,\"R\":false,\"ps\":\"LONG\",\"rp\":\"0\",\"st\":\"C_TAKE_PROFIT\",\"si\":12893,\"V\":\"EXPIRE_TAKER\",\"gtd\":0}}" },
        { "UserDataStreamEventsResponse/OutboundAccountPosition", "{\"E\":1564034571105,\"u\":1564034571073,\"U\":1027053479517,\"B\":[{\"a\":\"ETH\",\"f\":\"10000.000000\",\"l\":\"0.000000\"}]}" },
        { "UserDataStreamEventsResponse/RiskLevelChange", "{\"E\":1587727187525,\"u\":\"1.99999999\",\"s\":\"MARGIN_CALL\",\"eq\":\"30.23416728\",\"ae\":\"30.23416728\",\"m\":\"15.11708371\"}" },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void DecodesAndRoundTrips(string name, string json)
    {
        var assembly = typeof(DerivativesTradingPortfolioMarginWebSocketStreams).Assembly;
        var type = assembly.GetType($"Binance.DerivativesTradingPortfolioMargin.WebSocketStreams.{name.Split('/')[0]}", throwOnError: true)!;
        var context = (JsonSerializerContext)assembly.GetType("Binance.DerivativesTradingPortfolioMargin.WebSocketStreams.DerivativesTradingPortfolioMarginWebSocketStreamsJson")!.GetProperty("Default")!.GetValue(null)!;
        // A model that no operation returns is not in the serializer context, so it is decoded by reflection.
        var info = context.GetTypeInfo(type);
        var model = info is null ? JsonSerializer.Deserialize(json, type, Reflection) : JsonSerializer.Deserialize(json, info);
        ExampleAssert.Matches(json, model);
    }
}
