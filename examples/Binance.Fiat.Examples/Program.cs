//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

namespace Binance.Fiat.Examples;

internal static class Program
{
    private static readonly Dictionary<string, Func<Task>> Examples = new(StringComparer.OrdinalIgnoreCase)
    {
        ["RestApi/Deposit"] = global::Binance.Fiat.Examples.RestApi.Deposit.Main,
        ["RestApi/FiatWithdraw"] = global::Binance.Fiat.Examples.RestApi.FiatWithdraw.Main,
        ["RestApi/GetFiatDepositWithdrawHistory"] = global::Binance.Fiat.Examples.RestApi.GetFiatDepositWithdrawHistory.Main,
        ["RestApi/GetFiatPaymentsHistory"] = global::Binance.Fiat.Examples.RestApi.GetFiatPaymentsHistory.Main,
        ["RestApi/GetOrderDetail"] = global::Binance.Fiat.Examples.RestApi.GetOrderDetail.Main,
    };

    public static async Task<int> Main(string[] args)
    {
        if (args.Length == 1 && Examples.TryGetValue(args[0].Replace('\\', '/'), out var run))
        {
            await run();
            return 0;
        }

        Console.Error.WriteLine("Usage: dotnet run --project examples/Binance.Fiat.Examples -- <example>");
        Console.Error.WriteLine("Examples:");
        foreach (var name in Examples.Keys.Order(StringComparer.OrdinalIgnoreCase))
            Console.Error.WriteLine("  " + name);
        return args.Length == 0 ? 0 : 1;
    }
}
