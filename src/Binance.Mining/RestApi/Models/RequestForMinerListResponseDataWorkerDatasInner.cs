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

public sealed class RequestForMinerListResponseDataWorkerDatasInner
{
    /// <summary>Miner ID</summary>
    [JsonPropertyName("workerId")]
    public string? WorkerId { get; set; }

    /// <summary>Miner name</summary>
    [JsonPropertyName("workerName")]
    public string? WorkerName { get; set; }

    /// <summary>Status: 1 Valid, 2 Invalid, 3 No longer valid</summary>
    [JsonPropertyName("status")]
    public long? Status { get; set; }

    /// <summary>Real-time rate</summary>
    [JsonPropertyName("hashRate")]
    public long? HashRate { get; set; }

    /// <summary>24H hashrate</summary>
    [JsonPropertyName("dayHashRate")]
    public decimal? DayHashRate { get; set; }

    /// <summary>Real-time rejection rate</summary>
    [JsonPropertyName("rejectRate")]
    public long? RejectRate { get; set; }

    /// <summary>Last share time</summary>
    [JsonPropertyName("lastShareTime")]
    public long? LastShareTime { get; set; }
}
