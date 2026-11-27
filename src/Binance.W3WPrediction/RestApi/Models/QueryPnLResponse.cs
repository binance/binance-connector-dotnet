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

public sealed class QueryPnLResponse
{
    [JsonPropertyName("chainId")]
    public string? ChainId { get; set; }

    [JsonPropertyName("walletAddress")]
    public string? WalletAddress { get; set; }

    [JsonPropertyName("pnl")]
    public JsonElement? Pnl { get; set; }

    [JsonPropertyName("pnlList")]
    public List<GetPortfolioResponsePositionsInner>? PnlList { get; set; }

    [JsonPropertyName("totalCount")]
    public long? TotalCount { get; set; }

    [JsonPropertyName("totalRealizedPnl")]
    public string? TotalRealizedPnl { get; set; }

    [JsonPropertyName("totalUnrealizedPnl")]
    public string? TotalUnrealizedPnl { get; set; }

    [JsonPropertyName("totalPnl")]
    public string? TotalPnl { get; set; }
}
