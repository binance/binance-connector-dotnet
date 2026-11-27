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

namespace Binance.StockOptions.RestApi;

public sealed class CancelAllOptionOrdersResponse
{
    /// <summary>
    /// true if the cancel-all request was accepted upstream. Individual orders may still fail to cancel
    /// (e.g. already filled); check with Current Open Option Orders.
    /// </summary>
    [JsonPropertyName("success")]
    public bool? Success { get; set; }
}
