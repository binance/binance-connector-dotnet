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

namespace Binance.Convert.RestApi;

public sealed class SendQuoteRequestResponse
{
    [JsonPropertyName("quoteId")]
    public string? QuoteId { get; set; }

    [JsonPropertyName("ratio")]
    public string? Ratio { get; set; }

    [JsonPropertyName("inverseRatio")]
    public string? InverseRatio { get; set; }

    [JsonPropertyName("validTimestamp")]
    public long? ValidTimestamp { get; set; }

    [JsonPropertyName("toAmount")]
    public string? ToAmount { get; set; }

    [JsonPropertyName("fromAmount")]
    public string? FromAmount { get; set; }
}
