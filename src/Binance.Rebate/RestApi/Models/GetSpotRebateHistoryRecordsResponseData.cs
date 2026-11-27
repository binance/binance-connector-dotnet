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

namespace Binance.Rebate.RestApi;

public sealed class GetSpotRebateHistoryRecordsResponseData
{
    /// <summary>Current page number.</summary>
    [JsonPropertyName("page")]
    public long? Page { get; set; }

    /// <summary>Total number of records.</summary>
    [JsonPropertyName("totalRecords")]
    public long? TotalRecords { get; set; }

    /// <summary>Total number of pages.</summary>
    [JsonPropertyName("totalPageNum")]
    public long? TotalPageNum { get; set; }

    /// <summary>Rebate records.</summary>
    [JsonPropertyName("data")]
    public List<GetSpotRebateHistoryRecordsResponseDataDataInner>? Data { get; set; }
}
