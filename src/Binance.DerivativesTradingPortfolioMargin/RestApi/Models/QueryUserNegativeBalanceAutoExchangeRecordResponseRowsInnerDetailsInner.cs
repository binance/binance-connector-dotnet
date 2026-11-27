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

public sealed class QueryUserNegativeBalanceAutoExchangeRecordResponseRowsInnerDetailsInner
{
    /// <summary>asset name</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>negative balance amount</summary>
    [JsonPropertyName("negativeBalance")]
    public decimal? NegativeBalance { get; set; }

    /// <summary>the max negative balance threshold</summary>
    [JsonPropertyName("negativeMaxThreshold")]
    public long? NegativeMaxThreshold { get; set; }
}
