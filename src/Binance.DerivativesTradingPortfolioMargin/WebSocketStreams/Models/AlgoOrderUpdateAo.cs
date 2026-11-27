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

/// <summary>Algo order info</summary>
public sealed class AlgoOrderUpdateAo
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

    /// <summary>Time in Force</summary>
    [JsonPropertyName("f")]
    public string? F { get; set; }

    /// <summary>Quantity</summary>
    [JsonPropertyName("q")]
    public string? Q { get; set; }

    /// <summary>Algo Status: NEW, CANCELED, TRIGGERING, TRIGGERED, FINISHED, REJECTED, EXPIRED</summary>
    [JsonPropertyName("X")]
    public string? XUppercase { get; set; }

    /// <summary>Actual order ID in matching engine</summary>
    [JsonPropertyName("ai")]
    public string? Ai { get; set; }

    /// <summary>Avg fill price in matching engine</summary>
    [JsonPropertyName("ap")]
    public string? Ap { get; set; }

    /// <summary>Executed quantity in matching engine</summary>
    [JsonPropertyName("aq")]
    public string? Aq { get; set; }

    /// <summary>Actual order type in matching engine</summary>
    [JsonPropertyName("act")]
    public string? Act { get; set; }

    /// <summary>Trigger Price</summary>
    [JsonPropertyName("tp")]
    public string? Tp { get; set; }

    /// <summary>Order Price</summary>
    [JsonPropertyName("p")]
    public string? P { get; set; }

    /// <summary>Self Trade Prevention Mode</summary>
    [JsonPropertyName("V")]
    public string? VUppercase { get; set; }

    /// <summary>Working Type</summary>
    [JsonPropertyName("wt")]
    public string? Wt { get; set; }

    /// <summary>Price Match</summary>
    [JsonPropertyName("pm")]
    public string? Pm { get; set; }

    /// <summary>If Close-All</summary>
    [JsonPropertyName("cp")]
    public bool? Cp { get; set; }

    /// <summary>If price protection is on</summary>
    [JsonPropertyName("pP")]
    public bool? PPUppercase { get; set; }

    /// <summary>Is reduce only</summary>
    [JsonPropertyName("R")]
    public bool? RUppercase { get; set; }

    /// <summary>Trigger Time</summary>
    [JsonPropertyName("tt")]
    public long? Tt { get; set; }

    /// <summary>Good Till Date</summary>
    [JsonPropertyName("gtd")]
    public long? Gtd { get; set; }

    /// <summary>Algo order failed reason</summary>
    [JsonPropertyName("rm")]
    public string? Rm { get; set; }

    /// <summary>Is activated or not, only meaningful for trailing order</summary>
    [JsonPropertyName("ia")]
    public bool? Ia { get; set; }
}
