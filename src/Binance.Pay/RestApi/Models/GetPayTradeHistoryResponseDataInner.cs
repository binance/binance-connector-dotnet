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

namespace Binance.Pay.RestApi;

public sealed class GetPayTradeHistoryResponseDataInner
{
    /// <summary>
    /// Order type. Enum: PAY, PAY_REFUND, C2C, CRYPTO_BOX, CRYPTO_BOX_RF, C2C_HOLDING, C2C_HOLDING_RF,
    /// PAYOUT, REMITTANCE.
    /// </summary>
    [JsonPropertyName("orderType")]
    public string? OrderType { get; set; }

    /// <summary>Transaction ID.</summary>
    [JsonPropertyName("transactionId")]
    public string? TransactionId { get; set; }

    /// <summary>Trade timestamp.</summary>
    [JsonPropertyName("transactionTime")]
    public long? TransactionTime { get; set; }

    /// <summary>
    /// Order amount (up to 8 decimal places). Positive means income; negative means expenditure.
    /// </summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>Order asset.</summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    /// <summary>
    /// Main wallet type: 1=funding wallet, 2=spot wallet, 3=fiat wallet, 4 or 6=card payment, 5=earn
    /// wallet.
    /// </summary>
    [JsonPropertyName("walletType")]
    public long? WalletType { get; set; }

    /// <summary>Array format of wallet types. Multiple values may appear for combined payments.</summary>
    [JsonPropertyName("walletTypes")]
    public List<long>? WalletTypes { get; set; }

    /// <summary>Funds usage details.</summary>
    [JsonPropertyName("fundsDetail")]
    public List<GetPayTradeHistoryResponseDataInnerFundsDetailInner>? FundsDetail { get; set; }

    [JsonPropertyName("payerInfo")]
    public GetPayTradeHistoryResponseDataInnerPayerInfo? PayerInfo { get; set; }

    [JsonPropertyName("receiverInfo")]
    public GetPayTradeHistoryResponseDataInnerReceiverInfo? ReceiverInfo { get; set; }
}
