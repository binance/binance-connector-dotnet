//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.W3WPrediction.RestApi;

/// <summary>The System.Text.Json context of the W3WPrediction RestApi models: <c>JsonSerializer.Serialize(value, W3WPredictionRestApiJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(ApplyMmDepositResponse), TypeInfoPropertyName = "ApplyMmDepositResponse")]
[JsonSerializable(typeof(ApplyMmWithdrawResponse), TypeInfoPropertyName = "ApplyMmWithdrawResponse")]
[JsonSerializable(typeof(BatchCancelOrdersResponse), TypeInfoPropertyName = "BatchCancelOrdersResponse")]
[JsonSerializable(typeof(BatchRedeemResponse), TypeInfoPropertyName = "BatchRedeemResponse")]
[JsonSerializable(typeof(CreateInboundTransferResponse), TypeInfoPropertyName = "CreateInboundTransferResponse")]
[JsonSerializable(typeof(CreateOtcBlocktradeResponse), TypeInfoPropertyName = "CreateOtcBlocktradeResponse")]
[JsonSerializable(typeof(CreateOutboundTransferResponse), TypeInfoPropertyName = "CreateOutboundTransferResponse")]
[JsonSerializable(typeof(FulfilOtcBlocktradeResponse), TypeInfoPropertyName = "FulfilOtcBlocktradeResponse")]
[JsonSerializable(typeof(GetMarketDetailResponse), TypeInfoPropertyName = "GetMarketDetailResponse")]
[JsonSerializable(typeof(GetOtcBlocktradeDetailResponse), TypeInfoPropertyName = "GetOtcBlocktradeDetailResponse")]
[JsonSerializable(typeof(GetOtcBlocktradeEventsResponse), TypeInfoPropertyName = "GetOtcBlocktradeEventsResponse")]
[JsonSerializable(typeof(GetOtcReservedBalancesResponse), TypeInfoPropertyName = "GetOtcReservedBalancesResponse")]
[JsonSerializable(typeof(GetPortfolioResponse), TypeInfoPropertyName = "GetPortfolioResponse")]
[JsonSerializable(typeof(GetPositionByTokenResponse), TypeInfoPropertyName = "GetPositionByTokenResponse")]
[JsonSerializable(typeof(GetQuotaStatusResponse), TypeInfoPropertyName = "GetQuotaStatusResponse")]
[JsonSerializable(typeof(GetQuoteResponse), TypeInfoPropertyName = "GetQuoteResponse")]
[JsonSerializable(typeof(GetRedeemStatusResponse), TypeInfoPropertyName = "GetRedeemStatusResponse")]
[JsonSerializable(typeof(List<BatchCancelOrdersCancelInfoListParameterInner>), TypeInfoPropertyName = "ListBatchCancelOrdersCancelInfoListParameterInner")]
[JsonSerializable(typeof(List<GetOtcReservedBalancesAssetsParameterInner>), TypeInfoPropertyName = "ListGetOtcReservedBalancesAssetsParameterInner")]
[JsonSerializable(typeof(List<MarketSearchResponseInner>), TypeInfoPropertyName = "ListMarketSearchResponseInner")]
[JsonSerializable(typeof(ListOtcBlocktradesResponse), TypeInfoPropertyName = "ListOtcBlocktradesResponse")]
[JsonSerializable(typeof(ListPredictionCategoriesResponse), TypeInfoPropertyName = "ListPredictionCategoriesResponse")]
[JsonSerializable(typeof(ListPredictionMarketsResponse), TypeInfoPropertyName = "ListPredictionMarketsResponse")]
[JsonSerializable(typeof(ListPredictionWalletsResponse), TypeInfoPropertyName = "ListPredictionWalletsResponse")]
[JsonSerializable(typeof(PlaceOrderResponse), TypeInfoPropertyName = "PlaceOrderResponse")]
[JsonSerializable(typeof(PreviewOtcBlocktradeResponse), TypeInfoPropertyName = "PreviewOtcBlocktradeResponse")]
[JsonSerializable(typeof(QueryActiveOrdersResponse), TypeInfoPropertyName = "QueryActiveOrdersResponse")]
[JsonSerializable(typeof(QueryLastTradePriceResponse), TypeInfoPropertyName = "QueryLastTradePriceResponse")]
[JsonSerializable(typeof(QueryOrderBookResponse), TypeInfoPropertyName = "QueryOrderBookResponse")]
[JsonSerializable(typeof(QueryOrderHistoryResponse), TypeInfoPropertyName = "QueryOrderHistoryResponse")]
[JsonSerializable(typeof(QueryPaymentOptionBalancesResponse), TypeInfoPropertyName = "QueryPaymentOptionBalancesResponse")]
[JsonSerializable(typeof(QueryPnLResponse), TypeInfoPropertyName = "QueryPnLResponse")]
[JsonSerializable(typeof(QueryPositionsByFilterResponse), TypeInfoPropertyName = "QueryPositionsByFilterResponse")]
[JsonSerializable(typeof(QueryPositionsResponse), TypeInfoPropertyName = "QueryPositionsResponse")]
[JsonSerializable(typeof(QuerySettledPositionHistoryResponse), TypeInfoPropertyName = "QuerySettledPositionHistoryResponse")]
[JsonSerializable(typeof(QueryTransferListResponse), TypeInfoPropertyName = "QueryTransferListResponse")]
[JsonSerializable(typeof(QueryTransferStatusResponse), TypeInfoPropertyName = "QueryTransferStatusResponse")]
[JsonSerializable(typeof(RemoveOtcBlocktradesResponse), TypeInfoPropertyName = "RemoveOtcBlocktradesResponse")]
public sealed partial class W3WPredictionRestApiJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the W3WPrediction RestApi (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
