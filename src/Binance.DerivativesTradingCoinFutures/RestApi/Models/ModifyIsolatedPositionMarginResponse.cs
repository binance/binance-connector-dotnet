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

namespace Binance.DerivativesTradingCoinFutures.RestApi;

public sealed class ModifyIsolatedPositionMarginResponse
{
    /// <summary>Amount.</summary>
    [JsonPropertyName("amount")]
    public decimal? Amount { get; set; }

    /// <summary>API response code. "000000" indicates success.</summary>
    [JsonPropertyName("code")]
    public long? Code { get; set; }

    /// <summary>Message details.</summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    /// <summary>Order type.</summary>
    [JsonPropertyName("type")]
    public long? Type { get; set; }
}
