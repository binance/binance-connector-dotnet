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

public sealed class GetAssetsThatCanBeConvertedIntoBnbResponseDetailsInner
{
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    [JsonPropertyName("assetFullName")]
    public string? AssetFullName { get; set; }

    /// <summary>Convertible amount</summary>
    [JsonPropertyName("amountFree")]
    public string? AmountFree { get; set; }

    /// <summary>BTC amount</summary>
    [JsonPropertyName("toBTC")]
    public string? ToBTC { get; set; }

    /// <summary>BNB amount（Not deducted commission fee）</summary>
    [JsonPropertyName("toBNB")]
    public string? ToBNB { get; set; }

    /// <summary>BNB amount（Deducted commission fee）</summary>
    [JsonPropertyName("toBNBOffExchange")]
    public string? ToBNBOffExchange { get; set; }

    /// <summary>Commission fee</summary>
    [JsonPropertyName("exchange")]
    public string? Exchange { get; set; }
}
