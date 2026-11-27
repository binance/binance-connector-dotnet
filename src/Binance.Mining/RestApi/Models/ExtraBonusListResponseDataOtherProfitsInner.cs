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

namespace Binance.Mining.RestApi;

public sealed class ExtraBonusListResponseDataOtherProfitsInner
{
    /// <summary>Mining date</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    /// <summary>Coin name</summary>
    [JsonPropertyName("coinName")]
    public string? CoinName { get; set; }

    /// <summary>
    /// 1: Merged Mining, 2: Activity Bonus, 3: Rebate, 4: Smart Pool, 6: Income Transfer, 7: Pool Savings
    /// </summary>
    [JsonPropertyName("type")]
    public long? Type { get; set; }

    /// <summary>Amount</summary>
    [JsonPropertyName("profitAmount")]
    public decimal? ProfitAmount { get; set; }

    /// <summary>Status: 0 Unpaid, 1 Paying, 2 Paid</summary>
    [JsonPropertyName("status")]
    public long? Status { get; set; }
}
