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

public sealed class TakerBuySellVolumeResponseInner
{
    [JsonPropertyName("buySellRatio")]
    public string? BuySellRatio { get; set; }

    [JsonPropertyName("buyVol")]
    public string? BuyVol { get; set; }

    [JsonPropertyName("sellVol")]
    public string? SellVol { get; set; }

    /// <summary>Start time of the period, in milliseconds.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; set; }
}
