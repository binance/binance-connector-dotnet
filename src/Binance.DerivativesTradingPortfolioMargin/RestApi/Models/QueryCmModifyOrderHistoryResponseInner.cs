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

namespace Binance.DerivativesTradingPortfolioMargin.RestApi;

public sealed class QueryCmModifyOrderHistoryResponseInner
{
    /// <summary>Order modification ID</summary>
    [JsonPropertyName("amendmentId")]
    public long? AmendmentId { get; set; }

    /// <summary>Trade symbol, if existing.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Pair.</summary>
    [JsonPropertyName("pair")]
    public string? Pair { get; set; }

    /// <summary>
    /// Normal orderID after trigger if appliable, only have when the strategy is triggered
    /// </summary>
    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    /// <summary>Client Order ID.</summary>
    [JsonPropertyName("clientOrderId")]
    public string? ClientOrderId { get; set; }

    /// <summary>Order modification time</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    [JsonPropertyName("amendment")]
    public QueryCmModifyOrderHistoryResponseInnerAmendment? Amendment { get; set; }
}
