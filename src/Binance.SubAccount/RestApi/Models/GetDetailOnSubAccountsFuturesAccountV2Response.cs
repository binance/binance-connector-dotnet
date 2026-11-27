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

public sealed class GetDetailOnSubAccountsFuturesAccountV2Response
{
    [JsonPropertyName("futureAccountResp")]
    public GetDetailOnSubAccountsFuturesAccountV2ResponseFutureAccountResp? FutureAccountResp { get; set; }

    [JsonPropertyName("deliveryAccountResp")]
    public GetDetailOnSubAccountsFuturesAccountV2ResponseDeliveryAccountResp? DeliveryAccountResp { get; set; }
}
