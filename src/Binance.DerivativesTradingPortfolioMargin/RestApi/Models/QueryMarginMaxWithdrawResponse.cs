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

namespace Binance.DerivativesTradingPortfolioMargin.RestApi;

public sealed class QueryMarginMaxWithdrawResponse
{
    /// <summary>account's currently max withdrawable amount with sufficient system availability</summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }
}
