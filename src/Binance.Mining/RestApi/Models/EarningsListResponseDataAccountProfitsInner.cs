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

public sealed class EarningsListResponseDataAccountProfitsInner
{
    /// <summary>Mining date</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    /// <summary>
    /// 0: Mining Wallet, 5: Mining Address, 7: Pool Savings, 8: Transferred, 31: Income Transfer, 32:
    /// Hashrate Resale-Mining Wallet, 33: Hashrate Resale-Pool Savings
    /// </summary>
    [JsonPropertyName("type")]
    public long? Type { get; set; }

    /// <summary>Transferred hashrate</summary>
    [JsonPropertyName("hashTransfer")]
    public long? HashTransfer { get; set; }

    /// <summary>Transferred income</summary>
    [JsonPropertyName("transferAmount")]
    public decimal? TransferAmount { get; set; }

    /// <summary>Daily hashrate</summary>
    [JsonPropertyName("dayHashRate")]
    public long? DayHashRate { get; set; }

    /// <summary>Earnings amount</summary>
    [JsonPropertyName("profitAmount")]
    public decimal? ProfitAmount { get; set; }

    /// <summary>Coin type</summary>
    [JsonPropertyName("coinName")]
    public string? CoinName { get; set; }

    /// <summary>Status: 0 Unpaid, 1 Paying, 2 Paid</summary>
    [JsonPropertyName("status")]
    public long? Status { get; set; }
}
