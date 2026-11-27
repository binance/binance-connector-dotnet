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

public sealed class OptionContractsResponseInner
{
    /// <summary>OCC contract symbol; usable for order placement and Option Exchange Info.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>CALL / PUT.</summary>
    [JsonPropertyName("contractType")]
    public string? ContractType { get; set; }

    /// <summary>Strike price.</summary>
    [JsonPropertyName("strikePrice")]
    public string? StrikePrice { get; set; }

    /// <summary>Premium multiplier. Order cost = price × quantity × multiplier.</summary>
    [JsonPropertyName("multiplier")]
    public string? Multiplier { get; set; }

    /// <summary>
    /// Shares delivered per contract. Equals multiplier for standard contracts; may differ after a
    /// corporate action.
    /// </summary>
    [JsonPropertyName("contractSize")]
    public long? ContractSize { get; set; }

    /// <summary>Expiration date in YYYY-MM-DD, US Eastern (ET) calendar day.</summary>
    [JsonPropertyName("expirationDate")]
    public string? ExpirationDate { get; set; }

    /// <summary>
    /// Contract trading status: OPEN_CLOSE / CLOSE_ONLY / NONE. Omitted when the status of a contract is
    /// temporarily unavailable. See Common Definition.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
