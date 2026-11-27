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

public sealed class QuerySubAccountTransactionStatisticsResponseTradeInfoVosInner
{
    [JsonPropertyName("userId")]
    public long? UserId { get; set; }

    [JsonPropertyName("btc")]
    public long? Btc { get; set; }

    [JsonPropertyName("btcFutures")]
    public long? BtcFutures { get; set; }

    [JsonPropertyName("btcMargin")]
    public long? BtcMargin { get; set; }

    [JsonPropertyName("busd")]
    public long? Busd { get; set; }

    [JsonPropertyName("busdFutures")]
    public long? BusdFutures { get; set; }

    [JsonPropertyName("busdMargin")]
    public long? BusdMargin { get; set; }

    [JsonPropertyName("date")]
    public long? Date { get; set; }
}
