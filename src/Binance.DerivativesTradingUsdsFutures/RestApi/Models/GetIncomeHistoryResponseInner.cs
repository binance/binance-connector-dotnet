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

namespace Binance.DerivativesTradingUsdsFutures.RestApi;

public sealed class GetIncomeHistoryResponseInner
{
    /// <summary>trade symbol, if existing</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>income type</summary>
    [JsonPropertyName("incomeType")]
    public string? IncomeType { get; set; }

    /// <summary>income amount</summary>
    [JsonPropertyName("income")]
    public string? Income { get; set; }

    /// <summary>income asset</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>extra information</summary>
    [JsonPropertyName("info")]
    public string? Info { get; set; }

    /// <summary>Time.</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    /// <summary>transaction id</summary>
    [JsonPropertyName("tranId")]
    public long? TranId { get; set; }

    /// <summary>trade id, if existing</summary>
    [JsonPropertyName("tradeId")]
    public string? TradeId { get; set; }
}
