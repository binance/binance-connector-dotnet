//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.W3WPrediction.WebSocketStreams;

namespace Binance.W3WPrediction.Tests.WebSocketStreams;

[Trait("Category", "Native")]
public class DefaultApiTests
{
    [Fact]
    public async Task BatchClaimPartiallySucceeded()
    {
        const string example = """""{"pushId":"pm_CLAIM_BATCH_20260528003_pm_claim_partial_success_e1f2a3b4"}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes) { Signed = true };
        await using var client = await new W3WPredictionWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        using var subscription = client.BatchClaimPartiallySucceeded();

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("web3_prediction_pm_claim_partial_success", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task FundTransferFailed()
    {
        const string example = """""{"pushId":"pm_TRANSFER_20260528002_pm_transfer_fail_a3b4c5d6","amount":"100.00"}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes) { Signed = true };
        await using var client = await new W3WPredictionWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        using var subscription = client.FundTransferFailed();

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("web3_prediction_pm_transfer_fail", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task FundTransferSucceeded()
    {
        const string example = """""{"pushId":"pm_TRANSFER_20260528001_pm_transfer_success_f2a3b4c5","amount":"100.00"}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes) { Signed = true };
        await using var client = await new W3WPredictionWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        using var subscription = client.FundTransferSucceeded();

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("web3_prediction_pm_transfer_success", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task LimitOrderFullyFilled()
    {
        const string example = """""{"pushId":"pm_PM2026052812347_pm_limit_order_filled_a7b8c9d0","amount":"100.00","topic":"BTC will hi.."}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes) { Signed = true };
        await using var client = await new W3WPredictionWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        using var subscription = client.LimitOrderFullyFilled();

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("web3_prediction_pm_limit_order_filled", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task LimitOrderPartiallyFilled()
    {
        const string example = """""{"pushId":"pm_PM2026052812347_pm_limit_order_partial_fill_b8c9d0e1","amount":"30.00","topic":"BTC will hi.."}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes) { Signed = true };
        await using var client = await new W3WPredictionWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        using var subscription = client.LimitOrderPartiallyFilled();

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("web3_prediction_pm_limit_order_partial_fill", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task LimitOrderSubmissionFailed()
    {
        const string example = """""{"pushId":"pm_PM2026052812347_pm_limit_submit_fail_f6a7b8c9","topic":"BTC will hi.."}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes) { Signed = true };
        await using var client = await new W3WPredictionWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        using var subscription = client.LimitOrderSubmissionFailed();

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("web3_prediction_pm_limit_submit_fail", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task LimitOrderSubmittedSuccessfully()
    {
        const string example = """""{"pushId":"pm_PM2026052812347_pm_limit_submit_success_e5f6a7b8","amount":"100.00","topic":"BTC will hi.."}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes) { Signed = true };
        await using var client = await new W3WPredictionWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        using var subscription = client.LimitOrderSubmittedSuccessfully();

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("web3_prediction_pm_limit_submit_success", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task MarketBuyOrderFailed()
    {
        const string example = """""{"pushId":"pm_PM2026052812345_pm_market_buy_fail_b2c3d4e5","amount":"12.34","topic":"BTC will hi.."}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes) { Signed = true };
        await using var client = await new W3WPredictionWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        using var subscription = client.MarketBuyOrderFailed();

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("web3_prediction_pm_market_buy_fail", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task MarketBuyOrderFullyFilled()
    {
        const string example = """""{"pushId":"pm_PM2026052812345_pm_market_buy_success_a1b2c3d4","amount":"12.34","topic":"BTC will hi.."}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes) { Signed = true };
        await using var client = await new W3WPredictionWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        using var subscription = client.MarketBuyOrderFullyFilled();

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("web3_prediction_pm_market_buy_success", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task MarketResolutionNotification()
    {
        const string example = """""{"pushId":"pm_8859231_pm_market_close_b4c5d6e7","topic":"BTC will hi.."}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes) { Signed = true };
        await using var client = await new W3WPredictionWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        using var subscription = client.MarketResolutionNotification();

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("web3_prediction_pm_market_close", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task MarketSellOrderFailedExpired()
    {
        const string example = """""{"pushId":"pm_PM2026052812346_pm_market_sell_fail_d4e5f6a7","amount":"10.50","topic":"ETH price.."}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes) { Signed = true };
        await using var client = await new W3WPredictionWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        using var subscription = client.MarketSellOrderFailedExpired();

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("web3_prediction_pm_market_sell_fail", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task MarketSellOrderFullyFilled()
    {
        const string example = """""{"pushId":"pm_PM2026052812346_pm_market_sell_success_c3d4e5f6","amount":"10.50","topic":"ETH price.."}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes) { Signed = true };
        await using var client = await new W3WPredictionWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        using var subscription = client.MarketSellOrderFullyFilled();

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("web3_prediction_pm_market_sell_success", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task PredictionOrderBookByMarketId()
    {
        const string example = """""{"msgType":"orderbook","marketId":8859231,"updateTimestampMs":1717420800123,"asks":[[0.32,500],[0.33,1200.5]],"bids":[[0.31,800],[0.3,2000]]}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes) { Signed = true };
        await using var client = await new W3WPredictionWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new PredictionOrderBookByMarketIdRequest
        {
            MarketId = "8859231",
        };

        using var subscription = client.PredictionOrderBookByMarketId(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("web3_prediction_orderbook_8859231", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task RewardClaimFailed()
    {
        const string example = """""{"pushId":"pm_CLAIM_BATCH_20260528002_pm_claim_fail_d0e1f2a3","amount":"10.00","outcome":"Yes"}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes) { Signed = true };
        await using var client = await new W3WPredictionWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        using var subscription = client.RewardClaimFailed();

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("web3_prediction_pm_claim_fail", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task RewardClaimSucceeded()
    {
        const string example = """""{"pushId":"pm_CLAIM_BATCH_20260528001_pm_claim_success_c9d0e1f2","amount":"50.00"}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes) { Signed = true };
        await using var client = await new W3WPredictionWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        using var subscription = client.RewardClaimSucceeded();

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("web3_prediction_pm_claim_success", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }
}
