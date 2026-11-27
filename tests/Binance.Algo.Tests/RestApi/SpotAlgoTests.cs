//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.Algo.RestApi;

namespace Binance.Algo.Tests.RestApi.SpotAlgo;

[Trait("Category", "Native")]
public class SpotAlgoApiTests
{
    private static AlgoRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task CancelAlgoOrderSpotAlgoAsync()
    {
        const string example = """""{"algoId":14511,"success":true,"code":0,"msg":"OK"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.CancelAlgoOrderSpotAlgoAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/sapi/v1/algo/spot/order", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelAlgoOrderSpotAlgoWithOptionalParametersAsync()
    {
        const string example = """""{"algoId":14511,"success":true,"code":0,"msg":"OK"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelAlgoOrderSpotAlgoRequest
        {
            AlgoId = 14511L,
            ClientAlgoId = "65ce1630101a480b85915d7e11fd5078",
            RecvWindow = 5000L,
        };

        var response = await client.CancelAlgoOrderSpotAlgoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/sapi/v1/algo/spot/order", seen.Path);
        Assert.Equal("14511", seen.Param("algoId"));
        Assert.Equal("65ce1630101a480b85915d7e11fd5078", seen.Param("clientAlgoId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelAlgoOrderSpotAlgoBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CancelAlgoOrderSpotAlgoAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryCurrentAlgoOpenOrdersSpotAlgoAsync()
    {
        const string example = """""{"total":1,"orders":[{"algoId":14517,"symbol":"ETHUSDT","side":"SELL","totalQty":"5.000","executedQty":"0.000","executedAmt":"0.00000000","avgPrice":"0.00","clientAlgoId":"d7096549481642f8a0bb69e9e2e31f2e","bookTime":1649756817004,"endTime":0,"algoStatus":"WORKING","algoType":"TWAP","urgency":"LOW","duration":86400}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryCurrentAlgoOpenOrdersSpotAlgoAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/algo/spot/openOrders", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCurrentAlgoOpenOrdersSpotAlgoWithOptionalParametersAsync()
    {
        const string example = """""{"total":1,"orders":[{"algoId":14517,"symbol":"ETHUSDT","side":"SELL","totalQty":"5.000","executedQty":"0.000","executedAmt":"0.00000000","avgPrice":"0.00","clientAlgoId":"d7096549481642f8a0bb69e9e2e31f2e","bookTime":1649756817004,"endTime":0,"algoStatus":"WORKING","algoType":"TWAP","urgency":"LOW","duration":86400}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryCurrentAlgoOpenOrdersSpotAlgoRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.QueryCurrentAlgoOpenOrdersSpotAlgoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/algo/spot/openOrders", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCurrentAlgoOpenOrdersSpotAlgoBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryCurrentAlgoOpenOrdersSpotAlgoAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryHistoricalAlgoOrdersSpotAlgoAsync()
    {
        const string example = """""{"total":1,"orders":[{"algoId":14518,"symbol":"BNBUSDT","side":"BUY","totalQty":"100.00","executedQty":"0.00","executedAmt":"0.00000000","avgPrice":"0.000","clientAlgoId":"acacab56b3c44bef9f6a8f8ebd2a8408","bookTime":1649757019503,"endTime":1649757088101,"algoStatus":"CANCELLED","algoType":"TWAP","urgency":"LOW","duration":86400}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryHistoricalAlgoOrdersSpotAlgoAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/algo/spot/historicalOrders", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryHistoricalAlgoOrdersSpotAlgoWithOptionalParametersAsync()
    {
        const string example = """""{"total":1,"orders":[{"algoId":14518,"symbol":"BNBUSDT","side":"BUY","totalQty":"100.00","executedQty":"0.00","executedAmt":"0.00000000","avgPrice":"0.000","clientAlgoId":"acacab56b3c44bef9f6a8f8ebd2a8408","bookTime":1649757019503,"endTime":1649757088101,"algoStatus":"CANCELLED","algoType":"TWAP","urgency":"LOW","duration":86400}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryHistoricalAlgoOrdersSpotAlgoRequest
        {
            Symbol = "BTCUSDT",
            Side = QueryHistoricalAlgoOrdersSpotAlgoSide.Buy,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Page = 1L,
            PageSize = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryHistoricalAlgoOrdersSpotAlgoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/algo/spot/historicalOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("page"));
        Assert.Equal("10", seen.Param("pageSize"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryHistoricalAlgoOrdersSpotAlgoBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryHistoricalAlgoOrdersSpotAlgoAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QuerySubOrdersSpotAlgoAsync()
    {
        const string example = """""{"total":1,"executedQty":"1.000","executedAmt":"3229.44000000","subOrders":[{"algoId":13723,"orderId":8389765519993909000,"orderStatus":"FILLED","executedQty":"1.000","executedAmt":"3229.44000000","feeAmt":"-1.61471999","feeAsset":"USDT","bookTime":1649319001964,"avgPrice":"3229.44","side":"SELL","symbol":"ETHUSDT","subId":1,"timeInForce":"IMMEDIATE_OR_CANCEL","origQty":"1.000"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QuerySubOrdersSpotAlgoRequest
        {
            AlgoId = 1L,
        };

        var response = await client.QuerySubOrdersSpotAlgoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/algo/spot/subOrders", seen.Path);
        Assert.Equal("1", seen.Param("algoId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QuerySubOrdersSpotAlgoWithOptionalParametersAsync()
    {
        const string example = """""{"total":1,"executedQty":"1.000","executedAmt":"3229.44000000","subOrders":[{"algoId":13723,"orderId":8389765519993909000,"orderStatus":"FILLED","executedQty":"1.000","executedAmt":"3229.44000000","feeAmt":"-1.61471999","feeAsset":"USDT","bookTime":1649319001964,"avgPrice":"3229.44","side":"SELL","symbol":"ETHUSDT","subId":1,"timeInForce":"IMMEDIATE_OR_CANCEL","origQty":"1.000"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QuerySubOrdersSpotAlgoRequest
        {
            AlgoId = 1L,
            Page = 1L,
            PageSize = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.QuerySubOrdersSpotAlgoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/algo/spot/subOrders", seen.Path);
        Assert.Equal("1", seen.Param("algoId"));
        Assert.Equal("1", seen.Param("page"));
        Assert.Equal("10", seen.Param("pageSize"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QuerySubOrdersSpotAlgoBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QuerySubOrdersSpotAlgoRequest
        {
            AlgoId = 1L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QuerySubOrdersSpotAlgoAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TimeWeightedAveragePriceSpotAlgoAsync()
    {
        const string example = """""{"clientAlgoId":"65ce1630101a480b85915d7e11fd5078","success":true,"code":0,"msg":"OK"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TimeWeightedAveragePriceSpotAlgoRequest
        {
            Symbol = "BTCUSDT",
            Side = TimeWeightedAveragePriceSpotAlgoSide.Buy,
            Quantity = 1m,
            Duration = 5000L,
        };

        var response = await client.TimeWeightedAveragePriceSpotAlgoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/algo/spot/newOrderTwap", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("1", seen.Param("quantity"));
        Assert.Equal("5000", seen.Param("duration"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TimeWeightedAveragePriceSpotAlgoWithOptionalParametersAsync()
    {
        const string example = """""{"clientAlgoId":"65ce1630101a480b85915d7e11fd5078","success":true,"code":0,"msg":"OK"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TimeWeightedAveragePriceSpotAlgoRequest
        {
            Symbol = "BTCUSDT",
            Side = TimeWeightedAveragePriceSpotAlgoSide.Buy,
            Quantity = 1m,
            Duration = 5000L,
            ClientAlgoId = "1",
            LimitPrice = 1m,
        };

        var response = await client.TimeWeightedAveragePriceSpotAlgoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/algo/spot/newOrderTwap", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("1", seen.Param("quantity"));
        Assert.Equal("5000", seen.Param("duration"));
        Assert.Equal("1", seen.Param("clientAlgoId"));
        Assert.Equal("1", seen.Param("limitPrice"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TimeWeightedAveragePriceSpotAlgoBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new TimeWeightedAveragePriceSpotAlgoRequest
        {
            Symbol = "BTCUSDT",
            Side = TimeWeightedAveragePriceSpotAlgoSide.Buy,
            Quantity = 1m,
            Duration = 5000L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.TimeWeightedAveragePriceSpotAlgoAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task VolumeParticipationAsync()
    {
        const string example = """""{"clientAlgoId":"65ce1630101a480b85915d7e11fd5078","success":true,"code":0,"msg":"OK"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new VolumeParticipationRequest
        {
            Symbol = "BTCUSDT",
            Side = VolumeParticipationSide.Buy,
            Quantity = 1m,
            Urgency = VolumeParticipationUrgency.Low,
        };

        var response = await client.VolumeParticipationAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/algo/spot/newOrderVp", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("1", seen.Param("quantity"));
        Assert.Equal("LOW", seen.Param("urgency"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task VolumeParticipationWithOptionalParametersAsync()
    {
        const string example = """""{"clientAlgoId":"65ce1630101a480b85915d7e11fd5078","success":true,"code":0,"msg":"OK"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new VolumeParticipationRequest
        {
            Symbol = "BTCUSDT",
            Side = VolumeParticipationSide.Buy,
            Quantity = 1m,
            Urgency = VolumeParticipationUrgency.Low,
            ClientAlgoId = "1",
            VpTimeLimit = 5000L,
            RecvWindow = 5000L,
        };

        var response = await client.VolumeParticipationAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/algo/spot/newOrderVp", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("1", seen.Param("quantity"));
        Assert.Equal("LOW", seen.Param("urgency"));
        Assert.Equal("1", seen.Param("clientAlgoId"));
        Assert.Equal("5000", seen.Param("vpTimeLimit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task VolumeParticipationBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new VolumeParticipationRequest
        {
            Symbol = "BTCUSDT",
            Side = VolumeParticipationSide.Buy,
            Quantity = 1m,
            Urgency = VolumeParticipationUrgency.Low,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.VolumeParticipationAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
