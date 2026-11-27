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

public sealed class QueryInsuranceFundBalanceSnapshotResponse2Inner
{
    [JsonPropertyName("symbols")]
    public List<string>? Symbols { get; set; }

    [JsonPropertyName("assets")]
    public List<QueryInsuranceFundBalanceSnapshotResponse2InnerAssetsInner>? Assets { get; set; }
}
