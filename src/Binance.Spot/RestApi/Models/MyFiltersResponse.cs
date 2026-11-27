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

namespace Binance.Spot.RestApi;

public sealed class MyFiltersResponse
{
    [JsonPropertyName("exchangeFilters")]
    public List<MyFiltersResponseExchangeFiltersInner>? ExchangeFilters { get; set; }

    [JsonPropertyName("symbolFilters")]
    public List<MyFiltersResponseSymbolFiltersInner>? SymbolFilters { get; set; }

    [JsonPropertyName("assetFilters")]
    public List<MyFiltersResponseAssetFiltersInner>? AssetFilters { get; set; }

    [JsonPropertyName("rateLimits")]
    public List<MyFiltersResponseRateLimitsInner>? RateLimits { get; set; }
}
