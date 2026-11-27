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

namespace Binance.MarginTrading.RestApi;

public sealed class QueryIsolatedMarginAccountInfoResponse
{
    /// <summary>assets list.</summary>
    [JsonPropertyName("assets")]
    public List<QueryIsolatedMarginAccountInfoResponseAssetsInner>? Assets { get; set; }

    /// <summary>total Asset Of Btc.</summary>
    [JsonPropertyName("totalAssetOfBtc")]
    public string? TotalAssetOfBtc { get; set; }

    /// <summary>total Liability Of Btc.</summary>
    [JsonPropertyName("totalLiabilityOfBtc")]
    public string? TotalLiabilityOfBtc { get; set; }

    /// <summary>total Net Asset Of Btc.</summary>
    [JsonPropertyName("totalNetAssetOfBtc")]
    public string? TotalNetAssetOfBtc { get; set; }
}
