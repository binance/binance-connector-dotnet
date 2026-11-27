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

public sealed class GetBfusdQuotaDetailsResponse
{
    [JsonPropertyName("subscriptionQuota")]
    public GetBfusdQuotaDetailsResponseSubscriptionQuota? SubscriptionQuota { get; set; }

    [JsonPropertyName("fastRedemptionQuota")]
    public GetBfusdQuotaDetailsResponseFastRedemptionQuota? FastRedemptionQuota { get; set; }

    [JsonPropertyName("standardRedemptionQuota")]
    public GetBfusdQuotaDetailsResponseStandardRedemptionQuota? StandardRedemptionQuota { get; set; }
}
