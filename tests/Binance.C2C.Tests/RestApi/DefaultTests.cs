//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.C2C.RestApi;

namespace Binance.C2C.Tests.RestApi;

[Trait("Category", "Native")]
public class DefaultApiTests
{
    private static C2CRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task GetC2CTradeHistoryAsync()
    {
        const string example = """""{"code":"000000","message":"success","data":[{"orderNumber":"20219644646554779648","advNo":"11218246497340923904","tradeType":"SELL","asset":"BUSD","fiat":"CNY","fiatSymbol":"￥","amount":"5000.00000000","totalPrice":"33400.00000000","unitPrice":"6.68","orderStatus":"COMPLETED","createTime":1619361369000,"commission":"0","counterPartNickName":"阿涛❤***","payMethodName":"BANK","additionalKycVerify":0,"takerCommissionRate":"0","takerCommission":"0","takerAmount":"343.4","advertisementRole":"TAKER"}],"total":1,"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetC2CTradeHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/c2c/orderMatch/listUserOrderHistory", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetC2CTradeHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"code":"000000","message":"success","data":[{"orderNumber":"20219644646554779648","advNo":"11218246497340923904","tradeType":"SELL","asset":"BUSD","fiat":"CNY","fiatSymbol":"￥","amount":"5000.00000000","totalPrice":"33400.00000000","unitPrice":"6.68","orderStatus":"COMPLETED","createTime":1619361369000,"commission":"0","counterPartNickName":"阿涛❤***","payMethodName":"BANK","additionalKycVerify":0,"takerCommissionRate":"0","takerCommission":"0","takerAmount":"343.4","advertisementRole":"TAKER"}],"total":1,"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetC2CTradeHistoryRequest
        {
            TradeType = GetC2CTradeHistoryTradeType.Buy,
            StartTimestamp = 1770736694138L,
            EndTimestamp = 1770736694138L,
            Page = 1L,
            Rows = 100L,
        };

        var response = await client.GetC2CTradeHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/c2c/orderMatch/listUserOrderHistory", seen.Path);
        Assert.Equal("BUY", seen.Param("tradeType"));
        Assert.Equal("1770736694138", seen.Param("startTimestamp"));
        Assert.Equal("1770736694138", seen.Param("endTimestamp"));
        Assert.Equal("1", seen.Param("page"));
        Assert.Equal("100", seen.Param("rows"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetC2CTradeHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetC2CTradeHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
