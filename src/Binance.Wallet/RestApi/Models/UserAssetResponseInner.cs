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

namespace Binance.Wallet.RestApi;

public sealed class UserAssetResponseInner
{
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    [JsonPropertyName("free")]
    public string? Free { get; set; }

    [JsonPropertyName("locked")]
    public string? Locked { get; set; }

    [JsonPropertyName("freeze")]
    public string? Freeze { get; set; }

    [JsonPropertyName("withdrawing")]
    public string? Withdrawing { get; set; }

    [JsonPropertyName("ipoable")]
    public string? Ipoable { get; set; }

    [JsonPropertyName("btcValuation")]
    public string? BtcValuation { get; set; }
}
