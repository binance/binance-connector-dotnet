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

namespace Binance.CopyTrading.RestApi;

public sealed class GetFuturesLeadTradingSymbolWhitelistResponseDataInner
{
    /// <summary>Trading symbol</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Base asset</summary>
    [JsonPropertyName("baseAsset")]
    public string? BaseAsset { get; set; }

    /// <summary>Quote asset</summary>
    [JsonPropertyName("quoteAsset")]
    public string? QuoteAsset { get; set; }
}
