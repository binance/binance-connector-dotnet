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

namespace Binance.GiftCard.RestApi;

public sealed class FetchTokenLimitResponseDataInner
{
    [JsonPropertyName("coin")]
    public string? Coin { get; set; }

    [JsonPropertyName("fromMin")]
    public string? FromMin { get; set; }

    [JsonPropertyName("fromMax")]
    public string? FromMax { get; set; }
}
