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

namespace Binance.DerivativesTradingUsdsFutures.WebSocketApi;

public sealed class FuturesAccountBalanceResponseResultInner
{
    /// <summary>unique account code</summary>
    [JsonPropertyName("accountAlias")]
    public string? AccountAlias { get; set; }

    /// <summary>asset name</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>wallet balance</summary>
    [JsonPropertyName("balance")]
    public string? Balance { get; set; }

    /// <summary>crossed wallet balance</summary>
    [JsonPropertyName("crossWalletBalance")]
    public string? CrossWalletBalance { get; set; }

    /// <summary>unrealized profit of crossed positions</summary>
    [JsonPropertyName("crossUnPnl")]
    public string? CrossUnPnl { get; set; }

    /// <summary>available balance</summary>
    [JsonPropertyName("availableBalance")]
    public string? AvailableBalance { get; set; }

    /// <summary>maximum amount for transfer out</summary>
    [JsonPropertyName("maxWithdrawAmount")]
    public string? MaxWithdrawAmount { get; set; }

    /// <summary>whether the asset can be used as margin in Multi-Assets mode</summary>
    [JsonPropertyName("marginAvailable")]
    public bool? MarginAvailable { get; set; }

    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }
}
