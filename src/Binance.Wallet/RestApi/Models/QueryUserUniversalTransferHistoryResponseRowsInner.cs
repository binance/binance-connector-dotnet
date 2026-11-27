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

public sealed class QueryUserUniversalTransferHistoryResponseRowsInner
{
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>status: CONFIRMED / FAILED / PENDING</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("tranId")]
    public long? TranId { get; set; }

    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; set; }
}
