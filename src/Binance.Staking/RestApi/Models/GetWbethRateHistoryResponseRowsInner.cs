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

namespace Binance.Staking.RestApi;

public sealed class GetWbethRateHistoryResponseRowsInner
{
    /// <summary>BETH APR</summary>
    [JsonPropertyName("annualPercentageRate")]
    public string? AnnualPercentageRate { get; set; }

    /// <summary>BETH value per 1 WBETH</summary>
    [JsonPropertyName("exchangeRate")]
    public string? ExchangeRate { get; set; }

    [JsonPropertyName("time")]
    public long? Time { get; set; }
}
