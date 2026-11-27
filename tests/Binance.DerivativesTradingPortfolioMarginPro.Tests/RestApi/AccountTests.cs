//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.DerivativesTradingPortfolioMarginPro.RestApi;

namespace Binance.DerivativesTradingPortfolioMarginPro.Tests.RestApi.Account;

[Trait("Category", "Native")]
public class AccountApiTests
{
    private static DerivativesTradingPortfolioMarginProRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task BnbTransferAsync()
    {
        const string example = """""{"tranId":100000001}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new BnbTransferRequest
        {
            Amount = 1.0m,
            TransferSide = BnbTransferTransferSide.ToUm,
        };

        var response = await client.BnbTransferAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/bnb-transfer", seen.Path);
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("TO_UM", seen.Param("transferSide"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task BnbTransferWithOptionalParametersAsync()
    {
        const string example = """""{"tranId":100000001}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new BnbTransferRequest
        {
            Amount = 1.0m,
            TransferSide = BnbTransferTransferSide.ToUm,
            RecvWindow = 5000L,
        };

        var response = await client.BnbTransferAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/bnb-transfer", seen.Path);
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("TO_UM", seen.Param("transferSide"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task BnbTransferBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new BnbTransferRequest
        {
            Amount = 1.0m,
            TransferSide = BnbTransferTransferSide.ToUm,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.BnbTransferAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ChangeAutoRepayFuturesStatusAsync()
    {
        const string example = """""{"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ChangeAutoRepayFuturesStatusRequest
        {
            AutoRepay = ChangeAutoRepayFuturesStatusAutoRepay.True,
        };

        var response = await client.ChangeAutoRepayFuturesStatusAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/repay-futures-switch", seen.Path);
        Assert.Equal("true", seen.Param("autoRepay"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ChangeAutoRepayFuturesStatusWithOptionalParametersAsync()
    {
        const string example = """""{"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ChangeAutoRepayFuturesStatusRequest
        {
            AutoRepay = ChangeAutoRepayFuturesStatusAutoRepay.True,
            RecvWindow = 5000L,
        };

        var response = await client.ChangeAutoRepayFuturesStatusAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/repay-futures-switch", seen.Path);
        Assert.Equal("true", seen.Param("autoRepay"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ChangeAutoRepayFuturesStatusBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new ChangeAutoRepayFuturesStatusRequest
        {
            AutoRepay = ChangeAutoRepayFuturesStatusAutoRepay.True,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ChangeAutoRepayFuturesStatusAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task DeleteMarginCallLevelAsync()
    {
        const string example = """""{"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.DeleteMarginCallLevelAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/margin-call-level", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DeleteMarginCallLevelWithOptionalParametersAsync()
    {
        const string example = """""{"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DeleteMarginCallLevelRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.DeleteMarginCallLevelAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/margin-call-level", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DeleteMarginCallLevelBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.DeleteMarginCallLevelAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task FundAutoCollectionAsync()
    {
        const string example = """""{"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.FundAutoCollectionAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/auto-collection", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FundAutoCollectionWithOptionalParametersAsync()
    {
        const string example = """""{"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new FundAutoCollectionRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.FundAutoCollectionAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/auto-collection", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FundAutoCollectionBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.FundAutoCollectionAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task FundCollectionByAssetAsync()
    {
        const string example = """""{"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new FundCollectionByAssetRequest
        {
            Asset = "USDT",
        };

        var response = await client.FundCollectionByAssetAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/asset-collection", seen.Path);
        Assert.Equal("USDT", seen.Param("asset"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FundCollectionByAssetWithOptionalParametersAsync()
    {
        const string example = """""{"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new FundCollectionByAssetRequest
        {
            Asset = "USDT",
            Amount = 10m,
            FutureType = FundCollectionByAssetFutureType.Um,
            RecvWindow = 5000L,
        };

        var response = await client.FundCollectionByAssetAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/asset-collection", seen.Path);
        Assert.Equal("USDT", seen.Param("asset"));
        Assert.Equal("10", seen.Param("amount"));
        Assert.Equal("UM", seen.Param("futureType"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FundCollectionByAssetBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new FundCollectionByAssetRequest
        {
            Asset = "USDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.FundCollectionByAssetAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetAutoRepayFuturesStatusAsync()
    {
        const string example = """""{"autoRepay":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetAutoRepayFuturesStatusAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/repay-futures-switch", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetAutoRepayFuturesStatusWithOptionalParametersAsync()
    {
        const string example = """""{"autoRepay":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetAutoRepayFuturesStatusRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetAutoRepayFuturesStatusAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/repay-futures-switch", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetAutoRepayFuturesStatusBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetAutoRepayFuturesStatusAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetDeltaModeStatusAsync()
    {
        const string example = """""{"deltaEnabled":false}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetDeltaModeStatusAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/delta-mode", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDeltaModeStatusWithOptionalParametersAsync()
    {
        const string example = """""{"deltaEnabled":false}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDeltaModeStatusRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetDeltaModeStatusAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/delta-mode", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDeltaModeStatusBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetDeltaModeStatusAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetMarginCallLevelAsync()
    {
        const string example = """""{"marginCallLevel":"1.67354637"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetMarginCallLevelAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/margin-call-level", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetMarginCallLevelWithOptionalParametersAsync()
    {
        const string example = """""{"marginCallLevel":"1.67354637"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetMarginCallLevelRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetMarginCallLevelAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/margin-call-level", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetMarginCallLevelBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetMarginCallLevelAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetPortfolioMarginProAccountBalanceAsync()
    {
        const string example = """""[{"asset":"USDT","totalWalletBalance":"122607.35137903","crossMarginAsset":"92.27530794","crossMarginBorrowed":"10.00000000","crossMarginFree":"100.00000000","crossMarginInterest":"0.72469206","crossMarginLocked":"3.00000000","umWalletBalance":"0.00000000","umUnrealizedPNL":"23.72469206","cmWalletBalance":"23.72469206","cmUnrealizedPNL":"","updateTime":1617939110373,"negativeBalance":"0","optionWalletBalance":"0","optionEquity":"0"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetPortfolioMarginProAccountBalanceAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/balance", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetPortfolioMarginProAccountBalanceWithOptionalParametersAsync()
    {
        const string example = """""[{"asset":"USDT","totalWalletBalance":"122607.35137903","crossMarginAsset":"92.27530794","crossMarginBorrowed":"10.00000000","crossMarginFree":"100.00000000","crossMarginInterest":"0.72469206","crossMarginLocked":"3.00000000","umWalletBalance":"0.00000000","umUnrealizedPNL":"23.72469206","cmWalletBalance":"23.72469206","cmUnrealizedPNL":"","updateTime":1617939110373,"negativeBalance":"0","optionWalletBalance":"0","optionEquity":"0"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetPortfolioMarginProAccountBalanceRequest
        {
            Asset = "BTC",
            RecvWindow = 5000L,
        };

        var response = await client.GetPortfolioMarginProAccountBalanceAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/balance", seen.Path);
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetPortfolioMarginProAccountBalanceBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetPortfolioMarginProAccountBalanceAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetPortfolioMarginProAccountInfoAsync()
    {
        const string example = """""{"uniMMR":"5167.92171923","accountEquity":"122607.35137903","actualEquity":"142607.35137903","accountMaintMargin":"23.72469206","accountInitialMargin":"47.44938412","totalAvailableBalance":"122,559.90199491","accountStatus":"NORMAL","accountType":"PM_1"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetPortfolioMarginProAccountInfoAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/account", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetPortfolioMarginProAccountInfoWithOptionalParametersAsync()
    {
        const string example = """""{"uniMMR":"5167.92171923","accountEquity":"122607.35137903","actualEquity":"142607.35137903","accountMaintMargin":"23.72469206","accountInitialMargin":"47.44938412","totalAvailableBalance":"122,559.90199491","accountStatus":"NORMAL","accountType":"PM_1"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetPortfolioMarginProAccountInfoRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetPortfolioMarginProAccountInfoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/account", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetPortfolioMarginProAccountInfoBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetPortfolioMarginProAccountInfoAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetPortfolioMarginProSpanAccountInfoAsync()
    {
        const string example = """""{"uniMMR":"5167.92171923","accountEquity":"122607.35137903","actualEquity":"142607.35137903","accountMaintMargin":"23.72469206","riskUnitMMList":[{"asset":"BTC","uniMaintainUsd":"23.72469206"}],"marginMM":"0.00000000","otherMM":"0.00000000","accountStatus":"NORMAL","accountType":"PM_3"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetPortfolioMarginProSpanAccountInfoAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/portfolio/account", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetPortfolioMarginProSpanAccountInfoWithOptionalParametersAsync()
    {
        const string example = """""{"uniMMR":"5167.92171923","accountEquity":"122607.35137903","actualEquity":"142607.35137903","accountMaintMargin":"23.72469206","riskUnitMMList":[{"asset":"BTC","uniMaintainUsd":"23.72469206"}],"marginMM":"0.00000000","otherMM":"0.00000000","accountStatus":"NORMAL","accountType":"PM_3"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetPortfolioMarginProSpanAccountInfoRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetPortfolioMarginProSpanAccountInfoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/portfolio/account", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetPortfolioMarginProSpanAccountInfoBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetPortfolioMarginProSpanAccountInfoAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetTransferableEarnAssetBalanceForPortfolioMarginAsync()
    {
        const string example = """""{"asset":"LDUSDT","amount":"0.55"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetTransferableEarnAssetBalanceForPortfolioMarginRequest
        {
            Asset = "LDUSDT",
            TransferType = GetTransferableEarnAssetBalanceForPortfolioMarginTransferType.EarnToFuture,
        };

        var response = await client.GetTransferableEarnAssetBalanceForPortfolioMarginAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/earn-asset-balance", seen.Path);
        Assert.Equal("LDUSDT", seen.Param("asset"));
        Assert.Equal("EARN_TO_FUTURE", seen.Param("transferType"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetTransferableEarnAssetBalanceForPortfolioMarginWithOptionalParametersAsync()
    {
        const string example = """""{"asset":"LDUSDT","amount":"0.55"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetTransferableEarnAssetBalanceForPortfolioMarginRequest
        {
            Asset = "LDUSDT",
            TransferType = GetTransferableEarnAssetBalanceForPortfolioMarginTransferType.EarnToFuture,
            RecvWindow = 5000L,
        };

        var response = await client.GetTransferableEarnAssetBalanceForPortfolioMarginAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/earn-asset-balance", seen.Path);
        Assert.Equal("LDUSDT", seen.Param("asset"));
        Assert.Equal("EARN_TO_FUTURE", seen.Param("transferType"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetTransferableEarnAssetBalanceForPortfolioMarginBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetTransferableEarnAssetBalanceForPortfolioMarginRequest
        {
            Asset = "LDUSDT",
            TransferType = GetTransferableEarnAssetBalanceForPortfolioMarginTransferType.EarnToFuture,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetTransferableEarnAssetBalanceForPortfolioMarginAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task PortfolioMarginProBankruptcyLoanRepayAsync()
    {
        const string example = """""{"tranId":58203331886213500}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.PortfolioMarginProBankruptcyLoanRepayAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/repay", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task PortfolioMarginProBankruptcyLoanRepayWithOptionalParametersAsync()
    {
        const string example = """""{"tranId":58203331886213500}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new PortfolioMarginProBankruptcyLoanRepayRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.PortfolioMarginProBankruptcyLoanRepayAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/repay", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task PortfolioMarginProBankruptcyLoanRepayBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.PortfolioMarginProBankruptcyLoanRepayAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryPortfolioMarginProBankruptcyLoanAmountAsync()
    {
        const string example = """""{"asset":"BUSD","amount":"579.45"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryPortfolioMarginProBankruptcyLoanAmountAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/pmLoan", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryPortfolioMarginProBankruptcyLoanAmountWithOptionalParametersAsync()
    {
        const string example = """""{"asset":"BUSD","amount":"579.45"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryPortfolioMarginProBankruptcyLoanAmountRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.QueryPortfolioMarginProBankruptcyLoanAmountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/pmLoan", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryPortfolioMarginProBankruptcyLoanAmountBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryPortfolioMarginProBankruptcyLoanAmountAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryPortfolioMarginProBankruptcyLoanRepayHistoryAsync()
    {
        const string example = """""{"total":3,"rows":[{"asset":"USDT","amount":"404.80294503","repayTime":1731336427804}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryPortfolioMarginProBankruptcyLoanRepayHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/pmloan-history", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryPortfolioMarginProBankruptcyLoanRepayHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"total":3,"rows":[{"asset":"USDT","amount":"404.80294503","repayTime":1731336427804}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryPortfolioMarginProBankruptcyLoanRepayHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Size = 10L,
            Current = 1L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryPortfolioMarginProBankruptcyLoanRepayHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/pmloan-history", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("10", seen.Param("size"));
        Assert.Equal("1", seen.Param("current"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryPortfolioMarginProBankruptcyLoanRepayHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryPortfolioMarginProBankruptcyLoanRepayHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryPortfolioMarginProNegativeBalanceInterestHistoryAsync()
    {
        const string example = """""[{"asset":"USDT","interest":"24.4440","interestAccruedTime":1670227200000,"interestRate":"0.0001164","principal":"210000"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryPortfolioMarginProNegativeBalanceInterestHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/interest-history", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryPortfolioMarginProNegativeBalanceInterestHistoryWithOptionalParametersAsync()
    {
        const string example = """""[{"asset":"USDT","interest":"24.4440","interestAccruedTime":1670227200000,"interestRate":"0.0001164","principal":"210000"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryPortfolioMarginProNegativeBalanceInterestHistoryRequest
        {
            Asset = "USDT",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryPortfolioMarginProNegativeBalanceInterestHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/interest-history", seen.Path);
        Assert.Equal("USDT", seen.Param("asset"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("10", seen.Param("size"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryPortfolioMarginProNegativeBalanceInterestHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryPortfolioMarginProNegativeBalanceInterestHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task RepayFuturesNegativeBalanceAsync()
    {
        const string example = """""{"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.RepayFuturesNegativeBalanceAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/repay-futures-negative-balance", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task RepayFuturesNegativeBalanceWithOptionalParametersAsync()
    {
        const string example = """""{"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new RepayFuturesNegativeBalanceRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.RepayFuturesNegativeBalanceAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/repay-futures-negative-balance", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task RepayFuturesNegativeBalanceBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.RepayFuturesNegativeBalanceAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SetMarginCallLevelAsync()
    {
        const string example = """""{"marginCallLevel":"1.67354637"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SetMarginCallLevelRequest
        {
            MarginCallLevel = 1.5m,
        };

        var response = await client.SetMarginCallLevelAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/margin-call-level", seen.Path);
        Assert.Equal("1.5", seen.Param("marginCallLevel"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SetMarginCallLevelWithOptionalParametersAsync()
    {
        const string example = """""{"marginCallLevel":"1.67354637"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SetMarginCallLevelRequest
        {
            MarginCallLevel = 1.5m,
            RecvWindow = 5000L,
        };

        var response = await client.SetMarginCallLevelAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/margin-call-level", seen.Path);
        Assert.Equal("1.5", seen.Param("marginCallLevel"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SetMarginCallLevelBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new SetMarginCallLevelRequest
        {
            MarginCallLevel = 1.5m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SetMarginCallLevelAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SwitchDeltaModeAsync()
    {
        const string example = """""{"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SwitchDeltaModeRequest
        {
            DeltaEnabled = SwitchDeltaModeDeltaEnabled.True,
        };

        var response = await client.SwitchDeltaModeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/delta-mode", seen.Path);
        Assert.Equal("true", seen.Param("deltaEnabled"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SwitchDeltaModeWithOptionalParametersAsync()
    {
        const string example = """""{"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SwitchDeltaModeRequest
        {
            DeltaEnabled = SwitchDeltaModeDeltaEnabled.True,
            RecvWindow = 5000L,
        };

        var response = await client.SwitchDeltaModeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/delta-mode", seen.Path);
        Assert.Equal("true", seen.Param("deltaEnabled"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SwitchDeltaModeBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new SwitchDeltaModeRequest
        {
            DeltaEnabled = SwitchDeltaModeDeltaEnabled.True,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SwitchDeltaModeAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TransferLdusdtRwusdForPortfolioMarginAsync()
    {
        const string example = """""{"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TransferLdusdtRwusdForPortfolioMarginRequest
        {
            Asset = TransferLdusdtRwusdForPortfolioMarginAsset.Ldusdt,
            TransferType = TransferLdusdtRwusdForPortfolioMarginTransferType.EarnToFuture,
            Amount = 1m,
        };

        var response = await client.TransferLdusdtRwusdForPortfolioMarginAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/earn-asset-transfer", seen.Path);
        Assert.Equal("LDUSDT", seen.Param("asset"));
        Assert.Equal("EARN_TO_FUTURE", seen.Param("transferType"));
        Assert.Equal("1", seen.Param("amount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TransferLdusdtRwusdForPortfolioMarginWithOptionalParametersAsync()
    {
        const string example = """""{"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TransferLdusdtRwusdForPortfolioMarginRequest
        {
            Asset = TransferLdusdtRwusdForPortfolioMarginAsset.Ldusdt,
            TransferType = TransferLdusdtRwusdForPortfolioMarginTransferType.EarnToFuture,
            Amount = 1m,
            RecvWindow = 5000L,
        };

        var response = await client.TransferLdusdtRwusdForPortfolioMarginAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/earn-asset-transfer", seen.Path);
        Assert.Equal("LDUSDT", seen.Param("asset"));
        Assert.Equal("EARN_TO_FUTURE", seen.Param("transferType"));
        Assert.Equal("1", seen.Param("amount"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TransferLdusdtRwusdForPortfolioMarginBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new TransferLdusdtRwusdForPortfolioMarginRequest
        {
            Asset = TransferLdusdtRwusdForPortfolioMarginAsset.Ldusdt,
            TransferType = TransferLdusdtRwusdForPortfolioMarginTransferType.EarnToFuture,
            Amount = 1m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.TransferLdusdtRwusdForPortfolioMarginAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
