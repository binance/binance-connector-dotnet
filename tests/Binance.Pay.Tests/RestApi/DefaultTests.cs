//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.Pay.RestApi;

namespace Binance.Pay.Tests.RestApi;

[Trait("Category", "Native")]
public class DefaultApiTests
{
    private static PayRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task GetPayTradeHistoryAsync()
    {
        const string example = """""{"code":"000000","message":"success","data":[{"orderType":"C2C","transactionId":"M_P_71505104267788288","transactionTime":1610090460133,"amount":"23.72469206","currency":"BNB","walletType":1,"walletTypes":[1],"fundsDetail":[{"currency":"USDT","amount":"1.2","walletAssetCost":{"1":"0.6","2":"0.6"}}],"payerInfo":{"name":"Jack","type":"USER","binanceId":"12345678"},"receiverInfo":{"name":"Alan","type":"MERCHANT","email":"alan@binance.com","binanceId":"34355667","accountId":"21326891","countryCode":"1","phoneNumber":"8057651210","mobileCode":"US","extend":{"institutionName":"","cardNumber":"","digitalWalletId":""}}}],"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetPayTradeHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/pay/transactions", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetPayTradeHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"code":"000000","message":"success","data":[{"orderType":"C2C","transactionId":"M_P_71505104267788288","transactionTime":1610090460133,"amount":"23.72469206","currency":"BNB","walletType":1,"walletTypes":[1],"fundsDetail":[{"currency":"USDT","amount":"1.2","walletAssetCost":{"1":"0.6","2":"0.6"}}],"payerInfo":{"name":"Jack","type":"USER","binanceId":"12345678"},"receiverInfo":{"name":"Alan","type":"MERCHANT","email":"alan@binance.com","binanceId":"34355667","accountId":"21326891","countryCode":"1","phoneNumber":"8057651210","mobileCode":"US","extend":{"institutionName":"","cardNumber":"","digitalWalletId":""}}}],"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetPayTradeHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 100L,
            RecvWindow = 5000L,
        };

        var response = await client.GetPayTradeHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/pay/transactions", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("100", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetPayTradeHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetPayTradeHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
