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

public sealed class GetSpotAssetTagsResponseInner
{
    /// <summary>Asset code.</summary>
    [JsonPropertyName("assetCode")]
    public string? AssetCode { get; set; }

    /// <summary>Asset name.</summary>
    [JsonPropertyName("assetName")]
    public string? AssetName { get; set; }

    /// <summary>Asset trading status. This endpoint only returns true.</summary>
    [JsonPropertyName("trading")]
    public bool? Trading { get; set; }

    /// <summary>Tags configured for the asset. Returns an empty array when the asset has no tags.</summary>
    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }
}
