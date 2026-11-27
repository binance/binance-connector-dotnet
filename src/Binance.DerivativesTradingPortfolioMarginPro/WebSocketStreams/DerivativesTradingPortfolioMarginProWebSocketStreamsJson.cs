//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.DerivativesTradingPortfolioMarginPro.WebSocketStreams;

/// <summary>The System.Text.Json context of the DerivativesTradingPortfolioMarginPro WebSocketStreams models: <c>JsonSerializer.Serialize(value, DerivativesTradingPortfolioMarginProWebSocketStreamsJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(PmProAccountUpdate), TypeInfoPropertyName = "PmProAccountUpdate")]
[JsonSerializable(typeof(Risklevelchange), TypeInfoPropertyName = "Risklevelchange")]
[JsonSerializable(typeof(UserDataStreamEventsResponse), TypeInfoPropertyName = "UserDataStreamEventsResponse")]
public sealed partial class DerivativesTradingPortfolioMarginProWebSocketStreamsJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the DerivativesTradingPortfolioMarginPro WebSocketStreams (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
