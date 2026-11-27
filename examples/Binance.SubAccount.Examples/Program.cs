//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

namespace Binance.SubAccount.Examples;

internal static class Program
{
    private static readonly Dictionary<string, Func<Task>> Examples = new(StringComparer.OrdinalIgnoreCase)
    {
        ["RestApi/AccountManagement/CreateAVirtualSubAccount"] = global::Binance.SubAccount.Examples.RestApi.AccountManagement.CreateAVirtualSubAccount.Main,
        ["RestApi/AccountManagement/EnableFuturesForSubAccount"] = global::Binance.SubAccount.Examples.RestApi.AccountManagement.EnableFuturesForSubAccount.Main,
        ["RestApi/AccountManagement/EnableOptionsForSubAccount"] = global::Binance.SubAccount.Examples.RestApi.AccountManagement.EnableOptionsForSubAccount.Main,
        ["RestApi/AccountManagement/GetFuturesPositionRiskOfSubAccount"] = global::Binance.SubAccount.Examples.RestApi.AccountManagement.GetFuturesPositionRiskOfSubAccount.Main,
        ["RestApi/AccountManagement/GetFuturesPositionRiskOfSubAccountV2"] = global::Binance.SubAccount.Examples.RestApi.AccountManagement.GetFuturesPositionRiskOfSubAccountV2.Main,
        ["RestApi/AccountManagement/GetSubAccountsStatusOnMarginOrFutures"] = global::Binance.SubAccount.Examples.RestApi.AccountManagement.GetSubAccountsStatusOnMarginOrFutures.Main,
        ["RestApi/AccountManagement/QuerySubAccountList"] = global::Binance.SubAccount.Examples.RestApi.AccountManagement.QuerySubAccountList.Main,
        ["RestApi/AccountManagement/QuerySubAccountTransactionStatistics"] = global::Binance.SubAccount.Examples.RestApi.AccountManagement.QuerySubAccountTransactionStatistics.Main,
        ["RestApi/ApiManagement/AddIpRestrictionForSubAccountApiKey"] = global::Binance.SubAccount.Examples.RestApi.ApiManagement.AddIpRestrictionForSubAccountApiKey.Main,
        ["RestApi/ApiManagement/CreateSubAccountApiKey"] = global::Binance.SubAccount.Examples.RestApi.ApiManagement.CreateSubAccountApiKey.Main,
        ["RestApi/ApiManagement/CreateSubAccountApiKeyV2"] = global::Binance.SubAccount.Examples.RestApi.ApiManagement.CreateSubAccountApiKeyV2.Main,
        ["RestApi/ApiManagement/DeleteIpListForASubAccountApiKey"] = global::Binance.SubAccount.Examples.RestApi.ApiManagement.DeleteIpListForASubAccountApiKey.Main,
        ["RestApi/ApiManagement/DeleteSubAccountApiKey"] = global::Binance.SubAccount.Examples.RestApi.ApiManagement.DeleteSubAccountApiKey.Main,
        ["RestApi/ApiManagement/GetIpRestrictionForASubAccountApiKey"] = global::Binance.SubAccount.Examples.RestApi.ApiManagement.GetIpRestrictionForASubAccountApiKey.Main,
        ["RestApi/ApiManagement/ModifySubAccountApiKeyPermission"] = global::Binance.SubAccount.Examples.RestApi.ApiManagement.ModifySubAccountApiKeyPermission.Main,
        ["RestApi/ApiManagement/QuerySubAccountApiKey"] = global::Binance.SubAccount.Examples.RestApi.ApiManagement.QuerySubAccountApiKey.Main,
        ["RestApi/AssetManagement/FuturesTransferForSubAccount"] = global::Binance.SubAccount.Examples.RestApi.AssetManagement.FuturesTransferForSubAccount.Main,
        ["RestApi/AssetManagement/GetDetailOnSubAccountsFuturesAccount"] = global::Binance.SubAccount.Examples.RestApi.AssetManagement.GetDetailOnSubAccountsFuturesAccount.Main,
        ["RestApi/AssetManagement/GetDetailOnSubAccountsFuturesAccountV2"] = global::Binance.SubAccount.Examples.RestApi.AssetManagement.GetDetailOnSubAccountsFuturesAccountV2.Main,
        ["RestApi/AssetManagement/GetDetailOnSubAccountsMarginAccount"] = global::Binance.SubAccount.Examples.RestApi.AssetManagement.GetDetailOnSubAccountsMarginAccount.Main,
        ["RestApi/AssetManagement/GetMovePositionHistoryForSubAccount"] = global::Binance.SubAccount.Examples.RestApi.AssetManagement.GetMovePositionHistoryForSubAccount.Main,
        ["RestApi/AssetManagement/GetSubAccountDepositAddress"] = global::Binance.SubAccount.Examples.RestApi.AssetManagement.GetSubAccountDepositAddress.Main,
        ["RestApi/AssetManagement/GetSubAccountDepositHistory"] = global::Binance.SubAccount.Examples.RestApi.AssetManagement.GetSubAccountDepositHistory.Main,
        ["RestApi/AssetManagement/GetSummaryOfSubAccountsFuturesAccount"] = global::Binance.SubAccount.Examples.RestApi.AssetManagement.GetSummaryOfSubAccountsFuturesAccount.Main,
        ["RestApi/AssetManagement/GetSummaryOfSubAccountsFuturesAccountV2"] = global::Binance.SubAccount.Examples.RestApi.AssetManagement.GetSummaryOfSubAccountsFuturesAccountV2.Main,
        ["RestApi/AssetManagement/GetSummaryOfSubAccountsMarginAccount"] = global::Binance.SubAccount.Examples.RestApi.AssetManagement.GetSummaryOfSubAccountsMarginAccount.Main,
        ["RestApi/AssetManagement/MarginTransferForSubAccount"] = global::Binance.SubAccount.Examples.RestApi.AssetManagement.MarginTransferForSubAccount.Main,
        ["RestApi/AssetManagement/MovePositionForSubAccount"] = global::Binance.SubAccount.Examples.RestApi.AssetManagement.MovePositionForSubAccount.Main,
        ["RestApi/AssetManagement/QuerySubAccountAssets"] = global::Binance.SubAccount.Examples.RestApi.AssetManagement.QuerySubAccountAssets.Main,
        ["RestApi/AssetManagement/QuerySubAccountAssetsAssetManagement"] = global::Binance.SubAccount.Examples.RestApi.AssetManagement.QuerySubAccountAssetsAssetManagement.Main,
        ["RestApi/AssetManagement/QuerySubAccountFuturesAssetTransferHistory"] = global::Binance.SubAccount.Examples.RestApi.AssetManagement.QuerySubAccountFuturesAssetTransferHistory.Main,
        ["RestApi/AssetManagement/QuerySubAccountSpotAssetsSummary"] = global::Binance.SubAccount.Examples.RestApi.AssetManagement.QuerySubAccountSpotAssetsSummary.Main,
        ["RestApi/AssetManagement/QuerySubAccountSpotAssetTransferHistory"] = global::Binance.SubAccount.Examples.RestApi.AssetManagement.QuerySubAccountSpotAssetTransferHistory.Main,
        ["RestApi/AssetManagement/QueryUniversalTransferHistory"] = global::Binance.SubAccount.Examples.RestApi.AssetManagement.QueryUniversalTransferHistory.Main,
        ["RestApi/AssetManagement/SubAccountFuturesAssetTransfer"] = global::Binance.SubAccount.Examples.RestApi.AssetManagement.SubAccountFuturesAssetTransfer.Main,
        ["RestApi/AssetManagement/SubAccountTransferHistory"] = global::Binance.SubAccount.Examples.RestApi.AssetManagement.SubAccountTransferHistory.Main,
        ["RestApi/AssetManagement/TransferToMaster"] = global::Binance.SubAccount.Examples.RestApi.AssetManagement.TransferToMaster.Main,
        ["RestApi/AssetManagement/TransferToSubAccountOfSameMaster"] = global::Binance.SubAccount.Examples.RestApi.AssetManagement.TransferToSubAccountOfSameMaster.Main,
        ["RestApi/AssetManagement/UniversalTransfer"] = global::Binance.SubAccount.Examples.RestApi.AssetManagement.UniversalTransfer.Main,
        ["RestApi/ManagedSubAccount/DepositAssetsIntoTheManagedSubAccount"] = global::Binance.SubAccount.Examples.RestApi.ManagedSubAccount.DepositAssetsIntoTheManagedSubAccount.Main,
        ["RestApi/ManagedSubAccount/GetManagedSubAccountDepositAddress"] = global::Binance.SubAccount.Examples.RestApi.ManagedSubAccount.GetManagedSubAccountDepositAddress.Main,
        ["RestApi/ManagedSubAccount/QueryManagedSubAccountAssetDetails"] = global::Binance.SubAccount.Examples.RestApi.ManagedSubAccount.QueryManagedSubAccountAssetDetails.Main,
        ["RestApi/ManagedSubAccount/QueryManagedSubAccountFuturesAssetDetails"] = global::Binance.SubAccount.Examples.RestApi.ManagedSubAccount.QueryManagedSubAccountFuturesAssetDetails.Main,
        ["RestApi/ManagedSubAccount/QueryManagedSubAccountList"] = global::Binance.SubAccount.Examples.RestApi.ManagedSubAccount.QueryManagedSubAccountList.Main,
        ["RestApi/ManagedSubAccount/QueryManagedSubAccountMarginAssetDetails"] = global::Binance.SubAccount.Examples.RestApi.ManagedSubAccount.QueryManagedSubAccountMarginAssetDetails.Main,
        ["RestApi/ManagedSubAccount/QueryManagedSubAccountSnapshot"] = global::Binance.SubAccount.Examples.RestApi.ManagedSubAccount.QueryManagedSubAccountSnapshot.Main,
        ["RestApi/ManagedSubAccount/QueryManagedSubAccountTransferLogMasterAccountInvestor"] = global::Binance.SubAccount.Examples.RestApi.ManagedSubAccount.QueryManagedSubAccountTransferLogMasterAccountInvestor.Main,
        ["RestApi/ManagedSubAccount/QueryManagedSubAccountTransferLogMasterAccountTrading"] = global::Binance.SubAccount.Examples.RestApi.ManagedSubAccount.QueryManagedSubAccountTransferLogMasterAccountTrading.Main,
        ["RestApi/ManagedSubAccount/QueryManagedSubAccountTransferLogSubAccountTrading"] = global::Binance.SubAccount.Examples.RestApi.ManagedSubAccount.QueryManagedSubAccountTransferLogSubAccountTrading.Main,
        ["RestApi/ManagedSubAccount/WithdrawlAssetsFromTheManagedSubAccount"] = global::Binance.SubAccount.Examples.RestApi.ManagedSubAccount.WithdrawlAssetsFromTheManagedSubAccount.Main,
    };

    public static async Task<int> Main(string[] args)
    {
        if (args.Length == 1 && Examples.TryGetValue(args[0].Replace('\\', '/'), out var run))
        {
            await run();
            return 0;
        }

        Console.Error.WriteLine("Usage: dotnet run --project examples/Binance.SubAccount.Examples -- <example>");
        Console.Error.WriteLine("Examples:");
        foreach (var name in Examples.Keys.Order(StringComparer.OrdinalIgnoreCase))
            Console.Error.WriteLine("  " + name);
        return args.Length == 0 ? 0 : 1;
    }
}
