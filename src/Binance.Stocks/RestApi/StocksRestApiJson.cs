//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.Stocks.RestApi;

/// <summary>The System.Text.Json context of the Stocks RestApi models: <c>JsonSerializer.Serialize(value, StocksRestApiJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(BstocksCorporateActionRecordsResponse), TypeInfoPropertyName = "BstocksCorporateActionRecordsResponse")]
[JsonSerializable(typeof(CancelAllEquityOrdersResponse), TypeInfoPropertyName = "CancelAllEquityOrdersResponse")]
[JsonSerializable(typeof(CancelEquityOrderResponse), TypeInfoPropertyName = "CancelEquityOrderResponse")]
[JsonSerializable(typeof(CorporateActionRecordsResponse), TypeInfoPropertyName = "CorporateActionRecordsResponse")]
[JsonSerializable(typeof(CreateRenewListenKeyResponse), TypeInfoPropertyName = "CreateRenewListenKeyResponse")]
[JsonSerializable(typeof(EquityOrderDetailResponse), TypeInfoPropertyName = "EquityOrderDetailResponse")]
[JsonSerializable(typeof(EquityOrderHistoryResponse), TypeInfoPropertyName = "EquityOrderHistoryResponse")]
[JsonSerializable(typeof(EquityTradeHistoryResponse), TypeInfoPropertyName = "EquityTradeHistoryResponse")]
[JsonSerializable(typeof(ExchangeInfoResponse), TypeInfoPropertyName = "ExchangeInfoResponse")]
[JsonSerializable(typeof(LatestQuoteResponse), TypeInfoPropertyName = "LatestQuoteResponse")]
[JsonSerializable(typeof(List<CurrentOpenOrdersResponseInner>), TypeInfoPropertyName = "ListCurrentOpenOrdersResponseInner")]
[JsonSerializable(typeof(List<TokenizedAssetsResponseInner>), TypeInfoPropertyName = "ListTokenizedAssetsResponseInner")]
[JsonSerializable(typeof(PlaceEquityOrderResponse), TypeInfoPropertyName = "PlaceEquityOrderResponse")]
[JsonSerializable(typeof(SignUsEquityDisclaimerResponse), TypeInfoPropertyName = "SignUsEquityDisclaimerResponse")]
[JsonSerializable(typeof(TokenizedConvertHistoryResponse), TypeInfoPropertyName = "TokenizedConvertHistoryResponse")]
[JsonSerializable(typeof(TokenizedConvertStatusResponse), TypeInfoPropertyName = "TokenizedConvertStatusResponse")]
[JsonSerializable(typeof(TokenizedMintResponse), TypeInfoPropertyName = "TokenizedMintResponse")]
[JsonSerializable(typeof(TokenizedRedeemResponse), TypeInfoPropertyName = "TokenizedRedeemResponse")]
public sealed partial class StocksRestApiJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the Stocks RestApi (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
