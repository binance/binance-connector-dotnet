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

public sealed class QueryCrossMarginAccountDetailsResponseUserAssetsInner
{
    /// <summary>asset.</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>borrowed.</summary>
    [JsonPropertyName("borrowed")]
    public string? Borrowed { get; set; }

    /// <summary>free.</summary>
    [JsonPropertyName("free")]
    public string? Free { get; set; }

    /// <summary>interest.</summary>
    [JsonPropertyName("interest")]
    public string? Interest { get; set; }

    /// <summary>locked.</summary>
    [JsonPropertyName("locked")]
    public string? Locked { get; set; }

    /// <summary>net Asset.</summary>
    [JsonPropertyName("netAsset")]
    public string? NetAsset { get; set; }
}
