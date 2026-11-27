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

namespace Binance.DerivativesTradingCoinFutures.WebSocketStreams;

public sealed class AlgoUpdateO
{
    /// <summary>Client Algo Id</summary>
    [JsonPropertyName("caid")]
    public string? Caid { get; set; }

    /// <summary>Algo Id</summary>
    [JsonPropertyName("aid")]
    public long? Aid { get; set; }

    /// <summary>Algo Type</summary>
    [JsonPropertyName("at")]
    public string? At { get; set; }

    /// <summary>Order Type</summary>
    [JsonPropertyName("o")]
    public string? O { get; set; }

    /// <summary>Symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>Side</summary>
    [JsonPropertyName("S")]
    public string? SUppercase { get; set; }

    /// <summary>Position Side</summary>
    [JsonPropertyName("ps")]
    public string? Ps { get; set; }

    /// <summary>Time in force</summary>
    [JsonPropertyName("f")]
    public string? F { get; set; }

    /// <summary>Quantity</summary>
    [JsonPropertyName("q")]
    public string? Q { get; set; }

    /// <summary>Algo Status</summary>
    [JsonPropertyName("X")]
    public string? XUppercase { get; set; }

    /// <summary>Order Id</summary>
    [JsonPropertyName("ai")]
    public string? Ai { get; set; }

    /// <summary>
    /// Avg fill price in matching engine, only display when order is triggered and placed in matching
    /// engine
    /// </summary>
    [JsonPropertyName("ap")]
    public string? Ap { get; set; }

    /// <summary>
    /// Executed quantity in matching engine, only display when order is triggered and placed in matching
    /// engine
    /// </summary>
    [JsonPropertyName("aq")]
    public string? Aq { get; set; }

    /// <summary>
    /// Actual order type in matching engine, only display when order is triggered and placed in matching
    /// engine
    /// </summary>
    [JsonPropertyName("act")]
    public string? Act { get; set; }

    /// <summary>Trigger Price</summary>
    [JsonPropertyName("tp")]
    public string? Tp { get; set; }

    /// <summary>Order Price</summary>
    [JsonPropertyName("p")]
    public string? P { get; set; }

    /// <summary>STP mode</summary>
    [JsonPropertyName("V")]
    public string? VUppercase { get; set; }

    /// <summary>Working type</summary>
    [JsonPropertyName("wt")]
    public string? Wt { get; set; }

    /// <summary>Price match mode</summary>
    [JsonPropertyName("pm")]
    public string? Pm { get; set; }

    /// <summary>If Close-All</summary>
    [JsonPropertyName("cp")]
    public bool? Cp { get; set; }

    /// <summary>If price protection is turned on</summary>
    [JsonPropertyName("pP")]
    public bool? PPUppercase { get; set; }

    /// <summary>Is this reduce only</summary>
    [JsonPropertyName("R")]
    public bool? RUppercase { get; set; }

    /// <summary>Trigger time</summary>
    [JsonPropertyName("tt")]
    public long? Tt { get; set; }

    /// <summary>Good till time for GTD time in force</summary>
    [JsonPropertyName("gtd")]
    public long? Gtd { get; set; }

    /// <summary>Algo order failed reason</summary>
    [JsonPropertyName("rm")]
    public string? Rm { get; set; }

    /// <summary>Is activated or not, only meaningful for trailing order</summary>
    [JsonPropertyName("ia")]
    public bool? Ia { get; set; }

    /// <summary>Sub price type, only meaningful for CHASE order</summary>
    [JsonPropertyName("spt")]
    public string? Spt { get; set; }

    /// <summary>Sub price value, only meaningful for CHASE order</summary>
    [JsonPropertyName("spv")]
    public string? Spv { get; set; }

    /// <summary>Sub price limit value, only meaningful for CHASE order</summary>
    [JsonPropertyName("splv")]
    public string? Splv { get; set; }
}
