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

namespace Binance.DualInvestment.Tests.RestApi.MarketData;

[Trait("Category", "Native")]
public class MarketDataApiTests
{
    private static DualInvestmentRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task GetDualInvestmentProductListAsync()
    {
        const string example = """""{"total":1,"list":[{"id":"741590","investCoin":"USDT","exercisedCoin":"BNB","strikePrice":"380","duration":4,"settleDate":1709020800000,"purchaseDecimal":8,"purchaseEndTime":1708934400000,"canPurchase":true,"apr":"0.6076","orderId":8257205859,"minAmount":"0.1","maxAmount":"25265.7","createTimestamp":1708560084000,"optionType":"PUT","isAutoCompoundEnable":true,"autoCompoundPlanList":["STANDARD","ADVANCE"]}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDualInvestmentProductListRequest
        {
            OptionType = GetDualInvestmentProductListOptionType.Call,
            ExercisedCoin = "USDT",
            InvestCoin = "BNB",
        };

        var response = await client.GetDualInvestmentProductListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/dci/product/list", seen.Path);
        Assert.Equal("CALL", seen.Param("optionType"));
        Assert.Equal("USDT", seen.Param("exercisedCoin"));
        Assert.Equal("BNB", seen.Param("investCoin"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDualInvestmentProductListWithOptionalParametersAsync()
    {
        const string example = """""{"total":1,"list":[{"id":"741590","investCoin":"USDT","exercisedCoin":"BNB","strikePrice":"380","duration":4,"settleDate":1709020800000,"purchaseDecimal":8,"purchaseEndTime":1708934400000,"canPurchase":true,"apr":"0.6076","orderId":8257205859,"minAmount":"0.1","maxAmount":"25265.7","createTimestamp":1708560084000,"optionType":"PUT","isAutoCompoundEnable":true,"autoCompoundPlanList":["STANDARD","ADVANCE"]}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDualInvestmentProductListRequest
        {
            OptionType = GetDualInvestmentProductListOptionType.Call,
            ExercisedCoin = "USDT",
            InvestCoin = "BNB",
            PageSize = 10L,
            PageIndex = 1L,
            RecvWindow = 5000L,
        };

        var response = await client.GetDualInvestmentProductListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/dci/product/list", seen.Path);
        Assert.Equal("CALL", seen.Param("optionType"));
        Assert.Equal("USDT", seen.Param("exercisedCoin"));
        Assert.Equal("BNB", seen.Param("investCoin"));
        Assert.Equal("10", seen.Param("pageSize"));
        Assert.Equal("1", seen.Param("pageIndex"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDualInvestmentProductListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetDualInvestmentProductListRequest
        {
            OptionType = GetDualInvestmentProductListOptionType.Call,
            ExercisedCoin = "USDT",
            InvestCoin = "BNB",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetDualInvestmentProductListAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
