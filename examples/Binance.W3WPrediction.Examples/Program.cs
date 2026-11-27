//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

namespace Binance.W3WPrediction.Examples;

internal static class Program
{
    private static readonly Dictionary<string, Func<Task>> Examples = new(StringComparer.OrdinalIgnoreCase)
    {
        ["RestApi/MarketData/GetMarketDetail"] = global::Binance.W3WPrediction.Examples.RestApi.MarketData.GetMarketDetail.Main,
        ["RestApi/MarketData/ListPredictionCategories"] = global::Binance.W3WPrediction.Examples.RestApi.MarketData.ListPredictionCategories.Main,
        ["RestApi/MarketData/ListPredictionMarkets"] = global::Binance.W3WPrediction.Examples.RestApi.MarketData.ListPredictionMarkets.Main,
        ["RestApi/MarketData/MarketSearch"] = global::Binance.W3WPrediction.Examples.RestApi.MarketData.MarketSearch.Main,
        ["RestApi/MarketData/QueryLastTradePrice"] = global::Binance.W3WPrediction.Examples.RestApi.MarketData.QueryLastTradePrice.Main,
        ["RestApi/MarketData/QueryOrderBook"] = global::Binance.W3WPrediction.Examples.RestApi.MarketData.QueryOrderBook.Main,
        ["RestApi/Otc/CreateOtcBlocktrade"] = global::Binance.W3WPrediction.Examples.RestApi.Otc.CreateOtcBlocktrade.Main,
        ["RestApi/Otc/FulfilOtcBlocktrade"] = global::Binance.W3WPrediction.Examples.RestApi.Otc.FulfilOtcBlocktrade.Main,
        ["RestApi/Otc/GetOtcBlocktradeDetail"] = global::Binance.W3WPrediction.Examples.RestApi.Otc.GetOtcBlocktradeDetail.Main,
        ["RestApi/Otc/GetOtcBlocktradeEvents"] = global::Binance.W3WPrediction.Examples.RestApi.Otc.GetOtcBlocktradeEvents.Main,
        ["RestApi/Otc/GetOtcReservedBalances"] = global::Binance.W3WPrediction.Examples.RestApi.Otc.GetOtcReservedBalances.Main,
        ["RestApi/Otc/ListOtcBlocktrades"] = global::Binance.W3WPrediction.Examples.RestApi.Otc.ListOtcBlocktrades.Main,
        ["RestApi/Otc/PreviewOtcBlocktrade"] = global::Binance.W3WPrediction.Examples.RestApi.Otc.PreviewOtcBlocktrade.Main,
        ["RestApi/Otc/RemoveOtcBlocktrades"] = global::Binance.W3WPrediction.Examples.RestApi.Otc.RemoveOtcBlocktrades.Main,
        ["RestApi/Position/GetPositionByToken"] = global::Binance.W3WPrediction.Examples.RestApi.Position.GetPositionByToken.Main,
        ["RestApi/Position/QueryPnL"] = global::Binance.W3WPrediction.Examples.RestApi.Position.QueryPnL.Main,
        ["RestApi/Position/QueryPositions"] = global::Binance.W3WPrediction.Examples.RestApi.Position.QueryPositions.Main,
        ["RestApi/Position/QueryPositionsByFilter"] = global::Binance.W3WPrediction.Examples.RestApi.Position.QueryPositionsByFilter.Main,
        ["RestApi/Position/QuerySettledPositionHistory"] = global::Binance.W3WPrediction.Examples.RestApi.Position.QuerySettledPositionHistory.Main,
        ["RestApi/Redeem/BatchRedeem"] = global::Binance.W3WPrediction.Examples.RestApi.Redeem.BatchRedeem.Main,
        ["RestApi/Redeem/GetRedeemStatus"] = global::Binance.W3WPrediction.Examples.RestApi.Redeem.GetRedeemStatus.Main,
        ["RestApi/Trade/BatchCancelOrders"] = global::Binance.W3WPrediction.Examples.RestApi.Trade.BatchCancelOrders.Main,
        ["RestApi/Trade/GetQuote"] = global::Binance.W3WPrediction.Examples.RestApi.Trade.GetQuote.Main,
        ["RestApi/Trade/PlaceOrder"] = global::Binance.W3WPrediction.Examples.RestApi.Trade.PlaceOrder.Main,
        ["RestApi/Trade/QueryActiveOrders"] = global::Binance.W3WPrediction.Examples.RestApi.Trade.QueryActiveOrders.Main,
        ["RestApi/Trade/QueryOrderHistory"] = global::Binance.W3WPrediction.Examples.RestApi.Trade.QueryOrderHistory.Main,
        ["RestApi/Transfer/ApplyMmDeposit"] = global::Binance.W3WPrediction.Examples.RestApi.Transfer.ApplyMmDeposit.Main,
        ["RestApi/Transfer/ApplyMmWithdraw"] = global::Binance.W3WPrediction.Examples.RestApi.Transfer.ApplyMmWithdraw.Main,
        ["RestApi/Transfer/CreateInboundTransfer"] = global::Binance.W3WPrediction.Examples.RestApi.Transfer.CreateInboundTransfer.Main,
        ["RestApi/Transfer/CreateOutboundTransfer"] = global::Binance.W3WPrediction.Examples.RestApi.Transfer.CreateOutboundTransfer.Main,
        ["RestApi/Transfer/QueryTransferList"] = global::Binance.W3WPrediction.Examples.RestApi.Transfer.QueryTransferList.Main,
        ["RestApi/Transfer/QueryTransferStatus"] = global::Binance.W3WPrediction.Examples.RestApi.Transfer.QueryTransferStatus.Main,
        ["RestApi/Wallet/GetPortfolio"] = global::Binance.W3WPrediction.Examples.RestApi.Wallet.GetPortfolio.Main,
        ["RestApi/Wallet/GetQuotaStatus"] = global::Binance.W3WPrediction.Examples.RestApi.Wallet.GetQuotaStatus.Main,
        ["RestApi/Wallet/ListPredictionWallets"] = global::Binance.W3WPrediction.Examples.RestApi.Wallet.ListPredictionWallets.Main,
        ["RestApi/Wallet/QueryPaymentOptionBalances"] = global::Binance.W3WPrediction.Examples.RestApi.Wallet.QueryPaymentOptionBalances.Main,
        ["WebSocketStreams/BatchClaimPartiallySucceeded"] = global::Binance.W3WPrediction.Examples.WebSocketStreams.BatchClaimPartiallySucceeded.Main,
        ["WebSocketStreams/FundTransferFailed"] = global::Binance.W3WPrediction.Examples.WebSocketStreams.FundTransferFailed.Main,
        ["WebSocketStreams/FundTransferSucceeded"] = global::Binance.W3WPrediction.Examples.WebSocketStreams.FundTransferSucceeded.Main,
        ["WebSocketStreams/LimitOrderFullyFilled"] = global::Binance.W3WPrediction.Examples.WebSocketStreams.LimitOrderFullyFilled.Main,
        ["WebSocketStreams/LimitOrderPartiallyFilled"] = global::Binance.W3WPrediction.Examples.WebSocketStreams.LimitOrderPartiallyFilled.Main,
        ["WebSocketStreams/LimitOrderSubmissionFailed"] = global::Binance.W3WPrediction.Examples.WebSocketStreams.LimitOrderSubmissionFailed.Main,
        ["WebSocketStreams/LimitOrderSubmittedSuccessfully"] = global::Binance.W3WPrediction.Examples.WebSocketStreams.LimitOrderSubmittedSuccessfully.Main,
        ["WebSocketStreams/MarketBuyOrderFailed"] = global::Binance.W3WPrediction.Examples.WebSocketStreams.MarketBuyOrderFailed.Main,
        ["WebSocketStreams/MarketBuyOrderFullyFilled"] = global::Binance.W3WPrediction.Examples.WebSocketStreams.MarketBuyOrderFullyFilled.Main,
        ["WebSocketStreams/MarketResolutionNotification"] = global::Binance.W3WPrediction.Examples.WebSocketStreams.MarketResolutionNotification.Main,
        ["WebSocketStreams/MarketSellOrderFailedExpired"] = global::Binance.W3WPrediction.Examples.WebSocketStreams.MarketSellOrderFailedExpired.Main,
        ["WebSocketStreams/MarketSellOrderFullyFilled"] = global::Binance.W3WPrediction.Examples.WebSocketStreams.MarketSellOrderFullyFilled.Main,
        ["WebSocketStreams/PredictionOrderBookByMarketId"] = global::Binance.W3WPrediction.Examples.WebSocketStreams.PredictionOrderBookByMarketId.Main,
        ["WebSocketStreams/RewardClaimFailed"] = global::Binance.W3WPrediction.Examples.WebSocketStreams.RewardClaimFailed.Main,
        ["WebSocketStreams/RewardClaimSucceeded"] = global::Binance.W3WPrediction.Examples.WebSocketStreams.RewardClaimSucceeded.Main,
    };

    public static async Task<int> Main(string[] args)
    {
        if (args.Length == 1 && Examples.TryGetValue(args[0].Replace('\\', '/'), out var run))
        {
            await run();
            return 0;
        }

        Console.Error.WriteLine("Usage: dotnet run --project examples/Binance.W3WPrediction.Examples -- <example>");
        Console.Error.WriteLine("Examples:");
        foreach (var name in Examples.Keys.Order(StringComparer.OrdinalIgnoreCase))
            Console.Error.WriteLine("  " + name);
        return args.Length == 0 ? 0 : 1;
    }
}
