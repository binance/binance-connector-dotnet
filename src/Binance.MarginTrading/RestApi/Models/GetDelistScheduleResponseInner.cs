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

namespace Binance.MarginTrading.RestApi;

public sealed class GetDelistScheduleResponseInner
{
    /// <summary>delist Time.</summary>
    [JsonPropertyName("delistTime")]
    public long? DelistTime { get; set; }

    /// <summary>cross Margin Assets list.</summary>
    [JsonPropertyName("crossMarginAssets")]
    public List<string>? CrossMarginAssets { get; set; }

    /// <summary>isolated Margin Symbols list.</summary>
    [JsonPropertyName("isolatedMarginSymbols")]
    public List<string>? IsolatedMarginSymbols { get; set; }
}
