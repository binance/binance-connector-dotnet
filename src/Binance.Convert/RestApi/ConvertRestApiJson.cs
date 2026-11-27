//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.Convert.RestApi;

/// <summary>The System.Text.Json context of the Convert RestApi models: <c>JsonSerializer.Serialize(value, ConvertRestApiJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(AcceptQuoteResponse), TypeInfoPropertyName = "AcceptQuoteResponse")]
[JsonSerializable(typeof(CancelLimitOrderResponse), TypeInfoPropertyName = "CancelLimitOrderResponse")]
[JsonSerializable(typeof(GetConvertTradeHistoryResponse), TypeInfoPropertyName = "GetConvertTradeHistoryResponse")]
[JsonSerializable(typeof(List<ListAllConvertPairsResponseInner>), TypeInfoPropertyName = "ListListAllConvertPairsResponseInner")]
[JsonSerializable(typeof(List<QueryOrderQuantityPrecisionPerAssetResponseInner>), TypeInfoPropertyName = "ListQueryOrderQuantityPrecisionPerAssetResponseInner")]
[JsonSerializable(typeof(OrderStatusResponse), TypeInfoPropertyName = "OrderStatusResponse")]
[JsonSerializable(typeof(PlaceLimitOrderResponse), TypeInfoPropertyName = "PlaceLimitOrderResponse")]
[JsonSerializable(typeof(QueryLimitOpenOrdersResponse), TypeInfoPropertyName = "QueryLimitOpenOrdersResponse")]
[JsonSerializable(typeof(SendQuoteRequestResponse), TypeInfoPropertyName = "SendQuoteRequestResponse")]
public sealed partial class ConvertRestApiJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the Convert RestApi (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
