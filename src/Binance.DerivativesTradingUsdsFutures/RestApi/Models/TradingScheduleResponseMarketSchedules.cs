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

public sealed class TradingScheduleResponseMarketSchedules
{
    [JsonPropertyName("EQUITY")]
    public TradingScheduleResponseMarketSchedulesEQUITY? EQUITY { get; set; }

    [JsonPropertyName("COMMODITY")]
    public TradingScheduleResponseMarketSchedulesCOMMODITY? COMMODITY { get; set; }

    [JsonPropertyName("KR_EQUITY")]
    public TradingScheduleResponseMarketSchedulesKREQUITY? KrEquity { get; set; }

    [JsonPropertyName("HK_EQUITY")]
    public TradingScheduleResponseMarketSchedulesHKEQUITY? HkEquity { get; set; }

    [JsonPropertyName("CN_EQUITY")]
    public TradingScheduleResponseMarketSchedulesHKEQUITY? CnEquity { get; set; }

    [JsonPropertyName("FX")]
    public TradingScheduleResponseMarketSchedulesFX? FXUppercase { get; set; }
}
