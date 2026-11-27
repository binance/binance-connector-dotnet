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

namespace Binance.Fiat.RestApi;

public sealed class GetFiatPaymentsHistoryResponse
{
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("data")]
    public List<GetFiatPaymentsHistoryResponseDataInner>? Data { get; set; }

    [JsonPropertyName("total")]
    public long? Total { get; set; }

    [JsonPropertyName("success")]
    public bool? Success { get; set; }
}
