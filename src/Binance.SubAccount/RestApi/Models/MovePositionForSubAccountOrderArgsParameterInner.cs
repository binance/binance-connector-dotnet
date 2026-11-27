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

namespace Binance.SubAccount.RestApi;

public sealed class MovePositionForSubAccountOrderArgsParameterInner
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("quantity")]
    public decimal? Quantity { get; set; }

    /// <summary>
    /// Required when productType=UM. Optional and ignored when productType=OPTION (the response returns
    /// positionSide as null).
    /// </summary>
    [JsonPropertyName("positionSide")]
    public string? PositionSide { get; set; }
}
