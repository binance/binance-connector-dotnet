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

namespace Binance.SimpleEarn.RestApi;

public sealed class GetRwusdQuotaDetailsResponse
{
    [JsonPropertyName("subscriptionQuota")]
    public GetRwusdQuotaDetailsResponseSubscriptionQuota? SubscriptionQuota { get; set; }

    [JsonPropertyName("fastRedemptionQuota")]
    public GetRwusdQuotaDetailsResponseFastRedemptionQuota? FastRedemptionQuota { get; set; }

    [JsonPropertyName("standardRedemptionQuota")]
    public GetRwusdQuotaDetailsResponseStandardRedemptionQuota? StandardRedemptionQuota { get; set; }

    [JsonPropertyName("subscribeEnable")]
    public bool? SubscribeEnable { get; set; }

    [JsonPropertyName("redeemEnable")]
    public bool? RedeemEnable { get; set; }
}
