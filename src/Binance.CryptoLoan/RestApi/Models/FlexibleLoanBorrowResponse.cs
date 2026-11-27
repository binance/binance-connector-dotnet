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

public sealed class FlexibleLoanBorrowResponse
{
    [JsonPropertyName("loanCoin")]
    public string? LoanCoin { get; set; }

    [JsonPropertyName("loanAmount")]
    public string? LoanAmount { get; set; }

    [JsonPropertyName("collateralCoin")]
    public string? CollateralCoin { get; set; }

    [JsonPropertyName("collateralAmount")]
    public string? CollateralAmount { get; set; }

    /// <summary>Succeeds, Failed, Processing</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
