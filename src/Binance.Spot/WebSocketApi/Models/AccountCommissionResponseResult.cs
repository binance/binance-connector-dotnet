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

public sealed class AccountCommissionResponseResult
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("standardCommission")]
    public AccountCommissionResponseResultStandardCommission? StandardCommission { get; set; }

    [JsonPropertyName("specialCommission")]
    public AccountCommissionResponseResultSpecialCommission? SpecialCommission { get; set; }

    [JsonPropertyName("taxCommission")]
    public AccountCommissionResponseResultTaxCommission? TaxCommission { get; set; }

    [JsonPropertyName("discount")]
    public AccountCommissionResponseResultDiscount? Discount { get; set; }
}
