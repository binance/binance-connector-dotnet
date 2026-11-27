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

public sealed class GetFlexibleLoanLtvAdjustmentHistoryResponseRowsInner
{
    [JsonPropertyName("loanCoin")]
    public string? LoanCoin { get; set; }

    [JsonPropertyName("collateralCoin")]
    public string? CollateralCoin { get; set; }

    [JsonPropertyName("direction")]
    public string? Direction { get; set; }

    [JsonPropertyName("collateralAmount")]
    public string? CollateralAmount { get; set; }

    [JsonPropertyName("preLTV")]
    public string? PreLTV { get; set; }

    [JsonPropertyName("afterLTV")]
    public string? AfterLTV { get; set; }

    [JsonPropertyName("adjustTime")]
    public long? AdjustTime { get; set; }
}
