//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

namespace Binance.DerivativesTradingPortfolioMargin.Examples;

internal static class Program
{
    private static readonly Dictionary<string, Func<Task>> Examples = new(StringComparer.OrdinalIgnoreCase)
    {
        ["RestApi/Account/AccountBalance"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.AccountBalance.Main,
        ["RestApi/Account/AccountInformation"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.AccountInformation.Main,
        ["RestApi/Account/BnbTransfer"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.BnbTransfer.Main,
        ["RestApi/Account/ChangeAutoRepayFuturesStatus"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.ChangeAutoRepayFuturesStatus.Main,
        ["RestApi/Account/ChangeCmInitialLeverage"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.ChangeCmInitialLeverage.Main,
        ["RestApi/Account/ChangeCmPositionMode"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.ChangeCmPositionMode.Main,
        ["RestApi/Account/ChangeUmInitialLeverage"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.ChangeUmInitialLeverage.Main,
        ["RestApi/Account/ChangeUmPositionMode"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.ChangeUmPositionMode.Main,
        ["RestApi/Account/CmNotionalAndLeverageBrackets"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.CmNotionalAndLeverageBrackets.Main,
        ["RestApi/Account/FundAutoCollection"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.FundAutoCollection.Main,
        ["RestApi/Account/FundCollectionByAsset"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.FundCollectionByAsset.Main,
        ["RestApi/Account/GetAutoRepayFuturesStatus"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.GetAutoRepayFuturesStatus.Main,
        ["RestApi/Account/GetCmAccountDetail"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.GetCmAccountDetail.Main,
        ["RestApi/Account/GetCmCurrentPositionMode"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.GetCmCurrentPositionMode.Main,
        ["RestApi/Account/GetCmFuturesOrderDownloadLinkById"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.GetCmFuturesOrderDownloadLinkById.Main,
        ["RestApi/Account/GetCmFuturesTradeDownloadLinkById"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.GetCmFuturesTradeDownloadLinkById.Main,
        ["RestApi/Account/GetCmFuturesTransactionDownloadLinkById"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.GetCmFuturesTransactionDownloadLinkById.Main,
        ["RestApi/Account/GetCmIncomeHistory"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.GetCmIncomeHistory.Main,
        ["RestApi/Account/GetDownloadIdForCmFuturesOrderHistory"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.GetDownloadIdForCmFuturesOrderHistory.Main,
        ["RestApi/Account/GetDownloadIdForCmFuturesTradeHistory"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.GetDownloadIdForCmFuturesTradeHistory.Main,
        ["RestApi/Account/GetDownloadIdForCmFuturesTransactionHistory"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.GetDownloadIdForCmFuturesTransactionHistory.Main,
        ["RestApi/Account/GetDownloadIdForUmFuturesOrderHistory"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.GetDownloadIdForUmFuturesOrderHistory.Main,
        ["RestApi/Account/GetDownloadIdForUmFuturesTradeHistory"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.GetDownloadIdForUmFuturesTradeHistory.Main,
        ["RestApi/Account/GetDownloadIdForUmFuturesTransactionHistory"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.GetDownloadIdForUmFuturesTransactionHistory.Main,
        ["RestApi/Account/GetMarginBorrowLoanInterestHistory"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.GetMarginBorrowLoanInterestHistory.Main,
        ["RestApi/Account/GetUmAccountDetail"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.GetUmAccountDetail.Main,
        ["RestApi/Account/GetUmAccountDetailV2"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.GetUmAccountDetailV2.Main,
        ["RestApi/Account/GetUmCurrentPositionMode"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.GetUmCurrentPositionMode.Main,
        ["RestApi/Account/GetUmFuturesOrderDownloadLinkById"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.GetUmFuturesOrderDownloadLinkById.Main,
        ["RestApi/Account/GetUmFuturesTradeDownloadLinkById"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.GetUmFuturesTradeDownloadLinkById.Main,
        ["RestApi/Account/GetUmFuturesTransactionDownloadLinkById"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.GetUmFuturesTransactionDownloadLinkById.Main,
        ["RestApi/Account/GetUmIncomeHistory"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.GetUmIncomeHistory.Main,
        ["RestApi/Account/GetUserCommissionRateForCm"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.GetUserCommissionRateForCm.Main,
        ["RestApi/Account/GetUserCommissionRateForUm"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.GetUserCommissionRateForUm.Main,
        ["RestApi/Account/MarginMaxBorrow"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.MarginMaxBorrow.Main,
        ["RestApi/Account/PortfolioMarginUmTradingQuantitativeRulesIndicators"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.PortfolioMarginUmTradingQuantitativeRulesIndicators.Main,
        ["RestApi/Account/QueryCmPositionInformation"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.QueryCmPositionInformation.Main,
        ["RestApi/Account/QueryMarginLoanRecord"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.QueryMarginLoanRecord.Main,
        ["RestApi/Account/QueryMarginMaxWithdraw"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.QueryMarginMaxWithdraw.Main,
        ["RestApi/Account/QueryMarginRepayRecord"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.QueryMarginRepayRecord.Main,
        ["RestApi/Account/QueryPortfolioMarginNegativeBalanceInterestHistory"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.QueryPortfolioMarginNegativeBalanceInterestHistory.Main,
        ["RestApi/Account/QueryUmPositionInformation"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.QueryUmPositionInformation.Main,
        ["RestApi/Account/QueryUserNegativeBalanceAutoExchangeRecord"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.QueryUserNegativeBalanceAutoExchangeRecord.Main,
        ["RestApi/Account/QueryUserRateLimit"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.QueryUserRateLimit.Main,
        ["RestApi/Account/RepayFuturesNegativeBalance"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.RepayFuturesNegativeBalance.Main,
        ["RestApi/Account/UmFuturesAccountConfiguration"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.UmFuturesAccountConfiguration.Main,
        ["RestApi/Account/UmFuturesSymbolConfiguration"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.UmFuturesSymbolConfiguration.Main,
        ["RestApi/Account/UmNotionalAndLeverageBrackets"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Account.UmNotionalAndLeverageBrackets.Main,
        ["RestApi/MarketData/TestConnectivity"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.MarketData.TestConnectivity.Main,
        ["RestApi/Trade/CancelAllCmOpenConditionalOrders"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.CancelAllCmOpenConditionalOrders.Main,
        ["RestApi/Trade/CancelAllCmOpenOrders"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.CancelAllCmOpenOrders.Main,
        ["RestApi/Trade/CancelAllUmAlgoOpenOrders"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.CancelAllUmAlgoOpenOrders.Main,
        ["RestApi/Trade/CancelAllUmOpenOrders"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.CancelAllUmOpenOrders.Main,
        ["RestApi/Trade/CancelCmConditionalOrder"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.CancelCmConditionalOrder.Main,
        ["RestApi/Trade/CancelCmOrder"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.CancelCmOrder.Main,
        ["RestApi/Trade/CancelMarginAccountAllOpenOrdersOnASymbol"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.CancelMarginAccountAllOpenOrdersOnASymbol.Main,
        ["RestApi/Trade/CancelMarginAccountOcoOrders"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.CancelMarginAccountOcoOrders.Main,
        ["RestApi/Trade/CancelMarginAccountOrder"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.CancelMarginAccountOrder.Main,
        ["RestApi/Trade/CancelUmAlgoOrder"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.CancelUmAlgoOrder.Main,
        ["RestApi/Trade/CancelUmOrder"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.CancelUmOrder.Main,
        ["RestApi/Trade/CmAccountTradeList"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.CmAccountTradeList.Main,
        ["RestApi/Trade/CmPositionAdlQuantileEstimation"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.CmPositionAdlQuantileEstimation.Main,
        ["RestApi/Trade/FuturesTradfiPerpsContract"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.FuturesTradfiPerpsContract.Main,
        ["RestApi/Trade/GetUmFuturesBnbBurnStatus"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.GetUmFuturesBnbBurnStatus.Main,
        ["RestApi/Trade/MarginAccountBorrow"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.MarginAccountBorrow.Main,
        ["RestApi/Trade/MarginAccountNewOco"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.MarginAccountNewOco.Main,
        ["RestApi/Trade/MarginAccountRepay"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.MarginAccountRepay.Main,
        ["RestApi/Trade/MarginAccountRepayDebt"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.MarginAccountRepayDebt.Main,
        ["RestApi/Trade/MarginAccountTradeList"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.MarginAccountTradeList.Main,
        ["RestApi/Trade/ModifyCmOrder"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.ModifyCmOrder.Main,
        ["RestApi/Trade/ModifyUmOrder"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.ModifyUmOrder.Main,
        ["RestApi/Trade/NewCmConditionalOrder"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.NewCmConditionalOrder.Main,
        ["RestApi/Trade/NewCmOrder"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.NewCmOrder.Main,
        ["RestApi/Trade/NewMarginOrder"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.NewMarginOrder.Main,
        ["RestApi/Trade/NewUmAlgoOrder"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.NewUmAlgoOrder.Main,
        ["RestApi/Trade/NewUmOrder"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.NewUmOrder.Main,
        ["RestApi/Trade/QueryAllCmConditionalOrders"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.QueryAllCmConditionalOrders.Main,
        ["RestApi/Trade/QueryAllCmOrders"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.QueryAllCmOrders.Main,
        ["RestApi/Trade/QueryAllCurrentCmOpenConditionalOrders"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.QueryAllCurrentCmOpenConditionalOrders.Main,
        ["RestApi/Trade/QueryAllCurrentCmOpenOrders"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.QueryAllCurrentCmOpenOrders.Main,
        ["RestApi/Trade/QueryAllCurrentUmOpenAlgoOrders"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.QueryAllCurrentUmOpenAlgoOrders.Main,
        ["RestApi/Trade/QueryAllCurrentUmOpenOrders"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.QueryAllCurrentUmOpenOrders.Main,
        ["RestApi/Trade/QueryAllMarginAccountOrders"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.QueryAllMarginAccountOrders.Main,
        ["RestApi/Trade/QueryAllUmOrders"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.QueryAllUmOrders.Main,
        ["RestApi/Trade/QueryCmConditionalOrderHistory"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.QueryCmConditionalOrderHistory.Main,
        ["RestApi/Trade/QueryCmModifyOrderHistory"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.QueryCmModifyOrderHistory.Main,
        ["RestApi/Trade/QueryCmOrder"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.QueryCmOrder.Main,
        ["RestApi/Trade/QueryCurrentCmOpenConditionalOrder"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.QueryCurrentCmOpenConditionalOrder.Main,
        ["RestApi/Trade/QueryCurrentCmOpenOrder"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.QueryCurrentCmOpenOrder.Main,
        ["RestApi/Trade/QueryCurrentMarginOpenOrder"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.QueryCurrentMarginOpenOrder.Main,
        ["RestApi/Trade/QueryCurrentUmOpenAlgoOrder"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.QueryCurrentUmOpenAlgoOrder.Main,
        ["RestApi/Trade/QueryCurrentUmOpenOrder"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.QueryCurrentUmOpenOrder.Main,
        ["RestApi/Trade/QueryMarginAccountOrder"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.QueryMarginAccountOrder.Main,
        ["RestApi/Trade/QueryMarginAccountsAllOco"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.QueryMarginAccountsAllOco.Main,
        ["RestApi/Trade/QueryMarginAccountsOco"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.QueryMarginAccountsOco.Main,
        ["RestApi/Trade/QueryMarginAccountsOpenOco"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.QueryMarginAccountsOpenOco.Main,
        ["RestApi/Trade/QueryUmAlgoOrderHistory"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.QueryUmAlgoOrderHistory.Main,
        ["RestApi/Trade/QueryUmModifyOrderHistory"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.QueryUmModifyOrderHistory.Main,
        ["RestApi/Trade/QueryUmOrder"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.QueryUmOrder.Main,
        ["RestApi/Trade/QueryUsersCmForceOrders"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.QueryUsersCmForceOrders.Main,
        ["RestApi/Trade/QueryUsersMarginForceOrders"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.QueryUsersMarginForceOrders.Main,
        ["RestApi/Trade/QueryUsersUmForceOrders"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.QueryUsersUmForceOrders.Main,
        ["RestApi/Trade/ToggleBnbBurnOnUmFuturesTrade"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.ToggleBnbBurnOnUmFuturesTrade.Main,
        ["RestApi/Trade/UmAccountTradeList"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.UmAccountTradeList.Main,
        ["RestApi/Trade/UmPositionAdlQuantileEstimation"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade.UmPositionAdlQuantileEstimation.Main,
        ["RestApi/UserDataStreams/CloseUserDataStream"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.UserDataStreams.CloseUserDataStream.Main,
        ["RestApi/UserDataStreams/KeepaliveUserDataStream"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.UserDataStreams.KeepaliveUserDataStream.Main,
        ["RestApi/UserDataStreams/StartUserDataStream"] = global::Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.UserDataStreams.StartUserDataStream.Main,
    };

    public static async Task<int> Main(string[] args)
    {
        if (args.Length == 1 && Examples.TryGetValue(args[0].Replace('\\', '/'), out var run))
        {
            await run();
            return 0;
        }

        Console.Error.WriteLine("Usage: dotnet run --project examples/Binance.DerivativesTradingPortfolioMargin.Examples -- <example>");
        Console.Error.WriteLine("Examples:");
        foreach (var name in Examples.Keys.Order(StringComparer.OrdinalIgnoreCase))
            Console.Error.WriteLine("  " + name);
        return args.Length == 0 ? 0 : 1;
    }
}
