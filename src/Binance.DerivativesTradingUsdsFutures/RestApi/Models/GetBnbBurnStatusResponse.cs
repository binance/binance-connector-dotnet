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

public sealed class GetBnbBurnStatusResponse
{
    /// <summary>"true": Fee Discount On; "false": Fee Discount Off</summary>
    [JsonPropertyName("feeBurn")]
    public bool? FeeBurn { get; set; }
}
