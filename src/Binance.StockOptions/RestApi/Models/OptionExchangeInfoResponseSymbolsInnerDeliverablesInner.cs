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

namespace Binance.StockOptions.RestApi;

public sealed class OptionExchangeInfoResponseSymbolsInnerDeliverablesInner
{
    /// <summary>
    /// EQUITY (shares; symbol is the ticker and amount is the number of shares) / CASH (symbol is the
    /// currency and amount is the cash amount).
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>Ticker or currency.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Number of shares or cash amount.</summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }
}
