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

public sealed class SubscribeSolStakingResponse
{
    [JsonPropertyName("success")]
    public bool? Success { get; set; }

    [JsonPropertyName("bnsolAmount")]
    public string? BnsolAmount { get; set; }

    [JsonPropertyName("purchaseId")]
    public long? PurchaseId { get; set; }

    /// <summary>SOL amount per 1 BNSOL</summary>
    [JsonPropertyName("exchangeRate")]
    public string? ExchangeRate { get; set; }
}
