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

namespace Binance.DerivativesTradingCoinFutures.RestApi;

public sealed class GetOrderModifyHistoryResponseInner
{
    /// <summary>Order modification ID</summary>
    [JsonPropertyName("amendmentId")]
    public long? AmendmentId { get; set; }

    /// <summary>Trading symbol</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Pair</summary>
    [JsonPropertyName("pair")]
    public string? Pair { get; set; }

    /// <summary>Sub-order ID</summary>
    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    /// <summary>Client order ID.</summary>
    [JsonPropertyName("clientOrderId")]
    public string? ClientOrderId { get; set; }

    /// <summary>Time</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    [JsonPropertyName("amendment")]
    public GetOrderModifyHistoryResponseInnerAmendment? Amendment { get; set; }
}
