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

public sealed class OptionSettlementEventDetailResponse
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

    /// <summary>Number of contracts, absolute value (unsigned), unlike the history endpoint.</summary>
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

    /// <summary>Time the settlement record was created (ms).</summary>
    [JsonPropertyName("eventTime")]
    public long? EventTime { get; set; }

    /// <summary>
    /// Settlement method: PHYSICAL (physical delivery) / CASH (cash settlement) / MIXED (both). Not
    /// returned for EXPIRY events.
    /// </summary>
    [JsonPropertyName("settlementKind")]
    public string? SettlementKind { get; set; }

    /// <summary>
    /// Reference price of the underlying when the event was generated, for display only; it is not used in
    /// the settlement calculation. Not returned if unavailable.
    /// </summary>
    [JsonPropertyName("underlyingPrice")]
    public string? UnderlyingPrice { get; set; }

    /// <summary>Cash direction: DEBIT / CREDIT. Not returned for EXPIRY events.</summary>
    [JsonPropertyName("cashDirection")]
    public string? CashDirection { get; set; }

    /// <summary>
    /// Net cash amount (absolute value); see cashDirection for the direction. Not returned for EXPIRY
    /// events.
    /// </summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>
    /// Only for EXPIRY events on short positions (covered call / cash-secured put): collateral released
    /// back to the user, e.g. the cash of a cash-secured put (strike × contracts × multiplier).
    /// </summary>
    [JsonPropertyName("collateralRelease")]
    public List<OptionSettlementEventDetailResponseCollateralReleaseInner>? CollateralRelease { get; set; }

    /// <summary>Last update time (ms).</summary>
    [JsonPropertyName("updatedTime")]
    public long? UpdatedTime { get; set; }
}
