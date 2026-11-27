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

namespace Binance.DerivativesTradingCoinFutures.RestApi;

public sealed class TakerBuySellVolumeResponseInner
{
    /// <summary>Pair</summary>
    [JsonPropertyName("pair")]
    public string? Pair { get; set; }

    /// <summary>Contract type.</summary>
    [JsonPropertyName("contractType")]
    public string? ContractType { get; set; }

    /// <summary>unit: cont</summary>
    [JsonPropertyName("takerBuyVol")]
    public string? TakerBuyVol { get; set; }

    /// <summary>unit: cont</summary>
    [JsonPropertyName("takerSellVol")]
    public string? TakerSellVol { get; set; }

    /// <summary>unit: base asset</summary>
    [JsonPropertyName("takerBuyVolValue")]
    public string? TakerBuyVolValue { get; set; }

    /// <summary>unit: base asset</summary>
    [JsonPropertyName("takerSellVolValue")]
    public string? TakerSellVolValue { get; set; }

    /// <summary>Start time of the period, in milliseconds.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; set; }
}
