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

namespace Binance.DualInvestment.RestApi;

public sealed class GetDualInvestmentProductListResponse
{
    [JsonPropertyName("total")]
    public long? Total { get; set; }

    [JsonPropertyName("list")]
    public List<GetDualInvestmentProductListResponseListInner>? List { get; set; }
}
