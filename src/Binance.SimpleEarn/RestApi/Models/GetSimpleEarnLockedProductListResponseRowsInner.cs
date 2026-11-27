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

public sealed class GetSimpleEarnLockedProductListResponseRowsInner
{
    [JsonPropertyName("projectId")]
    public string? ProjectId { get; set; }

    [JsonPropertyName("detail")]
    public GetSimpleEarnLockedProductListResponseRowsInnerDetail? Detail { get; set; }

    [JsonPropertyName("quota")]
    public GetSimpleEarnLockedProductListResponseRowsInnerQuota? Quota { get; set; }
}
