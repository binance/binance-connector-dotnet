//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.CopyTrading.RestApi;

/// <summary>The System.Text.Json context of the CopyTrading RestApi models: <c>JsonSerializer.Serialize(value, CopyTradingRestApiJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(GetFuturesLeadTraderStatusResponse), TypeInfoPropertyName = "GetFuturesLeadTraderStatusResponse")]
[JsonSerializable(typeof(GetFuturesLeadTradingSymbolWhitelistResponse), TypeInfoPropertyName = "GetFuturesLeadTradingSymbolWhitelistResponse")]
public sealed partial class CopyTradingRestApiJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the CopyTrading RestApi (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
