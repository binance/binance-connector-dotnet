//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

namespace Binance.MarginTrading.Examples;

internal static class Program
{
    private static readonly Dictionary<string, Func<Task>> Examples = new(StringComparer.OrdinalIgnoreCase)
    {
        ["RestApi/Account/AdjustCrossMarginMaxLeverage"] = global::Binance.MarginTrading.Examples.RestApi.Account.AdjustCrossMarginMaxLeverage.Main,
        ["RestApi/Account/DisableIsolatedMarginAccount"] = global::Binance.MarginTrading.Examples.RestApi.Account.DisableIsolatedMarginAccount.Main,
        ["RestApi/Account/EnableIsolatedMarginAccount"] = global::Binance.MarginTrading.Examples.RestApi.Account.EnableIsolatedMarginAccount.Main,
        ["RestApi/Account/GetBnbBurnStatus"] = global::Binance.MarginTrading.Examples.RestApi.Account.GetBnbBurnStatus.Main,
        ["RestApi/Account/GetSummaryOfMarginAccount"] = global::Binance.MarginTrading.Examples.RestApi.Account.GetSummaryOfMarginAccount.Main,
        ["RestApi/Account/QueryCrossIsolatedMarginCapitalFlow"] = global::Binance.MarginTrading.Examples.RestApi.Account.QueryCrossIsolatedMarginCapitalFlow.Main,
        ["RestApi/Account/QueryCrossMarginAccountDetails"] = global::Binance.MarginTrading.Examples.RestApi.Account.QueryCrossMarginAccountDetails.Main,
        ["RestApi/Account/QueryCrossMarginFeeData"] = global::Binance.MarginTrading.Examples.RestApi.Account.QueryCrossMarginFeeData.Main,
        ["RestApi/Account/QueryEnabledIsolatedMarginAccountLimit"] = global::Binance.MarginTrading.Examples.RestApi.Account.QueryEnabledIsolatedMarginAccountLimit.Main,
        ["RestApi/Account/QueryIsolatedMarginAccountInfo"] = global::Binance.MarginTrading.Examples.RestApi.Account.QueryIsolatedMarginAccountInfo.Main,
        ["RestApi/Account/QueryIsolatedMarginFeeData"] = global::Binance.MarginTrading.Examples.RestApi.Account.QueryIsolatedMarginFeeData.Main,
        ["RestApi/BorrowRepay/GetFutureHourlyInterestRate"] = global::Binance.MarginTrading.Examples.RestApi.BorrowRepay.GetFutureHourlyInterestRate.Main,
        ["RestApi/BorrowRepay/GetInterestHistory"] = global::Binance.MarginTrading.Examples.RestApi.BorrowRepay.GetInterestHistory.Main,
        ["RestApi/BorrowRepay/MarginAccountBorrowRepay"] = global::Binance.MarginTrading.Examples.RestApi.BorrowRepay.MarginAccountBorrowRepay.Main,
        ["RestApi/BorrowRepay/QueryBorrowRepayRecordsInMarginAccount"] = global::Binance.MarginTrading.Examples.RestApi.BorrowRepay.QueryBorrowRepayRecordsInMarginAccount.Main,
        ["RestApi/BorrowRepay/QueryMarginInterestRateHistory"] = global::Binance.MarginTrading.Examples.RestApi.BorrowRepay.QueryMarginInterestRateHistory.Main,
        ["RestApi/BorrowRepay/QueryMaxBorrow"] = global::Binance.MarginTrading.Examples.RestApi.BorrowRepay.QueryMaxBorrow.Main,
        ["RestApi/MarketData/CrossMarginCollateralRatio"] = global::Binance.MarginTrading.Examples.RestApi.MarketData.CrossMarginCollateralRatio.Main,
        ["RestApi/MarketData/GetAllCrossMarginPairs"] = global::Binance.MarginTrading.Examples.RestApi.MarketData.GetAllCrossMarginPairs.Main,
        ["RestApi/MarketData/GetAllIsolatedMarginSymbol"] = global::Binance.MarginTrading.Examples.RestApi.MarketData.GetAllIsolatedMarginSymbol.Main,
        ["RestApi/MarketData/GetAllMarginAssets"] = global::Binance.MarginTrading.Examples.RestApi.MarketData.GetAllMarginAssets.Main,
        ["RestApi/MarketData/GetDelistSchedule"] = global::Binance.MarginTrading.Examples.RestApi.MarketData.GetDelistSchedule.Main,
        ["RestApi/MarketData/GetLimitPricePairs"] = global::Binance.MarginTrading.Examples.RestApi.MarketData.GetLimitPricePairs.Main,
        ["RestApi/MarketData/GetListSchedule"] = global::Binance.MarginTrading.Examples.RestApi.MarketData.GetListSchedule.Main,
        ["RestApi/MarketData/GetMarginAssetRiskBasedLiquidationRatio"] = global::Binance.MarginTrading.Examples.RestApi.MarketData.GetMarginAssetRiskBasedLiquidationRatio.Main,
        ["RestApi/MarketData/GetMarginRestrictedAssets"] = global::Binance.MarginTrading.Examples.RestApi.MarketData.GetMarginRestrictedAssets.Main,
        ["RestApi/MarketData/QueryIsolatedMarginTierData"] = global::Binance.MarginTrading.Examples.RestApi.MarketData.QueryIsolatedMarginTierData.Main,
        ["RestApi/MarketData/QueryLiabilityCoinLeverageBracketInCrossMarginProMode"] = global::Binance.MarginTrading.Examples.RestApi.MarketData.QueryLiabilityCoinLeverageBracketInCrossMarginProMode.Main,
        ["RestApi/MarketData/QueryMarginAvailableInventory"] = global::Binance.MarginTrading.Examples.RestApi.MarketData.QueryMarginAvailableInventory.Main,
        ["RestApi/MarketData/QueryMarginPriceindex"] = global::Binance.MarginTrading.Examples.RestApi.MarketData.QueryMarginPriceindex.Main,
        ["RestApi/Trade/CreateSpecialKey"] = global::Binance.MarginTrading.Examples.RestApi.Trade.CreateSpecialKey.Main,
        ["RestApi/Trade/DeleteSpecialKey"] = global::Binance.MarginTrading.Examples.RestApi.Trade.DeleteSpecialKey.Main,
        ["RestApi/Trade/EditIpForSpecialKey"] = global::Binance.MarginTrading.Examples.RestApi.Trade.EditIpForSpecialKey.Main,
        ["RestApi/Trade/ExitSpecialKeyMode"] = global::Binance.MarginTrading.Examples.RestApi.Trade.ExitSpecialKeyMode.Main,
        ["RestApi/Trade/GetForceLiquidationRecord"] = global::Binance.MarginTrading.Examples.RestApi.Trade.GetForceLiquidationRecord.Main,
        ["RestApi/Trade/GetSmallLiabilityExchangeCoinList"] = global::Binance.MarginTrading.Examples.RestApi.Trade.GetSmallLiabilityExchangeCoinList.Main,
        ["RestApi/Trade/GetSmallLiabilityExchangeHistory"] = global::Binance.MarginTrading.Examples.RestApi.Trade.GetSmallLiabilityExchangeHistory.Main,
        ["RestApi/Trade/LiquidationLoanRepay"] = global::Binance.MarginTrading.Examples.RestApi.Trade.LiquidationLoanRepay.Main,
        ["RestApi/Trade/MarginAccountCancelAllOpenOrdersOnASymbol"] = global::Binance.MarginTrading.Examples.RestApi.Trade.MarginAccountCancelAllOpenOrdersOnASymbol.Main,
        ["RestApi/Trade/MarginAccountCancelOco"] = global::Binance.MarginTrading.Examples.RestApi.Trade.MarginAccountCancelOco.Main,
        ["RestApi/Trade/MarginAccountCancelOrder"] = global::Binance.MarginTrading.Examples.RestApi.Trade.MarginAccountCancelOrder.Main,
        ["RestApi/Trade/MarginAccountNewOco"] = global::Binance.MarginTrading.Examples.RestApi.Trade.MarginAccountNewOco.Main,
        ["RestApi/Trade/MarginAccountNewOrder"] = global::Binance.MarginTrading.Examples.RestApi.Trade.MarginAccountNewOrder.Main,
        ["RestApi/Trade/MarginAccountNewOto"] = global::Binance.MarginTrading.Examples.RestApi.Trade.MarginAccountNewOto.Main,
        ["RestApi/Trade/MarginAccountNewOtoco"] = global::Binance.MarginTrading.Examples.RestApi.Trade.MarginAccountNewOtoco.Main,
        ["RestApi/Trade/MarginManualLiquidation"] = global::Binance.MarginTrading.Examples.RestApi.Trade.MarginManualLiquidation.Main,
        ["RestApi/Trade/QueryCurrentMarginOrderCountUsage"] = global::Binance.MarginTrading.Examples.RestApi.Trade.QueryCurrentMarginOrderCountUsage.Main,
        ["RestApi/Trade/QueryLiquidationLoan"] = global::Binance.MarginTrading.Examples.RestApi.Trade.QueryLiquidationLoan.Main,
        ["RestApi/Trade/QueryLiquidationLoanRepayHistory"] = global::Binance.MarginTrading.Examples.RestApi.Trade.QueryLiquidationLoanRepayHistory.Main,
        ["RestApi/Trade/QueryMarginAccountsAllOco"] = global::Binance.MarginTrading.Examples.RestApi.Trade.QueryMarginAccountsAllOco.Main,
        ["RestApi/Trade/QueryMarginAccountsAllOrders"] = global::Binance.MarginTrading.Examples.RestApi.Trade.QueryMarginAccountsAllOrders.Main,
        ["RestApi/Trade/QueryMarginAccountsOco"] = global::Binance.MarginTrading.Examples.RestApi.Trade.QueryMarginAccountsOco.Main,
        ["RestApi/Trade/QueryMarginAccountsOpenOco"] = global::Binance.MarginTrading.Examples.RestApi.Trade.QueryMarginAccountsOpenOco.Main,
        ["RestApi/Trade/QueryMarginAccountsOpenOrders"] = global::Binance.MarginTrading.Examples.RestApi.Trade.QueryMarginAccountsOpenOrders.Main,
        ["RestApi/Trade/QueryMarginAccountsOpenOtootocoOrderLists"] = global::Binance.MarginTrading.Examples.RestApi.Trade.QueryMarginAccountsOpenOtootocoOrderLists.Main,
        ["RestApi/Trade/QueryMarginAccountsOrder"] = global::Binance.MarginTrading.Examples.RestApi.Trade.QueryMarginAccountsOrder.Main,
        ["RestApi/Trade/QueryMarginAccountsTradeList"] = global::Binance.MarginTrading.Examples.RestApi.Trade.QueryMarginAccountsTradeList.Main,
        ["RestApi/Trade/QueryPreventedMatches"] = global::Binance.MarginTrading.Examples.RestApi.Trade.QueryPreventedMatches.Main,
        ["RestApi/Trade/QuerySpecialKey"] = global::Binance.MarginTrading.Examples.RestApi.Trade.QuerySpecialKey.Main,
        ["RestApi/Trade/QuerySpecialKeyList"] = global::Binance.MarginTrading.Examples.RestApi.Trade.QuerySpecialKeyList.Main,
        ["RestApi/Trade/SmallLiabilityExchange"] = global::Binance.MarginTrading.Examples.RestApi.Trade.SmallLiabilityExchange.Main,
        ["RestApi/Transfer/GetCrossMarginTransferHistory"] = global::Binance.MarginTrading.Examples.RestApi.Transfer.GetCrossMarginTransferHistory.Main,
        ["RestApi/Transfer/QueryMaxTransferOutAmount"] = global::Binance.MarginTrading.Examples.RestApi.Transfer.QueryMaxTransferOutAmount.Main,
        ["RestApi/UserDataStream/CloseUserDataStream"] = global::Binance.MarginTrading.Examples.RestApi.UserDataStream.CloseUserDataStream.Main,
        ["RestApi/UserDataStream/CloseUserDataStreamV2"] = global::Binance.MarginTrading.Examples.RestApi.UserDataStream.CloseUserDataStreamV2.Main,
        ["RestApi/UserDataStream/KeepaliveUserDataStream"] = global::Binance.MarginTrading.Examples.RestApi.UserDataStream.KeepaliveUserDataStream.Main,
        ["RestApi/UserDataStream/KeepaliveUserDataStreamV2"] = global::Binance.MarginTrading.Examples.RestApi.UserDataStream.KeepaliveUserDataStreamV2.Main,
        ["RestApi/UserDataStream/StartUserDataStream"] = global::Binance.MarginTrading.Examples.RestApi.UserDataStream.StartUserDataStream.Main,
        ["RestApi/UserDataStream/StartUserDataStreamV2"] = global::Binance.MarginTrading.Examples.RestApi.UserDataStream.StartUserDataStreamV2.Main,
    };

    public static async Task<int> Main(string[] args)
    {
        if (args.Length == 1 && Examples.TryGetValue(args[0].Replace('\\', '/'), out var run))
        {
            await run();
            return 0;
        }

        Console.Error.WriteLine("Usage: dotnet run --project examples/Binance.MarginTrading.Examples -- <example>");
        Console.Error.WriteLine("Examples:");
        foreach (var name in Examples.Keys.Order(StringComparer.OrdinalIgnoreCase))
            Console.Error.WriteLine("  " + name);
        return args.Length == 0 ? 0 : 1;
    }
}
