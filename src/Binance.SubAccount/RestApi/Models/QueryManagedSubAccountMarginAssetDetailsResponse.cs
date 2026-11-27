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

namespace Binance.SubAccount.RestApi;

public sealed class QueryManagedSubAccountMarginAssetDetailsResponse
{
    [JsonPropertyName("marginLevel")]
    public string? MarginLevel { get; set; }

    [JsonPropertyName("totalAssetOfBtc")]
    public string? TotalAssetOfBtc { get; set; }

    [JsonPropertyName("totalLiabilityOfBtc")]
    public string? TotalLiabilityOfBtc { get; set; }

    [JsonPropertyName("totalNetAssetOfBtc")]
    public string? TotalNetAssetOfBtc { get; set; }

    [JsonPropertyName("userAssets")]
    public List<QueryManagedSubAccountMarginAssetDetailsResponseUserAssetsInner>? UserAssets { get; set; }
}
