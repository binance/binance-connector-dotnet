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

public sealed class AccountInformationResponse
{
    /// <summary>Supported assets.</summary>
    [JsonPropertyName("assets")]
    public List<AccountInformationResponseAssetsInner>? Assets { get; set; }

    /// <summary>Position list.</summary>
    [JsonPropertyName("positions")]
    public List<AccountInformationResponsePositionsInner>? Positions { get; set; }

    /// <summary>Whether deposits are enabled.</summary>
    [JsonPropertyName("canDeposit")]
    public bool? CanDeposit { get; set; }

    /// <summary>Whether trading is enabled.</summary>
    [JsonPropertyName("canTrade")]
    public bool? CanTrade { get; set; }

    /// <summary>Whether withdrawals are enabled.</summary>
    [JsonPropertyName("canWithdraw")]
    public bool? CanWithdraw { get; set; }

    /// <summary>Fee tier level.</summary>
    [JsonPropertyName("feeTier")]
    public long? FeeTier { get; set; }

    /// <summary>update time</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }
}
