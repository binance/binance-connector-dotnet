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

namespace Binance.W3WPrediction.RestApi;

public sealed class QueryPaymentOptionBalancesResponseItemsInner
{
    [JsonPropertyName("accountType")]
    public string? AccountType { get; set; }

    [JsonPropertyName("availableBalanceDisplay")]
    public string? AvailableBalanceDisplay { get; set; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }
}
