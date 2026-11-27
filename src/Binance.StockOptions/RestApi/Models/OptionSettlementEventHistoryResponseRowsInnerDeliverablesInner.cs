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

public sealed class OptionSettlementEventHistoryResponseRowsInnerDeliverablesInner
{
    /// <summary>
    /// Present on cash legs only: OPEXC (exercise cash) / OPASN (assignment cash) / OPCSH (cash
    /// settlement).
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>Ticker for the share leg, currency for the cash leg.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>
    /// Signed amount: positive = received, negative = paid. Number of shares for the share leg.
    /// </summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }
}
