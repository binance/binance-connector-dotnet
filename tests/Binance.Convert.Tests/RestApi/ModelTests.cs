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
using Binance.Convert.RestApi;

namespace Binance.Convert.Tests.RestApi;

/// <summary>Decodes an instance of every model, built from its schema, with the serializer context of the module.</summary>
public class ModelTests
{
    private static readonly JsonSerializerOptions Reflection = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };

    public static TheoryData<string, string> Cases => new()
    {
        { "AcceptQuoteResponse", "{\"orderId\":\"933256278426274426\",\"createTime\":1623381330472,\"orderStatus\":\"PROCESS\"}" },
        { "CancelLimitOrderResponse", "{\"orderId\":\"1603680255057330400\",\"status\":\"CANCELED\"}" },
        { "GetConvertTradeHistoryResponse", "{\"list\":[{\"quoteId\":\"f3b91c525b2644c7bc1e1cd31b6e1aa6\",\"orderId\":\"940708407462087200\",\"orderStatus\":\"SUCCESS\",\"fromAsset\":\"USDT\",\"fromAmount\":\"20\",\"toAsset\":\"BNB\",\"toAmount\":\"0.06154036\",\"ratio\":\"0.00307702\",\"inverseRatio\":\"324.99\",\"createTime\":1624248872184}],\"startTime\":1623824139000,\"endTime\":1626416139000,\"limit\":100,\"moreData\":false}" },
        { "GetConvertTradeHistoryResponseListInner", "{\"quoteId\":\"f3b91c525b2644c7bc1e1cd31b6e1aa6\",\"orderId\":\"940708407462087200\",\"orderStatus\":\"SUCCESS\",\"fromAsset\":\"USDT\",\"fromAmount\":\"20\",\"toAsset\":\"BNB\",\"toAmount\":\"0.06154036\",\"ratio\":\"0.00307702\",\"inverseRatio\":\"324.99\",\"createTime\":1624248872184}" },
        { "ListAllConvertPairsResponseInner", "{\"fromAsset\":\"BTC\",\"toAsset\":\"USDT\",\"fromAssetMinAmount\":\"0.0004\",\"fromAssetMaxAmount\":\"50\",\"toAssetMinAmount\":\"20\",\"toAssetMaxAmount\":\"2500000\"}" },
        { "OrderStatusResponse", "{\"orderId\":\"933256278426274400\",\"orderStatus\":\"SUCCESS\",\"fromAsset\":\"BTC\",\"fromAmount\":\"0.00054414\",\"toAsset\":\"USDT\",\"toAmount\":\"20\",\"ratio\":\"36755\",\"inverseRatio\":\"0.00002721\",\"createTime\":1623381330472}" },
        { "PlaceLimitOrderResponse", "{\"orderId\":\"1603680255057330400\",\"status\":\"PROCESS\"}" },
        { "QueryLimitOpenOrdersResponse", "{\"list\":[{\"quoteId\":\"18sdf87kh9df\",\"orderId\":1150901289839,\"orderStatus\":\"SUCCESS\",\"fromAsset\":\"BNB\",\"fromAmount\":\"10\",\"toAsset\":\"USDT\",\"toAmount\":\"2317.89\",\"ratio\":\"231.789\",\"inverseRatio\":\"0.00431427\",\"createTime\":1614089498000,\"expiredTimestamp\":1614099498000}]}" },
        { "QueryLimitOpenOrdersResponseListInner", "{\"quoteId\":\"18sdf87kh9df\",\"orderId\":1150901289839,\"orderStatus\":\"SUCCESS\",\"fromAsset\":\"BNB\",\"fromAmount\":\"10\",\"toAsset\":\"USDT\",\"toAmount\":\"2317.89\",\"ratio\":\"231.789\",\"inverseRatio\":\"0.00431427\",\"createTime\":1614089498000,\"expiredTimestamp\":1614099498000}" },
        { "QueryOrderQuantityPrecisionPerAssetResponseInner", "{\"asset\":\"BTC\",\"fraction\":8}" },
        { "SendQuoteRequestResponse", "{\"quoteId\":\"12415572564\",\"ratio\":\"38163.7\",\"inverseRatio\":\"0.0000262\",\"validTimestamp\":1623319461670,\"toAmount\":\"3816.37\",\"fromAmount\":\"0.1\"}" },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void DecodesAndRoundTrips(string name, string json)
    {
        var assembly = typeof(ConvertRestApi).Assembly;
        var type = assembly.GetType($"Binance.Convert.RestApi.{name.Split('/')[0]}", throwOnError: true)!;
        var context = (JsonSerializerContext)assembly.GetType("Binance.Convert.RestApi.ConvertRestApiJson")!.GetProperty("Default")!.GetValue(null)!;
        // A model that no operation returns is not in the serializer context, so it is decoded by reflection.
        var info = context.GetTypeInfo(type);
        var model = info is null ? JsonSerializer.Deserialize(json, type, Reflection) : JsonSerializer.Deserialize(json, info);
        ExampleAssert.Matches(json, model);
    }
}
