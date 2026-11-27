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

namespace Binance.Spot.WebSocketApi;

[JsonConverter(typeof(OneOfConverter<Ticker24hrResponseResult>))]
public sealed class Ticker24hrResponseResult : OneOf
{
    /// <inheritdoc/>
    protected override JsonSerializerContext Context => SpotWebSocketApiJson.Default;

    private static readonly Type[] AlternativeList = [typeof(Ticker24hrResponse1Result), typeof(List<Ticker24hrResponse2ResultInner>)];

    /// <inheritdoc/>
    protected override IReadOnlyList<Type> Alternatives => AlternativeList;
}
