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

namespace Binance.W3WPrediction.RestApi;

public sealed class GetPortfolioResponse
{
    [JsonPropertyName("chainId")]
    public string? ChainId { get; set; }

    [JsonPropertyName("walletAddress")]
    public string? WalletAddress { get; set; }

    [JsonPropertyName("activePositionsCount")]
    public long? ActivePositionsCount { get; set; }

    [JsonPropertyName("totalRealizedPnl")]
    public string? TotalRealizedPnl { get; set; }

    [JsonPropertyName("totalUnrealizedPnl")]
    public string? TotalUnrealizedPnl { get; set; }

    [JsonPropertyName("totalPnl")]
    public string? TotalPnl { get; set; }

    [JsonPropertyName("totalCostBasis")]
    public string? TotalCostBasis { get; set; }

    [JsonPropertyName("totalCurrentValue")]
    public string? TotalCurrentValue { get; set; }

    [JsonPropertyName("positions")]
    public List<GetPortfolioResponsePositionsInner>? Positions { get; set; }
}
