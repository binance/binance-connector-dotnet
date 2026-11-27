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

namespace Binance.DerivativesTradingCoinFutures.RestApi;

public sealed class BasisResponseInner
{
    /// <summary>index price</summary>
    [JsonPropertyName("indexPrice")]
    public string? IndexPrice { get; set; }

    /// <summary>Contract type.</summary>
    [JsonPropertyName("contractType")]
    public string? ContractType { get; set; }

    /// <summary>Basis rate.</summary>
    [JsonPropertyName("basisRate")]
    public string? BasisRate { get; set; }

    /// <summary>Futures price.</summary>
    [JsonPropertyName("futuresPrice")]
    public string? FuturesPrice { get; set; }

    /// <summary>Annualized basis rate.</summary>
    [JsonPropertyName("annualizedBasisRate")]
    public string? AnnualizedBasisRate { get; set; }

    /// <summary>Basis value.</summary>
    [JsonPropertyName("basis")]
    public string? Basis { get; set; }

    /// <summary>Pair</summary>
    [JsonPropertyName("pair")]
    public string? Pair { get; set; }

    /// <summary>Start time of the period, in milliseconds.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; set; }
}
