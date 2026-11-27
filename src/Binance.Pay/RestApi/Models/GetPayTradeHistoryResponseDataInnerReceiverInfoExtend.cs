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

/// <summary>Extension fields.</summary>
public sealed class GetPayTradeHistoryResponseDataInnerReceiverInfoExtend
{
    /// <summary>Bank name or digital wallet name.</summary>
    [JsonPropertyName("institutionName")]
    public string? InstitutionName { get; set; }

    /// <summary>Card number.</summary>
    [JsonPropertyName("cardNumber")]
    public string? CardNumber { get; set; }

    /// <summary>Digital wallet ID.</summary>
    [JsonPropertyName("digitalWalletId")]
    public string? DigitalWalletId { get; set; }
}
