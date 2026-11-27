//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.DerivativesTradingUsdsFutures.WebSocketStreams;

/// <summary>The System.Text.Json context of the DerivativesTradingUsdsFutures WebSocketStreams models: <c>JsonSerializer.Serialize(value, DerivativesTradingUsdsFuturesWebSocketStreamsJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(AccountConfigUpdate), TypeInfoPropertyName = "AccountConfigUpdate")]
[JsonSerializable(typeof(AccountUpdate), TypeInfoPropertyName = "AccountUpdate")]
[JsonSerializable(typeof(AggregateTradeStreamsResponse), TypeInfoPropertyName = "AggregateTradeStreamsResponse")]
[JsonSerializable(typeof(AlgoUpdate), TypeInfoPropertyName = "AlgoUpdate")]
[JsonSerializable(typeof(AllBookTickersStreamResponse), TypeInfoPropertyName = "AllBookTickersStreamResponse")]
[JsonSerializable(typeof(AllMarketLiquidationOrderStreamsResponse), TypeInfoPropertyName = "AllMarketLiquidationOrderStreamsResponse")]
[JsonSerializable(typeof(CompositeIndexSymbolInformationStreamsResponse), TypeInfoPropertyName = "CompositeIndexSymbolInformationStreamsResponse")]
[JsonSerializable(typeof(ConditionalOrderTriggerReject), TypeInfoPropertyName = "ConditionalOrderTriggerReject")]
[JsonSerializable(typeof(ContinuousContractKlineCandlestickStreamsResponse), TypeInfoPropertyName = "ContinuousContractKlineCandlestickStreamsResponse")]
[JsonSerializable(typeof(ContractInfoStreamResponse), TypeInfoPropertyName = "ContractInfoStreamResponse")]
[JsonSerializable(typeof(DiffBookDepthStreamsResponse), TypeInfoPropertyName = "DiffBookDepthStreamsResponse")]
[JsonSerializable(typeof(GridUpdate), TypeInfoPropertyName = "GridUpdate")]
[JsonSerializable(typeof(IndividualSymbolBookTickerStreamsResponse), TypeInfoPropertyName = "IndividualSymbolBookTickerStreamsResponse")]
[JsonSerializable(typeof(IndividualSymbolMiniTickerStreamResponse), TypeInfoPropertyName = "IndividualSymbolMiniTickerStreamResponse")]
[JsonSerializable(typeof(IndividualSymbolTickerStreamsResponse), TypeInfoPropertyName = "IndividualSymbolTickerStreamsResponse")]
[JsonSerializable(typeof(KlineCandlestickStreamsResponse), TypeInfoPropertyName = "KlineCandlestickStreamsResponse")]
[JsonSerializable(typeof(LiquidationOrderStreamsResponse), TypeInfoPropertyName = "LiquidationOrderStreamsResponse")]
[JsonSerializable(typeof(List<AllMarketMiniTickersStreamResponseInner>), TypeInfoPropertyName = "ListAllMarketMiniTickersStreamResponseInner")]
[JsonSerializable(typeof(List<AllMarketTickersStreamsResponseInner>), TypeInfoPropertyName = "ListAllMarketTickersStreamsResponseInner")]
[JsonSerializable(typeof(List<AssetIndexResponseInner>), TypeInfoPropertyName = "ListAssetIndexResponseInner")]
[JsonSerializable(typeof(List<MarkPriceStreamForAllMarketResponseInner>), TypeInfoPropertyName = "ListMarkPriceStreamForAllMarketResponseInner")]
[JsonSerializable(typeof(ListenKeyExpired), TypeInfoPropertyName = "ListenKeyExpired")]
[JsonSerializable(typeof(MarginCall), TypeInfoPropertyName = "MarginCall")]
[JsonSerializable(typeof(MarkPriceStreamResponse), TypeInfoPropertyName = "MarkPriceStreamResponse")]
[JsonSerializable(typeof(OrderTradeUpdate), TypeInfoPropertyName = "OrderTradeUpdate")]
[JsonSerializable(typeof(PartialBookDepthStreamsResponse), TypeInfoPropertyName = "PartialBookDepthStreamsResponse")]
[JsonSerializable(typeof(RpiDiffBookDepthStreamsResponse), TypeInfoPropertyName = "RpiDiffBookDepthStreamsResponse")]
[JsonSerializable(typeof(StrategyUpdate), TypeInfoPropertyName = "StrategyUpdate")]
[JsonSerializable(typeof(TradeLite), TypeInfoPropertyName = "TradeLite")]
[JsonSerializable(typeof(TradingSessionStreamResponse), TypeInfoPropertyName = "TradingSessionStreamResponse")]
[JsonSerializable(typeof(UserDataStreamEventsResponse), TypeInfoPropertyName = "UserDataStreamEventsResponse")]
public sealed partial class DerivativesTradingUsdsFuturesWebSocketStreamsJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the DerivativesTradingUsdsFutures WebSocketStreams (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
