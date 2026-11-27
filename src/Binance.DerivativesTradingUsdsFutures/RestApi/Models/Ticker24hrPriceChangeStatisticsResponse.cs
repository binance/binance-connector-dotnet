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

namespace Binance.DerivativesTradingUsdsFutures.RestApi;

[JsonConverter(typeof(OneOfConverter<Ticker24hrPriceChangeStatisticsResponse>))]
public sealed class Ticker24hrPriceChangeStatisticsResponse : OneOf
{
    /// <inheritdoc/>
    protected override JsonSerializerContext Context => DerivativesTradingUsdsFuturesRestApiJson.Default;

    private static readonly Type[] AlternativeList = [typeof(Ticker24hrPriceChangeStatisticsResponse1), typeof(List<Ticker24hrPriceChangeStatisticsResponse2Inner>)];

    /// <inheritdoc/>
    protected override IReadOnlyList<Type> Alternatives => AlternativeList;
}
