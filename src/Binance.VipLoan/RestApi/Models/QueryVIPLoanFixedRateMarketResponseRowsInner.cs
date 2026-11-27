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

public sealed class QueryVIPLoanFixedRateMarketResponseRowsInner
{
    /// <summary>Supply request ID</summary>
    [JsonPropertyName("requestId")]
    public long? RequestId { get; set; }

    /// <summary>Request number</summary>
    [JsonPropertyName("requestNo")]
    public long? RequestNo { get; set; }

    /// <summary>Coin</summary>
    [JsonPropertyName("coin")]
    public string? Coin { get; set; }

    /// <summary>Annual interest rate</summary>
    [JsonPropertyName("interestRate")]
    public string? InterestRate { get; set; }

    /// <summary>Duration in days</summary>
    [JsonPropertyName("duration")]
    public long? Duration { get; set; }

    /// <summary>Minimum borrow amount</summary>
    [JsonPropertyName("minimumAmount")]
    public string? MinimumAmount { get; set; }

    /// <summary>Maximum available borrow amount</summary>
    [JsonPropertyName("availableAmount")]
    public string? AvailableAmount { get; set; }

    /// <summary>Estimated interest</summary>
    [JsonPropertyName("estimatedInterest")]
    public string? EstimatedInterest { get; set; }
}
