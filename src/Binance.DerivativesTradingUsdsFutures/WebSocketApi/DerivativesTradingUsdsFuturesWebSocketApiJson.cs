//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.DerivativesTradingUsdsFutures.WebSocketApi;

/// <summary>The System.Text.Json context of the DerivativesTradingUsdsFutures WebSocketApi models: <c>JsonSerializer.Serialize(value, DerivativesTradingUsdsFuturesWebSocketApiJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(AccountInformationResponseResult), TypeInfoPropertyName = "AccountInformationResponseResult")]
[JsonSerializable(typeof(AccountInformationV2ResponseResult), TypeInfoPropertyName = "AccountInformationV2ResponseResult")]
[JsonSerializable(typeof(CancelAlgoOrderResponseResult), TypeInfoPropertyName = "CancelAlgoOrderResponseResult")]
[JsonSerializable(typeof(CancelOrderResponseResult), TypeInfoPropertyName = "CancelOrderResponseResult")]
[JsonSerializable(typeof(JsonElement), TypeInfoPropertyName = "JsonElement")]
[JsonSerializable(typeof(KeepaliveUserDataStreamResponseResult), TypeInfoPropertyName = "KeepaliveUserDataStreamResponseResult")]
[JsonSerializable(typeof(List<FuturesAccountBalanceResponseResultInner>), TypeInfoPropertyName = "ListFuturesAccountBalanceResponseResultInner")]
[JsonSerializable(typeof(List<PositionInformationResponseResultInner>), TypeInfoPropertyName = "ListPositionInformationResponseResultInner")]
[JsonSerializable(typeof(List<PositionInformationV2ResponseResultInner>), TypeInfoPropertyName = "ListPositionInformationV2ResponseResultInner")]
[JsonSerializable(typeof(List<SymbolOrderBookTickerResponse2ResultInner>), TypeInfoPropertyName = "ListSymbolOrderBookTickerResponse2ResultInner")]
[JsonSerializable(typeof(List<SymbolPriceTickerResponse2ResultInner>), TypeInfoPropertyName = "ListSymbolPriceTickerResponse2ResultInner")]
[JsonSerializable(typeof(ModifyOrderResponseResult), TypeInfoPropertyName = "ModifyOrderResponseResult")]
[JsonSerializable(typeof(NewAlgoOrderResponseResult), TypeInfoPropertyName = "NewAlgoOrderResponseResult")]
[JsonSerializable(typeof(NewOrderResponseResult), TypeInfoPropertyName = "NewOrderResponseResult")]
[JsonSerializable(typeof(OrderBookResponseResult), TypeInfoPropertyName = "OrderBookResponseResult")]
[JsonSerializable(typeof(QueryOrderResponseResult), TypeInfoPropertyName = "QueryOrderResponseResult")]
[JsonSerializable(typeof(StartUserDataStreamResponseResult), TypeInfoPropertyName = "StartUserDataStreamResponseResult")]
[JsonSerializable(typeof(SymbolOrderBookTickerResponse1), TypeInfoPropertyName = "SymbolOrderBookTickerResponse1")]
[JsonSerializable(typeof(SymbolOrderBookTickerResponse1Result), TypeInfoPropertyName = "SymbolOrderBookTickerResponse1Result")]
[JsonSerializable(typeof(SymbolOrderBookTickerResponse2), TypeInfoPropertyName = "SymbolOrderBookTickerResponse2")]
[JsonSerializable(typeof(SymbolOrderBookTickerResponseResult), TypeInfoPropertyName = "SymbolOrderBookTickerResponseResult")]
[JsonSerializable(typeof(SymbolPriceTickerResponse1), TypeInfoPropertyName = "SymbolPriceTickerResponse1")]
[JsonSerializable(typeof(SymbolPriceTickerResponse1Result), TypeInfoPropertyName = "SymbolPriceTickerResponse1Result")]
[JsonSerializable(typeof(SymbolPriceTickerResponse2), TypeInfoPropertyName = "SymbolPriceTickerResponse2")]
[JsonSerializable(typeof(SymbolPriceTickerResponseResult), TypeInfoPropertyName = "SymbolPriceTickerResponseResult")]
public sealed partial class DerivativesTradingUsdsFuturesWebSocketApiJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the DerivativesTradingUsdsFutures WebSocketApi (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
