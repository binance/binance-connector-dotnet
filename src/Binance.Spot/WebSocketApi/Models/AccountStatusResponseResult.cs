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

namespace Binance.Spot.WebSocketApi;

public sealed class AccountStatusResponseResult
{
    [JsonPropertyName("makerCommission")]
    public long? MakerCommission { get; set; }

    [JsonPropertyName("takerCommission")]
    public long? TakerCommission { get; set; }

    [JsonPropertyName("buyerCommission")]
    public long? BuyerCommission { get; set; }

    [JsonPropertyName("sellerCommission")]
    public long? SellerCommission { get; set; }

    [JsonPropertyName("canTrade")]
    public bool? CanTrade { get; set; }

    [JsonPropertyName("canWithdraw")]
    public bool? CanWithdraw { get; set; }

    [JsonPropertyName("canDeposit")]
    public bool? CanDeposit { get; set; }

    [JsonPropertyName("commissionRates")]
    public AccountStatusResponseResultCommissionRates? CommissionRates { get; set; }

    [JsonPropertyName("brokered")]
    public bool? Brokered { get; set; }

    [JsonPropertyName("requireSelfTradePrevention")]
    public bool? RequireSelfTradePrevention { get; set; }

    [JsonPropertyName("preventSor")]
    public bool? PreventSor { get; set; }

    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }

    [JsonPropertyName("accountType")]
    public string? AccountType { get; set; }

    [JsonPropertyName("balances")]
    public List<AccountStatusResponseResultBalancesInner>? Balances { get; set; }

    [JsonPropertyName("permissions")]
    public List<string>? Permissions { get; set; }

    [JsonPropertyName("uid")]
    public long? Uid { get; set; }
}
