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

public sealed class StatisticListResponseData
{
    /// <summary>15-minute hashrate</summary>
    [JsonPropertyName("fifteenMinHashRate")]
    public string? FifteenMinHashRate { get; set; }

    /// <summary>24H hashrate</summary>
    [JsonPropertyName("dayHashRate")]
    public string? DayHashRate { get; set; }

    /// <summary>Effective quantity</summary>
    [JsonPropertyName("validNum")]
    public long? ValidNum { get; set; }

    /// <summary>Invalid quantity</summary>
    [JsonPropertyName("invalidNum")]
    public long? InvalidNum { get; set; }

    /// <summary>
    /// Today's estimate. Keys are coin symbols (e.g. BTC, BSV, BCH), values are earning amounts as strings.
    /// </summary>
    [JsonPropertyName("profitToday")]
    public Dictionary<string, string>? ProfitToday { get; set; }

    /// <summary>
    /// Yesterday's earnings. Keys are coin symbols (e.g. BTC, BSV, BCH), values are earning amounts as
    /// strings.
    /// </summary>
    [JsonPropertyName("profitYesterday")]
    public Dictionary<string, string>? ProfitYesterday { get; set; }

    /// <summary>Mining account</summary>
    [JsonPropertyName("userName")]
    public string? UserName { get; set; }

    /// <summary>Unit</summary>
    [JsonPropertyName("unit")]
    public string? Unit { get; set; }

    /// <summary>Algorithm</summary>
    [JsonPropertyName("algo")]
    public string? Algo { get; set; }
}
