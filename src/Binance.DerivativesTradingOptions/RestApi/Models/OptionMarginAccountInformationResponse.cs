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

public sealed class OptionMarginAccountInformationResponse
{
    /// <summary>asset</summary>
    [JsonPropertyName("asset")]
    public List<OptionMarginAccountInformationResponseAssetInner>? Asset { get; set; }

    /// <summary>greek</summary>
    [JsonPropertyName("greek")]
    public List<OptionMarginAccountInformationResponseGreekInner>? Greek { get; set; }

    /// <summary>time</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    /// <summary>can Trade</summary>
    [JsonPropertyName("canTrade")]
    public bool? CanTrade { get; set; }

    /// <summary>can Deposit</summary>
    [JsonPropertyName("canDeposit")]
    public bool? CanDeposit { get; set; }

    /// <summary>can Withdraw</summary>
    [JsonPropertyName("canWithdraw")]
    public bool? CanWithdraw { get; set; }

    /// <summary>reduce Only</summary>
    [JsonPropertyName("reduceOnly")]
    public bool? ReduceOnly { get; set; }

    /// <summary>Trade group ID</summary>
    [JsonPropertyName("tradeGroupId")]
    public long? TradeGroupId { get; set; }
}
