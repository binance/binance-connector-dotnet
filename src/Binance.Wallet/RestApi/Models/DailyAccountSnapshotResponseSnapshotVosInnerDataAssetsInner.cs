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

public sealed class DailyAccountSnapshotResponseSnapshotVosInnerDataAssetsInner
{
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>Not real-time data, can ignore</summary>
    [JsonPropertyName("marginBalance")]
    public string? MarginBalance { get; set; }

    [JsonPropertyName("walletBalance")]
    public string? WalletBalance { get; set; }
}
