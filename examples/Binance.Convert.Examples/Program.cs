//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

namespace Binance.Convert.Examples;

internal static class Program
{
    private static readonly Dictionary<string, Func<Task>> Examples = new(StringComparer.OrdinalIgnoreCase)
    {
        ["RestApi/MarketData/ListAllConvertPairs"] = global::Binance.Convert.Examples.RestApi.MarketData.ListAllConvertPairs.Main,
        ["RestApi/MarketData/QueryOrderQuantityPrecisionPerAsset"] = global::Binance.Convert.Examples.RestApi.MarketData.QueryOrderQuantityPrecisionPerAsset.Main,
        ["RestApi/Trade/AcceptQuote"] = global::Binance.Convert.Examples.RestApi.Trade.AcceptQuote.Main,
        ["RestApi/Trade/CancelLimitOrder"] = global::Binance.Convert.Examples.RestApi.Trade.CancelLimitOrder.Main,
        ["RestApi/Trade/GetConvertTradeHistory"] = global::Binance.Convert.Examples.RestApi.Trade.GetConvertTradeHistory.Main,
        ["RestApi/Trade/OrderStatus"] = global::Binance.Convert.Examples.RestApi.Trade.OrderStatus.Main,
        ["RestApi/Trade/PlaceLimitOrder"] = global::Binance.Convert.Examples.RestApi.Trade.PlaceLimitOrder.Main,
        ["RestApi/Trade/QueryLimitOpenOrders"] = global::Binance.Convert.Examples.RestApi.Trade.QueryLimitOpenOrders.Main,
        ["RestApi/Trade/SendQuoteRequest"] = global::Binance.Convert.Examples.RestApi.Trade.SendQuoteRequest.Main,
    };

    public static async Task<int> Main(string[] args)
    {
        if (args.Length == 1 && Examples.TryGetValue(args[0].Replace('\\', '/'), out var run))
        {
            await run();
            return 0;
        }

        Console.Error.WriteLine("Usage: dotnet run --project examples/Binance.Convert.Examples -- <example>");
        Console.Error.WriteLine("Examples:");
        foreach (var name in Examples.Keys.Order(StringComparer.OrdinalIgnoreCase))
            Console.Error.WriteLine("  " + name);
        return args.Length == 0 ? 0 : 1;
    }
}
