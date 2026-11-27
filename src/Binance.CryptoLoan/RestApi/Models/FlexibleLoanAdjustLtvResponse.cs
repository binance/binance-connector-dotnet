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

public sealed class FlexibleLoanAdjustLtvResponse
{
    [JsonPropertyName("loanCoin")]
    public string? LoanCoin { get; set; }

    [JsonPropertyName("collateralCoin")]
    public string? CollateralCoin { get; set; }

    [JsonPropertyName("direction")]
    public string? Direction { get; set; }

    [JsonPropertyName("adjustmentAmount")]
    public string? AdjustmentAmount { get; set; }

    [JsonPropertyName("currentLTV")]
    public string? CurrentLTV { get; set; }

    /// <summary>Succeeds, Failed, Processing</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
