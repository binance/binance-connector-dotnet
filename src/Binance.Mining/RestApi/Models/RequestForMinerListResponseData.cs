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

public sealed class RequestForMinerListResponseData
{
    [JsonPropertyName("workerDatas")]
    public List<RequestForMinerListResponseDataWorkerDatasInner>? WorkerDatas { get; set; }

    /// <summary>Total amount</summary>
    [JsonPropertyName("totalNum")]
    public long? TotalNum { get; set; }

    /// <summary>Rows per page</summary>
    [JsonPropertyName("pageSize")]
    public long? PageSize { get; set; }
}
