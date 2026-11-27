//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

namespace Binance.Stocks.Examples;

internal static class Program
{
    private static readonly Dictionary<string, Func<Task>> Examples = new(StringComparer.OrdinalIgnoreCase)
    {
        ["RestApi/Account/SignUsEquityDisclaimer"] = global::Binance.Stocks.Examples.RestApi.Account.SignUsEquityDisclaimer.Main,
        ["RestApi/MarketData/ExchangeInfo"] = global::Binance.Stocks.Examples.RestApi.MarketData.ExchangeInfo.Main,
        ["RestApi/MarketData/LatestQuote"] = global::Binance.Stocks.Examples.RestApi.MarketData.LatestQuote.Main,
        ["RestApi/MarketData/TokenizedAssets"] = global::Binance.Stocks.Examples.RestApi.MarketData.TokenizedAssets.Main,
        ["RestApi/Tokenized/BstocksCorporateActionRecords"] = global::Binance.Stocks.Examples.RestApi.Tokenized.BstocksCorporateActionRecords.Main,
        ["RestApi/Tokenized/CorporateActionRecords"] = global::Binance.Stocks.Examples.RestApi.Tokenized.CorporateActionRecords.Main,
        ["RestApi/Tokenized/TokenizedConvertHistory"] = global::Binance.Stocks.Examples.RestApi.Tokenized.TokenizedConvertHistory.Main,
        ["RestApi/Tokenized/TokenizedConvertStatus"] = global::Binance.Stocks.Examples.RestApi.Tokenized.TokenizedConvertStatus.Main,
        ["RestApi/Tokenized/TokenizedMint"] = global::Binance.Stocks.Examples.RestApi.Tokenized.TokenizedMint.Main,
        ["RestApi/Tokenized/TokenizedRedeem"] = global::Binance.Stocks.Examples.RestApi.Tokenized.TokenizedRedeem.Main,
        ["RestApi/Trade/CancelAllEquityOrders"] = global::Binance.Stocks.Examples.RestApi.Trade.CancelAllEquityOrders.Main,
        ["RestApi/Trade/CancelEquityOrder"] = global::Binance.Stocks.Examples.RestApi.Trade.CancelEquityOrder.Main,
        ["RestApi/Trade/CurrentOpenOrders"] = global::Binance.Stocks.Examples.RestApi.Trade.CurrentOpenOrders.Main,
        ["RestApi/Trade/EquityOrderDetail"] = global::Binance.Stocks.Examples.RestApi.Trade.EquityOrderDetail.Main,
        ["RestApi/Trade/EquityOrderHistory"] = global::Binance.Stocks.Examples.RestApi.Trade.EquityOrderHistory.Main,
        ["RestApi/Trade/EquityTradeHistory"] = global::Binance.Stocks.Examples.RestApi.Trade.EquityTradeHistory.Main,
        ["RestApi/Trade/PlaceEquityOrder"] = global::Binance.Stocks.Examples.RestApi.Trade.PlaceEquityOrder.Main,
        ["RestApi/UserDataStreams/CreateRenewListenKey"] = global::Binance.Stocks.Examples.RestApi.UserDataStreams.CreateRenewListenKey.Main,
        ["WebSocketStreams/MarketStreams/CalendarStream"] = global::Binance.Stocks.Examples.WebSocketStreams.MarketStreams.CalendarStream.Main,
        ["WebSocketStreams/MarketStreams/KlineStream"] = global::Binance.Stocks.Examples.WebSocketStreams.MarketStreams.KlineStream.Main,
        ["WebSocketStreams/MarketStreams/PriceStream"] = global::Binance.Stocks.Examples.WebSocketStreams.MarketStreams.PriceStream.Main,
        ["WebSocketStreams/MarketStreams/QuoteStream"] = global::Binance.Stocks.Examples.WebSocketStreams.MarketStreams.QuoteStream.Main,
        ["WebSocketStreams/MarketStreams/TradabilityStream"] = global::Binance.Stocks.Examples.WebSocketStreams.MarketStreams.TradabilityStream.Main,
        ["WebSocketStreams/MarketStreams/TradingStatusStream"] = global::Binance.Stocks.Examples.WebSocketStreams.MarketStreams.TradingStatusStream.Main,
        ["WebSocketStreams/UserStreams/OrderReportStream"] = global::Binance.Stocks.Examples.WebSocketStreams.UserStreams.OrderReportStream.Main,
    };

    public static async Task<int> Main(string[] args)
    {
        if (args.Length == 1 && Examples.TryGetValue(args[0].Replace('\\', '/'), out var run))
        {
            await run();
            return 0;
        }

        Console.Error.WriteLine("Usage: dotnet run --project examples/Binance.Stocks.Examples -- <example>");
        Console.Error.WriteLine("Examples:");
        foreach (var name in Examples.Keys.Order(StringComparer.OrdinalIgnoreCase))
            Console.Error.WriteLine("  " + name);
        return args.Length == 0 ? 0 : 1;
    }
}
