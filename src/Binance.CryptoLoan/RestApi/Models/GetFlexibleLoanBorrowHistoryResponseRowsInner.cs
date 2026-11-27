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

public sealed class GetFlexibleLoanBorrowHistoryResponseRowsInner
{
    [JsonPropertyName("loanCoin")]
    public string? LoanCoin { get; set; }

    [JsonPropertyName("initialLoanAmount")]
    public string? InitialLoanAmount { get; set; }

    [JsonPropertyName("collateralCoin")]
    public string? CollateralCoin { get; set; }

    [JsonPropertyName("initialCollateralAmount")]
    public string? InitialCollateralAmount { get; set; }

    [JsonPropertyName("borrowTime")]
    public long? BorrowTime { get; set; }

    /// <summary>SUCCESS, FAILED, PENDING</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
