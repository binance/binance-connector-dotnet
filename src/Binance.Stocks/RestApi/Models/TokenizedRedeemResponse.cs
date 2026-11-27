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

public sealed class TokenizedRedeemResponse
{
    /// <summary>Server-assigned convert request id. Use it to poll /tokenized/convert-status.</summary>
    [JsonPropertyName("issuerRequestId")]
    public string? IssuerRequestId { get; set; }

    /// <summary>Convert status code: P = processing, S = success, F = failed.</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// The wallet the tokenized asset is settled in: MAIN = Spot wallet, CARD = Funding wallet.
    /// </summary>
    [JsonPropertyName("tokenizedAssetSettleWalletType")]
    public string? TokenizedAssetSettleWalletType { get; set; }
}
