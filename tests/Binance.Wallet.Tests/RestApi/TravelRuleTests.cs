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

namespace Binance.Wallet.Tests.RestApi.TravelRule;

[Trait("Category", "Native")]
public class TravelRuleApiTests
{
    private static WalletRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task BrokerWithdrawAsync()
    {
        const string example = """""{"trId":123456,"accepted":true,"info":"Withdraw request accepted"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new BrokerWithdrawRequest
        {
            Address = "address_example",
            Coin = "BTC",
            Amount = 1.0m,
            WithdrawOrderId = "1",
            Questionnaire = "questionnaire_example",
            OriginatorPii = "originatorPii_example",
        };

        var response = await client.BrokerWithdrawAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/localentity/broker/withdraw/apply", seen.Path);
        Assert.Equal("address_example", seen.Param("address"));
        Assert.Equal("BTC", seen.Param("coin"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("1", seen.Param("withdrawOrderId"));
        Assert.Equal("questionnaire_example", seen.Param("questionnaire"));
        Assert.Equal("originatorPii_example", seen.Param("originatorPii"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task BrokerWithdrawWithOptionalParametersAsync()
    {
        const string example = """""{"trId":123456,"accepted":true,"info":"Withdraw request accepted"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new BrokerWithdrawRequest
        {
            Address = "address_example",
            Coin = "BTC",
            Amount = 1.0m,
            WithdrawOrderId = "1",
            Questionnaire = "questionnaire_example",
            OriginatorPii = "originatorPii_example",
            AddressTag = "addressTag_example",
            Network = "network_example",
            AddressName = "addressName_example",
            TransactionFeeFlag = true,
            WalletType = 0L,
        };

        var response = await client.BrokerWithdrawAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/localentity/broker/withdraw/apply", seen.Path);
        Assert.Equal("address_example", seen.Param("address"));
        Assert.Equal("BTC", seen.Param("coin"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("1", seen.Param("withdrawOrderId"));
        Assert.Equal("questionnaire_example", seen.Param("questionnaire"));
        Assert.Equal("originatorPii_example", seen.Param("originatorPii"));
        Assert.Equal("addressTag_example", seen.Param("addressTag"));
        Assert.Equal("network_example", seen.Param("network"));
        Assert.Equal("addressName_example", seen.Param("addressName"));
        Assert.Equal("true", seen.Param("transactionFeeFlag"));
        Assert.Equal("0", seen.Param("walletType"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task BrokerWithdrawBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new BrokerWithdrawRequest
        {
            Address = "address_example",
            Coin = "BTC",
            Amount = 1.0m,
            WithdrawOrderId = "1",
            Questionnaire = "questionnaire_example",
            OriginatorPii = "originatorPii_example",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.BrokerWithdrawAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CheckQuestionnaireRequirementsAsync()
    {
        const string example = """""{"questionnaireCountryCode":"AE"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.CheckQuestionnaireRequirementsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/localentity/questionnaire-requirements", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CheckQuestionnaireRequirementsWithOptionalParametersAsync()
    {
        const string example = """""{"questionnaireCountryCode":"AE"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CheckQuestionnaireRequirementsRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.CheckQuestionnaireRequirementsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/localentity/questionnaire-requirements", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CheckQuestionnaireRequirementsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CheckQuestionnaireRequirementsAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task DepositHistoryTravelRuleAsync()
    {
        const string example = """""[{"trId":123451123,"tranId":17644346245865,"amount":"0.001","coin":"BNB","network":"BNB","depositStatus":0,"travelRuleStatus":1,"travelRuleStatusV2":"PENDING","address":"bnb136ns6lfw4zs5hg4n85vdthaad7hq5m4gtkgf23","addressTag":"101764890","txId":"98A3EA560C6B3336D348B6C83F0F95ECE4F1F5919E94BD006E5BF3BF264FACFC","insertTime":1661493146000,"completeTime":1661493206000,"transferType":0,"confirmTimes":"1/1","requireQuestionnaire":false,"questionnaire":"{\"question1\":\"answer1\",\"question2\":\"answer2\"}"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.DepositHistoryTravelRuleAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/localentity/deposit/history", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DepositHistoryTravelRuleWithOptionalParametersAsync()
    {
        const string example = """""[{"trId":123451123,"tranId":17644346245865,"amount":"0.001","coin":"BNB","network":"BNB","depositStatus":0,"travelRuleStatus":1,"travelRuleStatusV2":"PENDING","address":"bnb136ns6lfw4zs5hg4n85vdthaad7hq5m4gtkgf23","addressTag":"101764890","txId":"98A3EA560C6B3336D348B6C83F0F95ECE4F1F5919E94BD006E5BF3BF264FACFC","insertTime":1661493146000,"completeTime":1661493206000,"transferType":0,"confirmTimes":"1/1","requireQuestionnaire":false,"questionnaire":"{\"question1\":\"answer1\",\"question2\":\"answer2\"}"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DepositHistoryTravelRuleRequest
        {
            TrId = "1",
            TxId = "1",
            TranId = "1",
            Network = "network_example",
            Coin = "BTC",
            TravelRuleStatus = 0L,
            PendingQuestionnaire = true,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Offset = 1L,
            Limit = 1000L,
        };

        var response = await client.DepositHistoryTravelRuleAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/localentity/deposit/history", seen.Path);
        Assert.Equal("1", seen.Param("trId"));
        Assert.Equal("1", seen.Param("txId"));
        Assert.Equal("1", seen.Param("tranId"));
        Assert.Equal("network_example", seen.Param("network"));
        Assert.Equal("BTC", seen.Param("coin"));
        Assert.Equal("0", seen.Param("travelRuleStatus"));
        Assert.Equal("true", seen.Param("pendingQuestionnaire"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("offset"));
        Assert.Equal("1000", seen.Param("limit"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DepositHistoryTravelRuleBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.DepositHistoryTravelRuleAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task DepositHistoryV2Async()
    {
        const string example = """""[{"depositId":"4615328107052018945","amount":"0.01","network":"AVAXC","coin":"AVAX","depositStatus":1,"travelRuleReqStatus":0,"address":"0x0010627ab66d69232f4080d54e0f838b4dc3894a","addressTag":"","txId":"0xdde578983015741eed764e7ca10defb5a2caafdca3db5f92872d24a96beb1879","transferType":0,"confirmTimes":"12/12","requireQuestionnaire":false,"questionnaire":{"vaspName":"BINANCE","depositOriginator":0},"insertTime":1753053392000}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.DepositHistoryV2Async();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/localentity/deposit/history", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DepositHistoryV2WithOptionalParametersAsync()
    {
        const string example = """""[{"depositId":"4615328107052018945","amount":"0.01","network":"AVAXC","coin":"AVAX","depositStatus":1,"travelRuleReqStatus":0,"address":"0x0010627ab66d69232f4080d54e0f838b4dc3894a","addressTag":"","txId":"0xdde578983015741eed764e7ca10defb5a2caafdca3db5f92872d24a96beb1879","transferType":0,"confirmTimes":"12/12","requireQuestionnaire":false,"questionnaire":{"vaspName":"BINANCE","depositOriginator":0},"insertTime":1753053392000}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DepositHistoryV2Request
        {
            DepositId = 1L,
            TxId = "1",
            Network = "network_example",
            Coin = "BTC",
            RetrieveQuestionnaire = true,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Offset = 0L,
            Limit = 1000L,
        };

        var response = await client.DepositHistoryV2Async(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/localentity/deposit/history", seen.Path);
        Assert.Equal("1", seen.Param("depositId"));
        Assert.Equal("1", seen.Param("txId"));
        Assert.Equal("network_example", seen.Param("network"));
        Assert.Equal("BTC", seen.Param("coin"));
        Assert.Equal("true", seen.Param("retrieveQuestionnaire"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("0", seen.Param("offset"));
        Assert.Equal("1000", seen.Param("limit"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DepositHistoryV2BadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.DepositHistoryV2Async());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task FetchAddressVerificationListAsync()
    {
        const string example = """""[{"status":"PENDING","token":"AVAX","network":"AVAXC","walletAddress":"0xc03a6aa728a8dde7464c33828424ede7553a0021","addressQuestionnaire":{"sendTo":1,"satoshiToken":"AVAX","isAddressOwner":1,"verifyMethod":1}}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.FetchAddressVerificationListAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/addressVerify/list", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FetchAddressVerificationListWithOptionalParametersAsync()
    {
        const string example = """""[{"status":"PENDING","token":"AVAX","network":"AVAXC","walletAddress":"0xc03a6aa728a8dde7464c33828424ede7553a0021","addressQuestionnaire":{"sendTo":1,"satoshiToken":"AVAX","isAddressOwner":1,"verifyMethod":1}}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new FetchAddressVerificationListRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.FetchAddressVerificationListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/addressVerify/list", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FetchAddressVerificationListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.FetchAddressVerificationListAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetCountryListAsync()
    {
        const string example = """""{"countries":[{"countryCode":"au","countryName":"Australia","blockType":"supported","depositAllowed":true,"withdrawalAllowed":true,"hasRegionRestrictions":false}],"lastUpdated":1716300000000}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetCountryListAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/localentity/country/list", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetCountryListWithOptionalParametersAsync()
    {
        const string example = """""{"countries":[{"countryCode":"au","countryName":"Australia","blockType":"supported","depositAllowed":true,"withdrawalAllowed":true,"hasRegionRestrictions":false}],"lastUpdated":1716300000000}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetCountryListRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetCountryListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/localentity/country/list", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetCountryListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetCountryListAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetRegionListAsync()
    {
        const string example = """""{"countryCode":"au","regions":[{"regionName":"New South Wales","blockType":"supported","depositAllowed":true,"withdrawalAllowed":true}],"lastUpdated":1716300000000}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetRegionListRequest
        {
            CountryCode = "au",
        };

        var response = await client.GetRegionListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/localentity/region/list", seen.Path);
        Assert.Equal("au", seen.Param("countryCode"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetRegionListWithOptionalParametersAsync()
    {
        const string example = """""{"countryCode":"au","regions":[{"regionName":"New South Wales","blockType":"supported","depositAllowed":true,"withdrawalAllowed":true}],"lastUpdated":1716300000000}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetRegionListRequest
        {
            CountryCode = "au",
            RecvWindow = 5000L,
        };

        var response = await client.GetRegionListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/localentity/region/list", seen.Path);
        Assert.Equal("au", seen.Param("countryCode"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetRegionListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetRegionListRequest
        {
            CountryCode = "au",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetRegionListAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SubmitDepositQuestionnaireAsync()
    {
        const string example = """""{"trId":765127651,"accepted":true,"info":"Deposit questionnaire accepted."}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SubmitDepositQuestionnaireRequest
        {
            SubAccountId = "1",
            DepositId = 1L,
            Questionnaire = "questionnaire_example",
            BeneficiaryPii = "beneficiaryPii_example",
        };

        var response = await client.SubmitDepositQuestionnaireAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("PUT", seen.Method);
        Assert.Equal("/sapi/v1/localentity/broker/deposit/provide-info", seen.Path);
        Assert.Equal("1", seen.Param("subAccountId"));
        Assert.Equal("1", seen.Param("depositId"));
        Assert.Equal("questionnaire_example", seen.Param("questionnaire"));
        Assert.Equal("beneficiaryPii_example", seen.Param("beneficiaryPii"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SubmitDepositQuestionnaireWithOptionalParametersAsync()
    {
        const string example = """""{"trId":765127651,"accepted":true,"info":"Deposit questionnaire accepted."}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SubmitDepositQuestionnaireRequest
        {
            SubAccountId = "1",
            DepositId = 1L,
            Questionnaire = "questionnaire_example",
            BeneficiaryPii = "beneficiaryPii_example",
            Network = "network_example",
            Coin = "BTC",
            Amount = 1.0m,
            Address = "address_example",
            AddressTag = "addressTag_example",
        };

        var response = await client.SubmitDepositQuestionnaireAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("PUT", seen.Method);
        Assert.Equal("/sapi/v1/localentity/broker/deposit/provide-info", seen.Path);
        Assert.Equal("1", seen.Param("subAccountId"));
        Assert.Equal("1", seen.Param("depositId"));
        Assert.Equal("questionnaire_example", seen.Param("questionnaire"));
        Assert.Equal("beneficiaryPii_example", seen.Param("beneficiaryPii"));
        Assert.Equal("network_example", seen.Param("network"));
        Assert.Equal("BTC", seen.Param("coin"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("address_example", seen.Param("address"));
        Assert.Equal("addressTag_example", seen.Param("addressTag"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SubmitDepositQuestionnaireBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new SubmitDepositQuestionnaireRequest
        {
            SubAccountId = "1",
            DepositId = 1L,
            Questionnaire = "questionnaire_example",
            BeneficiaryPii = "beneficiaryPii_example",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SubmitDepositQuestionnaireAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SubmitDepositQuestionnaireTravelRuleAsync()
    {
        const string example = """""{"trId":765127651,"accepted":true,"info":"Deposit questionnaire accepted."}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SubmitDepositQuestionnaireTravelRuleRequest
        {
            TranId = 1L,
            Questionnaire = "questionnaire_example",
        };

        var response = await client.SubmitDepositQuestionnaireTravelRuleAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("PUT", seen.Method);
        Assert.Equal("/sapi/v1/localentity/deposit/provide-info", seen.Path);
        Assert.Equal("1", seen.Param("tranId"));
        Assert.Equal("questionnaire_example", seen.Param("questionnaire"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SubmitDepositQuestionnaireTravelRuleBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new SubmitDepositQuestionnaireTravelRuleRequest
        {
            TranId = 1L,
            Questionnaire = "questionnaire_example",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SubmitDepositQuestionnaireTravelRuleAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SubmitDepositQuestionnaireV2Async()
    {
        const string example = """""{"trId":765127651,"accepted":true,"info":"Deposit questionnaire accepted."}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SubmitDepositQuestionnaireV2Request
        {
            DepositId = 1L,
            Questionnaire = "questionnaire_example",
        };

        var response = await client.SubmitDepositQuestionnaireV2Async(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("PUT", seen.Method);
        Assert.Equal("/sapi/v2/localentity/deposit/provide-info", seen.Path);
        Assert.Equal("1", seen.Param("depositId"));
        Assert.Equal("questionnaire_example", seen.Param("questionnaire"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SubmitDepositQuestionnaireV2BadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new SubmitDepositQuestionnaireV2Request
        {
            DepositId = 1L,
            Questionnaire = "questionnaire_example",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SubmitDepositQuestionnaireV2Async(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task VaspListAsync()
    {
        const string example = """""[{"vaspName":"Binance","vaspCode":"BINANCE","identifier":"xxx"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.VaspListAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/localentity/vasp", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task VaspListWithOptionalParametersAsync()
    {
        const string example = """""[{"vaspName":"Binance","vaspCode":"BINANCE","identifier":"xxx"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new VaspListRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.VaspListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/localentity/vasp", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task VaspListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.VaspListAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task WithdrawHistoryV1Async()
    {
        const string example = """""[{"id":"b6ae22b3aa844210a7041aee7589627c","trId":1234456,"amount":"8.91000000","transactionFee":"0.004","coin":"USDT","withdrawalStatus":6,"travelRuleStatus":0,"address":"0x94df8b352de7f46f64b01d3666bf6e936e44ce60","txId":"0xb5ef8c13b968a406cc62a93a8bd80f9e9a906ef1b3fcf20a2e48573c17659268","applyTime":"2019-10-12 11:12:02","network":"ETH","transferType":0,"withdrawOrderId":"WITHDRAWtest123","info":"The address is not valid. Please confirm with the recipient","confirmNo":3,"walletType":1,"txKey":"","questionnaire":"{\"question1\":\"answer1\",\"question2\":\"answer2\"}","completeTime":"2023-03-23 16:52:41"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.WithdrawHistoryV1Async();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/localentity/withdraw/history", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task WithdrawHistoryV1WithOptionalParametersAsync()
    {
        const string example = """""[{"id":"b6ae22b3aa844210a7041aee7589627c","trId":1234456,"amount":"8.91000000","transactionFee":"0.004","coin":"USDT","withdrawalStatus":6,"travelRuleStatus":0,"address":"0x94df8b352de7f46f64b01d3666bf6e936e44ce60","txId":"0xb5ef8c13b968a406cc62a93a8bd80f9e9a906ef1b3fcf20a2e48573c17659268","applyTime":"2019-10-12 11:12:02","network":"ETH","transferType":0,"withdrawOrderId":"WITHDRAWtest123","info":"The address is not valid. Please confirm with the recipient","confirmNo":3,"walletType":1,"txKey":"","questionnaire":"{\"question1\":\"answer1\",\"question2\":\"answer2\"}","completeTime":"2023-03-23 16:52:41"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new WithdrawHistoryV1Request
        {
            TrId = "1",
            TxId = "1",
            WithdrawOrderId = "1",
            Network = "network_example",
            Coin = "BTC",
            TravelRuleStatus = 0L,
            Offset = 0L,
            Limit = 1000L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            RecvWindow = 5000L,
        };

        var response = await client.WithdrawHistoryV1Async(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/localentity/withdraw/history", seen.Path);
        Assert.Equal("1", seen.Param("trId"));
        Assert.Equal("1", seen.Param("txId"));
        Assert.Equal("1", seen.Param("withdrawOrderId"));
        Assert.Equal("network_example", seen.Param("network"));
        Assert.Equal("BTC", seen.Param("coin"));
        Assert.Equal("0", seen.Param("travelRuleStatus"));
        Assert.Equal("0", seen.Param("offset"));
        Assert.Equal("1000", seen.Param("limit"));
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
    public async Task WithdrawHistoryV1BadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.WithdrawHistoryV1Async());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task WithdrawHistoryV2Async()
    {
        const string example = """""[{"id":"b6ae22b3aa844210a7041aee7589627c","trId":1234456,"amount":"8.91000000","transactionFee":"0.004","coin":"USDT","withdrawalStatus":6,"travelRuleStatus":0,"address":"0x94df8b352de7f46f64b01d3666bf6e936e44ce60","txId":"0xb5ef8c13b968a406cc62a93a8bd80f9e9a906ef1b3fcf20a2e48573c17659268","applyTime":"2019-10-12 11:12:02","network":"ETH","transferType":0,"withdrawOrderId":"WITHDRAWtest123","info":"The address is not valid. Please confirm with the recipient","confirmNo":3,"walletType":1,"txKey":"","questionnaire":"{\"question1\":\"answer1\",\"question2\":\"answer2\"}","completeTime":"2023-03-23 16:52:41"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.WithdrawHistoryV2Async();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/localentity/withdraw/history", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task WithdrawHistoryV2WithOptionalParametersAsync()
    {
        const string example = """""[{"id":"b6ae22b3aa844210a7041aee7589627c","trId":1234456,"amount":"8.91000000","transactionFee":"0.004","coin":"USDT","withdrawalStatus":6,"travelRuleStatus":0,"address":"0x94df8b352de7f46f64b01d3666bf6e936e44ce60","txId":"0xb5ef8c13b968a406cc62a93a8bd80f9e9a906ef1b3fcf20a2e48573c17659268","applyTime":"2019-10-12 11:12:02","network":"ETH","transferType":0,"withdrawOrderId":"WITHDRAWtest123","info":"The address is not valid. Please confirm with the recipient","confirmNo":3,"walletType":1,"txKey":"","questionnaire":"{\"question1\":\"answer1\",\"question2\":\"answer2\"}","completeTime":"2023-03-23 16:52:41"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new WithdrawHistoryV2Request
        {
            TrId = "1",
            TxId = "1",
            WithdrawOrderId = "1",
            Network = "network_example",
            Coin = "coin_example",
            TravelRuleStatus = 0L,
            Offset = 0L,
            Limit = 1000L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            RecvWindow = 5000L,
        };

        var response = await client.WithdrawHistoryV2Async(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/localentity/withdraw/history", seen.Path);
        Assert.Equal("1", seen.Param("trId"));
        Assert.Equal("1", seen.Param("txId"));
        Assert.Equal("1", seen.Param("withdrawOrderId"));
        Assert.Equal("network_example", seen.Param("network"));
        Assert.Equal("coin_example", seen.Param("coin"));
        Assert.Equal("0", seen.Param("travelRuleStatus"));
        Assert.Equal("0", seen.Param("offset"));
        Assert.Equal("1000", seen.Param("limit"));
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
    public async Task WithdrawHistoryV2BadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.WithdrawHistoryV2Async());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task WithdrawTravelRuleAsync()
    {
        const string example = """""{"trId":123456,"accepted":true,"info":"Withdraw request accepted"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new WithdrawTravelRuleRequest
        {
            Coin = "BTC",
            Address = "address_example",
            Amount = 1.0m,
            Questionnaire = "questionnaire_example",
        };

        var response = await client.WithdrawTravelRuleAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/localentity/withdraw/apply", seen.Path);
        Assert.Equal("BTC", seen.Param("coin"));
        Assert.Equal("address_example", seen.Param("address"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("questionnaire_example", seen.Param("questionnaire"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task WithdrawTravelRuleWithOptionalParametersAsync()
    {
        const string example = """""{"trId":123456,"accepted":true,"info":"Withdraw request accepted"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new WithdrawTravelRuleRequest
        {
            Coin = "BTC",
            Address = "address_example",
            Amount = 1.0m,
            Questionnaire = "questionnaire_example",
            WithdrawOrderId = "1",
            Network = "network_example",
            AddressTag = "addressTag_example",
            TransactionFeeFlag = true,
            Name = "name_example",
            WalletType = 0L,
            RecvWindow = 5000L,
        };

        var response = await client.WithdrawTravelRuleAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/localentity/withdraw/apply", seen.Path);
        Assert.Equal("BTC", seen.Param("coin"));
        Assert.Equal("address_example", seen.Param("address"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("questionnaire_example", seen.Param("questionnaire"));
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
    public async Task WithdrawTravelRuleBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new WithdrawTravelRuleRequest
        {
            Coin = "BTC",
            Address = "address_example",
            Amount = 1.0m,
            Questionnaire = "questionnaire_example",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.WithdrawTravelRuleAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
