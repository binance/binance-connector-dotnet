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

namespace Binance.DerivativesTradingOptions.RestApi;

public sealed class ExchangeInformationResponse
{
    /// <summary>Time zone used by the server</summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    /// <summary>Current system time</summary>
    [JsonPropertyName("serverTime")]
    public long? ServerTime { get; set; }

    /// <summary>Option contract underlying asset info</summary>
    [JsonPropertyName("optionContracts")]
    public List<ExchangeInformationResponseOptionContractsInner>? OptionContracts { get; set; }

    /// <summary>Option asset info</summary>
    [JsonPropertyName("optionAssets")]
    public List<ExchangeInformationResponseOptionAssetsInner>? OptionAssets { get; set; }

    /// <summary>Option trading pair info</summary>
    [JsonPropertyName("optionSymbols")]
    public List<ExchangeInformationResponseOptionSymbolsInner>? OptionSymbols { get; set; }

    /// <summary>rate Limits</summary>
    [JsonPropertyName("rateLimits")]
    public List<ExchangeInformationResponseRateLimitsInner>? RateLimits { get; set; }
}
