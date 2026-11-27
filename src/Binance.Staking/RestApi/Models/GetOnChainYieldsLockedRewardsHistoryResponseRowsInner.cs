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

namespace Binance.Staking.RestApi;

public sealed class GetOnChainYieldsLockedRewardsHistoryResponseRowsInner
{
    [JsonPropertyName("positionId")]
    public string? PositionId { get; set; }

    [JsonPropertyName("time")]
    public long? Time { get; set; }

    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    [JsonPropertyName("lockPeriod")]
    public string? LockPeriod { get; set; }

    [JsonPropertyName("amount")]
    public string? Amount { get; set; }
}
