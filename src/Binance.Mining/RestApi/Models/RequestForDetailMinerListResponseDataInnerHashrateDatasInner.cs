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

namespace Binance.Mining.RestApi;

public sealed class RequestForDetailMinerListResponseDataInnerHashrateDatasInner
{
    /// <summary>Time</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    /// <summary>Hashrate</summary>
    [JsonPropertyName("hashrate")]
    public string? Hashrate { get; set; }

    /// <summary>Rejection rate</summary>
    [JsonPropertyName("reject")]
    public long? Reject { get; set; }
}
