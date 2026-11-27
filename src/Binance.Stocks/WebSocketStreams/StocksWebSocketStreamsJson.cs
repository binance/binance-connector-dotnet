//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.Stocks.WebSocketStreams;

/// <summary>The System.Text.Json context of the Stocks WebSocketStreams models: <c>JsonSerializer.Serialize(value, StocksWebSocketStreamsJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(CalendarStreamResponse), TypeInfoPropertyName = "CalendarStreamResponse")]
[JsonSerializable(typeof(KlineStreamResponse), TypeInfoPropertyName = "KlineStreamResponse")]
[JsonSerializable(typeof(OrderReportStreamResponse), TypeInfoPropertyName = "OrderReportStreamResponse")]
[JsonSerializable(typeof(PriceStreamResponse), TypeInfoPropertyName = "PriceStreamResponse")]
[JsonSerializable(typeof(QuoteStreamResponse), TypeInfoPropertyName = "QuoteStreamResponse")]
[JsonSerializable(typeof(TradabilityStreamResponse), TypeInfoPropertyName = "TradabilityStreamResponse")]
[JsonSerializable(typeof(TradingStatusStreamResponse), TypeInfoPropertyName = "TradingStatusStreamResponse")]
public sealed partial class StocksWebSocketStreamsJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the Stocks WebSocketStreams (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
