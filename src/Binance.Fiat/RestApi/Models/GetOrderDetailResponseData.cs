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

namespace Binance.Fiat.RestApi;

public sealed class GetOrderDetailResponseData
{
    /// <summary>Order id</summary>
    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

    /// <summary>Order status</summary>
    [JsonPropertyName("orderStatus")]
    public string? OrderStatus { get; set; }

    /// <summary>Order amount</summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>Trade fee</summary>
    [JsonPropertyName("fee")]
    public string? Fee { get; set; }

    /// <summary>Fiat token</summary>
    [JsonPropertyName("fiatCurrency")]
    public string? FiatCurrency { get; set; }

    /// <summary>Error code if any</summary>
    [JsonPropertyName("errorCode")]
    public string? ErrorCode { get; set; }

    /// <summary>Error message if any</summary>
    [JsonPropertyName("errorMessage")]
    public string? ErrorMessage { get; set; }

    /// <summary>Extra info</summary>
    [JsonPropertyName("ext")]
    public JsonElement? Ext { get; set; }
}
