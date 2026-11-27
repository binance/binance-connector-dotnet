//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.Wallet.RestApi;

namespace Binance.Wallet.Tests.RestApi.Asset;

[Trait("Category", "Native")]
public class AssetApiTests
{
    private static WalletRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task AssetDetailAsync()
    {
        const string example = """""{"CTR":{"minWithdrawAmount":"70.00000000","depositStatus":false,"withdrawFee":35,"withdrawStatus":true,"depositTip":"Delisted, Deposit Suspended"},"SKY":{"minWithdrawAmount":"0.02000000","depositStatus":true,"withdrawFee":0.01,"withdrawStatus":true}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.AssetDetailAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/asset/assetDetail", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AssetDetailWithOptionalParametersAsync()
    {
        const string example = """""{"CTR":{"minWithdrawAmount":"70.00000000","depositStatus":false,"withdrawFee":35,"withdrawStatus":true,"depositTip":"Delisted, Deposit Suspended"},"SKY":{"minWithdrawAmount":"0.02000000","depositStatus":true,"withdrawFee":0.01,"withdrawStatus":true}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AssetDetailRequest
        {
            Asset = "BTC",
            RecvWindow = 5000L,
        };

        var response = await client.AssetDetailAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/asset/assetDetail", seen.Path);
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AssetDetailBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AssetDetailAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task AssetDividendRecordAsync()
    {
        const string example = """""{"rows":[{"id":1637366104,"amount":"10.00000000","asset":"BHFT","divTime":1563189166000,"enInfo":"BHFT distribution","tranId":2968885920,"direction":1}],"total":2}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.AssetDividendRecordAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/asset/assetDividend", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AssetDividendRecordWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"id":1637366104,"amount":"10.00000000","asset":"BHFT","divTime":1563189166000,"enInfo":"BHFT distribution","tranId":2968885920,"direction":1}],"total":2}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AssetDividendRecordRequest
        {
            Asset = "BTC",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 20L,
            RecvWindow = 5000L,
        };

        var response = await client.AssetDividendRecordAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/asset/assetDividend", seen.Path);
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("20", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AssetDividendRecordBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AssetDividendRecordAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task DustConvertAsync()
    {
        const string example = """""{"totalTransfered":"3.5971223","totalServiceCharge":"0.0794964","transferResult":[{"tranId":2987331510,"fromAsset":"USDT","amount":"1","transferedAmount":"3.5971223","serviceChargeAmount":"0.0794964","operateTime":1765212029749}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DustConvertRequest
        {
            Asset = "USDT",
        };

        var response = await client.DustConvertAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/asset/dust-convert/convert", seen.Path);
        Assert.Equal("USDT", seen.Param("asset"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DustConvertWithOptionalParametersAsync()
    {
        const string example = """""{"totalTransfered":"3.5971223","totalServiceCharge":"0.0794964","transferResult":[{"tranId":2987331510,"fromAsset":"USDT","amount":"1","transferedAmount":"3.5971223","serviceChargeAmount":"0.0794964","operateTime":1765212029749}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DustConvertRequest
        {
            Asset = "USDT",
            AccountType = "SPOT",
            ClientId = "1",
            TargetAsset = "BTC",
            ThirdPartyClientId = "1",
            DustQuotaAssetToTargetAssetPrice = 1.0m,
        };

        var response = await client.DustConvertAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/asset/dust-convert/convert", seen.Path);
        Assert.Equal("USDT", seen.Param("asset"));
        Assert.Equal("SPOT", seen.Param("accountType"));
        Assert.Equal("1", seen.Param("clientId"));
        Assert.Equal("BTC", seen.Param("targetAsset"));
        Assert.Equal("1", seen.Param("thirdPartyClientId"));
        Assert.Equal("1.0", seen.Param("dustQuotaAssetToTargetAssetPrice"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DustConvertBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new DustConvertRequest
        {
            Asset = "USDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.DustConvertAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task DustConvertibleAssetsAsync()
    {
        const string example = """""{"dribbletPercentage":"0.02","totalTransferQuotaAssetAmount":"0.7899968","totalTransferTargetAssetAmount":"0.7899968","dribbletBase":"10","details":[{"asset":"AR","assetFullName":"AR","amountFree":"0.00856","exchange":"0.00073616","toQuotaAssetAmount":"0.036808","toTargetAssetAmount":"0.036808","toTargetAssetOffExchange":"0.03607184"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DustConvertibleAssetsRequest
        {
            TargetAsset = "BTC",
        };

        var response = await client.DustConvertibleAssetsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/asset/dust-convert/query-convertible-assets", seen.Path);
        Assert.Equal("BTC", seen.Param("targetAsset"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DustConvertibleAssetsWithOptionalParametersAsync()
    {
        const string example = """""{"dribbletPercentage":"0.02","totalTransferQuotaAssetAmount":"0.7899968","totalTransferTargetAssetAmount":"0.7899968","dribbletBase":"10","details":[{"asset":"AR","assetFullName":"AR","amountFree":"0.00856","exchange":"0.00073616","toQuotaAssetAmount":"0.036808","toTargetAssetAmount":"0.036808","toTargetAssetOffExchange":"0.03607184"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DustConvertibleAssetsRequest
        {
            TargetAsset = "BTC",
            AccountType = "SPOT",
            DustQuotaAssetToTargetAssetPrice = 1.0m,
        };

        var response = await client.DustConvertibleAssetsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/asset/dust-convert/query-convertible-assets", seen.Path);
        Assert.Equal("BTC", seen.Param("targetAsset"));
        Assert.Equal("SPOT", seen.Param("accountType"));
        Assert.Equal("1.0", seen.Param("dustQuotaAssetToTargetAssetPrice"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DustConvertibleAssetsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new DustConvertibleAssetsRequest
        {
            TargetAsset = "BTC",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.DustConvertibleAssetsAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task DustTransferAsync()
    {
        const string example = """""{"totalServiceCharge":"0.02102542","totalTransfered":"1.05127099","transferResult":[{"amount":"0.03000000","fromAsset":"ETH","operateTime":1563368549307,"serviceChargeAmount":"0.00500000","tranId":2970932918,"transferedAmount":"0.25000000"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DustTransferRequest
        {
            Asset = "BTC",
        };

        var response = await client.DustTransferAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/asset/dust", seen.Path);
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DustTransferWithOptionalParametersAsync()
    {
        const string example = """""{"totalServiceCharge":"0.02102542","totalTransfered":"1.05127099","transferResult":[{"amount":"0.03000000","fromAsset":"ETH","operateTime":1563368549307,"serviceChargeAmount":"0.00500000","tranId":2970932918,"transferedAmount":"0.25000000"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DustTransferRequest
        {
            Asset = "BTC",
            AccountType = DustTransferAccountType.Spot,
            RecvWindow = 5000L,
        };

        var response = await client.DustTransferAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/asset/dust", seen.Path);
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("SPOT", seen.Param("accountType"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DustTransferBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new DustTransferRequest
        {
            Asset = "BTC",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.DustTransferAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task DustlogAsync()
    {
        const string example = """""{"total":8,"userAssetDribblets":[{"operateTime":1615985535000,"totalTransferedAmount":"0.00132256","totalServiceChargeAmount":"0.00002699","transId":45178372831,"userAssetDribbletDetails":[{"transId":4359321,"serviceChargeAmount":"0.000009","amount":"0.0009","operateTime":1615985535000,"transferedAmount":"0.000441","fromAsset":"USDT","targetAsset":"BNB"}]}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.DustlogAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/asset/dribblet", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DustlogWithOptionalParametersAsync()
    {
        const string example = """""{"total":8,"userAssetDribblets":[{"operateTime":1615985535000,"totalTransferedAmount":"0.00132256","totalServiceChargeAmount":"0.00002699","transId":45178372831,"userAssetDribbletDetails":[{"transId":4359321,"serviceChargeAmount":"0.000009","amount":"0.0009","operateTime":1615985535000,"transferedAmount":"0.000441","fromAsset":"USDT","targetAsset":"BNB"}]}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DustlogRequest
        {
            AccountType = DustlogAccountType.Spot,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            RecvWindow = 5000L,
        };

        var response = await client.DustlogAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/asset/dribblet", seen.Path);
        Assert.Equal("SPOT", seen.Param("accountType"));
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
    public async Task DustlogBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.DustlogAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task FundingWalletAsync()
    {
        const string example = """""[{"asset":"USDT","free":"1","locked":"0","freeze":"0","withdrawing":"0","btcValuation":"0.00000091"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.FundingWalletAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/asset/get-funding-asset", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FundingWalletWithOptionalParametersAsync()
    {
        const string example = """""[{"asset":"USDT","free":"1","locked":"0","freeze":"0","withdrawing":"0","btcValuation":"0.00000091"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new FundingWalletRequest
        {
            Asset = "BTC",
            NeedBtcValuation = true,
            RecvWindow = 5000L,
        };

        var response = await client.FundingWalletAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/asset/get-funding-asset", seen.Path);
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("true", seen.Param("needBtcValuation"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FundingWalletBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.FundingWalletAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetAssetsThatCanBeConvertedIntoBnbAsync()
    {
        const string example = """""{"details":[{"asset":"ADA","assetFullName":"ADA","amountFree":"6.21","toBTC":"0.00016848","toBNB":"0.01777302","toBNBOffExchange":"0.01741756","exchange":"0.00035546"}],"totalTransferBtc":"0.00016848","totalTransferBNB":"0.01777302","dribbletPercentage":"0.02"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetAssetsThatCanBeConvertedIntoBnbAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/asset/dust-btc", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetAssetsThatCanBeConvertedIntoBnbWithOptionalParametersAsync()
    {
        const string example = """""{"details":[{"asset":"ADA","assetFullName":"ADA","amountFree":"6.21","toBTC":"0.00016848","toBNB":"0.01777302","toBNBOffExchange":"0.01741756","exchange":"0.00035546"}],"totalTransferBtc":"0.00016848","totalTransferBNB":"0.01777302","dribbletPercentage":"0.02"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetAssetsThatCanBeConvertedIntoBnbRequest
        {
            AccountType = GetAssetsThatCanBeConvertedIntoBnbAccountType.Spot,
            RecvWindow = 5000L,
        };

        var response = await client.GetAssetsThatCanBeConvertedIntoBnbAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/asset/dust-btc", seen.Path);
        Assert.Equal("SPOT", seen.Param("accountType"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetAssetsThatCanBeConvertedIntoBnbBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetAssetsThatCanBeConvertedIntoBnbAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetCloudMiningPaymentAndRefundHistoryAsync()
    {
        const string example = """""{"total":5,"rows":[{"createTime":1667880112000,"tranId":121230610120,"type":248,"asset":"USDT","amount":"25.0068","status":"S"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetCloudMiningPaymentAndRefundHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var response = await client.GetCloudMiningPaymentAndRefundHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/asset/ledger-transfer/cloud-mining/queryByPage", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetCloudMiningPaymentAndRefundHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"total":5,"rows":[{"createTime":1667880112000,"tranId":121230610120,"type":248,"asset":"USDT","amount":"25.0068","status":"S"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetCloudMiningPaymentAndRefundHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            TranId = 1L,
            ClientTranId = "1",
            Asset = "BTC",
            Current = 1L,
            Size = 10L,
        };

        var response = await client.GetCloudMiningPaymentAndRefundHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/asset/ledger-transfer/cloud-mining/queryByPage", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("tranId"));
        Assert.Equal("1", seen.Param("clientTranId"));
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("1", seen.Param("current"));
        Assert.Equal("10", seen.Param("size"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetCloudMiningPaymentAndRefundHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetCloudMiningPaymentAndRefundHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetCloudMiningPaymentAndRefundHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetOpenSymbolListAsync()
    {
        const string example = """""[{"openTime":1686161202000,"symbols":["BNBBTC"]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetOpenSymbolListAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/spot/open-symbol-list", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetOpenSymbolListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetOpenSymbolListAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetSpotAssetTagsAsync()
    {
        const string example = """""[{"assetCode":"BNB","assetName":"BNB","trading":true,"tags":["Layer1_Layer2","BSC"]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetSpotAssetTagsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/spot/asset/tags", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetSpotAssetTagsWithOptionalParametersAsync()
    {
        const string example = """""[{"assetCode":"BNB","assetName":"BNB","trading":true,"tags":["Layer1_Layer2","BSC"]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetSpotAssetTagsRequest
        {
            Tag = "Layer1_Layer2,BSC",
        };

        var response = await client.GetSpotAssetTagsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/spot/asset/tags", seen.Path);
        Assert.Equal("Layer1_Layer2,BSC", seen.Param("tag"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetSpotAssetTagsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetSpotAssetTagsAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryUserDelegationHistoryAsync()
    {
        const string example = """""{"total":3316,"rows":[{"clientTranId":"293915932290879488","transferType":"Undelegate","asset":"ETH","amount":"1","time":1695205406000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryUserDelegationHistoryRequest
        {
            Email = "abc@test.com",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var response = await client.QueryUserDelegationHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/asset/custody/transfer-history", seen.Path);
        Assert.Equal("abc@test.com", seen.Param("email"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryUserDelegationHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"total":3316,"rows":[{"clientTranId":"293915932290879488","transferType":"Undelegate","asset":"ETH","amount":"1","time":1695205406000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryUserDelegationHistoryRequest
        {
            Email = "abc@test.com",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Type = QueryUserDelegationHistoryType.Delegate,
            Asset = "BTC",
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryUserDelegationHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/asset/custody/transfer-history", seen.Path);
        Assert.Equal("abc@test.com", seen.Param("email"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("DELEGATE", seen.Param("type"));
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("1", seen.Param("current"));
        Assert.Equal("10", seen.Param("size"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryUserDelegationHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryUserDelegationHistoryRequest
        {
            Email = "abc@test.com",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryUserDelegationHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryUserUniversalTransferHistoryAsync()
    {
        const string example = """""{"total":2,"rows":[{"asset":"USDT","amount":"1","type":"MAIN_UMFUTURE","status":"CONFIRMED","tranId":11415955596,"timestamp":1544433328000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryUserUniversalTransferHistoryRequest
        {
            Type = "type_example",
        };

        var response = await client.QueryUserUniversalTransferHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/asset/transfer", seen.Path);
        Assert.Equal("type_example", seen.Param("type"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryUserUniversalTransferHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"total":2,"rows":[{"asset":"USDT","amount":"1","type":"MAIN_UMFUTURE","status":"CONFIRMED","tranId":11415955596,"timestamp":1544433328000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryUserUniversalTransferHistoryRequest
        {
            Type = "type_example",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Size = 10L,
            FromSymbol = QueryUserUniversalTransferHistoryFromSymbol.IsolatedmarginMargin,
            ToSymbol = QueryUserUniversalTransferHistoryToSymbol.MarginIsolatedmargin,
            RecvWindow = 5000L,
        };

        var response = await client.QueryUserUniversalTransferHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/asset/transfer", seen.Path);
        Assert.Equal("type_example", seen.Param("type"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("current"));
        Assert.Equal("10", seen.Param("size"));
        Assert.Equal("ISOLATEDMARGIN_MARGIN", seen.Param("fromSymbol"));
        Assert.Equal("MARGIN_ISOLATEDMARGIN", seen.Param("toSymbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryUserUniversalTransferHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryUserUniversalTransferHistoryRequest
        {
            Type = "type_example",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryUserUniversalTransferHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryUserWalletBalanceAsync()
    {
        const string example = """""[{"activate":true,"balance":"0","walletName":"Spot","assetBalances":[{"asset":"USDT","assetName":"TetherUS","free":"6.238383","locked":"0","freeze":"0","withdrawing":"0","btcValuation":"6.238383"}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryUserWalletBalanceAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/asset/wallet/balance", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryUserWalletBalanceWithOptionalParametersAsync()
    {
        const string example = """""[{"activate":true,"balance":"0","walletName":"Spot","assetBalances":[{"asset":"USDT","assetName":"TetherUS","free":"6.238383","locked":"0","freeze":"0","withdrawing":"0","btcValuation":"6.238383"}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryUserWalletBalanceRequest
        {
            QuoteAsset = "BTC",
            NeedBalanceDetail = false,
            RecvWindow = 5000L,
        };

        var response = await client.QueryUserWalletBalanceAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/asset/wallet/balance", seen.Path);
        Assert.Equal("BTC", seen.Param("quoteAsset"));
        Assert.Equal("false", seen.Param("needBalanceDetail"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryUserWalletBalanceBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryUserWalletBalanceAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ToggleBnbBurnOnSpotTradeAndMarginInterestAsync()
    {
        const string example = """""{"spotBNBBurn":true,"interestBNBBurn":false}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.ToggleBnbBurnOnSpotTradeAndMarginInterestAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/bnbBurn", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ToggleBnbBurnOnSpotTradeAndMarginInterestWithOptionalParametersAsync()
    {
        const string example = """""{"spotBNBBurn":true,"interestBNBBurn":false}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ToggleBnbBurnOnSpotTradeAndMarginInterestRequest
        {
            SpotBNBBurn = "true",
            InterestBNBBurn = "true",
            RecvWindow = 5000L,
        };

        var response = await client.ToggleBnbBurnOnSpotTradeAndMarginInterestAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/bnbBurn", seen.Path);
        Assert.Equal("true", seen.Param("spotBNBBurn"));
        Assert.Equal("true", seen.Param("interestBNBBurn"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ToggleBnbBurnOnSpotTradeAndMarginInterestBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ToggleBnbBurnOnSpotTradeAndMarginInterestAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TradeFeeAsync()
    {
        const string example = """""[{"symbol":"ADABNB","makerCommission":"0.001","takerCommission":"0.001"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.TradeFeeAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/asset/tradeFee", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TradeFeeWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"ADABNB","makerCommission":"0.001","takerCommission":"0.001"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TradeFeeRequest
        {
            Symbol = "ADABNB",
            RecvWindow = 5000L,
        };

        var response = await client.TradeFeeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/asset/tradeFee", seen.Path);
        Assert.Equal("ADABNB", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TradeFeeBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.TradeFeeAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task UserAssetAsync()
    {
        const string example = """""[{"asset":"AVAX","free":"1","locked":"0","freeze":"0","withdrawing":"0","ipoable":"0","btcValuation":"0"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.UserAssetAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v3/asset/getUserAsset", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task UserAssetWithOptionalParametersAsync()
    {
        const string example = """""[{"asset":"AVAX","free":"1","locked":"0","freeze":"0","withdrawing":"0","ipoable":"0","btcValuation":"0"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new UserAssetRequest
        {
            Asset = "BTC",
            NeedBtcValuation = true,
            RecvWindow = 5000L,
        };

        var response = await client.UserAssetAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v3/asset/getUserAsset", seen.Path);
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("true", seen.Param("needBtcValuation"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task UserAssetBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.UserAssetAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task UserUniversalTransferAsync()
    {
        const string example = """""{"tranId":13526853623}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new UserUniversalTransferRequest
        {
            Type = UserUniversalTransferType.MainUmfuture,
            Asset = "BTC",
            Amount = 1.0m,
        };

        var response = await client.UserUniversalTransferAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/asset/transfer", seen.Path);
        Assert.Equal("MAIN_UMFUTURE", seen.Param("type"));
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task UserUniversalTransferWithOptionalParametersAsync()
    {
        const string example = """""{"tranId":13526853623}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new UserUniversalTransferRequest
        {
            Type = UserUniversalTransferType.MainUmfuture,
            Asset = "BTC",
            Amount = 1.0m,
            FromSymbol = UserUniversalTransferFromSymbol.IsolatedmarginMargin,
            ToSymbol = UserUniversalTransferToSymbol.MarginIsolatedmargin,
            RecvWindow = 5000L,
        };

        var response = await client.UserUniversalTransferAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/asset/transfer", seen.Path);
        Assert.Equal("MAIN_UMFUTURE", seen.Param("type"));
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("ISOLATEDMARGIN_MARGIN", seen.Param("fromSymbol"));
        Assert.Equal("MARGIN_ISOLATEDMARGIN", seen.Param("toSymbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task UserUniversalTransferBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new UserUniversalTransferRequest
        {
            Type = UserUniversalTransferType.MainUmfuture,
            Asset = "BTC",
            Amount = 1.0m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.UserUniversalTransferAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
