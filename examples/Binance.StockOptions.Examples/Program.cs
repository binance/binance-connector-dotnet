//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

namespace Binance.StockOptions.Examples;

internal static class Program
{
    private static readonly Dictionary<string, Func<Task>> Examples = new(StringComparer.OrdinalIgnoreCase)
    {
        ["RestApi/MarketData/OptionContracts"] = global::Binance.StockOptions.Examples.RestApi.MarketData.OptionContracts.Main,
        ["RestApi/MarketData/OptionExchangeInfo"] = global::Binance.StockOptions.Examples.RestApi.MarketData.OptionExchangeInfo.Main,
        ["RestApi/MarketData/OptionExpirations"] = global::Binance.StockOptions.Examples.RestApi.MarketData.OptionExpirations.Main,
        ["RestApi/Trade/CancelAllOptionOrders"] = global::Binance.StockOptions.Examples.RestApi.Trade.CancelAllOptionOrders.Main,
        ["RestApi/Trade/CancelOptionOrder"] = global::Binance.StockOptions.Examples.RestApi.Trade.CancelOptionOrder.Main,
        ["RestApi/Trade/PlaceOptionOrder"] = global::Binance.StockOptions.Examples.RestApi.Trade.PlaceOptionOrder.Main,
        ["RestApi/Trade/SubmitOptionExercise"] = global::Binance.StockOptions.Examples.RestApi.Trade.SubmitOptionExercise.Main,
        ["RestApi/UserData/CurrentOpenOptionOrders"] = global::Binance.StockOptions.Examples.RestApi.UserData.CurrentOpenOptionOrders.Main,
        ["RestApi/UserData/ExercisableOptions"] = global::Binance.StockOptions.Examples.RestApi.UserData.ExercisableOptions.Main,
        ["RestApi/UserData/OptionExerciseDetail"] = global::Binance.StockOptions.Examples.RestApi.UserData.OptionExerciseDetail.Main,
        ["RestApi/UserData/OptionExerciseHistory"] = global::Binance.StockOptions.Examples.RestApi.UserData.OptionExerciseHistory.Main,
        ["RestApi/UserData/OptionOrderDetail"] = global::Binance.StockOptions.Examples.RestApi.UserData.OptionOrderDetail.Main,
        ["RestApi/UserData/OptionOrderHistory"] = global::Binance.StockOptions.Examples.RestApi.UserData.OptionOrderHistory.Main,
        ["RestApi/UserData/OptionPositions"] = global::Binance.StockOptions.Examples.RestApi.UserData.OptionPositions.Main,
        ["RestApi/UserData/OptionSettlementEventDetail"] = global::Binance.StockOptions.Examples.RestApi.UserData.OptionSettlementEventDetail.Main,
        ["RestApi/UserData/OptionSettlementEventHistory"] = global::Binance.StockOptions.Examples.RestApi.UserData.OptionSettlementEventHistory.Main,
        ["RestApi/UserData/OptionTradeHistory"] = global::Binance.StockOptions.Examples.RestApi.UserData.OptionTradeHistory.Main,
        ["RestApi/UserDataStreams/CreateRenewListenKey"] = global::Binance.StockOptions.Examples.RestApi.UserDataStreams.CreateRenewListenKey.Main,
        ["WebSocketStreams/UserStreams/OrderReportV2Stream"] = global::Binance.StockOptions.Examples.WebSocketStreams.UserStreams.OrderReportV2Stream.Main,
    };

    public static async Task<int> Main(string[] args)
    {
        if (args.Length == 1 && Examples.TryGetValue(args[0].Replace('\\', '/'), out var run))
        {
            await run();
            return 0;
        }

        Console.Error.WriteLine("Usage: dotnet run --project examples/Binance.StockOptions.Examples -- <example>");
        Console.Error.WriteLine("Examples:");
        foreach (var name in Examples.Keys.Order(StringComparer.OrdinalIgnoreCase))
            Console.Error.WriteLine("  " + name);
        return args.Length == 0 ? 0 : 1;
    }
}
