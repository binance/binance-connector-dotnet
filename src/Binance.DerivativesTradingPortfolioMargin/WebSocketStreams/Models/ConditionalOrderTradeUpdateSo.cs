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

namespace Binance.DerivativesTradingPortfolioMargin.WebSocketStreams;

public sealed class ConditionalOrderTradeUpdateSo
{
    /// <summary>Symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>Strategy Client Order Id</summary>
    [JsonPropertyName("c")]
    public string? C { get; set; }

    /// <summary>Strategy ID</summary>
    [JsonPropertyName("si")]
    public long? Si { get; set; }

    /// <summary>Side</summary>
    [JsonPropertyName("S")]
    public string? SUppercase { get; set; }

    /// <summary>Strategy Type</summary>
    [JsonPropertyName("st")]
    public string? St { get; set; }

    /// <summary>Time in Force</summary>
    [JsonPropertyName("f")]
    public string? F { get; set; }

    /// <summary>Quantity</summary>
    [JsonPropertyName("q")]
    public string? Q { get; set; }

    /// <summary>Price</summary>
    [JsonPropertyName("p")]
    public string? P { get; set; }

    /// <summary>Stop Price. Please ignore with TRAILING_STOP_MARKET order</summary>
    [JsonPropertyName("sp")]
    public string? Sp { get; set; }

    /// <summary>Strategy Order Status</summary>
    [JsonPropertyName("os")]
    public string? Os { get; set; }

    /// <summary>Order book Time</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>Order update Time</summary>
    [JsonPropertyName("ut")]
    public long? Ut { get; set; }

    /// <summary>Is this reduce only</summary>
    [JsonPropertyName("R")]
    public bool? RUppercase { get; set; }

    /// <summary>Stop Price Working Type</summary>
    [JsonPropertyName("wt")]
    public string? Wt { get; set; }

    /// <summary>Position Side</summary>
    [JsonPropertyName("ps")]
    public string? Ps { get; set; }

    /// <summary>If Close-All, pushed with conditional order</summary>
    [JsonPropertyName("cp")]
    public bool? Cp { get; set; }

    /// <summary>Activation Price, only pushed with TRAILING_STOP_MARKET order</summary>
    [JsonPropertyName("AP")]
    public string? APUppercase { get; set; }

    /// <summary>Callback Rate, only pushed with TRAILING_STOP_MARKET order</summary>
    [JsonPropertyName("cr")]
    public string? Cr { get; set; }

    /// <summary>Order Id</summary>
    [JsonPropertyName("i")]
    public long? I { get; set; }

    /// <summary>STP mode</summary>
    [JsonPropertyName("V")]
    public string? VUppercase { get; set; }

    /// <summary>TIF GTD order auto cancel time</summary>
    [JsonPropertyName("gtd")]
    public long? Gtd { get; set; }
}
