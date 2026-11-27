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

public sealed class FuturesAccountConfigurationResponse
{
    /// <summary>account commission tier</summary>
    [JsonPropertyName("feeTier")]
    public long? FeeTier { get; set; }

    /// <summary>if can trade</summary>
    [JsonPropertyName("canTrade")]
    public bool? CanTrade { get; set; }

    /// <summary>if can transfer in asset</summary>
    [JsonPropertyName("canDeposit")]
    public bool? CanDeposit { get; set; }

    /// <summary>if can transfer out asset</summary>
    [JsonPropertyName("canWithdraw")]
    public bool? CanWithdraw { get; set; }

    [JsonPropertyName("dualSidePosition")]
    public bool? DualSidePosition { get; set; }

    /// <summary>reserved property, please ignore</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }

    [JsonPropertyName("multiAssetsMargin")]
    public bool? MultiAssetsMargin { get; set; }

    [JsonPropertyName("tradeGroupId")]
    public long? TradeGroupId { get; set; }
}
