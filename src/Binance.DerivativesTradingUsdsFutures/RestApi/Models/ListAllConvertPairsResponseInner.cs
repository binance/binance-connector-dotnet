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

public sealed class ListAllConvertPairsResponseInner
{
    [JsonPropertyName("fromAsset")]
    public string? FromAsset { get; set; }

    [JsonPropertyName("toAsset")]
    public string? ToAsset { get; set; }

    [JsonPropertyName("fromAssetMinAmount")]
    public string? FromAssetMinAmount { get; set; }

    [JsonPropertyName("fromAssetMaxAmount")]
    public string? FromAssetMaxAmount { get; set; }

    [JsonPropertyName("toAssetMinAmount")]
    public string? ToAssetMinAmount { get; set; }

    [JsonPropertyName("toAssetMaxAmount")]
    public string? ToAssetMaxAmount { get; set; }
}
