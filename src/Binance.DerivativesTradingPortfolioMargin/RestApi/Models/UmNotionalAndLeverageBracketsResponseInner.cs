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

public sealed class UmNotionalAndLeverageBracketsResponseInner
{
    /// <summary>Trade symbol, if existing.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Notional Coef.</summary>
    [JsonPropertyName("notionalCoef")]
    public string? NotionalCoef { get; set; }

    /// <summary>Brackets.</summary>
    [JsonPropertyName("brackets")]
    public List<UmNotionalAndLeverageBracketsResponseInnerBracketsInner>? Brackets { get; set; }
}
