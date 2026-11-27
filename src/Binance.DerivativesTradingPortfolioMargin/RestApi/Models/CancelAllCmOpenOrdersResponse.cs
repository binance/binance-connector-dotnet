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

public sealed class CancelAllCmOpenOrdersResponse
{
    /// <summary>Code.</summary>
    [JsonPropertyName("code")]
    public long? Code { get; set; }

    /// <summary>Msg.</summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }
}
