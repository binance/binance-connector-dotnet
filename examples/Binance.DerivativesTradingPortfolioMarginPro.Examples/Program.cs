//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

namespace Binance.DerivativesTradingPortfolioMarginPro.Examples;

internal static class Program
{
    private static readonly Dictionary<string, Func<Task>> Examples = new(StringComparer.OrdinalIgnoreCase)
    {
        ["RestApi/Account/BnbTransfer"] = global::Binance.DerivativesTradingPortfolioMarginPro.Examples.RestApi.Account.BnbTransfer.Main,
        ["RestApi/Account/ChangeAutoRepayFuturesStatus"] = global::Binance.DerivativesTradingPortfolioMarginPro.Examples.RestApi.Account.ChangeAutoRepayFuturesStatus.Main,
        ["RestApi/Account/DeleteMarginCallLevel"] = global::Binance.DerivativesTradingPortfolioMarginPro.Examples.RestApi.Account.DeleteMarginCallLevel.Main,
        ["RestApi/Account/FundAutoCollection"] = global::Binance.DerivativesTradingPortfolioMarginPro.Examples.RestApi.Account.FundAutoCollection.Main,
        ["RestApi/Account/FundCollectionByAsset"] = global::Binance.DerivativesTradingPortfolioMarginPro.Examples.RestApi.Account.FundCollectionByAsset.Main,
        ["RestApi/Account/GetAutoRepayFuturesStatus"] = global::Binance.DerivativesTradingPortfolioMarginPro.Examples.RestApi.Account.GetAutoRepayFuturesStatus.Main,
        ["RestApi/Account/GetDeltaModeStatus"] = global::Binance.DerivativesTradingPortfolioMarginPro.Examples.RestApi.Account.GetDeltaModeStatus.Main,
        ["RestApi/Account/GetMarginCallLevel"] = global::Binance.DerivativesTradingPortfolioMarginPro.Examples.RestApi.Account.GetMarginCallLevel.Main,
        ["RestApi/Account/GetPortfolioMarginProAccountBalance"] = global::Binance.DerivativesTradingPortfolioMarginPro.Examples.RestApi.Account.GetPortfolioMarginProAccountBalance.Main,
        ["RestApi/Account/GetPortfolioMarginProAccountInfo"] = global::Binance.DerivativesTradingPortfolioMarginPro.Examples.RestApi.Account.GetPortfolioMarginProAccountInfo.Main,
        ["RestApi/Account/GetPortfolioMarginProSpanAccountInfo"] = global::Binance.DerivativesTradingPortfolioMarginPro.Examples.RestApi.Account.GetPortfolioMarginProSpanAccountInfo.Main,
        ["RestApi/Account/GetTransferableEarnAssetBalanceForPortfolioMargin"] = global::Binance.DerivativesTradingPortfolioMarginPro.Examples.RestApi.Account.GetTransferableEarnAssetBalanceForPortfolioMargin.Main,
        ["RestApi/Account/PortfolioMarginProBankruptcyLoanRepay"] = global::Binance.DerivativesTradingPortfolioMarginPro.Examples.RestApi.Account.PortfolioMarginProBankruptcyLoanRepay.Main,
        ["RestApi/Account/QueryPortfolioMarginProBankruptcyLoanAmount"] = global::Binance.DerivativesTradingPortfolioMarginPro.Examples.RestApi.Account.QueryPortfolioMarginProBankruptcyLoanAmount.Main,
        ["RestApi/Account/QueryPortfolioMarginProBankruptcyLoanRepayHistory"] = global::Binance.DerivativesTradingPortfolioMarginPro.Examples.RestApi.Account.QueryPortfolioMarginProBankruptcyLoanRepayHistory.Main,
        ["RestApi/Account/QueryPortfolioMarginProNegativeBalanceInterestHistory"] = global::Binance.DerivativesTradingPortfolioMarginPro.Examples.RestApi.Account.QueryPortfolioMarginProNegativeBalanceInterestHistory.Main,
        ["RestApi/Account/RepayFuturesNegativeBalance"] = global::Binance.DerivativesTradingPortfolioMarginPro.Examples.RestApi.Account.RepayFuturesNegativeBalance.Main,
        ["RestApi/Account/SetMarginCallLevel"] = global::Binance.DerivativesTradingPortfolioMarginPro.Examples.RestApi.Account.SetMarginCallLevel.Main,
        ["RestApi/Account/SwitchDeltaMode"] = global::Binance.DerivativesTradingPortfolioMarginPro.Examples.RestApi.Account.SwitchDeltaMode.Main,
        ["RestApi/Account/TransferLdusdtRwusdForPortfolioMargin"] = global::Binance.DerivativesTradingPortfolioMarginPro.Examples.RestApi.Account.TransferLdusdtRwusdForPortfolioMargin.Main,
        ["RestApi/MarketData/GetPortfolioMarginAssetLeverage"] = global::Binance.DerivativesTradingPortfolioMarginPro.Examples.RestApi.MarketData.GetPortfolioMarginAssetLeverage.Main,
        ["RestApi/MarketData/GetPortfolioMarginTieredCollateralRates"] = global::Binance.DerivativesTradingPortfolioMarginPro.Examples.RestApi.MarketData.GetPortfolioMarginTieredCollateralRates.Main,
        ["RestApi/MarketData/PortfolioMarginCollateralRate"] = global::Binance.DerivativesTradingPortfolioMarginPro.Examples.RestApi.MarketData.PortfolioMarginCollateralRate.Main,
        ["RestApi/MarketData/PortfolioMarginProTieredCollateralRate"] = global::Binance.DerivativesTradingPortfolioMarginPro.Examples.RestApi.MarketData.PortfolioMarginProTieredCollateralRate.Main,
        ["RestApi/MarketData/QueryPortfolioMarginAssetIndexPrice"] = global::Binance.DerivativesTradingPortfolioMarginPro.Examples.RestApi.MarketData.QueryPortfolioMarginAssetIndexPrice.Main,
    };

    public static async Task<int> Main(string[] args)
    {
        if (args.Length == 1 && Examples.TryGetValue(args[0].Replace('\\', '/'), out var run))
        {
            await run();
            return 0;
        }

        Console.Error.WriteLine("Usage: dotnet run --project examples/Binance.DerivativesTradingPortfolioMarginPro.Examples -- <example>");
        Console.Error.WriteLine("Examples:");
        foreach (var name in Examples.Keys.Order(StringComparer.OrdinalIgnoreCase))
            Console.Error.WriteLine("  " + name);
        return args.Length == 0 ? 0 : 1;
    }
}
