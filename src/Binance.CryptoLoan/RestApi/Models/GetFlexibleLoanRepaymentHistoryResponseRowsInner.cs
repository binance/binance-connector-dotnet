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

namespace Binance.CryptoLoan.RestApi;

public sealed class GetFlexibleLoanRepaymentHistoryResponseRowsInner
{
    [JsonPropertyName("loanCoin")]
    public string? LoanCoin { get; set; }

    [JsonPropertyName("repayAmount")]
    public string? RepayAmount { get; set; }

    [JsonPropertyName("collateralCoin")]
    public string? CollateralCoin { get; set; }

    [JsonPropertyName("collateralReturn")]
    public string? CollateralReturn { get; set; }

    /// <summary>REPAID, REPAYING, FAILED</summary>
    [JsonPropertyName("repayStatus")]
    public string? RepayStatus { get; set; }

    [JsonPropertyName("repayTime")]
    public long? RepayTime { get; set; }
}
