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

public sealed class GetFlexibleLoanAssetsDataResponseRowsInner
{
    [JsonPropertyName("loanCoin")]
    public string? LoanCoin { get; set; }

    [JsonPropertyName("flexibleInterestRate")]
    public string? FlexibleInterestRate { get; set; }

    [JsonPropertyName("flexibleMinLimit")]
    public string? FlexibleMinLimit { get; set; }

    [JsonPropertyName("flexibleMaxLimit")]
    public string? FlexibleMaxLimit { get; set; }
}
