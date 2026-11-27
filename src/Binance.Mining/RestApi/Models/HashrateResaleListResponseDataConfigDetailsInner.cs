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

public sealed class HashrateResaleListResponseDataConfigDetailsInner
{
    /// <summary>Configuration ID</summary>
    [JsonPropertyName("configId")]
    public long? ConfigId { get; set; }

    /// <summary>Transfer-out sub-account</summary>
    [JsonPropertyName("poolUsername")]
    public string? PoolUsername { get; set; }

    /// <summary>Transfer-in sub-account</summary>
    [JsonPropertyName("toPoolUsername")]
    public string? ToPoolUsername { get; set; }

    /// <summary>Transfer algorithm name</summary>
    [JsonPropertyName("algoName")]
    public string? AlgoName { get; set; }

    /// <summary>Transferred hashrate</summary>
    [JsonPropertyName("hashRate")]
    public long? HashRate { get; set; }

    /// <summary>Start date</summary>
    [JsonPropertyName("startDay")]
    public long? StartDay { get; set; }

    /// <summary>End date</summary>
    [JsonPropertyName("endDay")]
    public long? EndDay { get; set; }

    /// <summary>Status: 0 Processing, 1 Cancelled, 2 Terminated</summary>
    [JsonPropertyName("status")]
    public long? Status { get; set; }

    /// <summary>Type: 0 Hashrate transfer record, 1 Hashrate receive record</summary>
    [JsonPropertyName("type")]
    public long? Type { get; set; }
}
