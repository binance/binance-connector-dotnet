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

namespace Binance.W3WPrediction.Tests.RestApi.Position;

[Trait("Category", "Native")]
public class PositionApiTests
{
    private static W3WPredictionRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task GetPositionByTokenAsync()
    {
        const string example = """""{"position":{"positionId":1001,"vendor":"PREDICT_FUN","chainId":"56","tokenId":"112233","collateralSymbol":"USDT","topicType":"FLAT","marketTopicId":4229564,"marketId":5567895,"marketTopicTitle":"BTC Price 1h Up or Down?","marketTitle":"UP","outcomeName":"YES","outcomeIndex":0,"shares":"1923.07","avgPrice":"0.52","totalCost":"1.00","value":"1.06","currentPrice":"0.55","positionStatus":"OPEN","endDate":1748134800000,"unrealizedPnl":"0.06","realizedPnl":"0.00","pnl":"0.06","createdTime":1748131500000,"updatedTime":1748132000000}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetPositionByTokenRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            TokenId = "112233",
        };

        var response = await client.GetPositionByTokenAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/position/token", seen.Path);
        Assert.Equal("0x12e32db8817e292508c34111cbc4b23340df542c", seen.Param("walletAddress"));
        Assert.Equal("112233", seen.Param("tokenId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetPositionByTokenWithOptionalParametersAsync()
    {
        const string example = """""{"position":{"positionId":1001,"vendor":"PREDICT_FUN","chainId":"56","tokenId":"112233","collateralSymbol":"USDT","topicType":"FLAT","marketTopicId":4229564,"marketId":5567895,"marketTopicTitle":"BTC Price 1h Up or Down?","marketTitle":"UP","outcomeName":"YES","outcomeIndex":0,"shares":"1923.07","avgPrice":"0.52","totalCost":"1.00","value":"1.06","currentPrice":"0.55","positionStatus":"OPEN","endDate":1748134800000,"unrealizedPnl":"0.06","realizedPnl":"0.00","pnl":"0.06","createdTime":1748131500000,"updatedTime":1748132000000}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetPositionByTokenRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            TokenId = "112233",
            RecvWindow = 5000L,
        };

        var response = await client.GetPositionByTokenAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/position/token", seen.Path);
        Assert.Equal("0x12e32db8817e292508c34111cbc4b23340df542c", seen.Param("walletAddress"));
        Assert.Equal("112233", seen.Param("tokenId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetPositionByTokenBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetPositionByTokenRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            TokenId = "112233",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetPositionByTokenAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryPnLAsync()
    {
        const string example = """""{"chainId":"56","walletAddress":"0x12e32db8817e292508c34111cbc4b23340df542c","pnl":{},"pnlList":[{"id":10001,"walletAddress":"0x12e32db8817e292508c34111cbc4b23340df542c","marketTopicId":4229564,"marketId":5567895,"tokenId":"112233","vendor":"PREDICT_FUN","currentShares":"1923.07","avgPrice":"0.52","currentPrice":"0.55","realizedPnl":"0.00","unrealizedPnl":"0.06","totalPnl":"0.06","pnlPercentage":"6.00","isResolved":false}],"totalCount":1,"totalRealizedPnl":"0.00","totalUnrealizedPnl":"0.06","totalPnl":"0.06"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryPnLRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
        };

        var response = await client.QueryPnLAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/pnl/query", seen.Path);
        Assert.Equal("0x12e32db8817e292508c34111cbc4b23340df542c", seen.Param("walletAddress"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryPnLWithOptionalParametersAsync()
    {
        const string example = """""{"chainId":"56","walletAddress":"0x12e32db8817e292508c34111cbc4b23340df542c","pnl":{},"pnlList":[{"id":10001,"walletAddress":"0x12e32db8817e292508c34111cbc4b23340df542c","marketTopicId":4229564,"marketId":5567895,"tokenId":"112233","vendor":"PREDICT_FUN","currentShares":"1923.07","avgPrice":"0.52","currentPrice":"0.55","realizedPnl":"0.00","unrealizedPnl":"0.06","totalPnl":"0.06","pnlPercentage":"6.00","isResolved":false}],"totalCount":1,"totalRealizedPnl":"0.00","totalUnrealizedPnl":"0.06","totalPnl":"0.06"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryPnLRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            TokenId = "112233",
            MarketId = 5567895L,
            MarketTopicId = 4229564L,
            ActiveOnly = false,
            RecvWindow = 5000L,
        };

        var response = await client.QueryPnLAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/pnl/query", seen.Path);
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
    public async Task QueryPnLBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryPnLRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryPnLAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryPositionsAsync()
    {
        const string example = """""{"summary":{"totalValue":"1523.45","positionValue":"523.45","walletBalance":"1000.00","totalClaimableAmount":"50.00","todayRealizedPnl":"15.30","todayRealizedPnlPercent":"3.10","todayTotalCost":"493.55"},"counts":{"ongoingCount":3,"endedCount":12,"pendingClaimCount":1},"positions":[{"positionId":1001,"vendor":"PREDICT_FUN","chainId":"56","tokenId":"112233","collateralSymbol":"USDT","topicType":"FLAT","marketTopicId":4229564,"marketId":5567895,"marketTopicTitle":"BTC Price 1h Up or Down?","marketTitle":"UP","outcomeName":"YES","outcomeIndex":0,"shares":"1923.07","avgPrice":"0.52","totalCost":"1.00","value":"1.06","currentPrice":"0.55","toWin":"1923.07","positionStatus":"OPEN","canClaim":false,"endDate":1748134800000,"unrealizedPnl":"0.06","unrealizedPnlPercent":"6.00","realizedPnl":"0.00","pnl":"0.06","createdTime":1748131500000,"updatedTime":1748132000000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryPositionsRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
        };

        var response = await client.QueryPositionsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/position/list", seen.Path);
        Assert.Equal("0x12e32db8817e292508c34111cbc4b23340df542c", seen.Param("walletAddress"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryPositionsWithOptionalParametersAsync()
    {
        const string example = """""{"summary":{"totalValue":"1523.45","positionValue":"523.45","walletBalance":"1000.00","totalClaimableAmount":"50.00","todayRealizedPnl":"15.30","todayRealizedPnlPercent":"3.10","todayTotalCost":"493.55"},"counts":{"ongoingCount":3,"endedCount":12,"pendingClaimCount":1},"positions":[{"positionId":1001,"vendor":"PREDICT_FUN","chainId":"56","tokenId":"112233","collateralSymbol":"USDT","topicType":"FLAT","marketTopicId":4229564,"marketId":5567895,"marketTopicTitle":"BTC Price 1h Up or Down?","marketTitle":"UP","outcomeName":"YES","outcomeIndex":0,"shares":"1923.07","avgPrice":"0.52","totalCost":"1.00","value":"1.06","currentPrice":"0.55","toWin":"1923.07","positionStatus":"OPEN","canClaim":false,"endDate":1748134800000,"unrealizedPnl":"0.06","unrealizedPnlPercent":"6.00","realizedPnl":"0.00","pnl":"0.06","createdTime":1748131500000,"updatedTime":1748132000000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryPositionsRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            Tab = "ONGOING",
            Offset = 0L,
            Limit = 20L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryPositionsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/position/list", seen.Path);
        Assert.Equal("0x12e32db8817e292508c34111cbc4b23340df542c", seen.Param("walletAddress"));
        Assert.Equal("ONGOING", seen.Param("tab"));
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
    public async Task QueryPositionsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryPositionsRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryPositionsAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryPositionsByFilterAsync()
    {
        const string example = """""{"positions":[{"positionId":1001,"vendor":"PREDICT_FUN","chainId":"56","tokenId":"112233","collateralSymbol":"USDT","topicType":"FLAT","marketTopicId":4229564,"marketId":5567895,"marketTopicTitle":"BTC Price 1h Up or Down?","marketTitle":"UP","outcomeName":"YES","outcomeIndex":0,"shares":"1923.07","avgPrice":"0.52","totalCost":"1.00","value":"1.06","currentPrice":"0.55","positionStatus":"OPEN","endDate":1748134800000,"unrealizedPnl":"0.06","realizedPnl":"0.00","pnl":"0.06","createdTime":1748131500000,"updatedTime":1748132000000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryPositionsByFilterAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/position/filter", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryPositionsByFilterWithOptionalParametersAsync()
    {
        const string example = """""{"positions":[{"positionId":1001,"vendor":"PREDICT_FUN","chainId":"56","tokenId":"112233","collateralSymbol":"USDT","topicType":"FLAT","marketTopicId":4229564,"marketId":5567895,"marketTopicTitle":"BTC Price 1h Up or Down?","marketTitle":"UP","outcomeName":"YES","outcomeIndex":0,"shares":"1923.07","avgPrice":"0.52","totalCost":"1.00","value":"1.06","currentPrice":"0.55","positionStatus":"OPEN","endDate":1748134800000,"unrealizedPnl":"0.06","realizedPnl":"0.00","pnl":"0.06","createdTime":1748131500000,"updatedTime":1748132000000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryPositionsByFilterRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            MarketTopicId = 4229564L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryPositionsByFilterAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/position/filter", seen.Path);
        Assert.Equal("0x12e32db8817e292508c34111cbc4b23340df542c", seen.Param("walletAddress"));
        Assert.Equal("4229564", seen.Param("marketTopicId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryPositionsByFilterBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryPositionsByFilterAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QuerySettledPositionHistoryAsync()
    {
        const string example = """""{"totalCount":5,"positions":[{"positionId":998,"vendor":"PREDICT_FUN","chainId":"56","tokenId":"112200","collateralSymbol":"USDT","topicType":"FLAT","marketTopicId":4229500,"marketId":5567800,"marketTopicTitle":"BTC Price 1h Up or Down?","marketTitle":"UP","outcomeName":"YES","outcomeIndex":0,"shares":"5000.00","avgPrice":"0.30","totalCost":"1.50","value":"5000.00","currentPrice":"1.00","toWin":"5000.00","positionStatus":"CLAIMED","isWinner":true,"redeemStatus":"CONFIRMED","endDate":1748040000000,"finalOutcome":"YES","realizedPnl":"4998.50","pnl":"4998.50","claimAmount":"5000.00","settledDate":1748040000000,"createdTime":1748020000000,"updatedTime":1748040500000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QuerySettledPositionHistoryRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
        };

        var response = await client.QuerySettledPositionHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/position/settled-history", seen.Path);
        Assert.Equal("0x12e32db8817e292508c34111cbc4b23340df542c", seen.Param("walletAddress"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QuerySettledPositionHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"totalCount":5,"positions":[{"positionId":998,"vendor":"PREDICT_FUN","chainId":"56","tokenId":"112200","collateralSymbol":"USDT","topicType":"FLAT","marketTopicId":4229500,"marketId":5567800,"marketTopicTitle":"BTC Price 1h Up or Down?","marketTitle":"UP","outcomeName":"YES","outcomeIndex":0,"shares":"5000.00","avgPrice":"0.30","totalCost":"1.50","value":"5000.00","currentPrice":"1.00","toWin":"5000.00","positionStatus":"CLAIMED","isWinner":true,"redeemStatus":"CONFIRMED","endDate":1748040000000,"finalOutcome":"YES","realizedPnl":"4998.50","pnl":"4998.50","claimAmount":"5000.00","settledDate":1748040000000,"createdTime":1748020000000,"updatedTime":1748040500000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QuerySettledPositionHistoryRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            L1Category = "crypto",
            Result = 1L,
            StartDate = "2026-05-01",
            EndDate = "2026-05-25",
            Offset = 0L,
            Limit = 20L,
            RecvWindow = 5000L,
        };

        var response = await client.QuerySettledPositionHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/position/settled-history", seen.Path);
        Assert.Equal("0x12e32db8817e292508c34111cbc4b23340df542c", seen.Param("walletAddress"));
        Assert.Equal("crypto", seen.Param("l1Category"));
        Assert.Equal("1", seen.Param("result"));
        Assert.Equal("2026-05-01", seen.Param("startDate"));
        Assert.Equal("2026-05-25", seen.Param("endDate"));
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
    public async Task QuerySettledPositionHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QuerySettledPositionHistoryRequest
        {
            WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QuerySettledPositionHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
