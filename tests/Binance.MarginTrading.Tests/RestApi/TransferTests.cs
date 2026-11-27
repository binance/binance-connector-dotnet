//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.MarginTrading.RestApi;

namespace Binance.MarginTrading.Tests.RestApi.Transfer;

[Trait("Category", "Native")]
public class TransferApiTests
{
    private static MarginTradingRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task GetCrossMarginTransferHistoryAsync()
    {
        const string example = """""{"rows":[{"amount":"0.10000000","asset":"BNB","status":"CONFIRMED","timestamp":1566898617,"txId":5240372201,"type":"ROLL_IN","transFrom":"SPOT","transTo":"ISOLATED_MARGIN","fromSymbol":"BNBUSDT","toSymbol":"BTCUSDT"}],"total":3}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetCrossMarginTransferHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/transfer", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetCrossMarginTransferHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"amount":"0.10000000","asset":"BNB","status":"CONFIRMED","timestamp":1566898617,"txId":5240372201,"type":"ROLL_IN","transFrom":"SPOT","transTo":"ISOLATED_MARGIN","fromSymbol":"BNBUSDT","toSymbol":"BTCUSDT"}],"total":3}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetCrossMarginTransferHistoryRequest
        {
            Asset = "BNB",
            Type = GetCrossMarginTransferHistoryType.RollIn,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Size = 10L,
            IsolatedSymbol = "BNBUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.GetCrossMarginTransferHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/transfer", seen.Path);
        Assert.Equal("BNB", seen.Param("asset"));
        Assert.Equal("ROLL_IN", seen.Param("type"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("current"));
        Assert.Equal("10", seen.Param("size"));
        Assert.Equal("BNBUSDT", seen.Param("isolatedSymbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetCrossMarginTransferHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetCrossMarginTransferHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryMaxTransferOutAmountAsync()
    {
        const string example = """""{"amount":"3.59498107"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryMaxTransferOutAmountRequest
        {
            Asset = "BTC",
        };

        var response = await client.QueryMaxTransferOutAmountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/maxTransferable", seen.Path);
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryMaxTransferOutAmountWithOptionalParametersAsync()
    {
        const string example = """""{"amount":"3.59498107"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryMaxTransferOutAmountRequest
        {
            Asset = "BTC",
            IsolatedSymbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.QueryMaxTransferOutAmountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/maxTransferable", seen.Path);
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("BTCUSDT", seen.Param("isolatedSymbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryMaxTransferOutAmountBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryMaxTransferOutAmountRequest
        {
            Asset = "BTC",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryMaxTransferOutAmountAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
