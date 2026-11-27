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

namespace Binance.Wallet.RestApi;

public sealed class DustConvertibleAssetsResponseDetailsInner
{
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    [JsonPropertyName("assetFullName")]
    public string? AssetFullName { get; set; }

    [JsonPropertyName("amountFree")]
    public string? AmountFree { get; set; }

    [JsonPropertyName("exchange")]
    public string? Exchange { get; set; }

    [JsonPropertyName("toQuotaAssetAmount")]
    public string? ToQuotaAssetAmount { get; set; }

    [JsonPropertyName("toTargetAssetAmount")]
    public string? ToTargetAssetAmount { get; set; }

    [JsonPropertyName("toTargetAssetOffExchange")]
    public string? ToTargetAssetOffExchange { get; set; }
}
