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

namespace Binance.SubAccount.RestApi;

public sealed class QuerySubAccountTransactionStatisticsResponse
{
    [JsonPropertyName("recent30BtcTotal")]
    public string? Recent30BtcTotal { get; set; }

    [JsonPropertyName("recent30BtcFuturesTotal")]
    public string? Recent30BtcFuturesTotal { get; set; }

    [JsonPropertyName("recent30BtcMarginTotal")]
    public string? Recent30BtcMarginTotal { get; set; }

    [JsonPropertyName("recent30BusdTotal")]
    public string? Recent30BusdTotal { get; set; }

    [JsonPropertyName("recent30BusdFuturesTotal")]
    public string? Recent30BusdFuturesTotal { get; set; }

    [JsonPropertyName("recent30BusdMarginTotal")]
    public string? Recent30BusdMarginTotal { get; set; }

    [JsonPropertyName("tradeInfoVos")]
    public List<QuerySubAccountTransactionStatisticsResponseTradeInfoVosInner>? TradeInfoVos { get; set; }
}
