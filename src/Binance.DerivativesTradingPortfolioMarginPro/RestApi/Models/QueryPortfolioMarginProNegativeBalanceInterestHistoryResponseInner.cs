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

namespace Binance.DerivativesTradingPortfolioMarginPro.RestApi;

public sealed class QueryPortfolioMarginProNegativeBalanceInterestHistoryResponseInner
{
    /// <summary>asset.</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>interest amount</summary>
    [JsonPropertyName("interest")]
    public string? Interest { get; set; }

    /// <summary>interest Accrued Time.</summary>
    [JsonPropertyName("interestAccruedTime")]
    public long? InterestAccruedTime { get; set; }

    /// <summary>daily interest rate</summary>
    [JsonPropertyName("interestRate")]
    public string? InterestRate { get; set; }

    /// <summary>principal.</summary>
    [JsonPropertyName("principal")]
    public string? Principal { get; set; }
}
