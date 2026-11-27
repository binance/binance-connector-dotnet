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

namespace Binance.SubAccount.RestApi;

public sealed class MovePositionForSubAccountResponseMovePositionOrdersInner
{
    [JsonPropertyName("fromUserEmail")]
    public string? FromUserEmail { get; set; }

    [JsonPropertyName("toUserEmail")]
    public string? ToUserEmail { get; set; }

    [JsonPropertyName("productType")]
    public string? ProductType { get; set; }

    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("priceType")]
    public string? PriceType { get; set; }

    [JsonPropertyName("price")]
    public string? Price { get; set; }

    [JsonPropertyName("quantity")]
    public string? Quantity { get; set; }

    /// <summary>null when productType=OPTION.</summary>
    [JsonPropertyName("positionSide")]
    public string? PositionSide { get; set; }

    [JsonPropertyName("side")]
    public string? Side { get; set; }

    [JsonPropertyName("success")]
    public bool? Success { get; set; }
}
