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

public sealed class CancelAllAlgoOpenOrdersResponse
{
    [JsonPropertyName("code")]
    public long? Code { get; set; }

    [JsonPropertyName("msg")]
    public string? Msg { get; set; }
}
