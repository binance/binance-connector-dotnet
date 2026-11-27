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

namespace Binance.MarginTrading.RestApi;

public sealed class QueryIsolatedMarginTierDataResponseInner
{
    /// <summary>symbol.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>tier.</summary>
    [JsonPropertyName("tier")]
    public long? Tier { get; set; }

    /// <summary>effective Multiple.</summary>
    [JsonPropertyName("effectiveMultiple")]
    public string? EffectiveMultiple { get; set; }

    /// <summary>initial Risk Ratio.</summary>
    [JsonPropertyName("initialRiskRatio")]
    public string? InitialRiskRatio { get; set; }

    /// <summary>liquidation Risk Ratio.</summary>
    [JsonPropertyName("liquidationRiskRatio")]
    public string? LiquidationRiskRatio { get; set; }

    /// <summary>base Asset Max Borrowable.</summary>
    [JsonPropertyName("baseAssetMaxBorrowable")]
    public string? BaseAssetMaxBorrowable { get; set; }

    /// <summary>quote Asset Max Borrowable.</summary>
    [JsonPropertyName("quoteAssetMaxBorrowable")]
    public string? QuoteAssetMaxBorrowable { get; set; }
}
