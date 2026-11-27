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

namespace Binance.DerivativesTradingUsdsFutures.RestApi;

public sealed class NotionalAndLeverageBracketsResponse2
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>
    /// user symbol bracket multiplier, only appears when user's symbol bracket is adjusted
    /// </summary>
    [JsonPropertyName("notionalCoef")]
    public decimal? NotionalCoef { get; set; }

    [JsonPropertyName("brackets")]
    public List<NotionalAndLeverageBracketsResponse2BracketsInner>? Brackets { get; set; }
}
