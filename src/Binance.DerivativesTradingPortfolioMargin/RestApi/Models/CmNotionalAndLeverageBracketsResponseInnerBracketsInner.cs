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

namespace Binance.DerivativesTradingPortfolioMargin.RestApi;

public sealed class CmNotionalAndLeverageBracketsResponseInnerBracketsInner
{
    /// <summary>bracket level</summary>
    [JsonPropertyName("bracket")]
    public long? Bracket { get; set; }

    /// <summary>the maximum leverage</summary>
    [JsonPropertyName("initialLeverage")]
    public long? InitialLeverage { get; set; }

    /// <summary>upper edge of base asset quantity</summary>
    [JsonPropertyName("qtyCap")]
    public long? QtyCap { get; set; }

    /// <summary>lower edge of base asset quantity</summary>
    [JsonPropertyName("qtyFloor")]
    public long? QtyFloor { get; set; }

    /// <summary>maintenance margin rate</summary>
    [JsonPropertyName("maintMarginRatio")]
    public decimal? MaintMarginRatio { get; set; }

    /// <summary>Auxiliary number for quick calculation</summary>
    [JsonPropertyName("cum")]
    public decimal? Cum { get; set; }
}
