//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.DerivativesTradingOptions.RestApi;

/// <summary>The System.Text.Json context of the DerivativesTradingOptions RestApi models: <c>JsonSerializer.Serialize(value, DerivativesTradingOptionsRestApiJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(AcceptBlockTradeOrderResponse), TypeInfoPropertyName = "AcceptBlockTradeOrderResponse")]
[JsonSerializable(typeof(AutoCancelAllOpenOrdersResponse), TypeInfoPropertyName = "AutoCancelAllOpenOrdersResponse")]
[JsonSerializable(typeof(CancelAllOptionOrdersByUnderlyingResponse), TypeInfoPropertyName = "CancelAllOptionOrdersByUnderlyingResponse")]
[JsonSerializable(typeof(CancelAllOptionOrdersOnSpecificSymbolResponse), TypeInfoPropertyName = "CancelAllOptionOrdersOnSpecificSymbolResponse")]
[JsonSerializable(typeof(CancelOptionOrderResponse), TypeInfoPropertyName = "CancelOptionOrderResponse")]
[JsonSerializable(typeof(CheckServerTimeResponse), TypeInfoPropertyName = "CheckServerTimeResponse")]
[JsonSerializable(typeof(ExchangeInformationResponse), TypeInfoPropertyName = "ExchangeInformationResponse")]
[JsonSerializable(typeof(ExtendBlockTradeOrderResponse), TypeInfoPropertyName = "ExtendBlockTradeOrderResponse")]
[JsonSerializable(typeof(GetAutoCancelAllOpenOrdersResponse), TypeInfoPropertyName = "GetAutoCancelAllOpenOrdersResponse")]
[JsonSerializable(typeof(GetMarketMakerProtectionConfigResponse), TypeInfoPropertyName = "GetMarketMakerProtectionConfigResponse")]
[JsonSerializable(typeof(IndexPriceResponse), TypeInfoPropertyName = "IndexPriceResponse")]
[JsonSerializable(typeof(JsonElement), TypeInfoPropertyName = "JsonElement")]
[JsonSerializable(typeof(List<AccountBlockTradeListResponseInner>), TypeInfoPropertyName = "ListAccountBlockTradeListResponseInner")]
[JsonSerializable(typeof(List<AccountFundingFlowResponseInner>), TypeInfoPropertyName = "ListAccountFundingFlowResponseInner")]
[JsonSerializable(typeof(List<AccountTradeListResponseInner>), TypeInfoPropertyName = "ListAccountTradeListResponseInner")]
[JsonSerializable(typeof(List<CancelMultipleOptionOrdersResponseInner>), TypeInfoPropertyName = "ListCancelMultipleOptionOrdersResponseInner")]
[JsonSerializable(typeof(List<HistoricalExerciseRecordsResponseInner>), TypeInfoPropertyName = "ListHistoricalExerciseRecordsResponseInner")]
[JsonSerializable(typeof(List<List<KlineCandlestickDataItemInner>>), TypeInfoPropertyName = "ListListKlineCandlestickDataItemInner")]
[JsonSerializable(typeof(List<NewBlockTradeOrderLegsParameterInner>), TypeInfoPropertyName = "ListNewBlockTradeOrderLegsParameterInner")]
[JsonSerializable(typeof(List<OpenInterestResponseInner>), TypeInfoPropertyName = "ListOpenInterestResponseInner")]
[JsonSerializable(typeof(List<OptionMarkPriceResponseInner>), TypeInfoPropertyName = "ListOptionMarkPriceResponseInner")]
[JsonSerializable(typeof(List<OptionPositionInformationResponseInner>), TypeInfoPropertyName = "ListOptionPositionInformationResponseInner")]
[JsonSerializable(typeof(List<PlaceMultipleOrdersOrdersParameterInner>), TypeInfoPropertyName = "ListPlaceMultipleOrdersOrdersParameterInner")]
[JsonSerializable(typeof(List<PlaceMultipleOrdersResponseInner>), TypeInfoPropertyName = "ListPlaceMultipleOrdersResponseInner")]
[JsonSerializable(typeof(List<QueryBlockTradeOrderResponseInner>), TypeInfoPropertyName = "ListQueryBlockTradeOrderResponseInner")]
[JsonSerializable(typeof(List<QueryCurrentOpenOptionOrdersResponseInner>), TypeInfoPropertyName = "ListQueryCurrentOpenOptionOrdersResponseInner")]
[JsonSerializable(typeof(List<QueryOptionOrderHistoryResponseInner>), TypeInfoPropertyName = "ListQueryOptionOrderHistoryResponseInner")]
[JsonSerializable(typeof(List<RecentBlockTradesListResponseInner>), TypeInfoPropertyName = "ListRecentBlockTradesListResponseInner")]
[JsonSerializable(typeof(List<RecentTradesListResponseInner>), TypeInfoPropertyName = "ListRecentTradesListResponseInner")]
[JsonSerializable(typeof(List<Ticker24hrPriceChangeStatisticsResponseInner>), TypeInfoPropertyName = "ListTicker24hrPriceChangeStatisticsResponseInner")]
[JsonSerializable(typeof(List<UserExerciseRecordResponseInner>), TypeInfoPropertyName = "ListUserExerciseRecordResponseInner")]
[JsonSerializable(typeof(NewBlockTradeOrderResponse), TypeInfoPropertyName = "NewBlockTradeOrderResponse")]
[JsonSerializable(typeof(NewOrderResponse), TypeInfoPropertyName = "NewOrderResponse")]
[JsonSerializable(typeof(OptionMarginAccountInformationResponse), TypeInfoPropertyName = "OptionMarginAccountInformationResponse")]
[JsonSerializable(typeof(OrderBookResponse), TypeInfoPropertyName = "OrderBookResponse")]
[JsonSerializable(typeof(QueryBlockTradeDetailsResponse), TypeInfoPropertyName = "QueryBlockTradeDetailsResponse")]
[JsonSerializable(typeof(QuerySingleOrderResponse), TypeInfoPropertyName = "QuerySingleOrderResponse")]
[JsonSerializable(typeof(ResetMarketMakerProtectionConfigResponse), TypeInfoPropertyName = "ResetMarketMakerProtectionConfigResponse")]
[JsonSerializable(typeof(SetAutoCancelAllOpenOrdersResponse), TypeInfoPropertyName = "SetAutoCancelAllOpenOrdersResponse")]
[JsonSerializable(typeof(SetMarketMakerProtectionConfigResponse), TypeInfoPropertyName = "SetMarketMakerProtectionConfigResponse")]
[JsonSerializable(typeof(StartUserDataStreamResponse), TypeInfoPropertyName = "StartUserDataStreamResponse")]
[JsonSerializable(typeof(TradfiOptionsContractResponse), TypeInfoPropertyName = "TradfiOptionsContractResponse")]
[JsonSerializable(typeof(UserCommissionResponse), TypeInfoPropertyName = "UserCommissionResponse")]
[JsonSerializable(typeof(long))]
[JsonSerializable(typeof(string))]
public sealed partial class DerivativesTradingOptionsRestApiJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the DerivativesTradingOptions RestApi (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
