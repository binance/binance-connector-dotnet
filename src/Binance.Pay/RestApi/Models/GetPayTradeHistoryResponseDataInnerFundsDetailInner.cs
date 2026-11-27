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

namespace Binance.Pay.RestApi;

public sealed class GetPayTradeHistoryResponseDataInnerFundsDetailInner
{
    /// <summary>Asset.</summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    /// <summary>Asset amount.</summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>
    /// Asset cost details per wallet type. Keys are wallet type IDs (e.g. "1", "2"), values are cost
    /// amounts.
    /// </summary>
    [JsonPropertyName("walletAssetCost")]
    public Dictionary<string, string>? WalletAssetCost { get; set; }
}
