//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

namespace Binance.DerivativesTradingOptions.Examples;

internal static class Program
{
    private static readonly Dictionary<string, Func<Task>> Examples = new(StringComparer.OrdinalIgnoreCase)
    {
        ["RestApi/Account/AccountFundingFlow"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.Account.AccountFundingFlow.Main,
        ["RestApi/Account/OptionMarginAccountInformation"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.Account.OptionMarginAccountInformation.Main,
        ["RestApi/MarketData/CheckServerTime"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.MarketData.CheckServerTime.Main,
        ["RestApi/MarketData/ExchangeInformation"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.MarketData.ExchangeInformation.Main,
        ["RestApi/MarketData/HistoricalExerciseRecords"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.MarketData.HistoricalExerciseRecords.Main,
        ["RestApi/MarketData/IndexPrice"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.MarketData.IndexPrice.Main,
        ["RestApi/MarketData/KlineCandlestickData"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.MarketData.KlineCandlestickData.Main,
        ["RestApi/MarketData/OpenInterest"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.MarketData.OpenInterest.Main,
        ["RestApi/MarketData/OptionMarkPrice"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.MarketData.OptionMarkPrice.Main,
        ["RestApi/MarketData/OrderBook"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.MarketData.OrderBook.Main,
        ["RestApi/MarketData/RecentBlockTradesList"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.MarketData.RecentBlockTradesList.Main,
        ["RestApi/MarketData/RecentTradesList"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.MarketData.RecentTradesList.Main,
        ["RestApi/MarketData/TestConnectivity"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.MarketData.TestConnectivity.Main,
        ["RestApi/MarketData/Ticker24hrPriceChangeStatistics"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.MarketData.Ticker24hrPriceChangeStatistics.Main,
        ["RestApi/MarketMakerBlockTrade/AcceptBlockTradeOrder"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.MarketMakerBlockTrade.AcceptBlockTradeOrder.Main,
        ["RestApi/MarketMakerBlockTrade/AccountBlockTradeList"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.MarketMakerBlockTrade.AccountBlockTradeList.Main,
        ["RestApi/MarketMakerBlockTrade/CancelBlockTradeOrder"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.MarketMakerBlockTrade.CancelBlockTradeOrder.Main,
        ["RestApi/MarketMakerBlockTrade/ExtendBlockTradeOrder"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.MarketMakerBlockTrade.ExtendBlockTradeOrder.Main,
        ["RestApi/MarketMakerBlockTrade/NewBlockTradeOrder"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.MarketMakerBlockTrade.NewBlockTradeOrder.Main,
        ["RestApi/MarketMakerBlockTrade/QueryBlockTradeDetails"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.MarketMakerBlockTrade.QueryBlockTradeDetails.Main,
        ["RestApi/MarketMakerBlockTrade/QueryBlockTradeOrder"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.MarketMakerBlockTrade.QueryBlockTradeOrder.Main,
        ["RestApi/MarketMakerEndpoints/AutoCancelAllOpenOrders"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.MarketMakerEndpoints.AutoCancelAllOpenOrders.Main,
        ["RestApi/MarketMakerEndpoints/GetAutoCancelAllOpenOrders"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.MarketMakerEndpoints.GetAutoCancelAllOpenOrders.Main,
        ["RestApi/MarketMakerEndpoints/GetMarketMakerProtectionConfig"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.MarketMakerEndpoints.GetMarketMakerProtectionConfig.Main,
        ["RestApi/MarketMakerEndpoints/ResetMarketMakerProtectionConfig"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.MarketMakerEndpoints.ResetMarketMakerProtectionConfig.Main,
        ["RestApi/MarketMakerEndpoints/SetAutoCancelAllOpenOrders"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.MarketMakerEndpoints.SetAutoCancelAllOpenOrders.Main,
        ["RestApi/MarketMakerEndpoints/SetMarketMakerProtectionConfig"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.MarketMakerEndpoints.SetMarketMakerProtectionConfig.Main,
        ["RestApi/Trade/AccountTradeList"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.Trade.AccountTradeList.Main,
        ["RestApi/Trade/CancelAllOptionOrdersByUnderlying"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.Trade.CancelAllOptionOrdersByUnderlying.Main,
        ["RestApi/Trade/CancelAllOptionOrdersOnSpecificSymbol"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.Trade.CancelAllOptionOrdersOnSpecificSymbol.Main,
        ["RestApi/Trade/CancelMultipleOptionOrders"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.Trade.CancelMultipleOptionOrders.Main,
        ["RestApi/Trade/CancelOptionOrder"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.Trade.CancelOptionOrder.Main,
        ["RestApi/Trade/NewOrder"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.Trade.NewOrder.Main,
        ["RestApi/Trade/OptionPositionInformation"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.Trade.OptionPositionInformation.Main,
        ["RestApi/Trade/PlaceMultipleOrders"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.Trade.PlaceMultipleOrders.Main,
        ["RestApi/Trade/QueryCurrentOpenOptionOrders"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.Trade.QueryCurrentOpenOptionOrders.Main,
        ["RestApi/Trade/QueryOptionOrderHistory"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.Trade.QueryOptionOrderHistory.Main,
        ["RestApi/Trade/QuerySingleOrder"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.Trade.QuerySingleOrder.Main,
        ["RestApi/Trade/TradfiOptionsContract"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.Trade.TradfiOptionsContract.Main,
        ["RestApi/Trade/UserCommission"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.Trade.UserCommission.Main,
        ["RestApi/Trade/UserExerciseRecord"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.Trade.UserExerciseRecord.Main,
        ["RestApi/UserDataStreams/CloseUserDataStream"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.UserDataStreams.CloseUserDataStream.Main,
        ["RestApi/UserDataStreams/KeepaliveUserDataStream"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.UserDataStreams.KeepaliveUserDataStream.Main,
        ["RestApi/UserDataStreams/StartUserDataStream"] = global::Binance.DerivativesTradingOptions.Examples.RestApi.UserDataStreams.StartUserDataStream.Main,
        ["WebSocketStreams/Market/IndexPriceStreams"] = global::Binance.DerivativesTradingOptions.Examples.WebSocketStreams.Market.IndexPriceStreams.Main,
        ["WebSocketStreams/Market/KlineCandlestickStreams"] = global::Binance.DerivativesTradingOptions.Examples.WebSocketStreams.Market.KlineCandlestickStreams.Main,
        ["WebSocketStreams/Market/NewSymbolInfo"] = global::Binance.DerivativesTradingOptions.Examples.WebSocketStreams.Market.NewSymbolInfo.Main,
        ["WebSocketStreams/Market/OpenInterest"] = global::Binance.DerivativesTradingOptions.Examples.WebSocketStreams.Market.OpenInterest.Main,
        ["WebSocketStreams/Market/OptionMarkPrice"] = global::Binance.DerivativesTradingOptions.Examples.WebSocketStreams.Market.OptionMarkPrice.Main,
        ["WebSocketStreams/Public/DiffBookDepthStreams"] = global::Binance.DerivativesTradingOptions.Examples.WebSocketStreams.PublicApi.DiffBookDepthStreams.Main,
        ["WebSocketStreams/Public/Hour24Ticker"] = global::Binance.DerivativesTradingOptions.Examples.WebSocketStreams.PublicApi.Hour24Ticker.Main,
        ["WebSocketStreams/Public/IndividualSymbolBookTickerStreams"] = global::Binance.DerivativesTradingOptions.Examples.WebSocketStreams.PublicApi.IndividualSymbolBookTickerStreams.Main,
        ["WebSocketStreams/Public/PartialBookDepthStreams"] = global::Binance.DerivativesTradingOptions.Examples.WebSocketStreams.PublicApi.PartialBookDepthStreams.Main,
        ["WebSocketStreams/Public/TradeStreams"] = global::Binance.DerivativesTradingOptions.Examples.WebSocketStreams.PublicApi.TradeStreams.Main,
    };

    public static async Task<int> Main(string[] args)
    {
        if (args.Length == 1 && Examples.TryGetValue(args[0].Replace('\\', '/'), out var run))
        {
            await run();
            return 0;
        }

        Console.Error.WriteLine("Usage: dotnet run --project examples/Binance.DerivativesTradingOptions.Examples -- <example>");
        Console.Error.WriteLine("Examples:");
        foreach (var name in Examples.Keys.Order(StringComparer.OrdinalIgnoreCase))
            Console.Error.WriteLine("  " + name);
        return args.Length == 0 ? 0 : 1;
    }
}
