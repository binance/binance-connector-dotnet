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

public sealed class GetPositionMarginChangeHistoryResponseInner
{
    /// <summary>Symbol.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Type.</summary>
    [JsonPropertyName("type")]
    public long? Type { get; set; }

    /// <summary>Delta Type.</summary>
    [JsonPropertyName("deltaType")]
    public string? DeltaType { get; set; }

    /// <summary>Amount.</summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>Asset.</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>Time.</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    /// <summary>Position Side.</summary>
    [JsonPropertyName("positionSide")]
    public string? PositionSide { get; set; }
}
