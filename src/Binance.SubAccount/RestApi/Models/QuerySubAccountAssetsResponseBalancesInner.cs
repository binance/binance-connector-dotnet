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

public sealed class QuerySubAccountAssetsResponseBalancesInner
{
    [JsonPropertyName("freeze")]
    public long? Freeze { get; set; }

    [JsonPropertyName("withdrawing")]
    public long? Withdrawing { get; set; }

    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    [JsonPropertyName("free")]
    public decimal? Free { get; set; }

    [JsonPropertyName("locked")]
    public long? Locked { get; set; }
}
