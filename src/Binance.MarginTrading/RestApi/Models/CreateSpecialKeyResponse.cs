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

public sealed class CreateSpecialKeyResponse
{
    /// <summary>api Key.</summary>
    [JsonPropertyName("apiKey")]
    public string? ApiKey { get; set; }

    /// <summary>secretKey will be null when creating an RSA key</summary>
    [JsonPropertyName("secretKey")]
    public string? SecretKey { get; set; }

    /// <summary>HMAC_SHA256 or RSA</summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }
}
