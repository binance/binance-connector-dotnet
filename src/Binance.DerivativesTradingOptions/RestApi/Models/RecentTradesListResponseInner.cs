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

namespace Binance.DerivativesTradingOptions.RestApi;

public sealed class RecentTradesListResponseInner
{
    /// <summary>id</summary>
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    /// <summary>TradeId</summary>
    [JsonPropertyName("tradeId")]
    public long? TradeId { get; set; }

    /// <summary>Option trading pair</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Completed trade price</summary>
    [JsonPropertyName("price")]
    public string? Price { get; set; }

    /// <summary>Completed trade quantity</summary>
    [JsonPropertyName("qty")]
    public string? Qty { get; set; }

    /// <summary>Completed trade amount</summary>
    [JsonPropertyName("quoteQty")]
    public string? QuoteQty { get; set; }

    /// <summary>Completed trade direction（-1 Sell，1 Buy）</summary>
    [JsonPropertyName("side")]
    public long? Side { get; set; }

    /// <summary>Time</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }
}
