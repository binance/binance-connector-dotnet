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

public sealed class QueryCrossIsolatedMarginCapitalFlowResponseInner
{
    /// <summary>id.</summary>
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    /// <summary>tran Id.</summary>
    [JsonPropertyName("tranId")]
    public long? TranId { get; set; }

    /// <summary>timestamp.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; set; }

    /// <summary>asset.</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>symbol.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>type.</summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>amount.</summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>note.</summary>
    [JsonPropertyName("note")]
    public string? Note { get; set; }
}
