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

public sealed class QueryManagedSubAccountTransferLogMasterAccountInvestorResponseManagerSubTransferHistoryVosInner
{
    [JsonPropertyName("fromEmail")]
    public string? FromEmail { get; set; }

    [JsonPropertyName("fromAccountType")]
    public string? FromAccountType { get; set; }

    [JsonPropertyName("toEmail")]
    public string? ToEmail { get; set; }

    [JsonPropertyName("toAccountType")]
    public string? ToAccountType { get; set; }

    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    [JsonPropertyName("scheduledData")]
    public long? ScheduledData { get; set; }

    [JsonPropertyName("createTime")]
    public long? CreateTime { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("tranId")]
    public long? TranId { get; set; }
}
