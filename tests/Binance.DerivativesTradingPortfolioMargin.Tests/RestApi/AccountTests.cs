//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.DerivativesTradingPortfolioMargin.RestApi;

namespace Binance.DerivativesTradingPortfolioMargin.Tests.RestApi.Account;

[Trait("Category", "Native")]
public class AccountApiTests
{
    private static DerivativesTradingPortfolioMarginRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task AccountBalanceAsync()
    {
        const string example = """""[{"asset":"USDT","totalWalletBalance":"126.72469206","crossMarginAsset":"103.00000000","crossMarginBorrowed":"10.00000000","crossMarginFree":"100.00000000","crossMarginInterest":"0.72469206","crossMarginLocked":"3.00000000","umWalletBalance":"0.00000000","umUnrealizedPNL":"23.72469206","cmWalletBalance":"23.72469206","cmUnrealizedPNL":"","updateTime":1617939110373,"negativeBalance":"0"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.AccountBalanceAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/balance", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AccountBalanceWithOptionalParametersAsync()
    {
        const string example = """""[{"asset":"USDT","totalWalletBalance":"126.72469206","crossMarginAsset":"103.00000000","crossMarginBorrowed":"10.00000000","crossMarginFree":"100.00000000","crossMarginInterest":"0.72469206","crossMarginLocked":"3.00000000","umWalletBalance":"0.00000000","umUnrealizedPNL":"23.72469206","cmWalletBalance":"23.72469206","cmUnrealizedPNL":"","updateTime":1617939110373,"negativeBalance":"0"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AccountBalanceRequest
        {
            Asset = "USDT",
            RecvWindow = 5000L,
        };

        var response = await client.AccountBalanceAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/balance", seen.Path);
        Assert.Equal("USDT", seen.Param("asset"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AccountBalanceBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AccountBalanceAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task AccountInformationAsync()
    {
        const string example = """""{"uniMMR":"5167.92171923","accountEquity":"73.47428058","actualEquity":"122607.35137903","accountInitialMargin":"23.72469206","accountMaintMargin":"23.72469206","accountStatus":"NORMAL","virtualMaxWithdrawAmount":"1627523.32459208","totalAvailableBalance":"","totalMarginOpenLoss":"","updateTime":1657707212154}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.AccountInformationAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/account", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AccountInformationWithOptionalParametersAsync()
    {
        const string example = """""{"uniMMR":"5167.92171923","accountEquity":"73.47428058","actualEquity":"122607.35137903","accountInitialMargin":"23.72469206","accountMaintMargin":"23.72469206","accountStatus":"NORMAL","virtualMaxWithdrawAmount":"1627523.32459208","totalAvailableBalance":"","totalMarginOpenLoss":"","updateTime":1657707212154}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AccountInformationRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.AccountInformationAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/account", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AccountInformationBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AccountInformationAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

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
        Assert.Equal("/papi/v1/bnb-transfer", seen.Path);
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
        Assert.Equal("/papi/v1/bnb-transfer", seen.Path);
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
        Assert.Equal("/papi/v1/repay-futures-switch", seen.Path);
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
        Assert.Equal("/papi/v1/repay-futures-switch", seen.Path);
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
    public async Task ChangeCmInitialLeverageAsync()
    {
        const string example = """""{"leverage":21,"maxQty":"1000","symbol":"BTCUSD_200925"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ChangeCmInitialLeverageRequest
        {
            Symbol = "BTCUSD_200925",
            Leverage = 21L,
        };

        var response = await client.ChangeCmInitialLeverageAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/papi/v1/cm/leverage", seen.Path);
        Assert.Equal("BTCUSD_200925", seen.Param("symbol"));
        Assert.Equal("21", seen.Param("leverage"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ChangeCmInitialLeverageWithOptionalParametersAsync()
    {
        const string example = """""{"leverage":21,"maxQty":"1000","symbol":"BTCUSD_200925"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ChangeCmInitialLeverageRequest
        {
            Symbol = "BTCUSD_200925",
            Leverage = 21L,
            RecvWindow = 5000L,
        };

        var response = await client.ChangeCmInitialLeverageAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/papi/v1/cm/leverage", seen.Path);
        Assert.Equal("BTCUSD_200925", seen.Param("symbol"));
        Assert.Equal("21", seen.Param("leverage"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ChangeCmInitialLeverageBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new ChangeCmInitialLeverageRequest
        {
            Symbol = "BTCUSD_200925",
            Leverage = 21L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ChangeCmInitialLeverageAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ChangeCmPositionModeAsync()
    {
        const string example = """""{"code":200,"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ChangeCmPositionModeRequest
        {
            DualSidePosition = ChangeCmPositionModeDualSidePosition.True,
        };

        var response = await client.ChangeCmPositionModeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/papi/v1/cm/positionSide/dual", seen.Path);
        Assert.Equal("true", seen.Param("dualSidePosition"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ChangeCmPositionModeWithOptionalParametersAsync()
    {
        const string example = """""{"code":200,"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ChangeCmPositionModeRequest
        {
            DualSidePosition = ChangeCmPositionModeDualSidePosition.True,
            RecvWindow = 5000L,
        };

        var response = await client.ChangeCmPositionModeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/papi/v1/cm/positionSide/dual", seen.Path);
        Assert.Equal("true", seen.Param("dualSidePosition"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ChangeCmPositionModeBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new ChangeCmPositionModeRequest
        {
            DualSidePosition = ChangeCmPositionModeDualSidePosition.True,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ChangeCmPositionModeAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ChangeUmInitialLeverageAsync()
    {
        const string example = """""{"leverage":21,"maxNotionalValue":"1000000","symbol":"BTCUSDT"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ChangeUmInitialLeverageRequest
        {
            Symbol = "BTCUSDT",
            Leverage = 21L,
        };

        var response = await client.ChangeUmInitialLeverageAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/papi/v1/um/leverage", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("21", seen.Param("leverage"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ChangeUmInitialLeverageWithOptionalParametersAsync()
    {
        const string example = """""{"leverage":21,"maxNotionalValue":"1000000","symbol":"BTCUSDT"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ChangeUmInitialLeverageRequest
        {
            Symbol = "BTCUSDT",
            Leverage = 21L,
            RecvWindow = 5000L,
        };

        var response = await client.ChangeUmInitialLeverageAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/papi/v1/um/leverage", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("21", seen.Param("leverage"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ChangeUmInitialLeverageBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new ChangeUmInitialLeverageRequest
        {
            Symbol = "BTCUSDT",
            Leverage = 21L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ChangeUmInitialLeverageAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ChangeUmPositionModeAsync()
    {
        const string example = """""{"code":200,"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ChangeUmPositionModeRequest
        {
            DualSidePosition = ChangeUmPositionModeDualSidePosition.True,
        };

        var response = await client.ChangeUmPositionModeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/papi/v1/um/positionSide/dual", seen.Path);
        Assert.Equal("true", seen.Param("dualSidePosition"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ChangeUmPositionModeWithOptionalParametersAsync()
    {
        const string example = """""{"code":200,"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ChangeUmPositionModeRequest
        {
            DualSidePosition = ChangeUmPositionModeDualSidePosition.True,
            RecvWindow = 5000L,
        };

        var response = await client.ChangeUmPositionModeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/papi/v1/um/positionSide/dual", seen.Path);
        Assert.Equal("true", seen.Param("dualSidePosition"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ChangeUmPositionModeBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new ChangeUmPositionModeRequest
        {
            DualSidePosition = ChangeUmPositionModeDualSidePosition.True,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ChangeUmPositionModeAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CmNotionalAndLeverageBracketsAsync()
    {
        const string example = """""[{"symbol":"BTCUSD_PERP","brackets":[{"bracket":1,"initialLeverage":125,"qtyCap":50,"qtyFloor":0,"maintMarginRatio":0.004,"cum":0}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.CmNotionalAndLeverageBracketsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/leverageBracket", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CmNotionalAndLeverageBracketsWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"BTCUSD_PERP","brackets":[{"bracket":1,"initialLeverage":125,"qtyCap":50,"qtyFloor":0,"maintMarginRatio":0.004,"cum":0}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CmNotionalAndLeverageBracketsRequest
        {
            Symbol = "BTCUSD_PERP",
            RecvWindow = 5000L,
        };

        var response = await client.CmNotionalAndLeverageBracketsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/leverageBracket", seen.Path);
        Assert.Equal("BTCUSD_PERP", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CmNotionalAndLeverageBracketsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CmNotionalAndLeverageBracketsAsync());

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
        Assert.Equal("/papi/v1/auto-collection", seen.Path);
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
        Assert.Equal("/papi/v1/auto-collection", seen.Path);
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
            Asset = "BTC",
        };

        var response = await client.FundCollectionByAssetAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/papi/v1/asset-collection", seen.Path);
        Assert.Equal("BTC", seen.Param("asset"));
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
            Asset = "BTC",
            Amount = 10m,
            FutureType = FundCollectionByAssetFutureType.Um,
            RecvWindow = 5000L,
        };

        var response = await client.FundCollectionByAssetAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/papi/v1/asset-collection", seen.Path);
        Assert.Equal("BTC", seen.Param("asset"));
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
            Asset = "BTC",
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
        Assert.Equal("/papi/v1/repay-futures-switch", seen.Path);
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
        Assert.Equal("/papi/v1/repay-futures-switch", seen.Path);
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
    public async Task GetCmAccountDetailAsync()
    {
        const string example = """""{"assets":[{"asset":"BTC","crossWalletBalance":"0.00241969","crossUnPnl":"0.00000000","maintMargin":"0.00000000","initialMargin":"0.00000000","positionInitialMargin":"0.00000000","openOrderInitialMargin":"0.00000000","updateTime":1625474304765}],"positions":[{"symbol":"BTCUSD_201225","positionAmt":"0","initialMargin":"0","maintMargin":"0","unrealizedProfit":"0.00000000","positionInitialMargin":"0","openOrderInitialMargin":"0","leverage":"125","positionSide":"BOTH","entryPrice":"0.0","maxQty":"50","updateTime":0}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetCmAccountDetailAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/account", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetCmAccountDetailWithOptionalParametersAsync()
    {
        const string example = """""{"assets":[{"asset":"BTC","crossWalletBalance":"0.00241969","crossUnPnl":"0.00000000","maintMargin":"0.00000000","initialMargin":"0.00000000","positionInitialMargin":"0.00000000","openOrderInitialMargin":"0.00000000","updateTime":1625474304765}],"positions":[{"symbol":"BTCUSD_201225","positionAmt":"0","initialMargin":"0","maintMargin":"0","unrealizedProfit":"0.00000000","positionInitialMargin":"0","openOrderInitialMargin":"0","leverage":"125","positionSide":"BOTH","entryPrice":"0.0","maxQty":"50","updateTime":0}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetCmAccountDetailRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetCmAccountDetailAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/account", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetCmAccountDetailBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetCmAccountDetailAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetCmCurrentPositionModeAsync()
    {
        const string example = """""{"dualSidePosition":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetCmCurrentPositionModeAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/positionSide/dual", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetCmCurrentPositionModeWithOptionalParametersAsync()
    {
        const string example = """""{"dualSidePosition":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetCmCurrentPositionModeRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetCmCurrentPositionModeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/positionSide/dual", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetCmCurrentPositionModeBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetCmCurrentPositionModeAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetCmFuturesOrderDownloadLinkByIdAsync()
    {
        const string example = """""{"downloadId":"545923594199212032","status":"processing","url":"","s3Link":"null","notified":false,"expirationTimestamp":-1,"isExpired":"null"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetCmFuturesOrderDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
        };

        var response = await client.GetCmFuturesOrderDownloadLinkByIdAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/order/asyn/id", seen.Path);
        Assert.Equal("545923594199212032", seen.Param("downloadId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetCmFuturesOrderDownloadLinkByIdWithOptionalParametersAsync()
    {
        const string example = """""{"downloadId":"545923594199212032","status":"processing","url":"","s3Link":"null","notified":false,"expirationTimestamp":-1,"isExpired":"null"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetCmFuturesOrderDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
            RecvWindow = 5000L,
        };

        var response = await client.GetCmFuturesOrderDownloadLinkByIdAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/order/asyn/id", seen.Path);
        Assert.Equal("545923594199212032", seen.Param("downloadId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetCmFuturesOrderDownloadLinkByIdBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetCmFuturesOrderDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetCmFuturesOrderDownloadLinkByIdAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetCmFuturesTradeDownloadLinkByIdAsync()
    {
        const string example = """""{"downloadId":"545923594199212032","status":"processing","url":"","s3Link":"null","notified":false,"expirationTimestamp":-1,"isExpired":"null"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetCmFuturesTradeDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
        };

        var response = await client.GetCmFuturesTradeDownloadLinkByIdAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/trade/asyn/id", seen.Path);
        Assert.Equal("545923594199212032", seen.Param("downloadId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetCmFuturesTradeDownloadLinkByIdWithOptionalParametersAsync()
    {
        const string example = """""{"downloadId":"545923594199212032","status":"processing","url":"","s3Link":"null","notified":false,"expirationTimestamp":-1,"isExpired":"null"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetCmFuturesTradeDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
            RecvWindow = 5000L,
        };

        var response = await client.GetCmFuturesTradeDownloadLinkByIdAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/trade/asyn/id", seen.Path);
        Assert.Equal("545923594199212032", seen.Param("downloadId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetCmFuturesTradeDownloadLinkByIdBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetCmFuturesTradeDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetCmFuturesTradeDownloadLinkByIdAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetCmFuturesTransactionDownloadLinkByIdAsync()
    {
        const string example = """""{"downloadId":"545923594199212032","status":"processing","url":"","s3Link":"null","notified":false,"expirationTimestamp":-1,"isExpired":"null"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetCmFuturesTransactionDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
        };

        var response = await client.GetCmFuturesTransactionDownloadLinkByIdAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/income/asyn/id", seen.Path);
        Assert.Equal("545923594199212032", seen.Param("downloadId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetCmFuturesTransactionDownloadLinkByIdWithOptionalParametersAsync()
    {
        const string example = """""{"downloadId":"545923594199212032","status":"processing","url":"","s3Link":"null","notified":false,"expirationTimestamp":-1,"isExpired":"null"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetCmFuturesTransactionDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
            RecvWindow = 5000L,
        };

        var response = await client.GetCmFuturesTransactionDownloadLinkByIdAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/income/asyn/id", seen.Path);
        Assert.Equal("545923594199212032", seen.Param("downloadId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetCmFuturesTransactionDownloadLinkByIdBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetCmFuturesTransactionDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetCmFuturesTransactionDownloadLinkByIdAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetCmIncomeHistoryAsync()
    {
        const string example = """""[{"symbol":"","incomeType":"TRANSFER","income":"-0.37500000","asset":"BTC","info":"WITHDRAW","time":1570608000000,"tranId":"9689322392","tradeId":""}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetCmIncomeHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/income", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetCmIncomeHistoryWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"","incomeType":"TRANSFER","income":"-0.37500000","asset":"BTC","info":"WITHDRAW","time":1570608000000,"tranId":"9689322392","tradeId":""}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetCmIncomeHistoryRequest
        {
            Symbol = "BTCUSD_200925",
            IncomeType = GetCmIncomeHistoryIncomeType.Transfer,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 100L,
            RecvWindow = 5000L,
        };

        var response = await client.GetCmIncomeHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/income", seen.Path);
        Assert.Equal("BTCUSD_200925", seen.Param("symbol"));
        Assert.Equal("TRANSFER", seen.Param("incomeType"));
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
    public async Task GetCmIncomeHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetCmIncomeHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetDownloadIdForCmFuturesOrderHistoryAsync()
    {
        const string example = """""{"avgCostTimestampOfLast30d":7241837,"downloadId":"546975389218332672"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDownloadIdForCmFuturesOrderHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var response = await client.GetDownloadIdForCmFuturesOrderHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/order/asyn", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDownloadIdForCmFuturesOrderHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"avgCostTimestampOfLast30d":7241837,"downloadId":"546975389218332672"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDownloadIdForCmFuturesOrderHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            RecvWindow = 5000L,
        };

        var response = await client.GetDownloadIdForCmFuturesOrderHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/order/asyn", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDownloadIdForCmFuturesOrderHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetDownloadIdForCmFuturesOrderHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetDownloadIdForCmFuturesOrderHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetDownloadIdForCmFuturesTradeHistoryAsync()
    {
        const string example = """""{"avgCostTimestampOfLast30d":7241837,"downloadId":"546975389218332672"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDownloadIdForCmFuturesTradeHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var response = await client.GetDownloadIdForCmFuturesTradeHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/trade/asyn", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDownloadIdForCmFuturesTradeHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"avgCostTimestampOfLast30d":7241837,"downloadId":"546975389218332672"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDownloadIdForCmFuturesTradeHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            RecvWindow = 5000L,
        };

        var response = await client.GetDownloadIdForCmFuturesTradeHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/trade/asyn", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDownloadIdForCmFuturesTradeHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetDownloadIdForCmFuturesTradeHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetDownloadIdForCmFuturesTradeHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetDownloadIdForCmFuturesTransactionHistoryAsync()
    {
        const string example = """""{"avgCostTimestampOfLast30d":7241837,"downloadId":"546975389218332672"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDownloadIdForCmFuturesTransactionHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var response = await client.GetDownloadIdForCmFuturesTransactionHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/income/asyn", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDownloadIdForCmFuturesTransactionHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"avgCostTimestampOfLast30d":7241837,"downloadId":"546975389218332672"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDownloadIdForCmFuturesTransactionHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            RecvWindow = 5000L,
        };

        var response = await client.GetDownloadIdForCmFuturesTransactionHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/income/asyn", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDownloadIdForCmFuturesTransactionHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetDownloadIdForCmFuturesTransactionHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetDownloadIdForCmFuturesTransactionHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetDownloadIdForUmFuturesOrderHistoryAsync()
    {
        const string example = """""{"avgCostTimestampOfLast30d":7241837,"downloadId":"546975389218332672"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDownloadIdForUmFuturesOrderHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var response = await client.GetDownloadIdForUmFuturesOrderHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/order/asyn", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDownloadIdForUmFuturesOrderHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"avgCostTimestampOfLast30d":7241837,"downloadId":"546975389218332672"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDownloadIdForUmFuturesOrderHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            RecvWindow = 5000L,
        };

        var response = await client.GetDownloadIdForUmFuturesOrderHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/order/asyn", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDownloadIdForUmFuturesOrderHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetDownloadIdForUmFuturesOrderHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetDownloadIdForUmFuturesOrderHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetDownloadIdForUmFuturesTradeHistoryAsync()
    {
        const string example = """""{"avgCostTimestampOfLast30d":7241837,"downloadId":"546975389218332672"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDownloadIdForUmFuturesTradeHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var response = await client.GetDownloadIdForUmFuturesTradeHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/trade/asyn", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDownloadIdForUmFuturesTradeHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"avgCostTimestampOfLast30d":7241837,"downloadId":"546975389218332672"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDownloadIdForUmFuturesTradeHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            RecvWindow = 5000L,
        };

        var response = await client.GetDownloadIdForUmFuturesTradeHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/trade/asyn", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDownloadIdForUmFuturesTradeHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetDownloadIdForUmFuturesTradeHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetDownloadIdForUmFuturesTradeHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetDownloadIdForUmFuturesTransactionHistoryAsync()
    {
        const string example = """""{"avgCostTimestampOfLast30d":7241837,"downloadId":"546975389218332672"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDownloadIdForUmFuturesTransactionHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var response = await client.GetDownloadIdForUmFuturesTransactionHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/income/asyn", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDownloadIdForUmFuturesTransactionHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"avgCostTimestampOfLast30d":7241837,"downloadId":"546975389218332672"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDownloadIdForUmFuturesTransactionHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            RecvWindow = 5000L,
        };

        var response = await client.GetDownloadIdForUmFuturesTransactionHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/income/asyn", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDownloadIdForUmFuturesTransactionHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetDownloadIdForUmFuturesTransactionHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetDownloadIdForUmFuturesTransactionHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetMarginBorrowLoanInterestHistoryAsync()
    {
        const string example = """""{"rows":[{"txId":1352286576452864800,"interestAccuredTime":1672160400000,"asset":"USDT","rawAsset":"USDT","principal":"45.3313","interest":"0.00024995","interestRate":"0.00013233","type":"ON_BORROW"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetMarginBorrowLoanInterestHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/margin/marginInterestHistory", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetMarginBorrowLoanInterestHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"txId":1352286576452864800,"interestAccuredTime":1672160400000,"asset":"USDT","rawAsset":"USDT","principal":"45.3313","interest":"0.00024995","interestRate":"0.00013233","type":"ON_BORROW"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetMarginBorrowLoanInterestHistoryRequest
        {
            Asset = "USDT",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Size = 10L,
            Archived = GetMarginBorrowLoanInterestHistoryArchived.True,
            RecvWindow = 5000L,
        };

        var response = await client.GetMarginBorrowLoanInterestHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/margin/marginInterestHistory", seen.Path);
        Assert.Equal("USDT", seen.Param("asset"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("current"));
        Assert.Equal("10", seen.Param("size"));
        Assert.Equal("true", seen.Param("archived"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetMarginBorrowLoanInterestHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetMarginBorrowLoanInterestHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetUmAccountDetailAsync()
    {
        const string example = """""{"assets":[{"asset":"USDT","crossWalletBalance":"23.72469206","crossUnPnl":"0.00000000","maintMargin":"0.00000000","initialMargin":"0.00000000","positionInitialMargin":"0.00000000","openOrderInitialMargin":"0.00000000","updateTime":1625474304765}],"positions":[{"symbol":"BTCUSDT","initialMargin":"0","maintMargin":"0","unrealizedProfit":"0.00000000","positionInitialMargin":"0","openOrderInitialMargin":"0","leverage":"100","entryPrice":"0.00000","maxNotional":"250000","bidNotional":"0","askNotional":"0","positionSide":"BOTH","positionAmt":"0","updateTime":0}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetUmAccountDetailAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/account", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetUmAccountDetailWithOptionalParametersAsync()
    {
        const string example = """""{"assets":[{"asset":"USDT","crossWalletBalance":"23.72469206","crossUnPnl":"0.00000000","maintMargin":"0.00000000","initialMargin":"0.00000000","positionInitialMargin":"0.00000000","openOrderInitialMargin":"0.00000000","updateTime":1625474304765}],"positions":[{"symbol":"BTCUSDT","initialMargin":"0","maintMargin":"0","unrealizedProfit":"0.00000000","positionInitialMargin":"0","openOrderInitialMargin":"0","leverage":"100","entryPrice":"0.00000","maxNotional":"250000","bidNotional":"0","askNotional":"0","positionSide":"BOTH","positionAmt":"0","updateTime":0}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetUmAccountDetailRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetUmAccountDetailAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/account", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetUmAccountDetailBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetUmAccountDetailAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetUmAccountDetailV2Async()
    {
        const string example = """""{"assets":[{"asset":"USDT","crossWalletBalance":"23.72469206","crossUnPnl":"0.00000000","maintMargin":"0.00000000","initialMargin":"0.00000000","positionInitialMargin":"0.00000000","openOrderInitialMargin":"0.00000000","updateTime":1625474304765}],"positions":[{"symbol":"BTCUSDT","initialMargin":"0","maintMargin":"0","unrealizedProfit":"0.00000000","positionSide":"BOTH","positionAmt":"0","updateTime":0,"notional":"86.98650000"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetUmAccountDetailV2Async();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v2/um/account", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetUmAccountDetailV2WithOptionalParametersAsync()
    {
        const string example = """""{"assets":[{"asset":"USDT","crossWalletBalance":"23.72469206","crossUnPnl":"0.00000000","maintMargin":"0.00000000","initialMargin":"0.00000000","positionInitialMargin":"0.00000000","openOrderInitialMargin":"0.00000000","updateTime":1625474304765}],"positions":[{"symbol":"BTCUSDT","initialMargin":"0","maintMargin":"0","unrealizedProfit":"0.00000000","positionSide":"BOTH","positionAmt":"0","updateTime":0,"notional":"86.98650000"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetUmAccountDetailV2Request
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetUmAccountDetailV2Async(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v2/um/account", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetUmAccountDetailV2BadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetUmAccountDetailV2Async());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetUmCurrentPositionModeAsync()
    {
        const string example = """""{"dualSidePosition":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetUmCurrentPositionModeAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/positionSide/dual", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetUmCurrentPositionModeWithOptionalParametersAsync()
    {
        const string example = """""{"dualSidePosition":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetUmCurrentPositionModeRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetUmCurrentPositionModeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/positionSide/dual", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetUmCurrentPositionModeBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetUmCurrentPositionModeAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetUmFuturesOrderDownloadLinkByIdAsync()
    {
        const string example = """""{"downloadId":"545923594199212032","status":"processing","url":"","s3Link":"null","notified":false,"expirationTimestamp":-1,"isExpired":"null"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetUmFuturesOrderDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
        };

        var response = await client.GetUmFuturesOrderDownloadLinkByIdAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/order/asyn/id", seen.Path);
        Assert.Equal("545923594199212032", seen.Param("downloadId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetUmFuturesOrderDownloadLinkByIdWithOptionalParametersAsync()
    {
        const string example = """""{"downloadId":"545923594199212032","status":"processing","url":"","s3Link":"null","notified":false,"expirationTimestamp":-1,"isExpired":"null"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetUmFuturesOrderDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
            RecvWindow = 5000L,
        };

        var response = await client.GetUmFuturesOrderDownloadLinkByIdAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/order/asyn/id", seen.Path);
        Assert.Equal("545923594199212032", seen.Param("downloadId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetUmFuturesOrderDownloadLinkByIdBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetUmFuturesOrderDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetUmFuturesOrderDownloadLinkByIdAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetUmFuturesTradeDownloadLinkByIdAsync()
    {
        const string example = """""{"downloadId":"545923594199212032","status":"processing","url":"","s3Link":"null","notified":false,"expirationTimestamp":-1,"isExpired":"null"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetUmFuturesTradeDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
        };

        var response = await client.GetUmFuturesTradeDownloadLinkByIdAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/trade/asyn/id", seen.Path);
        Assert.Equal("545923594199212032", seen.Param("downloadId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetUmFuturesTradeDownloadLinkByIdWithOptionalParametersAsync()
    {
        const string example = """""{"downloadId":"545923594199212032","status":"processing","url":"","s3Link":"null","notified":false,"expirationTimestamp":-1,"isExpired":"null"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetUmFuturesTradeDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
            RecvWindow = 5000L,
        };

        var response = await client.GetUmFuturesTradeDownloadLinkByIdAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/trade/asyn/id", seen.Path);
        Assert.Equal("545923594199212032", seen.Param("downloadId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetUmFuturesTradeDownloadLinkByIdBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetUmFuturesTradeDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetUmFuturesTradeDownloadLinkByIdAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetUmFuturesTransactionDownloadLinkByIdAsync()
    {
        const string example = """""{"downloadId":"545923594199212032","status":"processing","url":"","s3Link":"null","notified":false,"expirationTimestamp":-1,"isExpired":"null"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetUmFuturesTransactionDownloadLinkByIdRequest
        {
            DownloadId = "1",
        };

        var response = await client.GetUmFuturesTransactionDownloadLinkByIdAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/income/asyn/id", seen.Path);
        Assert.Equal("1", seen.Param("downloadId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetUmFuturesTransactionDownloadLinkByIdWithOptionalParametersAsync()
    {
        const string example = """""{"downloadId":"545923594199212032","status":"processing","url":"","s3Link":"null","notified":false,"expirationTimestamp":-1,"isExpired":"null"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetUmFuturesTransactionDownloadLinkByIdRequest
        {
            DownloadId = "1",
            RecvWindow = 5000L,
        };

        var response = await client.GetUmFuturesTransactionDownloadLinkByIdAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/income/asyn/id", seen.Path);
        Assert.Equal("1", seen.Param("downloadId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetUmFuturesTransactionDownloadLinkByIdBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetUmFuturesTransactionDownloadLinkByIdRequest
        {
            DownloadId = "1",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetUmFuturesTransactionDownloadLinkByIdAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetUmIncomeHistoryAsync()
    {
        const string example = """""[{"symbol":"","incomeType":"TRANSFER","income":"-0.37500000","asset":"USDT","info":"TRANSFER","time":1570608000000,"tranId":"9689322392","tradeId":""}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetUmIncomeHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/income", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetUmIncomeHistoryWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"","incomeType":"TRANSFER","income":"-0.37500000","asset":"USDT","info":"TRANSFER","time":1570608000000,"tranId":"9689322392","tradeId":""}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetUmIncomeHistoryRequest
        {
            Symbol = "symbol_example",
            IncomeType = GetUmIncomeHistoryIncomeType.Transfer,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 100L,
            RecvWindow = 5000L,
        };

        var response = await client.GetUmIncomeHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/income", seen.Path);
        Assert.Equal("symbol_example", seen.Param("symbol"));
        Assert.Equal("TRANSFER", seen.Param("incomeType"));
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
    public async Task GetUmIncomeHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetUmIncomeHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetUserCommissionRateForCmAsync()
    {
        const string example = """""{"symbol":"BTCUSD_PERP","makerCommissionRate":"0.00015","takerCommissionRate":"0.00040"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetUserCommissionRateForCmRequest
        {
            Symbol = "BTCUSD_PERP",
        };

        var response = await client.GetUserCommissionRateForCmAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/commissionRate", seen.Path);
        Assert.Equal("BTCUSD_PERP", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetUserCommissionRateForCmWithOptionalParametersAsync()
    {
        const string example = """""{"symbol":"BTCUSD_PERP","makerCommissionRate":"0.00015","takerCommissionRate":"0.00040"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetUserCommissionRateForCmRequest
        {
            Symbol = "BTCUSD_PERP",
            RecvWindow = 5000L,
        };

        var response = await client.GetUserCommissionRateForCmAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/commissionRate", seen.Path);
        Assert.Equal("BTCUSD_PERP", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetUserCommissionRateForCmBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetUserCommissionRateForCmRequest
        {
            Symbol = "BTCUSD_PERP",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetUserCommissionRateForCmAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetUserCommissionRateForUmAsync()
    {
        const string example = """""{"symbol":"BTCUSDT","makerCommissionRate":"0.0002","takerCommissionRate":"0.0004"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetUserCommissionRateForUmRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.GetUserCommissionRateForUmAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/commissionRate", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetUserCommissionRateForUmWithOptionalParametersAsync()
    {
        const string example = """""{"symbol":"BTCUSDT","makerCommissionRate":"0.0002","takerCommissionRate":"0.0004"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetUserCommissionRateForUmRequest
        {
            Symbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.GetUserCommissionRateForUmAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/commissionRate", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetUserCommissionRateForUmBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetUserCommissionRateForUmRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetUserCommissionRateForUmAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task MarginMaxBorrowAsync()
    {
        const string example = """""{"amount":"1.69248805","borrowLimit":"60"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarginMaxBorrowRequest
        {
            Asset = "USDT",
        };

        var response = await client.MarginMaxBorrowAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/margin/maxBorrowable", seen.Path);
        Assert.Equal("USDT", seen.Param("asset"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarginMaxBorrowWithOptionalParametersAsync()
    {
        const string example = """""{"amount":"1.69248805","borrowLimit":"60"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarginMaxBorrowRequest
        {
            Asset = "USDT",
            RecvWindow = 5000L,
        };

        var response = await client.MarginMaxBorrowAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/margin/maxBorrowable", seen.Path);
        Assert.Equal("USDT", seen.Param("asset"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarginMaxBorrowBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new MarginMaxBorrowRequest
        {
            Asset = "USDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.MarginMaxBorrowAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task PortfolioMarginUmTradingQuantitativeRulesIndicatorsAsync()
    {
        const string example = """""{"indicators":{"BTCUSDT":[{"isLocked":true,"plannedRecoverTime":1545741270000,"indicator":"UFR","value":0.05,"triggerValue":0.995}],"ACCOUNT":[{"indicator":"TMV","value":10,"triggerValue":1,"plannedRecoverTime":1644919865000,"isLocked":true}]},"updateTime":1644913304748}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.PortfolioMarginUmTradingQuantitativeRulesIndicatorsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/apiTradingStatus", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task PortfolioMarginUmTradingQuantitativeRulesIndicatorsWithOptionalParametersAsync()
    {
        const string example = """""{"indicators":{"BTCUSDT":[{"isLocked":true,"plannedRecoverTime":1545741270000,"indicator":"UFR","value":0.05,"triggerValue":0.995}],"ACCOUNT":[{"indicator":"TMV","value":10,"triggerValue":1,"plannedRecoverTime":1644919865000,"isLocked":true}]},"updateTime":1644913304748}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new PortfolioMarginUmTradingQuantitativeRulesIndicatorsRequest
        {
            Symbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.PortfolioMarginUmTradingQuantitativeRulesIndicatorsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/apiTradingStatus", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task PortfolioMarginUmTradingQuantitativeRulesIndicatorsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.PortfolioMarginUmTradingQuantitativeRulesIndicatorsAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryCmPositionInformationAsync()
    {
        const string example = """""[{"symbol":"BTCUSD_201225","positionAmt":"0","entryPrice":"0.0","markPrice":"0.00000000","unRealizedProfit":"0.00000000","liquidationPrice":"6170.20509059","leverage":"125","positionSide":"BOTH","updateTime":0,"maxQty":"50","notionalValue":"0.00084827"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryCmPositionInformationAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/positionRisk", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCmPositionInformationWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"BTCUSD_201225","positionAmt":"0","entryPrice":"0.0","markPrice":"0.00000000","unRealizedProfit":"0.00000000","liquidationPrice":"6170.20509059","leverage":"125","positionSide":"BOTH","updateTime":0,"maxQty":"50","notionalValue":"0.00084827"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryCmPositionInformationRequest
        {
            MarginAsset = "USDT",
            Pair = "BTCUSD_201225",
            RecvWindow = 5000L,
        };

        var response = await client.QueryCmPositionInformationAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/positionRisk", seen.Path);
        Assert.Equal("USDT", seen.Param("marginAsset"));
        Assert.Equal("BTCUSD_201225", seen.Param("pair"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCmPositionInformationBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryCmPositionInformationAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryMarginLoanRecordAsync()
    {
        const string example = """""{"rows":[{"txId":12807067523,"asset":"BNB","principal":"0.84624403","timestamp":1555056425000,"status":"CONFIRMED"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryMarginLoanRecordRequest
        {
            Asset = "USDT",
        };

        var response = await client.QueryMarginLoanRecordAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/margin/marginLoan", seen.Path);
        Assert.Equal("USDT", seen.Param("asset"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryMarginLoanRecordWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"txId":12807067523,"asset":"BNB","principal":"0.84624403","timestamp":1555056425000,"status":"CONFIRMED"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryMarginLoanRecordRequest
        {
            Asset = "USDT",
            TxId = 1L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Size = 10L,
            Archived = QueryMarginLoanRecordArchived.True,
            RecvWindow = 5000L,
        };

        var response = await client.QueryMarginLoanRecordAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/margin/marginLoan", seen.Path);
        Assert.Equal("USDT", seen.Param("asset"));
        Assert.Equal("1", seen.Param("txId"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("current"));
        Assert.Equal("10", seen.Param("size"));
        Assert.Equal("true", seen.Param("archived"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryMarginLoanRecordBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryMarginLoanRecordRequest
        {
            Asset = "USDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryMarginLoanRecordAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryMarginMaxWithdrawAsync()
    {
        const string example = """""{"amount":"60"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryMarginMaxWithdrawRequest
        {
            Asset = "USDT",
        };

        var response = await client.QueryMarginMaxWithdrawAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/margin/maxWithdraw", seen.Path);
        Assert.Equal("USDT", seen.Param("asset"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryMarginMaxWithdrawWithOptionalParametersAsync()
    {
        const string example = """""{"amount":"60"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryMarginMaxWithdrawRequest
        {
            Asset = "USDT",
            RecvWindow = 5000L,
        };

        var response = await client.QueryMarginMaxWithdrawAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/margin/maxWithdraw", seen.Path);
        Assert.Equal("USDT", seen.Param("asset"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryMarginMaxWithdrawBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryMarginMaxWithdrawRequest
        {
            Asset = "USDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryMarginMaxWithdrawAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryMarginRepayRecordAsync()
    {
        const string example = """""{"rows":[{"amount":"14.00000000","asset":"BNB","interest":"0.01866667","principal":"13.98133333","status":"CONFIRMED","timestamp":1563438204000,"txId":2970933056}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryMarginRepayRecordRequest
        {
            Asset = "USDT",
        };

        var response = await client.QueryMarginRepayRecordAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/margin/repayLoan", seen.Path);
        Assert.Equal("USDT", seen.Param("asset"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryMarginRepayRecordWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"amount":"14.00000000","asset":"BNB","interest":"0.01866667","principal":"13.98133333","status":"CONFIRMED","timestamp":1563438204000,"txId":2970933056}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryMarginRepayRecordRequest
        {
            Asset = "USDT",
            TxId = 1L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Size = 10L,
            Archived = QueryMarginRepayRecordArchived.True,
            RecvWindow = 5000L,
        };

        var response = await client.QueryMarginRepayRecordAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/margin/repayLoan", seen.Path);
        Assert.Equal("USDT", seen.Param("asset"));
        Assert.Equal("1", seen.Param("txId"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("current"));
        Assert.Equal("10", seen.Param("size"));
        Assert.Equal("true", seen.Param("archived"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryMarginRepayRecordBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryMarginRepayRecordRequest
        {
            Asset = "USDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryMarginRepayRecordAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryPortfolioMarginNegativeBalanceInterestHistoryAsync()
    {
        const string example = """""[{"asset":"USDT","interest":"24.4440","interestAccuredTime":1670227200000,"interestRate":"0.0001164","principal":"210000"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryPortfolioMarginNegativeBalanceInterestHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/portfolio/interest-history", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryPortfolioMarginNegativeBalanceInterestHistoryWithOptionalParametersAsync()
    {
        const string example = """""[{"asset":"USDT","interest":"24.4440","interestAccuredTime":1670227200000,"interestRate":"0.0001164","principal":"210000"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryPortfolioMarginNegativeBalanceInterestHistoryRequest
        {
            Asset = "USDT",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryPortfolioMarginNegativeBalanceInterestHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/portfolio/interest-history", seen.Path);
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
    public async Task QueryPortfolioMarginNegativeBalanceInterestHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryPortfolioMarginNegativeBalanceInterestHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryUmPositionInformationAsync()
    {
        const string example = """""[{"entryPrice":"0.00000","leverage":"10","markPrice":"6679.50671178","maxNotionalValue":"20000000","positionAmt":"0.000","notional":"0","symbol":"BTCUSDT","unRealizedProfit":"0.00000000","liquidationPrice":"6170.20509059","positionSide":"BOTH","updateTime":1625474304765}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryUmPositionInformationAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/positionRisk", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryUmPositionInformationWithOptionalParametersAsync()
    {
        const string example = """""[{"entryPrice":"0.00000","leverage":"10","markPrice":"6679.50671178","maxNotionalValue":"20000000","positionAmt":"0.000","notional":"0","symbol":"BTCUSDT","unRealizedProfit":"0.00000000","liquidationPrice":"6170.20509059","positionSide":"BOTH","updateTime":1625474304765}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryUmPositionInformationRequest
        {
            Symbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.QueryUmPositionInformationAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/positionRisk", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryUmPositionInformationBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryUmPositionInformationAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryUserNegativeBalanceAutoExchangeRecordAsync()
    {
        const string example = """""{"total":2,"rows":[{"startTime":1736263046841,"endTime":1736263248179,"details":[{"asset":"ETH","negativeBalance":1.10264488,"negativeMaxThreshold":5}]}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryUserNegativeBalanceAutoExchangeRecordRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var response = await client.QueryUserNegativeBalanceAutoExchangeRecordAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/portfolio/negative-balance-exchange-record", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryUserNegativeBalanceAutoExchangeRecordWithOptionalParametersAsync()
    {
        const string example = """""{"total":2,"rows":[{"startTime":1736263046841,"endTime":1736263248179,"details":[{"asset":"ETH","negativeBalance":1.10264488,"negativeMaxThreshold":5}]}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryUserNegativeBalanceAutoExchangeRecordRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryUserNegativeBalanceAutoExchangeRecordAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/portfolio/negative-balance-exchange-record", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryUserNegativeBalanceAutoExchangeRecordBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryUserNegativeBalanceAutoExchangeRecordRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryUserNegativeBalanceAutoExchangeRecordAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryUserRateLimitAsync()
    {
        const string example = """""[{"rateLimitType":"ORDERS","interval":"MINUTE","intervalNum":1,"limit":1200}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryUserRateLimitAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/rateLimit/order", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryUserRateLimitWithOptionalParametersAsync()
    {
        const string example = """""[{"rateLimitType":"ORDERS","interval":"MINUTE","intervalNum":1,"limit":1200}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryUserRateLimitRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.QueryUserRateLimitAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/rateLimit/order", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryUserRateLimitBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryUserRateLimitAsync());

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
        Assert.Equal("/papi/v1/repay-futures-negative-balance", seen.Path);
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
        Assert.Equal("/papi/v1/repay-futures-negative-balance", seen.Path);
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
    public async Task UmFuturesAccountConfigurationAsync()
    {
        const string example = """""{"feeTier":0,"canTrade":true,"canDeposit":true,"canWithdraw":true,"dualSidePosition":true,"updateTime":1724416653850,"multiAssetsMargin":false,"tradeGroupId":-1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.UmFuturesAccountConfigurationAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/accountConfig", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task UmFuturesAccountConfigurationWithOptionalParametersAsync()
    {
        const string example = """""{"feeTier":0,"canTrade":true,"canDeposit":true,"canWithdraw":true,"dualSidePosition":true,"updateTime":1724416653850,"multiAssetsMargin":false,"tradeGroupId":-1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new UmFuturesAccountConfigurationRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.UmFuturesAccountConfigurationAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/accountConfig", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task UmFuturesAccountConfigurationBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.UmFuturesAccountConfigurationAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task UmFuturesSymbolConfigurationAsync()
    {
        const string example = """""[{"symbol":"BTCUSDT","marginType":"CROSSED","isAutoAddMargin":"false","leverage":21,"maxNotionalValue":"1000000"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.UmFuturesSymbolConfigurationAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/symbolConfig", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task UmFuturesSymbolConfigurationWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"BTCUSDT","marginType":"CROSSED","isAutoAddMargin":"false","leverage":21,"maxNotionalValue":"1000000"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new UmFuturesSymbolConfigurationRequest
        {
            Symbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.UmFuturesSymbolConfigurationAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/symbolConfig", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task UmFuturesSymbolConfigurationBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.UmFuturesSymbolConfigurationAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task UmNotionalAndLeverageBracketsAsync()
    {
        const string example = """""[{"symbol":"ETHUSDT","notionalCoef":"4.0","brackets":[{"bracket":1,"initialLeverage":75,"notionalCap":10000,"notionalFloor":0,"maintMarginRatio":0.0065,"cum":0}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.UmNotionalAndLeverageBracketsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/leverageBracket", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task UmNotionalAndLeverageBracketsWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"ETHUSDT","notionalCoef":"4.0","brackets":[{"bracket":1,"initialLeverage":75,"notionalCap":10000,"notionalFloor":0,"maintMarginRatio":0.0065,"cum":0}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new UmNotionalAndLeverageBracketsRequest
        {
            Symbol = "ETHUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.UmNotionalAndLeverageBracketsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/leverageBracket", seen.Path);
        Assert.Equal("ETHUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task UmNotionalAndLeverageBracketsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.UmNotionalAndLeverageBracketsAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
