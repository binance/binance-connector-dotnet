//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;
using Binance.Common.Tests;
using Binance.DerivativesTradingPortfolioMarginPro.RestApi;

namespace Binance.DerivativesTradingPortfolioMarginPro.Tests.RestApi;

/// <summary>Decodes an instance of every model, built from its schema, with the serializer context of the module.</summary>
public class ModelTests
{
    private static readonly JsonSerializerOptions Reflection = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };

    public static TheoryData<string, string> Cases => new()
    {
        { "BnbTransferResponse", "{\"tranId\":100000001}" },
        { "ChangeAutoRepayFuturesStatusResponse", "{\"msg\":\"success\"}" },
        { "DeleteMarginCallLevelResponse", "{\"msg\":\"success\"}" },
        { "FundAutoCollectionResponse", "{\"msg\":\"success\"}" },
        { "FundCollectionByAssetResponse", "{\"msg\":\"success\"}" },
        { "GetAutoRepayFuturesStatusResponse", "{\"autoRepay\":true}" },
        { "GetDeltaModeStatusResponse", "{\"deltaEnabled\":false}" },
        { "GetMarginCallLevelResponse", "{\"marginCallLevel\":\"1.67354637\"}" },
        { "GetPortfolioMarginAssetLeverageResponseInner", "{\"asset\":\"USDC\",\"leverage\":10}" },
        { "GetPortfolioMarginProAccountBalanceResponseInner", "{\"asset\":\"USDT\",\"totalWalletBalance\":\"122607.35137903\",\"crossMarginAsset\":\"92.27530794\",\"crossMarginBorrowed\":\"10.00000000\",\"crossMarginFree\":\"100.00000000\",\"crossMarginInterest\":\"0.72469206\",\"crossMarginLocked\":\"3.00000000\",\"umWalletBalance\":\"0.00000000\",\"umUnrealizedPNL\":\"23.72469206\",\"cmWalletBalance\":\"23.72469206\",\"cmUnrealizedPNL\":\"x\",\"updateTime\":1617939110373,\"negativeBalance\":\"0\",\"optionWalletBalance\":\"0\",\"optionEquity\":\"0\"}" },
        { "GetPortfolioMarginProAccountInfoResponse", "{\"uniMMR\":\"5167.92171923\",\"accountEquity\":\"122607.35137903\",\"actualEquity\":\"142607.35137903\",\"accountMaintMargin\":\"23.72469206\",\"accountInitialMargin\":\"47.44938412\",\"totalAvailableBalance\":\"122,559.90199491\",\"accountStatus\":\"NORMAL\",\"accountType\":\"PM_1\"}" },
        { "GetPortfolioMarginProSpanAccountInfoResponse", "{\"uniMMR\":\"5167.92171923\",\"accountEquity\":\"122607.35137903\",\"actualEquity\":\"142607.35137903\",\"accountMaintMargin\":\"23.72469206\",\"riskUnitMMList\":[{\"asset\":\"BTC\",\"uniMaintainUsd\":\"23.72469206\"}],\"marginMM\":\"0.00000000\",\"otherMM\":\"0.00000000\",\"accountStatus\":\"NORMAL\",\"accountType\":\"PM_3\"}" },
        { "GetPortfolioMarginProSpanAccountInfoResponseRiskUnitMMListInner", "{\"asset\":\"BTC\",\"uniMaintainUsd\":\"23.72469206\"}" },
        { "GetPortfolioMarginTieredCollateralRatesResponseInner", "{\"asset\":\"BNB\",\"collateralInfo\":[{\"tierFloor\":\"0.0000\",\"tierCap\":\"1000.0000\",\"collateralRate\":\"1.0000\",\"cum\":\"0.0000\"}]}" },
        { "GetPortfolioMarginTieredCollateralRatesResponseInnerCollateralInfoInner", "{\"tierFloor\":\"0.0000\",\"tierCap\":\"1000.0000\",\"collateralRate\":\"1.0000\",\"cum\":\"0.0000\"}" },
        { "GetTransferableEarnAssetBalanceForPortfolioMarginResponse", "{\"asset\":\"LDUSDT\",\"amount\":\"0.55\"}" },
        { "PortfolioMarginCollateralRateResponseInner", "{\"asset\":\"USDC\",\"collateralRate\":\"1.0000\"}" },
        { "PortfolioMarginProBankruptcyLoanRepayResponse", "{\"tranId\":\"58203331886213500\"}" },
        { "PortfolioMarginProTieredCollateralRateResponseInner", "{\"asset\":\"BNB\",\"collateralInfo\":[{\"tierFloor\":\"0.0000\",\"tierCap\":\"1000.0000\",\"collateralRate\":\"1.0000\",\"cum\":\"0.0000\"}]}" },
        { "PortfolioMarginProTieredCollateralRateResponseInnerCollateralInfoInner", "{\"tierFloor\":\"0.0000\",\"tierCap\":\"1000.0000\",\"collateralRate\":\"1.0000\",\"cum\":\"0.0000\"}" },
        { "QueryPortfolioMarginAssetIndexPriceResponseInner", "{\"asset\":\"BTC\",\"assetIndexPrice\":\"28251.9136906\",\"time\":1683518338121}" },
        { "QueryPortfolioMarginProBankruptcyLoanAmountResponse", "{\"asset\":\"BUSD\",\"amount\":\"579.45\"}" },
        { "QueryPortfolioMarginProBankruptcyLoanRepayHistoryResponse", "{\"total\":3,\"rows\":[{\"asset\":\"USDT\",\"amount\":\"404.80294503\",\"repayTime\":1731336427804}]}" },
        { "QueryPortfolioMarginProBankruptcyLoanRepayHistoryResponseRowsInner", "{\"asset\":\"USDT\",\"amount\":\"404.80294503\",\"repayTime\":1731336427804}" },
        { "QueryPortfolioMarginProNegativeBalanceInterestHistoryResponseInner", "{\"asset\":\"USDT\",\"interest\":\"24.4440\",\"interestAccruedTime\":1670227200000,\"interestRate\":\"0.0001164\",\"principal\":\"210000\"}" },
        { "RepayFuturesNegativeBalanceResponse", "{\"msg\":\"success\"}" },
        { "SetMarginCallLevelResponse", "{\"marginCallLevel\":\"1.67354637\"}" },
        { "SwitchDeltaModeResponse", "{\"msg\":\"success\"}" },
        { "TransferLdusdtRwusdForPortfolioMarginResponse", "{\"msg\":\"success\"}" },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void DecodesAndRoundTrips(string name, string json)
    {
        var assembly = typeof(DerivativesTradingPortfolioMarginProRestApi).Assembly;
        var type = assembly.GetType($"Binance.DerivativesTradingPortfolioMarginPro.RestApi.{name.Split('/')[0]}", throwOnError: true)!;
        var context = (JsonSerializerContext)assembly.GetType("Binance.DerivativesTradingPortfolioMarginPro.RestApi.DerivativesTradingPortfolioMarginProRestApiJson")!.GetProperty("Default")!.GetValue(null)!;
        // A model that no operation returns is not in the serializer context, so it is decoded by reflection.
        var info = context.GetTypeInfo(type);
        var model = info is null ? JsonSerializer.Deserialize(json, type, Reflection) : JsonSerializer.Deserialize(json, info);
        ExampleAssert.Matches(json, model);
    }
}
