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

namespace Binance.DerivativesTradingUsdsFutures.WebSocketStreams;

public sealed class ContractInfoStreamResponseBksInner
{
    /// <summary>Notional bracket</summary>
    [JsonPropertyName("bs")]
    public long? Bs { get; set; }

    /// <summary>Floor notional of this bracket</summary>
    [JsonPropertyName("bnf")]
    public long? Bnf { get; set; }

    /// <summary>Cap notional of this bracket</summary>
    [JsonPropertyName("bnc")]
    public long? Bnc { get; set; }

    /// <summary>Maintenance ratio for this bracket</summary>
    [JsonPropertyName("mmr")]
    public decimal? Mmr { get; set; }

    /// <summary>Auxiliary number for quick calculation</summary>
    [JsonPropertyName("cf")]
    public long? Cf { get; set; }

    /// <summary>Min leverage for this bracket</summary>
    [JsonPropertyName("mi")]
    public long? Mi { get; set; }

    /// <summary>Max leverage for this bracket</summary>
    [JsonPropertyName("ma")]
    public long? Ma { get; set; }
}
