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

public sealed class QueryUserDelegationHistoryResponseRowsInner
{
    [JsonPropertyName("clientTranId")]
    public string? ClientTranId { get; set; }

    [JsonPropertyName("transferType")]
    public string? TransferType { get; set; }

    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    [JsonPropertyName("time")]
    public long? Time { get; set; }
}
