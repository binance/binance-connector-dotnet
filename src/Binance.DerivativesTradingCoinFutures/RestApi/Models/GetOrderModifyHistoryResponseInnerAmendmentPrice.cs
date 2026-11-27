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

/// <summary>Latest token price.</summary>
public sealed class GetOrderModifyHistoryResponseInnerAmendmentPrice
{
    /// <summary>Before value.</summary>
    [JsonPropertyName("before")]
    public string? Before { get; set; }

    /// <summary>After value.</summary>
    [JsonPropertyName("after")]
    public string? After { get; set; }
}
