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

namespace Binance.W3WPrediction.Tests.RestApi.Otc;

[Trait("Category", "Native")]
public class OtcApiTests
{
    private static W3WPredictionRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task CreateOtcBlocktradeAsync()
    {
        const string example = """""{"orderId":"26080500000001234567","secretToken":"a1b2c3d4-e5f6-7890-abcd-ef1234567890"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CreateOtcBlocktradeRequest
        {
            MarketId = "123",
            TokenId = "71321045679252212594626385532706912750332728571942532289631379312455583992563",
            Side = CreateOtcBlocktradeSide.Buy,
            MakerAmount = "600000000000000000000",
            TakerAmount = "1000000000000000000000",
            PricePerShare = "0.65",
            Expiration = 1790000000L,
        };

        var response = await client.CreateOtcBlocktradeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/otc/blocktrade/create", seen.Path);
        Assert.Equal("123", seen.Param("marketId"));
        Assert.Equal("71321045679252212594626385532706912750332728571942532289631379312455583992563", seen.Param("tokenId"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("600000000000000000000", seen.Param("makerAmount"));
        Assert.Equal("1000000000000000000000", seen.Param("takerAmount"));
        Assert.Equal("0.65", seen.Param("pricePerShare"));
        Assert.Equal("1790000000", seen.Param("expiration"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CreateOtcBlocktradeBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CreateOtcBlocktradeRequest
        {
            MarketId = "123",
            TokenId = "71321045679252212594626385532706912750332728571942532289631379312455583992563",
            Side = CreateOtcBlocktradeSide.Buy,
            MakerAmount = "600000000000000000000",
            TakerAmount = "1000000000000000000000",
            PricePerShare = "0.65",
            Expiration = 1790000000L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CreateOtcBlocktradeAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task FulfilOtcBlocktradeAsync()
    {
        const string example = """""{"orderId":"26080500000001234568"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new FulfilOtcBlocktradeRequest
        {
            OrderId = "26080500000001234567",
            SecretToken = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
        };

        var response = await client.FulfilOtcBlocktradeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/otc/blocktrade/fulfil", seen.Path);
        Assert.Equal("26080500000001234567", seen.Param("orderId"));
        Assert.Equal("a1b2c3d4-e5f6-7890-abcd-ef1234567890", seen.Param("secretToken"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FulfilOtcBlocktradeBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new FulfilOtcBlocktradeRequest
        {
            OrderId = "26080500000001234567",
            SecretToken = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.FulfilOtcBlocktradeAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetOtcBlocktradeDetailAsync()
    {
        const string example = """""{"orderId":"26080500000001234567","status":"OPEN","orderData":{"status":"OPEN","marketId":"123","tokenId":"71321045679252212594626385532706912750332728571942532289631379312455583992563","side":0,"maker":"0x12e32db8817e292508c34111cbc4b23340df542c","taker":"taker","makerAmount":"600000000000000000000","takerAmount":"1000000000000000000000","price":0.65,"orderType":"GTD","timeInForce":"GTD","expiration":1790000000,"filledAmount":"0","quoteType":"Bid","createdAt":"2026-08-05T10:30:00.000Z","isNegRisk":false,"isYieldBearing":false,"secretToken":"a1b2c3d4-e5f6-7890-abcd-ef1234567890"}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetOtcBlocktradeDetailRequest
        {
            OrderId = "26080500000001234567",
        };

        var response = await client.GetOtcBlocktradeDetailAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/otc/blocktrade/detail", seen.Path);
        Assert.Equal("26080500000001234567", seen.Param("orderId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetOtcBlocktradeDetailBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetOtcBlocktradeDetailRequest
        {
            OrderId = "26080500000001234567",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetOtcBlocktradeDetailAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetOtcBlocktradeEventsAsync()
    {
        const string example = """""{"cursor":"next-cursor-string","events":[{"event":"CREATE","blocktradeId":"pf-bt-001","orderId":"26080500000001234567","marketId":123,"amount":"600000000000000000000","fee":"1000000000000000","effectiveFee":"1000000000000000","price":"650000000000000000","transactionHash":"transactionHash","reason":"reason","isMaker":true,"timestamp":"2026-08-05T10:30:00.000Z"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetOtcBlocktradeEventsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/otc/blocktrade/events", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetOtcBlocktradeEventsWithOptionalParametersAsync()
    {
        const string example = """""{"cursor":"next-cursor-string","events":[{"event":"CREATE","blocktradeId":"pf-bt-001","orderId":"26080500000001234567","marketId":123,"amount":"600000000000000000000","fee":"1000000000000000","effectiveFee":"1000000000000000","price":"650000000000000000","transactionHash":"transactionHash","reason":"reason","isMaker":true,"timestamp":"2026-08-05T10:30:00.000Z"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetOtcBlocktradeEventsRequest
        {
            First = 20L,
            After = "next-cursor-string",
            EventTypes = new() { },
            MarketId = 123L,
        };

        var response = await client.GetOtcBlocktradeEventsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/otc/blocktrade/events", seen.Path);
        Assert.Equal("20", seen.Param("first"));
        Assert.Equal("next-cursor-string", seen.Param("after"));
        Assert.Equal("123", seen.Param("marketId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetOtcBlocktradeEventsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetOtcBlocktradeEventsAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetOtcReservedBalancesAsync()
    {
        const string example = """""{"balances":[{"type":"USDT","tokenId":"tokenId","amount":"500000000000000000000"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetOtcReservedBalancesRequest
        {
            Assets = new() { },
        };

        var response = await client.GetOtcReservedBalancesAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/otc/blocktrade/reserved-balances", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetOtcReservedBalancesBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetOtcReservedBalancesRequest
        {
            Assets = new() { },
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetOtcReservedBalancesAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ListOtcBlocktradesAsync()
    {
        const string example = """""{"cursor":"next-cursor-string","blocktrades":[{"status":"OPEN","marketId":"123","tokenId":"71321045679252212594626385532706912750332728571942532289631379312455583992563","side":0,"maker":"0x12e32db8817e292508c34111cbc4b23340df542c","makerAmount":"600000000000000000000","takerAmount":"1000000000000000000000","price":0.65,"quoteType":"Bid","createdAt":"2026-08-05T10:30:00.000Z","secretToken":"a1b2c3d4-e5f6-7890-abcd-ef1234567890"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.ListOtcBlocktradesAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/otc/blocktrade/list", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ListOtcBlocktradesWithOptionalParametersAsync()
    {
        const string example = """""{"cursor":"next-cursor-string","blocktrades":[{"status":"OPEN","marketId":"123","tokenId":"71321045679252212594626385532706912750332728571942532289631379312455583992563","side":0,"maker":"0x12e32db8817e292508c34111cbc4b23340df542c","makerAmount":"600000000000000000000","takerAmount":"1000000000000000000000","price":0.65,"quoteType":"Bid","createdAt":"2026-08-05T10:30:00.000Z","secretToken":"a1b2c3d4-e5f6-7890-abcd-ef1234567890"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ListOtcBlocktradesRequest
        {
            First = 20L,
            After = "next-cursor-string",
            Status = ListOtcBlocktradesStatus.Open,
        };

        var response = await client.ListOtcBlocktradesAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/otc/blocktrade/list", seen.Path);
        Assert.Equal("20", seen.Param("first"));
        Assert.Equal("next-cursor-string", seen.Param("after"));
        Assert.Equal("OPEN", seen.Param("status"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ListOtcBlocktradesBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ListOtcBlocktradesAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task PreviewOtcBlocktradeAsync()
    {
        const string example = """""{"orderId":"orderId","status":"OPEN","orderData":{"status":"OPEN","marketId":"123","tokenId":"71321045679252212594626385532706912750332728571942532289631379312455583992563","side":0,"maker":"0x12e32db8817e292508c34111cbc4b23340df542c","taker":"taker","makerAmount":"600000000000000000000","takerAmount":"1000000000000000000000","price":0.65,"orderType":"GTD","timeInForce":"GTD","expiration":1790000000,"filledAmount":"0","quoteType":"Bid","createdAt":"2026-08-05T10:30:00.000Z","isNegRisk":false,"isYieldBearing":false}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new PreviewOtcBlocktradeRequest
        {
            SecretToken = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
        };

        var response = await client.PreviewOtcBlocktradeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/otc/blocktrade/preview", seen.Path);
        Assert.Equal("a1b2c3d4-e5f6-7890-abcd-ef1234567890", seen.Param("secretToken"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task PreviewOtcBlocktradeBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new PreviewOtcBlocktradeRequest
        {
            SecretToken = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.PreviewOtcBlocktradeAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task RemoveOtcBlocktradesAsync()
    {
        const string example = """""{"removed":["26080500000001234567"],"noop":["26080500000001234568"]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new RemoveOtcBlocktradesRequest
        {
            OrderIds = new() { },
        };

        var response = await client.RemoveOtcBlocktradesAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/otc/blocktrade/remove", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task RemoveOtcBlocktradesBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new RemoveOtcBlocktradesRequest
        {
            OrderIds = new() { },
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.RemoveOtcBlocktradesAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
