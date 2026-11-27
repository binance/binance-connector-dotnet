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

[JsonConverter(typeof(OneOfConverter<TickerTradingDayResponse>))]
public sealed class TickerTradingDayResponse : OneOf
{
    /// <inheritdoc/>
    protected override JsonSerializerContext Context => SpotRestApiJson.Default;

    private static readonly Type[] AlternativeList = [typeof(TickerTradingDayResponse1), typeof(List<TickerTradingDayResponse2Inner>)];

    /// <inheritdoc/>
    protected override IReadOnlyList<Type> Alternatives => AlternativeList;
}
