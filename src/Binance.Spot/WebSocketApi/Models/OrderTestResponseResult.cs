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

public sealed class OrderTestResponseResult
{
    [JsonPropertyName("standardCommissionForOrder")]
    public OrderTestResponseResultStandardCommissionForOrder? StandardCommissionForOrder { get; set; }

    [JsonPropertyName("specialCommissionForOrder")]
    public OrderTestResponseResultSpecialCommissionForOrder? SpecialCommissionForOrder { get; set; }

    [JsonPropertyName("taxCommissionForOrder")]
    public OrderTestResponseResultTaxCommissionForOrder? TaxCommissionForOrder { get; set; }

    [JsonPropertyName("discount")]
    public OrderTestResponseResultDiscount? Discount { get; set; }
}
