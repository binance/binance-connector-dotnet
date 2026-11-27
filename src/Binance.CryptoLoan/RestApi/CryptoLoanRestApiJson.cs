//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.CryptoLoan.RestApi;

/// <summary>The System.Text.Json context of the CryptoLoan RestApi models: <c>JsonSerializer.Serialize(value, CryptoLoanRestApiJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(CheckCollateralRepayRateResponse), TypeInfoPropertyName = "CheckCollateralRepayRateResponse")]
[JsonSerializable(typeof(FlexibleLoanAdjustLtvResponse), TypeInfoPropertyName = "FlexibleLoanAdjustLtvResponse")]
[JsonSerializable(typeof(FlexibleLoanBorrowResponse), TypeInfoPropertyName = "FlexibleLoanBorrowResponse")]
[JsonSerializable(typeof(FlexibleLoanRepayResponse), TypeInfoPropertyName = "FlexibleLoanRepayResponse")]
[JsonSerializable(typeof(GetFlexibleLoanAssetsDataResponse), TypeInfoPropertyName = "GetFlexibleLoanAssetsDataResponse")]
[JsonSerializable(typeof(GetFlexibleLoanBorrowHistoryResponse), TypeInfoPropertyName = "GetFlexibleLoanBorrowHistoryResponse")]
[JsonSerializable(typeof(GetFlexibleLoanCollateralAssetsDataResponse), TypeInfoPropertyName = "GetFlexibleLoanCollateralAssetsDataResponse")]
[JsonSerializable(typeof(GetFlexibleLoanInterestRateHistoryResponse), TypeInfoPropertyName = "GetFlexibleLoanInterestRateHistoryResponse")]
[JsonSerializable(typeof(GetFlexibleLoanLiquidationHistoryResponse), TypeInfoPropertyName = "GetFlexibleLoanLiquidationHistoryResponse")]
[JsonSerializable(typeof(GetFlexibleLoanLtvAdjustmentHistoryResponse), TypeInfoPropertyName = "GetFlexibleLoanLtvAdjustmentHistoryResponse")]
[JsonSerializable(typeof(GetFlexibleLoanOngoingOrdersResponse), TypeInfoPropertyName = "GetFlexibleLoanOngoingOrdersResponse")]
[JsonSerializable(typeof(GetFlexibleLoanRepaymentHistoryResponse), TypeInfoPropertyName = "GetFlexibleLoanRepaymentHistoryResponse")]
public sealed partial class CryptoLoanRestApiJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the CryptoLoan RestApi (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
