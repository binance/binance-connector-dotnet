//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;
using Binance.Common.Tests;
using Binance.Mining.RestApi;

namespace Binance.Mining.Tests.RestApi;

/// <summary>Decodes an instance of every model, built from its schema, with the serializer context of the module.</summary>
public class ModelTests
{
    private static readonly JsonSerializerOptions Reflection = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };

    public static TheoryData<string, string> Cases => new()
    {
        { "AccountListResponse", "{\"code\":0,\"msg\":\"x\",\"data\":[{\"type\":\"H_hashrate\",\"userName\":\"test\",\"list\":[{\"time\":1585267200000,\"hashrate\":\"0.00000000\",\"reject\":\"0.00000000\"}]}]}" },
        { "AccountListResponseDataInner", "{\"type\":\"H_hashrate\",\"userName\":\"test\",\"list\":[{\"time\":1585267200000,\"hashrate\":\"0.00000000\",\"reject\":\"0.00000000\"}]}" },
        { "AccountListResponseDataInnerListInner", "{\"time\":1585267200000,\"hashrate\":\"0.00000000\",\"reject\":\"0.00000000\"}" },
        { "AcquiringAlgorithmResponse", "{\"code\":0,\"msg\":\"x\",\"data\":[{\"algoName\":\"SHA256-BTC\",\"algoId\":1,\"poolIndex\":100,\"unit\":\"h/s\"}]}" },
        { "AcquiringAlgorithmResponseDataInner", "{\"algoName\":\"SHA256-BTC\",\"algoId\":1,\"poolIndex\":100,\"unit\":\"h/s\"}" },
        { "AcquiringCoinnameResponse", "{\"code\":0,\"msg\":\"x\",\"data\":[{\"coinName\":\"BTC\",\"coinId\":1,\"poolIndex\":0,\"algoId\":1,\"algoName\":\"SHA256-BTC\"}]}" },
        { "AcquiringCoinnameResponseDataInner", "{\"coinName\":\"BTC\",\"coinId\":1,\"poolIndex\":0,\"algoId\":1,\"algoName\":\"SHA256-BTC\"}" },
        { "CancelHashrateResaleConfigurationResponse", "{\"code\":0,\"msg\":\"x\",\"data\":true}" },
        { "EarningsListResponse", "{\"code\":0,\"msg\":\"x\",\"data\":{\"accountProfits\":[{\"time\":1586188800000,\"type\":31,\"hashTransfer\":200000000000,\"transferAmount\":0.02180958,\"dayHashRate\":129129903378244,\"profitAmount\":8.6083060304,\"coinName\":\"BTC\",\"status\":2}],\"totalNum\":3,\"pageSize\":20}}" },
        { "EarningsListResponseData", "{\"accountProfits\":[{\"time\":1586188800000,\"type\":31,\"hashTransfer\":200000000000,\"transferAmount\":0.02180958,\"dayHashRate\":129129903378244,\"profitAmount\":8.6083060304,\"coinName\":\"BTC\",\"status\":2}],\"totalNum\":3,\"pageSize\":20}" },
        { "EarningsListResponseDataAccountProfitsInner", "{\"time\":1586188800000,\"type\":31,\"hashTransfer\":200000000000,\"transferAmount\":0.02180958,\"dayHashRate\":129129903378244,\"profitAmount\":8.6083060304,\"coinName\":\"BTC\",\"status\":2}" },
        { "ExtraBonusListResponse", "{\"code\":0,\"msg\":\"x\",\"data\":{\"otherProfits\":[{\"time\":1607443200000,\"coinName\":\"BTC\",\"type\":4,\"profitAmount\":0.0011859,\"status\":2}],\"totalNum\":3,\"pageSize\":20}}" },
        { "ExtraBonusListResponseData", "{\"otherProfits\":[{\"time\":1607443200000,\"coinName\":\"BTC\",\"type\":4,\"profitAmount\":0.0011859,\"status\":2}],\"totalNum\":3,\"pageSize\":20}" },
        { "ExtraBonusListResponseDataOtherProfitsInner", "{\"time\":1607443200000,\"coinName\":\"BTC\",\"type\":4,\"profitAmount\":0.0011859,\"status\":2}" },
        { "HashrateResaleDetailResponse", "{\"code\":0,\"msg\":\"x\",\"data\":{\"profitTransferDetails\":[{\"poolUsername\":\"test4001\",\"toPoolUsername\":\"pop\",\"algoName\":\"sha256\",\"hashRate\":200000000000,\"day\":20201213,\"amount\":0.2256872,\"coinName\":\"BTC\"}],\"totalNum\":8,\"pageSize\":200}}" },
        { "HashrateResaleDetailResponseData", "{\"profitTransferDetails\":[{\"poolUsername\":\"test4001\",\"toPoolUsername\":\"pop\",\"algoName\":\"sha256\",\"hashRate\":200000000000,\"day\":20201213,\"amount\":0.2256872,\"coinName\":\"BTC\"}],\"totalNum\":8,\"pageSize\":200}" },
        { "HashrateResaleDetailResponseDataProfitTransferDetailsInner", "{\"poolUsername\":\"test4001\",\"toPoolUsername\":\"pop\",\"algoName\":\"sha256\",\"hashRate\":200000000000,\"day\":20201213,\"amount\":0.2256872,\"coinName\":\"BTC\"}" },
        { "HashrateResaleListResponse", "{\"code\":0,\"msg\":\"x\",\"data\":{\"configDetails\":[{\"configId\":168,\"poolUsername\":\"123\",\"toPoolUsername\":\"user1\",\"algoName\":\"Ethash\",\"hashRate\":5000000,\"startDay\":20201210,\"endDay\":20210405,\"status\":1,\"type\":0}],\"totalNum\":21,\"pageSize\":200}}" },
        { "HashrateResaleListResponseData", "{\"configDetails\":[{\"configId\":168,\"poolUsername\":\"123\",\"toPoolUsername\":\"user1\",\"algoName\":\"Ethash\",\"hashRate\":5000000,\"startDay\":20201210,\"endDay\":20210405,\"status\":1,\"type\":0}],\"totalNum\":21,\"pageSize\":200}" },
        { "HashrateResaleListResponseDataConfigDetailsInner", "{\"configId\":168,\"poolUsername\":\"123\",\"toPoolUsername\":\"user1\",\"algoName\":\"Ethash\",\"hashRate\":5000000,\"startDay\":20201210,\"endDay\":20210405,\"status\":1,\"type\":0}" },
        { "HashrateResaleRequestResponse", "{\"code\":0,\"msg\":\"x\",\"data\":171}" },
        { "MiningAccountEarningResponse", "{\"code\":0,\"msg\":\"x\",\"data\":{\"accountProfits\":[{\"time\":1607443200000,\"coinName\":\"BTC\",\"type\":2,\"puid\":59985472,\"subName\":\"vdvaghani\",\"amount\":0.09186957}],\"totalNum\":3,\"pageSize\":20}}" },
        { "MiningAccountEarningResponseData", "{\"accountProfits\":[{\"time\":1607443200000,\"coinName\":\"BTC\",\"type\":2,\"puid\":59985472,\"subName\":\"vdvaghani\",\"amount\":0.09186957}],\"totalNum\":3,\"pageSize\":20}" },
        { "MiningAccountEarningResponseDataAccountProfitsInner", "{\"time\":1607443200000,\"coinName\":\"BTC\",\"type\":2,\"puid\":59985472,\"subName\":\"vdvaghani\",\"amount\":0.09186957}" },
        { "RequestForDetailMinerListResponse", "{\"code\":0,\"msg\":\"x\",\"data\":[{\"workerName\":\"bhdc1.16A10404B\",\"type\":\"H_hashrate\",\"hashrateDatas\":[{\"time\":1587902400000,\"hashrate\":\"0\",\"reject\":0}]}]}" },
        { "RequestForDetailMinerListResponseDataInner", "{\"workerName\":\"bhdc1.16A10404B\",\"type\":\"H_hashrate\",\"hashrateDatas\":[{\"time\":1587902400000,\"hashrate\":\"0\",\"reject\":0}]}" },
        { "RequestForDetailMinerListResponseDataInnerHashrateDatasInner", "{\"time\":1587902400000,\"hashrate\":\"0\",\"reject\":0}" },
        { "RequestForMinerListResponse", "{\"code\":0,\"msg\":\"x\",\"data\":{\"workerDatas\":[{\"workerId\":\"1420554439452400131\",\"workerName\":\"2X73\",\"status\":3,\"hashRate\":0,\"dayHashRate\":12697781298013.66,\"rejectRate\":0,\"lastShareTime\":1587712919000}],\"totalNum\":18530,\"pageSize\":20}}" },
        { "RequestForMinerListResponseData", "{\"workerDatas\":[{\"workerId\":\"1420554439452400131\",\"workerName\":\"2X73\",\"status\":3,\"hashRate\":0,\"dayHashRate\":12697781298013.66,\"rejectRate\":0,\"lastShareTime\":1587712919000}],\"totalNum\":18530,\"pageSize\":20}" },
        { "RequestForMinerListResponseDataWorkerDatasInner", "{\"workerId\":\"1420554439452400131\",\"workerName\":\"2X73\",\"status\":3,\"hashRate\":0,\"dayHashRate\":12697781298013.66,\"rejectRate\":0,\"lastShareTime\":1587712919000}" },
        { "StatisticListResponse", "{\"code\":0,\"msg\":\"x\",\"data\":{\"fifteenMinHashRate\":\"457835490067496409.00000000\",\"dayHashRate\":\"214289268068874127.65000000\",\"validNum\":0,\"invalidNum\":17562,\"profitToday\":{\"k\":\"x\"},\"profitYesterday\":{\"k\":\"x\"},\"userName\":\"test\",\"unit\":\"h/s\",\"algo\":\"sha256\"}}" },
        { "StatisticListResponseData", "{\"fifteenMinHashRate\":\"457835490067496409.00000000\",\"dayHashRate\":\"214289268068874127.65000000\",\"validNum\":0,\"invalidNum\":17562,\"profitToday\":{\"k\":\"x\"},\"profitYesterday\":{\"k\":\"x\"},\"userName\":\"test\",\"unit\":\"h/s\",\"algo\":\"sha256\"}" },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void DecodesAndRoundTrips(string name, string json)
    {
        var assembly = typeof(MiningRestApi).Assembly;
        var type = assembly.GetType($"Binance.Mining.RestApi.{name.Split('/')[0]}", throwOnError: true)!;
        var context = (JsonSerializerContext)assembly.GetType("Binance.Mining.RestApi.MiningRestApiJson")!.GetProperty("Default")!.GetValue(null)!;
        // A model that no operation returns is not in the serializer context, so it is decoded by reflection.
        var info = context.GetTypeInfo(type);
        var model = info is null ? JsonSerializer.Deserialize(json, type, Reflection) : JsonSerializer.Deserialize(json, info);
        ExampleAssert.Matches(json, model);
    }
}
