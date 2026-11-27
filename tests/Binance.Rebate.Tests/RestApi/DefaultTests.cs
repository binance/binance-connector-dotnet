//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.Rebate.RestApi;

namespace Binance.Rebate.Tests.RestApi;

[Trait("Category", "Native")]
public class DefaultApiTests
{
    private static RebateRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task GetSpotRebateHistoryRecordsAsync()
    {
        const string example = """""{"status":"OK","type":"GENERAL","code":"000000000","data":{"page":1,"totalRecords":2,"totalPageNum":1,"data":[{"asset":"USDT","type":1,"amount":"0.0001126","updateTime":1637651320000}]}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetSpotRebateHistoryRecordsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/rebate/taxQuery", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetSpotRebateHistoryRecordsWithOptionalParametersAsync()
    {
        const string example = """""{"status":"OK","type":"GENERAL","code":"000000000","data":{"page":1,"totalRecords":2,"totalPageNum":1,"data":[{"asset":"USDT","type":1,"amount":"0.0001126","updateTime":1637651320000}]}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetSpotRebateHistoryRecordsRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Page = 1L,
            RecvWindow = 5000L,
        };

        var response = await client.GetSpotRebateHistoryRecordsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/rebate/taxQuery", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("page"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetSpotRebateHistoryRecordsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetSpotRebateHistoryRecordsAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
