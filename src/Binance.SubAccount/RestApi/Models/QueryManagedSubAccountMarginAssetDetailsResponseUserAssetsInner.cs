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

public sealed class QueryManagedSubAccountMarginAssetDetailsResponseUserAssetsInner
{
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    [JsonPropertyName("borrowed")]
    public string? Borrowed { get; set; }

    [JsonPropertyName("free")]
    public string? Free { get; set; }

    [JsonPropertyName("interest")]
    public string? Interest { get; set; }

    [JsonPropertyName("locked")]
    public string? Locked { get; set; }

    [JsonPropertyName("netAsset")]
    public string? NetAsset { get; set; }
}
