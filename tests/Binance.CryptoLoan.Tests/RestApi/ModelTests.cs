//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;
using Binance.Common.Tests;
using Binance.CryptoLoan.RestApi;

namespace Binance.CryptoLoan.Tests.RestApi;

/// <summary>Decodes an instance of every model, built from its schema, with the serializer context of the module.</summary>
public class ModelTests
{
    private static readonly JsonSerializerOptions Reflection = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };

    public static TheoryData<string, string> Cases => new()
    {
        { "CheckCollateralRepayRateResponse", "{\"loanCoin\":\"BUSD\",\"collateralCoin\":\"BNB\",\"rate\":\"300.36781234\"}" },
        { "FlexibleLoanAdjustLtvResponse", "{\"loanCoin\":\"BUSD\",\"collateralCoin\":\"BNB\",\"direction\":\"ADDITIONAL\",\"adjustmentAmount\":\"5.235\",\"currentLTV\":\"0.52\",\"status\":\"Succeeds\"}" },
        { "FlexibleLoanBorrowResponse", "{\"loanCoin\":\"BUSD\",\"loanAmount\":\"100.5\",\"collateralCoin\":\"BNB\",\"collateralAmount\":\"50.5\",\"status\":\"Succeeds\"}" },
        { "FlexibleLoanRepayResponse", "{\"loanCoin\":\"BUSD\",\"collateralCoin\":\"BNB\",\"remainingDebt\":\"100.5\",\"remainingCollateral\":\"5.253\",\"fullRepayment\":false,\"currentLTV\":\"0.25\",\"repayStatus\":\"REPAID\"}" },
        { "GetFlexibleLoanAssetsDataResponse", "{\"rows\":[{\"loanCoin\":\"BUSD\",\"flexibleInterestRate\":\"0.00000491\",\"flexibleMinLimit\":\"100\",\"flexibleMaxLimit\":\"1000000\"}],\"total\":1}" },
        { "GetFlexibleLoanAssetsDataResponseRowsInner", "{\"loanCoin\":\"BUSD\",\"flexibleInterestRate\":\"0.00000491\",\"flexibleMinLimit\":\"100\",\"flexibleMaxLimit\":\"1000000\"}" },
        { "GetFlexibleLoanBorrowHistoryResponse", "{\"rows\":[{\"loanCoin\":\"BUSD\",\"initialLoanAmount\":\"10000\",\"collateralCoin\":\"BNB\",\"initialCollateralAmount\":\"49.27565492\",\"borrowTime\":1575018510000,\"status\":\"SUCCESS\"}],\"total\":1}" },
        { "GetFlexibleLoanBorrowHistoryResponseRowsInner", "{\"loanCoin\":\"BUSD\",\"initialLoanAmount\":\"10000\",\"collateralCoin\":\"BNB\",\"initialCollateralAmount\":\"49.27565492\",\"borrowTime\":1575018510000,\"status\":\"SUCCESS\"}" },
        { "GetFlexibleLoanCollateralAssetsDataResponse", "{\"rows\":[{\"collateralCoin\":\"BNB\",\"initialLTV\":\"0.65\",\"marginCallLTV\":\"0.75\",\"liquidationLTV\":\"0.83\",\"maxLimit\":\"1000000\"}],\"total\":1}" },
        { "GetFlexibleLoanCollateralAssetsDataResponseRowsInner", "{\"collateralCoin\":\"BNB\",\"initialLTV\":\"0.65\",\"marginCallLTV\":\"0.75\",\"liquidationLTV\":\"0.83\",\"maxLimit\":\"1000000\"}" },
        { "GetFlexibleLoanInterestRateHistoryResponse", "{\"rows\":[{\"coin\":\"USDT\",\"annualizedInterestRate\":\"0.0647\",\"time\":1575018510000}],\"total\":2}" },
        { "GetFlexibleLoanInterestRateHistoryResponseRowsInner", "{\"coin\":\"USDT\",\"annualizedInterestRate\":\"0.0647\",\"time\":1575018510000}" },
        { "GetFlexibleLoanLiquidationHistoryResponse", "{\"rows\":[{\"loanCoin\":\"BUSD\",\"liquidationDebt\":\"10000\",\"collateralCoin\":\"BNB\",\"liquidationCollateralAmount\":\"123\",\"returnCollateralAmount\":\"0.2\",\"liquidationFee\":\"1.2\",\"liquidationStartingPrice\":\"49.27565492\",\"liquidationStartingTime\":1575018510000,\"status\":\"Liquidated\"}],\"total\":1}" },
        { "GetFlexibleLoanLiquidationHistoryResponseRowsInner", "{\"loanCoin\":\"BUSD\",\"liquidationDebt\":\"10000\",\"collateralCoin\":\"BNB\",\"liquidationCollateralAmount\":\"123\",\"returnCollateralAmount\":\"0.2\",\"liquidationFee\":\"1.2\",\"liquidationStartingPrice\":\"49.27565492\",\"liquidationStartingTime\":1575018510000,\"status\":\"Liquidated\"}" },
        { "GetFlexibleLoanLtvAdjustmentHistoryResponse", "{\"rows\":[{\"loanCoin\":\"BUSD\",\"collateralCoin\":\"BNB\",\"direction\":\"ADDITIONAL\",\"collateralAmount\":\"5.235\",\"preLTV\":\"0.78\",\"afterLTV\":\"0.56\",\"adjustTime\":1575018510000}],\"total\":1}" },
        { "GetFlexibleLoanLtvAdjustmentHistoryResponseRowsInner", "{\"loanCoin\":\"BUSD\",\"collateralCoin\":\"BNB\",\"direction\":\"ADDITIONAL\",\"collateralAmount\":\"5.235\",\"preLTV\":\"0.78\",\"afterLTV\":\"0.56\",\"adjustTime\":1575018510000}" },
        { "GetFlexibleLoanOngoingOrdersResponse", "{\"rows\":[{\"loanCoin\":\"BUSD\",\"totalDebt\":\"10000\",\"collateralCoin\":\"BNB\",\"collateralAmount\":\"49.27565492\",\"currentLTV\":\"0.57\"}],\"total\":1}" },
        { "GetFlexibleLoanOngoingOrdersResponseRowsInner", "{\"loanCoin\":\"BUSD\",\"totalDebt\":\"10000\",\"collateralCoin\":\"BNB\",\"collateralAmount\":\"49.27565492\",\"currentLTV\":\"0.57\"}" },
        { "GetFlexibleLoanRepaymentHistoryResponse", "{\"rows\":[{\"loanCoin\":\"BUSD\",\"repayAmount\":\"10000\",\"collateralCoin\":\"BNB\",\"collateralReturn\":\"49.27565492\",\"repayStatus\":\"REPAID\",\"repayTime\":1575018510000}],\"total\":1}" },
        { "GetFlexibleLoanRepaymentHistoryResponseRowsInner", "{\"loanCoin\":\"BUSD\",\"repayAmount\":\"10000\",\"collateralCoin\":\"BNB\",\"collateralReturn\":\"49.27565492\",\"repayStatus\":\"REPAID\",\"repayTime\":1575018510000}" },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void DecodesAndRoundTrips(string name, string json)
    {
        var assembly = typeof(CryptoLoanRestApi).Assembly;
        var type = assembly.GetType($"Binance.CryptoLoan.RestApi.{name.Split('/')[0]}", throwOnError: true)!;
        var context = (JsonSerializerContext)assembly.GetType("Binance.CryptoLoan.RestApi.CryptoLoanRestApiJson")!.GetProperty("Default")!.GetValue(null)!;
        // A model that no operation returns is not in the serializer context, so it is decoded by reflection.
        var info = context.GetTypeInfo(type);
        var model = info is null ? JsonSerializer.Deserialize(json, type, Reflection) : JsonSerializer.Deserialize(json, info);
        ExampleAssert.Matches(json, model);
    }
}
