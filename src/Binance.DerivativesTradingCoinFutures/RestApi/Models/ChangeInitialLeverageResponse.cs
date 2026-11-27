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

namespace Binance.DerivativesTradingCoinFutures.RestApi;

public sealed class ChangeInitialLeverageResponse
{
    /// <summary>Leverage value.</summary>
    [JsonPropertyName("leverage")]
    public long? Leverage { get; set; }

    /// <summary>maximum quantity of base asset</summary>
    [JsonPropertyName("maxQty")]
    public string? MaxQty { get; set; }

    /// <summary>Trading symbol</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }
}
