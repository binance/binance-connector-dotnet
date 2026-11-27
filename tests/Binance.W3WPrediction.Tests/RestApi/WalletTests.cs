//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.W3WPrediction.RestApi;

namespace Binance.W3WPrediction.Tests.RestApi.Wallet;

[Trait("Category", "Native")]
public class WalletApiTests
{
    private static W3WPredictionRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task GetPortfolioAsync()
    {
        const string example = """""{"chainId":"56","walletAddress":"0x12e32db8817e292508c34111cbc4b23340df542c","activePositionsCount":3,"totalRealizedPnl":"120.50","totalUnrealizedPnl":"15.30","totalPnl":"135.80","totalCostBasis":"450.00","totalCurrentValue":"465.30","positions":[{"id":10001,"walletAddress":"0x12e32db8817e292508c34111cbc4b23340df542c","marketTopicId":4229564,"marketId":5567895,"tokenId":"112233","vendor":"PREDICT_FUN","currentShares":"1923.07","avgPrice":"0.52","currentPrice":"0.55","realizedPnl":"0.00","unrealizedPnl":"0.06","totalPnl":"0.06","pnlPercentage":"6.00","isResolved":false}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetPortfolioRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
        };

        var response = await client.GetPortfolioAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/pnl/portfolio", seen.Path);
        Assert.Equal("0x12e32db8817e292508c34111cbc4b23340df542c", seen.Param("walletAddress"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetPortfolioWithOptionalParametersAsync()
    {
        const string example = """""{"chainId":"56","walletAddress":"0x12e32db8817e292508c34111cbc4b23340df542c","activePositionsCount":3,"totalRealizedPnl":"120.50","totalUnrealizedPnl":"15.30","totalPnl":"135.80","totalCostBasis":"450.00","totalCurrentValue":"465.30","positions":[{"id":10001,"walletAddress":"0x12e32db8817e292508c34111cbc4b23340df542c","marketTopicId":4229564,"marketId":5567895,"tokenId":"112233","vendor":"PREDICT_FUN","currentShares":"1923.07","avgPrice":"0.52","currentPrice":"0.55","realizedPnl":"0.00","unrealizedPnl":"0.06","totalPnl":"0.06","pnlPercentage":"6.00","isResolved":false}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetPortfolioRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            TokenId = "112233",
            MarketId = 5567895L,
            MarketTopicId = 4229564L,
            ActiveOnly = false,
            RecvWindow = 5000L,
        };

        var response = await client.GetPortfolioAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/pnl/portfolio", seen.Path);
        Assert.Equal("0x12e32db8817e292508c34111cbc4b23340df542c", seen.Param("walletAddress"));
        Assert.Equal("112233", seen.Param("tokenId"));
        Assert.Equal("5567895", seen.Param("marketId"));
        Assert.Equal("4229564", seen.Param("marketTopicId"));
        Assert.Equal("false", seen.Param("activeOnly"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetPortfolioBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetPortfolioRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetPortfolioAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetQuotaStatusAsync()
    {
        const string example = """""{"dailyLimit":"10000.00","remainingDailyLimit":"8500.00"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetQuotaStatusAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/quota/limit/status", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetQuotaStatusWithOptionalParametersAsync()
    {
        const string example = """""{"dailyLimit":"10000.00","remainingDailyLimit":"8500.00"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetQuotaStatusRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetQuotaStatusAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/quota/limit/status", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetQuotaStatusBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetQuotaStatusAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ListPredictionWalletsAsync()
    {
        const string example = """""{"wallets":[{"walletAddress":"0x12e32db8817e292508c34111cbc4b23340df542c","walletId":"5b5c1ec3be4e4416a5872b21c1ca5d20","registeredTime":1748000000000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.ListPredictionWalletsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/wallet/list", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ListPredictionWalletsWithOptionalParametersAsync()
    {
        const string example = """""{"wallets":[{"walletAddress":"0x12e32db8817e292508c34111cbc4b23340df542c","walletId":"5b5c1ec3be4e4416a5872b21c1ca5d20","registeredTime":1748000000000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ListPredictionWalletsRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.ListPredictionWalletsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/wallet/list", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ListPredictionWalletsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ListPredictionWalletsAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryPaymentOptionBalancesAsync()
    {
        const string example = """""{"items":[{"accountType":"SPOT","availableBalanceDisplay":"1000.00","enabled":true}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryPaymentOptionBalancesAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/balance/payment-options", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryPaymentOptionBalancesWithOptionalParametersAsync()
    {
        const string example = """""{"items":[{"accountType":"SPOT","availableBalanceDisplay":"1000.00","enabled":true}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryPaymentOptionBalancesRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.QueryPaymentOptionBalancesAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/balance/payment-options", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryPaymentOptionBalancesBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryPaymentOptionBalancesAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
