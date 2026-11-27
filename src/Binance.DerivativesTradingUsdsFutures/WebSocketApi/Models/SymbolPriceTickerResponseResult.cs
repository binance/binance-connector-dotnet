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

namespace Binance.DerivativesTradingUsdsFutures.WebSocketApi;

[JsonConverter(typeof(OneOfConverter<SymbolPriceTickerResponseResult>))]
public sealed class SymbolPriceTickerResponseResult : OneOf
{
    /// <inheritdoc/>
    protected override JsonSerializerContext Context => DerivativesTradingUsdsFuturesWebSocketApiJson.Default;

    private static readonly Type[] AlternativeList = [typeof(SymbolPriceTickerResponse1Result), typeof(List<SymbolPriceTickerResponse2ResultInner>)];

    /// <inheritdoc/>
    protected override IReadOnlyList<Type> Alternatives => AlternativeList;
}
