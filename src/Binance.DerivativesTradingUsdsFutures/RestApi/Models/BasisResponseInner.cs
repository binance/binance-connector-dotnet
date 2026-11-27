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

namespace Binance.DerivativesTradingUsdsFutures.RestApi;

public sealed class BasisResponseInner
{
    [JsonPropertyName("indexPrice")]
    public string? IndexPrice { get; set; }

    [JsonPropertyName("contractType")]
    public string? ContractType { get; set; }

    [JsonPropertyName("basisRate")]
    public string? BasisRate { get; set; }

    [JsonPropertyName("futuresPrice")]
    public string? FuturesPrice { get; set; }

    [JsonPropertyName("annualizedBasisRate")]
    public string? AnnualizedBasisRate { get; set; }

    [JsonPropertyName("basis")]
    public string? Basis { get; set; }

    [JsonPropertyName("pair")]
    public string? Pair { get; set; }

    /// <summary>Start time of the period, in milliseconds.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; set; }
}
