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

public sealed class QueryMarginLoanRecordResponseRowsInner
{
    /// <summary>Tx ID.</summary>
    [JsonPropertyName("txId")]
    public long? TxId { get; set; }

    /// <summary>asset name</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>Principal repaid</summary>
    [JsonPropertyName("principal")]
    public string? Principal { get; set; }

    /// <summary>Timestamp.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; set; }

    /// <summary>
    /// one of PENDING (pending execution), CONFIRMED (successfully loaned), FAILED (execution failed,
    /// nothing happened to your account);
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
