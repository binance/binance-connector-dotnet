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

public sealed class GetFuturesPositionRiskOfSubAccountV2Response
{
    [JsonPropertyName("futurePositionRiskVos")]
    public List<GetFuturesPositionRiskOfSubAccountResponseInner>? FuturePositionRiskVos { get; set; }

    [JsonPropertyName("deliveryPositionRiskVos")]
    public List<GetFuturesPositionRiskOfSubAccountV2ResponseDeliveryPositionRiskVosInner>? DeliveryPositionRiskVos { get; set; }
}
