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

public sealed class ListOtcBlocktradesResponseBlocktradesInner
{
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("marketId")]
    public string? MarketId { get; set; }

    [JsonPropertyName("tokenId")]
    public string? TokenId { get; set; }

    /// <summary>
    /// 0 = BUY (Bid), 1 = SELL (Ask) — see Create OTC Blocktrade for the side/quoteType mapping
    /// </summary>
    [JsonPropertyName("side")]
    public long? Side { get; set; }

    [JsonPropertyName("maker")]
    public string? Maker { get; set; }

    [JsonPropertyName("makerAmount")]
    public string? MakerAmount { get; set; }

    [JsonPropertyName("takerAmount")]
    public string? TakerAmount { get; set; }

    [JsonPropertyName("price")]
    public decimal? Price { get; set; }

    [JsonPropertyName("quoteType")]
    public string? QuoteType { get; set; }

    [JsonPropertyName("createdAt")]
    public string? CreatedAt { get; set; }

    [JsonPropertyName("secretToken")]
    public string? SecretToken { get; set; }
}
