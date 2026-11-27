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

namespace Binance.MarginTrading.RestApi;

public sealed class QueryPreventedMatchesResponseInner
{
    /// <summary>symbol.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>prevented Match Id.</summary>
    [JsonPropertyName("preventedMatchId")]
    public long? PreventedMatchId { get; set; }

    /// <summary>taker Order Id.</summary>
    [JsonPropertyName("takerOrderId")]
    public long? TakerOrderId { get; set; }

    /// <summary>maker Symbol.</summary>
    [JsonPropertyName("makerSymbol")]
    public string? MakerSymbol { get; set; }

    /// <summary>maker Order Id.</summary>
    [JsonPropertyName("makerOrderId")]
    public long? MakerOrderId { get; set; }

    /// <summary>trade Group Id.</summary>
    [JsonPropertyName("tradeGroupId")]
    public long? TradeGroupId { get; set; }

    /// <summary>self Trade Prevention Mode.</summary>
    [JsonPropertyName("selfTradePreventionMode")]
    public string? SelfTradePreventionMode { get; set; }

    /// <summary>price.</summary>
    [JsonPropertyName("price")]
    public string? Price { get; set; }

    /// <summary>maker Prevented Quantity.</summary>
    [JsonPropertyName("makerPreventedQuantity")]
    public string? MakerPreventedQuantity { get; set; }

    /// <summary>transact Time.</summary>
    [JsonPropertyName("transactTime")]
    public long? TransactTime { get; set; }
}
