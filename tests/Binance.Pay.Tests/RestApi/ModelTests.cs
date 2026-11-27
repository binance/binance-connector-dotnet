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
using Binance.Pay.RestApi;

namespace Binance.Pay.Tests.RestApi;

/// <summary>Decodes an instance of every model, built from its schema, with the serializer context of the module.</summary>
public class ModelTests
{
    private static readonly JsonSerializerOptions Reflection = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };

    public static TheoryData<string, string> Cases => new()
    {
        { "GetPayTradeHistoryResponse", "{\"code\":\"000000\",\"message\":\"success\",\"data\":[{\"orderType\":\"C2C\",\"transactionId\":\"M_P_71505104267788288\",\"transactionTime\":1610090460133,\"amount\":\"23.72469206\",\"currency\":\"BNB\",\"walletType\":1,\"walletTypes\":[1],\"fundsDetail\":[{\"currency\":\"USDT\",\"amount\":\"1.2\",\"walletAssetCost\":{\"k\":\"x\"}}],\"payerInfo\":{\"name\":\"Jack\",\"type\":\"USER\",\"binanceId\":\"12345678\"},\"receiverInfo\":{\"name\":\"Alan\",\"type\":\"MERCHANT\",\"email\":\"alan@binance.com\",\"binanceId\":\"34355667\",\"accountId\":\"21326891\",\"countryCode\":\"1\",\"phoneNumber\":\"8057651210\",\"mobileCode\":\"US\",\"extend\":{\"institutionName\":\"x\",\"cardNumber\":\"x\",\"digitalWalletId\":\"x\"}}}],\"success\":true}" },
        { "GetPayTradeHistoryResponseDataInner", "{\"orderType\":\"C2C\",\"transactionId\":\"M_P_71505104267788288\",\"transactionTime\":1610090460133,\"amount\":\"23.72469206\",\"currency\":\"BNB\",\"walletType\":1,\"walletTypes\":[1],\"fundsDetail\":[{\"currency\":\"USDT\",\"amount\":\"1.2\",\"walletAssetCost\":{\"k\":\"x\"}}],\"payerInfo\":{\"name\":\"Jack\",\"type\":\"USER\",\"binanceId\":\"12345678\"},\"receiverInfo\":{\"name\":\"Alan\",\"type\":\"MERCHANT\",\"email\":\"alan@binance.com\",\"binanceId\":\"34355667\",\"accountId\":\"21326891\",\"countryCode\":\"1\",\"phoneNumber\":\"8057651210\",\"mobileCode\":\"US\",\"extend\":{\"institutionName\":\"x\",\"cardNumber\":\"x\",\"digitalWalletId\":\"x\"}}}" },
        { "GetPayTradeHistoryResponseDataInnerFundsDetailInner", "{\"currency\":\"USDT\",\"amount\":\"1.2\",\"walletAssetCost\":{\"k\":\"x\"}}" },
        { "GetPayTradeHistoryResponseDataInnerPayerInfo", "{\"name\":\"Jack\",\"type\":\"USER\",\"binanceId\":\"12345678\"}" },
        { "GetPayTradeHistoryResponseDataInnerReceiverInfo", "{\"name\":\"Alan\",\"type\":\"MERCHANT\",\"email\":\"alan@binance.com\",\"binanceId\":\"34355667\",\"accountId\":\"21326891\",\"countryCode\":\"1\",\"phoneNumber\":\"8057651210\",\"mobileCode\":\"US\",\"extend\":{\"institutionName\":\"x\",\"cardNumber\":\"x\",\"digitalWalletId\":\"x\"}}" },
        { "GetPayTradeHistoryResponseDataInnerReceiverInfoExtend", "{\"institutionName\":\"x\",\"cardNumber\":\"x\",\"digitalWalletId\":\"x\"}" },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void DecodesAndRoundTrips(string name, string json)
    {
        var assembly = typeof(PayRestApi).Assembly;
        var type = assembly.GetType($"Binance.Pay.RestApi.{name.Split('/')[0]}", throwOnError: true)!;
        var context = (JsonSerializerContext)assembly.GetType("Binance.Pay.RestApi.PayRestApiJson")!.GetProperty("Default")!.GetValue(null)!;
        // A model that no operation returns is not in the serializer context, so it is decoded by reflection.
        var info = context.GetTypeInfo(type);
        var model = info is null ? JsonSerializer.Deserialize(json, type, Reflection) : JsonSerializer.Deserialize(json, info);
        ExampleAssert.Matches(json, model);
    }
}
