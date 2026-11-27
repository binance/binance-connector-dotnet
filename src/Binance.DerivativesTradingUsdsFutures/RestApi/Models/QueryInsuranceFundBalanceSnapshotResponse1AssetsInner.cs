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

namespace Binance.DerivativesTradingUsdsFutures.RestApi;

public sealed class QueryInsuranceFundBalanceSnapshotResponse1AssetsInner
{
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    [JsonPropertyName("marginBalance")]
    public string? MarginBalance { get; set; }

    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }
}
