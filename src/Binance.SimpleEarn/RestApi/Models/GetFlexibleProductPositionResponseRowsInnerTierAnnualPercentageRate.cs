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

namespace Binance.SimpleEarn.RestApi;

public sealed class GetFlexibleProductPositionResponseRowsInnerTierAnnualPercentageRate
{
    [JsonPropertyName("0-5BTC")]
    public decimal? Var05BTC { get; set; }

    [JsonPropertyName("5-10BTC")]
    public decimal? Var510BTC { get; set; }
}
