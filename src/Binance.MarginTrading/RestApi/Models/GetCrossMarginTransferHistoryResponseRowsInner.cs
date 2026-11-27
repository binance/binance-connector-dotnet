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

public sealed class GetCrossMarginTransferHistoryResponseRowsInner
{
    /// <summary>amount.</summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>asset.</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>status.</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>timestamp.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; set; }

    /// <summary>tx Id.</summary>
    [JsonPropertyName("txId")]
    public long? TxId { get; set; }

    /// <summary>type.</summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// SPOT,FUTURES,FIAT,DELIVERY,MINING,ISOLATED_MARGIN,FUNDING,MOTHER_SPOT,OPTION,SUB_SPOT,SUB_MARGIN,CROSS_MARGIN
    /// </summary>
    [JsonPropertyName("transFrom")]
    public string? TransFrom { get; set; }

    /// <summary>
    /// SPOT,FUTURES,FIAT,DELIVERY,MINING,ISOLATED_MARGIN,FUNDING,MOTHER_SPOT,OPTION,SUB_SPOT,SUB_MARGIN,CROSS_MARGIN
    /// </summary>
    [JsonPropertyName("transTo")]
    public string? TransTo { get; set; }

    /// <summary>from Symbol.</summary>
    [JsonPropertyName("fromSymbol")]
    public string? FromSymbol { get; set; }

    /// <summary>to Symbol.</summary>
    [JsonPropertyName("toSymbol")]
    public string? ToSymbol { get; set; }
}
