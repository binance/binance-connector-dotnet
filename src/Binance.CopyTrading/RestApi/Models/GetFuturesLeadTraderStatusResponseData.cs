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

namespace Binance.CopyTrading.RestApi;

public sealed class GetFuturesLeadTraderStatusResponseData
{
    /// <summary>Whether the user is a futures lead trader</summary>
    [JsonPropertyName("isLeadTrader")]
    public bool? IsLeadTrader { get; set; }

    /// <summary>Server timestamp in milliseconds</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }
}
