//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.GiftCard.RestApi;

namespace Binance.GiftCard.Tests.RestApi.MarketData;

[Trait("Category", "Native")]
public class MarketDataApiTests
{
    private static GiftCardRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task CreateADualTokenGiftCardAsync()
    {
        const string example = """""{"code":"000000","message":"success","data":{"referenceNo":"0033002144060553","code":"6H9EKF5ECCWFBHGE","expiredTime":1727417154000},"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CreateADualTokenGiftCardRequest
        {
            BaseToken = "BUSD",
            FaceToken = "BNB",
            BaseTokenAmount = 1m,
        };

        var response = await client.CreateADualTokenGiftCardAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/giftcard/buyCode", seen.Path);
        Assert.Equal("BUSD", seen.Param("baseToken"));
        Assert.Equal("BNB", seen.Param("faceToken"));
        Assert.Equal("1", seen.Param("baseTokenAmount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CreateADualTokenGiftCardWithOptionalParametersAsync()
    {
        const string example = """""{"code":"000000","message":"success","data":{"referenceNo":"0033002144060553","code":"6H9EKF5ECCWFBHGE","expiredTime":1727417154000},"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CreateADualTokenGiftCardRequest
        {
            BaseToken = "BUSD",
            FaceToken = "BNB",
            BaseTokenAmount = 1m,
            RecvWindow = 5000L,
        };

        var response = await client.CreateADualTokenGiftCardAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/giftcard/buyCode", seen.Path);
        Assert.Equal("BUSD", seen.Param("baseToken"));
        Assert.Equal("BNB", seen.Param("faceToken"));
        Assert.Equal("1", seen.Param("baseTokenAmount"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CreateADualTokenGiftCardBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CreateADualTokenGiftCardRequest
        {
            BaseToken = "BUSD",
            FaceToken = "BNB",
            BaseTokenAmount = 1m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CreateADualTokenGiftCardAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CreateASingleTokenGiftCardAsync()
    {
        const string example = """""{"code":"000000","message":"success","data":{"referenceNo":"0033002144060553","code":"6H9EKF5ECCWFBHGE","expiredTime":1727417154000},"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CreateASingleTokenGiftCardRequest
        {
            Token = "BNB",
            Amount = 1m,
        };

        var response = await client.CreateASingleTokenGiftCardAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/giftcard/createCode", seen.Path);
        Assert.Equal("BNB", seen.Param("token"));
        Assert.Equal("1", seen.Param("amount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CreateASingleTokenGiftCardWithOptionalParametersAsync()
    {
        const string example = """""{"code":"000000","message":"success","data":{"referenceNo":"0033002144060553","code":"6H9EKF5ECCWFBHGE","expiredTime":1727417154000},"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CreateASingleTokenGiftCardRequest
        {
            Token = "BNB",
            Amount = 1m,
            RecvWindow = 5000L,
        };

        var response = await client.CreateASingleTokenGiftCardAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/giftcard/createCode", seen.Path);
        Assert.Equal("BNB", seen.Param("token"));
        Assert.Equal("1", seen.Param("amount"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CreateASingleTokenGiftCardBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CreateASingleTokenGiftCardRequest
        {
            Token = "BNB",
            Amount = 1m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CreateASingleTokenGiftCardAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task FetchRsaPublicKeyAsync()
    {
        const string example = """""{"code":"000000","message":"success","data":"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCXBBVKLAc1GQ5FsIFFqOHrPTox5noBONIKr+IAedTR9FkVxq6e65updEbfdhRNkMOeYIO2i0UylrjGC0X8YSoIszmrVHeV0l06Zh1oJuZos1+7N+WLuz9JvlPaawof3GUakTxYWWCa9+8KIbLKsoKMdfS96VT+8iOXO3quMGKUmQIDAQAB","success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.FetchRsaPublicKeyAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/giftcard/cryptography/rsa-public-key", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FetchRsaPublicKeyWithOptionalParametersAsync()
    {
        const string example = """""{"code":"000000","message":"success","data":"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCXBBVKLAc1GQ5FsIFFqOHrPTox5noBONIKr+IAedTR9FkVxq6e65updEbfdhRNkMOeYIO2i0UylrjGC0X8YSoIszmrVHeV0l06Zh1oJuZos1+7N+WLuz9JvlPaawof3GUakTxYWWCa9+8KIbLKsoKMdfS96VT+8iOXO3quMGKUmQIDAQAB","success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new FetchRsaPublicKeyRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.FetchRsaPublicKeyAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/giftcard/cryptography/rsa-public-key", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FetchRsaPublicKeyBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.FetchRsaPublicKeyAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task FetchTokenLimitAsync()
    {
        const string example = """""{"code":"000000","message":"success","data":[{"coin":"BNB","fromMin":"0.01","fromMax":"1"}],"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new FetchTokenLimitRequest
        {
            BaseToken = "BUSD",
        };

        var response = await client.FetchTokenLimitAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/giftcard/buyCode/token-limit", seen.Path);
        Assert.Equal("BUSD", seen.Param("baseToken"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FetchTokenLimitWithOptionalParametersAsync()
    {
        const string example = """""{"code":"000000","message":"success","data":[{"coin":"BNB","fromMin":"0.01","fromMax":"1"}],"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new FetchTokenLimitRequest
        {
            BaseToken = "BUSD",
            RecvWindow = 5000L,
        };

        var response = await client.FetchTokenLimitAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/giftcard/buyCode/token-limit", seen.Path);
        Assert.Equal("BUSD", seen.Param("baseToken"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FetchTokenLimitBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new FetchTokenLimitRequest
        {
            BaseToken = "BUSD",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.FetchTokenLimitAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task RedeemABinanceGiftCardAsync()
    {
        const string example = """""{"code":"000000","message":"success","data":{"referenceNo":"0033002328060227","identityNo":"10317392647411060736","token":"BNB","amount":"0.00000001"},"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new RedeemABinanceGiftCardRequest
        {
            Code = "6H9EKF5ECCWFBHGE",
        };

        var response = await client.RedeemABinanceGiftCardAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/giftcard/redeemCode", seen.Path);
        Assert.Equal("6H9EKF5ECCWFBHGE", seen.Param("code"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task RedeemABinanceGiftCardWithOptionalParametersAsync()
    {
        const string example = """""{"code":"000000","message":"success","data":{"referenceNo":"0033002328060227","identityNo":"10317392647411060736","token":"BNB","amount":"0.00000001"},"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new RedeemABinanceGiftCardRequest
        {
            Code = "6H9EKF5ECCWFBHGE",
            ExternalUid = "user-123",
            RecvWindow = 5000L,
        };

        var response = await client.RedeemABinanceGiftCardAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/giftcard/redeemCode", seen.Path);
        Assert.Equal("6H9EKF5ECCWFBHGE", seen.Param("code"));
        Assert.Equal("user-123", seen.Param("externalUid"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task RedeemABinanceGiftCardBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new RedeemABinanceGiftCardRequest
        {
            Code = "6H9EKF5ECCWFBHGE",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.RedeemABinanceGiftCardAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task VerifyBinanceGiftCardByGiftCardNumberAsync()
    {
        const string example = """""{"code":"000000","message":"success","data":{"valid":true,"token":"BNB","amount":"0.00000001"},"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new VerifyBinanceGiftCardByGiftCardNumberRequest
        {
            ReferenceNo = "0033002328060227",
        };

        var response = await client.VerifyBinanceGiftCardByGiftCardNumberAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/giftcard/verify", seen.Path);
        Assert.Equal("0033002328060227", seen.Param("referenceNo"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task VerifyBinanceGiftCardByGiftCardNumberWithOptionalParametersAsync()
    {
        const string example = """""{"code":"000000","message":"success","data":{"valid":true,"token":"BNB","amount":"0.00000001"},"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new VerifyBinanceGiftCardByGiftCardNumberRequest
        {
            ReferenceNo = "0033002328060227",
            RecvWindow = 5000L,
        };

        var response = await client.VerifyBinanceGiftCardByGiftCardNumberAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/giftcard/verify", seen.Path);
        Assert.Equal("0033002328060227", seen.Param("referenceNo"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task VerifyBinanceGiftCardByGiftCardNumberBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new VerifyBinanceGiftCardByGiftCardNumberRequest
        {
            ReferenceNo = "0033002328060227",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.VerifyBinanceGiftCardByGiftCardNumberAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
