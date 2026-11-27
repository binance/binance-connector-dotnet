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

namespace Binance.W3WPrediction.Tests.RestApi.Transfer;

[Trait("Category", "Native")]
public class TransferApiTests
{
    private static W3WPredictionRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task ApplyMmDepositAsync()
    {
        const string example = """""{"transferId":"26080400000000454343","status":"PROCESSING"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ApplyMmDepositRequest
        {
            FromToken = "USDT",
            FromTokenAmount = "1000000000000000000",
            ToToken = "USDT",
            AccountType = ApplyMmDepositAccountType.Spot,
        };

        var response = await client.ApplyMmDepositAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/deposit/apply", seen.Path);
        Assert.Equal("USDT", seen.Param("fromToken"));
        Assert.Equal("1000000000000000000", seen.Param("fromTokenAmount"));
        Assert.Equal("USDT", seen.Param("toToken"));
        Assert.Equal("SPOT", seen.Param("accountType"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ApplyMmDepositWithOptionalParametersAsync()
    {
        const string example = """""{"transferId":"26080400000000454343","status":"PROCESSING"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ApplyMmDepositRequest
        {
            FromToken = "USDT",
            FromTokenAmount = "1000000000000000000",
            ToToken = "USDT",
            AccountType = ApplyMmDepositAccountType.Spot,
            ChainId = "56",
        };

        var response = await client.ApplyMmDepositAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/deposit/apply", seen.Path);
        Assert.Equal("USDT", seen.Param("fromToken"));
        Assert.Equal("1000000000000000000", seen.Param("fromTokenAmount"));
        Assert.Equal("USDT", seen.Param("toToken"));
        Assert.Equal("SPOT", seen.Param("accountType"));
        Assert.Equal("56", seen.Param("chainId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ApplyMmDepositBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new ApplyMmDepositRequest
        {
            FromToken = "USDT",
            FromTokenAmount = "1000000000000000000",
            ToToken = "USDT",
            AccountType = ApplyMmDepositAccountType.Spot,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ApplyMmDepositAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ApplyMmWithdrawAsync()
    {
        const string example = """""{"id":"123456789","walletId":"0ecd3be8e3674b54b1258e24f9c3706b","walletAddress":"0x2ac3a1fb164da5c4e76f67ae6dbe6be821c000c8","transferId":"26080400000000454344"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ApplyMmWithdrawRequest
        {
            Coin = "USDT",
            Network = "BEP20",
            Amount = "100.00",
        };

        var response = await client.ApplyMmWithdrawAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/withdraw/apply", seen.Path);
        Assert.Equal("USDT", seen.Param("coin"));
        Assert.Equal("BEP20", seen.Param("network"));
        Assert.Equal("100.00", seen.Param("amount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ApplyMmWithdrawWithOptionalParametersAsync()
    {
        const string example = """""{"id":"123456789","walletId":"0ecd3be8e3674b54b1258e24f9c3706b","walletAddress":"0x2ac3a1fb164da5c4e76f67ae6dbe6be821c000c8","transferId":"26080400000000454344"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ApplyMmWithdrawRequest
        {
            Coin = "USDT",
            Network = "BEP20",
            Amount = "100.00",
            WithdrawOrderId = "wd_20260814_001",
            WalletType = ApplyMmWithdrawWalletType.WalletType0,
            Name = "MM withdraw",
        };

        var response = await client.ApplyMmWithdrawAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/withdraw/apply", seen.Path);
        Assert.Equal("USDT", seen.Param("coin"));
        Assert.Equal("BEP20", seen.Param("network"));
        Assert.Equal("100.00", seen.Param("amount"));
        Assert.Equal("wd_20260814_001", seen.Param("withdrawOrderId"));
        Assert.Equal("0", seen.Param("walletType"));
        Assert.Equal("MM withdraw", seen.Param("name"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ApplyMmWithdrawBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new ApplyMmWithdrawRequest
        {
            Coin = "USDT",
            Network = "BEP20",
            Amount = "100.00",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ApplyMmWithdrawAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CreateInboundTransferAsync()
    {
        const string example = """""{"transferId":"tf_20260525_in_001","status":"PROCESSING"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CreateInboundTransferRequest
        {
            WalletId = "5b5c1ec3be4e4416a5872b21c1ca5d20",
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            FromTokenAmount = "1000000000000000000",
            AccountType = CreateInboundTransferAccountType.Spot,
        };

        var response = await client.CreateInboundTransferAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/transfer/inbound", seen.Path);
        Assert.Equal("5b5c1ec3be4e4416a5872b21c1ca5d20", seen.Param("walletId"));
        Assert.Equal("0x12e32db8817e292508c34111cbc4b23340df542c", seen.Param("walletAddress"));
        Assert.Equal("1000000000000000000", seen.Param("fromTokenAmount"));
        Assert.Equal("SPOT", seen.Param("accountType"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CreateInboundTransferWithOptionalParametersAsync()
    {
        const string example = """""{"transferId":"tf_20260525_in_001","status":"PROCESSING"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CreateInboundTransferRequest
        {
            WalletId = "5b5c1ec3be4e4416a5872b21c1ca5d20",
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            FromTokenAmount = "1000000000000000000",
            AccountType = CreateInboundTransferAccountType.Spot,
            FromToken = "USDT",
            ToToken = "USDT",
            ChainId = "56",
        };

        var response = await client.CreateInboundTransferAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/transfer/inbound", seen.Path);
        Assert.Equal("5b5c1ec3be4e4416a5872b21c1ca5d20", seen.Param("walletId"));
        Assert.Equal("0x12e32db8817e292508c34111cbc4b23340df542c", seen.Param("walletAddress"));
        Assert.Equal("1000000000000000000", seen.Param("fromTokenAmount"));
        Assert.Equal("SPOT", seen.Param("accountType"));
        Assert.Equal("USDT", seen.Param("fromToken"));
        Assert.Equal("USDT", seen.Param("toToken"));
        Assert.Equal("56", seen.Param("chainId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CreateInboundTransferBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CreateInboundTransferRequest
        {
            WalletId = "5b5c1ec3be4e4416a5872b21c1ca5d20",
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            FromTokenAmount = "1000000000000000000",
            AccountType = CreateInboundTransferAccountType.Spot,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CreateInboundTransferAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CreateOutboundTransferAsync()
    {
        const string example = """""{"transferId":"tf_20260525_out_001","status":"PROCESSING"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CreateOutboundTransferRequest
        {
            WalletId = "5b5c1ec3be4e4416a5872b21c1ca5d20",
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            FromTokenAmount = "1000000000000000000",
            AccountType = CreateOutboundTransferAccountType.Spot,
            SourceBiz = CreateOutboundTransferSourceBiz.UserTransfer,
        };

        var response = await client.CreateOutboundTransferAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/transfer/outbound", seen.Path);
        Assert.Equal("5b5c1ec3be4e4416a5872b21c1ca5d20", seen.Param("walletId"));
        Assert.Equal("0x12e32db8817e292508c34111cbc4b23340df542c", seen.Param("walletAddress"));
        Assert.Equal("1000000000000000000", seen.Param("fromTokenAmount"));
        Assert.Equal("SPOT", seen.Param("accountType"));
        Assert.Equal("USER_TRANSFER", seen.Param("sourceBiz"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CreateOutboundTransferWithOptionalParametersAsync()
    {
        const string example = """""{"transferId":"tf_20260525_out_001","status":"PROCESSING"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CreateOutboundTransferRequest
        {
            WalletId = "5b5c1ec3be4e4416a5872b21c1ca5d20",
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            FromTokenAmount = "1000000000000000000",
            AccountType = CreateOutboundTransferAccountType.Spot,
            SourceBiz = CreateOutboundTransferSourceBiz.UserTransfer,
            FromToken = "USDT",
            ToToken = "USDT",
            ChainId = "56",
        };

        var response = await client.CreateOutboundTransferAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/transfer/outbound", seen.Path);
        Assert.Equal("5b5c1ec3be4e4416a5872b21c1ca5d20", seen.Param("walletId"));
        Assert.Equal("0x12e32db8817e292508c34111cbc4b23340df542c", seen.Param("walletAddress"));
        Assert.Equal("1000000000000000000", seen.Param("fromTokenAmount"));
        Assert.Equal("SPOT", seen.Param("accountType"));
        Assert.Equal("USER_TRANSFER", seen.Param("sourceBiz"));
        Assert.Equal("USDT", seen.Param("fromToken"));
        Assert.Equal("USDT", seen.Param("toToken"));
        Assert.Equal("56", seen.Param("chainId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CreateOutboundTransferBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CreateOutboundTransferRequest
        {
            WalletId = "5b5c1ec3be4e4416a5872b21c1ca5d20",
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            FromTokenAmount = "1000000000000000000",
            AccountType = CreateOutboundTransferAccountType.Spot,
            SourceBiz = CreateOutboundTransferSourceBiz.UserTransfer,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CreateOutboundTransferAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryTransferListAsync()
    {
        const string example = """""{"transfers":[{"transferId":"tf_20260525_out_001","direction":"OUTBOUND","status":"SUCCESS","walletAddress":"0x12e32db8817e292508c34111cbc4b23340df542c","fromToken":"USDT","fromTokenAmount":"100.00","toToken":"USDT","toTokenAmount":"100.00","errorCode":"errorCode","errorMessage":"errorMessage","createTime":"2026-05-25T04:00:00.000+00:00","updateTime":"2026-05-25T04:00:05.000+00:00","completeAt":"2026-05-25T04:00:05.000+00:00"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryTransferListRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            StartDate = "2026-05-01",
            EndDate = "2026-05-25",
        };

        var response = await client.QueryTransferListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/transfer/list", seen.Path);
        Assert.Equal("0x12e32db8817e292508c34111cbc4b23340df542c", seen.Param("walletAddress"));
        Assert.Equal("2026-05-01", seen.Param("startDate"));
        Assert.Equal("2026-05-25", seen.Param("endDate"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryTransferListWithOptionalParametersAsync()
    {
        const string example = """""{"transfers":[{"transferId":"tf_20260525_out_001","direction":"OUTBOUND","status":"SUCCESS","walletAddress":"0x12e32db8817e292508c34111cbc4b23340df542c","fromToken":"USDT","fromTokenAmount":"100.00","toToken":"USDT","toTokenAmount":"100.00","errorCode":"errorCode","errorMessage":"errorMessage","createTime":"2026-05-25T04:00:00.000+00:00","updateTime":"2026-05-25T04:00:05.000+00:00","completeAt":"2026-05-25T04:00:05.000+00:00"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryTransferListRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            StartDate = "2026-05-01",
            EndDate = "2026-05-25",
            TokenSymbol = "USDT",
            Direction = QueryTransferListDirection.Inbound,
            Offset = 0L,
            Limit = 20L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryTransferListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/transfer/list", seen.Path);
        Assert.Equal("0x12e32db8817e292508c34111cbc4b23340df542c", seen.Param("walletAddress"));
        Assert.Equal("2026-05-01", seen.Param("startDate"));
        Assert.Equal("2026-05-25", seen.Param("endDate"));
        Assert.Equal("USDT", seen.Param("tokenSymbol"));
        Assert.Equal("INBOUND", seen.Param("direction"));
        Assert.Equal("0", seen.Param("offset"));
        Assert.Equal("20", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryTransferListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryTransferListRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            StartDate = "2026-05-01",
            EndDate = "2026-05-25",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryTransferListAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryTransferStatusAsync()
    {
        const string example = """""{"transferId":"tf_20260525_out_001","direction":"OUTBOUND","status":"COMPLETED","fromToken":"USDT","fromTokenAmount":"100.00","toToken":"USDT","toTokenAmount":"100.00","errorCode":"errorCode","errorMessage":"errorMessage","createTime":"2026-05-25T04:00:00.000+00:00","updateTime":"2026-05-25T04:00:05.000+00:00"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryTransferStatusRequest
        {
            TransferId = "tf_20260525_out_001",
        };

        var response = await client.QueryTransferStatusAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/transfer/status", seen.Path);
        Assert.Equal("tf_20260525_out_001", seen.Param("transferId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryTransferStatusWithOptionalParametersAsync()
    {
        const string example = """""{"transferId":"tf_20260525_out_001","direction":"OUTBOUND","status":"COMPLETED","fromToken":"USDT","fromTokenAmount":"100.00","toToken":"USDT","toTokenAmount":"100.00","errorCode":"errorCode","errorMessage":"errorMessage","createTime":"2026-05-25T04:00:00.000+00:00","updateTime":"2026-05-25T04:00:05.000+00:00"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryTransferStatusRequest
        {
            TransferId = "tf_20260525_out_001",
            RecvWindow = 5000L,
        };

        var response = await client.QueryTransferStatusAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/transfer/status", seen.Path);
        Assert.Equal("tf_20260525_out_001", seen.Param("transferId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryTransferStatusBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryTransferStatusRequest
        {
            TransferId = "tf_20260525_out_001",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryTransferStatusAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
