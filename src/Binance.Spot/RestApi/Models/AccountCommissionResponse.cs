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

public sealed class AccountCommissionResponse
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("standardCommission")]
    public AccountCommissionResponseStandardCommission? StandardCommission { get; set; }

    [JsonPropertyName("specialCommission")]
    public AccountCommissionResponseSpecialCommission? SpecialCommission { get; set; }

    [JsonPropertyName("taxCommission")]
    public AccountCommissionResponseTaxCommission? TaxCommission { get; set; }

    [JsonPropertyName("discount")]
    public AccountCommissionResponseDiscount? Discount { get; set; }
}
