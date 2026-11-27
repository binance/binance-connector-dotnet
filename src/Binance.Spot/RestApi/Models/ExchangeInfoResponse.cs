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

public sealed class ExchangeInfoResponse
{
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    [JsonPropertyName("serverTime")]
    public long? ServerTime { get; set; }

    [JsonPropertyName("rateLimits")]
    public List<MyFiltersResponseRateLimitsInner>? RateLimits { get; set; }

    /// <summary>
    /// Exchange filters are explained on the "Filters" page: All exchange filters are optional.
    /// </summary>
    [JsonPropertyName("exchangeFilters")]
    public List<MyFiltersResponseExchangeFiltersInner>? ExchangeFilters { get; set; }

    [JsonPropertyName("symbols")]
    public List<ExchangeInfoResponseSymbolsInner>? Symbols { get; set; }

    /// <summary>Optional field. Present only when SOR is available.</summary>
    [JsonPropertyName("sors")]
    public List<ExchangeInfoResponseSorsInner>? Sors { get; set; }
}
