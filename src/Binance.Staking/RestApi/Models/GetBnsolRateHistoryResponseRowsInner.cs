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

namespace Binance.Staking.RestApi;

public sealed class GetBnsolRateHistoryResponseRowsInner
{
    /// <summary>BNSOL APR</summary>
    [JsonPropertyName("annualPercentageRate")]
    public string? AnnualPercentageRate { get; set; }

    /// <summary>SOL amount per 1 BNSOL</summary>
    [JsonPropertyName("exchangeRate")]
    public string? ExchangeRate { get; set; }

    [JsonPropertyName("boostRewards")]
    public List<GetBnsolRateHistoryResponseRowsInnerBoostRewardsInner>? BoostRewards { get; set; }

    [JsonPropertyName("time")]
    public long? Time { get; set; }
}
