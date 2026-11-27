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

public sealed class BatchRedeemResponseResultsInner
{
    [JsonPropertyName("requestId")]
    public string? RequestId { get; set; }

    [JsonPropertyName("txHash")]
    public string? TxHash { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("error")]
    public string? Error { get; set; }
}
