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
using Binance.GiftCard.RestApi;

namespace Binance.GiftCard.Tests.RestApi;

/// <summary>Decodes an instance of every model, built from its schema, with the serializer context of the module.</summary>
public class ModelTests
{
    private static readonly JsonSerializerOptions Reflection = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };

    public static TheoryData<string, string> Cases => new()
    {
        { "CreateADualTokenGiftCardResponse", "{\"code\":\"000000\",\"message\":\"success\",\"data\":{\"referenceNo\":\"0033002144060553\",\"code\":\"6H9EKF5ECCWFBHGE\",\"expiredTime\":1727417154000},\"success\":true}" },
        { "CreateADualTokenGiftCardResponseData", "{\"referenceNo\":\"0033002144060553\",\"code\":\"6H9EKF5ECCWFBHGE\",\"expiredTime\":1727417154000}" },
        { "CreateASingleTokenGiftCardResponse", "{\"code\":\"000000\",\"message\":\"success\",\"data\":{\"referenceNo\":\"0033002144060553\",\"code\":\"6H9EKF5ECCWFBHGE\",\"expiredTime\":1727417154000},\"success\":true}" },
        { "FetchRsaPublicKeyResponse", "{\"code\":\"000000\",\"message\":\"success\",\"data\":\"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCXBBVKLAc1GQ5FsIFFqOHrPTox5noBONIKr+IAedTR9FkVxq6e65updEbfdhRNkMOeYIO2i0UylrjGC0X8YSoIszmrVHeV0l06Zh1oJuZos1+7N+WLuz9JvlPaawof3GUakTxYWWCa9+8KIbLKsoKMdfS96VT+8iOXO3quMGKUmQIDAQAB\",\"success\":true}" },
        { "FetchTokenLimitResponse", "{\"code\":\"000000\",\"message\":\"success\",\"data\":[{\"coin\":\"BNB\",\"fromMin\":\"0.01\",\"fromMax\":\"1\"}],\"success\":true}" },
        { "FetchTokenLimitResponseDataInner", "{\"coin\":\"BNB\",\"fromMin\":\"0.01\",\"fromMax\":\"1\"}" },
        { "RedeemABinanceGiftCardResponse", "{\"code\":\"000000\",\"message\":\"success\",\"data\":{\"referenceNo\":\"0033002328060227\",\"identityNo\":\"10317392647411060736\",\"token\":\"BNB\",\"amount\":\"0.00000001\"},\"success\":true}" },
        { "RedeemABinanceGiftCardResponseData", "{\"referenceNo\":\"0033002328060227\",\"identityNo\":\"10317392647411060736\",\"token\":\"BNB\",\"amount\":\"0.00000001\"}" },
        { "VerifyBinanceGiftCardByGiftCardNumberResponse", "{\"code\":\"000000\",\"message\":\"success\",\"data\":{\"valid\":true,\"token\":\"BNB\",\"amount\":\"0.00000001\"},\"success\":true}" },
        { "VerifyBinanceGiftCardByGiftCardNumberResponseData", "{\"valid\":true,\"token\":\"BNB\",\"amount\":\"0.00000001\"}" },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void DecodesAndRoundTrips(string name, string json)
    {
        var assembly = typeof(GiftCardRestApi).Assembly;
        var type = assembly.GetType($"Binance.GiftCard.RestApi.{name.Split('/')[0]}", throwOnError: true)!;
        var context = (JsonSerializerContext)assembly.GetType("Binance.GiftCard.RestApi.GiftCardRestApiJson")!.GetProperty("Default")!.GetValue(null)!;
        // A model that no operation returns is not in the serializer context, so it is decoded by reflection.
        var info = context.GetTypeInfo(type);
        var model = info is null ? JsonSerializer.Deserialize(json, type, Reflection) : JsonSerializer.Deserialize(json, info);
        ExampleAssert.Matches(json, model);
    }
}
