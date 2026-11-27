//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.Alpha.RestApi;

/// <summary>The System.Text.Json context of the Alpha RestApi models: <c>JsonSerializer.Serialize(value, AlphaRestApiJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(AggregatedTradesResponse), TypeInfoPropertyName = "AggregatedTradesResponse")]
[JsonSerializable(typeof(FullDepthResponse), TypeInfoPropertyName = "FullDepthResponse")]
[JsonSerializable(typeof(GetExchangeInfoResponse), TypeInfoPropertyName = "GetExchangeInfoResponse")]
[JsonSerializable(typeof(KlinesResponse), TypeInfoPropertyName = "KlinesResponse")]
[JsonSerializable(typeof(TickerResponse), TypeInfoPropertyName = "TickerResponse")]
[JsonSerializable(typeof(TokenListResponse), TypeInfoPropertyName = "TokenListResponse")]
[JsonSerializable(typeof(long))]
[JsonSerializable(typeof(string))]
public sealed partial class AlphaRestApiJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the Alpha RestApi (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
