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

public sealed class NotionalAndLeverageBracketsResponse2BracketsInner
{
    /// <summary>Notional bracket</summary>
    [JsonPropertyName("bracket")]
    public long? Bracket { get; set; }

    /// <summary>Max initial leverage for this bracket</summary>
    [JsonPropertyName("initialLeverage")]
    public long? InitialLeverage { get; set; }

    /// <summary>Cap notional of this bracket</summary>
    [JsonPropertyName("notionalCap")]
    public long? NotionalCap { get; set; }

    /// <summary>Notional threshold of this bracket</summary>
    [JsonPropertyName("notionalFloor")]
    public long? NotionalFloor { get; set; }

    /// <summary>Maintenance ratio for this bracket</summary>
    [JsonPropertyName("maintMarginRatio")]
    public decimal? MaintMarginRatio { get; set; }

    /// <summary>Auxiliary number for quick calculation</summary>
    [JsonPropertyName("cum")]
    public long? Cum { get; set; }
}
