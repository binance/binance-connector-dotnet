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

public sealed class AssetDividendRecordResponseRowsInner
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    [JsonPropertyName("divTime")]
    public long? DivTime { get; set; }

    [JsonPropertyName("enInfo")]
    public string? EnInfo { get; set; }

    [JsonPropertyName("tranId")]
    public long? TranId { get; set; }

    /// <summary>direction: 1 for Asset credited (inflow), -1 for Asset debited (outflow)</summary>
    [JsonPropertyName("direction")]
    public long? Direction { get; set; }
}
