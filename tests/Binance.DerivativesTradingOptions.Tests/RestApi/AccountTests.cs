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

namespace Binance.DerivativesTradingOptions.Tests.RestApi.Account;

[Trait("Category", "Native")]
public class AccountApiTests
{
    private static DerivativesTradingOptionsRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task AccountFundingFlowAsync()
    {
        const string example = """""[{"id":1125899906842624000,"asset":"USDT","amount":"-0.552","symbol":"BTC-200730-9000-C","type":"FEE","createDate":1592449456000}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AccountFundingFlowRequest
        {
            Currency = AccountFundingFlowCurrency.Usdt,
        };

        var response = await client.AccountFundingFlowAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/bill", seen.Path);
        Assert.Equal("USDT", seen.Param("currency"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AccountFundingFlowWithOptionalParametersAsync()
    {
        const string example = """""[{"id":1125899906842624000,"asset":"USDT","amount":"-0.552","symbol":"BTC-200730-9000-C","type":"FEE","createDate":1592449456000}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AccountFundingFlowRequest
        {
            Currency = AccountFundingFlowCurrency.Usdt,
            RecordId = 100000L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 20L,
            RecvWindow = 5000L,
        };

        var response = await client.AccountFundingFlowAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/bill", seen.Path);
        Assert.Equal("USDT", seen.Param("currency"));
        Assert.Equal("100000", seen.Param("recordId"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("20", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AccountFundingFlowBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new AccountFundingFlowRequest
        {
            Currency = AccountFundingFlowCurrency.Usdt,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AccountFundingFlowAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OptionMarginAccountInformationAsync()
    {
        const string example = """""{"asset":[{"asset":"USDT","marginBalance":"10099.448","equity":"10094.44662","available":"8725.92524","initialMargin":"1084.52138","maintMargin":"151.00138","unrealizedPNL":"-5.00138","adjustedEquity":"34.13282285"}],"greek":[{"underlying":"BTCUSDT","delta":"-0.05","gamma":"-0.002","theta":"-0.05","vega":"-0.002"}],"time":1762843368098,"canTrade":true,"canDeposit":true,"canWithdraw":true,"reduceOnly":false,"tradeGroupId":-1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.OptionMarginAccountInformationAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/marginAccount", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OptionMarginAccountInformationWithOptionalParametersAsync()
    {
        const string example = """""{"asset":[{"asset":"USDT","marginBalance":"10099.448","equity":"10094.44662","available":"8725.92524","initialMargin":"1084.52138","maintMargin":"151.00138","unrealizedPNL":"-5.00138","adjustedEquity":"34.13282285"}],"greek":[{"underlying":"BTCUSDT","delta":"-0.05","gamma":"-0.002","theta":"-0.05","vega":"-0.002"}],"time":1762843368098,"canTrade":true,"canDeposit":true,"canWithdraw":true,"reduceOnly":false,"tradeGroupId":-1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OptionMarginAccountInformationRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.OptionMarginAccountInformationAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/marginAccount", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OptionMarginAccountInformationBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OptionMarginAccountInformationAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
