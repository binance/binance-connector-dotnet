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
using Binance.Fiat.RestApi;

namespace Binance.Fiat.Tests.RestApi;

/// <summary>Decodes an instance of every model, built from its schema, with the serializer context of the module.</summary>
public class ModelTests
{
    private static readonly JsonSerializerOptions Reflection = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };

    public static TheoryData<string, string> Cases => new()
    {
        { "DepositResponse", "{\"code\":\"000000\",\"message\":\"success\",\"data\":{\"orderId\":\"04595xxxxxxxxx37\"}}" },
        { "DepositResponseData", "{\"orderId\":\"04595xxxxxxxxx37\"}" },
        { "FiatWithdrawRequestAccountInfo", "{\"accountNumber\":\"1056894222\",\"agency\":\"1234\",\"bankCodeForPix\":\"222\",\"accountType\":\"current\"}" },
        { "FiatWithdrawResponse", "{\"code\":\"000000\",\"message\":\"success\",\"data\":{\"orderId\":\"04595xxxxxxxxx37\"}}" },
        { "FiatWithdrawResponseData", "{\"orderId\":\"04595xxxxxxxxx37\"}" },
        { "GetFiatDepositWithdrawHistoryResponse", "{\"code\":\"000000\",\"message\":\"success\",\"data\":[{\"orderNo\":\"7d76d611-0568-4f43-afb6-24cac7767365\",\"fiatCurrency\":\"BRL\",\"indicatedAmount\":\"10.00\",\"amount\":\"10.00\",\"totalFee\":\"0.00\",\"method\":\"BankAccount\",\"status\":\"Expired\",\"createTime\":1626144956000,\"updateTime\":1626400907000}],\"total\":1,\"success\":true}" },
        { "GetFiatDepositWithdrawHistoryResponseDataInner", "{\"orderNo\":\"7d76d611-0568-4f43-afb6-24cac7767365\",\"fiatCurrency\":\"BRL\",\"indicatedAmount\":\"10.00\",\"amount\":\"10.00\",\"totalFee\":\"0.00\",\"method\":\"BankAccount\",\"status\":\"Expired\",\"createTime\":1626144956000,\"updateTime\":1626400907000}" },
        { "GetFiatPaymentsHistoryResponse", "{\"code\":\"000000\",\"message\":\"success\",\"data\":[{\"orderNo\":\"353fca443f06466db0c4dc89f94f027a\",\"sourceAmount\":\"20.0\",\"fiatCurrency\":\"EUR\",\"obtainAmount\":\"4.462\",\"cryptoCurrency\":\"LUNA\",\"totalFee\":\"0.2\",\"price\":\"4.437472\",\"status\":\"Failed\",\"paymentMethod\":\"Credit Card\",\"createTime\":1624529919000,\"updateTime\":1624529919000}],\"total\":1,\"success\":true}" },
        { "GetFiatPaymentsHistoryResponseDataInner", "{\"orderNo\":\"353fca443f06466db0c4dc89f94f027a\",\"sourceAmount\":\"20.0\",\"fiatCurrency\":\"EUR\",\"obtainAmount\":\"4.462\",\"cryptoCurrency\":\"LUNA\",\"totalFee\":\"0.2\",\"price\":\"4.437472\",\"status\":\"Failed\",\"paymentMethod\":\"Credit Card\",\"createTime\":1624529919000,\"updateTime\":1624529919000}" },
        { "GetOrderDetailResponse", "{\"code\":\"000000\",\"message\":\"success\",\"data\":{\"orderId\":\"036752*678\",\"orderStatus\":\"ORDER_INITIAL\",\"amount\":\"4.33\",\"fee\":\"0.43\",\"fiatCurrency\":\"***\",\"errorCode\":\"x\",\"errorMessage\":\"x\",\"ext\":{}}}" },
        { "GetOrderDetailResponseData", "{\"orderId\":\"036752*678\",\"orderStatus\":\"ORDER_INITIAL\",\"amount\":\"4.33\",\"fee\":\"0.43\",\"fiatCurrency\":\"***\",\"errorCode\":\"x\",\"errorMessage\":\"x\",\"ext\":{}}" },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void DecodesAndRoundTrips(string name, string json)
    {
        var assembly = typeof(FiatRestApi).Assembly;
        var type = assembly.GetType($"Binance.Fiat.RestApi.{name.Split('/')[0]}", throwOnError: true)!;
        var context = (JsonSerializerContext)assembly.GetType("Binance.Fiat.RestApi.FiatRestApiJson")!.GetProperty("Default")!.GetValue(null)!;
        // A model that no operation returns is not in the serializer context, so it is decoded by reflection.
        var info = context.GetTypeInfo(type);
        var model = info is null ? JsonSerializer.Deserialize(json, type, Reflection) : JsonSerializer.Deserialize(json, info);
        ExampleAssert.Matches(json, model);
    }
}
