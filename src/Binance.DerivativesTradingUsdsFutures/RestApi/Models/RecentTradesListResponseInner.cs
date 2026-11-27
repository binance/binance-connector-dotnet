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

public sealed class RecentTradesListResponseInner
{
    /// <summary>Id.</summary>
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    /// <summary>Price.</summary>
    [JsonPropertyName("price")]
    public string? Price { get; set; }

    /// <summary>Qty.</summary>
    [JsonPropertyName("qty")]
    public string? Qty { get; set; }

    /// <summary>Quote Qty.</summary>
    [JsonPropertyName("quoteQty")]
    public string? QuoteQty { get; set; }

    /// <summary>Time.</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    /// <summary>Is Buyer Maker.</summary>
    [JsonPropertyName("isBuyerMaker")]
    public bool? IsBuyerMaker { get; set; }

    /// <summary>Is RPITrade.</summary>
    [JsonPropertyName("isRPITrade")]
    public bool? IsRPITrade { get; set; }
}
