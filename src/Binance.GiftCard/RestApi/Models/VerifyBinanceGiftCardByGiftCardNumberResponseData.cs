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

public sealed class VerifyBinanceGiftCardByGiftCardNumberResponseData
{
    [JsonPropertyName("valid")]
    public bool? Valid { get; set; }

    /// <summary>coin</summary>
    [JsonPropertyName("token")]
    public string? Token { get; set; }

    /// <summary>amount</summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }
}
