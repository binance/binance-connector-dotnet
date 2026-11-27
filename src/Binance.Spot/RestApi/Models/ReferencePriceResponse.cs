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

namespace Binance.Spot.RestApi;

public sealed class ReferencePriceResponse
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Reference price. Can be null if no reference price is set.</summary>
    [JsonPropertyName("referencePrice")]
    public string? ReferencePrice { get; set; }

    /// <summary>Timestamp when reference price was valid.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; set; }
}
