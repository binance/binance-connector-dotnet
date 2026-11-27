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

namespace Binance.Stocks.RestApi;

/// <summary>Empty object {} when no record matches.</summary>
public sealed class TokenizedConvertStatusResponse
{
    /// <summary>Underlying US-equity ticker, e.g. AAPL.</summary>
    [JsonPropertyName("underlyingAsset")]
    public string? UnderlyingAsset { get; set; }

    /// <summary>Quantity of the underlying asset involved.</summary>
    [JsonPropertyName("underlyingAssetAmount")]
    public string? UnderlyingAssetAmount { get; set; }

    /// <summary>Tokenized asset, e.g. AAPLB.</summary>
    [JsonPropertyName("tokenizedAsset")]
    public string? TokenizedAsset { get; set; }

    /// <summary>Quantity of the tokenized asset involved.</summary>
    [JsonPropertyName("tokenizedAssetAmount")]
    public string? TokenizedAssetAmount { get; set; }

    /// <summary>Echoes the requested id.</summary>
    [JsonPropertyName("issuerRequestId")]
    public string? IssuerRequestId { get; set; }

    /// <summary>MINT or REDEEM.</summary>
    [JsonPropertyName("convertType")]
    public string? ConvertType { get; set; }

    /// <summary>Convert status: P = processing, S = success, F = failed.</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>Creation time (ms epoch).</summary>
    [JsonPropertyName("createdAt")]
    public long? CreatedAt { get; set; }

    /// <summary>Last update time (ms epoch).</summary>
    [JsonPropertyName("updatedAt")]
    public long? UpdatedAt { get; set; }

    /// <summary>
    /// The wallet the tokenized asset is settled in: MAIN = Spot wallet, CARD = Funding wallet.
    /// </summary>
    [JsonPropertyName("tokenizedAssetSettleWalletType")]
    public string? TokenizedAssetSettleWalletType { get; set; }
}
