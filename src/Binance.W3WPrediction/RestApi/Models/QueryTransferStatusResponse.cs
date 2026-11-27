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

public sealed class QueryTransferStatusResponse
{
    [JsonPropertyName("transferId")]
    public string? TransferId { get; set; }

    [JsonPropertyName("direction")]
    public string? Direction { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("fromToken")]
    public string? FromToken { get; set; }

    [JsonPropertyName("fromTokenAmount")]
    public string? FromTokenAmount { get; set; }

    [JsonPropertyName("toToken")]
    public string? ToToken { get; set; }

    [JsonPropertyName("toTokenAmount")]
    public string? ToTokenAmount { get; set; }

    [JsonPropertyName("errorCode")]
    public string? ErrorCode { get; set; }

    [JsonPropertyName("errorMessage")]
    public string? ErrorMessage { get; set; }

    [JsonPropertyName("createTime")]
    public string? CreateTime { get; set; }

    [JsonPropertyName("updateTime")]
    public string? UpdateTime { get; set; }
}
