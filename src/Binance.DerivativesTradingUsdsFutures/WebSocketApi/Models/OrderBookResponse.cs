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

public sealed class OrderBookResponse
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("status")]
    public long? Status { get; set; }

    [JsonPropertyName("result")]
    public OrderBookResponseResult? Result { get; set; }

    /// <summary>Bid orders. Each entry is [price, quantity].</summary>
    [JsonPropertyName("bids")]
    public List<List<string>>? Bids { get; set; }

    /// <summary>Ask orders. Each entry is [price, quantity].</summary>
    [JsonPropertyName("asks")]
    public List<List<string>>? Asks { get; set; }

    [JsonPropertyName("rateLimits")]
    public List<OrderBookResponseRateLimitsInner>? RateLimits { get; set; }
}
