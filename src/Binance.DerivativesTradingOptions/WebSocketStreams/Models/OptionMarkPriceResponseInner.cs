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

namespace Binance.DerivativesTradingOptions.WebSocketStreams;

public sealed class OptionMarkPriceResponseInner
{
    /// <summary>Symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>Mark price</summary>
    [JsonPropertyName("mp")]
    public string? Mp { get; set; }

    /// <summary>Event time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Event type</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>Index price</summary>
    [JsonPropertyName("i")]
    public string? I { get; set; }

    /// <summary>Estimated Settle Price, only useful in the 0.5 hour before the settlement starts</summary>
    [JsonPropertyName("P")]
    public string? PUppercase { get; set; }

    /// <summary>The best buy price</summary>
    [JsonPropertyName("bo")]
    public string? Bo { get; set; }

    /// <summary>The best sell price</summary>
    [JsonPropertyName("ao")]
    public string? Ao { get; set; }

    /// <summary>The best buy quantity</summary>
    [JsonPropertyName("bq")]
    public string? Bq { get; set; }

    /// <summary>The best sell quantity</summary>
    [JsonPropertyName("aq")]
    public string? Aq { get; set; }

    /// <summary>BuyImplied volatility</summary>
    [JsonPropertyName("b")]
    public string? B { get; set; }

    /// <summary>SellImplied volatility</summary>
    [JsonPropertyName("a")]
    public string? A { get; set; }

    /// <summary>Buy Maximum price</summary>
    [JsonPropertyName("hl")]
    public string? Hl { get; set; }

    /// <summary>Sell Minimum price</summary>
    [JsonPropertyName("ll")]
    public string? Ll { get; set; }

    /// <summary>volatility</summary>
    [JsonPropertyName("vo")]
    public string? Vo { get; set; }

    /// <summary>risk free rate</summary>
    [JsonPropertyName("rf")]
    public string? Rf { get; set; }

    /// <summary>delta</summary>
    [JsonPropertyName("d")]
    public string? D { get; set; }

    /// <summary>theta</summary>
    [JsonPropertyName("t")]
    public string? T { get; set; }

    /// <summary>gamma</summary>
    [JsonPropertyName("g")]
    public string? G { get; set; }

    /// <summary>vega</summary>
    [JsonPropertyName("v")]
    public string? V { get; set; }
}
