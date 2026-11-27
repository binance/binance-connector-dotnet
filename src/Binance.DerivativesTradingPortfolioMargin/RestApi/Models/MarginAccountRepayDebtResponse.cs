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

namespace Binance.DerivativesTradingPortfolioMargin.RestApi;

public sealed class MarginAccountRepayDebtResponse
{
    /// <summary>Amount repaid</summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>asset name</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>Specify Repay Assets.</summary>
    [JsonPropertyName("specifyRepayAssets")]
    public List<string>? SpecifyRepayAssets { get; set; }

    /// <summary>last update time</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }

    /// <summary>Success.</summary>
    [JsonPropertyName("success")]
    public bool? Success { get; set; }
}
