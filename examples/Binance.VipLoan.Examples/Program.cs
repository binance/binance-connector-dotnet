//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

namespace Binance.VipLoan.Examples;

internal static class Program
{
    private static readonly Dictionary<string, Func<Task>> Examples = new(StringComparer.OrdinalIgnoreCase)
    {
        ["RestApi/MarketData/GetBorrowInterestRate"] = global::Binance.VipLoan.Examples.RestApi.MarketData.GetBorrowInterestRate.Main,
        ["RestApi/MarketData/GetCollateralAssetData"] = global::Binance.VipLoan.Examples.RestApi.MarketData.GetCollateralAssetData.Main,
        ["RestApi/MarketData/GetLoanableAssetsData"] = global::Binance.VipLoan.Examples.RestApi.MarketData.GetLoanableAssetsData.Main,
        ["RestApi/MarketData/GetVIPLoanInterestRateHistory"] = global::Binance.VipLoan.Examples.RestApi.MarketData.GetVIPLoanInterestRateHistory.Main,
        ["RestApi/MarketData/QueryVIPLoanFixedRateMarket"] = global::Binance.VipLoan.Examples.RestApi.MarketData.QueryVIPLoanFixedRateMarket.Main,
        ["RestApi/Trade/VipLoanBorrow"] = global::Binance.VipLoan.Examples.RestApi.Trade.VipLoanBorrow.Main,
        ["RestApi/Trade/VipLoanFixedRateBorrow"] = global::Binance.VipLoan.Examples.RestApi.Trade.VipLoanFixedRateBorrow.Main,
        ["RestApi/Trade/VipLoanRenew"] = global::Binance.VipLoan.Examples.RestApi.Trade.VipLoanRenew.Main,
        ["RestApi/Trade/VipLoanRepay"] = global::Binance.VipLoan.Examples.RestApi.Trade.VipLoanRepay.Main,
        ["RestApi/UserInformation/CheckVIPLoanCollateralAccount"] = global::Binance.VipLoan.Examples.RestApi.UserInformation.CheckVIPLoanCollateralAccount.Main,
        ["RestApi/UserInformation/GetVIPLoanAccruedInterest"] = global::Binance.VipLoan.Examples.RestApi.UserInformation.GetVIPLoanAccruedInterest.Main,
        ["RestApi/UserInformation/GetVIPLoanOngoingOrders"] = global::Binance.VipLoan.Examples.RestApi.UserInformation.GetVIPLoanOngoingOrders.Main,
        ["RestApi/UserInformation/GetVIPLoanRepaymentHistory"] = global::Binance.VipLoan.Examples.RestApi.UserInformation.GetVIPLoanRepaymentHistory.Main,
        ["RestApi/UserInformation/QueryApplicationStatus"] = global::Binance.VipLoan.Examples.RestApi.UserInformation.QueryApplicationStatus.Main,
    };

    public static async Task<int> Main(string[] args)
    {
        if (args.Length == 1 && Examples.TryGetValue(args[0].Replace('\\', '/'), out var run))
        {
            await run();
            return 0;
        }

        Console.Error.WriteLine("Usage: dotnet run --project examples/Binance.VipLoan.Examples -- <example>");
        Console.Error.WriteLine("Examples:");
        foreach (var name in Examples.Keys.Order(StringComparer.OrdinalIgnoreCase))
            Console.Error.WriteLine("  " + name);
        return args.Length == 0 ? 0 : 1;
    }
}
