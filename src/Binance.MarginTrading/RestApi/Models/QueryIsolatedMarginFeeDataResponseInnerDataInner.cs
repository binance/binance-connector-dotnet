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

public sealed class QueryIsolatedMarginFeeDataResponseInnerDataInner
{
    /// <summary>coin.</summary>
    [JsonPropertyName("coin")]
    public string? Coin { get; set; }

    /// <summary>daily Interest.</summary>
    [JsonPropertyName("dailyInterest")]
    public string? DailyInterest { get; set; }

    /// <summary>borrow Limit.</summary>
    [JsonPropertyName("borrowLimit")]
    public string? BorrowLimit { get; set; }
}
