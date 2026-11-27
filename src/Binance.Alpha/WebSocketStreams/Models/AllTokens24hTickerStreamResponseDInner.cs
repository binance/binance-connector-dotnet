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

namespace Binance.Alpha.WebSocketStreams;

public sealed class AllTokens24hTickerStreamResponseDInner
{
    /// <summary>Contract address@chain ID</summary>
    [JsonPropertyName("ca")]
    public string? Ca { get; set; }

    /// <summary>Number of trades in the last 24 hours</summary>
    [JsonPropertyName("cnt24")]
    public long? Cnt24 { get; set; }

    /// <summary>Fully diluted valuation</summary>
    [JsonPropertyName("fdv")]
    public string? Fdv { get; set; }

    /// <summary>Number of holders</summary>
    [JsonPropertyName("hc")]
    public string? Hc { get; set; }

    /// <summary>Liquidity</summary>
    [JsonPropertyName("liq")]
    public string? Liq { get; set; }

    /// <summary>Market cap</summary>
    [JsonPropertyName("mc")]
    public string? Mc { get; set; }

    /// <summary>Current price</summary>
    [JsonPropertyName("p")]
    public string? P { get; set; }

    /// <summary>24-hour price change percent</summary>
    [JsonPropertyName("pc24")]
    public string? Pc24 { get; set; }

    /// <summary>Token short identifier</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>Event timestamp in milliseconds</summary>
    [JsonPropertyName("t")]
    public long? T { get; set; }

    /// <summary>24-hour volume</summary>
    [JsonPropertyName("vol24")]
    public string? Vol24 { get; set; }
}
