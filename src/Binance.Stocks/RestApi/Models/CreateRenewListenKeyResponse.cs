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

public sealed class CreateRenewListenKeyResponse
{
    /// <summary>Session identifier for the stock user data stream.</summary>
    [JsonPropertyName("listenKey")]
    public string? ListenKey { get; set; }
}
