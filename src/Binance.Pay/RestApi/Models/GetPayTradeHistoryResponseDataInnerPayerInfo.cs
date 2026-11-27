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

namespace Binance.Pay.RestApi;

public sealed class GetPayTradeHistoryResponseDataInnerPayerInfo
{
    /// <summary>Nickname or merchant name.</summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>Account type: USER for personal, MERCHANT for merchant.</summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>Binance UID.</summary>
    [JsonPropertyName("binanceId")]
    public string? BinanceId { get; set; }
}
