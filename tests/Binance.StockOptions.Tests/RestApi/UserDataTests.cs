//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.StockOptions.RestApi;

namespace Binance.StockOptions.Tests.RestApi.UserData;

[Trait("Category", "Native")]
public class UserDataApiTests
{
    private static StockOptionsRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task CurrentOpenOptionOrdersAsync()
    {
        const string example = """""[{"orderId":"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71","clientOrderId":"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a","symbol":"NVDA260930C00100000","underlyingSymbol":"NVDA","rootSymbol":"NVDA","contractType":"CALL","strikePrice":"100","expirationDate":1790784000000,"multiplier":"100","positionIntent":"BUY_TO_OPEN","quoteAsset":"USDC","side":"BUY","orderType":"LIMIT","limitPrice":"1.5","qty":"1","filledQty":"0","filledNotional":"0","totalCost":"150.65","filledPercent":"0","status":"NEW","createdAt":1790173800000,"updatedAt":1790173800000}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.CurrentOpenOptionOrdersAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/order/open-orders", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CurrentOpenOptionOrdersWithOptionalParametersAsync()
    {
        const string example = """""[{"orderId":"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71","clientOrderId":"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a","symbol":"NVDA260930C00100000","underlyingSymbol":"NVDA","rootSymbol":"NVDA","contractType":"CALL","strikePrice":"100","expirationDate":1790784000000,"multiplier":"100","positionIntent":"BUY_TO_OPEN","quoteAsset":"USDC","side":"BUY","orderType":"LIMIT","limitPrice":"1.5","qty":"1","filledQty":"0","filledNotional":"0","totalCost":"150.65","filledPercent":"0","status":"NEW","createdAt":1790173800000,"updatedAt":1790173800000}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CurrentOpenOptionOrdersRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.CurrentOpenOptionOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/order/open-orders", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CurrentOpenOptionOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CurrentOpenOptionOrdersAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ExercisableOptionsAsync()
    {
        const string example = """""[{"symbol":"NVDA260930C00100000","underlyingSymbol":"NVDA","rootSymbol":"NVDA","contractType":"CALL","strikePrice":"100","expirationDate":1790784000000,"multiplier":"100","positionQty":"2","availableQty":"2","deliverables":[{"type":"EQUITY","symbol":"NVDA","amount":"100"}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.ExercisableOptionsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/exercise/exercisable", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ExercisableOptionsWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"NVDA260930C00100000","underlyingSymbol":"NVDA","rootSymbol":"NVDA","contractType":"CALL","strikePrice":"100","expirationDate":1790784000000,"multiplier":"100","positionQty":"2","availableQty":"2","deliverables":[{"type":"EQUITY","symbol":"NVDA","amount":"100"}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ExercisableOptionsRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.ExercisableOptionsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/exercise/exercisable", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ExercisableOptionsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ExercisableOptionsAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OptionExerciseDetailAsync()
    {
        const string example = """""{"tranId":1234567890,"clientOrderId":"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a","symbol":"NVDA260930C00100000","underlyingSymbol":"NVDA","rootSymbol":"NVDA","contractType":"CALL","strikePrice":"100","expirationDate":1790784000000,"requestedQty":"2","status":"SUCCESS","requestedTime":1790704800000,"updateTime":1790766761000,"optionEventId":"a7f3c2e1-4b5d-4e8f-9c0a-1b2c3d4e5f60","underlyingEventId":"c9d8e7f6-a5b4-4c3d-8e2f-1a0b9c8d7e6f","multiplier":"100","errorCode":"497505"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.OptionExerciseDetailAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/exercise/detail", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OptionExerciseDetailWithOptionalParametersAsync()
    {
        const string example = """""{"tranId":1234567890,"clientOrderId":"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a","symbol":"NVDA260930C00100000","underlyingSymbol":"NVDA","rootSymbol":"NVDA","contractType":"CALL","strikePrice":"100","expirationDate":1790784000000,"requestedQty":"2","status":"SUCCESS","requestedTime":1790704800000,"updateTime":1790766761000,"optionEventId":"a7f3c2e1-4b5d-4e8f-9c0a-1b2c3d4e5f60","underlyingEventId":"c9d8e7f6-a5b4-4c3d-8e2f-1a0b9c8d7e6f","multiplier":"100","errorCode":"497505"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OptionExerciseDetailRequest
        {
            TranId = 1234567890L,
            ClientOrderId = "web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a",
            RecvWindow = 5000L,
        };

        var response = await client.OptionExerciseDetailAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/exercise/detail", seen.Path);
        Assert.Equal("1234567890", seen.Param("tranId"));
        Assert.Equal("web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a", seen.Param("clientOrderId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OptionExerciseDetailBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OptionExerciseDetailAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OptionExerciseHistoryAsync()
    {
        const string example = """""{"total":1,"page":1,"size":20,"rows":[{"tranId":1234567890,"clientOrderId":"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a","symbol":"NVDA260930C00100000","underlyingSymbol":"NVDA","rootSymbol":"NVDA","contractType":"CALL","strikePrice":"100","expirationDate":1790784000000,"requestedQty":"2","status":"SUCCESS","requestedTime":1790704800000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.OptionExerciseHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/exercise/history", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OptionExerciseHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"total":1,"page":1,"size":20,"rows":[{"tranId":1234567890,"clientOrderId":"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a","symbol":"NVDA260930C00100000","underlyingSymbol":"NVDA","rootSymbol":"NVDA","contractType":"CALL","strikePrice":"100","expirationDate":1790784000000,"requestedQty":"2","status":"SUCCESS","requestedTime":1790704800000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OptionExerciseHistoryRequest
        {
            Status = "SUCCESS,FAILED",
            StartTime = 1790600000000L,
            EndTime = 1790800000000L,
            Current = 1L,
            Size = 20L,
            RecvWindow = 5000L,
        };

        var response = await client.OptionExerciseHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/exercise/history", seen.Path);
        Assert.Equal("SUCCESS,FAILED", seen.Param("status"));
        Assert.Equal("1790600000000", seen.Param("startTime"));
        Assert.Equal("1790800000000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("current"));
        Assert.Equal("20", seen.Param("size"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OptionExerciseHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OptionExerciseHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OptionOrderDetailAsync()
    {
        const string example = """""{"orderId":"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71","clientOrderId":"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a","symbol":"NVDA260930C00100000","underlyingSymbol":"NVDA","rootSymbol":"NVDA","contractType":"CALL","strikePrice":"100","expirationDate":1790784000000,"multiplier":"100","positionIntent":"BUY_TO_OPEN","autoLiquidation":false,"quote":"USDC","side":"BUY","orderType":"LIMIT","limitPrice":"1.5","avgFilledPrice":"1.48","qty":"1","filledQty":"1","filledTotal":"148","fee":"0.65","status":"FILLED","createdAt":1790173800000,"updatedAt":1790173802000,"timeInForce":"DAY","commission":"0.6","platformFee":"0","sec":"0","taf":"0","cat":"0.01","orf":"0.02","occ":"0.02","total":"148","filledAt":1790173802000,"canceledAt":1790173802000,"expiredAt":1790173802000,"settlementDate":1790272800000,"trades":[{"executionId":"8f2d0c1e-5b7a-4e3c-9d61-2a4b6c8e0f13","executionAt":1790173802000,"price":"1.48","qty":"1"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.OptionOrderDetailAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/order/detail", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OptionOrderDetailWithOptionalParametersAsync()
    {
        const string example = """""{"orderId":"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71","clientOrderId":"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a","symbol":"NVDA260930C00100000","underlyingSymbol":"NVDA","rootSymbol":"NVDA","contractType":"CALL","strikePrice":"100","expirationDate":1790784000000,"multiplier":"100","positionIntent":"BUY_TO_OPEN","autoLiquidation":false,"quote":"USDC","side":"BUY","orderType":"LIMIT","limitPrice":"1.5","avgFilledPrice":"1.48","qty":"1","filledQty":"1","filledTotal":"148","fee":"0.65","status":"FILLED","createdAt":1790173800000,"updatedAt":1790173802000,"timeInForce":"DAY","commission":"0.6","platformFee":"0","sec":"0","taf":"0","cat":"0.01","orf":"0.02","occ":"0.02","total":"148","filledAt":1790173802000,"canceledAt":1790173802000,"expiredAt":1790173802000,"settlementDate":1790272800000,"trades":[{"executionId":"8f2d0c1e-5b7a-4e3c-9d61-2a4b6c8e0f13","executionAt":1790173802000,"price":"1.48","qty":"1"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OptionOrderDetailRequest
        {
            OrderId = "c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71",
            ClientOrderId = "web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a",
            RecvWindow = 5000L,
        };

        var response = await client.OptionOrderDetailAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/order/detail", seen.Path);
        Assert.Equal("c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71", seen.Param("orderId"));
        Assert.Equal("web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a", seen.Param("clientOrderId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OptionOrderDetailBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OptionOrderDetailAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OptionOrderHistoryAsync()
    {
        const string example = """""{"total":1,"page":1,"size":20,"rows":[{"orderId":"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71","clientOrderId":"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a","symbol":"NVDA260930C00100000","underlyingSymbol":"NVDA","rootSymbol":"NVDA","contractType":"CALL","strikePrice":"100","expirationDate":1790784000000,"multiplier":"100","positionIntent":"BUY_TO_OPEN","autoLiquidation":false,"quote":"USDC","side":"BUY","orderType":"LIMIT","limitPrice":"1.5","avgFilledPrice":"1.48","qty":"1","filledQty":"1","filledTotal":"148","fee":"0.65","status":"FILLED","createdAt":1790173800000,"updatedAt":1790173802000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OptionOrderHistoryRequest
        {
            StartTime = 1790100000000L,
            EndTime = 1790200000000L,
        };

        var response = await client.OptionOrderHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/order/history", seen.Path);
        Assert.Equal("1790100000000", seen.Param("startTime"));
        Assert.Equal("1790200000000", seen.Param("endTime"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OptionOrderHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"total":1,"page":1,"size":20,"rows":[{"orderId":"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71","clientOrderId":"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a","symbol":"NVDA260930C00100000","underlyingSymbol":"NVDA","rootSymbol":"NVDA","contractType":"CALL","strikePrice":"100","expirationDate":1790784000000,"multiplier":"100","positionIntent":"BUY_TO_OPEN","autoLiquidation":false,"quote":"USDC","side":"BUY","orderType":"LIMIT","limitPrice":"1.5","avgFilledPrice":"1.48","qty":"1","filledQty":"1","filledTotal":"148","fee":"0.65","status":"FILLED","createdAt":1790173800000,"updatedAt":1790173802000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OptionOrderHistoryRequest
        {
            StartTime = 1790100000000L,
            EndTime = 1790200000000L,
            UnderlyingSymbol = "NVDA",
            Side = OptionOrderHistorySide.Buy,
            OrderStatus = "FILLED,CANCELED",
            Current = 1L,
            Size = 20L,
            RecvWindow = 5000L,
        };

        var response = await client.OptionOrderHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/order/history", seen.Path);
        Assert.Equal("1790100000000", seen.Param("startTime"));
        Assert.Equal("1790200000000", seen.Param("endTime"));
        Assert.Equal("NVDA", seen.Param("underlyingSymbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("FILLED,CANCELED", seen.Param("orderStatus"));
        Assert.Equal("1", seen.Param("current"));
        Assert.Equal("20", seen.Param("size"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OptionOrderHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new OptionOrderHistoryRequest
        {
            StartTime = 1790100000000L,
            EndTime = 1790200000000L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OptionOrderHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OptionPositionsAsync()
    {
        const string example = """""[{"symbol":"NVDA260930C00100000","underlyingSymbol":"NVDA","contractType":"CALL","side":"LONG","free":"2","locked":"1","strikePrice":"100","expirationDate":1790784000000,"multiplier":"100"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.OptionPositionsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/position", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OptionPositionsWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"NVDA260930C00100000","underlyingSymbol":"NVDA","contractType":"CALL","side":"LONG","free":"2","locked":"1","strikePrice":"100","expirationDate":1790784000000,"multiplier":"100"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OptionPositionsRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.OptionPositionsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/position", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OptionPositionsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OptionPositionsAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OptionSettlementEventDetailAsync()
    {
        const string example = """""{"eventId":"a7f3c2e1-4b5d-4e8f-9c0a-1b2c3d4e5f60","eventType":"EXERCISE","status":"Completed","symbol":"NVDA260930C00100000","underlyingSymbol":"NVDA","contractType":"CALL","contracts":"2","expirationDate":1790784000000,"strikePrice":"100","shareDelta":"200","deliverables":[{"type":"OPEXC","symbol":"USDC","amount":"-20000"}],"eventTime":1790766761000,"settlementKind":"PHYSICAL","underlyingPrice":"123.45","cashDirection":"DEBIT","amount":"20000","collateralRelease":[{"symbol":"USDC","amount":"9000"}],"updatedTime":1790766761000}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OptionSettlementEventDetailRequest
        {
            EventId = "a7f3c2e1-4b5d-4e8f-9c0a-1b2c3d4e5f60",
        };

        var response = await client.OptionSettlementEventDetailAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/event/detail", seen.Path);
        Assert.Equal("a7f3c2e1-4b5d-4e8f-9c0a-1b2c3d4e5f60", seen.Param("eventId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OptionSettlementEventDetailWithOptionalParametersAsync()
    {
        const string example = """""{"eventId":"a7f3c2e1-4b5d-4e8f-9c0a-1b2c3d4e5f60","eventType":"EXERCISE","status":"Completed","symbol":"NVDA260930C00100000","underlyingSymbol":"NVDA","contractType":"CALL","contracts":"2","expirationDate":1790784000000,"strikePrice":"100","shareDelta":"200","deliverables":[{"type":"OPEXC","symbol":"USDC","amount":"-20000"}],"eventTime":1790766761000,"settlementKind":"PHYSICAL","underlyingPrice":"123.45","cashDirection":"DEBIT","amount":"20000","collateralRelease":[{"symbol":"USDC","amount":"9000"}],"updatedTime":1790766761000}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OptionSettlementEventDetailRequest
        {
            EventId = "a7f3c2e1-4b5d-4e8f-9c0a-1b2c3d4e5f60",
            RecvWindow = 5000L,
        };

        var response = await client.OptionSettlementEventDetailAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/event/detail", seen.Path);
        Assert.Equal("a7f3c2e1-4b5d-4e8f-9c0a-1b2c3d4e5f60", seen.Param("eventId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OptionSettlementEventDetailBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new OptionSettlementEventDetailRequest
        {
            EventId = "a7f3c2e1-4b5d-4e8f-9c0a-1b2c3d4e5f60",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OptionSettlementEventDetailAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OptionSettlementEventHistoryAsync()
    {
        const string example = """""{"rows":[{"eventId":"a7f3c2e1-4b5d-4e8f-9c0a-1b2c3d4e5f60","eventType":"EXERCISE","status":"Completed","symbol":"NVDA260930C00100000","underlyingSymbol":"NVDA","contractType":"CALL","contracts":"2","expirationDate":1790784000000,"strikePrice":"100","shareDelta":"200","deliverables":[{"type":"OPEXC","symbol":"USDC","amount":"-20000"}],"eventTime":1790766760000}],"hasMore":false,"nextLastId":10086}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.OptionSettlementEventHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/event/history", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OptionSettlementEventHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"eventId":"a7f3c2e1-4b5d-4e8f-9c0a-1b2c3d4e5f60","eventType":"EXERCISE","status":"Completed","symbol":"NVDA260930C00100000","underlyingSymbol":"NVDA","contractType":"CALL","contracts":"2","expirationDate":1790784000000,"strikePrice":"100","shareDelta":"200","deliverables":[{"type":"OPEXC","symbol":"USDC","amount":"-20000"}],"eventTime":1790766760000}],"hasMore":false,"nextLastId":10086}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OptionSettlementEventHistoryRequest
        {
            UnderlyingSymbol = "NVDA",
            Symbol = "NVDA260930C00100000",
            EventType = "EXERCISE,ASSIGNMENT",
            StartTime = 1790700000000L,
            EndTime = 1790900000000L,
            LastId = 10086L,
            Size = 20L,
            RecvWindow = 5000L,
        };

        var response = await client.OptionSettlementEventHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/event/history", seen.Path);
        Assert.Equal("NVDA", seen.Param("underlyingSymbol"));
        Assert.Equal("NVDA260930C00100000", seen.Param("symbol"));
        Assert.Equal("EXERCISE,ASSIGNMENT", seen.Param("eventType"));
        Assert.Equal("1790700000000", seen.Param("startTime"));
        Assert.Equal("1790900000000", seen.Param("endTime"));
        Assert.Equal("10086", seen.Param("lastId"));
        Assert.Equal("20", seen.Param("size"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OptionSettlementEventHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OptionSettlementEventHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OptionTradeHistoryAsync()
    {
        const string example = """""{"total":1,"page":1,"size":20,"rows":[{"executionId":"8f2d0c1e-5b7a-4e3c-9d61-2a4b6c8e0f13","orderId":"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71","clientOrderId":"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a","symbol":"NVDA260930C00100000","underlyingSymbol":"NVDA","rootSymbol":"NVDA","contractType":"CALL","strikePrice":"100","expirationDate":1790784000000,"multiplier":"100","positionIntent":"BUY_TO_OPEN","autoLiquidation":false,"quote":"USDC","side":"BUY","orderType":"LIMIT","price":"1.48","qty":"1","total":"148","executionAt":1790173802000,"updatedAt":1790173802000,"settlementDate":1790272800000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OptionTradeHistoryRequest
        {
            StartTime = 1790100000000L,
            EndTime = 1790200000000L,
        };

        var response = await client.OptionTradeHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/trade/history", seen.Path);
        Assert.Equal("1790100000000", seen.Param("startTime"));
        Assert.Equal("1790200000000", seen.Param("endTime"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OptionTradeHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"total":1,"page":1,"size":20,"rows":[{"executionId":"8f2d0c1e-5b7a-4e3c-9d61-2a4b6c8e0f13","orderId":"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71","clientOrderId":"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a","symbol":"NVDA260930C00100000","underlyingSymbol":"NVDA","rootSymbol":"NVDA","contractType":"CALL","strikePrice":"100","expirationDate":1790784000000,"multiplier":"100","positionIntent":"BUY_TO_OPEN","autoLiquidation":false,"quote":"USDC","side":"BUY","orderType":"LIMIT","price":"1.48","qty":"1","total":"148","executionAt":1790173802000,"updatedAt":1790173802000,"settlementDate":1790272800000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OptionTradeHistoryRequest
        {
            StartTime = 1790100000000L,
            EndTime = 1790200000000L,
            UnderlyingSymbol = "NVDA",
            Side = OptionTradeHistorySide.Buy,
            OrderId = "c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71",
            Current = 1L,
            Size = 20L,
            RecvWindow = 5000L,
        };

        var response = await client.OptionTradeHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/trade/history", seen.Path);
        Assert.Equal("1790100000000", seen.Param("startTime"));
        Assert.Equal("1790200000000", seen.Param("endTime"));
        Assert.Equal("NVDA", seen.Param("underlyingSymbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71", seen.Param("orderId"));
        Assert.Equal("1", seen.Param("current"));
        Assert.Equal("20", seen.Param("size"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OptionTradeHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new OptionTradeHistoryRequest
        {
            StartTime = 1790100000000L,
            EndTime = 1790200000000L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OptionTradeHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
