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

public sealed class OptionTradeHistoryResponseRowsInner
{
    /// <summary>Execution ID.</summary>
    [JsonPropertyName("executionId")]
    public string? ExecutionId { get; set; }

    /// <summary>Option order ID.</summary>
    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

    /// <summary>Client order ID.</summary>
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

    /// <summary>Premium multiplier. Order cost = price × quantity × multiplier.</summary>
    [JsonPropertyName("multiplier")]
    public string? Multiplier { get; set; }

    /// <summary>Position intent: BUY_TO_OPEN / SELL_TO_CLOSE / SELL_TO_OPEN / BUY_TO_CLOSE.</summary>
    [JsonPropertyName("positionIntent")]
    public string? PositionIntent { get; set; }

    /// <summary>
    /// true if the order was initiated by the broker's automatic liquidation rather than by the user.
    /// </summary>
    [JsonPropertyName("autoLiquidation")]
    public bool? AutoLiquidation { get; set; }

    /// <summary>Quote asset.</summary>
    [JsonPropertyName("quote")]
    public string? Quote { get; set; }

    /// <summary>BUY / SELL.</summary>
    [JsonPropertyName("side")]
    public string? Side { get; set; }

    /// <summary>
    /// Order type: LIMIT; MARKET for orders placed by the broker's automatic liquidation on the expiration
    /// date.
    /// </summary>
    [JsonPropertyName("orderType")]
    public string? OrderType { get; set; }

    /// <summary>Fill price (premium per share).</summary>
    [JsonPropertyName("price")]
    public string? Price { get; set; }

    /// <summary>Fill quantity (contracts).</summary>
    [JsonPropertyName("qty")]
    public string? Qty { get; set; }

    /// <summary>Fill amount (price × qty × multiplier), excluding fees.</summary>
    [JsonPropertyName("total")]
    public string? Total { get; set; }

    /// <summary>Execution time (ms).</summary>
    [JsonPropertyName("executionAt")]
    public long? ExecutionAt { get; set; }

    /// <summary>Update time (ms).</summary>
    [JsonPropertyName("updatedAt")]
    public long? UpdatedAt { get; set; }

    /// <summary>
    /// Millisecond timestamp of 14:00 ET on the settlement date. Returned for sell fills only.
    /// </summary>
    [JsonPropertyName("settlementDate")]
    public long? SettlementDate { get; set; }
}
