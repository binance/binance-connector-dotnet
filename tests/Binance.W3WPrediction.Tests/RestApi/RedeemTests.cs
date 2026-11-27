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

namespace Binance.W3WPrediction.Tests.RestApi.Redeem;

[Trait("Category", "Native")]
public class RedeemApiTests
{
    private static W3WPredictionRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task BatchRedeemAsync()
    {
        const string example = """""{"batchId":"batch_20260525_redeem_001","results":[{"requestId":"req_001","txHash":"0xabc123def456789abcdef123456789abcdef123456789abcdef123456789abcd","status":"PENDING","error":"error"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new BatchRedeemRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            WalletId = "5b5c1ec3be4e4416a5872b21c1ca5d20",
            TokenIds = new() { },
        };

        var response = await client.BatchRedeemAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/batch-redeem", seen.Path);
        Assert.Equal("0x12e32db8817e292508c34111cbc4b23340df542c", seen.Param("walletAddress"));
        Assert.Equal("5b5c1ec3be4e4416a5872b21c1ca5d20", seen.Param("walletId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task BatchRedeemWithOptionalParametersAsync()
    {
        const string example = """""{"batchId":"batch_20260525_redeem_001","results":[{"requestId":"req_001","txHash":"0xabc123def456789abcdef123456789abcdef123456789abcdef123456789abcd","status":"PENDING","error":"error"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new BatchRedeemRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            WalletId = "5b5c1ec3be4e4416a5872b21c1ca5d20",
            TokenIds = new() { },
            ChainId = "56",
        };

        var response = await client.BatchRedeemAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/batch-redeem", seen.Path);
        Assert.Equal("0x12e32db8817e292508c34111cbc4b23340df542c", seen.Param("walletAddress"));
        Assert.Equal("5b5c1ec3be4e4416a5872b21c1ca5d20", seen.Param("walletId"));
        Assert.Equal("56", seen.Param("chainId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task BatchRedeemBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new BatchRedeemRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            WalletId = "5b5c1ec3be4e4416a5872b21c1ca5d20",
            TokenIds = new() { },
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.BatchRedeemAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetRedeemStatusAsync()
    {
        const string example = """""{"txHash":"0xabc123def456789abcdef123456789abcdef123456789abcdef123456789abcd","status":"CONFIRMED"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetRedeemStatusRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            TxHash = "0xabc123def456789abcdef123456789abcdef123456789abcdef123456789abcd",
        };

        var response = await client.GetRedeemStatusAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/redeem/status", seen.Path);
        Assert.Equal("0x12e32db8817e292508c34111cbc4b23340df542c", seen.Param("walletAddress"));
        Assert.Equal("0xabc123def456789abcdef123456789abcdef123456789abcdef123456789abcd", seen.Param("txHash"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetRedeemStatusWithOptionalParametersAsync()
    {
        const string example = """""{"txHash":"0xabc123def456789abcdef123456789abcdef123456789abcdef123456789abcd","status":"CONFIRMED"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetRedeemStatusRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            TxHash = "0xabc123def456789abcdef123456789abcdef123456789abcdef123456789abcd",
            RecvWindow = 5000L,
        };

        var response = await client.GetRedeemStatusAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/redeem/status", seen.Path);
        Assert.Equal("0x12e32db8817e292508c34111cbc4b23340df542c", seen.Param("walletAddress"));
        Assert.Equal("0xabc123def456789abcdef123456789abcdef123456789abcdef123456789abcd", seen.Param("txHash"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetRedeemStatusBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetRedeemStatusRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            TxHash = "0xabc123def456789abcdef123456789abcdef123456789abcdef123456789abcd",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetRedeemStatusAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
