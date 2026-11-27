//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.MarginTrading.WebSocketStreams;

/// <summary>The System.Text.Json context of the MarginTrading WebSocketStreams models: <c>JsonSerializer.Serialize(value, MarginTradingWebSocketStreamsJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(BalanceUpdate), TypeInfoPropertyName = "BalanceUpdate")]
[JsonSerializable(typeof(ExecutionReport), TypeInfoPropertyName = "ExecutionReport")]
[JsonSerializable(typeof(ListStatus), TypeInfoPropertyName = "ListStatus")]
[JsonSerializable(typeof(ListenKeyExpired), TypeInfoPropertyName = "ListenKeyExpired")]
[JsonSerializable(typeof(MarginLevelStatusChange), TypeInfoPropertyName = "MarginLevelStatusChange")]
[JsonSerializable(typeof(OutboundAccountPosition), TypeInfoPropertyName = "OutboundAccountPosition")]
[JsonSerializable(typeof(RiskDataStreamEventsResponse), TypeInfoPropertyName = "RiskDataStreamEventsResponse")]
[JsonSerializable(typeof(TradeDataStreamEventsResponse), TypeInfoPropertyName = "TradeDataStreamEventsResponse")]
[JsonSerializable(typeof(UserLiabilityChange), TypeInfoPropertyName = "UserLiabilityChange")]
public sealed partial class MarginTradingWebSocketStreamsJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the MarginTrading WebSocketStreams (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
