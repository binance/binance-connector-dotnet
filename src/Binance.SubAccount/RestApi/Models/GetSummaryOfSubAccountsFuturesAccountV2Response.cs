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

namespace Binance.SubAccount.RestApi;

public sealed class GetSummaryOfSubAccountsFuturesAccountV2Response
{
    [JsonPropertyName("futureAccountSummaryResp")]
    public GetSummaryOfSubAccountsFuturesAccountV2ResponseFutureAccountSummaryResp? FutureAccountSummaryResp { get; set; }

    [JsonPropertyName("deliveryAccountSummaryResp")]
    public GetSummaryOfSubAccountsFuturesAccountV2ResponseDeliveryAccountSummaryResp? DeliveryAccountSummaryResp { get; set; }
}
