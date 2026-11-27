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

public sealed class GetCmIncomeHistoryResponseInner
{
    /// <summary>Trade symbol, if existing.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Income type.</summary>
    [JsonPropertyName("incomeType")]
    public string? IncomeType { get; set; }

    /// <summary>Income amount.</summary>
    [JsonPropertyName("income")]
    public string? Income { get; set; }

    /// <summary>Income asset.</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>Extra information.</summary>
    [JsonPropertyName("info")]
    public string? Info { get; set; }

    /// <summary>Event time.</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    /// <summary>Transaction ID.</summary>
    [JsonPropertyName("tranId")]
    public string? TranId { get; set; }

    /// <summary>Trade ID, if existing.</summary>
    [JsonPropertyName("tradeId")]
    public string? TradeId { get; set; }
}
