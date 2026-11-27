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

namespace Binance.MarginTrading.RestApi;

public sealed class QueryIsolatedMarginFeeDataResponseInner
{
    /// <summary>vip Level.</summary>
    [JsonPropertyName("vipLevel")]
    public long? VipLevel { get; set; }

    /// <summary>symbol.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>leverage.</summary>
    [JsonPropertyName("leverage")]
    public string? Leverage { get; set; }

    /// <summary>data list.</summary>
    [JsonPropertyName("data")]
    public List<QueryIsolatedMarginFeeDataResponseInnerDataInner>? Data { get; set; }
}
