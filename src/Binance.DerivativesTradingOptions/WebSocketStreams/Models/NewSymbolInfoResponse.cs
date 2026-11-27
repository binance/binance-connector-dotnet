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

namespace Binance.DerivativesTradingOptions.WebSocketStreams;

public sealed class NewSymbolInfoResponse
{
    /// <summary>Event Type</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>Event Time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>Underlying index of the contract</summary>
    [JsonPropertyName("ps")]
    public string? Ps { get; set; }

    /// <summary>Quotation asset</summary>
    [JsonPropertyName("qa")]
    public string? Qa { get; set; }

    /// <summary>Option type</summary>
    [JsonPropertyName("d")]
    public string? D { get; set; }

    /// <summary>Strike price</summary>
    [JsonPropertyName("sp")]
    public string? Sp { get; set; }

    /// <summary>Delivery date time</summary>
    [JsonPropertyName("dt")]
    public long? Dt { get; set; }

    /// <summary>unit, the quantity of the underlying asset represented by a single contract.</summary>
    [JsonPropertyName("u")]
    public long? U { get; set; }

    /// <summary>onboard date time</summary>
    [JsonPropertyName("ot")]
    public long? Ot { get; set; }

    /// <summary>Contract status</summary>
    [JsonPropertyName("cs")]
    public string? Cs { get; set; }
}
