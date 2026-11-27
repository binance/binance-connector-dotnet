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
using Binance.C2C.RestApi;

namespace Binance.C2C.Tests.RestApi;

/// <summary>Decodes an instance of every model, built from its schema, with the serializer context of the module.</summary>
public class ModelTests
{
    private static readonly JsonSerializerOptions Reflection = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };

    public static TheoryData<string, string> Cases => new()
    {
        { "GetC2CTradeHistoryResponse", "{\"code\":\"000000\",\"message\":\"success\",\"data\":[{\"orderNumber\":\"20219644646554779648\",\"advNo\":\"11218246497340923904\",\"tradeType\":\"SELL\",\"asset\":\"BUSD\",\"fiat\":\"CNY\",\"fiatSymbol\":\"￥\",\"amount\":\"5000.00000000\",\"totalPrice\":\"33400.00000000\",\"unitPrice\":\"6.68\",\"orderStatus\":\"COMPLETED\",\"createTime\":1619361369000,\"commission\":\"0\",\"counterPartNickName\":\"阿涛❤***\",\"payMethodName\":\"BANK\",\"additionalKycVerify\":0,\"takerCommissionRate\":\"0\",\"takerCommission\":\"0\",\"takerAmount\":\"343.4\",\"advertisementRole\":\"TAKER\"}],\"total\":1,\"success\":true}" },
        { "GetC2CTradeHistoryResponseDataInner", "{\"orderNumber\":\"20219644646554779648\",\"advNo\":\"11218246497340923904\",\"tradeType\":\"SELL\",\"asset\":\"BUSD\",\"fiat\":\"CNY\",\"fiatSymbol\":\"￥\",\"amount\":\"5000.00000000\",\"totalPrice\":\"33400.00000000\",\"unitPrice\":\"6.68\",\"orderStatus\":\"COMPLETED\",\"createTime\":1619361369000,\"commission\":\"0\",\"counterPartNickName\":\"阿涛❤***\",\"payMethodName\":\"BANK\",\"additionalKycVerify\":0,\"takerCommissionRate\":\"0\",\"takerCommission\":\"0\",\"takerAmount\":\"343.4\",\"advertisementRole\":\"TAKER\"}" },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void DecodesAndRoundTrips(string name, string json)
    {
        var assembly = typeof(C2CRestApi).Assembly;
        var type = assembly.GetType($"Binance.C2C.RestApi.{name.Split('/')[0]}", throwOnError: true)!;
        var context = (JsonSerializerContext)assembly.GetType("Binance.C2C.RestApi.C2CRestApiJson")!.GetProperty("Default")!.GetValue(null)!;
        // A model that no operation returns is not in the serializer context, so it is decoded by reflection.
        var info = context.GetTypeInfo(type);
        var model = info is null ? JsonSerializer.Deserialize(json, type, Reflection) : JsonSerializer.Deserialize(json, info);
        ExampleAssert.Matches(json, model);
    }
}
