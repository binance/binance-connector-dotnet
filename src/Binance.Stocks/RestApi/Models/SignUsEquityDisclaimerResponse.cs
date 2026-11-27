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

namespace Binance.Stocks.RestApi;

public sealed class SignUsEquityDisclaimerResponse
{
    /// <summary>true = acceptance recorded successfully.</summary>
    [JsonPropertyName("success")]
    public bool? Success { get; set; }
}
