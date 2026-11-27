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

namespace Binance.SimpleEarn.RestApi;

public sealed class GetBfusdRedemptionHistoryResponse
{
    [JsonPropertyName("rows")]
    public List<GetBfusdRedemptionHistoryResponseRowsInner>? Rows { get; set; }

    [JsonPropertyName("total")]
    public long? Total { get; set; }
}
