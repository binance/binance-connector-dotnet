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

namespace Binance.Spot.WebSocketStreams;

public sealed class ListStatus
{
    /// <summary>Event Time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>OrderListId</summary>
    [JsonPropertyName("g")]
    public long? G { get; set; }

    /// <summary>Contingency Type</summary>
    [JsonPropertyName("c")]
    public string? C { get; set; }

    /// <summary>List Status Type</summary>
    [JsonPropertyName("l")]
    public string? L { get; set; }

    /// <summary>List Order Status</summary>
    [JsonPropertyName("L")]
    public string? LUppercase { get; set; }

    /// <summary>List Reject Reason</summary>
    [JsonPropertyName("r")]
    public string? R { get; set; }

    /// <summary>List Client Order ID</summary>
    [JsonPropertyName("C")]
    public string? CUppercase { get; set; }

    /// <summary>Transaction Time</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>An array of objects</summary>
    [JsonPropertyName("O")]
    public List<ListStatusOInner>? OUppercase { get; set; }
}
