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

public sealed class QueryCrossMarginFeeDataResponseInner
{
    /// <summary>vip Level.</summary>
    [JsonPropertyName("vipLevel")]
    public long? VipLevel { get; set; }

    /// <summary>coin.</summary>
    [JsonPropertyName("coin")]
    public string? Coin { get; set; }

    /// <summary>transfer In.</summary>
    [JsonPropertyName("transferIn")]
    public bool? TransferIn { get; set; }

    /// <summary>borrowable.</summary>
    [JsonPropertyName("borrowable")]
    public bool? Borrowable { get; set; }

    /// <summary>daily Interest.</summary>
    [JsonPropertyName("dailyInterest")]
    public string? DailyInterest { get; set; }

    /// <summary>yearly Interest.</summary>
    [JsonPropertyName("yearlyInterest")]
    public string? YearlyInterest { get; set; }

    /// <summary>borrow Limit.</summary>
    [JsonPropertyName("borrowLimit")]
    public string? BorrowLimit { get; set; }

    /// <summary>marginable Pairs list.</summary>
    [JsonPropertyName("marginablePairs")]
    public List<string>? MarginablePairs { get; set; }
}
