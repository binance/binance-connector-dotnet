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

namespace Binance.Stocks.RestApi;

public sealed class CancelAllEquityOrdersResponse
{
    /// <summary>
    /// true when the cancel-all request was accepted by upstream. Per-order outcomes live in
    /// /order/history.
    /// </summary>
    [JsonPropertyName("success")]
    public bool? Success { get; set; }
}
