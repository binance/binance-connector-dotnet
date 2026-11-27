//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.Algo.RestApi;

/// <summary>The System.Text.Json context of the Algo RestApi models: <c>JsonSerializer.Serialize(value, AlgoRestApiJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(CancelAlgoOrderFutureAlgoResponse), TypeInfoPropertyName = "CancelAlgoOrderFutureAlgoResponse")]
[JsonSerializable(typeof(CancelAlgoOrderSpotAlgoResponse), TypeInfoPropertyName = "CancelAlgoOrderSpotAlgoResponse")]
[JsonSerializable(typeof(QueryCurrentAlgoOpenOrdersFutureAlgoResponse), TypeInfoPropertyName = "QueryCurrentAlgoOpenOrdersFutureAlgoResponse")]
[JsonSerializable(typeof(QueryCurrentAlgoOpenOrdersSpotAlgoResponse), TypeInfoPropertyName = "QueryCurrentAlgoOpenOrdersSpotAlgoResponse")]
[JsonSerializable(typeof(QueryHistoricalAlgoOrdersFutureAlgoResponse), TypeInfoPropertyName = "QueryHistoricalAlgoOrdersFutureAlgoResponse")]
[JsonSerializable(typeof(QueryHistoricalAlgoOrdersSpotAlgoResponse), TypeInfoPropertyName = "QueryHistoricalAlgoOrdersSpotAlgoResponse")]
[JsonSerializable(typeof(QuerySubOrdersFutureAlgoResponse), TypeInfoPropertyName = "QuerySubOrdersFutureAlgoResponse")]
[JsonSerializable(typeof(QuerySubOrdersSpotAlgoResponse), TypeInfoPropertyName = "QuerySubOrdersSpotAlgoResponse")]
[JsonSerializable(typeof(TimeWeightedAveragePriceFutureAlgoResponse), TypeInfoPropertyName = "TimeWeightedAveragePriceFutureAlgoResponse")]
[JsonSerializable(typeof(TimeWeightedAveragePriceSpotAlgoResponse), TypeInfoPropertyName = "TimeWeightedAveragePriceSpotAlgoResponse")]
[JsonSerializable(typeof(VolumeParticipationFutureAlgoResponse), TypeInfoPropertyName = "VolumeParticipationFutureAlgoResponse")]
[JsonSerializable(typeof(VolumeParticipationResponse), TypeInfoPropertyName = "VolumeParticipationResponse")]
public sealed partial class AlgoRestApiJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the Algo RestApi (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
