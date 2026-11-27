//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

namespace Binance.DerivativesTradingCoinFutures.Examples;

internal static class Program
{
    private static readonly Dictionary<string, Func<Task>> Examples = new(StringComparer.OrdinalIgnoreCase)
    {
        ["RestApi/Account/AccountInformation"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Account.AccountInformation.Main,
        ["RestApi/Account/FuturesAccountBalance"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Account.FuturesAccountBalance.Main,
        ["RestApi/Account/GetCurrentPositionMode"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Account.GetCurrentPositionMode.Main,
        ["RestApi/Account/GetDownloadIdForFuturesOrderHistory"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Account.GetDownloadIdForFuturesOrderHistory.Main,
        ["RestApi/Account/GetDownloadIdForFuturesTradeHistory"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Account.GetDownloadIdForFuturesTradeHistory.Main,
        ["RestApi/Account/GetDownloadIdForFuturesTransactionHistory"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Account.GetDownloadIdForFuturesTransactionHistory.Main,
        ["RestApi/Account/GetFuturesOrderHistoryDownloadLinkById"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Account.GetFuturesOrderHistoryDownloadLinkById.Main,
        ["RestApi/Account/GetFuturesTradeDownloadLinkById"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Account.GetFuturesTradeDownloadLinkById.Main,
        ["RestApi/Account/GetFuturesTransactionHistoryDownloadLinkById"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Account.GetFuturesTransactionHistoryDownloadLinkById.Main,
        ["RestApi/Account/GetIncomeHistory"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Account.GetIncomeHistory.Main,
        ["RestApi/Account/NotionalBracketForPair"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Account.NotionalBracketForPair.Main,
        ["RestApi/Account/NotionalBracketForSymbol"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Account.NotionalBracketForSymbol.Main,
        ["RestApi/Account/UserCommissionRate"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Account.UserCommissionRate.Main,
        ["RestApi/MarketData/Basis"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.MarketData.Basis.Main,
        ["RestApi/MarketData/CheckServerTime"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.MarketData.CheckServerTime.Main,
        ["RestApi/MarketData/CompressedAggregateTradesList"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.MarketData.CompressedAggregateTradesList.Main,
        ["RestApi/MarketData/ContinuousContractKlineCandlestickData"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.MarketData.ContinuousContractKlineCandlestickData.Main,
        ["RestApi/MarketData/ExchangeInformation"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.MarketData.ExchangeInformation.Main,
        ["RestApi/MarketData/GetFundingRateHistoryOfPerpetualFutures"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.MarketData.GetFundingRateHistoryOfPerpetualFutures.Main,
        ["RestApi/MarketData/GetFundingRateInfo"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.MarketData.GetFundingRateInfo.Main,
        ["RestApi/MarketData/IndexPriceAndMarkPrice"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.MarketData.IndexPriceAndMarkPrice.Main,
        ["RestApi/MarketData/IndexPriceKlineCandlestickData"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.MarketData.IndexPriceKlineCandlestickData.Main,
        ["RestApi/MarketData/KlineCandlestickData"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.MarketData.KlineCandlestickData.Main,
        ["RestApi/MarketData/LongShortRatio"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.MarketData.LongShortRatio.Main,
        ["RestApi/MarketData/MarkPriceKlineCandlestickData"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.MarketData.MarkPriceKlineCandlestickData.Main,
        ["RestApi/MarketData/OldTradesLookup"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.MarketData.OldTradesLookup.Main,
        ["RestApi/MarketData/OpenInterest"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.MarketData.OpenInterest.Main,
        ["RestApi/MarketData/OpenInterestStatistics"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.MarketData.OpenInterestStatistics.Main,
        ["RestApi/MarketData/OrderBook"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.MarketData.OrderBook.Main,
        ["RestApi/MarketData/PremiumIndexKlineData"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.MarketData.PremiumIndexKlineData.Main,
        ["RestApi/MarketData/QueryIndexPriceConstituents"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.MarketData.QueryIndexPriceConstituents.Main,
        ["RestApi/MarketData/RecentTradesList"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.MarketData.RecentTradesList.Main,
        ["RestApi/MarketData/SymbolOrderBookTicker"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.MarketData.SymbolOrderBookTicker.Main,
        ["RestApi/MarketData/SymbolPriceTicker"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.MarketData.SymbolPriceTicker.Main,
        ["RestApi/MarketData/TakerBuySellVolume"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.MarketData.TakerBuySellVolume.Main,
        ["RestApi/MarketData/TestConnectivity"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.MarketData.TestConnectivity.Main,
        ["RestApi/MarketData/Ticker24hrPriceChangeStatistics"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.MarketData.Ticker24hrPriceChangeStatistics.Main,
        ["RestApi/MarketData/TopTraderLongShortRatioAccounts"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.MarketData.TopTraderLongShortRatioAccounts.Main,
        ["RestApi/MarketData/TopTraderLongShortRatioPositions"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.MarketData.TopTraderLongShortRatioPositions.Main,
        ["RestApi/Trade/AccountTradeList"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Trade.AccountTradeList.Main,
        ["RestApi/Trade/AllOrders"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Trade.AllOrders.Main,
        ["RestApi/Trade/AutoCancelAllOpenOrders"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Trade.AutoCancelAllOpenOrders.Main,
        ["RestApi/Trade/CancelAlgoOrder"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Trade.CancelAlgoOrder.Main,
        ["RestApi/Trade/CancelAllAlgoOpenOrders"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Trade.CancelAllAlgoOpenOrders.Main,
        ["RestApi/Trade/CancelAllOpenOrders"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Trade.CancelAllOpenOrders.Main,
        ["RestApi/Trade/CancelMultipleOrders"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Trade.CancelMultipleOrders.Main,
        ["RestApi/Trade/CancelOrder"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Trade.CancelOrder.Main,
        ["RestApi/Trade/ChangeInitialLeverage"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Trade.ChangeInitialLeverage.Main,
        ["RestApi/Trade/ChangeMarginType"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Trade.ChangeMarginType.Main,
        ["RestApi/Trade/ChangePositionMode"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Trade.ChangePositionMode.Main,
        ["RestApi/Trade/CurrentAllAlgoOpenOrders"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Trade.CurrentAllAlgoOpenOrders.Main,
        ["RestApi/Trade/CurrentAllOpenOrders"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Trade.CurrentAllOpenOrders.Main,
        ["RestApi/Trade/GetOrderModifyHistory"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Trade.GetOrderModifyHistory.Main,
        ["RestApi/Trade/GetPositionMarginChangeHistory"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Trade.GetPositionMarginChangeHistory.Main,
        ["RestApi/Trade/ModifyIsolatedPositionMargin"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Trade.ModifyIsolatedPositionMargin.Main,
        ["RestApi/Trade/ModifyMultipleOrders"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Trade.ModifyMultipleOrders.Main,
        ["RestApi/Trade/ModifyOrder"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Trade.ModifyOrder.Main,
        ["RestApi/Trade/NewAlgoOrder"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Trade.NewAlgoOrder.Main,
        ["RestApi/Trade/NewOrder"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Trade.NewOrder.Main,
        ["RestApi/Trade/PlaceMultipleOrders"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Trade.PlaceMultipleOrders.Main,
        ["RestApi/Trade/PositionAdlQuantileEstimation"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Trade.PositionAdlQuantileEstimation.Main,
        ["RestApi/Trade/PositionInformation"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Trade.PositionInformation.Main,
        ["RestApi/Trade/QueryAlgoOrder"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Trade.QueryAlgoOrder.Main,
        ["RestApi/Trade/QueryAllAlgoOrders"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Trade.QueryAllAlgoOrders.Main,
        ["RestApi/Trade/QueryCurrentOpenOrder"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Trade.QueryCurrentOpenOrder.Main,
        ["RestApi/Trade/QueryOrder"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Trade.QueryOrder.Main,
        ["RestApi/Trade/UsersForceOrders"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.Trade.UsersForceOrders.Main,
        ["RestApi/UserDataStreams/CloseUserDataStream"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.UserDataStreams.CloseUserDataStream.Main,
        ["RestApi/UserDataStreams/KeepaliveUserDataStream"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.UserDataStreams.KeepaliveUserDataStream.Main,
        ["RestApi/UserDataStreams/StartUserDataStream"] = global::Binance.DerivativesTradingCoinFutures.Examples.RestApi.UserDataStreams.StartUserDataStream.Main,
        ["WebSocketApi/Account/AccountInformation"] = global::Binance.DerivativesTradingCoinFutures.Examples.WebSocketApi.Account.AccountInformation.Main,
        ["WebSocketApi/Account/FuturesAccountBalance"] = global::Binance.DerivativesTradingCoinFutures.Examples.WebSocketApi.Account.FuturesAccountBalance.Main,
        ["WebSocketApi/Trade/CancelAlgoOrder"] = global::Binance.DerivativesTradingCoinFutures.Examples.WebSocketApi.Trade.CancelAlgoOrder.Main,
        ["WebSocketApi/Trade/CancelOrder"] = global::Binance.DerivativesTradingCoinFutures.Examples.WebSocketApi.Trade.CancelOrder.Main,
        ["WebSocketApi/Trade/ModifyOrder"] = global::Binance.DerivativesTradingCoinFutures.Examples.WebSocketApi.Trade.ModifyOrder.Main,
        ["WebSocketApi/Trade/NewAlgoOrder"] = global::Binance.DerivativesTradingCoinFutures.Examples.WebSocketApi.Trade.NewAlgoOrder.Main,
        ["WebSocketApi/Trade/NewOrder"] = global::Binance.DerivativesTradingCoinFutures.Examples.WebSocketApi.Trade.NewOrder.Main,
        ["WebSocketApi/Trade/PositionInformation"] = global::Binance.DerivativesTradingCoinFutures.Examples.WebSocketApi.Trade.PositionInformation.Main,
        ["WebSocketApi/Trade/QueryOrder"] = global::Binance.DerivativesTradingCoinFutures.Examples.WebSocketApi.Trade.QueryOrder.Main,
        ["WebSocketApi/UserDataStreams/CloseUserDataStream"] = global::Binance.DerivativesTradingCoinFutures.Examples.WebSocketApi.UserDataStreams.CloseUserDataStream.Main,
        ["WebSocketApi/UserDataStreams/KeepaliveUserDataStream"] = global::Binance.DerivativesTradingCoinFutures.Examples.WebSocketApi.UserDataStreams.KeepaliveUserDataStream.Main,
        ["WebSocketApi/UserDataStreams/StartUserDataStream"] = global::Binance.DerivativesTradingCoinFutures.Examples.WebSocketApi.UserDataStreams.StartUserDataStream.Main,
        ["WebSocketStreams/AggregateTradeStreams"] = global::Binance.DerivativesTradingCoinFutures.Examples.WebSocketStreams.AggregateTradeStreams.Main,
        ["WebSocketStreams/AllBookTickersStream"] = global::Binance.DerivativesTradingCoinFutures.Examples.WebSocketStreams.AllBookTickersStream.Main,
        ["WebSocketStreams/AllMarketLiquidationOrderStreams"] = global::Binance.DerivativesTradingCoinFutures.Examples.WebSocketStreams.AllMarketLiquidationOrderStreams.Main,
        ["WebSocketStreams/AllMarketMiniTickersStream"] = global::Binance.DerivativesTradingCoinFutures.Examples.WebSocketStreams.AllMarketMiniTickersStream.Main,
        ["WebSocketStreams/AllMarketTickersStreams"] = global::Binance.DerivativesTradingCoinFutures.Examples.WebSocketStreams.AllMarketTickersStreams.Main,
        ["WebSocketStreams/ContinuousContractKlineCandlestickStreams"] = global::Binance.DerivativesTradingCoinFutures.Examples.WebSocketStreams.ContinuousContractKlineCandlestickStreams.Main,
        ["WebSocketStreams/ContractInfoStream"] = global::Binance.DerivativesTradingCoinFutures.Examples.WebSocketStreams.ContractInfoStream.Main,
        ["WebSocketStreams/DiffBookDepthStreams"] = global::Binance.DerivativesTradingCoinFutures.Examples.WebSocketStreams.DiffBookDepthStreams.Main,
        ["WebSocketStreams/IndexKlineCandlestickStreams"] = global::Binance.DerivativesTradingCoinFutures.Examples.WebSocketStreams.IndexKlineCandlestickStreams.Main,
        ["WebSocketStreams/IndexPriceStream"] = global::Binance.DerivativesTradingCoinFutures.Examples.WebSocketStreams.IndexPriceStream.Main,
        ["WebSocketStreams/IndividualSymbolBookTickerStreams"] = global::Binance.DerivativesTradingCoinFutures.Examples.WebSocketStreams.IndividualSymbolBookTickerStreams.Main,
        ["WebSocketStreams/IndividualSymbolMiniTickerStream"] = global::Binance.DerivativesTradingCoinFutures.Examples.WebSocketStreams.IndividualSymbolMiniTickerStream.Main,
        ["WebSocketStreams/IndividualSymbolTickerStreams"] = global::Binance.DerivativesTradingCoinFutures.Examples.WebSocketStreams.IndividualSymbolTickerStreams.Main,
        ["WebSocketStreams/KlineCandlestickStreams"] = global::Binance.DerivativesTradingCoinFutures.Examples.WebSocketStreams.KlineCandlestickStreams.Main,
        ["WebSocketStreams/MarketLiquidationOrderStreams"] = global::Binance.DerivativesTradingCoinFutures.Examples.WebSocketStreams.MarketLiquidationOrderStreams.Main,
        ["WebSocketStreams/MarkPriceKlineCandlestickStreams"] = global::Binance.DerivativesTradingCoinFutures.Examples.WebSocketStreams.MarkPriceKlineCandlestickStreams.Main,
        ["WebSocketStreams/MarkPriceOfAllSymbolsOfAPair"] = global::Binance.DerivativesTradingCoinFutures.Examples.WebSocketStreams.MarkPriceOfAllSymbolsOfAPair.Main,
        ["WebSocketStreams/MarkPriceStream"] = global::Binance.DerivativesTradingCoinFutures.Examples.WebSocketStreams.MarkPriceStream.Main,
        ["WebSocketStreams/PartialBookDepthStreams"] = global::Binance.DerivativesTradingCoinFutures.Examples.WebSocketStreams.PartialBookDepthStreams.Main,
    };

    public static async Task<int> Main(string[] args)
    {
        if (args.Length == 1 && Examples.TryGetValue(args[0].Replace('\\', '/'), out var run))
        {
            await run();
            return 0;
        }

        Console.Error.WriteLine("Usage: dotnet run --project examples/Binance.DerivativesTradingCoinFutures.Examples -- <example>");
        Console.Error.WriteLine("Examples:");
        foreach (var name in Examples.Keys.Order(StringComparer.OrdinalIgnoreCase))
            Console.Error.WriteLine("  " + name);
        return args.Length == 0 ? 0 : 1;
    }
}
