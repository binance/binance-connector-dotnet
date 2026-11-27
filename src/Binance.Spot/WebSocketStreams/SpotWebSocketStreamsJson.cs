//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.Spot.WebSocketStreams;

/// <summary>The System.Text.Json context of the Spot WebSocketStreams models: <c>JsonSerializer.Serialize(value, SpotWebSocketStreamsJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(AggTradeResponse), TypeInfoPropertyName = "AggTradeResponse")]
[JsonSerializable(typeof(AvgPriceResponse), TypeInfoPropertyName = "AvgPriceResponse")]
[JsonSerializable(typeof(BalanceUpdate), TypeInfoPropertyName = "BalanceUpdate")]
[JsonSerializable(typeof(BlockTradeResponse), TypeInfoPropertyName = "BlockTradeResponse")]
[JsonSerializable(typeof(BookTickerResponse), TypeInfoPropertyName = "BookTickerResponse")]
[JsonSerializable(typeof(DiffBookDepthResponse), TypeInfoPropertyName = "DiffBookDepthResponse")]
[JsonSerializable(typeof(EventStreamTerminated), TypeInfoPropertyName = "EventStreamTerminated")]
[JsonSerializable(typeof(ExecutionReport), TypeInfoPropertyName = "ExecutionReport")]
[JsonSerializable(typeof(ExternalLockUpdate), TypeInfoPropertyName = "ExternalLockUpdate")]
[JsonSerializable(typeof(KlineOffsetResponse), TypeInfoPropertyName = "KlineOffsetResponse")]
[JsonSerializable(typeof(KlineResponse), TypeInfoPropertyName = "KlineResponse")]
[JsonSerializable(typeof(List<AllMarketRollingWindowTickerResponseInner>), TypeInfoPropertyName = "ListAllMarketRollingWindowTickerResponseInner")]
[JsonSerializable(typeof(List<AllMiniTickerResponseInner>), TypeInfoPropertyName = "ListAllMiniTickerResponseInner")]
[JsonSerializable(typeof(ListStatus), TypeInfoPropertyName = "ListStatus")]
[JsonSerializable(typeof(MiniTickerResponse), TypeInfoPropertyName = "MiniTickerResponse")]
[JsonSerializable(typeof(OutboundAccountPosition), TypeInfoPropertyName = "OutboundAccountPosition")]
[JsonSerializable(typeof(PartialBookDepthResponse), TypeInfoPropertyName = "PartialBookDepthResponse")]
[JsonSerializable(typeof(ReferencePriceResponse), TypeInfoPropertyName = "ReferencePriceResponse")]
[JsonSerializable(typeof(RollingWindowTickerResponse), TypeInfoPropertyName = "RollingWindowTickerResponse")]
[JsonSerializable(typeof(TickerResponse), TypeInfoPropertyName = "TickerResponse")]
[JsonSerializable(typeof(TradeResponse), TypeInfoPropertyName = "TradeResponse")]
[JsonSerializable(typeof(UserDataStreamEventsResponse), TypeInfoPropertyName = "UserDataStreamEventsResponse")]
public sealed partial class SpotWebSocketStreamsJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the Spot WebSocketStreams (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
