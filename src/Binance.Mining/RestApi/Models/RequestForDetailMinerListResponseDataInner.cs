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

public sealed class RequestForDetailMinerListResponseDataInner
{
    /// <summary>Mining account name</summary>
    [JsonPropertyName("workerName")]
    public string? WorkerName { get; set; }

    /// <summary>Type of hashrate bucket</summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("hashrateDatas")]
    public List<RequestForDetailMinerListResponseDataInnerHashrateDatasInner>? HashrateDatas { get; set; }
}
