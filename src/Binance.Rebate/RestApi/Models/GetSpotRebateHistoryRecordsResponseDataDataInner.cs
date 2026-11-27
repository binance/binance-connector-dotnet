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

namespace Binance.Rebate.RestApi;

public sealed class GetSpotRebateHistoryRecordsResponseDataDataInner
{
    /// <summary>Rebate asset.</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>1 is commission rebate, 2 is referral kickback</summary>
    [JsonPropertyName("type")]
    public long? Type { get; set; }

    /// <summary>Rebate amount.</summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>Update timestamp.</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }
}
