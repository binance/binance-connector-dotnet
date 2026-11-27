//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

namespace Binance.Wallet.Examples;

internal static class Program
{
    private static readonly Dictionary<string, Func<Task>> Examples = new(StringComparer.OrdinalIgnoreCase)
    {
        ["RestApi/Account/AccountApiTradingStatus"] = global::Binance.Wallet.Examples.RestApi.Account.AccountApiTradingStatus.Main,
        ["RestApi/Account/AccountInfo"] = global::Binance.Wallet.Examples.RestApi.Account.AccountInfo.Main,
        ["RestApi/Account/AccountStatus"] = global::Binance.Wallet.Examples.RestApi.Account.AccountStatus.Main,
        ["RestApi/Account/DailyAccountSnapshot"] = global::Binance.Wallet.Examples.RestApi.Account.DailyAccountSnapshot.Main,
        ["RestApi/Account/DisableFastWithdrawSwitch"] = global::Binance.Wallet.Examples.RestApi.Account.DisableFastWithdrawSwitch.Main,
        ["RestApi/Account/EnableFastWithdrawSwitch"] = global::Binance.Wallet.Examples.RestApi.Account.EnableFastWithdrawSwitch.Main,
        ["RestApi/Account/GetApiKeyPermission"] = global::Binance.Wallet.Examples.RestApi.Account.GetApiKeyPermission.Main,
        ["RestApi/Asset/AssetDetail"] = global::Binance.Wallet.Examples.RestApi.Asset.AssetDetail.Main,
        ["RestApi/Asset/AssetDividendRecord"] = global::Binance.Wallet.Examples.RestApi.Asset.AssetDividendRecord.Main,
        ["RestApi/Asset/DustConvert"] = global::Binance.Wallet.Examples.RestApi.Asset.DustConvert.Main,
        ["RestApi/Asset/DustConvertibleAssets"] = global::Binance.Wallet.Examples.RestApi.Asset.DustConvertibleAssets.Main,
        ["RestApi/Asset/Dustlog"] = global::Binance.Wallet.Examples.RestApi.Asset.Dustlog.Main,
        ["RestApi/Asset/DustTransfer"] = global::Binance.Wallet.Examples.RestApi.Asset.DustTransfer.Main,
        ["RestApi/Asset/FundingWallet"] = global::Binance.Wallet.Examples.RestApi.Asset.FundingWallet.Main,
        ["RestApi/Asset/GetAssetsThatCanBeConvertedIntoBnb"] = global::Binance.Wallet.Examples.RestApi.Asset.GetAssetsThatCanBeConvertedIntoBnb.Main,
        ["RestApi/Asset/GetCloudMiningPaymentAndRefundHistory"] = global::Binance.Wallet.Examples.RestApi.Asset.GetCloudMiningPaymentAndRefundHistory.Main,
        ["RestApi/Asset/GetOpenSymbolList"] = global::Binance.Wallet.Examples.RestApi.Asset.GetOpenSymbolList.Main,
        ["RestApi/Asset/GetSpotAssetTags"] = global::Binance.Wallet.Examples.RestApi.Asset.GetSpotAssetTags.Main,
        ["RestApi/Asset/QueryUserDelegationHistory"] = global::Binance.Wallet.Examples.RestApi.Asset.QueryUserDelegationHistory.Main,
        ["RestApi/Asset/QueryUserUniversalTransferHistory"] = global::Binance.Wallet.Examples.RestApi.Asset.QueryUserUniversalTransferHistory.Main,
        ["RestApi/Asset/QueryUserWalletBalance"] = global::Binance.Wallet.Examples.RestApi.Asset.QueryUserWalletBalance.Main,
        ["RestApi/Asset/ToggleBnbBurnOnSpotTradeAndMarginInterest"] = global::Binance.Wallet.Examples.RestApi.Asset.ToggleBnbBurnOnSpotTradeAndMarginInterest.Main,
        ["RestApi/Asset/TradeFee"] = global::Binance.Wallet.Examples.RestApi.Asset.TradeFee.Main,
        ["RestApi/Asset/UserAsset"] = global::Binance.Wallet.Examples.RestApi.Asset.UserAsset.Main,
        ["RestApi/Asset/UserUniversalTransfer"] = global::Binance.Wallet.Examples.RestApi.Asset.UserUniversalTransfer.Main,
        ["RestApi/Capital/AllCoinsInformation"] = global::Binance.Wallet.Examples.RestApi.Capital.AllCoinsInformation.Main,
        ["RestApi/Capital/DepositAddress"] = global::Binance.Wallet.Examples.RestApi.Capital.DepositAddress.Main,
        ["RestApi/Capital/DepositHistory"] = global::Binance.Wallet.Examples.RestApi.Capital.DepositHistory.Main,
        ["RestApi/Capital/FetchDepositAddressListWithNetwork"] = global::Binance.Wallet.Examples.RestApi.Capital.FetchDepositAddressListWithNetwork.Main,
        ["RestApi/Capital/FetchWithdrawAddressList"] = global::Binance.Wallet.Examples.RestApi.Capital.FetchWithdrawAddressList.Main,
        ["RestApi/Capital/FetchWithdrawQuota"] = global::Binance.Wallet.Examples.RestApi.Capital.FetchWithdrawQuota.Main,
        ["RestApi/Capital/OneClickArrivalDepositApply"] = global::Binance.Wallet.Examples.RestApi.Capital.OneClickArrivalDepositApply.Main,
        ["RestApi/Capital/Withdraw"] = global::Binance.Wallet.Examples.RestApi.Capital.Withdraw.Main,
        ["RestApi/Capital/WithdrawHistory"] = global::Binance.Wallet.Examples.RestApi.Capital.WithdrawHistory.Main,
        ["RestApi/Others/GetSymbolsDelistScheduleForSpot"] = global::Binance.Wallet.Examples.RestApi.Others.GetSymbolsDelistScheduleForSpot.Main,
        ["RestApi/Others/SystemStatus"] = global::Binance.Wallet.Examples.RestApi.Others.SystemStatus.Main,
        ["RestApi/TravelRule/BrokerWithdraw"] = global::Binance.Wallet.Examples.RestApi.TravelRule.BrokerWithdraw.Main,
        ["RestApi/TravelRule/CheckQuestionnaireRequirements"] = global::Binance.Wallet.Examples.RestApi.TravelRule.CheckQuestionnaireRequirements.Main,
        ["RestApi/TravelRule/DepositHistoryTravelRule"] = global::Binance.Wallet.Examples.RestApi.TravelRule.DepositHistoryTravelRule.Main,
        ["RestApi/TravelRule/DepositHistoryV2"] = global::Binance.Wallet.Examples.RestApi.TravelRule.DepositHistoryV2.Main,
        ["RestApi/TravelRule/FetchAddressVerificationList"] = global::Binance.Wallet.Examples.RestApi.TravelRule.FetchAddressVerificationList.Main,
        ["RestApi/TravelRule/GetCountryList"] = global::Binance.Wallet.Examples.RestApi.TravelRule.GetCountryList.Main,
        ["RestApi/TravelRule/GetRegionList"] = global::Binance.Wallet.Examples.RestApi.TravelRule.GetRegionList.Main,
        ["RestApi/TravelRule/SubmitDepositQuestionnaire"] = global::Binance.Wallet.Examples.RestApi.TravelRule.SubmitDepositQuestionnaire.Main,
        ["RestApi/TravelRule/SubmitDepositQuestionnaireTravelRule"] = global::Binance.Wallet.Examples.RestApi.TravelRule.SubmitDepositQuestionnaireTravelRule.Main,
        ["RestApi/TravelRule/SubmitDepositQuestionnaireV2"] = global::Binance.Wallet.Examples.RestApi.TravelRule.SubmitDepositQuestionnaireV2.Main,
        ["RestApi/TravelRule/VaspList"] = global::Binance.Wallet.Examples.RestApi.TravelRule.VaspList.Main,
        ["RestApi/TravelRule/WithdrawHistoryV1"] = global::Binance.Wallet.Examples.RestApi.TravelRule.WithdrawHistoryV1.Main,
        ["RestApi/TravelRule/WithdrawHistoryV2"] = global::Binance.Wallet.Examples.RestApi.TravelRule.WithdrawHistoryV2.Main,
        ["RestApi/TravelRule/WithdrawTravelRule"] = global::Binance.Wallet.Examples.RestApi.TravelRule.WithdrawTravelRule.Main,
    };

    public static async Task<int> Main(string[] args)
    {
        if (args.Length == 1 && Examples.TryGetValue(args[0].Replace('\\', '/'), out var run))
        {
            await run();
            return 0;
        }

        Console.Error.WriteLine("Usage: dotnet run --project examples/Binance.Wallet.Examples -- <example>");
        Console.Error.WriteLine("Examples:");
        foreach (var name in Examples.Keys.Order(StringComparer.OrdinalIgnoreCase))
            Console.Error.WriteLine("  " + name);
        return args.Length == 0 ? 0 : 1;
    }
}
