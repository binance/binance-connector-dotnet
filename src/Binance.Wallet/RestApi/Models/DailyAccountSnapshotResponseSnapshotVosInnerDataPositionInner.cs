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

public sealed class DailyAccountSnapshotResponseSnapshotVosInnerDataPositionInner
{
    [JsonPropertyName("entryPrice")]
    public string? EntryPrice { get; set; }

    [JsonPropertyName("markPrice")]
    public string? MarkPrice { get; set; }

    [JsonPropertyName("positionAmt")]
    public string? PositionAmt { get; set; }

    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Only show the value at the time of opening the position</summary>
    [JsonPropertyName("unRealizedProfit")]
    public string? UnRealizedProfit { get; set; }
}
