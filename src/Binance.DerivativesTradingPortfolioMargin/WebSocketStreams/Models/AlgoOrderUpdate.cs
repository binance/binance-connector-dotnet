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

namespace Binance.DerivativesTradingPortfolioMargin.WebSocketStreams;

public sealed class AlgoOrderUpdate
{
    /// <summary>Transaction Time</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>Event Time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Futures segment, UM for USDS-M Futures, CM for Coin-M Futures</summary>
    [JsonPropertyName("fs")]
    public string? Fs { get; set; }

    [JsonPropertyName("ao")]
    public AlgoOrderUpdateAo? Ao { get; set; }
}
