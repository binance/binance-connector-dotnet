//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.DerivativesTradingOptions.RestApi;

namespace Binance.DerivativesTradingOptions.Tests.RestApi.MarketMakerEndpoints;

[Trait("Category", "Native")]
public class MarketMakerEndpointsApiTests
{
    private static DerivativesTradingOptionsRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task AutoCancelAllOpenOrdersAsync()
    {
        const string example = """""{"underlyings":["BTCUSDT"]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AutoCancelAllOpenOrdersRequest
        {
            Underlyings = "BTCUSDT,ETHUSDT",
        };

        var response = await client.AutoCancelAllOpenOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/eapi/v1/countdownCancelAllHeartBeat", seen.Path);
        Assert.Equal("BTCUSDT,ETHUSDT", seen.Param("underlyings"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AutoCancelAllOpenOrdersWithOptionalParametersAsync()
    {
        const string example = """""{"underlyings":["BTCUSDT"]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AutoCancelAllOpenOrdersRequest
        {
            Underlyings = "BTCUSDT,ETHUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.AutoCancelAllOpenOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/eapi/v1/countdownCancelAllHeartBeat", seen.Path);
        Assert.Equal("BTCUSDT,ETHUSDT", seen.Param("underlyings"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AutoCancelAllOpenOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new AutoCancelAllOpenOrdersRequest
        {
            Underlyings = "BTCUSDT,ETHUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AutoCancelAllOpenOrdersAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetAutoCancelAllOpenOrdersAsync()
    {
        const string example = """""{"underlying":"ETHUSDT","countdownTime":100000}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetAutoCancelAllOpenOrdersAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/countdownCancelAll", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetAutoCancelAllOpenOrdersWithOptionalParametersAsync()
    {
        const string example = """""{"underlying":"ETHUSDT","countdownTime":100000}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetAutoCancelAllOpenOrdersRequest
        {
            Underlying = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.GetAutoCancelAllOpenOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/countdownCancelAll", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("underlying"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetAutoCancelAllOpenOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetAutoCancelAllOpenOrdersAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetMarketMakerProtectionConfigAsync()
    {
        const string example = """""{"underlyingId":2,"underlying":"BTCUSDT","windowTimeInMilliseconds":3000,"frozenTimeInMilliseconds":300000,"qtyLimit":"2","deltaLimit":"2.3","lastTriggerTime":0}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetMarketMakerProtectionConfigRequest
        {
            Underlying = "BTCUSDT",
        };

        var response = await client.GetMarketMakerProtectionConfigAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/mmp", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("underlying"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetMarketMakerProtectionConfigWithOptionalParametersAsync()
    {
        const string example = """""{"underlyingId":2,"underlying":"BTCUSDT","windowTimeInMilliseconds":3000,"frozenTimeInMilliseconds":300000,"qtyLimit":"2","deltaLimit":"2.3","lastTriggerTime":0}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetMarketMakerProtectionConfigRequest
        {
            Underlying = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.GetMarketMakerProtectionConfigAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/mmp", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("underlying"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetMarketMakerProtectionConfigBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetMarketMakerProtectionConfigRequest
        {
            Underlying = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetMarketMakerProtectionConfigAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ResetMarketMakerProtectionConfigAsync()
    {
        const string example = """""{"underlyingId":2,"underlying":"BTCUSDT","windowTimeInMilliseconds":3000,"frozenTimeInMilliseconds":300000,"qtyLimit":"2","deltaLimit":"2.3","lastTriggerTime":0}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ResetMarketMakerProtectionConfigRequest
        {
            Underlying = "BTCUSDT",
        };

        var response = await client.ResetMarketMakerProtectionConfigAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/eapi/v1/mmpReset", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("underlying"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ResetMarketMakerProtectionConfigWithOptionalParametersAsync()
    {
        const string example = """""{"underlyingId":2,"underlying":"BTCUSDT","windowTimeInMilliseconds":3000,"frozenTimeInMilliseconds":300000,"qtyLimit":"2","deltaLimit":"2.3","lastTriggerTime":0}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ResetMarketMakerProtectionConfigRequest
        {
            Underlying = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.ResetMarketMakerProtectionConfigAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/eapi/v1/mmpReset", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("underlying"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ResetMarketMakerProtectionConfigBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new ResetMarketMakerProtectionConfigRequest
        {
            Underlying = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ResetMarketMakerProtectionConfigAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SetAutoCancelAllOpenOrdersAsync()
    {
        const string example = """""{"underlying":"ETHUSDT","countdownTime":100000}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SetAutoCancelAllOpenOrdersRequest
        {
            Underlying = "BTCUSDT",
            CountdownTime = 5000L,
        };

        var response = await client.SetAutoCancelAllOpenOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/eapi/v1/countdownCancelAll", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("underlying"));
        Assert.Equal("5000", seen.Param("countdownTime"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SetAutoCancelAllOpenOrdersWithOptionalParametersAsync()
    {
        const string example = """""{"underlying":"ETHUSDT","countdownTime":100000}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SetAutoCancelAllOpenOrdersRequest
        {
            Underlying = "BTCUSDT",
            CountdownTime = 5000L,
            RecvWindow = 5000L,
        };

        var response = await client.SetAutoCancelAllOpenOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/eapi/v1/countdownCancelAll", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("underlying"));
        Assert.Equal("5000", seen.Param("countdownTime"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SetAutoCancelAllOpenOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new SetAutoCancelAllOpenOrdersRequest
        {
            Underlying = "BTCUSDT",
            CountdownTime = 5000L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SetAutoCancelAllOpenOrdersAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SetMarketMakerProtectionConfigAsync()
    {
        const string example = """""{"underlyingId":2,"underlying":"BTCUSDT","windowTimeInMilliseconds":3000,"frozenTimeInMilliseconds":300000,"qtyLimit":"2","deltaLimit":"2.3","lastTriggerTime":0}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SetMarketMakerProtectionConfigRequest
        {
            Underlying = "BTCUSDT",
            WindowTimeInMilliseconds = 1000L,
            FrozenTimeInMilliseconds = 1000L,
            QtyLimit = 1.0m,
            DeltaLimit = 1.0m,
        };

        var response = await client.SetMarketMakerProtectionConfigAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/eapi/v1/mmpSet", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("underlying"));
        Assert.Equal("1000", seen.Param("windowTimeInMilliseconds"));
        Assert.Equal("1000", seen.Param("frozenTimeInMilliseconds"));
        Assert.Equal("1.0", seen.Param("qtyLimit"));
        Assert.Equal("1.0", seen.Param("deltaLimit"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SetMarketMakerProtectionConfigWithOptionalParametersAsync()
    {
        const string example = """""{"underlyingId":2,"underlying":"BTCUSDT","windowTimeInMilliseconds":3000,"frozenTimeInMilliseconds":300000,"qtyLimit":"2","deltaLimit":"2.3","lastTriggerTime":0}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SetMarketMakerProtectionConfigRequest
        {
            Underlying = "BTCUSDT",
            WindowTimeInMilliseconds = 1000L,
            FrozenTimeInMilliseconds = 1000L,
            QtyLimit = 1.0m,
            DeltaLimit = 1.0m,
            RecvWindow = 5000L,
        };

        var response = await client.SetMarketMakerProtectionConfigAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/eapi/v1/mmpSet", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("underlying"));
        Assert.Equal("1000", seen.Param("windowTimeInMilliseconds"));
        Assert.Equal("1000", seen.Param("frozenTimeInMilliseconds"));
        Assert.Equal("1.0", seen.Param("qtyLimit"));
        Assert.Equal("1.0", seen.Param("deltaLimit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SetMarketMakerProtectionConfigBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new SetMarketMakerProtectionConfigRequest
        {
            Underlying = "BTCUSDT",
            WindowTimeInMilliseconds = 1000L,
            FrozenTimeInMilliseconds = 1000L,
            QtyLimit = 1.0m,
            DeltaLimit = 1.0m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SetMarketMakerProtectionConfigAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
