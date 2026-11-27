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

namespace Binance.DerivativesTradingOptions.RestApi;

public sealed class OptionMarginAccountInformationResponseGreekInner
{
    /// <summary>underlying</summary>
    [JsonPropertyName("underlying")]
    public string? Underlying { get; set; }

    /// <summary>delta</summary>
    [JsonPropertyName("delta")]
    public string? Delta { get; set; }

    /// <summary>gamma</summary>
    [JsonPropertyName("gamma")]
    public string? Gamma { get; set; }

    /// <summary>theta</summary>
    [JsonPropertyName("theta")]
    public string? Theta { get; set; }

    /// <summary>vega</summary>
    [JsonPropertyName("vega")]
    public string? Vega { get; set; }
}
