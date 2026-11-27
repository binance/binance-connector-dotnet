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

public sealed class OptionExchangeInfoResponseSymbolsInner
{
    /// <summary>OCC option contract symbol.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Underlying US-equity ticker.</summary>
    [JsonPropertyName("underlyingSymbol")]
    public string? UnderlyingSymbol { get; set; }

    /// <summary>
    /// OCC root symbol. Differs from underlyingSymbol for contracts adjusted by a corporate action (e.g.
    /// GOOG1).
    /// </summary>
    [JsonPropertyName("rootSymbol")]
    public string? RootSymbol { get; set; }

    /// <summary>CALL / PUT.</summary>
    [JsonPropertyName("contractType")]
    public string? ContractType { get; set; }

    /// <summary>
    /// Contract trading status: OPEN_CLOSE / CLOSE_ONLY / NONE. Omitted when the status of a contract is
    /// temporarily unavailable. See Common Definition.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>Strike price.</summary>
    [JsonPropertyName("strikePrice")]
    public string? StrikePrice { get; set; }

    /// <summary>
    /// Expiration date as the millisecond timestamp of 12:00 ET on the expiration day. Convert in
    /// America/New_York and take the date part (see General Info).
    /// </summary>
    [JsonPropertyName("expirationDate")]
    public long? ExpirationDate { get; set; }

    /// <summary>
    /// Premium multiplier. Order cost = price × quantity × multiplier. 100 for standard contracts.
    /// </summary>
    [JsonPropertyName("multiplier")]
    public string? Multiplier { get; set; }

    /// <summary>
    /// Shares delivered per contract. Equals multiplier for standard contracts; may differ after a
    /// corporate action.
    /// </summary>
    [JsonPropertyName("contractSize")]
    public long? ContractSize { get; set; }

    /// <summary>Minimum price increment.</summary>
    [JsonPropertyName("tickSize")]
    public string? TickSize { get; set; }

    /// <summary>Quantity increment (contracts).</summary>
    [JsonPropertyName("stepSize")]
    public string? StepSize { get; set; }

    /// <summary>Minimum order quantity (contracts).</summary>
    [JsonPropertyName("minQty")]
    public string? MinQty { get; set; }

    /// <summary>Maximum order quantity (contracts).</summary>
    [JsonPropertyName("maxQty")]
    public string? MaxQty { get; set; }

    /// <summary>Minimum order notional (price × quantity × multiplier), excluding fees.</summary>
    [JsonPropertyName("minNotional")]
    public string? MinNotional { get; set; }

    /// <summary>Maximum order notional (price × quantity × multiplier), excluding fees.</summary>
    [JsonPropertyName("maxNotional")]
    public string? MaxNotional { get; set; }

    /// <summary>
    /// Whether options on this underlying close 15 minutes later: true means 16:15 ET, otherwise 16:00 ET
    /// (both move earlier accordingly on early-close days).
    /// </summary>
    [JsonPropertyName("optionsLateClose")]
    public bool? OptionsLateClose { get; set; }

    /// <summary>Penny Program indicator. Omitted when unknown.</summary>
    [JsonPropertyName("pennyProgram")]
    public bool? PennyProgram { get; set; }

    /// <summary>What one contract delivers on exercise / assignment.</summary>
    [JsonPropertyName("deliverables")]
    public List<OptionExchangeInfoResponseSymbolsInnerDeliverablesInner>? Deliverables { get; set; }
}
