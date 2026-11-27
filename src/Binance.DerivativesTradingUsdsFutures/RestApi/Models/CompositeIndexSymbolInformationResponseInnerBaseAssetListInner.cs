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

public sealed class CompositeIndexSymbolInformationResponseInnerBaseAssetListInner
{
    /// <summary>Base Asset.</summary>
    [JsonPropertyName("baseAsset")]
    public string? BaseAsset { get; set; }

    /// <summary>Quote Asset.</summary>
    [JsonPropertyName("quoteAsset")]
    public string? QuoteAsset { get; set; }

    /// <summary>Weight In Quantity.</summary>
    [JsonPropertyName("weightInQuantity")]
    public string? WeightInQuantity { get; set; }

    /// <summary>Weight In Percentage.</summary>
    [JsonPropertyName("weightInPercentage")]
    public string? WeightInPercentage { get; set; }
}
