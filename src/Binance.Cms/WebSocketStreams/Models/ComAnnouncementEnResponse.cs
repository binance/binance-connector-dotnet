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

namespace Binance.Cms.WebSocketStreams;

public sealed class ComAnnouncementEnResponse
{
    /// <summary>Catalog ID</summary>
    [JsonPropertyName("catalogId")]
    public long? CatalogId { get; set; }

    /// <summary>Catalog Name</summary>
    [JsonPropertyName("catalogName")]
    public string? CatalogName { get; set; }

    /// <summary>Publish timestamp (milliseconds)</summary>
    [JsonPropertyName("publishDate")]
    public long? PublishDate { get; set; }

    /// <summary>Announcement title</summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>Announcement body</summary>
    [JsonPropertyName("body")]
    public string? Body { get; set; }

    /// <summary>Disclaimer</summary>
    [JsonPropertyName("disclaimer")]
    public string? Disclaimer { get; set; }
}
