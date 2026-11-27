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

namespace Binance.DerivativesTradingCoinFutures.WebSocketApi;

public sealed class FuturesAccountBalanceResponse
{
    /// <summary>positionId</summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("status")]
    public long? Status { get; set; }

    /// <summary>Indicates that combined is set to true.</summary>
    [JsonPropertyName("result")]
    public List<FuturesAccountBalanceResponseResultInner>? Result { get; set; }

    /// <summary>Rate limit definitions.</summary>
    [JsonPropertyName("rateLimits")]
    public List<AccountInformationResponseRateLimitsInner>? RateLimits { get; set; }
}
