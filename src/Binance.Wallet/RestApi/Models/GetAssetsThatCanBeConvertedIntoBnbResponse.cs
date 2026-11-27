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

public sealed class GetAssetsThatCanBeConvertedIntoBnbResponse
{
    [JsonPropertyName("details")]
    public List<GetAssetsThatCanBeConvertedIntoBnbResponseDetailsInner>? Details { get; set; }

    [JsonPropertyName("totalTransferBtc")]
    public string? TotalTransferBtc { get; set; }

    [JsonPropertyName("totalTransferBNB")]
    public string? TotalTransferBNB { get; set; }

    /// <summary>Commission fee</summary>
    [JsonPropertyName("dribbletPercentage")]
    public string? DribbletPercentage { get; set; }
}
