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

public sealed class OrderTestResponse
{
    [JsonPropertyName("standardCommissionForOrder")]
    public OrderTestResponseStandardCommissionForOrder? StandardCommissionForOrder { get; set; }

    [JsonPropertyName("specialCommissionForOrder")]
    public OrderTestResponseSpecialCommissionForOrder? SpecialCommissionForOrder { get; set; }

    [JsonPropertyName("taxCommissionForOrder")]
    public OrderTestResponseTaxCommissionForOrder? TaxCommissionForOrder { get; set; }

    [JsonPropertyName("discount")]
    public OrderTestResponseDiscount? Discount { get; set; }
}
