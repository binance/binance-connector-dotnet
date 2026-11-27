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

namespace Binance.Spot.RestApi;

[JsonConverter(typeof(OneOfConverter<MyFiltersResponseAssetFiltersInner>))]
public sealed class MyFiltersResponseAssetFiltersInner : OneOf
{
    /// <inheritdoc/>
    protected override JsonSerializerContext Context => SpotRestApiJson.Default;

    private static readonly Type[] AlternativeList = [typeof(MaxAssetFilter)];

    /// <inheritdoc/>
    protected override IReadOnlyList<Type> Alternatives => AlternativeList;

    /// <summary>The alternative the tag filterType selects, or null when the tag is missing or unknown.</summary>
    public object? Value => Json.ValueKind == JsonValueKind.Object && Json.TryGetProperty("filterType", out var tag)
        ? tag.GetString() switch
        {
            "MAX_ASSET" => As<MaxAssetFilter>(),
            _ => null,
        }
        : null;
}
