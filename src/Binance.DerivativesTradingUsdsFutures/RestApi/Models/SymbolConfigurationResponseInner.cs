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

public sealed class SymbolConfigurationResponseInner
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("marginType")]
    public string? MarginType { get; set; }

    [JsonPropertyName("isAutoAddMargin")]
    public bool? IsAutoAddMargin { get; set; }

    [JsonPropertyName("leverage")]
    public long? Leverage { get; set; }

    [JsonPropertyName("maxNotionalValue")]
    public string? MaxNotionalValue { get; set; }
}
