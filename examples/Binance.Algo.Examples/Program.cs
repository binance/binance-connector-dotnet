//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

namespace Binance.Algo.Examples;

internal static class Program
{
    private static readonly Dictionary<string, Func<Task>> Examples = new(StringComparer.OrdinalIgnoreCase)
    {
        ["RestApi/FutureAlgo/CancelAlgoOrderFutureAlgo"] = global::Binance.Algo.Examples.RestApi.FutureAlgo.CancelAlgoOrderFutureAlgo.Main,
        ["RestApi/FutureAlgo/QueryCurrentAlgoOpenOrdersFutureAlgo"] = global::Binance.Algo.Examples.RestApi.FutureAlgo.QueryCurrentAlgoOpenOrdersFutureAlgo.Main,
        ["RestApi/FutureAlgo/QueryHistoricalAlgoOrdersFutureAlgo"] = global::Binance.Algo.Examples.RestApi.FutureAlgo.QueryHistoricalAlgoOrdersFutureAlgo.Main,
        ["RestApi/FutureAlgo/QuerySubOrdersFutureAlgo"] = global::Binance.Algo.Examples.RestApi.FutureAlgo.QuerySubOrdersFutureAlgo.Main,
        ["RestApi/FutureAlgo/TimeWeightedAveragePriceFutureAlgo"] = global::Binance.Algo.Examples.RestApi.FutureAlgo.TimeWeightedAveragePriceFutureAlgo.Main,
        ["RestApi/FutureAlgo/VolumeParticipationFutureAlgo"] = global::Binance.Algo.Examples.RestApi.FutureAlgo.VolumeParticipationFutureAlgo.Main,
        ["RestApi/SpotAlgo/CancelAlgoOrderSpotAlgo"] = global::Binance.Algo.Examples.RestApi.SpotAlgo.CancelAlgoOrderSpotAlgo.Main,
        ["RestApi/SpotAlgo/QueryCurrentAlgoOpenOrdersSpotAlgo"] = global::Binance.Algo.Examples.RestApi.SpotAlgo.QueryCurrentAlgoOpenOrdersSpotAlgo.Main,
        ["RestApi/SpotAlgo/QueryHistoricalAlgoOrdersSpotAlgo"] = global::Binance.Algo.Examples.RestApi.SpotAlgo.QueryHistoricalAlgoOrdersSpotAlgo.Main,
        ["RestApi/SpotAlgo/QuerySubOrdersSpotAlgo"] = global::Binance.Algo.Examples.RestApi.SpotAlgo.QuerySubOrdersSpotAlgo.Main,
        ["RestApi/SpotAlgo/TimeWeightedAveragePriceSpotAlgo"] = global::Binance.Algo.Examples.RestApi.SpotAlgo.TimeWeightedAveragePriceSpotAlgo.Main,
        ["RestApi/SpotAlgo/VolumeParticipation"] = global::Binance.Algo.Examples.RestApi.SpotAlgo.VolumeParticipation.Main,
    };

    public static async Task<int> Main(string[] args)
    {
        if (args.Length == 1 && Examples.TryGetValue(args[0].Replace('\\', '/'), out var run))
        {
            await run();
            return 0;
        }

        Console.Error.WriteLine("Usage: dotnet run --project examples/Binance.Algo.Examples -- <example>");
        Console.Error.WriteLine("Examples:");
        foreach (var name in Examples.Keys.Order(StringComparer.OrdinalIgnoreCase))
            Console.Error.WriteLine("  " + name);
        return args.Length == 0 ? 0 : 1;
    }
}
