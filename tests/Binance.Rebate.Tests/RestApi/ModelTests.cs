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
using Binance.Rebate.RestApi;

namespace Binance.Rebate.Tests.RestApi;

/// <summary>Decodes an instance of every model, built from its schema, with the serializer context of the module.</summary>
public class ModelTests
{
    private static readonly JsonSerializerOptions Reflection = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };

    public static TheoryData<string, string> Cases => new()
    {
        { "GetSpotRebateHistoryRecordsResponse", "{\"status\":\"OK\",\"type\":\"GENERAL\",\"code\":\"000000000\",\"data\":{\"page\":1,\"totalRecords\":2,\"totalPageNum\":1,\"data\":[{\"asset\":\"USDT\",\"type\":1,\"amount\":\"0.0001126\",\"updateTime\":1637651320000}]}}" },
        { "GetSpotRebateHistoryRecordsResponseData", "{\"page\":1,\"totalRecords\":2,\"totalPageNum\":1,\"data\":[{\"asset\":\"USDT\",\"type\":1,\"amount\":\"0.0001126\",\"updateTime\":1637651320000}]}" },
        { "GetSpotRebateHistoryRecordsResponseDataDataInner", "{\"asset\":\"USDT\",\"type\":1,\"amount\":\"0.0001126\",\"updateTime\":1637651320000}" },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void DecodesAndRoundTrips(string name, string json)
    {
        var assembly = typeof(RebateRestApi).Assembly;
        var type = assembly.GetType($"Binance.Rebate.RestApi.{name.Split('/')[0]}", throwOnError: true)!;
        var context = (JsonSerializerContext)assembly.GetType("Binance.Rebate.RestApi.RebateRestApiJson")!.GetProperty("Default")!.GetValue(null)!;
        // A model that no operation returns is not in the serializer context, so it is decoded by reflection.
        var info = context.GetTypeInfo(type);
        var model = info is null ? JsonSerializer.Deserialize(json, type, Reflection) : JsonSerializer.Deserialize(json, info);
        ExampleAssert.Matches(json, model);
    }
}
