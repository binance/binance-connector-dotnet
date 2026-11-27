//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

namespace Binance.SimpleEarn.Examples;

internal static class Program
{
    private static readonly Dictionary<string, Func<Task>> Examples = new(StringComparer.OrdinalIgnoreCase)
    {
        ["RestApi/Bfusd/GetBfusdAccount"] = global::Binance.SimpleEarn.Examples.RestApi.Bfusd.GetBfusdAccount.Main,
        ["RestApi/Bfusd/GetBfusdQuotaDetails"] = global::Binance.SimpleEarn.Examples.RestApi.Bfusd.GetBfusdQuotaDetails.Main,
        ["RestApi/Bfusd/GetBfusdRateHistory"] = global::Binance.SimpleEarn.Examples.RestApi.Bfusd.GetBfusdRateHistory.Main,
        ["RestApi/Bfusd/GetBfusdRedemptionHistory"] = global::Binance.SimpleEarn.Examples.RestApi.Bfusd.GetBfusdRedemptionHistory.Main,
        ["RestApi/Bfusd/GetBfusdRewardsHistory"] = global::Binance.SimpleEarn.Examples.RestApi.Bfusd.GetBfusdRewardsHistory.Main,
        ["RestApi/Bfusd/GetBfusdSubscriptionHistory"] = global::Binance.SimpleEarn.Examples.RestApi.Bfusd.GetBfusdSubscriptionHistory.Main,
        ["RestApi/Bfusd/RedeemBfusd"] = global::Binance.SimpleEarn.Examples.RestApi.Bfusd.RedeemBfusd.Main,
        ["RestApi/Bfusd/SubscribeBfusd"] = global::Binance.SimpleEarn.Examples.RestApi.Bfusd.SubscribeBfusd.Main,
        ["RestApi/FlexibleLocked/GetCollateralRecord"] = global::Binance.SimpleEarn.Examples.RestApi.FlexibleLocked.GetCollateralRecord.Main,
        ["RestApi/FlexibleLocked/GetFlexiblePersonalLeftQuota"] = global::Binance.SimpleEarn.Examples.RestApi.FlexibleLocked.GetFlexiblePersonalLeftQuota.Main,
        ["RestApi/FlexibleLocked/GetFlexibleProductPosition"] = global::Binance.SimpleEarn.Examples.RestApi.FlexibleLocked.GetFlexibleProductPosition.Main,
        ["RestApi/FlexibleLocked/GetFlexibleRedemptionRecord"] = global::Binance.SimpleEarn.Examples.RestApi.FlexibleLocked.GetFlexibleRedemptionRecord.Main,
        ["RestApi/FlexibleLocked/GetFlexibleRewardsHistory"] = global::Binance.SimpleEarn.Examples.RestApi.FlexibleLocked.GetFlexibleRewardsHistory.Main,
        ["RestApi/FlexibleLocked/GetFlexibleSubscriptionPreview"] = global::Binance.SimpleEarn.Examples.RestApi.FlexibleLocked.GetFlexibleSubscriptionPreview.Main,
        ["RestApi/FlexibleLocked/GetFlexibleSubscriptionRecord"] = global::Binance.SimpleEarn.Examples.RestApi.FlexibleLocked.GetFlexibleSubscriptionRecord.Main,
        ["RestApi/FlexibleLocked/GetLockedPersonalLeftQuota"] = global::Binance.SimpleEarn.Examples.RestApi.FlexibleLocked.GetLockedPersonalLeftQuota.Main,
        ["RestApi/FlexibleLocked/GetLockedProductPosition"] = global::Binance.SimpleEarn.Examples.RestApi.FlexibleLocked.GetLockedProductPosition.Main,
        ["RestApi/FlexibleLocked/GetLockedRedemptionRecord"] = global::Binance.SimpleEarn.Examples.RestApi.FlexibleLocked.GetLockedRedemptionRecord.Main,
        ["RestApi/FlexibleLocked/GetLockedRewardsHistory"] = global::Binance.SimpleEarn.Examples.RestApi.FlexibleLocked.GetLockedRewardsHistory.Main,
        ["RestApi/FlexibleLocked/GetLockedSubscriptionPreview"] = global::Binance.SimpleEarn.Examples.RestApi.FlexibleLocked.GetLockedSubscriptionPreview.Main,
        ["RestApi/FlexibleLocked/GetLockedSubscriptionRecord"] = global::Binance.SimpleEarn.Examples.RestApi.FlexibleLocked.GetLockedSubscriptionRecord.Main,
        ["RestApi/FlexibleLocked/GetRateHistory"] = global::Binance.SimpleEarn.Examples.RestApi.FlexibleLocked.GetRateHistory.Main,
        ["RestApi/FlexibleLocked/GetSimpleEarnFlexibleProductList"] = global::Binance.SimpleEarn.Examples.RestApi.FlexibleLocked.GetSimpleEarnFlexibleProductList.Main,
        ["RestApi/FlexibleLocked/GetSimpleEarnLockedProductList"] = global::Binance.SimpleEarn.Examples.RestApi.FlexibleLocked.GetSimpleEarnLockedProductList.Main,
        ["RestApi/FlexibleLocked/RedeemFlexibleProduct"] = global::Binance.SimpleEarn.Examples.RestApi.FlexibleLocked.RedeemFlexibleProduct.Main,
        ["RestApi/FlexibleLocked/RedeemLockedProduct"] = global::Binance.SimpleEarn.Examples.RestApi.FlexibleLocked.RedeemLockedProduct.Main,
        ["RestApi/FlexibleLocked/SetFlexibleAutoSubscribe"] = global::Binance.SimpleEarn.Examples.RestApi.FlexibleLocked.SetFlexibleAutoSubscribe.Main,
        ["RestApi/FlexibleLocked/SetLockedAutoSubscribe"] = global::Binance.SimpleEarn.Examples.RestApi.FlexibleLocked.SetLockedAutoSubscribe.Main,
        ["RestApi/FlexibleLocked/SetLockedProductRedeemOption"] = global::Binance.SimpleEarn.Examples.RestApi.FlexibleLocked.SetLockedProductRedeemOption.Main,
        ["RestApi/FlexibleLocked/SimpleAccount"] = global::Binance.SimpleEarn.Examples.RestApi.FlexibleLocked.SimpleAccount.Main,
        ["RestApi/FlexibleLocked/SubscribeFlexibleProduct"] = global::Binance.SimpleEarn.Examples.RestApi.FlexibleLocked.SubscribeFlexibleProduct.Main,
        ["RestApi/FlexibleLocked/SubscribeLockedProduct"] = global::Binance.SimpleEarn.Examples.RestApi.FlexibleLocked.SubscribeLockedProduct.Main,
        ["RestApi/Rwusd/GetRwusdAccount"] = global::Binance.SimpleEarn.Examples.RestApi.Rwusd.GetRwusdAccount.Main,
        ["RestApi/Rwusd/GetRwusdQuotaDetails"] = global::Binance.SimpleEarn.Examples.RestApi.Rwusd.GetRwusdQuotaDetails.Main,
        ["RestApi/Rwusd/GetRwusdRateHistory"] = global::Binance.SimpleEarn.Examples.RestApi.Rwusd.GetRwusdRateHistory.Main,
        ["RestApi/Rwusd/GetRwusdRedemptionHistory"] = global::Binance.SimpleEarn.Examples.RestApi.Rwusd.GetRwusdRedemptionHistory.Main,
        ["RestApi/Rwusd/GetRwusdRewardsHistory"] = global::Binance.SimpleEarn.Examples.RestApi.Rwusd.GetRwusdRewardsHistory.Main,
        ["RestApi/Rwusd/GetRwusdSubscriptionHistory"] = global::Binance.SimpleEarn.Examples.RestApi.Rwusd.GetRwusdSubscriptionHistory.Main,
        ["RestApi/Rwusd/RedeemRwusd"] = global::Binance.SimpleEarn.Examples.RestApi.Rwusd.RedeemRwusd.Main,
        ["RestApi/Rwusd/SubscribeRwusd"] = global::Binance.SimpleEarn.Examples.RestApi.Rwusd.SubscribeRwusd.Main,
        ["RestApi/YieldArena/GetYieldArenaActivities"] = global::Binance.SimpleEarn.Examples.RestApi.YieldArena.GetYieldArenaActivities.Main,
    };

    public static async Task<int> Main(string[] args)
    {
        if (args.Length == 1 && Examples.TryGetValue(args[0].Replace('\\', '/'), out var run))
        {
            await run();
            return 0;
        }

        Console.Error.WriteLine("Usage: dotnet run --project examples/Binance.SimpleEarn.Examples -- <example>");
        Console.Error.WriteLine("Examples:");
        foreach (var name in Examples.Keys.Order(StringComparer.OrdinalIgnoreCase))
            Console.Error.WriteLine("  " + name);
        return args.Length == 0 ? 0 : 1;
    }
}
