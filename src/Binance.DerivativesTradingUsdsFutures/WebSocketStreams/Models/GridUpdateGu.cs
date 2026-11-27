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

public sealed class GridUpdateGu
{
    /// <summary>Strategy ID</summary>
    [JsonPropertyName("si")]
    public long? Si { get; set; }

    /// <summary>Strategy Type</summary>
    [JsonPropertyName("st")]
    public string? St { get; set; }

    /// <summary>Strategy Status</summary>
    [JsonPropertyName("ss")]
    public string? Ss { get; set; }

    /// <summary>Symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>Realized PNL</summary>
    [JsonPropertyName("r")]
    public string? R { get; set; }

    /// <summary>Unmatched Average Price</summary>
    [JsonPropertyName("up")]
    public string? Up { get; set; }

    /// <summary>Unmatched Qty</summary>
    [JsonPropertyName("uq")]
    public string? Uq { get; set; }

    /// <summary>Unmatched Fee</summary>
    [JsonPropertyName("uf")]
    public string? Uf { get; set; }

    /// <summary>Matched PNL</summary>
    [JsonPropertyName("mp")]
    public string? Mp { get; set; }

    /// <summary>Update Time</summary>
    [JsonPropertyName("ut")]
    public long? Ut { get; set; }
}
