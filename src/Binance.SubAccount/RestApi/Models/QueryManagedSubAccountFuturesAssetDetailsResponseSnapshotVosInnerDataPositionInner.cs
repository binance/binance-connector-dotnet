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

public sealed class QueryManagedSubAccountFuturesAssetDetailsResponseSnapshotVosInnerDataPositionInner
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("entryPrice")]
    public long? EntryPrice { get; set; }

    [JsonPropertyName("markPrice")]
    public long? MarkPrice { get; set; }

    [JsonPropertyName("positionAmt")]
    public decimal? PositionAmt { get; set; }
}
