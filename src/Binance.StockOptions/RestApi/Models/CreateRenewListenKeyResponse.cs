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

public sealed class CreateRenewListenKeyResponse
{
    /// <summary>User data stream session identifier.</summary>
    [JsonPropertyName("listenKey")]
    public string? ListenKey { get; set; }
}
