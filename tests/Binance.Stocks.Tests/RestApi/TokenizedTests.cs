//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.Stocks.RestApi;

namespace Binance.Stocks.Tests.RestApi.Tokenized;

[Trait("Category", "Native")]
public class TokenizedApiTests
{
    private static StocksRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task BstocksCorporateActionRecordsAsync()
    {
        const string example = """""{"items":[{"id":123456,"userId":100001,"assetCode":"EQ_AAPL","eventType":"FORWARD_SPLIT","amount":"10.50000000","dbModifyTime":1795593600000}],"nextTime":1795593600000,"nextId":123456}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new BstocksCorporateActionRecordsRequest
        {
            Limit = 20L,
        };

        var response = await client.BstocksCorporateActionRecordsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/bstocks/corp-action/history", seen.Path);
        Assert.Equal("20", seen.Param("limit"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task BstocksCorporateActionRecordsWithOptionalParametersAsync()
    {
        const string example = """""{"items":[{"id":123456,"userId":100001,"assetCode":"EQ_AAPL","eventType":"FORWARD_SPLIT","amount":"10.50000000","dbModifyTime":1795593600000}],"nextTime":1795593600000,"nextId":123456}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new BstocksCorporateActionRecordsRequest
        {
            Limit = 20L,
            LastTime = 1795593600000L,
            LastId = 123456L,
            RecvWindow = 5000L,
        };

        var response = await client.BstocksCorporateActionRecordsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/bstocks/corp-action/history", seen.Path);
        Assert.Equal("20", seen.Param("limit"));
        Assert.Equal("1795593600000", seen.Param("lastTime"));
        Assert.Equal("123456", seen.Param("lastId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task BstocksCorporateActionRecordsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new BstocksCorporateActionRecordsRequest
        {
            Limit = 20L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.BstocksCorporateActionRecordsAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CorporateActionRecordsAsync()
    {
        const string example = """""{"items":[{"id":123456,"userId":100001,"assetCode":"EQ_AAPL","eventType":"FORWARD_SPLIT","amount":"10.50000000","dbModifyTime":1795593600000}],"nextTime":1795593600000,"nextId":123456}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CorporateActionRecordsRequest
        {
            Limit = 20L,
        };

        var response = await client.CorporateActionRecordsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/corp-action/history", seen.Path);
        Assert.Equal("20", seen.Param("limit"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CorporateActionRecordsWithOptionalParametersAsync()
    {
        const string example = """""{"items":[{"id":123456,"userId":100001,"assetCode":"EQ_AAPL","eventType":"FORWARD_SPLIT","amount":"10.50000000","dbModifyTime":1795593600000}],"nextTime":1795593600000,"nextId":123456}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CorporateActionRecordsRequest
        {
            Limit = 20L,
            LastTime = 1795593600000L,
            LastId = 123456L,
            RecvWindow = 5000L,
        };

        var response = await client.CorporateActionRecordsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/corp-action/history", seen.Path);
        Assert.Equal("20", seen.Param("limit"));
        Assert.Equal("1795593600000", seen.Param("lastTime"));
        Assert.Equal("123456", seen.Param("lastId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CorporateActionRecordsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CorporateActionRecordsRequest
        {
            Limit = 20L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CorporateActionRecordsAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TokenizedConvertHistoryAsync()
    {
        const string example = """""{"rows":[{"underlyingAsset":"AAPL","underlyingAssetAmount":"1.000000000","tokenizedAsset":"AAPLB","tokenizedAssetAmount":"1.000000000","issuerRequestId":"mint-20260505-8f3b9e1a2d3c4b5a","convertType":"MINT","status":"S","createdAt":1735900000000,"updatedAt":1735900060000,"tokenizedAssetSettleWalletType":"CARD"}],"hasMore":true,"nextLastId":10020}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.TokenizedConvertHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/tokenized/history", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TokenizedConvertHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"underlyingAsset":"AAPL","underlyingAssetAmount":"1.000000000","tokenizedAsset":"AAPLB","tokenizedAssetAmount":"1.000000000","issuerRequestId":"mint-20260505-8f3b9e1a2d3c4b5a","convertType":"MINT","status":"S","createdAt":1735900000000,"updatedAt":1735900060000,"tokenizedAssetSettleWalletType":"CARD"}],"hasMore":true,"nextLastId":10020}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TokenizedConvertHistoryRequest
        {
            StartTime = 1735800000000L,
            EndTime = 1735900000000L,
            LastId = 10019L,
            Size = 20L,
            RecvWindow = 5000L,
        };

        var response = await client.TokenizedConvertHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/tokenized/history", seen.Path);
        Assert.Equal("1735800000000", seen.Param("startTime"));
        Assert.Equal("1735900000000", seen.Param("endTime"));
        Assert.Equal("10019", seen.Param("lastId"));
        Assert.Equal("20", seen.Param("size"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TokenizedConvertHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.TokenizedConvertHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TokenizedConvertStatusAsync()
    {
        const string example = """""{"underlyingAsset":"AAPL","underlyingAssetAmount":"1.000000000","tokenizedAsset":"AAPLB","tokenizedAssetAmount":"1.000000000","issuerRequestId":"mint-20260505-8f3b9e1a2d3c4b5a","convertType":"MINT","status":"S","createdAt":1735900000000,"updatedAt":1735900060000,"tokenizedAssetSettleWalletType":"CARD"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TokenizedConvertStatusRequest
        {
            IssuerRequestId = "mint-20260505-8f3b9e1a2d3c4b5a",
            ConvertType = TokenizedConvertStatusConvertType.Mint,
        };

        var response = await client.TokenizedConvertStatusAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/tokenized/convert-status", seen.Path);
        Assert.Equal("mint-20260505-8f3b9e1a2d3c4b5a", seen.Param("issuerRequestId"));
        Assert.Equal("MINT", seen.Param("convertType"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TokenizedConvertStatusWithOptionalParametersAsync()
    {
        const string example = """""{"underlyingAsset":"AAPL","underlyingAssetAmount":"1.000000000","tokenizedAsset":"AAPLB","tokenizedAssetAmount":"1.000000000","issuerRequestId":"mint-20260505-8f3b9e1a2d3c4b5a","convertType":"MINT","status":"S","createdAt":1735900000000,"updatedAt":1735900060000,"tokenizedAssetSettleWalletType":"CARD"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TokenizedConvertStatusRequest
        {
            IssuerRequestId = "mint-20260505-8f3b9e1a2d3c4b5a",
            ConvertType = TokenizedConvertStatusConvertType.Mint,
            RecvWindow = 5000L,
        };

        var response = await client.TokenizedConvertStatusAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/tokenized/convert-status", seen.Path);
        Assert.Equal("mint-20260505-8f3b9e1a2d3c4b5a", seen.Param("issuerRequestId"));
        Assert.Equal("MINT", seen.Param("convertType"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TokenizedConvertStatusBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new TokenizedConvertStatusRequest
        {
            IssuerRequestId = "mint-20260505-8f3b9e1a2d3c4b5a",
            ConvertType = TokenizedConvertStatusConvertType.Mint,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.TokenizedConvertStatusAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TokenizedMintAsync()
    {
        const string example = """""{"issuerRequestId":"mint-20260505-8f3b9e1a2d3c4b5a","status":"P","tokenizedAssetSettleWalletType":"CARD"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TokenizedMintRequest
        {
            UnderlyingAsset = "AAPL",
            UnderlyingAssetAmount = "1",
        };

        var response = await client.TokenizedMintAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/equity/tokenized/mint", seen.Path);
        Assert.Equal("AAPL", seen.Param("underlyingAsset"));
        Assert.Equal("1", seen.Param("underlyingAssetAmount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TokenizedMintWithOptionalParametersAsync()
    {
        const string example = """""{"issuerRequestId":"mint-20260505-8f3b9e1a2d3c4b5a","status":"P","tokenizedAssetSettleWalletType":"CARD"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TokenizedMintRequest
        {
            UnderlyingAsset = "AAPL",
            UnderlyingAssetAmount = "1",
            ClientOrderId = "mint-client-id-32chars-0000000001",
            TokenizedAssetSettleWalletType = TokenizedMintTokenizedAssetSettleWalletType.Main,
            RecvWindow = 5000L,
        };

        var response = await client.TokenizedMintAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/equity/tokenized/mint", seen.Path);
        Assert.Equal("AAPL", seen.Param("underlyingAsset"));
        Assert.Equal("1", seen.Param("underlyingAssetAmount"));
        Assert.Equal("mint-client-id-32chars-0000000001", seen.Param("clientOrderId"));
        Assert.Equal("MAIN", seen.Param("tokenizedAssetSettleWalletType"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TokenizedMintBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new TokenizedMintRequest
        {
            UnderlyingAsset = "AAPL",
            UnderlyingAssetAmount = "1",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.TokenizedMintAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TokenizedRedeemAsync()
    {
        const string example = """""{"issuerRequestId":"redeem-20260505-a1b2c3d4e5f6","status":"P","tokenizedAssetSettleWalletType":"CARD"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TokenizedRedeemRequest
        {
            TokenizedAsset = "AAPLB",
            TokenizedAssetAmount = "1",
        };

        var response = await client.TokenizedRedeemAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/equity/tokenized/redeem", seen.Path);
        Assert.Equal("AAPLB", seen.Param("tokenizedAsset"));
        Assert.Equal("1", seen.Param("tokenizedAssetAmount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TokenizedRedeemWithOptionalParametersAsync()
    {
        const string example = """""{"issuerRequestId":"redeem-20260505-a1b2c3d4e5f6","status":"P","tokenizedAssetSettleWalletType":"CARD"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TokenizedRedeemRequest
        {
            TokenizedAsset = "AAPLB",
            TokenizedAssetAmount = "1",
            ClientOrderId = "redeem-client-id-32chars-000000001",
            TokenizedAssetSettleWalletType = TokenizedRedeemTokenizedAssetSettleWalletType.Main,
            RecvWindow = 5000L,
        };

        var response = await client.TokenizedRedeemAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/equity/tokenized/redeem", seen.Path);
        Assert.Equal("AAPLB", seen.Param("tokenizedAsset"));
        Assert.Equal("1", seen.Param("tokenizedAssetAmount"));
        Assert.Equal("redeem-client-id-32chars-000000001", seen.Param("clientOrderId"));
        Assert.Equal("MAIN", seen.Param("tokenizedAssetSettleWalletType"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TokenizedRedeemBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new TokenizedRedeemRequest
        {
            TokenizedAsset = "AAPLB",
            TokenizedAssetAmount = "1",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.TokenizedRedeemAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
