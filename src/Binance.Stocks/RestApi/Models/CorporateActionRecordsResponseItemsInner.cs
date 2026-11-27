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

namespace Binance.Stocks.RestApi;

public sealed class CorporateActionRecordsResponseItemsInner
{
    /// <summary>Unique record ID.</summary>
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    /// <summary>User ID.</summary>
    [JsonPropertyName("userId")]
    public long? UserId { get; set; }

    /// <summary>
    /// Asset code, the unique identifier of the stock in the system, for example EQ_AAPL. Currently all
    /// asset codes carry the EQ_ prefix.
    /// </summary>
    [JsonPropertyName("assetCode")]
    public string? AssetCode { get; set; }

    /// <summary>
    /// Corporate action event type. Values include CASH_DIVIDEND, STOCK_DIVIDEND, FORWARD_SPLIT,
    /// REVERSE_SPLIT, SPIN_OFF, CASH_MERGER, STOCK_MERGER, STOCK_AND_CASH_MERGER, WORTHLESS_REMOVAL,
    /// NAME_CHANGE and RIGHTS_DISTRIBUTION.
    /// </summary>
    [JsonPropertyName("eventType")]
    public string? EventType { get; set; }

    /// <summary>Signed change of the asset quantity, including free and frozen balances.</summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>Last modification time (ms epoch).</summary>
    [JsonPropertyName("dbModifyTime")]
    public long? DbModifyTime { get; set; }
}
