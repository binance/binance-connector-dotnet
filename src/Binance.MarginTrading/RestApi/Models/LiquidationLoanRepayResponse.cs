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

namespace Binance.MarginTrading.RestApi;

public sealed class LiquidationLoanRepayResponse
{
    /// <summary>Unique identifier for this repayment transaction</summary>
    [JsonPropertyName("repayId")]
    public long? RepayId { get; set; }

    /// <summary>Asset used for repayment</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>Actual repayment amount</summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>Repayment status: SUCCESS (completed) or PENDING (processing)</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>Unix timestamp (milliseconds) when the repayment was created</summary>
    [JsonPropertyName("createTime")]
    public long? CreateTime { get; set; }
}
