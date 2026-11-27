//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

namespace Binance.Mining.Examples;

internal static class Program
{
    private static readonly Dictionary<string, Func<Task>> Examples = new(StringComparer.OrdinalIgnoreCase)
    {
        ["RestApi/AccountList"] = global::Binance.Mining.Examples.RestApi.AccountList.Main,
        ["RestApi/AcquiringAlgorithm"] = global::Binance.Mining.Examples.RestApi.AcquiringAlgorithm.Main,
        ["RestApi/AcquiringCoinname"] = global::Binance.Mining.Examples.RestApi.AcquiringCoinname.Main,
        ["RestApi/CancelHashrateResaleConfiguration"] = global::Binance.Mining.Examples.RestApi.CancelHashrateResaleConfiguration.Main,
        ["RestApi/EarningsList"] = global::Binance.Mining.Examples.RestApi.EarningsList.Main,
        ["RestApi/ExtraBonusList"] = global::Binance.Mining.Examples.RestApi.ExtraBonusList.Main,
        ["RestApi/HashrateResaleDetail"] = global::Binance.Mining.Examples.RestApi.HashrateResaleDetail.Main,
        ["RestApi/HashrateResaleList"] = global::Binance.Mining.Examples.RestApi.HashrateResaleList.Main,
        ["RestApi/HashrateResaleRequest"] = global::Binance.Mining.Examples.RestApi.HashrateResaleRequest.Main,
        ["RestApi/MiningAccountEarning"] = global::Binance.Mining.Examples.RestApi.MiningAccountEarning.Main,
        ["RestApi/RequestForDetailMinerList"] = global::Binance.Mining.Examples.RestApi.RequestForDetailMinerList.Main,
        ["RestApi/RequestForMinerList"] = global::Binance.Mining.Examples.RestApi.RequestForMinerList.Main,
        ["RestApi/StatisticList"] = global::Binance.Mining.Examples.RestApi.StatisticList.Main,
    };

    public static async Task<int> Main(string[] args)
    {
        if (args.Length == 1 && Examples.TryGetValue(args[0].Replace('\\', '/'), out var run))
        {
            await run();
            return 0;
        }

        Console.Error.WriteLine("Usage: dotnet run --project examples/Binance.Mining.Examples -- <example>");
        Console.Error.WriteLine("Examples:");
        foreach (var name in Examples.Keys.Order(StringComparer.OrdinalIgnoreCase))
            Console.Error.WriteLine("  " + name);
        return args.Length == 0 ? 0 : 1;
    }
}
