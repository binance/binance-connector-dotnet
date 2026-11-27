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

public sealed class QuerySubAccountSpotAssetsSummaryResponse
{
    [JsonPropertyName("totalCount")]
    public long? TotalCount { get; set; }

    [JsonPropertyName("masterAccountTotalAsset")]
    public string? MasterAccountTotalAsset { get; set; }

    [JsonPropertyName("spotSubUserAssetBtcVoList")]
    public List<QuerySubAccountSpotAssetsSummaryResponseSpotSubUserAssetBtcVoListInner>? SpotSubUserAssetBtcVoList { get; set; }
}
