//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;
using Binance.Common;

namespace Binance.W3WPrediction.RestApi;

public sealed class GetQuoteResponse
{
    [JsonPropertyName("quoteId")]
    public string? QuoteId { get; set; }

    [JsonPropertyName("tokenId")]
    public string? TokenId { get; set; }

    [JsonPropertyName("chance")]
    public string? Chance { get; set; }

    [JsonPropertyName("vendor")]
    public string? Vendor { get; set; }

    [JsonPropertyName("marketTitle")]
    public string? MarketTitle { get; set; }

    [JsonPropertyName("marketExtId")]
    public string? MarketExtId { get; set; }

    [JsonPropertyName("side")]
    public string? Side { get; set; }

    [JsonPropertyName("amountIn")]
    public string? AmountIn { get; set; }

    [JsonPropertyName("amountOut")]
    public string? AmountOut { get; set; }

    [JsonPropertyName("isMinAmountOut")]
    public bool? IsMinAmountOut { get; set; }

    [JsonPropertyName("feeAmount")]
    public string? FeeAmount { get; set; }

    [JsonPropertyName("feeDiscountBps")]
    public string? FeeDiscountBps { get; set; }

    [JsonPropertyName("averagePrice")]
    public decimal? AveragePrice { get; set; }

    [JsonPropertyName("lastPrice")]
    public decimal? LastPrice { get; set; }

    [JsonPropertyName("priceImpact")]
    public decimal? PriceImpact { get; set; }

    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; set; }

    [JsonPropertyName("chainId")]
    public string? ChainId { get; set; }

    [JsonPropertyName("userId")]
    public long? UserId { get; set; }

    [JsonPropertyName("walletAddress")]
    public string? WalletAddress { get; set; }

    [JsonPropertyName("orderType")]
    public string? OrderType { get; set; }

    [JsonPropertyName("slippageBps")]
    public long? SlippageBps { get; set; }

    [JsonPropertyName("feeRateBps")]
    public long? FeeRateBps { get; set; }

    [JsonPropertyName("minReceive")]
    public string? MinReceive { get; set; }

    [JsonPropertyName("expireAt")]
    public long? ExpireAt { get; set; }

    [JsonPropertyName("priceLimit")]
    public string? PriceLimit { get; set; }
}
