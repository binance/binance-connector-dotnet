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
using Binance.DerivativesTradingPortfolioMarginPro.WebSocketStreams;

namespace Binance.DerivativesTradingPortfolioMarginPro.Tests.WebSocketStreams;

/// <summary>Decodes an instance of every model, built from its schema, with the serializer context of the module.</summary>
public class ModelTests
{
    private static readonly JsonSerializerOptions Reflection = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };

    public static TheoryData<string, string> Cases => new()
    {
        { "PmProAccountUpdate", "{\"E\":1564745798939,\"u\":\"1.99999999\",\"eq\":\"30.23416728\",\"ae\":\"30.23416728\",\"im\":\"20.6783833\",\"mm\":\"15.11708371\",\"avb\":\"3.98972738\",\"vmw\":\"3.98972738\"}" },
        { "Risklevelchange", "{\"E\":1587727187525,\"u\":\"1.99999999\",\"s\":\"MARGIN_CALL\",\"eq\":\"30.23416728\",\"ae\":\"30.23416728\",\"m\":\"15.11708371\"}" },
        { "UserDataStreamEventsResponse/PmProAccountUpdate", "{\"E\":1564745798939,\"u\":\"1.99999999\",\"eq\":\"30.23416728\",\"ae\":\"30.23416728\",\"im\":\"20.6783833\",\"mm\":\"15.11708371\",\"avb\":\"3.98972738\",\"vmw\":\"3.98972738\"}" },
        { "UserDataStreamEventsResponse/Risklevelchange", "{\"E\":1587727187525,\"u\":\"1.99999999\",\"s\":\"MARGIN_CALL\",\"eq\":\"30.23416728\",\"ae\":\"30.23416728\",\"m\":\"15.11708371\"}" },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void DecodesAndRoundTrips(string name, string json)
    {
        var assembly = typeof(DerivativesTradingPortfolioMarginProWebSocketStreams).Assembly;
        var type = assembly.GetType($"Binance.DerivativesTradingPortfolioMarginPro.WebSocketStreams.{name.Split('/')[0]}", throwOnError: true)!;
        var context = (JsonSerializerContext)assembly.GetType("Binance.DerivativesTradingPortfolioMarginPro.WebSocketStreams.DerivativesTradingPortfolioMarginProWebSocketStreamsJson")!.GetProperty("Default")!.GetValue(null)!;
        // A model that no operation returns is not in the serializer context, so it is decoded by reflection.
        var info = context.GetTypeInfo(type);
        var model = info is null ? JsonSerializer.Deserialize(json, type, Reflection) : JsonSerializer.Deserialize(json, info);
        ExampleAssert.Matches(json, model);
    }
}
