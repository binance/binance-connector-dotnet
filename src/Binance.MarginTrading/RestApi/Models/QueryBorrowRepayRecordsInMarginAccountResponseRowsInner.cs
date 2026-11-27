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

public sealed class QueryBorrowRepayRecordsInMarginAccountResponseRowsInner
{
    /// <summary>
    /// AUTO,MANUAL for Cross Margin Borrow; MANUAL，AUTO，BNB_AUTO_REPAY，POINT_AUTO_REPAY for Cross Margin
    /// Repay; AUTO，MANUAL for Isolated Margin Borrow/Repay;
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>isolated symbol, will not be returned for crossed margin</summary>
    [JsonPropertyName("isolatedSymbol")]
    public string? IsolatedSymbol { get; set; }

    /// <summary>Total amount borrowed/repaid</summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>asset.</summary>
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
    /// nothing happened to your account);
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>timestamp.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; set; }

    /// <summary>tx Id.</summary>
    [JsonPropertyName("txId")]
    public long? TxId { get; set; }
}
