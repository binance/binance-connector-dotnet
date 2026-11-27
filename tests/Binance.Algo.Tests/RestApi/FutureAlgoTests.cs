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

namespace Binance.Algo.Tests.RestApi.FutureAlgo;

[Trait("Category", "Native")]
public class FutureAlgoApiTests
{
    private static AlgoRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task CancelAlgoOrderFutureAlgoAsync()
    {
        const string example = """""{"algoId":14511,"success":true,"code":0,"msg":"OK"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.CancelAlgoOrderFutureAlgoAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/sapi/v1/algo/futures/order", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelAlgoOrderFutureAlgoWithOptionalParametersAsync()
    {
        const string example = """""{"algoId":14511,"success":true,"code":0,"msg":"OK"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelAlgoOrderFutureAlgoRequest
        {
            AlgoId = 1L,
            ClientAlgoId = "65ce1630101a480b85915d7e11fd5078",
            RecvWindow = 5000L,
        };

        var response = await client.CancelAlgoOrderFutureAlgoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/sapi/v1/algo/futures/order", seen.Path);
        Assert.Equal("1", seen.Param("algoId"));
        Assert.Equal("65ce1630101a480b85915d7e11fd5078", seen.Param("clientAlgoId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelAlgoOrderFutureAlgoBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CancelAlgoOrderFutureAlgoAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryCurrentAlgoOpenOrdersFutureAlgoAsync()
    {
        const string example = """""{"total":1,"orders":[{"algoId":14517,"symbol":"ETHUSDT","side":"SELL","positionSide":"SHORT","totalQty":"5.000","executedQty":"0.000","executedAmt":"0.00000000","avgPrice":"0.00","clientAlgoId":"d7096549481642f8a0bb69e9e2e31f2e","bookTime":1649756817004,"endTime":0,"algoStatus":"WORKING","algoType":"VP","urgency":"LOW"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryCurrentAlgoOpenOrdersFutureAlgoAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/algo/futures/openOrders", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCurrentAlgoOpenOrdersFutureAlgoWithOptionalParametersAsync()
    {
        const string example = """""{"total":1,"orders":[{"algoId":14517,"symbol":"ETHUSDT","side":"SELL","positionSide":"SHORT","totalQty":"5.000","executedQty":"0.000","executedAmt":"0.00000000","avgPrice":"0.00","clientAlgoId":"d7096549481642f8a0bb69e9e2e31f2e","bookTime":1649756817004,"endTime":0,"algoStatus":"WORKING","algoType":"VP","urgency":"LOW"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryCurrentAlgoOpenOrdersFutureAlgoRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.QueryCurrentAlgoOpenOrdersFutureAlgoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/algo/futures/openOrders", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCurrentAlgoOpenOrdersFutureAlgoBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryCurrentAlgoOpenOrdersFutureAlgoAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryHistoricalAlgoOrdersFutureAlgoAsync()
    {
        const string example = """""{"total":1,"orders":[{"algoId":14518,"symbol":"BNBUSDT","side":"BUY","positionSide":"BOTH","totalQty":"100.00","executedQty":"0.00","executedAmt":"0.00000000","avgPrice":"0.000","clientAlgoId":"acacab56b3c44bef9f6a8f8ebd2a8408","bookTime":1649757019503,"endTime":1649757088101,"algoStatus":"CANCELLED","algoType":"VP","urgency":"LOW"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryHistoricalAlgoOrdersFutureAlgoAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/algo/futures/historicalOrders", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryHistoricalAlgoOrdersFutureAlgoWithOptionalParametersAsync()
    {
        const string example = """""{"total":1,"orders":[{"algoId":14518,"symbol":"BNBUSDT","side":"BUY","positionSide":"BOTH","totalQty":"100.00","executedQty":"0.00","executedAmt":"0.00000000","avgPrice":"0.000","clientAlgoId":"acacab56b3c44bef9f6a8f8ebd2a8408","bookTime":1649757019503,"endTime":1649757088101,"algoStatus":"CANCELLED","algoType":"VP","urgency":"LOW"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryHistoricalAlgoOrdersFutureAlgoRequest
        {
            Symbol = "BTCUSDT",
            Side = QueryHistoricalAlgoOrdersFutureAlgoSide.Buy,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Page = 1L,
            PageSize = 100L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryHistoricalAlgoOrdersFutureAlgoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/algo/futures/historicalOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("page"));
        Assert.Equal("100", seen.Param("pageSize"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryHistoricalAlgoOrdersFutureAlgoBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryHistoricalAlgoOrdersFutureAlgoAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QuerySubOrdersFutureAlgoAsync()
    {
        const string example = """""{"total":1,"executedQty":"1.000","executedAmt":"3229.44000000","subOrders":[{"algoId":13723,"orderId":8389765519993909000,"orderStatus":"FILLED","executedQty":"1.000","executedAmt":"3229.44000000","feeAmt":"-1.61471999","feeAsset":"USDT","bookTime":1649319001964,"avgPrice":"3229.44","side":"SELL","symbol":"ETHUSDT","subId":1,"timeInForce":"IMMEDIATE_OR_CANCEL","origQty":"1.000"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QuerySubOrdersFutureAlgoRequest
        {
            AlgoId = 1L,
        };

        var response = await client.QuerySubOrdersFutureAlgoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/algo/futures/subOrders", seen.Path);
        Assert.Equal("1", seen.Param("algoId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QuerySubOrdersFutureAlgoWithOptionalParametersAsync()
    {
        const string example = """""{"total":1,"executedQty":"1.000","executedAmt":"3229.44000000","subOrders":[{"algoId":13723,"orderId":8389765519993909000,"orderStatus":"FILLED","executedQty":"1.000","executedAmt":"3229.44000000","feeAmt":"-1.61471999","feeAsset":"USDT","bookTime":1649319001964,"avgPrice":"3229.44","side":"SELL","symbol":"ETHUSDT","subId":1,"timeInForce":"IMMEDIATE_OR_CANCEL","origQty":"1.000"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QuerySubOrdersFutureAlgoRequest
        {
            AlgoId = 1L,
            Page = 1L,
            PageSize = 100L,
            RecvWindow = 5000L,
        };

        var response = await client.QuerySubOrdersFutureAlgoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/algo/futures/subOrders", seen.Path);
        Assert.Equal("1", seen.Param("algoId"));
        Assert.Equal("1", seen.Param("page"));
        Assert.Equal("100", seen.Param("pageSize"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QuerySubOrdersFutureAlgoBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QuerySubOrdersFutureAlgoRequest
        {
            AlgoId = 1L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QuerySubOrdersFutureAlgoAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TimeWeightedAveragePriceFutureAlgoAsync()
    {
        const string example = """""{"clientAlgoId":"65ce1630101a480b85915d7e11fd5078","success":true,"code":0,"msg":"OK"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TimeWeightedAveragePriceFutureAlgoRequest
        {
            Symbol = "BTCUSDT",
            Side = TimeWeightedAveragePriceFutureAlgoSide.Buy,
            Quantity = 1m,
            Duration = 5000L,
        };

        var response = await client.TimeWeightedAveragePriceFutureAlgoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/algo/futures/newOrderTwap", seen.Path);
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
    public async Task TimeWeightedAveragePriceFutureAlgoWithOptionalParametersAsync()
    {
        const string example = """""{"clientAlgoId":"65ce1630101a480b85915d7e11fd5078","success":true,"code":0,"msg":"OK"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TimeWeightedAveragePriceFutureAlgoRequest
        {
            Symbol = "BTCUSDT",
            Side = TimeWeightedAveragePriceFutureAlgoSide.Buy,
            Quantity = 1m,
            Duration = 5000L,
            PositionSide = TimeWeightedAveragePriceFutureAlgoPositionSide.Both,
            ClientAlgoId = "1",
            ReduceOnly = false,
            LimitPrice = 1m,
            RecvWindow = 5000L,
        };

        var response = await client.TimeWeightedAveragePriceFutureAlgoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/algo/futures/newOrderTwap", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("1", seen.Param("quantity"));
        Assert.Equal("5000", seen.Param("duration"));
        Assert.Equal("BOTH", seen.Param("positionSide"));
        Assert.Equal("1", seen.Param("clientAlgoId"));
        Assert.Equal("false", seen.Param("reduceOnly"));
        Assert.Equal("1", seen.Param("limitPrice"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TimeWeightedAveragePriceFutureAlgoBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new TimeWeightedAveragePriceFutureAlgoRequest
        {
            Symbol = "BTCUSDT",
            Side = TimeWeightedAveragePriceFutureAlgoSide.Buy,
            Quantity = 1m,
            Duration = 5000L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.TimeWeightedAveragePriceFutureAlgoAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task VolumeParticipationFutureAlgoAsync()
    {
        const string example = """""{"clientAlgoId":"00358ce6a268403398bd34eaa36dffe7","success":true,"code":0,"msg":"OK"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new VolumeParticipationFutureAlgoRequest
        {
            Symbol = "BTCUSDT",
            Side = VolumeParticipationFutureAlgoSide.Buy,
            Quantity = 1m,
            Urgency = VolumeParticipationFutureAlgoUrgency.Low,
        };

        var response = await client.VolumeParticipationFutureAlgoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/algo/futures/newOrderVp", seen.Path);
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
    public async Task VolumeParticipationFutureAlgoWithOptionalParametersAsync()
    {
        const string example = """""{"clientAlgoId":"00358ce6a268403398bd34eaa36dffe7","success":true,"code":0,"msg":"OK"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new VolumeParticipationFutureAlgoRequest
        {
            Symbol = "BTCUSDT",
            Side = VolumeParticipationFutureAlgoSide.Buy,
            Quantity = 1m,
            Urgency = VolumeParticipationFutureAlgoUrgency.Low,
            PositionSide = VolumeParticipationFutureAlgoPositionSide.Both,
            ClientAlgoId = "1",
            ReduceOnly = false,
            LimitPrice = 1m,
            RecvWindow = 5000L,
        };

        var response = await client.VolumeParticipationFutureAlgoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/algo/futures/newOrderVp", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("1", seen.Param("quantity"));
        Assert.Equal("LOW", seen.Param("urgency"));
        Assert.Equal("BOTH", seen.Param("positionSide"));
        Assert.Equal("1", seen.Param("clientAlgoId"));
        Assert.Equal("false", seen.Param("reduceOnly"));
        Assert.Equal("1", seen.Param("limitPrice"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task VolumeParticipationFutureAlgoBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new VolumeParticipationFutureAlgoRequest
        {
            Symbol = "BTCUSDT",
            Side = VolumeParticipationFutureAlgoSide.Buy,
            Quantity = 1m,
            Urgency = VolumeParticipationFutureAlgoUrgency.Low,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.VolumeParticipationFutureAlgoAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
