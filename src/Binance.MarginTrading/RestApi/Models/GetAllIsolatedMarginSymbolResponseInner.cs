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

public sealed class GetAllIsolatedMarginSymbolResponseInner
{
    /// <summary>base.</summary>
    [JsonPropertyName("base")]
    public string? Base { get; set; }

    /// <summary>is Buy Allowed.</summary>
    [JsonPropertyName("isBuyAllowed")]
    public bool? IsBuyAllowed { get; set; }

    /// <summary>is Margin Trade.</summary>
    [JsonPropertyName("isMarginTrade")]
    public bool? IsMarginTrade { get; set; }

    /// <summary>is Sell Allowed.</summary>
    [JsonPropertyName("isSellAllowed")]
    public bool? IsSellAllowed { get; set; }

    /// <summary>quote.</summary>
    [JsonPropertyName("quote")]
    public string? Quote { get; set; }

    /// <summary>symbol.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }
}
