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

public sealed class OrderBookResponse
{
    /// <summary>Bid orders. Each entry is [price, quantity].</summary>
    [JsonPropertyName("bids")]
    public List<List<string>>? Bids { get; set; }

    /// <summary>Ask orders. Each entry is [price, quantity].</summary>
    [JsonPropertyName("asks")]
    public List<List<string>>? Asks { get; set; }

    /// <summary>transaction time</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>update id</summary>
    [JsonPropertyName("lastUpdateId")]
    public long? LastUpdateId { get; set; }
}
