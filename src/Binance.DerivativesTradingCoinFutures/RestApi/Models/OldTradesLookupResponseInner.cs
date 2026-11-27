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

public sealed class OldTradesLookupResponseInner
{
    /// <summary>positionId</summary>
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    /// <summary>Latest token price.</summary>
    [JsonPropertyName("price")]
    public string? Price { get; set; }

    /// <summary>Quantity.</summary>
    [JsonPropertyName("qty")]
    public string? Qty { get; set; }

    /// <summary>Base asset quantity.</summary>
    [JsonPropertyName("baseQty")]
    public string? BaseQty { get; set; }

    /// <summary>Time</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    /// <summary>Whether buyer is market maker.</summary>
    [JsonPropertyName("isBuyerMaker")]
    public bool? IsBuyerMaker { get; set; }
}
