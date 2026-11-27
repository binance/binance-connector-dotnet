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

public sealed class GetBorrowInterestRateResponseInner
{
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    [JsonPropertyName("flexibleDailyInterestRate")]
    public string? FlexibleDailyInterestRate { get; set; }

    [JsonPropertyName("flexibleYearlyInterestRate")]
    public string? FlexibleYearlyInterestRate { get; set; }

    [JsonPropertyName("time")]
    public long? Time { get; set; }
}
