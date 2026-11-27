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

public sealed class GetLoanableAssetsDataResponseRowsInner
{
    [JsonPropertyName("loanCoin")]
    public string? LoanCoin { get; set; }

    [JsonPropertyName("_flexibleDailyInterestRate")]
    public string? FlexibleDailyInterestRate { get; set; }

    [JsonPropertyName("_flexibleYearlyInterestRate")]
    public string? FlexibleYearlyInterestRate { get; set; }

    [JsonPropertyName("_30dDailyInterestRate")]
    public string? Var30dDailyInterestRate { get; set; }

    [JsonPropertyName("_30dYearlyInterestRate")]
    public string? Var30dYearlyInterestRate { get; set; }

    [JsonPropertyName("_60dDailyInterestRate")]
    public string? Var60dDailyInterestRate { get; set; }

    [JsonPropertyName("_60dYearlyInterestRate")]
    public string? Var60dYearlyInterestRate { get; set; }

    [JsonPropertyName("minLimit")]
    public string? MinLimit { get; set; }

    [JsonPropertyName("maxLimit")]
    public string? MaxLimit { get; set; }

    [JsonPropertyName("vipLevel")]
    public long? VipLevel { get; set; }
}
