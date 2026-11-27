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
using Binance.VipLoan.RestApi;

namespace Binance.VipLoan.Tests.RestApi;

/// <summary>Decodes an instance of every model, built from its schema, with the serializer context of the module.</summary>
public class ModelTests
{
    private static readonly JsonSerializerOptions Reflection = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };

    public static TheoryData<string, string> Cases => new()
    {
        { "CheckVIPLoanCollateralAccountResponse", "{\"rows\":[{\"collateralAccountId\":\"12345678\",\"collateralCoin\":\"BNB,BTC,ETH\"}],\"total\":2}" },
        { "CheckVIPLoanCollateralAccountResponseRowsInner", "{\"collateralAccountId\":\"12345678\",\"collateralCoin\":\"BNB,BTC,ETH\"}" },
        { "GetBorrowInterestRateResponseInner", "{\"asset\":\"BUSD\",\"flexibleDailyInterestRate\":\"0.001503\",\"flexibleYearlyInterestRate\":\"0.548595\",\"time\":1577233578000}" },
        { "GetCollateralAssetDataResponse", "{\"rows\":[{\"collateralCoin\":\"BUSD\",\"_1stCollateralRatio\":\"100%\",\"_1stCollateralRange\":\"1-10000000\",\"_2ndCollateralRatio\":\"80%\",\"_2ndCollateralRange\":\"10000000-100000000\",\"_3rdCollateralRatio\":\"60%\",\"_3rdCollateralRange\":\"100000000-1000000000\",\"_4thCollateralRatio\":\"0%\",\"_4thCollateralRange\":\">10000000000\"}],\"total\":1}" },
        { "GetCollateralAssetDataResponseRowsInner", "{\"collateralCoin\":\"BUSD\",\"_1stCollateralRatio\":\"100%\",\"_1stCollateralRange\":\"1-10000000\",\"_2ndCollateralRatio\":\"80%\",\"_2ndCollateralRange\":\"10000000-100000000\",\"_3rdCollateralRatio\":\"60%\",\"_3rdCollateralRange\":\"100000000-1000000000\",\"_4thCollateralRatio\":\"0%\",\"_4thCollateralRange\":\">10000000000\"}" },
        { "GetLoanableAssetsDataResponse", "{\"rows\":[{\"loanCoin\":\"BUSD\",\"_flexibleDailyInterestRate\":\"0.001503\",\"_flexibleYearlyInterestRate\":\"0.548595\",\"_30dDailyInterestRate\":\"0.000136\",\"_30dYearlyInterestRate\":\"0.03450\",\"_60dDailyInterestRate\":\"0.000145\",\"_60dYearlyInterestRate\":\"0.04103\",\"minLimit\":\"100\",\"maxLimit\":\"1000000\",\"vipLevel\":1}],\"total\":1}" },
        { "GetLoanableAssetsDataResponseRowsInner", "{\"loanCoin\":\"BUSD\",\"_flexibleDailyInterestRate\":\"0.001503\",\"_flexibleYearlyInterestRate\":\"0.548595\",\"_30dDailyInterestRate\":\"0.000136\",\"_30dYearlyInterestRate\":\"0.03450\",\"_60dDailyInterestRate\":\"0.000145\",\"_60dYearlyInterestRate\":\"0.04103\",\"minLimit\":\"100\",\"maxLimit\":\"1000000\",\"vipLevel\":1}" },
        { "GetVIPLoanAccruedInterestResponse", "{\"rows\":[{\"loanCoin\":\"USDT\",\"principalAmount\":\"10000\",\"interestAmount\":\"1.2\",\"annualInterestRate\":\"0.001273\",\"accrualTime\":1575018510000,\"orderId\":\"756783308056935400\"}],\"total\":1}" },
        { "GetVIPLoanAccruedInterestResponseRowsInner", "{\"loanCoin\":\"USDT\",\"principalAmount\":\"10000\",\"interestAmount\":\"1.2\",\"annualInterestRate\":\"0.001273\",\"accrualTime\":1575018510000,\"orderId\":\"756783308056935400\"}" },
        { "GetVIPLoanInterestRateHistoryResponse", "{\"rows\":[{\"coin\":\"USDT\",\"annualizedInterestRate\":\"0.0647\",\"time\":1575018510000}],\"total\":1}" },
        { "GetVIPLoanInterestRateHistoryResponseRowsInner", "{\"coin\":\"USDT\",\"annualizedInterestRate\":\"0.0647\",\"time\":1575018510000}" },
        { "GetVIPLoanOngoingOrdersResponse", "{\"rows\":[{\"orderId\":100000001,\"loanCoin\":\"BUSD\",\"totalDebt\":\"10000\",\"loanRate\":\"0.0123\",\"residualInterest\":\"10.27687923\",\"collateralAccountId\":\"12345678,23456789\",\"collateralCoin\":\"BNB,BNB-Earn,BTC,ETH\",\"totalCollateralValueAfterHaircut\":\"25000.27565492\",\"lockedCollateralValue\":\"25000.27565492\",\"currentLTV\":\"0.57\",\"expirationTime\":1575018510000,\"loanDate\":\"1676851200000\",\"loanTerm\":\"30days\"}],\"total\":1}" },
        { "GetVIPLoanOngoingOrdersResponseRowsInner", "{\"orderId\":100000001,\"loanCoin\":\"BUSD\",\"totalDebt\":\"10000\",\"loanRate\":\"0.0123\",\"residualInterest\":\"10.27687923\",\"collateralAccountId\":\"12345678,23456789\",\"collateralCoin\":\"BNB,BNB-Earn,BTC,ETH\",\"totalCollateralValueAfterHaircut\":\"25000.27565492\",\"lockedCollateralValue\":\"25000.27565492\",\"currentLTV\":\"0.57\",\"expirationTime\":1575018510000,\"loanDate\":\"1676851200000\",\"loanTerm\":\"30days\"}" },
        { "GetVIPLoanRepaymentHistoryResponse", "{\"rows\":[{\"loanCoin\":\"BUSD\",\"repayAmount\":\"10000\",\"repayPrincipal\":\"9500\",\"repayInterest\":\"500\",\"collateralCoin\":\"BNB,BTC,ETH\",\"repayStatus\":\"Repaid\",\"loanDate\":\"1676851200000\",\"repayTime\":\"1575018510000\",\"orderId\":\"756783308056935434\"}],\"total\":1}" },
        { "GetVIPLoanRepaymentHistoryResponseRowsInner", "{\"loanCoin\":\"BUSD\",\"repayAmount\":\"10000\",\"repayPrincipal\":\"9500\",\"repayInterest\":\"500\",\"collateralCoin\":\"BNB,BTC,ETH\",\"repayStatus\":\"Repaid\",\"loanDate\":\"1676851200000\",\"repayTime\":\"1575018510000\",\"orderId\":\"756783308056935434\"}" },
        { "QueryApplicationStatusResponse", "{\"rows\":[{\"loanAccountId\":\"12345678\",\"orderId\":\"12345678\",\"requestId\":\"12345678\",\"loanCoin\":\"BTC\",\"loanAmount\":\"100.55\",\"collateralAccountId\":\"12345678,12345678,12345678\",\"collateralCoin\":\"BUSD,USDT,USDT-Earn,ETH\",\"loanTerm\":\"30\",\"status\":\"Repaid\",\"loanDate\":\"1676851200000\"}],\"total\":1}" },
        { "QueryApplicationStatusResponseRowsInner", "{\"loanAccountId\":\"12345678\",\"orderId\":\"12345678\",\"requestId\":\"12345678\",\"loanCoin\":\"BTC\",\"loanAmount\":\"100.55\",\"collateralAccountId\":\"12345678,12345678,12345678\",\"collateralCoin\":\"BUSD,USDT,USDT-Earn,ETH\",\"loanTerm\":\"30\",\"status\":\"Repaid\",\"loanDate\":\"1676851200000\"}" },
        { "QueryVIPLoanFixedRateMarketResponse", "{\"total\":25,\"rows\":[{\"requestId\":1234567890,\"requestNo\":100001,\"coin\":\"USDT\",\"interestRate\":\"0.05\",\"duration\":30,\"minimumAmount\":\"100\",\"availableAmount\":\"1000000\",\"estimatedInterest\":\"4109.59\"}]}" },
        { "QueryVIPLoanFixedRateMarketResponseRowsInner", "{\"requestId\":1234567890,\"requestNo\":100001,\"coin\":\"USDT\",\"interestRate\":\"0.05\",\"duration\":30,\"minimumAmount\":\"100\",\"availableAmount\":\"1000000\",\"estimatedInterest\":\"4109.59\"}" },
        { "VipLoanBorrowResponse", "{\"loanAccountId\":\"12345678\",\"requestId\":\"12345678\",\"loanCoin\":\"BTC\",\"isFlexibleRate\":\"Yes\",\"loanAmount\":\"100.55\",\"collateralAccountId\":\"12345678,12345678,12345678\",\"collateralCoin\":\"BUSD,USDT,USDT-Earn,ETH\",\"loanTerm\":\"30\"}" },
        { "VipLoanFixedRateBorrowResponse", "{\"borrowCoin\":\"BUSD\",\"borrowAmount\":\"100.5\",\"actualReceivedAmount\":\"98.75\",\"collateralCoin\":\"BNB,BNB-Earn,ETH,BTC\",\"collateralAccountId\":\"12345,67890,13579\",\"borrowInterestRate\":\"0.01501231\",\"duration\":\"30Days\",\"autoRepay\":true,\"orderId\":123456789,\"status\":\"Succeeds\"}" },
        { "VipLoanRenewResponse", "{\"loanAccountId\":\"12345678\",\"loanCoin\":\"BTC\",\"loanAmount\":\"100.55\",\"collateralAccountId\":\"12345677,12345678,12345679\",\"collateralCoin\":\"BUSD,USDT,ETH\",\"loanTerm\":\"30\"}" },
        { "VipLoanRepayResponse", "{\"loanCoin\":\"BUSD\",\"repayAmount\":\"200.5\",\"remainingPrincipal\":\"100.5\",\"remainingInterest\":\"0\",\"collateralCoin\":\"BNB,BTC,ETH\",\"currentLTV\":\"0.25\",\"repayStatus\":\"Repaid\"}" },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void DecodesAndRoundTrips(string name, string json)
    {
        var assembly = typeof(VipLoanRestApi).Assembly;
        var type = assembly.GetType($"Binance.VipLoan.RestApi.{name.Split('/')[0]}", throwOnError: true)!;
        var context = (JsonSerializerContext)assembly.GetType("Binance.VipLoan.RestApi.VipLoanRestApiJson")!.GetProperty("Default")!.GetValue(null)!;
        // A model that no operation returns is not in the serializer context, so it is decoded by reflection.
        var info = context.GetTypeInfo(type);
        var model = info is null ? JsonSerializer.Deserialize(json, type, Reflection) : JsonSerializer.Deserialize(json, info);
        ExampleAssert.Matches(json, model);
    }
}
