//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.VipLoan.RestApi;

/// <summary>The System.Text.Json context of the VipLoan RestApi models: <c>JsonSerializer.Serialize(value, VipLoanRestApiJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(CheckVIPLoanCollateralAccountResponse), TypeInfoPropertyName = "CheckVIPLoanCollateralAccountResponse")]
[JsonSerializable(typeof(GetCollateralAssetDataResponse), TypeInfoPropertyName = "GetCollateralAssetDataResponse")]
[JsonSerializable(typeof(GetLoanableAssetsDataResponse), TypeInfoPropertyName = "GetLoanableAssetsDataResponse")]
[JsonSerializable(typeof(GetVIPLoanAccruedInterestResponse), TypeInfoPropertyName = "GetVIPLoanAccruedInterestResponse")]
[JsonSerializable(typeof(GetVIPLoanInterestRateHistoryResponse), TypeInfoPropertyName = "GetVIPLoanInterestRateHistoryResponse")]
[JsonSerializable(typeof(GetVIPLoanOngoingOrdersResponse), TypeInfoPropertyName = "GetVIPLoanOngoingOrdersResponse")]
[JsonSerializable(typeof(GetVIPLoanRepaymentHistoryResponse), TypeInfoPropertyName = "GetVIPLoanRepaymentHistoryResponse")]
[JsonSerializable(typeof(List<GetBorrowInterestRateResponseInner>), TypeInfoPropertyName = "ListGetBorrowInterestRateResponseInner")]
[JsonSerializable(typeof(QueryApplicationStatusResponse), TypeInfoPropertyName = "QueryApplicationStatusResponse")]
[JsonSerializable(typeof(QueryVIPLoanFixedRateMarketResponse), TypeInfoPropertyName = "QueryVIPLoanFixedRateMarketResponse")]
[JsonSerializable(typeof(VipLoanBorrowResponse), TypeInfoPropertyName = "VipLoanBorrowResponse")]
[JsonSerializable(typeof(VipLoanFixedRateBorrowResponse), TypeInfoPropertyName = "VipLoanFixedRateBorrowResponse")]
[JsonSerializable(typeof(VipLoanRenewResponse), TypeInfoPropertyName = "VipLoanRenewResponse")]
[JsonSerializable(typeof(VipLoanRepayResponse), TypeInfoPropertyName = "VipLoanRepayResponse")]
public sealed partial class VipLoanRestApiJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the VipLoan RestApi (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
