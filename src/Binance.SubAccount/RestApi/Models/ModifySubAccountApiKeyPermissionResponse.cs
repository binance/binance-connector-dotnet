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

public sealed class ModifySubAccountApiKeyPermissionResponse
{
    [JsonPropertyName("apiName")]
    public string? ApiName { get; set; }

    [JsonPropertyName("apikey")]
    public string? Apikey { get; set; }

    [JsonPropertyName("canTrade")]
    public bool? CanTrade { get; set; }

    [JsonPropertyName("canMarginLoanRepay")]
    public bool? CanMarginLoanRepay { get; set; }

    [JsonPropertyName("canFuturesTrade")]
    public bool? CanFuturesTrade { get; set; }

    [JsonPropertyName("canUniversalTransfer")]
    public bool? CanUniversalTransfer { get; set; }

    [JsonPropertyName("canVanillaOptions")]
    public bool? CanVanillaOptions { get; set; }

    [JsonPropertyName("canFixApiTrading")]
    public bool? CanFixApiTrading { get; set; }

    [JsonPropertyName("canFixApiReading")]
    public bool? CanFixApiReading { get; set; }

    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; set; }
}
