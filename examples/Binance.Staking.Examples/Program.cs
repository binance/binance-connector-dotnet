//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

namespace Binance.Staking.Examples;

internal static class Program
{
    private static readonly Dictionary<string, Func<Task>> Examples = new(StringComparer.OrdinalIgnoreCase)
    {
        ["RestApi/EthStaking/EthStakingAccount"] = global::Binance.Staking.Examples.RestApi.EthStaking.EthStakingAccount.Main,
        ["RestApi/EthStaking/GetCurrentEthStakingQuota"] = global::Binance.Staking.Examples.RestApi.EthStaking.GetCurrentEthStakingQuota.Main,
        ["RestApi/EthStaking/GetEthRedemptionHistory"] = global::Binance.Staking.Examples.RestApi.EthStaking.GetEthRedemptionHistory.Main,
        ["RestApi/EthStaking/GetEthStakingHistory"] = global::Binance.Staking.Examples.RestApi.EthStaking.GetEthStakingHistory.Main,
        ["RestApi/EthStaking/GetWbethRateHistory"] = global::Binance.Staking.Examples.RestApi.EthStaking.GetWbethRateHistory.Main,
        ["RestApi/EthStaking/GetWbethRewardsHistory"] = global::Binance.Staking.Examples.RestApi.EthStaking.GetWbethRewardsHistory.Main,
        ["RestApi/EthStaking/GetWbethUnwrapHistory"] = global::Binance.Staking.Examples.RestApi.EthStaking.GetWbethUnwrapHistory.Main,
        ["RestApi/EthStaking/GetWbethWrapHistory"] = global::Binance.Staking.Examples.RestApi.EthStaking.GetWbethWrapHistory.Main,
        ["RestApi/EthStaking/RedeemEth"] = global::Binance.Staking.Examples.RestApi.EthStaking.RedeemEth.Main,
        ["RestApi/EthStaking/SubscribeEthStaking"] = global::Binance.Staking.Examples.RestApi.EthStaking.SubscribeEthStaking.Main,
        ["RestApi/EthStaking/WrapBeth"] = global::Binance.Staking.Examples.RestApi.EthStaking.WrapBeth.Main,
        ["RestApi/OnChainYields/GetOnChainYieldsLockedPersonalLeftQuota"] = global::Binance.Staking.Examples.RestApi.OnChainYields.GetOnChainYieldsLockedPersonalLeftQuota.Main,
        ["RestApi/OnChainYields/GetOnChainYieldsLockedProductList"] = global::Binance.Staking.Examples.RestApi.OnChainYields.GetOnChainYieldsLockedProductList.Main,
        ["RestApi/OnChainYields/GetOnChainYieldsLockedProductPosition"] = global::Binance.Staking.Examples.RestApi.OnChainYields.GetOnChainYieldsLockedProductPosition.Main,
        ["RestApi/OnChainYields/GetOnChainYieldsLockedRedemptionRecord"] = global::Binance.Staking.Examples.RestApi.OnChainYields.GetOnChainYieldsLockedRedemptionRecord.Main,
        ["RestApi/OnChainYields/GetOnChainYieldsLockedRewardsHistory"] = global::Binance.Staking.Examples.RestApi.OnChainYields.GetOnChainYieldsLockedRewardsHistory.Main,
        ["RestApi/OnChainYields/GetOnChainYieldsLockedSubscriptionPreview"] = global::Binance.Staking.Examples.RestApi.OnChainYields.GetOnChainYieldsLockedSubscriptionPreview.Main,
        ["RestApi/OnChainYields/GetOnChainYieldsLockedSubscriptionRecord"] = global::Binance.Staking.Examples.RestApi.OnChainYields.GetOnChainYieldsLockedSubscriptionRecord.Main,
        ["RestApi/OnChainYields/OnChainYieldsAccount"] = global::Binance.Staking.Examples.RestApi.OnChainYields.OnChainYieldsAccount.Main,
        ["RestApi/OnChainYields/RedeemOnChainYieldsLockedProduct"] = global::Binance.Staking.Examples.RestApi.OnChainYields.RedeemOnChainYieldsLockedProduct.Main,
        ["RestApi/OnChainYields/SetOnChainYieldsLockedAutoSubscribe"] = global::Binance.Staking.Examples.RestApi.OnChainYields.SetOnChainYieldsLockedAutoSubscribe.Main,
        ["RestApi/OnChainYields/SetOnChainYieldsLockedProductRedeemOption"] = global::Binance.Staking.Examples.RestApi.OnChainYields.SetOnChainYieldsLockedProductRedeemOption.Main,
        ["RestApi/OnChainYields/SubscribeOnChainYieldsLockedProduct"] = global::Binance.Staking.Examples.RestApi.OnChainYields.SubscribeOnChainYieldsLockedProduct.Main,
        ["RestApi/SoftStaking/GetSoftStakingProductList"] = global::Binance.Staking.Examples.RestApi.SoftStaking.GetSoftStakingProductList.Main,
        ["RestApi/SoftStaking/GetSoftStakingRewardsHistory"] = global::Binance.Staking.Examples.RestApi.SoftStaking.GetSoftStakingRewardsHistory.Main,
        ["RestApi/SoftStaking/SetSoftStaking"] = global::Binance.Staking.Examples.RestApi.SoftStaking.SetSoftStaking.Main,
        ["RestApi/SolStaking/ClaimBoostRewards"] = global::Binance.Staking.Examples.RestApi.SolStaking.ClaimBoostRewards.Main,
        ["RestApi/SolStaking/GetBnsolRateHistory"] = global::Binance.Staking.Examples.RestApi.SolStaking.GetBnsolRateHistory.Main,
        ["RestApi/SolStaking/GetBnsolRewardsHistory"] = global::Binance.Staking.Examples.RestApi.SolStaking.GetBnsolRewardsHistory.Main,
        ["RestApi/SolStaking/GetBoostRewardsHistory"] = global::Binance.Staking.Examples.RestApi.SolStaking.GetBoostRewardsHistory.Main,
        ["RestApi/SolStaking/GetSolRedemptionHistory"] = global::Binance.Staking.Examples.RestApi.SolStaking.GetSolRedemptionHistory.Main,
        ["RestApi/SolStaking/GetSolStakingHistory"] = global::Binance.Staking.Examples.RestApi.SolStaking.GetSolStakingHistory.Main,
        ["RestApi/SolStaking/GetSolStakingQuotaDetails"] = global::Binance.Staking.Examples.RestApi.SolStaking.GetSolStakingQuotaDetails.Main,
        ["RestApi/SolStaking/GetUnclaimedRewards"] = global::Binance.Staking.Examples.RestApi.SolStaking.GetUnclaimedRewards.Main,
        ["RestApi/SolStaking/RedeemSol"] = global::Binance.Staking.Examples.RestApi.SolStaking.RedeemSol.Main,
        ["RestApi/SolStaking/SolStakingAccount"] = global::Binance.Staking.Examples.RestApi.SolStaking.SolStakingAccount.Main,
        ["RestApi/SolStaking/SubscribeSolStaking"] = global::Binance.Staking.Examples.RestApi.SolStaking.SubscribeSolStaking.Main,
    };

    public static async Task<int> Main(string[] args)
    {
        if (args.Length == 1 && Examples.TryGetValue(args[0].Replace('\\', '/'), out var run))
        {
            await run();
            return 0;
        }

        Console.Error.WriteLine("Usage: dotnet run --project examples/Binance.Staking.Examples -- <example>");
        Console.Error.WriteLine("Examples:");
        foreach (var name in Examples.Keys.Order(StringComparer.OrdinalIgnoreCase))
            Console.Error.WriteLine("  " + name);
        return args.Length == 0 ? 0 : 1;
    }
}
