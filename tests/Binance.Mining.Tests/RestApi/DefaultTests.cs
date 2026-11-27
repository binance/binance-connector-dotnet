//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.Mining.RestApi;

namespace Binance.Mining.Tests.RestApi;

[Trait("Category", "Native")]
public class DefaultApiTests
{
    private static MiningRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task AccountListAsync()
    {
        const string example = """""{"code":0,"msg":"","data":[{"type":"H_hashrate","userName":"test","list":[{"time":1585267200000,"hashrate":"0.00000000","reject":"0.00000000"}]}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AccountListRequest
        {
            Algo = "sha256",
            UserName = "test",
        };

        var response = await client.AccountListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/mining/statistics/user/list", seen.Path);
        Assert.Equal("sha256", seen.Param("algo"));
        Assert.Equal("test", seen.Param("userName"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AccountListWithOptionalParametersAsync()
    {
        const string example = """""{"code":0,"msg":"","data":[{"type":"H_hashrate","userName":"test","list":[{"time":1585267200000,"hashrate":"0.00000000","reject":"0.00000000"}]}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AccountListRequest
        {
            Algo = "sha256",
            UserName = "test",
            RecvWindow = 5000L,
        };

        var response = await client.AccountListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/mining/statistics/user/list", seen.Path);
        Assert.Equal("sha256", seen.Param("algo"));
        Assert.Equal("test", seen.Param("userName"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AccountListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new AccountListRequest
        {
            Algo = "sha256",
            UserName = "test",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AccountListAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task AcquiringAlgorithmAsync()
    {
        const string example = """""{"code":0,"msg":"","data":[{"algoName":"SHA256-BTC","algoId":1,"poolIndex":100,"unit":"h/s"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.AcquiringAlgorithmAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/mining/pub/algoList", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AcquiringAlgorithmBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AcquiringAlgorithmAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task AcquiringCoinnameAsync()
    {
        const string example = """""{"code":0,"msg":"","data":[{"coinName":"BTC","coinId":1,"poolIndex":0,"algoId":1,"algoName":"SHA256-BTC"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.AcquiringCoinnameAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/mining/pub/coinList", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AcquiringCoinnameBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AcquiringCoinnameAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CancelHashrateResaleConfigurationAsync()
    {
        const string example = """""{"code":0,"msg":"","data":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelHashrateResaleConfigurationRequest
        {
            ConfigId = 168L,
            UserName = "test",
        };

        var response = await client.CancelHashrateResaleConfigurationAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/mining/hash-transfer/config/cancel", seen.Path);
        Assert.Equal("168", seen.Param("configId"));
        Assert.Equal("test", seen.Param("userName"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelHashrateResaleConfigurationWithOptionalParametersAsync()
    {
        const string example = """""{"code":0,"msg":"","data":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelHashrateResaleConfigurationRequest
        {
            ConfigId = 168L,
            UserName = "test",
            RecvWindow = 5000L,
        };

        var response = await client.CancelHashrateResaleConfigurationAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/mining/hash-transfer/config/cancel", seen.Path);
        Assert.Equal("168", seen.Param("configId"));
        Assert.Equal("test", seen.Param("userName"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelHashrateResaleConfigurationBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CancelHashrateResaleConfigurationRequest
        {
            ConfigId = 168L,
            UserName = "test",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CancelHashrateResaleConfigurationAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task EarningsListAsync()
    {
        const string example = """""{"code":0,"msg":"","data":{"accountProfits":[{"time":1586188800000,"type":31,"hashTransfer":200000000000,"transferAmount":0.02180958,"dayHashRate":129129903378244,"profitAmount":8.6083060304,"coinName":"BTC","status":2}],"totalNum":3,"pageSize":20}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new EarningsListRequest
        {
            Algo = "sha256",
            UserName = "test",
        };

        var response = await client.EarningsListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/mining/payment/list", seen.Path);
        Assert.Equal("sha256", seen.Param("algo"));
        Assert.Equal("test", seen.Param("userName"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task EarningsListWithOptionalParametersAsync()
    {
        const string example = """""{"code":0,"msg":"","data":{"accountProfits":[{"time":1586188800000,"type":31,"hashTransfer":200000000000,"transferAmount":0.02180958,"dayHashRate":129129903378244,"profitAmount":8.6083060304,"coinName":"BTC","status":2}],"totalNum":3,"pageSize":20}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new EarningsListRequest
        {
            Algo = "sha256",
            UserName = "test",
            Coin = "BTC",
            StartDate = 1770736694138L,
            EndDate = 1770736694138L,
            PageIndex = 1L,
            PageSize = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.EarningsListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/mining/payment/list", seen.Path);
        Assert.Equal("sha256", seen.Param("algo"));
        Assert.Equal("test", seen.Param("userName"));
        Assert.Equal("BTC", seen.Param("coin"));
        Assert.Equal("1770736694138", seen.Param("startDate"));
        Assert.Equal("1770736694138", seen.Param("endDate"));
        Assert.Equal("1", seen.Param("pageIndex"));
        Assert.Equal("10", seen.Param("pageSize"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task EarningsListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new EarningsListRequest
        {
            Algo = "sha256",
            UserName = "test",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.EarningsListAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ExtraBonusListAsync()
    {
        const string example = """""{"code":0,"msg":"","data":{"otherProfits":[{"time":1607443200000,"coinName":"BTC","type":4,"profitAmount":0.0011859,"status":2}],"totalNum":3,"pageSize":20}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ExtraBonusListRequest
        {
            Algo = "sha256",
            UserName = "test",
        };

        var response = await client.ExtraBonusListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/mining/payment/other", seen.Path);
        Assert.Equal("sha256", seen.Param("algo"));
        Assert.Equal("test", seen.Param("userName"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ExtraBonusListWithOptionalParametersAsync()
    {
        const string example = """""{"code":0,"msg":"","data":{"otherProfits":[{"time":1607443200000,"coinName":"BTC","type":4,"profitAmount":0.0011859,"status":2}],"totalNum":3,"pageSize":20}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ExtraBonusListRequest
        {
            Algo = "sha256",
            UserName = "test",
            Coin = "BTC",
            StartDate = 1770736694138L,
            EndDate = 1770736694138L,
            PageIndex = 1L,
            PageSize = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.ExtraBonusListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/mining/payment/other", seen.Path);
        Assert.Equal("sha256", seen.Param("algo"));
        Assert.Equal("test", seen.Param("userName"));
        Assert.Equal("BTC", seen.Param("coin"));
        Assert.Equal("1770736694138", seen.Param("startDate"));
        Assert.Equal("1770736694138", seen.Param("endDate"));
        Assert.Equal("1", seen.Param("pageIndex"));
        Assert.Equal("10", seen.Param("pageSize"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ExtraBonusListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new ExtraBonusListRequest
        {
            Algo = "sha256",
            UserName = "test",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ExtraBonusListAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task HashrateResaleDetailAsync()
    {
        const string example = """""{"code":0,"msg":"","data":{"profitTransferDetails":[{"poolUsername":"test4001","toPoolUsername":"pop","algoName":"sha256","hashRate":200000000000,"day":20201213,"amount":0.2256872,"coinName":"BTC"}],"totalNum":8,"pageSize":200}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new HashrateResaleDetailRequest
        {
            ConfigId = 168L,
        };

        var response = await client.HashrateResaleDetailAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/mining/hash-transfer/profit/details", seen.Path);
        Assert.Equal("168", seen.Param("configId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task HashrateResaleDetailWithOptionalParametersAsync()
    {
        const string example = """""{"code":0,"msg":"","data":{"profitTransferDetails":[{"poolUsername":"test4001","toPoolUsername":"pop","algoName":"sha256","hashRate":200000000000,"day":20201213,"amount":0.2256872,"coinName":"BTC"}],"totalNum":8,"pageSize":200}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new HashrateResaleDetailRequest
        {
            ConfigId = 168L,
            PageIndex = 1L,
            PageSize = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.HashrateResaleDetailAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/mining/hash-transfer/profit/details", seen.Path);
        Assert.Equal("168", seen.Param("configId"));
        Assert.Equal("1", seen.Param("pageIndex"));
        Assert.Equal("10", seen.Param("pageSize"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task HashrateResaleDetailBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new HashrateResaleDetailRequest
        {
            ConfigId = 168L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.HashrateResaleDetailAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task HashrateResaleListAsync()
    {
        const string example = """""{"code":0,"msg":"","data":{"configDetails":[{"configId":168,"poolUsername":"123","toPoolUsername":"user1","algoName":"Ethash","hashRate":5000000,"startDay":20201210,"endDay":20210405,"status":1,"type":0}],"totalNum":21,"pageSize":200}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.HashrateResaleListAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/mining/hash-transfer/config/details/list", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task HashrateResaleListWithOptionalParametersAsync()
    {
        const string example = """""{"code":0,"msg":"","data":{"configDetails":[{"configId":168,"poolUsername":"123","toPoolUsername":"user1","algoName":"Ethash","hashRate":5000000,"startDay":20201210,"endDay":20210405,"status":1,"type":0}],"totalNum":21,"pageSize":200}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new HashrateResaleListRequest
        {
            PageIndex = 1L,
            PageSize = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.HashrateResaleListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/mining/hash-transfer/config/details/list", seen.Path);
        Assert.Equal("1", seen.Param("pageIndex"));
        Assert.Equal("10", seen.Param("pageSize"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task HashrateResaleListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.HashrateResaleListAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task HashrateResaleRequestAsync()
    {
        const string example = """""{"code":0,"msg":"","data":171}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new HashrateResaleRequestRequest
        {
            UserName = "test",
            Algo = "sha256",
            EndDate = 1770736694138L,
            StartDate = 1770736694138L,
            ToPoolUser = "S19pro",
            HashRate = 100000000L,
        };

        var response = await client.HashrateResaleRequestAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/mining/hash-transfer/config", seen.Path);
        Assert.Equal("test", seen.Param("userName"));
        Assert.Equal("sha256", seen.Param("algo"));
        Assert.Equal("1770736694138", seen.Param("endDate"));
        Assert.Equal("1770736694138", seen.Param("startDate"));
        Assert.Equal("S19pro", seen.Param("toPoolUser"));
        Assert.Equal("100000000", seen.Param("hashRate"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task HashrateResaleRequestWithOptionalParametersAsync()
    {
        const string example = """""{"code":0,"msg":"","data":171}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new HashrateResaleRequestRequest
        {
            UserName = "test",
            Algo = "sha256",
            EndDate = 1770736694138L,
            StartDate = 1770736694138L,
            ToPoolUser = "S19pro",
            HashRate = 100000000L,
            RecvWindow = 5000L,
        };

        var response = await client.HashrateResaleRequestAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/mining/hash-transfer/config", seen.Path);
        Assert.Equal("test", seen.Param("userName"));
        Assert.Equal("sha256", seen.Param("algo"));
        Assert.Equal("1770736694138", seen.Param("endDate"));
        Assert.Equal("1770736694138", seen.Param("startDate"));
        Assert.Equal("S19pro", seen.Param("toPoolUser"));
        Assert.Equal("100000000", seen.Param("hashRate"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task HashrateResaleRequestBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new HashrateResaleRequestRequest
        {
            UserName = "test",
            Algo = "sha256",
            EndDate = 1770736694138L,
            StartDate = 1770736694138L,
            ToPoolUser = "S19pro",
            HashRate = 100000000L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.HashrateResaleRequestAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task MiningAccountEarningAsync()
    {
        const string example = """""{"code":0,"msg":"","data":{"accountProfits":[{"time":1607443200000,"coinName":"BTC","type":2,"puid":59985472,"subName":"vdvaghani","amount":0.09186957}],"totalNum":3,"pageSize":20}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MiningAccountEarningRequest
        {
            Algo = "sha256",
        };

        var response = await client.MiningAccountEarningAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/mining/payment/uid", seen.Path);
        Assert.Equal("sha256", seen.Param("algo"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MiningAccountEarningWithOptionalParametersAsync()
    {
        const string example = """""{"code":0,"msg":"","data":{"accountProfits":[{"time":1607443200000,"coinName":"BTC","type":2,"puid":59985472,"subName":"vdvaghani","amount":0.09186957}],"totalNum":3,"pageSize":20}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MiningAccountEarningRequest
        {
            Algo = "sha256",
            StartDate = 1770736694138L,
            EndDate = 1770736694138L,
            PageIndex = 1L,
            PageSize = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.MiningAccountEarningAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/mining/payment/uid", seen.Path);
        Assert.Equal("sha256", seen.Param("algo"));
        Assert.Equal("1770736694138", seen.Param("startDate"));
        Assert.Equal("1770736694138", seen.Param("endDate"));
        Assert.Equal("1", seen.Param("pageIndex"));
        Assert.Equal("10", seen.Param("pageSize"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MiningAccountEarningBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new MiningAccountEarningRequest
        {
            Algo = "sha256",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.MiningAccountEarningAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task RequestForDetailMinerListAsync()
    {
        const string example = """""{"code":0,"msg":"","data":[{"workerName":"bhdc1.16A10404B","type":"H_hashrate","hashrateDatas":[{"time":1587902400000,"hashrate":"0","reject":0}]}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new RequestForDetailMinerListRequest
        {
            Algo = "sha256",
            UserName = "test",
            WorkerName = "bhdc1.16A10404B",
        };

        var response = await client.RequestForDetailMinerListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/mining/worker/detail", seen.Path);
        Assert.Equal("sha256", seen.Param("algo"));
        Assert.Equal("test", seen.Param("userName"));
        Assert.Equal("bhdc1.16A10404B", seen.Param("workerName"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task RequestForDetailMinerListWithOptionalParametersAsync()
    {
        const string example = """""{"code":0,"msg":"","data":[{"workerName":"bhdc1.16A10404B","type":"H_hashrate","hashrateDatas":[{"time":1587902400000,"hashrate":"0","reject":0}]}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new RequestForDetailMinerListRequest
        {
            Algo = "sha256",
            UserName = "test",
            WorkerName = "bhdc1.16A10404B",
            RecvWindow = 5000L,
        };

        var response = await client.RequestForDetailMinerListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/mining/worker/detail", seen.Path);
        Assert.Equal("sha256", seen.Param("algo"));
        Assert.Equal("test", seen.Param("userName"));
        Assert.Equal("bhdc1.16A10404B", seen.Param("workerName"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task RequestForDetailMinerListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new RequestForDetailMinerListRequest
        {
            Algo = "sha256",
            UserName = "test",
            WorkerName = "bhdc1.16A10404B",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.RequestForDetailMinerListAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task RequestForMinerListAsync()
    {
        const string example = """""{"code":0,"msg":"","data":{"workerDatas":[{"workerId":"1420554439452400131","workerName":"2X73","status":3,"hashRate":0,"dayHashRate":12697781298013.66,"rejectRate":0,"lastShareTime":1587712919000}],"totalNum":18530,"pageSize":20}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new RequestForMinerListRequest
        {
            Algo = "sha256",
            UserName = "test",
        };

        var response = await client.RequestForMinerListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/mining/worker/list", seen.Path);
        Assert.Equal("sha256", seen.Param("algo"));
        Assert.Equal("test", seen.Param("userName"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task RequestForMinerListWithOptionalParametersAsync()
    {
        const string example = """""{"code":0,"msg":"","data":{"workerDatas":[{"workerId":"1420554439452400131","workerName":"2X73","status":3,"hashRate":0,"dayHashRate":12697781298013.66,"rejectRate":0,"lastShareTime":1587712919000}],"totalNum":18530,"pageSize":20}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new RequestForMinerListRequest
        {
            Algo = "sha256",
            UserName = "test",
            PageIndex = 1L,
            Sort = 0L,
            SortColumn = 1L,
            WorkerStatus = 0L,
            RecvWindow = 5000L,
        };

        var response = await client.RequestForMinerListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/mining/worker/list", seen.Path);
        Assert.Equal("sha256", seen.Param("algo"));
        Assert.Equal("test", seen.Param("userName"));
        Assert.Equal("1", seen.Param("pageIndex"));
        Assert.Equal("0", seen.Param("sort"));
        Assert.Equal("1", seen.Param("sortColumn"));
        Assert.Equal("0", seen.Param("workerStatus"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task RequestForMinerListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new RequestForMinerListRequest
        {
            Algo = "sha256",
            UserName = "test",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.RequestForMinerListAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task StatisticListAsync()
    {
        const string example = """""{"code":0,"msg":"","data":{"fifteenMinHashRate":"457835490067496409.00000000","dayHashRate":"214289268068874127.65000000","validNum":0,"invalidNum":17562,"profitToday":{"BTC":"0.00314332","BSV":"56.17055953","BCH":"106.61586001"},"profitYesterday":{"BTC":"0.00314332","BSV":"56.17055953","BCH":"106.61586001"},"userName":"test","unit":"h/s","algo":"sha256"}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new StatisticListRequest
        {
            Algo = "sha256",
            UserName = "test",
        };

        var response = await client.StatisticListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/mining/statistics/user/status", seen.Path);
        Assert.Equal("sha256", seen.Param("algo"));
        Assert.Equal("test", seen.Param("userName"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task StatisticListWithOptionalParametersAsync()
    {
        const string example = """""{"code":0,"msg":"","data":{"fifteenMinHashRate":"457835490067496409.00000000","dayHashRate":"214289268068874127.65000000","validNum":0,"invalidNum":17562,"profitToday":{"BTC":"0.00314332","BSV":"56.17055953","BCH":"106.61586001"},"profitYesterday":{"BTC":"0.00314332","BSV":"56.17055953","BCH":"106.61586001"},"userName":"test","unit":"h/s","algo":"sha256"}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new StatisticListRequest
        {
            Algo = "sha256",
            UserName = "test",
            RecvWindow = 5000L,
        };

        var response = await client.StatisticListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/mining/statistics/user/status", seen.Path);
        Assert.Equal("sha256", seen.Param("algo"));
        Assert.Equal("test", seen.Param("userName"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task StatisticListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new StatisticListRequest
        {
            Algo = "sha256",
            UserName = "test",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.StatisticListAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
