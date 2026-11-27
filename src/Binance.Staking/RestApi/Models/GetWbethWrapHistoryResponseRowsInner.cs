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

namespace Binance.Staking.RestApi;

public sealed class GetWbethWrapHistoryResponseRowsInner
{
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    [JsonPropertyName("fromAsset")]
    public string? FromAsset { get; set; }

    [JsonPropertyName("fromAmount")]
    public string? FromAmount { get; set; }

    [JsonPropertyName("toAsset")]
    public string? ToAsset { get; set; }

    [JsonPropertyName("toAmount")]
    public string? ToAmount { get; set; }

    /// <summary>BETH amount per 1 WBETH</summary>
    [JsonPropertyName("exchangeRate")]
    public string? ExchangeRate { get; set; }

    /// <summary>PENDING,SUCCESS,FAILED</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
