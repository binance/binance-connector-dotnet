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

namespace Binance.DerivativesTradingOptions.RestApi;

public sealed class GetAutoCancelAllOpenOrdersResponse
{
    /// <summary>underlying</summary>
    [JsonPropertyName("underlying")]
    public string? Underlying { get; set; }

    /// <summary>countdown Time</summary>
    [JsonPropertyName("countdownTime")]
    public long? CountdownTime { get; set; }
}
