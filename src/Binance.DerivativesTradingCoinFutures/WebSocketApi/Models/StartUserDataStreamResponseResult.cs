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

namespace Binance.DerivativesTradingCoinFutures.WebSocketApi;

/// <summary>Indicates that combined is set to true.</summary>
public sealed class StartUserDataStreamResponseResult
{
    /// <summary>Listen key.</summary>
    [JsonPropertyName("listenKey")]
    public string? ListenKey { get; set; }
}
