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

public sealed class CompositeIndexSymbolInformationResponseInner
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Current time</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    /// <summary>Component asset</summary>
    [JsonPropertyName("component")]
    public string? Component { get; set; }

    [JsonPropertyName("baseAssetList")]
    public List<CompositeIndexSymbolInformationResponseInnerBaseAssetListInner>? BaseAssetList { get; set; }
}
