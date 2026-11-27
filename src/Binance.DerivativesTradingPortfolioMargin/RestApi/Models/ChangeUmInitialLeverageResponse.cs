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

public sealed class ChangeUmInitialLeverageResponse
{
    /// <summary>current initial leverage</summary>
    [JsonPropertyName("leverage")]
    public long? Leverage { get; set; }

    /// <summary>Max Notional Value.</summary>
    [JsonPropertyName("maxNotionalValue")]
    public string? MaxNotionalValue { get; set; }

    /// <summary>Trade symbol, if existing.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }
}
