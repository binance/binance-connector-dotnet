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

namespace Binance.DerivativesTradingCoinFutures.RestApi;

public sealed class ExchangeInformationResponse
{
    /// <summary>Exchange filters.</summary>
    [JsonPropertyName("exchangeFilters")]
    public List<string>? ExchangeFilters { get; set; }

    /// <summary>Rate limit definitions.</summary>
    [JsonPropertyName("rateLimits")]
    public List<ExchangeInformationResponseRateLimitsInner>? RateLimits { get; set; }

    /// <summary>
    /// Ignore please. If you want to check current server time, please check via "GET /dapi/v1/time"
    /// </summary>
    [JsonPropertyName("serverTime")]
    public long? ServerTime { get; set; }

    /// <summary>Supported trading symbols.</summary>
    [JsonPropertyName("symbols")]
    public List<ExchangeInformationResponseSymbolsInner>? Symbols { get; set; }

    /// <summary>Timezone of market data.</summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }
}
