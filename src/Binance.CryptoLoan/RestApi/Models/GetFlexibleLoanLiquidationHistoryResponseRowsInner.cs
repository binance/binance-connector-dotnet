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

public sealed class GetFlexibleLoanLiquidationHistoryResponseRowsInner
{
    [JsonPropertyName("loanCoin")]
    public string? LoanCoin { get; set; }

    [JsonPropertyName("liquidationDebt")]
    public string? LiquidationDebt { get; set; }

    [JsonPropertyName("collateralCoin")]
    public string? CollateralCoin { get; set; }

    [JsonPropertyName("liquidationCollateralAmount")]
    public string? LiquidationCollateralAmount { get; set; }

    [JsonPropertyName("returnCollateralAmount")]
    public string? ReturnCollateralAmount { get; set; }

    [JsonPropertyName("liquidationFee")]
    public string? LiquidationFee { get; set; }

    [JsonPropertyName("liquidationStartingPrice")]
    public string? LiquidationStartingPrice { get; set; }

    [JsonPropertyName("liquidationStartingTime")]
    public long? LiquidationStartingTime { get; set; }

    /// <summary>Liquidating</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
