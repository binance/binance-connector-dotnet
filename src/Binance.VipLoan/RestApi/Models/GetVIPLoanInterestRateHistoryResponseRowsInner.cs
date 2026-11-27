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

public sealed class GetVIPLoanInterestRateHistoryResponseRowsInner
{
    [JsonPropertyName("coin")]
    public string? Coin { get; set; }

    [JsonPropertyName("annualizedInterestRate")]
    public string? AnnualizedInterestRate { get; set; }

    [JsonPropertyName("time")]
    public long? Time { get; set; }
}
