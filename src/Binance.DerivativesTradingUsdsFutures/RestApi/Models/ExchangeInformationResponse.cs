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

namespace Binance.DerivativesTradingUsdsFutures.RestApi;

public sealed class ExchangeInformationResponse
{
    [JsonPropertyName("exchangeFilters")]
    public List<string>? ExchangeFilters { get; set; }

    /// <summary>Rate Limits.</summary>
    [JsonPropertyName("rateLimits")]
    public List<ExchangeInformationResponseRateLimitsInner>? RateLimits { get; set; }

    /// <summary>
    /// Ignore please. If you want to check current server time, please check via "GET /fapi/v1/time"
    /// </summary>
    [JsonPropertyName("serverTime")]
    public long? ServerTime { get; set; }

    /// <summary>assets information</summary>
    [JsonPropertyName("assets")]
    public List<ExchangeInformationResponseAssetsInner>? Assets { get; set; }

    /// <summary>Symbols.</summary>
    [JsonPropertyName("symbols")]
    public List<ExchangeInformationResponseSymbolsInner>? Symbols { get; set; }

    /// <summary>Timezone.</summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }
}
