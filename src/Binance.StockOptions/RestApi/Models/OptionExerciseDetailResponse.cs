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

public sealed class OptionExerciseDetailResponse
{
    /// <summary>Exercise transaction ID.</summary>
    [JsonPropertyName("tranId")]
    public long? TranId { get; set; }

    /// <summary>Client ID.</summary>
    [JsonPropertyName("clientOrderId")]
    public string? ClientOrderId { get; set; }

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

    /// <summary>Strike price.</summary>
    [JsonPropertyName("strikePrice")]
    public string? StrikePrice { get; set; }

    /// <summary>
    /// Expiration date as the millisecond timestamp of 12:00 ET on the expiration day. Convert in
    /// America/New_York and take the date part (see General Info).
    /// </summary>
    [JsonPropertyName("expirationDate")]
    public long? ExpirationDate { get; set; }

    /// <summary>Requested number of contracts.</summary>
    [JsonPropertyName("requestedQty")]
    public string? RequestedQty { get; set; }

    /// <summary>PROCESSING / SUCCESS / FAILED.</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>Submission time (ms).</summary>
    [JsonPropertyName("requestedTime")]
    public long? RequestedTime { get; set; }

    /// <summary>Last update time (ms).</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }

    /// <summary>
    /// Settlement event ID of the option leg; can be used with Option Settlement Event Detail.
    /// </summary>
    [JsonPropertyName("optionEventId")]
    public string? OptionEventId { get; set; }

    /// <summary>Settlement event ID of the underlying-share leg.</summary>
    [JsonPropertyName("underlyingEventId")]
    public string? UnderlyingEventId { get; set; }

    /// <summary>Premium multiplier. Order cost = price × quantity × multiplier.</summary>
    [JsonPropertyName("multiplier")]
    public string? Multiplier { get; set; }

    /// <summary>
    /// Error code on failure; one of the option business error codes in Error Code. Returned only when
    /// status is FAILED.
    /// </summary>
    [JsonPropertyName("errorCode")]
    public string? ErrorCode { get; set; }
}
