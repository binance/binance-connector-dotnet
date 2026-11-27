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

public sealed class GetFiatDepositWithdrawHistoryResponseDataInner
{
    [JsonPropertyName("orderNo")]
    public string? OrderNo { get; set; }

    /// <summary>Fiat token</summary>
    [JsonPropertyName("fiatCurrency")]
    public string? FiatCurrency { get; set; }

    /// <summary>Trade amount</summary>
    [JsonPropertyName("indicatedAmount")]
    public string? IndicatedAmount { get; set; }

    /// <summary>Actual amount (after fee deduction)</summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>Trade fee</summary>
    [JsonPropertyName("totalFee")]
    public string? TotalFee { get; set; }

    /// <summary>Trade method</summary>
    [JsonPropertyName("method")]
    public string? Method { get; set; }

    /// <summary>
    /// Processing, Failed, Successful, Finished, Refunding, Refunded, Refund Failed, Order Partial Credit
    /// Stopped
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>Order create time</summary>
    [JsonPropertyName("createTime")]
    public long? CreateTime { get; set; }

    /// <summary>Order update time</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }
}
