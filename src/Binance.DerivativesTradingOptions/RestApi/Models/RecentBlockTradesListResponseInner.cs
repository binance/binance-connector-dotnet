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

public sealed class RecentBlockTradesListResponseInner
{
    /// <summary>id</summary>
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    /// <summary>trade Id</summary>
    [JsonPropertyName("tradeId")]
    public long? TradeId { get; set; }

    /// <summary>symbol</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>price</summary>
    [JsonPropertyName("price")]
    public string? Price { get; set; }

    /// <summary>qty</summary>
    [JsonPropertyName("qty")]
    public string? Qty { get; set; }

    /// <summary>quote Qty</summary>
    [JsonPropertyName("quoteQty")]
    public string? QuoteQty { get; set; }

    /// <summary>side</summary>
    [JsonPropertyName("side")]
    public long? Side { get; set; }

    /// <summary>time</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }
}
