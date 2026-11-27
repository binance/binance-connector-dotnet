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

[JsonConverter(typeof(OneOfConverter<TickerResponse>))]
public sealed class TickerResponse : OneOf
{
    /// <inheritdoc/>
    protected override JsonSerializerContext Context => SpotRestApiJson.Default;

    private static readonly Type[] AlternativeList = [typeof(TickerResponse1), typeof(List<TickerResponse2Inner>)];

    /// <inheritdoc/>
    protected override IReadOnlyList<Type> Alternatives => AlternativeList;
}
