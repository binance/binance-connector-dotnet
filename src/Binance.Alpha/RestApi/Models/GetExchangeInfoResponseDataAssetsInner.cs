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

namespace Binance.Alpha.RestApi;

public sealed class GetExchangeInfoResponseDataAssetsInner
{
    /// <summary>Asset symbol.</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }
}
