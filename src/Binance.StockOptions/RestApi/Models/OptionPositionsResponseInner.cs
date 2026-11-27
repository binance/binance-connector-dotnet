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

namespace Binance.StockOptions.RestApi;

public sealed class OptionPositionsResponseInner
{
    /// <summary>OCC option contract symbol.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Underlying US-equity ticker.</summary>
    [JsonPropertyName("underlyingSymbol")]
    public string? UnderlyingSymbol { get; set; }

    /// <summary>CALL / PUT.</summary>
    [JsonPropertyName("contractType")]
    public string? ContractType { get; set; }

    /// <summary>Position side: LONG / SHORT.</summary>
    [JsonPropertyName("side")]
    public string? Side { get; set; }

    /// <summary>Contracts available to close, signed (negative for short positions).</summary>
    [JsonPropertyName("free")]
    public string? Free { get; set; }

    /// <summary>
    /// Contracts reserved by open orders or submitted exercises, signed (negative for short positions).
    /// </summary>
    [JsonPropertyName("locked")]
    public string? Locked { get; set; }

    /// <summary>Strike price.</summary>
    [JsonPropertyName("strikePrice")]
    public string? StrikePrice { get; set; }

    /// <summary>
    /// Expiration date as the millisecond timestamp of 12:00 ET on the expiration day. Convert in
    /// America/New_York and take the date part (see General Info).
    /// </summary>
    [JsonPropertyName("expirationDate")]
    public long? ExpirationDate { get; set; }

    /// <summary>Premium multiplier. Order cost = price × quantity × multiplier.</summary>
    [JsonPropertyName("multiplier")]
    public string? Multiplier { get; set; }
}
