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

namespace Binance.DerivativesTradingPortfolioMarginPro.RestApi;

public sealed class GetMarginCallLevelResponse
{
    /// <summary>The margin call level value. Empty object returned if not set.</summary>
    [JsonPropertyName("marginCallLevel")]
    public string? MarginCallLevel { get; set; }
}
