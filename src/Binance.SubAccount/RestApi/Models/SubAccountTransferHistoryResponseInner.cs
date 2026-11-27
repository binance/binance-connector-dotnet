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

public sealed class SubAccountTransferHistoryResponseInner
{
    [JsonPropertyName("counterParty")]
    public string? CounterParty { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>1 for transfer in, 2 for transfer out</summary>
    [JsonPropertyName("type")]
    public long? Type { get; set; }

    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    [JsonPropertyName("qty")]
    public string? Qty { get; set; }

    [JsonPropertyName("fromAccountType")]
    public string? FromAccountType { get; set; }

    [JsonPropertyName("toAccountType")]
    public string? ToAccountType { get; set; }

    /// <summary>status: PROCESS / SUCCESS / FAILURE</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("tranId")]
    public long? TranId { get; set; }

    [JsonPropertyName("time")]
    public long? Time { get; set; }
}
