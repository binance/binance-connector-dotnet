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
using Binance.StockOptions.WebSocketStreams;

namespace Binance.StockOptions.Tests.WebSocketStreams;

/// <summary>Decodes an instance of every model, built from its schema, with the serializer context of the module.</summary>
public class ModelTests
{
    private static readonly JsonSerializerOptions Reflection = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };

    public static TheoryData<string, string> Cases => new()
    {
        { "OrderReportV2StreamResponse", "{\"e\":\"orderReportV2\",\"E\":1792679109312,\"x\":\"ORDER_UPDATE\",\"i\":\"b0b6dd9d-8b9b-48a9-ba46-b9d54906e415\",\"ci\":\"6a1f3c2e-90b4-4d7e-a1c5-2f8e7d6b5a40\",\"ai\":\"8d3f2a61-5c7e-4b90-9e1d-3a6c4f2b7e18\",\"b\":\"EQ_SPCX\",\"q\":\"USDC\",\"S\":\"buy\",\"o\":\"limit\",\"p\":0.57,\"Q\":1,\"N\":1,\"fq\":0,\"FN\":0,\"tc\":57.66,\"Z\":0,\"n\":\"RTH\",\"s\":\"accepted\",\"T\":1792679109000,\"U\":1792679109000,\"ac\":\"us_option\",\"os\":\"SPCX261023C00005000\",\"u\":\"SPCX\",\"rs\":\"SPCX\",\"ct\":\"CALL\",\"sp\":5,\"ed\":1792771200000,\"m\":100,\"pi\":\"buy_to_open\"}" },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void DecodesAndRoundTrips(string name, string json)
    {
        var assembly = typeof(StockOptionsWebSocketStreams).Assembly;
        var type = assembly.GetType($"Binance.StockOptions.WebSocketStreams.{name.Split('/')[0]}", throwOnError: true)!;
        var context = (JsonSerializerContext)assembly.GetType("Binance.StockOptions.WebSocketStreams.StockOptionsWebSocketStreamsJson")!.GetProperty("Default")!.GetValue(null)!;
        // A model that no operation returns is not in the serializer context, so it is decoded by reflection.
        var info = context.GetTypeInfo(type);
        var model = info is null ? JsonSerializer.Deserialize(json, type, Reflection) : JsonSerializer.Deserialize(json, info);
        ExampleAssert.Matches(json, model);
    }
}
