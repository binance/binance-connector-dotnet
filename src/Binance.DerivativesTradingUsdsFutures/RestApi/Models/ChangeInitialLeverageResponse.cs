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

public sealed class ChangeInitialLeverageResponse
{
    /// <summary>Leverage.</summary>
    [JsonPropertyName("leverage")]
    public long? Leverage { get; set; }

    /// <summary>Max Notional Value.</summary>
    [JsonPropertyName("maxNotionalValue")]
    public string? MaxNotionalValue { get; set; }

    /// <summary>Symbol.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }
}
