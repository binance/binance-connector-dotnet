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

namespace Binance.Alpha.RestApi;

/// <summary>Exchange metadata, including assets and symbols.</summary>
public sealed class GetExchangeInfoResponseData
{
    /// <summary>Timezone of market data.</summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    /// <summary>Supported assets.</summary>
    [JsonPropertyName("assets")]
    public List<GetExchangeInfoResponseDataAssetsInner>? Assets { get; set; }

    /// <summary>Supported trading symbols.</summary>
    [JsonPropertyName("symbols")]
    public List<GetExchangeInfoResponseDataSymbolsInner>? Symbols { get; set; }

    /// <summary>Order types metadata returned by backend.</summary>
    [JsonPropertyName("orderTypes")]
    public string? OrderTypes { get; set; }
}
