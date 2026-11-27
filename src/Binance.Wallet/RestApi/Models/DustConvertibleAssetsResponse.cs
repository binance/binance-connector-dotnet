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

public sealed class DustConvertibleAssetsResponse
{
    [JsonPropertyName("dribbletPercentage")]
    public string? DribbletPercentage { get; set; }

    [JsonPropertyName("totalTransferQuotaAssetAmount")]
    public string? TotalTransferQuotaAssetAmount { get; set; }

    [JsonPropertyName("totalTransferTargetAssetAmount")]
    public string? TotalTransferTargetAssetAmount { get; set; }

    [JsonPropertyName("dribbletBase")]
    public string? DribbletBase { get; set; }

    [JsonPropertyName("details")]
    public List<DustConvertibleAssetsResponseDetailsInner>? Details { get; set; }
}
