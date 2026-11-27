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

/// <summary>Price.</summary>
public sealed class QueryCmModifyOrderHistoryResponseInnerAmendmentPrice
{
    /// <summary>Before.</summary>
    [JsonPropertyName("before")]
    public string? Before { get; set; }

    /// <summary>After.</summary>
    [JsonPropertyName("after")]
    public string? After { get; set; }
}
