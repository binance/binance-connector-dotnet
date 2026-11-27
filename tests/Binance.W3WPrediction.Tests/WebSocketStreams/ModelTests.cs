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
using Binance.W3WPrediction.WebSocketStreams;

namespace Binance.W3WPrediction.Tests.WebSocketStreams;

/// <summary>Decodes an instance of every model, built from its schema, with the serializer context of the module.</summary>
public class ModelTests
{
    private static readonly JsonSerializerOptions Reflection = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };

    public static TheoryData<string, string> Cases => new()
    {
        { "BatchClaimPartiallySucceededResponse", "{\"pushId\":\"pm_CLAIM_BATCH_20260528003_pm_claim_partial_success_e1f2a3b4\"}" },
        { "FundTransferFailedResponse", "{\"pushId\":\"pm_TRANSFER_20260528002_pm_transfer_fail_a3b4c5d6\",\"amount\":\"100.00\"}" },
        { "FundTransferSucceededResponse", "{\"pushId\":\"pm_TRANSFER_20260528001_pm_transfer_success_f2a3b4c5\",\"amount\":\"100.00\"}" },
        { "LimitOrderFullyFilledResponse", "{\"pushId\":\"pm_PM2026052812347_pm_limit_order_filled_a7b8c9d0\",\"amount\":\"100.00\",\"topic\":\"BTC will hi..\"}" },
        { "LimitOrderPartiallyFilledResponse", "{\"pushId\":\"pm_PM2026052812347_pm_limit_order_partial_fill_b8c9d0e1\",\"amount\":\"30.00\",\"topic\":\"BTC will hi..\"}" },
        { "LimitOrderSubmissionFailedResponse", "{\"pushId\":\"pm_PM2026052812347_pm_limit_submit_fail_f6a7b8c9\",\"topic\":\"BTC will hi..\"}" },
        { "LimitOrderSubmittedSuccessfullyResponse", "{\"pushId\":\"pm_PM2026052812347_pm_limit_submit_success_e5f6a7b8\",\"amount\":\"100.00\",\"topic\":\"BTC will hi..\"}" },
        { "MarketBuyOrderFailedResponse", "{\"pushId\":\"pm_PM2026052812345_pm_market_buy_fail_b2c3d4e5\",\"amount\":\"12.34\",\"topic\":\"BTC will hi..\"}" },
        { "MarketBuyOrderFullyFilledResponse", "{\"pushId\":\"pm_PM2026052812345_pm_market_buy_success_a1b2c3d4\",\"amount\":\"12.34\",\"topic\":\"BTC will hi..\"}" },
        { "MarketResolutionNotificationResponse", "{\"pushId\":\"pm_8859231_pm_market_close_b4c5d6e7\",\"topic\":\"BTC will hi..\"}" },
        { "MarketSellOrderFailedExpiredResponse", "{\"pushId\":\"pm_PM2026052812346_pm_market_sell_fail_d4e5f6a7\",\"amount\":\"10.50\",\"topic\":\"ETH price..\"}" },
        { "MarketSellOrderFullyFilledResponse", "{\"pushId\":\"pm_PM2026052812346_pm_market_sell_success_c3d4e5f6\",\"amount\":\"10.50\",\"topic\":\"ETH price..\"}" },
        { "PredictionOrderBookByMarketIdResponse", "{\"msgType\":\"orderbook\",\"marketId\":8859231,\"updateTimestampMs\":1717420800123,\"asks\":[[1]],\"bids\":[[1]]}" },
        { "RewardClaimFailedResponse", "{\"pushId\":\"pm_CLAIM_BATCH_20260528002_pm_claim_fail_d0e1f2a3\",\"amount\":\"10.00\",\"outcome\":\"Yes\"}" },
        { "RewardClaimSucceededResponse", "{\"pushId\":\"pm_CLAIM_BATCH_20260528001_pm_claim_success_c9d0e1f2\",\"amount\":\"50.00\"}" },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void DecodesAndRoundTrips(string name, string json)
    {
        var assembly = typeof(W3WPredictionWebSocketStreams).Assembly;
        var type = assembly.GetType($"Binance.W3WPrediction.WebSocketStreams.{name.Split('/')[0]}", throwOnError: true)!;
        var context = (JsonSerializerContext)assembly.GetType("Binance.W3WPrediction.WebSocketStreams.W3WPredictionWebSocketStreamsJson")!.GetProperty("Default")!.GetValue(null)!;
        // A model that no operation returns is not in the serializer context, so it is decoded by reflection.
        var info = context.GetTypeInfo(type);
        var model = info is null ? JsonSerializer.Deserialize(json, type, Reflection) : JsonSerializer.Deserialize(json, info);
        ExampleAssert.Matches(json, model);
    }
}
