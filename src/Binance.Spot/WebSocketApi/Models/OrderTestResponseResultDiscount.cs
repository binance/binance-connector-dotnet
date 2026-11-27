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

/// <summary>Discount on standard commissions when paying in BNB.</summary>
public sealed class OrderTestResponseResultDiscount
{
    [JsonPropertyName("enabledForAccount")]
    public bool? EnabledForAccount { get; set; }

    [JsonPropertyName("enabledForSymbol")]
    public bool? EnabledForSymbol { get; set; }

    [JsonPropertyName("discountAsset")]
    public string? DiscountAsset { get; set; }

    /// <summary>Standard commission is reduced by this rate when paying commission in BNB.</summary>
    [JsonPropertyName("discount")]
    public string? Discount { get; set; }
}
