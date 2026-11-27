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

public sealed class ExchangeInformationResponseOptionContractsInner
{
    /// <summary>Base currency</summary>
    [JsonPropertyName("baseAsset")]
    public string? BaseAsset { get; set; }

    /// <summary>Quotation asset</summary>
    [JsonPropertyName("quoteAsset")]
    public string? QuoteAsset { get; set; }

    /// <summary>Name of the underlying asset of the option contract</summary>
    [JsonPropertyName("underlying")]
    public string? Underlying { get; set; }

    /// <summary>Settlement currency</summary>
    [JsonPropertyName("settleAsset")]
    public string? SettleAsset { get; set; }
}
