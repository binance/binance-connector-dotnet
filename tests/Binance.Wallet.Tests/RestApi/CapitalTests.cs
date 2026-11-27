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

namespace Binance.Wallet.Tests.RestApi.Capital;

[Trait("Category", "Native")]
public class CapitalApiTests
{
    private static WalletRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task AllCoinsInformationAsync()
    {
        const string example = """""[{"coin":"1MBABYDOGE","depositAllEnable":true,"withdrawAllEnable":true,"name":"1M x BABYDOGE","free":"34941.1","locked":"0","freeze":"0","withdrawing":"0","ipoing":"0","ipoable":"0","storage":"0","isLegalMoney":false,"trading":true,"networkList":[{"network":"BSC","coin":"1MBABYDOGE","withdrawIntegerMultiple":"0.01","isDefault":false,"depositEnable":true,"withdrawEnable":true,"depositDesc":"","withdrawDesc":"","specialTips":"","specialWithdrawTips":"","name":"BNB Smart Chain (BEP20)","resetAddressStatus":false,"addressRegex":"^(0x)[0-9A-Fa-f]{40}$","memoRegex":"","withdrawFee":"10","withdrawMin":"20","withdrawMax":"9999999999","withdrawInternalMin":"0.01","depositDust":"0.01","minConfirm":5,"unLockConfirm":0,"sameAddress":false,"withdrawTag":false,"estimatedArrivalTime":1,"busy":false,"contractAddressUrl":"https://bscscan.com/token/","contractAddress":"0xc748673057861a797275cd8a068abb95a902e8de","denomination":1000000}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.AllCoinsInformationAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/capital/config/getall", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AllCoinsInformationWithOptionalParametersAsync()
    {
        const string example = """""[{"coin":"1MBABYDOGE","depositAllEnable":true,"withdrawAllEnable":true,"name":"1M x BABYDOGE","free":"34941.1","locked":"0","freeze":"0","withdrawing":"0","ipoing":"0","ipoable":"0","storage":"0","isLegalMoney":false,"trading":true,"networkList":[{"network":"BSC","coin":"1MBABYDOGE","withdrawIntegerMultiple":"0.01","isDefault":false,"depositEnable":true,"withdrawEnable":true,"depositDesc":"","withdrawDesc":"","specialTips":"","specialWithdrawTips":"","name":"BNB Smart Chain (BEP20)","resetAddressStatus":false,"addressRegex":"^(0x)[0-9A-Fa-f]{40}$","memoRegex":"","withdrawFee":"10","withdrawMin":"20","withdrawMax":"9999999999","withdrawInternalMin":"0.01","depositDust":"0.01","minConfirm":5,"unLockConfirm":0,"sameAddress":false,"withdrawTag":false,"estimatedArrivalTime":1,"busy":false,"contractAddressUrl":"https://bscscan.com/token/","contractAddress":"0xc748673057861a797275cd8a068abb95a902e8de","denomination":1000000}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AllCoinsInformationRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.AllCoinsInformationAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/capital/config/getall", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AllCoinsInformationBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AllCoinsInformationAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task DepositAddressAsync()
    {
        const string example = """""{"address":"1HPn8Rx2y6nNSfagQBKy27GB99Vbzg89wv","coin":"BTC","tag":"","url":"https://btc.com/1HPn8Rx2y6nNSfagQBKy27GB99Vbzg89wv"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DepositAddressRequest
        {
            Coin = "BTC",
        };

        var response = await client.DepositAddressAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/capital/deposit/address", seen.Path);
        Assert.Equal("BTC", seen.Param("coin"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DepositAddressWithOptionalParametersAsync()
    {
        const string example = """""{"address":"1HPn8Rx2y6nNSfagQBKy27GB99Vbzg89wv","coin":"BTC","tag":"","url":"https://btc.com/1HPn8Rx2y6nNSfagQBKy27GB99Vbzg89wv"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DepositAddressRequest
        {
            Coin = "BTC",
            Network = "network_example",
            Amount = 1.0m,
            RecvWindow = 5000L,
        };

        var response = await client.DepositAddressAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/capital/deposit/address", seen.Path);
        Assert.Equal("BTC", seen.Param("coin"));
        Assert.Equal("network_example", seen.Param("network"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DepositAddressBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new DepositAddressRequest
        {
            Coin = "BTC",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.DepositAddressAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task DepositHistoryAsync()
    {
        const string example = """""[{"id":"769800519366885376","amount":"0.001","coin":"BNB","network":"BNB","status":1,"address":"bnb136ns6lfw4zs5hg4n85vdthaad7hq5m4gtkgf23","addressTag":"101764890","txId":"98A3EA560C6B3336D348B6C83F0F95ECE4F1F5919E94BD006E5BF3BF264FACFC","insertTime":1661493146000,"completeTime":1661493146000,"transferType":0,"confirmTimes":"1/1","unlockConfirm":0,"walletType":0,"travelRuleStatus":0}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.DepositHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/capital/deposit/hisrec", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DepositHistoryWithOptionalParametersAsync()
    {
        const string example = """""[{"id":"769800519366885376","amount":"0.001","coin":"BNB","network":"BNB","status":1,"address":"bnb136ns6lfw4zs5hg4n85vdthaad7hq5m4gtkgf23","addressTag":"101764890","txId":"98A3EA560C6B3336D348B6C83F0F95ECE4F1F5919E94BD006E5BF3BF264FACFC","insertTime":1661493146000,"completeTime":1661493146000,"transferType":0,"confirmTimes":"1/1","unlockConfirm":0,"walletType":0,"travelRuleStatus":0}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DepositHistoryRequest
        {
            IncludeSource = false,
            Coin = "BTC",
            Status = DepositHistoryStatus.Status0,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Offset = 0L,
            Limit = 1000L,
            RecvWindow = 5000L,
            TxId = "1",
        };

        var response = await client.DepositHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/capital/deposit/hisrec", seen.Path);
        Assert.Equal("false", seen.Param("includeSource"));
        Assert.Equal("BTC", seen.Param("coin"));
        Assert.Equal("0", seen.Param("status"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("0", seen.Param("offset"));
        Assert.Equal("1000", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("1", seen.Param("txId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DepositHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.DepositHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task FetchDepositAddressListWithNetworkAsync()
    {
        const string example = """""[{"coin":"ETH","address":"0xD316E95Fd9E8E237Cb11f8200Babbc5D8D177BA4","tag":"","isDefault":0}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new FetchDepositAddressListWithNetworkRequest
        {
            Coin = "BTC",
        };

        var response = await client.FetchDepositAddressListWithNetworkAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/capital/deposit/address/list", seen.Path);
        Assert.Equal("BTC", seen.Param("coin"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FetchDepositAddressListWithNetworkWithOptionalParametersAsync()
    {
        const string example = """""[{"coin":"ETH","address":"0xD316E95Fd9E8E237Cb11f8200Babbc5D8D177BA4","tag":"","isDefault":0}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new FetchDepositAddressListWithNetworkRequest
        {
            Coin = "BTC",
            Network = "network_example",
        };

        var response = await client.FetchDepositAddressListWithNetworkAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/capital/deposit/address/list", seen.Path);
        Assert.Equal("BTC", seen.Param("coin"));
        Assert.Equal("network_example", seen.Param("network"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FetchDepositAddressListWithNetworkBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new FetchDepositAddressListWithNetworkRequest
        {
            Coin = "BTC",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.FetchDepositAddressListWithNetworkAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task FetchWithdrawAddressListAsync()
    {
        const string example = """""[{"address":"1A1zP1eP5QGefi2DMPTfTL5SLmv7DivfNa","addressTag":"","coin":"BTC","name":"Satoshi","network":"BTC","origin":"bla","originType":"others","whiteStatus":true}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.FetchWithdrawAddressListAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/capital/withdraw/address/list", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FetchWithdrawAddressListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.FetchWithdrawAddressListAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task FetchWithdrawQuotaAsync()
    {
        const string example = """""{"wdQuota":"10000","usedWdQuota":"1000"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.FetchWithdrawQuotaAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/capital/withdraw/quota", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FetchWithdrawQuotaBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.FetchWithdrawQuotaAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OneClickArrivalDepositApplyAsync()
    {
        const string example = """""{"code":"000000","message":"success","data":true,"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.OneClickArrivalDepositApplyAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/capital/deposit/credit-apply", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OneClickArrivalDepositApplyWithOptionalParametersAsync()
    {
        const string example = """""{"code":"000000","message":"success","data":true,"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OneClickArrivalDepositApplyRequest
        {
            DepositId = 1L,
            TxId = "1",
            SubAccountId = "1",
            SubUserId = 1L,
        };

        var response = await client.OneClickArrivalDepositApplyAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/capital/deposit/credit-apply", seen.Path);
        Assert.Equal("1", seen.Param("depositId"));
        Assert.Equal("1", seen.Param("txId"));
        Assert.Equal("1", seen.Param("subAccountId"));
        Assert.Equal("1", seen.Param("subUserId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OneClickArrivalDepositApplyBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OneClickArrivalDepositApplyAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task WithdrawAsync()
    {
        const string example = """""{"id":"7213fea8e94b4a5593d507237e5a555b"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new WithdrawRequest
        {
            Coin = "BTC",
            Address = "address_example",
            Amount = 1.0m,
        };

        var response = await client.WithdrawAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/capital/withdraw/apply", seen.Path);
        Assert.Equal("BTC", seen.Param("coin"));
        Assert.Equal("address_example", seen.Param("address"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task WithdrawWithOptionalParametersAsync()
    {
        const string example = """""{"id":"7213fea8e94b4a5593d507237e5a555b"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new WithdrawRequest
        {
            Coin = "BTC",
            Address = "address_example",
            Amount = 1.0m,
            WithdrawOrderId = "1",
            Network = "network_example",
            AddressTag = "addressTag_example",
            TransactionFeeFlag = true,
            Name = "name_example",
            WalletType = 0L,
            RecvWindow = 5000L,
        };

        var response = await client.WithdrawAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/capital/withdraw/apply", seen.Path);
        Assert.Equal("BTC", seen.Param("coin"));
        Assert.Equal("address_example", seen.Param("address"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("1", seen.Param("withdrawOrderId"));
        Assert.Equal("network_example", seen.Param("network"));
        Assert.Equal("addressTag_example", seen.Param("addressTag"));
        Assert.Equal("true", seen.Param("transactionFeeFlag"));
        Assert.Equal("name_example", seen.Param("name"));
        Assert.Equal("0", seen.Param("walletType"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task WithdrawBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new WithdrawRequest
        {
            Coin = "BTC",
            Address = "address_example",
            Amount = 1.0m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.WithdrawAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task WithdrawHistoryAsync()
    {
        const string example = """""[{"id":"b6ae22b3aa844210a7041aee7589627c","amount":"8.91000000","transactionFee":"0.004","coin":"USDT","status":6,"address":"0x94df8b352de7f46f64b01d3666bf6e936e44ce60","txId":"0xb5ef8c13b968a406cc62a93a8bd80f9e9a906ef1b3fcf20a2e48573c17659268","applyTime":"2019-10-12 11:12:02","network":"ETH","transferType":0,"withdrawOrderId":"WITHDRAWtest123","info":"The address is not valid. Please confirm with the recipient","confirmNo":3,"walletType":1,"txKey":"","completeTime":"2023-03-23 16:52:41"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.WithdrawHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/capital/withdraw/history", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task WithdrawHistoryWithOptionalParametersAsync()
    {
        const string example = """""[{"id":"b6ae22b3aa844210a7041aee7589627c","amount":"8.91000000","transactionFee":"0.004","coin":"USDT","status":6,"address":"0x94df8b352de7f46f64b01d3666bf6e936e44ce60","txId":"0xb5ef8c13b968a406cc62a93a8bd80f9e9a906ef1b3fcf20a2e48573c17659268","applyTime":"2019-10-12 11:12:02","network":"ETH","transferType":0,"withdrawOrderId":"WITHDRAWtest123","info":"The address is not valid. Please confirm with the recipient","confirmNo":3,"walletType":1,"txKey":"","completeTime":"2023-03-23 16:52:41"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new WithdrawHistoryRequest
        {
            Coin = "BTC",
            WithdrawOrderId = "1",
            Status = 0L,
            Offset = 0L,
            Limit = 1000L,
            IdList = "idList_example",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            RecvWindow = 5000L,
        };

        var response = await client.WithdrawHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/capital/withdraw/history", seen.Path);
        Assert.Equal("BTC", seen.Param("coin"));
        Assert.Equal("1", seen.Param("withdrawOrderId"));
        Assert.Equal("0", seen.Param("status"));
        Assert.Equal("0", seen.Param("offset"));
        Assert.Equal("1000", seen.Param("limit"));
        Assert.Equal("idList_example", seen.Param("idList"));
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
    public async Task WithdrawHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.WithdrawHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
