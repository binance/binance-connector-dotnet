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

public sealed class OptionSettlementEventHistoryResponseRowsInner
{
    /// <summary>Event ID; use it with Option Settlement Event Detail.</summary>
    [JsonPropertyName("eventId")]
    public string? EventId { get; set; }

    /// <summary>EXERCISE / ASSIGNMENT / EXPIRY.</summary>
    [JsonPropertyName("eventType")]
    public string? EventType { get; set; }

    /// <summary>Event status. Only settled events are returned, so the value is always Completed.</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>OCC option contract symbol.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Underlying US-equity ticker.</summary>
    [JsonPropertyName("underlyingSymbol")]
    public string? UnderlyingSymbol { get; set; }

    /// <summary>CALL / PUT.</summary>
    [JsonPropertyName("contractType")]
    public string? ContractType { get; set; }

    /// <summary>
    /// Number of contracts, signed: positive for long, negative for short. (Option Settlement Event Detail
    /// returns the absolute value.)
    /// </summary>
    [JsonPropertyName("contracts")]
    public string? Contracts { get; set; }

    /// <summary>
    /// Expiration date as the millisecond timestamp of 12:00 ET on the expiration day. Convert in
    /// America/New_York and take the date part (see General Info).
    /// </summary>
    [JsonPropertyName("expirationDate")]
    public long? ExpirationDate { get; set; }

    /// <summary>Strike price.</summary>
    [JsonPropertyName("strikePrice")]
    public string? StrikePrice { get; set; }

    /// <summary>
    /// Net change in underlying shares (signed). Not returned for EXPIRY events, or for events on adjusted
    /// contracts that deliver more than one stock (see deliverables).
    /// </summary>
    [JsonPropertyName("shareDelta")]
    public string? ShareDelta { get; set; }

    /// <summary>Assets actually delivered. Empty array when nothing is delivered.</summary>
    [JsonPropertyName("deliverables")]
    public List<OptionSettlementEventHistoryResponseRowsInnerDeliverablesInner>? Deliverables { get; set; }

    /// <summary>Event time (ms).</summary>
    [JsonPropertyName("eventTime")]
    public long? EventTime { get; set; }
}
