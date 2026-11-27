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

namespace Binance.Spot.RestApi;

/// <summary>Discount commission when paying in BNB</summary>
public sealed class AccountCommissionResponseDiscount
{
    [JsonPropertyName("enabledForAccount")]
    public bool? EnabledForAccount { get; set; }

    [JsonPropertyName("enabledForSymbol")]
    public bool? EnabledForSymbol { get; set; }

    [JsonPropertyName("discountAsset")]
    public string? DiscountAsset { get; set; }

    /// <summary>
    /// Multiplier applied to the standard commission when paying commission in BNB (e.g. 0.75 = 75% of the
    /// standard commission is charged).
    /// </summary>
    [JsonPropertyName("discount")]
    public string? Discount { get; set; }
}
