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

namespace Binance.C2C.RestApi;

public sealed class GetC2CTradeHistoryResponseDataInner
{
    /// <summary>Order Number</summary>
    [JsonPropertyName("orderNumber")]
    public string? OrderNumber { get; set; }

    /// <summary>Adv Number</summary>
    [JsonPropertyName("advNo")]
    public string? AdvNo { get; set; }

    /// <summary>"BUY" or "SELL"</summary>
    [JsonPropertyName("tradeType")]
    public string? TradeType { get; set; }

    /// <summary>Crypto asset</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>Fiat currency</summary>
    [JsonPropertyName("fiat")]
    public string? Fiat { get; set; }

    /// <summary>Fiat currency symbol</summary>
    [JsonPropertyName("fiatSymbol")]
    public string? FiatSymbol { get; set; }

    /// <summary>Quantity (in Crypto)</summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>Total order amount in fiat</summary>
    [JsonPropertyName("totalPrice")]
    public string? TotalPrice { get; set; }

    /// <summary>Unit Price (in Fiat)</summary>
    [JsonPropertyName("unitPrice")]
    public string? UnitPrice { get; set; }

    /// <summary>
    /// PENDING, TRADING, BUYER_PAYED, DISTRIBUTING, COMPLETED, IN_APPEAL, CANCELLED, CANCELLED_BY_SYSTEM
    /// </summary>
    [JsonPropertyName("orderStatus")]
    public string? OrderStatus { get; set; }

    /// <summary>Order creation timestamp in milliseconds</summary>
    [JsonPropertyName("createTime")]
    public long? CreateTime { get; set; }

    /// <summary>Transaction Fee (in Crypto)</summary>
    [JsonPropertyName("commission")]
    public string? Commission { get; set; }

    /// <summary>Counterparty nickname</summary>
    [JsonPropertyName("counterPartNickName")]
    public string? CounterPartNickName { get; set; }

    /// <summary>Identifier of the payment method</summary>
    [JsonPropertyName("payMethodName")]
    public string? PayMethodName { get; set; }

    /// <summary>KYC verification status. 0: not required, 1: not verified, 2: verified</summary>
    [JsonPropertyName("additionalKycVerify")]
    public long? AdditionalKycVerify { get; set; }

    /// <summary>Taker commission rate</summary>
    [JsonPropertyName("takerCommissionRate")]
    public string? TakerCommissionRate { get; set; }

    /// <summary>Taker commission amount</summary>
    [JsonPropertyName("takerCommission")]
    public string? TakerCommission { get; set; }

    /// <summary>Taker trade amount</summary>
    [JsonPropertyName("takerAmount")]
    public string? TakerAmount { get; set; }

    [JsonPropertyName("advertisementRole")]
    public string? AdvertisementRole { get; set; }
}
