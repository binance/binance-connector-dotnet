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

namespace Binance.DerivativesTradingUsdsFutures.WebSocketApi;

public sealed class FuturesAccountBalanceV2Response
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("status")]
    public long? Status { get; set; }

    [JsonPropertyName("result")]
    public List<FuturesAccountBalanceResponseResultInner>? Result { get; set; }

    [JsonPropertyName("rateLimits")]
    public List<AccountInformationResponseRateLimitsInner>? RateLimits { get; set; }
}
