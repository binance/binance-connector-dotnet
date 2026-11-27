//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

namespace Binance.GiftCard.Examples;

internal static class Program
{
    private static readonly Dictionary<string, Func<Task>> Examples = new(StringComparer.OrdinalIgnoreCase)
    {
        ["RestApi/MarketData/CreateADualTokenGiftCard"] = global::Binance.GiftCard.Examples.RestApi.MarketData.CreateADualTokenGiftCard.Main,
        ["RestApi/MarketData/CreateASingleTokenGiftCard"] = global::Binance.GiftCard.Examples.RestApi.MarketData.CreateASingleTokenGiftCard.Main,
        ["RestApi/MarketData/FetchRsaPublicKey"] = global::Binance.GiftCard.Examples.RestApi.MarketData.FetchRsaPublicKey.Main,
        ["RestApi/MarketData/FetchTokenLimit"] = global::Binance.GiftCard.Examples.RestApi.MarketData.FetchTokenLimit.Main,
        ["RestApi/MarketData/RedeemABinanceGiftCard"] = global::Binance.GiftCard.Examples.RestApi.MarketData.RedeemABinanceGiftCard.Main,
        ["RestApi/MarketData/VerifyBinanceGiftCardByGiftCardNumber"] = global::Binance.GiftCard.Examples.RestApi.MarketData.VerifyBinanceGiftCardByGiftCardNumber.Main,
    };

    public static async Task<int> Main(string[] args)
    {
        if (args.Length == 1 && Examples.TryGetValue(args[0].Replace('\\', '/'), out var run))
        {
            await run();
            return 0;
        }

        Console.Error.WriteLine("Usage: dotnet run --project examples/Binance.GiftCard.Examples -- <example>");
        Console.Error.WriteLine("Examples:");
        foreach (var name in Examples.Keys.Order(StringComparer.OrdinalIgnoreCase))
            Console.Error.WriteLine("  " + name);
        return args.Length == 0 ? 0 : 1;
    }
}
