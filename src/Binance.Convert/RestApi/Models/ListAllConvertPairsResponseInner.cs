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

namespace Binance.Convert.RestApi;

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

    /// <summary>9E+24 signals that this symbol has a very large upper limit close to infinity</summary>
    [JsonPropertyName("toAssetMaxAmount")]
    public string? ToAssetMaxAmount { get; set; }
}
