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
using Binance.MarginTrading.WebSocketStreams;

namespace Binance.MarginTrading.Tests.WebSocketStreams;

/// <summary>Decodes an instance of every model, built from its schema, with the serializer context of the module.</summary>
public class ModelTests
{
    private static readonly JsonSerializerOptions Reflection = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };

    public static TheoryData<string, string> Cases => new()
    {
        { "BalanceUpdate", "{\"E\":1573200697110,\"a\":\"BTC\",\"d\":\"100.00000000\",\"T\":1573200697068}" },
        { "ExecutionReport", "{\"E\":1499405658658,\"s\":\"ETHBTC\",\"c\":\"mUvoqJxFIILMdfAW5iGSOW\",\"S\":\"BUY\",\"o\":\"LIMIT\",\"f\":\"GTC\",\"q\":\"1.00000000\",\"p\":\"0.10264410\",\"P\":\"0.00000000\",\"F\":\"0.00000000\",\"g\":-1,\"C\":\"x\",\"x\":\"NEW\",\"X\":\"NEW\",\"r\":\"NONE\",\"i\":4293153,\"l\":\"0.00000000\",\"z\":\"0.00000000\",\"L\":\"0.00000000\",\"n\":\"0\",\"N\":\"null\",\"T\":1499405658657,\"t\":-1,\"I\":8641984,\"w\":true,\"m\":false,\"M\":false,\"O\":1499405658657,\"Z\":\"0.00000000\",\"Y\":\"0.00000000\",\"Q\":\"0.00000000\",\"W\":1499405658657,\"V\":\"NONE\",\"d\":4,\"D\":1668680518494,\"j\":1,\"J\":1000000,\"v\":3,\"A\":\"3.000000\",\"B\":\"3.000000\",\"u\":1,\"U\":37,\"Cs\":\"BTCUSDT\",\"pl\":\"2.123456\",\"pL\":\"0.10000001\",\"pY\":\"0.21234562\",\"b\":\"ONE_PARTY_TRADE_REPORT\",\"a\":1234,\"k\":\"SOR\",\"uS\":true}" },
        { "ListStatus", "{\"E\":1564035303637,\"s\":\"ETHBTC\",\"g\":2,\"c\":\"OCO\",\"l\":\"EXEC_STARTED\",\"L\":\"EXECUTING\",\"r\":\"NONE\",\"C\":\"F4QN4G8DlFATFlIUQ0cjdD\",\"T\":1564035303625,\"O\":[{\"s\":\"ETHBTC\",\"i\":17,\"c\":\"AJYsMjErWJesZvqlJCTUgL\"}]}" },
        { "ListStatusOInner", "{\"s\":\"ETHBTC\",\"i\":17,\"c\":\"AJYsMjErWJesZvqlJCTUgL\"}" },
        { "ListenKeyExpired", "{\"E\":\"1699596037418\",\"listenKey\":\"OfYGbUzi3PraNagEkdKuFwUHn48brFsItTdsuiIXrucEvD0rhRXZ7I6URWfE8YE8\"}" },
        { "MarginLevelStatusChange", "{\"E\":1701949763462,\"l\":\"1.1\",\"s\":\"MARGIN_CALL\"}" },
        { "OutboundAccountPosition", "{\"E\":1564034571105,\"u\":1564034571073,\"B\":[{\"a\":\"ETH\",\"f\":\"10000.000000\",\"l\":\"0.000000\"}]}" },
        { "OutboundAccountPositionBInner", "{\"a\":\"ETH\",\"f\":\"10000.000000\",\"l\":\"0.000000\"}" },
        { "RiskDataStreamEventsResponse/MarginLevelStatusChange", "{\"E\":1701949763462,\"l\":\"1.1\",\"s\":\"MARGIN_CALL\"}" },
        { "RiskDataStreamEventsResponse/UserLiabilityChange", "{\"E\":1701949801133,\"a\":\"BTC\",\"t\":\"BORROW\",\"p\":\"0.00000100\",\"i\":\"0.00000000\"}" },
        { "TradeDataStreamEventsResponse/MarginLevelStatusChange", "{\"E\":1701949763462,\"l\":\"1.1\",\"s\":\"MARGIN_CALL\"}" },
        { "TradeDataStreamEventsResponse/UserLiabilityChange", "{\"E\":1701949801133,\"a\":\"BTC\",\"t\":\"BORROW\",\"p\":\"0.00000100\",\"i\":\"0.00000000\"}" },
        { "TradeDataStreamEventsResponse/BalanceUpdate", "{\"E\":1573200697110,\"a\":\"BTC\",\"d\":\"100.00000000\",\"T\":1573200697068}" },
        { "TradeDataStreamEventsResponse/ExecutionReport", "{\"E\":1499405658658,\"s\":\"ETHBTC\",\"c\":\"mUvoqJxFIILMdfAW5iGSOW\",\"S\":\"BUY\",\"o\":\"LIMIT\",\"f\":\"GTC\",\"q\":\"1.00000000\",\"p\":\"0.10264410\",\"P\":\"0.00000000\",\"F\":\"0.00000000\",\"g\":-1,\"C\":\"x\",\"x\":\"NEW\",\"X\":\"NEW\",\"r\":\"NONE\",\"i\":4293153,\"l\":\"0.00000000\",\"z\":\"0.00000000\",\"L\":\"0.00000000\",\"n\":\"0\",\"N\":\"null\",\"T\":1499405658657,\"t\":-1,\"I\":8641984,\"w\":true,\"m\":false,\"M\":false,\"O\":1499405658657,\"Z\":\"0.00000000\",\"Y\":\"0.00000000\",\"Q\":\"0.00000000\",\"W\":1499405658657,\"V\":\"NONE\",\"d\":4,\"D\":1668680518494,\"j\":1,\"J\":1000000,\"v\":3,\"A\":\"3.000000\",\"B\":\"3.000000\",\"u\":1,\"U\":37,\"Cs\":\"BTCUSDT\",\"pl\":\"2.123456\",\"pL\":\"0.10000001\",\"pY\":\"0.21234562\",\"b\":\"ONE_PARTY_TRADE_REPORT\",\"a\":1234,\"k\":\"SOR\",\"uS\":true}" },
        { "TradeDataStreamEventsResponse/ListStatus", "{\"E\":1564035303637,\"s\":\"ETHBTC\",\"g\":2,\"c\":\"OCO\",\"l\":\"EXEC_STARTED\",\"L\":\"EXECUTING\",\"r\":\"NONE\",\"C\":\"F4QN4G8DlFATFlIUQ0cjdD\",\"T\":1564035303625,\"O\":[{\"s\":\"ETHBTC\",\"i\":17,\"c\":\"AJYsMjErWJesZvqlJCTUgL\"}]}" },
        { "TradeDataStreamEventsResponse/ListenKeyExpired", "{\"E\":\"1699596037418\",\"listenKey\":\"OfYGbUzi3PraNagEkdKuFwUHn48brFsItTdsuiIXrucEvD0rhRXZ7I6URWfE8YE8\"}" },
        { "TradeDataStreamEventsResponse/OutboundAccountPosition", "{\"E\":1564034571105,\"u\":1564034571073,\"B\":[{\"a\":\"ETH\",\"f\":\"10000.000000\",\"l\":\"0.000000\"}]}" },
        { "UserLiabilityChange", "{\"E\":1701949801133,\"a\":\"BTC\",\"t\":\"BORROW\",\"p\":\"0.00000100\",\"i\":\"0.00000000\"}" },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void DecodesAndRoundTrips(string name, string json)
    {
        var assembly = typeof(MarginTradingWebSocketStreams).Assembly;
        var type = assembly.GetType($"Binance.MarginTrading.WebSocketStreams.{name.Split('/')[0]}", throwOnError: true)!;
        var context = (JsonSerializerContext)assembly.GetType("Binance.MarginTrading.WebSocketStreams.MarginTradingWebSocketStreamsJson")!.GetProperty("Default")!.GetValue(null)!;
        // A model that no operation returns is not in the serializer context, so it is decoded by reflection.
        var info = context.GetTypeInfo(type);
        var model = info is null ? JsonSerializer.Deserialize(json, type, Reflection) : JsonSerializer.Deserialize(json, info);
        ExampleAssert.Matches(json, model);
    }
}
