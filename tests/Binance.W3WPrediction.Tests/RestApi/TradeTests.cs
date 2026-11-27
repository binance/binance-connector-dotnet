//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.W3WPrediction.RestApi;

namespace Binance.W3WPrediction.Tests.RestApi.Trade;

[Trait("Category", "Native")]
public class TradeApiTests
{
    private static W3WPredictionRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task BatchCancelOrdersAsync()
    {
        const string example = """""{"canceled":["54124"],"failed":[{"orderId":"54126","reason":"ORDER_NOT_FOUND"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new BatchCancelOrdersRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            WalletId = "5b5c1ec3be4e4416a5872b21c1ca5d20",
        };

        var response = await client.BatchCancelOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/trade/batch-cancel", seen.Path);
        Assert.Equal("0x12e32db8817e292508c34111cbc4b23340df542c", seen.Param("walletAddress"));
        Assert.Equal("5b5c1ec3be4e4416a5872b21c1ca5d20", seen.Param("walletId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task BatchCancelOrdersWithOptionalParametersAsync()
    {
        const string example = """""{"canceled":["54124"],"failed":[{"orderId":"54126","reason":"ORDER_NOT_FOUND"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new BatchCancelOrdersRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            WalletId = "5b5c1ec3be4e4416a5872b21c1ca5d20",
            CancelInfoList = new() { },
        };

        var response = await client.BatchCancelOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/trade/batch-cancel", seen.Path);
        Assert.Equal("0x12e32db8817e292508c34111cbc4b23340df542c", seen.Param("walletAddress"));
        Assert.Equal("5b5c1ec3be4e4416a5872b21c1ca5d20", seen.Param("walletId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task BatchCancelOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new BatchCancelOrdersRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            WalletId = "5b5c1ec3be4e4416a5872b21c1ca5d20",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.BatchCancelOrdersAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetQuoteAsync()
    {
        const string example = """""{"quoteId":"q_20260525_abc123xyz","tokenId":"112233","chance":"0.52","vendor":"PREDICT_FUN","marketTitle":"UP","marketExtId":"ext_001","side":"BUY","amountIn":"1000000000000000000","amountOut":"1923070000000000000","isMinAmountOut":false,"feeAmount":"20000000000000000","feeDiscountBps":"0","averagePrice":0.52,"lastPrice":0.52,"priceImpact":0.001,"timestamp":1748131500000,"chainId":"56","userId":100103755893,"walletAddress":"0x12e32db8817e292508c34111cbc4b23340df542c","orderType":"MARKET","slippageBps":1200,"feeRateBps":200,"minReceive":"1900000000000000000","expireAt":1748131800000,"priceLimit":"priceLimit"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetQuoteRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            TokenId = "112233",
            Side = GetQuoteSide.Buy,
            AmountIn = "1000000000000000000",
            OrderType = GetQuoteOrderType.Market,
            SlippageBps = 1200L,
        };

        var response = await client.GetQuoteAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/trade/get-quote", seen.Path);
        Assert.Equal("0x12e32db8817e292508c34111cbc4b23340df542c", seen.Param("walletAddress"));
        Assert.Equal("112233", seen.Param("tokenId"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("1000000000000000000", seen.Param("amountIn"));
        Assert.Equal("MARKET", seen.Param("orderType"));
        Assert.Equal("1200", seen.Param("slippageBps"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetQuoteWithOptionalParametersAsync()
    {
        const string example = """""{"quoteId":"q_20260525_abc123xyz","tokenId":"112233","chance":"0.52","vendor":"PREDICT_FUN","marketTitle":"UP","marketExtId":"ext_001","side":"BUY","amountIn":"1000000000000000000","amountOut":"1923070000000000000","isMinAmountOut":false,"feeAmount":"20000000000000000","feeDiscountBps":"0","averagePrice":0.52,"lastPrice":0.52,"priceImpact":0.001,"timestamp":1748131500000,"chainId":"56","userId":100103755893,"walletAddress":"0x12e32db8817e292508c34111cbc4b23340df542c","orderType":"MARKET","slippageBps":1200,"feeRateBps":200,"minReceive":"1900000000000000000","expireAt":1748131800000,"priceLimit":"priceLimit"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetQuoteRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            TokenId = "112233",
            Side = GetQuoteSide.Buy,
            AmountIn = "1000000000000000000",
            OrderType = GetQuoteOrderType.Market,
            SlippageBps = 1200L,
            PriceLimit = "0.5",
            ChainId = "56",
            FeeRateBps = 200L,
            FundingSource = GetQuoteFundingSource.Mpc,
            FundTransferAmount = "1000000000000000000",
        };

        var response = await client.GetQuoteAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/trade/get-quote", seen.Path);
        Assert.Equal("0x12e32db8817e292508c34111cbc4b23340df542c", seen.Param("walletAddress"));
        Assert.Equal("112233", seen.Param("tokenId"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("1000000000000000000", seen.Param("amountIn"));
        Assert.Equal("MARKET", seen.Param("orderType"));
        Assert.Equal("1200", seen.Param("slippageBps"));
        Assert.Equal("0.5", seen.Param("priceLimit"));
        Assert.Equal("56", seen.Param("chainId"));
        Assert.Equal("200", seen.Param("feeRateBps"));
        Assert.Equal("MPC", seen.Param("fundingSource"));
        Assert.Equal("1000000000000000000", seen.Param("fundTransferAmount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetQuoteBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetQuoteRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            TokenId = "112233",
            Side = GetQuoteSide.Buy,
            AmountIn = "1000000000000000000",
            OrderType = GetQuoteOrderType.Market,
            SlippageBps = 1200L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetQuoteAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task PlaceOrderAsync()
    {
        const string example = """""{"orderId":"54124"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new PlaceOrderRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            WalletId = "5b5c1ec3be4e4416a5872b21c1ca5d20",
            QuoteId = "q_20260525_abc123xyz",
            TimeInForce = "FOK",
            AccountType = PlaceOrderAccountType.Spot,
            OrderType = PlaceOrderOrderType.Market,
            SlippageBps = 1200L,
        };

        var response = await client.PlaceOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/trade/place-order-bundle", seen.Path);
        Assert.Equal("0x12e32db8817e292508c34111cbc4b23340df542c", seen.Param("walletAddress"));
        Assert.Equal("5b5c1ec3be4e4416a5872b21c1ca5d20", seen.Param("walletId"));
        Assert.Equal("q_20260525_abc123xyz", seen.Param("quoteId"));
        Assert.Equal("FOK", seen.Param("timeInForce"));
        Assert.Equal("SPOT", seen.Param("accountType"));
        Assert.Equal("MARKET", seen.Param("orderType"));
        Assert.Equal("1200", seen.Param("slippageBps"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task PlaceOrderWithOptionalParametersAsync()
    {
        const string example = """""{"orderId":"54124"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new PlaceOrderRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            WalletId = "5b5c1ec3be4e4416a5872b21c1ca5d20",
            QuoteId = "q_20260525_abc123xyz",
            TimeInForce = "FOK",
            AccountType = PlaceOrderAccountType.Spot,
            OrderType = PlaceOrderOrderType.Market,
            SlippageBps = 1200L,
            PriceLimit = "0.5",
            FundingSource = PlaceOrderFundingSource.Mpc,
            FundTransferAmount = "1000000000000000000",
        };

        var response = await client.PlaceOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/trade/place-order-bundle", seen.Path);
        Assert.Equal("0x12e32db8817e292508c34111cbc4b23340df542c", seen.Param("walletAddress"));
        Assert.Equal("5b5c1ec3be4e4416a5872b21c1ca5d20", seen.Param("walletId"));
        Assert.Equal("q_20260525_abc123xyz", seen.Param("quoteId"));
        Assert.Equal("FOK", seen.Param("timeInForce"));
        Assert.Equal("SPOT", seen.Param("accountType"));
        Assert.Equal("MARKET", seen.Param("orderType"));
        Assert.Equal("1200", seen.Param("slippageBps"));
        Assert.Equal("0.5", seen.Param("priceLimit"));
        Assert.Equal("MPC", seen.Param("fundingSource"));
        Assert.Equal("1000000000000000000", seen.Param("fundTransferAmount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task PlaceOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new PlaceOrderRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            WalletId = "5b5c1ec3be4e4416a5872b21c1ca5d20",
            QuoteId = "q_20260525_abc123xyz",
            TimeInForce = "FOK",
            AccountType = PlaceOrderAccountType.Spot,
            OrderType = PlaceOrderOrderType.Market,
            SlippageBps = 1200L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.PlaceOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryActiveOrdersAsync()
    {
        const string example = """""{"total":2,"offset":0,"limit":20,"orders":[{"orderId":"54124","vendorOrderId":"0x1234abcd...","vendor":"PREDICT_FUN","marketTopicId":4229564,"slug":"btc-price-1h-up-or-down","marketTopicTitle":"BTC Price 1h Up or Down?","marketId":5567895,"marketTitle":"UP","outcome":"YES","outcomeIndex":0,"status":"OPENING","side":"BUY","orderType":"LIMIT","createTime":1748131500000,"modifyTime":1748131500000,"makerUsdtAmount":"1.00","makerShareQty":"2000.00","filledUsdtAmount":"0.00","filledShareQty":"0.00","fillPercentage":"0.00","price":"0.50","marketProviderFee":"0.02","networkFee":"0.000001"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryActiveOrdersRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
        };

        var response = await client.QueryActiveOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/order/list", seen.Path);
        Assert.Equal("0x12e32db8817e292508c34111cbc4b23340df542c", seen.Param("walletAddress"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryActiveOrdersWithOptionalParametersAsync()
    {
        const string example = """""{"total":2,"offset":0,"limit":20,"orders":[{"orderId":"54124","vendorOrderId":"0x1234abcd...","vendor":"PREDICT_FUN","marketTopicId":4229564,"slug":"btc-price-1h-up-or-down","marketTopicTitle":"BTC Price 1h Up or Down?","marketId":5567895,"marketTitle":"UP","outcome":"YES","outcomeIndex":0,"status":"OPENING","side":"BUY","orderType":"LIMIT","createTime":1748131500000,"modifyTime":1748131500000,"makerUsdtAmount":"1.00","makerShareQty":"2000.00","filledUsdtAmount":"0.00","filledShareQty":"0.00","fillPercentage":"0.00","price":"0.50","marketProviderFee":"0.02","networkFee":"0.000001"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryActiveOrdersRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            TradeSide = QueryActiveOrdersTradeSide.Buy,
            L1Category = "crypto",
            MarketId = 5567895L,
            Offset = 0L,
            Limit = 20L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryActiveOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/order/list", seen.Path);
        Assert.Equal("0x12e32db8817e292508c34111cbc4b23340df542c", seen.Param("walletAddress"));
        Assert.Equal("BUY", seen.Param("tradeSide"));
        Assert.Equal("crypto", seen.Param("l1Category"));
        Assert.Equal("5567895", seen.Param("marketId"));
        Assert.Equal("0", seen.Param("offset"));
        Assert.Equal("20", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryActiveOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryActiveOrdersRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryActiveOrdersAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryOrderHistoryAsync()
    {
        const string example = """""{"total":15,"offset":0,"limit":20,"orders":[{"orderId":"54100","vendorOrderId":"0xabcd5678...","vendor":"PREDICT_FUN","marketTopicId":4229500,"slug":"btc-price-1h-up-or-down-prev","marketTopicTitle":"BTC Price 1h Up or Down?","marketId":5567800,"marketTitle":"UP","outcome":"YES","outcomeIndex":0,"status":"CLOSED","side":"BUY","orderType":"MARKET","createTime":1748045100000,"modifyTime":1748045101000,"terminalTime":1748045101000,"makerUsdtAmount":"1.00","makerShareQty":"1923.07","filledUsdtAmount":"1.00","filledShareQty":"1923.07","fillPercentage":"1.00","price":"0.52","marketProviderFee":"0.02","networkFee":"0.000001"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryOrderHistoryRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
        };

        var response = await client.QueryOrderHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/order/history", seen.Path);
        Assert.Equal("0x12e32db8817e292508c34111cbc4b23340df542c", seen.Param("walletAddress"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryOrderHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"total":15,"offset":0,"limit":20,"orders":[{"orderId":"54100","vendorOrderId":"0xabcd5678...","vendor":"PREDICT_FUN","marketTopicId":4229500,"slug":"btc-price-1h-up-or-down-prev","marketTopicTitle":"BTC Price 1h Up or Down?","marketId":5567800,"marketTitle":"UP","outcome":"YES","outcomeIndex":0,"status":"CLOSED","side":"BUY","orderType":"MARKET","createTime":1748045100000,"modifyTime":1748045101000,"terminalTime":1748045101000,"makerUsdtAmount":"1.00","makerShareQty":"1923.07","filledUsdtAmount":"1.00","filledShareQty":"1923.07","fillPercentage":"1.00","price":"0.52","marketProviderFee":"0.02","networkFee":"0.000001"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryOrderHistoryRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            L1Category = "crypto",
            OrderType = QueryOrderHistoryOrderType.Market,
            Status = "CLOSED",
            StartDate = "2026-05-01",
            EndDate = "2026-05-25",
            Offset = 0L,
            Limit = 20L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryOrderHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/order/history", seen.Path);
        Assert.Equal("0x12e32db8817e292508c34111cbc4b23340df542c", seen.Param("walletAddress"));
        Assert.Equal("crypto", seen.Param("l1Category"));
        Assert.Equal("MARKET", seen.Param("orderType"));
        Assert.Equal("CLOSED", seen.Param("status"));
        Assert.Equal("2026-05-01", seen.Param("startDate"));
        Assert.Equal("2026-05-25", seen.Param("endDate"));
        Assert.Equal("0", seen.Param("offset"));
        Assert.Equal("20", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryOrderHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryOrderHistoryRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryOrderHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
