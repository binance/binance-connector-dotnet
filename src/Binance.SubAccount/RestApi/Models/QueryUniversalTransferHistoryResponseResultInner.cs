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

public sealed class QueryUniversalTransferHistoryResponseResultInner
{
    [JsonPropertyName("tranId")]
    public long? TranId { get; set; }

    [JsonPropertyName("fromEmail")]
    public string? FromEmail { get; set; }

    [JsonPropertyName("toEmail")]
    public string? ToEmail { get; set; }

    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    [JsonPropertyName("createTimeStamp")]
    public long? CreateTimeStamp { get; set; }

    [JsonPropertyName("fromAccountType")]
    public string? FromAccountType { get; set; }

    [JsonPropertyName("toAccountType")]
    public string? ToAccountType { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("clientTranId")]
    public string? ClientTranId { get; set; }
}
