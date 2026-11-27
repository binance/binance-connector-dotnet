//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.Alpha.RestApi;

namespace Binance.Alpha.Tests.RestApi.MarketData;

[Trait("Category", "Native")]
public class MarketDataApiTests
{
    private static AlphaRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task AggregatedTradesAsync()
    {
        const string example = """""{"code":"000000","message":"","messageDetail":"","data":[{"a":58470,"p":"1.00","q":"1.00","f":58470,"l":58665,"T":1752568680000,"m":true}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AggregatedTradesRequest
        {
            Symbol = "ALPHA_118USDC",
        };

        var response = await client.AggregatedTradesAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/bapi/defi/v1/public/alpha-trade/agg-trades", seen.Path);
        Assert.Equal("ALPHA_118USDC", seen.Param("symbol"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AggregatedTradesWithOptionalParametersAsync()
    {
        const string example = """""{"code":"000000","message":"","messageDetail":"","data":[{"a":58470,"p":"1.00","q":"1.00","f":58470,"l":58665,"T":1752568680000,"m":true}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AggregatedTradesRequest
        {
            Symbol = "ALPHA_118USDC",
            FromId = 58470L,
            StartTime = 1752568680000L,
            EndTime = 1752572280000L,
            Limit = 500L,
        };

        var response = await client.AggregatedTradesAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/bapi/defi/v1/public/alpha-trade/agg-trades", seen.Path);
        Assert.Equal("ALPHA_118USDC", seen.Param("symbol"));
        Assert.Equal("58470", seen.Param("fromId"));
        Assert.Equal("1752568680000", seen.Param("startTime"));
        Assert.Equal("1752572280000", seen.Param("endTime"));
        Assert.Equal("500", seen.Param("limit"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AggregatedTradesBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new AggregatedTradesRequest
        {
            Symbol = "ALPHA_118USDC",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AggregatedTradesAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task FullDepthAsync()
    {
        const string example = """""{"code":"000000","message":"message","messageDetail":"messageDetail","success":true,"data":{"lastUpdateId":47534656223,"symbol":"ALPHA_175USDT","bids":[["0.00040161","365980.85000000"]],"asks":[["0.00046996","61994.70000000"]],"E":1775027836086,"T":1775027836072}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new FullDepthRequest
        {
            Symbol = "ALPHA_175USDT",
        };

        var response = await client.FullDepthAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/bapi/defi/v1/public/alpha-trade/fullDepth", seen.Path);
        Assert.Equal("ALPHA_175USDT", seen.Param("symbol"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FullDepthWithOptionalParametersAsync()
    {
        const string example = """""{"code":"000000","message":"message","messageDetail":"messageDetail","success":true,"data":{"lastUpdateId":47534656223,"symbol":"ALPHA_175USDT","bids":[["0.00040161","365980.85000000"]],"asks":[["0.00046996","61994.70000000"]],"E":1775027836086,"T":1775027836072}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new FullDepthRequest
        {
            Symbol = "ALPHA_175USDT",
            Limit = FullDepthLimit.Limit5,
        };

        var response = await client.FullDepthAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/bapi/defi/v1/public/alpha-trade/fullDepth", seen.Path);
        Assert.Equal("ALPHA_175USDT", seen.Param("symbol"));
        Assert.Equal("5", seen.Param("limit"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FullDepthBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new FullDepthRequest
        {
            Symbol = "ALPHA_175USDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.FullDepthAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetExchangeInfoAsync()
    {
        const string example = """""{"code":"000000","message":"","messageDetail":"","success":true,"data":{"timezone":"UTC","assets":[{"asset":"USDT"}],"symbols":[{"symbol":"ALPHA_105USDT","status":"TRADING","baseAsset":"ALPHA_105","quoteAsset":"USDT","pricePrecision":8,"quantityPrecision":8,"baseAssetPrecision":8,"quotePrecision":8,"filters":[{"filterType":"PRICE_FILTER","minPrice":"0.00000001","maxPrice":"1000","tickSize":"0.00000001","stepSize":"0.01000000","maxQty":"277778","minQty":"0.01000000","limit":200,"minNotional":"0.1","maxNotional":"1000000","multiplierDown":"0.20000","multiplierUp":"5","bidMultiplierUp":"5","askMultiplierUp":"5","bidMultiplierDown":"0.20000","askMultiplierDown":"0.20000"}],"orderTypes":["LIMIT"]}],"orderTypes":""}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetExchangeInfoAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/bapi/defi/v1/public/alpha-trade/get-exchange-info", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetExchangeInfoBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetExchangeInfoAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task KlinesAsync()
    {
        const string example = """""{"code":"000000","message":"","messageDetail":"","success":true,"data":[["1752642000000"]]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new KlinesRequest
        {
            Symbol = "ALPHA_175USDT",
            Interval = KlinesInterval.Interval1s,
        };

        var response = await client.KlinesAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/bapi/defi/v1/public/alpha-trade/klines", seen.Path);
        Assert.Equal("ALPHA_175USDT", seen.Param("symbol"));
        Assert.Equal("1s", seen.Param("interval"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task KlinesWithOptionalParametersAsync()
    {
        const string example = """""{"code":"000000","message":"","messageDetail":"","success":true,"data":[["1752642000000"]]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new KlinesRequest
        {
            Symbol = "ALPHA_175USDT",
            Interval = KlinesInterval.Interval1s,
            Limit = 500L,
            StartTime = 1752642000000L,
            EndTime = 1752645599999L,
        };

        var response = await client.KlinesAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/bapi/defi/v1/public/alpha-trade/klines", seen.Path);
        Assert.Equal("ALPHA_175USDT", seen.Param("symbol"));
        Assert.Equal("1s", seen.Param("interval"));
        Assert.Equal("500", seen.Param("limit"));
        Assert.Equal("1752642000000", seen.Param("startTime"));
        Assert.Equal("1752645599999", seen.Param("endTime"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task KlinesBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new KlinesRequest
        {
            Symbol = "ALPHA_175USDT",
            Interval = KlinesInterval.Interval1s,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.KlinesAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TickerAsync()
    {
        const string example = """""{"code":"000000","message":"","messageDetail":"","data":{"symbol":"ALPHA_175USDT","priceChange":"-0.00007172","priceChangePercent":"-8.841","weightedAvgPrice":"0.00079608","lastPrice":"0.00073954","lastQty":"12600.43000000","openPrice":"0.00081126","highPrice":"0.00081126","lowPrice":"0.00073954","volume":"1204754.30000000","quoteVolume":"959.07729927","openTime":1768808100000,"closeTime":1768893244772,"firstId":93742,"lastId":93768,"count":38},"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TickerRequest
        {
            Symbol = "ALPHA_175USDT",
        };

        var response = await client.TickerAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/bapi/defi/v1/public/alpha-trade/ticker", seen.Path);
        Assert.Equal("ALPHA_175USDT", seen.Param("symbol"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TickerBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new TickerRequest
        {
            Symbol = "ALPHA_175USDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.TickerAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TokenListAsync()
    {
        const string example = """""{"code":"000000","message":"","messageDetail":"","success":true,"data":[{"tokenId":"3F350C8B3621770A673159B7A19BC034","chainId":"56","chainIconUrl":"https://bin.bnbstatic.com/image/admin_mgs_image_upload/20250228/d0216ce4-a3e9-4bda-8937-4a6aa943ccf2.png","chainName":"BSC","contractAddress":"0xcf640fdf9b3d9e45cbd69fda91d7e22579c14444","name":"gorilla","symbol":"gorilla","iconUrl":"https://bin.bnbstatic.com/images/web3-data/public/token/logos/248b5406f88a4ee28913a29107875339.png","price":"0.00080595003978242023","percentChange24h":"-7.42","volume24h":"14847.711222633409558029675","marketCap":"805950.03978242","fdv":"805950.03978242","liquidity":"263192.72813121626034","totalSupply":"1000000000","circulatingSupply":"1000000000","holders":"7120","decimals":18,"listingCex":false,"hotTag":false,"cexCoinName":"","canTransfer":false,"denomination":1,"offline":false,"tradeDecimal":8,"alphaId":"ALPHA_175","offsell":false,"priceHigh24h":"0.00088873864475645879","priceLow24h":"0.0008020805165487083","count24h":"166","onlineTge":false,"onlineAirdrop":false,"score":1,"cexOffDisplay":false,"stockState":false,"listingTime":1746686700000,"mulPoint":1,"bnExclusiveState":false}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.TokenListAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/bapi/defi/v1/public/wallet-direct/buw/wallet/cex/alpha/all/token/list", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TokenListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.TokenListAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
