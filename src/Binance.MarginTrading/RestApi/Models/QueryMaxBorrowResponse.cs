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

public sealed class QueryMaxBorrowResponse
{
    /// <summary>account's currently max borrowable amount with sufficient system availability</summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>max borrowable amount limited by the account level</summary>
    [JsonPropertyName("borrowLimit")]
    public string? BorrowLimit { get; set; }
}
