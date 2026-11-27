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

namespace Binance.Alpha.RestApi;

public sealed class TokenListResponseDataInner
{
    /// <summary>Unique token identifier.</summary>
    [JsonPropertyName("tokenId")]
    public string? TokenId { get; set; }

    /// <summary>Chain ID.</summary>
    [JsonPropertyName("chainId")]
    public string? ChainId { get; set; }

    /// <summary>Chain icon URL.</summary>
    [JsonPropertyName("chainIconUrl")]
    public string? ChainIconUrl { get; set; }

    /// <summary>Chain name.</summary>
    [JsonPropertyName("chainName")]
    public string? ChainName { get; set; }

    /// <summary>Token contract address.</summary>
    [JsonPropertyName("contractAddress")]
    public string? ContractAddress { get; set; }

    /// <summary>Token name.</summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>Token symbol.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Token icon URL.</summary>
    [JsonPropertyName("iconUrl")]
    public string? IconUrl { get; set; }

    /// <summary>Latest token price.</summary>
    [JsonPropertyName("price")]
    public string? Price { get; set; }

    /// <summary>24-hour price change percentage.</summary>
    [JsonPropertyName("percentChange24h")]
    public string? PercentChange24h { get; set; }

    /// <summary>24-hour trading volume.</summary>
    [JsonPropertyName("volume24h")]
    public string? Volume24h { get; set; }

    [JsonPropertyName("marketCap")]
    public string? MarketCap { get; set; }

    [JsonPropertyName("fdv")]
    public string? Fdv { get; set; }

    [JsonPropertyName("liquidity")]
    public string? Liquidity { get; set; }

    [JsonPropertyName("totalSupply")]
    public string? TotalSupply { get; set; }

    [JsonPropertyName("circulatingSupply")]
    public string? CirculatingSupply { get; set; }

    [JsonPropertyName("holders")]
    public string? Holders { get; set; }

    [JsonPropertyName("decimals")]
    public long? Decimals { get; set; }

    [JsonPropertyName("listingCex")]
    public bool? ListingCex { get; set; }

    [JsonPropertyName("hotTag")]
    public bool? HotTag { get; set; }

    [JsonPropertyName("cexCoinName")]
    public string? CexCoinName { get; set; }

    [JsonPropertyName("canTransfer")]
    public bool? CanTransfer { get; set; }

    [JsonPropertyName("denomination")]
    public long? Denomination { get; set; }

    [JsonPropertyName("offline")]
    public bool? Offline { get; set; }

    [JsonPropertyName("tradeDecimal")]
    public long? TradeDecimal { get; set; }

    /// <summary>ALPHA token ID, e.g. ALPHA_175.</summary>
    [JsonPropertyName("alphaId")]
    public string? AlphaId { get; set; }

    [JsonPropertyName("offsell")]
    public bool? Offsell { get; set; }

    [JsonPropertyName("priceHigh24h")]
    public string? PriceHigh24h { get; set; }

    [JsonPropertyName("priceLow24h")]
    public string? PriceLow24h { get; set; }

    [JsonPropertyName("count24h")]
    public string? Count24h { get; set; }

    [JsonPropertyName("onlineTge")]
    public bool? OnlineTge { get; set; }

    [JsonPropertyName("onlineAirdrop")]
    public bool? OnlineAirdrop { get; set; }

    [JsonPropertyName("score")]
    public long? Score { get; set; }

    [JsonPropertyName("cexOffDisplay")]
    public bool? CexOffDisplay { get; set; }

    [JsonPropertyName("stockState")]
    public bool? StockState { get; set; }

    [JsonPropertyName("listingTime")]
    public long? ListingTime { get; set; }

    [JsonPropertyName("mulPoint")]
    public long? MulPoint { get; set; }

    [JsonPropertyName("bnExclusiveState")]
    public bool? BnExclusiveState { get; set; }
}
