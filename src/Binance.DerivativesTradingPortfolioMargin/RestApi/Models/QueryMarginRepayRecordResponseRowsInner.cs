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

namespace Binance.DerivativesTradingPortfolioMargin.RestApi;

public sealed class QueryMarginRepayRecordResponseRowsInner
{
    /// <summary>Total amount repaid</summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>asset name</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>Interest repaid</summary>
    [JsonPropertyName("interest")]
    public string? Interest { get; set; }

    /// <summary>Principal repaid</summary>
    [JsonPropertyName("principal")]
    public string? Principal { get; set; }

    /// <summary>
    /// one of PENDING (pending execution), CONFIRMED (successfully execution), FAILED (execution failed,
    /// nothing happened to your account)
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>Timestamp.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; set; }

    /// <summary>Tx ID.</summary>
    [JsonPropertyName("txId")]
    public long? TxId { get; set; }
}
