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

namespace Binance.DerivativesTradingCoinFutures.WebSocketApi;

/// <summary>Indicates that combined is set to true.</summary>
public sealed class AccountInformationResponseResult
{
    /// <summary>Fee tier level.</summary>
    [JsonPropertyName("feeTier")]
    public long? FeeTier { get; set; }

    /// <summary>Whether trading is enabled.</summary>
    [JsonPropertyName("canTrade")]
    public bool? CanTrade { get; set; }

    /// <summary>Whether deposits are enabled.</summary>
    [JsonPropertyName("canDeposit")]
    public bool? CanDeposit { get; set; }

    /// <summary>Whether withdrawals are enabled.</summary>
    [JsonPropertyName("canWithdraw")]
    public bool? CanWithdraw { get; set; }

    /// <summary>update time</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }

    /// <summary>Supported assets.</summary>
    [JsonPropertyName("assets")]
    public List<AccountInformationResponseResultAssetsInner>? Assets { get; set; }

    /// <summary>Position list.</summary>
    [JsonPropertyName("positions")]
    public List<AccountInformationResponseResultPositionsInner>? Positions { get; set; }
}
