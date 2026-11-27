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

public sealed class GetPortfolioResponsePositionsInner
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("walletAddress")]
    public string? WalletAddress { get; set; }

    [JsonPropertyName("marketTopicId")]
    public long? MarketTopicId { get; set; }

    [JsonPropertyName("marketId")]
    public long? MarketId { get; set; }

    [JsonPropertyName("tokenId")]
    public string? TokenId { get; set; }

    [JsonPropertyName("vendor")]
    public string? Vendor { get; set; }

    [JsonPropertyName("currentShares")]
    public string? CurrentShares { get; set; }

    [JsonPropertyName("avgPrice")]
    public string? AvgPrice { get; set; }

    [JsonPropertyName("currentPrice")]
    public string? CurrentPrice { get; set; }

    [JsonPropertyName("realizedPnl")]
    public string? RealizedPnl { get; set; }

    [JsonPropertyName("unrealizedPnl")]
    public string? UnrealizedPnl { get; set; }

    [JsonPropertyName("totalPnl")]
    public string? TotalPnl { get; set; }

    [JsonPropertyName("pnlPercentage")]
    public string? PnlPercentage { get; set; }

    [JsonPropertyName("isResolved")]
    public bool? IsResolved { get; set; }
}
