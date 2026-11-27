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

namespace Binance.MarginTrading.RestApi;

public sealed class GetSummaryOfMarginAccountResponse
{
    /// <summary>normal Bar.</summary>
    [JsonPropertyName("normalBar")]
    public string? NormalBar { get; set; }

    /// <summary>margin Call Bar.</summary>
    [JsonPropertyName("marginCallBar")]
    public string? MarginCallBar { get; set; }

    /// <summary>force Liquidation Bar.</summary>
    [JsonPropertyName("forceLiquidationBar")]
    public string? ForceLiquidationBar { get; set; }
}
