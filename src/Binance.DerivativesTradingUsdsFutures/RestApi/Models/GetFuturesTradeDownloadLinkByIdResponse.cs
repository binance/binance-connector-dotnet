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

public sealed class GetFuturesTradeDownloadLinkByIdResponse
{
    /// <summary>Download Id.</summary>
    [JsonPropertyName("downloadId")]
    public string? DownloadId { get; set; }

    /// <summary>Enum：completed，processing</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>The link is mapped to download id</summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>ignore</summary>
    [JsonPropertyName("notified")]
    public bool? Notified { get; set; }

    /// <summary>The link would expire after this timestamp</summary>
    [JsonPropertyName("expirationTimestamp")]
    public long? ExpirationTimestamp { get; set; }

    [JsonPropertyName("isExpired")]
    public string? IsExpired { get; set; }
}
