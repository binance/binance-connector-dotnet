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

public sealed class GetCmAccountDetailResponse
{
    /// <summary>Assets.</summary>
    [JsonPropertyName("assets")]
    public List<GetCmAccountDetailResponseAssetsInner>? Assets { get; set; }

    /// <summary>positions of all symbols in the market are returned</summary>
    [JsonPropertyName("positions")]
    public List<GetCmAccountDetailResponsePositionsInner>? Positions { get; set; }
}
