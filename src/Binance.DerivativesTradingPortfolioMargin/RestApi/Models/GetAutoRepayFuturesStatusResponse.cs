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

public sealed class GetAutoRepayFuturesStatusResponse
{
    /// <summary>
    /// "true" for turn on the auto-repay futures; "false" for turn off the auto-repay futures
    /// </summary>
    [JsonPropertyName("autoRepay")]
    public bool? AutoRepay { get; set; }
}
