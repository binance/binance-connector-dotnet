//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

namespace Binance.Alpha.Examples;

internal static class Program
{
    private static readonly Dictionary<string, Func<Task>> Examples = new(StringComparer.OrdinalIgnoreCase)
    {
        ["RestApi/MarketData/AggregatedTrades"] = global::Binance.Alpha.Examples.RestApi.MarketData.AggregatedTrades.Main,
        ["RestApi/MarketData/FullDepth"] = global::Binance.Alpha.Examples.RestApi.MarketData.FullDepth.Main,
        ["RestApi/MarketData/GetExchangeInfo"] = global::Binance.Alpha.Examples.RestApi.MarketData.GetExchangeInfo.Main,
        ["RestApi/MarketData/Klines"] = global::Binance.Alpha.Examples.RestApi.MarketData.Klines.Main,
        ["RestApi/MarketData/Ticker"] = global::Binance.Alpha.Examples.RestApi.MarketData.Ticker.Main,
        ["RestApi/MarketData/TokenList"] = global::Binance.Alpha.Examples.RestApi.MarketData.TokenList.Main,
        ["WebSocketStreams/AggregateTradeStream"] = global::Binance.Alpha.Examples.WebSocketStreams.AggregateTradeStream.Main,
        ["WebSocketStreams/AllBookTickerStream"] = global::Binance.Alpha.Examples.WebSocketStreams.AllBookTickerStream.Main,
        ["WebSocketStreams/AllMiniTickerStream"] = global::Binance.Alpha.Examples.WebSocketStreams.AllMiniTickerStream.Main,
        ["WebSocketStreams/AllTickerStream"] = global::Binance.Alpha.Examples.WebSocketStreams.AllTickerStream.Main,
        ["WebSocketStreams/AllTokens24hTickerStream"] = global::Binance.Alpha.Examples.WebSocketStreams.AllTokens24hTickerStream.Main,
        ["WebSocketStreams/BookTickerStream"] = global::Binance.Alpha.Examples.WebSocketStreams.BookTickerStream.Main,
        ["WebSocketStreams/ContractKlineStream"] = global::Binance.Alpha.Examples.WebSocketStreams.ContractKlineStream.Main,
        ["WebSocketStreams/FullDepthStream"] = global::Binance.Alpha.Examples.WebSocketStreams.FullDepthStream.Main,
        ["WebSocketStreams/KlineStream"] = global::Binance.Alpha.Examples.WebSocketStreams.KlineStream.Main,
        ["WebSocketStreams/MiniTickerStream"] = global::Binance.Alpha.Examples.WebSocketStreams.MiniTickerStream.Main,
        ["WebSocketStreams/PartialDepthStream"] = global::Binance.Alpha.Examples.WebSocketStreams.PartialDepthStream.Main,
        ["WebSocketStreams/TickerStream"] = global::Binance.Alpha.Examples.WebSocketStreams.TickerStream.Main,
        ["WebSocketStreams/TradeStream"] = global::Binance.Alpha.Examples.WebSocketStreams.TradeStream.Main,
    };

    public static async Task<int> Main(string[] args)
    {
        if (args.Length == 1 && Examples.TryGetValue(args[0].Replace('\\', '/'), out var run))
        {
            await run();
            return 0;
        }

        Console.Error.WriteLine("Usage: dotnet run --project examples/Binance.Alpha.Examples -- <example>");
        Console.Error.WriteLine("Examples:");
        foreach (var name in Examples.Keys.Order(StringComparer.OrdinalIgnoreCase))
            Console.Error.WriteLine("  " + name);
        return args.Length == 0 ? 0 : 1;
    }
}
