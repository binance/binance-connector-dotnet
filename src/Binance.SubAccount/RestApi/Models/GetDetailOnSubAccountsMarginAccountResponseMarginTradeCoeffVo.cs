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

public sealed class GetDetailOnSubAccountsMarginAccountResponseMarginTradeCoeffVo
{
    /// <summary>Liquidation margin ratio</summary>
    [JsonPropertyName("forceLiquidationBar")]
    public string? ForceLiquidationBar { get; set; }

    /// <summary>Margin call margin ratio</summary>
    [JsonPropertyName("marginCallBar")]
    public string? MarginCallBar { get; set; }

    /// <summary>Initial margin ratio</summary>
    [JsonPropertyName("normalBar")]
    public string? NormalBar { get; set; }
}
