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

public sealed class DailyAccountSnapshotResponseSnapshotVosInnerData
{
    [JsonPropertyName("balances")]
    public List<DailyAccountSnapshotResponseSnapshotVosInnerDataBalancesInner>? Balances { get; set; }

    [JsonPropertyName("totalAssetOfBtc")]
    public string? TotalAssetOfBtc { get; set; }

    [JsonPropertyName("marginLevel")]
    public string? MarginLevel { get; set; }

    [JsonPropertyName("totalLiabilityOfBtc")]
    public string? TotalLiabilityOfBtc { get; set; }

    [JsonPropertyName("totalNetAssetOfBtc")]
    public string? TotalNetAssetOfBtc { get; set; }

    [JsonPropertyName("userAssets")]
    public List<DailyAccountSnapshotResponseSnapshotVosInnerDataUserAssetsInner>? UserAssets { get; set; }

    [JsonPropertyName("assets")]
    public List<DailyAccountSnapshotResponseSnapshotVosInnerDataAssetsInner>? Assets { get; set; }

    [JsonPropertyName("position")]
    public List<DailyAccountSnapshotResponseSnapshotVosInnerDataPositionInner>? Position { get; set; }
}
