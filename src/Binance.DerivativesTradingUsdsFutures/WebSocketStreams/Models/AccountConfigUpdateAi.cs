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

namespace Binance.DerivativesTradingUsdsFutures.WebSocketStreams;

/// <summary>User's Account Configuration</summary>
public sealed class AccountConfigUpdateAi
{
    /// <summary>Multi-Assets Mode</summary>
    [JsonPropertyName("j")]
    public bool? J { get; set; }
}
