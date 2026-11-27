//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.DualInvestment.RestApi;

namespace Binance.DualInvestment.Tests.RestApi.Trade;

[Trait("Category", "Native")]
public class TradeApiTests
{
    private static DualInvestmentRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task CheckDualInvestmentAccountsAsync()
    {
        const string example = """""{"totalAmountInBTC":"0.01067982","totalAmountInUSDT":"77.13289230"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.CheckDualInvestmentAccountsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/dci/product/accounts", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CheckDualInvestmentAccountsWithOptionalParametersAsync()
    {
        const string example = """""{"totalAmountInBTC":"0.01067982","totalAmountInUSDT":"77.13289230"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CheckDualInvestmentAccountsRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.CheckDualInvestmentAccountsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/dci/product/accounts", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CheckDualInvestmentAccountsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CheckDualInvestmentAccountsAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetDualInvestmentPositionsAsync()
    {
        const string example = """""{"total":1,"list":[{"id":"10160533","investCoin":"USDT","exercisedCoin":"BNB","subscriptionAmount":"0.5","strikePrice":"330","duration":4,"settleDate":1708416000000,"purchaseStatus":"PURCHASE_SUCCESS","apr":"0.0365","orderId":7973677530,"purchaseEndTime":1708329600000,"optionType":"PUT","autoCompoundPlan":"STANDARD","subscriptionTime":1708243200000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetDualInvestmentPositionsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/dci/product/positions", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDualInvestmentPositionsWithOptionalParametersAsync()
    {
        const string example = """""{"total":1,"list":[{"id":"10160533","investCoin":"USDT","exercisedCoin":"BNB","subscriptionAmount":"0.5","strikePrice":"330","duration":4,"settleDate":1708416000000,"purchaseStatus":"PURCHASE_SUCCESS","apr":"0.0365","orderId":7973677530,"purchaseEndTime":1708329600000,"optionType":"PUT","autoCompoundPlan":"STANDARD","subscriptionTime":1708243200000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDualInvestmentPositionsRequest
        {
            Status = GetDualInvestmentPositionsStatus.Pending,
            PageSize = 10L,
            PageIndex = 1L,
            RecvWindow = 5000L,
        };

        var response = await client.GetDualInvestmentPositionsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/dci/product/positions", seen.Path);
        Assert.Equal("PENDING", seen.Param("status"));
        Assert.Equal("10", seen.Param("pageSize"));
        Assert.Equal("1", seen.Param("pageIndex"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDualInvestmentPositionsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetDualInvestmentPositionsAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SubscribeDualInvestmentProductsAsync()
    {
        const string example = """""{"positionId":10208824,"investCoin":"BNB","exercisedCoin":"USDT","subscriptionAmount":"0.002","duration":4,"autoCompoundPlan":"STANDARD","strikePrice":"380","settleDate":1709020800000,"purchaseStatus":"PURCHASE_SUCCESS","apr":"0.7397","orderId":8259117597,"purchaseTime":1708677583874,"optionType":"CALL"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SubscribeDualInvestmentProductsRequest
        {
            Id = "741590",
            OrderId = "8257205859",
            DepositAmount = 1m,
        };

        var response = await client.SubscribeDualInvestmentProductsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/dci/product/subscribe", seen.Path);
        Assert.Equal("741590", seen.Param("id"));
        Assert.Equal("8257205859", seen.Param("orderId"));
        Assert.Equal("1", seen.Param("depositAmount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SubscribeDualInvestmentProductsWithOptionalParametersAsync()
    {
        const string example = """""{"positionId":10208824,"investCoin":"BNB","exercisedCoin":"USDT","subscriptionAmount":"0.002","duration":4,"autoCompoundPlan":"STANDARD","strikePrice":"380","settleDate":1709020800000,"purchaseStatus":"PURCHASE_SUCCESS","apr":"0.7397","orderId":8259117597,"purchaseTime":1708677583874,"optionType":"CALL"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SubscribeDualInvestmentProductsRequest
        {
            Id = "741590",
            OrderId = "8257205859",
            DepositAmount = 1m,
            RecvWindow = 5000L,
        };

        var response = await client.SubscribeDualInvestmentProductsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/dci/product/subscribe", seen.Path);
        Assert.Equal("741590", seen.Param("id"));
        Assert.Equal("8257205859", seen.Param("orderId"));
        Assert.Equal("1", seen.Param("depositAmount"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SubscribeDualInvestmentProductsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new SubscribeDualInvestmentProductsRequest
        {
            Id = "741590",
            OrderId = "8257205859",
            DepositAmount = 1m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SubscribeDualInvestmentProductsAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
