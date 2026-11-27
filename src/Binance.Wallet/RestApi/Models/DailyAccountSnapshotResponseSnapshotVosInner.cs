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

public sealed class DailyAccountSnapshotResponseSnapshotVosInner
{
    [JsonPropertyName("data")]
    public DailyAccountSnapshotResponseSnapshotVosInnerData? Data { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }
}
