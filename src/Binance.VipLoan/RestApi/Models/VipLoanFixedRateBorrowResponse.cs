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

namespace Binance.VipLoan.RestApi;

public sealed class VipLoanFixedRateBorrowResponse
{
    /// <summary>Echo of input parameter</summary>
    [JsonPropertyName("borrowCoin")]
    public string? BorrowCoin { get; set; }

    /// <summary>Actual total borrow amount (aggregated when multiple supplyRequest)</summary>
    [JsonPropertyName("borrowAmount")]
    public string? BorrowAmount { get; set; }

    /// <summary>Actual received amount</summary>
    [JsonPropertyName("actualReceivedAmount")]
    public string? ActualReceivedAmount { get; set; }

    /// <summary>Echo of input parameter, comma-separated</summary>
    [JsonPropertyName("collateralCoin")]
    public string? CollateralCoin { get; set; }

    /// <summary>Echo of input parameter, comma-separated</summary>
    [JsonPropertyName("collateralAccountId")]
    public string? CollateralAccountId { get; set; }

    /// <summary>Actual borrow interest rate (weighted average when multiple)</summary>
    [JsonPropertyName("borrowInterestRate")]
    public string? BorrowInterestRate { get; set; }

    /// <summary>{loanTerm}Days, e.g. "30Days"</summary>
    [JsonPropertyName("duration")]
    public string? Duration { get; set; }

    /// <summary>Echo of input parameter</summary>
    [JsonPropertyName("autoRepay")]
    public bool? AutoRepay { get; set; }

    /// <summary>Order ID</summary>
    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    /// <summary>Succeeds / Failed / Processing</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
