//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

namespace Binance.CryptoLoan.Examples;

internal static class Program
{
    private static readonly Dictionary<string, Func<Task>> Examples = new(StringComparer.OrdinalIgnoreCase)
    {
        ["RestApi/FlexibleRate/CheckCollateralRepayRate"] = global::Binance.CryptoLoan.Examples.RestApi.FlexibleRate.CheckCollateralRepayRate.Main,
        ["RestApi/FlexibleRate/FlexibleLoanAdjustLtv"] = global::Binance.CryptoLoan.Examples.RestApi.FlexibleRate.FlexibleLoanAdjustLtv.Main,
        ["RestApi/FlexibleRate/FlexibleLoanBorrow"] = global::Binance.CryptoLoan.Examples.RestApi.FlexibleRate.FlexibleLoanBorrow.Main,
        ["RestApi/FlexibleRate/FlexibleLoanRepay"] = global::Binance.CryptoLoan.Examples.RestApi.FlexibleRate.FlexibleLoanRepay.Main,
        ["RestApi/FlexibleRate/GetFlexibleLoanAssetsData"] = global::Binance.CryptoLoan.Examples.RestApi.FlexibleRate.GetFlexibleLoanAssetsData.Main,
        ["RestApi/FlexibleRate/GetFlexibleLoanBorrowHistory"] = global::Binance.CryptoLoan.Examples.RestApi.FlexibleRate.GetFlexibleLoanBorrowHistory.Main,
        ["RestApi/FlexibleRate/GetFlexibleLoanCollateralAssetsData"] = global::Binance.CryptoLoan.Examples.RestApi.FlexibleRate.GetFlexibleLoanCollateralAssetsData.Main,
        ["RestApi/FlexibleRate/GetFlexibleLoanInterestRateHistory"] = global::Binance.CryptoLoan.Examples.RestApi.FlexibleRate.GetFlexibleLoanInterestRateHistory.Main,
        ["RestApi/FlexibleRate/GetFlexibleLoanLiquidationHistory"] = global::Binance.CryptoLoan.Examples.RestApi.FlexibleRate.GetFlexibleLoanLiquidationHistory.Main,
        ["RestApi/FlexibleRate/GetFlexibleLoanLtvAdjustmentHistory"] = global::Binance.CryptoLoan.Examples.RestApi.FlexibleRate.GetFlexibleLoanLtvAdjustmentHistory.Main,
        ["RestApi/FlexibleRate/GetFlexibleLoanOngoingOrders"] = global::Binance.CryptoLoan.Examples.RestApi.FlexibleRate.GetFlexibleLoanOngoingOrders.Main,
        ["RestApi/FlexibleRate/GetFlexibleLoanRepaymentHistory"] = global::Binance.CryptoLoan.Examples.RestApi.FlexibleRate.GetFlexibleLoanRepaymentHistory.Main,
    };

    public static async Task<int> Main(string[] args)
    {
        if (args.Length == 1 && Examples.TryGetValue(args[0].Replace('\\', '/'), out var run))
        {
            await run();
            return 0;
        }

        Console.Error.WriteLine("Usage: dotnet run --project examples/Binance.CryptoLoan.Examples -- <example>");
        Console.Error.WriteLine("Examples:");
        foreach (var name in Examples.Keys.Order(StringComparer.OrdinalIgnoreCase))
            Console.Error.WriteLine("  " + name);
        return args.Length == 0 ? 0 : 1;
    }
}
