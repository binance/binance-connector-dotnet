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

public sealed class MiningAccountEarningResponseDataAccountProfitsInner
{
    /// <summary>Time</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    /// <summary>Coin</summary>
    [JsonPropertyName("coinName")]
    public string? CoinName { get; set; }

    /// <summary>0: Referral, 1: Refund, 2: Rebate</summary>
    [JsonPropertyName("type")]
    public long? Type { get; set; }

    /// <summary>Mining sub-account ID</summary>
    [JsonPropertyName("puid")]
    public long? Puid { get; set; }

    /// <summary>Mining account</summary>
    [JsonPropertyName("subName")]
    public string? SubName { get; set; }

    /// <summary>Amount</summary>
    [JsonPropertyName("amount")]
    public decimal? Amount { get; set; }
}
