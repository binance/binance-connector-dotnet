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
using Binance.Alpha.RestApi;

namespace Binance.Alpha.Tests.RestApi;

/// <summary>Decodes an instance of every model, built from its schema, with the serializer context of the module.</summary>
public class ModelTests
{
    private static readonly JsonSerializerOptions Reflection = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };

    public static TheoryData<string, string> Cases => new()
    {
        { "AggregatedTradesResponse", "{\"code\":\"000000\",\"message\":\"x\",\"messageDetail\":\"x\",\"data\":[{\"a\":58470,\"p\":\"1.00\",\"q\":\"1.00\",\"f\":58470,\"l\":58665,\"T\":1752568680000,\"m\":true}]}" },
        { "AggregatedTradesResponseDataInner", "{\"a\":58470,\"p\":\"1.00\",\"q\":\"1.00\",\"f\":58470,\"l\":58665,\"T\":1752568680000,\"m\":true}" },
        { "FullDepthResponse", "{\"code\":\"000000\",\"message\":\"message\",\"messageDetail\":\"messageDetail\",\"success\":true,\"data\":{\"lastUpdateId\":47534656223,\"symbol\":\"ALPHA_175USDT\",\"bids\":[[\"x\"]],\"asks\":[[\"x\"]],\"E\":1775027836086,\"T\":1775027836072}}" },
        { "FullDepthResponseData", "{\"lastUpdateId\":47534656223,\"symbol\":\"ALPHA_175USDT\",\"bids\":[[\"x\"]],\"asks\":[[\"x\"]],\"E\":1775027836086,\"T\":1775027836072}" },
        { "GetExchangeInfoResponse", "{\"code\":\"000000\",\"message\":\"x\",\"messageDetail\":\"x\",\"success\":true,\"data\":{\"timezone\":\"UTC\",\"assets\":[{\"asset\":\"USDT\"}],\"symbols\":[{\"symbol\":\"ALPHA_105USDT\",\"status\":\"TRADING\",\"baseAsset\":\"ALPHA_105\",\"quoteAsset\":\"USDT\",\"pricePrecision\":8,\"quantityPrecision\":8,\"baseAssetPrecision\":8,\"quotePrecision\":8,\"filters\":[{\"filterType\":\"PRICE_FILTER\",\"minPrice\":\"0.00000001\",\"maxPrice\":\"1000\",\"tickSize\":\"0.00000001\",\"stepSize\":\"0.01000000\",\"maxQty\":\"277778\",\"minQty\":\"0.01000000\",\"limit\":200,\"minNotional\":\"0.1\",\"maxNotional\":\"1000000\",\"multiplierDown\":\"0.20000\",\"multiplierUp\":\"5\",\"bidMultiplierUp\":\"5\",\"askMultiplierUp\":\"5\",\"bidMultiplierDown\":\"0.20000\",\"askMultiplierDown\":\"0.20000\"}],\"orderTypes\":[\"x\"]}],\"orderTypes\":\"x\"}}" },
        { "GetExchangeInfoResponseData", "{\"timezone\":\"UTC\",\"assets\":[{\"asset\":\"USDT\"}],\"symbols\":[{\"symbol\":\"ALPHA_105USDT\",\"status\":\"TRADING\",\"baseAsset\":\"ALPHA_105\",\"quoteAsset\":\"USDT\",\"pricePrecision\":8,\"quantityPrecision\":8,\"baseAssetPrecision\":8,\"quotePrecision\":8,\"filters\":[{\"filterType\":\"PRICE_FILTER\",\"minPrice\":\"0.00000001\",\"maxPrice\":\"1000\",\"tickSize\":\"0.00000001\",\"stepSize\":\"0.01000000\",\"maxQty\":\"277778\",\"minQty\":\"0.01000000\",\"limit\":200,\"minNotional\":\"0.1\",\"maxNotional\":\"1000000\",\"multiplierDown\":\"0.20000\",\"multiplierUp\":\"5\",\"bidMultiplierUp\":\"5\",\"askMultiplierUp\":\"5\",\"bidMultiplierDown\":\"0.20000\",\"askMultiplierDown\":\"0.20000\"}],\"orderTypes\":[\"x\"]}],\"orderTypes\":\"x\"}" },
        { "GetExchangeInfoResponseDataAssetsInner", "{\"asset\":\"USDT\"}" },
        { "GetExchangeInfoResponseDataSymbolsInner", "{\"symbol\":\"ALPHA_105USDT\",\"status\":\"TRADING\",\"baseAsset\":\"ALPHA_105\",\"quoteAsset\":\"USDT\",\"pricePrecision\":8,\"quantityPrecision\":8,\"baseAssetPrecision\":8,\"quotePrecision\":8,\"filters\":[{\"filterType\":\"PRICE_FILTER\",\"minPrice\":\"0.00000001\",\"maxPrice\":\"1000\",\"tickSize\":\"0.00000001\",\"stepSize\":\"0.01000000\",\"maxQty\":\"277778\",\"minQty\":\"0.01000000\",\"limit\":200,\"minNotional\":\"0.1\",\"maxNotional\":\"1000000\",\"multiplierDown\":\"0.20000\",\"multiplierUp\":\"5\",\"bidMultiplierUp\":\"5\",\"askMultiplierUp\":\"5\",\"bidMultiplierDown\":\"0.20000\",\"askMultiplierDown\":\"0.20000\"}],\"orderTypes\":[\"x\"]}" },
        { "GetExchangeInfoResponseDataSymbolsInnerFiltersInner", "{\"filterType\":\"PRICE_FILTER\",\"minPrice\":\"0.00000001\",\"maxPrice\":\"1000\",\"tickSize\":\"0.00000001\",\"stepSize\":\"0.01000000\",\"maxQty\":\"277778\",\"minQty\":\"0.01000000\",\"limit\":200,\"minNotional\":\"0.1\",\"maxNotional\":\"1000000\",\"multiplierDown\":\"0.20000\",\"multiplierUp\":\"5\",\"bidMultiplierUp\":\"5\",\"askMultiplierUp\":\"5\",\"bidMultiplierDown\":\"0.20000\",\"askMultiplierDown\":\"0.20000\"}" },
        { "KlinesResponse", "{\"code\":\"000000\",\"message\":\"x\",\"messageDetail\":\"x\",\"success\":true,\"data\":[[\"x\"]]}" },
        { "KlinesResponseDataInnerInner/string", "\"x\"" },
        { "KlinesResponseDataInnerInner/long", "1" },
        { "TickerResponse", "{\"code\":\"000000\",\"message\":\"x\",\"messageDetail\":\"x\",\"data\":{\"symbol\":\"ALPHA_175USDT\",\"priceChange\":\"-0.00007172\",\"priceChangePercent\":\"-8.841\",\"weightedAvgPrice\":\"0.00079608\",\"lastPrice\":\"0.00073954\",\"lastQty\":\"12600.43000000\",\"openPrice\":\"0.00081126\",\"highPrice\":\"0.00081126\",\"lowPrice\":\"0.00073954\",\"volume\":\"1204754.30000000\",\"quoteVolume\":\"959.07729927\",\"openTime\":1768808100000,\"closeTime\":1768893244772,\"firstId\":93742,\"lastId\":93768,\"count\":38},\"success\":true}" },
        { "TickerResponseData", "{\"symbol\":\"ALPHA_175USDT\",\"priceChange\":\"-0.00007172\",\"priceChangePercent\":\"-8.841\",\"weightedAvgPrice\":\"0.00079608\",\"lastPrice\":\"0.00073954\",\"lastQty\":\"12600.43000000\",\"openPrice\":\"0.00081126\",\"highPrice\":\"0.00081126\",\"lowPrice\":\"0.00073954\",\"volume\":\"1204754.30000000\",\"quoteVolume\":\"959.07729927\",\"openTime\":1768808100000,\"closeTime\":1768893244772,\"firstId\":93742,\"lastId\":93768,\"count\":38}" },
        { "TokenListResponse", "{\"code\":\"000000\",\"message\":\"x\",\"messageDetail\":\"x\",\"success\":true,\"data\":[{\"tokenId\":\"3F350C8B3621770A673159B7A19BC034\",\"chainId\":\"56\",\"chainIconUrl\":\"https://bin.bnbstatic.com/image/admin_mgs_image_upload/20250228/d0216ce4-a3e9-4bda-8937-4a6aa943ccf2.png\",\"chainName\":\"BSC\",\"contractAddress\":\"0xcf640fdf9b3d9e45cbd69fda91d7e22579c14444\",\"name\":\"gorilla\",\"symbol\":\"gorilla\",\"iconUrl\":\"https://bin.bnbstatic.com/images/web3-data/public/token/logos/248b5406f88a4ee28913a29107875339.png\",\"price\":\"0.00080595003978242023\",\"percentChange24h\":\"-7.42\",\"volume24h\":\"14847.711222633409558029675\",\"marketCap\":\"805950.03978242\",\"fdv\":\"805950.03978242\",\"liquidity\":\"263192.72813121626034\",\"totalSupply\":\"1000000000\",\"circulatingSupply\":\"1000000000\",\"holders\":\"7120\",\"decimals\":18,\"listingCex\":false,\"hotTag\":false,\"cexCoinName\":\"x\",\"canTransfer\":false,\"denomination\":1,\"offline\":false,\"tradeDecimal\":8,\"alphaId\":\"ALPHA_175\",\"offsell\":false,\"priceHigh24h\":\"0.00088873864475645879\",\"priceLow24h\":\"0.0008020805165487083\",\"count24h\":\"166\",\"onlineTge\":false,\"onlineAirdrop\":false,\"score\":1,\"cexOffDisplay\":false,\"stockState\":false,\"listingTime\":1746686700000,\"mulPoint\":1,\"bnExclusiveState\":false}]}" },
        { "TokenListResponseDataInner", "{\"tokenId\":\"3F350C8B3621770A673159B7A19BC034\",\"chainId\":\"56\",\"chainIconUrl\":\"https://bin.bnbstatic.com/image/admin_mgs_image_upload/20250228/d0216ce4-a3e9-4bda-8937-4a6aa943ccf2.png\",\"chainName\":\"BSC\",\"contractAddress\":\"0xcf640fdf9b3d9e45cbd69fda91d7e22579c14444\",\"name\":\"gorilla\",\"symbol\":\"gorilla\",\"iconUrl\":\"https://bin.bnbstatic.com/images/web3-data/public/token/logos/248b5406f88a4ee28913a29107875339.png\",\"price\":\"0.00080595003978242023\",\"percentChange24h\":\"-7.42\",\"volume24h\":\"14847.711222633409558029675\",\"marketCap\":\"805950.03978242\",\"fdv\":\"805950.03978242\",\"liquidity\":\"263192.72813121626034\",\"totalSupply\":\"1000000000\",\"circulatingSupply\":\"1000000000\",\"holders\":\"7120\",\"decimals\":18,\"listingCex\":false,\"hotTag\":false,\"cexCoinName\":\"x\",\"canTransfer\":false,\"denomination\":1,\"offline\":false,\"tradeDecimal\":8,\"alphaId\":\"ALPHA_175\",\"offsell\":false,\"priceHigh24h\":\"0.00088873864475645879\",\"priceLow24h\":\"0.0008020805165487083\",\"count24h\":\"166\",\"onlineTge\":false,\"onlineAirdrop\":false,\"score\":1,\"cexOffDisplay\":false,\"stockState\":false,\"listingTime\":1746686700000,\"mulPoint\":1,\"bnExclusiveState\":false}" },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void DecodesAndRoundTrips(string name, string json)
    {
        var assembly = typeof(AlphaRestApi).Assembly;
        var type = assembly.GetType($"Binance.Alpha.RestApi.{name.Split('/')[0]}", throwOnError: true)!;
        var context = (JsonSerializerContext)assembly.GetType("Binance.Alpha.RestApi.AlphaRestApiJson")!.GetProperty("Default")!.GetValue(null)!;
        // A model that no operation returns is not in the serializer context, so it is decoded by reflection.
        var info = context.GetTypeInfo(type);
        var model = info is null ? JsonSerializer.Deserialize(json, type, Reflection) : JsonSerializer.Deserialize(json, info);
        ExampleAssert.Matches(json, model);
    }
}
