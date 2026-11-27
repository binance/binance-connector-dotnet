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

/// <summary>assets information</summary>
public sealed class ExchangeInformationResponseAssetsInner
{
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>whether the asset can be used as margin in Multi-Assets mode</summary>
    [JsonPropertyName("marginAvailable")]
    public bool? MarginAvailable { get; set; }

    /// <summary>auto-exchange threshold in Multi-Assets margin mode</summary>
    [JsonPropertyName("autoAssetExchange")]
    public string? AutoAssetExchange { get; set; }
}
