//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.DerivativesTradingPortfolioMarginPro.RestApi;

/// <summary>The System.Text.Json context of the DerivativesTradingPortfolioMarginPro RestApi models: <c>JsonSerializer.Serialize(value, DerivativesTradingPortfolioMarginProRestApiJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(BnbTransferResponse), TypeInfoPropertyName = "BnbTransferResponse")]
[JsonSerializable(typeof(ChangeAutoRepayFuturesStatusResponse), TypeInfoPropertyName = "ChangeAutoRepayFuturesStatusResponse")]
[JsonSerializable(typeof(DeleteMarginCallLevelResponse), TypeInfoPropertyName = "DeleteMarginCallLevelResponse")]
[JsonSerializable(typeof(FundAutoCollectionResponse), TypeInfoPropertyName = "FundAutoCollectionResponse")]
[JsonSerializable(typeof(FundCollectionByAssetResponse), TypeInfoPropertyName = "FundCollectionByAssetResponse")]
[JsonSerializable(typeof(GetAutoRepayFuturesStatusResponse), TypeInfoPropertyName = "GetAutoRepayFuturesStatusResponse")]
[JsonSerializable(typeof(GetDeltaModeStatusResponse), TypeInfoPropertyName = "GetDeltaModeStatusResponse")]
[JsonSerializable(typeof(GetMarginCallLevelResponse), TypeInfoPropertyName = "GetMarginCallLevelResponse")]
[JsonSerializable(typeof(GetPortfolioMarginProAccountInfoResponse), TypeInfoPropertyName = "GetPortfolioMarginProAccountInfoResponse")]
[JsonSerializable(typeof(GetPortfolioMarginProSpanAccountInfoResponse), TypeInfoPropertyName = "GetPortfolioMarginProSpanAccountInfoResponse")]
[JsonSerializable(typeof(GetTransferableEarnAssetBalanceForPortfolioMarginResponse), TypeInfoPropertyName = "GetTransferableEarnAssetBalanceForPortfolioMarginResponse")]
[JsonSerializable(typeof(List<GetPortfolioMarginAssetLeverageResponseInner>), TypeInfoPropertyName = "ListGetPortfolioMarginAssetLeverageResponseInner")]
[JsonSerializable(typeof(List<GetPortfolioMarginProAccountBalanceResponseInner>), TypeInfoPropertyName = "ListGetPortfolioMarginProAccountBalanceResponseInner")]
[JsonSerializable(typeof(List<GetPortfolioMarginTieredCollateralRatesResponseInner>), TypeInfoPropertyName = "ListGetPortfolioMarginTieredCollateralRatesResponseInner")]
[JsonSerializable(typeof(List<PortfolioMarginCollateralRateResponseInner>), TypeInfoPropertyName = "ListPortfolioMarginCollateralRateResponseInner")]
[JsonSerializable(typeof(List<PortfolioMarginProTieredCollateralRateResponseInner>), TypeInfoPropertyName = "ListPortfolioMarginProTieredCollateralRateResponseInner")]
[JsonSerializable(typeof(List<QueryPortfolioMarginAssetIndexPriceResponseInner>), TypeInfoPropertyName = "ListQueryPortfolioMarginAssetIndexPriceResponseInner")]
[JsonSerializable(typeof(List<QueryPortfolioMarginProNegativeBalanceInterestHistoryResponseInner>), TypeInfoPropertyName = "ListQueryPortfolioMarginProNegativeBalanceInterestHistoryResponseInner")]
[JsonSerializable(typeof(PortfolioMarginProBankruptcyLoanRepayResponse), TypeInfoPropertyName = "PortfolioMarginProBankruptcyLoanRepayResponse")]
[JsonSerializable(typeof(QueryPortfolioMarginProBankruptcyLoanAmountResponse), TypeInfoPropertyName = "QueryPortfolioMarginProBankruptcyLoanAmountResponse")]
[JsonSerializable(typeof(QueryPortfolioMarginProBankruptcyLoanRepayHistoryResponse), TypeInfoPropertyName = "QueryPortfolioMarginProBankruptcyLoanRepayHistoryResponse")]
[JsonSerializable(typeof(RepayFuturesNegativeBalanceResponse), TypeInfoPropertyName = "RepayFuturesNegativeBalanceResponse")]
[JsonSerializable(typeof(SetMarginCallLevelResponse), TypeInfoPropertyName = "SetMarginCallLevelResponse")]
[JsonSerializable(typeof(SwitchDeltaModeResponse), TypeInfoPropertyName = "SwitchDeltaModeResponse")]
[JsonSerializable(typeof(TransferLdusdtRwusdForPortfolioMarginResponse), TypeInfoPropertyName = "TransferLdusdtRwusdForPortfolioMarginResponse")]
public sealed partial class DerivativesTradingPortfolioMarginProRestApiJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the DerivativesTradingPortfolioMarginPro RestApi (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
