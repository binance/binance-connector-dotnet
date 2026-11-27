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

namespace Binance.Spot.WebSocketApi;

public sealed class SorOrderPlaceResponseResultInnerFillsInner
{
    [JsonPropertyName("matchType")]
    public string? MatchType { get; set; }

    [JsonPropertyName("price")]
    public string? Price { get; set; }

    [JsonPropertyName("qty")]
    public string? Qty { get; set; }

    [JsonPropertyName("commission")]
    public string? Commission { get; set; }

    [JsonPropertyName("commissionAsset")]
    public string? CommissionAsset { get; set; }

    [JsonPropertyName("tradeId")]
    public long? TradeId { get; set; }

    [JsonPropertyName("allocId")]
    public long? AllocId { get; set; }
}
