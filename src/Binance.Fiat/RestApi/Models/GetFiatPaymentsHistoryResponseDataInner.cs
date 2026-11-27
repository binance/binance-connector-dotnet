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

public sealed class GetFiatPaymentsHistoryResponseDataInner
{
    [JsonPropertyName("orderNo")]
    public string? OrderNo { get; set; }

    /// <summary>Fiat trade amount</summary>
    [JsonPropertyName("sourceAmount")]
    public string? SourceAmount { get; set; }

    /// <summary>Fiat token</summary>
    [JsonPropertyName("fiatCurrency")]
    public string? FiatCurrency { get; set; }

    /// <summary>Crypto trade amount</summary>
    [JsonPropertyName("obtainAmount")]
    public string? ObtainAmount { get; set; }

    /// <summary>Crypto token</summary>
    [JsonPropertyName("cryptoCurrency")]
    public string? CryptoCurrency { get; set; }

    /// <summary>Trade fee</summary>
    [JsonPropertyName("totalFee")]
    public string? TotalFee { get; set; }

    /// <summary>Price</summary>
    [JsonPropertyName("price")]
    public string? Price { get; set; }

    /// <summary>Processing, Completed, Failed, Refunded</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>Payment method</summary>
    [JsonPropertyName("paymentMethod")]
    public string? PaymentMethod { get; set; }

    /// <summary>Order create time</summary>
    [JsonPropertyName("createTime")]
    public long? CreateTime { get; set; }

    /// <summary>Order update time</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }
}
