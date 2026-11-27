//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.DerivativesTradingOptions.WebSocketStreams;

/// <summary>The System.Text.Json context of the DerivativesTradingOptions WebSocketStreams models: <c>JsonSerializer.Serialize(value, DerivativesTradingOptionsWebSocketStreamsJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(AccountUpdate), TypeInfoPropertyName = "AccountUpdate")]
[JsonSerializable(typeof(BalancePositionUpdate), TypeInfoPropertyName = "BalancePositionUpdate")]
[JsonSerializable(typeof(DiffBookDepthStreamsResponse), TypeInfoPropertyName = "DiffBookDepthStreamsResponse")]
[JsonSerializable(typeof(GreekUpdate), TypeInfoPropertyName = "GreekUpdate")]
[JsonSerializable(typeof(Hour24TickerResponse), TypeInfoPropertyName = "Hour24TickerResponse")]
[JsonSerializable(typeof(IndividualSymbolBookTickerStreamsResponse), TypeInfoPropertyName = "IndividualSymbolBookTickerStreamsResponse")]
[JsonSerializable(typeof(KlineCandlestickStreamsResponse), TypeInfoPropertyName = "KlineCandlestickStreamsResponse")]
[JsonSerializable(typeof(List<IndexPriceStreamsResponseInner>), TypeInfoPropertyName = "ListIndexPriceStreamsResponseInner")]
[JsonSerializable(typeof(List<OpenInterestResponseInner>), TypeInfoPropertyName = "ListOpenInterestResponseInner")]
[JsonSerializable(typeof(List<OptionMarkPriceResponseInner>), TypeInfoPropertyName = "ListOptionMarkPriceResponseInner")]
[JsonSerializable(typeof(ListenKeyExpired), TypeInfoPropertyName = "ListenKeyExpired")]
[JsonSerializable(typeof(NewSymbolInfoResponse), TypeInfoPropertyName = "NewSymbolInfoResponse")]
[JsonSerializable(typeof(OrderTradeUpdate), TypeInfoPropertyName = "OrderTradeUpdate")]
[JsonSerializable(typeof(PartialBookDepthStreamsResponse), TypeInfoPropertyName = "PartialBookDepthStreamsResponse")]
[JsonSerializable(typeof(RiskLevelChange), TypeInfoPropertyName = "RiskLevelChange")]
[JsonSerializable(typeof(TradeStreamsResponse), TypeInfoPropertyName = "TradeStreamsResponse")]
[JsonSerializable(typeof(UserDataStreamEventsResponse), TypeInfoPropertyName = "UserDataStreamEventsResponse")]
public sealed partial class DerivativesTradingOptionsWebSocketStreamsJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the DerivativesTradingOptions WebSocketStreams (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
