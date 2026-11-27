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

namespace Binance.DualInvestment.RestApi;

public sealed class CheckDualInvestmentAccountsResponse
{
    /// <summary>Total BTC amount in Dual Investment</summary>
    [JsonPropertyName("totalAmountInBTC")]
    public string? TotalAmountInBTC { get; set; }

    /// <summary>Total USDT equivalent amount in Dual Investment</summary>
    [JsonPropertyName("totalAmountInUSDT")]
    public string? TotalAmountInUSDT { get; set; }
}
