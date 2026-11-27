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

namespace Binance.Wallet.RestApi;

public sealed class GetCountryListResponse
{
    [JsonPropertyName("countries")]
    public List<GetCountryListResponseCountriesInner>? Countries { get; set; }

    /// <summary>Last data update timestamp (epoch milliseconds); 0 if empty.</summary>
    [JsonPropertyName("lastUpdated")]
    public long? LastUpdated { get; set; }
}
