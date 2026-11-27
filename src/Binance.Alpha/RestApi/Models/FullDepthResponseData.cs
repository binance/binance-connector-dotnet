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

/// <summary>Order book data.</summary>
public sealed class FullDepthResponseData
{
    /// <summary>Last order book update ID.</summary>
    [JsonPropertyName("lastUpdateId")]
    public long? LastUpdateId { get; set; }

    /// <summary>Trading pair symbol.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Bid orders. Each entry is [price, quantity].</summary>
    [JsonPropertyName("bids")]
    public List<List<string>>? Bids { get; set; }

    /// <summary>Ask orders. Each entry is [price, quantity].</summary>
    [JsonPropertyName("asks")]
    public List<List<string>>? Asks { get; set; }

    /// <summary>Event time in milliseconds.</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Transaction time in milliseconds.</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }
}
