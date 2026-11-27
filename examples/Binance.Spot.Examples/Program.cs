//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

namespace Binance.Spot.Examples;

internal static class Program
{
    private static readonly Dictionary<string, Func<Task>> Examples = new(StringComparer.OrdinalIgnoreCase)
    {
        ["RestApi/Account/AccountCommission"] = global::Binance.Spot.Examples.RestApi.Account.AccountCommission.Main,
        ["RestApi/Account/AllOrderList"] = global::Binance.Spot.Examples.RestApi.Account.AllOrderList.Main,
        ["RestApi/Account/AllOrders"] = global::Binance.Spot.Examples.RestApi.Account.AllOrders.Main,
        ["RestApi/Account/GetAccount"] = global::Binance.Spot.Examples.RestApi.Account.GetAccount.Main,
        ["RestApi/Account/GetOpenOrders"] = global::Binance.Spot.Examples.RestApi.Account.GetOpenOrders.Main,
        ["RestApi/Account/GetOrder"] = global::Binance.Spot.Examples.RestApi.Account.GetOrder.Main,
        ["RestApi/Account/GetOrderList"] = global::Binance.Spot.Examples.RestApi.Account.GetOrderList.Main,
        ["RestApi/Account/MyAllocations"] = global::Binance.Spot.Examples.RestApi.Account.MyAllocations.Main,
        ["RestApi/Account/MyFilters"] = global::Binance.Spot.Examples.RestApi.Account.MyFilters.Main,
        ["RestApi/Account/MyPreventedMatches"] = global::Binance.Spot.Examples.RestApi.Account.MyPreventedMatches.Main,
        ["RestApi/Account/MyTrades"] = global::Binance.Spot.Examples.RestApi.Account.MyTrades.Main,
        ["RestApi/Account/OpenOrderList"] = global::Binance.Spot.Examples.RestApi.Account.OpenOrderList.Main,
        ["RestApi/Account/OrderAmendments"] = global::Binance.Spot.Examples.RestApi.Account.OrderAmendments.Main,
        ["RestApi/Account/RateLimitOrder"] = global::Binance.Spot.Examples.RestApi.Account.RateLimitOrder.Main,
        ["RestApi/General/ExchangeInfo"] = global::Binance.Spot.Examples.RestApi.General.ExchangeInfo.Main,
        ["RestApi/General/ExecutionRules"] = global::Binance.Spot.Examples.RestApi.General.ExecutionRules.Main,
        ["RestApi/General/Ping"] = global::Binance.Spot.Examples.RestApi.General.Ping.Main,
        ["RestApi/General/Time"] = global::Binance.Spot.Examples.RestApi.General.Time.Main,
        ["RestApi/Market/AggTrades"] = global::Binance.Spot.Examples.RestApi.Market.AggTrades.Main,
        ["RestApi/Market/AvgPrice"] = global::Binance.Spot.Examples.RestApi.Market.AvgPrice.Main,
        ["RestApi/Market/Depth"] = global::Binance.Spot.Examples.RestApi.Market.Depth.Main,
        ["RestApi/Market/GetTrades"] = global::Binance.Spot.Examples.RestApi.Market.GetTrades.Main,
        ["RestApi/Market/HistoricalBlockTrades"] = global::Binance.Spot.Examples.RestApi.Market.HistoricalBlockTrades.Main,
        ["RestApi/Market/HistoricalTrades"] = global::Binance.Spot.Examples.RestApi.Market.HistoricalTrades.Main,
        ["RestApi/Market/Klines"] = global::Binance.Spot.Examples.RestApi.Market.Klines.Main,
        ["RestApi/Market/ReferencePrice"] = global::Binance.Spot.Examples.RestApi.Market.ReferencePrice.Main,
        ["RestApi/Market/ReferencePriceCalculation"] = global::Binance.Spot.Examples.RestApi.Market.ReferencePriceCalculation.Main,
        ["RestApi/Market/Ticker"] = global::Binance.Spot.Examples.RestApi.Market.Ticker.Main,
        ["RestApi/Market/Ticker24hr"] = global::Binance.Spot.Examples.RestApi.Market.Ticker24hr.Main,
        ["RestApi/Market/TickerBookTicker"] = global::Binance.Spot.Examples.RestApi.Market.TickerBookTicker.Main,
        ["RestApi/Market/TickerPrice"] = global::Binance.Spot.Examples.RestApi.Market.TickerPrice.Main,
        ["RestApi/Market/TickerTradingDay"] = global::Binance.Spot.Examples.RestApi.Market.TickerTradingDay.Main,
        ["RestApi/Market/UiKlines"] = global::Binance.Spot.Examples.RestApi.Market.UiKlines.Main,
        ["RestApi/Trade/DeleteOpenOrders"] = global::Binance.Spot.Examples.RestApi.Trade.DeleteOpenOrders.Main,
        ["RestApi/Trade/DeleteOrder"] = global::Binance.Spot.Examples.RestApi.Trade.DeleteOrder.Main,
        ["RestApi/Trade/DeleteOrderList"] = global::Binance.Spot.Examples.RestApi.Trade.DeleteOrderList.Main,
        ["RestApi/Trade/NewOrder"] = global::Binance.Spot.Examples.RestApi.Trade.NewOrder.Main,
        ["RestApi/Trade/OrderAmendKeepPriority"] = global::Binance.Spot.Examples.RestApi.Trade.OrderAmendKeepPriority.Main,
        ["RestApi/Trade/OrderCancelReplace"] = global::Binance.Spot.Examples.RestApi.Trade.OrderCancelReplace.Main,
        ["RestApi/Trade/OrderListOco"] = global::Binance.Spot.Examples.RestApi.Trade.OrderListOco.Main,
        ["RestApi/Trade/OrderListOpo"] = global::Binance.Spot.Examples.RestApi.Trade.OrderListOpo.Main,
        ["RestApi/Trade/OrderListOpoco"] = global::Binance.Spot.Examples.RestApi.Trade.OrderListOpoco.Main,
        ["RestApi/Trade/OrderListOto"] = global::Binance.Spot.Examples.RestApi.Trade.OrderListOto.Main,
        ["RestApi/Trade/OrderListOtoco"] = global::Binance.Spot.Examples.RestApi.Trade.OrderListOtoco.Main,
        ["RestApi/Trade/OrderOco"] = global::Binance.Spot.Examples.RestApi.Trade.OrderOco.Main,
        ["RestApi/Trade/OrderTest"] = global::Binance.Spot.Examples.RestApi.Trade.OrderTest.Main,
        ["RestApi/Trade/SorOrder"] = global::Binance.Spot.Examples.RestApi.Trade.SorOrder.Main,
        ["RestApi/Trade/SorOrderTest"] = global::Binance.Spot.Examples.RestApi.Trade.SorOrderTest.Main,
        ["WebSocketApi/Account/AccountCommission"] = global::Binance.Spot.Examples.WebSocketApi.Account.AccountCommission.Main,
        ["WebSocketApi/Account/AccountRateLimitsOrders"] = global::Binance.Spot.Examples.WebSocketApi.Account.AccountRateLimitsOrders.Main,
        ["WebSocketApi/Account/AccountStatus"] = global::Binance.Spot.Examples.WebSocketApi.Account.AccountStatus.Main,
        ["WebSocketApi/Account/AllOrderLists"] = global::Binance.Spot.Examples.WebSocketApi.Account.AllOrderLists.Main,
        ["WebSocketApi/Account/AllOrders"] = global::Binance.Spot.Examples.WebSocketApi.Account.AllOrders.Main,
        ["WebSocketApi/Account/MyAllocations"] = global::Binance.Spot.Examples.WebSocketApi.Account.MyAllocations.Main,
        ["WebSocketApi/Account/MyFilters"] = global::Binance.Spot.Examples.WebSocketApi.Account.MyFilters.Main,
        ["WebSocketApi/Account/MyPreventedMatches"] = global::Binance.Spot.Examples.WebSocketApi.Account.MyPreventedMatches.Main,
        ["WebSocketApi/Account/MyTrades"] = global::Binance.Spot.Examples.WebSocketApi.Account.MyTrades.Main,
        ["WebSocketApi/Account/OpenOrderListsStatus"] = global::Binance.Spot.Examples.WebSocketApi.Account.OpenOrderListsStatus.Main,
        ["WebSocketApi/Account/OpenOrdersStatus"] = global::Binance.Spot.Examples.WebSocketApi.Account.OpenOrdersStatus.Main,
        ["WebSocketApi/Account/OrderAmendments"] = global::Binance.Spot.Examples.WebSocketApi.Account.OrderAmendments.Main,
        ["WebSocketApi/Account/OrderListStatus"] = global::Binance.Spot.Examples.WebSocketApi.Account.OrderListStatus.Main,
        ["WebSocketApi/Account/OrderStatus"] = global::Binance.Spot.Examples.WebSocketApi.Account.OrderStatus.Main,
        ["WebSocketApi/Auth/SessionLogon"] = global::Binance.Spot.Examples.WebSocketApi.Auth.SessionLogon.Main,
        ["WebSocketApi/Auth/SessionLogout"] = global::Binance.Spot.Examples.WebSocketApi.Auth.SessionLogout.Main,
        ["WebSocketApi/Auth/SessionStatus"] = global::Binance.Spot.Examples.WebSocketApi.Auth.SessionStatus.Main,
        ["WebSocketApi/General/ExchangeInfo"] = global::Binance.Spot.Examples.WebSocketApi.General.ExchangeInfo.Main,
        ["WebSocketApi/General/ExecutionRules"] = global::Binance.Spot.Examples.WebSocketApi.General.ExecutionRules.Main,
        ["WebSocketApi/General/Ping"] = global::Binance.Spot.Examples.WebSocketApi.General.Ping.Main,
        ["WebSocketApi/General/Time"] = global::Binance.Spot.Examples.WebSocketApi.General.Time.Main,
        ["WebSocketApi/Market/AvgPrice"] = global::Binance.Spot.Examples.WebSocketApi.Market.AvgPrice.Main,
        ["WebSocketApi/Market/BlockTradesHistorical"] = global::Binance.Spot.Examples.WebSocketApi.Market.BlockTradesHistorical.Main,
        ["WebSocketApi/Market/Depth"] = global::Binance.Spot.Examples.WebSocketApi.Market.Depth.Main,
        ["WebSocketApi/Market/Klines"] = global::Binance.Spot.Examples.WebSocketApi.Market.Klines.Main,
        ["WebSocketApi/Market/ReferencePrice"] = global::Binance.Spot.Examples.WebSocketApi.Market.ReferencePrice.Main,
        ["WebSocketApi/Market/ReferencePriceCalculation"] = global::Binance.Spot.Examples.WebSocketApi.Market.ReferencePriceCalculation.Main,
        ["WebSocketApi/Market/Ticker"] = global::Binance.Spot.Examples.WebSocketApi.Market.Ticker.Main,
        ["WebSocketApi/Market/Ticker24hr"] = global::Binance.Spot.Examples.WebSocketApi.Market.Ticker24hr.Main,
        ["WebSocketApi/Market/TickerBook"] = global::Binance.Spot.Examples.WebSocketApi.Market.TickerBook.Main,
        ["WebSocketApi/Market/TickerPrice"] = global::Binance.Spot.Examples.WebSocketApi.Market.TickerPrice.Main,
        ["WebSocketApi/Market/TickerTradingDay"] = global::Binance.Spot.Examples.WebSocketApi.Market.TickerTradingDay.Main,
        ["WebSocketApi/Market/TradesAggregate"] = global::Binance.Spot.Examples.WebSocketApi.Market.TradesAggregate.Main,
        ["WebSocketApi/Market/TradesHistorical"] = global::Binance.Spot.Examples.WebSocketApi.Market.TradesHistorical.Main,
        ["WebSocketApi/Market/TradesRecent"] = global::Binance.Spot.Examples.WebSocketApi.Market.TradesRecent.Main,
        ["WebSocketApi/Market/UiKlines"] = global::Binance.Spot.Examples.WebSocketApi.Market.UiKlines.Main,
        ["WebSocketApi/Trade/OpenOrdersCancelAll"] = global::Binance.Spot.Examples.WebSocketApi.Trade.OpenOrdersCancelAll.Main,
        ["WebSocketApi/Trade/OrderAmendKeepPriority"] = global::Binance.Spot.Examples.WebSocketApi.Trade.OrderAmendKeepPriority.Main,
        ["WebSocketApi/Trade/OrderCancel"] = global::Binance.Spot.Examples.WebSocketApi.Trade.OrderCancel.Main,
        ["WebSocketApi/Trade/OrderCancelReplace"] = global::Binance.Spot.Examples.WebSocketApi.Trade.OrderCancelReplace.Main,
        ["WebSocketApi/Trade/OrderListCancel"] = global::Binance.Spot.Examples.WebSocketApi.Trade.OrderListCancel.Main,
        ["WebSocketApi/Trade/OrderListPlace"] = global::Binance.Spot.Examples.WebSocketApi.Trade.OrderListPlace.Main,
        ["WebSocketApi/Trade/OrderListPlaceOco"] = global::Binance.Spot.Examples.WebSocketApi.Trade.OrderListPlaceOco.Main,
        ["WebSocketApi/Trade/OrderListPlaceOpo"] = global::Binance.Spot.Examples.WebSocketApi.Trade.OrderListPlaceOpo.Main,
        ["WebSocketApi/Trade/OrderListPlaceOpoco"] = global::Binance.Spot.Examples.WebSocketApi.Trade.OrderListPlaceOpoco.Main,
        ["WebSocketApi/Trade/OrderListPlaceOto"] = global::Binance.Spot.Examples.WebSocketApi.Trade.OrderListPlaceOto.Main,
        ["WebSocketApi/Trade/OrderListPlaceOtoco"] = global::Binance.Spot.Examples.WebSocketApi.Trade.OrderListPlaceOtoco.Main,
        ["WebSocketApi/Trade/OrderPlace"] = global::Binance.Spot.Examples.WebSocketApi.Trade.OrderPlace.Main,
        ["WebSocketApi/Trade/OrderTest"] = global::Binance.Spot.Examples.WebSocketApi.Trade.OrderTest.Main,
        ["WebSocketApi/Trade/SorOrderPlace"] = global::Binance.Spot.Examples.WebSocketApi.Trade.SorOrderPlace.Main,
        ["WebSocketApi/Trade/SorOrderTest"] = global::Binance.Spot.Examples.WebSocketApi.Trade.SorOrderTest.Main,
        ["WebSocketApi/UserDataStream/SessionSubscriptions"] = global::Binance.Spot.Examples.WebSocketApi.UserDataStream.SessionSubscriptions.Main,
        ["WebSocketApi/UserDataStream/UserDataStreamSubscribe"] = global::Binance.Spot.Examples.WebSocketApi.UserDataStream.UserDataStreamSubscribe.Main,
        ["WebSocketApi/UserDataStream/UserDataStreamSubscribeSignature"] = global::Binance.Spot.Examples.WebSocketApi.UserDataStream.UserDataStreamSubscribeSignature.Main,
        ["WebSocketApi/UserDataStream/UserDataStreamUnsubscribe"] = global::Binance.Spot.Examples.WebSocketApi.UserDataStream.UserDataStreamUnsubscribe.Main,
        ["WebSocketStreams/AggTrade"] = global::Binance.Spot.Examples.WebSocketStreams.AggTrade.Main,
        ["WebSocketStreams/AllMarketRollingWindowTicker"] = global::Binance.Spot.Examples.WebSocketStreams.AllMarketRollingWindowTicker.Main,
        ["WebSocketStreams/AllMiniTicker"] = global::Binance.Spot.Examples.WebSocketStreams.AllMiniTicker.Main,
        ["WebSocketStreams/AvgPrice"] = global::Binance.Spot.Examples.WebSocketStreams.AvgPrice.Main,
        ["WebSocketStreams/BlockTrade"] = global::Binance.Spot.Examples.WebSocketStreams.BlockTrade.Main,
        ["WebSocketStreams/BookTicker"] = global::Binance.Spot.Examples.WebSocketStreams.BookTicker.Main,
        ["WebSocketStreams/DiffBookDepth"] = global::Binance.Spot.Examples.WebSocketStreams.DiffBookDepth.Main,
        ["WebSocketStreams/Kline"] = global::Binance.Spot.Examples.WebSocketStreams.Kline.Main,
        ["WebSocketStreams/KlineOffset"] = global::Binance.Spot.Examples.WebSocketStreams.KlineOffset.Main,
        ["WebSocketStreams/MiniTicker"] = global::Binance.Spot.Examples.WebSocketStreams.MiniTicker.Main,
        ["WebSocketStreams/PartialBookDepth"] = global::Binance.Spot.Examples.WebSocketStreams.PartialBookDepth.Main,
        ["WebSocketStreams/ReferencePrice"] = global::Binance.Spot.Examples.WebSocketStreams.ReferencePrice.Main,
        ["WebSocketStreams/RollingWindowTicker"] = global::Binance.Spot.Examples.WebSocketStreams.RollingWindowTicker.Main,
        ["WebSocketStreams/Ticker"] = global::Binance.Spot.Examples.WebSocketStreams.Ticker.Main,
        ["WebSocketStreams/Trade"] = global::Binance.Spot.Examples.WebSocketStreams.Trade.Main,
    };

    public static async Task<int> Main(string[] args)
    {
        if (args.Length == 1 && Examples.TryGetValue(args[0].Replace('\\', '/'), out var run))
        {
            await run();
            return 0;
        }

        Console.Error.WriteLine("Usage: dotnet run --project examples/Binance.Spot.Examples -- <example>");
        Console.Error.WriteLine("Examples:");
        foreach (var name in Examples.Keys.Order(StringComparer.OrdinalIgnoreCase))
            Console.Error.WriteLine("  " + name);
        return args.Length == 0 ? 0 : 1;
    }
}
