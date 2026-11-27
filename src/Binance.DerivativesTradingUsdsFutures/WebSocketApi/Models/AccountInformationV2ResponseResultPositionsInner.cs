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

public sealed class AccountInformationV2ResponseResultPositionsInner
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>position side</summary>
    [JsonPropertyName("positionSide")]
    public string? PositionSide { get; set; }

    [JsonPropertyName("positionAmt")]
    public string? PositionAmt { get; set; }

    /// <summary>unrealized profit</summary>
    [JsonPropertyName("unrealizedProfit")]
    public string? UnrealizedProfit { get; set; }

    [JsonPropertyName("isolatedMargin")]
    public string? IsolatedMargin { get; set; }

    [JsonPropertyName("notional")]
    public string? Notional { get; set; }

    [JsonPropertyName("isolatedWallet")]
    public string? IsolatedWallet { get; set; }

    /// <summary>total initial margin required with current mark price</summary>
    [JsonPropertyName("initialMargin")]
    public string? InitialMargin { get; set; }

    /// <summary>maintenance margin required</summary>
    [JsonPropertyName("maintMargin")]
    public string? MaintMargin { get; set; }

    /// <summary>last update time</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }
}
