//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.Alpha.WebSocketStreams;

/// <summary>The System.Text.Json context of the Alpha WebSocketStreams models: <c>JsonSerializer.Serialize(value, AlphaWebSocketStreamsJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(AggregateTradeStreamResponse), TypeInfoPropertyName = "AggregateTradeStreamResponse")]
[JsonSerializable(typeof(AllBookTickerStreamResponse), TypeInfoPropertyName = "AllBookTickerStreamResponse")]
[JsonSerializable(typeof(AllMiniTickerStreamResponse), TypeInfoPropertyName = "AllMiniTickerStreamResponse")]
[JsonSerializable(typeof(AllTickerStreamResponse), TypeInfoPropertyName = "AllTickerStreamResponse")]
[JsonSerializable(typeof(AllTokens24hTickerStreamResponse), TypeInfoPropertyName = "AllTokens24hTickerStreamResponse")]
[JsonSerializable(typeof(BookTickerStreamResponse), TypeInfoPropertyName = "BookTickerStreamResponse")]
[JsonSerializable(typeof(ContractKlineStreamResponse), TypeInfoPropertyName = "ContractKlineStreamResponse")]
[JsonSerializable(typeof(FullDepthStreamResponse), TypeInfoPropertyName = "FullDepthStreamResponse")]
[JsonSerializable(typeof(KlineStreamResponse), TypeInfoPropertyName = "KlineStreamResponse")]
[JsonSerializable(typeof(MiniTickerStreamResponse), TypeInfoPropertyName = "MiniTickerStreamResponse")]
[JsonSerializable(typeof(PartialDepthStreamResponse), TypeInfoPropertyName = "PartialDepthStreamResponse")]
[JsonSerializable(typeof(TickerStreamResponse), TypeInfoPropertyName = "TickerStreamResponse")]
[JsonSerializable(typeof(TradeStreamResponse), TypeInfoPropertyName = "TradeStreamResponse")]
public sealed partial class AlphaWebSocketStreamsJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the Alpha WebSocketStreams (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
