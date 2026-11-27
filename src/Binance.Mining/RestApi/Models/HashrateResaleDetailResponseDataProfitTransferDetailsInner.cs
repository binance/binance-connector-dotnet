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

public sealed class HashrateResaleDetailResponseDataProfitTransferDetailsInner
{
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

    /// <summary>Transfer date</summary>
    [JsonPropertyName("day")]
    public long? Day { get; set; }

    /// <summary>Transferred income</summary>
    [JsonPropertyName("amount")]
    public decimal? Amount { get; set; }

    /// <summary>Income coin</summary>
    [JsonPropertyName("coinName")]
    public string? CoinName { get; set; }
}
