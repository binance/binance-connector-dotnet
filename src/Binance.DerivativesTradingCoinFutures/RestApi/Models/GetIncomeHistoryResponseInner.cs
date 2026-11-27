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

namespace Binance.DerivativesTradingCoinFutures.RestApi;

public sealed class GetIncomeHistoryResponseInner
{
    /// <summary>Trading symbol</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>income type</summary>
    [JsonPropertyName("incomeType")]
    public string? IncomeType { get; set; }

    /// <summary>income amount</summary>
    [JsonPropertyName("income")]
    public string? Income { get; set; }

    /// <summary>asset name</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>extra information</summary>
    [JsonPropertyName("info")]
    public string? Info { get; set; }

    /// <summary>Time</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    /// <summary>transaction id</summary>
    [JsonPropertyName("tranId")]
    public string? TranId { get; set; }

    /// <summary>Trade ID.</summary>
    [JsonPropertyName("tradeId")]
    public string? TradeId { get; set; }
}
