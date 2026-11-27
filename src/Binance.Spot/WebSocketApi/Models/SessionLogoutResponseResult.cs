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

namespace Binance.Spot.WebSocketApi;

public sealed class SessionLogoutResponseResult
{
    [JsonPropertyName("apiKey")]
    public string? ApiKey { get; set; }

    [JsonPropertyName("authorizedSince")]
    public long? AuthorizedSince { get; set; }

    [JsonPropertyName("connectedSince")]
    public long? ConnectedSince { get; set; }

    [JsonPropertyName("returnRateLimits")]
    public bool? ReturnRateLimits { get; set; }

    [JsonPropertyName("serverTime")]
    public long? ServerTime { get; set; }

    /// <summary>Is User Data Stream subscription active?</summary>
    [JsonPropertyName("userDataStream")]
    public bool? UserDataStream { get; set; }
}
