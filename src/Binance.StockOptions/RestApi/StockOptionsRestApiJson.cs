//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.StockOptions.RestApi;

/// <summary>The System.Text.Json context of the StockOptions RestApi models: <c>JsonSerializer.Serialize(value, StockOptionsRestApiJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(CancelAllOptionOrdersResponse), TypeInfoPropertyName = "CancelAllOptionOrdersResponse")]
[JsonSerializable(typeof(CancelOptionOrderResponse), TypeInfoPropertyName = "CancelOptionOrderResponse")]
[JsonSerializable(typeof(CreateRenewListenKeyResponse), TypeInfoPropertyName = "CreateRenewListenKeyResponse")]
[JsonSerializable(typeof(List<CurrentOpenOptionOrdersResponseInner>), TypeInfoPropertyName = "ListCurrentOpenOptionOrdersResponseInner")]
[JsonSerializable(typeof(List<ExercisableOptionsResponseInner>), TypeInfoPropertyName = "ListExercisableOptionsResponseInner")]
[JsonSerializable(typeof(List<OptionContractsResponseInner>), TypeInfoPropertyName = "ListOptionContractsResponseInner")]
[JsonSerializable(typeof(List<OptionExpirationsResponseInner>), TypeInfoPropertyName = "ListOptionExpirationsResponseInner")]
[JsonSerializable(typeof(List<OptionPositionsResponseInner>), TypeInfoPropertyName = "ListOptionPositionsResponseInner")]
[JsonSerializable(typeof(OptionExchangeInfoResponse), TypeInfoPropertyName = "OptionExchangeInfoResponse")]
[JsonSerializable(typeof(OptionExerciseDetailResponse), TypeInfoPropertyName = "OptionExerciseDetailResponse")]
[JsonSerializable(typeof(OptionExerciseHistoryResponse), TypeInfoPropertyName = "OptionExerciseHistoryResponse")]
[JsonSerializable(typeof(OptionOrderDetailResponse), TypeInfoPropertyName = "OptionOrderDetailResponse")]
[JsonSerializable(typeof(OptionOrderHistoryResponse), TypeInfoPropertyName = "OptionOrderHistoryResponse")]
[JsonSerializable(typeof(OptionSettlementEventDetailResponse), TypeInfoPropertyName = "OptionSettlementEventDetailResponse")]
[JsonSerializable(typeof(OptionSettlementEventHistoryResponse), TypeInfoPropertyName = "OptionSettlementEventHistoryResponse")]
[JsonSerializable(typeof(OptionTradeHistoryResponse), TypeInfoPropertyName = "OptionTradeHistoryResponse")]
[JsonSerializable(typeof(PlaceOptionOrderResponse), TypeInfoPropertyName = "PlaceOptionOrderResponse")]
[JsonSerializable(typeof(SubmitOptionExerciseResponse), TypeInfoPropertyName = "SubmitOptionExerciseResponse")]
public sealed partial class StockOptionsRestApiJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the StockOptions RestApi (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
